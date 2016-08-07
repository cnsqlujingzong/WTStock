using System;

namespace wt.Model
{
	public class PurchaseDetailInfo
	{
		private int _id;

		private int _billid;

		private int _goodsid;

		private int _unitid;

		private decimal _qty;

		private decimal _price;

		private decimal? _total;

		private string _remark;

		private string _sn;

		private decimal _taxrate;

		private decimal _taxamount;

		private decimal _goodsamount;

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

		public decimal GoodsAmount
		{
			get
			{
				return this._goodsamount;
			}
			set
			{
				this._goodsamount = value;
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

		public decimal? Total
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

		public PurchaseDetailInfo()
		{
		}
	}
}