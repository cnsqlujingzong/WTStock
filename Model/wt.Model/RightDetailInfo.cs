using System;

namespace wt.Model
{
	public class RightDetailInfo
	{
		private int _id;

		private int _rightid;

		private string _rightcode;

		private bool _bvalue;

		public bool bValue
		{
			get
			{
				return this._bvalue;
			}
			set
			{
				this._bvalue = value;
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

		public string RightCode
		{
			get
			{
				return this._rightcode;
			}
			set
			{
				this._rightcode = value;
			}
		}

		public int RightID
		{
			get
			{
				return this._rightid;
			}
			set
			{
				this._rightid = value;
			}
		}

		public RightDetailInfo()
		{
		}
	}
}