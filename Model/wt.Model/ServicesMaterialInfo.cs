using System;

namespace wt.Model
{
	public class ServicesMaterialInfo
	{
		private int _id;

		private string _chargestyle;

		private string _remark;

		private int _billid;

		private int _goodsid;

		private int _unitid;

		private decimal _qty;

		private decimal _price;

		private decimal _total;

		private string _maintenanceperiod;

		private string _periodenddate;

		private string _sn;

		private bool _outsourcing;

		private decimal _costprice;

		private decimal _taxrate;

		private decimal _taxamount;

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

		public string ChargeStyle
		{
			get
			{
				return this._chargestyle;
			}
			set
			{
				this._chargestyle = value;
			}
		}

		public decimal CostPrice
		{
			get
			{
				return this._costprice;
			}
			set
			{
				this._costprice = value;
			}
		}

		public int GoodsID
		{
			get
			{
				return this._goodsid;
			}
			set
			{
				this._goodsid = value;
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

		public bool OutSourcing
		{
			get
			{
				return this._outsourcing;
			}
			set
			{
				this._outsourcing = value;
			}
		}

		public string PeriodEndDate
		{
			get
			{
				return this._periodenddate;
			}
			set
			{
				this._periodenddate = value;
			}
		}

		public decimal Price
		{
			get
			{
				return this._price;
			}
			set
			{
				this._price = value;
			}
		}

		public decimal Qty
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

		public decimal TaxAmount
		{
			get
			{
				return this._taxamount;
			}
			set
			{
				this._taxamount = value;
			}
		}

		public decimal TaxRate
		{
			get
			{
				return this._taxrate;
			}
			set
			{
				this._taxrate = value;
			}
		}

		public decimal Total
		{
			get
			{
				return this._total;
			}
			set
			{
				this._total = value;
			}
		}

		public int UnitID
		{
			get
			{
				return this._unitid;
			}
			set
			{
				this._unitid = value;
			}
		}

		public ServicesMaterialInfo()
		{
		}
	}
}