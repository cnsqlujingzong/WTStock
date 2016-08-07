using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class Branch_Financial_SltBill : Page, IRequiresSessionState
{
	private string strfid;

	private string f;

	private int custype;

	private int cusid;

	private int iflag;

	

	public string Str_Fid
	{
		get
		{
			return this.strfid;
		}
	}

	public string Str_F
	{
		get
		{
			return this.f;
		}
	}
    
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		int.TryParse(base.Request["custype"], out this.custype);
		int.TryParse(base.Request["cusid"].ToString().Replace("c", "").Replace("b", "").Replace("s", ""), out this.cusid);
		int.TryParse(base.Request["iFlag"], out this.iflag);
		if (this.cusid == 0 || this.custype == 0 || this.iflag == 0)
		{
			base.Response.End();
		}
		this.strfid = base.Request["fid"];
		if (this.strfid == null || this.strfid == string.Empty)
		{
			this.strfid = "iframeDialog";
			this.f = "1";
		}
		else
		{
			this.f = "";
		}
		if (!base.IsPostBack)
		{
			this.FillData();
		}
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.FillData();
	}

	protected void FillData()
	{
		string text = string.Concat(new string[]
		{
			" NotChargeAmount>0 and Status=1 and DeptID=",
			(string)this.Session["Session_wtBranchID"],
			" and CusType=",
			this.custype.ToString(),
			" and CustomerID=",
			this.cusid.ToString()
		});
		if (this.iflag == 1)
		{
			text += " and Type='应收款' ";
		}
		else
		{
			text += " and Type='应付款' ";
		}
		if (this.ddlKey.SelectedValue != "-1")
		{
			string text2 = FunLibrary.ChkInput(this.tbCon.Text);
			if (this.tbCon.Text.Trim() != "")
			{
				string text3 = text;
				text = string.Concat(new string[]
				{
					text3,
					" and ",
					this.ddlKey.SelectedValue,
					" like '%",
					text2,
					"%'"
				});
			}
		}
		this.gvdata.DataSource = DALCommon.GetDataList("zk_cusarrearage", "", text);
		this.gvdata.DataBind();
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		string[] array = this.hfreclist.Value.Split(new char[]
		{
			'^'
		});
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ChkSltList();");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Text = "<input id=\"cb" + e.Row.Cells[0].Text + "\" type=\"checkbox\" onclick=\"cbone(this);\"/>";
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].ToString() == e.Row.Cells[0].Text)
				{
					e.Row.Cells[1].Text = "<input id=\"cb" + e.Row.Cells[0].Text + "\" type=\"checkbox\" checked=\"checked\" onclick=\"cbone(this);\"/>";
					e.Row.Attributes.Add("style", "background:#D6F1F8;");
					break;
				}
			}
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
