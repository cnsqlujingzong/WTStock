<%@ WebHandler Language="C#" Class="PicFaultDis" %>

using System;
using System.Web;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using wt.DAL;
using System.Data;
using System.Web.SessionState;

public class PicFaultDis : IHttpHandler, IRequiresSessionState
{
    public void ProcessRequest(HttpContext context)
    {
        //收集数据
        string deptid = context.Request["deptid"];
        string startdate = context.Request["startdate"];
        string enddate = context.Request["enddate"];
        string brandid = context.Request["brandid"];
        string classid = context.Request["classid"];
        string modelid = context.Request["modelid"];
        
        string widths = context.Request["width"];
        string heights = context.Request["height"];
        int iflag = 6;

        deptid = wt.Library.FunLibrary.ChkInput(deptid);

        int iwidth;
        int.TryParse(widths, out iwidth);

        int iheights;
        int.TryParse(heights, out iheights);

        string parm = " and curStatus='已结束' ";

        if (deptid != "-1")
        {
            parm += " and DisposalID=" + deptid;
        }
        if (brandid != "-1")
        {
            parm += " and ProductBrandID=" + brandid;
        }
        if (classid != "-1")
        {
            parm += " and ProductClassID=" + classid;
        }
        if (modelid != "-1")
        {
            parm += " and ProductModelID=" + modelid;
        }
        if (startdate != "")
        {
            parm += " and convert(char(10),Time_TakeOver,120)>='" + startdate + "'";
        }
        if (enddate != "")
        {
            parm += " and convert(char(10),Time_TakeOver,120)<='" + enddate + " 23:59:59'";
        }

        DataTable tb_type = DALCommon.GetStMKBB("tj_fw_report", iflag, "", "", parm, "").Tables[0];
        int count_type = tb_type.Rows.Count;

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
        g.DrawString("故障分布图" , new Font("黑体", 14, FontStyle.Regular), new SolidBrush(Color.Black), new PointF(250, 15));

        Pen pen = new Pen(Color.Black);
        SolidBrush brush = new SolidBrush(Color.Black);

        //矩形
        brush.Color = Color.White;
        if (count_type != 0)
        {
            g.DrawRectangle(pen, 601, 4, 108, 22 * count_type + 3);
            g.FillRectangle(brush, 602, 5, 107, 22 * count_type + 2);
        }
        else
        {
            g.DrawRectangle(pen, 601, 4, 108, 22 * 1 + 3);
            g.FillRectangle(brush, 602, 5, 107, 22 * 1 + 2);
            brush.Color = Color.Black;
            g.DrawString("无统计数据！", new Font("宋体", 9, FontStyle.Regular), brush, new PointF(601 + 5, 4 + 3 + 5));
        }

        float[] x_value = new float[count_type];
        string[] x_text = new string[count_type];
        float x_value_sum = 0f;

        for (int i = 0; i < count_type; i++)
        {
            brush.Color = GetColor(i);
            g.DrawRectangle(pen, 609, 9 + i * 20, 8, 15);
            g.FillRectangle(brush, 610, 10 + i * 20, 7, 14);

            brush.Color = Color.Black;
            g.DrawString(tb_type.Rows[i]["by_name"].ToString(), new Font("宋体", 9, FontStyle.Regular), brush, new PointF(622, 11 + i * 20));

            x_value[i] = float.Parse(tb_type.Rows[i]["by_count"].ToString());
            x_text[i] = tb_type.Rows[i]["by_name"].ToString();
            x_value_sum += x_value[i];
        }

        float angle = 0.0F;
        Point[] centers = new Point[count_type];
        g.SmoothingMode = SmoothingMode.AntiAlias;
        Rectangle area_pie = new Rectangle(25, 80, 550, 250);
        Rectangle area_point = new Rectangle(25, 80, 370, 450);


        //数据表识
        StringFormat strFmt = new StringFormat();
        strFmt.Alignment = StringAlignment.Near;
        SolidBrush btmForeColor = new SolidBrush(Color.Black);
        SolidBrush btmBackColor = new SolidBrush(Color.FromArgb(251, 228, 150));
        Font btmFont = new Font("Verdana", 9, FontStyle.Regular);
        SizeF textSize = new SizeF();
        float x = 0f;
        float y = 0f;
        float w = 0f;
        float h = 0f;
        RectangleF textArea;
        string istr = string.Empty;

        for (int j = 10; j > 0; j--)
        {
            for (int i = 0; i < x_value.Length; i++)
            {
                float sweep = Convert.ToSingle(x_value[i]) / x_value_sum * 360;
                Rectangle shadowArea = new Rectangle(area_pie.Location, area_pie.Size);
                shadowArea.Offset(1, j);
                g.FillPie(new HatchBrush(HatchStyle.Percent50, GetColor(i)), shadowArea, angle, sweep);

                // wedge
                g.FillPie(new SolidBrush(GetColor(i)), area_pie, angle, sweep);
                g.DrawEllipse(new Pen(Color.Gray, 1), area_pie);

                // center of the wedge to use later to draw labels
                Point center = GetPoint(angle + sweep / 2, area_point.Width, area_point.Height);
                center.X = (int)((area_point.Right - area_point.Left) / 2 + center.X) / 2 + 80;
                center.Y = (int)((area_point.Bottom - area_point.Top) / 2 + center.Y) / 2 - 30;
                centers[i] = center;

                angle += sweep;
            }

            for (int i = 0; i < x_text.Length; i++)
            {
                istr = x_text[i].ToString() + " " + Convert.ToDouble(x_value[i] / x_value_sum).ToString("#00%");
                //标注
                textSize = g.MeasureString(istr, btmFont);
                x = centers[i].X;
                y = centers[i].Y;
                w = textSize.Width;
                h = textSize.Height - 1;
                textArea = new RectangleF(x, y, w, h);
                g.DrawRectangle(new Pen(Color.Black), x - 1, y - 1, w + 2, h + 2);
                g.FillRectangle(btmBackColor, textArea);
                g.DrawString(istr, btmFont, btmForeColor, textArea);
            }
        }

        context.Response.ContentType = "image/png";
        MemoryStream ms = new MemoryStream();
        bmp.Save(ms, ImageFormat.Png);
        ms.WriteTo(context.Response.OutputStream);

        btmForeColor.Dispose();
        btmBackColor.Dispose();
        pen.Dispose();
        brush.Dispose();
        ms.Dispose();
        bmp.Dispose();
        g.Dispose();

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="angle"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <returns></returns>
    private Point GetPoint(float angle, int width, int height)
    {
        int radius = width / 2;
        Point topCenter = new Point(radius, 0);
        double rad = Math.PI * 2 * angle / 360;

        Point pt = new Point();
        pt.X = (int)(radius * Math.Cos(rad)) + width / 2;
        pt.Y = (int)(radius * Math.Sin(rad)) + height / 2;

        //pt.X = (int)(Math.Cos(rad) * topCenter.X - Math.Sin(rad) * topCenter.Y) + width / 2;
        //pt.Y = (int)(Math.Sin(rad) * topCenter.X + Math.Cos(rad) * topCenter.Y) + height / 2;

        return pt;
    }

    /// <summary>
    /// 产生色彩值
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    private Color GetColor(int i)
    {
        Color newcolor;
        switch (i)
        {
            case 0:
                newcolor = Color.FromArgb(209, 160, 11); break;
            case 1:
                newcolor = Color.FromArgb(148, 182, 210); break;
            case 2:
                newcolor = Color.FromArgb(0, 119, 119); break;
            case 3:
                newcolor = Color.FromArgb(231, 149, 98); break;
            case 4:
                newcolor = Color.FromArgb(130, 168, 21); break;
            case 5:
                newcolor = Color.FromArgb(153, 51, 0); break;
            case 6:
                newcolor = Color.FromArgb(0, 153, 102); break;
            case 7:
                newcolor = Color.FromArgb(153, 153, 102); break;
            case 8:
                newcolor = Color.FromArgb(204, 154, 102); break;
            case 9:
                newcolor = Color.FromArgb(148, 14, 210); break;
            case 10:
                newcolor = Color.FromArgb(74, 119, 119); break;
            case 11:
                newcolor = Color.FromArgb(231, 149, 98); break;
            case 12:
                newcolor = Color.FromArgb(241, 168, 21); break;
            case 13:
                newcolor = Color.FromArgb(95, 51, 0); break;
            case 14:
                newcolor = Color.FromArgb(23, 153, 102); break;
            case 15:
                newcolor = Color.FromArgb(153, 95, 102); break;
            case 16:
                newcolor = Color.FromArgb(123, 102, 102); break;
            default:
                newcolor = Color.FromArgb(153, 153, 153); break;
        }
        return newcolor;
    }
}