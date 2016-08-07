using System;
using System.Collections.Generic;

namespace wt.Model
{
	public class LayoutDetailInfo
	{
		private List<LayoutDetailInfos> _layoutdetailinfoss;

		public List<LayoutDetailInfos> LayoutDetailInfoss
		{
			get
			{
				return this._layoutdetailinfoss;
			}
			set
			{
				this._layoutdetailinfoss = value;
			}
		}

		public LayoutDetailInfo()
		{
		}
	}
}