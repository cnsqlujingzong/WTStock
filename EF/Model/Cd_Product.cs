using System;
namespace Coding.Stock.Model
{
	/// <summary>
	/// Cd_Product:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Cd_Product
	{
		public Cd_Product()
		{}
		#region Model
		private int _id;
		private string _proname;
		private string _proseri;
		private string _promodel;
		private string _prodescribe;
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
		public string ProName
		{
			set{ _proname=value;}
			get{return _proname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProSeri
		{
			set{ _proseri=value;}
			get{return _proseri;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProModel
		{
			set{ _promodel=value;}
			get{return _promodel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProDescribe
		{
			set{ _prodescribe=value;}
			get{return _prodescribe;}
		}
		#endregion Model

	}
}

