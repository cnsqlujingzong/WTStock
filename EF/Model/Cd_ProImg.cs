using System;
namespace Coding.Stock.Model
{
	/// <summary>
	/// Cd_ProImg:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Cd_ProImg
	{
		public Cd_ProImg()
		{}
		#region Model
		private int _id;
		private int? _proid;
		private string _imgname;
		private string _imgsrc;
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
		public int? ProID
		{
			set{ _proid=value;}
			get{return _proid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ImgName
		{
			set{ _imgname=value;}
			get{return _imgname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ImgSrc
		{
			set{ _imgsrc=value;}
			get{return _imgsrc;}
		}
		#endregion Model

	}
}

