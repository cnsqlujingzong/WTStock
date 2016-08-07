<%@ WebHandler Language="C#" Class="CustomerAdd" %>

using System;
using System.Web;
using wt.Model;
using wt.DAL;
using wt.Library;
public class CustomerAdd : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {

        int operatorerId=-1;
     
        context.Response.ContentType = "text/plain";
        string deptId = context.Request.Form["deptId"];
        string operatorer = context.Request.Form["UserName"]; //受理人,登录的用户名
        string cusName = context.Request.Form["Name"];
        string linkMan = context.Request.Form["LinkMan"];
        string tel = context.Request.Form["Tel"];
        string adr = context.Request.Form["Adr"];
    
        //获取员工信息
        System.Data.DataTable dt = DALCommon.GetDataList("StaffList", "", " DeptID=" + deptId + "and _Name='" + operatorer+"'").Tables[0];
        if (dt.Rows.Count > 0)
        {
            operatorerId = int.Parse(dt.Rows[0]["ID"].ToString());
        }

        //开始添加主表数据
        DALCustomerList dalcus = new DALCustomerList();
        CustomerListInfo cusinfo = new CustomerListInfo();
        cusinfo.DeptID = int.Parse(deptId);
        cusinfo._Name = FunLibrary.ChkInput(cusName);
        cusinfo.pyCode = wt.Library.FunLibrary.CVT(FunLibrary.ChkInput(cusName));
       
        cusinfo.LinkMan = FunLibrary.ChkInput(linkMan);
        cusinfo.Tel = FunLibrary.ChkInput(tel);
        cusinfo.Adr = FunLibrary.ChkInput(adr);
       
        cusinfo.TrackOperatorID =operatorerId;
        cusinfo.OperatorID =operatorerId;
        
        string strMsg;
        int iTbid;
        int flag;
        flag = dalcus.Add(cusinfo, true, out strMsg, out iTbid);
        
        context.Response.Write(flag);
        context.Response.End();
        return;
        //End
        
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}