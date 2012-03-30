using System;
namespace Electric.Model
{
	/// <summary>
	/// BAS_Organization:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BAS_Organization
	{
		public BAS_Organization()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _name;
		private string _membership;
		private string _enterprisenature;
		private string _texno;
		private string _address;
		private string _website;
		private string _bankname;
		private string _bankclass;
		private string _account;
		private int? _rowstatus;
		private int? _createuserid;
		private DateTime? _createtime;
		private int? _updateuserid;
		private DateTime? _updatetime;
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
		public string Membership
		{
			set{ _membership=value;}
			get{return _membership;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EnterpriseNature
		{
			set{ _enterprisenature=value;}
			get{return _enterprisenature;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TexNo
		{
			set{ _texno=value;}
			get{return _texno;}
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
		public string WebSite
		{
			set{ _website=value;}
			get{return _website;}
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
		public int? RowStatus
		{
			set{ _rowstatus=value;}
			get{return _rowstatus;}
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
		#endregion Model

	}
}

