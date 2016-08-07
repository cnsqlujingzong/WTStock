<%@ WebHandler Language="C#" Class="GetTecList" %>

using System;
using System.Web;
using wt.DAL;
using System.Data;
using System.Text;
using Newtonsoft.Json.Converters;

public class GetTecList : IHttpHandler
{
    /// <summary>
    /// 获取技术员列表
    /// </summary>
    /// <param name="context"></param>
    public void ProcessRequest(HttpContext context)
    {
        string sign = context.Request["sign"];
        int pageNum = 0;
        int.TryParse(context.Request["pageNum"], out pageNum);
        int deptId = 0;//网点id
        int.TryParse(context.Request["deptid"], out deptId);
        string key = context.Request["key"];
        int userid = 0;
        int.TryParse(context.Request["userid"], out userid);
        string pwd = context.Request["pwd"];
  
        
        //判断标签
        if (string.IsNullOrEmpty(sign) || deptId == 0 ||userid==0 || string.IsNullOrEmpty(pwd))
        {
            context.Response.Write("{\"result\":-1}");//返回-1 参数不正确
            context.Response.End();
        }
        string ssign =StringMD5("wtit88223309").ToString().ToLower();
        if (sign.ToLower() != ssign)
        {
            context.Response.Write("{\"result\":-1}");//返回-1 签名错误
            context.Response.End();
        }
        //操作
        string result = FillData(pageNum, deptId, key, userid, pwd);
        context.Response.Write(result);
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }


    protected string FillData(int pageNum, int deptId, string key, int userid, string pwd)
    {
        int count = 0;
        string strJson="";
        string strp = strParm(deptId, key);
        string stro = "ID Desc";
        DataTable dt = DALCommon.GetList_HL(1, "jc_staff", "ID,_Name,JobNO", 200, pageNum, strp, stro, out count).Tables[0];
        if (dt.Rows.Count > 0)
        {
            strJson = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
        }
        else
        {
            strJson = "0";
        }
        strJson = "{\"result\":" + strJson + "}";
        return strJson;
    }


    /// <summary>
    /// 查询条件
    /// </summary>
    /// <returns></returns>
    protected string strParm(int deptId, string key)
    {
        string strParm = " DeptID=" + deptId + " and bTechnician='√' and Status='在职' ";
        string str = wt.Library.FunLibrary.ChkInput(key);
        if (str != "")
        {
            strParm += " and (_Name like '%" + str + "%' or JobNO like '%" + str + "%')";
        }
        return strParm;
    }

    /// <summary>
    /// 字符窜32位md5加密
    /// </summary>
    /// <param name="myStr"></param>
    /// <returns></returns>
    public static string StringMD5(string str)
    {
        return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower();
    }

}