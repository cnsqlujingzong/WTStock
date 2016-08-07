using System;

namespace wt.Model
{
	public class ExtendedSetInfo
	{
		private int _id;

		private int _brandid;

		private int _classid;

		private decimal _dpoint;

		public int BrandID
		{
			get
			{
				return this._brandid;
			}
			set
			{
				this._brandid = value;
			}
		}

		public int ClassID
		{
			get
			{
				return this._classid;
			}
			set
			{
				this._classid = value;
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

		public ExtendedSetInfo()
		{
		}
	}
}