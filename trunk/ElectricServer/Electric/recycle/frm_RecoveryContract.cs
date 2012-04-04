﻿using System;
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
            decimal dclSubsidy = 20;
            dgvItem.Rows[e.RowIndex].ErrorText = "";
            string columnName = dgvItem.Columns[e.ColumnIndex].Name;
            //编辑的行为金额时候计算合计
            bool bl = false;
            string rowValue;
            if (columnName == "Qty" || columnName == "UnitPrice" || columnName == "BuyPower")
            {
                decimal dclQty = 0, dclUnitPrice = 0, dclBuyPower = 0;
                decimal dclPrice = 0, dclSumSubsidy = 0;
                if (dgvItem.Rows[e.RowIndex].Cells["Qty"].Value != null &&
                    dgvItem.Rows[e.RowIndex].Cells["UnitPrice"].Value != null &&
                        dgvItem.Rows[e.RowIndex].Cells["BuyPower"].Value != null)
                {
                    rowValue = dgvItem.Rows[e.RowIndex].Cells["Qty"].Value.ToString();
                    bl = decimal.TryParse(rowValue, out dclQty);
                    rowValue = dgvItem.Rows[e.RowIndex].Cells["UnitPrice"].Value.ToString();
                    bl = decimal.TryParse(rowValue, out dclUnitPrice);
                    rowValue = dgvItem.Rows[e.RowIndex].Cells["BuyPower"].Value.ToString();
                    bl = decimal.TryParse(rowValue, out dclBuyPower);
                    dclPrice = dclQty * dclUnitPrice;
                    dgvItem.Rows[e.RowIndex].Cells["Price"].Value = dclPrice;
                    dclSumSubsidy = dclQty * dclBuyPower * dclSubsidy;
                    dgvItem.Rows[e.RowIndex].Cells["Subsidy"].Value = dclSumSubsidy;
                    dgvItem.Rows[e.RowIndex].Cells["SumPrice"].Value = dclPrice + dclSumSubsidy;
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
                model.ContractNo = "RC" + global.GenerateCode(bll.GetMaxId().ToString());
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
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            txtWords.Text = Maticsoft.Common.Rmb.CmycurD(txtPrice.Text);
        }
    }
}
