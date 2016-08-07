using System;

namespace wt.Model
{
	public class MeterReadingInfo
	{
		private int _id;

		private int _billid;

		private int _deviceid;

		private string __date;

		private int _operatorid;

		private int _qty;

		private string _remark;

		private int _loss;

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

		public int Loss
		{
			get
			{
				return this._loss;
			}
			set
			{
				this._loss = value;
			}
		}

		public int OperatorID
		{
			get
			{
				return this._operatorid;
			}
			set
			{
				this._operatorid = value;
			}
		}

		public int Qty
		{
			get
			{
				return this._qty;
			}
			set
			{
				this._qty = value;
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

		public MeterReadingInfo()
		{
		}
	}
}