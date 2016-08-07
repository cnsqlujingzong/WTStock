using System;
using System.Collections.Generic;
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

public partial class Headquarters_Lease_SettleCharge : Page, IRequiresSessionState
{

	private int id;

	private decimal dec_Rec;

	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("OperationID", typeof(string)));
				dataTable.Columns.Add(new DataColumn("_Date", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Operator", typeof(string)));
				dataTable.Columns.Add(new DataColumn("StartDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("EndDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("dRec", typeof(string)));
				dataTable.Columns.Add(new DataColumn("InCash", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("ID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("Discount", typeof(decimal)));
				this.ViewState["List"] = dataTable;
			}
			return (DataTable)this.ViewState["List"];
		}
		set
		{
			this.ViewState["List"] = value;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "zl_r10"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=1 and Status=0");
			string b = (string)this.Session["Session_wtUser"];
			for (int i = 0; i < this.ddlOperator.Items.Count; i++)
			{
				if (this.ddlOperator.Items[i].Text == b)
				{
					this.ddlOperator.Items[i].Selected = true;
					break;
				}
			}
			OtherFunction.BindChargeItem(this.ddlItem, " Type=0 and DeptID=1");
			OtherFunction.BindChargeStyle(this.ddlChargeStyle, "");
			OtherFunction.BindInviceClass(this.ddlInvoiceClass, "");
			OtherFunction.BindChargeAccount(this.ddlAccount, "DeptID=1");
			this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
			this.tbRent.Text = (this.tbSuperZhangFee.Text = (this.tbRec.Text = (this.tbInCash.Text = (this.tbDiscount.Text = "0.00"))));
			this.AddEmpty();
			decimal d = 0m;
			decimal d2 = 0m;
			decimal d3 = 0m;
			DataTable gridViewSource = this.GridViewSource;
			DataTable dataTable = DALCommon.GetDataList("zl_leasecharge", "", "Status=1 and [BillID]=" + this.id).Tables[0];
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				DataRow dataRow = gridViewSource.NewRow();
				dataRow[0] = dataTable.Rows[i]["OperationID"].ToString();
				dataRow[1] = dataTable.Rows[i]["_Date"].ToString();
				dataRow[2] = dataTable.Rows[i]["Operator"].ToString();
				dataRow[3] = dataTable.Rows[i]["StartDate"].ToString();
				dataRow[4] = dataTable.Rows[i]["EndDate"].ToString();
				dataRow[5] = decimal.Parse(dataTable.Rows[i]["dRec"].ToString());
				dataRow[6] = decimal.Parse(dataTable.Rows[i]["dRec"].ToString());
				dataRow[7] = int.Parse(dataTable.Rows[i]["ID"].ToString());
				dataRow[8] = 0;
				d += decimal.Parse(dataTable.Rows[i]["Rent"].ToString()) * decimal.Parse(dataTable.Rows[i]["Cycle"].ToString());
				d2 += decimal.Parse(dataTable.Rows[i]["SuperZhangFee"].ToString());
				d3 += decimal.Parse(dataTable.Rows[i]["dRec"].ToString());
				gridViewSource.Rows.Add(dataRow);
			}
			this.tbRent.Text = d.ToString("0.00");
			this.tbSuperZhangFee.Text = d2.ToString("0.00");
			this.tbRec.Text = (this.tbInCash.Text = d3.ToString("0.00"));
			this.GridViewSource = gridViewSource;
			this.BindData();
		}
	}

	private void AddEmpty()
	{
		DataTable gridViewSource = this.GridViewSource;
		DataRow dataRow = gridViewSource.NewRow();
		dataRow[0] = "";
		dataRow[1] = "";
		dataRow[2] = "";
		dataRow[3] = "";
		dataRow[4] = "";
		dataRow[5] = 0;
		dataRow[6] = 0;
		dataRow[7] = 0;
		dataRow[8] = 0;
		gridViewSource.Rows.Add(dataRow);
		this.GridViewSource = gridViewSource;
		this.BindData();
	}

	private void BindData()
	{
		this.gvdata.DataSource = this.GridViewSource;
		this.gvdata.DataBind();
	}

	protected void CollectData()
	{
		for (int i = 0; i < this.gvdata.Rows.Count; i++)
		{
			TextBox textBox = this.gvdata.Rows[i].FindControl("tbInCash") as TextBox;
			TextBox textBox2 = this.gvdata.Rows[i].FindControl("tbDiscount") as TextBox;
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i]["InCash"] = decimal.Parse(textBox.Text);
			gridViewSource.Rows[i]["Discount"] = decimal.Parse(textBox2.Text);
		}
	}

	protected void gvdata_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		this.CollectData();
		decimal num = decimal.Parse(this.tbDiscount.Text);
		decimal d = decimal.Parse(this.tbRec.Text);
		decimal d2 = decimal.Parse(this.tbInCash.Text);
		decimal d3 = decimal.Parse(this.GridViewSource.Rows[e.RowIndex][6].ToString());
		decimal d4 = decimal.Parse(this.GridViewSource.Rows[e.RowIndex][6].ToString());
		this.tbRec.Text = (d - d3).ToString();
		this.tbInCash.Text = (d2 - d4).ToString();
		this.GridViewSource.Rows[e.RowIndex].Delete();
		this.BindData();
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowIndex == 0)
		{
			e.Row.Visible = false;
		}
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			LinkButton linkButton = e.Row.FindControl("lbDel") as LinkButton;
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex);
			linkButton.Attributes.Add("num", e.Row.RowIndex.ToString());
			decimal.TryParse(e.Row.Cells[8].Text, out this.dec_Rec);
			TextBox textBox = e.Row.FindControl("tbDiscount") as TextBox;
			TextBox textBox2 = e.Row.FindControl("tbInCash") as TextBox;
			textBox.Attributes.Add("onchange", string.Concat(new object[]
			{
				"calcAmount1(",
				textBox2.ClientID,
				",",
				this.dec_Rec,
				",",
				textBox.ClientID,
				")"
			}));
			e.Row.Cells[9].Attributes.Add("class", "tbbg");
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		this.CollectData();
		DataTable gridViewSource = this.GridViewSource;
		if (this.GridViewSource.Rows.Count == 1)
		{
			this.SysInfo("window.alert('操作失败！结算明细不存在，不能结算');");
		}
		else
		{
			decimal num = 0m;
			decimal.TryParse(this.tbRec.Text, out num);
			decimal d = 0m;
			decimal d2 = 0m;
			decimal.TryParse(this.tbInCash.Text, out d2);
			decimal d3 = 0m;
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				decimal.TryParse(gridViewSource.Rows[i]["InCash"].ToString(), out d3);
				d += d3;
			}
			if (d != d2)
			{
				this.SysInfo("window.alert('操作失败！现收金额与单据明细不符，请修改！');");
			}
			else
			{
				int customerID = new DALLease().getCustomerID(this.id);
				decimal d4 = 0m;
				decimal.TryParse(this.tbInCash.Text, out d4);
				decimal positionAmount = new DALCustomerList().getPositionAmount(customerID);
				decimal balance = new DALArrearage().getBalance(customerID);
				decimal d5 = 0m;
				decimal.TryParse(this.tbRec.Text, out d5);
				decimal d6 = 0m;
				decimal.TryParse(this.tbDiscount.Text, out d6);
				if (positionAmount > 0m)
				{
					if (positionAmount - balance - d5 + d6 + d4 < 0m)
					{
						this.SysInfo("window.alert('结算失败，客户信誉额度不足，无法挂账！');");
						return;
					}
				}
				string str = "";
				DALLeaseCharge dALLeaseCharge = new DALLeaseCharge();
				int num2 = 0;
				decimal num3 = 0m;
				List<string[]> list = new List<string[]>();
				for (int j = 1; j < gridViewSource.Rows.Count; j++)
				{
					string[] array = new string[3];
					array[0] = "LeaseCharge";
					decimal.TryParse(gridViewSource.Rows[j]["InCash"].ToString(), out num3);
					string text = " InCash=" + num3.ToString();
					array[1] = text;
					int.TryParse(gridViewSource.Rows[j]["ID"].ToString(), out num2);
					array[2] = " [ID]=" + num2.ToString();
					list.Add(array);
				}
				decimal invoiceAmount = 0m;
				decimal.TryParse(this.tbInvoiceAmount.Text, out invoiceAmount);
				int num4 = dALLeaseCharge.UpdateCusBln(list, out str);
				if (num4 == 0)
				{
					int iOperator = 0;
					int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
					DALLease dALLease = new DALLease();
					for (int i = 1; i < gridViewSource.Rows.Count; i++)
					{
						string jsID = gridViewSource.Rows[i]["OperationID"].ToString();
						decimal amount = 0m;
						decimal.TryParse(gridViewSource.Rows[i]["dRec"].ToString(), out amount);
						decimal dInCash = 0m;
						decimal.TryParse(gridViewSource.Rows[i]["InCash"].ToString(), out dInCash);
						decimal dDiscount = 0m;
						decimal.TryParse(gridViewSource.Rows[i]["Discount"].ToString(), out dDiscount);
						num4 = dALLease.ChkBln(1, this.id, iOperator, int.Parse(this.ddlOperator.SelectedValue), jsID, DateTime.Parse(this.tbDate.Text), amount, int.Parse(this.ddlAccount.SelectedValue), dInCash, FunLibrary.ChkInput(this.tbRemark.Text), int.Parse(this.ddlChargeStyle.SelectedValue), FunLibrary.ChkInput(this.tbInvoiceDate.Text), invoiceAmount, FunLibrary.ChkInput(this.tbInvoiceNO.Text), int.Parse(this.ddlInvoiceClass.SelectedValue), int.Parse(this.ddlItem.SelectedValue), out str, dDiscount);
						if (num4 == 0)
						{
							this.SysInfo("parent.CloseDialog('2');window.alert('操作成功！结算单审核成功');");
						}
						else
						{
							this.SysInfo("window.alert('操作失败！" + str + "');");
						}
					}
				}
				else
				{
					this.SysInfo("window.alert('操作失败！" + str + "');");
				}
			}
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
