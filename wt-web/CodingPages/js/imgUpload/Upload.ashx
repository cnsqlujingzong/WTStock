<%@ WebHandler Language="C#" Class="Upload" %>

using System;
using System.Web;

public class Upload : IHttpHandler {
      
       Coding.Stock.DAL.Cd_ProImg imgbll=new Coding.Stock.DAL.Cd_ProImg ();
        Coding.Stock.DAL.Cd_ProductFiles filebll=new Coding.Stock.DAL.Cd_ProductFiles ();
        Coding.Stock.DAL.Cd_ImgStock imgStockBll = new Coding.Stock.DAL.Cd_ImgStock();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.ContentEncoding = System.Text.Encoding.UTF8;
            context.Response.HeaderEncoding = System.Text.Encoding.UTF8;
            HttpPostedFile file = context.Request.Files["FileData"];

            try
            {
                string delid = HttpUtility.HtmlEncode(context.Request.Params["delid"]);

                if (string.IsNullOrEmpty(delid))
                {
                    string type = HttpUtility.HtmlEncode(context.Request.QueryString["type"]);//proimg
                    string tid = HttpUtility.HtmlEncode(context.Request.QueryString["pid"]);//id
                    if (type != null)
                    {
                        if (string.IsNullOrEmpty(type) || string.IsNullOrEmpty(tid))
                        {
                            context.Response.Write("0");
                            return;
                        }
                        else
                        {
                            string path = context.Request["folder"] + "/" + tid + "/";
                            string uploadpath = context.Server.MapPath(path);
                            string fileNew;
                            if (!System.IO.Directory.Exists(uploadpath))
                            {
                                System.IO.Directory.CreateDirectory(uploadpath);
                            }
                            if (type == "proimg")//为图片上�?
                            {
                                fileNew = CreateRandomCode(22) + file.FileName.Substring(file.FileName.LastIndexOf("."));//  file.FileName;
                                Coding.Stock.Model.Cd_ProImg m = new Coding.Stock.Model.Cd_ProImg();
                                m.ImgName = file.FileName;
                                m.ImgSrc = path + fileNew;
                                m.ProID = int.Parse(tid);
                                imgbll.Add(m);
                                file.SaveAs(uploadpath + fileNew);
                            }
                            if (type == "profile")//为文件上�?
                            {
                                // fileNew = CreateRandomCode(22) + file.FileName.Substring(file.FileName.LastIndexOf("."));//  file.FileName;
                                Coding.Stock.Model.Cd_ProductFiles m = new Coding.Stock.Model.Cd_ProductFiles();
                                m.FileName = file.FileName;
                                m.FileSrc = path + file.FileName;
                                m.ProID = int.Parse(tid);
                                filebll.Add(m);
                                file.SaveAs(uploadpath + file.FileName);
                            }
                            if (type == "imgstock")
                            {
                                string imgFrom = HttpUtility.HtmlEncode(context.Request.Params["source"]);
                                fileNew = CreateRandomCode(22) + file.FileName.Substring(file.FileName.LastIndexOf("."));//  file.FileName;
                                Coding.Stock.Model.Cd_ImgStock m = new Coding.Stock.Model.Cd_ImgStock();
                                m.ImgName = file.FileName;
                                m.ImgSrc = path + fileNew;
                                m.FlagName = tid;
                                m.ImgType = imgFrom;

                                imgStockBll.Add(m);
                                file.SaveAs(uploadpath + fileNew);
                            }

                            context.Response.Write("1");
                        }

                    }
                    else
                    {
                        context.Response.Write("0");
                    }
                }
                else
                {
                    string type = HttpUtility.HtmlEncode(context.Request.Params["type"]);
                    if (string.IsNullOrEmpty(type))
                    {
                        context.Response.Write("0");
                        return;
                    }
                    else
                    {
                        if (type == "proimg")//为图片上�?
                        {
                            imgbll.Delete(int.Parse(delid));

                        }
                        else if (type == "profile")//为文件上�?
                        {
                            filebll.Delete(int.Parse(delid));
                        }
                        if (type == "imgstock")
                        {
                            imgStockBll.Delete(int.Parse(delid));
                        }
                        context.Response.Write("1");
                    }
                }
            }
            catch (Exception e)
            {
                context.Response.Write(e.Message);
                context.Response.Write("0");
            }
            
            
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

    private string CreateRandomCode(int codeCount)
    {
        string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,i,J,K,M,N,P,Q,R,S,T,U,W,X,Y,Z";
        string[] allCharArray = allChar.Split(',');
        string randomCode = "";
        int temp = -1;

        Random rand = new Random();
        for (int i = 0; i < codeCount; i++)
        {

            if (temp != -1)
            {
                rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
            }
            int t = rand.Next(32);
            if (temp == t)
            {
                return CreateRandomCode(codeCount);//性能问题
            }
            temp = t;
            randomCode += allCharArray[t];

        }
        return randomCode;
    }
    public string GetSize(int filesize)
    {
        int i = Convert.ToInt32(filesize);
        string size = "";

        if (i > 0)
        {
            if ((i / 1024) < 1024)
            {
                size = i / 1024 + "K";
            }
            else
            {
                size = (i / 1024) / 1024 + "M";

            }
            return size;
        }
        else
        {
            return "0";
        }


    }

}