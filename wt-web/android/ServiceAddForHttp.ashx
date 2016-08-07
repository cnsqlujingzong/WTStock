<%@ WebHandler Language="C#" Class="ServiceAddForHttp" %>

using System;
using System.Web;
using wt.Model;
using wt.DAL;
using System.Drawing;
using System.IO;
public class ServiceAddForHttp : IHttpHandler {

    /// <summary>
    /// 开单
    /// </summary>
    /// <param name="context"></param>
    public void ProcessRequest(HttpContext context)
    {
        int operatorerId = -1;
        //System.Web.HttpContext.Current.Session["Session_wtUserID"] = operatorerId; //给错误日志方法一个session
        ServicesInfo servicesInfoss = new ServicesInfo();
        DALServices dalServices = new DALServices();

        context.Response.ContentType = "text/plain;charset=UTF-8";

        int deptId = 0;
        int.TryParse(context.Request.Form["deptId"], out deptId);//当前的网点id

        string operatorer = context.Request.Form["Operator"]; //受理人,登录的用户名
        string typeId = context.Request.Form["TypeHd"]; //服务类别id
        string takeStyleId = context.Request.Form["TakeStyleHd"];//受理方式id
        string brandId = context.Request.Form["BrandHd"];  //品牌id
        string repStatusId = context.Request.Form["RepStatusHd"];//保修情况id
        string cusName = context.Request.Form["CusName"];
        string cusNameId = context.Request.Form["CusNameHd"];
        string deviceNO = context.Request.Form["DeviceNO"];
        string SN1 = context.Request.Form["SN1"];
        string tel = context.Request.Form["Tel"];
        string adr = context.Request.Form["Adr"];
        string fault = context.Request.Form["Fault"];
        int userid = 0;
        int.TryParse(context.Request.Form["userid"], out userid);
        string pwd = context.Request.Form["pwd"];


        if (userid == 0 || string.IsNullOrEmpty(pwd))
        {
            context.Response.Write("{\"result\":-1}");//返回-1 参数不正确
            context.Response.End();
        }

        //判断用户是否存在
        wt.DAL.DALUserManage daluser = new wt.DAL.DALUserManage();
        wt.Model.UserManageInfo userinfo = daluser.Login(userid);
        if (userinfo == null)
        {
            context.Response.Write("-1");//返回-1 参数不正确
            context.Response.End();
        }
        if (pwd.ToUpper() != userinfo.Pwd.ToUpper() || userinfo.Status != "正常" || userinfo.DeptID != deptId)
        {
            context.Response.Write("-1");//返回-1 参数不正确
            context.Response.End();
        }
        
        //获取员工信息
        operatorerId = userinfo.StaffID;

        string strsn = wt.Library.FunLibrary.ChkInput(SN1);
        string strno = wt.Library.FunLibrary.ChkInput(deviceNO);
        if (strsn != "")
        {
            System.Data.DataTable dtsn = DALCommon.GetDataList("ServicesList", "[ID]", " CustomerID=" + cusNameId + " and ProductSN1='" + strsn + "' and (curStatus='待处理' or curStatus='处理中')").Tables[0];
            if (dtsn.Rows.Count > 0)
            {
                context.Response.Write("-2");//返回-2 该客户的该机器正在维修中...
                context.Response.End();
                return;
            }
        }
        else
        {
            if (strno != "")
            {
                System.Data.DataTable dtsn = DALCommon.GetDataList("ServicesList", "[ID]", " CustomerID=" + cusNameId + " and DeviceNO='" + strno + "' and (curStatus='待处理' or curStatus='处理中')").Tables[0];
                if (dtsn.Rows.Count > 0)
                {
                    context.Response.Write("-2");//返回-2 该客户的该机器正在维修中...
                    context.Response.End();
                    return;
                }
            }
        }

        servicesInfoss.TakeOverID = deptId;
        servicesInfoss.DisposalID = deptId;
        servicesInfoss.curStatus = "待处理";
        servicesInfoss.dPoint = 0;
        servicesInfoss.SubscribePrice = 0;
        servicesInfoss.PreCharge = 0;
        servicesInfoss.Time_Make = DateTime.Now.ToString(); //制单时间
        servicesInfoss.Time_TakeOver = DateTime.Now.ToString();//受理时间
        //防止时间为null时默认 1900-01-01
        servicesInfoss.SubscribeTime = "";
        servicesInfoss.SubscribeConnectTime = "";
        servicesInfoss.Time_Complete = "";//预计完成时间

        servicesInfoss.OperatorID = operatorerId;
        servicesInfoss.TypeID = int.Parse(typeId);
        servicesInfoss.TakeStyleID = int.Parse(takeStyleId);
        servicesInfoss.ProductBrandID = int.Parse(brandId);
        servicesInfoss.WarrantyID = int.Parse(repStatusId);
        servicesInfoss.CustomerID = int.Parse(cusNameId);
        servicesInfoss.CustomerName = cusName;
        servicesInfoss.DeviceNO = deviceNO;
        servicesInfoss.ProductSN1 = SN1;
        servicesInfoss.Tel = tel;
        servicesInfoss.Adr = adr;
        servicesInfoss.Fault = fault;
        servicesInfoss.Remark = "手机客户端开单";
        int iTbid;
        string BillID;
        int flag = dalServices.Add(servicesInfoss, "", out iTbid);
        if (flag == 0)
            AddPic(context, iTbid);
        context.Response.Write(flag.ToString());
        context.Response.End();

    }

    private void AddPic(HttpContext context, int bid)
    {
        
        //bid 是工单id或者处理过程id 
        //获取上传图片集合
        HttpFileCollection file = context.Request.Files;
        wt.DAL.DalSerAttach dal = new wt.DAL.DalSerAttach();
        wt.Model.SerAttachInfo model = new wt.Model.SerAttachInfo();
        if (file.Count > 0)
        {
            string docMonth = DateTime.Now.ToString("yyyy-MM");
            string path = System.Web.HttpContext.Current.Server.MapPath("../SerAttach");
            for (int i = 0; i < file.Count; i++)
            {


                byte[] fileData = new byte[file[i].ContentLength];
                file[i].InputStream.Read(fileData, 0, fileData.Length);
                //string[] exts = file[i].FileName.Split('.');
                //string ext = "." + exts[exts.Length - 1];

                System.Drawing.Image bmp = ReadImage(fileData); //生成成图片
                //string saveName = DateTime.Now.ToString("ddHHmmss"); //图片文件夹
                string saveName = "03044231";
                string docPath = path + "\\" + docMonth + "\\" + saveName;

                if (!System.IO.Directory.Exists(docPath))
                {
                    System.IO.Directory.CreateDirectory(docPath);
                }
                bmp.Save(docPath + "\\" + file[i].FileName); //保存图片

                model.FileName = file[i].FileName;
                model.FilePath = "../../SerAttach/" + docMonth + "/" + saveName + "/";
                model.BillID = bid;
                model.iType = 1;//附件类型(1 报称故障)
                int ID = dal.Add(model);

            }
        }

    }

    public Image ReadImage(byte[] bytes)
    {

        MemoryStream ms = new MemoryStream(bytes);
        Image image = Image.FromStream(ms);
        ms.Close();
        return image;
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}