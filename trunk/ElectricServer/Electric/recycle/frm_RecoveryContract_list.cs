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
    public partial class frm_RecoveryContract_list : Form
    {
        public frm_RecoveryContract_list()
        {
            InitializeComponent();
        }

        private void boolBtnAdd_Click(object sender, EventArgs e)
        {
            //global.FormDialog(new frm_RecoveryContract(), "回收合同");
            global.FormStyle((frm_Main)this.MdiParent, new frm_RecoveryContract(), "回收合同");
        }

        private void toolBtnModify_Click(object sender, EventArgs e)
        {
            int _id = 0;
            frm_RecoveryContract _frm = new frm_RecoveryContract();
            foreach (DataGridViewRow item in dgv.Rows)
            {
                if (item.Selected)
                {
                    if (int.TryParse(item.Cells["ID"].Value.ToString(), out _id))
                    {
                        //_id = int.Parse(item.Cells["ID"].Value.ToString());
                        _frm.ID = _id;
                        _frm.isUpdate = true;
                        global.FormStyle((frm_Main)this.MdiParent, _frm, "回收合同");
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
                                Electric.Model.BS_RecoveryContract model = new Electric.Model.BS_RecoveryContract();
                                Electric.BLL.BS_RecoveryContract bll = new Electric.BLL.BS_RecoveryContract();
                                Electric.BLL.BS_RecoveryContract_Details bllDetail = new Electric.BLL.BS_RecoveryContract_Details();
                                model = bll.GetModel(_id);
                                List<Electric.Model.BS_RecoveryContract_Details> _list = bllDetail.GetModelList(model.ContractNo);
                                string idList = "";
                                foreach (Electric.Model.BS_RecoveryContract_Details _item in _list)
                                {
                                    idList += string.Format("{0},", _item.ID);
                                }
                                idList = idList.Remove(idList.Length - 1);
                                //删除item 
                                bllDetail.DeleteList(idList);
                                bll.Delete(_id);
                                btnSearch_Click(null, null);//删除后刷新列表
                            }
                        }
                    }
                    return;
                }
            }
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
            BLL.BS_RecoveryContract bll = new BLL.BS_RecoveryContract();

            _sqlWhere = string.Format("ContractNo like '%{0}%' and ", txtContractNo.Text.Trim());
            _sqlWhere += string.Format("PartnerCode like '%{0}%' and ", txtPartnerCode.Text.Trim());
            _sqlWhere += string.Format("PartnerName like '%{0}%'  ", txtPartnerName.Text.Trim());
            _recordCount = bll.GetRecordCount(_sqlWhere);
            if (_recordCount > _pagesize) _pageEndIndex = _pagesize;

            DataSet _ds = bll.GetListByPage("", "ID", 1, _pagesize);
            dgv.DataSource = _ds;
            dgv.DataMember = "ds";
            //this.dgv.RowsDefaultCellStyle.BackColor = Color.Bisque;
            setGridTitle();
            if (_ds.Tables[0].Rows.Count > 0)
            {
                dgv.Rows[0].Selected = true;
                //dgvHead_CellClick(null, null);
            }
        }

        private void btnUP_Click(object sender, EventArgs e)
        {
            if (_pageStartIndex >= _pagesize)
            {
                _pageStartIndex -= _pagesize;
                _pageEndIndex -= _pagesize;
                DataSet _ds = new BLL.BS_RecoveryContract().GetListByPage(_sqlWhere, "ID", _pageStartIndex, _pageEndIndex);
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
                    DataSet _ds = new BLL.BS_RecoveryContract().GetListByPage(_sqlWhere, "ID", _pageStartIndex, _pageEndIndex);
                    dgv.DataSource = _ds;
                    dgv.DataMember = "ds";
                    setGridTitle();
                }
            }


        }

        void setGridTitle()
        {
            global.SetDataGridViewStyle(dgv);


            //设置对齐方式
            this.dgv.Columns["ID"].Visible = false;
            this.dgv.Columns["row"].HeaderText = "编号";
            this.dgv.Columns["OrgCode"].HeaderText = "公司ID";
            this.dgv.Columns["OrgCode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgv.Columns["ContractNo"].HeaderText = "合同编号";
            this.dgv.Columns["PartnerCode"].HeaderText = "交售方代码";
            this.dgv.Columns["PartnerName"].HeaderText = "交售方名称";
            this.dgv.Columns["PartnerAddress"].HeaderText = "交售方地址";
            this.dgv.Columns["PartnerContract"].HeaderText = "交售方联系人";

            this.dgv.Columns["PartnerTel"].HeaderText = "交售方联系电话";
            this.dgv.Columns["PartnerBank"].HeaderText = "交售方开户行";
            this.dgv.Columns["PartnerAccount"].HeaderText = "交售方账号";
            this.dgv.Columns["PartnerTaxNo"].HeaderText = "交售方税号";
            this.dgv.Columns["DeliveryTerm"].HeaderText = "设备交付期限";
            this.dgv.Columns["Price"].HeaderText = "合同金额";
            this.dgv.Columns["Words"].HeaderText = "合同金额(大写) ";
            this.dgv.Columns["FPP"].HeaderText = "第一次预付期限";
            this.dgv.Columns["FPR"].HeaderText = "第一次预付比率";
            this.dgv.Columns["SPP"].HeaderText = "第二次预付期限";
            this.dgv.Columns["SPR"].HeaderText = "第二次预付比率";
            this.dgv.Columns["LPP"].HeaderText = "最后一次预付期限";
            this.dgv.Columns["LPR"].HeaderText = "最后一次预付比率";

            this.dgv.Columns["CreateUserID"].Visible = false;
            this.dgv.Columns["CreateTime"].Visible = false;
            this.dgv.Columns["UpdateUserID"].Visible = false;
            this.dgv.Columns["UpdateTime"].Visible = false;
            this.dgv.Columns["SubmitUserID"].Visible = false;
            this.dgv.Columns["SubmitTime"].Visible = false;
            this.dgv.Columns["ApproveUserID"].Visible = false;
            this.dgv.Columns["ApproveTime"].Visible = false;

        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string strContractNo = dgv.Rows[e.RowIndex].Cells["ContractNo"].Value.ToString();
            DataSet dsItem = new Electric.BLL.BS_RecoveryContract_Details().GetList(string.Format("ContractNo = '{0}'", strContractNo));
            dgvItem.DataSource = dsItem;
            dgvItem.DataMember = "ds";
            global.SetDataGridViewStyle(dgvItem);
            this.dgvItem.Columns["Model"].HeaderText = "型号";
            this.dgvItem.Columns["Qty"].HeaderText = "台数";
            this.dgvItem.Columns["PowerRating"].HeaderText = "额定功率";
            this.dgvItem.Columns["UnitPrice"].HeaderText = "回收单价";
            this.dgvItem.Columns["Price"].HeaderText = "回收金额";
            this.dgvItem.Columns["BuyPower"].HeaderText = "购买电机功率";
            this.dgvItem.Columns["Subsidy"].HeaderText = "补贴";
            this.dgvItem.Columns["SumPrice"].HeaderText = "合计金额";
            this.dgvItem.Columns["OrgCode"].HeaderText = "公司ID";
            this.dgvItem.Columns["ContractNo"].HeaderText = "合同编号";

            this.dgvItem.Columns["ID"].Visible = false;
            this.dgvItem.Columns["CreateUserID"].Visible = false;
            this.dgvItem.Columns["CreateTime"].Visible = false;
            this.dgvItem.Columns["UpdateUserID"].Visible = false;
            this.dgvItem.Columns["UpdateTime"].Visible = false;
        }

        private void toolBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
