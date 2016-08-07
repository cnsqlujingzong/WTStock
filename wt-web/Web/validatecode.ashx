<%@ WebHandler Language="C#" Class="ValidateCode" %>

using System;
using System.Web;
using System.Drawing;
using System.IO;
using System.Web.SessionState;

public class ValidateCode : IHttpHandler, IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        string list = "0,1,2,3,4,5,6,7,8,9";
        string[] strArr = list.Split(',');
        string code = string.Empty;
        Random random = new Random();
        for (int i = 0; i < 4; i++)
        {
            code += strArr[random.Next(0, strArr.Length)];
        }
        context.Session["ValidateCode"] = code;
        
        Bitmap image = new Bitmap(100, 30);
        Graphics g = Graphics.FromImage(image);
        g.Clear(Color.White);

        random = new Random();
        //»­Í¼Æ¬µÄ±³¾°ÔëÒôÏß
        for (int i = 0; i < 12; i++)
        {
            int x1 = random.Next(image.Width);
            int x2 = random.Next(image.Width);
            int y1 = random.Next(image.Height);
            int y2 = random.Next(image.Height);

            g.DrawLine(new Pen(Color.LightGray), x1, y1, x2, y2);
        }
        string[] flist = { "Arial", "ºÚÌå", "BatangChe", "Verdana" };
        Font font = null;
        System.Drawing.Drawing2D.LinearGradientBrush brush=null;
        for (int i = 0; i < code.Length; i++)
        {
            font = new Font(flist[random.Next(4)].ToString(), 16, FontStyle.Strikeout | FontStyle.Bold);
            brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.Green, 1.2f, true);
            g.DrawString(code[i].ToString(), font, brush, (float)i * 20 + 8, (float)(random.Next(12)));
        }

        //»­Í¼Æ¬µÄÇ°¾°ÔëÒôµã
        for (int i = 0; i < 20; i++)
        {
            int x = random.Next(image.Width);
            int y = random.Next(image.Height);
            image.SetPixel(x, y, Color.Blue);
        }

        //»­Í¼Æ¬µÄ±ß¿òÏß
        //g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
        context.Response.ClearContent();
        context.Response.ContentType = "image/Gif";
        context.Response.BinaryWrite(ms.ToArray());
        g.Dispose();
        image.Dispose();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}