using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Electric.Model;
namespace Electric.BLL
{
	/// <summary>
	/// BS_NewForOld
	/// </summary>
	public partial class BS_NewForOld
	{
		private readonly Electric.DAL.BS_NewForOld dal=new Electric.DAL.BS_NewForOld();
		public BS_NewForOld()
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
		public bool Exists(string ContractNo,int ID)
		{
			return dal.Exists(ContractNo,ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Electric.Model.BS_NewForOld model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Electric.Model.BS_NewForOld model)
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
		public bool Delete(string ContractNo,int ID)
		{
			
			return dal.Delete(ContractNo,ID);
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
		public Electric.Model.BS_NewForOld GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Electric.Model.BS_NewForOld GetModelByCache(int ID)
		{
			
			string CacheKey = "BS_NewForOldModel-" + ID;
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
			return (Electric.Model.BS_NewForOld)objModel;
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
		public List<Electric.Model.BS_NewForOld> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Electric.Model.BS_NewForOld> DataTableToList(DataTable dt)
		{
			List<Electric.Model.BS_NewForOld> modelList = new List<Electric.Model.BS_NewForOld>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Electric.Model.BS_NewForOld model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Electric.Model.BS_NewForOld();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["OrgID"]!=null && dt.Rows[n]["OrgID"].ToString()!="")
					{
						model.OrgID=int.Parse(dt.Rows[n]["OrgID"].ToString());
					}
					if(dt.Rows[n]["ContractNo"]!=null && dt.Rows[n]["ContractNo"].ToString()!="")
					{
					model.ContractNo=dt.Rows[n]["ContractNo"].ToString();
					}
					if(dt.Rows[n]["PartnerCode"]!=null && dt.Rows[n]["PartnerCode"].ToString()!="")
					{
					model.PartnerCode=dt.Rows[n]["PartnerCode"].ToString();
					}
					if(dt.Rows[n]["PartnerName"]!=null && dt.Rows[n]["PartnerName"].ToString()!="")
					{
					model.PartnerName=dt.Rows[n]["PartnerName"].ToString();
					}
					if(dt.Rows[n]["BelongTo"]!=null && dt.Rows[n]["BelongTo"].ToString()!="")
					{
					model.BelongTo=dt.Rows[n]["BelongTo"].ToString();
					}
					if(dt.Rows[n]["Ownership"]!=null && dt.Rows[n]["Ownership"].ToString()!="")
					{
					model.Ownership=dt.Rows[n]["Ownership"].ToString();
					}
					if(dt.Rows[n]["PartnerAddress"]!=null && dt.Rows[n]["PartnerAddress"].ToString()!="")
					{
					model.PartnerAddress=dt.Rows[n]["PartnerAddress"].ToString();
					}
					if(dt.Rows[n]["PartnerContract"]!=null && dt.Rows[n]["PartnerContract"].ToString()!="")
					{
					model.PartnerContract=dt.Rows[n]["PartnerContract"].ToString();
					}
					if(dt.Rows[n]["PartnerTel"]!=null && dt.Rows[n]["PartnerTel"].ToString()!="")
					{
					model.PartnerTel=dt.Rows[n]["PartnerTel"].ToString();
					}
					if(dt.Rows[n]["BuyTime"]!=null && dt.Rows[n]["BuyTime"].ToString()!="")
					{
						model.BuyTime=DateTime.Parse(dt.Rows[n]["BuyTime"].ToString());
					}
					if(dt.Rows[n]["InvoiceNo"]!=null && dt.Rows[n]["InvoiceNo"].ToString()!="")
					{
					model.InvoiceNo=dt.Rows[n]["InvoiceNo"].ToString();
					}
					if(dt.Rows[n]["TotalOldQty"]!=null && dt.Rows[n]["TotalOldQty"].ToString()!="")
					{
						model.TotalOldQty=int.Parse(dt.Rows[n]["TotalOldQty"].ToString());
					}
					if(dt.Rows[n]["TotalPowerRating"]!=null && dt.Rows[n]["TotalPowerRating"].ToString()!="")
					{
						model.TotalPowerRating=decimal.Parse(dt.Rows[n]["TotalPowerRating"].ToString());
					}
					if(dt.Rows[n]["TotalOldPrice"]!=null && dt.Rows[n]["TotalOldPrice"].ToString()!="")
					{
						model.TotalOldPrice=decimal.Parse(dt.Rows[n]["TotalOldPrice"].ToString());
					}
					if(dt.Rows[n]["TotalOldSubsidy"]!=null && dt.Rows[n]["TotalOldSubsidy"].ToString()!="")
					{
						model.TotalOldSubsidy=decimal.Parse(dt.Rows[n]["TotalOldSubsidy"].ToString());
					}
					if(dt.Rows[n]["TotalOldSumPrice"]!=null && dt.Rows[n]["TotalOldSumPrice"].ToString()!="")
					{
						model.TotalOldSumPrice=decimal.Parse(dt.Rows[n]["TotalOldSumPrice"].ToString());
					}
					if(dt.Rows[n]["TotalNewPowerRating"]!=null && dt.Rows[n]["TotalNewPowerRating"].ToString()!="")
					{
						model.TotalNewPowerRating=decimal.Parse(dt.Rows[n]["TotalNewPowerRating"].ToString());
					}
					if(dt.Rows[n]["TotalNewQty"]!=null && dt.Rows[n]["TotalNewQty"].ToString()!="")
					{
						model.TotalNewQty=decimal.Parse(dt.Rows[n]["TotalNewQty"].ToString());
					}
					if(dt.Rows[n]["TotalPurchasePrice"]!=null && dt.Rows[n]["TotalPurchasePrice"].ToString()!="")
					{
						model.TotalPurchasePrice=decimal.Parse(dt.Rows[n]["TotalPurchasePrice"].ToString());
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
					if(dt.Rows[n]["SubmitUserID"]!=null && dt.Rows[n]["SubmitUserID"].ToString()!="")
					{
						model.SubmitUserID=int.Parse(dt.Rows[n]["SubmitUserID"].ToString());
					}
					if(dt.Rows[n]["SubmitTime"]!=null && dt.Rows[n]["SubmitTime"].ToString()!="")
					{
						model.SubmitTime=DateTime.Parse(dt.Rows[n]["SubmitTime"].ToString());
					}
					if(dt.Rows[n]["ApproveUserID"]!=null && dt.Rows[n]["ApproveUserID"].ToString()!="")
					{
						model.ApproveUserID=int.Parse(dt.Rows[n]["ApproveUserID"].ToString());
					}
					if(dt.Rows[n]["ApproveTime"]!=null && dt.Rows[n]["ApproveTime"].ToString()!="")
					{
						model.ApproveTime=DateTime.Parse(dt.Rows[n]["ApproveTime"].ToString());
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

