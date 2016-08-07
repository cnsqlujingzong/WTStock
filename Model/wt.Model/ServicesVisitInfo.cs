using System;
using System.Collections.Generic;

namespace wt.Model
{
	public class ServicesVisitInfo
	{
		private int _id;

		private int _billid;

		private string __date;

		private int _operatorid;

		private string _cusname;

		private string _opinion;

		private int _visitstyleid;

		private string _remark;

		private decimal _score;

		private List<ServicesVisitResultInfo> _servicesvisitresultinfos;

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

		public string CusName
		{
			get
			{
				return this._cusname;
			}
			set
			{
				this._cusname = value;
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

		public string Opinion
		{
			get
			{
				return this._opinion;
			}
			set
			{
				this._opinion = value;
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

		public decimal Score
		{
			get
			{
				return this._score;
			}
			set
			{
				this._score = value;
			}
		}

		public List<ServicesVisitResultInfo> ServicesVisitResultInfos
		{
			get
			{
				return this._servicesvisitresultinfos;
			}
			set
			{
				this._servicesvisitresultinfos = value;
			}
		}

		public int VisitStyleID
		{
			get
			{
				return this._visitstyleid;
			}
			set
			{
				this._visitstyleid = value;
			}
		}

		public ServicesVisitInfo()
		{
		}
	}
}