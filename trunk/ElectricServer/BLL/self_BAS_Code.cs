using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Electric.Model;
namespace Electric.BLL
{
    /// <summary>
    /// BAS_Code
    /// </summary>
    public partial class BAS_Code
    {


        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId(string strSelectCode)
        {
            return dal.GetMaxId(strSelectCode);
        }

    }
}

