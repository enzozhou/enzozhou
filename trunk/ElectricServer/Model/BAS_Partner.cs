using System;
namespace Electric.Model
{
	/// <summary>
	/// BAS_Partner:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BAS_Partner
	{
		public BAS_Partner()
		{}
		#region Model
		private int _id;
		private string _orgcodesys;
		private string _code;
		private string _name;
		private string _partnerclass;
		private string _address;
		private string _corporate;
		private string _orgcode;
		private string _licence;
		private string _taxno;
		private string _ownership;
		private decimal? _registeredcapital;
		private string _supervisor;
		private decimal? _fixedassets;
		private int? _enterprisenum;
		private string _contract;
		private string _tel;
		private string _email;
		private string _etc;
		private decimal? _lysv;
		private decimal? _yblsv;
		private string _bankname;
		private string _bankclass;
		private string _account;
		private int? _createuserid;
		private DateTime? _createtime;
		private int? _updateuserid;
		private DateTime? _updatetime;
		private int? _submituserid;
		private DateTime? _submittime;
		private int? _approveuserid;
		private DateTime? _approvetime;
	    private string _membership;
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
		public string OrgCodeSYS
		{
			set{ _orgcodesys=value;}
			get{return _orgcodesys;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PartnerClass
		{
			set{ _partnerclass=value;}
			get{return _partnerclass;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Corporate
		{
			set{ _corporate=value;}
			get{return _corporate;}
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
		public string Licence
		{
			set{ _licence=value;}
			get{return _licence;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TaxNo
		{
			set{ _taxno=value;}
			get{return _taxno;}
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
		public decimal? RegisteredCapital
		{
			set{ _registeredcapital=value;}
			get{return _registeredcapital;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Supervisor
		{
			set{ _supervisor=value;}
			get{return _supervisor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? FixedAssets
		{
			set{ _fixedassets=value;}
			get{return _fixedassets;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EnterpriseNum
		{
			set{ _enterprisenum=value;}
			get{return _enterprisenum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Contract
		{
			set{ _contract=value;}
			get{return _contract;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ETC
		{
			set{ _etc=value;}
			get{return _etc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? LYSV
		{
			set{ _lysv=value;}
			get{return _lysv;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? YBLSV
		{
			set{ _yblsv=value;}
			get{return _yblsv;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BankName
		{
			set{ _bankname=value;}
			get{return _bankname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string BankClass
		{
			set{ _bankclass=value;}
			get{return _bankclass;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Account
		{
			set{ _account=value;}
			get{return _account;}
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
        public string Membership
        {
            set { _membership = value; }
            get { return _membership; }
        }


		#endregion Model

	}
}

