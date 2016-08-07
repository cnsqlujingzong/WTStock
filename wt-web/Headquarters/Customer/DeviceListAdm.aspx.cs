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

public partial class Headquarters_Customer_DeviceListAdm : Page, IRequiresSessionState
{

	private int pageSize = 20;

	private int pageSized = 20;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "kh_r6"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
				if (!dALRight.GetRight(num, "kh_r8"))
				{
					this.btnDel.Enabled = false;
					this.btnDelConf.Enabled = false;
					this.btnDelQty.Enabled = false;
				}
				if (!dALRight.GetRight(num, "kh_r9"))
				{
					this.btnExcel.Enabled = false;
				}
				if (!dALRight.GetRight(num, "kh_r7"))
				{
					this.btnInput.Visible = false;
					this.btnInDevConf.Visible = false;
					this.btnIntputDevConf.Visible = false;
				}
				if (dALRight.GetRight(num, "kh_r34"))
				{
					this.hfPur1.Value = "1";
				}
				if (dALRight.GetRight(num, "kh_r18"))
				{
					DataTable dataTable = DALCommon.GetDataList("StaffList", "Area", " [ID]=" + (string)this.Session["Session_wtUserID"]).Tables[0];
					if (dataTable.Rows.Count > 0)
					{
						this.hfPurArea.Value = dataTable.Rows[0]["Area"].ToString();
					}
				}
				if (dALRight.GetRight(num, "kh_r35"))
				{
					this.hfPurDept.Value = "1";
				}
			}
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
	}

	protected void btnClr_Click(object sender, EventArgs e)
	{
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		if (this.hfRecID.Value != "-1")
		{
			this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
			this.ShowDetail();
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
			this.ShowDetail();
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
		int.TryParse((string)this.Session["Session_wtUserID"], out userID);
		DALSys dALSys = new DALSys();
		DataTable dataTable = dALSys.GetLayoutDetail(1, 1, 16, 0, userID).Tables[0];
		if (dataTable.Rows.Count > 0)
		{
			this.gvtrouble.Columns.Clear();
			TemplateField templateField = new TemplateField();
			templateField.HeaderText = "<input id=\"chkall\" type=\"checkbox\" class=\"cb1\" onclick=\"ChkALL();\" title=\"全选/取消全选\"/>";
			templateField.ItemTemplate = new MyTemplatexcus18("", DataControlRowType.DataRow);
			this.gvtrouble.Columns.Add(templateField);
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
		if (this.hfPur1.Value == "1")
		{
			text = text + " and (CHARINDEX('" + this.Session["Session_wtUser"].ToString() + "',Technicians)>0)";
		}
		if (this.hfPurDept.Value == "1")
		{
			text = text + " and (SellerID in(select ID from StaffList where StaffDeptID=(select StaffDeptID from StaffList where ID=" + (string)this.Session["Session_wtUserID"] + ")) or SellerID is null)";
		}
		this.hfSql.Value = text;
		this.gvtrouble.DataSource = DALCommon.GetList_HL(1, "ks_device", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
		this.gvtrouble.DataBind();
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
		if (this.gvtrouble.Rows.Count > 0)
		{
			for (int i = 1; i < this.gvtrouble.HeaderRow.Cells.Count; i++)
			{
				string dataField = ((BoundField)this.gvtrouble.Columns[i]).DataField;
				string text2 = this.gvtrouble.HeaderRow.Cells[i].Text;
				this.gvtrouble.HeaderRow.Cells[i].Attributes.Add("id", dataField);
				this.gvtrouble.HeaderRow.Cells[i].Attributes.Add("onclick", string.Concat(new string[]
				{
					"HeaderOrder('",
					dataField,
					"','",
					text2,
					"');"
				}));
				this.gvtrouble.HeaderRow.Cells[i].Attributes.Add("onmouseover", "this.style.cursor='default';");
				if (dataField != "ID")
				{
					if (this.hfTbTitle.Value == string.Empty)
					{
						this.hfTbTitle.Value = text2;
					}
					else
					{
						HiddenField expr_38B = this.hfTbTitle;
						expr_38B.Value = expr_38B.Value + "," + text2;
					}
					if (this.hfTbField.Value == string.Empty)
					{
						this.hfTbField.Value = dataField;
					}
					else
					{
						HiddenField expr_3DB = this.hfTbField;
						expr_3DB.Value = expr_3DB.Value + "," + dataField;
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
		string text = " 1=1 ";
		string text2 = FunLibrary.ChkInput(this.tbCon.Text);
		if (this.hfSch.Value == "0")
		{
			if (this.ddlKey.SelectedValue != "-1")
			{
				if (this.ddlKey.SelectedValue == "9")
				{
					if (text2 != "")
					{
						text = text + " and [ID] in (select DevID from ks_maintenanceplan where Status='" + text2 + "')";
					}
				}
				else
				{
					int schid = 0;
					int.TryParse(this.ddlKey.SelectedValue, out schid);
					if (text2 != "")
					{
						DALDeviceList dALDeviceList = new DALDeviceList();
						text += dALDeviceList.GetSchWhere(schid, text2);
					}
				}
			}
		}
		return text;
	}

	protected void gvtrouble_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[1].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[1].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[1].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ModClick();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[0].Text = "<input id=\"chk" + e.Row.Cells[1].Text + "\" type=\"checkbox\"/>";
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.gvtrouble.Rows.Count.ToString();
		}
	}

	protected void btnDel_Click(object sender, EventArgs e)
	{
		string value = this.hfcbID.Value;
		if (value != "")
		{
			string[] array = value.Split(new char[]
			{
				','
			});
			string[] array2 = array;
			int i = 0;
			while (i < array2.Length)
			{
				string s = array2[i];
				int iTbid = int.Parse(s);
				string empty = string.Empty;
				int num = DALCommon.DeteleData(1, 0, iTbid, out empty);
				if (num == 0)
				{
					this.hfRecID.Value = "-1";
					this.hfcbID.Value = "-1";
					i++;
				}
				else
				{
					if (num == -1)
					{
						this.SysInfo("window.alert('" + empty + "');");
						return;
					}
					this.SysInfo("window.alert('" + empty + "');");
					return;
				}
			}
		}
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
		DataTable dt = DALCommon.GetDataList("ks_device", this.hfTbField.Value, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "机器档案", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert('" + empty + "');");
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "p" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrBaseID3('p" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "EditDevPlan();");
			e.Row.Cells[1].Attributes.Add("id", "tp" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "d" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('d" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ModDevConf();");
			e.Row.Cells[1].Attributes.Add("id", "td" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}

	protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "q" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('q" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ModQty();");
			e.Row.Cells[1].Attributes.Add("id", "tq" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}

	protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "a" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('a" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ModAcc();");
			e.Row.Cells[1].Attributes.Add("id", "ta" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
			if (e.Row.Cells[4].Text != "&nbsp;" && e.Row.Cells[4].Text != "")
			{
				e.Row.Cells[4].Text = "<a href=\"" + e.Row.Cells[4].Text + "\" target=\"_blank\" style=\"color:#0000ff\" >查看</a>";
			}
		}
	}

	protected void btnDelQty_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		int num = DALCommon.DeteleData("QtyList", " [ID]=" + this.hfRecID2.Value.Replace("q", ""), out empty);
		if (num == 0)
		{
			this.hfRecID2.Value = "-1";
		}
		else if (num == -1)
		{
			this.SysInfo("window.alert('" + empty + "');");
		}
		else
		{
			this.SysInfo("window.alert('系统错误！请查看错误日志');");
		}
		this.FillDataa();
	}

	protected void btnDelAcc_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		int num = DALCommon.DeteleData("DeviceAccessory", " [ID]=" + this.hfRecID2.Value.Replace("a", ""), out empty);
		if (num == 0)
		{
			this.hfRecID2.Value = "-1";
		}
		else if (num == -1)
		{
			this.SysInfo("window.alert('" + empty + "');");
		}
		else
		{
			this.SysInfo("window.alert('系统错误！请查看错误日志');");
		}
		this.FillDataa();
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void btnShow_Click(object sender, EventArgs e)
	{
		this.ShowDetail();
	}

	protected void ShowDetail()
	{
		int num = 0;
		this.GridView2.DataSource = DALCommon.GetList_HL(0, "DeviceConfig", "", 0, 0, " DeviceID=" + this.hfRecID.Value, " ID desc ", out num);
		this.GridView2.DataBind();
		this.GridView1.DataSource = DALCommon.GetDataList("ks_maintenanceplan", "", " DevID=" + this.hfRecID.Value + " order by ID desc");
		this.GridView1.DataBind();
		this.FillDataa();
		this.FillDatale();
		this.FillDatab();
		DataTable dataTable = DALCommon.GetDataList("ks_device", "ProductSN1", "[ID]=" + this.hfRecID.Value).Tables[0];
		string text = " DeviceID=" + this.hfRecID.Value;
		if (dataTable.Rows.Count > 0)
		{
			text = text + " or SN='" + dataTable.Rows[0]["ProductSN1"].ToString() + "'";
		}
		this.GridView3.DataSource = DALCommon.GetDataList("ks_qtylist", "", text);
		this.GridView3.DataBind();
	}

	protected void FillDataa()
	{
		this.GridView4.DataSource = DALCommon.GetDataList("ks_deviceaccessory", "", " DeviceID=" + this.hfRecID.Value + " order by ID desc");
		this.GridView4.DataBind();
	}

	protected void btnDelConf_Click(object sender, EventArgs e)
	{
		string str = this.hfRecID2.Value.Replace("d", "");
		string empty = string.Empty;
		int num = DALCommon.DeteleData("DeviceConfig", "[ID]=" + str, out empty);
		if (num == 0)
		{
			this.hfRecID2.Value = "-1";
		}
		else if (num == -1)
		{
			this.SysInfo("window.alert('" + empty + "');");
		}
		else
		{
			this.SysInfo("window.alert('系统错误！请查看错误日志');");
		}
		this.ShowDetail();
	}

	protected void FillDatale()
	{
		int recordCount = 0;
		string strCondition = " DeviceID=" + this.hfRecID.Value;
		string fldSort = " [_Date] desc";
		this.GridView5.DataSource = DALCommon.GetList_HL(1, "zl_meterreading", "", this.pageSized, this.jsPagerle.CurrentPageIndex, strCondition, fldSort, out recordCount);
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
			e.Row.Cells[1].Attributes.Add("id", "tle" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPagele.Text = "当前页:" + this.GridView5.Rows.Count.ToString();
		}
	}

	protected void FillDatab()
	{
		string text = " 1=1 ";
		DataTable dataTable = DALCommon.GetDataList("ks_device", "CustomerID,ProductSN1,ProductBrand,ProductClass,ProductModel", "[ID]=" + this.hfRecID.Value).Tables[0];
		if (dataTable.Rows.Count > 0)
		{
			text = text + " and CustomerID=" + dataTable.Rows[0]["CustomerID"].ToString();
			if (dataTable.Rows[0]["ProductSN1"].ToString() != "")
			{
				text = text + " and ProductSN1='" + dataTable.Rows[0]["ProductSN1"].ToString() + "'";
			}
			else
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					" and ProductBrand='",
					dataTable.Rows[0]["ProductBrand"].ToString(),
					"' and ProductClass='",
					dataTable.Rows[0]["ProductClass"].ToString(),
					"' and ProductModel='",
					dataTable.Rows[0]["ProductModel"].ToString(),
					"'"
				});
			}
		}
		this.hfSql2.Value = text;
		this.GridView6.DataSource = DALCommon.GetDataList("fw_services", "", text);
		this.GridView6.DataBind();
		this.hfTbTitle2.Value = (this.hfTbField2.Value = string.Empty);
		if (this.GridView6.Rows.Count > 0)
		{
			for (int i = 0; i < this.GridView6.HeaderRow.Cells.Count; i++)
			{
				if (i > 1)
				{
					string dataField = ((BoundField)this.GridView6.Columns[i]).DataField;
					string text3 = this.GridView6.HeaderRow.Cells[i].Text;
					if (this.hfTbTitle2.Value == string.Empty)
					{
						this.hfTbTitle2.Value = text3;
					}
					else
					{
						HiddenField expr_270 = this.hfTbTitle2;
						expr_270.Value = expr_270.Value + "," + text3;
					}
					if (this.hfTbField2.Value == string.Empty)
					{
						this.hfTbField2.Value = dataField;
					}
					else
					{
						HiddenField expr_2C0 = this.hfTbField2;
						expr_2C0.Value = expr_2C0.Value + "," + dataField;
					}
				}
			}
		}
	}

	protected void GridView6_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
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
	}

	protected void btnExcelSer_Click(object sender, EventArgs e)
	{
		string value = this.hfSql2.Value;
		DataTable dt = DALCommon.GetDataList("fw_services", this.hfTbField2.Value, value).Tables[0];
		string[] tbTitle = this.hfTbTitle2.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "services", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert('" + empty + "');");
		}
	}

	protected void btnDelPlan_Click(object sender, EventArgs e)
	{
		DALMaintenancePlan dALMaintenancePlan = new DALMaintenancePlan();
		int num = dALMaintenancePlan.DelPlan(int.Parse(this.hfRecID3.Value.Trim(new char[]
		{
			'p'
		})));
		if (num <= 0)
		{
			ScriptManager.RegisterStartupScript(this.UpdatePanel3, this.UpdatePanel3.GetType(), "key", "window.alert('删除失败！只能删除已终止的保养计划');", true);
		}
		this.ShowDetail();
	}

	protected void btnAccExcel_Click(object sender, EventArgs e)
	{
		string strCondition = "DeviceID=" + this.hfRecID.Value;
		DataTable dt = DALCommon.GetDataList("ks_deviceaccessory", "_Name,Remark,_Date,Operator", strCondition).Tables[0];
		string[] tbTitle = new string[]
		{
			"名称",
			"摘要",
			"创建日期",
			"创建人"
		};
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "机器附件", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert('" + empty + "');");
		}
	}
}
