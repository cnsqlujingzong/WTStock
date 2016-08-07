using System;

namespace wt.Model
{
	[Serializable]
	public class PriceAdjust
	{
		public int _goodsadjustconfigid;

		public bool _selectflag;

		public string _pricename1;

		public string _pricename2;

		public string _separator;

		public decimal _price;

		public string _formula;

		public string Formula
		{
			get
			{
				return this._formula;
			}
			set
			{
				this._formula = value;
			}
		}

		public int Godsadjustconfigid
		{
			get
			{
				return this._goodsadjustconfigid;
			}
			set
			{
				this._goodsadjustconfigid = value;
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

		public string Pricename1
		{
			get
			{
				return this._pricename1;
			}
			set
			{
				this._pricename1 = value;
			}
		}

		public string Pricename2
		{
			get
			{
				return this._pricename2;
			}
			set
			{
				this._pricename2 = value;
			}
		}

		public bool Selectflag
		{
			get
			{
				return this._selectflag;
			}
			set
			{
				this._selectflag = value;
			}
		}

		public string Separator
		{
			get
			{
				return this._separator;
			}
			set
			{
				this._separator = value;
			}
		}

		public PriceAdjust()
		{
		}
	}
}