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

public partial class Headquarters_Services_RepairRcvCal : Page, IRequiresSessionState
{

	private string id;

	private string type;

	private string corp;

	private int corpid;

	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("BillID", typeof(string)));
				dataTable.Columns.Add(new DataColumn("RepairSndDate", typeof(DateTime)));
				dataTable.Columns.Add(new DataColumn("Cost", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("ProductModel", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ProductSN1", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ProductBrand", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ProductClass", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));
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
		FunLibrary.ChkHead();
		this.id = base.Request["id"];
		if (this.id == null || this.id == string.Empty)
		{
			base.Response.End();
		}
		this.type = base.Request["type"];
		this.corp = base.Request["corp"];
		int.TryParse(base.Request["corpid"], out this.corpid);
		if (this.corpid == 0 || this.type == null || this.type == "" || this.corp == null || this.corp == "")
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "gd_r11"))
				{
					this.btnSave.Enabled = false;
				}
			}
			this.tbRepairType.Text = this.type;
			this.tbRepairCorp.Text = this.corp;
			this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
			this.tbRMoney.Text = "0.00";
			DataTable gridViewSource = this.GridViewSource;
			DataTable dataTable = DALCommon.GetDataList("fw_services", "", " [ID] in(" + this.id.TrimEnd(new char[]
			{
				','
			}) + ")").Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					DataRow dataRow = gridViewSource.NewRow();
					dataRow[0] = dataTable.Rows[i]["BillID"].ToString();
					dataRow[1] = dataTable.Rows[i]["RepairSndDate"].ToString();
					dataRow[2] = decimal.Parse(dataTable.Rows[i]["RepairCost"].ToString()).ToString("#0.00");
					dataRow[3] = dataTable.Rows[i]["ProductModel"].ToString();
					dataRow[4] = dataTable.Rows[i]["ProductSN1"].ToString();
					dataRow[5] = dataTable.Rows[i]["ProductBrand"].ToString();
					dataRow[6] = dataTable.Rows[i]["ProductClass"].ToString();
					dataRow[7] = dataTable.Rows[i]["Remark"].ToString();
					dataRow[8] = int.Parse(dataTable.Rows[i]["ID"].ToString());
					this.tbRMoney.Text = Convert.ToDouble(decimal.Parse(this.tbRMoney.Text) + decimal.Parse(dataTable.Rows[i]["RepairCost"].ToString())).ToString("#0.00");
					gridViewSource.Rows.Add(dataRow);
				}
				this.GridViewSource = gridViewSource;
				this.BindData();
			}
		}
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
			TextBox textBox = this.gvdata.Rows[i].FindControl("tbCost") as TextBox;
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i]["Cost"] = textBox.Text;
		}
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			TextBox textBox = e.Row.FindControl("tbCost") as TextBox;
			textBox.Attributes.Add("oldNum", textBox.Text);
			textBox.Attributes.Add("onblur", "ChkMoney(this);");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
			e.Row.Cells[1].Attributes.Add("style", "background:#ECE9D8;");
			e.Row.Cells[4].Attributes.Add("class", "tbbg");
		}
	}

	protected void btnAvg_Click(object sender, EventArgs e)
	{
		decimal d = 0m;
		decimal.TryParse(this.tbRMoney.Text, out d);
		if (d == 0m)
		{
			this.SysInfo("window.alert('维修费用为0，不能平均分配');$('tbRMoney').focus();");
		}
		else
		{
			this.CollectData();
			DataTable gridViewSource = this.GridViewSource;
			decimal num = d / gridViewSource.Rows.Count;
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				gridViewSource.Rows[i]["Cost"] = num;
			}
			this.BindData();
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		this.CollectData();
		DataTable gridViewSource = this.GridViewSource;
		decimal d = 0m;
		decimal d2 = 0m;
		decimal.TryParse(this.tbRMoney.Text, out d2);
		decimal d3 = 0m;
		for (int i = 0; i < gridViewSource.Rows.Count; i++)
		{
			decimal.TryParse(gridViewSource.Rows[i]["Cost"].ToString(), out d3);
			d += d3;
		}
		if (d != d2)
		{
			this.SysInfo("window.alert('操作失败！维修费用与单据明细不符，请修改！');");
		}
		else
		{
			DALServices dALServices = new DALServices();
			string strBillID = this.id.Replace("'", "");
			decimal num = 0m;
			decimal.TryParse(this.tbRMoney.Text, out num);
			int repairType = 2;
			if (this.type == "内部送修")
			{
				repairType = 3;
			}
			int num2 = 0;
			int iOperatorid = int.Parse((string)this.Session["Session_wtUserID"]);
			string text = this.tbDate.Text;
			string str = "";
			int num3 = dALServices.RepairRcvCal(1, iOperatorid, strBillID, repairType, this.corpid, text, num, out num2, out str);
			if (num3 == 0)
			{
				if (num > 0m)
				{
					decimal num4 = 0m;
					int iTbid = 0;
					for (int j = 0; j < gridViewSource.Rows.Count; j++)
					{
						decimal.TryParse(gridViewSource.Rows[j]["Cost"].ToString(), out num4);
						int.TryParse(gridViewSource.Rows[j]["ID"].ToString(), out iTbid);
						if (num4 > 0m)
						{
							if (num2 > 0)
							{
								dALServices.RepairRcvCalMX(1, iOperatorid, iTbid, repairType, this.corpid, text, num4, num2);
							}
						}
					}
				}
				this.SysInfo("parent.CloseDialog('2');window.alert('操作成功！送修物品已收货完成');");
			}
			else
			{
				this.SysInfo("parent.CloseDialog('2');window.alert('操作失败！" + str + "');");
			}
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
