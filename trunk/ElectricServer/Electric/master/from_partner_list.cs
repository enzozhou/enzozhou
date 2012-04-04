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
    public partial class from_partner_list : Form
    {
        public from_partner_list()
        {
            InitializeComponent();
        }

        private void boolBtnAdd_Click(object sender, EventArgs e)
        {
            frm_partner _frm = new frm_partner();
            global.FormDialog(_frm, "合作伙伴");
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

            BLL.BAS_Partner bll = new BLL.BAS_Partner();
            _sqlWhere = string.Format("code like '%{0}%' and ", txtCode.Text.Trim());
            _sqlWhere += string.Format("name like '%{0}%' and ", txtName.Text.Trim());
            _sqlWhere += string.Format("orgCode like '%{0}%' ", txtOrgCode.Text.Trim());
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
                DataSet _ds = new BLL.BAS_Partner().GetListByPage(_sqlWhere, "ID", _pageStartIndex, _pageEndIndex);
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
                    DataSet _ds = new BLL.BAS_Partner().GetListByPage(_sqlWhere, "ID", _pageStartIndex, _pageEndIndex);
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
            this.dgv.Columns["OrgCodeSYS"].Visible = false;
            //this.dgvData.Columns["总计"].Width = 100;//Enzo 20111005

            //设置对齐方式
            this.dgv.Columns["row"].HeaderText = "编号";
            this.dgv.Columns["Code"].DefaultCellStyle.Alignment
                = DataGridViewContentAlignment.MiddleRight;
            this.dgv.Columns["Code"].HeaderText = "代码";
            this.dgv.Columns["Name"].HeaderText = "企业名称";
            this.dgv.Columns["OrgCode"].HeaderText = "公司ID";
            this.dgv.Columns["PartnerClass"].HeaderText = "伙伴类型";
            this.dgv.Columns["Address"].HeaderText = "企业地址";
            this.dgv.Columns["Corporate"].HeaderText = "企业法人代表";
            this.dgv.Columns["OrgCode"].HeaderText = "组织机构代码";
            this.dgv.Columns["Licence"].HeaderText = "营业执照号码";
            this.dgv.Columns["TaxNo"].HeaderText = "税号";
            this.dgv.Columns["Ownership"].HeaderText = "所有制性质";
            this.dgv.Columns["RegisteredCapital"].HeaderText = "注册资金";
            this.dgv.Columns["Supervisor"].HeaderText = "上级主管部门";
            this.dgv.Columns["FixedAssets"].HeaderText = "固定资产";
            this.dgv.Columns["EnterpriseNum"].HeaderText = "企业人数";
            this.dgv.Columns["Contract"].HeaderText = "联系人";
            this.dgv.Columns["Tel"].HeaderText = "联系电话";
            this.dgv.Columns["Email"].HeaderText = "邮箱";
            this.dgv.Columns["ETC"].HeaderText = "生产企业技术中心";
            this.dgv.Columns["LYSV"].HeaderText = "前一年销售量";
            this.dgv.Columns["YBLSV"].HeaderText = "前二年销售量";
            this.dgv.Columns["YBLSV"].HeaderText = "生产企业技术中心";
            this.dgv.Columns["BankName"].HeaderText = "开户名称";
            this.dgv.Columns["BankClass"].HeaderText = "开户银行";
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
            this.dgv.Columns["SubmitUserID"].Visible = false;
            this.dgv.Columns["SubmitTime"].Visible = false;
            this.dgv.Columns["ApproveUserID"].Visible = false;
            this.dgv.Columns["ApproveTime"].Visible = false;
        }

        private void toolBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolBtnModify_Click(object sender, EventArgs e)
        {
            int _id = 0;
            frm_partner _frm = new frm_partner();
            foreach (DataGridViewRow item in dgv.Rows)
            {
                if (item.Selected)
                {
                    if (int.TryParse(item.Cells["ID"].Value.ToString(), out _id))
                    {
                        //_id = int.Parse(item.Cells["ID"].Value.ToString());
                        _frm.ID = _id;
                        _frm.isUpdate = true;
                        global.FormDialog(_frm, "合作伙伴");
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
                                new Electric.BLL.BAS_Partner().Delete(_id);
                                btnSearch_Click(null, null);//删除后刷新列表
                            }
                        }
                    }
                    return;
                }
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                toolBtnModify_Click(null, null);
            }
        }
    }
}
