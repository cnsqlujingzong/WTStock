using System;

namespace wt.Model
{
	[Serializable]
	public class StockListInfo
	{
		private int _id;

		private int? _deptid;

		private string __name;

		private int? _stockadmid1;

		private int? _stockadmid2;

		private string _stocksite;

		private bool _breject;

		private bool _bstop;

		private string _remark;

		private string _otherstockadm;

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

		public bool bReject
		{
			get
			{
				return this._breject;
			}
			set
			{
				this._breject = value;
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

		public string OtherStockAdm
		{
			get
			{
				return this._otherstockadm;
			}
			set
			{
				this._otherstockadm = value;
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

		public int? StockAdmID1
		{
			get
			{
				return this._stockadmid1;
			}
			set
			{
				this._stockadmid1 = value;
			}
		}

		public int? StockAdmID2
		{
			get
			{
				return this._stockadmid2;
			}
			set
			{
				this._stockadmid2 = value;
			}
		}

		public string StockSite
		{
			get
			{
				return this._stocksite;
			}
			set
			{
				this._stocksite = value;
			}
		}

		public StockListInfo()
		{
		}
	}
}