using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Electric
{
    public partial class frm_organization : Form
    {
        public frm_organization()
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
                    strErr += "代码不能为空.\r";
                }
                if (this.txtName.Text.Trim().Length == 0)
                {
                    strErr += "名称不能为空.\r";
                }
                if (this.cmbMembership.Text.Trim().Length == 0)
                {
                    strErr += "所属集团区县不能为空.\r";
                }
                if (this.txtEnterpriseNature.Text.Trim().Length == 0)
                {
                    strErr += "企业性质不能为空.\r";
                }
                if (this.txtTaxNo.Text.Trim().Length == 0)
                {
                    strErr += "税号不能为空.\r";
                }
                if (this.txtAddress.Text.Trim().Length == 0)
                {
                    strErr += "地址不能为空.\r";
                }
                if (this.txtWebSite.Text.Trim().Length == 0)
                {
                    strErr += "网址不能为空.\r";
                }

                if (strErr != "")
                {
                    MessageBox.Show(this, strErr);
                    return;
                }
                string Code = this.txtCode.Text;
                string Name = this.txtName.Text;
                string Membership = this.cmbMembership.SelectedValue.ToString();
                string EnterpriseNature = this.txtEnterpriseNature.Text;
                string TexNo = this.txtTaxNo.Text;
                string Address = this.txtAddress.Text;
                string WebSite = this.txtWebSite.Text;
                string BankName = this.txtBankName.Text;
                string BankClass = this.txtBankClass.Text;
                string Account = this.txtAccount.Text;
                int RowStatus = 0;
                int CreateUserID = global.UserID;
                DateTime CreateTime = DateTime.Now;
                int UpdateUserID = global.UserID;
                DateTime UpdateTime = DateTime.Now;
                Electric.Model.BAS_Organization model = new Electric.Model.BAS_Organization();
                model.Code = Code;
                model.Name = Name;
                model.Membership = Membership;
                model.EnterpriseNature = EnterpriseNature;
                model.TexNo = TexNo;
                model.Address = Address;
                model.WebSite = WebSite;
                model.BankName = BankName;
                model.BankClass = BankClass;
                model.Account = Account;
                model.RowStatus = RowStatus;


                Electric.BLL.BAS_Organization bll = new Electric.BLL.BAS_Organization();
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
            Electric.Model.BAS_Organization model = new Electric.Model.BAS_Organization();
            Electric.BLL.BAS_Organization bll = new Electric.BLL.BAS_Organization();
            model = bll.GetModel(_id);
            this.txtCode.Text = model.Code;
            this.txtName.Text = model.Name;
            global.SetComboBoxDefaultValue(cmbMembership, model.Membership);
            //this.cmbMembership.Text = model.Membership;
            this.txtEnterpriseNature.Text = model.EnterpriseNature;
            this.txtTaxNo.Text = model.TexNo;
            this.txtAddress.Text = model.Address;
            this.txtWebSite.Text = model.WebSite;
            this.txtBankName.Text = model.BankName;
            this.txtBankClass.Text = model.BankClass;
            this.txtAccount.Text = model.Account;
        }

        private void frm_organization_Load(object sender, EventArgs e)
        {
            global.BandBaseCodeComboBox(cmbMembership, "BCP00001");
            if (_isUpdate)
            {
                showUpdate();
            }
        }

    }
}
