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
using Wuqi.Webdiyer;

public partial class Headquarters_Customer_ConsumablesTrack : Page, IRequiresSessionState
{
	private int pageSize = 15;

	private int iflag;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["iflag"], out this.iflag);
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "kh_r11"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
				if (dALRight.GetRight(num, "kh_r18"))
				{
					DataTable dataTable = DALCommon.GetDataList("StaffList", "Area", " [ID]=" + (string)this.Session["Session_wtUserID"]).Tables[0];
					if (dataTable.Rows.Count > 0)
					{
						this.hfPurArea.Value = dataTable.Rows[0]["Area"].ToString();
					}
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
			if (this.iflag == 0)
			{
				this.cbHidden.Checked = true;
			}
			this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
	}

	protected void btnClr_Click(object sender, EventArgs e)
	{
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		if (this.hfRecID.Value != "-1")
		{
			this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
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
		this.hfParm.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void btnFsh_Click(object sender, EventArgs e)
	{
		this.hfSch.Value = "-1";
		this.hfRecID.Value = "-1";
		this.hfParm.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void FillData(string sortExpression, string direction)
	{
		int recordCount = 0;
		string text = (this.hfParm.Value == "-1") ? this.strParm() : (this.hfParm.Value + " and DeptID=1 and datediff(d,getdate(),WDate-7)<=0 and Status=" + this.ddlStatus.SelectedItem.Value);
		string fldSort = sortExpression + " " + direction;
		if (this.iflag == 1)
		{
			text = ((this.hfParm.Value == "-1") ? this.strParm() : (this.hfParm.Value + " and DeptID=1 and datediff(d,getdate(),WDate-7)<=0 and Status=" + this.ddlStatus.SelectedItem.Value));
		}
		if (this.hfPurArea.Value != "")
		{
			text = text + " and (CHARINDEX('" + this.hfPurArea.Value + "',Area)>0 or Area='' or Area is null) ";
		}
		if (this.cbHidden.Checked)
		{
			text += " and convert(varchar(100),WDate,23)>=convert(varchar(100),getdate(),23) ";
		}
		this.hfSql.Value = text;
		this.gvdata.DataSource = DALCommon.GetList_HL(1, "ks_consumablestrack", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
		this.gvdata.DataBind();
		this.lbCount.Text = recordCount.ToString();
		if (this.lbCount.Text == "0")
		{
			this.lbCount.Visible = false;
			this.lbPage.Visible = false;
			this.lbCountText.Visible = false;
		}
		else
		{
			this.lbCount.Visible = true;
			this.lbPage.Visible = true;
			this.lbCountText.Visible = true;
		}
		this.jsPager.PageSize = this.pageSize;
		this.jsPager.RecordCount = recordCount;
		this.hfTbTitle.Value = (this.hfTbField.Value = string.Empty);
		if (this.gvdata.Rows.Count > 0)
		{
			for (int i = 0; i < this.gvdata.HeaderRow.Cells.Count; i++)
			{
				if (i > 1)
				{
					string dataField = ((BoundField)this.gvdata.Columns[i]).DataField;
					string text2 = this.gvdata.HeaderRow.Cells[i].Text;
					this.gvdata.HeaderRow.Cells[i].Attributes.Add("id", dataField);
					this.gvdata.HeaderRow.Cells[i].Attributes.Add("onclick", string.Concat(new string[]
					{
						"HeaderOrder('",
						dataField,
						"','",
						text2,
						"');"
					}));
					this.gvdata.HeaderRow.Cells[i].Attributes.Add("onmouseover", "this.style.cursor='default';");
					if (this.hfTbTitle.Value == string.Empty)
					{
						this.hfTbTitle.Value = text2;
					}
					else
					{
						HiddenField expr_38C = this.hfTbTitle;
						expr_38C.Value = expr_38C.Value + "," + text2;
					}
					if (this.hfTbField.Value == string.Empty)
					{
						this.hfTbField.Value = dataField;
					}
					else
					{
						HiddenField expr_3DC = this.hfTbField;
						expr_3DC.Value = expr_3DC.Value + "," + dataField;
					}
				}
			}
		}
	}

	protected void jsPager_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected string strParm()
	{
		string text = " DeptID=1 and datediff(d,getdate(),WDate-7)<=0 ";
		if (this.iflag == 1)
		{
			text = " DeptID=1 and datediff(d,getdate(),WDate-7)<=0 ";
		}
		text = text + " and Status=" + this.ddlStatus.SelectedItem.Value;
		string text2 = FunLibrary.ChkInput(this.tbCon.Text);
		if (this.hfSch.Value == "0")
		{
			if (this.ddlKey.SelectedValue != "-1")
			{
				if (text2 != "")
				{
					string text3 = text;
					text = string.Concat(new string[]
					{
						text3,
						" and ",
						this.ddlKey.SelectedValue,
						" like '%",
						text2,
						"%' "
					});
				}
			}
		}
		return text;
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		string empty = string.Empty;
		string[] array = this.hfcbID.Value.Split(new char[]
		{
			','
		});
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;");
			e.Row.Cells[1].Text = string.Concat(new string[]
			{
				"<input id=\"cb",
				e.Row.Cells[0].Text,
				"\" type=\"checkbox\" onclick=\"SltValue('",
				e.Row.Cells[0].Text,
				"',this);\"/>"
			});
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].ToString() == e.Row.Cells[0].Text)
				{
					e.Row.Cells[1].Text = string.Concat(new string[]
					{
						"<input id=\"cb",
						e.Row.Cells[0].Text,
						"\" type=\"checkbox\" checked=\"checked\" onclick=\"SltValue('",
						e.Row.Cells[0].Text,
						"',this);\"/>"
					});
					break;
				}
			}
			if (e.Row.Cells[3].Text == "销售")
			{
				e.Row.Cells[4].Text = string.Concat(new string[]
				{
					"<a href=\"#\" style=\"color:#0000ff\" onclick=\"Sell('",
					e.Row.Cells[4].Text,
					"','销售单')\">",
					e.Row.Cells[4].Text,
					"</a>"
				});
			}
			else if (e.Row.Cells[3].Text == "租赁")
			{
				e.Row.Cells[4].Text = string.Concat(new string[]
				{
					"<a href=\"#\" style=\"color:#0000ff\" onclick=\"Lease('",
					e.Row.Cells[4].Text,
					"')\">",
					e.Row.Cells[4].Text,
					"</a>"
				});
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.gvdata.Rows.Count.ToString();
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		string strCondition = string.Concat(new string[]
		{
			this.hfSql.Value,
			" order by ",
			this.hfOrderName.Value,
			" ",
			this.hfOrder.Value
		});
		DataTable dt = DALCommon.GetDataList("ks_consumablestrack", this.hfTbField.Value, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "track", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert('" + empty + "');");
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		string text = "";
		DALConsumablesTrack dALConsumablesTrack = new DALConsumablesTrack();
		int num = 0;
		int iOperator = 0;
		int.TryParse(this.ddlOperator.SelectedValue, out iOperator);
		string strDate = FunLibrary.ChkInput(this.tbDate.Text);
		string strResult = FunLibrary.ChkInput(this.tbRemark.Text);
		int.TryParse(this.hfRecID.Value, out num);
		if (num > 0)
		{
			int num2 = dALConsumablesTrack.ChkDoTrack(num, iOperator, strDate, strResult, false, "", out text);
			if (num2 == 0)
			{
				this.hfRecID.Value = "-1";
				this.SysInfo("window.alert('" + text + "');");
			}
			else
			{
				this.SysInfo(string.Concat(new string[]
				{
					"window.alert('",
					text,
					"');ChkID('",
					this.hfRecID.Value,
					"');"
				}));
			}
		}
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void btnCancel_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		DALConsumablesTrack dALConsumablesTrack = new DALConsumablesTrack();
		int num = 0;
		int num2 = 0;
		string value = this.hfcbID.Value;
		if (value == "")
		{
			value = this.hfRecID.Value;
		}
		string[] array = value.Split(new char[]
		{
			','
		});
		int num3 = 0;
		for (int i = 0; i < array.Length; i++)
		{
			int.TryParse(array[i].ToString(), out num3);
			if (num3 != 0)
			{
				int num4 = dALConsumablesTrack.ChkCancel(num3, out empty);
				if (num4 == 0)
				{
					num2++;
				}
				else
				{
					num++;
				}
			}
		}
		if (num == 0)
		{
			this.SysInfo("window.alert('操作成功！" + num2.ToString() + "条耗材跟踪已取消');");
		}
		else if (num2 == 0)
		{
			this.SysInfo("window.alert('操作失败！" + num.ToString() + "条耗材跟踪状态已变化，请刷新后操作！');");
		}
		else
		{
			this.SysInfo(string.Concat(new string[]
			{
				"window.alert('",
				num2.ToString(),
				"条已取消；",
				num.ToString(),
				"条耗材跟踪状态已变化，请刷新后操作！');"
			}));
		}
		this.hfRecID.Value = "-1";
		this.hfcbID.Value = "";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void cbHidden_CheckedChanged(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.hfParm.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}
}
