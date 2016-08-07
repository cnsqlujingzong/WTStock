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

public partial class Branch_Basic_SupplierAdm : Page, IRequiresSessionState
{
	

	private int pageSize = 20;

	private int pageSized = 20;

	

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "kh_r33"))
				{
					this.btnDel.Enabled = false;
					this.btnMerge.Disabled = true;
					this.btnExcel.Enabled = false;
					this.btnNew.Disabled = true;
					this.btnClass.Disabled = true;
					this.btntel.Disabled = true;
					this.btnInput.Disabled = true;
				}
			}
			this.LoadClass();
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
	}

	protected void LoadClass()
	{
		int num = 0;
		DataTable dt = DALCommon.GetList_HL(0, "SupplierClass", "", 0, 0, "", " Array Asc", out num).Tables[0];
		this.tvsup.Nodes.Clear();
		TreeNode treeNode = new TreeNode();
		treeNode.Text = "全部(" + num.ToString() + ")";
		treeNode.Value = "-1";
		this.tvsup.Nodes.Add(treeNode);
		Branch_Basic_SupplierAdm.BindTreeNode(treeNode, dt, treeNode.Value);
		TreeNode treeNode2 = new TreeNode();
		treeNode2.Value = "0";
		treeNode2.Text = "未分类";
		this.tvsup.Nodes[0].ChildNodes.Add(treeNode2);
		this.tvsup.Nodes[0].Selected = true;
		this.tvsup.ExpandDepth = 1;
	}

	public static void BindTreeNode(TreeNode node, DataTable dt, string parentid)
	{
		DataRow[] array = dt.Select(" Father=" + parentid);
		DataRow[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			DataRow dataRow = array2[i];
			TreeNode treeNode = new TreeNode();
			treeNode.Text = dataRow["_Name"].ToString();
			treeNode.Value = dataRow["_Level"].ToString();
			treeNode.ToolTip = dataRow["ID"].ToString();
			node.ChildNodes.Add(treeNode);
			Branch_Basic_SupplierAdm.BindTreeNode(treeNode, dt, dataRow["ID"].ToString());
		}
	}

	protected void btnClr_Click(object sender, EventArgs e)
	{
		this.hfcbID.Value = "";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		if (this.hfRecID.Value != "-1")
		{
			this.btnShow_Click(sender, e);
			this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
		}
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		this.hfcbID.Value = "";
		this.hfSch.Value = "0";
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void btnOrder_Click(object sender, EventArgs e)
	{
		this.hfcbID.Value = "";
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
		this.hfcbID.Value = "";
		this.hfSch.Value = "-1";
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void LoadField()
	{
		int userID = 0;
		int.TryParse((string)this.Session["Session_wtUserID"], out userID);
		DALSys dALSys = new DALSys();
		DataTable dataTable = dALSys.GetLayoutDetail(1, 1, 17, 0, userID).Tables[0];
		if (dataTable.Rows.Count > 0)
		{
			this.GvData.Columns.Clear();
			BoundField boundField = new BoundField();
			boundField.DataField = "ID";
			boundField.HeaderText = "ID";
			this.GvData.Columns.Add(boundField);
			boundField = new BoundField();
			boundField.DataField = "bStop";
			boundField.HeaderText = "停用";
			this.GvData.Columns.Add(boundField);
			TemplateField templateField = new TemplateField();
			templateField.HeaderText = "<input id=\"cball\" type=\"checkbox\" class=\"cb1\" onclick=\"SltAllValue();\" title=\"全选/取消全选\"/>";
			templateField.ItemTemplate = new BMyTemplatexgdsadf("", DataControlRowType.DataRow);
			this.GvData.Columns.Add(templateField);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				BoundField boundField2 = new BoundField();
				boundField2.DataField = dataTable.Rows[i]["FieldName"].ToString();
				boundField2.HeaderText = dataTable.Rows[i]["TitleName"].ToString();
				this.GvData.Columns.Add(boundField2);
			}
		}
	}

	protected void FillData(string sortExpression, string direction)
	{
		this.LoadField();
		int recordCount = 0;
		string text = this.strParm();
		string fldSort = sortExpression + " " + direction;
		this.hfSql.Value = text;
		this.GvData.DataSource = DALCommon.GetList_HL(1, "ks_supplier", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
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
				if (i > 2)
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
							HiddenField expr_2A6 = this.hfTbTitle;
							expr_2A6.Value = expr_2A6.Value + "," + text2;
						}
						if (this.hfTbField.Value == string.Empty)
						{
							this.hfTbField.Value = dataField;
						}
						else
						{
							HiddenField expr_2F6 = this.hfTbField;
							expr_2F6.Value = expr_2F6.Value + "," + dataField;
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
		string text = (this.ddlType.SelectedValue == "All") ? "1=1 " : (this.ddlType.SelectedValue + "='√'");
		if (this.hfClass.Value != string.Empty && this.hfClass.Value != "-1")
		{
			if (this.hfClass.Value == "0")
			{
				text += "and ClassID is null ";
			}
			else
			{
				text = text + " and _Level like '" + this.hfClass.Value + "%'";
			}
		}
		string text2 = FunLibrary.ChkInput(this.tbCon.Text);
		if (this.hfSch.Value == "0")
		{
			if (this.ddlKey.SelectedValue != "-1")
			{
				int schid = 0;
				int.TryParse(this.ddlKey.SelectedValue, out schid);
				if (text2 != "")
				{
					DALSupplierList dALSupplierList = new DALSupplierList();
					text += dALSupplierList.GetSchWhere(schid, text2);
				}
			}
		}
		return text;
	}

	protected void GvData_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[19].Visible = false;
		e.Row.Cells[0].Visible = (e.Row.Cells[1].Visible = false);
		string[] array = this.hfcbID.Value.Split(new char[]
		{
			','
		});
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			if (e.Row.Cells[19].Text != this.Session["Session_wtBranchID"].ToString())
			{
				e.Row.Attributes.Add("style", "color:#008000");
			}
			e.Row.Attributes.Add("ondblclick", "ModClick();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[2].Attributes.Add("style", "width:20px;padding-right:5px;");
			if (e.Row.Cells[1].Text == "√")
			{
				e.Row.Attributes.Add("style", "color:#999;");
			}
			e.Row.Cells[2].Text = string.Concat(new string[]
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
					e.Row.Cells[2].Text = string.Concat(new string[]
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
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.GvData.Rows.Count.ToString();
		}
	}

	protected void btnDel_Click(object sender, EventArgs e)
	{
		string value = this.hfcbID.Value;
		if (value == "")
		{
			value = this.hfRecID.Value;
		}
		int num = 0;
		int num2 = 0;
		string empty = string.Empty;
		string[] array = value.Split(new char[]
		{
			','
		});
		DALSupplierList dALSupplierList = new DALSupplierList();
		int num3 = 0;
		for (int i = 0; i < array.Length; i++)
		{
			int.TryParse(array[i].ToString(), out num3);
			SupplierListInfo model = dALSupplierList.GetModel(num3);
			if (!(model.DeptID.ToString() == this.Session["Session_wtBranchID"].ToString()))
			{
				this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
				this.SysInfo("window.alert('操作失败！不是本网点建立的供应商信息')");
				return;
			}
			if (num3 != 0)
			{
				int num4 = DALCommon.DeteleData("SupplierList", "ID=" + num3 + "", out empty);
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
		if (num > 0)
		{
			if (num2 == 0)
			{
				this.SysInfo(string.Concat(new string[]
				{
					"window.alert('操作失败！",
					num.ToString(),
					"条厂商信息信息",
					empty,
					"');"
				}));
			}
			else
			{
				this.SysInfo(string.Concat(new string[]
				{
					"window.alert('",
					num2.ToString(),
					"条厂商信息已删除；",
					num.ToString(),
					"条厂商信息删除失败');"
				}));
			}
		}
		this.hfRecID.Value = "-1";
		this.hfcbID.Value = "";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void SysInfol(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel4, this.UpdatePanel4.GetType(), "SysInfo", str, true);
	}

	protected void tvsup_SelectedNodeChanged(object sender, EventArgs e)
	{
		this.tvsup.SelectedNode.Expanded = new bool?(true);
		this.hfSch.Value = "-1";
		this.hfRecID.Value = "-1";
		this.hfClass.Value = this.tvsup.SelectedNode.Value;
		this.hfClassID.Value = this.tvsup.SelectedNode.ToolTip.ToString();
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
		DataTable dt = DALCommon.GetDataList("ks_supplier", this.hfTbField.Value, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "往来厂商", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert('" + empty + "');");
		}
	}

	protected void btnDelLink_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		int num = DALCommon.DeteleData("SupplierLinkMan", " [ID]=" + this.hfRecID2.Value.Replace("l", ""), out empty);
		if (num == 0)
		{
			this.hfRecID2.Value = "-1";
		}
		else if (num == -1)
		{
			this.SysInfol("window.alert('" + empty + "');");
		}
		else
		{
			this.SysInfol("window.alert('系统错误！请查看错误日志');");
		}
		this.FillDatal();
	}

	protected void FillDatal()
	{
		int recordCount = 0;
		string text = " SupplierID=" + this.hfRecID.Value;
		string fldSort = " ID desc";
		DataSet list_HL = DALCommon.GetList_HL(1, "SupplierLinkMan", "", this.pageSized, this.jsPagerl.CurrentPageIndex, text, fldSort, out recordCount);
		this.GridView1.DataSource = list_HL;
		this.GridView1.DataBind();
		this.lbCountl.Text = recordCount.ToString();
		if (this.lbCountl.Text == "0")
		{
			this.lbCountl.Visible = false;
			this.lbPagel.Visible = false;
			this.lbCountTextl.Visible = false;
		}
		else
		{
			this.lbCountl.Visible = true;
			this.lbPagel.Visible = true;
			this.lbCountTextl.Visible = true;
		}
		this.jsPagerl.PageSize = this.pageSized;
		this.jsPagerl.RecordCount = recordCount;
		if (this.ddlKey.SelectedValue == "3" && !this.tbCon.Text.Trim().Equals(""))
		{
			string text2 = FunLibrary.SqlSeltC(this.tbCon.Text.Trim());
			if (text2.Equals(this.tbCon.Text.Trim()))
			{
				DataRow[] array = list_HL.Tables[0].Select("_Name like '%" + this.tbCon.Text.Trim() + "%'");
				if (array.Length > 0)
				{
					this.SysInfol("ClrID2('l" + array[0]["ID"].ToString() + "')");
				}
			}
			else
			{
				int num;
				DataSet list_HL2 = DALCommon.GetList_HL(0, "SupplierLinkMan", "top 1 ID", 0, 0, text + " and _Name like '%" + text2 + "%'", "ID", out num);
				if (list_HL2.Tables[0].Rows.Count > 0)
				{
					this.SysInfol("ClrID2('l" + list_HL2.Tables[0].Rows[0][0].ToString() + "')");
				}
			}
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "l" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('l" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ModLink();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPagel.Text = "当前页:" + this.GridView1.Rows.Count.ToString();
		}
	}

	protected void jsPagerl_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID2.Value = "-1";
		this.FillDatal();
	}

	protected void btnShow_Click(object sender, EventArgs e)
	{
		this.FillDatal();
	}
}
