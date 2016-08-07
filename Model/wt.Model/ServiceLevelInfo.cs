using System;

namespace wt.Model
{
	public class ServiceLevelInfo
	{
		private int _id;

		private string __name;

		private int _responsetime;

		private int _repairtime;

		private string _remark;

		private int _number;

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

		public int Number
		{
			get
			{
				return this._number;
			}
			set
			{
				this._number = value;
			}
		}

		public string Remark
		{
			get
			{
				return this._remark;
			}
			set
			{
				this._remark = value;
			}
		}

		public int RepairTime
		{
			get
			{
				return this._repairtime;
			}
			set
			{
				this._repairtime = value;
			}
		}

		public int ResponseTime
		{
			get
			{
				return this._responsetime;
			}
			set
			{
				this._responsetime = value;
			}
		}

		public ServiceLevelInfo()
		{
		}
	}
}