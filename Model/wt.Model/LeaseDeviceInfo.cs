using System;

namespace wt.Model
{
	public class LeaseDeviceInfo
	{
		private int _id;

		private int _billid;

		private int _stockid;

		private int _goodsid;

		private int _deviceid;

		private int _brandid;

		private int _classid;

		private int _modelid;

		private string _deviceno;

		private string _productsn1;

		private string _productsn2;

		private string _strqty;

		private decimal _outprice;

		private decimal _inprice;

		private string _remark;

		private string _status;

		private int _icount;

		private decimal _leaseprice;

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

		public int BrandID
		{
			get
			{
				return this._brandid;
			}
			set
			{
				this._brandid = value;
			}
		}

		public int ClassID
		{
			get
			{
				return this._classid;
			}
			set
			{
				this._classid = value;
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

		public string DeviceNO
		{
			get
			{
				return this._deviceno;
			}
			set
			{
				this._deviceno = value;
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

		public int iCount
		{
			get
			{
				return this._icount;
			}
			set
			{
				this._icount = value;
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

		public decimal InPrice
		{
			get
			{
				return this._inprice;
			}
			set
			{
				this._inprice = value;
			}
		}

		public decimal LeasePrice
		{
			get
			{
				return this._leaseprice;
			}
			set
			{
				this._leaseprice = value;
			}
		}

		public int ModelID
		{
			get
			{
				return this._modelid;
			}
			set
			{
				this._modelid = value;
			}
		}

		public decimal OutPrice
		{
			get
			{
				return this._outprice;
			}
			set
			{
				this._outprice = value;
			}
		}

		public string ProductSN1
		{
			get
			{
				return this._productsn1;
			}
			set
			{
				this._productsn1 = value;
			}
		}

		public string ProductSN2
		{
			get
			{
				return this._productsn2;
			}
			set
			{
				this._productsn2 = value;
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

		public string Status
		{
			get
			{
				return this._status;
			}
			set
			{
				this._status = value;
			}
		}

		public int StockID
		{
			get
			{
				return this._stockid;
			}
			set
			{
				this._stockid = value;
			}
		}

		public string StrQty
		{
			get
			{
				return this._strqty;
			}
			set
			{
				this._strqty = value;
			}
		}

		public LeaseDeviceInfo()
		{
		}
	}
}