using System;
namespace Electric.Model
{
	/// <summary>
	/// BAS_CodeProfire:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class BAS_CodeProfire
	{
		public BAS_CodeProfire()
		{}
		#region Model
		private int _id;
		private string _selectcode;
		private string _description;
		private int? _seq;
		private string _codetype;
		private string _remarks;
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
		public string SelectCode
		{
			set{ _selectcode=value;}
			get{return _selectcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SEQ
		{
			set{ _seq=value;}
			get{return _seq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CodeType
		{
			set{ _codetype=value;}
			get{return _codetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remarks
		{
			set{ _remarks=value;}
			get{return _remarks;}
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

