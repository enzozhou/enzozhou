using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Electric.DAL
{
	/// <summary>
	/// 数据访问类:BS_BuyInfo_Details
	/// </summary>
	public partial class BS_BuyInfo_Details
	{
		public BS_BuyInfo_Details()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "BS_BuyInfo_Details"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BS_BuyInfo_Details");
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
		public int Add(Electric.Model.BS_BuyInfo_Details model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BS_BuyInfo_Details(");
			strSql.Append("OrgCode,ContractNo,InvoiceNo,InvoiceDate,NewModel,NewQty,NewRating,NewVoltage,NewSpeed,NewProtectionLev,NewMC,NewWeight,Price,TerminalUnit,TUNo,NewSerialNum,CreateUserID,CreateTime,UpdateUserID,UpdateTime,SubmitUserID,SubmitTime,ApproveUserID,ApproveTime,UnitPrice,Subsidy)");
			strSql.Append(" values (");
			strSql.Append("@OrgCode,@ContractNo,@InvoiceNo,@InvoiceDate,@NewModel,@NewQty,@NewRating,@NewVoltage,@NewSpeed,@NewProtectionLev,@NewMC,@NewWeight,@Price,@TerminalUnit,@TUNo,@NewSerialNum,@CreateUserID,@CreateTime,@UpdateUserID,@UpdateTime,@SubmitUserID,@SubmitTime,@ApproveUserID,@ApproveTime,@UnitPrice,@Subsidy)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@OrgCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractNo", SqlDbType.NVarChar,50),
					new SqlParameter("@InvoiceNo", SqlDbType.NVarChar,50),
					new SqlParameter("@InvoiceDate", SqlDbType.DateTime),
					new SqlParameter("@NewModel", SqlDbType.NVarChar,50),
					new SqlParameter("@NewQty", SqlDbType.Int,4),
					new SqlParameter("@NewRating", SqlDbType.Decimal,9),
					new SqlParameter("@NewVoltage", SqlDbType.Decimal,9),
					new SqlParameter("@NewSpeed", SqlDbType.Decimal,9),
					new SqlParameter("@NewProtectionLev", SqlDbType.NVarChar,50),
					new SqlParameter("@NewMC", SqlDbType.NVarChar,100),
					new SqlParameter("@NewWeight", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@TerminalUnit", SqlDbType.NVarChar,50),
					new SqlParameter("@TUNo", SqlDbType.NVarChar,50),
					new SqlParameter("@NewSerialNum", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateUserID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateUserID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@SubmitUserID", SqlDbType.Int,4),
					new SqlParameter("@SubmitTime", SqlDbType.DateTime),
					new SqlParameter("@ApproveUserID", SqlDbType.Int,4),
					new SqlParameter("@ApproveTime", SqlDbType.DateTime),
					new SqlParameter("@UnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Subsidy", SqlDbType.Decimal,9)};
			parameters[0].Value = model.OrgCode;
			parameters[1].Value = model.ContractNo;
			parameters[2].Value = model.InvoiceNo;
			parameters[3].Value = model.InvoiceDate;
			parameters[4].Value = model.NewModel;
			parameters[5].Value = model.NewQty;
			parameters[6].Value = model.NewRating;
			parameters[7].Value = model.NewVoltage;
			parameters[8].Value = model.NewSpeed;
			parameters[9].Value = model.NewProtectionLev;
			parameters[10].Value = model.NewMC;
			parameters[11].Value = model.NewWeight;
			parameters[12].Value = model.Price;
			parameters[13].Value = model.TerminalUnit;
			parameters[14].Value = model.TUNo;
			parameters[15].Value = model.NewSerialNum;
			parameters[16].Value = model.CreateUserID;
			parameters[17].Value = model.CreateTime;
			parameters[18].Value = model.UpdateUserID;
			parameters[19].Value = model.UpdateTime;
			parameters[20].Value = model.SubmitUserID;
			parameters[21].Value = model.SubmitTime;
			parameters[22].Value = model.ApproveUserID;
			parameters[23].Value = model.ApproveTime;
            parameters[24].Value = model.UnitPrice;
            parameters[25].Value = model.Subsidy;

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
		public bool Update(Electric.Model.BS_BuyInfo_Details model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BS_BuyInfo_Details set ");
			strSql.Append("OrgCode=@OrgCode,");
			strSql.Append("ContractNo=@ContractNo,");
			strSql.Append("InvoiceNo=@InvoiceNo,");
			strSql.Append("InvoiceDate=@InvoiceDate,");
			strSql.Append("NewModel=@NewModel,");
			strSql.Append("NewQty=@NewQty,");
			strSql.Append("NewRating=@NewRating,");
			strSql.Append("NewVoltage=@NewVoltage,");
			strSql.Append("NewSpeed=@NewSpeed,");
			strSql.Append("NewProtectionLev=@NewProtectionLev,");
			strSql.Append("NewMC=@NewMC,");
			strSql.Append("NewWeight=@NewWeight,");
			strSql.Append("Price=@Price,");
			strSql.Append("TerminalUnit=@TerminalUnit,");
			strSql.Append("TUNo=@TUNo,");
			strSql.Append("NewSerialNum=@NewSerialNum,");
			strSql.Append("CreateUserID=@CreateUserID,");
			strSql.Append("CreateTime=@CreateTime,");
			strSql.Append("UpdateUserID=@UpdateUserID,");
			strSql.Append("UpdateTime=@UpdateTime,");
			strSql.Append("SubmitUserID=@SubmitUserID,");
			strSql.Append("SubmitTime=@SubmitTime,");
			strSql.Append("ApproveUserID=@ApproveUserID,");
            strSql.Append("ApproveTime=@ApproveTime,");
            strSql.Append("UnitPrice=@UnitPrice,");
            strSql.Append("Subsidy=@SubSidy,");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@OrgCode", SqlDbType.NVarChar,50),
					new SqlParameter("@ContractNo", SqlDbType.NVarChar,50),
					new SqlParameter("@InvoiceNo", SqlDbType.NVarChar,50),
					new SqlParameter("@InvoiceDate", SqlDbType.DateTime),
					new SqlParameter("@NewModel", SqlDbType.NVarChar,50),
					new SqlParameter("@NewQty", SqlDbType.Int,4),
					new SqlParameter("@NewRating", SqlDbType.Decimal,9),
					new SqlParameter("@NewVoltage", SqlDbType.Decimal,9),
					new SqlParameter("@NewSpeed", SqlDbType.Decimal,9),
					new SqlParameter("@NewProtectionLev", SqlDbType.NVarChar,50),
					new SqlParameter("@NewMC", SqlDbType.NVarChar,100),
					new SqlParameter("@NewWeight", SqlDbType.Decimal,9),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
					new SqlParameter("@TerminalUnit", SqlDbType.NVarChar,50),
					new SqlParameter("@TUNo", SqlDbType.NVarChar,50),
					new SqlParameter("@NewSerialNum", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateUserID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateUserID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@SubmitUserID", SqlDbType.Int,4),
					new SqlParameter("@SubmitTime", SqlDbType.DateTime),
					new SqlParameter("@ApproveUserID", SqlDbType.Int,4),
					new SqlParameter("@ApproveTime", SqlDbType.DateTime),
					new SqlParameter("@UnitPrice", SqlDbType.Decimal,9),
					new SqlParameter("@Subsidy", SqlDbType.Decimal,9),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.OrgCode;
			parameters[1].Value = model.ContractNo;
			parameters[2].Value = model.InvoiceNo;
			parameters[3].Value = model.InvoiceDate;
			parameters[4].Value = model.NewModel;
			parameters[5].Value = model.NewQty;
			parameters[6].Value = model.NewRating;
			parameters[7].Value = model.NewVoltage;
			parameters[8].Value = model.NewSpeed;
			parameters[9].Value = model.NewProtectionLev;
			parameters[10].Value = model.NewMC;
			parameters[11].Value = model.NewWeight;
			parameters[12].Value = model.Price;
			parameters[13].Value = model.TerminalUnit;
			parameters[14].Value = model.TUNo;
			parameters[15].Value = model.NewSerialNum;
			parameters[16].Value = model.CreateUserID;
			parameters[17].Value = model.CreateTime;
			parameters[18].Value = model.UpdateUserID;
			parameters[19].Value = model.UpdateTime;
			parameters[20].Value = model.SubmitUserID;
			parameters[21].Value = model.SubmitTime;
			parameters[22].Value = model.ApproveUserID;
            parameters[23].Value = model.ApproveTime;
            parameters[24].Value = model.UnitPrice;
            parameters[25].Value = model.Subsidy;
			parameters[26].Value = model.ID;

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
			strSql.Append("delete from BS_BuyInfo_Details ");
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
			strSql.Append("delete from BS_BuyInfo_Details ");
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
		public Electric.Model.BS_BuyInfo_Details GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,OrgCode,ContractNo,InvoiceNo,InvoiceDate,NewModel,NewQty,NewRating,NewVoltage,NewSpeed,NewProtectionLev,NewMC,NewWeight,Price,TerminalUnit,TUNo,NewSerialNum,CreateUserID,CreateTime,UpdateUserID,UpdateTime,SubmitUserID,SubmitTime,ApproveUserID,ApproveTime,UnitPrice,Subsidy from BS_BuyInfo_Details ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			Electric.Model.BS_BuyInfo_Details model=new Electric.Model.BS_BuyInfo_Details();
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
				if(ds.Tables[0].Rows[0]["InvoiceNo"]!=null && ds.Tables[0].Rows[0]["InvoiceNo"].ToString()!="")
				{
					model.InvoiceNo=ds.Tables[0].Rows[0]["InvoiceNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["InvoiceDate"]!=null && ds.Tables[0].Rows[0]["InvoiceDate"].ToString()!="")
				{
					model.InvoiceDate=DateTime.Parse(ds.Tables[0].Rows[0]["InvoiceDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NewModel"]!=null && ds.Tables[0].Rows[0]["NewModel"].ToString()!="")
				{
					model.NewModel=ds.Tables[0].Rows[0]["NewModel"].ToString();
				}
				if(ds.Tables[0].Rows[0]["NewQty"]!=null && ds.Tables[0].Rows[0]["NewQty"].ToString()!="")
				{
					model.NewQty=int.Parse(ds.Tables[0].Rows[0]["NewQty"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NewRating"]!=null && ds.Tables[0].Rows[0]["NewRating"].ToString()!="")
				{
					model.NewRating=decimal.Parse(ds.Tables[0].Rows[0]["NewRating"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NewVoltage"]!=null && ds.Tables[0].Rows[0]["NewVoltage"].ToString()!="")
				{
					model.NewVoltage=decimal.Parse(ds.Tables[0].Rows[0]["NewVoltage"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NewSpeed"]!=null && ds.Tables[0].Rows[0]["NewSpeed"].ToString()!="")
				{
					model.NewSpeed=decimal.Parse(ds.Tables[0].Rows[0]["NewSpeed"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NewProtectionLev"]!=null && ds.Tables[0].Rows[0]["NewProtectionLev"].ToString()!="")
				{
					model.NewProtectionLev=ds.Tables[0].Rows[0]["NewProtectionLev"].ToString();
				}
				if(ds.Tables[0].Rows[0]["NewMC"]!=null && ds.Tables[0].Rows[0]["NewMC"].ToString()!="")
				{
					model.NewMC=ds.Tables[0].Rows[0]["NewMC"].ToString();
				}
				if(ds.Tables[0].Rows[0]["NewWeight"]!=null && ds.Tables[0].Rows[0]["NewWeight"].ToString()!="")
				{
					model.NewWeight=decimal.Parse(ds.Tables[0].Rows[0]["NewWeight"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Price"]!=null && ds.Tables[0].Rows[0]["Price"].ToString()!="")
				{
					model.Price=decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TerminalUnit"]!=null && ds.Tables[0].Rows[0]["TerminalUnit"].ToString()!="")
				{
					model.TerminalUnit=ds.Tables[0].Rows[0]["TerminalUnit"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TUNo"]!=null && ds.Tables[0].Rows[0]["TUNo"].ToString()!="")
				{
					model.TUNo=ds.Tables[0].Rows[0]["TUNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["NewSerialNum"]!=null && ds.Tables[0].Rows[0]["NewSerialNum"].ToString()!="")
				{
					model.NewSerialNum=ds.Tables[0].Rows[0]["NewSerialNum"].ToString();
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
                if (ds.Tables[0].Rows[0]["UnitPrice"] != null && ds.Tables[0].Rows[0]["UnitPrice"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["UnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Subsidy"] != null && ds.Tables[0].Rows[0]["Subsidy"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Subsidy"].ToString());
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
			strSql.Append("select ID,OrgCode,ContractNo,InvoiceNo,InvoiceDate,NewModel,NewQty,NewRating,NewVoltage,NewSpeed,NewProtectionLev,NewMC,NewWeight,Price,TerminalUnit,TUNo,NewSerialNum,CreateUserID,CreateTime,UpdateUserID,UpdateTime,SubmitUserID,SubmitTime,ApproveUserID,ApproveTime,UnitPrice,Subsidy ");
			strSql.Append(" FROM BS_BuyInfo_Details ");
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
			strSql.Append(" ID,OrgCode,ContractNo,InvoiceNo,InvoiceDate,NewModel,NewQty,NewRating,NewVoltage,NewSpeed,NewProtectionLev,NewMC,NewWeight,Price,TerminalUnit,TUNo,NewSerialNum,CreateUserID,CreateTime,UpdateUserID,UpdateTime,SubmitUserID,SubmitTime,ApproveUserID,ApproveTime,UnitPrice,Subsidy ");
			strSql.Append(" FROM BS_BuyInfo_Details ");
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
			strSql.Append("select count(1) FROM BS_BuyInfo_Details ");
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
			strSql.Append(")AS Row, T.*  from BS_BuyInfo_Details T ");
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
			parameters[0].Value = "BS_BuyInfo_Details";
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

