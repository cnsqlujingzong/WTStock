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
using Wuqi.Webdiyer;

public partial class Branch_Office_MailAdm : Page, IRequiresSessionState
{
	
	private int pageSize = 20;


	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "bg_r7"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			this.LoadClass();
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
	}

	protected void LoadClass()
	{
		DALOA_Mail dALOA_Mail = new DALOA_Mail();
		string str = dALOA_Mail.TCount(" RcvID='" + int.Parse((string)this.Session["Session_wtUserBID"]) + "' and bRead=0 and bSndFlag=1 and bRcvFlag=0 ");
		this.tv.Nodes.Clear();
		TreeNode treeNode = new TreeNode();
		treeNode.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + (string)this.Session["Session_wtUserB"];
		treeNode.Value = "-1";
		this.tv.Nodes.Add(treeNode);
		treeNode = new TreeNode();
		treeNode.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;收件箱(" + str + ")";
		treeNode.Value = "0";
		this.tv.Nodes[0].ChildNodes.Add(treeNode);
		treeNode = new TreeNode();
		treeNode.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;发件箱";
		treeNode.Value = "1";
		this.tv.Nodes[0].ChildNodes.Add(treeNode);
		treeNode = new TreeNode();
		treeNode.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;已发送的邮件";
		treeNode.Value = "2";
		this.tv.Nodes[0].ChildNodes.Add(treeNode);
		treeNode = new TreeNode();
		treeNode.Text = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;废件箱";
		treeNode.Value = "3";
		this.tv.Nodes[0].ChildNodes.Add(treeNode);
	}

	protected void btnClr_Click(object sender, EventArgs e)
	{
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
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

	protected void btnFsh_Click(object sender, EventArgs e)
	{
		this.hfSch.Value = "-1";
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void FillData(string sortExpression, string direction)
	{
		int recordCount = 0;
		string text = this.strParm();
		string fldSort = sortExpression + " " + direction;
		this.hfSql.Value = text;
		this.GvData.DataSource = DALCommon.GetList_HL(1, "oa_mail", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
		this.GvData.DataBind();
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
		if (this.GvData.Rows.Count > 0)
		{
			for (int i = 0; i < this.GvData.HeaderRow.Cells.Count; i++)
			{
				string dataField = ((BoundField)this.GvData.Columns[i]).DataField;
				string text2 = this.GvData.HeaderRow.Cells[i].Text;
				this.GvData.HeaderRow.Cells[i].Attributes.Add("id", dataField);
				this.GvData.HeaderRow.Cells[i].Attributes.Add("onclick", string.Concat(new string[]
				{
					"HeaderOrder('",
					dataField,
					"','",
					text2,
					"');"
				}));
				this.GvData.HeaderRow.Cells[i].Attributes.Add("onmouseover", "this.style.cursor='default';");
				if (dataField != "ID")
				{
					if (this.hfTbTitle.Value == string.Empty)
					{
						this.hfTbTitle.Value = text2;
					}
					else
					{
						HiddenField expr_28F = this.hfTbTitle;
						expr_28F.Value = expr_28F.Value + "," + text2;
					}
					if (this.hfTbField.Value == string.Empty)
					{
						this.hfTbField.Value = dataField;
					}
					else
					{
						HiddenField expr_2DF = this.hfTbField;
						expr_2DF.Value = expr_2DF.Value + "," + dataField;
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
		string text = "1=1 ";
		string value = this.hfClass.Value;
		if (value != null)
		{
			if (!(value == "-1") && !(value == "0"))
			{
				if (!(value == "1"))
				{
					if (!(value == "2"))
					{
						if (value == "3")
						{
							text = text + " and RcvID='" + (string)this.Session["Session_wtUserBID"] + "' and bRcvFlag=1 ";
						}
					}
					else
					{
						text = text + " and SndID='" + (string)this.Session["Session_wtUserBID"] + "'and bSndFlag=1 ";
					}
				}
				else
				{
					text = text + " and SndID='" + (string)this.Session["Session_wtUserBID"] + "' and bSndFlag=0 ";
				}
			}
			else
			{
				text = text + " and RcvID='" + (string)this.Session["Session_wtUserBID"] + "' and bRcvFlag=0 and bSndFlag=1 ";
			}
		}
		if (this.hfSch.Value == "0")
		{
			if (this.ddlKey.SelectedValue != "-1")
			{
				if (this.tbCon.Text.Trim() != "")
				{
					string text2 = text;
					text = string.Concat(new string[]
					{
						text2,
						" and ",
						this.ddlKey.SelectedValue,
						" like '%",
						FunLibrary.ChkInput(this.tbCon.Text),
						"%'"
					});
				}
			}
		}
		return text;
	}

	protected void GvData_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ModClick();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			if (e.Row.Cells[1].Text.ToLower() == "false")
			{
				e.Row.Cells[1].Text = "&nbsp;<img src=\"../../Public/Images/Mail/mail.gif\" />";
				e.Row.Attributes.Add("title", "这是一封新邮件，双击打开");
			}
			else
			{
				e.Row.Cells[1].Text = "&nbsp;<img src=\"../../Public/Images/Mail/read.gif\" />";
			}
			if (e.Row.Cells[6].Text.ToLower() == "false")
			{
				e.Row.Cells[6].Text = "&nbsp;";
			}
			else
			{
				e.Row.Cells[6].Text = "<img src=\"../../Public/Images/Mail/accessory.gif\" title=\"含有附件\" />";
			}
		}
		if (this.hfClass.Value == "1" || this.hfClass.Value == "2")
		{
			e.Row.Cells[2].Visible = false;
		}
		else
		{
			e.Row.Cells[3].Visible = false;
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.GvData.Rows.Count.ToString();
		}
	}

	protected void btnDel_Click(object sender, EventArgs e)
	{
		int recID = 0;
		int.TryParse(this.hfRecID.Value, out recID);
		DALOA_Mail dALOA_Mail = new DALOA_Mail();
		string value = this.hfClass.Value;
		if (value != null)
		{
			if (!(value == "-1") && !(value == "0"))
			{
				if (!(value == "1"))
				{
					if (!(value == "2"))
					{
						if (value == "3")
						{
							dALOA_Mail.UpdateRcv(recID, 2);
						}
					}
					else
					{
						dALOA_Mail.UpdateSnd(recID, 2);
					}
				}
				else
				{
					dALOA_Mail.UpdateSnd(recID, 2);
				}
			}
			else
			{
				dALOA_Mail.UpdateRcv(recID, 1);
			}
		}
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void tv_SelectedNodeChanged(object sender, EventArgs e)
	{
		this.hfSch.Value = "-1";
		this.hfRecID.Value = "-1";
		this.hfClass.Value = this.tv.SelectedNode.Value;
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
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
		DataTable dt = DALCommon.GetDataList("oa_mail", this.hfTbField.Value, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "邮件", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert('" + empty + "');");
		}
	}

	protected void btnSend_Click(object sender, EventArgs e)
	{
		int recID = 0;
		int.TryParse(this.hfRecID.Value, out recID);
		DALOA_Mail dALOA_Mail = new DALOA_Mail();
		dALOA_Mail.UpdateSnd(recID, 1);
		this.SysInfo("window.alert('邮件已经发送成功...！');");
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}
}
