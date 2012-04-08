using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Electric.Model;
namespace Electric.BLL
{
    /// <summary>
    /// V_BAS_PPC
    /// </summary>
    public partial class V_BAS_PPC
    {
        private readonly Electric.DAL.V_BAS_PPC dal = new Electric.DAL.V_BAS_PPC();
        public V_BAS_PPC()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Electric.Model.V_BAS_PPC model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Electric.Model.V_BAS_PPC model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Electric.Model.V_BAS_PPC GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Electric.Model.V_BAS_PPC GetModelByCache(int ID)
        {

            string CacheKey = "V_BAS_PPCModel-" + ID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Electric.Model.V_BAS_PPC)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Electric.Model.V_BAS_PPC> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Electric.Model.V_BAS_PPC> DataTableToList(DataTable dt)
        {
            List<Electric.Model.V_BAS_PPC> modelList = new List<Electric.Model.V_BAS_PPC>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Electric.Model.V_BAS_PPC model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Electric.Model.V_BAS_PPC();
                    if (dt.Rows[n]["ID"] != null && dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["OrgCodeSYS"] != null && dt.Rows[n]["OrgCodeSYS"].ToString() != "")
                    {
                        model.OrgCodeSYS = dt.Rows[n]["OrgCodeSYS"].ToString();
                    }
                    if (dt.Rows[n]["Code"] != null && dt.Rows[n]["Code"].ToString() != "")
                    {
                        model.Code = dt.Rows[n]["Code"].ToString();
                    }
                    if (dt.Rows[n]["Name"] != null && dt.Rows[n]["Name"].ToString() != "")
                    {
                        model.Name = dt.Rows[n]["Name"].ToString();
                    }
                    if (dt.Rows[n]["PartnerClass"] != null && dt.Rows[n]["PartnerClass"].ToString() != "")
                    {
                        model.PartnerClass = dt.Rows[n]["PartnerClass"].ToString();
                    }
                    if (dt.Rows[n]["Address"] != null && dt.Rows[n]["Address"].ToString() != "")
                    {
                        model.Address = dt.Rows[n]["Address"].ToString();
                    }
                    if (dt.Rows[n]["Corporate"] != null && dt.Rows[n]["Corporate"].ToString() != "")
                    {
                        model.Corporate = dt.Rows[n]["Corporate"].ToString();
                    }
                    if (dt.Rows[n]["OrgCode"] != null && dt.Rows[n]["OrgCode"].ToString() != "")
                    {
                        model.OrgCode = dt.Rows[n]["OrgCode"].ToString();
                    }
                    if (dt.Rows[n]["Licence"] != null && dt.Rows[n]["Licence"].ToString() != "")
                    {
                        model.Licence = dt.Rows[n]["Licence"].ToString();
                    }
                    if (dt.Rows[n]["TaxNo"] != null && dt.Rows[n]["TaxNo"].ToString() != "")
                    {
                        model.TaxNo = dt.Rows[n]["TaxNo"].ToString();
                    }
                    if (dt.Rows[n]["Ownership"] != null && dt.Rows[n]["Ownership"].ToString() != "")
                    {
                        model.Ownership = dt.Rows[n]["Ownership"].ToString();
                    }
                    if (dt.Rows[n]["RegisteredCapital"] != null && dt.Rows[n]["RegisteredCapital"].ToString() != "")
                    {
                        model.RegisteredCapital = decimal.Parse(dt.Rows[n]["RegisteredCapital"].ToString());
                    }
                    if (dt.Rows[n]["Supervisor"] != null && dt.Rows[n]["Supervisor"].ToString() != "")
                    {
                        model.Supervisor = dt.Rows[n]["Supervisor"].ToString();
                    }
                    if (dt.Rows[n]["FixedAssets"] != null && dt.Rows[n]["FixedAssets"].ToString() != "")
                    {
                        model.FixedAssets = decimal.Parse(dt.Rows[n]["FixedAssets"].ToString());
                    }
                    if (dt.Rows[n]["EnterpriseNum"] != null && dt.Rows[n]["EnterpriseNum"].ToString() != "")
                    {
                        model.EnterpriseNum = int.Parse(dt.Rows[n]["EnterpriseNum"].ToString());
                    }
                    if (dt.Rows[n]["Contract"] != null && dt.Rows[n]["Contract"].ToString() != "")
                    {
                        model.Contract = dt.Rows[n]["Contract"].ToString();
                    }
                    if (dt.Rows[n]["Tel"] != null && dt.Rows[n]["Tel"].ToString() != "")
                    {
                        model.Tel = dt.Rows[n]["Tel"].ToString();
                    }
                    if (dt.Rows[n]["Email"] != null && dt.Rows[n]["Email"].ToString() != "")
                    {
                        model.Email = dt.Rows[n]["Email"].ToString();
                    }
                    if (dt.Rows[n]["ETC"] != null && dt.Rows[n]["ETC"].ToString() != "")
                    {
                        model.ETC = dt.Rows[n]["ETC"].ToString();
                    }
                    if (dt.Rows[n]["LYSV"] != null && dt.Rows[n]["LYSV"].ToString() != "")
                    {
                        model.LYSV = decimal.Parse(dt.Rows[n]["LYSV"].ToString());
                    }
                    if (dt.Rows[n]["YBLSV"] != null && dt.Rows[n]["YBLSV"].ToString() != "")
                    {
                        model.YBLSV = decimal.Parse(dt.Rows[n]["YBLSV"].ToString());
                    }
                    if (dt.Rows[n]["BankName"] != null && dt.Rows[n]["BankName"].ToString() != "")
                    {
                        model.BankName = dt.Rows[n]["BankName"].ToString();
                    }
                    if (dt.Rows[n]["BankClass"] != null && dt.Rows[n]["BankClass"].ToString() != "")
                    {
                        model.BankClass = dt.Rows[n]["BankClass"].ToString();
                    }
                    if (dt.Rows[n]["Account"] != null && dt.Rows[n]["Account"].ToString() != "")
                    {
                        model.Account = dt.Rows[n]["Account"].ToString();
                    }
                    if (dt.Rows[n]["CreateUserID"] != null && dt.Rows[n]["CreateUserID"].ToString() != "")
                    {
                        model.CreateUserID = int.Parse(dt.Rows[n]["CreateUserID"].ToString());
                    }
                    if (dt.Rows[n]["CreateTime"] != null && dt.Rows[n]["CreateTime"].ToString() != "")
                    {
                        model.CreateTime = DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
                    }
                    if (dt.Rows[n]["UpdateUserID"] != null && dt.Rows[n]["UpdateUserID"].ToString() != "")
                    {
                        model.UpdateUserID = int.Parse(dt.Rows[n]["UpdateUserID"].ToString());
                    }
                    if (dt.Rows[n]["UpdateTime"] != null && dt.Rows[n]["UpdateTime"].ToString() != "")
                    {
                        model.UpdateTime = DateTime.Parse(dt.Rows[n]["UpdateTime"].ToString());
                    }
                    if (dt.Rows[n]["SubmitUserID"] != null && dt.Rows[n]["SubmitUserID"].ToString() != "")
                    {
                        model.SubmitUserID = int.Parse(dt.Rows[n]["SubmitUserID"].ToString());
                    }
                    if (dt.Rows[n]["SubmitTime"] != null && dt.Rows[n]["SubmitTime"].ToString() != "")
                    {
                        model.SubmitTime = DateTime.Parse(dt.Rows[n]["SubmitTime"].ToString());
                    }
                    if (dt.Rows[n]["ApproveUserID"] != null && dt.Rows[n]["ApproveUserID"].ToString() != "")
                    {
                        model.ApproveUserID = int.Parse(dt.Rows[n]["ApproveUserID"].ToString());
                    }
                    if (dt.Rows[n]["ApproveTime"] != null && dt.Rows[n]["ApproveTime"].ToString() != "")
                    {
                        model.ApproveTime = DateTime.Parse(dt.Rows[n]["ApproveTime"].ToString());
                    }
                    if (dt.Rows[n]["ContractNo"] != null && dt.Rows[n]["ContractNo"].ToString() != "")
                    {
                        model.BankName = dt.Rows[n]["ContractNo"].ToString();
                    }
                    if (dt.Rows[n]["Membership"] != null && dt.Rows[n]["Membership"].ToString() != "")
                    {
                        model.BankName = dt.Rows[n]["Membership"].ToString();
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method
    }
}

