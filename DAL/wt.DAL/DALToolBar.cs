using System;
using System.Collections.Generic;
using wt.DB;

namespace wt.DAL
{
	public class DALToolBar
	{
		public int Update(List<string[]> StrParameters, List<string[]> strdellist, out string strMsg)
		{
			return DbHelperSQL.UpdateProcedureTran(StrParameters, strdellist, out strMsg);
		}
	}
}
