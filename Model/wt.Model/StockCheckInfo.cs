using System;
using System.Collections.Generic;

namespace wt.Model
{
	public class StockCheckInfo
	{
		private int _id;

		private string _remark;

		private string _billid;

		private int _deptid;

		private string __date;

		private int _operatorid;

		private int _stockid;

		private DateTime _chkdate;

		private int _chkoperatorid;

		private int _status;

		private List<StockCheckDetailInfo> _stockcheckdetailinfos;

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

		public DateTime ChkDate
		{
			get
			{
				return this._chkdate;
			}
			set
			{
				this._chkdate = value;
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

		public int DeptID
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

		public int Status
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

		public List<StockCheckDetailInfo> StockCheckDetailInfos
		{
			get
			{
				return this._stockcheckdetailinfos;
			}
			set
			{
				this._stockcheckdetailinfos = value;
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

		public StockCheckInfo()
		{
		}
	}
}