using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Electric.DAL
{
	/// <summary>
	/// 数据访问类:BS_NewForOld_Details
	/// </summary>
	public partial class BS_NewForOld_Details
	{
		public BS_NewForOld_Details()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "BS_NewForOld_Details"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from BS_NewForOld_Details");
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
		public int Add(Electric.Model.BS_NewForOld_Details model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into BS_NewForOld_Details(");
			strSql.Append("OrgID,ContractNo,OldModel,OldPowerRating,OldQty,OldSpeed,OldProtectionLev,OldOutDate,OldWeight,OldPrice,OldSubsidy,OldSumPrice,TerminalUnit,TUNo,NewModel,NewPowerRating,NewQty,PurchasePrice,Reconstruction,NewInvoiceNo,NewInvoiceDate,NewMC,NewSerialNum,CreateUserID,CreateTime,UpdateUserID,UpdateTime,SubmitUserID,SubmitTime,ApproveUserID,ApproveTime)");
			strSql.Append(" values (");
			strSql.Append("@OrgID,@ContractNo,@OldModel,@OldPowerRating,@OldQty,@OldSpeed,@OldProtectionLev,@OldOutDate,@OldWeight,@OldPrice,@OldSubsidy,@OldSumPrice,@TerminalUnit,@TUNo,@NewModel,@NewPowerRating,@NewQty,@PurchasePrice,@Reconstruction,@NewInvoiceNo,@NewInvoiceDate,@NewMC,@NewSerialNum,@CreateUserID,@CreateTime,@UpdateUserID,@UpdateTime,@SubmitUserID,@SubmitTime,@ApproveUserID,@ApproveTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@OrgID", SqlDbType.Int,4),
					new SqlParameter("@ContractNo", SqlDbType.NVarChar,50),
					new SqlParameter("@OldModel", SqlDbType.NVarChar,50),
					new SqlParameter("@OldPowerRating", SqlDbType.Decimal,9),
					new SqlParameter("@OldQty", SqlDbType.Int,4),
					new SqlParameter("@OldSpeed", SqlDbType.Decimal,9),
					new SqlParameter("@OldProtectionLev", SqlDbType.NVarChar,50),
					new SqlParameter("@OldOutDate", SqlDbType.DateTime),
					new SqlParameter("@OldWeight", SqlDbType.Decimal,9),
					new SqlParameter("@OldPrice", SqlDbType.Decimal,9),
					new SqlParameter("@OldSubsidy", SqlDbType.Decimal,9),
					new SqlParameter("@OldSumPrice", SqlDbType.Decimal,9),
					new SqlParameter("@TerminalUnit", SqlDbType.NVarChar,50),
					new SqlParameter("@TUNo", SqlDbType.NVarChar,50),
					new SqlParameter("@NewModel", SqlDbType.NVarChar,50),
					new SqlParameter("@NewPowerRating", SqlDbType.Decimal,9),
					new SqlParameter("@NewQty", SqlDbType.Int,4),
					new SqlParameter("@PurchasePrice", SqlDbType.Decimal,9),
					new SqlParameter("@Reconstruction", SqlDbType.NVarChar,50),
					new SqlParameter("@NewInvoiceNo", SqlDbType.NVarChar,50),
					new SqlParameter("@NewInvoiceDate", SqlDbType.DateTime),
					new SqlParameter("@NewMC", SqlDbType.NVarChar,100),
					new SqlParameter("@NewSerialNum", SqlDbType.NVarChar,50),
					new SqlParameter("@CreateUserID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateUserID", SqlDbType.Int,4),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@SubmitUserID", SqlDbType.Int,4),
					new SqlParameter("@SubmitTime", SqlDbType.DateTime),
					new SqlParameter("@ApproveUserID", SqlDbType.Int,4),
					new SqlParameter("@ApproveTime", SqlDbType.DateTime)};
			parameters[0].Value = model.OrgID;
			parameters[1].Value = model.ContractNo;
			parameters[2].Value = model.OldModel;
			parameters[3].Value = model.OldPowerRating;
			parameters[4].Value = model.OldQty;
			parameters[5].Value = model.OldSpeed;
			parameters[6].Value = model.OldProtectionLev;
			parameters[7].Value = model.OldOutDate;
			parameters[8].Value = model.OldWeight;
			parameters[9].Value = model.OldPrice;
			parameters[10].Value = model.OldSubsidy;
			parameters[11].Value = model.OldSumPrice;
			parameters[12].Value = model.TerminalUnit;
			parameters[13].Value = model.TUNo;
			parameters[14].Value = model.NewModel;
			parameters[15].Value = model.NewPowerRating;
			parameters[16].Value = model.NewQty;
			parameters[17].Value = model.PurchasePrice;
			parameters[18].Value = model.Reconstruction;
			parameters[19].Value = model.NewInvoiceNo;
			parameters[20].Value = model.NewInvoiceDate;
			parameters[21].Value = model.NewMC;
			parameters[22].Value = model.NewSerialNum;
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
		public bool Update(Electric.Model.BS_NewForOld_Details model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update BS_NewForOld_Details set ");
			strSql.Append("OrgID=@OrgID,");
			strSql.Append("ContractNo=@ContractNo,");
			strSql.Append("OldModel=@OldModel,");
			strSql.Append("OldPowerRating=@OldPowerRating,");
			strSql.Append("OldQty=@OldQty,");
			strSql.Append("OldSpeed=@OldSpeed,");
			strSql.Append("OldProtectionLev=@OldProtectionLev,");
			strSql.Append("OldOutDate=@OldOutDate,");
			strSql.Append("OldWeight=@OldWeight,");
			strSql.Append("OldPrice=@OldPrice,");
			strSql.Append("OldSubsidy=@OldSubsidy,");
			strSql.Append("OldSumPrice=@OldSumPrice,");
			strSql.Append("TerminalUnit=@TerminalUnit,");
			strSql.Append("TUNo=@TUNo,");
			strSql.Append("NewModel=@NewModel,");
			strSql.Append("NewPowerRating=@NewPowerRating,");
			strSql.Append("NewQty=@NewQty,");
			strSql.Append("PurchasePrice=@PurchasePrice,");
			strSql.Append("Reconstruction=@Reconstruction,");
			strSql.Append("NewInvoiceNo=@NewInvoiceNo,");
			strSql.Append("NewInvoiceDate=@NewInvoiceDate,");
			strSql.Append("NewMC=@NewMC,");
			strSql.Append("NewSerialNum=@NewSerialNum,");
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
					new SqlParameter("@ContractNo", SqlDbType.NVarChar,50),
					new SqlParameter("@OldModel", SqlDbType.NVarChar,50),
					new SqlParameter("@OldPowerRating", SqlDbType.Decimal,9),
					new SqlParameter("@OldQty", SqlDbType.Int,4),
					new SqlParameter("@OldSpeed", SqlDbType.Decimal,9),
					new SqlParameter("@OldProtectionLev", SqlDbType.NVarChar,50),
					new SqlParameter("@OldOutDate", SqlDbType.DateTime),
					new SqlParameter("@OldWeight", SqlDbType.Decimal,9),
					new SqlParameter("@OldPrice", SqlDbType.Decimal,9),
					new SqlParameter("@OldSubsidy", SqlDbType.Decimal,9),
					new SqlParameter("@OldSumPrice", SqlDbType.Decimal,9),
					new SqlParameter("@TerminalUnit", SqlDbType.NVarChar,50),
					new SqlParameter("@TUNo", SqlDbType.NVarChar,50),
					new SqlParameter("@NewModel", SqlDbType.NVarChar,50),
					new SqlParameter("@NewPowerRating", SqlDbType.Decimal,9),
					new SqlParameter("@NewQty", SqlDbType.Int,4),
					new SqlParameter("@PurchasePrice", SqlDbType.Decimal,9),
					new SqlParameter("@Reconstruction", SqlDbType.NVarChar,50),
					new SqlParameter("@NewInvoiceNo", SqlDbType.NVarChar,50),
					new SqlParameter("@NewInvoiceDate", SqlDbType.DateTime),
					new SqlParameter("@NewMC", SqlDbType.NVarChar,100),
					new SqlParameter("@NewSerialNum", SqlDbType.NVarChar,50),
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
			parameters[1].Value = model.ContractNo;
			parameters[2].Value = model.OldModel;
			parameters[3].Value = model.OldPowerRating;
			parameters[4].Value = model.OldQty;
			parameters[5].Value = model.OldSpeed;
			parameters[6].Value = model.OldProtectionLev;
			parameters[7].Value = model.OldOutDate;
			parameters[8].Value = model.OldWeight;
			parameters[9].Value = model.OldPrice;
			parameters[10].Value = model.OldSubsidy;
			parameters[11].Value = model.OldSumPrice;
			parameters[12].Value = model.TerminalUnit;
			parameters[13].Value = model.TUNo;
			parameters[14].Value = model.NewModel;
			parameters[15].Value = model.NewPowerRating;
			parameters[16].Value = model.NewQty;
			parameters[17].Value = model.PurchasePrice;
			parameters[18].Value = model.Reconstruction;
			parameters[19].Value = model.NewInvoiceNo;
			parameters[20].Value = model.NewInvoiceDate;
			parameters[21].Value = model.NewMC;
			parameters[22].Value = model.NewSerialNum;
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
			strSql.Append("delete from BS_NewForOld_Details ");
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
			strSql.Append("delete from BS_NewForOld_Details ");
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
		public Electric.Model.BS_NewForOld_Details GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,OrgID,ContractNo,OldModel,OldPowerRating,OldQty,OldSpeed,OldProtectionLev,OldOutDate,OldWeight,OldPrice,OldSubsidy,OldSumPrice,TerminalUnit,TUNo,NewModel,NewPowerRating,NewQty,PurchasePrice,Reconstruction,NewInvoiceNo,NewInvoiceDate,NewMC,NewSerialNum,CreateUserID,CreateTime,UpdateUserID,UpdateTime,SubmitUserID,SubmitTime,ApproveUserID,ApproveTime from BS_NewForOld_Details ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			Electric.Model.BS_NewForOld_Details model=new Electric.Model.BS_NewForOld_Details();
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
				if(ds.Tables[0].Rows[0]["ContractNo"]!=null && ds.Tables[0].Rows[0]["ContractNo"].ToString()!="")
				{
					model.ContractNo=ds.Tables[0].Rows[0]["ContractNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["OldModel"]!=null && ds.Tables[0].Rows[0]["OldModel"].ToString()!="")
				{
					model.OldModel=ds.Tables[0].Rows[0]["OldModel"].ToString();
				}
				if(ds.Tables[0].Rows[0]["OldPowerRating"]!=null && ds.Tables[0].Rows[0]["OldPowerRating"].ToString()!="")
				{
					model.OldPowerRating=decimal.Parse(ds.Tables[0].Rows[0]["OldPowerRating"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OldQty"]!=null && ds.Tables[0].Rows[0]["OldQty"].ToString()!="")
				{
					model.OldQty=int.Parse(ds.Tables[0].Rows[0]["OldQty"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OldSpeed"]!=null && ds.Tables[0].Rows[0]["OldSpeed"].ToString()!="")
				{
					model.OldSpeed=decimal.Parse(ds.Tables[0].Rows[0]["OldSpeed"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OldProtectionLev"]!=null && ds.Tables[0].Rows[0]["OldProtectionLev"].ToString()!="")
				{
					model.OldProtectionLev=ds.Tables[0].Rows[0]["OldProtectionLev"].ToString();
				}
				if(ds.Tables[0].Rows[0]["OldOutDate"]!=null && ds.Tables[0].Rows[0]["OldOutDate"].ToString()!="")
				{
					model.OldOutDate=DateTime.Parse(ds.Tables[0].Rows[0]["OldOutDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OldWeight"]!=null && ds.Tables[0].Rows[0]["OldWeight"].ToString()!="")
				{
					model.OldWeight=decimal.Parse(ds.Tables[0].Rows[0]["OldWeight"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OldPrice"]!=null && ds.Tables[0].Rows[0]["OldPrice"].ToString()!="")
				{
					model.OldPrice=decimal.Parse(ds.Tables[0].Rows[0]["OldPrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OldSubsidy"]!=null && ds.Tables[0].Rows[0]["OldSubsidy"].ToString()!="")
				{
					model.OldSubsidy=decimal.Parse(ds.Tables[0].Rows[0]["OldSubsidy"].ToString());
				}
				if(ds.Tables[0].Rows[0]["OldSumPrice"]!=null && ds.Tables[0].Rows[0]["OldSumPrice"].ToString()!="")
				{
					model.OldSumPrice=decimal.Parse(ds.Tables[0].Rows[0]["OldSumPrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TerminalUnit"]!=null && ds.Tables[0].Rows[0]["TerminalUnit"].ToString()!="")
				{
					model.TerminalUnit=ds.Tables[0].Rows[0]["TerminalUnit"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TUNo"]!=null && ds.Tables[0].Rows[0]["TUNo"].ToString()!="")
				{
					model.TUNo=ds.Tables[0].Rows[0]["TUNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["NewModel"]!=null && ds.Tables[0].Rows[0]["NewModel"].ToString()!="")
				{
					model.NewModel=ds.Tables[0].Rows[0]["NewModel"].ToString();
				}
				if(ds.Tables[0].Rows[0]["NewPowerRating"]!=null && ds.Tables[0].Rows[0]["NewPowerRating"].ToString()!="")
				{
					model.NewPowerRating=decimal.Parse(ds.Tables[0].Rows[0]["NewPowerRating"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NewQty"]!=null && ds.Tables[0].Rows[0]["NewQty"].ToString()!="")
				{
					model.NewQty=int.Parse(ds.Tables[0].Rows[0]["NewQty"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PurchasePrice"]!=null && ds.Tables[0].Rows[0]["PurchasePrice"].ToString()!="")
				{
					model.PurchasePrice=decimal.Parse(ds.Tables[0].Rows[0]["PurchasePrice"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Reconstruction"]!=null && ds.Tables[0].Rows[0]["Reconstruction"].ToString()!="")
				{
					model.Reconstruction=ds.Tables[0].Rows[0]["Reconstruction"].ToString();
				}
				if(ds.Tables[0].Rows[0]["NewInvoiceNo"]!=null && ds.Tables[0].Rows[0]["NewInvoiceNo"].ToString()!="")
				{
					model.NewInvoiceNo=ds.Tables[0].Rows[0]["NewInvoiceNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["NewInvoiceDate"]!=null && ds.Tables[0].Rows[0]["NewInvoiceDate"].ToString()!="")
				{
					model.NewInvoiceDate=DateTime.Parse(ds.Tables[0].Rows[0]["NewInvoiceDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NewMC"]!=null && ds.Tables[0].Rows[0]["NewMC"].ToString()!="")
				{
					model.NewMC=ds.Tables[0].Rows[0]["NewMC"].ToString();
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
			strSql.Append("select ID,OrgID,ContractNo,OldModel,OldPowerRating,OldQty,OldSpeed,OldProtectionLev,OldOutDate,OldWeight,OldPrice,OldSubsidy,OldSumPrice,TerminalUnit,TUNo,NewModel,NewPowerRating,NewQty,PurchasePrice,Reconstruction,NewInvoiceNo,NewInvoiceDate,NewMC,NewSerialNum,CreateUserID,CreateTime,UpdateUserID,UpdateTime,SubmitUserID,SubmitTime,ApproveUserID,ApproveTime ");
			strSql.Append(" FROM BS_NewForOld_Details ");
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
			strSql.Append(" ID,OrgID,ContractNo,OldModel,OldPowerRating,OldQty,OldSpeed,OldProtectionLev,OldOutDate,OldWeight,OldPrice,OldSubsidy,OldSumPrice,TerminalUnit,TUNo,NewModel,NewPowerRating,NewQty,PurchasePrice,Reconstruction,NewInvoiceNo,NewInvoiceDate,NewMC,NewSerialNum,CreateUserID,CreateTime,UpdateUserID,UpdateTime,SubmitUserID,SubmitTime,ApproveUserID,ApproveTime ");
			strSql.Append(" FROM BS_NewForOld_Details ");
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
			strSql.Append("select count(1) FROM BS_NewForOld_Details ");
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
			strSql.Append(")AS Row, T.*  from BS_NewForOld_Details T ");
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
			parameters[0].Value = "BS_NewForOld_Details";
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

