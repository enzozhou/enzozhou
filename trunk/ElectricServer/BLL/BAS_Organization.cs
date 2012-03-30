using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Electric.Model;
namespace Electric.BLL
{
	/// <summary>
	/// BAS_Organization
	/// </summary>
	public partial class BAS_Organization
	{
		private readonly Electric.DAL.BAS_Organization dal=new Electric.DAL.BAS_Organization();
		public BAS_Organization()
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
		public int  Add(Electric.Model.BAS_Organization model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Electric.Model.BAS_Organization model)
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
		public Electric.Model.BAS_Organization GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Electric.Model.BAS_Organization GetModelByCache(int ID)
		{
			
			string CacheKey = "BAS_OrganizationModel-" + ID;
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
			return (Electric.Model.BAS_Organization)objModel;
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
		public List<Electric.Model.BAS_Organization> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Electric.Model.BAS_Organization> DataTableToList(DataTable dt)
		{
			List<Electric.Model.BAS_Organization> modelList = new List<Electric.Model.BAS_Organization>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Electric.Model.BAS_Organization model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Electric.Model.BAS_Organization();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["Code"]!=null && dt.Rows[n]["Code"].ToString()!="")
					{
					model.Code=dt.Rows[n]["Code"].ToString();
					}
					if(dt.Rows[n]["Name"]!=null && dt.Rows[n]["Name"].ToString()!="")
					{
					model.Name=dt.Rows[n]["Name"].ToString();
					}
					if(dt.Rows[n]["Membership"]!=null && dt.Rows[n]["Membership"].ToString()!="")
					{
					model.Membership=dt.Rows[n]["Membership"].ToString();
					}
					if(dt.Rows[n]["EnterpriseNature"]!=null && dt.Rows[n]["EnterpriseNature"].ToString()!="")
					{
					model.EnterpriseNature=dt.Rows[n]["EnterpriseNature"].ToString();
					}
					if(dt.Rows[n]["TexNo"]!=null && dt.Rows[n]["TexNo"].ToString()!="")
					{
					model.TexNo=dt.Rows[n]["TexNo"].ToString();
					}
					if(dt.Rows[n]["Address"]!=null && dt.Rows[n]["Address"].ToString()!="")
					{
					model.Address=dt.Rows[n]["Address"].ToString();
					}
					if(dt.Rows[n]["WebSite"]!=null && dt.Rows[n]["WebSite"].ToString()!="")
					{
					model.WebSite=dt.Rows[n]["WebSite"].ToString();
					}
					if(dt.Rows[n]["BankName"]!=null && dt.Rows[n]["BankName"].ToString()!="")
					{
					model.BankName=dt.Rows[n]["BankName"].ToString();
					}
					if(dt.Rows[n]["BankClass"]!=null && dt.Rows[n]["BankClass"].ToString()!="")
					{
					model.BankClass=dt.Rows[n]["BankClass"].ToString();
					}
					if(dt.Rows[n]["Account"]!=null && dt.Rows[n]["Account"].ToString()!="")
					{
					model.Account=dt.Rows[n]["Account"].ToString();
					}
					if(dt.Rows[n]["RowStatus"]!=null && dt.Rows[n]["RowStatus"].ToString()!="")
					{
						model.RowStatus=int.Parse(dt.Rows[n]["RowStatus"].ToString());
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

