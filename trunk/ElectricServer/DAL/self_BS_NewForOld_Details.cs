using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Electric.DAL
{
    /// <summary>
    /// 数据访问类:BAS_CodeProfire
    /// </summary>
    public partial class BS_NewForOld_Details
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetSummaryList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT b.ContractNo, a.PartnerName, c.Description BelongTo, 
sum(b.OldQty)OldQty,  sum(b.OldPowerRating)OldPowerRating, sum(b.OldSumPrice)OldSumPrice,
sum(b.NewQty)NewQty,sum(b.NewPowerRating)NewPowerRating,sum(b.OldSubsidy)OldSubsidy
 FROM BS_NewForOld a
LEFT JOIN BS_NewForOld_Details b ON a.ContractNo = b.ContractNo
LEFT JOIN BAS_Code c ON a.BelongTo = c.Code ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" GROUP BY b.ContractNo, a.PartnerName, c.Description ");

            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

