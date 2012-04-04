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
    public partial class frm_BuyInfo : Form
    {
        public frm_BuyInfo()
        {
            InitializeComponent();
        }

        private void dgvItem_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string columnName = dgvItem.Columns[e.ColumnIndex].Name;
            //检查数字
            if (columnName == "NewQty")
            {
                int i = 0;
                if (e.FormattedValue.ToString() != "" && !int.TryParse(e.FormattedValue.ToString(), out  i))
                {
                    e.Cancel = true;
                    dgvItem.Rows[e.RowIndex].ErrorText = "新电机台数数据格式错误";
                }
            }

            if (columnName == "NewRating")
            {
                decimal i = 0;
                if (e.FormattedValue.ToString() != "" && !decimal.TryParse(e.FormattedValue.ToString(), out  i))
                {
                    e.Cancel = true;
                    dgvItem.Rows[e.RowIndex].ErrorText = "新电机功率数据格式错误";
                }
            }
            if (columnName == "NewVoltage")
            {
                decimal i = 0;
                if (e.FormattedValue.ToString() != "" && !decimal.TryParse(e.FormattedValue.ToString(), out  i))
                {
                    e.Cancel = true;
                    dgvItem.Rows[e.RowIndex].ErrorText = "新电机电压数据格式错误";
                }
            }
            if (columnName == "NewSpeed")
            {
                decimal i = 0;
                if (e.FormattedValue.ToString() != "" && !decimal.TryParse(e.FormattedValue.ToString(), out  i))
                {
                    e.Cancel = true;
                    dgvItem.Rows[e.RowIndex].ErrorText = "新电机额定转速数据格式错误";
                }
            }
            if (columnName == "NewWeight")
            {
                decimal i = 0;
                if (e.FormattedValue.ToString() != "" && !decimal.TryParse(e.FormattedValue.ToString(), out  i))
                {
                    e.Cancel = true;
                    dgvItem.Rows[e.RowIndex].ErrorText = "新电机重量数据格式错误";
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
            if (columnName == "Price")
            {
                if (dgvItem.Rows[e.RowIndex].Cells["Price"].Value != null)
                {
                    rowValue = dgvItem.Rows[e.RowIndex].Cells["Price"].Value.ToString();
                    bl = decimal.TryParse(rowValue, out dclRowValue);
                    dclSum += dclRowValue;
                }
                dgvItem.Rows[e.RowIndex].Cells["SumPrice"].Value = dclSum.ToString();
                CaclulateSub();
            }
        }
        /// <summary>
        /// 计算item 合计到head
        /// </summary>
        private void CaclulateSub()
        {
            bool bl = false;
            int int_TotalNewQty = 0;//新电机台数
            decimal dcl_TotalPurchasePrice = 0; //新电机采购总金额 
            decimal dclRowValue = 0;
            int intRowValue = 0;
            foreach (DataGridViewRow item in dgvItem.Rows)
            {
                if (!item.IsNewRow)
                {
                    bl = int.TryParse(global.ConvertObject(item.Cells["NewQty"].Value), out intRowValue);
                    int_TotalNewQty += intRowValue;
                    bl = decimal.TryParse(global.ConvertObject(item.Cells["PurchasePrice"].Value), out dclRowValue);
                    dcl_TotalPurchasePrice += dclRowValue;
                }
            }
            txtTotalNewQty.Text = int_TotalNewQty.ToString();
            txtTotalPurchasePrice.Text = int_TotalNewQty.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strErr = "";
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
            Electric.BLL.BS_BuyInfo bll = new Electric.BLL.BS_BuyInfo();
            Electric.BLL.BS_BuyInfo_Details bllDetail = new Electric.BLL.BS_BuyInfo_Details();
            Electric.Model.BS_BuyInfo model = new Electric.Model.BS_BuyInfo();

            model.BuyTime = Convert.ToDateTime(dtpBuyTime.Text);
            model.BelongTo = cmbBelongTo.Text;
            model.OrgCode = global.OrganizationCode;
            model.Ownership = cmbOwnership.Text;
            model.PartnerAddress = txtPartnerAddress.Text;
            model.PartnerCode = txtPartnerCode.Text;
            model.PartnerContract = txtPartnerContract.Text;
            model.PartnerName = txtPartnerName.Text;
            model.PartnerTel = txtPartnerTel.Text;
            decimal dcl = 0;
            decimal.TryParse(txtTotalNewPowerRating.Text, out dcl);
            model.TotalNewPowerRating = dcl;
            decimal.TryParse(txtTotalNewQty.Text, out dcl);
            model.TotalNewQty = dcl;
            decimal.TryParse(txtTotalPurchasePrice.Text, out dcl);
            model.TotalPurchasePrice = dcl;
            decimal.TryParse(txtTotalWeight.Text, out dcl);
            model.TotalWeight = dcl;


            //model.ApproveTime = DateTime.Now;
            //model.ApproveUserID = global.UserID;
            //model.SubmitTime = DateTime.Now();
            //model.SubmitUserID = global.UserID;

            if (!_isupdate)
            {
                model.CreateTime = DateTime.Now;
                model.CreateUserID = global.UserID;
                model.ContractNo = "BI" + global.GenerateCode(bll.GetMaxId().ToString());
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
            Electric.Model.BS_BuyInfo_Details modelDetail;
            bool bl = dgvItem.Columns.Contains("ID");//判断是要新增还是修改
            int iTmp;
            foreach (DataGridViewRow item in dgvItem.Rows)
            {
                if (!item.IsNewRow)
                {
                    if (item.Cells["InvoiceNo"].Value != null || item.Cells["InvoiceDate"].Value != null || item.Cells["NewModel"].Value != null || item.Cells["NewQty"].Value != null || item.Cells["NewRating"].Value != null || item.Cells["NewVoltage"].Value != null || item.Cells["NewSpeed"].Value != null)
                    {
                        modelDetail = new Electric.Model.BS_BuyInfo_Details();
                        modelDetail.OrgCode = model.OrgCode;
                        modelDetail.NewModel = global.ConvertObject(item.Cells["NewModel"].Value);
                        int.TryParse(global.ConvertObject(item.Cells["NewQty"].Value), out iTmp);
                        modelDetail.NewQty = iTmp;
                        decimal.TryParse(global.ConvertObject(item.Cells["NewRating"].Value), out dcl);
                        modelDetail.NewRating = dcl;
                        decimal.TryParse(global.ConvertObject(item.Cells["Price"].Value), out dcl);
                        modelDetail.Price = dcl;
                        decimal.TryParse(global.ConvertObject(item.Cells["NewSpeed"].Value), out dcl);
                        modelDetail.NewSpeed = dcl;
                        decimal.TryParse(global.ConvertObject(item.Cells["NewVoltage"].Value), out dcl);
                        modelDetail.NewVoltage = dcl;
                        modelDetail.InvoiceDate = Convert.ToDateTime(item.Cells["InvoiceDate"].Value);
                        modelDetail.InvoiceNo = global.ConvertObject(item.Cells["InvoiceNo"].Value);
                        modelDetail.NewMC = global.ConvertObject(item.Cells["NewMC"].Value);
                        modelDetail.NewModel = global.ConvertObject(item.Cells["NewModel"].Value);
                        modelDetail.NewProtectionLev = global.ConvertObject(item.Cells["NewModel"].Value);
                        modelDetail.NewSerialNum = global.ConvertObject(item.Cells["NewModel"].Value);
                        modelDetail.TerminalUnit = "";
                        modelDetail.TUNo = "";
                        //modelDetail.ContractNo = model.ContractNo;


                        if (modelDetail.NewModel != "" || modelDetail.InvoiceNo != "" || modelDetail.Price > 0 || modelDetail.NewQty > 0 || modelDetail.NewRating > 0 || modelDetail.NewSpeed > 0)
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
            Electric.Model.BS_BuyInfo _model = new Electric.BLL.BS_BuyInfo().GetModel(_id);
            _contractNo = _model.ContractNo;
            txtTotalWeight.Text = _model.TotalWeight.ToString();
            txtTotalPurchasePrice.Text = _model.TotalPurchasePrice.ToString();
            txtTotalNewQty.Text = _model.TotalNewQty.ToString();
            txtTotalNewPowerRating.Text = _model.TotalNewPowerRating.ToString();
            txtPartnerTel.Text = _model.PartnerTel;
            txtPartnerName.Text = _model.PartnerName;
            txtPartnerContract.Text = _model.PartnerContract;
            txtPartnerCode.Text = _model.PartnerCode;
            txtPartnerAddress.Text = _model.PartnerAddress;



            txtContractNo.ReadOnly = true;
            //txtWtxtords.Text = _model.Words;
            //txtCheckedLimit.Text = _model.CheckedLimit.ToString();

            //Detail
            DataSet _ds = new Electric.BLL.BS_BuyInfo_Details().GetList(string.Format("ContractNo='{0}'", _model.ContractNo));
            dgvItem.DataSource = _ds;
            dgvItem.DataMember = "ds";


            this.dgvItem.Columns["OrgCode"].Visible = false;
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

        private void frm_BuyInfo_Load(object sender, EventArgs e)
        {
            global.BandBaseCodeComboBox(cmbBelongTo, "BCP00001");
            global.BandBaseCodeComboBox(cmbOwnership, "BCP00003");
        }

    }
}
