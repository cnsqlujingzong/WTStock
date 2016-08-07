using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussModule.Biz.Model
{
   public class fw_services
    {
        public fw_services()
        { }
        #region Model
        private int _id;
        private string _billid;
        private string _takedept;
        private string _disposaldept;
        private string _curstatus;
        private bool _btake;
        private int? _payeeoperid;
        private int? _chkoperatorid;
        private int? _backseeoperid;
        private DateTime? _time_complete;
        private int _takeoverid;
        private int _disposalid;
        private string _servicestype;
        private string _takestyle;
        private int? _takestyleid;
        private int? _typeid;
        private int? _isdismissed;
        private string _offerconf;
        private string _sercount;
        private DateTime? _time_make;
        private DateTime? _time_takeover;
        private DateTime? _time_start;
        private DateTime? _time_over;
        private string _time_payee;
        private int? _operatorid;
        private DateTime? _time_backsee;
        private DateTime? _time_close;
        private string _operator;
        private string _person;
        private int? _personid;
        private string _startoperator;
        private string _payeeoper;
        private string _chkoperator;
        private int? _productclassid;
        private int? _productbrandid;
        private int? _productmodelid;
        private string _backseeoper;
        private string _customername;
        private int? _branchid;
        private string _customerfrom;
        private string _customerclass;
        private string _userdef1;
        private string _userdef2;
        private string _userdef3;
        private string _userdef4;
        private string _userdef5;
        private string _userdef6;
        private string _linkman;
        private string _tel;
        private string _useperson;
        private string _usepersondept;
        private string _usepersontel;
        private string _area;
        private string _adr;
        private string _productsn1;
        private string _productsn2;
        private string _fintec;
        private string _buydate;
        private string _buyfrom;
        private string _productclass;
        private string _productmodel;
        private string _productbrand;
        private string _aspect;
        private int? _custype;
        private int? _warrantyid;
        private string _accessory;
        private string _fault;
        private string _warranty;
        private string _buyinvoice;
        private decimal? _dpoint;
        private int? _sellerid;
        private string _speding;
        private int? _time;
        private int? _timeout;
        private string _brepair;
        private string _saveid;
        private string _supplierid;
        private string _chargecorp;
        private string _disposaloper;
        private DateTime? _subscribetime;
        private string _subscribeconnecttime;
        private decimal? _subscribeprice;
        private decimal? _precharge;
        private string _repairstatus;
        private string _repairtype;
        private int? _repaircorpid;
        private string _repaircorp;
        private string _remark;
        private string _cancelreason;
        private DateTime? _repairsnddate;
        private DateTime? _repairrcvdate;
        private decimal? _repaircost;
        private int _customerid;
        private int _warrantychargecorpid;
        private string _postno;
        private decimal? _postage;
        private decimal? _materailcost;
        private decimal? _extracost;
        private decimal? _fee_materail;
        private decimal? _fee_labor;
        private decimal? _fee_add;
        private decimal? _warrantychargevalue;
        private decimal? _chargevalue;
        private decimal? _fee_total;
        private decimal? _profit;
        private string _warrantyenddate;
        private string _warrantybound;
        private string _goodsto;
        private string _connectdate;
        private string _bcall;
        private string _smsstatus;
        private DateTime? _confirmdate;
        private string _corpname;
        private string _coordinates;
        private string _corplinkman;
        private string _corptel;
        private string _corpfax;
        private string _corpzip;
        private string _corparea;
        private string _corpadr;
        private decimal? _incash;
        private string __pri;
        private string _contractno;
        private string _sndstyle;
        private int? _sndstyleid;
        private int? _servicelevelid;
        private int? _responsetime;
        private int? _repairtime;
        private string _deviceno;
        private decimal? _premoney;
        private decimal? _realmoney;
        private string _takesteps;
        private string _qtytype;
        private string _oldqtytype;
        private decimal _haveamount;
        private decimal _notchargeamount;
        private string _path;
        private string _bagain;
        private string _deduct;
        private string _visitdate;
        private string _visitcusname;
        private string _visitopinon;
        private string _visitremark;
        private string _visitoperator;
        private string _visitstyle;
        private string _hfqk;
        private int? _visitid;
        private string _cmbprover;
        private string _cmbcity;
        private string _branchname;
        private decimal? _branchratio;
        private string _branchratiotype;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BillID
        {
            set { _billid = value; }
            get { return _billid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TakeDept
        {
            set { _takedept = value; }
            get { return _takedept; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DisposalDept
        {
            set { _disposaldept = value; }
            get { return _disposaldept; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string curStatus
        {
            set { _curstatus = value; }
            get { return _curstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool bTake
        {
            set { _btake = value; }
            get { return _btake; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PayeeOperID
        {
            set { _payeeoperid = value; }
            get { return _payeeoperid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ChkOperatorID
        {
            set { _chkoperatorid = value; }
            get { return _chkoperatorid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? BackSeeOperID
        {
            set { _backseeoperid = value; }
            get { return _backseeoperid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Time_Complete
        {
            set { _time_complete = value; }
            get { return _time_complete; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int TakeOverID
        {
            set { _takeoverid = value; }
            get { return _takeoverid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int DisposalID
        {
            set { _disposalid = value; }
            get { return _disposalid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ServicesType
        {
            set { _servicestype = value; }
            get { return _servicestype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TakeStyle
        {
            set { _takestyle = value; }
            get { return _takestyle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TakeStyleID
        {
            set { _takestyleid = value; }
            get { return _takestyleid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsDismissed
        {
            set { _isdismissed = value; }
            get { return _isdismissed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OfferConf
        {
            set { _offerconf = value; }
            get { return _offerconf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SerCount
        {
            set { _sercount = value; }
            get { return _sercount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Time_Make
        {
            set { _time_make = value; }
            get { return _time_make; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Time_TakeOver
        {
            set { _time_takeover = value; }
            get { return _time_takeover; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Time_Start
        {
            set { _time_start = value; }
            get { return _time_start; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Time_Over
        {
            set { _time_over = value; }
            get { return _time_over; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Time_Payee
        {
            set { _time_payee = value; }
            get { return _time_payee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OperatorID
        {
            set { _operatorid = value; }
            get { return _operatorid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Time_BackSee
        {
            set { _time_backsee = value; }
            get { return _time_backsee; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Time_Close
        {
            set { _time_close = value; }
            get { return _time_close; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Operator
        {
            set { _operator = value; }
            get { return _operator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Person
        {
            set { _person = value; }
            get { return _person; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PersonID
        {
            set { _personid = value; }
            get { return _personid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StartOperator
        {
            set { _startoperator = value; }
            get { return _startoperator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PayeeOper
        {
            set { _payeeoper = value; }
            get { return _payeeoper; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ChkOperator
        {
            set { _chkoperator = value; }
            get { return _chkoperator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ProductClassID
        {
            set { _productclassid = value; }
            get { return _productclassid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ProductBrandID
        {
            set { _productbrandid = value; }
            get { return _productbrandid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ProductModelID
        {
            set { _productmodelid = value; }
            get { return _productmodelid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BackSeeOper
        {
            set { _backseeoper = value; }
            get { return _backseeoper; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CustomerName
        {
            set { _customername = value; }
            get { return _customername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? BranchID
        {
            set { _branchid = value; }
            get { return _branchid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CustomerFrom
        {
            set { _customerfrom = value; }
            get { return _customerfrom; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CustomerClass
        {
            set { _customerclass = value; }
            get { return _customerclass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string userdef1
        {
            set { _userdef1 = value; }
            get { return _userdef1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string userdef2
        {
            set { _userdef2 = value; }
            get { return _userdef2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string userdef3
        {
            set { _userdef3 = value; }
            get { return _userdef3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string userdef4
        {
            set { _userdef4 = value; }
            get { return _userdef4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string userdef5
        {
            set { _userdef5 = value; }
            get { return _userdef5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string userdef6
        {
            set { _userdef6 = value; }
            get { return _userdef6; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LinkMan
        {
            set { _linkman = value; }
            get { return _linkman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UsePerson
        {
            set { _useperson = value; }
            get { return _useperson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UsePersonDept
        {
            set { _usepersondept = value; }
            get { return _usepersondept; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UsePersonTel
        {
            set { _usepersontel = value; }
            get { return _usepersontel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Area
        {
            set { _area = value; }
            get { return _area; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Adr
        {
            set { _adr = value; }
            get { return _adr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductSN1
        {
            set { _productsn1 = value; }
            get { return _productsn1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductSN2
        {
            set { _productsn2 = value; }
            get { return _productsn2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FinTec
        {
            set { _fintec = value; }
            get { return _fintec; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BuyDate
        {
            set { _buydate = value; }
            get { return _buydate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BuyFrom
        {
            set { _buyfrom = value; }
            get { return _buyfrom; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductClass
        {
            set { _productclass = value; }
            get { return _productclass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductModel
        {
            set { _productmodel = value; }
            get { return _productmodel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProductBrand
        {
            set { _productbrand = value; }
            get { return _productbrand; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Aspect
        {
            set { _aspect = value; }
            get { return _aspect; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CusType
        {
            set { _custype = value; }
            get { return _custype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? WarrantyID
        {
            set { _warrantyid = value; }
            get { return _warrantyid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Accessory
        {
            set { _accessory = value; }
            get { return _accessory; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fault
        {
            set { _fault = value; }
            get { return _fault; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Warranty
        {
            set { _warranty = value; }
            get { return _warranty; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BuyInvoice
        {
            set { _buyinvoice = value; }
            get { return _buyinvoice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? dPoint
        {
            set { _dpoint = value; }
            get { return _dpoint; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SellerID
        {
            set { _sellerid = value; }
            get { return _sellerid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Speding
        {
            set { _speding = value; }
            get { return _speding; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Time
        {
            set { _time = value; }
            get { return _time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Timeout
        {
            set { _timeout = value; }
            get { return _timeout; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bRepair
        {
            set { _brepair = value; }
            get { return _brepair; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SaveID
        {
            set { _saveid = value; }
            get { return _saveid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SupplierID
        {
            set { _supplierid = value; }
            get { return _supplierid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ChargeCorp
        {
            set { _chargecorp = value; }
            get { return _chargecorp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DisposalOper
        {
            set { _disposaloper = value; }
            get { return _disposaloper; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SubscribeTime
        {
            set { _subscribetime = value; }
            get { return _subscribetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SubscribeConnectTime
        {
            set { _subscribeconnecttime = value; }
            get { return _subscribeconnecttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? SubscribePrice
        {
            set { _subscribeprice = value; }
            get { return _subscribeprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PreCharge
        {
            set { _precharge = value; }
            get { return _precharge; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RepairStatus
        {
            set { _repairstatus = value; }
            get { return _repairstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RepairType
        {
            set { _repairtype = value; }
            get { return _repairtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? RepairCorpID
        {
            set { _repaircorpid = value; }
            get { return _repaircorpid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RepairCorp
        {
            set { _repaircorp = value; }
            get { return _repaircorp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CancelReason
        {
            set { _cancelreason = value; }
            get { return _cancelreason; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? RepairSndDate
        {
            set { _repairsnddate = value; }
            get { return _repairsnddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? RepairRcvDate
        {
            set { _repairrcvdate = value; }
            get { return _repairrcvdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? RepairCost
        {
            set { _repaircost = value; }
            get { return _repaircost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int CustomerID
        {
            set { _customerid = value; }
            get { return _customerid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int WarrantyChargeCorpID
        {
            set { _warrantychargecorpid = value; }
            get { return _warrantychargecorpid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PostNO
        {
            set { _postno = value; }
            get { return _postno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Postage
        {
            set { _postage = value; }
            get { return _postage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? MaterailCost
        {
            set { _materailcost = value; }
            get { return _materailcost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ExtraCost
        {
            set { _extracost = value; }
            get { return _extracost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Fee_Materail
        {
            set { _fee_materail = value; }
            get { return _fee_materail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Fee_Labor
        {
            set { _fee_labor = value; }
            get { return _fee_labor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Fee_Add
        {
            set { _fee_add = value; }
            get { return _fee_add; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? WarrantyChargeValue
        {
            set { _warrantychargevalue = value; }
            get { return _warrantychargevalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ChargeValue
        {
            set { _chargevalue = value; }
            get { return _chargevalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Fee_Total
        {
            set { _fee_total = value; }
            get { return _fee_total; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Profit
        {
            set { _profit = value; }
            get { return _profit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WarrantyEndDate
        {
            set { _warrantyenddate = value; }
            get { return _warrantyenddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string WarrantyBound
        {
            set { _warrantybound = value; }
            get { return _warrantybound; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GoodsTo
        {
            set { _goodsto = value; }
            get { return _goodsto; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ConnectDate
        {
            set { _connectdate = value; }
            get { return _connectdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bCall
        {
            set { _bcall = value; }
            get { return _bcall; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SmsStatus
        {
            set { _smsstatus = value; }
            get { return _smsstatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ConfirmDate
        {
            set { _confirmdate = value; }
            get { return _confirmdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CorpName
        {
            set { _corpname = value; }
            get { return _corpname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Coordinates
        {
            set { _coordinates = value; }
            get { return _coordinates; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CorpLinkMan
        {
            set { _corplinkman = value; }
            get { return _corplinkman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CorpTel
        {
            set { _corptel = value; }
            get { return _corptel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CorpFax
        {
            set { _corpfax = value; }
            get { return _corpfax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CorpZip
        {
            set { _corpzip = value; }
            get { return _corpzip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CorpArea
        {
            set { _corparea = value; }
            get { return _corparea; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CorpAdr
        {
            set { _corpadr = value; }
            get { return _corpadr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? InCash
        {
            set { _incash = value; }
            get { return _incash; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string _PRI
        {
            set { __pri = value; }
            get { return __pri; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ContractNO
        {
            set { _contractno = value; }
            get { return _contractno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SndStyle
        {
            set { _sndstyle = value; }
            get { return _sndstyle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SndStyleID
        {
            set { _sndstyleid = value; }
            get { return _sndstyleid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ServiceLevelID
        {
            set { _servicelevelid = value; }
            get { return _servicelevelid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ResponseTime
        {
            set { _responsetime = value; }
            get { return _responsetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? RepairTime
        {
            set { _repairtime = value; }
            get { return _repairtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DeviceNO
        {
            set { _deviceno = value; }
            get { return _deviceno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PreMoney
        {
            set { _premoney = value; }
            get { return _premoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? RealMoney
        {
            set { _realmoney = value; }
            get { return _realmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TakeSteps
        {
            set { _takesteps = value; }
            get { return _takesteps; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QtyType
        {
            set { _qtytype = value; }
            get { return _qtytype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OldQtyType
        {
            set { _oldqtytype = value; }
            get { return _oldqtytype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal HaveAmount
        {
            set { _haveamount = value; }
            get { return _haveamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal NotChargeAmount
        {
            set { _notchargeamount = value; }
            get { return _notchargeamount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Path
        {
            set { _path = value; }
            get { return _path; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bAgain
        {
            set { _bagain = value; }
            get { return _bagain; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Deduct
        {
            set { _deduct = value; }
            get { return _deduct; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string VisitDate
        {
            set { _visitdate = value; }
            get { return _visitdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string VisitCusName
        {
            set { _visitcusname = value; }
            get { return _visitcusname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string VisitOpinon
        {
            set { _visitopinon = value; }
            get { return _visitopinon; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string VisitRemark
        {
            set { _visitremark = value; }
            get { return _visitremark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string VisitOperator
        {
            set { _visitoperator = value; }
            get { return _visitoperator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string VisitStyle
        {
            set { _visitstyle = value; }
            get { return _visitstyle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HFQK
        {
            set { _hfqk = value; }
            get { return _hfqk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? VisitID
        {
            set { _visitid = value; }
            get { return _visitid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cmbProver
        {
            set { _cmbprover = value; }
            get { return _cmbprover; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cmbCity
        {
            set { _cmbcity = value; }
            get { return _cmbcity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BranchName
        {
            set { _branchname = value; }
            get { return _branchname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? BranchRatio
        {
            set { _branchratio = value; }
            get { return _branchratio; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BranchRatioType
        {
            set { _branchratiotype = value; }
            get { return _branchratiotype; }
        }
        #endregion Model
    }
}
