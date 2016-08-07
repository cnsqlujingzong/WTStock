using System;

namespace wt.Model
{
	public class DisMountingInfo
	{
		private int _id;

		private int _dismountingid;

		private int _goodsid;

		private decimal _qty;

		public int DisMountingID
		{
			get
			{
				return this._dismountingid;
			}
			set
			{
				this._dismountingid = value;
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

		public DisMountingInfo()
		{
		}
	}
}