using System;
namespace Coding.Stock.Model
{
	/// <summary>
	/// Cd_UserInt:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Cd_UserInt
	{
		public Cd_UserInt()
		{}
		#region Model
		private int _id;
		private int _userid;
		private string _inttype;
		private decimal? _intqty;
		private DateTime? _datetime;
		private string _upuser;
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
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IntType
		{
			set{ _inttype=value;}
			get{return _inttype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? IntQty
		{
			set{ _intqty=value;}
			get{return _intqty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? Datetime
		{
			set{ _datetime=value;}
			get{return _datetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UpUser
		{
			set{ _upuser=value;}
			get{return _upuser;}
		}
		#endregion Model

	}
}

