﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Electric.DAL
{
	/// <summary>
	/// 数据访问类:BS_RecoveryContract
	/// </summary>
	public partial class BS_RecoveryContract
	{
		public BS_RecoveryContract()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "BS_RecoveryContract"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string ContractNo,int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BS_RecoveryContract");
			strSql.Append(" where ContractNo=@ContractNo and ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ContractNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)			};
			parameters[0].Value = ContractNo;
			parameters[1].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Electric.Model.BS_RecoveryContract model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BS_RecoveryContract(");
			strSql.Append("OrgCode,ContractNo,PartnerCode,PartnerName,PartnerAddress,PartnerContract,PartnerTel,PartnerBank,PartnerAccount,PartnerTaxNo,DeliveryTerm,Price,Words,FPP,FPR,SPP,SPR,LPP,LPR,CreateUserID,CreateTime,UpdateUserID,UpdateTime,SubmitUserID,SubmitTime,ApproveUserID,ApproveTime)");
			strSql.Append(" values (");
			strSql.Append("@OrgCode,@ContractNo,@PartnerCode,@PartnerName,@PartnerAddress,@PartnerContract,@PartnerTel,@PartnerBank,@PartnerAccount,@PartnerTaxNo,@DeliveryTerm,@Price,@Words,@FPP,@FPR,@SPP,@SPR,@LPP,@LPR,@CreateUserID,@CreateTime,@UpdateUserID,@UpdateTime,@SubmitUserID,@SubmitTime,@ApproveUserID,@ApproveTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@OrgCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractNo", SqlDbType.NVarChar,50),
					new SqlParameter("@PartnerCode", SqlDbType.NVarChar,50),
					new SqlParameter("@PartnerName", SqlDbType.NVarChar,100),
					new SqlParameter("@PartnerAddress", SqlDbType.NVarChar,100),
					new SqlParameter("@PartnerContract", SqlDbType.NVarChar,50),
					new SqlParameter("@PartnerTel", SqlDbType.NVarChar,50),
					new SqlParameter("@PartnerBank", SqlDbType.NVarChar,50),
					new SqlParameter("@PartnerAccount", SqlDbType.NVarChar,50),
					new SqlParameter("@PartnerTaxNo", SqlDbType.NVarChar,50),
					new SqlParameter("@DeliveryTerm", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@Words", SqlDbType.NVarChar,100),
					new SqlParameter("@FPP", SqlDbType.Int,4),
					new SqlParameter("@FPR", SqlDbType.Decimal,9),
					new SqlParameter("@SPP", SqlDbType.Int,4),
					new SqlParameter("@SPR", SqlDbType.Decimal,9),
					new SqlParameter("@LPP", SqlDbType.Int,4),
					new SqlParameter("@LPR", SqlDbType.Decimal,9),
					new SqlParameter("@CreateUserID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateUserID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@SubmitUserID", SqlDbType.Int,4),
					new SqlParameter("@SubmitTime", SqlDbType.DateTime),
					new SqlParameter("@ApproveUserID", SqlDbType.Int,4),
					new SqlParameter("@ApproveTime", SqlDbType.DateTime)};
			parameters[0].Value = model.OrgCode;
			parameters[1].Value = model.ContractNo;
			parameters[2].Value = model.PartnerCode;
			parameters[3].Value = model.PartnerName;
			parameters[4].Value = model.PartnerAddress;
			parameters[5].Value = model.PartnerContract;
			parameters[6].Value = model.PartnerTel;
			parameters[7].Value = model.PartnerBank;
			parameters[8].Value = model.PartnerAccount;
			parameters[9].Value = model.PartnerTaxNo;
			parameters[10].Value = model.DeliveryTerm;
			parameters[11].Value = model.Price;
			parameters[12].Value = model.Words;
			parameters[13].Value = model.FPP;
			parameters[14].Value = model.FPR;
			parameters[15].Value = model.SPP;
			parameters[16].Value = model.SPR;
			parameters[17].Value = model.LPP;
			parameters[18].Value = model.LPR;
			parameters[19].Value = model.CreateUserID;
			parameters[20].Value = model.CreateTime;
			parameters[21].Value = model.UpdateUserID;
			parameters[22].Value = model.UpdateTime;
			parameters[23].Value = model.SubmitUserID;
			parameters[24].Value = model.SubmitTime;
			parameters[25].Value = model.ApproveUserID;
			parameters[26].Value = model.ApproveTime;

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
		public bool Update(Electric.Model.BS_RecoveryContract model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BS_RecoveryContract set ");
			strSql.Append("OrgCode=@OrgCode,");
			strSql.Append("PartnerCode=@PartnerCode,");
			strSql.Append("PartnerName=@PartnerName,");
			strSql.Append("PartnerAddress=@PartnerAddress,");
			strSql.Append("PartnerContract=@PartnerContract,");
			strSql.Append("PartnerTel=@PartnerTel,");
			strSql.Append("PartnerBank=@PartnerBank,");
			strSql.Append("PartnerAccount=@PartnerAccount,");
			strSql.Append("PartnerTaxNo=@PartnerTaxNo,");
			strSql.Append("DeliveryTerm=@DeliveryTerm,");
			strSql.Append("Price=@Price,");
			strSql.Append("Words=@Words,");
			strSql.Append("FPP=@FPP,");
			strSql.Append("FPR=@FPR,");
			strSql.Append("SPP=@SPP,");
			strSql.Append("SPR=@SPR,");
			strSql.Append("LPP=@LPP,");
			strSql.Append("LPR=@LPR,");
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
					new SqlParameter("@OrgCode", SqlDbType.NVarChar,50),
					new SqlParameter("@PartnerCode", SqlDbType.NVarChar,50),
					new SqlParameter("@PartnerName", SqlDbType.NVarChar,100),
					new SqlParameter("@PartnerAddress", SqlDbType.NVarChar,100),
					new SqlParameter("@PartnerContract", SqlDbType.NVarChar,50),
					new SqlParameter("@PartnerTel", SqlDbType.NVarChar,50),
					new SqlParameter("@PartnerBank", SqlDbType.NVarChar,50),
					new SqlParameter("@PartnerAccount", SqlDbType.NVarChar,50),
					new SqlParameter("@PartnerTaxNo", SqlDbType.NVarChar,50),
					new SqlParameter("@DeliveryTerm", SqlDbType.Int,4),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@Words", SqlDbType.NVarChar,100),
					new SqlParameter("@FPP", SqlDbType.Int,4),
					new SqlParameter("@FPR", SqlDbType.Decimal,9),
					new SqlParameter("@SPP", SqlDbType.Int,4),
					new SqlParameter("@SPR", SqlDbType.Decimal,9),
					new SqlParameter("@LPP", SqlDbType.Int,4),
					new SqlParameter("@LPR", SqlDbType.Decimal,9),
					new SqlParameter("@CreateUserID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateUserID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@SubmitUserID", SqlDbType.Int,4),
					new SqlParameter("@SubmitTime", SqlDbType.DateTime),
					new SqlParameter("@ApproveUserID", SqlDbType.Int,4),
					new SqlParameter("@ApproveTime", SqlDbType.DateTime),
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@ContractNo", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.OrgCode;
			parameters[1].Value = model.PartnerCode;
			parameters[2].Value = model.PartnerName;
			parameters[3].Value = model.PartnerAddress;
			parameters[4].Value = model.PartnerContract;
			parameters[5].Value = model.PartnerTel;
			parameters[6].Value = model.PartnerBank;
			parameters[7].Value = model.PartnerAccount;
			parameters[8].Value = model.PartnerTaxNo;
			parameters[9].Value = model.DeliveryTerm;
			parameters[10].Value = model.Price;
			parameters[11].Value = model.Words;
			parameters[12].Value = model.FPP;
			parameters[13].Value = model.FPR;
			parameters[14].Value = model.SPP;
			parameters[15].Value = model.SPR;
			parameters[16].Value = model.LPP;
			parameters[17].Value = model.LPR;
			parameters[18].Value = model.CreateUserID;
			parameters[19].Value = model.CreateTime;
			parameters[20].Value = model.UpdateUserID;
			parameters[21].Value = model.UpdateTime;
			parameters[22].Value = model.SubmitUserID;
			parameters[23].Value = model.SubmitTime;
			parameters[24].Value = model.ApproveUserID;
			parameters[25].Value = model.ApproveTime;
			parameters[26].Value = model.ID;
			parameters[27].Value = model.ContractNo;

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
			strSql.Append("delete from BS_RecoveryContract ");
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
		public bool Delete(string ContractNo,int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from BS_RecoveryContract ");
			strSql.Append(" where ContractNo=@ContractNo and ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ContractNo", SqlDbType.NVarChar,50),
					new SqlParameter("@ID", SqlDbType.Int,4)			};
			parameters[0].Value = ContractNo;
			parameters[1].Value = ID;

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
			strSql.Append("delete from BS_RecoveryContract ");
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
		public Electric.Model.BS_RecoveryContract GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,OrgCode,ContractNo,PartnerCode,PartnerName,PartnerAddress,PartnerContract,PartnerTel,PartnerBank,PartnerAccount,PartnerTaxNo,DeliveryTerm,Price,Words,FPP,FPR,SPP,SPR,LPP,LPR,CreateUserID,CreateTime,UpdateUserID,UpdateTime,SubmitUserID,SubmitTime,ApproveUserID,ApproveTime from BS_RecoveryContract ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			Electric.Model.BS_RecoveryContract model=new Electric.Model.BS_RecoveryContract();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OrgCode"]!=null && ds.Tables[0].Rows[0]["OrgCode"].ToString()!="")
				{
					model.OrgCode=ds.Tables[0].Rows[0]["OrgCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ContractNo"]!=null && ds.Tables[0].Rows[0]["ContractNo"].ToString()!="")
				{
					model.ContractNo=ds.Tables[0].Rows[0]["ContractNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PartnerCode"]!=null && ds.Tables[0].Rows[0]["PartnerCode"].ToString()!="")
				{
					model.PartnerCode=ds.Tables[0].Rows[0]["PartnerCode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PartnerName"]!=null && ds.Tables[0].Rows[0]["PartnerName"].ToString()!="")
				{
					model.PartnerName=ds.Tables[0].Rows[0]["PartnerName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PartnerAddress"]!=null && ds.Tables[0].Rows[0]["PartnerAddress"].ToString()!="")
				{
					model.PartnerAddress=ds.Tables[0].Rows[0]["PartnerAddress"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PartnerContract"]!=null && ds.Tables[0].Rows[0]["PartnerContract"].ToString()!="")
				{
					model.PartnerContract=ds.Tables[0].Rows[0]["PartnerContract"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PartnerTel"]!=null && ds.Tables[0].Rows[0]["PartnerTel"].ToString()!="")
				{
					model.PartnerTel=ds.Tables[0].Rows[0]["PartnerTel"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PartnerBank"]!=null && ds.Tables[0].Rows[0]["PartnerBank"].ToString()!="")
				{
					model.PartnerBank=ds.Tables[0].Rows[0]["PartnerBank"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PartnerAccount"]!=null && ds.Tables[0].Rows[0]["PartnerAccount"].ToString()!="")
				{
					model.PartnerAccount=ds.Tables[0].Rows[0]["PartnerAccount"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PartnerTaxNo"]!=null && ds.Tables[0].Rows[0]["PartnerTaxNo"].ToString()!="")
				{
					model.PartnerTaxNo=ds.Tables[0].Rows[0]["PartnerTaxNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["DeliveryTerm"]!=null && ds.Tables[0].Rows[0]["DeliveryTerm"].ToString()!="")
				{
					model.DeliveryTerm=int.Parse(ds.Tables[0].Rows[0]["DeliveryTerm"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"]!=null && ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Words"]!=null && ds.Tables[0].Rows[0]["Words"].ToString()!="")
				{
					model.Words=ds.Tables[0].Rows[0]["Words"].ToString();
				}
				if(ds.Tables[0].Rows[0]["FPP"]!=null && ds.Tables[0].Rows[0]["FPP"].ToString()!="")
				{
					model.FPP=int.Parse(ds.Tables[0].Rows[0]["FPP"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FPR"]!=null && ds.Tables[0].Rows[0]["FPR"].ToString()!="")
				{
					model.FPR=decimal.Parse(ds.Tables[0].Rows[0]["FPR"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SPP"]!=null && ds.Tables[0].Rows[0]["SPP"].ToString()!="")
				{
					model.SPP=int.Parse(ds.Tables[0].Rows[0]["SPP"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SPR"]!=null && ds.Tables[0].Rows[0]["SPR"].ToString()!="")
				{
					model.SPR=decimal.Parse(ds.Tables[0].Rows[0]["SPR"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LPP"]!=null && ds.Tables[0].Rows[0]["LPP"].ToString()!="")
				{
					model.LPP=int.Parse(ds.Tables[0].Rows[0]["LPP"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LPR"]!=null && ds.Tables[0].Rows[0]["LPR"].ToString()!="")
				{
					model.LPR=decimal.Parse(ds.Tables[0].Rows[0]["LPR"].ToString());
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
			strSql.Append("select ID,OrgCode,ContractNo,PartnerCode,PartnerName,PartnerAddress,PartnerContract,PartnerTel,PartnerBank,PartnerAccount,PartnerTaxNo,DeliveryTerm,Price,Words,FPP,FPR,SPP,SPR,LPP,LPR,CreateUserID,CreateTime,UpdateUserID,UpdateTime,SubmitUserID,SubmitTime,ApproveUserID,ApproveTime ");
			strSql.Append(" FROM BS_RecoveryContract ");
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
			strSql.Append(" ID,OrgCode,ContractNo,PartnerCode,PartnerName,PartnerAddress,PartnerContract,PartnerTel,PartnerBank,PartnerAccount,PartnerTaxNo,DeliveryTerm,Price,Words,FPP,FPR,SPP,SPR,LPP,LPR,CreateUserID,CreateTime,UpdateUserID,UpdateTime,SubmitUserID,SubmitTime,ApproveUserID,ApproveTime ");
			strSql.Append(" FROM BS_RecoveryContract ");
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
			strSql.Append("select count(1) FROM BS_RecoveryContract ");
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
			strSql.Append(")AS Row, T.*  from BS_RecoveryContract T ");
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
			parameters[0].Value = "BS_RecoveryContract";
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

