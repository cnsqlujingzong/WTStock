using System;

namespace Model
{
	public class IPControlInfo
	{
		private string _startIP;

		private string _endIP;

		private int _id;

		public string EndIP
		{
			get
			{
				return this._endIP;
			}
			set
			{
				this._endIP = value;
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

		public string StartIP
		{
			get
			{
				return this._startIP;
			}
			set
			{
				this._startIP = value;
			}
		}

		public IPControlInfo()
		{
		}
	}
}