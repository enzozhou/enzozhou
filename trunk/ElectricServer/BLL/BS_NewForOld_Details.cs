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
		private readonly Electric.DAL.BS_NewForOld_Details dal=new Electric.DAL.BS_NewForOld_Details();
		public BS_NewForOld_Details()
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
		public int  Add(Electric.Model.BS_NewForOld_Details model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Electric.Model.BS_NewForOld_Details model)
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
		public Electric.Model.BS_NewForOld_Details GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Electric.Model.BS_NewForOld_Details GetModelByCache(int ID)
		{
			
			string CacheKey = "BS_NewForOld_DetailsModel-" + ID;
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
			return (Electric.Model.BS_NewForOld_Details)objModel;
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
		public List<Electric.Model.BS_NewForOld_Details> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Electric.Model.BS_NewForOld_Details> DataTableToList(DataTable dt)
		{
			List<Electric.Model.BS_NewForOld_Details> modelList = new List<Electric.Model.BS_NewForOld_Details>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Electric.Model.BS_NewForOld_Details model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Electric.Model.BS_NewForOld_Details();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["OrgCode"]!=null && dt.Rows[n]["OrgCode"].ToString()!="")
					{
					model.OrgCode=dt.Rows[n]["OrgCode"].ToString();
					}
					if(dt.Rows[n]["ContractNo"]!=null && dt.Rows[n]["ContractNo"].ToString()!="")
					{
					model.ContractNo=dt.Rows[n]["ContractNo"].ToString();
					}
					if(dt.Rows[n]["OldModel"]!=null && dt.Rows[n]["OldModel"].ToString()!="")
					{
					model.OldModel=dt.Rows[n]["OldModel"].ToString();
					}
					if(dt.Rows[n]["OldPowerRating"]!=null && dt.Rows[n]["OldPowerRating"].ToString()!="")
					{
						model.OldPowerRating=decimal.Parse(dt.Rows[n]["OldPowerRating"].ToString());
					}
					if(dt.Rows[n]["OldQty"]!=null && dt.Rows[n]["OldQty"].ToString()!="")
					{
						model.OldQty=int.Parse(dt.Rows[n]["OldQty"].ToString());
					}
					if(dt.Rows[n]["OldSpeed"]!=null && dt.Rows[n]["OldSpeed"].ToString()!="")
					{
						model.OldSpeed=decimal.Parse(dt.Rows[n]["OldSpeed"].ToString());
					}
					if(dt.Rows[n]["OldProtectionLev"]!=null && dt.Rows[n]["OldProtectionLev"].ToString()!="")
					{
					model.OldProtectionLev=dt.Rows[n]["OldProtectionLev"].ToString();
					}
					if(dt.Rows[n]["OldOutDate"]!=null && dt.Rows[n]["OldOutDate"].ToString()!="")
					{
						model.OldOutDate=DateTime.Parse(dt.Rows[n]["OldOutDate"].ToString());
					}
					if(dt.Rows[n]["OldWeight"]!=null && dt.Rows[n]["OldWeight"].ToString()!="")
					{
						model.OldWeight=decimal.Parse(dt.Rows[n]["OldWeight"].ToString());
					}
					if(dt.Rows[n]["OldPrice"]!=null && dt.Rows[n]["OldPrice"].ToString()!="")
					{
						model.OldPrice=decimal.Parse(dt.Rows[n]["OldPrice"].ToString());
					}
					if(dt.Rows[n]["OldSubsidy"]!=null && dt.Rows[n]["OldSubsidy"].ToString()!="")
					{
						model.OldSubsidy=decimal.Parse(dt.Rows[n]["OldSubsidy"].ToString());
					}
					if(dt.Rows[n]["OldSumPrice"]!=null && dt.Rows[n]["OldSumPrice"].ToString()!="")
					{
						model.OldSumPrice=decimal.Parse(dt.Rows[n]["OldSumPrice"].ToString());
					}
					if(dt.Rows[n]["TerminalUnit"]!=null && dt.Rows[n]["TerminalUnit"].ToString()!="")
					{
					model.TerminalUnit=dt.Rows[n]["TerminalUnit"].ToString();
					}
					if(dt.Rows[n]["TUNo"]!=null && dt.Rows[n]["TUNo"].ToString()!="")
					{
					model.TUNo=dt.Rows[n]["TUNo"].ToString();
					}
					if(dt.Rows[n]["NewModel"]!=null && dt.Rows[n]["NewModel"].ToString()!="")
					{
					model.NewModel=dt.Rows[n]["NewModel"].ToString();
					}
					if(dt.Rows[n]["NewPowerRating"]!=null && dt.Rows[n]["NewPowerRating"].ToString()!="")
					{
						model.NewPowerRating=decimal.Parse(dt.Rows[n]["NewPowerRating"].ToString());
					}
					if(dt.Rows[n]["NewQty"]!=null && dt.Rows[n]["NewQty"].ToString()!="")
					{
						model.NewQty=int.Parse(dt.Rows[n]["NewQty"].ToString());
					}
					if(dt.Rows[n]["PurchasePrice"]!=null && dt.Rows[n]["PurchasePrice"].ToString()!="")
					{
						model.PurchasePrice=decimal.Parse(dt.Rows[n]["PurchasePrice"].ToString());
					}
					if(dt.Rows[n]["Reconstruction"]!=null && dt.Rows[n]["Reconstruction"].ToString()!="")
					{
					model.Reconstruction=dt.Rows[n]["Reconstruction"].ToString();
					}
					if(dt.Rows[n]["NewInvoiceNo"]!=null && dt.Rows[n]["NewInvoiceNo"].ToString()!="")
					{
					model.NewInvoiceNo=dt.Rows[n]["NewInvoiceNo"].ToString();
					}
					if(dt.Rows[n]["NewInvoiceDate"]!=null && dt.Rows[n]["NewInvoiceDate"].ToString()!="")
					{
						model.NewInvoiceDate=DateTime.Parse(dt.Rows[n]["NewInvoiceDate"].ToString());
					}
					if(dt.Rows[n]["NewMC"]!=null && dt.Rows[n]["NewMC"].ToString()!="")
					{
					model.NewMC=dt.Rows[n]["NewMC"].ToString();
					}
					if(dt.Rows[n]["NewSerialNum"]!=null && dt.Rows[n]["NewSerialNum"].ToString()!="")
					{
					model.NewSerialNum=dt.Rows[n]["NewSerialNum"].ToString();
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

