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
            if (Login(txtUser.Text,txtPWD.Text))
            {
                //global.UserID = 1;
                this.DialogResult = DialogResult.OK;

                BLL.BAS_Code code = new BLL.BAS_Code();
                string _sqlWhere = "";

                _sqlWhere = string.Format("1 = '{0}'", 1);
                DataSet _ds = code.GetList(_sqlWhere);
                if (_ds.Tables.Count >0 && _ds.Tables[0].Rows.Count >0 )
                {
                    global.dtCodes = _ds.Tables[0];
                }

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

        private bool Login(string username, string pwd)
        {
            BLL.SYS_User user = new BLL.SYS_User();
            string _sqlWhere = "";

            _sqlWhere = string.Format("code = '{0}' and ", username);
            _sqlWhere += string.Format("pwd = '{0}'  ", pwd);
            DataSet _ds = user.GetList(_sqlWhere);

            if (_ds.Tables.Count >0 && _ds.Tables[0].Rows.Count ==1)
            {
                DataTable dtUser = _ds.Tables[0];
                global.UserID = Int32.Parse(dtUser.Rows[0]["ID"].ToString());
                global.Username = dtUser.Rows[0]["Name"].ToString();
                global.IsAdmin = dtUser.Rows[0]["IsAdmin"].ToString();
                return true;
            }
            return false;
        }


    }
}
