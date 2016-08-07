using System;

namespace wt.Model
{
	public class LeaseChargeDetailInfo
	{
		private int _id;

		private int _billid;

		private int _deviceid;

		private int _qtytypeid;

		private int _benqty;

		private int _shangqty;

		private int _lossqty;

		private int _zhangqty;

		private int _rated;

		private decimal _supperzhangfee;

		private decimal _zsupperzhangfee;

		private string _chargedate;

		public int BenQty
		{
			get
			{
				return this._benqty;
			}
			set
			{
				this._benqty = value;
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

		public string ChargeDate
		{
			get
			{
				return this._chargedate;
			}
			set
			{
				this._chargedate = value;
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

		public int LossQty
		{
			get
			{
				return this._lossqty;
			}
			set
			{
				this._lossqty = value;
			}
		}

		public int QtyTypeID
		{
			get
			{
				return this._qtytypeid;
			}
			set
			{
				this._qtytypeid = value;
			}
		}

		public int Rated
		{
			get
			{
				return this._rated;
			}
			set
			{
				this._rated = value;
			}
		}

		public int ShangQty
		{
			get
			{
				return this._shangqty;
			}
			set
			{
				this._shangqty = value;
			}
		}

		public decimal SupperZhangFee
		{
			get
			{
				return this._supperzhangfee;
			}
			set
			{
				this._supperzhangfee = value;
			}
		}

		public int ZhangQty
		{
			get
			{
				return this._zhangqty;
			}
			set
			{
				this._zhangqty = value;
			}
		}

		public decimal ZSupperZhangFee
		{
			get
			{
				return this._zsupperzhangfee;
			}
			set
			{
				this._zsupperzhangfee = value;
			}
		}

		public LeaseChargeDetailInfo()
		{
		}
	}
}