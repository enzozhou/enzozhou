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
    public partial class frm_NewForOld_list : Form
    {
        public frm_NewForOld_list()
        {
            InitializeComponent();
        }

        private void boolBtnAdd_Click(object sender, EventArgs e)
        {
            global.FormStyle((frm_Main)this.MdiParent, new frm_NewForOld(), "以旧换新");
        }

        private void toolBtnModify_Click(object sender, EventArgs e)
        {
            int _id = 0;
            frm_NewForOld _frm = new frm_NewForOld();
            foreach (DataGridViewRow item in dgv.Rows)
            {
                if (item.Selected)
                {
                    if (int.TryParse(item.Cells["ID"].Value.ToString(), out _id))
                    {
                        //_id = int.Parse(item.Cells["ID"].Value.ToString());
                        _frm.ID = _id;
                        _frm.isUpdate = true;
                        global.FormStyle((frm_Main)this.MdiParent, _frm, "以旧换新");
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
                                Electric.Model.BS_NewForOld model = new Electric.Model.BS_NewForOld();
                                Electric.BLL.BS_NewForOld bll = new Electric.BLL.BS_NewForOld();
                                Electric.BLL.BS_NewForOld_Details bllDetail = new Electric.BLL.BS_NewForOld_Details();
                                model = bll.GetModel(_id);
                                List<Electric.Model.BS_NewForOld_Details> _list = bllDetail.GetModelList(string.Format("ContractNo='{0}'", model.ContractNo));
                                string idList = "";
                                foreach (Electric.Model.BS_NewForOld_Details _item in _list)
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
            BLL.BS_NewForOld bll = new BLL.BS_NewForOld();

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
                DataSet _ds = new BLL.BS_NewForOld().GetListByPage(_sqlWhere, "ID", _pageStartIndex, _pageEndIndex);
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
                    DataSet _ds = new BLL.BS_NewForOld().GetListByPage(_sqlWhere, "ID", _pageStartIndex, _pageEndIndex);
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
            this.dgv.Columns["BelongTo"].HeaderText = "所属县区集团";
            this.dgv.Columns["Ownership"].HeaderText = "所有制性质";

            this.dgv.Columns["BuyTime"].HeaderText = "回购时间";
            this.dgv.Columns["InvoiceNo"].HeaderText = "发票号码";
            this.dgv.Columns["TotalOldQty"].HeaderText = "旧电机总台数";
            this.dgv.Columns["TotalPowerRating"].HeaderText = "旧电机总额定功率";
            this.dgv.Columns["TotalOldPrice"].HeaderText = "旧电机总回购小计";
            this.dgv.Columns["TotalOldSubsidy"].HeaderText = "旧电机总补贴";
            this.dgv.Columns["TotalOldSumPrice"].HeaderText = "回购总计";
            this.dgv.Columns["TotalNewPowerRating"].HeaderText = "新电机总功率";
            this.dgv.Columns["TotalNewQty"].HeaderText = "新电机台数";
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
            DataSet dsItem = new Electric.BLL.BS_NewForOld_Details().GetList(string.Format("ContractNo = '{0}'", strContractNo));
            dgvItem.DataSource = dsItem;
            dgvItem.DataMember = "ds";
            global.SetDataGridViewStyle(dgvItem);
            this.dgvItem.Columns["OrgCode"].HeaderText = "公司ID";
            this.dgvItem.Columns["ContractNo"].HeaderText = "合同编号";
            this.dgvItem.Columns["OldModel"].HeaderText = "旧电机型号";
            this.dgvItem.Columns["OldPowerRating"].HeaderText = "旧电机额定功率";
            this.dgvItem.Columns["OldQty"].HeaderText = "旧电机台数";
            this.dgvItem.Columns["OldSpeed"].HeaderText = "旧电机额定转速";
            this.dgvItem.Columns["OldProtectionLev"].HeaderText = "旧电机防护等级";
            this.dgvItem.Columns["OldOutDate"].HeaderText = "旧电机出场年月";
            this.dgvItem.Columns["OldWeight"].HeaderText = "旧电机重量";
            this.dgvItem.Columns["OldPrice"].HeaderText = "旧电机回购小计";
            this.dgvItem.Columns["OldSubsidy"].HeaderText = "回购补贴";
            this.dgvItem.Columns["OldSumPrice"].HeaderText = "回购合计";
            this.dgvItem.Columns["TerminalUnit"].HeaderText = "替换终端";
            this.dgvItem.Columns["TUNo"].HeaderText = "替换终端编号";
            this.dgvItem.Columns["NewModel"].HeaderText = "新电机型号";
            this.dgvItem.Columns["NewPowerRating"].HeaderText = "新电机功率";
            this.dgvItem.Columns["NewQty"].HeaderText = "新电机台数";
            this.dgvItem.Columns["PurchasePrice"].HeaderText = "采购金额";
            this.dgvItem.Columns["Reconstruction"].HeaderText = "再造电机";
            this.dgvItem.Columns["NewInvoiceNo"].HeaderText = "新电机发票号码";
            this.dgvItem.Columns["NewInvoiceDate"].HeaderText = "新电机发票日期";
            this.dgvItem.Columns["NewMC"].HeaderText = "新电机制造企业";
            this.dgvItem.Columns["NewSerialNum"].HeaderText = "新电机生产编号";

            this.dgvItem.Columns["ID"].Visible = false;
            this.dgvItem.Columns["CreateUserID"].Visible = false;
            this.dgvItem.Columns["CreateTime"].Visible = false;
            this.dgvItem.Columns["UpdateUserID"].Visible = false;
            this.dgvItem.Columns["UpdateTime"].Visible = false;
            this.dgvItem.Columns["SubmitUserID"].Visible = false;
            this.dgvItem.Columns["SubmitTime"].Visible = false;
            this.dgvItem.Columns["ApproveUserID"].Visible = false;
            this.dgvItem.Columns["ApproveTime"].Visible = false;
        }

        private void toolBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
