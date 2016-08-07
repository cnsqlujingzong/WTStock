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

public partial class Headquarters_Lease_ChangeMachine : Page, IRequiresSessionState
{

	private int pageSize = 15;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "zl_r5"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
				if (!dALRight.GetRight(num, "zl_r13"))
				{
					this.btnExcel.Enabled = false;
				}
				if (!dALRight.GetRight(num, "zl_r17"))
				{
					this.btnPrint.Visible = false;
				}
				if (!dALRight.GetRight(num, "zl_r18"))
				{
					this.btnPrint2.Visible = false;
				}
				if (dALRight.GetRight(num, "zl_r26"))
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

	protected void FillData(string sortExpression, string direction)
	{
		int recordCount = 0;
		string text = (this.hfParm.Value == "-1") ? this.strParm() : (this.hfParm.Value + " and DeptID=1 and Status=1 and DevStatus='����'");
		string fldSort = sortExpression + " " + direction;
		if (this.hfPurDept.Value == "1")
		{
			text = text + " and (SellerID in(select ID from StaffList where StaffDeptID=(select StaffDeptID from StaffList where ID=" + (string)this.Session["Session_wtUserID"] + ")) or SellerID is null)";
		}
		this.hfSql.Value = text;
		this.gvdata.DataSource = DALCommon.GetList_HL(1, "zl_leasedevice", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
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
				string dataField = ((BoundField)this.gvdata.Columns[i]).DataField;
				string text2 = this.gvdata.HeaderRow.Cells[i].Text;
				if (dataField != "" && dataField != "ID")
				{
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
						HiddenField expr_321 = this.hfTbTitle;
						expr_321.Value = expr_321.Value + "," + text2;
					}
					if (this.hfTbField.Value == string.Empty)
					{
						this.hfTbField.Value = dataField;
					}
					else
					{
						HiddenField expr_371 = this.hfTbField;
						expr_371.Value = expr_371.Value + "," + dataField;
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
		string text = " DeptID=1 and Status=1 and DevStatus='����' ";
		string text2 = FunLibrary.ChkInput(this.tbCon.Text);
		if (this.hfSch.Value == "0")
		{
			if (this.ddlKey.SelectedValue != "-1")
			{
				int schid = 0;
				int.TryParse(this.ddlKey.SelectedValue, out schid);
				if (text2 != "")
				{
					DALLease dALLease = new DALLease();
					text += dALLease.GetDeviceWhere(schid, text2);
				}
			}
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
			e.Row.Attributes.Add("ondblclick", "ModBill('" + e.Row.Cells[1].Text + "');");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			if (e.Row.Cells[2].Text == "����������")
			{
				e.Row.Attributes.Add("style", "color:#0000ff");
			}
			else if (e.Row.Cells[2].Text == "�ǳ���������")
			{
				e.Row.Attributes.Add("style", "color:#68031E");
			}
			else if (e.Row.Cells[2].Text == "ȫ��")
			{
				e.Row.Attributes.Add("style", "color:#008000");
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "��ǰҳ:" + this.gvdata.Rows.Count.ToString();
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
		DataTable dt = DALCommon.GetDataList("zl_leasedevice", this.hfTbField.Value, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "Lease", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert('" + empty + "');");
		}
	}

	protected void btnExcel2_Click(object sender, EventArgs e)
	{
		if (this.hfRecID.Value != "-1")
		{
			DataTable dt = DALCommon.GetDataList("zl_leasecharge", "OperationID,strStatus,_Date,Operator,StartDate,EndDate,Cycle,ShangQty,BenQty,Rent,SuperZhangFee,dRec,InCash,Remark", " BillID=" + this.hfRecID.Value).Tables[0];
			string[] tbTitle = new string[]
			{
				"���㵥��",
				"״̬",
				"����",
				"������",
				"��ʼ����",
				"��ֹ����",
				"����",
				"���ڼ���",
				"���ڼ���",
				"��������",
				"���ŷ�",
				"�ϼ�Ӧ��",
				"���ս��",
				"���㱸ע"
			};
			string empty = string.Empty;
			bool flag = false;
			DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "lecharge", out flag, out empty);
			if (!flag)
			{
				this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
				this.SysInfo("window.alert('" + empty + "');");
			}
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
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
			if (e.Row.Cells[4].Text == "����ʽ�㷨")
			{
				e.Row.Cells[4].Text = "����ʽ�㷨<a href=\"#\" onclick=\"ViewFormula('" + e.Row.Cells[0].Text + "')\">�鿴��ʽ</a>";
			}
		}
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "q" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('q" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "tq" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:30px;padding:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}

	protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "j" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('j" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "tj" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:30px;padding:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
			if (e.Row.Cells[3].Text == "������")
			{
				e.Row.Cells[3].Attributes.Add("style", "color:#ff0000;");
			}
			else if (e.Row.Cells[3].Text == "�ѽ���")
			{
				e.Row.Cells[3].Attributes.Add("style", "color:#0000ff;");
			}
			else if (e.Row.Cells[3].Text == "��ȡ��")
			{
				e.Row.Cells[3].Attributes.Add("style", "color:#848284;");
			}
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void btnShow_Click(object sender, EventArgs e)
	{
		this.hfRecID2.Value = "-1";
		this.ShowDetail();
	}

	protected void ShowDetail()
	{
		if (this.hfRecIDs.Value != "" && this.hfRecIDs.Value != "-1" && this.hfRecIDs.Value != "undefined")
		{
			this.GridView1.DataSource = DALCommon.GetDataList("zl_leasedetail", "", " BillID=" + this.hfRecID.Value);
			this.GridView1.DataBind();
			this.GridView2.DataSource = DALCommon.GetDataList("zl_meterreading", "", " iBillID=" + this.hfRecIDs.Value + " order by [_Date] desc");
			this.GridView2.DataBind();
			this.GridView3.DataSource = DALCommon.GetDataList("zl_leasecharge", "", " BillID=" + this.hfRecIDs.Value);
			this.GridView3.DataBind();
		}
	}
}
