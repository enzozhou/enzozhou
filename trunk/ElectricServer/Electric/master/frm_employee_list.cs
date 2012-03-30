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
    public partial class frm_employee_list : Form
    {
        public frm_employee_list()
        {
            InitializeComponent();
            cmbGender.SelectedIndex = 0;
        }

        private void boolBtnAdd_Click(object sender, EventArgs e)
        {
            frm_employee _model = new frm_employee();
            global.FormDialog(_model, "员工信息");
        }

        private int _pageStartIndex = 1;
        private int _pageEndIndex = 1;
        private string _sqlWhere = "";
        private int _recordCount;
        private int _pagesize = global.pageSize;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            _pageStartIndex = 1;
            _pageEndIndex = 1;

            BLL.BAS_Employess bll = new BLL.BAS_Employess();

            _sqlWhere = string.Format("orgId like '%{0}%' and ", txtOrgID.Text.Trim());
            _sqlWhere += string.Format("code like '%{0}%' and ", txtCode.Text.Trim());
            _sqlWhere += string.Format("name like '%{0}%' and ", txtName.Text.Trim());
            _sqlWhere += string.Format("deparment like '%{0}%' and ", txtDep.Text.Trim());
            _sqlWhere += string.Format("Gender = {0} ", cmbGender.Text.Trim() == "男" ? 1 : 0);
            _recordCount = bll.GetRecordCount(_sqlWhere);
            if (_recordCount > _pagesize) _pageEndIndex = _pagesize;

            DataSet _ds = bll.GetListByPage(_sqlWhere, "ID", 1, _pagesize);
            dgv.DataSource = _ds;
            dgv.DataMember = "ds";
            //this.dgv.RowsDefaultCellStyle.BackColor = Color.Bisque;
            setGridTitle();
        }

        private void btnUP_Click(object sender, EventArgs e)
        {
            if (_pageStartIndex >= _pagesize)
            {
                _pageStartIndex -= _pagesize;
                _pageEndIndex -= _pagesize;
                DataSet _ds = new BLL.BAS_Employess().GetListByPage(_sqlWhere, "ID", _pageStartIndex, _pageEndIndex);
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
                    DataSet _ds = new BLL.BAS_Employess().GetListByPage(_sqlWhere, "ID", _pageStartIndex, _pageEndIndex);
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
            //this.dgvData.Columns["总计"].Width = 100;//Enzo 20111005

            //设置对齐方式
            this.dgv.Columns["row"].HeaderText = "编号";
            this.dgv.Columns["OrgID"].HeaderText = "公司ID";

            this.dgv.Columns["Code"].DefaultCellStyle.Alignment
                = DataGridViewContentAlignment.MiddleRight;
            this.dgv.Columns["Code"].HeaderText = "代码";
            this.dgv.Columns["Name"].HeaderText = "名称";
            this.dgv.Columns["Gender"].HeaderText = "性别";
            this.dgv.Columns["Tel"].HeaderText = "联系电话";
            this.dgv.Columns["Email"].HeaderText = "邮箱";
            this.dgv.Columns["Fax"].HeaderText = "传真";
            this.dgv.Columns["Mobile"].HeaderText = "手机";
            this.dgv.Columns["Deparment"].HeaderText = "部门";
            //this.dgv.Columns["RowStatus"].HeaderText = "";
            //this.dgv.Columns["CreateUserID"].HeaderText = "创建人";
            //this.dgv.Columns["CreateTime"].HeaderText = "创建时间";
            //this.dgv.Columns["UpdateUserID"].HeaderText = "编辑人";
            //this.dgv.Columns["UpdateTime"].HeaderText = "编辑时间";
            this.dgv.Columns["CreateUserID"].Visible = false;
            this.dgv.Columns["CreateTime"].Visible = false;
            this.dgv.Columns["UpdateUserID"].Visible = false;
            this.dgv.Columns["UpdateTime"].Visible = false;
            this.dgv.Columns["CancelUserID"].Visible = false;
            this.dgv.Columns["CancelTime"].Visible = false;
        }

        private void toolBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolBtnModify_Click(object sender, EventArgs e)
        {
            int _id = 0;
            frm_employee _frm = new frm_employee();
            foreach (DataGridViewRow item in dgv.Rows)
            {
                if (item.Selected)
                {
                    if (int.TryParse(item.Cells["ID"].Value.ToString(), out _id))
                    {
                        //_id = int.Parse(item.Cells["ID"].Value.ToString());
                        _frm.ID = _id;
                        _frm.isUpdate = true;
                        global.FormDialog(_frm, "员工信息");
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
                                new Electric.BLL.BAS_Organization().Delete(_id);
                                btnSearch_Click(null, null);//删除后刷新列表
                            }
                        }
                    }
                    return;
                }
            }
        }

    }
}
