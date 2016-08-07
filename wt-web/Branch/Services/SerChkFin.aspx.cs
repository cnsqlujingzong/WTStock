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

public partial class Branch_Services_SerChkFin : Page, IRequiresSessionState
{

	private int id;

	private int iType;

	
	public string aType
	{
		get
		{
			return this.iType.ToString();
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		int.TryParse(base.Request.QueryString["id"], out this.id);
		if (this.id <= 0)
		{
			base.Response.End();
		}
		if (base.Request.QueryString["t"].Trim().Equals("1"))
		{
			this.iType = 4;
		}
		else
		{
			this.iType = 5;
		}
		if (!base.IsPostBack)
		{
			if (this.iType == 5)
			{
				this.Label1.Text = "建议";
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALServices dALServices = new DALServices();
		if (this.iType == 4)
		{
			dALServices.BranchChk(int.Parse(this.Session["Session_wtUserBID"].ToString()), this.id, this.tbRemark.Text, this.hfAttachs.Value.Trim().Trim(new char[]
			{
				','
			}));
		}
		else
		{
			string text = string.Empty;
			text = dALServices.BranchReject(int.Parse(this.Session["Session_wtUserBID"].ToString()), this.id, this.tbRemark.Text, this.hfAttachs.Value.Trim().Trim(new char[]
			{
				','
			}));
		}
		this.SysInfo("parent.CloseDialog('1');");
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
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
		}
	}

	protected void btnDel_Click(object sender, EventArgs e)
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
