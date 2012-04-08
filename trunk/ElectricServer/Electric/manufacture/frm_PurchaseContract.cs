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
    public partial class frm_PurchaseContract : Form
    {
        public frm_PurchaseContract()
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

            if (columnName == "PowerRating")
            {
                decimal i = 0;
                if (e.FormattedValue.ToString() != "" && !decimal.TryParse(e.FormattedValue.ToString(), out  i))
                {
                    e.Cancel = true;
                    dgvItem.Rows[e.RowIndex].ErrorText = "额定功率数据格式错误";
                }
            }
            if (columnName == "UnitPrice")
            {
                decimal i = 0;
                if (e.FormattedValue.ToString() != "" && !decimal.TryParse(e.FormattedValue.ToString(), out  i))
                {
                    e.Cancel = true;
                    dgvItem.Rows[e.RowIndex].ErrorText = "销售单价数据格式错误";
                }
            }
            if (columnName == "Price")
            {
                decimal i = 0;
                if (e.FormattedValue.ToString() != "" && !decimal.TryParse(e.FormattedValue.ToString(), out  i))
                {
                    e.Cancel = true;
                    dgvItem.Rows[e.RowIndex].ErrorText = "销售金额数据格式错误";
                }
            }
            if (columnName == "Subsidy")
            {
                decimal i = 0;
                if (e.FormattedValue.ToString() != "" && !decimal.TryParse(e.FormattedValue.ToString(), out  i))
                {
                    e.Cancel = true;
                    dgvItem.Rows[e.RowIndex].ErrorText = "补贴数据格式错误";
                }
            }
            if (columnName == "SumPrice")
            {
                decimal i = 0;
                if (e.FormattedValue.ToString() != "" && !decimal.TryParse(e.FormattedValue.ToString(), out  i))
                {
                    e.Cancel = true;
                    dgvItem.Rows[e.RowIndex].ErrorText = "合计金额数据格式错误";
                }
            }
        }

        private void dgvItem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvItem.Rows[e.RowIndex].ErrorText = "";
            string columnName = dgvItem.Columns[e.ColumnIndex].Name;
            //编辑的行为金额时候计算合计
            bool bl = false;
            int qty = 0;
            decimal unitPrice = 0;
            decimal price = 0;
            decimal powerRating = 0;
            decimal subSidy = 0;
            decimal dclSum = 0;
            decimal dclRowValue = 0;
            string rowValue;
            if (columnName == "UnitPrice" || columnName == "Price" || columnName == "PowerRating" || columnName == "qty")
            {
                if (dgvItem.Rows[e.RowIndex].Cells["qty"].Value != null)
                {
                    rowValue = dgvItem.Rows[e.RowIndex].Cells["qty"].Value.ToString();
                    bl = int.TryParse(rowValue, out qty);
                    
                }
                if (dgvItem.Rows[e.RowIndex].Cells["UnitPrice"].Value != null)
                {
                    rowValue = dgvItem.Rows[e.RowIndex].Cells["UnitPrice"].Value.ToString();
                    bl = decimal.TryParse(rowValue, out unitPrice);
                    
                }
                //if (dgvItem.Rows[e.RowIndex].Cells["Price"].Value != null)
                //{
                //    rowValue = dgvItem.Rows[e.RowIndex].Cells["Price"].Value.ToString();
                //    bl = decimal.TryParse(rowValue, out dclRowValue);
                //    dclSum += dclRowValue;
                //}
                if (dgvItem.Rows[e.RowIndex].Cells["PowerRating"].Value != null)
                {
                    rowValue = dgvItem.Rows[e.RowIndex].Cells["PowerRating"].Value.ToString();
                    bl = decimal.TryParse(rowValue, out powerRating);
                    
                }
                price = qty*unitPrice;
                dgvItem.Rows[e.RowIndex].Cells["Price"].Value = price;
                subSidy = powerRating*45;
                dgvItem.Rows[e.RowIndex].Cells["SubSidy"].Value = subSidy;
                dclSum = price + subSidy;
                dgvItem.Rows[e.RowIndex].Cells["SumPrice"].Value = dclSum.ToString();
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (this.txtContractNo.Text.Trim().Length == 0)
            {
                strErr += "合同编号不能为空.\n";
            }
            if (this.txtPartnerCode.Text.Trim().Length == 0)
            {
                strErr += "采购方代码不能为空.\n";
            }
            if (this.txtPartnerName.Text.Trim().Length == 0)
            {
                strErr += "采购方名称不能为空.\n";
            }
            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }
            Electric.BLL.BS_PurchaseContract bll = new Electric.BLL.BS_PurchaseContract();
            Electric.BLL.BS_PurchaseContract_Details bllDetail = new Electric.BLL.BS_PurchaseContract_Details();
            Electric.Model.BS_PurchaseContract model = new Electric.Model.BS_PurchaseContract();

            int iTmp = 0;
            int.TryParse(global.ConvertObject(txtCheckedLimit.Text), out iTmp);
            model.CheckedLimit = iTmp;
            model.ContractNo = txtContractNo.Text;
            decimal dcl = 0;
            decimal.TryParse(txtDamagesRate.Text, out dcl);
            model.DamagesRate = dcl;
            int.TryParse(global.ConvertObject(txtDeliveryTime.Text), out iTmp);
            model.DeliveryTime = iTmp;
            int.TryParse(txtFPP.Text, out iTmp);
            model.FPP = iTmp;
            decimal.TryParse(txtFPR.Text, out dcl);
            model.FPR = dcl;
            int.TryParse(txtLPP.Text, out iTmp);
            model.LPP = iTmp;
            decimal.TryParse(txtLPR.Text, out dcl);
            model.LPR = dcl;
            model.OrgCode = global.OrganizationCode;
            model.PartnerAccount = txtPartnerAccount.Text;
            model.PartnerAddress = txtPartnerAddress.Text;
            model.PartnerBank = txtPartnerBank.Text;
            model.PartnerCode = txtPartnerCode.Text;
            model.PartnerContract = txtPartnerContract.Text;
            model.PartnerName = txtPartnerName.Text;
            model.PartnerTaxNo = txtPartnerTaxNo.Text;
            model.PartnerTel = txtPartnerTel.Text;
            decimal.TryParse(txtPrice.Text, out dcl);
            model.Price = dcl;
            decimal.TryParse(txtSPR.Text, out dcl);
            model.SPR = dcl;
            model.Words = txtWords.Text;
            model.BearCost = txtBearCost.Text;
            model.ContractNo = txtContractNo.Text;

            //model.ApproveTime = DateTime.Now;
            //model.ApproveUserID = global.UserID;
            //model.SubmitTime = DateTime.Now();
            //model.SubmitUserID = global.UserID;

            if (!_isupdate)
            {
                model.CreateTime = DateTime.Now;
                model.CreateUserID = global.UserID;
                //model.ContractNo = "PC" + global.GenerateCode(bll.GetMaxId().ToString());
                bll.Add(model);
            }
            else
            {
                model.UpdateTime = DateTime.Now;
                model.UpdateUserID = global.UserID;
                model.ContractNo = _contractNo;
                bll.Update(model);
            }

            //保存Item
            Electric.Model.BS_PurchaseContract_Details modelDetail;
            bool bl = dgvItem.Columns.Contains("ID");//判断是要新增还是修改
            foreach (DataGridViewRow item in dgvItem.Rows)
            {
                if (!item.IsNewRow)
                {
                    if (item.Cells["Model"].Value != null || item.Cells["Qty"].Value != null || item.Cells["PowerRating"].Value != null || item.Cells["UnitPrice"].Value != null || item.Cells["Price"].Value != null || item.Cells["Subsidy"].Value != null || item.Cells["SumPrice"].Value != null)
                    {
                        modelDetail = new Electric.Model.BS_PurchaseContract_Details();
                        modelDetail.OrgCode = model.OrgCode;
                        modelDetail.Model = global.ConvertObject(item.Cells["Model"].Value);
                        int.TryParse(global.ConvertObject(item.Cells["Qty"].Value), out iTmp);
                        modelDetail.Qty = iTmp;
                        decimal.TryParse(global.ConvertObject(item.Cells["PowerRating"].Value), out dcl);
                        modelDetail.PowerRating = dcl;
                        decimal.TryParse(global.ConvertObject(item.Cells["UnitPrice"].Value), out dcl);
                        modelDetail.UnitPrice = dcl;
                        decimal.TryParse(global.ConvertObject(item.Cells["Price"].Value), out dcl);
                        modelDetail.Price = dcl;
                        decimal.TryParse(global.ConvertObject(item.Cells["Subsidy"].Value), out dcl);
                        modelDetail.Subsidy = dcl;
                        decimal.TryParse(global.ConvertObject(item.Cells["SumPrice"].Value), out dcl);
                        modelDetail.SumPrice = dcl;
                        modelDetail.ContractNo = model.ContractNo;


                        if (modelDetail.Model != "" || modelDetail.Qty > 0 || modelDetail.PowerRating > 0 || modelDetail.UnitPrice > 0 || modelDetail.Price > 0 || modelDetail.Subsidy > 0 || modelDetail.SumPrice > 0)
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
            this.ResetText();////////
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
            Electric.Model.BS_PurchaseContract _model = new Electric.BLL.BS_PurchaseContract().GetModel(_id);
            _contractNo = _model.ContractNo;
            txtWords.Text = _model.Words;
            txtSPR.Text = _model.SPR.ToString();
            txtPrice.Text = _model.Price.ToString();
            txtPartnerTel.Text = _model.PartnerTel;
            txtPartnerTaxNo.Text = _model.PartnerTaxNo;
            txtPartnerName.Text = _model.PartnerName;
            txtPartnerContract.Text = _model.PartnerContract;
            txtPartnerCode.Text = _model.PartnerCode;
            txtPartnerBank.Text = _model.PartnerBank;
            txtPartnerAddress.Text = _model.PartnerAddress;
            txtPartnerAccount.Text = _model.PartnerAccount;
            txtLPR.Text = _model.LPR.ToString();
            txtLPP.Text = _model.LPP.ToString();
            txtFPR.Text = _model.FPR.ToString();
            txtFPP.Text = _model.FPP.ToString();
            txtDeliveryTime.Text = _model.DeliveryTime.ToString();
            txtDamagesRate.Text = _model.DamagesRate.ToString();
            txtContractNo.Text = _model.ContractNo;
            txtContractNo.ReadOnly = true;
            txtCheckedLimit.Text = _model.CheckedLimit.ToString();
            txtBearCost.Text = _model.BearCost;

            //Detail
            DataSet _ds = new Electric.BLL.BS_PurchaseContract_Details().GetList(string.Format("ContractNo='{0}'", _model.ContractNo));
            dgvItem.DataSource = _ds;
            dgvItem.DataMember = "ds";

            //
            this.dgvItem.Columns["OrgCode"].HeaderText = "公司ID";
            this.dgvItem.Columns["ContractNo"].HeaderText = "合同编号";
            this.dgvItem.Columns["Qty"].HeaderText = "台数";
            this.dgvItem.Columns["PowerRating"].HeaderText = "额定功率";
            this.dgvItem.Columns["UnitPrice"].HeaderText = "销售单价";
            this.dgvItem.Columns["Price"].HeaderText = "销售金额";
            this.dgvItem.Columns["Subsidy"].HeaderText = "补贴";
            this.dgvItem.Columns["SumPrice"].HeaderText = "合计金额";

            this.dgvItem.Columns["ContractNo"].Visible = false;
            this.dgvItem.Columns["OrgCode"].Visible = false;
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

        private void txtPartnerCode_MouseDoubleClick(object sender, MouseEventArgs e)
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

        private void txtPartnerName_MouseDoubleClick(object sender, MouseEventArgs e)
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

        private void frm_PurchaseContract_Load(object sender, EventArgs e)
        {
            DataSet _ds = new Electric.BLL.BAS_Partner().GetList("");
            DataTable dtPartner = _ds.Tables[0];
            lstPartner.DataSource = dtPartner;
            lstPartner.DisplayMember = "Name";
            lstPartner.ValueMember = "Code";
            lstPartner.Visible = false;

            dgvItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            txtOrg.Text = global.OrganizationName;
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

        private void dgvItem_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            decimal sumPrice = 0;
            decimal price = 0;
            bool bl = false;
            if (dgvItem.Rows.Count>0)
            {
                for(int i=0;i<dgvItem.Rows.Count-1 ;i++)
                {
                    bl = decimal.TryParse(dgvItem.Rows[i].Cells["SumPrice"].Value.ToString(), out price);
                    sumPrice = sumPrice + price;
                }
            }
            txtPrice.Text = sumPrice.ToString("f2");
            txtWords.Text = Maticsoft.Common.Rmb.CmycurD(txtPrice.Text);
        }

        private void txtFPR_Validated(object sender, EventArgs e)
        {
            SumPrepaidRatio("LPR");
        }

        private void txtSPR_Validated(object sender, EventArgs e)
        {
            SumPrepaidRatio("LPR");
        }

    }
}
