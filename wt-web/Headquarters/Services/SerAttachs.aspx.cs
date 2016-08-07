using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class Headquarters_Services_SerAttachs : Page, IRequiresSessionState
{

	private string billid;

	private int iType;

	public string aType
	{
		get
		{
			return this.iType.ToString();
		}
	}

	public string Str_bid
	{
		get
		{
			return this.billid;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		bool btel = false;
		if (base.Request.QueryString["itel"] != null)
		{
			btel = true;
		}
		FunLibrary.ChkHead(btel);
		int.TryParse(base.Request.QueryString["t"], out this.iType);
		if (!base.IsPostBack)
		{
			if (base.Request.QueryString["aids"] != null && !base.Request.QueryString["aids"].Trim().Equals(""))
			{
				this.hfAttachs.Value = base.Request.QueryString["aids"].Trim().Trim(new char[]
				{
					','
				}) + ',';
				this.BindAttachs();
			}
			if (base.Request.QueryString["m"] != null)
			{
				this.btnAdd.Enabled = false;
				this.btnAddAttach.Disabled = true;
			}
			if (base.Request["bid"] != null && !base.Request["bid"].Trim().Equals(""))
			{
				this.billid = base.Request["bid"];
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		string text = "hfAttachs";
		if (this.iType == 2)
		{
			text = "hfTSAttachs";
		}
		else if (this.iType == 3)
		{
			text = "hfReasonAttachs";
		}
		this.SysInfo(string.Concat(new string[]
		{
			"parent.iframeDialog.$('",
			text,
			"').value='",
			this.hfAttachs.Value.Trim().Trim(new char[]
			{
				','
			}),
			"';parent.CloseDialog1();"
		}));
	}

	protected void BindAttachs()
	{
		string text = this.hfAttachs.Value.Trim().Trim(new char[]
		{
			','
		});
		if (text.Length > 0)
		{
			DalSerAttach dalSerAttach = new DalSerAttach();
			DataSet list = dalSerAttach.GetList(string.Format("ID in({0})", text));
			this.gvdata.DataSource = list;
			this.gvdata.DataBind();
		}
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (base.Request.QueryString["m"] != null)
		{
			e.Row.Cells[2].Visible = false;
		}
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
		}
	}

	protected void btnDel_Click(object sender, EventArgs e)
	{
		if (base.Request.QueryString["m"] == null)
		{
			int num = 0;
			int.TryParse(this.hfRecID.Value, out num);
			if (num > 0)
			{
				DalSerAttach dalSerAttach = new DalSerAttach();
				string path = base.Server.MapPath(this.hfDelFile.Value);
				if (File.Exists(path))
				{
					File.Delete(path);
				}
				dalSerAttach.Delete(num);
				string text = this.hfAttachs.Value.Trim();
				text = Regex.Replace(text, "(^|,)" + num + "(,|$)", ",");
				this.hfAttachs.Value = text;
			}
		}
		this.BindAttachs();
	}

	protected void btnRfrh_Click(object sender, EventArgs e)
	{
		this.BindAttachs();
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
