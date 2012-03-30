using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Electric.Model;
namespace Electric.BLL
{
	/// <summary>
	/// BS_RecoveryContract_Details
	/// </summary>
	public partial class BS_RecoveryContract_Details
	{
		private readonly Electric.DAL.BS_RecoveryContract_Details dal=new Electric.DAL.BS_RecoveryContract_Details();
		public BS_RecoveryContract_Details()
		{}
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
		public int  Add(Electric.Model.BS_RecoveryContract_Details model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Electric.Model.BS_RecoveryContract_Details model)
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
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Electric.Model.BS_RecoveryContract_Details GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Electric.Model.BS_RecoveryContract_Details GetModelByCache(int ID)
		{
			
			string CacheKey = "BS_RecoveryContract_DetailsModel-" + ID;
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
				catch{}
			}
			return (Electric.Model.BS_RecoveryContract_Details)objModel;
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Electric.Model.BS_RecoveryContract_Details> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Electric.Model.BS_RecoveryContract_Details> DataTableToList(DataTable dt)
		{
			List<Electric.Model.BS_RecoveryContract_Details> modelList = new List<Electric.Model.BS_RecoveryContract_Details>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Electric.Model.BS_RecoveryContract_Details model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Electric.Model.BS_RecoveryContract_Details();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["Model"]!=null && dt.Rows[n]["Model"].ToString()!="")
					{
					model.Model=dt.Rows[n]["Model"].ToString();
					}
					if(dt.Rows[n]["Qty"]!=null && dt.Rows[n]["Qty"].ToString()!="")
					{
						model.Qty=int.Parse(dt.Rows[n]["Qty"].ToString());
					}
					if(dt.Rows[n]["PowerRating"]!=null && dt.Rows[n]["PowerRating"].ToString()!="")
					{
						model.PowerRating=decimal.Parse(dt.Rows[n]["PowerRating"].ToString());
					}
					if(dt.Rows[n]["UnitPrice"]!=null && dt.Rows[n]["UnitPrice"].ToString()!="")
					{
						model.UnitPrice=decimal.Parse(dt.Rows[n]["UnitPrice"].ToString());
					}
					if(dt.Rows[n]["Price"]!=null && dt.Rows[n]["Price"].ToString()!="")
					{
						model.Price=decimal.Parse(dt.Rows[n]["Price"].ToString());
					}
					if(dt.Rows[n]["BuyPower"]!=null && dt.Rows[n]["BuyPower"].ToString()!="")
					{
						model.BuyPower=decimal.Parse(dt.Rows[n]["BuyPower"].ToString());
					}
					if(dt.Rows[n]["Subsidy"]!=null && dt.Rows[n]["Subsidy"].ToString()!="")
					{
						model.Subsidy=decimal.Parse(dt.Rows[n]["Subsidy"].ToString());
					}
					if(dt.Rows[n]["SumPrice"]!=null && dt.Rows[n]["SumPrice"].ToString()!="")
					{
						model.SumPrice=decimal.Parse(dt.Rows[n]["SumPrice"].ToString());
					}
					if(dt.Rows[n]["OrgID"]!=null && dt.Rows[n]["OrgID"].ToString()!="")
					{
						model.OrgID=int.Parse(dt.Rows[n]["OrgID"].ToString());
					}
					if(dt.Rows[n]["ContractNo"]!=null && dt.Rows[n]["ContractNo"].ToString()!="")
					{
					model.ContractNo=dt.Rows[n]["ContractNo"].ToString();
					}
					if(dt.Rows[n]["CreateUserID"]!=null && dt.Rows[n]["CreateUserID"].ToString()!="")
					{
						model.CreateUserID=int.Parse(dt.Rows[n]["CreateUserID"].ToString());
					}
					if(dt.Rows[n]["CreateTime"]!=null && dt.Rows[n]["CreateTime"].ToString()!="")
					{
						model.CreateTime=DateTime.Parse(dt.Rows[n]["CreateTime"].ToString());
					}
					if(dt.Rows[n]["UpdateUserID"]!=null && dt.Rows[n]["UpdateUserID"].ToString()!="")
					{
						model.UpdateUserID=int.Parse(dt.Rows[n]["UpdateUserID"].ToString());
					}
					if(dt.Rows[n]["UpdateTime"]!=null && dt.Rows[n]["UpdateTime"].ToString()!="")
					{
						model.UpdateTime=DateTime.Parse(dt.Rows[n]["UpdateTime"].ToString());
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
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
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

