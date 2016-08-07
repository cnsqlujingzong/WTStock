
using Biz.DAO;
using BussModule.Biz.DAO;
using BussModule.Biz.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace STWebAPP.Controllers
{
    public class HomeController : Controller
    {
        private static  readonly object lockObj = new object();
        private static readonly object lockObj2 = new object();
        JavaScriptSerializer jss = new JavaScriptSerializer();
        private static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
 
        // GET: /Home/
        private string _CorpID = "wxf937e1e5b98ea70d";
        private string _Secret = "k1V9zslI7BqnjNcIZzm0RNOPXR2F3z8CsJkQoBosP9H7eXwG4WFujp-0cnStGtd4";
        //AccessToken URL
        private string getAccessTokenUrl = "https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={0}&corpsecret={1}";       
        //企业获取code URL
        private string comGetCodeURL = "https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=snsapi_base&state={2}#wechat_redirect";
         //根据code获取成员信息
        private string getUIDURL = "https://qyapi.weixin.qq.com/cgi-bin/user/getuserinfo?access_token={0}&code={1}";
        private string getJsap_ticketURL = "https://qyapi.weixin.qq.com/cgi-bin/get_jsapi_ticket?access_token={0}";
        private string getResURL = "https://qyapi.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}";
        TaskBuss taskBll = new TaskBuss();
        /// <summary>
        /// 登录
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            log.Info("****************进入Index 登录*****************");
            string url = "http://weixinapp.sthx.top/Home/Index";
            //企业获取Code
            string memberCode = Request.QueryString["code"];
            log.Info("memberCode:" + memberCode);
            if (string.IsNullOrEmpty(memberCode))
            {   //没有得到跳转获取Code      
                Response.Redirect(string.Format(comGetCodeURL, _CorpID, HttpUtility.UrlEncode(url), "DIYState"), true);
            }
            else 
            {
             string access_token = GetAccessToken();
                //得到code 
                //根据code获取成员信息
              string uidStr= CommonUtils.RequestUtil.GetDataToUrl(string.Format(getUIDURL, access_token, memberCode));
              log.Info("GetUid:"+uidStr);
              if (uidStr.IndexOf("UserId") >= 0)
              {
                  //正确得到uid json
                  UidModel u = jss.Deserialize<UidModel>(uidStr);
                  //获取用户              
                  UserInfo dt_user = taskBll.GetUserByWinxin(u.UserId);
                  if (dt_user == null)
                  {
                      //没有此用户
                      log.Info("没有(" + u.UserId + ")此用户！");
                      return RedirectToAction("Login");
                  }
                  else { 
                    //查询到账户==>查询任务
                      Session["UserInfo"] = dt_user;
                      log.Info("即将跳转 MyHome Action！");
                     return  RedirectToAction("MyHome");
                  }
              }
              else 
              { 
                 //错误
              }

            }
            //
            //企业如果需要员工在跳转到企业网页时带上员工的身份信息，需构造如下的链接：
            //Response.Redirect(string.Format(loginURL, _CorpID, HttpUtility.UrlEncode(url), "in", "member"),true);
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 主页
        /// </summary>
        public ActionResult MyHome()
        {
            if (Session["UserInfo"] == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
       fw_servicesBuss serBll = new fw_servicesBuss();//服务详情
       fw_servicesProcessBuss serprocessBll = new fw_servicesProcessBuss();//服务处理
       fw_servicesmaterialBuss materialBll = new fw_servicesmaterialBuss();//服务备件
       fw_servicesitemBuss servicesitemBll = new fw_servicesitemBuss();//服务项目
       ServicesDeviceConfBuss servicesdeviceconfBll = new ServicesDeviceConfBuss();//机器配置
       fw_servicesofferBuss servicesofferBll = new fw_servicesofferBuss();//服务报价
       fw_servicespushBuss servicespushBll = new fw_servicespushBuss();//催单
       ks_qtylistBuss ks_qtylistBll = new ks_qtylistBuss();//计数器
       Cd_ImgStockBuss imgstockBll = new Cd_ImgStockBuss();//图片
       fw_serviceslogBuss serviceslogBll = new fw_serviceslogBuss();//日志
        /// <summary>
        /// 服务列表
        /// </summary>
        /// <returns></returns>
        public ActionResult ServicesAllot()
        {
            if (Session["UserInfo"] == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                UserInfo u = (UserInfo)Session["UserInfo"];
                List<BussModule.Biz.Model.fw_services> list;
                if (u.School == "经理")
                {
                    list=serBll.GetList(" curStatus <>'已结束'  and curStatus<>'已取消' ");
              
                  }
                else {
                    list=serBll.GetList(string.Format(" (Operator='{0}' or DisposalOper='{0}') and curStatus <>'已结束'  and curStatus<>'已取消' ", u._Name));              
                }
                    return View(list);
            }
        }
        public ActionResult ServiceDetail(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }           
            //UserInfo dt_user = taskBll.GetUserByWinxin("Codinglu");
            //Session["UserInfo"] = dt_user;
            if (Session["UserInfo"] == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ServicesInfo model = new ServicesInfo();
                fw_services servicesdetail = serBll.GetModel(id);//详情
                if (servicesdetail != null)
                {
                    List<fw_servicesprocess> process = serprocessBll.GetList(" [BillID]='" + servicesdetail.ID + "'");//处理
                    List<fw_servicesmaterial> materials = materialBll.GetList(" [BillID]='" + servicesdetail.ID + "'");//备件
                    List<fw_servicesitem> serivceitem = servicesitemBll.GetList(" [BillID]='" + servicesdetail.ID + "'");//服务项目
                    List<ServicesDeviceConf> servicesdeviceconf = servicesdeviceconfBll.GetList(" [BillID]='" + servicesdetail.ID + "'");//机器配置
                    List<fw_servicesoffer> servicesoffer = servicesofferBll.GetList(" [BillID]='" + servicesdetail.ID + "'");//服务报价
                    List<fw_servicespush> servicespush = servicespushBll.GetList(" [BillID]='" + servicesdetail.ID + "'");//催单
                    List<ks_qtylist> ksqty = ks_qtylistBll.GetList(" [BillID]='" + servicesdetail.ID + "'  or SN='" + servicesdetail.ProductSN1 + "' ");//计数器
                    List<Cd_ImgStock> imgstock = imgstockBll.GetList(string.Format(" FlagName='{0}'", servicesdetail.BillID));//图片
                    List<fw_serviceslog> serviceslog = serviceslogBll.GetList(" [BillID]='" + servicesdetail.ID + "'");//日志         
                    model.ServiceDetail = servicesdetail;
                    model.ServiceProcess = process;
                    model.ServiceMaterial = materials;
                    model.ServiceItem = serivceitem;
                    model.ServicesDeviceConfig = servicesdeviceconf;
                    model.ServiceOffer = servicesoffer;
                    model.ServicePush = servicespush;
                    model.KSQty = ksqty;
                    model.ImgStock = imgstock;
                    model.ServiceLog = serviceslog;
                }
                return View(model);
            }
        }
        /// <summary>
        /// 我的任务列表
        /// </summary>
        /// <returns></returns>
        public ActionResult MyTask()
        {
            if (Session["UserInfo"] == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                UserInfo u = (UserInfo)Session["UserInfo"];
                List<Task> taskList = taskBll.GetTaskList(u.ID.ToString());
                return View(taskList);
            }
        }
       
        [HttpGet]
        public ActionResult SendWeixinMsg()
        {
            //ViewBag.ReMsg  
            ViewBag.ReMsg = "";
            return View();
        }
        [HttpPost]
        public ActionResult SendWeixinMsg(string user, string msg)
        {
            log.Info("****************进入SendWeixinMsg*****************");
            try
            {
                log.Info("user:"+user+"----msg:"+msg);
                string request = "{\"touser\": \"" + user + "\",\"msgtype\": \"text\",\"agentid\": 5,\"text\": {\"content\": \""+msg+"\"},\"safe\":\"0\"}";
                string url = "https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token={0}";
                string token = GetAccessToken();
                log.Info("request:" + request);
                log.Info("url:" + string.Format(url, token));
                string result = CommonUtils.RequestUtil.PostDataToUrl(request, string.Format(url, token), null);
                log.Info("SendWeixinMsg:" + result);
                ViewBag.ReMsg = "发送结果：" + result;
            }
            catch(Exception e) {
                log.Info("异常:" + e.Message+e.StackTrace);
                log.Info("异常:" + e.StackTrace);
                ViewBag.ReMsg = e.Message;
            }
            log.Info("****************离开SendWeixinMsg*****************");
           return View();
        }
        //上传图片
    [HttpGet]
        public ActionResult UploadImg(string id)
        {
            log.Info("****************进入UploadImg--Get*****************");
             ticketParm o = new ticketParm();
             TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);  
             o.timestamp=Convert.ToInt64(ts.TotalSeconds).ToString();
             o.noncestr = CommonUtils.RandomCode.GetRandomCode(16);
             o.jsapi_ticket = GetJsap_ticket();
             string url = "http://weixinapp.sthx.top/home/UploadImg/" + id;
            string sha1Str="jsapi_ticket={0}&noncestr={1}&timestamp={2}&url={3}";
            string sha1 = FormsAuthentication.HashPasswordForStoringInConfigFile(string.Format(sha1Str,o.jsapi_ticket,o.noncestr,o.timestamp,url),"SHA1");
            o.sha1 = sha1;
            ViewBag.Parm = o;
            log.Info("Ticket Parm:"+jss.Serialize(o));
            log.Info("****************离开UploadImg--Get*****************");
            return View();
        }
    [HttpPost]
    public ActionResult UploadImg(string serID,string bid ,string type)
    {
        log.Info("****************进入UploadImg--POST*****************");
        log.Info("serID:" + serID);    
            if(!string.IsNullOrEmpty(serID))
            {   
                    string accToke = GetAccessToken();
                    string imgPath = CommonUtils.RequestUtil.GetImgToUrl(string.Format(getResURL, accToke, serID),bid,type);
                    log.Info("图片:  " + imgPath);                
            }
            log.Info("****************离开UploadImg--POST*****************");
            return Json(new { r="ok"},JsonRequestBehavior.AllowGet);
    }

        private string GetAccessToken(bool isGetNew = false)
        {    
            lock (lockObj)
            {      
                object old_o =CommonUtils.DataCache.GetCache("access_token");
                if (old_o != null && !isGetNew)
                {
                    log.Info("Old AccessToken:" + old_o.ToString());
                    return old_o.ToString();
                }
          
                string getR =CommonUtils.RequestUtil.GetDataToUrl(string.Format(getAccessTokenUrl, _CorpID, _Secret));
                log.Info("Get AccessToken:"+getR);
                 if (getR.IndexOf("access_token") >= 0)
                {
                    AccessToken o = jss.Deserialize<AccessToken>(getR);
                    CommonUtils.DataCache.SetCache("access_token", o.access_token, DateTime.Now.AddSeconds(7180), System.Web.Caching.Cache.NoSlidingExpiration);
                    return o.access_token;
                }
                else //if (getR.IndexOf("access_token") >= 0)
                {
                    log.Info("获取AccessToken失败！");
                    return "";
                }
            }
        }
        private string GetJsap_ticket(bool isGetNew = false)
        {
            lock (lockObj2)
            {
                object old_o = CommonUtils.DataCache.GetCache("jsap_ticket");
                if (old_o != null && !isGetNew)
                {
                    log.Info("Old jsap_ticket:" + old_o.ToString());
                    return old_o.ToString();
                }
                string accToke = GetAccessToken();
                string getR = CommonUtils.RequestUtil.GetDataToUrl(string.Format(getJsap_ticketURL, accToke));
                log.Info("Get jsap_ticket:" + getR);              
                TicketModel o = jss.Deserialize<TicketModel>(getR);
                if (o.errcode == 0 && o.errmsg == "ok")
                {
                    CommonUtils.DataCache.SetCache("jsap_ticket", o.ticket, DateTime.Now.AddSeconds(7180), System.Web.Caching.Cache.NoSlidingExpiration);
                    return o.ticket;
                }
                else 
                {
                    log.Info("获取jsap_ticket失败！");
                    return "";
                }
            }
        }
    }

    //获取AccessToken Model
    public class AccessToken
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
    }
    //获取UserID Model
    public class UidModel {
        public string UserId { get; set; }
        public string DeviceId { get; set; }
    }
    //获取Jsapi_ticket Model
    public class TicketModel 
    { 
    public int errcode{get;set;}
    public string errmsg{get;set;}
    public string ticket{get;set;}
    public int expires_in { get; set; }     
    }
    public class ticketParm 
    {
        public string noncestr { get; set; }
        public string jsapi_ticket { get; set; }
        public string timestamp { get; set; }
        public string sha1 { get; set; }
  
    }
}
