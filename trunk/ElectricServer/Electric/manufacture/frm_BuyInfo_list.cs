using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;

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

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportNewForOld();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region NPOI
        void ExportNewForOld()
        {
            int id = 0; //取当前选中的行ID
            bool bl = false;
            foreach (DataGridViewRow item in dgv.Rows)
            {
                if (item.Selected)
                {
                    bl = int.TryParse(item.Cells["ID"].Value.ToString(), out id);
                    continue;
                }
            }
            if (id == 0)
            {
                MessageBox.Show("没有选中的行。");
                return;
            }

            InitializeWorkbook();
            //单元格读取行和列都是从0开始
            Sheet sheet1 = hssfworkbook.GetSheet("Sheet1");
            //create cell on rows, since rows do already exist,it's not necessary to create rows again.
            sheet1.GetRow(12).GetCell(3).SetCellValue(180123);
            sheet1.GetRow(13).GetCell(3).SetCellValue(150);

            #region head
            Electric.Model.BS_BuyInfo model = new Electric.BLL.BS_BuyInfo().GetModel(id);
            sheet1.GetRow(2).GetCell(3).SetCellValue(model.PartnerName);
            sheet1.GetRow(2).GetCell(11).SetCellValue(model.BelongTo);
            sheet1.GetRow(2).GetCell(14).SetCellValue(model.Ownership);
            sheet1.GetRow(2).GetCell(26).SetCellValue("");//明细表编号
            sheet1.GetRow(3).GetCell(3).SetCellValue(model.PartnerAddress);
            sheet1.GetRow(3).GetCell(11).SetCellValue(model.PartnerContract);
            sheet1.GetRow(3).GetCell(14).SetCellValue(model.PartnerTel);
            sheet1.GetRow(3).GetCell(26).SetCellValue(model.BuyTime.ToString());
            sheet1.GetRow(4).GetCell(3).SetCellValue("");
            sheet1.GetRow(4).GetCell(11).SetCellValue("");
            sheet1.GetRow(4).GetCell(14).SetCellValue("");
            sheet1.GetRow(4).GetCell(26).SetCellValue("");
            sheet1.GetRow(5).GetCell(3).SetCellValue("");
            sheet1.GetRow(5).GetCell(11).SetCellValue("");
            sheet1.GetRow(5).GetCell(14).SetCellValue("");
            sheet1.GetRow(5).GetCell(26).SetCellValue("");
            #endregion

            #region item
            //= 
            List<Electric.Model.BS_BuyInfo_Details> listDetail = new Electric.BLL.BS_BuyInfo_Details().GetModelList(string.Format(" ContractNo='{0}'", model.ContractNo));
            int i = 1;
            int int2 = 0;
            decimal dcl3 = 0, dcl8 = 0, dcl9 = 0;
            foreach (Electric.Model.BS_BuyInfo_Details item in listDetail)
            {
                sheet1.GetRow(10 + i).GetCell(0).SetCellValue(i);
                sheet1.GetRow(10 + i).GetCell(1).SetCellValue(item.NewModel);
                sheet1.GetRow(10 + i).GetCell(2).SetCellValue(item.NewQty.ToString());
                sheet1.GetRow(10 + i).GetCell(3).SetCellValue(item.NewRating.ToString());
                sheet1.GetRow(10 + i).GetCell(4).SetCellValue(item.NewVoltage.ToString());
                sheet1.GetRow(10 + i).GetCell(5).SetCellValue(item.NewSpeed.ToString());
                sheet1.GetRow(10 + i).GetCell(6).SetCellValue(item.NewProtectionLev);
                sheet1.GetRow(10 + i).GetCell(7).SetCellValue(item.NewMC);//生产企业
                sheet1.GetRow(10 + i).GetCell(8).SetCellValue(item.NewWeight.ToString());
                sheet1.GetRow(10 + i).GetCell(9).SetCellValue(item.Price.ToString());
                sheet1.GetRow(10 + i).GetCell(10).SetCellValue((item.NewQty * 45).ToString());
                sheet1.GetRow(10 + i).GetCell(11).SetCellValue((item.Price + item.NewQty * 45).ToString());

                sheet1.GetRow(10 + i).GetCell(12).SetCellValue(item.TerminalUnit);
                sheet1.GetRow(10 + i).GetCell(13).SetCellValue(item.TUNo);
                sheet1.GetRow(10 + i).GetCell(14).SetCellValue(item.NewSerialNum);
                sheet1.GetRow(10 + i).GetCell(15).SetCellValue(item.InvoiceNo);
                sheet1.GetRow(10 + i).GetCell(16).SetCellValue(item.InvoiceDate.ToString());

                int2 += int.Parse(item.NewQty.ToString());
                dcl3 += decimal.Parse(item.NewRating.ToString());
                dcl8 += decimal.Parse(item.NewWeight.ToString());
                dcl9 += decimal.Parse(item.Price.ToString());
                i++;
            }
            //设置合计
            sheet1.GetRow(10 + i).GetCell(0).SetCellValue("合计");
            sheet1.GetRow(10 + i).GetCell(2).SetCellValue(int2);
            sheet1.GetRow(10 + i).GetCell(3).SetCellValue(dcl3.ToString());
            sheet1.GetRow(10 + i).GetCell(8).SetCellValue(dcl8.ToString());
            sheet1.GetRow(10 + i).GetCell(9).SetCellValue(dcl9.ToString());
            #endregion


            //Force excel to recalculate all the formula while open
            sheet1.ForceFormulaRecalculation = true;

            WriteToFile();
        }
        static HSSFWorkbook hssfworkbook;

        static void WriteToFile()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.RestoreDirectory = true;
            sfd.FileName = "再制造高效电机推广信息明细表";
            sfd.Filter = "微软Excel表格文件 (*.xls) | *.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //Write the stream data of workbook to the root directory
                System.IO.FileStream file = new System.IO.FileStream(string.Format("{0}", sfd.FileName), System.IO.FileMode.Create);
                hssfworkbook.Write(file);
                file.Close();
            }
        }

        static void InitializeWorkbook()
        {
            //read the template via FileStream, it is suggested to use FileAccess.Read to prevent file lock.
            //book1.xls is an Excel-2007-generated file, so some new unknown BIFF records are added. 
            System.IO.FileStream file = new System.IO.FileStream(@"template/再制造高效电机推广信息明细表.xlt", System.IO.FileMode.Open, System.IO.FileAccess.Read);

            hssfworkbook = new HSSFWorkbook(file);

            //create a entry of DocumentSummaryInformation
            DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
            dsi.Company = "NPOI Team";
            hssfworkbook.DocumentSummaryInformation = dsi;

            //create a entry of SummaryInformation
            SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
            si.Subject = "NPOI SDK Example";
            hssfworkbook.SummaryInformation = si;
        }
        #endregion
    }
}
