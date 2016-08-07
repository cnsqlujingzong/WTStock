using System;

namespace wt.Model
{
	public class SaleContractDetailInfo
	{
		private int _id;

		private int _contractID;

		private int _stockID;

		private int _goodsID;

		private int _unitID;

		private decimal _qty;

		private decimal _sellQty;

		private decimal _price;

		private decimal _dis;

		private decimal _total;

		private string _remark;

		private decimal _taxRate;

		private decimal _taxAmount;

		private decimal _goodsAmount;

		private decimal _quotety;

		private string _mainTenancePeriod;

		private string _spec;

		private string _productBrand;

		public int ContractID
		{
			get
			{
				return this._contractID;
			}
			set
			{
				this._contractID = value;
			}
		}

		public decimal Dis
		{
			get
			{
				return this._dis;
			}
			set
			{
				this._dis = value;
			}
		}

		public decimal GoodsAmount
		{
			get
			{
				return this._goodsAmount;
			}
			set
			{
				this._goodsAmount = value;
			}
		}

		public int GoodsID
		{
			get
			{
				return this._goodsID;
			}
			set
			{
				this._goodsID = value;
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

		public string MainTenancePeriod
		{
			get
			{
				return this._mainTenancePeriod;
			}
			set
			{
				this._mainTenancePeriod = value;
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

		public string ProductBrand
		{
			get
			{
				return this._productBrand;
			}
			set
			{
				this._productBrand = value;
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

		public decimal Quotety
		{
			get
			{
				return this._quotety;
			}
			set
			{
				this._quotety = value;
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

		public decimal SellQty
		{
			get
			{
				return this._sellQty;
			}
			set
			{
				this._sellQty = value;
			}
		}

		public string Spec
		{
			get
			{
				return this._spec;
			}
			set
			{
				this._spec = value;
			}
		}

		public int StockID
		{
			get
			{
				return this._stockID;
			}
			set
			{
				this._stockID = value;
			}
		}

		public decimal TaxAmount
		{
			get
			{
				return this._taxAmount;
			}
			set
			{
				this._taxAmount = value;
			}
		}

		public decimal TaxRate
		{
			get
			{
				return this._taxRate;
			}
			set
			{
				this._taxRate = value;
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
				return this._unitID;
			}
			set
			{
				this._unitID = value;
			}
		}

		public SaleContractDetailInfo()
		{
		}
	}
}