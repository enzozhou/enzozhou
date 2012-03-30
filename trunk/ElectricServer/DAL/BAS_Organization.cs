using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Electric.DAL
{
	/// <summary>
	/// 数据访问类:BAS_Organization
	/// </summary>
	public partial class BAS_Organization
	{
		public BAS_Organization()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "BAS_Organization"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BAS_Organization");
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
		public int Add(Electric.Model.BAS_Organization model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BAS_Organization(");
			strSql.Append("Code,Name,Membership,EnterpriseNature,TexNo,Address,WebSite,BankName,BankClass,Account,RowStatus,CreateUserID,CreateTime,UpdateUserID,UpdateTime)");
			strSql.Append(" values (");
			strSql.Append("@Code,@Name,@Membership,@EnterpriseNature,@TexNo,@Address,@WebSite,@BankName,@BankClass,@Account,@RowStatus,@CreateUserID,@CreateTime,@UpdateUserID,@UpdateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,200),
					new SqlParameter("@Membership", SqlDbType.NVarChar,50),
					new SqlParameter("@EnterpriseNature", SqlDbType.NVarChar,50),
					new SqlParameter("@TexNo", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,200),
					new SqlParameter("@WebSite", SqlDbType.NVarChar,100),
					new SqlParameter("@BankName", SqlDbType.NVarChar,100),
					new SqlParameter("@BankClass", SqlDbType.NVarChar,50),
					new SqlParameter("@Account", SqlDbType.NVarChar,50),
					new SqlParameter("@RowStatus", SqlDbType.Int,4),
					new SqlParameter("@CreateUserID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateUserID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.Code;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Membership;
			parameters[3].Value = model.EnterpriseNature;
			parameters[4].Value = model.TexNo;
			parameters[5].Value = model.Address;
			parameters[6].Value = model.WebSite;
			parameters[7].Value = model.BankName;
			parameters[8].Value = model.BankClass;
			parameters[9].Value = model.Account;
			parameters[10].Value = model.RowStatus;
			parameters[11].Value = model.CreateUserID;
			parameters[12].Value = model.CreateTime;
			parameters[13].Value = model.UpdateUserID;
			parameters[14].Value = model.UpdateTime;

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
		public bool Update(Electric.Model.BAS_Organization model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BAS_Organization set ");
			strSql.Append("Code=@Code,");
			strSql.Append("Name=@Name,");
			strSql.Append("Membership=@Membership,");
			strSql.Append("EnterpriseNature=@EnterpriseNature,");
			strSql.Append("TexNo=@TexNo,");
			strSql.Append("Address=@Address,");
			strSql.Append("WebSite=@WebSite,");
			strSql.Append("BankName=@BankName,");
			strSql.Append("BankClass=@BankClass,");
			strSql.Append("Account=@Account,");
			strSql.Append("RowStatus=@RowStatus,");
			strSql.Append("CreateUserID=@CreateUserID,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("UpdateUserID=@UpdateUserID,");
			strSql.Append("UpdateTime=@UpdateTime");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,200),
					new SqlParameter("@Membership", SqlDbType.NVarChar,50),
					new SqlParameter("@EnterpriseNature", SqlDbType.NVarChar,50),
					new SqlParameter("@TexNo", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,200),
					new SqlParameter("@WebSite", SqlDbType.NVarChar,100),
					new SqlParameter("@BankName", SqlDbType.NVarChar,100),
					new SqlParameter("@BankClass", SqlDbType.NVarChar,50),
					new SqlParameter("@Account", SqlDbType.NVarChar,50),
					new SqlParameter("@RowStatus", SqlDbType.Int,4),
					new SqlParameter("@CreateUserID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateUserID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.Code;
			parameters[1].Value = model.Name;
			parameters[2].Value = model.Membership;
			parameters[3].Value = model.EnterpriseNature;
			parameters[4].Value = model.TexNo;
			parameters[5].Value = model.Address;
			parameters[6].Value = model.WebSite;
			parameters[7].Value = model.BankName;
			parameters[8].Value = model.BankClass;
			parameters[9].Value = model.Account;
			parameters[10].Value = model.RowStatus;
			parameters[11].Value = model.CreateUserID;
			parameters[12].Value = model.CreateTime;
			parameters[13].Value = model.UpdateUserID;
			parameters[14].Value = model.UpdateTime;
			parameters[15].Value = model.ID;

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
			strSql.Append("delete from BAS_Organization ");
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
			strSql.Append("delete from BAS_Organization ");
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
		public Electric.Model.BAS_Organization GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,Code,Name,Membership,EnterpriseNature,TexNo,Address,WebSite,BankName,BankClass,Account,RowStatus,CreateUserID,CreateTime,UpdateUserID,UpdateTime from BAS_Organization ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			Electric.Model.BAS_Organization model=new Electric.Model.BAS_Organization();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Code"]!=null && ds.Tables[0].Rows[0]["Code"].ToString()!="")
				{
					model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Name"]!=null && ds.Tables[0].Rows[0]["Name"].ToString()!="")
				{
					model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Membership"]!=null && ds.Tables[0].Rows[0]["Membership"].ToString()!="")
				{
					model.Membership=ds.Tables[0].Rows[0]["Membership"].ToString();
				}
				if(ds.Tables[0].Rows[0]["EnterpriseNature"]!=null && ds.Tables[0].Rows[0]["EnterpriseNature"].ToString()!="")
				{
					model.EnterpriseNature=ds.Tables[0].Rows[0]["EnterpriseNature"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TexNo"]!=null && ds.Tables[0].Rows[0]["TexNo"].ToString()!="")
				{
					model.TexNo=ds.Tables[0].Rows[0]["TexNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Address"]!=null && ds.Tables[0].Rows[0]["Address"].ToString()!="")
				{
					model.Address=ds.Tables[0].Rows[0]["Address"].ToString();
				}
				if(ds.Tables[0].Rows[0]["WebSite"]!=null && ds.Tables[0].Rows[0]["WebSite"].ToString()!="")
				{
					model.WebSite=ds.Tables[0].Rows[0]["WebSite"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BankName"]!=null && ds.Tables[0].Rows[0]["BankName"].ToString()!="")
				{
					model.BankName=ds.Tables[0].Rows[0]["BankName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["BankClass"]!=null && ds.Tables[0].Rows[0]["BankClass"].ToString()!="")
				{
					model.BankClass=ds.Tables[0].Rows[0]["BankClass"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Account"]!=null && ds.Tables[0].Rows[0]["Account"].ToString()!="")
				{
					model.Account=ds.Tables[0].Rows[0]["Account"].ToString();
				}
				if(ds.Tables[0].Rows[0]["RowStatus"]!=null && ds.Tables[0].Rows[0]["RowStatus"].ToString()!="")
				{
					model.RowStatus=int.Parse(ds.Tables[0].Rows[0]["RowStatus"].ToString());
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
			strSql.Append("select ID,Code,Name,Membership,EnterpriseNature,TexNo,Address,WebSite,BankName,BankClass,Account,RowStatus,CreateUserID,CreateTime,UpdateUserID,UpdateTime ");
			strSql.Append(" FROM BAS_Organization ");
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
			strSql.Append(" ID,Code,Name,Membership,EnterpriseNature,TexNo,Address,WebSite,BankName,BankClass,Account,RowStatus,CreateUserID,CreateTime,UpdateUserID,UpdateTime ");
			strSql.Append(" FROM BAS_Organization ");
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
			strSql.Append("select count(1) FROM BAS_Organization ");
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
			strSql.Append(")AS Row, T.*  from BAS_Organization T ");
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
			parameters[0].Value = "BAS_Organization";
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

