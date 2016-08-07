<%@ WebHandler Language="C#" Class="GetPosts" %>

using System;
using System.Web;
using System.Text;
using System.Data;

public class GetPosts : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        wt.DAL.DALOA_Annunciate bll = new wt.DAL.DALOA_Annunciate();
        StringBuilder strOut = new StringBuilder();
        string sNew;
        string sBranch = "Office/AnnView.aspx";
        DataSet ds = wt.DAL.DALCommon.GetDataList("OA_Annunciate","top 5 ID,Title,_Date", "1=1 order by id desc");
        if (context.Request["b"] != null)
        {
            if (context.Request["b"] == "2")
            {
                sBranch = "Office/AnnView.aspx";
            }
            else if (context.Request["b"] == "3")
            {
                sBranch = "Web/Posts.aspx";
            }
        }
        for (int i = ds.Tables[0].Rows.Count - 1; i > - 1; i--)
        {
            if (wt.Library.FunLibrary.GetTimeSpanByDay(ds.Tables[0].Rows[i]["_Date"].ToString(), DateTime.Now.ToString()) <= 3)
                sNew = "<img src=\"../../Public/Images/new.gif\" />";
            else
                sNew = "";
            strOut.Append(string.Format("<a target='_blank' href='../{3}?id={0}'>{2}</a>{1}", ds.Tables[0].Rows[i]["ID"].ToString(), sNew, ds.Tables[0].Rows[i]["title"].ToString(), sBranch));
        }
        if (strOut.Length == 0)
        {
            strOut.Append("0");
        }
        context.Response.Write(strOut.ToString());
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}