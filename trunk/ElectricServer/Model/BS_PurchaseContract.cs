using System;
namespace Electric.Model
{
	/// <summary>
	/// BS_PurchaseContract:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BS_PurchaseContract
	{
		public BS_PurchaseContract()
		{}
		#region Model
		private int _id;
		private string _orgcode;
		private string _contractno;
		private string _partnercode;
		private string _partnername;
		private string _partneraddress;
		private string _partnercontract;
		private string _partnertel;
		private string _partnerbank;
		private string _partneraccount;
		private string _partnertaxno;
		private int? _deliverytime;
		private decimal? _price;
		private string _words;
		private int? _fpp;
		private decimal? _fpr;
		private decimal? _spr;
		private int? _checkedlimit;
		private int? _lpp;
		private decimal? _lpr;
		private decimal? _damagesrate;
		private int? _createuserid;
		private DateTime? _createtime;
		private int? _updateuserid;
		private DateTime? _updatetime;
		private int? _submituserid;
		private DateTime? _submittime;
		private int? _approveuserid;
		private DateTime? _approvetime;
	    private string _bearcost;

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
		public string PartnerBank
		{
			set{ _partnerbank=value;}
			get{return _partnerbank;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PartnerAccount
		{
			set{ _partneraccount=value;}
			get{return _partneraccount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PartnerTaxNo
		{
			set{ _partnertaxno=value;}
			get{return _partnertaxno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? DeliveryTime
		{
			set{ _deliverytime=value;}
			get{return _deliverytime;}
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
		public string Words
		{
			set{ _words=value;}
			get{return _words;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FPP
		{
			set{ _fpp=value;}
			get{return _fpp;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? FPR
		{
			set{ _fpr=value;}
			get{return _fpr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? SPR
		{
			set{ _spr=value;}
			get{return _spr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CheckedLimit
		{
			set{ _checkedlimit=value;}
			get{return _checkedlimit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? LPP
		{
			set{ _lpp=value;}
			get{return _lpp;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? LPR
		{
			set{ _lpr=value;}
			get{return _lpr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? DamagesRate
		{
			set{ _damagesrate=value;}
			get{return _damagesrate;}
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
        /// <summary>
        /// 
        /// </summary>
        public string BearCost
        {
            set { _bearcost = value; }
            get { return _bearcost; }
        }
		#endregion Model

	}
}

