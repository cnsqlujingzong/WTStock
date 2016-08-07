using System;

namespace wt.Model
{
	[Serializable]
	public class ProductModelInfo
	{
		private int _id;

		private int? _classid;

		private int? _brandid;

		private string __name;

		private int? _period;

		private string _pycode;

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

		public int? BrandID
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

		public int? ClassID
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

		public int? Period
		{
			get
			{
				return this._period;
			}
			set
			{
				this._period = value;
			}
		}

		public string pyCode
		{
			get
			{
				return this._pycode;
			}
			set
			{
				this._pycode = value;
			}
		}

		public ProductModelInfo()
		{
		}
	}
}