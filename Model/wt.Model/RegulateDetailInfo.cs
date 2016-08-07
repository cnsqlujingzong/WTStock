using System;

namespace wt.Model
{
	public class RegulateDetailInfo
	{
		private int _id;

		private int _billid;

		private int _goodsid;

		private decimal _qty;

		private decimal _price;

		private decimal _total;

		private decimal _regulateprice;

		private decimal _regulatetotal;

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

		public decimal RegulatePrice
		{
			get
			{
				return this._regulateprice;
			}
			set
			{
				this._regulateprice = value;
			}
		}

		public decimal RegulateTotal
		{
			get
			{
				return this._regulatetotal;
			}
			set
			{
				this._regulatetotal = value;
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

		public RegulateDetailInfo()
		{
		}
	}
}