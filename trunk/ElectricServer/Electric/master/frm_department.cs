using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Electric
{
    public partial class frm_department : Form
    {
        public frm_department()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 查询窗口传递值过来修改记录ID
        /// </summary>
        private int _id = 0;
        public int ID
        {
            set { _id = value; showUpdate(); }
        }
        private bool _isUpdate = false;
        public bool isUpdate
        {
            set { _isUpdate = value; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (this.txtCode.Text.Trim().Length == 0)
            {
                strErr += "部门代码不能为空.\n";
            }
            if (this.txtName.Text.Trim().Length == 0)
            {
                strErr += "部门名称不能为空.\n";
            }


            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }
            string OrgCode = global.OrganizationCode;
            string Code = this.txtCode.Text;
            string Name = this.txtName.Text;
            int CreateUserID = global.UserID;
            DateTime CreateTime = DateTime.Now;
            int UpdateUserID = global.UserID;
            DateTime UpdateTime = DateTime.Now;

            Electric.Model.BAS_Department model = new Electric.Model.BAS_Department();
            Electric.BLL.BAS_Department bll = new Electric.BLL.BAS_Department();
            model.OrgCode = global.OrganizationCode;
            model.Code = Code;
            model.Name = Name;
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showUpdate()
        {
            Electric.Model.BAS_Department _model = new Electric.Model.BAS_Department();
            _model = new Electric.BLL.BAS_Department().GetModel(_id);
            txtCode.Text = _model.Code;
            txtName.Text = _model.Name;
        }


        private void frm_department_Load(object sender, EventArgs e)
        {
            txtOrg.Text = global.OrganizationName;
        }
    }
}
