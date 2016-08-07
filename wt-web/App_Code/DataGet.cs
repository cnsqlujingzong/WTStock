using System;
using System.Data;
using System.Web.Services;
using wt.DAL;

[WebService(Namespace = "http://tempuri.org/"), WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class DataGet : WebService
{
	[WebMethod]
	public DataSet TelGet(string User, string Pwd)
	{
		return DALCommon.GetDataList("SysParm", "", "");
	}
}
