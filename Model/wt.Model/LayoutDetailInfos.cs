using System;

namespace wt.Model
{
	public class LayoutDetailInfos
	{
		private int _id;

		private int _deptid;

		private int _classid;

		private int _winname;

		private string _titlename;

		private string _fieldname;

		private int __order;

		private bool _bshow;

		public int _Order
		{
			get
			{
				return this.__order;
			}
			set
			{
				this.__order = value;
			}
		}

		public bool bShow
		{
			get
			{
				return this._bshow;
			}
			set
			{
				this._bshow = value;
			}
		}

		public int ClassID
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

		public int DeptID
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

		public string FieldName
		{
			get
			{
				return this._fieldname;
			}
			set
			{
				this._fieldname = value;
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

		public string TitleName
		{
			get
			{
				return this._titlename;
			}
			set
			{
				this._titlename = value;
			}
		}

		public int WinName
		{
			get
			{
				return this._winname;
			}
			set
			{
				this._winname = value;
			}
		}

		public LayoutDetailInfos()
		{
		}
	}
}