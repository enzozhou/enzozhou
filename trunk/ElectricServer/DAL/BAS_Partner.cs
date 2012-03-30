using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Electric.DAL
{
	/// <summary>
	/// 数据访问类:BAS_Partner
	/// </summary>
	public partial class BAS_Partner
	{
		public BAS_Partner()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "BAS_Partner"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BAS_Partner");
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
		public int Add(Electric.Model.BAS_Partner model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BAS_Partner(");
			strSql.Append("OrgID,Code,Name,PartnerClass,Address,Corporate,OrgCode,Licence,TaxNo,Ownership,RegisteredCapital,Supervisor,FixedAssets,EnterpriseNum,Contract,Tel,Email,ETC,LYSV,YBLSV,BankName,BankClass,Account,CreateUserID,CreateTime,UpdateUserID,UpdateTime,SubmitUserID,SubmitTime,ApproveUserID,ApproveTime)");
			strSql.Append(" values (");
			strSql.Append("@OrgID,@Code,@Name,@PartnerClass,@Address,@Corporate,@OrgCode,@Licence,@TaxNo,@Ownership,@RegisteredCapital,@Supervisor,@FixedAssets,@EnterpriseNum,@Contract,@Tel,@Email,@ETC,@LYSV,@YBLSV,@BankName,@BankClass,@Account,@CreateUserID,@CreateTime,@UpdateUserID,@UpdateTime,@SubmitUserID,@SubmitTime,@ApproveUserID,@ApproveTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@OrgID", SqlDbType.Int,4),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,100),
					new SqlParameter("@PartnerClass", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,100),
					new SqlParameter("@Corporate", SqlDbType.NVarChar,50),
					new SqlParameter("@OrgCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Licence", SqlDbType.NVarChar,50),
					new SqlParameter("@TaxNo", SqlDbType.NVarChar,50),
					new SqlParameter("@Ownership", SqlDbType.NVarChar,50),
					new SqlParameter("@RegisteredCapital", SqlDbType.Decimal,9),
					new SqlParameter("@Supervisor", SqlDbType.NVarChar,50),
					new SqlParameter("@FixedAssets", SqlDbType.Decimal,9),
					new SqlParameter("@EnterpriseNum", SqlDbType.Int,4),
					new SqlParameter("@Contract", SqlDbType.NVarChar,50),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,100),
					new SqlParameter("@ETC", SqlDbType.NVarChar,50),
					new SqlParameter("@LYSV", SqlDbType.Decimal,9),
					new SqlParameter("@YBLSV", SqlDbType.Decimal,9),
					new SqlParameter("@BankName", SqlDbType.NVarChar,50),
					new SqlParameter("@BankClass", SqlDbType.NVarChar,50),
					new SqlParameter("@Account", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateUserID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateUserID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@SubmitUserID", SqlDbType.Int,4),
					new SqlParameter("@SubmitTime", SqlDbType.DateTime),
					new SqlParameter("@ApproveUserID", SqlDbType.Int,4),
					new SqlParameter("@ApproveTime", SqlDbType.DateTime)};
			parameters[0].Value = model.OrgID;
			parameters[1].Value = model.Code;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.PartnerClass;
			parameters[4].Value = model.Address;
			parameters[5].Value = model.Corporate;
			parameters[6].Value = model.OrgCode;
			parameters[7].Value = model.Licence;
			parameters[8].Value = model.TaxNo;
			parameters[9].Value = model.Ownership;
			parameters[10].Value = model.RegisteredCapital;
			parameters[11].Value = model.Supervisor;
			parameters[12].Value = model.FixedAssets;
			parameters[13].Value = model.EnterpriseNum;
			parameters[14].Value = model.Contract;
			parameters[15].Value = model.Tel;
			parameters[16].Value = model.Email;
			parameters[17].Value = model.ETC;
			parameters[18].Value = model.LYSV;
			parameters[19].Value = model.YBLSV;
			parameters[20].Value = model.BankName;
			parameters[21].Value = model.BankClass;
			parameters[22].Value = model.Account;
			parameters[23].Value = model.CreateUserID;
			parameters[24].Value = model.CreateTime;
			parameters[25].Value = model.UpdateUserID;
			parameters[26].Value = model.UpdateTime;
			parameters[27].Value = model.SubmitUserID;
			parameters[28].Value = model.SubmitTime;
			parameters[29].Value = model.ApproveUserID;
			parameters[30].Value = model.ApproveTime;

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
		public bool Update(Electric.Model.BAS_Partner model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BAS_Partner set ");
			strSql.Append("OrgID=@OrgID,");
			strSql.Append("Code=@Code,");
			strSql.Append("Name=@Name,");
			strSql.Append("PartnerClass=@PartnerClass,");
			strSql.Append("Address=@Address,");
			strSql.Append("Corporate=@Corporate,");
			strSql.Append("OrgCode=@OrgCode,");
			strSql.Append("Licence=@Licence,");
			strSql.Append("TaxNo=@TaxNo,");
			strSql.Append("Ownership=@Ownership,");
			strSql.Append("RegisteredCapital=@RegisteredCapital,");
			strSql.Append("Supervisor=@Supervisor,");
			strSql.Append("FixedAssets=@FixedAssets,");
			strSql.Append("EnterpriseNum=@EnterpriseNum,");
			strSql.Append("Contract=@Contract,");
			strSql.Append("Tel=@Tel,");
			strSql.Append("Email=@Email,");
			strSql.Append("ETC=@ETC,");
			strSql.Append("LYSV=@LYSV,");
			strSql.Append("YBLSV=@YBLSV,");
			strSql.Append("BankName=@BankName,");
			strSql.Append("BankClass=@BankClass,");
			strSql.Append("Account=@Account,");
			strSql.Append("CreateUserID=@CreateUserID,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("UpdateUserID=@UpdateUserID,");
			strSql.Append("UpdateTime=@UpdateTime,");
			strSql.Append("SubmitUserID=@SubmitUserID,");
			strSql.Append("SubmitTime=@SubmitTime,");
			strSql.Append("ApproveUserID=@ApproveUserID,");
			strSql.Append("ApproveTime=@ApproveTime");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@OrgID", SqlDbType.Int,4),
					new SqlParameter("@Code", SqlDbType.NVarChar,50),
					new SqlParameter("@Name", SqlDbType.NVarChar,100),
					new SqlParameter("@PartnerClass", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,100),
					new SqlParameter("@Corporate", SqlDbType.NVarChar,50),
					new SqlParameter("@OrgCode", SqlDbType.NVarChar,50),
					new SqlParameter("@Licence", SqlDbType.NVarChar,50),
					new SqlParameter("@TaxNo", SqlDbType.NVarChar,50),
					new SqlParameter("@Ownership", SqlDbType.NVarChar,50),
					new SqlParameter("@RegisteredCapital", SqlDbType.Decimal,9),
					new SqlParameter("@Supervisor", SqlDbType.NVarChar,50),
					new SqlParameter("@FixedAssets", SqlDbType.Decimal,9),
					new SqlParameter("@EnterpriseNum", SqlDbType.Int,4),
					new SqlParameter("@Contract", SqlDbType.NVarChar,50),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
					new SqlParameter("@Email", SqlDbType.NVarChar,100),
					new SqlParameter("@ETC", SqlDbType.NVarChar,50),
					new SqlParameter("@LYSV", SqlDbType.Decimal,9),
					new SqlParameter("@YBLSV", SqlDbType.Decimal,9),
					new SqlParameter("@BankName", SqlDbType.NVarChar,50),
					new SqlParameter("@BankClass", SqlDbType.NVarChar,50),
					new SqlParameter("@Account", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateUserID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateUserID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@SubmitUserID", SqlDbType.Int,4),
					new SqlParameter("@SubmitTime", SqlDbType.DateTime),
					new SqlParameter("@ApproveUserID", SqlDbType.Int,4),
					new SqlParameter("@ApproveTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.OrgID;
			parameters[1].Value = model.Code;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.PartnerClass;
			parameters[4].Value = model.Address;
			parameters[5].Value = model.Corporate;
			parameters[6].Value = model.OrgCode;
			parameters[7].Value = model.Licence;
			parameters[8].Value = model.TaxNo;
			parameters[9].Value = model.Ownership;
			parameters[10].Value = model.RegisteredCapital;
			parameters[11].Value = model.Supervisor;
			parameters[12].Value = model.FixedAssets;
			parameters[13].Value = model.EnterpriseNum;
			parameters[14].Value = model.Contract;
			parameters[15].Value = model.Tel;
			parameters[16].Value = model.Email;
			parameters[17].Value = model.ETC;
			parameters[18].Value = model.LYSV;
			parameters[19].Value = model.YBLSV;
			parameters[20].Value = model.BankName;
			parameters[21].Value = model.BankClass;
			parameters[22].Value = model.Account;
			parameters[23].Value = model.CreateUserID;
			parameters[24].Value = model.CreateTime;
			parameters[25].Value = model.UpdateUserID;
			parameters[26].Value = model.UpdateTime;
			parameters[27].Value = model.SubmitUserID;
			parameters[28].Value = model.SubmitTime;
			parameters[29].Value = model.ApproveUserID;
			parameters[30].Value = model.ApproveTime;
			parameters[31].Value = model.ID;

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
			strSql.Append("delete from BAS_Partner ");
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
			strSql.Append("delete from BAS_Partner ");
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
		public Electric.Model.BAS_Partner GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,OrgID,Code,Name,PartnerClass,Address,Corporate,OrgCode,Licence,TaxNo,Ownership,RegisteredCapital,Supervisor,FixedAssets,EnterpriseNum,Contract,Tel,Email,ETC,LYSV,YBLSV,BankName,BankClass,Account,CreateUserID,CreateTime,UpdateUserID,UpdateTime,SubmitUserID,SubmitTime,ApproveUserID,ApproveTime from BAS_Partner ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			Electric.Model.BAS_Partner model=new Electric.Model.BAS_Partner();
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
				if(ds.Tables[0].Rows[0]["PartnerClass"]!=null && ds.Tables[0].Rows[0]["PartnerClass"].ToString()!="")
				{
					model.PartnerClass=ds.Tables[0].Rows[0]["PartnerClass"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Address"]!=null && ds.Tables[0].Rows[0]["Address"].ToString()!="")
				{
					model.Address=ds.Tables[0].Rows[0]["Address"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Corporate"]!=null && ds.Tables[0].Rows[0]["Corporate"].ToString()!="")
				{
					model.Corporate=ds.Tables[0].Rows[0]["Corporate"].ToString();
				}
				if(ds.Tables[0].Rows[0]["OrgCode"]!=null && ds.Tables[0].Rows[0]["OrgCode"].ToString()!="")
				{
					model.OrgCode=ds.Tables[0].Rows[0]["OrgCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Licence"]!=null && ds.Tables[0].Rows[0]["Licence"].ToString()!="")
				{
					model.Licence=ds.Tables[0].Rows[0]["Licence"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TaxNo"]!=null && ds.Tables[0].Rows[0]["TaxNo"].ToString()!="")
				{
					model.TaxNo=ds.Tables[0].Rows[0]["TaxNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Ownership"]!=null && ds.Tables[0].Rows[0]["Ownership"].ToString()!="")
				{
					model.Ownership=ds.Tables[0].Rows[0]["Ownership"].ToString();
				}
				if(ds.Tables[0].Rows[0]["RegisteredCapital"]!=null && ds.Tables[0].Rows[0]["RegisteredCapital"].ToString()!="")
				{
					model.RegisteredCapital=decimal.Parse(ds.Tables[0].Rows[0]["RegisteredCapital"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Supervisor"]!=null && ds.Tables[0].Rows[0]["Supervisor"].ToString()!="")
				{
					model.Supervisor=ds.Tables[0].Rows[0]["Supervisor"].ToString();
				}
				if(ds.Tables[0].Rows[0]["FixedAssets"]!=null && ds.Tables[0].Rows[0]["FixedAssets"].ToString()!="")
				{
					model.FixedAssets=decimal.Parse(ds.Tables[0].Rows[0]["FixedAssets"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EnterpriseNum"]!=null && ds.Tables[0].Rows[0]["EnterpriseNum"].ToString()!="")
				{
					model.EnterpriseNum=int.Parse(ds.Tables[0].Rows[0]["EnterpriseNum"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Contract"]!=null && ds.Tables[0].Rows[0]["Contract"].ToString()!="")
				{
					model.Contract=ds.Tables[0].Rows[0]["Contract"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Tel"]!=null && ds.Tables[0].Rows[0]["Tel"].ToString()!="")
				{
					model.Tel=ds.Tables[0].Rows[0]["Tel"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Email"]!=null && ds.Tables[0].Rows[0]["Email"].ToString()!="")
				{
					model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ETC"]!=null && ds.Tables[0].Rows[0]["ETC"].ToString()!="")
				{
					model.ETC=ds.Tables[0].Rows[0]["ETC"].ToString();
				}
				if(ds.Tables[0].Rows[0]["LYSV"]!=null && ds.Tables[0].Rows[0]["LYSV"].ToString()!="")
				{
					model.LYSV=decimal.Parse(ds.Tables[0].Rows[0]["LYSV"].ToString());
				}
				if(ds.Tables[0].Rows[0]["YBLSV"]!=null && ds.Tables[0].Rows[0]["YBLSV"].ToString()!="")
				{
					model.YBLSV=decimal.Parse(ds.Tables[0].Rows[0]["YBLSV"].ToString());
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
				if(ds.Tables[0].Rows[0]["SubmitUserID"]!=null && ds.Tables[0].Rows[0]["SubmitUserID"].ToString()!="")
				{
					model.SubmitUserID=int.Parse(ds.Tables[0].Rows[0]["SubmitUserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SubmitTime"]!=null && ds.Tables[0].Rows[0]["SubmitTime"].ToString()!="")
				{
					model.SubmitTime=DateTime.Parse(ds.Tables[0].Rows[0]["SubmitTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ApproveUserID"]!=null && ds.Tables[0].Rows[0]["ApproveUserID"].ToString()!="")
				{
					model.ApproveUserID=int.Parse(ds.Tables[0].Rows[0]["ApproveUserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ApproveTime"]!=null && ds.Tables[0].Rows[0]["ApproveTime"].ToString()!="")
				{
					model.ApproveTime=DateTime.Parse(ds.Tables[0].Rows[0]["ApproveTime"].ToString());
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
			strSql.Append("select ID,OrgID,Code,Name,PartnerClass,Address,Corporate,OrgCode,Licence,TaxNo,Ownership,RegisteredCapital,Supervisor,FixedAssets,EnterpriseNum,Contract,Tel,Email,ETC,LYSV,YBLSV,BankName,BankClass,Account,CreateUserID,CreateTime,UpdateUserID,UpdateTime,SubmitUserID,SubmitTime,ApproveUserID,ApproveTime ");
			strSql.Append(" FROM BAS_Partner ");
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
			strSql.Append(" ID,OrgID,Code,Name,PartnerClass,Address,Corporate,OrgCode,Licence,TaxNo,Ownership,RegisteredCapital,Supervisor,FixedAssets,EnterpriseNum,Contract,Tel,Email,ETC,LYSV,YBLSV,BankName,BankClass,Account,CreateUserID,CreateTime,UpdateUserID,UpdateTime,SubmitUserID,SubmitTime,ApproveUserID,ApproveTime ");
			strSql.Append(" FROM BAS_Partner ");
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
			strSql.Append("select count(1) FROM BAS_Partner ");
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
			strSql.Append(")AS Row, T.*  from BAS_Partner T ");
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
			parameters[0].Value = "BAS_Partner";
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

