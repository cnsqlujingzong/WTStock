using System;

namespace wt.Model
{
	public class CustomerMembersInfo
	{
		private int _id;

		private string __name;

		private string _price;

		private decimal _dis;

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

		public decimal Dis
		{
			get
			{
				return this._dis;
			}
			set
			{
				this._dis = value;
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

		public string Price
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

		public CustomerMembersInfo()
		{
		}
	}
}