<%@ WebHandler Language="C#" Class="GetHasConfig" %>

using System;
using System.Web;
using System.Text;
using System.Collections;
using System.Collections.Generic;
public class GetHasConfig : IHttpHandler {
    Coding.Stock.DAL.Cd_ProTypeAttr dal = new Coding.Stock.DAL.Cd_ProTypeAttr();
    System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        string id=context.Request.Params["id"];
        if (string.IsNullOrEmpty(id))
        {
            context.Response.Write("{\"r\":false,\"msg\":\"id 为空！\"}");
        }
        else
        {
            System.Data.DataTable exists = dal.GetList(" ProTypeID=" + id).Tables[0];
            List<object> list = new List<object>();
            for (int i = 0; i < exists.Rows.Count;i++ )
            {
                list.Add(new { AttName = exists.Rows[i]["AttName"].ToString(), AttDisplay = exists.Rows[i]["DisplayAttrName"].ToString(), AttOB = exists.Rows[i]["Orderby"].ToString() });
            }

            context.Response.Write(jss.Serialize(new { r = true, msg = jss.Serialize(list) }));//"{\"r\":true,\"msg\":\""++"\"}"
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}