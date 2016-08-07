using System;
using System.Collections.Generic;

namespace wt.Model
{
	public class RightInfo
	{
		private int _id;

		private int _deptid;

		private string __name;

		private bool _bdefault;

		private List<RightDetailInfo> _rightdetailinfo;

		public string _Name
		{
			get
			{
				return this.__name;
			}
			set
			{
				this.__name = value;
			}
		}

		public bool bDefault
		{
			get
			{
				return this._bdefault;
			}
			set
			{
				this._bdefault = value;
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

		public List<RightDetailInfo> RightDetailInfos
		{
			get
			{
				return this._rightdetailinfo;
			}
			set
			{
				this._rightdetailinfo = value;
			}
		}

		public RightInfo()
		{
		}
	}
}