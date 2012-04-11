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
using System.Reflection;
using System.Resources;


namespace Electric
{
    public partial class frm_Main : Form
    {
        public frm_Main()
        {
            InitializeComponent();
            menuAdd();//添加leftmenu
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
            //DialogResult result = MessageBox.Show("确认退出系统？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result == DialogResult.Yes)
            //{
            //    //this.Close();
            //    //Application.Exit();
            //}

        }

        private void tsmi_company_Click(object sender, EventArgs e)
        {
            global.FormStyle(this, new frm_organization_list(), "公司信息");
        }


        private void tsmi_department_Click(object sender, EventArgs e)
        {
            global.FormStyle(this, new frm_department_list(), "部门信息");
        }

        private void tsmi_employee_Click(object sender, EventArgs e)
        {
            global.FormStyle(this, new frm_employee_list(), "员工信息");
        }

        private void tsmi_partner_Click(object sender, EventArgs e)
        {
            global.FormStyle(this, new from_partner_list(), "合作伙伴信息");
        }

        private void tsmi_RecoveryContract_Click(object sender, EventArgs e)
        {
            global.FormStyle(this, new frm_RecoveryContract_list(), "回收合同");
        }

        private void tsmi_NewForOld_Click(object sender, EventArgs e)
        {
            global.FormStyle(this, new frm_NewForOld_list(), "以旧换新");
        }

        private void tsmi_buy_Click(object sender, EventArgs e)
        {
            global.FormStyle(this, new frm_BuyInfo_list(), "购买信息");
        }

        private void tsmi_Purchase_Click(object sender, EventArgs e)
        {
            global.FormStyle(this, new frm_PurchaseContract_list(), "采购合同");
        }




        //ResourceManager rmBitmaps = null;
        ResourceManager rmListImages = null;
        //ImageList outlookLargeIcons = null;
        //ImageList outlookSmallIcons = null;
        ImageList myShortcutsLargeIcons = null;
        ImageList myShortcutsSmallIcons = null;
        //private ImageList imageList;
        //private ImageList headerImageList;
        void InitializeImageLists()
        {

            //imageList = new ImageList();
            //imageList.ImageSize = new Size(16, 16);
            //Bitmap icons = (Bitmap)rmListImages.GetObject("ListIcons");
            //icons.MakeTransparent(Color.FromArgb(192, 192, 192));
            //imageList.Images.AddStrip(icons);

            //headerImageList = new ImageList();
            //headerImageList.ImageSize = new Size(16, 16);
            //icons = (Bitmap)rmListImages.GetObject("HeaderIcons");
            //icons.MakeTransparent(Color.FromArgb(0, 255, 255));
            //headerImageList.Images.AddStrip(icons);

            //outlookLargeIcons = new ImageList();
            //outlookLargeIcons.ImageSize = new Size(32, 32);
            //icons = (Bitmap)rmListImages.GetObject("OutlookLargeIcons");
            //icons.MakeTransparent(Color.FromArgb(255, 0, 255));
            //outlookLargeIcons.Images.AddStrip(icons);

            //outlookSmallIcons = new ImageList();
            //outlookSmallIcons.ImageSize = new Size(16, 16);
            //icons = (Bitmap)rmListImages.GetObject("OutlookSmallIcons");
            //icons.MakeTransparent(Color.FromArgb(255, 0, 255));
            //outlookSmallIcons.Images.AddStrip(icons);

            myShortcutsLargeIcons = new ImageList();
            myShortcutsLargeIcons.ColorDepth = ColorDepth.Depth32Bit;
            myShortcutsLargeIcons.ImageSize = new Size(48, 48);
            Bitmap icons = (Bitmap)rmListImages.GetObject("MyShortcutsLargeIcons");
            icons.MakeTransparent(Color.FromArgb(255, 0, 255));
            myShortcutsLargeIcons.Images.AddStrip(icons);

            myShortcutsSmallIcons = new ImageList();
            myShortcutsSmallIcons.ImageSize = new Size(16, 16);
            icons = (Bitmap)rmListImages.GetObject("MyShortcutsSmallIcons");
            icons.MakeTransparent(Color.FromArgb(255, 0, 255));
            myShortcutsSmallIcons.Images.AddStrip(icons);

        }
        void menuAdd()
        {
            OutlookBar _outlookBar = new OutlookBar();

            //Assembly thisAssembly = Assembly.GetAssembly(Type.GetType("Electric.frm_Main"));
            Assembly thisAssembly = Assembly.GetAssembly(Type.GetType("Electric.frm_Main"));
            rmListImages = new ResourceManager("Electric.IconImages", thisAssembly);//Assembly.GetExecutingAssembly()
            //rmBitmaps = new ResourceManager("Menus", thisAssembly);
            InitializeImageLists();
            //My shortcuts band

            OutlookBarBand mu_master = new OutlookBarBand("基本信息");
            mu_master.SmallImageList = myShortcutsSmallIcons;
            mu_master.LargeImageList = myShortcutsLargeIcons;
            mu_master.Items.Add(new OutlookBarItem("公司信息", 0));
            mu_master.Items.Add(new OutlookBarItem("部门信息", 0));
            mu_master.Items.Add(new OutlookBarItem("员工信息", 0));
            mu_master.Items.Add(new OutlookBarItem("合作伙伴", 0));
            //mu_master.Items.Add(new OutlookBarItem());

            OutlookBarBand mu_recycle = new OutlookBarBand("电机回收");
            mu_recycle.SmallImageList = myShortcutsSmallIcons;
            mu_recycle.LargeImageList = myShortcutsLargeIcons;
            mu_recycle.Items.Add(new OutlookBarItem("回收合同", 0));
            mu_recycle.Items.Add(new OutlookBarItem("以旧换新", 1));

            OutlookBarBand mu_manufacture = new OutlookBarBand("电机再制造");
            mu_manufacture.SmallImageList = myShortcutsSmallIcons;
            mu_manufacture.LargeImageList = myShortcutsLargeIcons;
            mu_manufacture.Items.Add(new OutlookBarItem("采购合同", 0));
            mu_manufacture.Items.Add(new OutlookBarItem("购买信息", 1));

            OutlookBarBand mu_reports = new OutlookBarBand("报表");
            mu_reports.SmallImageList = myShortcutsSmallIcons;
            mu_reports.LargeImageList = myShortcutsLargeIcons;
            mu_reports.Items.Add(new OutlookBarItem("采购合同", 0));
            mu_reports.Items.Add(new OutlookBarItem("购买信息", 1));

            OutlookBarBand mu_sys = new OutlookBarBand("系统管理");
            mu_sys.SmallImageList = myShortcutsSmallIcons;
            mu_sys.LargeImageList = myShortcutsLargeIcons;
            mu_sys.Items.Add(new OutlookBarItem("用户管理", 0));
            mu_sys.Items.Add(new OutlookBarItem("基础数据管理", 0));
            //mu_sys.Items.Add(new OutlookBarItem("退出", 1));

            //mu_reports.Background = SystemColors.AppWorkspace;
            //mu_reports.TextColor = Color.White;
            _outlookBar.Bands.Add(mu_master);
            _outlookBar.Bands.Add(mu_recycle);
            _outlookBar.Bands.Add(mu_manufacture);
            //_outlookBar.Bands.Add(mu_reports);
            _outlookBar.Bands.Add(mu_sys);

            _outlookBar.Dock = DockStyle.Fill;
            _outlookBar.SetCurrentBand(1);
            _outlookBar.ItemClicked += new OutlookBarItemClickedHandler(OnOutlookBarItemClicked);
            //_outlookBar.ItemDropped += new OutlookBarItemDroppedHandler(OnOutlookBarItemDropped);
            plMenu.Controls.AddRange(new Control[] { _outlookBar });
        }

        void OnOutlookBarItemClicked(OutlookBarBand band, OutlookBarItem item)
        {
            switch (item.Text)
            {
                case "公司信息":
                    tsmi_company_Click(null, null);
                    break;
                case "部门信息":
                    tsmi_department_Click(null, null);
                    break;
                case "员工信息":
                    tsmi_employee_Click(null, null);
                    break;
                case "合作伙伴信息":
                    tsmi_partner_Click(null, null);
                    break;
                case "回收合同":
                    tsmi_RecoveryContract_Click(null, null);
                    break;
                case "以旧换新":
                    tsmi_NewForOld_Click(null, null);
                    break;
                case "购买信息":
                    tsmi_buy_Click(null, null);
                    break;
                case "采购合同":
                    tsmi_Purchase_Click(null, null);
                    break;
                case "用户管理":
                    tsmi_User_Click(null, null);
                    break;
                case "基础数据管理":
                    tsmi_base_Click(null, null);
                    break;
            }

            //string message = "Item : " + item.Text + " was clicked...";
            //MessageBox.Show(message);
        }

        void OnOutlookBarItemDropped(OutlookBarBand band, OutlookBarItem item)
        {
            //string message = "Item : " + item.Text + " was dropped...";
            //MessageBox.Show(message);
        }


        private void tsmi_User_Click(object sender, EventArgs e)
        {
            global.FormStyle(this, new frm_User_list(), "用户管理");
        }

        private void tsmi_base_Click(object sender, EventArgs e)
        {
            global.FormStyle(this, new frm_CodeProfire(), "基础数据管理");
        }



    }
}
