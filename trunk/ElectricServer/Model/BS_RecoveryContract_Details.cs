using System;
namespace Electric.Model
{
	/// <summary>
	/// BS_RecoveryContract_Details:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BS_RecoveryContract_Details
	{
		public BS_RecoveryContract_Details()
		{}
		#region Model
		private int _id;
		private string _model;
		private int? _qty;
		private decimal? _powerrating;
		private decimal? _unitprice;
		private decimal? _price;
		private decimal? _buypower;
		private decimal? _subsidy;
		private decimal? _sumprice;
		private int? _orgid;
		private string _contractno;
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
		public string Model
		{
			set{ _model=value;}
			get{return _model;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Qty
		{
			set{ _qty=value;}
			get{return _qty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? PowerRating
		{
			set{ _powerrating=value;}
			get{return _powerrating;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? UnitPrice
		{
			set{ _unitprice=value;}
			get{return _unitprice;}
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
		public decimal? BuyPower
		{
			set{ _buypower=value;}
			get{return _buypower;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Subsidy
		{
			set{ _subsidy=value;}
			get{return _subsidy;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? SumPrice
		{
			set{ _sumprice=value;}
			get{return _sumprice;}
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

