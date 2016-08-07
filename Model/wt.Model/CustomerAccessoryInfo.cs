using System;

namespace wt.Model
{
	public class CustomerAccessoryInfo
	{
		private int _id;

		private int _customerid;

		private string __name;

		private DateTime __date;

		private int _operatorid;

		private string _path;

		private string _remark;

		public DateTime _Date
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

		public int CustomerID
		{
			get
			{
				return this._customerid;
			}
			set
			{
				this._customerid = value;
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

		public string Path
		{
			get
			{
				return this._path;
			}
			set
			{
				this._path = value;
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

		public CustomerAccessoryInfo()
		{
		}
	}
}