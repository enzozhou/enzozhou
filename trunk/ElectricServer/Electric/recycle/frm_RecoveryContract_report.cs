using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace Electric
{
    public partial class frm_RecoveryContract_report : Form
    {
        public frm_RecoveryContract_report()
        {
            InitializeComponent();
        }

        private int _id = 0;
        public int id
        {
            set { _id = value; }
        }

        //绑定报表数据
        private void frm_RecoveryContract_report_Load(object sender, EventArgs e)
        {
            DataSet ds = new Electric.BLL.BS_RecoveryContract().GetContractDetailList(string.Format(" a.ID={0}", _id));

            xsdRecycleContract _xsdRecycleContract = new xsdRecycleContract();
            xsdRecycleContract.dtRecycleContractItemRow dr = null;
            decimal dclTotalPrice = 0, dclTmp = 0;
            object sumObject;
            sumObject = ds.Tables[0].Compute("sum(SumPrice)", "true");
            decimal.TryParse(global.ConvertObject(sumObject), out dclTotalPrice);
            string strTotalPriceWords = Maticsoft.Common.Rmb.CmycurD(dclTotalPrice);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                dr = _xsdRecycleContract.dtRecycleContractItem.NewdtRecycleContractItemRow();
                dr["OrganizationName"] = item["Name"];
                dr["OrganizationAddress"] = item["Address"];
                dr["PartnerName"] = item["PartnerName"];
                dr["PartnerAddress"] = item["PartnerAddress"];
                dr["Model"] = item["Model"];
                dr["PowerRating"] = item["PowerRating"];
                dr["UnitPrice"] = item["UnitPrice"];
                dr["Price"] = item["Price"];
                dr["SumPrice"] = item["SumPrice"];
                dr["Subsidy"] = item["Subsidy"];
                dr["SubPriceWords"] = strTotalPriceWords;
                
                //decimal.TryParse(global.ConvertObject(item["SumPrice"]), dclTmp);
                //dclTotalPrice += dclTmp;
                _xsdRecycleContract.dtRecycleContractItem.AdddtRecycleContractItemRow(dr);
            }
            
            CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            rpt.Load(string.Format("reports/{0}", new rptRecycleContract().ResourceName));
            rpt.SetDataSource(_xsdRecycleContract);

            //rpt.ReportOptions = "回收合同明细";
            crv.ReportSource = rpt;
        }
    }
}
