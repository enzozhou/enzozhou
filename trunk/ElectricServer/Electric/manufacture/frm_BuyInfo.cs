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
        private DataTable dtContractDetails = null;

        public frm_BuyInfo()
        {
            InitializeComponent();

            DataSet _ds = new Electric.BLL.V_BAS_PPC().GetList("");
            DataTable dtContract = _ds.Tables[0];
            lstContractNo.DataSource = dtContract;
            lstContractNo.DisplayMember = "ContractNo";
            lstContractNo.ValueMember = "ContractNo";
            lstContractNo.Visible = false;

            //加载Combobox
            global.BandBaseCodeComboBox(cmbBelongTo, "BCP00001");
            global.BandBaseCodeComboBox(cmbOwnership, "BCP00003");

            global.BandBaseDgvCodeComboBox(NewProtectionLev, "ProtectionLev");
            //global.BandBaseDgvCodeComboBox(TerminalUnit, "TerminalUnit");

            DataSet _dsPartner = new Electric.BLL.BAS_Partner().GetList("");
            DataTable dtPartner = _dsPartner.Tables[0];
            global.BandDgvCodeComboBox(NewMC, dtPartner, "Code", "Name");
        }


        private DataTable QueryPartnerInfo(string code)
        {
            DataSet _ds = new Electric.BLL.V_BAS_PPC().GetList("ContractNo like '%" + code + "%'");
            DataTable dtPartner = _ds.Tables[0];
            return dtPartner;
        }

        /// <summary>
        /// Load合作伙伴信息 FZ20120405
        /// </summary>
        /// <param name="row"></param>
        private void LoadContractInfo(DataRow row)
        {
            if (row != null)
            {
                lstContractNo.Visible = false;
                txtContractNo.Text = row["ContractNo"].ToString();
                txtPartnerCode.Text = row["Code"].ToString();
                txtPartnerName.Text = row["Name"].ToString();
                txtPartnerContract.Text = row["Contract"].ToString();
                txtPartnerTel.Text = row["Tel"].ToString();
                cmbBelongTo.SelectedValue = row["Membership"].ToString();
                cmbOwnership.SelectedValue = row["Ownership"].ToString();
                txtPartnerAddress.Text = row["Address"].ToString();

                DataSet _dsdetails =
                    new Electric.BLL.BS_PurchaseContract_Details().GetList("ContractNo ='" + txtContractNo.Text + "'");
                if (_dsdetails.Tables.Count > 0)
                {
                    dtContractDetails = _dsdetails.Tables[0];
                    LoadContractDetails(dtContractDetails);
                }

            }
            else
            {
                lstContractNo.Visible = false;
                txtPartnerCode.Text = "";
                txtPartnerName.Text = "";
                txtPartnerContract.Text = "";
                txtPartnerTel.Text = "";
                txtPartnerAddress.Text = "";
            }
        }

        private bool CheckedValue()
        {
            string strErr = "";
            if (this.txtContractNo.Text.Trim() == string.Empty)
            {
                strErr += "合同编号不能为空 \n";
            }
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
                return false;
            }
            return true;
        }

        private void LoadContractDetails(DataTable dtDetails)
        {
            if (dtDetails.Rows.Count > 0)
            {
                dgvItem.Rows.Clear();
                dgvItem.Rows.Add(dtDetails.Rows.Count);
                for (int rowCount = 0; rowCount < dtDetails.Rows.Count; rowCount++)
                {
                    //DataGridViewRowCollection dvRow = dgvItem.Rows;
                    dgvItem.Rows[rowCount].Cells["NewModel"].Value = dtDetails.Rows[rowCount]["Model"].ToString();
                    dgvItem.Rows[rowCount].Cells["NewQty"].Value = dtDetails.Rows[rowCount]["Qty"].ToString();
                    dgvItem.Rows[rowCount].Cells["NewRating"].Value = dtDetails.Rows[rowCount]["PowerRating"].ToString();
                    dgvItem.Rows[rowCount].Cells["UnitPrice"].Value = dtDetails.Rows[rowCount]["UnitPrice"].ToString();
                    dgvItem.Rows[rowCount].Cells["Subsidy"].Value = dtDetails.Rows[rowCount]["Subsidy"].ToString();
                    dgvItem.Rows[rowCount].Cells["Price"].Value = dtDetails.Rows[rowCount]["Price"].ToString();
                    //dgvItem.Rows[rowCount].Cells["OldSumPrice"].Value = dtDetails.Rows[rowCount]["SumPrice"].ToString();

                }
                CaclulateSub();
            }
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
            decimal dclSubsidy = 0;
            decimal dclUnitPrice = 0;
            int qty = 0;

            decimal dclRowValue = 0;
            string rowValue;
            if (columnName == "Subsidy" || columnName == "UnitPrice" || columnName == "NewQty")
            {
                if (dgvItem.Rows[e.RowIndex].Cells["Subsidy"].Value != null)
                {
                    rowValue = dgvItem.Rows[e.RowIndex].Cells["Subsidy"].Value.ToString();
                    bl = decimal.TryParse(rowValue, out dclSubsidy);
                }
                if (dgvItem.Rows[e.RowIndex].Cells["UnitPrice"].Value != null)
                {
                    rowValue = dgvItem.Rows[e.RowIndex].Cells["UnitPrice"].Value.ToString();
                    bl = decimal.TryParse(rowValue, out dclUnitPrice);
                }
                if (dgvItem.Rows[e.RowIndex].Cells["NewQty"].Value != null)
                {
                    rowValue = dgvItem.Rows[e.RowIndex].Cells["NewQty"].Value.ToString();
                    bl = int.TryParse(rowValue, out qty);
                }
                dclSum = dclUnitPrice * qty + dclSubsidy;
                dgvItem.Rows[e.RowIndex].Cells["Price"].Value = dclSum.ToString();
                ;
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
            decimal totalRating = 0;//总功率
            decimal totalWeight = 0;//总重量

            decimal dclRowValue = 0;
            int intRowValue = 0;
            foreach (DataGridViewRow item in dgvItem.Rows)
            {
                //if (!item.IsNewRow)
                {
                    bl = int.TryParse(global.ConvertObject(item.Cells["NewQty"].Value), out intRowValue);
                    int_TotalNewQty += intRowValue;
                    bl = decimal.TryParse(global.ConvertObject(item.Cells["NewRating"].Value), out dclRowValue);
                    totalRating += dclRowValue * intRowValue;
                    bl = decimal.TryParse(global.ConvertObject(item.Cells["Price"].Value), out dclRowValue);
                    dcl_TotalPurchasePrice += dclRowValue;
                    bl = decimal.TryParse(global.ConvertObject(item.Cells["NewWeight"].Value), out dclRowValue);
                    totalWeight += dclRowValue;
                }
            }
            txtTotalNewQty.Text = int_TotalNewQty.ToString();
            txtTotalNewPowerRating.Text = totalRating.ToString();
            txtTotalPurchasePrice.Text = dcl_TotalPurchasePrice.ToString();
            txtTotalWeight.Text = totalWeight.ToString();
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
            Electric.BLL.BS_BuyInfo bll = new Electric.BLL.BS_BuyInfo();
            Electric.BLL.BS_BuyInfo_Details bllDetail = new Electric.BLL.BS_BuyInfo_Details();
            Electric.Model.BS_BuyInfo model = new Electric.Model.BS_BuyInfo();

            model.OrgCode = global.OrganizationCode;
            model.ContractNo = txtContractNo.Text;
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

            DateTime dtime = DateTime.Parse("1900-1-1");

            //model.ApproveTime = DateTime.Now;
            //model.ApproveUserID = global.UserID;
            //model.SubmitTime = DateTime.Now();
            //model.SubmitUserID = global.UserID;

            if (!_isupdate)
            {
                model.CreateTime = DateTime.Now;
                model.CreateUserID = global.UserID;
                //model.ContractNo = "BI" + global.GenerateCode(bll.GetMaxId().ToString());
                bll.Add(model);
            }
            else
            {
                model.UpdateTime = DateTime.Now;
                model.UpdateUserID = global.UserID;
                model.ID = _id;
                //model.ContractNo = _contractNo;
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
                        modelDetail.ContractNo = txtContractNo.Text;
                        modelDetail.NewModel = global.ConvertObject(item.Cells["NewModel"].Value);
                        int.TryParse(global.ConvertObject(item.Cells["NewQty"].Value), out iTmp);
                        modelDetail.NewQty = iTmp;
                        decimal.TryParse(global.ConvertObject(item.Cells["NewRating"].Value), out dcl);
                        modelDetail.NewRating = dcl;
                        decimal.TryParse(global.ConvertObject(item.Cells["NewVoltage"].Value), out dcl);
                        modelDetail.NewVoltage = dcl;
                        decimal.TryParse(global.ConvertObject(item.Cells["NewSpeed"].Value), out dcl);
                        modelDetail.NewSpeed = dcl;
                        modelDetail.NewProtectionLev = global.ConvertObject(item.Cells["NewProtectionLev"].Value);
                        modelDetail.NewMC = global.ConvertObject(item.Cells["NewMC"].Value);
                        decimal.TryParse(global.ConvertObject(item.Cells["NewWeight"].Value), out dcl);
                        modelDetail.NewWeight = dcl;
                        decimal.TryParse(global.ConvertObject(item.Cells["UnitPrice"].Value), out dcl);
                        modelDetail.UnitPrice = dcl;
                        decimal.TryParse(global.ConvertObject(item.Cells["Subsidy"].Value), out dcl);
                        modelDetail.Subsidy = dcl;
                        decimal.TryParse(global.ConvertObject(item.Cells["Price"].Value), out dcl);
                        modelDetail.Price = dcl;
                        modelDetail.TerminalUnit = global.ConvertObject(item.Cells["TerminalUnit"].Value);
                        modelDetail.TUNo = global.ConvertObject(item.Cells["TUNo"].Value);
                        modelDetail.NewSerialNum = global.ConvertObject(item.Cells["NewSerialNum"].Value);
                        modelDetail.InvoiceNo = global.ConvertObject(item.Cells["InvoiceNo"].Value);
                        DateTime.TryParse(global.ConvertObject(item.Cells["InvoiceDate"].Value), out dtime);
                        if (dtime < DateTime.Parse("1900-1-1"))
                        {
                            dtime = DateTime.Parse("1900-1-1");
                        }
                        modelDetail.InvoiceDate = dtime;

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

            }
        }

        private bool _isupdate = false;
        public bool isUpdate
        {
            set { _isupdate = value; }
            get { return _isupdate; }
        }

        private string _contractNo = "";
        private void showUpdate()
        {
            //Head
            Electric.Model.BS_BuyInfo _model = new Electric.BLL.BS_BuyInfo().GetModel(_id);
            _contractNo = _model.ContractNo;
            txtContractNo.Text = _model.ContractNo;
            txtTotalWeight.Text = _model.TotalWeight.ToString();
            txtTotalPurchasePrice.Text = _model.TotalPurchasePrice.ToString();
            txtTotalNewQty.Text = _model.TotalNewQty.ToString();
            txtTotalNewPowerRating.Text = _model.TotalNewPowerRating.ToString();
            txtPartnerTel.Text = _model.PartnerTel;
            txtPartnerName.Text = _model.PartnerName;
            txtPartnerContract.Text = _model.PartnerContract;
            txtPartnerCode.Text = _model.PartnerCode;
            txtPartnerAddress.Text = _model.PartnerAddress;
            dtpBuyTime.Text = _model.BuyTime.ToString();


            txtContractNo.ReadOnly = true;
            //txtWtxtords.Text = _model.Words;
            //txtCheckedLimit.Text = _model.CheckedLimit.ToString();

            //Detail
            DataSet _ds = new Electric.BLL.BS_BuyInfo_Details().GetList(string.Format("ContractNo='{0}'", _model.ContractNo));
            dgvItem.DataSource = _ds;
            dgvItem.DataMember = "ds";


            //this.dgvItem.Columns["OrgCode"].Visible = false;
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
            ////加载Combobox
            //global.BandBaseCodeComboBox(cmbBelongTo, "BCP00001");
            //global.BandBaseCodeComboBox(cmbOwnership, "BCP00003");



            //global.BandBaseDgvCodeComboBox(NewProtectionLev, "ProtectionLev");
            //global.BandBaseDgvCodeComboBox(TerminalUnit, "TerminalUnit");

            if (isUpdate)
            {
                showUpdate();
            }
        }

        private void txtContractNo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataTable dtContract = QueryPartnerInfo(txtContractNo.Text);
            if (dtContract.Rows.Count == 1)
            {
                LoadContractInfo(dtContract.Rows[0]);
            }
            else if (dtContract.Rows.Count > 1)
            {
                lstContractNo.Visible = true;
            }
            else
            {
                LoadContractInfo(null);
                if (txtPartnerCode.Text != string.Empty)
                {
                    txtPartnerCode.Focus();
                }
            }
        }

        private void lstContractNo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataTable dtContract = QueryPartnerInfo(lstContractNo.SelectedValue.ToString());
            if (dtContract.Rows.Count == 1)
            {
                LoadContractInfo(dtContract.Rows[0]);
                lstContractNo.Visible = false;
            }
        }

        private void dgvItem_RowValidated(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvItem_Validated(object sender, EventArgs e)
        {
            CaclulateSub();
        }

    }
}
