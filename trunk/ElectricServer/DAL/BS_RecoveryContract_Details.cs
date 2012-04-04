using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Electric.DAL
{
	/// <summary>
	/// 数据访问类:BS_RecoveryContract_Details
	/// </summary>
	public partial class BS_RecoveryContract_Details
	{
		public BS_RecoveryContract_Details()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "BS_RecoveryContract_Details"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BS_RecoveryContract_Details");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Electric.Model.BS_RecoveryContract_Details model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BS_RecoveryContract_Details(");
			strSql.Append("Model,Qty,PowerRating,UnitPrice,Price,BuyPower,Subsidy,SumPrice,OrgCode,ContractNo,CreateUserID,CreateTime,UpdateUserID,UpdateTime)");
			strSql.Append(" values (");
			strSql.Append("@Model,@Qty,@PowerRating,@UnitPrice,@Price,@BuyPower,@Subsidy,@SumPrice,@OrgCode,@ContractNo,@CreateUserID,@CreateTime,@UpdateUserID,@UpdateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Model", SqlDbType.NVarChar,50),
					new SqlParameter("@Qty", SqlDbType.Int,4),
					new SqlParameter("@PowerRating", SqlDbType.Decimal,9),
					new SqlParameter("@UnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@BuyPower", SqlDbType.Decimal,9),
					new SqlParameter("@Subsidy", SqlDbType.Decimal,9),
					new SqlParameter("@SumPrice", SqlDbType.Decimal,9),
					new SqlParameter("@OrgCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractNo", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateUserID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateUserID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.Model;
			parameters[1].Value = model.Qty;
			parameters[2].Value = model.PowerRating;
			parameters[3].Value = model.UnitPrice;
			parameters[4].Value = model.Price;
			parameters[5].Value = model.BuyPower;
			parameters[6].Value = model.Subsidy;
			parameters[7].Value = model.SumPrice;
			parameters[8].Value = model.OrgCode;
			parameters[9].Value = model.ContractNo;
			parameters[10].Value = model.CreateUserID;
			parameters[11].Value = model.CreateTime;
			parameters[12].Value = model.UpdateUserID;
			parameters[13].Value = model.UpdateTime;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Electric.Model.BS_RecoveryContract_Details model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BS_RecoveryContract_Details set ");
			strSql.Append("Model=@Model,");
			strSql.Append("Qty=@Qty,");
			strSql.Append("PowerRating=@PowerRating,");
			strSql.Append("UnitPrice=@UnitPrice,");
			strSql.Append("Price=@Price,");
			strSql.Append("BuyPower=@BuyPower,");
			strSql.Append("Subsidy=@Subsidy,");
			strSql.Append("SumPrice=@SumPrice,");
			strSql.Append("OrgCode=@OrgCode,");
			strSql.Append("ContractNo=@ContractNo,");
			strSql.Append("CreateUserID=@CreateUserID,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("UpdateUserID=@UpdateUserID,");
			strSql.Append("UpdateTime=@UpdateTime");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Model", SqlDbType.NVarChar,50),
					new SqlParameter("@Qty", SqlDbType.Int,4),
					new SqlParameter("@PowerRating", SqlDbType.Decimal,9),
					new SqlParameter("@UnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@BuyPower", SqlDbType.Decimal,9),
					new SqlParameter("@Subsidy", SqlDbType.Decimal,9),
					new SqlParameter("@SumPrice", SqlDbType.Decimal,9),
					new SqlParameter("@OrgCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractNo", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateUserID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateUserID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.Model;
			parameters[1].Value = model.Qty;
			parameters[2].Value = model.PowerRating;
			parameters[3].Value = model.UnitPrice;
			parameters[4].Value = model.Price;
			parameters[5].Value = model.BuyPower;
			parameters[6].Value = model.Subsidy;
			parameters[7].Value = model.SumPrice;
			parameters[8].Value = model.OrgCode;
			parameters[9].Value = model.ContractNo;
			parameters[10].Value = model.CreateUserID;
			parameters[11].Value = model.CreateTime;
			parameters[12].Value = model.UpdateUserID;
			parameters[13].Value = model.UpdateTime;
			parameters[14].Value = model.ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BS_RecoveryContract_Details ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BS_RecoveryContract_Details ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Electric.Model.BS_RecoveryContract_Details GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Model,Qty,PowerRating,UnitPrice,Price,BuyPower,Subsidy,SumPrice,OrgCode,ContractNo,CreateUserID,CreateTime,UpdateUserID,UpdateTime from BS_RecoveryContract_Details ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			Electric.Model.BS_RecoveryContract_Details model=new Electric.Model.BS_RecoveryContract_Details();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Model"]!=null && ds.Tables[0].Rows[0]["Model"].ToString()!="")
				{
					model.Model=ds.Tables[0].Rows[0]["Model"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Qty"]!=null && ds.Tables[0].Rows[0]["Qty"].ToString()!="")
				{
					model.Qty=int.Parse(ds.Tables[0].Rows[0]["Qty"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PowerRating"]!=null && ds.Tables[0].Rows[0]["PowerRating"].ToString()!="")
				{
					model.PowerRating=decimal.Parse(ds.Tables[0].Rows[0]["PowerRating"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UnitPrice"]!=null && ds.Tables[0].Rows[0]["UnitPrice"].ToString()!="")
				{
					model.UnitPrice=decimal.Parse(ds.Tables[0].Rows[0]["UnitPrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"]!=null && ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BuyPower"]!=null && ds.Tables[0].Rows[0]["BuyPower"].ToString()!="")
				{
					model.BuyPower=decimal.Parse(ds.Tables[0].Rows[0]["BuyPower"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Subsidy"]!=null && ds.Tables[0].Rows[0]["Subsidy"].ToString()!="")
				{
					model.Subsidy=decimal.Parse(ds.Tables[0].Rows[0]["Subsidy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SumPrice"]!=null && ds.Tables[0].Rows[0]["SumPrice"].ToString()!="")
				{
					model.SumPrice=decimal.Parse(ds.Tables[0].Rows[0]["SumPrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OrgCode"]!=null && ds.Tables[0].Rows[0]["OrgCode"].ToString()!="")
				{
					model.OrgCode=ds.Tables[0].Rows[0]["OrgCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ContractNo"]!=null && ds.Tables[0].Rows[0]["ContractNo"].ToString()!="")
				{
					model.ContractNo=ds.Tables[0].Rows[0]["ContractNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CreateUserID"]!=null && ds.Tables[0].Rows[0]["CreateUserID"].ToString()!="")
				{
					model.CreateUserID=int.Parse(ds.Tables[0].Rows[0]["CreateUserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CreateTime"]!=null && ds.Tables[0].Rows[0]["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdateUserID"]!=null && ds.Tables[0].Rows[0]["UpdateUserID"].ToString()!="")
				{
					model.UpdateUserID=int.Parse(ds.Tables[0].Rows[0]["UpdateUserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdateTime"]!=null && ds.Tables[0].Rows[0]["UpdateTime"].ToString()!="")
				{
					model.UpdateTime=DateTime.Parse(ds.Tables[0].Rows[0]["UpdateTime"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,Model,Qty,PowerRating,UnitPrice,Price,BuyPower,Subsidy,SumPrice,OrgCode,ContractNo,CreateUserID,CreateTime,UpdateUserID,UpdateTime ");
			strSql.Append(" FROM BS_RecoveryContract_Details ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,Model,Qty,PowerRating,UnitPrice,Price,BuyPower,Subsidy,SumPrice,OrgCode,ContractNo,CreateUserID,CreateTime,UpdateUserID,UpdateTime ");
			strSql.Append(" FROM BS_RecoveryContract_Details ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM BS_RecoveryContract_Details ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from BS_RecoveryContract_Details T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "BS_RecoveryContract_Details";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

