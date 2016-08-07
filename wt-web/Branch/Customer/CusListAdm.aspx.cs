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

public partial class Branch_Customer_CusListAdm : Page, IRequiresSessionState
{
	private int pageSize = 20;

	private int pageSized = 10;

	

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "kh_r1"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
				if (!dALRight.GetRight(num, "kh_r3"))
				{
					this.btnDel.Enabled = false;
					this.btnDelLink.Enabled = false;
					this.btnDelDept.Enabled = false;
					this.btnMerge.Disabled = true;
				}
				if (!dALRight.GetRight(num, "kh_r7"))
				{
					this.btnDelD.Enabled = false;
				}
				if (!dALRight.GetRight(num, "kh_r4"))
				{
					this.btnExcel.Enabled = false;
				}
				if (!dALRight.GetRight(num, "kh_r14"))
				{
					this.btnDelCont.Enabled = false;
				}
				if (!dALRight.GetRight(num, "kh_r15"))
				{
					this.btnCancel.Visible = false;
				}
				if (!dALRight.GetRight(num, "kh_r5"))
				{
					this.hfPurDev.Value = "0";
				}
				if (!dALRight.GetRight(num, "gd_r1"))
				{
					this.hfPurSer.Value = "0";
				}
				if (!dALRight.GetRight(num, "xs_r3"))
				{
					this.hfPurSel.Value = "0";
				}
				if (!dALRight.GetRight(num, "zl_r12"))
				{
					this.hfPurLea.Value = "0";
				}
				if (!dALRight.GetRight(num, "kh_r11"))
				{
					this.hfPurCont.Value = "0";
				}
				if (!dALRight.GetRight(num, "kh_r2"))
				{
					this.btnInput.Visible = false;
				}
				if (!dALRight.GetRight(num, "kh_r17"))
				{
					this.btnNewT.Visible = false;
				}
				if (!dALRight.GetRight(num, "kh_r18"))
				{
					this.btnModT.Visible = false;
				}
				if (!dALRight.GetRight(num, "kh_r28"))
				{
					this.btnAllot.Visible = false;
				}
				if (!dALRight.GetRight(num, "kh_r19"))
				{
					this.btnDelT.Enabled = false;
				}
				if (dALRight.GetRight(num, "kh_r10"))
				{
					DataTable dataTable = DALCommon.GetDataList("StaffList", "Area", " [ID]=" + (string)this.Session["Session_wtUserBID"]).Tables[0];
					if (dataTable.Rows.Count > 0)
					{
						this.hfPurArea.Value = dataTable.Rows[0]["Area"].ToString();
					}
				}
				if (dALRight.GetRight(num, "kh_r31"))
				{
					this.hfPurTDev.Value = "1";
				}
				if (dALRight.GetRight(num, "kh_r25"))
				{
					this.hfPur1.Value = "1";
				}
				if (dALRight.GetRight(num, "kh_r26"))
				{
					this.hfPur2.Value = "1";
				}
				if (dALRight.GetRight(num, "kh_r27"))
				{
					this.hfPur3.Value = "1";
				}
				if (!dALRight.GetRight(num, "kh_r16"))
				{
					this.hfCusTrack.Value = "1";
				}
				if (!dALRight.GetRight(num, "kh_r29"))
				{
					this.hfPur4.Value = "1";
				}
				if (dALRight.GetRight(num, "kh_r32"))
				{
					this.hfPurDept.Value = "1";
				}
			}
			this.LoadClass();
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.btnShow_Click(sender, e);
		}
	}

	protected void LoadClass()
	{
		int num = 0;
		DataTable dt = DALCommon.GetList_HL(0, "CustomerClass", "", 0, 0, "", " Array Asc", out num).Tables[0];
		this.tvcus.Nodes.Clear();
		TreeNode treeNode = new TreeNode();
		treeNode.Text = "全部(" + num.ToString() + ")";
		treeNode.Value = "-1";
		this.tvcus.Nodes.Add(treeNode);
		Branch_Customer_CusListAdm.BindTreeNode(treeNode, dt, treeNode.Value);
		TreeNode treeNode2 = new TreeNode();
		treeNode2.Value = "0";
		treeNode2.Text = "未分类";
		this.tvcus.Nodes[0].ChildNodes.Add(treeNode2);
		this.tvcus.Nodes[0].Selected = true;
		this.tvcus.ExpandDepth = 1;
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
			Branch_Customer_CusListAdm.BindTreeNode(treeNode, dt, dataRow["ID"].ToString());
		}
	}

	protected void btnClr_Click(object sender, EventArgs e)
	{
		this.hfcbID.Value = "";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		this.btnShow_Click(sender, e);
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
		this.hfParm.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		this.btnShow_Click(sender, e);
	}

	protected void btnSchH_Click(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		if (this.hfParm.Value != "-1")
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.btnShow_Click(sender, e);
		}
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
		this.btnShow_Click(sender, e);
	}

	protected void LoadField()
	{
		int userID = 0;
		int.TryParse((string)this.Session["Session_wtUserBID"], out userID);
		int deptID = 0;
		int.TryParse((string)this.Session["Session_wtBranchID"], out deptID);
		DALSys dALSys = new DALSys();
		DataTable dataTable = dALSys.GetLayoutDetail(1, deptID, 15, 0, userID).Tables[0];
		if (dataTable.Rows.Count > 0)
		{
			this.gvcus.Columns.Clear();
			BoundField boundField = new BoundField();
			boundField.DataField = "ID";
			boundField.HeaderText = "ID";
			this.gvcus.Columns.Add(boundField);
			boundField = new BoundField();
			boundField.DataField = "bStop";
			boundField.HeaderText = "停用";
			this.gvcus.Columns.Add(boundField);
			TemplateField templateField = new TemplateField();
			templateField.HeaderText = "<input id=\"cball\" type=\"checkbox\" class=\"cb1\" onclick=\"SltAllValue();\" title=\"全选/取消全选\"/>";
			templateField.ItemTemplate = new MyTemplatexcusbc("", DataControlRowType.DataRow);
			this.gvcus.Columns.Add(templateField);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				BoundField boundField2 = new BoundField();
				boundField2.DataField = dataTable.Rows[i]["FieldName"].ToString();
				boundField2.HeaderText = dataTable.Rows[i]["TitleName"].ToString();
				this.gvcus.Columns.Add(boundField2);
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
		this.gvcus.DataSource = DALCommon.GetList_HL(1, "ks_customer", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
		this.gvcus.DataBind();
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
		if (this.gvcus.Rows.Count > 0)
		{
			for (int i = 0; i < this.gvcus.HeaderRow.Cells.Count; i++)
			{
				if (i > 2)
				{
					string dataField = ((BoundField)this.gvcus.Columns[i]).DataField;
					string text2 = this.gvcus.HeaderRow.Cells[i].Text;
					this.gvcus.HeaderRow.Cells[i].Attributes.Add("id", dataField);
					this.gvcus.HeaderRow.Cells[i].Attributes.Add("onclick", string.Concat(new string[]
					{
						"HeaderOrder('",
						dataField,
						"','",
						text2,
						"');"
					}));
					this.gvcus.HeaderRow.Cells[i].Attributes.Add("onmouseover", "this.style.cursor='default';");
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
		this.btnShow_Click(sender, e);
	}

	protected string strParm()
	{
		string text = string.Empty;
		if (this.hfParm.Value == "-1")
		{
			text = "1=1 ";
			string text2 = FunLibrary.ChkInput(this.tbCon.Text);
			if (this.hfClass.Value != string.Empty && this.hfClass.Value != "-1")
			{
				if (this.hfClass.Value == "0")
				{
					text += " and ClassID is null ";
				}
				else
				{
					text = text + " and _Level like '" + this.hfClass.Value + "%'";
				}
			}
			if (this.hfSch.Value == "0")
			{
				if (this.ddlKey.SelectedValue != "-1")
				{
					int schid = 0;
					int.TryParse(this.ddlKey.SelectedValue, out schid);
					if (text2 != "")
					{
						DALCustomerList dALCustomerList = new DALCustomerList();
						text += dALCustomerList.GetSchWhere(schid, text2);
					}
				}
			}
		}
		else
		{
			text = this.hfParm.Value;
		}
		DALSysParm dALSysParm = new DALSysParm();
		SysParmInfo model = dALSysParm.GetModel(1);
		if (this.hfPurDept.Value == "1")
		{
			text = text + " and (SellerID in(select ID from StaffList where StaffDeptID=(select StaffDeptID from StaffList where ID=" + (string)this.Session["Session_wtUserBID"] + ")) or SellerID is null)";
		}
		if (model.CustomerShar == 1)
		{
			text += string.Format(" and (RegDept={0} or BranchID={0})", (string)this.Session["Session_wtBranchID"]);
		}
		if (this.hfPurArea.Value != "")
		{
			text = text + " and (CHARINDEX('" + this.hfPurArea.Value + "',Area)>0 or Area='' or Area is null) ";
		}
		if (this.hfPur1.Value != "")
		{
			text = text + " and SellerID=" + (string)this.Session["Session_wtUserBID"];
		}
		if (this.hfPur2.Value != "")
		{
			if (this.hfPur4.Value == "")
			{
				string text3 = text;
				text = string.Concat(new string[]
				{
					text3,
					" and (CHARINDEX('",
					(string)this.Session["Session_wtUserB"],
					"',HistoryTrackOper)>0 or TrackOperatorID=",
					(string)this.Session["Session_wtUserBID"],
					")"
				});
			}
			else
			{
				text = text + " and TrackOperatorID=" + (string)this.Session["Session_wtUserBID"];
			}
		}
		return text;
	}

	protected void gvcus_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = (e.Row.Cells[1].Visible = false);
		string[] array = this.hfcbID.Value.Split(new char[]
		{
			','
		});
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ModClick();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[2].Attributes.Add("style", "width:20px;padding-right:0px;");
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
			this.lbPage.Text = "当前页:" + this.gvcus.Rows.Count.ToString();
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
		int num3 = 0;
		for (int i = 0; i < array.Length; i++)
		{
			int.TryParse(array[i].ToString(), out num3);
			if (num3 != 0)
			{
				int num4 = DALCommon.DeteleData(4, 0, num3, out empty);
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
					"条客户信息",
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
					"条客户信息已删除；",
					num.ToString(),
					"条客户信息删除失败');"
				}));
			}
		}
		this.hfRecID.Value = "-1";
		this.hfcbID.Value = "";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		this.btnShow_Click(sender, e);
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void tvcus_SelectedNodeChanged(object sender, EventArgs e)
	{
		this.tvcus.SelectedNode.Expanded = new bool?(true);
		this.hfSch.Value = "-1";
		this.hfRecID.Value = "-1";
		this.hfClass.Value = this.tvcus.SelectedNode.Value;
		this.hfClassID.Value = this.tvcus.SelectedNode.ToolTip.ToString();
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		this.btnShow_Click(sender, e);
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
		DataTable dt = DALCommon.GetDataList("ks_customer", this.hfTbField.Value, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "客户档案", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.btnShow_Click(sender, e);
			this.SysInfo("window.alert('" + empty + "');");
		}
	}

	protected void btnShow_Click(object sender, EventArgs e)
	{
		if (this.hfSltType.Value == "1")
		{
			if (this.hfPurDev.Value == "1")
			{
				this.FillDatad();
			}
		}
		else if (this.hfSltType.Value == "2")
		{
			this.FillDatal();
		}
		else if (this.hfSltType.Value == "3")
		{
			this.FillDatap();
		}
		else if (this.hfSltType.Value == "5")
		{
			this.FillDataa();
		}
		else if (this.hfSltType.Value == "6")
		{
			if (this.hfPurSer.Value == "1")
			{
				this.FillDatab();
			}
		}
		else if (this.hfSltType.Value == "7")
		{
			if (this.hfPurSel.Value == "1")
			{
				this.FillDatas();
			}
		}
		else if (this.hfSltType.Value == "8")
		{
			if (this.hfPurLea.Value == "1")
			{
				this.FillDatale();
			}
		}
		else if (this.hfSltType.Value == "4")
		{
			if (this.hfPurCont.Value == "1")
			{
				this.FillDatac();
			}
		}
		else if (this.hfSltType.Value == "9")
		{
			if (this.hfCusTrack.Value == "")
			{
				this.FillDatat();
			}
		}
		else if (this.hfSltType.Value == "10")
		{
			this.FillDatalog();
		}
	}

	protected void LoadFieldd()
	{
		int userID = 0;
		int.TryParse((string)this.Session["Session_wtUserBID"], out userID);
		int deptID = 0;
		int.TryParse((string)this.Session["Session_wtBranchID"], out deptID);
		DALSys dALSys = new DALSys();
		DataTable dataTable = dALSys.GetLayoutDetail(1, deptID, 16, 0, userID).Tables[0];
		if (dataTable.Rows.Count > 0)
		{
			this.gvtrouble.Columns.Clear();
			BoundField boundField = new BoundField();
			boundField.DataField = "ID";
			boundField.HeaderText = "ID";
			this.gvtrouble.Columns.Add(boundField);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				BoundField boundField2 = new BoundField();
				boundField2.DataField = dataTable.Rows[i]["FieldName"].ToString();
				boundField2.HeaderText = dataTable.Rows[i]["TitleName"].ToString();
				this.gvtrouble.Columns.Add(boundField2);
			}
		}
	}

	protected void FillDatad()
	{
		this.LoadFieldd();
		int recordCount = 0;
		string text;
		if (this.hfRecID.Value != "-1")
		{
			text = " CustomerID=" + this.hfRecID.Value;
		}
		else if (!this.cbNoShow.Checked)
		{
			string str = this.strParm();
			text = " CustomerID in (select ID from ks_customer where " + str + ")";
		}
		else
		{
			text = " 1=2 ";
		}
		string fldSort = " ID desc";
		if (this.hfPurTDev.Value == "1")
		{
			text = text + " and (CHARINDEX('" + this.Session["Session_wtUserB"].ToString() + "',Technicians)>0)";
		}
		this.gvtrouble.DataSource = DALCommon.GetList_HL(1, "ks_device", "", this.pageSized, this.jsPagerd.CurrentPageIndex, text, fldSort, out recordCount);
		this.gvtrouble.DataBind();
		this.lbCountd.Text = recordCount.ToString();
		if (this.lbCountd.Text == "0")
		{
			this.lbCountd.Visible = false;
			this.lbPaged.Visible = false;
			this.lbCountTextd.Visible = false;
		}
		else
		{
			this.lbCountd.Visible = true;
			this.lbPaged.Visible = true;
			this.lbCountTextd.Visible = true;
		}
		this.jsPagerd.PageSize = this.pageSized;
		this.jsPagerd.RecordCount = recordCount;
	}

	protected void jsPagerd_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID2.Value = "-1";
		this.FillDatad();
	}

	protected void gvtrouble_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "d" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('d" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ModD();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPaged.Text = "当前页:" + this.gvtrouble.Rows.Count.ToString();
		}
	}

	protected void btnDelD_Click(object sender, EventArgs e)
	{
		int iTbid = int.Parse(this.hfRecID2.Value.Replace("d", ""));
		string empty = string.Empty;
		int num = DALCommon.DeteleData(1, 0, iTbid, out empty);
		if (num == 0)
		{
			this.hfRecID2.Value = "-1";
		}
		else if (num == -1)
		{
			this.SysInfod("window.alert('" + empty + "');");
		}
		else
		{
			this.SysInfod("window.alert('系统错误！请查看错误日志');");
		}
		this.FillDatad();
	}

	protected void GridView9_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "log" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('log" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "tlog" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}

	protected void FillDatalog()
	{
		string strCondition;
		if (this.hfRecID.Value != "-1")
		{
			strCondition = " CustomerID=" + this.hfRecID.Value;
		}
		else if (!this.cbNoShow.Checked)
		{
			string str = this.strParm();
			strCondition = " CustomerID in (select ID from ks_customer where " + str + ")";
		}
		else
		{
			strCondition = " 1=2 ";
		}
		this.GridView9.DataSource = DALCommon.GetDataList("ks_customerlog", "", strCondition);
		this.GridView9.DataBind();
	}

	protected void FillDatal()
	{
		int recordCount = 0;
		string text;
		if (this.hfRecID.Value != "-1")
		{
			text = " CustomerID=" + this.hfRecID.Value;
		}
		else if (!this.cbNoShow.Checked)
		{
			string str = this.strParm();
			text = " CustomerID in (select ID from ks_customer where " + str + ")";
		}
		else
		{
			text = " 1=2 ";
		}
		string fldSort = " ID desc";
		DataSet list_HL = DALCommon.GetList_HL(1, "CustomerLinkMan", "", this.pageSized, this.jsPagerl.CurrentPageIndex, text, fldSort, out recordCount);
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
				DataSet list_HL2 = DALCommon.GetList_HL(0, "CustomerLinkMan", "top 1 ID", 0, 0, text + " and _Name like '%" + text2 + "%'", "ID", out num);
				if (list_HL2.Tables[0].Rows.Count > 0)
				{
					this.SysInfol("ClrID2('l" + list_HL2.Tables[0].Rows[0][0].ToString() + "')");
				}
			}
		}
	}

	protected void jsPagerl_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID2.Value = "-1";
		this.FillDatal();
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
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

	protected void btnDelLink_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		int num = DALCommon.DeteleData("CustomerLinkMan", " [ID]=" + this.hfRecID2.Value.Replace("l", ""), out empty);
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

	protected void FillDatap()
	{
		int recordCount = 0;
		string strCondition;
		if (this.hfRecID.Value != "-1")
		{
			strCondition = " CustomerID=" + this.hfRecID.Value;
		}
		else if (!this.cbNoShow.Checked)
		{
			string str = this.strParm();
			strCondition = " CustomerID in (select ID from ks_customer where " + str + ")";
		}
		else
		{
			strCondition = " 1=2 ";
		}
		string fldSort = " ID desc";
		this.GridView2.DataSource = DALCommon.GetList_HL(1, "CustomerDept", "", this.pageSized, this.jsPagerp.CurrentPageIndex, strCondition, fldSort, out recordCount);
		this.GridView2.DataBind();
		this.lbCountp.Text = recordCount.ToString();
		if (this.lbCountp.Text == "0")
		{
			this.lbCountp.Visible = false;
			this.lbPagep.Visible = false;
			this.lbCountTextp.Visible = false;
		}
		else
		{
			this.lbCountp.Visible = true;
			this.lbPagep.Visible = true;
			this.lbCountTextp.Visible = true;
		}
		this.jsPagerp.PageSize = this.pageSized;
		this.jsPagerp.RecordCount = recordCount;
	}

	protected void jsPagerp_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID2.Value = "-1";
		this.FillDatap();
	}

	protected void GridView8_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "t" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('t" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ModT();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			if (e.Row.Cells[7].Text.Length > 16)
			{
				e.Row.Cells[7].Text = string.Concat(new string[]
				{
					"<a href=\"#\" style=\"color:#0000ff\" title=\"",
					e.Row.Cells[7].Text,
					"\" onclick=\"ShowTC('",
					e.Row.Cells[0].Text,
					"')\">",
					e.Row.Cells[7].Text.Substring(0, 16),
					"...</a>"
				});
			}
			if (e.Row.Cells[8].Text.Length > 16)
			{
				e.Row.Cells[8].Text = string.Concat(new string[]
				{
					"<a href=\"#\" style=\"color:#0000ff\" title=\"",
					e.Row.Cells[8].Text,
					"\" onclick=\"ShowTR('",
					e.Row.Cells[0].Text,
					"')\">",
					e.Row.Cells[8].Text.Substring(0, 16),
					"...</a>"
				});
			}
		}
	}

	protected void btnDelT_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		int num = DALCommon.DeteleData("CustomerTrack", " [ID]=" + this.hfRecID2.Value.Replace("t", ""), out empty);
		if (num == 0)
		{
			this.hfRecID2.Value = "-1";
		}
		else if (num == -1)
		{
			this.SysInfot("window.alert('" + empty + "');");
		}
		else
		{
			this.SysInfot("window.alert('系统错误！请查看错误日志');");
		}
		this.FillDatat();
	}

	protected void FillDatat()
	{
		if (this.hfRecID.Value != "-1")
		{
			string text;
			if (this.hfRecID.Value != "-1")
			{
				text = " CustomerID=" + this.hfRecID.Value;
			}
			else if (!this.cbNoShow.Checked)
			{
				string str = this.strParm();
				text = " CustomerID in (select ID from ks_customer where " + str + ")";
			}
			else
			{
				text = " 1=2 ";
			}
			if (this.hfPur3.Value != "")
			{
				text = text + " and OperatorID=" + (string)this.Session["Session_wtUserBID"];
			}
			this.GridView8.DataSource = DALCommon.GetDataList("ks_customertrack", "", text);
			this.GridView8.DataBind();
		}
	}

	protected void SysInfot(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel11, this.UpdatePanel11.GetType(), "SysInfo", str, true);
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "p" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('p" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ModDept();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPagep.Text = "当前页:" + this.GridView2.Rows.Count.ToString();
		}
	}

	protected void btnDelDept_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		int num = DALCommon.DeteleData("CustomerDept", " [ID]=" + this.hfRecID2.Value.Replace("p", ""), out empty);
		if (num == 0)
		{
			this.hfRecID2.Value = "-1";
		}
		else if (num == -1)
		{
			this.SysInfop("window.alert('" + empty + "');");
		}
		else
		{
			this.SysInfop("window.alert('系统错误！请查看错误日志');");
		}
		this.FillDatap();
	}

	protected void FillDatab()
	{
		int recordCount = 0;
		string strCondition;
		if (this.hfRecID.Value != "-1")
		{
			strCondition = " CustomerID=" + this.hfRecID.Value;
		}
		else if (!this.cbNoShow.Checked)
		{
			string str = this.strParm();
			strCondition = " CustomerID in (select ID from ks_customer where " + str + ")";
		}
		else
		{
			strCondition = " 1=2 ";
		}
		string fldSort = " ID desc";
		this.GridView3.DataSource = DALCommon.GetList_HL(1, "fw_services", "", this.pageSized, this.jsPagerb.CurrentPageIndex, strCondition, fldSort, out recordCount);
		this.GridView3.DataBind();
		this.lbCountb.Text = recordCount.ToString();
		if (this.lbCountb.Text == "0")
		{
			this.lbCountb.Visible = false;
			this.lbPageb.Visible = false;
			this.lbCountTextb.Visible = false;
		}
		else
		{
			this.lbCountb.Visible = true;
			this.lbPageb.Visible = true;
			this.lbCountTextb.Visible = true;
		}
		this.jsPagerb.PageSize = this.pageSized;
		this.jsPagerb.RecordCount = recordCount;
	}

	protected void jsPagerb_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID2.Value = "-1";
		this.FillDatab();
	}

	protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "b" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('b" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "SerV();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			if (e.Row.Cells[20].Text.Length > 16)
			{
				e.Row.Cells[20].Text = string.Concat(new string[]
				{
					"<a href=\"#\" style=\"color:#0000ff\" title=\"",
					e.Row.Cells[20].Text,
					"\" onclick=\"ShowTA('",
					e.Row.Cells[0].Text,
					"')\">",
					e.Row.Cells[20].Text.Substring(0, 16),
					"...</a>"
				});
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPageb.Text = "当前页:" + this.GridView3.Rows.Count.ToString();
		}
	}

	protected void FillDatas()
	{
		int recordCount = 0;
		string strCondition;
		if (this.hfRecID.Value != "-1")
		{
			strCondition = " CustomerID=" + this.hfRecID.Value;
		}
		else if (!this.cbNoShow.Checked)
		{
			string str = this.strParm();
			strCondition = " CustomerID in (select ID from ks_customer where " + str + ")";
		}
		else
		{
			strCondition = " 1=2 ";
		}
		string fldSort = " ID desc";
		this.GridView4.DataSource = DALCommon.GetList_HL(1, "xs_sell", "", this.pageSized, this.jsPagers.CurrentPageIndex, strCondition, fldSort, out recordCount);
		this.GridView4.DataBind();
		this.lbCounts.Text = recordCount.ToString();
		if (this.lbCounts.Text == "0")
		{
			this.lbCounts.Visible = false;
			this.lbPages.Visible = false;
			this.lbCountTexts.Visible = false;
		}
		else
		{
			this.lbCounts.Visible = true;
			this.lbPages.Visible = true;
			this.lbCountTexts.Visible = true;
		}
		this.jsPagers.PageSize = this.pageSized;
		this.jsPagers.RecordCount = recordCount;
	}

	protected void jsPagers_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID2.Value = "-1";
		this.FillDatas();
	}

	protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "s" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('s" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "SellV();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPages.Text = "当前页:" + this.GridView4.Rows.Count.ToString();
		}
	}

	protected void FillDatale()
	{
		int recordCount = 0;
		string strCondition;
		if (this.hfRecID.Value != "-1")
		{
			strCondition = " CustomerID=" + this.hfRecID.Value;
		}
		else if (!this.cbNoShow.Checked)
		{
			string str = this.strParm();
			strCondition = " CustomerID in (select ID from ks_customer where " + str + ")";
		}
		else
		{
			strCondition = " 1=2 ";
		}
		string fldSort = " ID desc";
		this.GridView5.DataSource = DALCommon.GetList_HL(1, "zl_lease", "", this.pageSized, this.jsPagerle.CurrentPageIndex, strCondition, fldSort, out recordCount);
		this.GridView5.DataBind();
		this.lbCountle.Text = recordCount.ToString();
		if (this.lbCountle.Text == "0")
		{
			this.lbCountle.Visible = false;
			this.lbPagele.Visible = false;
			this.lbCountTextle.Visible = false;
		}
		else
		{
			this.lbCountle.Visible = true;
			this.lbPagele.Visible = true;
			this.lbCountTextle.Visible = true;
		}
		this.jsPagerle.PageSize = this.pageSized;
		this.jsPagerle.RecordCount = recordCount;
	}

	protected void jsPagerle_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID2.Value = "-1";
		this.FillDatale();
	}

	protected void GridView5_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "le" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('le" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "LeaseV();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPagele.Text = "当前页:" + this.GridView5.Rows.Count.ToString();
		}
	}

	protected void FillDataa()
	{
		int recordCount = 0;
		string strCondition;
		if (this.hfRecID.Value != "-1")
		{
			strCondition = " CustomerID=" + this.hfRecID.Value;
		}
		else if (!this.cbNoShow.Checked)
		{
			string str = this.strParm();
			strCondition = " CustomerID in (select ID from ks_customer where " + str + ")";
		}
		else
		{
			strCondition = " 1=2 ";
		}
		string fldSort = " ID desc";
		this.GridView6.DataSource = DALCommon.GetList_HL(1, "ks_customeraccessory", "", this.pageSized, this.jsPagera.CurrentPageIndex, strCondition, fldSort, out recordCount);
		this.GridView6.DataBind();
		this.lbCounta.Text = recordCount.ToString();
		if (this.lbCounta.Text == "0")
		{
			this.lbCounta.Visible = false;
			this.lbPagea.Visible = false;
			this.lbCountTexta.Visible = false;
		}
		else
		{
			this.lbCounta.Visible = true;
			this.lbPagea.Visible = true;
			this.lbCountTexta.Visible = true;
		}
		this.jsPagera.PageSize = this.pageSized;
		this.jsPagera.RecordCount = recordCount;
	}

	protected void jsPagera_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID2.Value = "-1";
		this.FillDataa();
	}

	protected void GridView6_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "a" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('a" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ModAcc();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			if (e.Row.Cells[3].Text != "&nbsp;" && e.Row.Cells[3].Text != "")
			{
				e.Row.Cells[3].Text = "<a href=\"" + e.Row.Cells[3].Text + "\" target=\"_blank\" style=\"color:#0000ff\" >查看</a>";
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPagea.Text = "当前页:" + this.GridView6.Rows.Count.ToString();
		}
	}

	protected void btnDelAcc_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		int num = DALCommon.DeteleData("CustomerAccessory", " [ID]=" + this.hfRecID2.Value.Replace("a", ""), out empty);
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
		this.FillDataa();
	}

	protected void FillDatac()
	{
		int recordCount = 0;
		string strCondition;
		if (this.hfRecID.Value != "-1")
		{
			strCondition = " CustomerID=" + this.hfRecID.Value;
		}
		else if (!this.cbNoShow.Checked)
		{
			string str = this.strParm();
			strCondition = " CustomerID in (select ID from ks_customer where " + str + ")";
		}
		else
		{
			strCondition = " 1=2 ";
		}
		string fldSort = " ID desc ";
		this.GridView7.DataSource = DALCommon.GetList_HL(1, "ks_maintenancecontract", "", this.pageSized, this.jsPagerc.CurrentPageIndex, strCondition, fldSort, out recordCount);
		this.GridView7.DataBind();
		this.lbCountc.Text = recordCount.ToString();
		if (this.lbCountc.Text == "0")
		{
			this.lbCountc.Visible = false;
			this.lbPagec.Visible = false;
			this.lbCountTextc.Visible = false;
		}
		else
		{
			this.lbCountc.Visible = true;
			this.lbPagec.Visible = true;
			this.lbCountTextc.Visible = true;
		}
		this.jsPagerc.PageSize = this.pageSized;
		this.jsPagerc.RecordCount = recordCount;
	}

	protected void jsPagerc_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID2.Value = "-1";
		this.FillDatac();
	}

	protected void GridView7_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "c" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('c" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ModCont();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			if (e.Row.Cells[1].Text == "将执行")
			{
				e.Row.Attributes.Add("style", "color: #ff0000");
			}
			else if (e.Row.Cells[1].Text == "正执行")
			{
				e.Row.Attributes.Add("style", "color: #008000");
			}
			else if (e.Row.Cells[1].Text == "已过期")
			{
				e.Row.Attributes.Add("style", "color: #0000ff");
			}
			else if (e.Row.Cells[1].Text == "已终止")
			{
				e.Row.Attributes.Add("style", "color:#848284");
			}
			if (e.Row.Cells[9].Text != "&nbsp;" && e.Row.Cells[9].Text != "")
			{
				e.Row.Cells[9].Text = "<a href=\"" + e.Row.Cells[9].Text + "\" target=\"_blank\" style=\"color:#0000ff\" >查看</a>";
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPagec.Text = "当前页:" + this.GridView7.Rows.Count.ToString();
		}
	}

	protected void btnDelCont_Click(object sender, EventArgs e)
	{
		int iTbid = 0;
		int.TryParse(this.hfRecID2.Value.Replace("c", ""), out iTbid);
		DALMaintenanceContract dALMaintenanceContract = new DALMaintenanceContract();
		string empty = string.Empty;
		int iOperator = 0;
		int.TryParse((string)this.Session["Session_wtUserBID"], out iOperator);
		int num = dALMaintenanceContract.Delete(int.Parse((string)this.Session["Session_wtBranchID"]), iTbid, iOperator, out empty);
		if (num == 0)
		{
			this.hfRecID2.Value = "-1";
		}
		else if (num == -1)
		{
			this.SysInfo10("window.alert('" + empty + "');");
		}
		else
		{
			this.SysInfo10("window.alert('系统错误！请查看错误日志');");
		}
		this.FillDatac();
	}

	protected void SysInfo10(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel10, this.UpdatePanel10.GetType(), "SysInfo", str, true);
	}

	protected void SysInfod(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel3, this.UpdatePanel3.GetType(), "SysInfo", str, true);
	}

	protected void SysInfol(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel4, this.UpdatePanel4.GetType(), "SysInfo", str, true);
	}

	protected void SysInfop(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel5, this.UpdatePanel5.GetType(), "SysInfo", str, true);
	}

	protected void btnExeclRecord_Click(object sender, EventArgs e)
	{
		DataTable dt = DALCommon.GetDataList("ks_customertrack", "_Date,Operator,Content,LinkMan,Tel,TrackStyle,TrackType,Result,NextTrack,bTrack", "CustomerID=" + this.hfRecID.Value).Tables[0];
		string[] tbTitle = new string[]
		{
			"跟踪日期",
			"跟踪人",
			"跟踪内容",
			"联系人",
			"联系电话",
			"跟踪方式",
			"跟踪类别",
			"跟踪结果",
			"下次跟踪日期",
			"不再跟踪"
		};
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "跟踪记录", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.btnShow_Click(sender, e);
			this.SysInfo("window.alert('" + empty + "');");
		}
	}
}
