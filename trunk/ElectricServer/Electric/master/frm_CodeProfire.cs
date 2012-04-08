using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Electric
{
    public partial class frm_CodeProfire : Form
    {
        public frm_CodeProfire()
        {
            InitializeComponent();
        }

        void DataBanding()
        {
            DataSet _ds = new Electric.BLL.BAS_CodeProfire().GetList("CodeType ='CUS'");
            //DataSet _ds = new Electric.BLL.BAS_CodeProfire().GetList("");
            dgvHead.DataSource = _ds;
            dgvHead.DataMember = "ds";
            global.SetDataGridViewStyle(dgvHead);
            if (_ds.Tables[0].Rows.Count > 0)
            {
                dgvHead.Rows[1].Selected = true;
                dgvHead_CellClick(null, null);
            }

            //设置对齐方式

            this.dgvHead.Columns["SelectCode"].HeaderText = "编号";
            this.dgvHead.Columns["Description"].HeaderText = "描述";
            this.dgvHead.Columns["ID"].Visible = false;
            this.dgvHead.Columns["SelectCode"].Visible = false;
            this.dgvHead.Columns["SEQ"].Visible = false;
            this.dgvHead.Columns["CodeType"].Visible = false;
            this.dgvHead.Columns["Remarks"].Visible = false;
            //this.dgv.Columns["排序"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvHead.Columns["CreateUserID"].Visible = false;
            this.dgvHead.Columns["CreateTime"].Visible = false;
            this.dgvHead.Columns["UpdateUserID"].Visible = false;
            this.dgvHead.Columns["UpdateTime"].Visible = false;
        }


        private void dgvHead_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvItem.IsCurrentCellDirty)
            {
                MessageBox.Show("IsCurrentCellDirty");
                return;
            }

            string strSelectCode = dgvHead.Rows[dgvHead.CurrentRow.Index].Cells["SelectCode"].Value.ToString();
            DataSet dsItem = new Electric.BLL.BAS_Code().GetList(string.Format("SelectCode = '{0}'", strSelectCode));
            dgvItem.DataSource = dsItem;
            dgvItem.DataMember = "ds";
            this.dgvItem.Columns["SelectCode"].ReadOnly = true;
            this.dgvItem.Columns["Code"].ReadOnly = true;

            //global.SetDataGridViewStyle(dgvItem);
            this.dgvItem.Columns["SelectCode"].HeaderText = "上层编号";
            this.dgvItem.Columns["Description"].HeaderText = "描述";
            this.dgvItem.Columns["SEQ"].HeaderText = "排序";
            //this.dgv.Columns["排序"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvItem.Columns["ID"].Visible = false;
            this.dgvItem.Columns["Code"].Visible = false;
            this.dgvItem.Columns["SelectCode"].Visible = false;
            this.dgvItem.Columns["CreateUserID"].Visible = false;
            this.dgvItem.Columns["CreateTime"].Visible = false;
            this.dgvItem.Columns["UpdateUserID"].Visible = false;
            this.dgvItem.Columns["UpdateTime"].Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string strSelectCode = dgvHead.Rows[dgvHead.CurrentRow.Index].Cells["SelectCode"].Value.ToString();
            int iTmp = 0;
            Electric.Model.BAS_Code modelDetail;
            Electric.BLL.BAS_Code bll = new Electric.BLL.BAS_Code();
            bool bl = dgvItem.Columns.Contains("ID");//判断是要新增还是修改
            foreach (DataGridViewRow item in dgvItem.Rows)
            {
                if (item.Cells["Description"].Value != null || item.Cells["SEQ"].Value != null)
                {
                    modelDetail = new Electric.Model.BAS_Code();
                    modelDetail.Description = global.ConvertObject(item.Cells["Description"].Value);
                    int.TryParse(global.ConvertObject(item.Cells["SEQ"].Value), out iTmp);
                    modelDetail.SEQ = iTmp;
                    modelDetail.SelectCode = strSelectCode;
                    if (modelDetail.Description != "" || modelDetail.SEQ > 0)
                    {
                        if (global.ConvertObject(item.Cells["Code"].Value) == "")
                        {
                            modelDetail.Code = "BS" + global.GenerateCode(5, bll.GetMaxId().ToString());
                            bll.Add(modelDetail);
                        }
                        else
                        {
                            modelDetail.Code = global.ConvertObject(item.Cells["Code"].Value);
                            int tmp = 0;
                            int.TryParse(global.ConvertObject(item.Cells["ID"].Value), out tmp);
                            bll.Delete(tmp);
                            bll.Add(modelDetail);
                        }
                    }
                }
            }
            MessageBox.Show("保存成功。");
            dgvHead_CellClick(null, null);
        }

        private void frm_CodeProfire_Load(object sender, EventArgs e)
        {
            DataBanding();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void frm_CodeProfire_AutoSizeChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            btnSave.Width = 75;
            btnSave.Height = 23;
            btnClose.Width = 75;
            btnClose.Height = 23;
        }

    }
}
