using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using wt.Model;
using Wuqi.Webdiyer;

public partial class Web_ServicesCall : Page, IRequiresSessionState
{
	private string user;


	protected void Page_Load(object sender, EventArgs e)
	{
		this.ChkWebUser();
		this.user = (string)this.Session["Session_Web_Name"];
		if (!base.IsPostBack)
		{
			this.hfcusid.Value = "-1";
			DALAssociator dALAssociator = new DALAssociator();
			AssociatorInfo model = dALAssociator.GetModel(this.user);
			if (model != null)
			{
				if (model.CustomerID > 0)
				{
					this.hfcusid.Value = model.CustomerID.ToString();
				}
			}
			this.DisplayData();
		}
	}

	public void ChkWebUser()
	{
		if (this.Session["Session_Web_Name"] == null || this.Session["Session_Web_ID"] == null)
		{
			base.Response.Write("<Script>top.location.href = 'Default.aspx?a=1';</Script>");
			base.Response.End();
		}
	}

	protected void DisplayData()
	{
		this.hfrecid.Value = string.Empty;
		this.hfreclist.Value = string.Empty;
	}

	protected void btnfresh_Click(object sender, EventArgs e)
	{
		this.DisplayData();
	}

	protected void jsPager_PageChanged(object sender, EventArgs e)
	{
		this.DisplayData();
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[1].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[1].Text);
			e.Row.Attributes.Add("onmouseover", "this.bgColor='#ffffd1'");
			e.Row.Attributes.Add("onmouseout", "this.bgColor=''");
			e.Row.Cells[0].Text = "<input id=\"cb" + e.Row.Cells[1].Text + "\" type=\"checkbox\" class=\"cb1\" onclick=\"cbone(this);\"/>";
			e.Row.Cells[9].Text = "<a href=\"BillView.aspx?id=" + e.Row.Cells[2].Text + "\" title=\"�鿴��ϸ��Ϣ\">�鿴</a>";
			string text = e.Row.Cells[4].Text;
			if (text == "������")
			{
				e.Row.Cells[4].Text = "<span style=\"color:#fff;background:#ff0000\">" + text + "</span>";
			}
			else if (text == "������")
			{
				e.Row.Cells[4].Text = "<span style=\"color:#fff;background:#0000ff\">" + text + "</span>";
			}
			else if (text == "���ط�")
			{
				e.Row.Cells[4].Text = "<span style=\"color:#fff;background:#008000\">" + text + "</span>";
			}
			else if (text == "��ȡ��")
			{
				e.Row.Cells[4].Text = "<span style=\"color:#fff;background:#848284\">" + text + "</span>";
			}
			else if (text == "�ѽ���")
			{
				e.Row.Cells[4].Text = "<span style=\"color:#fff;background:#840000\">" + text + "</span>";
			}
			else if (text == "����")
			{
				e.Row.Cells[4].Text = "<span style=\"color:#fff;background:#8a4000\">" + text + "</span>";
			}
			else if (text == "�����")
			{
				e.Row.Cells[4].Text = "<span style=\"color:#fff;background:#333\">" + text + "</span>";
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "��ǰҳ:" + this.GridView1.Rows.Count.ToString();
		}
	}

	protected string strParm()
	{
		string text = " RecID>0 ";
		if (this.ddlkey.SelectedValue != "-1")
		{
			if (this.tbcon.Text.Trim() != "")
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					"and ",
					this.ddlkey.SelectedValue,
					" like '%",
					FunLibrary.ChkInput(this.tbcon.Text),
					"%'"
				});
			}
		}
		return text;
	}

	protected void btnsch_Click(object sender, EventArgs e)
	{
		this.DisplayData();
		this.ReturnStr("��ѯ���.");
	}

	protected void ReturnStr(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "ReturnStr", "document.getElementById(\"span_info\").style.display=\"inline\";document.getElementById(\"span_info\").innerHTML=\"" + str + "\";", true);
	}
}