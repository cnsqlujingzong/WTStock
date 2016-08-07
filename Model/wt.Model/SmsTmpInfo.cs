using System;

namespace wt.Model
{
	public class SmsTmpInfo
	{
		private int _recid;

		private string _title;

		private string _content;

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

		public SmsTmpInfo()
		{
		}
	}
}