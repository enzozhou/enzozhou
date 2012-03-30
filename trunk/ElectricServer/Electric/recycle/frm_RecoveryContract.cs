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
        public frm_RecoveryContract()
        {
            InitializeComponent();
            dgvItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
            decimal dclSum = 0;
            decimal dclRowValue = 0;
            string rowValue;
            if (columnName == "UnitPrice" || columnName == "Price" || columnName == "Subsidy")
            {
                if (dgvItem.Rows[e.RowIndex].Cells["UnitPrice"].Value != null)
                {
                    rowValue = dgvItem.Rows[e.RowIndex].Cells["UnitPrice"].Value.ToString();
                    bl = decimal.TryParse(rowValue, out dclRowValue);
                    dclSum += dclRowValue;
                }
                if (dgvItem.Rows[e.RowIndex].Cells["Price"].Value != null)
                {
                    rowValue = dgvItem.Rows[e.RowIndex].Cells["Price"].Value.ToString();
                    bl = decimal.TryParse(rowValue, out dclRowValue);
                    dclSum += dclRowValue;
                }
                if (dgvItem.Rows[e.RowIndex].Cells["Subsidy"].Value != null)
                {
                    rowValue = dgvItem.Rows[e.RowIndex].Cells["Subsidy"].Value.ToString();
                    bl = decimal.TryParse(rowValue, out dclRowValue);
                    dclSum += dclRowValue;
                }
                dgvItem.Rows[e.RowIndex].Cells["SumPrice"].Value = dclSum.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (this.txtPartnerCode.Text.Trim().Length == 0)
            {
                strErr += "PartnerCode不能为空.\n";
            }
            if (this.txtPartnerName.Text.Trim().Length == 0)
            {
                strErr += "PartnerName不能为空.\n";
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
            int.TryParse(cmbOrgID.Text.ToString(), out iTmp);
            model.OrgID = iTmp;
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
                model.ContractNo = "RC" + global.GenerateCode(bll.GetMaxId().ToString());
                bll.Add(model);
            }
            else
            {
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
                        modelDetail.OrgID = model.OrgID;
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
            cmbOrgID.SelectedValue = _model.OrgID.ToString();
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
            _contractNo = _model.ContractNo;
            //Detail
            DataSet _ds = new Electric.BLL.BS_RecoveryContract_Details().GetList(string.Format("ContractNo='{0}'", _model.ContractNo));
            dgvItem.DataSource = _ds;
            dgvItem.DataMember = "ds";

            //
            this.dgvItem.Columns["Model"].HeaderText = "型号";
            this.dgvItem.Columns["Qty"].HeaderText = "台数";
            this.dgvItem.Columns["PowerRating"].HeaderText = "额定功率";
            this.dgvItem.Columns["UnitPrice"].HeaderText = "回收单价";
            this.dgvItem.Columns["Price"].HeaderText = "回收金额";
            this.dgvItem.Columns["BuyPower"].HeaderText = "购买电机功率";
            this.dgvItem.Columns["Subsidy"].HeaderText = "补贴";
            this.dgvItem.Columns["SumPrice"].HeaderText = "合计金额";
            this.dgvItem.Columns["OrgID"].HeaderText = "公司ID";
            this.dgvItem.Columns["ContractNo"].HeaderText = "合同编号";

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

        private void label7_Click(object sender, EventArgs e)
        {

        }


    }
}
