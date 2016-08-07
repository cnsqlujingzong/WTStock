using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using wt.OtherLibrary;

public partial class Headquarters_Stat_StExtServices : Page, IRequiresSessionState
{
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "tj_r37"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			OtherFunction.BindBranch(this.ddlBranch);
			this.ddlBranch.Items.Insert(0, new ListItem("全部", "-1"));
			this.tbDateB.Text = DateTime.Now.ToString("yyyy-MM-") + "01";
			this.tbDateE.Text = DateTime.Now.ToString("yyyy-MM-dd");
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
	}

	protected void btnOrder_Click(object sender, EventArgs e)
	{
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		if (this.hfOrder.Value != "ID")
		{
			this.SysInfo("ClrHeaderOrder('" + this.hfOrderName.Value + "');");
		}
		if (this.hfRecID.Value != "-1")
		{
			this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
		}
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		this.hfSch.Value = "0";
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void FillData(string sortExpression, string direction)
	{
		string text = FunLibrary.ChkInput(this.tbDateB.Text);
		string text2 = FunLibrary.ChkInput(this.tbDateE.Text);
		string text3 = " curStatus='已结束' and SJPoint>bPoint and bPoint>0 ";
		if (this.ddlBranch.SelectedValue != "-1")
		{
			text3 = text3 + " and DisposalID=" + this.ddlBranch.SelectedValue;
		}
		if (text != "")
		{
			text3 = text3 + " and Time_TakeOver>='" + text + " 00:00:00'";
		}
		if (text2 != "")
		{
			text3 = text3 + " and Time_TakeOver<='" + text2 + " 23:59:59'";
		}
		this.gvdata.DataSource = DALCommon.GetDataList("fw_extendedservices", "", text3);
		this.gvdata.DataBind();
		this.hfTbTitle.Value = (this.hfTbField.Value = string.Empty);
		if (this.gvdata.Rows.Count > 0)
		{
			for (int i = 0; i < this.gvdata.HeaderRow.Cells.Count; i++)
			{
				if (i > 0)
				{
					string dataField = ((BoundField)this.gvdata.Columns[i]).DataField;
					string text4 = this.gvdata.HeaderRow.Cells[i].Text;
					if (this.hfTbTitle.Value == string.Empty)
					{
						this.hfTbTitle.Value = text4;
					}
					else
					{
						HiddenField expr_1A8 = this.hfTbTitle;
						expr_1A8.Value = expr_1A8.Value + "," + text4;
					}
					if (this.hfTbField.Value == string.Empty)
					{
						this.hfTbField.Value = dataField;
					}
					else
					{
						HiddenField expr_1F8 = this.hfTbField;
						expr_1F8.Value = expr_1F8.Value + "," + dataField;
					}
				}
			}
		}
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		e.Row.Cells[1].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Cells[0].Text = Convert.ToDouble(e.Row.RowIndex + 1).ToString();
			e.Row.Attributes.Add("id", e.Row.Cells[1].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[1].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ChkView();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[0].Attributes.Add("style", "width:20px;padding-right:0px;text-align:center;");
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		string text = FunLibrary.ChkInput(this.tbDateB.Text);
		string text2 = FunLibrary.ChkInput(this.tbDateE.Text);
		string text3 = " curStatus='已结束' and SJPoint>bPoint and bPoint>0 ";
		if (this.ddlBranch.SelectedValue != "-1")
		{
			text3 = text3 + " and DisposalID=" + this.ddlBranch.SelectedValue;
		}
		if (text != "")
		{
			text3 = text3 + " and Time_TakeOver>='" + text + " 00:00:00'";
		}
		if (text2 != "")
		{
			text3 = text3 + " and Time_TakeOver<='" + text2 + " 23:59:59'";
		}
		DataTable dt = DALCommon.GetDataList("fw_extendedservices", this.hfTbField.Value, text3).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "StExtSer", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert(\"" + empty + "\");");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
