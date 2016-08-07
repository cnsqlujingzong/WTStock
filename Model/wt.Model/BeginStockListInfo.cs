using System;
using System.Collections.Generic;

namespace wt.Model
{
	[Serializable]
	public class BeginStockListInfo
	{
		private List<BeginStockInfo> _beginstockinfos;

		public List<BeginStockInfo> BeginStockInfos
		{
			get
			{
				return this._beginstockinfos;
			}
			set
			{
				this._beginstockinfos = value;
			}
		}

		public BeginStockListInfo()
		{
		}
	}
}