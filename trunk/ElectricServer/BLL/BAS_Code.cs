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
		private readonly Electric.DAL.BAS_Code dal=new Electric.DAL.BAS_Code();
		public BAS_Code()
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
		public bool Exists(string SelectCode,string Code,int ID)
		{
			return dal.Exists(SelectCode,Code,ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Electric.Model.BAS_Code model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Electric.Model.BAS_Code model)
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
		public bool Delete(string SelectCode,string Code,int ID)
		{
			
			return dal.Delete(SelectCode,Code,ID);
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
		public Electric.Model.BAS_Code GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Electric.Model.BAS_Code GetModelByCache(int ID)
		{
			
			string CacheKey = "BAS_CodeModel-" + ID;
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
			return (Electric.Model.BAS_Code)objModel;
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
		public List<Electric.Model.BAS_Code> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Electric.Model.BAS_Code> DataTableToList(DataTable dt)
		{
			List<Electric.Model.BAS_Code> modelList = new List<Electric.Model.BAS_Code>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Electric.Model.BAS_Code model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Electric.Model.BAS_Code();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["SelectCode"]!=null && dt.Rows[n]["SelectCode"].ToString()!="")
					{
					model.SelectCode=dt.Rows[n]["SelectCode"].ToString();
					}
					if(dt.Rows[n]["Code"]!=null && dt.Rows[n]["Code"].ToString()!="")
					{
					model.Code=dt.Rows[n]["Code"].ToString();
					}
					if(dt.Rows[n]["Description"]!=null && dt.Rows[n]["Description"].ToString()!="")
					{
					model.Description=dt.Rows[n]["Description"].ToString();
					}
					if(dt.Rows[n]["SEQ"]!=null && dt.Rows[n]["SEQ"].ToString()!="")
					{
						model.SEQ=int.Parse(dt.Rows[n]["SEQ"].ToString());
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

