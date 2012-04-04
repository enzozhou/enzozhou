using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Electric.DAL
{
	/// <summary>
	/// 数据访问类:V_BAS_Employess
	/// </summary>
	public partial class V_BAS_Employess
	{
		public V_BAS_Employess()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "V_BAS_Employess"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from V_BAS_Employess");
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
		public int Add(Electric.Model.V_BAS_Employess model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into V_BAS_Employess(");
			strSql.Append("OrgID,Code,Name,Gender,Tel,Email,Fax,Mobile,Deparment,CreateUserID,CreateTime,UpdateUserID,UpdateTime,CancelUserID,CancelTime)");
			strSql.Append(" values (");
			strSql.Append("@OrgID,@Code,@Name,@Gender,@Tel,@Email,@Fax,@Mobile,@Deparment,@CreateUserID,@CreateTime,@UpdateUserID,@UpdateTime,@CancelUserID,@CancelTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@OrgID", SqlDbType.Int,4),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Gender", SqlDbType.Int,4),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,100),
					new SqlParameter("@Fax", SqlDbType.NVarChar,50),
					new SqlParameter("@Mobile", SqlDbType.NVarChar,50),
					new SqlParameter("@Deparment", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateUserID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateUserID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@CancelUserID", SqlDbType.Int,4),
					new SqlParameter("@CancelTime", SqlDbType.DateTime)};
			parameters[0].Value = model.OrgID;
			parameters[1].Value = model.Code;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.Gender;
			parameters[4].Value = model.Tel;
			parameters[5].Value = model.Email;
			parameters[6].Value = model.Fax;
			parameters[7].Value = model.Mobile;
			parameters[8].Value = model.Deparment;
			parameters[9].Value = model.CreateUserID;
			parameters[10].Value = model.CreateTime;
			parameters[11].Value = model.UpdateUserID;
			parameters[12].Value = model.UpdateTime;
			parameters[13].Value = model.CancelUserID;
			parameters[14].Value = model.CancelTime;

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
		public bool Update(Electric.Model.V_BAS_Employess model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update V_BAS_Employess set ");
			strSql.Append("OrgID=@OrgID,");
			strSql.Append("Code=@Code,");
			strSql.Append("Name=@Name,");
			strSql.Append("Gender=@Gender,");
			strSql.Append("Tel=@Tel,");
			strSql.Append("Email=@Email,");
			strSql.Append("Fax=@Fax,");
			strSql.Append("Mobile=@Mobile,");
			strSql.Append("Deparment=@Deparment,");
			strSql.Append("CreateUserID=@CreateUserID,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("UpdateUserID=@UpdateUserID,");
			strSql.Append("UpdateTime=@UpdateTime,");
			strSql.Append("CancelUserID=@CancelUserID,");
			strSql.Append("CancelTime=@CancelTime");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@OrgID", SqlDbType.Int,4),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Gender", SqlDbType.Int,4),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,100),
					new SqlParameter("@Fax", SqlDbType.NVarChar,50),
					new SqlParameter("@Mobile", SqlDbType.NVarChar,50),
					new SqlParameter("@Deparment", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateUserID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateUserID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@CancelUserID", SqlDbType.Int,4),
					new SqlParameter("@CancelTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.OrgID;
			parameters[1].Value = model.Code;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.Gender;
			parameters[4].Value = model.Tel;
			parameters[5].Value = model.Email;
			parameters[6].Value = model.Fax;
			parameters[7].Value = model.Mobile;
			parameters[8].Value = model.Deparment;
			parameters[9].Value = model.CreateUserID;
			parameters[10].Value = model.CreateTime;
			parameters[11].Value = model.UpdateUserID;
			parameters[12].Value = model.UpdateTime;
			parameters[13].Value = model.CancelUserID;
			parameters[14].Value = model.CancelTime;
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
			strSql.Append("delete from V_BAS_Employess ");
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
			strSql.Append("delete from V_BAS_Employess ");
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
		public Electric.Model.V_BAS_Employess GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,OrgID,Code,Name,Gender,Tel,Email,Fax,Mobile,Deparment,CreateUserID,CreateTime,UpdateUserID,UpdateTime,CancelUserID,CancelTime from V_BAS_Employess ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			Electric.Model.V_BAS_Employess model=new Electric.Model.V_BAS_Employess();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OrgID"]!=null && ds.Tables[0].Rows[0]["OrgID"].ToString()!="")
				{
					model.OrgID=int.Parse(ds.Tables[0].Rows[0]["OrgID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Code"]!=null && ds.Tables[0].Rows[0]["Code"].ToString()!="")
				{
					model.Code=ds.Tables[0].Rows[0]["Code"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Name"]!=null && ds.Tables[0].Rows[0]["Name"].ToString()!="")
				{
					model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Gender"]!=null && ds.Tables[0].Rows[0]["Gender"].ToString()!="")
				{
					model.Gender=int.Parse(ds.Tables[0].Rows[0]["Gender"].ToString());
                }
                if (ds.Tables[0].Rows[0]["GenderName"] != null && ds.Tables[0].Rows[0]["GenderName"].ToString() != "")
                {
                    model.Gender = int.Parse(ds.Tables[0].Rows[0]["GenderName"].ToString());
                }
				if(ds.Tables[0].Rows[0]["Tel"]!=null && ds.Tables[0].Rows[0]["Tel"].ToString()!="")
				{
					model.Tel=ds.Tables[0].Rows[0]["Tel"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Email"]!=null && ds.Tables[0].Rows[0]["Email"].ToString()!="")
				{
					model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Fax"]!=null && ds.Tables[0].Rows[0]["Fax"].ToString()!="")
				{
					model.Fax=ds.Tables[0].Rows[0]["Fax"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Mobile"]!=null && ds.Tables[0].Rows[0]["Mobile"].ToString()!="")
				{
					model.Mobile=ds.Tables[0].Rows[0]["Mobile"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Deparment"]!=null && ds.Tables[0].Rows[0]["Deparment"].ToString()!="")
				{
					model.Deparment=ds.Tables[0].Rows[0]["Deparment"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DptName"] != null && ds.Tables[0].Rows[0]["DptName"].ToString() != "")
                {
                    model.Deparment = ds.Tables[0].Rows[0]["DptName"].ToString();
                }
				if(ds.Tables[0].Rows[0]["CreateUserID"]!=null && ds.Tables[0].Rows[0]["CreateUserID"].ToString()!="")
				{
					model.CreateUserID=int.Parse(ds.Tables[0].Rows[0]["CreateUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateUserName"] != null && ds.Tables[0].Rows[0]["CreateUserName"].ToString() != "")
                {
                    model.CreateUserID = int.Parse(ds.Tables[0].Rows[0]["CreateUserName"].ToString());
                }
				if(ds.Tables[0].Rows[0]["CreateTime"]!=null && ds.Tables[0].Rows[0]["CreateTime"].ToString()!="")
				{
					model.CreateTime=DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UpdateUserID"]!=null && ds.Tables[0].Rows[0]["UpdateUserID"].ToString()!="")
				{
					model.UpdateUserID=int.Parse(ds.Tables[0].Rows[0]["UpdateUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["UpdateUserName"] != null && ds.Tables[0].Rows[0]["UpdateUserName"].ToString() != "")
                {
                    model.UpdateUserID = int.Parse(ds.Tables[0].Rows[0]["UpdateUserName"].ToString());
                }
				if(ds.Tables[0].Rows[0]["UpdateTime"]!=null && ds.Tables[0].Rows[0]["UpdateTime"].ToString()!="")
				{
					model.UpdateTime=DateTime.Parse(ds.Tables[0].Rows[0]["UpdateTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CancelUserID"]!=null && ds.Tables[0].Rows[0]["CancelUserID"].ToString()!="")
				{
					model.CancelUserID=int.Parse(ds.Tables[0].Rows[0]["CancelUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CancelUserName"] != null && ds.Tables[0].Rows[0]["CancelUserName"].ToString() != "")
                {
                    model.CancelUserID = int.Parse(ds.Tables[0].Rows[0]["CancelUserName"].ToString());
                }
				if(ds.Tables[0].Rows[0]["CancelTime"]!=null && ds.Tables[0].Rows[0]["CancelTime"].ToString()!="")
				{
					model.CancelTime=DateTime.Parse(ds.Tables[0].Rows[0]["CancelTime"].ToString());
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
			strSql.Append("select ID,OrgID,Code,Name,Gender,GenderName,Tel,Email,Fax,Mobile,Deparment,DepName,CreateUserID,CreateUserName,CreateTime,UpdateUserID,UpdateUserName,UpdateTime,CancelUserID,CancelUserName,CancelTime ");
			strSql.Append(" FROM V_BAS_Employess ");
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
            strSql.Append("select ID,OrgID,Code,Name,Gender,GenderName,Tel,Email,Fax,Mobile,Deparment,DepName,CreateUserID,CreateUserName,CreateTime,UpdateUserID,UpdateUserName,UpdateTime,CancelUserID,CancelUserName,CancelTime ");
            strSql.Append(" FROM V_BAS_Employess ");
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
			strSql.Append("select count(1) FROM V_BAS_Employess ");
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
			strSql.Append(")AS Row, T.*  from V_BAS_Employess T ");
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
			parameters[0].Value = "V_BAS_Employess";
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

