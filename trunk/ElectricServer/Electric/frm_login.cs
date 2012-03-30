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
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.SizeGripStyle = SizeGripStyle.Hide;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Trim() == "admin" && txtUser.Text.Trim() == "admin")
            {
                global.UserID = 1;
                this.DialogResult = DialogResult.OK;
                //frm_Main frm = new frm_Main();
                //frm.WindowState = FormWindowState.Maximized;
                //frm.Show();
            }
            else if (txtUser.Text.Trim() == "")
            {
                MessageBox.Show("用户名不能为空。");
            }
            else if (txtUser.Text.Trim() == "")
            {
                MessageBox.Show("密码不能为空。");
            }
            else
            {
                MessageBox.Show("输入错误。");
            }

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}
