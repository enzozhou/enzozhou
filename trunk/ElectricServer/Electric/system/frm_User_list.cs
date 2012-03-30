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
    public partial class frm_User_list : Form
    {
        public frm_User_list()
        {
            InitializeComponent();
        }

        private void boolBtnAdd_Click(object sender, EventArgs e)
        {
            frm_User _User = new frm_User();
            _User.isUpdate = false;

            global.FormDialog(_User, "用户信息");

            QueryData();
        }

        private int _pageStartIndex = 1;
        private int _pageEndIndex = 1;
        private string _sqlWhere = "";
        private int _recordCount;
        private int _pagesize = global.pageSize;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            QueryData();
        }

        private void btnUP_Click(object sender, EventArgs e)
        {
            if (_pageStartIndex >= _pagesize)
            {
                _pageStartIndex -= _pagesize;
                _pageEndIndex -= _pagesize;
                DataSet _ds = new BLL.SYS_User().GetListByPage(_sqlWhere, "ID", _pageStartIndex, _pageEndIndex);
                dgv.DataSource = _ds;
                dgv.DataMember = "ds";
                setGridTitle();
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (_recordCount >= _pageEndIndex)
            {

                if ((_recordCount / _pageEndIndex > 1) || _recordCount % _pageEndIndex >= 1)
                {
                    _pageStartIndex += _pagesize;
                    _pageEndIndex += _pagesize;
                    DataSet _ds = new BLL.SYS_User().GetListByPage(_sqlWhere, "ID", _pageStartIndex, _pageEndIndex);
                    dgv.DataSource = _ds;
                    dgv.DataMember = "ds";
                    setGridTitle();
                }
            }


        }

        void setGridTitle()
        {
            global.SetDataGridViewStyle(dgv);
            this.dgv.Columns["ID"].Visible = false;
            this.dgv.Columns["RowStatus"].Visible = false;
            //this.dgvData.Columns["总计"].Width = 100;//Enzo 20111005

            //设置对齐方式
            this.dgv.Columns["row"].HeaderText = "编号";
            //this.dgv.Columns["Code"].DefaultCellStyle.Alignment
            //    = DataGridViewContentAlignment.MiddleRight;
            this.dgv.Columns["Code"].HeaderText = "代码";
            this.dgv.Columns["Name"].HeaderText = "名称";
            this.dgv.Columns["Pwd"].HeaderText = "密码";
            this.dgv.Columns["IsAdmin"].HeaderText = "管理员";
            //this.dgv.Columns["RowStatus"].HeaderText = "";
            //this.dgv.Columns["CreateUserID"].HeaderText = "创建人";
            //this.dgv.Columns["CreateTime"].HeaderText = "创建时间";
            //this.dgv.Columns["UpdateUserID"].HeaderText = "编辑人";
            //this.dgv.Columns["UpdateTime"].HeaderText = "编辑时间";

            this.dgv.Columns["row"].Visible = false;
            this.dgv.Columns["Pwd"].Visible = false;
            this.dgv.Columns["CreateUserID"].Visible = false;
            this.dgv.Columns["CreateTime"].Visible = false;
            this.dgv.Columns["UpdateUserID"].Visible = false;
            this.dgv.Columns["UpdateTime"].Visible = false;
        }

        private void toolBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolBtnModify_Click(object sender, EventArgs e)
        {
            int _id = 0;


            foreach (DataGridViewRow item in dgv.Rows)
            {
                if (item.Selected)
                {
                    if (int.TryParse(item.Cells["ID"].Value.ToString(), out _id))
                    {
                        ShowUser(_id);
                    }
                    return;
                }
            }
        }

        private void toolBtnDelete_Click(object sender, EventArgs e)
        {
            int _id = 0;
            foreach (DataGridViewRow item in dgv.Rows)
            {
                if (item.Selected)
                {
                    if (int.TryParse(item.Cells["ID"].Value.ToString(), out _id))
                    {
                        //_id = int.Parse(item.Cells["ID"].Value.ToString());
                        if (_id > 0)
                        {
                            DialogResult _result = MessageBox.Show("确定删除", "删除", MessageBoxButtons.YesNo);
                            if (_result == DialogResult.Yes)
                            {
                                new Electric.BLL.SYS_User().Delete(_id);
                                btnSearch_Click(null, null);//删除后刷新列表
                            }
                        }
                    }
                    return;
                }
            }
        }

        private void QueryData()
        {
            _pageStartIndex = 1;
            _pageEndIndex = 1;

            BLL.SYS_User bll = new BLL.SYS_User();

            _sqlWhere = string.Format("code like '%{0}%' and ", txtCode.Text.Trim());
            _sqlWhere += string.Format("name like '%{0}%'  ", txtName.Text.Trim());
            _recordCount = bll.GetRecordCount(_sqlWhere);
            if (_recordCount > _pagesize) _pageEndIndex = _pagesize;

            DataSet _ds = bll.GetListByPage(_sqlWhere, "ID", 1, _pagesize);
            dgv.DataSource = _ds;
            dgv.DataMember = "ds";
            //this.dgv.RowsDefaultCellStyle.BackColor = Color.Bisque;
            setGridTitle();
        }

        private void ShowUser(int id)
        {
            frm_User _frm = new frm_User();

            _frm.isUpdate = true;
            //_id = int.Parse(item.Cells["ID"].Value.ToString());
            _frm.ID = id;

            global.FormDialog(_frm, "用户信息");
            QueryData();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = 0;
            int.TryParse(dgv.Rows[e.RowIndex].Cells["ID"].Value.ToString(), out id);

            ShowUser(id);
        }

    }
}
