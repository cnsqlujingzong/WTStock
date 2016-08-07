using System;
using System.Collections.Generic;

namespace wt.Model
{
	public class GoodsInfo
	{
		private int _id;

		private string _maintenanceperiod;

		private int? _stockid;

		private int? _provid;

		private bool _bstock;

		private int _costmode;

		private int? _valid;

		private bool _bincrement;

		private bool _bstop;

		private string _pycode;

		private string _remark;

		private string _goodsno;

		private string __name;

		private int? _classid;

		private string _class;

		private string _spec;

		private int? _brandid;

		private string _picpath;

		private string _forproducts;

		private string _attr;

		private decimal? _pricewholesale1;

		private decimal? _pricewholesale2;

		private decimal? _pricewholesale3;

		private int? _unitid;

		private string _barcode;

		private decimal? _pricedetail;

		private decimal? _pricecost;

		private decimal? _priceinner;

		private int? _goodsunitid;

		private bool _bsntrack;

		private string _userdef1;

		private string _userdef2;

		private string _userdef3;

		private string _userdef4;

		private string _userdef5;

		private string _userdef6;

		private string _suppliername;

		private decimal _lowprice;
        private string _PCB;

        public string PCB
        {
            get { return _PCB; }
            set { _PCB = value; }
        }

		private List<GoodsUnitInfo> _goodsunitinfos;

		private List<DisMountingInfo> _dismountinginfos;

		private List<StockInfo> _stockinfos;

		private List<StockDeptInfo> _stockdeptinfos;

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

		public string Attr
		{
			get
			{
				return this._attr;
			}
			set
			{
				this._attr = value;
			}
		}

		public string BarCode
		{
			get
			{
				return this._barcode;
			}
			set
			{
				this._barcode = value;
			}
		}

		public bool bIncrement
		{
			get
			{
				return this._bincrement;
			}
			set
			{
				this._bincrement = value;
			}
		}

		public int? BrandID
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

		public bool bSNTrack
		{
			get
			{
				return this._bsntrack;
			}
			set
			{
				this._bsntrack = value;
			}
		}

		public bool bStock
		{
			get
			{
				return this._bstock;
			}
			set
			{
				this._bstock = value;
			}
		}

		public bool bStop
		{
			get
			{
				return this._bstop;
			}
			set
			{
				this._bstop = value;
			}
		}

		public string Class
		{
			get
			{
				return this._class;
			}
			set
			{
				this._class = value;
			}
		}

		public int? ClassID
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

		public int CostMode
		{
			get
			{
				return this._costmode;
			}
			set
			{
				this._costmode = value;
			}
		}

		public List<DisMountingInfo> DisMountingInfos
		{
			get
			{
				return this._dismountinginfos;
			}
			set
			{
				this._dismountinginfos = value;
			}
		}

		public string ForProducts
		{
			get
			{
				return this._forproducts;
			}
			set
			{
				this._forproducts = value;
			}
		}

		public string GoodsNO
		{
			get
			{
				return this._goodsno;
			}
			set
			{
				this._goodsno = value;
			}
		}

		public int? GoodsUnitID
		{
			get
			{
				return this._goodsunitid;
			}
			set
			{
				this._goodsunitid = value;
			}
		}

		public List<GoodsUnitInfo> GoodsUnitInfos
		{
			get
			{
				return this._goodsunitinfos;
			}
			set
			{
				this._goodsunitinfos = value;
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

		public decimal LowPrice
		{
			get
			{
				return this._lowprice;
			}
			set
			{
				this._lowprice = value;
			}
		}

		public string MainTenancePeriod
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

		public string PicPath
		{
			get
			{
				return this._picpath;
			}
			set
			{
				this._picpath = value;
			}
		}

		public decimal? PriceCost
		{
			get
			{
				return this._pricecost;
			}
			set
			{
				this._pricecost = value;
			}
		}

		public decimal? PriceDetail
		{
			get
			{
				return this._pricedetail;
			}
			set
			{
				this._pricedetail = value;
			}
		}

		public decimal? PriceInner
		{
			get
			{
				return this._priceinner;
			}
			set
			{
				this._priceinner = value;
			}
		}

		public decimal? PriceWholesale1
		{
			get
			{
				return this._pricewholesale1;
			}
			set
			{
				this._pricewholesale1 = value;
			}
		}

		public decimal? PriceWholesale2
		{
			get
			{
				return this._pricewholesale2;
			}
			set
			{
				this._pricewholesale2 = value;
			}
		}

		public decimal? PriceWholesale3
		{
			get
			{
				return this._pricewholesale3;
			}
			set
			{
				this._pricewholesale3 = value;
			}
		}

		public int? ProvID
		{
			get
			{
				return this._provid;
			}
			set
			{
				this._provid = value;
			}
		}

		public string pyCode
		{
			get
			{
				return this._pycode;
			}
			set
			{
				this._pycode = value;
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

		public List<StockDeptInfo> StockDeptInfos
		{
			get
			{
				return this._stockdeptinfos;
			}
			set
			{
				this._stockdeptinfos = value;
			}
		}

		public int? StockID
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

		public List<StockInfo> StockInfos
		{
			get
			{
				return this._stockinfos;
			}
			set
			{
				this._stockinfos = value;
			}
		}

		public string SupplierName
		{
			get
			{
				return this._suppliername;
			}
			set
			{
				this._suppliername = value;
			}
		}

		public int? UnitID
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

		public string userdef1
		{
			get
			{
				return this._userdef1;
			}
			set
			{
				this._userdef1 = value;
			}
		}

		public string userdef2
		{
			get
			{
				return this._userdef2;
			}
			set
			{
				this._userdef2 = value;
			}
		}

		public string userdef3
		{
			get
			{
				return this._userdef3;
			}
			set
			{
				this._userdef3 = value;
			}
		}

		public string userdef4
		{
			get
			{
				return this._userdef4;
			}
			set
			{
				this._userdef4 = value;
			}
		}

		public string userdef5
		{
			get
			{
				return this._userdef5;
			}
			set
			{
				this._userdef5 = value;
			}
		}

		public string userdef6
		{
			get
			{
				return this._userdef6;
			}
			set
			{
				this._userdef6 = value;
			}
		}

		public int? Valid
		{
			get
			{
				return this._valid;
			}
			set
			{
				this._valid = value;
			}
		}

		public GoodsInfo()
		{
		}
	}
}