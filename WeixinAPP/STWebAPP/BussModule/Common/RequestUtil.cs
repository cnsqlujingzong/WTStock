using System;
using System.Net;
using System.Text;
using System.IO;
using System.Drawing;
using log4net;
using System.Reflection;

namespace CommonUtils
{

    /// <summary>
    /// 支付平台-请求工具类
    /// </summary>
    /// <history>
    ///     <date>2011-03-23</date>
    ///     <programmer>taoqingxue</programmer>
    /// </history>
    public static class RequestUtil
    {
        private static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// POST数据到指定URL
        /// </summary>
        /// <param name="data">要post的数据</param>
        /// <param name="url">目标url</param>
        /// <returns>服务器响应</returns>
        public static string PostDataToUrl(string data, string url, string contentType)
        {
            byte[] bytesToPost = Encoding.UTF8.GetBytes(data);

            return RequestUtil.PostDataToUrl(bytesToPost, url, contentType);
        }

        /// <summary>
        /// POST数据到指定URL
        /// </summary>
        /// <param name="data">要post的数据</param>
        /// <param name="url">目标url</param>
        /// <returns>服务器响应</returns>
        public static string PostDataToUrl(byte[] data, string url, string contentType)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            if (string.IsNullOrEmpty(contentType))
            {
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            }
            else
            {
                httpWebRequest.ContentType = contentType;
            }
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentLength = data.Length;

            Stream requestStream = httpWebRequest.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();

            string response = string.Empty;
            using (Stream responseStream = httpWebRequest.GetResponse().GetResponseStream())
            {
                using (StreamReader responseReader = new StreamReader(responseStream, Encoding.UTF8))
                {
                    response = responseReader.ReadToEnd();
                }
            }

            return response;
        }

        /// <summary>
        /// Get请求 数据
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetDataToUrl(string url)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream msg = response.GetResponseStream();
                StreamReader sr = new StreamReader(msg);
                return sr.ReadToEnd();
            }
            else
            {
                return GetDataToUrl(url);
            }
        }
     
        public static string GetImgToUrl(string url,string bid,string type)
        {
            log.Info("***********进入GetImgToUrl**********");
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "GET";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                log.Info("response:StatusCode" + response.StatusCode + "\n");
                log.Info("response:ContentType" + response.ContentType + "\n");
                if (response.StatusCode == HttpStatusCode.OK && response.ContentType.IndexOf("image") >= 0)
                {
                    Stream msg = response.GetResponseStream();
                    // StreamReader sr = new StreamReader(msg);
                    Image img = Image.FromStream(msg);
                    string vpath = "/Upload/weixin/" + string.Format("{0:yyyyMMdd}", DateTime.Now) + "/";
                    string rpath = System.Web.HttpContext.Current.Server.MapPath(vpath);
                    log.Info("rpath" + rpath + "\n");
                    if (!Directory.Exists(rpath))
                    {
                        Directory.CreateDirectory(rpath);
                    }
                    string fileName = CommonUtils.RandomCode.GetRandomCode(16) + ".jpg";
                    log.Info("fileName" + fileName + "\n");
                    img.Save(rpath + fileName);
                    msg.Close();
                    msg.Dispose();
                    BussModule.Biz.Model.Cd_ImgStock imgModel = new BussModule.Biz.Model.Cd_ImgStock();
                    imgModel.FlagName=bid;
                    imgModel.ImgType = type;
                    imgModel.ImgName = fileName;
                    imgModel.ImgSrc = "http://weixinapp.sthx.top/" + vpath + fileName;
                    BussModule.Biz.DAO.Cd_ImgStockBuss imgbll = new BussModule.Biz.DAO.Cd_ImgStockBuss();
                    imgbll.Add(imgModel);
                    return vpath + fileName;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception e)
            {
                log.Info("Exception:");
                return "";
            }
        }
    }
}