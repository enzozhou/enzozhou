using System;
namespace Electric.Model
{
	/// <summary>
	/// BS_BuyInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BS_BuyInfo
	{
		public BS_BuyInfo()
		{}
		#region Model
		private int _id;
		private int? _orgid;
		private string _contractno;
		private string _partnercode;
		private string _partnername;
		private string _belongto;
		private string _ownership;
		private string _partneraddress;
		private string _partnercontract;
		private string _partnertel;
		private DateTime? _buytime;
		private decimal? _totalnewqty;
		private decimal? _totalnewpowerrating;
		private decimal? _totalweight;
		private decimal? _totalpurchaseprice;
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
		public int? OrgID
		{
			set{ _orgid=value;}
			get{return _orgid;}
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
		public string PartnerCode
		{
			set{ _partnercode=value;}
			get{return _partnercode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PartnerName
		{
			set{ _partnername=value;}
			get{return _partnername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BelongTo
		{
			set{ _belongto=value;}
			get{return _belongto;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Ownership
		{
			set{ _ownership=value;}
			get{return _ownership;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PartnerAddress
		{
			set{ _partneraddress=value;}
			get{return _partneraddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PartnerContract
		{
			set{ _partnercontract=value;}
			get{return _partnercontract;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PartnerTel
		{
			set{ _partnertel=value;}
			get{return _partnertel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? BuyTime
		{
			set{ _buytime=value;}
			get{return _buytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TotalNewQty
		{
			set{ _totalnewqty=value;}
			get{return _totalnewqty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TotalNewPowerRating
		{
			set{ _totalnewpowerrating=value;}
			get{return _totalnewpowerrating;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TotalWeight
		{
			set{ _totalweight=value;}
			get{return _totalweight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? TotalPurchasePrice
		{
			set{ _totalpurchaseprice=value;}
			get{return _totalpurchaseprice;}
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

