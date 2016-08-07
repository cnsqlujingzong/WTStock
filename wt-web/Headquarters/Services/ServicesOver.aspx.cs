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

public partial class Headquarters_Services_ServicesOver : Page, IRequiresSessionState
{
	private int pageSize = 20;

	private bool blayout = false;

	private int itake = 22;

	private int count;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "gd_r1"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
				if (!dALRight.GetRight(num, "gd_r18"))
				{
					this.btnPrint.Visible = false;
				}
				if (!dALRight.GetRight(num, "gd_r17"))
				{
					this.btnExcel.Enabled = false;
				}
				if (!dALRight.GetRight(num, "gd_r14"))
				{
					this.btnChkClose.Enabled = false;
					this.btnDel.Enabled = false;
				}
				if (!dALRight.GetRight(num, "gd_r34"))
				{
					this.btnRepair.Disabled = true;
				}
				if (dALRight.GetRight(num, "gd_r33"))
				{
					this.divdetail.Visible = false;
				}
				if (dALRight.GetRight(num, "gd_r25"))
				{
					this.hfPurDept.Value = "1";
				}
				if (dALRight.GetRight(num, "gd_r27"))
				{
					this.hfPurOPDept.Value = "1";
				}
				if (dALRight.GetRight(num, "gd_r36"))
				{
					this.hfTecDept.Value = "1";
				}
			}
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
	}

	protected void btnClr_Click(object sender, EventArgs e)
	{
		this.hfcbID.Value = "";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		if (this.hfRecID.Value != "-1")
		{
			this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
			this.ShowDetail();
		}
	}

	protected void btnOrder_Click(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
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
		this.hfSch.Value = "0";
		this.hfRecID.Value = "-1";
		this.hfcbID.Value = "";
		this.hfParm.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void btnSchH_Click(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.hfcbID.Value = "";
		if (this.hfParm.Value != "-1")
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
	}

	protected void btnFsh_Click(object sender, EventArgs e)
	{
		this.hfSch.Value = "-1";
		this.hfRecID.Value = "-1";
		this.hfcbID.Value = "";
		this.hfParm.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void LoadField()
	{
		int userID = 0;
		int.TryParse((string)this.Session["Session_wtUserID"], out userID);
		DALSys dALSys = new DALSys();
		DataTable dataTable = dALSys.GetLayoutDetail(1, 1, 13, 0, userID).Tables[0];
		this.count = dataTable.Rows.Count;
		if (dataTable.Rows.Count > 0)
		{
			this.gvdata.Columns.Clear();
			BoundField boundField = new BoundField();
			boundField.DataField = "ID";
			boundField.HeaderText = "ID";
			this.gvdata.Columns.Add(boundField);
			TemplateField templateField = new TemplateField();
			templateField.ItemTemplate = new MyTemplate2("", DataControlRowType.DataRow);
			this.gvdata.Columns.Add(templateField);
			boundField = new BoundField();
			boundField.DataField = "CancelReason";
			boundField.HeaderText = "取消原因";
			this.gvdata.Columns.Add(boundField);
			this.itake = 0;
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				BoundField boundField2 = new BoundField();
				boundField2.DataField = dataTable.Rows[i]["FieldName"].ToString();
				boundField2.HeaderText = dataTable.Rows[i]["TitleName"].ToString();
				if (dataTable.Rows[i]["FieldName"].ToString() == "TakeSteps")
				{
					this.itake = i + 3;
				}
				this.gvdata.Columns.Add(boundField2);
			}
			boundField = new BoundField();
			boundField.DataField = "IsDismissed";
			boundField.HeaderText = "IsDismissed";
			this.gvdata.Columns.Add(boundField);
			this.blayout = true;
		}
	}

	protected void FillData(string sortExpression, string direction)
	{
		this.LoadField();
		int recordCount = 0;
		string text = (this.hfParm.Value == "-1") ? this.strParm() : (this.hfParm.Value + " and curStatus='待审核' ");
		string fldSort = sortExpression + " " + direction;
		if (this.hfPurDept.Value == "1")
		{
			text = text + " and (SellerID in(select ID from StaffList where StaffDeptID=(select StaffDeptID from StaffList where ID=" + (string)this.Session["Session_wtUserID"] + ")) or SellerID is null)";
		}
		if (this.hfPurOPDept.Value == "1")
		{
			text = text + " and (OperatorID in(select ID from StaffList where StaffDeptID=(select StaffDeptID from StaffList where ID=" + (string)this.Session["Session_wtUserID"] + ")) or OperatorID is null)";
		}
		if (this.hfTecDept.Value == "1")
		{
			text = text + " and (DisposalOper in(select _Name from StaffList where bTechnician=1 and StaffDeptID=(select StaffDeptID from StaffList where ID=" + (string)this.Session["Session_wtUserID"] + ")) or DisposalOper is null)";
		}
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
				if (i > 2)
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
					if (dataField != "ID" && dataField != "IsDismissed")
					{
						if (this.hfTbTitle.Value == string.Empty)
						{
							this.hfTbTitle.Value = text2;
						}
						else
						{
							HiddenField expr_3C6 = this.hfTbTitle;
							expr_3C6.Value = expr_3C6.Value + "," + text2;
						}
						if (this.hfTbField.Value == string.Empty)
						{
							this.hfTbField.Value = dataField;
						}
						else
						{
							HiddenField expr_416 = this.hfTbField;
							expr_416.Value = expr_416.Value + "," + dataField;
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
		string text = " curStatus='待审核' ";
		string text2 = FunLibrary.ChkInput(this.tbCon.Text);
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
		e.Row.Cells[0].Visible = (e.Row.Cells[2].Visible = false);
		if (this.count == 0)
		{
			e.Row.Cells[31].Visible = false;
		}
		else
		{
			e.Row.Cells[this.count + 3].Visible = false;
		}
		string empty = string.Empty;
		string[] array = this.hfcbID.Value.Split(new char[]
		{
			','
		});
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ChkView();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:5px;");
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
			if (e.Row.Cells[2].Text != "&nbsp;")
			{
				e.Row.Attributes.Add("style", "color:#848284");
			}
			if (this.count == 0)
			{
				if (e.Row.Cells[31].Text == "1")
				{
					e.Row.Attributes.Add("style", "color:#893232");
				}
			}
			else if (e.Row.Cells[this.count + 3].Text == "1")
			{
				e.Row.Attributes.Add("style", "color:#893232");
			}
			if (this.blayout)
			{
				if (this.itake > 3)
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

	protected void btnChkClose_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		DALServices dALServices = new DALServices();
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
				int num4 = dALServices.ChkClose(num3, int.Parse((string)this.Session["Session_wtUserID"]), out empty);
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
			this.SysInfo("window.alert('操作成功！" + num2.ToString() + "条服务单已审核关闭');");
		}
		else if (num2 == 0)
		{
			this.SysInfo("window.alert('操作失败！" + num.ToString() + "条服务单状态已变化，请刷新后操作！');");
		}
		else
		{
			this.SysInfo(string.Concat(new string[]
			{
				"window.alert('",
				num2.ToString(),
				"条服务单已审核关闭；",
				num.ToString(),
				"条服务单状态已变化，请刷新后操作！');"
			}));
		}
		this.hfRecID.Value = "-1";
		this.hfcbID.Value = "";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void btnShow_Click(object sender, EventArgs e)
	{
		this.ShowDetail();
	}

	public void ShowDetail()
	{
		if (this.hfRecID.Value != "-1")
		{
			DataTable dataTable = DALCommon.GetDataList("fw_services", "", " [ID]=" + this.hfRecID.Value).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbDOperator.Text = dataTable.Rows[0]["DisposalOper"].ToString();
				this.tbBrand.Text = dataTable.Rows[0]["ProductBrand"].ToString();
				this.tbClass.Text = dataTable.Rows[0]["ProductClass"].ToString();
				this.tbModel.Text = dataTable.Rows[0]["ProductModel"].ToString();
				this.tbFault.Text = dataTable.Rows[0]["Fault"].ToString();
				this.tbTakeSteps.Text = dataTable.Rows[0]["TakeSteps"].ToString();
				this.tbdPoint.Text = dataTable.Rows[0]["dPoint"].ToString();
				this.tbRemark.Text = dataTable.Rows[0]["Remark"].ToString();
				this.tbSubPrice.Text = dataTable.Rows[0]["SubscribePrice"].ToString();
				this.tbFee_Materail.Text = dataTable.Rows[0]["Fee_Materail"].ToString();
				this.tbFee_Labor.Text = dataTable.Rows[0]["Fee_Labor"].ToString();
				this.tbCancelReason.Text = dataTable.Rows[0]["CancelReason"].ToString();
				this.tbSurCharge.Text = dataTable.Rows[0]["Fee_Add"].ToString();
				this.tbTotal.Text = dataTable.Rows[0]["Fee_Total"].ToString();
			}
		}
		this.GridView2.DataSource = DALCommon.GetDataList("fw_deduct", "", " BillID=" + this.hfRecID.Value);
		this.GridView2.DataBind();
	}

	protected void btnDel_Click(object sender, EventArgs e)
	{
		string str = this.hfRecID2.Value.Replace("d", "");
		string empty = string.Empty;
		int num = DALCommon.DeteleData("BillDeduct", "[ID]=" + str, out empty);
		if (num == 0)
		{
			this.hfRecID2.Value = "-1";
		}
		else if (num == -1)
		{
			this.SysInfo("window.alert(\"" + empty + "\");");
		}
		else
		{
			this.SysInfo("window.alert('系统错误！请查看错误日志');");
		}
		this.ShowDetail();
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "d" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('d" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ModDeduct();");
			e.Row.Cells[1].Attributes.Add("id", "td" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
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
			this.SysInfo("window.alert(\"" + empty + "\");");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
