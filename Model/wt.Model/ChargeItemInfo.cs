using System;

namespace wt.Model
{
	[Serializable]
	public class ChargeItemInfo
	{
		private int _id;

		private int? _deptid;

		private string __name;

		private int? _type;

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

		public int? Type
		{
			get
			{
				return this._type;
			}
			set
			{
				this._type = value;
			}
		}

		public ChargeItemInfo()
		{
		}
	}
}