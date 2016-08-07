using System;

namespace wt.Model
{
	public class OA_MailAccessoryInfo
	{
		private int _id;

		private int? _mailid;

		private string _filepath;

		public string FilePath
		{
			get
			{
				return this._filepath;
			}
			set
			{
				this._filepath = value;
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

		public int? MailID
		{
			get
			{
				return this._mailid;
			}
			set
			{
				this._mailid = value;
			}
		}

		public OA_MailAccessoryInfo()
		{
		}
	}
}