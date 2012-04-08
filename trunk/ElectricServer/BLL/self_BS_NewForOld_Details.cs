using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Electric.Model;
namespace Electric.BLL
{
    /// <summary>
    /// BS_NewForOld_Details
    /// </summary>
    public partial class BS_NewForOld_Details
    {

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetSummaryList(string strWhere)
        {
            return dal.GetSummaryList(strWhere);
        }        
    }
}

