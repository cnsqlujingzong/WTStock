using System;

namespace wt.Model
{
	[Serializable]
	public class DeviceConfItemInfo
	{
		private int _id;

		private int? _deptid;

		private int _productclassid;

		private string __name;

		private string _parameter;

		private string _maintenanceperiod;

		private string _remark;

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

		public string MaintenancePeriod
		{
			get
			{
				return this._maintenanceperiod;
			}
			set
			{
				this._maintenanceperiod = value;
			}
		}

		public string Parameter
		{
			get
			{
				return this._parameter;
			}
			set
			{
				this._parameter = value;
			}
		}

		public int ProductClassID
		{
			get
			{
				return this._productclassid;
			}
			set
			{
				this._productclassid = value;
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

		public DeviceConfItemInfo()
		{
		}
	}
}