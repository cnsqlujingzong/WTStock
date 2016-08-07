using System;
using System.Net;
using System.Text;
using System.IO;

namespace Coding.Stock.Common
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
        /// Get请求
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string CreateGetHttpResponse(string url)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream imgStream = response.GetResponseStream();
                StreamReader sr = new StreamReader(imgStream);
                return sr.ReadToEnd();
            }
            else
            {
                return CreateGetHttpResponse(url);
            }
        }
        
    }
}