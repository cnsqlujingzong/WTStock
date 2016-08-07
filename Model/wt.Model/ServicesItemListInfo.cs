using System;

namespace wt.Model
{
	[Serializable]
	public class ServicesItemListInfo
	{
		private int _id;

		private string _itemno;

		private string __name;

		private decimal? _price;

		private decimal? _warrantyprice;

		private decimal? _tecdeduct;

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

		public string ItemNO
		{
			get
			{
				return this._itemno;
			}
			set
			{
				this._itemno = value;
			}
		}

		public decimal? Price
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

		public decimal? TecDeduct
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

		public decimal? WarrantyPrice
		{
			get
			{
				return this._warrantyprice;
			}
			set
			{
				this._warrantyprice = value;
			}
		}

		public ServicesItemListInfo()
		{
		}
	}
}