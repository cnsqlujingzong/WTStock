<%@ WebHandler Language="C#" Class="modprohdl" %>

using System;
using System.Web;

public class modprohdl : IHttpHandler {
    Coding.Stock.DAL.Cd_ProTypeAttr bll = new Coding.Stock.DAL.Cd_ProTypeAttr();
    Coding.Stock.DAL.Cd_productType bll2 = new Coding.Stock.DAL.Cd_productType();
    Coding.Stock.DAL.Cd_ProAtts bll3 = new Coding.Stock.DAL.Cd_ProAtts();
    System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        // modpro.aspx?id=18&&tid=1
        string id = context.Request.Params["id"];
        string tid = context.Request.Params["tid"];
        try
        {
            System.Data.DataTable proTypeAttr = bll.GetList(" ProTypeID=" + tid).Tables[0];
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            System.Collections.Generic.Dictionary<string, string> map = new System.Collections.Generic.Dictionary<string, string>();

            sb.Append(" select top 1  ID ");
            for (int i = 0; i < proTypeAttr.Rows.Count; i++)
            {
                map.Add(proTypeAttr.Rows[i]["AttName"].ToString(), proTypeAttr.Rows[i]["DisplayAttrName"].ToString());
                sb.Append("," + proTypeAttr.Rows[i]["AttName"].ToString());

            }
            sb.Append(" from Cd_ProAtts where ID=" + id);
            System.Data.DataTable dt = bll3.GetListBysql(sb.ToString()).Tables[0];
            System.Collections.Generic.List<modProModel> list = new System.Collections.Generic.List<modProModel>();
            modProModel m;
            if (dt.Rows.Count > 0)
            {
                foreach (System.Collections.Generic.KeyValuePair<string, string> kvp in map)
                {
                    m =  new modProModel(); 
                    m.attName = kvp.Key;
                    m.attDisName = kvp.Value;
                    m.value = dt.Rows[0][kvp.Key] == null ? "" : dt.Rows[0][kvp.Key].ToString();
                    list.Add(m);
                }
                context.Response.Write(jss.Serialize( new { r = true, d = jss.Serialize(list) }));
            }
            else
            {
                context.Response.Write(jss.Serialize( new { r = false, d = "没有数据" }));
            }
        }
        catch (Exception e){
            context.Response.Write(jss.Serialize(new { r = false, d = e.Message }));
        }
        

       
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
public class modProModel 
{
    public string  attName { get; set; }
    public string  attDisName { get; set; }
    public string value { get; set; }
}