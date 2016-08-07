using System;
namespace Coding.Stock.Model
{
	/// <summary>
	/// Cd_ProTypeAttr:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Cd_ProTypeAttr
	{
		public Cd_ProTypeAttr()
		{}
		#region Model
		private int _id;
		private int _protypeid;
		private string _attname;
		private string _displayattrname;
		private int _orderby;
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
		public int ProTypeID
		{
			set{ _protypeid=value;}
			get{return _protypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AttName
		{
			set{ _attname=value;}
			get{return _attname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DisplayAttrName
		{
			set{ _displayattrname=value;}
			get{return _displayattrname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Orderby
		{
			set{ _orderby=value;}
			get{return _orderby;}
		}
		#endregion Model

	}
}

