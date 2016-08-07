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
using wt.Model;
using wt.OtherLibrary;

public partial class Branch_Stock_AllocateSignConf : Page, IRequiresSessionState
{

	private int id;
    

	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("GoodsNO", typeof(string)));
				dataTable.Columns.Add(new DataColumn("_Name", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Spec", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ProductBrand", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Unit", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Qty", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("SndQty", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("RecQty", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Price", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Total", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("MainTenancePeriod", typeof(string)));
				dataTable.Columns.Add(new DataColumn("SN", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));
				dataTable.Columns.Add(new DataColumn("GoodsID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("UnitID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("ID", typeof(int)));
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
		FunLibrary.ChkBran();
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "ck_r37"))
				{
					this.btnAdd.Enabled = false;
				}
				if (!dALRight.GetRight(num, "ck_r40"))
				{
					this.btnPrint.Visible = false;
				}
			}
			OtherFunction.BindBranch(this.ddlBranch);
			this.ddlBranch.Items.Insert(0, new ListItem("", "-1"));
			this.tbRecDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
			OtherFunction.BindStocks(this.ddlInStock, " DeptID=" + (string)this.Session["Session_wtBranchID"] + " and bStop=0 ");
			DALAllocate dALAllocate = new DALAllocate();
			AllocateInfo model = dALAllocate.GetModel(this.id);
			if (model != null)
			{
				this.hfPrintID.Value = this.id.ToString();
				OtherFunction.BindStaff(this.ddlOperator, " ID=" + model.PersonID.ToString());
				this.tbBillID.Text = model.BillID;
				this.tbDate.Text = model._Date;
				for (int i = 0; i < this.ddlOperator.Items.Count; i++)
				{
					if (this.ddlOperator.Items[i].Value == model.PersonID.ToString())
					{
						this.ddlOperator.Items[i].Selected = true;
						break;
					}
				}
				for (int i = 0; i < this.ddlBranch.Items.Count; i++)
				{
					if (this.ddlBranch.Items[i].Value == model.ToDept.ToString())
					{
						this.ddlBranch.Items[i].Selected = true;
						break;
					}
				}
				OtherFunction.BindStocks(this.ddlStock, " [ID]=" + model.StockID.ToString());
				this.ddlStock.Items.Remove(new ListItem("", "-1"));
				for (int i = 0; i < this.ddlStock.Items.Count; i++)
				{
					if (this.ddlStock.Items[i].Value == model.StockID.ToString())
					{
						this.ddlStock.Items[i].Selected = true;
						break;
					}
				}
				this.tbRemark.Text = model.Remark;
				this.tbInCash.Text = (this.tbAmount.Text = "0.00");
				DataTable gridViewSource = this.GridViewSource;
				DataTable dataTable = DALCommon.GetDataList("ck_allocatedetail", "", " BillID=" + this.id.ToString()).Tables[0];
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					DataRow dataRow = gridViewSource.NewRow();
					dataRow[0] = dataTable.Rows[i]["GoodsNO"].ToString();
					dataRow[1] = dataTable.Rows[i]["_Name"].ToString();
					dataRow[2] = dataTable.Rows[i]["Spec"].ToString();
					dataRow[3] = dataTable.Rows[i]["ProductBrand"].ToString();
					dataRow[4] = dataTable.Rows[i]["Unit"].ToString();
					dataRow[5] = decimal.Parse(dataTable.Rows[i]["AppQty"].ToString()).ToString("#0.00");
					dataRow[6] = decimal.Parse(dataTable.Rows[i]["SndQty"].ToString()).ToString("#0.00");
					dataRow[7] = decimal.Parse(dataTable.Rows[i]["SndQty"].ToString()).ToString("#0.00");
					dataRow[8] = decimal.Parse(dataTable.Rows[i]["Price"].ToString()).ToString("#0.00");
					dataRow[9] = decimal.Parse(dataTable.Rows[i]["Totals"].ToString()).ToString("#0.00");
					dataRow[10] = dataTable.Rows[i]["MainTenancePeriod"].ToString();
					dataRow[11] = dataTable.Rows[i]["SN"].ToString();
					dataRow[12] = dataTable.Rows[i]["Remark"].ToString();
					dataRow[13] = int.Parse(dataTable.Rows[i]["GoodsID"].ToString());
					dataRow[14] = int.Parse(dataTable.Rows[i]["UnitID"].ToString());
					dataRow[15] = int.Parse(dataTable.Rows[i]["ID"].ToString());
					this.tbAmount.Text = Convert.ToDouble(decimal.Parse(this.tbAmount.Text) + decimal.Parse(dataTable.Rows[i]["Totals"].ToString())).ToString("#0.00");
					gridViewSource.Rows.Add(dataRow);
				}
				this.GridViewSource = gridViewSource;
				this.BindData();
			}
		}
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = (e.Row.Cells[1].Visible = false);
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			TextBox textBox = e.Row.FindControl("tbQty") as TextBox;
			TextBox textBox2 = e.Row.FindControl("tbPrice") as TextBox;
			Label label = e.Row.FindControl("lbAmount") as Label;
			TextBox textBox3 = e.Row.FindControl("tbSN") as TextBox;
			textBox.Attributes.Add("oldNum", textBox.Text);
			textBox2.Attributes.Add("oldNum", textBox2.Text);
			label.Attributes.Add("oldNum", label.Text);
			textBox.Attributes.Add("onchange", string.Concat(new string[]
			{
				"ValidateNumd(this,'",
				textBox2.ClientID,
				"','",
				label.ClientID,
				"');"
			}));
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[2].Text = Convert.ToString(e.Row.RowIndex + 1);
			e.Row.Cells[10].Attributes.Add("class", "tbbg1");
			e.Row.Cells[10].Attributes.Add("class", "tbbg");
			e.Row.Cells[12].Attributes.Add("class", "tbbg");
			e.Row.Cells[15].Attributes.Add("class", "tbbg");
			e.Row.Cells[11].Text = string.Concat(new string[]
			{
				"<a href=\"#\" onclick=\"EditSN('",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"','",
				textBox3.ClientID,
				"','",
				textBox.ClientID,
				"');\">±‡º≠–Ú¡–∫≈</a>"
			});
		}
	}

	private void BindData()
	{
		this.gvdata.DataSource = this.GridViewSource;
		this.gvdata.DataBind();
	}

	protected void CollectData()
	{
		decimal d = 0m;
		for (int i = 0; i < this.gvdata.Rows.Count; i++)
		{
			TextBox textBox = this.gvdata.Rows[i].FindControl("tbQty") as TextBox;
			TextBox textBox2 = this.gvdata.Rows[i].FindControl("tbSN") as TextBox;
			TextBox textBox3 = this.gvdata.Rows[i].FindControl("tbPrice") as TextBox;
			TextBox textBox4 = this.gvdata.Rows[i].FindControl("tbRemark") as TextBox;
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i]["RecQty"] = textBox.Text;
			gridViewSource.Rows[i]["SN"] = textBox2.Text;
			gridViewSource.Rows[i]["Price"] = textBox3.Text;
			gridViewSource.Rows[i]["Total"] = Convert.ToDouble(decimal.Parse(textBox.Text) * decimal.Parse(textBox3.Text)).ToString("#0.00");
			gridViewSource.Rows[i]["Remark"] = FunLibrary.ChkInput(textBox4.Text);
			d += decimal.Parse(textBox.Text) * decimal.Parse(textBox3.Text);
		}
		this.tbAmount.Text = d.ToString("#0.00");
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		this.CollectData();
		this.BindData();
		string str;
		int num = this.BillUpdate(out str);
		if (num == 0)
		{
			DALAllocate dALAllocate = new DALAllocate();
			int iOperator = 0;
			int.TryParse((string)this.Session["Session_wtUserBID"], out iOperator);
			decimal dXFJE = 0m;
			decimal.TryParse(this.tbInCash.Text, out dXFJE);
			num = dALAllocate.ChkAllocateSign(this.id, iOperator, this.tbRecDate.Text, int.Parse(this.ddlInStock.SelectedValue), dXFJE, out str);
			if (num == 0)
			{
				this.SysInfo("window.alert('" + str + "');parent.CloseDialog('2');");
			}
			else
			{
				this.SysInfo("window.alert('" + str + "');");
			}
		}
		else
		{
			this.SysInfo("window.alert('≤Ÿ◊˜ ß∞‹£°" + str + "');");
		}
	}

	protected int BillUpdate(out string strMsg)
	{
		AllocateInfo allocateInfo = new AllocateInfo();
		allocateInfo.ID = this.id;
		allocateInfo.StockID = new int?(int.Parse(this.ddlStock.SelectedValue));
		allocateInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		DataTable gridViewSource = this.GridViewSource;
		if (gridViewSource.Rows.Count > 0)
		{
			List<AllocateDetailInfo> list = new List<AllocateDetailInfo>();
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				if (int.Parse(gridViewSource.Rows[i]["GoodsID"].ToString()) > 0)
				{
					list.Add(new AllocateDetailInfo
					{
						ID = int.Parse(gridViewSource.Rows[i]["ID"].ToString()),
						SndQty = new decimal?(decimal.Parse(gridViewSource.Rows[i]["SndQty"].ToString())),
						RecQty = new decimal?(decimal.Parse(gridViewSource.Rows[i]["RecQty"].ToString())),
						AppQty = new decimal?(decimal.Parse(gridViewSource.Rows[i]["Qty"].ToString())),
						Price = new decimal?(decimal.Parse(gridViewSource.Rows[i]["Price"].ToString())),
						Remark = gridViewSource.Rows[i]["Remark"].ToString(),
						SN = gridViewSource.Rows[i]["SN"].ToString()
					});
				}
			}
			allocateInfo.AllocateDetailInfos = list;
		}
		List<string[]> strdellist = new List<string[]>();
		DALAllocate dALAllocate = new DALAllocate();
		return dALAllocate.Update(allocateInfo, strdellist, out strMsg);
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
