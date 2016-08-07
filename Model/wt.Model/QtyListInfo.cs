using System;

namespace wt.Model
{
	public class QtyListInfo
	{
		private int _id;

		private int _billid;

		private int _deviceid;

		private string _sn;

		private DateTime __date;

		private int _operatorid;

		private string _qtytype;

		private int _qty;

		private string _remark;

		private string _allowance;

		public DateTime _Date
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

		public string Allowance
		{
			get
			{
				return this._allowance;
			}
			set
			{
				this._allowance = value;
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

		public string QtyType
		{
			get
			{
				return this._qtytype;
			}
			set
			{
				this._qtytype = value;
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

		public QtyListInfo()
		{
		}
	}
}