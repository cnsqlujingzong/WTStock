using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
public partial class CodingPages_WX_Default : System.Web.UI.Page
{
    JavaScriptSerializer jss = new JavaScriptSerializer();
    private  static readonly object lockObj = new object();
     private  string _CorpID = "wxf937e1e5b98ea70d";
     private string _Secret = "k1V9zslI7BqnjNcIZzm0RNOPXR2F3z8CsJkQoBosP9H7eXwG4WFujp-0cnStGtd4";
        //{"access_token":"rAcFvrUyXhZDCdNtMtCZBMtijQnNJ2v7FLTG2TLOELiKzVBxWZ7Kzk0Cr7Eu3L5A","expires_in":7200}
     string getAccessTokenUrl="https://qyapi.weixin.qq.com/cgi-bin/gettoken?corpid={0}&corpsecret={1}";

    protected void Page_Load(object sender, EventArgs e)
    {
      
        //"https://qyapi.weixin.qq.com";
    }
    private string GetAccessToken(bool isGetNew=false)
    {
        lock (lockObj)
        {
            object old_o = Coding.Stock.Common.DataCache.GetCache("access_token");
            if (old_o != null && !isGetNew)
            {
                return old_o.ToString();
            }
            string getR = Coding.Stock.Common.RequestUtil.CreateGetHttpResponse(string.Format(getAccessTokenUrl, _CorpID, _Secret));
            if (getR.IndexOf("access_token") >= 0)
            {
                AccessToken o = jss.Deserialize<AccessToken>(getR);
                Coding.Stock.Common.DataCache.SetCache("access_token", o.access_token, DateTime.Now.AddSeconds(7200), System.Web.Caching.Cache.NoSlidingExpiration);
                return o.access_token;
            }
            else //if (getR.IndexOf("access_token") >= 0)
            {
                return "";
            }
        }
    }
}
public class AccessToken
{
  public  string access_token { get; set; }
  public int expires_in { get; set; }
}