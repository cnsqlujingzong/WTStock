using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF
{
   public class WTLog
    {
 
      public static Coding.Stock.DAL.WTLog bll = new Coding.Stock.DAL.WTLog();
       public static void WriteLog(string source, string billID,string opt,string decribe="",string common="")
       {
           	//.Session["Session_wtUser"] = text;
				//this.Session["Session_wtUserID"] = userManageInfo.StaffID.ToString();
           Coding.Stock.Model.WTLog log = new Coding.Stock.Model.WTLog();
           log.source = source;
           log.personID = System.Web.HttpContext.Current.Session["Session_wtUserID"] == null ? "-1" : System.Web.HttpContext.Current.Session["Session_wtUserID"].ToString();
           log.person = System.Web.HttpContext.Current.Session["Session_wtUser"] == null ? "离线用户" : System.Web.HttpContext.Current.Session["Session_wtUser"].ToString();
           log.logtime = DateTime.Now;
           log.Dtime = DateTime.Now;
           log.Dtime2 = DateTime.Now;
           log.decribe = decribe;
           log.common = common;
           log.BillID = billID;
           log.opt = opt;
           log.Att1 = "";
           log.Att2 = "";
           bll.Add(log);       
       }
    }
}
