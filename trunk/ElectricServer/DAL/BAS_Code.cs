using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Electric.DAL
{
	/// <summary>
	/// 数据访问类:BAS_Code
	/// </summary>
	public partial class BAS_Code
	{
		public BAS_Code()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "BAS_Code"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string SelectCode,string Code,int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BAS_Code");
			strSql.Append(" where SelectCode=@SelectCode and Code=@Code and ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SelectCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)			};
			parameters[0].Value = SelectCode;
			parameters[1].Value = Code;
			parameters[2].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Electric.Model.BAS_Code model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BAS_Code(");
			strSql.Append("SelectCode,Code,Description,SEQ,CreateUserID,CreateTime,UpdateUserID,UpdateTime)");
			strSql.Append(" values (");
			strSql.Append("@SelectCode,@Code,@Description,@SEQ,@CreateUserID,@CreateTime,@UpdateUserID,@UpdateTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SelectCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Description", SqlDbType.NVarChar,50),
					new SqlParameter("@SEQ", SqlDbType.Int,4),
					new SqlParameter("@CreateUserID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateUserID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime)};
			parameters[0].Value = model.SelectCode;
			parameters[1].Value = model.Code;
			parameters[2].Value = model.Description;
			parameters[3].Value = model.SEQ;
			parameters[4].Value = model.CreateUserID;
			parameters[5].Value = model.CreateTime;
			parameters[6].Value = model.UpdateUserID;
			parameters[7].Value = model.UpdateTime;

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
		public bool Update(Electric.Model.BAS_Code model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BAS_Code set ");
			strSql.Append("Description=@Description,");
			strSql.Append("SEQ=@SEQ,");
			strSql.Append("CreateUserID=@CreateUserID,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("UpdateUserID=@UpdateUserID,");
			strSql.Append("UpdateTime=@UpdateTime");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Description", SqlDbType.NVarChar,50),
					new SqlParameter("@SEQ", SqlDbType.Int,4),
					new SqlParameter("@CreateUserID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateUserID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@SelectCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Code", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.Description;
			parameters[1].Value = model.SEQ;
			parameters[2].Value = model.CreateUserID;
			parameters[3].Value = model.CreateTime;
			parameters[4].Value = model.UpdateUserID;
			parameters[5].Value = model.UpdateTime;
			parameters[6].Value = model.ID;
			parameters[7].Value = model.SelectCode;
			parameters[8].Value = model.Code;

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
			strSql.Append("delete from BAS_Code ");
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(string SelectCode,string Code,int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BAS_Code ");
			strSql.Append(" where SelectCode=@SelectCode and Code=@Code and ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SelectCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)			};
			parameters[0].Value = SelectCode;
			parameters[1].Value = Code;
			parameters[2].Value = ID;

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
			strSql.Append("delete from BAS_Code ");
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
		public Electric.Model.BAS_Code GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,SelectCode,Code,Description,SEQ,CreateUserID,CreateTime,UpdateUserID,UpdateTime from BAS_Code ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			Electric.Model.BAS_Code model=new Electric.Model.BAS_Code();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SelectCode"]!=null && ds.Tables[0].Rows[0]["SelectCode"].ToString()!="")
				{
					model.SelectCode=ds.Tables[0].Rows[0]["SelectCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Code"]!=null && ds.Tables[0].Rows[0]["Code"].ToString()!="")
				{
					model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Description"]!=null && ds.Tables[0].Rows[0]["Description"].ToString()!="")
				{
					model.Description=ds.Tables[0].Rows[0]["Description"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SEQ"]!=null && ds.Tables[0].Rows[0]["SEQ"].ToString()!="")
				{
					model.SEQ=int.Parse(ds.Tables[0].Rows[0]["SEQ"].ToString());
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
			strSql.Append("select ID,SelectCode,Code,Description,SEQ,CreateUserID,CreateTime,UpdateUserID,UpdateTime ");
			strSql.Append(" FROM BAS_Code ");
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
			strSql.Append(" ID,SelectCode,Code,Description,SEQ,CreateUserID,CreateTime,UpdateUserID,UpdateTime ");
			strSql.Append(" FROM BAS_Code ");
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
			strSql.Append("select count(1) FROM BAS_Code ");
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
			strSql.Append(")AS Row, T.*  from BAS_Code T ");
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
			parameters[0].Value = "BAS_Code";
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

