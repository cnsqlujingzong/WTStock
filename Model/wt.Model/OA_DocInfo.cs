using System;

namespace wt.Model
{
	[Serializable]
	public class OA_DocInfo
	{
		private int _id;

		private int? _deptid;

		private int? _classid;

		private string __date;

		private int? _authorid;

		private string _title;

		private int? _filesize;

		private string _filename;

		private string _filepath;

		private int? _hit;

		public string _Date
		{
			get
			{
				return this.__date;
			}
			set
			{
				this.__date = value;
			}
		}

		public int? AuthorID
		{
			get
			{
				return this._authorid;
			}
			set
			{
				this._authorid = value;
			}
		}

		public int? ClassID
		{
			get
			{
				return this._classid;
			}
			set
			{
				this._classid = value;
			}
		}

		public int? DeptID
		{
			get
			{
				return this._deptid;
			}
			set
			{
				this._deptid = value;
			}
		}

		public string FileName
		{
			get
			{
				return this._filename;
			}
			set
			{
				this._filename = value;
			}
		}

		public string FilePath
		{
			get
			{
				return this._filepath;
			}
			set
			{
				this._filepath = value;
			}
		}

		public int? FileSize
		{
			get
			{
				return this._filesize;
			}
			set
			{
				this._filesize = value;
			}
		}

		public int? Hit
		{
			get
			{
				return this._hit;
			}
			set
			{
				this._hit = value;
			}
		}

		public int ID
		{
			get
			{
				return this._id;
			}
			set
			{
				this._id = value;
			}
		}

		public string Title
		{
			get
			{
				return this._title;
			}
			set
			{
				this._title = value;
			}
		}

		public OA_DocInfo()
		{
		}
	}
}