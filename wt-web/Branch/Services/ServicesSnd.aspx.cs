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

public partial class Branch_Services_ServicesSnd : Page, IRequiresSessionState
{
	private int pageSize = 20;

	private bool blayout = false;

	private int itake = 25;



	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "gd_r1"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
				if (!dALRight.GetRight(num, "gd_r15"))
				{
					this.btnPrint.Visible = false;
				}
				if (!dALRight.GetRight(num, "gd_r14"))
				{
					this.btnExcel.Enabled = false;
				}
				if (!dALRight.GetRight(num, "gd_r8"))
				{
					this.btnSnd.Enabled = false;
				}
			}
			this.LoadClass();
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.tbSndDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
			OtherFunction.BindSndStyle(this.ddlSndStyle, " DeptID=" + (string)this.Session["Session_wtBranchID"] + " ");
		}
	}

	protected void LoadClass()
	{
		int num = 0;
		DataTable dt = DALCommon.GetList_HL(0, "SupplierList", "[ID],[_Name]", 0, 0, " bTransmitCorp=1 and bStop=0 ", " ID Asc", out num).Tables[0];
		this.tvsup.Nodes.Clear();
		TreeNode treeNode = new TreeNode();
		treeNode.Text = "送修厂商";
		treeNode.Value = "-1";
		this.tvsup.Nodes.Add(treeNode);
		this.InitFirst(dt, treeNode);
		this.tvsup.Nodes[0].Selected = true;
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
		this.hfParm.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void btnSchH_Click(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		if (this.hfParm.Value != "-1")
		{
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

	protected void btnFsh_Click(object sender, EventArgs e)
	{
		this.hfSch.Value = "-1";
		this.hfRecID.Value = "-1";
		this.hfParm.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void LoadField()
	{
		int userID = 0;
		int.TryParse((string)this.Session["Session_wtUserBID"], out userID);
		int deptID = 0;
		int.TryParse((string)this.Session["Session_wtBranchID"], out deptID);
		DALSys dALSys = new DALSys();
		DataTable dataTable = dALSys.GetLayoutDetail(1, deptID, 8, 0, userID).Tables[0];
		if (dataTable.Rows.Count > 0)
		{
			this.gvdata.Columns.Clear();
			BoundField boundField = new BoundField();
			boundField.DataField = "ID";
			boundField.HeaderText = "ID";
			this.gvdata.Columns.Add(boundField);
			boundField = new BoundField();
			boundField.DataField = "RepairCorpID";
			boundField.HeaderText = "送修厂商ID";
			this.gvdata.Columns.Add(boundField);
			boundField = new BoundField();
			boundField.DataField = "RepairCorp";
			boundField.HeaderText = "送修厂商";
			this.gvdata.Columns.Add(boundField);
			boundField = new BoundField();
			boundField.DataField = "SubscribeTime";
			boundField.HeaderText = "预约时间";
			this.gvdata.Columns.Add(boundField);
			this.itake = 0;
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				BoundField boundField2 = new BoundField();
				boundField2.DataField = dataTable.Rows[i]["FieldName"].ToString();
				boundField2.HeaderText = dataTable.Rows[i]["TitleName"].ToString();
				if (dataTable.Rows[i]["FieldName"].ToString() == "TakeSteps")
				{
					this.itake = i + 4;
				}
				this.gvdata.Columns.Add(boundField2);
			}
			this.blayout = true;
		}
	}

	protected void FillData(string sortExpression, string direction)
	{
		this.LoadField();
		this.hfRecList.Value = "";
		int recordCount = 0;
		string text = (this.hfParm.Value == "-1") ? this.strParm() : (this.hfParm.Value + " and DisposalID=" + (string)this.Session["Session_wtBranchID"] + " and curStatus='送修' and RepairStatus='待送修发货' ");
		string fldSort = sortExpression + " " + direction;
		this.hfSql.Value = text;
		this.gvdata.DataSource = DALCommon.GetList_HL(1, "fw_services", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
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
				if (i > 3)
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
					if (dataField != "ID")
					{
						if (this.hfTbTitle.Value == string.Empty)
						{
							this.hfTbTitle.Value = text2;
						}
						else
						{
							HiddenField expr_305 = this.hfTbTitle;
							expr_305.Value = expr_305.Value + "," + text2;
						}
						if (this.hfTbField.Value == string.Empty)
						{
							this.hfTbField.Value = dataField;
						}
						else
						{
							HiddenField expr_355 = this.hfTbField;
							expr_355.Value = expr_355.Value + "," + dataField;
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
		string text = " DisposalID=" + (string)this.Session["Session_wtBranchID"] + " and curStatus='送修' and RepairStatus='待送修发货' ";
		string text2 = FunLibrary.ChkInput(this.tbCon.Text);
		if (this.hfClass.Value != string.Empty && this.hfClass.Value != "-1")
		{
			text = text + " and RepairCorpID=" + this.hfClass.Value.Replace("'", "");
		}
		if (this.hfSch.Value == "0")
		{
			if (this.ddlKey.SelectedValue != "-1")
			{
				int schid = 0;
				int.TryParse(this.ddlKey.SelectedValue, out schid);
				if (text2 != "")
				{
					DALServices dALServices = new DALServices();
					text += dALServices.GetSchWhere(schid, text2);
				}
			}
		}
		return text;
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = (e.Row.Cells[1].Visible = (e.Row.Cells[2].Visible = (e.Row.Cells[3].Visible = (e.Row.Cells[4].Visible = false))));
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			this.hfRecList.Value = this.hfRecList.Value + "," + e.Row.Cells[0].Text;
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkID('",
				e.Row.Cells[0].Text,
				"');ChkSupplier('",
				e.Row.Cells[2].Text,
				"','",
				e.Row.Cells[1].Text.Replace("&nbsp;", "").Replace("\"", ""),
				"');"
			}));
			e.Row.Attributes.Add("ondblclick", "ChkGo();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Attributes.Add("title", "双击选择");
			string empty = string.Empty;
			string[] array = this.hflist.Value.Split(new char[]
			{
				','
			});
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == "'" + e.Row.Cells[0].Text + "'")
				{
					e.Row.Visible = false;
				}
			}
			if (e.Row.Cells[3].Text == "紧急")
			{
				e.Row.Attributes.Add("style", "color:#ff0000");
			}
			if (e.Row.Cells[4].Text != "&nbsp;")
			{
				e.Row.Attributes.Add("style", "color:#0000ff");
			}
			if (this.blayout)
			{
				if (this.itake > 4)
				{
					if (e.Row.Cells[this.itake].Text.Length > 16)
					{
						e.Row.Cells[this.itake].Text = string.Concat(new string[]
						{
							"<a href=\"#\" style=\"color:#0000ff\" title=\"",
							e.Row.Cells[this.itake].Text,
							"\" onclick=\"ShowTA('",
							e.Row.Cells[0].Text,
							"')\">",
							e.Row.Cells[this.itake].Text.Substring(0, 16),
							"...</a>"
						});
					}
				}
			}
			else if (e.Row.Cells[this.itake].Text.Length > 16)
			{
				e.Row.Cells[this.itake].Text = string.Concat(new string[]
				{
					"<a href=\"#\" style=\"color:#0000ff\" title=\"",
					e.Row.Cells[this.itake].Text,
					"\" onclick=\"ShowTA('",
					e.Row.Cells[0].Text,
					"')\">",
					e.Row.Cells[this.itake].Text.Substring(0, 16),
					"...</a>"
				});
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.gvdata.Rows.Count.ToString();
		}
	}

	protected void BindsNone()
	{
		this.GridView2.DataSource = null;
		this.GridView2.DataBind();
	}

	protected void Binds()
	{
		if (this.hflist.Value != "")
		{
			this.GridView2.DataSource = DALCommon.GetDataList("fw_services", "", " [ID] in (" + this.hflist.Value + ")");
			this.GridView2.DataBind();
			this.lbsCount.Text = "已选择了" + this.GridView2.Rows.Count.ToString() + "个";
			if (this.lbsCount.Text == "已选择了0个")
			{
				this.lbsCount.Text = "";
			}
		}
		else
		{
			this.lbsCount.Text = "";
			this.GridView2.DataSource = null;
			this.GridView2.DataBind();
		}
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 1px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			this.hfRecsList.Value = this.hfRecsList.Value + "," + e.Row.Cells[0].Text;
			e.Row.Attributes.Add("id", "s" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('s" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ChkBack();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Attributes.Add("title", "双击撤销");
		}
	}

	protected void btnGo_Click(object sender, EventArgs e)
	{
		if (this.hfRecID.Value != "-1")
		{
			this.AddOne(this.hfRecID.Value);
		}
		this.Binds();
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		if (this.ddlRepairCorp.SelectedItem.Text == "")
		{
			this.ddlRepairCorp.Items.Clear();
			this.ddlRepairCorp.Items.Insert(0, new ListItem(this.hfSup.Value, this.hfSupID.Value));
			DataSet dataList = DALCommon.GetDataList("SupplierLinkman", "ID,_Name", "SupplierID=" + this.hfSupID.Value);
			this.ddlLinkman.DataSource = dataList;
			this.ddlLinkman.DataTextField = "_Name";
			this.ddlLinkman.DataValueField = "ID";
			this.ddlLinkman.DataBind();
			this.ddlLinkman.Items.Insert(0, new ListItem("", ""));
		}
	}

	protected void btnBack_Click(object sender, EventArgs e)
	{
		string text = string.Empty;
		string[] array = this.hflist.Value.Split(new char[]
		{
			','
		});
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] != "'" + this.hfRecID2.Value.TrimStart(new char[]
			{
				's'
			}) + "'")
			{
				text = text + "," + array[i];
			}
			if (array.Length == 0)
			{
				this.hfSupID.Value = "";
				this.hfSup.Value = "";
			}
		}
		this.hflist.Value = text.TrimStart(new char[]
		{
			','
		});
		if (this.hflist.Value == "")
		{
			this.ddlRepairCorp.Items.Clear();
			this.ddlRepairCorp.Items.Insert(0, new ListItem("", ""));
			this.ddlLinkman.Items.Clear();
			this.tbAdr.Text = "";
			this.tbLinkman.Text = "";
		}
		this.hfRecID.Value = "-1";
		this.Binds();
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void btnGoAll_Click(object sender, EventArgs e)
	{
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		if (this.gvdata.Rows.Count > 0)
		{
			string text = (this.hfSupID.Value == "") ? this.gvdata.Rows[0].Cells[1].Text : this.hfSupID.Value;
			string text2 = (this.hfSup.Value == "") ? this.gvdata.Rows[0].Cells[2].Text : this.hfSup.Value;
			for (int i = 0; i < this.gvdata.Rows.Count; i++)
			{
				if (text2 != this.gvdata.Rows[i].Cells[2].Text || text != this.gvdata.Rows[0].Cells[1].Text)
				{
					this.SysInfo("alert('同一待送修列表不允许存在不同的送修厂商！');");
					this.hfRecID.Value = "-1";
					this.Binds();
					this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
					return;
				}
				text2 = this.gvdata.Rows[i].Cells[2].Text;
				this.hfSup.Value = this.gvdata.Rows[i].Cells[2].Text;
				text = this.gvdata.Rows[i].Cells[1].Text;
				this.hfSupID.Value = this.gvdata.Rows[i].Cells[1].Text;
			}
			if (this.hfRecList.Value != "")
			{
				string text3 = this.hfRecList.Value.TrimStart(new char[]
				{
					','
				});
				string[] array = text3.Split(new char[]
				{
					','
				});
				for (int i = 0; i < array.Length; i++)
				{
					this.AddOne(array[i]);
				}
			}
			this.Binds();
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.ddlRepairCorp.Items.Clear();
			this.ddlRepairCorp.Items.Insert(0, new ListItem(text2, text));
			DataSet dataList = DALCommon.GetDataList("SupplierLinkman", "ID,_Name", "SupplierID=" + text);
			this.ddlLinkman.DataSource = dataList;
			this.ddlLinkman.DataTextField = "_Name";
			this.ddlLinkman.DataValueField = "ID";
			this.ddlLinkman.DataBind();
			this.ddlLinkman.Items.Insert(0, new ListItem("", ""));
		}
	}

	protected void btnBackAll_Click(object sender, EventArgs e)
	{
		this.hfRecID2.Value = "-1";
		this.hflist.Value = "";
		this.hfRecID.Value = "-1";
		this.hfSup.Value = "";
		this.hfSupID.Value = "";
		this.Binds();
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		this.ddlRepairCorp.Items.Clear();
		this.ddlRepairCorp.Items.Insert(0, new ListItem("", ""));
		this.ddlLinkman.Items.Clear();
		this.tbAdr.Text = "";
		this.tbLinkman.Text = "";
	}

	protected void AddOne(string RecID)
	{
		string text = this.hflist.Value;
		string[] array = text.Split(new char[]
		{
			','
		});
		bool flag = false;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == RecID)
			{
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			text = text + ",'" + RecID + "'";
			this.hflist.Value = text.TrimStart(new char[]
			{
				','
			});
		}
	}

	protected void btnNO_Click(object sender, EventArgs e)
	{
		string text = FunLibrary.ChkInput(this.tbSNO.Text);
		if (text != string.Empty)
		{
			DataTable dataTable = DALCommon.GetDataList("fw_services", "", string.Concat(new string[]
			{
				" ProductSN1='",
				text,
				"' and DisposalID=",
				(string)this.Session["Session_wtBranchID"],
				" and curStatus='送修' and RepairStatus='待送修发货' "
			})).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				string text2 = (this.hfSupID.Value == "") ? dataTable.Rows[0]["RepairCorpID"].ToString() : this.hfSupID.Value;
				string text3 = (this.hfSup.Value == "") ? dataTable.Rows[0]["RepairCorp"].ToString() : this.hfSup.Value;
				if (text3 != dataTable.Rows[0]["RepairCorp"].ToString() && text2 != dataTable.Rows[0]["RepairCorpID"].ToString())
				{
					this.SysInfo("window.alert('同一待送修列表不允许存在不同的送修厂商！');");
					this.hfRecID.Value = "-1";
					this.Binds();
					this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
					this.SysInfo("$('tbSNO').select();");
				}
				else
				{
					this.hfSupID.Value = text2;
					this.hfSup.Value = text3;
					string recID = dataTable.Rows[0]["ID"].ToString();
					this.AddOne(recID);
					this.Binds();
					this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
					if (this.ddlRepairCorp.SelectedItem.Text == "")
					{
						this.ddlRepairCorp.Items.Clear();
						this.ddlRepairCorp.Items.Insert(0, new ListItem(this.hfSup.Value, this.hfSupID.Value));
						DataSet dataList = DALCommon.GetDataList("SupplierLinkman", "ID,_Name", "SupplierID=" + this.hfSupID.Value);
						this.ddlLinkman.DataSource = dataList;
						this.ddlLinkman.DataTextField = "_Name";
						this.ddlLinkman.DataValueField = "ID";
						this.ddlLinkman.DataBind();
						this.ddlLinkman.Items.Insert(0, new ListItem("", ""));
					}
					this.SysInfo("$('tbSNO').value='';$('tbSNO').select();");
				}
			}
			else
			{
				this.SysInfo("window.alert('操作失败！不存在该序列号的机器');");
				this.hfRecID.Value = "-1";
				this.Binds();
				this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
				this.SysInfo("$('tbSNO').select();");
			}
		}
	}

	protected void btnSnd_Click(object sender, EventArgs e)
	{
		string text = this.hflist.Value.Replace("'", "");
		if (text != "")
		{
			DALServices dALServices = new DALServices();
			decimal postage = 0m;
			decimal.TryParse(this.tbPostage.Text, out postage);
			string str = "";
			int num = dALServices.RepairSnd(int.Parse((string)this.Session["Session_wtBranchID"]), int.Parse((string)this.Session["Session_wtUserBID"]), text, int.Parse(this.hfSupID.Value), this.tbSndDate.Text, int.Parse(this.ddlSndStyle.SelectedValue), FunLibrary.ChkInput(this.tbPostNO.Text), postage, this.tbLinkman.Text.Trim(), this.tbAdr.Text.Trim(), out str);
			if (num == 0)
			{
				this.SysInfo("window.alert('操作成功！机器已送修');");
			}
			else
			{
				this.SysInfo("window.alert('" + str + "');");
			}
		}
		this.hfRecID2.Value = "-1";
		this.hflist.Value = "";
		this.hfRecID.Value = "-1";
		this.hfSup.Value = "";
		this.hfSupID.Value = "";
		this.Binds();
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		this.ddlRepairCorp.Items.Clear();
		this.ddlRepairCorp.Items.Insert(0, new ListItem("", ""));
		this.ddlLinkman.Items.Clear();
		this.tbAdr.Text = "";
		this.tbLinkman.Text = "";
		this.ddlSndStyle.ClearSelection();
		for (int i = 0; i < this.ddlSndStyle.Items.Count; i++)
		{
			if (this.ddlSndStyle.Items[i].Text == "")
			{
				this.ddlSndStyle.Items[i].Selected = true;
				break;
			}
		}
		this.tbPostNO.Text = "";
		this.tbPostage.Text = "";
		this.tbSndDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void tvsup_SelectedNodeChanged(object sender, EventArgs e)
	{
		this.tvsup.SelectedNode.Expanded = new bool?(true);
		this.hfSch.Value = "-1";
		this.hfRecID.Value = "-1";
		this.hfClass.Value = this.tvsup.SelectedNode.Value;
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
		DataTable dt = DALCommon.GetDataList("fw_services", this.hfTbField.Value, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "Services", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert('" + empty + "');");
		}
	}

	protected void ddlLinkman_SelectedIndexChanged(object sender, EventArgs e)
	{
		DataSet dataList = DALCommon.GetDataList("SupplierLinkman", "Adr", "ID=" + this.ddlLinkman.SelectedValue);
		if (dataList.Tables[0].Rows.Count > 0)
		{
			this.tbAdr.Text = dataList.Tables[0].Rows[0][0].ToString().Trim();
		}
	}
}
