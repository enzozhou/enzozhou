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
    public partial class frm_organization_list : Form
    {
        public frm_organization_list()
        {
            InitializeComponent();
        }

        private void boolBtnAdd_Click(object sender, EventArgs e)
        {
            frm_organization _company = new frm_organization();
            global.FormDialog(_company, "公司信息");
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
                DataSet _ds = new BLL.BAS_Organization().GetListByPage(_sqlWhere, "ID", _pageStartIndex, _pageEndIndex);
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
                    DataSet _ds = new BLL.BAS_Organization().GetListByPage(_sqlWhere, "ID", _pageStartIndex, _pageEndIndex);
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
            this.dgv.Columns["Code"].DefaultCellStyle.Alignment
                = DataGridViewContentAlignment.MiddleRight;
            this.dgv.Columns["Code"].HeaderText = "代码";
            this.dgv.Columns["Name"].HeaderText = "名称";
            this.dgv.Columns["Membership"].HeaderText = "所属集团区县";
            this.dgv.Columns["EnterpriseNature"].HeaderText = "企业性质";
            this.dgv.Columns["TexNo"].HeaderText = "税号";
            this.dgv.Columns["Address"].HeaderText = "地址";
            this.dgv.Columns["WebSite"].HeaderText = "网站";
            this.dgv.Columns["BankName"].HeaderText = "银行名称";
            this.dgv.Columns["BankClass"].HeaderText = "银行类型";
            this.dgv.Columns["Account"].HeaderText = "银行账号";
            //this.dgv.Columns["RowStatus"].HeaderText = "";
            //this.dgv.Columns["CreateUserID"].HeaderText = "创建人";
            //this.dgv.Columns["CreateTime"].HeaderText = "创建时间";
            //this.dgv.Columns["UpdateUserID"].HeaderText = "编辑人";
            //this.dgv.Columns["UpdateTime"].HeaderText = "编辑时间";
            
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
            frm_organization _frm = new frm_organization();
            foreach (DataGridViewRow item in dgv.Rows)
            {
                if (item.Selected)
                {
                    if (int.TryParse(item.Cells["ID"].Value.ToString(), out _id))
                    {
                        //_id = int.Parse(item.Cells["ID"].Value.ToString());
                        _frm.ID = _id;
                        _frm.isUpdate = true;
                        global.FormDialog(_frm, "公司信息");
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

        private void QueryData()
        {
            _pageStartIndex = 1;
            _pageEndIndex = 1;

            BLL.BAS_Organization bll = new BLL.BAS_Organization();

            _sqlWhere = string.Format("code like '%{0}%' and ", txtCode.Text.Trim());
            _sqlWhere += string.Format("name like '%{0}%' and ", txtName.Text.Trim());
            _sqlWhere += string.Format("Membership like '%{0}%' and ", cmbMembership.Text.Trim());
            _sqlWhere += string.Format("EnterpriseNature like '%{0}%' ", txtEnterpriseNature.Text.Trim());
            _recordCount = bll.GetRecordCount(_sqlWhere);
            if (_recordCount > _pagesize) _pageEndIndex = _pagesize;

            DataSet _ds = bll.GetListByPage(_sqlWhere, "ID", 1, _pagesize);
            dgv.DataSource = _ds;
            dgv.DataMember = "ds";
            //this.dgv.RowsDefaultCellStyle.BackColor = Color.Bisque;
            setGridTitle();
        }

        private void ShowOrg(int id)
        {
            frm_organization _frm = new frm_organization();

            _frm.isUpdate = true;
            //_id = int.Parse(item.Cells["ID"].Value.ToString());
            _frm.ID = id;

            global.FormDialog(_frm, "公司信息");
            QueryData();
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = 0;
                int.TryParse(dgv.Rows[e.RowIndex].Cells["ID"].Value.ToString(), out id);
                ShowOrg(id);
            }
        }

        private void frm_organization_list_Load(object sender, EventArgs e)
        {
            global.BandBaseCodeComboBox(cmbMembership, "BCP00001");
            cmbMembership.SelectedIndex = -1;
        }
    }
}
