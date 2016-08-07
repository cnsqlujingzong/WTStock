using System;
using System.Collections.Generic;
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

public partial class Headquarters_Lease_Reading : Page, IRequiresSessionState
{
	private int id;

	public string Str_id
	{
		get
		{
			return this.id.ToString();
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "zl_r3"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=1 and Status=0");
			string b = (string)this.Session["Session_wtUser"];
			for (int i = 0; i < this.ddlOperator.Items.Count; i++)
			{
				if (this.ddlOperator.Items[i].Text == b)
				{
					this.ddlOperator.Items[i].Selected = true;
					break;
				}
			}
			this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
			this.gvdata.DataSource = DALCommon.GetDataList("zl_leasedetail", "", " DevStatus='正常' and iBillID=" + this.id);
			this.gvdata.DataBind();
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < this.gvdata.Rows.Count; i++)
		{
			TextBox textBox = this.gvdata.Rows[i].FindControl("tbQty") as TextBox;
			int.TryParse(textBox.Text, out num2);
			num += num2;
		}
		if (num == 0)
		{
			this.SysInfo("window.alert('操作失败！未填写任何计数信息，操作已终止。');");
		}
		else
		{
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			string str = "";
			bool flag = false;
			DALMeterReading dALMeterReading = new DALMeterReading();
			for (int i = 0; i < this.gvdata.Rows.Count; i++)
			{
				List<string[]> list = new List<string[]>();
				int.TryParse(this.gvdata.Rows[i].Cells[1].Text, out num3);
				int.TryParse(this.gvdata.Rows[i].Cells[2].Text, out num4);
				int.TryParse(this.gvdata.Rows[i].Cells[3].Text, out num5);
				TextBox textBox = this.gvdata.Rows[i].FindControl("tbQty") as TextBox;
				if (string.IsNullOrEmpty(textBox.Text))
				{
					flag = true;
				}
				int.TryParse(textBox.Text, out num);
				TextBox textBox2 = this.gvdata.Rows[i].FindControl("tbLoss") as TextBox;
				TextBox textBox3 = this.gvdata.Rows[i].FindControl("tbWDate") as TextBox;
				TextBox textBox4 = this.gvdata.Rows[i].FindControl("tbWRemark") as TextBox;
				int.TryParse(textBox2.Text, out num6);
				DataTable dataTable = DALCommon.GetDataList("zl_meterreading", "Top 1 *", string.Concat(new object[]
				{
					" BillID=",
					this.id,
					" and QtyType=",
					num4,
					" and DeviceID=",
					num3,
					" order by [ID] desc"
				})).Tables[0];
				if (flag)
				{
					if (dataTable.Rows.Count > 0)
					{
						int.TryParse(dataTable.Rows[0]["Qty"].ToString(), out num);
					}
				}
				flag = false;
				int num8 = 0;
				if (dataTable.Rows.Count > 0)
				{
					int.TryParse(dataTable.Rows[0]["Qty"].ToString(), out num8);
				}
				else
				{
					num8 = 0;
				}
				int num9 = num - num8 - num6;
				if (num4 > 0)
				{
					list.Add(new string[]
					{
						num3.ToString(),
						this.tbDate.Text,
						this.ddlOperator.SelectedValue,
						num.ToString(),
						num4.ToString(),
						FunLibrary.ChkInput(textBox3.Text),
						FunLibrary.ChkInput(textBox4.Text),
						num5.ToString(),
						num6.ToString(),
						num9.ToString()
					});
				}
				num7 = dALMeterReading.Add(list, out str);
			}
			if (num7 == 0)
			{
				this.SysInfo("window.alert(\"操作成功！计数已登记\");parent.CloseDialog('1');");
			}
			else if (num7 == -1)
			{
				this.SysInfo("window.alert('" + str + "');");
			}
			else
			{
				this.SysInfo("window.alert('系统错误！请查看错误日志');");
			}
		}
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = (e.Row.Cells[1].Visible = (e.Row.Cells[2].Visible = (e.Row.Cells[3].Visible = false)));
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[4].Attributes.Add("style", "width:30px;padding:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[4].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
