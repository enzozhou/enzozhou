using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Electric.reports;

namespace Electric
{
    public partial class frm_PurchaseContract_report : Form
    {
        public frm_PurchaseContract_report()
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
            DataSet ds = new Electric.BLL.BS_PurchaseContract().GetContractDetailList(string.Format(" a.ID={0}", _id));

            xsdPurchaseContract _xsdPurchaseContract = new xsdPurchaseContract();
            xsdPurchaseContract.dtPurchaseContractRow dr = null;
            decimal dclTotalPrice = 0, dclTmp = 0;
            object sumObject;
            sumObject = ds.Tables[0].Compute("sum(SumPrice)", "true");
            decimal.TryParse(global.ConvertObject(sumObject), out dclTotalPrice);
            string strTotalPriceWords = Maticsoft.Common.Rmb.CmycurD(dclTotalPrice);
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                dr = _xsdPurchaseContract.dtPurchaseContract.NewdtPurchaseContractRow();
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
                _xsdPurchaseContract.dtPurchaseContract.AdddtPurchaseContractRow(dr);
            }

            CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            rpt.Load(string.Format("reports/{0}", new rptPurchaseContract().ResourceName));
            rpt.SetDataSource(_xsdPurchaseContract);

            CRV.ReportSource = rpt;
        }
    }
}
