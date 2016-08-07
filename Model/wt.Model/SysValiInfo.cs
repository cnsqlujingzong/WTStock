using System;

namespace wt.Model
{
	public class SysValiInfo
	{
		private int _recid;

		private string _s_item;

		private string _s_value;

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

		public string S_Item
		{
			get
			{
				return this._s_item;
			}
			set
			{
				this._s_item = value;
			}
		}

		public string S_Value
		{
			get
			{
				return this._s_value;
			}
			set
			{
				this._s_value = value;
			}
		}

		public SysValiInfo()
		{
		}
	}
}