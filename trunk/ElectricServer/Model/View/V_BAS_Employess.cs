using System;
namespace Electric.Model
{
	/// <summary>
	/// BAS_Employess:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class V_BAS_Employess
	{
		public V_BAS_Employess()
		{}
		#region Model
		private int _id;
		private int? _orgid;
		private string _code;
		private string _name;
		private int? _gender;
	    private string _gendername;
		private string _tel;
		private string _email;
		private string _fax;
		private string _mobile;
		private string _deparment;
	    private string _dptname;
		private int? _createuserid;
	    private string _createusername;
		private DateTime? _createtime;
		private int? _updateuserid;
	    private string _updateusername;
		private DateTime? _updatetime;
		private int? _canceluserid;
	    private string _cancelusername;
		private DateTime? _canceltime;
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
		public int? Gender
		{
			set{ _gender=value;}
			get{return _gender;}
        }
        /// <summary>
        /// 
        /// </summary>
        public string GenderName
        {
            set { _gendername = value; }
            get { return _gendername; }
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
		public string Fax
		{
			set{ _fax=value;}
			get{return _fax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Deparment
		{
			set{ _deparment=value;}
			get{return _deparment;}
        }
        /// <summary>
        /// 
        /// </summary>
        public string DptName
        {
            set { _dptname = value; }
            get { return _dptname; }
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
        public string CreateUserName
        {
            set { _createusername = value; }
            get { return _createusername; }
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
        public string UpdateUserName
        {
            set { _updateusername = value; }
            get { return _updateusername; }
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
		public int? CancelUserID
		{
			set{ _canceluserid=value;}
			get{return _canceluserid;}
        }
        /// <summary>
        /// 
        /// </summary>
        public string CancelUserName
        {
            set { _cancelusername = value; }
            get { return _cancelusername; }
        }
		/// <summary>
		/// 
		/// </summary>
		public DateTime? CancelTime
		{
			set{ _canceltime=value;}
			get{return _canceltime;}
		}
		#endregion Model

	}
}

