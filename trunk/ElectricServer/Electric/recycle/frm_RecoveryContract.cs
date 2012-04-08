using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Electric
{
    public partial class frm_RecoveryContract : Form
    {
        decimal dclSubsidy = 0;

        public frm_RecoveryContract()
        {
            InitializeComponent();
        }

        private void FillLst()
        {
            DataTable dtPartner = QueryPartnerInfo(txtPartnerName.Text);
            if (dtPartner.Rows.Count == 1)
            {
                LoadPartnerInfo(dtPartner.Rows[0]);
            }
            else if (dtPartner.Rows.Count > 1)
            {
                lstPartner.Visible = true;
            }
            else
            {
                LoadPartnerInfo(null);
                
            }
        }

        private DataTable QueryPartnerInfo(string code)
        {
            DataSet _ds = new Electric.BLL.BAS_Partner().GetList("Code = '" + code + "' or Name like '%" + code + "%'");
            DataTable dtPartner = _ds.Tables[0];
            return dtPartner;
        }

        /// <summary>
        /// Load合作伙伴信息 FZ20120405
        /// </summary>
        /// <param name="row"></param>
        private void LoadPartnerInfo(DataRow row)
        {
            if (row != null)
            {
                lstPartner.Visible = false;
                txtPartnerCode.Text = row["Code"].ToString();
                txtPartnerName.Text = row["Name"].ToString();
                txtPartnerContract.Text = row["Contract"].ToString();
                txtPartnerTel.Text = row["Tel"].ToString();
                txtPartnerTaxNo.Text = row["TaxNo"].ToString();
                txtPartnerBank.Text = row["BankName"].ToString();
                txtPartnerAccount.Text = row["Account"].ToString();
                txtPartnerAddress.Text = row["Address"].ToString();
            }
            else
            {
                lstPartner.Visible = false;
                txtPartnerCode.Text = "";
                txtPartnerName.Text = "";
                txtPartnerContract.Text = "";
                txtPartnerTel.Text = "";
                txtPartnerTaxNo.Text = "";
                txtPartnerBank.Text = "";
                txtPartnerAccount.Text = "";
                txtPartnerAddress.Text = "";
            }
        }

        private void SumPrepaidRatio(string sentClase)
        {
            decimal fpr = 0;
            decimal spr = 0;
            decimal lpr = 0;

            bool bl = false;

            bl = decimal.TryParse(txtFPR.Text.Trim(), out fpr);
            bl = decimal.TryParse(txtSPR.Text.Trim(), out spr);
            bl = decimal.TryParse(txtLPR.Text.Trim(), out lpr);

            if (sentClase == "FPR")
            {
                fpr = 100 - spr - lpr;
                txtFPR.Text = fpr.ToString();
            }
            else if (sentClase == "SPR")
            {
                spr = 100 - fpr - lpr;
                txtSPR.Text = spr.ToString();
            }
            else if (sentClase == "LPR")
            {
                lpr = 100 - fpr - spr;
                txtLPR.Text = lpr.ToString();
            }
        }


        private void dgvItem_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string columnName = dgvItem.Columns[e.ColumnIndex].Name;
            //检查数字
            if (columnName == "Qty")
            {
                int i = 0;
                if (e.FormattedValue.ToString() != "" && !int.TryParse(e.FormattedValue.ToString(), out  i))
                {
                    e.Cancel = true;
                    dgvItem.Rows[e.RowIndex].ErrorText = "台数数据格式错误";
                }
            }
            //编辑的行为金额时候计算合计
            bool bl = false;
            string rowValue;
            decimal dclRowValue = 0;
            if (e.FormattedValue.ToString() != "" && columnName == "UnitPrice")
            {
                rowValue = e.FormattedValue.ToString();
                bl = decimal.TryParse(rowValue, out dclRowValue);
                if (!bl)
                {
                    e.Cancel = true;
                    dgvItem.Rows[e.RowIndex].ErrorText = "回收单价数据格式错误";
                }
            }
            if (e.FormattedValue.ToString() != "" && columnName == "Price")
            {

                rowValue = e.FormattedValue.ToString();
                bl = decimal.TryParse(rowValue, out dclRowValue);
                if (!bl)
                {
                    e.Cancel = true;
                    dgvItem.Rows[e.RowIndex].ErrorText = "回收金额数据格式错误";
                }
            }
            if (e.FormattedValue.ToString() != "" && columnName == "Subsidy")
            {
                rowValue = e.FormattedValue.ToString();
                bl = decimal.TryParse(rowValue, out dclRowValue);
                if (!bl)
                {
                    e.Cancel = true;
                    dgvItem.Rows[e.RowIndex].ErrorText = "补贴数据格式错误";
                }
            }
        }

        private void dgvItem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvItem.Rows[e.RowIndex].ErrorText = "";
            string columnName = dgvItem.Columns[e.ColumnIndex].Name;
            //编辑的行为金额时候计算合计
            bool bl = false;
            string rowValue;
            if (columnName == "Qty" || columnName == "UnitPrice" || columnName == "BuyPower" || columnName == "PowerRating")
            {
                decimal dclQty = 0;
                decimal dcPR = 0;
                decimal dcTotalPR = 0;
                decimal dclUnitPrice = 0, dclBuyPower = 0;
                decimal dclPrice = 0, dclSumSubsidy = 0;
                if (dgvItem.Rows[e.RowIndex].Cells["Qty"].Value != null)
                {
                    rowValue = dgvItem.Rows[e.RowIndex].Cells["Qty"].Value.ToString();
                    bl = decimal.TryParse(rowValue, out dclQty);

                    if (dgvItem.Rows[e.RowIndex].Cells["UnitPrice"].Value != null)
                    {
                        rowValue = dgvItem.Rows[e.RowIndex].Cells["UnitPrice"].Value.ToString();
                        bl = decimal.TryParse(rowValue, out dclUnitPrice);
                        dclPrice = dclQty * dclUnitPrice;
                        dgvItem.Rows[e.RowIndex].Cells["Price"].Value = dclPrice;
                    }
                    if (dgvItem.Rows[e.RowIndex].Cells["PowerRating"].Value != null)
                    {
                        rowValue = dgvItem.Rows[e.RowIndex].Cells["PowerRating"].Value.ToString();
                        bl = decimal.TryParse(rowValue, out dclBuyPower);
                        dclSumSubsidy = dclQty * dclBuyPower * dclSubsidy;
                        dgvItem.Rows[e.RowIndex].Cells["Subsidy"].Value = dclSumSubsidy;
                    }

                    dgvItem.Rows[e.RowIndex].Cells["SumPrice"].Value = dclPrice + dclSumSubsidy;

                    //if (dgvItem.Rows[e.RowIndex].Cells["UnitPrice"].Value != null &&
                    //dgvItem.Rows[e.RowIndex].Cells["BuyPower"].Value != null)
                    //{
                    //    rowValue = dgvItem.Rows[e.RowIndex].Cells["UnitPrice"].Value.ToString();
                    //    bl = decimal.TryParse(rowValue, out dclUnitPrice);
                    //    rowValue = dgvItem.Rows[e.RowIndex].Cells["BuyPower"].Value.ToString();
                    //    bl = decimal.TryParse(rowValue, out dclBuyPower);
                    //    dclPrice = dclQty*dclUnitPrice;
                    //    dgvItem.Rows[e.RowIndex].Cells["Price"].Value = dclPrice;
                    //    dclSumSubsidy = dclQty*dclBuyPower*dclSubsidy;
                    //    dgvItem.Rows[e.RowIndex].Cells["Subsidy"].Value = dclSumSubsidy;
                    //    dgvItem.Rows[e.RowIndex].Cells["SumPrice"].Value = dclPrice + dclSumSubsidy;
                    //}
                    //else if (dgvItem.Rows[e.RowIndex].Cells["PowerRating"].Value != null)
                    //{
                    //    rowValue = dgvItem.Rows[e.RowIndex].Cells["PowerRating"].Value.ToString();
                    //    bl = decimal.TryParse(rowValue, out dcPR);
                    //    dcTotalPR = dcPR*dclQty*20;
                    //    dgvItem.Rows[e.RowIndex].Cells["Subsidy"].Value 
                    //}
                }

                CaclulateSub();
            }
        }
        /// <summary>
        /// 计算item 合计到head
        /// </summary>
        private void CaclulateSub()
        {
            bool bl = false;
            decimal dcl_TotalPrice = 0;
            decimal dclRowValue = 0;
            foreach (DataGridViewRow item in dgvItem.Rows)
            {
                bl = decimal.TryParse(global.ConvertObject(item.Cells["SumPrice"].Value), out dclRowValue);
                dcl_TotalPrice += dclRowValue;
            }
            txtPrice.Text = dcl_TotalPrice.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (this.txtPartnerCode.Text.Trim().Length == 0)
            {
                strErr += "交售方代码不能为空.\n";
            }
            if (this.txtPartnerName.Text.Trim().Length == 0)
            {
                strErr += "交售方名称不能为空.\n";
            }
            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }
            Electric.BLL.BS_RecoveryContract bll = new Electric.BLL.BS_RecoveryContract();
            Electric.BLL.BS_RecoveryContract_Details bllDetail = new Electric.BLL.BS_RecoveryContract_Details();
            Electric.Model.BS_RecoveryContract model = new Electric.Model.BS_RecoveryContract();
            int iTmp = 0;
            int.TryParse(txtFPP.Text, out iTmp);
            model.FPP = iTmp;
            int.TryParse(txtFPR.Text, out iTmp);
            model.FPR = iTmp;
            int.TryParse(txtLPP.Text, out iTmp);
            model.LPP = iTmp;
            int.TryParse(txtLPR.Text, out iTmp);
            model.LPR = iTmp;
            model.OrgCode = global.OrganizationCode;
            model.PartnerAccount = txtPartnerAccount.Text;
            model.PartnerAddress = txtPartnerAddress.Text;
            model.PartnerBank = txtPartnerBank.Text;
            model.PartnerCode = txtPartnerCode.Text;
            model.PartnerContract = txtPartnerContract.Text;
            model.PartnerName = txtPartnerName.Text;
            model.PartnerTaxNo = txtPartnerTaxNo.Text;
            model.PartnerTel = txtPartnerTel.Text;
            decimal dclTmp = 0;
            decimal.TryParse(txtPrice.Text, out dclTmp);
            model.Price = dclTmp;
            decimal.TryParse(txtSPR.Text, out dclTmp);
            model.SPR = dclTmp;
            model.Words = txtWords.Text;
            int.TryParse(txtSPP.Text, out iTmp);
            model.SPP = iTmp;
            int.TryParse(txtDeliveryTerm.Text, out iTmp);
            model.DeliveryTerm = iTmp;
            if (!_isupdate)
            {
                txtContractNo.Text = "RC" + global.GenerateCode(bll.GetMaxId().ToString());
                model.ContractNo = txtContractNo.Text;
                bll.Add(model);
            }
            else
            {
                model.ID = _id;
                model.ContractNo = _contractNo;
                bll.Update(model);
            }

            //保存Item
            Electric.Model.BS_RecoveryContract_Details modelDetail;
            bool bl = dgvItem.Columns.Contains("ID");//判断是要新增还是修改
            foreach (DataGridViewRow item in dgvItem.Rows)
            {
                if (!item.IsNewRow)
                {
                    if (item.Cells["Model"].Value != null || item.Cells["Qty"].Value != null || item.Cells["Price"].Value != null || item.Cells["UnitPrice"].Value != null || item.Cells["SumPrice"].Value != null || item.Cells["PowerRating"].Value != null || item.Cells["BuyPower"].Value != null)
                    {
                        modelDetail = new Electric.Model.BS_RecoveryContract_Details();
                        modelDetail.Model = global.ConvertObject(item.Cells["Model"].Value);
                        modelDetail.OrgCode = model.OrgCode;
                        int.TryParse(global.ConvertObject(item.Cells["Qty"].Value), out iTmp);
                        modelDetail.Qty = iTmp;
                        decimal.TryParse(global.ConvertObject(item.Cells["Price"].Value), out dclTmp);
                        modelDetail.Price = dclTmp;
                        decimal.TryParse(global.ConvertObject(item.Cells["PowerRating"].Value), out dclTmp);
                        modelDetail.PowerRating = dclTmp;
                        decimal.TryParse(global.ConvertObject(item.Cells["UnitPrice"].Value), out dclTmp);
                        modelDetail.UnitPrice = dclTmp;
                        decimal.TryParse(global.ConvertObject(item.Cells["SumPrice"].Value), out dclTmp);
                        modelDetail.SumPrice = dclTmp;
                        decimal.TryParse(global.ConvertObject(item.Cells["Subsidy"].Value), out dclTmp);
                        modelDetail.Subsidy = dclTmp;
                        decimal.TryParse(global.ConvertObject(item.Cells["BuyPower"].Value), out dclTmp);
                        modelDetail.BuyPower = dclTmp;
                        modelDetail.ContractNo = model.ContractNo;
                        if (modelDetail.BuyPower > 0 || modelDetail.PowerRating > 0 || modelDetail.Price > 0 || modelDetail.Qty > 0 || modelDetail.Subsidy > 0 || modelDetail.SumPrice > 0 || modelDetail.UnitPrice > 0 || modelDetail.Model.Trim() != "")
                        {
                            if (!bl)
                            {
                                bllDetail.Add(modelDetail);
                            }
                            else
                            {
                                int.TryParse(item.Cells["ID"].Value.ToString(), out iTmp);
                                modelDetail.ID = iTmp;
                                bllDetail.Delete(iTmp);
                                bllDetail.Add(modelDetail);
                            }
                        }
                        else
                        {
                            int.TryParse(item.Cells["ID"].Value.ToString(), out iTmp);
                            bllDetail.Delete(iTmp);
                        }
                    }
                }
            }
            MessageBox.Show("保存成功.");
        }

        private int _id = 0;
        public int ID
        {
            set
            {
                _id = value;
                showUpdate();
            }
        }

        private bool _isupdate = false;
        public bool isUpdate
        {
            set { _isupdate = value; }
        }

        private string _contractNo = "";
        private void showUpdate()
        {
            //Head
            Electric.Model.BS_RecoveryContract _model = new Electric.BLL.BS_RecoveryContract().GetModel(_id);
            txtDeliveryTerm.Text = _model.DeliveryTerm.ToString();
            txtFPP.Text = _model.FPP.ToString();
            txtFPR.Text = _model.FPR.ToString();
            txtLPP.Text = _model.LPP.ToString();
            txtLPR.Text = _model.LPR.ToString();
            txtPartnerAccount.Text = _model.PartnerAccount;
            txtPartnerAddress.Text = _model.PartnerAddress;
            txtPartnerBank.Text = _model.PartnerBank;
            txtPartnerCode.Text = _model.PartnerCode;
            txtPartnerContract.Text = _model.PartnerContract;
            txtPartnerName.Text = _model.PartnerName;
            txtPartnerTaxNo.Text = _model.PartnerTaxNo;
            txtPartnerTel.Text = _model.PartnerTel;
            txtPrice.Text = _model.Price.ToString();
            txtSPP.Text = _model.SPP.ToString();
            txtSPR.Text = _model.SPR.ToString();
            txtWords.Text = _model.Words;
            txtContractNo.Text = _model.ContractNo;
            _contractNo = _model.ContractNo;
            //Detail
            DataSet _ds = new Electric.BLL.BS_RecoveryContract_Details().GetList(string.Format("ContractNo='{0}'", _model.ContractNo));
            dgvItem.DataSource = _ds;
            dgvItem.DataMember = "ds";
            this.dgvItem.Columns["Subsidy"].ReadOnly = true;
            this.dgvItem.Columns["SumPrice"].ReadOnly = true;

            this.dgvItem.Columns["Model"].HeaderText = "型号(Type)";
            this.dgvItem.Columns["Qty"].HeaderText = "台数";
            this.dgvItem.Columns["PowerRating"].HeaderText = "额定功率(kW)";
            this.dgvItem.Columns["UnitPrice"].HeaderText = "旧电机回收单价(元/台)";
            this.dgvItem.Columns["Price"].HeaderText = "回收资金小计(元)";
            this.dgvItem.Columns["BuyPower"].HeaderText = "新购高效电机功率(含再制造高效电机)(kW)";
            this.dgvItem.Columns["Subsidy"].HeaderText = "以旧换新补贴金额(元)";
            this.dgvItem.Columns["SumPrice"].HeaderText = "合计";
            this.dgvItem.Columns["OrgCode"].HeaderText = "公司ID";
            this.dgvItem.Columns["ContractNo"].HeaderText = "合同编号";

            this.dgvItem.Columns["OrgCode"].Visible = false;
            this.dgvItem.Columns["ContractNo"].Visible = false;
            this.dgvItem.Columns["ID"].Visible = false;
            this.dgvItem.Columns["CreateUserID"].Visible = false;
            this.dgvItem.Columns["CreateTime"].Visible = false;
            this.dgvItem.Columns["UpdateUserID"].Visible = false;
            this.dgvItem.Columns["UpdateTime"].Visible = false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_RecoveryContract_Load(object sender, EventArgs e)
        {
            dgvItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            txtOrg.Text = global.OrganizationName;

            DataSet _ds = new Electric.BLL.BAS_Partner().GetList("");
            DataTable dtPartner = _ds.Tables[0];
            lstPartner.DataSource = dtPartner;
            lstPartner.DisplayMember = "Name";
            lstPartner.ValueMember = "Code";
            lstPartner.Visible = false;

            DataView dvCode = global.dtCodes.DefaultView;
            dvCode.RowFilter = "SelectCode='BCP00006'";
            if (dvCode.Count > 0)
            {
                bool bl = decimal.TryParse(dvCode[dvCode.Count - 1]["Description"].ToString(), out dclSubsidy);

            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            txtWords.Text = Maticsoft.Common.Rmb.CmycurD(txtPrice.Text);
        }

        private void txtPartnerCode_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void txtPartnerCode_Validated(object sender, EventArgs e)
        {
            DataTable dtPartner = QueryPartnerInfo(txtPartnerCode.Text);
            if (dtPartner.Rows.Count == 1)
            {
                LoadPartnerInfo(dtPartner.Rows[0]);
            }
            //else if (dtPartner.Rows.Count > 1)
            //{
            //    lstPartner.Visible = true;
            //}
            else
            {
                LoadPartnerInfo(null);
                if (txtPartnerCode.Text != string.Empty)
                {
                    txtPartnerCode.Focus();
                }
            }
        }

        private void lstPartner_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataTable dtPartner = QueryPartnerInfo(lstPartner.SelectedValue.ToString());
            if (dtPartner.Rows.Count == 1)
            {
                LoadPartnerInfo(dtPartner.Rows[0]);
                lstPartner.Visible = false;
            }
        }



        private void dgvItem_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int _id = 0;
                if (int.TryParse(dgvItem.Rows[e.RowIndex].Cells["ID"].Value.ToString(), out _id))
                {
                    frm_RecoveryContract_DetailView _frm = new frm_RecoveryContract_DetailView();
                    _frm.ID = _id;
                    _frm.ShowDialog();
                }

                //_id = int.Parse(item.Cells["ID"].Value.ToString());


            }
        }

        private void txtPartnerName_DoubleClick(object sender, EventArgs e)
        {
            FillLst();
            if (txtPartnerName.Text != string.Empty)
            {
                txtPartnerCode.Focus();
            }
        }

        private void txtPartnerName_Validated(object sender, EventArgs e)
        {
            FillLst();
            if (txtPartnerName.Text != string.Empty)
            {
                txtPartnerCode.Focus();
            }
        }

        private void txtFPR_Validated(object sender, EventArgs e)
        {
            SumPrepaidRatio("LPR");
        }

        private void txtSPR_Validated(object sender, EventArgs e)
        {
            SumPrepaidRatio("LPR");
        }

        private void txtLPR_Validated(object sender, EventArgs e)
        {
            //SumPrepaidRatio("LPR");
        }
    }
}
