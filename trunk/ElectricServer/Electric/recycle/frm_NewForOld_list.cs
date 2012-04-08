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
            this.dgv.Columns["TotalNewPowerRating"].HeaderText = "新电机总功率";
            this.dgv.Columns["TotalNewQty"].HeaderText = "新电机台数";
            this.dgv.Columns["TotalPurchasePrice"].HeaderText = "新电机采购总金额";
            this.dgv.Columns["TotalOldQty"].HeaderText = "旧电机总台数";
            this.dgv.Columns["TotalPowerRating"].HeaderText = "旧电机总额定功率";
            this.dgv.Columns["TotalOldPrice"].HeaderText = "旧电机总回购小计";
            this.dgv.Columns["TotalOldSubsidy"].HeaderText = "旧电机总补贴";
            this.dgv.Columns["TotalOldSumPrice"].HeaderText = "回购总计";
            this.dgv.Columns["TotalNewPowerRating"].HeaderText = "新电机总功率";
            this.dgv.Columns["TotalNewQty"].HeaderText = "新电机台数";


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
            if (e.RowIndex >= 0)
            {
                string strContractNo = dgv.Rows[e.RowIndex].Cells["ContractNo"].Value.ToString();
                DataSet dsItem = new Electric.BLL.BS_NewForOld_Details().GetList(string.Format("ContractNo = '{0}'", strContractNo));
                dgvItem.DataSource = dsItem;
                dgvItem.DataMember = "ds";
                global.SetDataGridViewStyle(dgvItem);
                this.dgvItem.Columns["OrgCode"].HeaderText = "公司ID";
                this.dgvItem.Columns["ContractNo"].HeaderText = "合同编号";
                this.dgvItem.Columns["OldQty"].HeaderText = "台数";
                this.dgvItem.Columns["OldSpeed"].HeaderText = "额定转速(speed)(r/min)";
                this.dgvItem.Columns["OldProtectionLev"].HeaderText = "防护等级(IP)";
                this.dgvItem.Columns["OldOutDate"].HeaderText = "出厂年月";
                this.dgvItem.Columns["OldWeight"].HeaderText = "重量(WT.)(kg)";
                this.dgvItem.Columns["TerminalUnit"].HeaderText = "终端产品";
                #region 必填
                this.dgvItem.Columns["OldModel"].HeaderText = "旧电机型号";
                this.dgvItem.Columns["OldPowerRating"].HeaderText = "额定功率(output)(kW)";
                this.dgvItem.Columns["OldPrice"].HeaderText = "回购小计(元)";
                this.dgvItem.Columns["OldSubsidy"].HeaderText = "兑付回购补贴金额(元)";
                this.dgvItem.Columns["OldSumPrice"].HeaderText = "回购合计";
                this.dgvItem.Columns["TUNo"].HeaderText = "设备唯一编号";
                this.dgvItem.Columns["NewModel"].HeaderText = "新购高效电机型号";
                this.dgvItem.Columns["NewPowerRating"].HeaderText = "新购高效电机功率(kW)";
                this.dgvItem.Columns["NewQty"].HeaderText = "新购高效电机台数";
                this.dgvItem.Columns["PurchasePrice"].HeaderText = "采购合计(元)";
                this.dgvItem.Columns["Reconstruction"].HeaderText = "是否为再制造高效电机";
                this.dgvItem.Columns["NewInvoiceNo"].HeaderText = "新购高效电机发票号码";
                this.dgvItem.Columns["NewInvoiceDate"].HeaderText = "新购高效电机发票日期";
                this.dgvItem.Columns["NewMC"].HeaderText = "新购高效电机生产企业";
                this.dgvItem.Columns["NewSerialNum"].HeaderText = "新购高效电机生产编号";

                #endregion
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
        }

        private void toolBtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
                ExportSummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region NPOI
        //导出汇总 Enzo 2012-04-08
        void ExportSummary()
        {
            List<Electric.Model.BAS_Organization> listModel = new BLL.BAS_Organization().GetModelList(string.Format(" Code='{0}'", "NCMS"));
            Electric.Model.BAS_Organization modelOrg = null;
            if (listModel.Count > 0)
            {
                modelOrg = (Electric.Model.BAS_Organization)listModel[0];
            }

            InitializeWorkbook();
            //单元格读取行和列都是从0开始
            Sheet sheet1 = hssfworkbook.GetSheet("Sheet1");
            //create cell on rows, since rows do already exist,it's not necessary to create rows again.
            if (modelOrg != null)
            {
                sheet1.GetRow(2).GetCell(2).SetCellValue(modelOrg.Name);
                sheet1.GetRow(2).GetCell(9).SetCellValue(string.Format("{0} 年第 {1} 季度", DateTime.Now.Year, DateTime.Parse(DateTime.Now.AddMonths(22 - ((DateTime.Now.Month - 1) % 22)).ToString("yyyy-MM-01")).AddDays(-1).ToShortDateString()));
                sheet1.GetRow(3).GetCell(2).SetCellValue("");//联系人
                sheet1.GetRow(3).GetCell(9).SetCellValue("");//联系电话
                sheet1.GetRow(4).GetCell(3).SetCellValue("");//开户行名称
                sheet1.GetRow(5).GetCell(3).SetCellValue(modelOrg.BankName);//联系人
                sheet1.GetRow(6).GetCell(3).SetCellValue(modelOrg.Account);
            }

            DataSet ds = new Electric.BLL.BS_NewForOld_Details().GetSummaryList("");
            if (ds.Tables.Count > 0)
            {
                int i = 0;
                double dblTmp = 0;
                double dblOldQty = 0, dblOldPowerRating = 0, dblOldSumPrice = 0,
                    dblNewQty = 0, dblNewPowerRating = 0, dblOldSubsidy = 0;
                Row row = null;
                HSSFCellStyle style = (NPOI.HSSF.UserModel.HSSFCellStyle)hssfworkbook.CreateCellStyle();
                style.BorderBottom = CellBorderType.THIN;
                style.BorderLeft = CellBorderType.THIN;
                style.BorderRight = CellBorderType.THIN;
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    row = sheet1.CreateRow(9 + i);
                    //row = sheet1.GetRow(9 + i);
                    row.CreateCell(0).SetCellValue((i + 1));
                    row.CreateCell(1).SetCellValue(global.ConvertObject(item["PartnerName"]));
                    row.CreateCell(2).SetCellValue(global.ConvertObject(item["BelongTo"]));
                    double.TryParse(global.ConvertObject(item["OldQty"]), out dblTmp);
                    dblOldQty += dblTmp;
                    row.CreateCell(3).SetCellValue(dblTmp);
                    double.TryParse(global.ConvertObject(item["OldPowerRating"]), out dblTmp);
                    dblOldPowerRating += dblTmp;
                    row.CreateCell(4).SetCellValue(dblTmp);
                    double.TryParse(global.ConvertObject(item["OldSumPrice"]), out dblTmp);
                    dblOldSumPrice += dblTmp;
                    row.CreateCell(5).SetCellValue(dblTmp);
                    double.TryParse(global.ConvertObject(item["NewQty"]), out dblTmp);
                    dblNewQty += dblTmp;
                    row.CreateCell(6).SetCellValue(dblTmp);
                    double.TryParse(global.ConvertObject(item["NewPowerRating"]), out dblTmp);
                    dblNewPowerRating += dblTmp;
                    row.CreateCell(8).SetCellValue(dblTmp);
                    double.TryParse(global.ConvertObject(item["OldSubsidy"]), out dblTmp);
                    dblOldSubsidy += dblTmp;
                    row.CreateCell(10).SetCellValue(dblTmp);
                    row.CreateCell(11).SetCellValue(dblTmp);
                    row.CreateCell(12).SetCellValue(dblTmp);

                    row.GetCell(0).CellStyle = style;
                    row.GetCell(1).CellStyle = style;
                    row.GetCell(2).CellStyle = style;
                    row.GetCell(3).CellStyle = style;
                    row.GetCell(4).CellStyle = style;
                    row.GetCell(5).CellStyle = style;
                    row.GetCell(8).CellStyle = style;
                    row.GetCell(10).CellStyle = style;
                    row.GetCell(11).CellStyle = style;
                    row.GetCell(12).CellStyle = style;
                    row.GetCell(6).CellStyle = style;
                    row.CreateCell(7);
                    row.GetCell(7).CellStyle = style;
                    row.GetCell(8).CellStyle = style;
                    row.CreateCell(9);
                    row.GetCell(9).CellStyle = style;
                    sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(9 + i, 9 + i, 6, 7));
                    sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(9 + i, 9 + i, 8, 9));

                    i++;
                }
                #region 合计
                row = sheet1.CreateRow(9 + i);
                row.CreateCell(0).SetCellValue("合计");
                row.CreateCell(1);
                row.CreateCell(2);
                row.CreateCell(3).SetCellValue(dblOldQty);
                row.CreateCell(4).SetCellValue(dblOldPowerRating);
                row.CreateCell(5).SetCellValue(dblOldSumPrice);
                row.CreateCell(6).SetCellValue(dblNewQty);
                row.CreateCell(8).SetCellValue(dblNewPowerRating);
                row.CreateCell(10).SetCellValue(dblOldSubsidy);
                row.CreateCell(11).SetCellValue(dblOldSubsidy);
                row.CreateCell(12).SetCellValue(dblOldSubsidy);
                row.GetCell(0).CellStyle = style;
                row.GetCell(1).CellStyle = style;
                row.GetCell(2).CellStyle = style;
                row.GetCell(3).CellStyle = style;
                row.GetCell(4).CellStyle = style;
                row.GetCell(5).CellStyle = style;
                row.GetCell(8).CellStyle = style;
                row.GetCell(10).CellStyle = style;
                row.GetCell(11).CellStyle = style;
                row.GetCell(12).CellStyle = style;
                row.GetCell(6).CellStyle = style;
                row.CreateCell(7);
                row.GetCell(7).CellStyle = style;
                row.GetCell(8).CellStyle = style;
                row.CreateCell(9);
                row.GetCell(9).CellStyle = style;
                sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(9 + i, 9 + i, 6, 7));
                sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(9 + i, 9 + i, 8, 9));
                #endregion


                int lastRow = 9 + i + 1;
                row = sheet1.CreateRow(lastRow);
                row.Height = 900 * 2;
                row.CreateCell(0).SetCellValue("回收企业名称\n（盖章处）");
                row.CreateCell(1);
                row.CreateCell(2);
                row.CreateCell(3);
                row.CreateCell(4);
                row.CreateCell(5);
                row.CreateCell(6).SetCellValue("上海市高效电机推广办公室\n（盖章处）");
                row.CreateCell(7);
                row.CreateCell(8);
                row.CreateCell(9);
                row.CreateCell(10);
                row.CreateCell(11);
                row.CreateCell(12);
                style = (NPOI.HSSF.UserModel.HSSFCellStyle)hssfworkbook.CreateCellStyle();
                style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                style.BorderRight = CellBorderType.THIN;
                style.BorderBottom = CellBorderType.THIN;
                style.BorderLeft = CellBorderType.THIN;
                style.WrapText = true;

                row.GetCell(0).CellStyle = style;
                row.GetCell(1).CellStyle = style;
                row.GetCell(2).CellStyle = style;
                row.GetCell(3).CellStyle = style;
                row.GetCell(4).CellStyle = style;
                row.GetCell(5).CellStyle = style;
                row.GetCell(6).CellStyle = style;
                row.GetCell(7).CellStyle = style;
                row.GetCell(8).CellStyle = style;
                row.GetCell(9).CellStyle = style;
                row.GetCell(10).CellStyle = style;
                row.GetCell(11).CellStyle = style;
                row.GetCell(12).CellStyle = style;
                sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(lastRow, lastRow, 0, 5));
                sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(lastRow, lastRow, 6, 12));
            }

            //Force excel to recalculate all the formula while open
            sheet1.ForceFormulaRecalculation = true;

            WriteToFile();
        }

        //导出明细 现已经停用 重新修改模板文件路径即可以 Enzo 2012-04-08
        void ExportNewForOldDetail()
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

            #region head
            Electric.Model.BS_NewForOld model = new Electric.BLL.BS_NewForOld().GetModel(id);
            sheet1.GetRow(2).GetCell(2).SetCellValue(model.PartnerName);
            sheet1.GetRow(2).GetCell(13).SetCellValue(model.BelongTo);
            sheet1.GetRow(2).GetCell(18).SetCellValue(model.Ownership);
            sheet1.GetRow(2).GetCell(22).SetCellValue("");//明细表编号
            sheet1.GetRow(3).GetCell(2).SetCellValue(model.PartnerAddress);
            sheet1.GetRow(3).GetCell(13).SetCellValue(model.PartnerContract);
            sheet1.GetRow(3).GetCell(18).SetCellValue(model.PartnerTel);
            sheet1.GetRow(3).GetCell(22).SetCellValue(model.BuyTime.ToString());
            sheet1.GetRow(4).GetCell(2).SetCellValue("");
            sheet1.GetRow(4).GetCell(13).SetCellValue("");
            sheet1.GetRow(4).GetCell(18).SetCellValue("");
            sheet1.GetRow(4).GetCell(22).SetCellValue("");
            sheet1.GetRow(5).GetCell(2).SetCellValue("");
            sheet1.GetRow(5).GetCell(13).SetCellValue("");
            sheet1.GetRow(5).GetCell(18).SetCellValue("");
            sheet1.GetRow(5).GetCell(22).SetCellValue("");
            #endregion

            #region item
            //= 
            List<Electric.Model.BS_NewForOld_Details> listDetail = new Electric.BLL.BS_NewForOld_Details().GetModelList(string.Format(" ContractNo='{0}'", model.ContractNo));
            int i = 1;
            int int2 = 0;
            decimal dcl3 = 0, dcl4 = 0, dcl8 = 0, dcl9 = 0, dcl10 = 0, dcl11 = 0, dcl15 = 0, dcl16 = 0, dcl17 = 0;
            foreach (Electric.Model.BS_NewForOld_Details item in listDetail)
            {
                sheet1.GetRow(10 + i).GetCell(0).SetCellValue(i);
                sheet1.GetRow(10 + i).GetCell(1).SetCellValue(item.OldModel);
                sheet1.GetRow(10 + i).GetCell(2).SetCellValue(item.OldQty.ToString());
                sheet1.GetRow(10 + i).GetCell(3).SetCellValue(item.OldPowerRating.ToString());
                sheet1.GetRow(10 + i).GetCell(4).SetCellValue(item.OldSpeed.ToString());
                sheet1.GetRow(10 + i).GetCell(5).SetCellValue(item.OldProtectionLev);
                sheet1.GetRow(10 + i).GetCell(6).SetCellValue(item.OldOutDate.ToString());
                sheet1.GetRow(10 + i).GetCell(7).SetCellValue("");//生产企业
                sheet1.GetRow(10 + i).GetCell(8).SetCellValue(item.OldWeight.ToString());
                sheet1.GetRow(10 + i).GetCell(9).SetCellValue(item.OldPrice.ToString());
                sheet1.GetRow(10 + i).GetCell(10).SetCellValue(item.OldSubsidy.ToString());
                sheet1.GetRow(10 + i).GetCell(11).SetCellValue(item.OldSumPrice.ToString());

                sheet1.GetRow(10 + i).GetCell(12).SetCellValue(item.TerminalUnit);
                sheet1.GetRow(10 + i).GetCell(13).SetCellValue(item.TUNo);
                sheet1.GetRow(10 + i).GetCell(14).SetCellValue(item.NewModel);
                sheet1.GetRow(10 + i).GetCell(15).SetCellValue(item.NewPowerRating.ToString());
                sheet1.GetRow(10 + i).GetCell(16).SetCellValue(item.NewQty.ToString());
                sheet1.GetRow(10 + i).GetCell(17).SetCellValue(item.OldPrice.ToString());
                sheet1.GetRow(10 + i).GetCell(18).SetCellValue(item.NewMC);
                sheet1.GetRow(10 + i).GetCell(19).SetCellValue(item.NewSerialNum);
                sheet1.GetRow(10 + i).GetCell(20).SetCellValue(item.Reconstruction);
                sheet1.GetRow(10 + i).GetCell(21).SetCellValue(item.NewInvoiceNo);
                sheet1.GetRow(10 + i).GetCell(22).SetCellValue(item.NewInvoiceDate.ToString());

                int2 += int.Parse(item.OldQty.ToString()); dcl3 += decimal.Parse(item.OldPowerRating.ToString());
                dcl4 += decimal.Parse(item.OldSpeed.ToString()); dcl8 += decimal.Parse(item.OldWeight.ToString());
                dcl9 += decimal.Parse(item.OldPrice.ToString()); dcl10 += decimal.Parse(item.OldSubsidy.ToString());
                dcl11 += decimal.Parse(item.OldSumPrice.ToString()); dcl15 += decimal.Parse(item.NewPowerRating.ToString());
                dcl16 += decimal.Parse(item.NewQty.ToString()); dcl17 += decimal.Parse(item.OldPrice.ToString());
                i++;
            }
            //设置合计
            sheet1.GetRow(10 + i).GetCell(0).SetCellValue("合计");
            sheet1.GetRow(10 + i).GetCell(2).SetCellValue(int2);
            sheet1.GetRow(10 + i).GetCell(3).SetCellValue(dcl3.ToString());
            sheet1.GetRow(10 + i).GetCell(4).SetCellValue(dcl4.ToString());
            sheet1.GetRow(10 + i).GetCell(8).SetCellValue(dcl8.ToString());
            sheet1.GetRow(10 + i).GetCell(9).SetCellValue(dcl9.ToString());
            sheet1.GetRow(10 + i).GetCell(10).SetCellValue(dcl10.ToString());
            sheet1.GetRow(10 + i).GetCell(11).SetCellValue(dcl11.ToString());
            sheet1.GetRow(10 + i).GetCell(15).SetCellValue(dcl15.ToString());
            sheet1.GetRow(10 + i).GetCell(16).SetCellValue(dcl16.ToString());
            sheet1.GetRow(10 + i).GetCell(17).SetCellValue(dcl17.ToString());
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
            //sfd.FileName = "旧电机回收信息明细表";
            sfd.FileName = "旧电机回收补贴信息汇总申报表";
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
            System.IO.FileStream file = new System.IO.FileStream(@"template/旧电机回收补贴信息汇总申报表.xlt", System.IO.FileMode.Open, System.IO.FileAccess.Read);

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
