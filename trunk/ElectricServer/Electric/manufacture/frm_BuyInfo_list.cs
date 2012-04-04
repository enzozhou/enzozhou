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
    public partial class frm_BuyInfo_list : Form
    {
        public frm_BuyInfo_list()
        {
            InitializeComponent();
        }

        private void boolBtnAdd_Click(object sender, EventArgs e)
        {
            global.FormStyle((frm_Main)this.MdiParent, new frm_BuyInfo(), "购买信息");
        }

        private void toolBtnModify_Click(object sender, EventArgs e)
        {
            int _id = 0;
            frm_PurchaseContract _frm = new frm_PurchaseContract();
            foreach (DataGridViewRow item in dgv.Rows)
            {
                if (item.Selected)
                {
                    if (int.TryParse(item.Cells["ID"].Value.ToString(), out _id))
                    {
                        //_id = int.Parse(item.Cells["ID"].Value.ToString());
                        _frm.ID = _id;
                        _frm.isUpdate = true;
                        global.FormStyle((frm_Main)this.MdiParent, _frm, "采购合同");
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
                                Electric.Model.BS_BuyInfo model = new Electric.Model.BS_BuyInfo();
                                Electric.BLL.BS_BuyInfo bll = new Electric.BLL.BS_BuyInfo();
                                Electric.BLL.BS_BuyInfo_Details bllDetail = new Electric.BLL.BS_BuyInfo_Details();
                                model = bll.GetModel(_id);
                                List<Electric.Model.BS_BuyInfo_Details> _list = bllDetail.GetModelList(string.Format("ContractNo='{0}'", model.ContractNo));
                                string idList = "";
                                foreach (Electric.Model.BS_BuyInfo_Details _item in _list)
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
            BLL.BS_BuyInfo bll = new BLL.BS_BuyInfo();

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
        }

        private void btnUP_Click(object sender, EventArgs e)
        {
            if (_pageStartIndex >= _pagesize)
            {
                _pageStartIndex -= _pagesize;
                _pageEndIndex -= _pagesize;
                DataSet _ds = new BLL.BS_BuyInfo().GetListByPage(_sqlWhere, "ID", _pageStartIndex, _pageEndIndex);
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
                    DataSet _ds = new BLL.BS_BuyInfo().GetListByPage(_sqlWhere, "ID", _pageStartIndex, _pageEndIndex);
                    dgv.DataSource = _ds;
                    dgv.DataMember = "ds";
                    setGridTitle();
                }
            }


        }

        void setGridTitle()
        {
            global.SetDataGridViewStyle(dgv);
            dgv.Rows[1].Selected = true;
            //设置对齐方式
            this.dgv.Columns["ID"].Visible = false;
            this.dgv.Columns["row"].HeaderText = "编号";
            this.dgv.Columns["OrgCode"].HeaderText = "公司ID";
            this.dgv.Columns["OrgCode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgv.Columns["ContractNo"].HeaderText = "合同编号";
            this.dgv.Columns["PartnerCode"].HeaderText = "采购方代码";
            this.dgv.Columns["PartnerName"].HeaderText = "采购方名称";
            this.dgv.Columns["PartnerAddress"].HeaderText = "采购方地址";
            this.dgv.Columns["PartnerContract"].HeaderText = "采购方联系人";
            this.dgv.Columns["PartnerTel"].HeaderText = "采购方联系电话";
            this.dgv.Columns["BelongTo"].HeaderText = "所属县区集团";
            this.dgv.Columns["Ownership"].HeaderText = "所有制性质";
            this.dgv.Columns["TotalNewQty"].HeaderText = "新电机台数";
            this.dgv.Columns["BuyTime"].HeaderText = "销售时间";
            this.dgv.Columns["TotalNewPowerRating"].HeaderText = "新电机总功率";
            this.dgv.Columns["TotalNewQty"].HeaderText = "新电机台数";
            this.dgv.Columns["TotalNewPowerRating"].HeaderText = "新电机总功率";
            this.dgv.Columns["Ownership"].HeaderText = "新电机台数";
            this.dgv.Columns["TotalWeight"].HeaderText = "新电机总重量";
            this.dgv.Columns["TotalPurchasePrice"].HeaderText = "新电机采购总金额";

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
            DataSet dsItem = new Electric.BLL.BS_PurchaseContract_Details().GetList(string.Format("ContractNo = '{0}'", strContractNo));
            dgvItem.DataSource = dsItem;
            dgvItem.DataMember = "ds";
            global.SetDataGridViewStyle(dgvItem);
            this.dgvItem.Columns["OrgCode"].HeaderText = "公司ID";
            this.dgvItem.Columns["ContractNo"].HeaderText = "合同编号";
            this.dgvItem.Columns["ContractNo"].ReadOnly = true;
            this.dgvItem.Columns["InvoiceNo"].HeaderText = "发票号码";
            this.dgvItem.Columns["InvoiceDate"].HeaderText = "发票日期";
            this.dgvItem.Columns["NewModel"].HeaderText = "新电机型号";
            this.dgvItem.Columns["NewQty"].HeaderText = "新电机台数";
            this.dgvItem.Columns["NewRating"].HeaderText = "新电机功率";
            this.dgvItem.Columns["NewVoltage"].HeaderText = "新电机电压";
            this.dgvItem.Columns["NewSpeed"].HeaderText = "新电机额定转速";
            this.dgvItem.Columns["NewProtectionLev"].HeaderText = "新电机防护等级";
            this.dgvItem.Columns["NewMC"].HeaderText = "新电机制造企业";
            this.dgvItem.Columns["NewWeight"].HeaderText = "新电机重量";
            this.dgvItem.Columns["Price"].HeaderText = "销售金额";
            this.dgvItem.Columns["TerminalUnit"].HeaderText = "终端产品";
            this.dgvItem.Columns["TUNo"].HeaderText = "终端产品编号";
            this.dgvItem.Columns["NewSerialNum"].HeaderText = "新电机生产编号";

            this.dgvItem.Columns["ID"].Visible = false;
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

        /// <summary>
        /// 双击显示detail详细
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

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
