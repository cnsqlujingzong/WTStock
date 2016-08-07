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
using wt.OtherLibrary;

public partial class Headquarters_Financial_ManualHedge : Page, IRequiresSessionState
{

	private int id;

	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("ID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
				dataTable.Columns.Add(new DataColumn("BillID", typeof(string)));
				dataTable.Columns.Add(new DataColumn("_Date", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Operator", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Amount", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("HaveAmount", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("NotChargeAmount", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("ChargeAmount", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));
				this.ViewState["List"] = dataTable;
			}
			return (DataTable)this.ViewState["List"];
		}
		set
		{
			this.ViewState["List"] = value;
		}
	}

	private DataTable GridViewSource2
	{
		get
		{
			if (this.ViewState["List2"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("ID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("Type", typeof(string)));
				dataTable.Columns.Add(new DataColumn("BillID", typeof(string)));
				dataTable.Columns.Add(new DataColumn("_Date", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Operator", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Amount", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("HaveAmount", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("NotChargeAmount", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("ChargeAmount", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));
				this.ViewState["List2"] = dataTable;
			}
			return (DataTable)this.ViewState["List2"];
		}
		set
		{
			this.ViewState["List2"] = value;
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
				if (!dALRight.GetRight(num, "zk_r15"))
				{
					this.btnAuto.Enabled = false;
					this.btnSave.Enabled = false;
				}
			}
			OtherFunction.BindChargeAccount(this.ddlAccount, " DeptID=1");
			DALArrearage dALArrearage = new DALArrearage();
			ArrearageInfo model = dALArrearage.GetModel(this.id);
			if (model != null)
			{
				if (model.Rec > model.Due)
				{
					this.tbAmount.Text = model.Due.ToString("#0.00");
				}
				else
				{
					this.tbAmount.Text = model.Rec.ToString("#0.00");
				}
				if (model.Rec == 0m)
				{
					this.lbMod.Text = "应收款为0，不能够进行对冲！";
					this.lbMod.Attributes.Add("class", "si2");
					this.btnSave.Enabled = false;
					this.btnAuto.Enabled = false;
				}
				if (model.Due == 0m)
				{
					this.lbMod.Text = "应付款为0，不能够进行对冲！";
					this.lbMod.Attributes.Add("class", "si2");
					this.btnSave.Enabled = false;
					this.btnAuto.Enabled = false;
				}
				this.hfCusID.Value = model.CustomerID.ToString();
				this.hfCusType.Value = model.CusType.ToString();
				this.GridViewSource.Clear();
				this.AddEmpty();
				DataTable gridViewSource = this.GridViewSource;
				DataTable dataTable = DALCommon.GetDataList("zk_cusarrearage", "", " DeptID=1 and Status=1 and NotChargeAmount>0 and Type='应收款' and CustomerID=" + this.hfCusID.Value + " and CusType=" + this.hfCusType.Value).Tables[0];
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					DataRow dataRow = gridViewSource.NewRow();
					dataRow[0] = int.Parse(dataTable.Rows[i]["ID"].ToString());
					dataRow[1] = dataTable.Rows[i]["RecType"].ToString();
					dataRow[2] = dataTable.Rows[i]["OperationID"].ToString();
					dataRow[3] = dataTable.Rows[i]["_Date"].ToString();
					dataRow[4] = dataTable.Rows[i]["_Name"].ToString();
					dataRow[5] = decimal.Parse(dataTable.Rows[i]["Amount"].ToString());
					dataRow[6] = decimal.Parse(dataTable.Rows[i]["HaveAmount"].ToString());
					dataRow[7] = decimal.Parse(dataTable.Rows[i]["NotChargeAmount"].ToString());
					dataRow[8] = 0;
					dataRow[9] = dataTable.Rows[i]["Remark"].ToString();
					gridViewSource.Rows.Add(dataRow);
				}
				this.GridViewSource = gridViewSource;
				this.BindData();
				this.GridViewSource2.Clear();
				this.AddEmpty2();
				DataTable gridViewSource2 = this.GridViewSource2;
				DataTable dataTable2 = DALCommon.GetDataList("zk_cusarrearage", "", " DeptID=1 and Status=1 and NotChargeAmount>0 and Type='应付款' and CustomerID=" + this.hfCusID.Value + " and CusType=" + this.hfCusType.Value).Tables[0];
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					DataRow dataRow2 = gridViewSource2.NewRow();
					dataRow2[0] = int.Parse(dataTable2.Rows[i]["ID"].ToString());
					dataRow2[1] = dataTable2.Rows[i]["RecType"].ToString();
					dataRow2[2] = dataTable2.Rows[i]["OperationID"].ToString();
					dataRow2[3] = dataTable2.Rows[i]["_Date"].ToString();
					dataRow2[4] = dataTable2.Rows[i]["_Name"].ToString();
					dataRow2[5] = decimal.Parse(dataTable2.Rows[i]["Amount"].ToString());
					dataRow2[6] = decimal.Parse(dataTable2.Rows[i]["HaveAmount"].ToString());
					dataRow2[7] = decimal.Parse(dataTable2.Rows[i]["NotChargeAmount"].ToString());
					dataRow2[8] = 0;
					dataRow2[9] = dataTable2.Rows[i]["Remark"].ToString();
					gridViewSource2.Rows.Add(dataRow2);
				}
				this.GridViewSource2 = gridViewSource2;
				this.BindData2();
			}
		}
	}

	private void AddEmpty()
	{
		DataTable gridViewSource = this.GridViewSource;
		DataRow dataRow = gridViewSource.NewRow();
		dataRow[0] = 0;
		dataRow[1] = "";
		dataRow[2] = "";
		dataRow[3] = "";
		dataRow[4] = "";
		dataRow[5] = 0;
		dataRow[6] = 0;
		dataRow[7] = 0;
		dataRow[8] = 0;
		dataRow[9] = "";
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
			TextBox textBox = this.gvdata.Rows[i].FindControl("tbChargeMoney") as TextBox;
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i]["ChargeAmount"] = textBox.Text;
		}
	}

	protected void gvdata_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		this.CollectData();
		this.GridViewSource.Rows[e.RowIndex].Delete();
		this.BindData();
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.Cells[0].Text == "0")
		{
			e.Row.Visible = false;
		}
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex);
			e.Row.Cells[1].Attributes.Add("style", "background:#ECE9D8;");
			e.Row.Cells[9].Attributes.Add("class", "tbbg");
		}
	}

	private void AddEmpty2()
	{
		DataTable gridViewSource = this.GridViewSource2;
		DataRow dataRow = gridViewSource.NewRow();
		dataRow[0] = 0;
		dataRow[1] = "";
		dataRow[2] = "";
		dataRow[3] = "";
		dataRow[4] = "";
		dataRow[5] = 0;
		dataRow[6] = 0;
		dataRow[7] = 0;
		dataRow[8] = 0;
		dataRow[9] = "";
		gridViewSource.Rows.Add(dataRow);
		this.GridViewSource2 = gridViewSource;
		this.BindData2();
	}

	private void BindData2()
	{
		this.gvdata2.DataSource = this.GridViewSource2;
		this.gvdata2.DataBind();
	}

	protected void CollectData2()
	{
		for (int i = 0; i < this.gvdata2.Rows.Count; i++)
		{
			TextBox textBox = this.gvdata2.Rows[i].FindControl("tbChargeMoney") as TextBox;
			DataTable gridViewSource = this.GridViewSource2;
			gridViewSource.Rows[i]["ChargeAmount"] = textBox.Text;
		}
	}

	protected void gvdata2_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		this.CollectData2();
		this.GridViewSource2.Rows[e.RowIndex].Delete();
		this.BindData2();
	}

	protected void gvdata2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.Cells[0].Text == "0")
		{
			e.Row.Visible = false;
		}
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex);
			e.Row.Cells[1].Attributes.Add("style", "background:#ECE9D8;");
			e.Row.Cells[9].Attributes.Add("class", "tbbg");
		}
	}

	protected void btnSltID_Click(object sender, EventArgs e)
	{
		string text = string.Empty;
		if (this.hfreclist.Value.EndsWith(","))
		{
			text = this.hfreclist.Value.Remove(this.hfreclist.Value.LastIndexOf(','));
		}
		else
		{
			text = this.hfreclist.Value;
		}
		if (text != string.Empty)
		{
			DataTable dataTable;
			if (this.hfType.Value == "1")
			{
				dataTable = this.GridViewSource;
			}
			else
			{
				dataTable = this.GridViewSource2;
			}
			DataTable dataTable2 = DALCommon.GetDataList("zk_cusarrearage", "", " [ID] in(" + text + ") ").Tables[0];
			if (dataTable2.Rows.Count > 0)
			{
				if (this.hfType.Value == "1")
				{
					this.CollectData();
				}
				else
				{
					this.CollectData2();
				}
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					bool flag = true;
					for (int j = 1; j < dataTable.Rows.Count; j++)
					{
						if (dataTable.Rows[j]["ID"].ToString() == dataTable2.Rows[i]["ID"].ToString())
						{
							flag = false;
						}
					}
					if (flag)
					{
						DataRow dataRow = dataTable.NewRow();
						dataRow[0] = int.Parse(dataTable2.Rows[i]["ID"].ToString());
						dataRow[1] = dataTable2.Rows[i]["RecType"].ToString();
						dataRow[2] = dataTable2.Rows[i]["OperationID"].ToString();
						dataRow[3] = dataTable2.Rows[i]["_Date"].ToString();
						dataRow[4] = dataTable2.Rows[i]["_Name"].ToString();
						dataRow[5] = decimal.Parse(dataTable2.Rows[i]["Amount"].ToString());
						dataRow[6] = decimal.Parse(dataTable2.Rows[i]["HaveAmount"].ToString());
						dataRow[7] = decimal.Parse(dataTable2.Rows[i]["NotChargeAmount"].ToString());
						dataRow[8] = 0;
						dataRow[9] = dataTable2.Rows[i]["Remark"].ToString();
						dataTable.Rows.Add(dataRow);
					}
				}
				if (this.hfType.Value == "1")
				{
					this.BindData();
				}
				else
				{
					this.BindData2();
				}
			}
		}
	}

	protected void btnAuto_Click(object sender, EventArgs e)
	{
		decimal num = 0m;
		decimal.TryParse(this.tbAmount.Text, out num);
		if (num == 0m)
		{
			this.SysInfo("window.alert('对冲金额为0，不能自动分配');");
		}
		else
		{
			this.CollectData();
			DataTable gridViewSource = this.GridViewSource;
			if (gridViewSource.Rows.Count == 1)
			{
				this.SysInfo("window.alert('操作失败！无应收明细，请添加！');");
			}
			else
			{
				this.CollectData2();
				DataTable gridViewSource2 = this.GridViewSource2;
				if (gridViewSource2.Rows.Count == 1)
				{
					this.SysInfo("window.alert('操作失败！无应付明细，请添加！');");
				}
				else
				{
					decimal num2 = 0m;
					for (int i = 0; i < gridViewSource.Rows.Count; i++)
					{
						decimal.TryParse(gridViewSource.Rows[i]["NotChargeAmount"].ToString(), out num2);
						if (num > 0m)
						{
							if (num > num2)
							{
								gridViewSource.Rows[i]["ChargeAmount"] = num2;
							}
							else
							{
								gridViewSource.Rows[i]["ChargeAmount"] = num;
							}
						}
						else
						{
							gridViewSource.Rows[i]["ChargeAmount"] = 0;
						}
						num -= num2;
					}
					this.BindData();
					decimal.TryParse(this.tbAmount.Text, out num);
					decimal num3 = 0m;
					for (int i = 0; i < gridViewSource2.Rows.Count; i++)
					{
						decimal.TryParse(gridViewSource2.Rows[i]["NotChargeAmount"].ToString(), out num3);
						if (num > 0m)
						{
							if (num > num3)
							{
								gridViewSource2.Rows[i]["ChargeAmount"] = num3;
							}
							else
							{
								gridViewSource2.Rows[i]["ChargeAmount"] = num;
							}
						}
						else
						{
							gridViewSource2.Rows[i]["ChargeAmount"] = 0;
						}
						num -= num3;
					}
					this.BindData2();
				}
			}
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		this.CollectData();
		DataTable gridViewSource = this.GridViewSource;
		if (gridViewSource.Rows.Count == 1)
		{
			this.SysInfo("window.alert('操作失败！无应收明细，请添加！');");
		}
		else
		{
			this.CollectData2();
			DataTable gridViewSource2 = this.GridViewSource2;
			if (gridViewSource2.Rows.Count == 1)
			{
				this.SysInfo("window.alert('操作失败！无应付明细，请添加！');");
			}
			else
			{
				decimal d = 0m;
				decimal d2 = 0m;
				decimal.TryParse(this.tbAmount.Text, out d2);
				decimal d3 = 0m;
				for (int i = 0; i < gridViewSource.Rows.Count; i++)
				{
					decimal.TryParse(gridViewSource.Rows[i]["ChargeAmount"].ToString(), out d3);
					d += d3;
				}
				if (d != d2)
				{
					this.SysInfo("window.alert('操作失败！本次对冲金额与单据明细不符，请修改！');");
				}
				else
				{
					decimal d4 = 0m;
					decimal d5 = 0m;
					decimal.TryParse(this.tbAmount.Text, out d5);
					decimal d6 = 0m;
					for (int i = 0; i < gridViewSource2.Rows.Count; i++)
					{
						decimal.TryParse(gridViewSource2.Rows[i]["ChargeAmount"].ToString(), out d6);
						d4 += d6;
					}
					if (d4 != d5)
					{
						this.SysInfo("window.alert('操作失败！本次对冲金额与单据明细不符，请修改！');");
					}
					else
					{
						string empty = string.Empty;
						DALArrearage dALArrearage = new DALArrearage();
						decimal dAmount = 0m;
						decimal.TryParse(this.tbAmount.Text, out dAmount);
						int iOperator = 0;
						int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
						int iTbid;
						int iTbid2;
						int num = dALArrearage.ManualHedge(this.id, dAmount, iOperator, int.Parse(this.ddlAccount.SelectedValue), out iTbid, out iTbid2, out empty);
						if (num == 0)
						{
							decimal num2 = 0m;
							for (int i = 0; i < gridViewSource.Rows.Count; i++)
							{
								decimal.TryParse(gridViewSource.Rows[i]["ChargeAmount"].ToString(), out num2);
								int iTbid3;
								int.TryParse(gridViewSource.Rows[i]["ID"].ToString(), out iTbid3);
								if (num2 > 0m)
								{
									num = dALArrearage.zk_sfk_yy_kd(iTbid, iTbid3, num2, out empty);
								}
							}
							for (int i = 0; i < gridViewSource2.Rows.Count; i++)
							{
								decimal.TryParse(gridViewSource2.Rows[i]["ChargeAmount"].ToString(), out num2);
								int iTbid3;
								int.TryParse(gridViewSource2.Rows[i]["ID"].ToString(), out iTbid3);
								if (num2 > 0m)
								{
									num = dALArrearage.zk_sfk_yy_kd(iTbid2, iTbid3, num2, out empty);
								}
							}
							this.SysInfo("window.alert('自动生成收付款单成功！');parent.CloseDialog('1');");
						}
						else
						{
							this.SysInfo("window.alert('" + empty + "');");
						}
					}
				}
			}
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
