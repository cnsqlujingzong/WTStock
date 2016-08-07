using System;

namespace wt.Model
{
	public class DeviceListInfo
	{
		private int _id;

		private int? _productclassid;

		private int? _productbrandid;

		private int? _productmodelid;

		private string _productsn1;

		private string _productsn2;

		private string _buydate;

		private string _buyfrom;

		private string _productaspect;

		private string _buyinvoice;

		private int? _customerid;

		private string _installdate;

		private string _maintenanceperiod;

		private int? _warrantyid;

		private string _warrantystart;

		private string _warrantyend;

		private int? _repairtimes;

		private string _repairlately;

		private string _repairwarrantyend;

		private string _contractwarrantystart;

		private string _contractwarrantyend;

		private string _linkman;

		private string _contractno;

		private string _remark;

		private string _cusdept;

		private string _tel;

		private string _tel2;

		private string _fax;

		private string _zip;

		private string _adr;

		private string _deviceno;

		private int _property;

		private decimal _buyprice;

		private string _userdef1;

		private string _userdef2;

		private string _userdef3;

		private string _userdef4;

		private string _userdef5;

		private string _technicians;

		public string Adr
		{
			get
			{
				return this._adr;
			}
			set
			{
				this._adr = value;
			}
		}

		public string BuyDate
		{
			get
			{
				return this._buydate;
			}
			set
			{
				this._buydate = value;
			}
		}

		public string BuyFrom
		{
			get
			{
				return this._buyfrom;
			}
			set
			{
				this._buyfrom = value;
			}
		}

		public string BuyInvoice
		{
			get
			{
				return this._buyinvoice;
			}
			set
			{
				this._buyinvoice = value;
			}
		}

		public decimal BuyPrice
		{
			get
			{
				return this._buyprice;
			}
			set
			{
				this._buyprice = value;
			}
		}

		public string ContractNO
		{
			get
			{
				return this._contractno;
			}
			set
			{
				this._contractno = value;
			}
		}

		public string ContractWarrantyEnd
		{
			get
			{
				return this._contractwarrantyend;
			}
			set
			{
				this._contractwarrantyend = value;
			}
		}

		public string ContractWarrantyStart
		{
			get
			{
				return this._contractwarrantystart;
			}
			set
			{
				this._contractwarrantystart = value;
			}
		}

		public string CusDept
		{
			get
			{
				return this._cusdept;
			}
			set
			{
				this._cusdept = value;
			}
		}

		public int? CustomerID
		{
			get
			{
				return this._customerid;
			}
			set
			{
				this._customerid = value;
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

		public string Fax
		{
			get
			{
				return this._fax;
			}
			set
			{
				this._fax = value;
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

		public string InstallDate
		{
			get
			{
				return this._installdate;
			}
			set
			{
				this._installdate = value;
			}
		}

		public string LinkMan
		{
			get
			{
				return this._linkman;
			}
			set
			{
				this._linkman = value;
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

		public string ProductAspect
		{
			get
			{
				return this._productaspect;
			}
			set
			{
				this._productaspect = value;
			}
		}

		public int? ProductBrandID
		{
			get
			{
				return this._productbrandid;
			}
			set
			{
				this._productbrandid = value;
			}
		}

		public int? ProductClassID
		{
			get
			{
				return this._productclassid;
			}
			set
			{
				this._productclassid = value;
			}
		}

		public int? ProductModelID
		{
			get
			{
				return this._productmodelid;
			}
			set
			{
				this._productmodelid = value;
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

		public int Property
		{
			get
			{
				return this._property;
			}
			set
			{
				this._property = value;
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

		public string Repairlately
		{
			get
			{
				return this._repairlately;
			}
			set
			{
				this._repairlately = value;
			}
		}

		public int? RepairTimes
		{
			get
			{
				return this._repairtimes;
			}
			set
			{
				this._repairtimes = value;
			}
		}

		public string RepairWarrantyEnd
		{
			get
			{
				return this._repairwarrantyend;
			}
			set
			{
				this._repairwarrantyend = value;
			}
		}

		public string Technicians
		{
			get
			{
				return this._technicians;
			}
			set
			{
				this._technicians = value;
			}
		}

		public string Tel
		{
			get
			{
				return this._tel;
			}
			set
			{
				this._tel = value;
			}
		}

		public string Tel2
		{
			get
			{
				return this._tel2;
			}
			set
			{
				this._tel2 = value;
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

		public string WarrantyEnd
		{
			get
			{
				return this._warrantyend;
			}
			set
			{
				this._warrantyend = value;
			}
		}

		public int? WarrantyID
		{
			get
			{
				return this._warrantyid;
			}
			set
			{
				this._warrantyid = value;
			}
		}

		public string WarrantyStart
		{
			get
			{
				return this._warrantystart;
			}
			set
			{
				this._warrantystart = value;
			}
		}

		public string Zip
		{
			get
			{
				return this._zip;
			}
			set
			{
				this._zip = value;
			}
		}

		public DeviceListInfo()
		{
		}
	}
}