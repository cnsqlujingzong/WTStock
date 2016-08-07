using System;
using System.Collections.Generic;

namespace wt.Model
{
	public class OA_EmailInfo
	{
		private int _id;

		private int? _brcvflag;

		private string __date;

		private int? _sndid;

		private int? _rcvid;

		private string _title;

		private string _content;

		private bool _bread;

		private bool _baccessory;

		private int? _bsndflag;

		private string _snd;

		private string _rcv;

		private List<OA_MailAccessoryInfo> _oa_mailaccessoryinfos;

		public string _Date
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

		public bool bAccessory
		{
			get
			{
				return this._baccessory;
			}
			set
			{
				this._baccessory = value;
			}
		}

		public int? bRcvFlag
		{
			get
			{
				return this._brcvflag;
			}
			set
			{
				this._brcvflag = value;
			}
		}

		public bool bRead
		{
			get
			{
				return this._bread;
			}
			set
			{
				this._bread = value;
			}
		}

		public int? bSndFlag
		{
			get
			{
				return this._bsndflag;
			}
			set
			{
				this._bsndflag = value;
			}
		}

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

		public List<OA_MailAccessoryInfo> OA_MailAccessoryInfos
		{
			get
			{
				return this._oa_mailaccessoryinfos;
			}
			set
			{
				this._oa_mailaccessoryinfos = value;
			}
		}

		public string Rcv
		{
			get
			{
				return this._rcv;
			}
			set
			{
				this._rcv = value;
			}
		}

		public int? RcvID
		{
			get
			{
				return this._rcvid;
			}
			set
			{
				this._rcvid = value;
			}
		}

		public string Snd
		{
			get
			{
				return this._snd;
			}
			set
			{
				this._snd = value;
			}
		}

		public int? SndID
		{
			get
			{
				return this._sndid;
			}
			set
			{
				this._sndid = value;
			}
		}

		public string Title
		{
			get
			{
				return this._title;
			}
			set
			{
				this._title = value;
			}
		}

		public OA_EmailInfo()
		{
		}
	}
}