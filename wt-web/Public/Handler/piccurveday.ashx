<%@ WebHandler Language="C#" Class="PicCurveDay" %>

using System;
using System.Web;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using wt.DAL;
using System.Data;
using System.Web.SessionState;

public class PicCurveDay : IHttpHandler, IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        //收集数据
        string year = context.Request["year"];
        string month = context.Request["month"];
        string dept = context.Request["dept"];
        string widths = context.Request["width"];
        string heights = context.Request["height"];
        
        year = wt.Library.FunLibrary.ChkInput(year);
        month = wt.Library.FunLibrary.ChkInput(month);
        dept = wt.Library.FunLibrary.ChkInput(dept);

        string parm = "";
        
        int iyear;
        int.TryParse(year, out iyear);
        year = iyear.ToString();

        int imonth;
        int.TryParse(month, out imonth);
        month = imonth.ToString();

        int iwidth;
        int.TryParse(widths, out iwidth);

        int iheights;
        int.TryParse(heights, out iheights);
        
        int idept;
        int.TryParse(dept, out idept);

        //
        int days = DateTime.DaysInMonth(iyear, imonth);
        //
        float[] x_point1 = new float[days];
        float[] x_point2 = new float[days];
        //

        DataTable dt = DALCommon.GetStDayData("tj_zk_rsz", idept, iyear, imonth).Tables[0];
        if (dt.Rows.Count > 0)
        {
            DateTime date = DateTime.Now;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DateTime.TryParse(dt.Rows[i]["ChkDate"].ToString(), out date);
                x_point1[date.Day - 1] = x_point1[date.Day - 1] + float.Parse(dt.Rows[i]["支出"].ToString());
                x_point2[date.Day - 1] = x_point2[date.Day - 1] + float.Parse(dt.Rows[i]["收入"].ToString());
            }
        }

        float max = GetArrMax(x_point1, x_point2);
        int y_cell = GetCell(max);
        int[] y_point ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        for (int i = 0; i < 11; i++)
        {
            y_point[i] = y_cell * (10 - i);
        }

        //
        Bitmap bmp;
        Graphics g;

        bmp = new Bitmap(iwidth, iheights);
        g = Graphics.FromImage(bmp);
        g.Clear(Color.White);

        Rectangle area = new Rectangle(0, 0, iwidth, iheights);
        //渐变笔刷
        LinearGradientBrush brInterior;
        brInterior = new LinearGradientBrush(area, Color.FromArgb(251, 228, 150), Color.White, LinearGradientMode.Vertical);

        //渐变因子
        float[] relativeIntensities ={ 0.0f, 0.6f, 1.0f };
        float[] relativePositions ={ 0.0f, 0.5f, 1.0f };
        Blend blend = new Blend();
        blend.Factors = relativeIntensities;
        blend.Positions = relativePositions;
        brInterior.Blend = blend;
        //绘制渐变矩形
        g.FillRectangle(brInterior, area);

        brInterior.Dispose();

        //标题
        g.DrawString("日收支曲线(" + year + "-" + month + "月)", new Font("黑体", 14, FontStyle.Regular), new SolidBrush(Color.Black), new PointF(410, 15));

        Pen pen = new Pen(Color.Black);
        SolidBrush brush = new SolidBrush(Color.Black);

        //矩形
        brush.Color = Color.White;
        g.DrawRectangle(pen, 851, 4, 70, 45);
        g.FillRectangle(brush, 852, 5, 69, 44);

        //
        brush.Color = Color.FromArgb(0, 128, 0);
        g.DrawRectangle(pen, 859, 9, 8, 15);
        g.FillRectangle(brush, 860, 10, 7, 14);

        brush.Color = Color.Black;
        g.DrawString("收入", new Font("宋体", 9, FontStyle.Regular), brush, new PointF(872, 11));

        //
        brush.Color = Color.FromArgb(255, 0, 0);
        g.DrawRectangle(pen, 859, 29, 8, 15);
        g.FillRectangle(brush, 860, 30, 7, 14);

        brush.Color = Color.Black;
        g.DrawString("支出", new Font("宋体", 9, FontStyle.Regular), brush, new PointF(872, 31));

        //坐标系(w,h):(882,382);原点(50,50)
        g.DrawRectangle(pen, 55, 55, 882, 382);

        pen.Color = Color.FromArgb(206, 206, 206);
        //纵方格
        for (int i = 0; i <= 9; i++)
        {
            if (i % 2 == 0)
            {
                brush.Color = Color.FromArgb(224, 226, 228);
                g.FillRectangle(brush, 56, 56 + i * 38, 880, 38);
            }
            else
            {
                brush.Color = Color.FromArgb(229, 233, 236);
                g.FillRectangle(brush, 56, 56 + i * 38, 880, 38);
            }
            //横线
            if (i != 0)
            {
                g.DrawLine(pen, 56, 56 + i * 38, 931, 56 + i * 38);
            }
        }

        brush.Color = Color.Black;
        StringFormat sft = new StringFormat();
        sft.Alignment = StringAlignment.Far;
        //纵坐标
        for (int i = 0; i <= 10; i++)
        {
            g.DrawString(y_point[i].ToString(), new Font("黑体", 10, FontStyle.Regular), brush, new RectangleF(5, 49 + i * 38, 48, 20), sft);
        }

        //纵线
        for (int i = 0; i <= 19; i++)
        {
            g.DrawLine(pen, 56 + i * 44, 56, 56 + i * 44, 431);
        }

        pen.Color = Color.Black;
        //横坐标
        for (int i = 0; i <days; i++)
        {
            g.DrawString(Convert.ToString(i + 1), new Font("黑体", 10, FontStyle.Regular), brush, new PointF(i * 27 + 80, 441));
        }

        //数据表识
        StringFormat strFmt = new StringFormat();
        strFmt.Alignment = StringAlignment.Near;
        SolidBrush btmForeColor = new SolidBrush(Color.WhiteSmoke);
        SolidBrush btmBackColor = new SolidBrush(Color.Black);
        Font btmFont = new Font("Verdana", 9, FontStyle.Regular);
        SizeF textSize = new SizeF();
        float x = 0f;
        float y = 0f;
        float w = 0f;
        float h = 0f;
        RectangleF textArea;

        //画线
        Point[] point = new Point[days];
        int p_iheight;
        float p_i_height;
        for (int i = 0; i < x_point1.Length; i++)
        {
            p_i_height = x_point1[i];
            p_iheight = (int)(p_i_height * 380 / (y_cell * 10));

            point[i].X = i * 27 + 76 + 10;
            point[i].Y = 415 - (p_iheight) + 15;
        }

        pen.Color = Color.Red;
        g.DrawLines(pen, point);

        //画线
        int p_pheight;
        float p_p_height;
        for (int i = 0; i < x_point2.Length; i++)
        {
            p_p_height = x_point2[i];
            p_pheight = (int)(p_p_height * 380 / (y_cell * 10));

            point[i].X = i * 27 + 76 + 10;
            point[i].Y = 415 - (p_pheight) + 15;
        }

        pen.Color = Color.FromArgb(0, 128, 0); ;
        g.DrawLines(pen, point);    
        
        
        //营业额
        int iheight;
        string istr;
        float i_height;
        
        for (int i = 0; i < x_point1.Length; i++)
        {
            i_height = x_point1[i];
            iheight = (int)(i_height * 380 / (y_cell * 10));
            
            istr = x_point1[i].ToString("#0.00");
            if (istr == "0.00")
                istr = "0";

            //营业额标注
            btmBackColor.Color = Color.Red;
            textSize = g.MeasureString(istr, btmFont);
            x = i * 27 + 76;
            y = 420 - (iheight);
            w = textSize.Width;
            h = textSize.Height - 1;
            textArea = new RectangleF(x, y, w, h);
            g.DrawRectangle(new Pen(Color.Black), x - 1, y - 1, w + 1, h + 2);
            g.FillRectangle(btmBackColor, textArea);
            g.DrawString(istr, btmFont, btmForeColor, textArea);

        }

        //毛利
        int pheight;
        string pstr;
        float p_height;
        for (int i = 0; i < x_point2.Length; i++)
        {
            //
            p_height = x_point2[i];
            pheight = (int)(p_height * 380 / (y_cell * 10));

            pstr = x_point2[i].ToString("#0.00");
            if (pstr == "0.00")
                pstr = "0";

            //毛利标注
            btmBackColor.Color = Color.FromArgb(0, 128, 0);
            textSize = g.MeasureString(pstr, btmFont);
            x = i * 27 + 87;
            y = 420 - (pheight);
            w = textSize.Width;
            h = textSize.Height;
            textArea = new RectangleF(x, y, w, h);
            g.FillRectangle(btmBackColor, textArea);
            g.DrawRectangle(new Pen(Color.Black), x - 1, y - 1, w + 1, h + 1);
            g.DrawString(pstr, btmFont, btmForeColor, textArea);

        }
        //

        context.Response.ContentType = "image/png";
        MemoryStream ms = new MemoryStream();
        bmp.Save(ms, ImageFormat.Png);
        ms.WriteTo(context.Response.OutputStream);

        pen.Dispose();
        brush.Dispose();
        btmBackColor.Dispose();
        btmForeColor.Dispose();
        ms.Dispose();
        bmp.Dispose();
        g.Dispose();

    }
    
    /// <summary>
    /// 取最大值
    /// </summary>
    /// <returns></returns>
    float GetArrMax(float[] x_point1, float[] x_point2)
    {
        float max = 0f;
        for (int i = 0; i < x_point1.Length; i++)
        {
            if (x_point1[i] >= max)
                max = x_point1[i];
        }
        for (int j = 0; j < x_point2.Length; j++)
        {
            if (x_point2[j] >= max)
                max = x_point2[j];
        }
        return max;
    }
    
    /// <summary>
    /// 确定坐标系单元格
    /// </summary>
    /// <param name="max"></param>
    /// <returns></returns>
    int GetCell(float max)
    {
        int y_cell = 0;
        if (max >= 0 && max <= 100) { y_cell = 10; }
        else if (max > 100 && max <= 1000) { y_cell = 100; }
        else if (max > 1000 && max <= 10000) { y_cell = 1000; }
        else if (max > 10000 && max <= 100000) { y_cell = 10000; }
        else if (max > 100000 && max <= 1000000) { y_cell = 100000; }
        else if (max > 1000000 && max <= 10000000) { y_cell = 1000000; }
        else if (max > 10000000 && max <= 100000000) { y_cell = 10000000; }
        else if (max > 100000000 && max <= 1000000000) { y_cell = 100000000; }
        else { y_cell = 1000000000; }
        return y_cell;
    }
    
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}