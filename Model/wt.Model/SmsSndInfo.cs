using System;

namespace wt.Model
{
	public class SmsSndInfo
	{
		private int _recid;

		private string _sndto;

		private string _content;

		private DateTime _sdate;

		private bool _sflag;

		private int _senderid;

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

		public int SenderID
		{
			get
			{
				return this._senderid;
			}
			set
			{
				this._senderid = value;
			}
		}

		public bool SFlag
		{
			get
			{
				return this._sflag;
			}
			set
			{
				this._sflag = value;
			}
		}

		public string SndTo
		{
			get
			{
				return this._sndto;
			}
			set
			{
				this._sndto = value;
			}
		}

		public SmsSndInfo()
		{
		}
	}
}