using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Coding.Stock.Common
{
   public class PostMSG
    {
         private  const string PostUrl = "http://106.ihuyi.cn/webservice/sms.php?method=Submit";
       public static bool SendMSG(System.Web.UI.Page page, string mobile,string content)
       {
           string account = "cf_sthx";
           string password = "536cda5a6f843755b9fe562131ccf8eb";//密码可以使用明文密码或使用32位MD5加密
           //string mobile = Request.QueryString["mobile"];
           Random rad = new Random();
           int mobile_code = rad.Next(1000, 10000);
          // string content = "您的验证码是：" + mobile_code + " 。请不要把验证码泄露给其他人。";

           //Session["mobile"] = mobile;
           //Session["mobile_code"] = mobile_code;

           string postStrTpl = "account={0}&password={1}&mobile={2}&content={3}";

           UTF8Encoding encoding = new UTF8Encoding();
           byte[] postData = encoding.GetBytes(string.Format(postStrTpl, account, password, mobile, content));

           HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(PostUrl);
           myRequest.Method = "POST";
           myRequest.ContentType = "application/x-www-form-urlencoded";
           myRequest.ContentLength = postData.Length;

           Stream newStream = myRequest.GetRequestStream();
           // Send the data.
           newStream.Write(postData, 0, postData.Length);
           newStream.Flush();
           newStream.Close();

           HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
           if (myResponse.StatusCode == HttpStatusCode.OK)
           {
               StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);

               //Response.Write(reader.ReadToEnd());

               string res = reader.ReadToEnd();
               int len1 = res.IndexOf("</code>");
               int len2 = res.IndexOf("<code>");
               string code = res.Substring((len2 + 6), (len1 - len2 - 6));
               //Response.Write(code);

               int len3 = res.IndexOf("</msg>");
               int len4 = res.IndexOf("<msg>");
               string msg = res.Substring((len4 + 5), (len3 - len4 - 5));
            //  page.Response.Write(msg);
           //   page.Response.End();
              return true;
           }
           else
           {
               return false;
               //访问失败
           }
       }
    }
}
