using System;
using System.Collections.Generic;

namespace wt.Model
{
	public class LeaseChargeInfo
	{
		private int _id;

		private int _billid;

		private string __date;

		private int _operatorid;

		private string _startdate;

		private string _enddate;

		private decimal _cycle;

		private decimal _superzhangfee;

		private decimal _drec;

		private int _status;

		private string _remark;

		private decimal _rent;

		private int _shangqty;

		private int _benqty;

		private int _loss;

		private List<LeaseChargeDetailInfo> _leasechargedetailinfos;

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

		public int BenQty
		{
			get
			{
				return this._benqty;
			}
			set
			{
				this._benqty = value;
			}
		}

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

		public decimal Cycle
		{
			get
			{
				return this._cycle;
			}
			set
			{
				this._cycle = value;
			}
		}

		public decimal dRec
		{
			get
			{
				return this._drec;
			}
			set
			{
				this._drec = value;
			}
		}

		public string EndDate
		{
			get
			{
				return this._enddate;
			}
			set
			{
				this._enddate = value;
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

		public List<LeaseChargeDetailInfo> LeaseChargeDetailInfos
		{
			get
			{
				return this._leasechargedetailinfos;
			}
			set
			{
				this._leasechargedetailinfos = value;
			}
		}

		public int Loss
		{
			get
			{
				return this._loss;
			}
			set
			{
				this._loss = value;
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

		public decimal Rent
		{
			get
			{
				return this._rent;
			}
			set
			{
				this._rent = value;
			}
		}

		public int ShangQty
		{
			get
			{
				return this._shangqty;
			}
			set
			{
				this._shangqty = value;
			}
		}

		public string StartDate
		{
			get
			{
				return this._startdate;
			}
			set
			{
				this._startdate = value;
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

		public decimal SuperZhangFee
		{
			get
			{
				return this._superzhangfee;
			}
			set
			{
				this._superzhangfee = value;
			}
		}

		public LeaseChargeInfo()
		{
		}
	}
}