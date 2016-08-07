using System;

namespace wt.Model
{
	public class ServicesItemInfo
	{
		private int _id;

		private int _billid;

		private int _itemid;

		private decimal _price;

		private decimal _dpoint;

		private string _tec;

		private string _chargestyle;

		private decimal _tecdeduct;

		private string _remark;

		private bool _bcomplete;

		public bool bComplete
		{
			get
			{
				return this._bcomplete;
			}
			set
			{
				this._bcomplete = value;
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

		public string ChargeStyle
		{
			get
			{
				return this._chargestyle;
			}
			set
			{
				this._chargestyle = value;
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

		public decimal Price
		{
			get
			{
				return this._price;
			}
			set
			{
				this._price = value;
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

		public string Tec
		{
			get
			{
				return this._tec;
			}
			set
			{
				this._tec = value;
			}
		}

		public decimal TecDeduct
		{
			get
			{
				return this._tecdeduct;
			}
			set
			{
				this._tecdeduct = value;
			}
		}

		public ServicesItemInfo()
		{
		}
	}
}