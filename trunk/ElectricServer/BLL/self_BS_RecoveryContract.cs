using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Electric.Model;
namespace Electric.BLL
{
	/// <summary>
	/// BS_RecoveryContract
	/// </summary>
	public partial class BS_RecoveryContract
	{
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetContractDetailList(string strWhere)
        {
            return dal.GetContractDetailList(strWhere);
        }
	}
}

