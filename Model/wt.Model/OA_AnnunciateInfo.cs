using System;

namespace wt.Model
{
	[Serializable]
	public class OA_AnnunciateInfo
	{
		private int _id;

		private int? _deptid;

		private string __date;

		private int? _authorid;

		private string _title;

		private string _content;

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

		public string Content
		{
			get
			{
				return this._content;
			}
			set
			{
				this._content = value;
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

		public OA_AnnunciateInfo()
		{
		}
	}
}