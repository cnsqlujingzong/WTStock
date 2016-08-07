using System;

namespace wt.Model
{
	public class StockCheckDetailInfo
	{
		private int _id;

		private int _billid;

		private int _goodsid;

		private int _stocklocid;

		private decimal _stock;

		private decimal _qty;

		private string _remark;

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

		public decimal Stock
		{
			get
			{
				return this._stock;
			}
			set
			{
				this._stock = value;
			}
		}

		public int StockLocID
		{
			get
			{
				return this._stocklocid;
			}
			set
			{
				this._stocklocid = value;
			}
		}

		public StockCheckDetailInfo()
		{
		}
	}
}