using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Electric
{
    public partial class frm_partner : Form
    {
        public frm_partner()
        {
            InitializeComponent();
        }

        private int _id = 0;
        /// <summary>
        /// 查询窗口传递值过来修改记录ID
        /// </summary>
        public int ID
        {
            set
            {
                if (value > 0)
                {
                    _id = value;
                    showUpdate();
                }
            }
        }

        private bool _isUpdate = false;
        public bool isUpdate
        {
            set { _isUpdate = value; }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string strErr = "";
                if (this.txtCode.Text.Trim().Length == 0)
                {
                    strErr += "代码不能为空.\n";
                }
                if (this.txtName.Text.Trim().Length == 0)
                {
                    strErr += "名称不能为空.\n";
                }
                //if (this.txtPartnerClass.Text.Trim().Length == 0)
                //{
                //    strErr += "类型不能为空.\n";
                //}
                if (this.txtAddress.Text.Trim().Length == 0)
                {
                    strErr += "企业地址不能为空.\n";
                }
                if (this.txtCorporate.Text.Trim().Length == 0)
                {
                    strErr += "法人代表不能为空.\n";
                }
                if (this.txtOrgCode.Text.Trim().Length == 0)
                {
                    strErr += "组织机构代码不能为空.\n";
                }
                if (this.txtLicence.Text.Trim().Length == 0)
                {
                    strErr += "营业执照号不能为空.\n";
                }
                if (this.txtTaxNo.Text.Trim().Length == 0)
                {
                    strErr += "税号不能为空.\n";
                }
                if (this.cmbOwnership.Text.Trim().Length == 0)
                {
                    strErr += "所有制形式不能为空.\n";
                }
                //if (!PageValidate.IsDecimal(txtRegisteredCapital.Text))
                //{
                //    strErr += "注册资金格式错误.\n";
                //}
                //if (this.txtSupervisor.Text.Trim().Length == 0)
                //{
                //    strErr += "Supervisor不能为空.\n";
                //}
                //if (!PageValidate.IsDecimal(txtFixedAssets.Text))
                //{
                //    strErr += "FixedAssets格式错误.\n";
                //}
                //if (!PageValidate.IsNumber(txtEnterpriseNum.Text))
                //{
                //    strErr += "EnterpriseNum格式错误.\n";
                //}
                //if (this.txtContract.Text.Trim().Length == 0)
                //{
                //    strErr += "Contract不能为空.\n";
                //}
                //if (this.txtTel.Text.Trim().Length == 0)
                //{
                //    strErr += "Tel不能为空.\n";
                //}
                //if (this.txtEmail.Text.Trim().Length == 0)
                //{
                //    strErr += "Email不能为空.\n";
                //}
                //if (this.txtETC.Text.Trim().Length == 0)
                //{
                //    strErr += "ETC不能为空.\n";
                //}
                //if (!PageValidate.IsDecimal(txtLYSV.Text))
                //{
                //    strErr += "LYSV格式错误.\n";
                //}
                //if (!PageValidate.IsDecimal(txtYBLSV.Text))
                //{
                //    strErr += "YBLSV格式错误.\n";
                //}
                //if (this.txtBankName.Text.Trim().Length == 0)
                //{
                //    strErr += "BankName不能为空.\n";
                //}
                //if (this.txtBankClass.Text.Trim().Length == 0)
                //{
                //    strErr += "BankClass不能为空.\n";
                //}
                //if (this.txtAccount.Text.Trim().Length == 0)
                //{
                //    strErr += "Account不能为空.\n";
                //}
                //if (!PageValidate.IsNumber(txtCreateUserID.Text))
                //{
                //    strErr += "CreateUserID格式错误.\n";
                //}
                //if (!PageValidate.IsDateTime(txtCreateTime.Text))
                //{
                //    strErr += "CreateTime格式错误.\n";
                //}
                //if (!PageValidate.IsNumber(txtUpdateUserID.Text))
                //{
                //    strErr += "UpdateUserID格式错误.\n";
                //}
                //if (!PageValidate.IsDateTime(txtUpdateTime.Text))
                //{
                //    strErr += "UpdateTime格式错误.\n";
                //}
                //if (!PageValidate.IsNumber(txtSubmitUserID.Text))
                //{
                //    strErr += "SubmitUserID格式错误.\n";
                //}
                //if (!PageValidate.IsDateTime(txtSubmitTime.Text))
                //{
                //    strErr += "SubmitTime格式错误.\n";
                //}
                //if (!PageValidate.IsNumber(txtApproveUserID.Text))
                //{
                //    strErr += "ApproveUserID格式错误.\n";
                //}
                //if (!PageValidate.IsDateTime(txtApproveTime.Text))
                //{
                //    strErr += "ApproveTime格式错误.\n";
                //}

                if (strErr != "")
                {
                    MessageBox.Show(this, strErr);
                    return;
                }


                if (strErr != "")
                {
                    MessageBox.Show(this, strErr);
                    return;
                }

                int OrgID = int.Parse(this.txtOrgCode.Text);
                string Code = this.txtCode.Text;
                string Name = this.txtName.Text;
                string PartnerClass = this.cmbType.Text;
                string Address = this.txtAddress.Text;
                string Corporate = this.txtCorporate.Text;
                string OrgCode = this.txtOrgCode.Text;
                string Licence = this.txtLicence.Text;
                string TaxNo = this.txtTaxNo.Text;
                string Ownership = this.cmbOwnership.Text;
                decimal RegisteredCapital = decimal.Parse(this.txtRegisteredCapital.Text);
                string Supervisor = this.cmbSupervisor.Text;
                decimal FixedAssets = decimal.Parse(this.txtFixedAssets.Text);
                int EnterpriseNum = int.Parse(this.txtEnterpriseNum.Text);
                string Contract = this.txtContract.Text;
                string Tel = this.txtTel.Text;
                string Email = this.txtMail.Text;
                string ETC = this.txtETC.Text;
                decimal LYSV = decimal.Parse(this.txtLYSV.Text);
                decimal YBLSV = decimal.Parse(this.txtYBLSV.Text);
                string BankName = this.txtBankName.Text;
                string BankClass = this.txtBankClass.Text;
                string Account = this.txtAccount.Text;
                int CreateUserID = global.UserID;
                DateTime CreateTime = DateTime.Now;
                int UpdateUserID = global.UserID;
                DateTime UpdateTime = DateTime.Now;
                int SubmitUserID = global.UserID;
                DateTime SubmitTime = DateTime.Now;
                int ApproveUserID = global.UserID;
                DateTime ApproveTime = DateTime.Now;

                Electric.Model.BAS_Partner model = new Electric.Model.BAS_Partner();
                model.OrgID = OrgID;
                model.Code = Code;
                model.Name = Name;
                model.PartnerClass = PartnerClass;
                model.Address = Address;
                model.Corporate = Corporate;
                model.OrgCode = OrgCode;
                model.Licence = Licence;
                model.TaxNo = TaxNo;
                model.Ownership = Ownership;
                model.RegisteredCapital = RegisteredCapital;
                model.Supervisor = Supervisor;
                model.FixedAssets = FixedAssets;
                model.EnterpriseNum = EnterpriseNum;
                model.Contract = Contract;
                model.Tel = Tel;
                model.Email = Email;
                model.ETC = ETC;
                model.LYSV = LYSV;
                model.YBLSV = YBLSV;
                model.BankName = BankName;
                model.BankClass = BankClass;
                model.Account = Account;
                model.CreateUserID = CreateUserID;
                model.CreateTime = CreateTime;
                model.UpdateUserID = UpdateUserID;
                model.UpdateTime = UpdateTime;
                model.SubmitUserID = SubmitUserID;
                model.SubmitTime = SubmitTime;
                model.ApproveUserID = ApproveUserID;
                model.ApproveTime = ApproveTime;

                Electric.BLL.BAS_Partner bll = new Electric.BLL.BAS_Partner();

                if (!_isUpdate)
                {
                    model.CreateUserID = CreateUserID;
                    model.CreateTime = CreateTime;
                    int _i = bll.Add(model);
                    if (_i >= 1)
                    {
                        MessageBox.Show("保存成功。");
                    }
                    else
                    {
                        MessageBox.Show("保存失败。");
                    }
                }
                else
                {
                    model.UpdateUserID = UpdateUserID;
                    model.UpdateTime = UpdateTime;
                    model.ID = _id;
                    bool _b = bll.Update(model);
                    if (_b)
                    {
                        MessageBox.Show("保存成功。");
                    }
                    else
                    {
                        MessageBox.Show("保存失败。");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showUpdate()
        {
            Electric.Model.BAS_Partner model = new Electric.Model.BAS_Partner();
            Electric.BLL.BAS_Partner bll = new Electric.BLL.BAS_Partner();
            model = bll.GetModel(_id);
            this.txtCode.Text = model.Code;
            this.txtName.Text = model.Name;
            this.txtOrgCode.Text = model.OrgCode;
            this.txtRegisteredCapital.Text = model.RegisteredCapital.ToString();
            this.txtTaxNo.Text = model.TaxNo;
            this.txtTel.Text = model.Tel;
            this.txtYBLSV.Text = model.YBLSV.ToString();
            this.txtLYSV.Text = model.LYSV.ToString();
            this.txtMail.Text = model.Email;
            this.txtLicence.Text = model.Licence;
            this.txtFixedAssets.Text = model.FixedAssets.ToString();
            this.lbl22.Text = model.ETC;
            this.txtEnterpriseNum.Text = model.EnterpriseNum.ToString();
            this.txtCorporate.Text = model.Corporate;
            this.txtContract.Text = model.Contract;
            this.txtBankName.Text = model.BankName;
            this.txtBankClass.Text = model.BankClass;
            this.txtAddress.Text = model.Address;
            this.txtAccount.Text = model.Account;
        }

        void bind()
        {
            DataSet _ds = new Electric.BLL.BAS_Organization().GetList("");
            global.BandComboBox(cmbOrgID, _ds, "Name", "ID", "");
        }
    }
}
