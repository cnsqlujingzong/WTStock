<%@ WebHandler Language="C#" Class="Prohx" %>

using System;
using System.Web;
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
public class Prohx : IHttpHandler {
      Coding.Stock.DAL.Cd_ProTypeAttr dal = new Coding.Stock.DAL.Cd_ProTypeAttr();
      JavaScriptSerializer jss = new JavaScriptSerializer();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string prams = context.Request.Params["prams"];

        try
        {
            ProAttrModel m = jss.Deserialize<ProAttrModel>(prams);
            //if (dal.Exists(m.proTypeID))
            // {
            //   context.Response.Write("{\"r\":false,\"msg\":\"该产品配置已经存在，只能修改\"}");
            // }
            DataTable exists = dal.GetList(" ProTypeID=" + m.proTypeID).Tables[0];
            Coding.Stock.Model.Cd_ProTypeAttr att;
            foreach (ProAttr item in m.AttrList)
            {
                att = dal.GetModel(" ProTypeID=" + m.proTypeID + " and AttName='" + item.AttrName + "'");
                if (att == null)
                {
                    att = new Coding.Stock.Model.Cd_ProTypeAttr();
                    att.AttName = item.AttrName;
                    att.DisplayAttrName = item.AttrDisplay;
                    att.Orderby = Convert.ToInt32(item.AttrOderBy);
                    att.ProTypeID = m.proTypeID;
                    dal.Add(att);
                }
                else
                {
                    att.DisplayAttrName = item.AttrDisplay;
                    att.Orderby = Convert.ToInt32(item.AttrOderBy);
                    dal.Update(att);
                }
            }
            foreach (DataRow item in exists.Rows)
            {
                bool ishas = false;
                foreach (ProAttr nitem in m.AttrList)
                {
                    if (item["AttName"].ToString() == nitem.AttrName)
                    {
                        ishas = true;
                    }
                }
                if (!ishas)
                {
                    dal.Delete(Convert.ToInt32(item["ID"]));
                }
            }
            context.Response.Write("{\"r\":true,\"msg\":\"ok\"}");
        }
        catch (Exception e)
        {
            context.Response.Write("{\"r\":false,\"msg\":\""+e.Message+"\"}");
        }
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
public class ProAttrModel 
{
    public int proTypeID { get; set; }
    public List<ProAttr> AttrList { get; set; }
}
public class ProAttr{
    public string AttrName{get;set;}
    public string AttrDisplay{get;set;}
    public string AttrOderBy{get;set;}
}
/*****
 * 
 * 
 * 
 * {"proTypeID":"1","AttrList":[{"AttrName":"A100_1","AttrDisplay":"颜色","AttrOderBy":"1"},{"AttrName":"A100_2","AttrDisplay":"型号","AttrOderBy":"3"}]}
 * 
 * 
 * 
 * 
 * 
 * 
 * **/