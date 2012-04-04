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
    public partial class frm_NewForOld : Form
    {
        public frm_NewForOld()
        {
            InitializeComponent();
        }


        private void frm_NewForOld_Load(object sender, EventArgs e)
        {
            dgvItem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            int _displayindex = 0;
            CalendarColumn col = new CalendarColumn();
            _displayindex = this.dgvItem.Columns["OldProtectionLev"].DisplayIndex + 1;
            this.dgvItem.Columns.Insert(_displayindex, col);
            this.dgvItem.Columns[_displayindex].Name = "OldOutDate";
            this.dgvItem.Columns[_displayindex].DataPropertyName = "OldOutDate";
            this.dgvItem.Columns[_displayindex].HeaderText = "旧电机出场年月";

            col = new CalendarColumn();
            _displayindex = this.dgvItem.Columns["NewInvoiceNo"].DisplayIndex + 1;
            this.dgvItem.Columns.Insert(_displayindex, col);
            this.dgvItem.Columns[_displayindex].Name = "NewInvoiceDate";
            this.dgvItem.Columns[_displayindex].DataPropertyName = "NewInvoiceDate";
            this.dgvItem.Columns[_displayindex].HeaderText = "新电机发票日期";

            txtTotalOldQty.ReadOnly = true;
            txtTotalNewQty.ReadOnly = true;
            txtTotalNewPowerRating.ReadOnly = true;
            txtTotalOldPrice.ReadOnly = true;
            txtTotalOldSubsidy.ReadOnly = true;
            txtTotalOldSumPrice.ReadOnly = true;
            txtTotalPurchasePrice.ReadOnly = true;

            global.BandBaseCodeComboBox(cmbOwnership, "BCP00003");
            global.BandBaseCodeComboBox(cmbBelongTo, "BCP00001");
            txtOrg.Text = global.OrganizationName;
        }

        private void dgvItem_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string columnName = dgvItem.Columns[e.ColumnIndex].Name;
            //检查数字
            if (columnName == "OldQty")
            {
                int i = 0;
                if (e.FormattedValue.ToString() != "" && !int.TryParse(e.FormattedValue.ToString(), out  i))
                {
                    e.Cancel = true;
                    dgvItem.Rows[e.RowIndex].ErrorText = "旧电机台数数据格式错误";
                }
            }
            if (columnName == "NewQty")
            {
                int i = 0;
                if (e.FormattedValue.ToString() != "" && !int.TryParse(e.FormattedValue.ToString(), out  i))
                {
                    e.Cancel = true;
                    dgvItem.Rows[e.RowIndex].ErrorText = "新电机台数数据格式错误";
                }
            }
            if (columnName == "OldPowerRating")
            {
                decimal i = 0;
                if (e.FormattedValue.ToString() != "" && !decimal.TryParse(e.FormattedValue.ToString(), out  i))
                {
                    e.Cancel = true;
                    dgvItem.Rows[e.RowIndex].ErrorText = "旧电机额定功率数据格式错误";
                }
            }
            if (columnName == "OldSpeed")
            {
                decimal i = 0;
                if (e.FormattedValue.ToString() != "" && !decimal.TryParse(e.FormattedValue.ToString(), out  i))
                {
                    e.Cancel = true;
                    dgvItem.Rows[e.RowIndex].ErrorText = "旧电机额定转速数据格式错误";
                }
            }
            if (columnName == "OldWeight")
            {
                decimal i = 0;
                if (e.FormattedValue.ToString() != "" && !decimal.TryParse(e.FormattedValue.ToString(), out  i))
                {
                    e.Cancel = true;
                    dgvItem.Rows[e.RowIndex].ErrorText = "旧电机重量数据格式错误";
                }
            }
            if (columnName == "NewPowerRating")
            {
                decimal i = 0;
                if (e.FormattedValue.ToString() != "" && !decimal.TryParse(e.FormattedValue.ToString(), out  i))
                {
                    e.Cancel = true;
                    dgvItem.Rows[e.RowIndex].ErrorText = "新电机功率数据格式错误";
                }
            }
            if (columnName == "PurchasePrice")
            {
                decimal i = 0;
                if (e.FormattedValue.ToString() != "" && !decimal.TryParse(e.FormattedValue.ToString(), out  i))
                {
                    e.Cancel = true;
                    dgvItem.Rows[e.RowIndex].ErrorText = "采购金额数据格式错误";
                }
            }
            //编辑的行为金额时候计算合计
            bool bl = false;
            string rowValue;
            decimal dclRowValue = 0;
            if (e.FormattedValue.ToString() != "" && columnName == "OldPrice")
            {
                rowValue = e.FormattedValue.ToString();
                bl = decimal.TryParse(rowValue, out dclRowValue);
                if (!bl)
                {
                    e.Cancel = true;
                    dgvItem.Rows[e.RowIndex].ErrorText = "旧电机回购小计数据格式错误";
                }
            }
            if (e.FormattedValue.ToString() != "" && columnName == "OldSubsidy")
            {

                rowValue = e.FormattedValue.ToString();
                bl = decimal.TryParse(rowValue, out dclRowValue);
                if (!bl)
                {
                    e.Cancel = true;
                    dgvItem.Rows[e.RowIndex].ErrorText = "回购补贴数据格式错误";
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
            if (columnName == "OldPrice" || columnName == "OldSubsidy")
            {
                if (dgvItem.Rows[e.RowIndex].Cells["OldPrice"].Value != null)
                {
                    rowValue = dgvItem.Rows[e.RowIndex].Cells["OldPrice"].Value.ToString();
                    bl = decimal.TryParse(rowValue, out dclRowValue);
                    dclSum += dclRowValue;
                }
                if (dgvItem.Rows[e.RowIndex].Cells["OldSubsidy"].Value != null)
                {
                    rowValue = dgvItem.Rows[e.RowIndex].Cells["OldSubsidy"].Value.ToString();
                    bl = decimal.TryParse(rowValue, out dclRowValue);
                    dclSum += dclRowValue;
                }
                dgvItem.Rows[e.RowIndex].Cells["OldSumPrice"].Value = dclSum.ToString();
                CaclulateSub();
            }
        }

        /// <summary>
        /// 计算item 合计到head
        /// </summary>
        private void CaclulateSub()
        {
            bool bl = false;
            int int_TotalOldQty = 0;//旧电机总台数
            int int_TotalNewQty = 0;//新电机台数
            decimal dcl_TotalPowerRating = 0;//旧电机总额定功率
            decimal dcl_TotalOldPrice = 0;//旧电机总回购小计
            decimal dcl_TotalOldSubsidy = 0;//旧电机总补贴
            decimal dcl_TotalOldSumPrice = 0;//回购总计
            decimal dcl_TotalNewPowerRating = 0;//新电机总功率
            decimal dcl_TotalPurchasePrice = 0; //新电机采购总金额 
            decimal dclRowValue = 0;
            int intRowValue = 0;
            foreach (DataGridViewRow item in dgvItem.Rows)
            {
                if (!item.IsNewRow)
                {

                    bl = int.TryParse(global.ConvertObject(item.Cells["OldQty"].Value), out intRowValue);
                    int_TotalOldQty += intRowValue;
                    bl = decimal.TryParse(global.ConvertObject(item.Cells["OldPrice"].Value), out dclRowValue);
                    dcl_TotalOldPrice += dclRowValue;
                    bl = decimal.TryParse(global.ConvertObject(item.Cells["OldSumPrice"].Value), out dclRowValue);
                    dcl_TotalOldSumPrice += dclRowValue;
                    bl = decimal.TryParse(global.ConvertObject(item.Cells["OldSubsidy"].Value), out dclRowValue);
                    dcl_TotalOldSubsidy += dclRowValue;
                    bl = decimal.TryParse(global.ConvertObject(item.Cells["OldPowerRating"].Value), out dclRowValue);
                    dcl_TotalPowerRating += dclRowValue;

                    bl = int.TryParse(global.ConvertObject(item.Cells["NewQty"].Value), out intRowValue);
                    int_TotalNewQty += intRowValue;
                    bl = decimal.TryParse(global.ConvertObject(item.Cells["NewPowerRating"].Value), out dclRowValue);
                    dcl_TotalNewPowerRating += dclRowValue;
                    bl = decimal.TryParse(global.ConvertObject(item.Cells["PurchasePrice"].Value), out dclRowValue);
                    dcl_TotalPurchasePrice += dclRowValue;
                }
            }
            txtTotalOldQty.Text = int_TotalOldQty.ToString();
            txtTotalNewQty.Text = int_TotalNewQty.ToString();
            txtTotalNewPowerRating.Text = dcl_TotalNewPowerRating.ToString();
            txtTotalOldPrice.Text = dcl_TotalOldPrice.ToString();
            txtTotalOldSubsidy.Text = dcl_TotalOldSubsidy.ToString();
            txtTotalOldSumPrice.Text = dcl_TotalOldSumPrice.ToString();
            txtTotalPurchasePrice.Text = dcl_TotalPurchasePrice.ToString();

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
            Electric.BLL.BS_NewForOld bll = new Electric.BLL.BS_NewForOld();
            Electric.BLL.BS_NewForOld_Details bllDetail = new Electric.BLL.BS_NewForOld_Details();
            Electric.Model.BS_NewForOld model = new Electric.Model.BS_NewForOld();
            model.BelongTo = cmbBelongTo.SelectedValue.ToString();
            model.Ownership = cmbOwnership.SelectedValue.ToString();
            model.BuyTime = Convert.ToDateTime(dtpBuyTime.Text);
            model.InvoiceNo = txtInvoiceNo.Text;
            model.PartnerAddress = txtPartnerAddress.Text;
            model.PartnerCode = txtPartnerCode.Text;
            model.PartnerContract = txtPartnerContract.Text;
            model.PartnerName = txtPartnerName.Text;
            model.PartnerTel = txtPartnerTel.Text;

            int iTmp = 0;
            model.OrgCode = global.OrganizationCode;
            int.TryParse(txtTotalNewQty.Text, out  iTmp);
            model.TotalNewQty = iTmp;
            int.TryParse(txtTotalOldQty.Text, out iTmp);
            model.TotalOldQty = iTmp;
            decimal dcl = 0;
            decimal.TryParse(txtTotalNewPowerRating.Text, out dcl);
            model.TotalNewPowerRating = dcl;
            decimal.TryParse(txtTotalNewQty.Text, out dcl);
            model.TotalNewPowerRating = dcl;
            decimal.TryParse(txtTotalOldPrice.Text, out dcl);
            model.TotalOldPrice = dcl;
            decimal.TryParse(txtTotalOldSubsidy.Text, out dcl);
            model.TotalOldSubsidy = dcl;
            decimal.TryParse(txtTotalOldSumPrice.Text, out dcl);
            model.TotalOldSumPrice = dcl;
            decimal.TryParse(txtTotalPurchasePrice.Text, out dcl);
            model.TotalPurchasePrice = dcl;
            decimal.TryParse(txtTotalPowerRating.Text, out dcl);
            model.TotalPowerRating = dcl;

            //model.ApproveTime = DateTime.Now;
            //model.ApproveUserID = global.UserID;
            //model.SubmitTime = DateTime.Now();
            //model.SubmitUserID = global.UserID;

            if (!_isupdate)
            {
                model.CreateTime = DateTime.Now;
                model.CreateUserID = global.UserID;
                model.ContractNo = "NO" + global.GenerateCode(bll.GetMaxId().ToString());
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
            Electric.Model.BS_NewForOld_Details modelDetail;
            bool bl = dgvItem.Columns.Contains("ID");//判断是要新增还是修改
            foreach (DataGridViewRow item in dgvItem.Rows)
            {
                if (!item.IsNewRow)
                {
                    if (item.Cells["OldModel"].Value != null || item.Cells["OldPowerRating"].Value != null || item.Cells["OldQty"].Value != null || item.Cells["OldSpeed"].Value != null || item.Cells["OldProtectionLev"].Value != null || item.Cells["OldWeight"].Value != null || item.Cells["OldPrice"].Value != null || item.Cells["OldSubsidy"].Value != null || item.Cells["OldSumPrice"].Value != null || item.Cells["OldSumPrice"].Value != null)
                    {
                        modelDetail = new Electric.Model.BS_NewForOld_Details();
                        modelDetail.OrgCode = model.OrgCode;
                        modelDetail.OldModel = global.ConvertObject(item.Cells["OldModel"].Value);
                        int.TryParse(global.ConvertObject(item.Cells["OldQty"].Value), out iTmp);
                        modelDetail.OldQty = iTmp;
                        decimal.TryParse(global.ConvertObject(item.Cells["OldPrice"].Value), out dcl);
                        modelDetail.OldPrice = dcl;
                        decimal.TryParse(global.ConvertObject(item.Cells["OldPowerRating"].Value), out dcl);
                        modelDetail.OldPowerRating = dcl;
                        decimal.TryParse(global.ConvertObject(item.Cells["OldSubsidy"].Value), out dcl);
                        modelDetail.OldSubsidy = dcl;
                        decimal.TryParse(global.ConvertObject(item.Cells["OldSumPrice"].Value), out dcl);
                        modelDetail.OldSumPrice = dcl;
                        decimal.TryParse(global.ConvertObject(item.Cells["OldSpeed"].Value), out dcl);
                        modelDetail.OldSpeed = dcl;
                        decimal.TryParse(global.ConvertObject(item.Cells["OldWeight"].Value), out dcl);
                        modelDetail.OldWeight = dcl;
                        int.TryParse(global.ConvertObject(item.Cells["NewQty"].Value), out iTmp);
                        modelDetail.NewQty = iTmp;
                        decimal.TryParse(global.ConvertObject(item.Cells["OldPrice"].Value), out dcl);
                        modelDetail.OldPrice = dcl;
                        decimal.TryParse(global.ConvertObject(item.Cells["NewPowerRating"].Value), out dcl);
                        modelDetail.NewPowerRating = dcl;
                        decimal.TryParse(global.ConvertObject(item.Cells["PurchasePrice"].Value), out dcl);
                        modelDetail.PurchasePrice = dcl;
                        modelDetail.OldProtectionLev = global.ConvertObject(item.Cells["OldProtectionLev"].Value);
                        modelDetail.ContractNo = model.ContractNo;
                        modelDetail.OldOutDate = Convert.ToDateTime(item.Cells["OldOutDate"].Value);
                        modelDetail.NewInvoiceDate = Convert.ToDateTime(item.Cells["NewInvoiceDate"].Value);


                        if (modelDetail.OldQty > 0 || modelDetail.OldSubsidy > 0 || modelDetail.OldPrice > 0 || modelDetail.OldSumPrice > 0 || modelDetail.PurchasePrice > 0 || modelDetail.OldPowerRating > 0 || modelDetail.OldWeight > 0 || modelDetail.OldSpeed > 0 || modelDetail.OldProtectionLev != "" || modelDetail.OldModel.Trim() != "")
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
            Electric.Model.BS_NewForOld _model = new Electric.BLL.BS_NewForOld().GetModel(_id);

            _contractNo = _model.ContractNo;
            txtTotalPurchasePrice.Text = _model.TotalPurchasePrice.ToString();
            txtTotalPowerRating.Text = _model.TotalPowerRating.ToString();
            txtTotalOldSumPrice.Text = _model.TotalOldSumPrice.ToString();
            txtTotalOldSubsidy.Text = _model.TotalOldSubsidy.ToString();
            txtTotalOldQty.Text = _model.TotalOldQty.ToString();
            txtTotalOldPrice.Text = _model.TotalOldPrice.ToString();
            txtTotalNewQty.Text = _model.TotalNewQty.ToString();
            txtTotalNewPowerRating.Text = _model.TotalNewPowerRating.ToString();
            txtPartnerTel.Text = _model.PartnerTel;
            txtPartnerName.Text = _model.PartnerName;
            txtPartnerContract.Text = _model.PartnerContract;
            txtPartnerCode.Text = _model.PartnerCode;
            txtPartnerAddress.Text = _model.PartnerAddress;
            txtInvoiceNo.Text = _model.InvoiceNo;

            //Detail
            DataSet _ds = new Electric.BLL.BS_NewForOld_Details().GetList(string.Format("ContractNo='{0}'", _model.ContractNo));
            dgvItem.DataSource = _ds;
            dgvItem.DataMember = "ds";

            //
            this.dgvItem.Columns["OrgCode"].HeaderText = "公司ID";
            this.dgvItem.Columns["ContractNo"].HeaderText = "合同编号";
            this.dgvItem.Columns["OldModel"].HeaderText = "旧电机型号";
            this.dgvItem.Columns["OldPowerRating"].HeaderText = "旧电机额定功率";
            this.dgvItem.Columns["OldQty"].HeaderText = "旧电机台数";
            this.dgvItem.Columns["OldSpeed"].HeaderText = "旧电机额定转速";
            this.dgvItem.Columns["OldProtectionLev"].HeaderText = "旧电机防护等级";
            this.dgvItem.Columns["OldOutDate"].HeaderText = "旧电机出场年月";
            this.dgvItem.Columns["OldWeight"].HeaderText = "旧电机重量";
            this.dgvItem.Columns["OldPrice"].HeaderText = "旧电机回购小计";
            this.dgvItem.Columns["OldSubsidy"].HeaderText = "回购补贴";
            this.dgvItem.Columns["OldSumPrice"].HeaderText = "回购合计";
            this.dgvItem.Columns["TerminalUnit"].HeaderText = "替换终端";
            this.dgvItem.Columns["TUNo"].HeaderText = "替换终端编号";
            this.dgvItem.Columns["NewModel"].HeaderText = "新电机型号";
            this.dgvItem.Columns["NewPowerRating"].HeaderText = "新电机功率";
            this.dgvItem.Columns["NewQty"].HeaderText = "新电机台数";
            this.dgvItem.Columns["PurchasePrice"].HeaderText = "采购金额";
            this.dgvItem.Columns["Reconstruction"].HeaderText = "再造电机";
            this.dgvItem.Columns["NewInvoiceNo"].HeaderText = "新电机发票号码";
            this.dgvItem.Columns["NewInvoiceDate"].HeaderText = "新电机发票日期";
            this.dgvItem.Columns["NewMC"].HeaderText = "新电机制造企业";
            this.dgvItem.Columns["NewSerialNum"].HeaderText = "新电机生产编号";

            this.dgvItem.Columns["ID"].Visible = false;
            this.dgvItem.Columns["CreateUserID"].Visible = false;
            this.dgvItem.Columns["CreateTime"].Visible = false;
            this.dgvItem.Columns["UpdateUserID"].Visible = false;
            this.dgvItem.Columns["UpdateTime"].Visible = false;
            this.dgvItem.Columns["SubmitUserID"].Visible = false;
            this.dgvItem.Columns["SubmitTime"].Visible = false;
            this.dgvItem.Columns["ApproveUserID"].Visible = false;
            this.dgvItem.Columns["ApproveTime"].Visible = false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
