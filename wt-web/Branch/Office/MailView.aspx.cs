
using System;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using wt.Model;

public partial class Branch_Office_MailView : Page, IRequiresSessionState
{
	private int id;


	protected string StrID
	{
		get
		{
			return this.id.ToString();
		}
	}


	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		int.TryParse(base.Request.QueryString["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			DALOA_Mail dALOA_Mail = new DALOA_Mail();
			OA_EmailInfo model = dALOA_Mail.GetModel(this.id);
			if (model != null)
			{
				this.tbSnd.Text = model.Snd;
				this.tbRcv.Text = model.Rcv;
				this.tbContent.Text = model.Content;
				this.tbTitle.Text = model.Title;
				if (model.bAccessory)
				{
					string listStr = dALOA_Mail.GetListStr(" MailID='" + model.ID + "'");
					string[] array = listStr.Split(new char[]
					{
						','
					});
					StringBuilder stringBuilder = new StringBuilder();
					for (int i = 0; i < array.Length; i++)
					{
						stringBuilder.Append(string.Concat(new string[]
						{
							"<img src='../../Public/Images/dmony.gif' /> <a href=../Document/",
							array[i],
							" target=_blank >附件",
							Convert.ToString(i + 1),
							"</a>"
						}));
					}
					this.dUpload.InnerHtml = stringBuilder.ToString();
				}
				if (this.tbRcv.Text == (string)this.Session["Session_wtUserB"])
				{
					dALOA_Mail.UpdateRead(this.id);
				}
			}
		}
	}
}
