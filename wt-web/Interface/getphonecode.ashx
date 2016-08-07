<%@ WebHandler Language="C#" Class="GetPhoneCode" %>

using System;
using System.Web;
using System.Web.SessionState;

public class GetPhoneCode : IHttpHandler,IRequiresSessionState {
    
    public void ProcessRequest (HttpContext context) {
        string username = context.Request["username"];
        string branch = context.Request["branch"];
        int deptid = 0;
        if (!int.TryParse(branch, out deptid))
        {
            context.Response.Write("参数错误");
            return;
        }
        
        string validPhoneNum = "^0{0,1}(13[0-9]|15[3-9]|15[0-2]|18[0-9])[0-9]{8}$";
        wt.DAL.DALStaffList dalstaff = new wt.DAL.DALStaffList();
        string phoneNum = dalstaff.getPhoneNum(username, deptid);
        if (phoneNum == "")
        {
            context.Response.Write("该用户名未填写手机号，请联系管理员");
            return;
        }
        System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(validPhoneNum);
        if (!reg.IsMatch(phoneNum))
        {
            context.Response.Write("该用户手机号码不正确，请联系管理员");
            return;
        }

        Random rand = new Random();
        int validCode = rand.Next(100000, 999999);
        context.Session.Add(username, validCode);
        
        wt.DAL.DALSmsSnd dalsms = new wt.DAL.DALSmsSnd();
        wt.Model.SmsSndInfo model = new wt.Model.SmsSndInfo();
        model.SndTo = phoneNum;
        model.Content = "维通.net软件登录验证码：" + validCode.ToString();
        model.SDate = DateTime.Now;
        model.SFlag = false;
        int flag = dalsms.Add(model);
        if (flag == 0)
            context.Response.Write("系统错误,验证码发送失败");
        else
            context.Response.Write("验证码发送成功，请注意查收");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}