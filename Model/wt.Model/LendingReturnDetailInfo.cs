using System;

namespace wt.Model
{
	[Serializable]
	public class LendingReturnDetailInfo
	{
		private int _id;

		private int _billid;

		private int _goodsid;

		private int _unitid;

		private decimal _qty = new decimal(0);

		private string _sn = "";

		private string _remark = "";

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

		public int GoodsID
		{
			get
			{
				return this._goodsid;
			}
			set
			{
				this._goodsid = value;
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

		public decimal Qty
		{
			get
			{
				return this._qty;
			}
			set
			{
				this._qty = value;
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

		public string SN
		{
			get
			{
				return this._sn;
			}
			set
			{
				this._sn = value;
			}
		}

		public int UnitID
		{
			get
			{
				return this._unitid;
			}
			set
			{
				this._unitid = value;
			}
		}

		public LendingReturnDetailInfo()
		{
		}
	}
}