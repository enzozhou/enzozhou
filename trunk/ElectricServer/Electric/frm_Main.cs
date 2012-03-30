using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UtilityLibrary.WinControls;
using UtilityLibrary.CommandBars;
using UtilityLibrary.Menus;
using UtilityLibrary.General;


namespace Electric
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            tsslUser.Text = string.Format("当前用户: {0} ", global.Username);
            this.WindowState = FormWindowState.Maximized;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            global.FormStyle(this, new frm_organization());
        }

        private void tsmi_exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确认退出系统？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void tsmi_company_Click(object sender, EventArgs e)
        {
            global.FormStyle(this, new frm_organization_list());
        }

        private void tv_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        private void tsmi_department_Click(object sender, EventArgs e)
        {
            global.FormStyle(this, new frm_department_list());
        }

        private void tsmi_employee_Click(object sender, EventArgs e)
        {
            global.FormStyle(this, new frm_employee_list());
        }

        private void tsmi_partner_Click(object sender, EventArgs e)
        {
            global.FormStyle(this, new from_partner_list());
        }

        private void tsmi_RecoveryContract_Click(object sender, EventArgs e)
        {
            global.FormStyle(this, new frm_RecoveryContract_list());
        }

        private void tsmi_NewForOld_Click(object sender, EventArgs e)
        {
            global.FormStyle(this, new frm_NewForOld_list());
        }

        private void tsmi_buy_Click(object sender, EventArgs e)
        {
            global.FormStyle(this, new frm_BuyInfo_list(), "购买信息");
        }

        private void tsmi_Purchase_Click(object sender, EventArgs e)
        {
            global.FormStyle(this, new frm_PurchaseContract_list(), "采购合同");
        }



        void test()
        {
            //OutlookBar outlookBar1 = null;
            // My shortcuts band
            
            //OutlookBarBand.myShorcutsBand = new OutlookBarBand("My Shorcuts");
            //myShorcutsBand.SmallImageList = myShortcutsSmallIcons;
            //myShorcutsBand.LargeImageList = myShortcutsLargeIcons;
            //myShorcutsBand.Items.Add(new OutlookBarItem("Contacts", 0));
            //myShorcutsBand.Items.Add(new OutlookBarItem("Music", 1));
            //myShorcutsBand.Items.Add(new OutlookBarItem("Defragment", 2));
            //myShorcutsBand.Items.Add(new OutlookBarItem("Games", 3));
            //myShorcutsBand.Items.Add(new OutlookBarItem("Security", 4));
            //myShorcutsBand.Items.Add(new OutlookBarItem("Users", 5));
            //myShorcutsBand.Items.Add(new OutlookBarItem("Fonts", 6));
            //myShorcutsBand.Items.Add(new OutlookBarItem("Speaker", 7));
            //myShorcutsBand.Items.Add(new OutlookBarItem("Pictures", 8));
            //myShorcutsBand.Background = SystemColors.AppWorkspace;
            //myShorcutsBand.TextColor = Color.White;
            //outlookBar1.Bands.Add(myShorcutsBand);
        }

    }
}
