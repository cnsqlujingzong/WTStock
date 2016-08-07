using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using wt.OtherLibrary;

public partial class Branch_Lease_CRelease : Page, IRequiresSessionState
{
	

	private int id;

	

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "zl_r8"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			OtherFunction.BindStocks(this.ddlStock, " DeptID=" + int.Parse((string)this.Session["Session_wtBranchID"]) + " and bStop=0 ");
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=" + int.Parse((string)this.Session["Session_wtBranchID"]) + " and Status=0");
			string b = (string)this.Session["Session_wtUserB"];
			for (int i = 0; i < this.ddlOperator.Items.Count; i++)
			{
				if (this.ddlOperator.Items[i].Text == b)
				{
					this.ddlOperator.Items[i].Selected = true;
					break;
				}
			}
			this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
			this.gvdata.DataSource = DALCommon.GetDataList("zl_leasedevice", "", " DevStatus='正常' and BillID=" + this.id);
			this.gvdata.DataBind();
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		string str = "";
		DALLease dALLease = new DALLease();
		List<string[]> list = new List<string[]>();
		for (int i = 0; i < this.gvdata.Rows.Count; i++)
		{
			decimal num = 0m;
			string[] array = new string[3];
			array[0] = "LeaseDevice";
			TextBox textBox = this.gvdata.Rows[i].FindControl("tbPrice") as TextBox;
			decimal.TryParse(textBox.Text, out num);
			string text = " InPrice=" + num.ToString();
			array[1] = text;
			int num2;
			int.TryParse(this.gvdata.Rows[i].Cells[1].Text, out num2);
			array[2] = " [ID]=" + num2.ToString();
			list.Add(array);
		}
		int num3 = dALLease.UpdateInPrice(list, out str);
		int iPerson = 0;
		int.TryParse((string)this.Session["Session_wtUserBID"], out iPerson);
		int iStock = int.Parse(this.ddlStock.SelectedValue);
		if (num3 == 0)
		{
			num3 = dALLease.ChkRelease(1, this.id, int.Parse(this.ddlOperator.SelectedValue), iPerson, iStock, this.tbDate.Text, out str);
		}
		if (num3 == 0)
		{
			this.SysInfo("window.alert('操作成功！合同已解约');parent.CloseDialog('1');");
		}
		else
		{
			this.SysInfo("window.alert('操作失败！" + str + "');");
		}
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[1].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[0].Attributes.Add("style", "width:20px;padding:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
