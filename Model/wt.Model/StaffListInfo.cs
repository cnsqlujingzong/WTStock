using System;

namespace wt.Model
{
	[Serializable]
	public class StaffListInfo
	{
		private int _id;

		private int? _deptid;

		private string _jobno;

		private string __name;

		private string _sex;

		private string _tel;

		private string _area;

		private string _adr;

		private string _nativeplace;

		private string _cardid;

		private string _birthdate;

		private string _academic;

		private string _school;

		private string _specialty;

		private string _jobdate;

		private string _billdeduct;

		private string _selldeduct;

		private int? _qid;

		private bool _btechnician;

		private bool _bseller;

		private bool _bstockman;

		private bool _bdestclerk;

		private bool _baccountant;

		private bool _ballot;

		private bool _bmanage;

		private int? _status;

		private string _remark;

		private string _attendancepwd;

		private decimal _salary;

		private decimal _allowance;

		private string _account;

		private int _staffdeptid;

		private string _profitformula;

		private int _ftype;

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

		public string Academic
		{
			get
			{
				return this._academic;
			}
			set
			{
				this._academic = value;
			}
		}

		public string Account
		{
			get
			{
				return this._account;
			}
			set
			{
				this._account = value;
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

		public decimal Allowance
		{
			get
			{
				return this._allowance;
			}
			set
			{
				this._allowance = value;
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

		public string AttendancePwd
		{
			get
			{
				return this._attendancepwd;
			}
			set
			{
				this._attendancepwd = value;
			}
		}

		public bool bAccountant
		{
			get
			{
				return this._baccountant;
			}
			set
			{
				this._baccountant = value;
			}
		}

		public bool bAllot
		{
			get
			{
				return this._ballot;
			}
			set
			{
				this._ballot = value;
			}
		}

		public bool bDestClerk
		{
			get
			{
				return this._bdestclerk;
			}
			set
			{
				this._bdestclerk = value;
			}
		}

		public string BillDeduct
		{
			get
			{
				return this._billdeduct;
			}
			set
			{
				this._billdeduct = value;
			}
		}

		public string BirthDate
		{
			get
			{
				return this._birthdate;
			}
			set
			{
				this._birthdate = value;
			}
		}

		public bool bManage
		{
			get
			{
				return this._bmanage;
			}
			set
			{
				this._bmanage = value;
			}
		}

		public bool bSeller
		{
			get
			{
				return this._bseller;
			}
			set
			{
				this._bseller = value;
			}
		}

		public bool bStockMan
		{
			get
			{
				return this._bstockman;
			}
			set
			{
				this._bstockman = value;
			}
		}

		public bool bTechnician
		{
			get
			{
				return this._btechnician;
			}
			set
			{
				this._btechnician = value;
			}
		}

		public string CardID
		{
			get
			{
				return this._cardid;
			}
			set
			{
				this._cardid = value;
			}
		}

		public int? DeptID
		{
			get
			{
				return this._deptid;
			}
			set
			{
				this._deptid = value;
			}
		}

		public int ftype
		{
			get
			{
				return this._ftype;
			}
			set
			{
				this._ftype = value;
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

		public string JobDate
		{
			get
			{
				return this._jobdate;
			}
			set
			{
				this._jobdate = value;
			}
		}

		public string JobNO
		{
			get
			{
				return this._jobno;
			}
			set
			{
				this._jobno = value;
			}
		}

		public string NativePlace
		{
			get
			{
				return this._nativeplace;
			}
			set
			{
				this._nativeplace = value;
			}
		}

		public string ProfitFormula
		{
			get
			{
				return this._profitformula;
			}
			set
			{
				this._profitformula = value;
			}
		}

		public int? Qid
		{
			get
			{
				return this._qid;
			}
			set
			{
				this._qid = value;
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

		public decimal Salary
		{
			get
			{
				return this._salary;
			}
			set
			{
				this._salary = value;
			}
		}

		public string School
		{
			get
			{
				return this._school;
			}
			set
			{
				this._school = value;
			}
		}

		public string SellDeduct
		{
			get
			{
				return this._selldeduct;
			}
			set
			{
				this._selldeduct = value;
			}
		}

		public string Sex
		{
			get
			{
				return this._sex;
			}
			set
			{
				this._sex = value;
			}
		}

		public string Specialty
		{
			get
			{
				return this._specialty;
			}
			set
			{
				this._specialty = value;
			}
		}

		public int StaffDeptID
		{
			get
			{
				return this._staffdeptid;
			}
			set
			{
				this._staffdeptid = value;
			}
		}

		public int? Status
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

		public StaffListInfo()
		{
		}
	}
}