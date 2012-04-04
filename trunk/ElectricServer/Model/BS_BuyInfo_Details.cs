using System;
namespace Electric.Model
{
	/// <summary>
	/// BS_BuyInfo_Details:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BS_BuyInfo_Details
	{
		public BS_BuyInfo_Details()
		{}
		#region Model
		private int _id;
		private string _orgcode;
		private int? _contractno;
		private string _invoiceno;
		private DateTime? _invoicedate;
		private string _newmodel;
		private int? _newqty;
		private decimal? _newrating;
		private decimal? _newvoltage;
		private decimal? _newspeed;
		private string _newprotectionlev;
		private string _newmc;
		private decimal? _newweight;
		private decimal? _price;
		private string _terminalunit;
		private string _tuno;
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
		public int? ContractNo
		{
			set{ _contractno=value;}
			get{return _contractno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string InvoiceNo
		{
			set{ _invoiceno=value;}
			get{return _invoiceno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? InvoiceDate
		{
			set{ _invoicedate=value;}
			get{return _invoicedate;}
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
		public int? NewQty
		{
			set{ _newqty=value;}
			get{return _newqty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? NewRating
		{
			set{ _newrating=value;}
			get{return _newrating;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? NewVoltage
		{
			set{ _newvoltage=value;}
			get{return _newvoltage;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? NewSpeed
		{
			set{ _newspeed=value;}
			get{return _newspeed;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NewProtectionLev
		{
			set{ _newprotectionlev=value;}
			get{return _newprotectionlev;}
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
		public decimal? NewWeight
		{
			set{ _newweight=value;}
			get{return _newweight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Price
		{
			set{ _price=value;}
			get{return _price;}
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

