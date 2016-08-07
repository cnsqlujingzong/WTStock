using System;

namespace wt.Model
{
	public class VisitResultInfo
	{
		private int _id;

		private int _contentid;

		private string _result;

		private decimal _rewards;

		private string _remark;

		public int ContentID
		{
			get
			{
				return this._contentid;
			}
			set
			{
				this._contentid = value;
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

		public string Result
		{
			get
			{
				return this._result;
			}
			set
			{
				this._result = value;
			}
		}

		public decimal Rewards
		{
			get
			{
				return this._rewards;
			}
			set
			{
				this._rewards = value;
			}
		}

		public VisitResultInfo()
		{
		}
	}
}