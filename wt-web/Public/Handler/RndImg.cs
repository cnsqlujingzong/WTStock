using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public class Public_Handler_RndImg : Page, IRequiresSessionState
{
	protected HtmlForm form1;

	protected DefaultProfile Profile
	{
		get
		{
			return (DefaultProfile)this.Context.Profile;
		}
	}

	protected HttpApplication ApplicationInstance
	{
		get
		{
			return this.Context.ApplicationInstance;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!base.IsPostBack)
		{
			string text = string.Empty;
			Random random = new Random();
			for (int i = 0; i < 4; i++)
			{
				int num = random.Next();
				text += ((char)(48 + (ushort)(num % 10))).ToString();
			}
			this.Session["Session_verifyCode"] = text;
			if (text != null && !(text.Trim() == string.Empty))
			{
				Bitmap bitmap = new Bitmap((int)Math.Ceiling((double)text.Length * 10.5), 18);
				Graphics graphics = Graphics.FromImage(bitmap);
				try
				{
					random = new Random();
					graphics.Clear(Color.White);
					for (int i = 0; i < 4; i++)
					{
						int x = random.Next(bitmap.Width);
						int x2 = random.Next(bitmap.Width);
						int y = random.Next(bitmap.Height);
						int y2 = random.Next(bitmap.Height);
						graphics.DrawLine(new Pen(Color.Silver), x, y, x2, y2);
					}
					Font font = new Font("黑体", 11f, FontStyle.Bold);
					LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, bitmap.Width, bitmap.Height), Color.Black, Color.Gray, 1.2f, true);
					graphics.DrawString(text, font, brush, 3f, 1f);
					for (int i = 0; i < 20; i++)
					{
						int x3 = random.Next(bitmap.Width);
						int y3 = random.Next(bitmap.Height);
						bitmap.SetPixel(x3, y3, Color.FromArgb(random.Next()));
					}
					graphics.DrawRectangle(new Pen(Color.Silver), 0, 0, bitmap.Width - 1, bitmap.Height - 1);
					MemoryStream memoryStream = new MemoryStream();
					bitmap.Save(memoryStream, ImageFormat.Gif);
					base.Response.ContentType = "image/gif";
					memoryStream.WriteTo(base.Response.OutputStream);
					memoryStream.Dispose();
				}
				finally
				{
					graphics.Dispose();
					bitmap.Dispose();
				}
			}
		}
	}
}
