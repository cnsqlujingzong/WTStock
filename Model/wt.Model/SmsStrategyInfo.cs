using System;

namespace wt.Model
{
	public class SmsStrategyInfo
	{
		private int _recid;

		private string _sndtiming;

		private string _smstmp;

		public int RecID
		{
			get
			{
				return this._recid;
			}
			set
			{
				this._recid = value;
			}
		}

		public string SmsTmp
		{
			get
			{
				return this._smstmp;
			}
			set
			{
				this._smstmp = value;
			}
		}

		public string SndTiming
		{
			get
			{
				return this._sndtiming;
			}
			set
			{
				this._sndtiming = value;
			}
		}

		public SmsStrategyInfo()
		{
		}
	}
}