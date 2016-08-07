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

public partial class Headquarters_Customer_CustomerTrack : Page, IRequiresSessionState
{

	private int pageSize = 20;

	private int iflag;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["iFlag"], out this.iflag);
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "kh_r13"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
				if (!dALRight.GetRight(num, "kh_r14"))
				{
					this.btnNewT.Visible = false;
				}
				if (!dALRight.GetRight(num, "kh_r15"))
				{
					this.btnModT.Visible = false;
				}
				if (!dALRight.GetRight(num, "kh_r16"))
				{
					this.btnDelT.Enabled = false;
				}
				if (dALRight.GetRight(num, "kh_r18"))
				{
					DataTable dataTable = DALCommon.GetDataList("StaffList", "Area", " [ID]=" + (string)this.Session["Session_wtUserID"]).Tables[0];
					if (dataTable.Rows.Count > 0)
					{
						this.hfPurArea.Value = dataTable.Rows[0]["Area"].ToString();
					}
				}
				if (dALRight.GetRight(num, "kh_r29"))
				{
					this.hfPur1.Value = "1";
				}
				if (dALRight.GetRight(num, "kh_r30"))
				{
					this.hfPur2.Value = "1";
				}
				if (dALRight.GetRight(num, "kh_r31"))
				{
					this.hfPur3.Value = "1";
				}
				if (dALRight.GetRight(num, "kh_r33"))
				{
					this.hfPur4.Value = "1";
				}
			}
			this.LoadClass();
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
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
		OtherFunction.BindTreeNode(treeNode, dt, treeNode.Value);
		TreeNode treeNode2 = new TreeNode();
		treeNode2.Value = "0";
		treeNode2.Text = "未分类";
		this.tvcus.Nodes[0].ChildNodes.Add(treeNode2);
		this.tvcus.Nodes[0].Selected = true;
		this.tvcus.ExpandDepth = 1;
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

	protected void btnSch_Click(object sender, EventArgs e)
	{
		this.hfcbID.Value = "";
		this.hfSch.Value = "0";
		this.hfRecID.Value = "-1";
		this.hfParm.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void btnSchH_Click(object sender, EventArgs e)
	{
		this.hfcbID.Value = "";
		this.hfRecID.Value = "-1";
		if (this.hfParm.Value != "-1")
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
	}

	protected void btnFsh_Click(object sender, EventArgs e)
	{
		this.hfcbID.Value = "";
		this.hfSch.Value = "-1";
		this.hfRecID.Value = "-1";
		this.hfParm.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void LoadField()
	{
		int userID = 0;
		int.TryParse((string)this.Session["Session_wtUserID"], out userID);
		DALSys dALSys = new DALSys();
		DataTable dataTable = dALSys.GetLayoutDetail(1, 1, 15, 0, userID).Tables[0];
		if (dataTable.Rows.Count > 0)
		{
			this.gvdata.Columns.Clear();
			BoundField boundField = new BoundField();
			boundField.DataField = "ID";
			boundField.HeaderText = "ID";
			this.gvdata.Columns.Add(boundField);
			TemplateField templateField = new TemplateField();
			templateField.HeaderText = "<input id=\"cball\" type=\"checkbox\" class=\"cb1\" onclick=\"SltAllValue();\" title=\"全选/取消全选\"/>";
			templateField.ItemTemplate = new MyTemplatexcusTT("", DataControlRowType.DataRow);
			this.gvdata.Columns.Add(templateField);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				BoundField boundField2 = new BoundField();
				boundField2.DataField = dataTable.Rows[i]["FieldName"].ToString();
				boundField2.HeaderText = dataTable.Rows[i]["TitleName"].ToString();
				this.gvdata.Columns.Add(boundField2);
			}
		}
	}

	protected void FillData(string sortExpression, string direction)
	{
		this.LoadField();
		int recordCount = 0;
		string text = (this.hfParm.Value == "-1") ? this.strParm() : this.hfParm.Value;
		string fldSort = sortExpression + " " + direction;
		if (this.hfPurArea.Value != "")
		{
			text = text + " and (CHARINDEX('" + this.hfPurArea.Value + "',Area)>0 or Area='' or Area is null) ";
		}
		if (this.hfPur1.Value != "")
		{
			text = text + " and SellerID=" + (string)this.Session["Session_wtUserID"];
		}
		if (this.iflag == 1)
		{
			text = text + " and TrackOperatorID=" + (string)this.Session["Session_wtUserID"];
		}
		if (this.iflag == 2)
		{
			text = text + " and [ID] in(select [CustomerID] from CustomerTrack a where datediff(d,dateadd(dd,0,getdate()),a.NextTrack)<=0) and TrackOperatorID=" + (string)this.Session["Session_wtUserID"];
		}
		if (this.hfPur2.Value != "")
		{
			if (this.hfPur4.Value == "")
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and (CHARINDEX('",
					(string)this.Session["Session_wtUser"],
					"',HistoryTrackOper)>0 or TrackOperatorID=",
					(string)this.Session["Session_wtUserID"],
					")"
				});
			}
			else
			{
				text = text + " and TrackOperatorID=" + (string)this.Session["Session_wtUserID"];
			}
		}
		this.hfSql.Value = text;
		this.gvdata.DataSource = DALCommon.GetList_HL(1, "ks_customer", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
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
					string text3 = this.gvdata.HeaderRow.Cells[i].Text;
					this.gvdata.HeaderRow.Cells[i].Attributes.Add("id", dataField);
					this.gvdata.HeaderRow.Cells[i].Attributes.Add("onclick", string.Concat(new string[]
					{
						"HeaderOrder('",
						dataField,
						"','",
						text3,
						"');"
					}));
					this.gvdata.HeaderRow.Cells[i].Attributes.Add("onmouseover", "this.style.cursor='default';");
					if (dataField != "ID")
					{
						if (this.hfTbTitle.Value == string.Empty)
						{
							this.hfTbTitle.Value = text3;
						}
						else
						{
							HiddenField expr_485 = this.hfTbTitle;
							expr_485.Value = expr_485.Value + "," + text3;
						}
						if (this.hfTbField.Value == string.Empty)
						{
							this.hfTbField.Value = dataField;
						}
						else
						{
							HiddenField expr_4D5 = this.hfTbField;
							expr_4D5.Value = expr_4D5.Value + "," + dataField;
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
		string text = " bStop='' and bTrack=1 ";
		string text2 = FunLibrary.ChkInput(this.tbCon.Text.Trim());
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
		return text;
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		string[] array = this.hfcbID.Value.Split(new char[]
		{
			','
		});
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ShowCus();");
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
		DataTable dt = DALCommon.GetDataList("ks_customer", this.hfTbField.Value, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "cusadm", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert('" + empty + "');");
		}
	}

	protected void tvcus_SelectedNodeChanged(object sender, EventArgs e)
	{
		this.tvcus.SelectedNode.Expanded = new bool?(true);
		this.hfSch.Value = "-1";
		this.hfRecID.Value = "-1";
		this.hfClass.Value = this.tvcus.SelectedNode.Value;
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('" + e.Row.Cells[0].Text + "');");
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
		int num = DALCommon.DeteleData("CustomerTrack", " [ID]=" + this.hfRecID2.Value, out empty);
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
			string text = " CustomerID=" + this.hfRecID.Value;
			if (this.hfPur3.Value != "")
			{
				text = text + " and OperatorID=" + (string)this.Session["Session_wtUserID"];
			}
			this.GridView1.DataSource = DALCommon.GetDataList("ks_customertrack", "", text);
			this.GridView1.DataBind();
		}
	}

	protected void btnShow_Click(object sender, EventArgs e)
	{
		this.FillDatat();
	}

	protected void SysInfot(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "SysInfo", str, true);
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void btnExcelDe_Click(object sender, EventArgs e)
	{
		DataTable dt = null;
		if (this.hfRecID.Value != "-1")
		{
			string text = " CustomerID=" + this.hfRecID.Value;
			if (this.hfPur3.Value != "")
			{
				text = text + " and OperatorID=" + (string)this.Session["Session_wtUserID"];
			}
			dt = DALCommon.GetDataList("ks_customertrack", "_Date,Operator,Content,LinkMan,Tel,TrackStyle,TrackType,Result,NextTrack,bTrack", text).Tables[0];
		}
		string text2 = "跟踪日期,跟踪人,跟踪内容,联系人,联系电话,跟踪方式,跟踪类别,跟踪结果,下次跟踪日期,不再跟踪";
		string[] tbTitle = text2.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "客户跟踪明细", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.FillDatat();
			this.SysInfot("window.alert(\"" + empty + "\");");
		}
	}
}
