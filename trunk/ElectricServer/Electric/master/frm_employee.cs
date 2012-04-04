﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Maticsoft.Common;

namespace Electric
{
    public partial class frm_employee : Form
    {
        public frm_employee()
        {
            InitializeComponent();
        }
        private int _id = 0;
        public int ID
        {
            set { _id = value; }
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
                    strErr += "代码不能为空.\n";
                }
                if (this.txtName.Text.Trim().Length == 0)
                {
                    strErr += "名称不能为空.\n";
                }
                //if (this.txtTel.Text.Trim().Length == 0)
                //{
                //    strErr += "电话不能为空.\n";
                //}
                //if (this.txtEmail.Text.Trim().Length == 0)
                //{
                //    strErr += "邮箱不能为空.\n";
                //}
                //if (this.txtFax.Text.Trim().Length == 0)
                //{
                //    strErr += "传真不能为空.\n";
                //}
                //if (this.txtMobile.Text.Trim().Length == 0)
                //{
                //    strErr += "手机不能为空.\n";
                //}
                //if (this.txtDeparment.Text.Trim().Length == 0)
                //{
                //    strErr += "部门不能为空.\n";
                //}


                if (strErr != "")
                {
                    System.Windows.Forms.MessageBox.Show(this, strErr);
                    return;
                }

                string Code = this.txtCode.Text;
                string Name = this.txtName.Text;
                int Gender = 0;

                if (cmbGender.Text == "男")
                {
                    Gender = 0;
                }
                else
                {
                    Gender = 1;
                }
                string Tel = this.txtTel.Text;
                string Email = this.txtEmail.Text;
                string Fax = this.txtFax.Text;
                string Mobile = this.txtMobile.Text;
                string Deparment = this.cmbDep.Text;
                int CreateUserID = global.UserID;
                DateTime CreateTime = DateTime.Now;
                int UpdateUserID = global.UserID;
                DateTime UpdateTime = DateTime.Now;
                int CancelUserID = global.UserID;
                DateTime CancelTime = DateTime.Now;


                Electric.Model.BAS_Employess model = new Electric.Model.BAS_Employess();
                model.OrgCode = global.OrganizationCode;
                model.Code = Code;
                model.Name = Name;
                model.Gender = Gender;
                model.Tel = Tel;
                model.Email = Email;
                model.Fax = Fax;
                model.Mobile = Mobile;
                model.Deparment = Deparment;
                model.CreateUserID = CreateUserID;
                model.CreateTime = CreateTime;
                model.UpdateUserID = UpdateUserID;
                model.UpdateTime = UpdateTime;
                model.CancelUserID = CancelUserID;
                model.CancelTime = CancelTime;


                Electric.BLL.BAS_Employess bll = new Electric.BLL.BAS_Employess();
                if (!_isUpdate)
                {
                    model.CreateUserID = CreateUserID;
                    model.CreateTime = CreateTime;
                    int _i = bll.Add(model);
                    if (_i >= 1)
                    {
                        System.Windows.Forms.MessageBox.Show("保存成功。");
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("保存失败。");
                    }
                }
                else
                {
                    model.CreateTime = modelChange.CreateTime;
                    model.CreateUserID = modelChange.CreateUserID;
                    model.CancelTime = modelChange.CancelTime;
                    model.CancelUserID = modelChange.CancelUserID;
                    model.UpdateUserID = UpdateUserID;
                    model.UpdateTime = UpdateTime;
                    model.ID = _id;
                    bool _b = bll.Update(model);
                    if (_b)
                    {
                        System.Windows.Forms.MessageBox.Show("保存成功。");
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("保存失败。");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        Electric.Model.BAS_Employess modelChange = new Electric.Model.BAS_Employess();
        private void showUpdate()
        {
            Electric.BLL.BAS_Employess bll = new Electric.BLL.BAS_Employess();
            modelChange = bll.GetModel(_id);
            this.txtCode.Text = modelChange.Code;
            this.txtName.Text = modelChange.Name;
            this.txtMobile.Text = modelChange.Mobile;
            this.txtTel.Text = modelChange.Tel;
            this.txtFax.Text = modelChange.Fax;
            this.txtEmail.Text = modelChange.Email;
            cmbGender.SelectedIndex = int.Parse(modelChange.Gender.ToString());
            global.SetComboBoxDefaultValue(cmbDep, modelChange.ID.ToString());
            ControlEnabled();
        }

        void band()
        {
            DataSet _ds = new Electric.BLL.BAS_Department().GetList("");
            global.BandComboBox(cmbDep, _ds, "ID", "Name");
        }

        private void frm_employee_Load(object sender, EventArgs e)
        {
            band();
            txtOrg.Text = global.OrganizationName;
            if (_isUpdate)
            {
                showUpdate();
            }
            else
            {
                cmbGender.SelectedIndex = 0;
            }
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

    }
}
