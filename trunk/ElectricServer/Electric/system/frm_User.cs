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
    public partial class frm_User : Form
    {

        public frm_User()
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
                    //showUpdate();
                }
            }
        }

        private bool _isUpdate = false;
        public bool isUpdate
        {
            set { _isUpdate = value; }
            get { return _isUpdate; }
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
                if (this.cmbIsAdmin.Text.Trim().Length == 0)
                {
                    strErr += "请选择是否为管理员.\r";
                }
                //if (this.txtBankName.Text.Trim().Length == 0)
                //{
                //    strErr += "银行不能为空.\r";
                //}
                //if (this.txtBankClass.Text.Trim().Length == 0)
                //{
                //    strErr += "BankClass不能为空.\r";
                //}
                //if (this.txtAccount.Text.Trim().Length == 0)
                //{
                //    strErr += "Account不能为空.\r";
                //}


                if (strErr != "")
                {
                    MessageBox.Show(this, strErr);
                    return;
                }
                string Code = this.txtCode.Text;
                string Name = this.txtName.Text;
                string Pwd = "";
                if (isUpdate)
                {
                    Pwd = txtPassword.Text;
                }
                else
                {
                     Pwd = "123456";
                }
                string IsAdmin = this.cmbIsAdmin.SelectedValue.ToString();
                int RowStatus = 0;
                int CreateUserID = global.UserID;
                DateTime CreateTime = DateTime.Now;
                int UpdateUserID = global.UserID;
                DateTime UpdateTime = DateTime.Now;

                Electric.Model.SYS_User model = new Electric.Model.SYS_User();
                model.Code = Code;
                model.Name = Name;
                model.Pwd = Pwd;
                model.IsAdmin = IsAdmin;
                model.RowStatus = RowStatus;


                Electric.BLL.SYS_User bll = new Electric.BLL.SYS_User();
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
            Electric.Model.SYS_User model = new Electric.Model.SYS_User();
            Electric.BLL.SYS_User bll = new Electric.BLL.SYS_User();
            model = bll.GetModel(_id);
            this.txtCode.Text = model.Code;
            this.txtName.Text = model.Name;
            this.cmbIsAdmin.SelectedValue = model.IsAdmin;

            this.txtPassword.Text = model.Pwd;
            ControlEnabled();
        }

        private void ControlEnabled()
        {
            if (isUpdate)
            {
                txtCode.Enabled = false;
            }
            else
            {
                txtCode.Enabled = true;
            }


        }

        private void frm_User_Load(object sender, EventArgs e)
        {
            if (global.dtCodes != null)
            {
                //DataRow[] rows = global.dtCodes.Select("SelectCode='TrueOrFalse'");
                DataView dvCode = global.dtCodes.DefaultView;
                dvCode.RowFilter = "SelectCode='TrueOrFalse'";
                if (dvCode.Count >0)
                {
                    cmbIsAdmin.DataSource = dvCode;
                    cmbIsAdmin.DisplayMember = "Description";
                    cmbIsAdmin.ValueMember = "Description";
                }
            }
            if(isUpdate)
            showUpdate();
        }

    }
}
