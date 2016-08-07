using System;

namespace wt.Model
{
	public class NetServicesInfo
	{
		private int _id;

		private int _typeid;

		private string __date;

		private string _status;

		private int _assid;

		private int _customerid;

		private string _customername;

		private string _linkman;

		private string _tel;

		private string _useperson;

		private string _usepersondept;

		private string _usepersontel;

		private string _area;

		private string _adr;

		private int _productclassid;

		private int _productbrandid;

		private int _productmodelid;

		private string _productsn1;

		private string _productsn2;

		private string _aspect;

		private string _accessory;

		private string _fault;

		private int _warrantyid;

		private string _buydate;

		private string _buyfrom;

		private string _buyinvoice;

		private string _subscribetime;

		private string _postno;

		private decimal _postage;

		private string _remark;

		private int _sndstyleid;

		private int _servicelevelid;

		private string _deviceno;

		private int iBranch;

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

		public string Accessory
		{
			get
			{
				return this._accessory;
			}
			set
			{
				this._accessory = value;
			}
		}

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

		public string Area
		{
			get
			{
				return this._area;
			}
			set
			{
				this._area = value;
			}
		}

		public string Aspect
		{
			get
			{
				return this._aspect;
			}
			set
			{
				this._aspect = value;
			}
		}

		public int AssID
		{
			get
			{
				return this._assid;
			}
			set
			{
				this._assid = value;
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

		public int CustomerID
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

		public string CustomerName
		{
			get
			{
				return this._customername;
			}
			set
			{
				this._customername = value;
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

		public string Fault
		{
			get
			{
				return this._fault;
			}
			set
			{
				this._fault = value;
			}
		}

		public int IBranch
		{
			get
			{
				return this.iBranch;
			}
			set
			{
				this.iBranch = value;
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

		public decimal Postage
		{
			get
			{
				return this._postage;
			}
			set
			{
				this._postage = value;
			}
		}

		public string PostNO
		{
			get
			{
				return this._postno;
			}
			set
			{
				this._postno = value;
			}
		}

		public int ProductBrandID
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

		public int ProductClassID
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

		public int ProductModelID
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

		public int ServiceLevelID
		{
			get
			{
				return this._servicelevelid;
			}
			set
			{
				this._servicelevelid = value;
			}
		}

		public int SndStyleID
		{
			get
			{
				return this._sndstyleid;
			}
			set
			{
				this._sndstyleid = value;
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

		public string SubscribeTime
		{
			get
			{
				return this._subscribetime;
			}
			set
			{
				this._subscribetime = value;
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

		public int TypeID
		{
			get
			{
				return this._typeid;
			}
			set
			{
				this._typeid = value;
			}
		}

		public string UsePerson
		{
			get
			{
				return this._useperson;
			}
			set
			{
				this._useperson = value;
			}
		}

		public string UsePersonDept
		{
			get
			{
				return this._usepersondept;
			}
			set
			{
				this._usepersondept = value;
			}
		}

		public string UsePersonTel
		{
			get
			{
				return this._usepersontel;
			}
			set
			{
				this._usepersontel = value;
			}
		}

		public int WarrantyID
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

		public NetServicesInfo()
		{
		}
	}
}