<%@ WebHandler Language="C#" Class="SetSignIn" %>

using System;
using System.Web;

/// <summary>
/// 定位上传
/// </summary>
public class SetSignIn : IHttpHandler
{
    public void ProcessRequest (HttpContext context) {
        int dept = 0;
        int.TryParse(context.Request["deptId"], out dept);
        string username = context.Request["username"];
        int userid = 0;
        int.TryParse(context.Request["userid"],out userid);
        string pwd = context.Request["pwd"];

        string longitude = context.Request["longitude"];//经度
        string latitude = context.Request["latitude"];//纬度

        //判断标签
        if (string.IsNullOrEmpty(pwd) || dept == 0 || string.IsNullOrEmpty(username)  || string.IsNullOrEmpty(longitude) || string.IsNullOrEmpty(latitude))
        {
            context.Response.Write("-1");//返回-1 参数不正确
            context.Response.End();
        }
  
        //判断用户是否存在
        wt.DAL.DALUserManage daluser = new wt.DAL.DALUserManage();
        wt.Model.UserManageInfo useinfo = daluser.Login(userid);
        if (useinfo == null)
        {
            context.Response.Write("-1");//返回-1 不存在该用户
            context.Response.End();
        }
        else if (pwd.ToUpper() != useinfo.Pwd)
        {
            context.Response.Write("-1");//返回-1 密码错误
            context.Response.End();
        }
        else if (useinfo.Status != "正常")
        {
            context.Response.Write("-1");//返回-1 该用户状态异常
            context.Response.End();
        }
        wt.DAL.DALCoordinates dalcoor = new wt.DAL.DALCoordinates();
        wt.Model.CoordinatesInfo coor = new wt.Model.CoordinatesInfo();
        coor.StaffID = useinfo.StaffID;
        coor.StaffName = username;
        coor.DeptID = useinfo.DeptID;
        coor.CreateTime = DateTime.Now;
        coor.Coordinate = longitude + "," + latitude;

        int flag = dalcoor.InsertData(coor);
        if (flag == 1)
        {
            context.Response.Write("1");
            context.Response.End();
        }
        else
        {
            context.Response.Write("0");//返回0 内部错误，数据插入错误
            context.Response.End();            
        }
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}