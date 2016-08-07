using System;

namespace wt.Model
{
	[Serializable]
	public class DeviceConfigInfo
	{
		private int _id;

		private int _deviceid;

		private string __name;

		private string _parameter;

		private string _sn;

		private string _maintenanceperiod;

		private string _buydate;

		private string _maintenanceend;

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

		public string BuyDate
		{
			get
			{
				return this._buydate;
			}
			set
			{
				this._buydate = value;
			}
		}

		public int DeviceID
		{
			get
			{
				return this._deviceid;
			}
			set
			{
				this._deviceid = value;
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

		public string MaintenanceEnd
		{
			get
			{
				return this._maintenanceend;
			}
			set
			{
				this._maintenanceend = value;
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

		public string SN
		{
			get
			{
				return this._sn;
			}
			set
			{
				this._sn = value;
			}
		}

		public DeviceConfigInfo()
		{
		}
	}
}