<%@ WebHandler Language="C#" Class="AddAllotDetail" %>

using System;
using System.Web;
using wt.Model;
using wt.DAL;
using wt.Library;
using System.Drawing;
using System.IO;
using System.Text;
public class AddAllotDetail : IHttpHandler
{
    /// <summary>
    /// 工单处理
    /// </summary>
    /// <param name="context"></param>
    public void ProcessRequest(HttpContext context)
    {

        context.Response.ContentType = "text/plain;charset=UTF-8";
        ServicesInfo servicesInfoss = new ServicesInfo();
        DALServices dalServices = new DALServices();

        string bid = context.Request.Form["Bid"];//工单编号id

        int deptId = 0;
        int.TryParse(context.Request.Form["DeptId"], out deptId);//当前的网点id
        string strdodept = context.Request.Form["DeptName"];//当前的网点名称

        //升级派工的网点id
        int iparam = 0;
        int.TryParse(context.Request.Form["iparam"], out iparam);

        string username = context.Request.Form["UserName"]; //受理人名称

        string doStyle = context.Request.Form["DoStyle"]; //处理类型(升级派工,完成关闭)

        string closeType = context.Request.Form["CloseType"]; //下一步处理(完成关闭类型[关闭 还是完成])
        string date = context.Request.Form["Date"]; //完工时间
        string caReason = context.Request.Form["caReason"]; //取消理由

        string disposal = context.Request.Form["Disposal"]; //派工的技术员

        string fault = context.Request.Form["Fault"];//故障描述
        string takeSteps = context.Request.Form["TakeSteps"]; //处理措施

        string doorDate = context.Request.Form["DoorDate"]; //上门时间

        string day = context.Request.Form["Day"]; //处理时长
        string hour = context.Request.Form["Hour"]; //处理时长

        string arrDate = context.Request.Form["ArrDate"]; //完成时间
        string reason = context.Request.Form["Reason"]; //故障原因
        string course = context.Request.Form["Course"]; //执行过程
        int operatorerId = 0;//用户id
        string strMsg = string.Empty; //返回信息

        int userid = 0;
        int.TryParse(context.Request.Form["userid"], out userid); //用户id
        string pwd = context.Request.Form["pwd"];
        

        
        //------------------------------------------------------------------------------------------
        //获取员工信息
        //System.Data.DataTable dt = DALCommon.GetDataNotify("StaffList", "", " DeptID=" + deptId + "and _Name='" + username + "'").Tables[0];
        //if (dt.Rows.Count > 0)
        //{
        //    operatorerId = int.Parse(dt.Rows[0]["ID"].ToString());
        //}

        if (deptId == 0 || userid == 0 || string.IsNullOrEmpty(pwd))
        {
            context.Response.Write("-1");//返回-1 参数不正确
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
        operatorerId = userinfo.StaffID;


        DALServices dalser = new DALServices();
        int flag = 0; //结果
        int ioperator = 0;//受理人
        int iperson = 0; //操作人员
        ioperator = operatorerId;
        iperson = operatorerId;

        //处理时长
        int idays = 0;
        decimal ihours = 0;
        int.TryParse(day, out idays);
        decimal.TryParse(hour, out ihours);
        //运单编号
        int iTbid = 0;
        int.TryParse(bid, out iTbid);

        if (iTbid > 0)
        {
            //上门时间
            DateTime visitdate = DateTime.MinValue;
            if (!doorDate.Trim().Equals(""))
            {
                DateTime.TryParse(doorDate, out visitdate);
            }
            if (doStyle.Equals("升级派工"))
            {

                string tec = FunLibrary.ChkInput(disposal);//派工网点的技术员

                int repairtype = 4; //内部升级      eg:内部升级时 网点和技术员 是当前的网点和当前网点的技术员

                flag = dalser.DisAllot(repairtype, iTbid, deptId, ioperator, iperson, iparam, tec, FunLibrary.ChkInput(reason), FunLibrary.ChkInput(takeSteps), FunLibrary.ChkInput(arrDate), idays, ihours, strdodept, visitdate, "", course, out strMsg);

                if (flag == 0)
                {
                    strMsg = "操作成功！该服务单已升级处理";
                    //推送消息
                    if (!disposal.Equals(username))
                    {
                        DALSysParm dalsysp = new DALSysParm();
                        SysParmInfo sysp = dalsysp.GetModel(1);
                         string companyName=sysp.CorpName;//公司名称
                        //TODO:发送短信
                       // PushMessage.MsgPush messPush = new PushMessage.MsgPush();
                      //  messPush.PushMessage(companyName, disposal,1,deptId);
                    }
                }
                else
                {
                    strMsg = "操作失败！该服务单状态已变化，请刷新后操作！";
                }
            }
            ////////////////完成,关闭
            else
            {
                if (closeType.Equals("完成") || closeType.Equals("网点确认"))
                {
                    bool bBranchChk = false;
                    if (closeType.Equals("网点确认"))
                        bBranchChk = true;

                    flag = dalser.DoBillOK(iTbid, ioperator, iperson, date, FunLibrary.ChkInput(reason), FunLibrary.ChkInput(takeSteps), FunLibrary.ChkInput(arrDate), idays, ihours, visitdate, "", bBranchChk, course, out strMsg);
                    if (flag == 0)
                    {
                        strMsg = "操作成功！该服务单已确认完工";
                    }

                }
                else
                {
                    flag = dalser.Cancel(iTbid, deptId, ioperator, iperson, FunLibrary.ChkInput(caReason), FunLibrary.ChkInput(reason), FunLibrary.ChkInput(takeSteps), FunLibrary.ChkInput(arrDate), idays, ihours, visitdate, "", course,out strMsg);
                    if (flag == 0)
                    {
                        strMsg = "操作成功！该服务单已取消";
                    }

                }
            }


            //附件更新
            if (flag == 0)
            AddPic(context,iTbid);

        }
        //---------------------------------------------------------------------------------------------

        context.Response.Write(flag + ":" + strMsg.ToString());
        context.Response.End();


    }
    //措施故障
    private void AddPic(HttpContext context, int iTbid)
    {
       
        //bid 是工单id或者处理过程id 
        //获取上传图片集合
        HttpFileCollection file = context.Request.Files;
        wt.DAL.DalSerAttach dal = new wt.DAL.DalSerAttach();
        wt.Model.SerAttachInfo model = new wt.Model.SerAttachInfo();
        int precessbid = dal.GetIDbyBillid(iTbid); //获取过程id
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
                string saveName = DateTime.Now.ToString("ddHHmmss"); //图片文件夹
         
                string docPath = path + "\\" + docMonth + "\\" + saveName;


                if (!System.IO.Directory.Exists(docPath))
                {
                    System.IO.Directory.CreateDirectory(docPath);
                }
                bmp.Save(docPath + "\\" + file[i].FileName); //保存图片

                model.FileName = file[i].FileName;
                model.FilePath = "../../SerAttach/" + docMonth + "/" + saveName + "/";
                model.BillID = precessbid;

                //附件类型(1报称故障,2措施附件,3原因附件)
                if (file.AllKeys[i].Trim().Equals("stepsfiles"))
                    model.iType = 2;
                if (file.AllKeys[i].Trim().Equals("reasonfiles"))
                    model.iType = 3;

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