using System;
namespace Coding.Stock.Model
{
	/// <summary>
	/// Cd_productType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Cd_productType
	{
		public Cd_productType()
		{}
		#region Model
		private int _id;
		private string _typename;
		private string _desc;
		private string _common;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TypeName
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Desc
		{
			set{ _desc=value;}
			get{return _desc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Common
		{
			set{ _common=value;}
			get{return _common;}
		}
		#endregion Model

	}
}

