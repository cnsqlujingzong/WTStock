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
using wt.Model;
using Wuqi.Webdiyer;

public partial class Headquarters_Repository_RepositoryAdm : Page, IRequiresSessionState
{

	private int pageSize = 20;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "bg_r10"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
				if (!dALRight.GetRight(num, "bg_r12"))
				{
					this.btnDel.Enabled = false;
				}
			}
			this.LoadClass();
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
	}

	protected void LoadClass()
	{
		int num = 0;
		DataTable dt = DALCommon.GetList_HL(0, "RepositoryClass", "", 0, 0, "", " ID Asc", out num).Tables[0];
		this.tv.Nodes.Clear();
		TreeNode treeNode = new TreeNode();
		treeNode.Text = "全部(" + num.ToString() + ")";
		treeNode.Value = "-1";
		this.tv.Nodes.Add(treeNode);
		this.InitFirst(dt, treeNode);
		this.tv.Nodes[0].Selected = true;
		TreeNode treeNode2 = new TreeNode();
		treeNode2.Value = "0";
		treeNode2.Text = "未分类";
		this.tv.Nodes[0].ChildNodes.Add(treeNode2);
		this.tv.Nodes[0].Selected = true;
	}

	protected void InitFirst(DataTable dt, TreeNode menu)
	{
		if (!dt.Rows.Count.Equals(0))
		{
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				TreeNode treeNode = new TreeNode();
				treeNode.Text = dt.Rows[i]["_Name"].ToString();
				treeNode.Value = dt.Rows[i]["ID"].ToString();
				menu.ChildNodes.Add(treeNode);
			}
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
		this.GvData.DataSource = DALCommon.GetList_HL(1, "zs_repository", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
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
				if (i != 6)
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
							HiddenField expr_29C = this.hfTbTitle;
							expr_29C.Value = expr_29C.Value + "," + text2;
						}
						if (this.hfTbField.Value == string.Empty)
						{
							this.hfTbField.Value = dataField;
						}
						else
						{
							HiddenField expr_2EC = this.hfTbField;
							expr_2EC.Value = expr_2EC.Value + "," + dataField;
						}
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
		if (this.hfClass.Value != string.Empty && this.hfClass.Value != "-1")
		{
			if (this.hfClass.Value == "0")
			{
				text += "and ClassID is null ";
			}
			else
			{
				text = text + "and ClassID=" + this.hfClass.Value.Replace("'", "");
			}
		}
		if (this.hfSch.Value == "0")
		{
			if (this.ddlKey.SelectedValue != "-1")
			{
				string text2 = FunLibrary.ChkInput(this.tbCon.Text);
				if (this.tbCon.Text.Trim() != "")
				{
					if (this.ddlKey.SelectedValue == "Author")
					{
						string text3 = text;
						text = string.Concat(new string[]
						{
							text3,
							" and (",
							this.ddlKey.SelectedValue,
							" like '%",
							text2,
							"%' or AuthorNO like '%",
							text2,
							"%')"
						});
					}
					else
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
			e.Row.Cells[6].Text = string.Concat(new string[]
			{
				"&nbsp;&nbsp;<a href=\"RepositoryView.aspx?id=",
				e.Row.Cells[0].Text,
				"\" id=\"a",
				e.Row.Cells[0].Text,
				"\" target=\"_blank\"><img src=\"../../Public/Images/page.gif\" border=\"0\" /></a>"
			});
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.GvData.Rows.Count.ToString();
		}
	}

	protected void btnDel_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		DALRepository dALRepository = new DALRepository();
		RepositoryInfo model = dALRepository.GetModel(int.Parse(this.hfRecID.Value));
		if (dALRepository != null)
		{
			if (model.AuthorID == int.Parse((string)this.Session["Session_wtUserID"]))
			{
				int num = DALCommon.DeteleData("Repository", "[ID]=" + this.hfRecID.Value, out empty);
				if (num == 0)
				{
					this.hfRecID.Value = "-1";
				}
				else if (num == -1)
				{
					this.SysInfo("window.alert(\"" + empty + "\");");
				}
				else
				{
					this.SysInfo("window.alert('系统错误！请查看错误日志');");
				}
			}
			else
			{
				this.SysInfo("window.alert('操作失败！只允许删除自己建的知识');");
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
		this.tv.SelectedNode.Expanded = new bool?(true);
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
		DataTable dt = DALCommon.GetDataList("zs_repository", this.hfTbField.Value, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "知识", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert(\"" + empty + "\");");
		}
	}
}
