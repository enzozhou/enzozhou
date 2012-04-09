using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Electric.DAL
{
    /// <summary>
    /// 数据访问类:BS_RecoveryContract
    /// </summary>
    public partial class BS_RecoveryContract
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetContractDetailList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"SELECT a.OrgCode, c.Name, c.Address, a.PartnerName, a.PartnerAddress 
, b.Model, b.Qty, b.PowerRating, b.UnitPrice, b.Price, b.SumPrice
FROM BS_RecoveryContract a
LEFT JOIN BS_RecoveryContract_Details b ON a.ContractNo = b.ContractNo
LEFT JOIN BAS_Organization c ON a.OrgCode = c.Code ");//WHERE a.ID=1
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}

