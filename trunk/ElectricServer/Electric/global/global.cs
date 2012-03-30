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

        public static string GenerateCode(string suffix)
        {
            return suffix.PadLeft(10, '0');
        }

        /// <summary>
        /// ComboBox数据绑定
        /// </summary>
        /// <param name="_cmb"></param>
        /// <param name="_ds"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public static void BindComboBox(ComboBox _cmb, System.Data.DataSet _ds, string name, string value)
        {
            _cmb.DataSource = _ds;
            _cmb.DisplayMember = name;
            _cmb.ValueMember = value;
            _cmb.DropDownStyle = ComboBoxStyle.DropDownList;
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

        public static void BandComboBox(System.Windows.Forms.ComboBox box, System.Data.DataSet ds, string text, string value, string defaultValue)
        {
            try
            {
                box.Items.Clear();
                //foreach (System.Data.DataRow item in ds.Tables[0].Rows)
                //{
                //    box.Items.Add(item[text].ToString());                   
                //}
                //box.DataSource = ds;
                //box.DisplayMember = text;
                //box.ValueMember = value;
                if (defaultValue != "")
                {
                    int index = box.FindString(defaultValue);
                    box.SelectedIndex = index;
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
