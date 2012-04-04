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
    public partial class BAS_Code
    {



        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId(string strSelectCode)
        {
            string FieldName = "ID", TableName = "BAS_Code";
            string strsql = "select max(" + FieldName + ")+1 from " + TableName;
            strsql += string.Format(" where SelectCode='{0}'", strSelectCode);
            object obj = DbHelperSQL.GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }



    }
}

