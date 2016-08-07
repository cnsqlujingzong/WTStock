using System;
using System.Collections.Generic;

namespace wt.Model
{
	[Serializable]
	public class BeginArrearageInfo
	{
		private List<BeginArrDetailInfo> _beginarrdetailinfos;

		public List<BeginArrDetailInfo> BeginArrDetailInfos
		{
			get
			{
				return this._beginarrdetailinfos;
			}
			set
			{
				this._beginarrdetailinfos = value;
			}
		}

		public BeginArrearageInfo()
		{
		}
	}
}