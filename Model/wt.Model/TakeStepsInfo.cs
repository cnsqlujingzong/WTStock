using System;

namespace wt.Model
{
	public class TakeStepsInfo
	{
		private int _id;

		private int? _troubleid;

		private string _summary;

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

		public string Summary
		{
			get
			{
				return this._summary;
			}
			set
			{
				this._summary = value;
			}
		}

		public int? TroubleID
		{
			get
			{
				return this._troubleid;
			}
			set
			{
				this._troubleid = value;
			}
		}

		public TakeStepsInfo()
		{
		}
	}
}