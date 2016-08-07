using System;

namespace wt.Model
{
	public class SmsRcvInfo
	{
		private int _recid;

		private string _sndfrom;

		private string _content;

		private DateTime _sdate;

		public string Content
		{
			get
			{
				return this._content;
			}
			set
			{
				this._content = value;
			}
		}

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

		public DateTime SDate
		{
			get
			{
				return this._sdate;
			}
			set
			{
				this._sdate = value;
			}
		}

		public string SndFrom
		{
			get
			{
				return this._sndfrom;
			}
			set
			{
				this._sndfrom = value;
			}
		}

		public SmsRcvInfo()
		{
		}
	}
}