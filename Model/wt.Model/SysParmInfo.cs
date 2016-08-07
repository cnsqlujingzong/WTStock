using System;

namespace wt.Model
{
	[Serializable]
	public class SysParmInfo
	{
		private int _id;

		private string _corpname;

		private string _tel;

		private string _adr;

		private string _zip;

		private string _sysname;

		private int _branchnum;

		private int _allocateprice;

		private int _warrantycycle;

		private int _customershar;

		private string _emailserver;

		private string _emaillogname;

		private string _emailpwd;

		private string _emailadr;

		private string _smscode;

		private string _backupadr;

		private int _bweb;

		private int _sndstyle;

		private string _username;

		private string _userpwd;

		private int _recdueday;

		private bool _bloginddl;

		private bool _bvalicode;

		private int _bbln;

		private bool _brememberpassword;

		private int _irepair;

		private bool _bfinish;

		private bool _bfinish2;

		private int _servicesdo;

		private string _city;

		private bool _btec;

		private bool _bSerItem;

		private bool _bheadbln;

		private bool _bsersep;

		private bool _bfaultnoinput;

		private bool _btakestepsnoinput;

		private bool _bsim;

		private bool _benforceinput;

		private bool _bplancontrol;

		private bool _bzeropurchase;

		private bool _bdisblingcontrol;

		private int _lockminutes;

		private bool _deviceonly;

		private bool _bpursep;

		private bool _bsellsep;

		private int costModel;

		private bool _bphone;

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

		public int AllocatePrice
		{
			get
			{
				return this._allocateprice;
			}
			set
			{
				this._allocateprice = value;
			}
		}

		public string BackUpAdr
		{
			get
			{
				return this._backupadr;
			}
			set
			{
				this._backupadr = value;
			}
		}

		public int bBln
		{
			get
			{
				return this._bbln;
			}
			set
			{
				this._bbln = value;
			}
		}

		public bool bDeviceOnly
		{
			get
			{
				return this._deviceonly;
			}
			set
			{
				this._deviceonly = value;
			}
		}

		public bool bDisblingControl
		{
			get
			{
				return this._bdisblingcontrol;
			}
			set
			{
				this._bdisblingcontrol = value;
			}
		}

		public bool bEnforceInput
		{
			get
			{
				return this._benforceinput;
			}
			set
			{
				this._benforceinput = value;
			}
		}

		public bool bFaultNoInput
		{
			get
			{
				return this._bfaultnoinput;
			}
			set
			{
				this._bfaultnoinput = value;
			}
		}

		public bool bFinish
		{
			get
			{
				return this._bfinish;
			}
			set
			{
				this._bfinish = value;
			}
		}

		public bool bFinish2
		{
			get
			{
				return this._bfinish2;
			}
			set
			{
				this._bfinish2 = value;
			}
		}

		public bool bHeadBln
		{
			get
			{
				return this._bheadbln;
			}
			set
			{
				this._bheadbln = value;
			}
		}

		public bool bLoginDdl
		{
			get
			{
				return this._bloginddl;
			}
			set
			{
				this._bloginddl = value;
			}
		}

		public bool bPhone
		{
			get
			{
				return this._bphone;
			}
			set
			{
				this._bphone = value;
			}
		}

		public bool bPlanControl
		{
			get
			{
				return this._bplancontrol;
			}
			set
			{
				this._bplancontrol = value;
			}
		}

		public bool bPurSep
		{
			get
			{
				return this._bpursep;
			}
			set
			{
				this._bpursep = value;
			}
		}

		public int BranchNum
		{
			get
			{
				return this._branchnum;
			}
			set
			{
				this._branchnum = value;
			}
		}

		public bool bRememberPassword
		{
			get
			{
				return this._brememberpassword;
			}
			set
			{
				this._brememberpassword = value;
			}
		}

		public bool bSellSep
		{
			get
			{
				return this._bsellsep;
			}
			set
			{
				this._bsellsep = value;
			}
		}

		public bool bSerItem
		{
			get
			{
				return this._bSerItem;
			}
			set
			{
				this._bSerItem = value;
			}
		}

		public bool bSerSep
		{
			get
			{
				return this._bsersep;
			}
			set
			{
				this._bsersep = value;
			}
		}

		public bool bSim
		{
			get
			{
				return this._bsim;
			}
			set
			{
				this._bsim = value;
			}
		}

		public bool bTakeStepsNoInput
		{
			get
			{
				return this._btakestepsnoinput;
			}
			set
			{
				this._btakestepsnoinput = value;
			}
		}

		public bool bTec
		{
			get
			{
				return this._btec;
			}
			set
			{
				this._btec = value;
			}
		}

		public bool bValiCode
		{
			get
			{
				return this._bvalicode;
			}
			set
			{
				this._bvalicode = value;
			}
		}

		public int bWeb
		{
			get
			{
				return this._bweb;
			}
			set
			{
				this._bweb = value;
			}
		}

		public bool bZeroPurchase
		{
			get
			{
				return this._bzeropurchase;
			}
			set
			{
				this._bzeropurchase = value;
			}
		}

		public string City
		{
			get
			{
				return this._city;
			}
			set
			{
				this._city = value;
			}
		}

		public string CorpName
		{
			get
			{
				return this._corpname;
			}
			set
			{
				this._corpname = value;
			}
		}

		public int CostModel
		{
			get
			{
				return this.costModel;
			}
			set
			{
				this.costModel = value;
			}
		}

		public int CustomerShar
		{
			get
			{
				return this._customershar;
			}
			set
			{
				this._customershar = value;
			}
		}

		public string EmailAdr
		{
			get
			{
				return this._emailadr;
			}
			set
			{
				this._emailadr = value;
			}
		}

		public string EmailLogName
		{
			get
			{
				return this._emaillogname;
			}
			set
			{
				this._emaillogname = value;
			}
		}

		public string EmailPwd
		{
			get
			{
				return this._emailpwd;
			}
			set
			{
				this._emailpwd = value;
			}
		}

		public string EmailServer
		{
			get
			{
				return this._emailserver;
			}
			set
			{
				this._emailserver = value;
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

		public int iRepair
		{
			get
			{
				return this._irepair;
			}
			set
			{
				this._irepair = value;
			}
		}

		public int LockMinutes
		{
			get
			{
				return this._lockminutes;
			}
			set
			{
				this._lockminutes = value;
			}
		}

		public int RecDueDay
		{
			get
			{
				return this._recdueday;
			}
			set
			{
				this._recdueday = value;
			}
		}

		public int ServicesDo
		{
			get
			{
				return this._servicesdo;
			}
			set
			{
				this._servicesdo = value;
			}
		}

		public string SmsCode
		{
			get
			{
				return this._smscode;
			}
			set
			{
				this._smscode = value;
			}
		}

		public int SndStyle
		{
			get
			{
				return this._sndstyle;
			}
			set
			{
				this._sndstyle = value;
			}
		}

		public string SysName
		{
			get
			{
				return this._sysname;
			}
			set
			{
				this._sysname = value;
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

		public string UserName
		{
			get
			{
				return this._username;
			}
			set
			{
				this._username = value;
			}
		}

		public string UserPwd
		{
			get
			{
				return this._userpwd;
			}
			set
			{
				this._userpwd = value;
			}
		}

		public int WarrantyCycle
		{
			get
			{
				return this._warrantycycle;
			}
			set
			{
				this._warrantycycle = value;
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

		public SysParmInfo()
		{
		}
	}
}