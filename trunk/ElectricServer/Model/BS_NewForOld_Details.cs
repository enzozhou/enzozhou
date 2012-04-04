using System;
namespace Electric.Model
{
	/// <summary>
	/// BS_NewForOld_Details:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BS_NewForOld_Details
	{
		public BS_NewForOld_Details()
		{}
		#region Model
		private int _id;
		private string _orgcode;
		private string _contractno;
		private string _oldmodel;
		private decimal? _oldpowerrating;
		private int? _oldqty;
		private decimal? _oldspeed;
		private string _oldprotectionlev;
		private DateTime? _oldoutdate;
		private decimal? _oldweight;
		private decimal? _oldprice;
		private decimal? _oldsubsidy;
		private decimal? _oldsumprice;
		private string _terminalunit;
		private string _tuno;
		private string _newmodel;
		private decimal? _newpowerrating;
		private int? _newqty;
		private decimal? _purchaseprice;
		private string _reconstruction;
		private string _newinvoiceno;
		private DateTime? _newinvoicedate;
		private string _newmc;
		private string _newserialnum;
		private int? _createuserid;
		private DateTime? _createtime;
		private int? _updateuserid;
		private DateTime? _updatetime;
		private int? _submituserid;
		private DateTime? _submittime;
		private int? _approveuserid;
		private DateTime? _approvetime;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OrgCode
		{
			set{ _orgcode=value;}
			get{return _orgcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ContractNo
		{
			set{ _contractno=value;}
			get{return _contractno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OldModel
		{
			set{ _oldmodel=value;}
			get{return _oldmodel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? OldPowerRating
		{
			set{ _oldpowerrating=value;}
			get{return _oldpowerrating;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? OldQty
		{
			set{ _oldqty=value;}
			get{return _oldqty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? OldSpeed
		{
			set{ _oldspeed=value;}
			get{return _oldspeed;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string OldProtectionLev
		{
			set{ _oldprotectionlev=value;}
			get{return _oldprotectionlev;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? OldOutDate
		{
			set{ _oldoutdate=value;}
			get{return _oldoutdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? OldWeight
		{
			set{ _oldweight=value;}
			get{return _oldweight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? OldPrice
		{
			set{ _oldprice=value;}
			get{return _oldprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? OldSubsidy
		{
			set{ _oldsubsidy=value;}
			get{return _oldsubsidy;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? OldSumPrice
		{
			set{ _oldsumprice=value;}
			get{return _oldsumprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TerminalUnit
		{
			set{ _terminalunit=value;}
			get{return _terminalunit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TUNo
		{
			set{ _tuno=value;}
			get{return _tuno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NewModel
		{
			set{ _newmodel=value;}
			get{return _newmodel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? NewPowerRating
		{
			set{ _newpowerrating=value;}
			get{return _newpowerrating;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? NewQty
		{
			set{ _newqty=value;}
			get{return _newqty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? PurchasePrice
		{
			set{ _purchaseprice=value;}
			get{return _purchaseprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Reconstruction
		{
			set{ _reconstruction=value;}
			get{return _reconstruction;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NewInvoiceNo
		{
			set{ _newinvoiceno=value;}
			get{return _newinvoiceno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? NewInvoiceDate
		{
			set{ _newinvoicedate=value;}
			get{return _newinvoicedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NewMC
		{
			set{ _newmc=value;}
			get{return _newmc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NewSerialNum
		{
			set{ _newserialnum=value;}
			get{return _newserialnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CreateUserID
		{
			set{ _createuserid=value;}
			get{return _createuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CreateTime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UpdateUserID
		{
			set{ _updateuserid=value;}
			get{return _updateuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SubmitUserID
		{
			set{ _submituserid=value;}
			get{return _submituserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? SubmitTime
		{
			set{ _submittime=value;}
			get{return _submittime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ApproveUserID
		{
			set{ _approveuserid=value;}
			get{return _approveuserid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ApproveTime
		{
			set{ _approvetime=value;}
			get{return _approvetime;}
		}
		#endregion Model

	}
}

