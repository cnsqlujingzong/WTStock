<%@ WebHandler Language="C#" Class="PicCurrent" %>

using System;
using System.Web;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using wt.DAL;
using System.Data;
using System.Web.SessionState;

public class PicCurrent : IHttpHandler, IRequiresSessionState
{
    float[] x_point1 ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    float[] x_point2 ={ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    public void ProcessRequest(HttpContext context)
    {
          
        //收集数据
        string year = context.Request["year"];
        string dept = context.Request["dept"];
        string widths = context.Request["width"];
        string heights = context.Request["height"];

        year = wt.Library.FunLibrary.ChkInput(year);
        dept = wt.Library.FunLibrary.ChkInput(dept);
        int iwidth;
        int.TryParse(widths, out iwidth);

        int iheights;
        int.TryParse(heights, out iheights);

        int iyear;
        int.TryParse(year, out iyear);
        year = iyear.ToString();

        string parm = " 1=1 ";
        int idept;
        int.TryParse(dept, out idept);
        switch (idept)
        {
            case -1: break;
            default:
                {
                    parm += " and DisposalID=" + idept.ToString();
                } break;
        }

        DataTable dt = DALCommon.GetDataList("ServicesList", "[Time_TakeOver],[Time_Start],[Time_Over],[Time_Payee],[Time_BackSee],[Time_Close],[curStatus]", parm + " and ((Time_Close>='" + year + "-1-1 00:00:00' and Time_Close<'" + year + "-12-31 23:59:59') or (Time_TakeOver>='" + year + "-1-1 00:00:00' and Time_TakeOver<'" + year + "-12-31 23:59:59'))").Tables[0];
        if (dt.Rows.Count > 0)
        {
            DateTime date = DateTime.Now;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["curStatus"].ToString() == "已结束")
                {
                    DateTime.TryParse(dt.Rows[i]["Time_Close"].ToString(), out date);
                    x_point2[date.Month - 1] = x_point2[date.Month - 1] + 1;
                }
                
                DateTime.TryParse(dt.Rows[i]["Time_TakeOver"].ToString(), out date);
                x_point1[date.Month - 1] = x_point1[date.Month - 1] + 1;
            }
        }
        //
        
        float max = GetArrMax();
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
        brInterior = new LinearGradientBrush(area, Color.FromArgb(248, 180, 155), Color.White, LinearGradientMode.Vertical);

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
        g.DrawString("业务趋势(" + year + "年)", new Font("黑体", 14, FontStyle.Regular), new SolidBrush(Color.Black), new PointF(400, 15));

        Pen pen = new Pen(Color.Black);
        SolidBrush brush = new SolidBrush(Color.Black);

        //矩形
        brush.Color = Color.White;
        g.DrawRectangle(pen, 851, 4, 80, 45);
        g.FillRectangle(brush, 852, 5, 79, 44);

        //
        brush.Color = Color.FromArgb(0, 128, 0);
        g.DrawRectangle(pen, 859, 9, 8, 15);
        g.FillRectangle(brush, 860, 10, 7, 14);

        brush.Color = Color.Black;
        g.DrawString("完成笔数", new Font("宋体", 9, FontStyle.Regular), brush, new PointF(872, 11));

        //
        brush.Color = Color.FromArgb(255, 0, 0);
        g.DrawRectangle(pen, 859, 29, 8, 15);
        g.FillRectangle(brush, 860, 30, 7, 14);

        brush.Color = Color.Black;
        g.DrawString("业务笔数", new Font("宋体", 9, FontStyle.Regular), brush, new PointF(872, 31));

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
        for (int i = 0; i <= 11; i++)
        {
            g.DrawString(Convert.ToString(i + 1) + "月", new Font("黑体", 10, FontStyle.Regular), brush, new PointF(i * 66 + 85, 441));
        }

        //数据表识
        StringFormat strFmt = new StringFormat();
        strFmt.Alignment = StringAlignment.Near ;
        SolidBrush btmForeColor = new SolidBrush(Color.Black);
        SolidBrush btmBackColor = new SolidBrush(Color.FromArgb(251, 228, 150));
        Font btmFont = new Font("Verdana", 9, FontStyle.Regular);
        SizeF textSize = new SizeF();
        float x = 0f;
        float y = 0f;
        float w = 0f;
        float h = 0f;
        RectangleF textArea;

        //
        int iheight;
        string istr;
        float i_height;
        for (int i = 0; i <= 11; i++)
        {
            //
            i_height = x_point1[i] > y_cell * 9.5 ? (float)(y_cell * 9.5) : x_point1[i];

            iheight = (int)(i_height * 380 / (y_cell * 10));
            brush.Color = Color.FromArgb(255, 0, 0);
            g.DrawRectangle(pen, i * 66 + 74, 435 - (iheight), 20, (iheight) + 1);
            g.FillRectangle(brush, i * 66 + 75, 436 - (iheight), 19, iheight);
        }

        //
        int pheight;
        string pstr;
        float p_height;
        for (int i = 0; i <= 11; i++)
        {
            //
            p_height = x_point2[i] > y_cell * 9.5 ? (float)(y_cell * 9.5) : x_point2[i];
            pheight = (int)(p_height * 380 / (y_cell * 10));
            brush.Color = Color.FromArgb(0, 128, 0);
            g.DrawRectangle(pen, i * 66 + 97, 435 - (pheight), 20, (pheight) + 1);
            g.FillRectangle(brush, i * 66 + 98, 436 - (pheight), 19, pheight);
        }

        // 防止被条形覆盖
        for (int i = 0; i <= 11; i++)
        {
            //
            i_height = x_point1[i] > y_cell * 9.5 ? (float)(y_cell * 9.5) : x_point1[i];
            iheight = (int)(i_height * 380 / (y_cell * 10));

            brush.Color = Color.FromArgb(31, 44, 2);
            istr = x_point1[i].ToString("#0");

            //标注
            textSize = g.MeasureString(istr, btmFont);
            x = i * 66 + 76;
            y = 420 - (iheight) - 3;
            w = textSize.Width;
            h = textSize.Height - 1;
            textArea = new RectangleF(x, y, w, h);
            g.DrawRectangle(new Pen(Color.Black), x - 1, y - 1, w + 2, h + 2);
            g.FillRectangle(btmBackColor, textArea);
            g.DrawString(istr, btmFont, btmForeColor, textArea);
        }

        // 防止被条形覆盖
        for (int i = 0; i <= 11; i++)
        {
            //
            p_height = x_point2[i] > y_cell * 9.5 ? (float)(y_cell * 9.5) : x_point2[i];
            pheight = (int)(p_height * 380 / (y_cell * 10));

            pstr = x_point2[i].ToString("#0");

            //标注
            textSize = g.MeasureString(pstr, btmFont);
            x = i * 66 + 99;
            y = 420 - (pheight) - 3;
            w = textSize.Width;
            h = textSize.Height;
            textArea = new RectangleF(x, y, w, h);
            g.FillRectangle(btmBackColor, textArea);
            g.DrawRectangle(new Pen(Color.Black), x - 1, y - 1, w + 1, h + 1);
            g.DrawString(pstr, btmFont, btmForeColor, textArea);
        }

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
    float GetArrMax()
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