using System;
namespace Coding.Stock.Model
{
	/// <summary>
	/// Cd_ProductFiles:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Cd_ProductFiles
	{
		public Cd_ProductFiles()
		{}
		#region Model
		private int _id;
		private int? _proid;
		private string _filename;
		private string _filesrc;
		private byte[] _filetype;
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
		public string FileName
		{
			set{ _filename=value;}
			get{return _filename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FileSrc
		{
			set{ _filesrc=value;}
			get{return _filesrc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] FileType
		{
			set{ _filetype=value;}
			get{return _filetype;}
		}
		#endregion Model

	}
}

