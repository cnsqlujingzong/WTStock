using System;

namespace wt.Model
{
	public class ServicesDeviceConfInfo
	{
		private int _id;

		private int _billid;

		private string __name;

		private string _parameter;

		private string _sn;

		private string _maintenanceperiod;

		private string _buydate;

		private string _maintenanceend;

		private string _remark;

		private int _devconfid;

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

		public int BillID
		{
			get
			{
				return this._billid;
			}
			set
			{
				this._billid = value;
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

		public int DevConfID
		{
			get
			{
				return this._devconfid;
			}
			set
			{
				this._devconfid = value;
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

		public ServicesDeviceConfInfo()
		{
		}
	}
}