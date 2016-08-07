using System;

namespace wt.Model
{
	public class ServicesTypeInfo
	{
		private int _id;

		private string __name;

		private bool _bcall;

		private string _pycode;

		private int _array;

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

		public int Array
		{
			get
			{
				return this._array;
			}
			set
			{
				this._array = value;
			}
		}

		public bool bCall
		{
			get
			{
				return this._bcall;
			}
			set
			{
				this._bcall = value;
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

		public ServicesTypeInfo()
		{
		}
	}
}