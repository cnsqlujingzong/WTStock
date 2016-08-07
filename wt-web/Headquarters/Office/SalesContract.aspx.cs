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

public partial class Headquarters_Office_SalesContract : Page, IRequiresSessionState
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
				if (!dALRight.GetRight(num, "kh_r20"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
				if (!dALRight.GetRight(num, "kh_r23"))
				{
					this.btnDelCont.Enabled = false;
				}
				if (!dALRight.GetRight(num, "kh_r24"))
				{
					this.btnCancel.Visible = false;
				}
				if (dALRight.GetRight(num, "kh_r18"))
				{
					DataTable dataTable = DALCommon.GetDataList("StaffList", "Area", " [ID]=" + (string)this.Session["Session_wtUserID"]).Tables[0];
					if (dataTable.Rows.Count > 0)
					{
						this.hfPurArea.Value = dataTable.Rows[0]["Area"].ToString();
					}
				}
				if (dALRight.GetRight(num, "xs_r20"))
				{
					this.hfgeli.Value = "1";
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
			this.SysInfo("ChkIDd('" + this.hfRecID.Value + "');");
			this.ShowDetail();
		}
	}

	protected void btnOrder_Click(object sender, EventArgs e)
	{
		this.hfcbID.Value = "";
		this.hfRecID.Value = "-1";
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

	protected void FillData(string sortExpression, string direction)
	{
		int recordCount = 0;
		string text = (this.hfParm.Value == "-1") ? this.strParm() : (this.hfParm.Value + " and DeptID=1 ");
		string fldSort = sortExpression + " " + direction;
		if (this.hfgeli.Value == "1")
		{
			text = text + " and SellerID=" + this.Session["Session_wtUserID"].ToString();
		}
		this.hfSql.Value = text;
		this.gvdata.DataSource = DALCommon.GetList_HL(1, "v_salecontract", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
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
					if (dataField != "ID")
					{
						if (this.hfTbTitle.Value == string.Empty)
						{
							this.hfTbTitle.Value = text2;
						}
						else
						{
							HiddenField expr_315 = this.hfTbTitle;
							expr_315.Value = expr_315.Value + "," + text2;
						}
						if (this.hfTbField.Value == string.Empty)
						{
							this.hfTbField.Value = dataField;
						}
						else
						{
							HiddenField expr_365 = this.hfTbField;
							expr_365.Value = expr_365.Value + "," + dataField;
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
		string text = " DeptID=1 ";
		string text2 = FunLibrary.ChkInput(this.tbCon.Text);
		if (this.hfSch.Value == "0")
		{
			if (this.ddlKey.SelectedValue != "-1")
			{
				int schid = 0;
				int.TryParse(this.ddlKey.SelectedValue, out schid);
				if (text2 != "")
				{
					DALMaintenanceContract dALMaintenanceContract = new DALMaintenanceContract();
					text += dALMaintenanceContract.GetSchWhere(schid, text2);
				}
			}
		}
		if (this.hfPurArea.Value != "")
		{
			text = text + " and (CHARINDEX('" + this.hfPurArea.Value + "',Area)>0 or Area='' or Area is null) ";
		}
		return text;
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = (e.Row.Cells[1].Visible = false);
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkID('",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');"
			}));
			e.Row.Attributes.Add("ondblclick", "ModCont();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			if (e.Row.Cells[2].Text == "1")
			{
				e.Row.Attributes.Add("style", "color: #ff0000");
				e.Row.Cells[2].Text = "待执行";
			}
			else if (e.Row.Cells[2].Text == "2")
			{
				e.Row.Attributes.Add("style", "color: #008000");
				e.Row.Cells[2].Text = "执行中";
			}
			else if (e.Row.Cells[2].Text == "3")
			{
				e.Row.Attributes.Add("style", "color: #0000ff");
				e.Row.Cells[2].Text = "已执行";
			}
			else if (e.Row.Cells[2].Text == "4")
			{
				e.Row.Attributes.Add("style", "color:#848284");
				e.Row.Cells[2].Text = "已终止";
			}
			if (e.Row.Cells[14].Text != "&nbsp;" && e.Row.Cells[14].Text != "")
			{
				e.Row.Cells[14].Text = "<a href=\"" + e.Row.Cells[14].Text + "\" target=\"_blank\" style=\"color:#0000ff\" >查看</a>";
			}
			if (e.Row.Cells[12].Text == "&nbsp;")
			{
				e.Row.Cells[12].Text = Convert.ToDouble(0).ToString("#0.00");
			}
			else
			{
				e.Row.Cells[12].Text = Convert.ToDouble(e.Row.Cells[12].Text).ToString("#0.00");
			}
			if (e.Row.Cells[13].Text == "&nbsp;")
			{
				e.Row.Cells[13].Text = Convert.ToDouble(0).ToString("#0.00");
			}
			else
			{
				e.Row.Cells[13].Text = Convert.ToDouble(e.Row.Cells[12].Text).ToString("#0.00");
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.gvdata.Rows.Count.ToString();
		}
	}

	protected void FillDatab()
	{
		string text = " CustomerID=" + this.hfCustomerID.Value;
		DataTable dataTable = DALCommon.GetDataList("ks_maintenancecontract", "", "[ID]=" + this.hfRecID.Value).Tables[0];
		if (dataTable.Rows.Count > 0)
		{
			text = text + " and Time_Make>='" + dataTable.Rows[0]["StartDate"].ToString() + " 00:00:00'";
			text = text + " and Time_Make<='" + dataTable.Rows[0]["EndDate"].ToString() + " 23:59:59'";
			text = text + " and CustomerID in(select CustomerID from MaintenanceContract where MaintenanceContract.[ID] in(select BillID from ks_contractdetail where ks_contractdetail.ProductSN1=fw_services.ProductSN1) and MaintenanceContract.[ID]=" + this.hfRecID.Value + ")";
		}
		this.hfSql2.Value = text;
		this.GridView3.DataSource = DALCommon.GetDataList("fw_services", "", text);
		this.GridView3.DataBind();
		this.hfTbTitle2.Value = (this.hfTbField2.Value = string.Empty);
		if (this.GridView3.Rows.Count > 0)
		{
			for (int i = 0; i < this.GridView3.HeaderRow.Cells.Count; i++)
			{
				if (i > 1)
				{
					string dataField = ((BoundField)this.GridView3.Columns[i]).DataField;
					string text2 = this.GridView3.HeaderRow.Cells[i].Text;
					if (this.hfTbTitle2.Value == string.Empty)
					{
						this.hfTbTitle2.Value = text2;
					}
					else
					{
						HiddenField expr_1D5 = this.hfTbTitle2;
						expr_1D5.Value = expr_1D5.Value + "," + text2;
					}
					if (this.hfTbField2.Value == string.Empty)
					{
						this.hfTbField2.Value = dataField;
					}
					else
					{
						HiddenField expr_225 = this.hfTbField2;
						expr_225.Value = expr_225.Value + "," + dataField;
					}
				}
			}
		}
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "d" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('d" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "td" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:30px;padding:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
			if (e.Row.Cells[8].Text == "&nbsp;")
			{
				e.Row.Cells[8].Text = Convert.ToDouble(0).ToString("#0.00");
			}
			if (e.Row.Cells[11].Text == "&nbsp;")
			{
				e.Row.Cells[11].Text = Convert.ToDouble(0).ToString("#0.00");
			}
			else
			{
				e.Row.Cells[11].Text = Convert.ToDouble(e.Row.Cells[12].Text).ToString("#0.00");
			}
		}
	}

	protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
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

	protected void btnShow_Click(object sender, EventArgs e)
	{
		this.ShowDetail();
	}

	protected void ShowDetail()
	{
		if (this.hfRecID.Value != "")
		{
			this.GridView2.DataSource = DALCommon.GetDataList("v_salecontractdetail", "", " ContractID=" + this.hfRecID.Value);
			this.GridView2.DataBind();
		}
		if (this.hfCustomerID.Value != "")
		{
			this.FillDatab();
			DataTable dataTable = DALCommon.GetDataList("ks_customer", "", " [ID]=" + this.hfCustomerID.Value).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbCusClass.Value = dataTable.Rows[0]["ClassName"].ToString();
				this.tbCusLinkMan.Text = dataTable.Rows[0]["LinkMan"].ToString();
				this.tbCusTel.Text = dataTable.Rows[0]["Tel"].ToString();
				this.tbCusTel2.Text = dataTable.Rows[0]["Tel2"].ToString();
				this.tbCusFax.Text = dataTable.Rows[0]["Fax"].ToString();
				this.tbCusZip.Text = dataTable.Rows[0]["Zip"].ToString();
				this.tbEmail.Text = dataTable.Rows[0]["Email"].ToString();
				this.tbArea.Text = dataTable.Rows[0]["Area"].ToString();
				this.tbSeller.Text = dataTable.Rows[0]["Seller"].ToString();
				this.tbFrom.Text = dataTable.Rows[0]["CusFrom"].ToString();
				this.tbMember.Text = dataTable.Rows[0]["Member"].ToString();
				this.tbAccount.Text = dataTable.Rows[0]["Account"].ToString();
				this.tbCusAdr.Text = dataTable.Rows[0]["Adr"].ToString();
				this.tbRemark.Text = dataTable.Rows[0]["Remark"].ToString();
				if (dataTable.Rows[0]["bStop"].ToString() != "")
				{
					this.cbStop.Checked = true;
				}
				if (dataTable.Rows[0]["bCall"].ToString() != "")
				{
					this.cbCall.Checked = true;
				}
				this.tbCoordinates.Text = dataTable.Rows[0]["Coordinates"].ToString();
			}
		}
	}

	protected void btnDelCont_Click(object sender, EventArgs e)
	{
		int num = 0;
		int.TryParse(this.hfRecID.Value, out num);
		DALSaleContract dALSaleContract = new DALSaleContract();
		int num2 = 0;
		int.TryParse((string)this.Session["Session_wtUserID"], out num2);
		int num3 = dALSaleContract.DeleteData(num);
		if (num3 == 1)
		{
			DALSaleContractDetail dALSaleContractDetail = new DALSaleContractDetail();
			dALSaleContractDetail.DeleteDataByContractID(num);
			this.hfRecID.Value = "-1";
			this.SysInfo("window.alert('删除成功');ChkIDd('" + this.hfRecID.Value + "');");
		}
		else
		{
			this.SysInfo("window.alert('系统错误！请查看错误日志');ChkIDd('" + this.hfRecID.Value + "');");
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
		DataTable dt = DALCommon.GetDataList("v_salecontract", this.hfTbField.Value, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "contract", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert('" + empty + "');");
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

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
