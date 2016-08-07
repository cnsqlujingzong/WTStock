using System;
using System.Collections.Generic;

namespace wt.Model
{
	[Serializable]
	public class ServicesInfo
	{
		private int _id;

		private string _billid;

		private int _takeoverid;

		private int _disposalid;

		private string _curstatus;

		private int _typeid;

		private int _takestyleid;

		private string _time_make;

		private string _time_takeover;

		private string _time_start;

		private string _time_over;

		private string _time_complete;

		private string _time_payee;

		private string _time_backsee;

		private string _time_close;

		private int _operatorid;

		private int _personid;

		private int _startoperatorid;

		private int _payeeoperid;

		private int _chkoperatorid;

		private int _backseeoperid;

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

		private string _buydate;

		private string _buyfrom;

		private string _aspect;

		private string _accessory;

		private string _fault;

		private int _warrantyid;

		private string __pri;

		private string _buyinvoice;

		private decimal _dpoint;

		private bool _brepair;

		private string _saveid;

		private string _supplierid;

		private int _warrantychargecorpid;

		private string _disposaloper;

		private string _subscribetime;

		private string _subscribeconnecttime;

		private decimal _subscribeprice;

		private decimal _precharge;

		private string _remark;

		private decimal _repaircost;

		private decimal _materailcost;

		private decimal _extracost;

		private decimal _fee_materail;

		private decimal _fee_labor;

		private decimal _fee_add;

		private string _dostatus;

		private string _takesteps;

		private decimal _postage;

		private string _postno;

		private int _sndstyleid;

		private int _servicelevelid;

		private string _contractno;

		private string _deviceno;

		private string _path;

		private bool _bagain;

		private List<ServicesDeviceConfInfo> _servicesdeviceconfinfos;

		private List<ServicesItemInfo> _servicesiteminfos;

		private List<ServicesMaterialInfo> _servicesmaterialinfos;

		private List<ServiceOfferInfo> _servicesofferinfos;
        //cmbProver 
        //cmbCity BranchName
        //BranchRatio 
        // BranchRatioType 
        private string _cmbProver;
        private string _cmbCity;
        private string _branchName;
        private decimal _branchRatio;
        private string _branchRatioType;

        public string _PRI
		{
			get
			{
				return this.__pri;
			}
			set
			{
				this.__pri = value;
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

		public int BackSeeOperID
		{
			get
			{
				return this._backseeoperid;
			}
			set
			{
				this._backseeoperid = value;
			}
		}

		public bool bAgain
		{
			get
			{
				return this._bagain;
			}
			set
			{
				this._bagain = value;
			}
		}

		public string BillID
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

		public bool bRepair
		{
			get
			{
				return this._brepair;
			}
			set
			{
				this._brepair = value;
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

		public int ChkOperatorID
		{
			get
			{
				return this._chkoperatorid;
			}
			set
			{
				this._chkoperatorid = value;
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

		public string curStatus
		{
			get
			{
				return this._curstatus;
			}
			set
			{
				this._curstatus = value;
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

		public int DisposalID
		{
			get
			{
				return this._disposalid;
			}
			set
			{
				this._disposalid = value;
			}
		}

		public string DisposalOper
		{
			get
			{
				return this._disposaloper;
			}
			set
			{
				this._disposaloper = value;
			}
		}

		public string DoStatus
		{
			get
			{
				return this._dostatus;
			}
			set
			{
				this._dostatus = value;
			}
		}

		public decimal dPoint
		{
			get
			{
				return this._dpoint;
			}
			set
			{
				this._dpoint = value;
			}
		}

		public decimal ExtraCost
		{
			get
			{
				return this._extracost;
			}
			set
			{
				this._extracost = value;
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

		public decimal Fee_Add
		{
			get
			{
				return this._fee_add;
			}
			set
			{
				this._fee_add = value;
			}
		}

		public decimal Fee_Labor
		{
			get
			{
				return this._fee_labor;
			}
			set
			{
				this._fee_labor = value;
			}
		}

		public decimal Fee_Materail
		{
			get
			{
				return this._fee_materail;
			}
			set
			{
				this._fee_materail = value;
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

		public decimal MaterailCost
		{
			get
			{
				return this._materailcost;
			}
			set
			{
				this._materailcost = value;
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

		public string Path
		{
			get
			{
				return this._path;
			}
			set
			{
				this._path = value;
			}
		}

		public int PayeeOperID
		{
			get
			{
				return this._payeeoperid;
			}
			set
			{
				this._payeeoperid = value;
			}
		}

		public int PersonID
		{
			get
			{
				return this._personid;
			}
			set
			{
				this._personid = value;
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

		public decimal PreCharge
		{
			get
			{
				return this._precharge;
			}
			set
			{
				this._precharge = value;
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

		public decimal RepairCost
		{
			get
			{
				return this._repaircost;
			}
			set
			{
				this._repaircost = value;
			}
		}

		public string SaveID
		{
			get
			{
				return this._saveid;
			}
			set
			{
				this._saveid = value;
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

		public List<ServiceOfferInfo> ServiceOfferInfos
		{
			get
			{
				return this._servicesofferinfos;
			}
			set
			{
				this._servicesofferinfos = value;
			}
		}

		public List<ServicesDeviceConfInfo> ServicesDeviceConfInfos
		{
			get
			{
				return this._servicesdeviceconfinfos;
			}
			set
			{
				this._servicesdeviceconfinfos = value;
			}
		}

		public List<ServicesItemInfo> ServicesItemInfos
		{
			get
			{
				return this._servicesiteminfos;
			}
			set
			{
				this._servicesiteminfos = value;
			}
		}

		public List<ServicesMaterialInfo> ServicesMaterialInfos
		{
			get
			{
				return this._servicesmaterialinfos;
			}
			set
			{
				this._servicesmaterialinfos = value;
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

		public int StartOperatorID
		{
			get
			{
				return this._startoperatorid;
			}
			set
			{
				this._startoperatorid = value;
			}
		}

		public string SubscribeConnectTime
		{
			get
			{
				return this._subscribeconnecttime;
			}
			set
			{
				this._subscribeconnecttime = value;
			}
		}

		public decimal SubscribePrice
		{
			get
			{
				return this._subscribeprice;
			}
			set
			{
				this._subscribeprice = value;
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

		public string SupplierID
		{
			get
			{
				return this._supplierid;
			}
			set
			{
				this._supplierid = value;
			}
		}

		public int TakeOverID
		{
			get
			{
				return this._takeoverid;
			}
			set
			{
				this._takeoverid = value;
			}
		}

		public string TakeSteps
		{
			get
			{
				return this._takesteps;
			}
			set
			{
				this._takesteps = value;
			}
		}

		public int TakeStyleID
		{
			get
			{
				return this._takestyleid;
			}
			set
			{
				this._takestyleid = value;
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

		public string Time_BackSee
		{
			get
			{
				return this._time_backsee;
			}
			set
			{
				this._time_backsee = value;
			}
		}

		public string Time_Close
		{
			get
			{
				return this._time_close;
			}
			set
			{
				this._time_close = value;
			}
		}

		public string Time_Complete
		{
			get
			{
				return this._time_complete;
			}
			set
			{
				this._time_complete = value;
			}
		}

		public string Time_Make
		{
			get
			{
				return this._time_make;
			}
			set
			{
				this._time_make = value;
			}
		}

		public string Time_Over
		{
			get
			{
				return this._time_over;
			}
			set
			{
				this._time_over = value;
			}
		}

		public string Time_Payee
		{
			get
			{
				return this._time_payee;
			}
			set
			{
				this._time_payee = value;
			}
		}

		public string Time_Start
		{
			get
			{
				return this._time_start;
			}
			set
			{
				this._time_start = value;
			}
		}

		public string Time_TakeOver
		{
			get
			{
				return this._time_takeover;
			}
			set
			{
				this._time_takeover = value;
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

		public int WarrantyChargeCorpID
		{
			get
			{
				return this._warrantychargecorpid;
			}
			set
			{
				this._warrantychargecorpid = value;
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

        public string CmbProver
        {
            get
            {
                return _cmbProver;
            }

            set
            {
                _cmbProver = value;
            }
        }

        public string CmbCity
        {
            get
            {
                return _cmbCity;
            }

            set
            {
                _cmbCity = value;
            }
        }

        public string BranchName
        {
            get
            {
                return _branchName;
            }

            set
            {
                _branchName = value;
            }
        }

        public decimal BranchRatio
        {
            get
            {
                return _branchRatio;
            }

            set
            {
                _branchRatio = value;
            }
        }

        public string BranchRatioType
        {
            get
            {
                return _branchRatioType;
            }

            set
            {
                _branchRatioType = value;
            }
        }

        public ServicesInfo()
		{
		}
	}
}