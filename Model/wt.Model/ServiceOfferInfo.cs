using System;

namespace wt.Model
{
	public class ServiceOfferInfo
	{
		private int _id;

		private int _billid;

		private string __date;

		private int _operatorid;

		private int _sellerid;

		private int _itemid;

		private decimal _damount;

		private bool _bcusconf;

		private string _remark;

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

		public bool bCusConf
		{
			get
			{
				return this._bcusconf;
			}
			set
			{
				this._bcusconf = value;
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

		public decimal dAmount
		{
			get
			{
				return this._damount;
			}
			set
			{
				this._damount = value;
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

		public int ItemID
		{
			get
			{
				return this._itemid;
			}
			set
			{
				this._itemid = value;
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

		public int SellerID
		{
			get
			{
				return this._sellerid;
			}
			set
			{
				this._sellerid = value;
			}
		}

		public ServiceOfferInfo()
		{
		}
	}
}