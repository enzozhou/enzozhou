using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using System.Data;

namespace Electric
{
    static class global
    {
        public static string Username = "";
        public static int UserID = 0;
        public static string OrganizationCode = "";
        public static string OrganizationName = "";
        public static string IsAdmin = "";
        public static int pageSize = 20;
        public static DataTable dtCodes = null;

        /// <summary>
        /// 设置窗体样式
        /// </summary>
        /// <param name="parentForm"></param>
        /// <param name="childForm"></param>
        public static void FormStyle(frm_Main parentForm, Form childForm)
        {
            if (CheckFormIsOpen(parentForm, childForm))
            {
                childForm.Activate();
                return;
            }
            childForm.WindowState = FormWindowState.Maximized;
            childForm.ShowInTaskbar = false;
            //childForm.MaximizeBox = false;
            //childForm.MinimizeBox = false;
            childForm.ShowIcon = false;
            //childForm.FormBorderStyle = FormBorderStyle.FixedSingle;//设置边框样式
            //childForm.ControlBox = false;
            childForm.MdiParent = parentForm;
            childForm.Show();
        }

        /// <summary>
        /// 设置窗体样式
        /// </summary>
        /// <param name="parentForm"></param>
        /// <param name="childForm"></param>
        public static void FormStyle(frm_Main parentForm, Form childForm, string formName)
        {
            FormStyle(parentForm, childForm);
            childForm.Text = formName;
        }

        public static void FormDialog(Form dialogForm, string formName)
        {
            dialogForm.Text = formName;
            //_company.ControlBox = false;
            dialogForm.MaximizeBox = false;
            dialogForm.MinimizeBox = false;
            dialogForm.ShowIcon = false;

            dialogForm.StartPosition = FormStartPosition.CenterParent;
            dialogForm.ShowDialog();
        }

        /// <summary>
        /// 检查窗体是否打开，已经打开就激活窗体。
        /// </summary>
        /// <param name="parentForm"></param>
        /// <param name="childForm"></param>
        /// <returns></returns>
        private static bool CheckFormIsOpen(frm_Main parentForm, Form childForm)
        {
            //if (parentForm.ActiveMdiChild != null && parentForm.ActiveMdiChild.Name == childForm.Name)

            bool _bool = false;
            for (int i = 0; i < parentForm.MdiChildren.Length; i++)
            {
                if (parentForm.MdiChildren[i].Name == childForm.Name)
                {
                    parentForm.MdiChildren[i].Activate(); //已经打开就激活窗体
                    _bool = true;
                    break;
                }
            }
            return _bool;
        }


        /// <summary>
        /// 设置DataGridView
        /// </summary>
        /// <param name="_dgv"></param>
        public static void SetDataGridViewStyle(DataGridView _dgv)
        {
            _dgv.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Beige;
            _dgv.AllowUserToAddRows = false;
            _dgv.AllowUserToDeleteRows = false;
            _dgv.AutoSize = true;
            _dgv.ReadOnly = true;
            _dgv.MultiSelect = false;
            _dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public static string GenerateCode(int size, string suffix)
        {
            return suffix.PadLeft(size, '0');
        }
        public static string GenerateCode(string suffix)
        {
            return GenerateCode(10, suffix);
        }

        /// <summary>
        /// ComboBox数据绑定
        /// </summary>
        /// <param name="_cmb"></param>
        /// <param name="Code"></param>
        /// <param name="defaultValue"></param>
        /// BCP00001	所属企业区县 BCP00002	性别 BCP00003	所有制性质 BCP00004	伙伴性质 BCP00005	上级主管部门
        public static void BandBaseCodeComboBox(ComboBox _cmb, string code)
        {
            string value = "Code", name = "Description";
            DataSet ds = new Electric.BLL.BAS_Code().GetList(string.Format(" SelectCode = '{0}'", code));
            _cmb.DataSource = ds.Tables[0].DefaultView;
            _cmb.DisplayMember = name;
            _cmb.ValueMember = value;
            //_cmb.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public static void BandComboBox(ComboBox _cmb, DataSet _ds, string value, string name)
        {
            _cmb.DataSource = _ds;
            _cmb.DisplayMember = name;
            _cmb.ValueMember = value;
            //_cmb.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public static void SetComboBoxDefaultValue(ComboBox _cmb, string defaultValue)
        {
            //_cmb.Items.Contains(defaultValue).
            if (defaultValue != "")
            {
                _cmb.SelectedValue = defaultValue;
                //int index = _cmb.FindString(defaultValue);
                //box.SelectedIndex = index;
            }
        }

        public static string ConvertObject(object obj)
        {
            if (obj == null)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }
    }
}
