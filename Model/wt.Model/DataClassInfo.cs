using System;

namespace wt.Model
{
	[Serializable]
	public class DataClassInfo
	{
		private int _id;

		private string __name;

		private int? _father;

		private string __level;

		private int _array;

		public string _Level
		{
			get
			{
				return this.__level;
			}
			set
			{
				this.__level = value;
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

		public int? Father
		{
			get
			{
				return this._father;
			}
			set
			{
				this._father = value;
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

		public DataClassInfo()
		{
		}
	}
}