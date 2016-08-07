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

public partial class Branch_Services_AddO : Page, IRequiresSessionState
{
	private int id;

	

	private DataTable GridViewSourceM
	{
		get
		{
			if (this.ViewState["ListM"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("_Name", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Total", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("bCusConf", typeof(bool)));
				dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ItemID", typeof(int)));
				this.ViewState["ListM"] = dataTable;
			}
			return (DataTable)this.ViewState["ListM"];
		}
		set
		{
			this.ViewState["ListM"] = value;
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
				if (!dALRight.GetRight(num, "gd_r18"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			this.AddEmptyM();
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=" + (string)this.Session["Session_wtBranchID"] + " and Status=0");
			string b = (string)this.Session["Session_wtUserB"];
			for (int i = 0; i < this.ddlOperator.Items.Count; i++)
			{
				if (this.ddlOperator.Items[i].Text == b)
				{
					this.ddlOperator.Items[i].Selected = true;
					break;
				}
			}
			this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
		}
	}

	private void AddEmptyM()
	{
		DataTable gridViewSourceM = this.GridViewSourceM;
		DataRow dataRow = gridViewSourceM.NewRow();
		dataRow[0] = "";
		dataRow[1] = 0;
		dataRow[2] = false;
		dataRow[3] = "";
		dataRow[4] = 0;
		gridViewSourceM.Rows.Add(dataRow);
		this.GridViewSourceM = gridViewSourceM;
		this.BindDataM();
	}

	protected void btnSure_Click(object sender, EventArgs e)
	{
		string text = FunLibrary.ChkInput(this.tbConInfo.Text);
		DataTable gridViewSourceM = this.GridViewSourceM;
		if (text != "")
		{
			DataTable dataTable = DALCommon.GetDataList("OfferItem", "", " _Name='" + text + "'").Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.CollectDataM();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					bool flag = true;
					for (int j = 1; j < gridViewSourceM.Rows.Count; j++)
					{
						if (gridViewSourceM.Rows[j]["ItemID"].ToString() == dataTable.Rows[i]["ID"].ToString())
						{
							flag = false;
						}
					}
					if (flag)
					{
						DataRow dataRow = gridViewSourceM.NewRow();
						dataRow[0] = dataTable.Rows[i]["_Name"].ToString();
						dataRow[1] = 0;
						dataRow[2] = false;
						dataRow[3] = "";
						dataRow[4] = int.Parse(dataTable.Rows[i]["ID"].ToString());
						gridViewSourceM.Rows.Add(dataRow);
					}
				}
				this.BindDataM();
			}
			else
			{
				this.SysInfo("window.alert('不存在该报价项目');$('tbConInfo').focus();");
			}
		}
	}

	protected void btnId_Click(object sender, EventArgs e)
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
		DataTable gridViewSourceM = this.GridViewSourceM;
		if (text != string.Empty)
		{
			DataTable dataTable = DALCommon.GetDataList("OfferItem", "", " [ID] in(" + text + ") ").Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.CollectDataM();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					bool flag = true;
					for (int j = 1; j < gridViewSourceM.Rows.Count; j++)
					{
						if (gridViewSourceM.Rows[j]["ItemID"].ToString() == dataTable.Rows[i]["ID"].ToString())
						{
							flag = false;
						}
					}
					if (flag)
					{
						DataRow dataRow = gridViewSourceM.NewRow();
						dataRow[0] = dataTable.Rows[i]["_Name"].ToString();
						dataRow[1] = 0;
						dataRow[2] = false;
						dataRow[3] = "";
						dataRow[4] = int.Parse(dataTable.Rows[i]["ID"].ToString());
						gridViewSourceM.Rows.Add(dataRow);
					}
				}
				this.BindDataM();
			}
		}
		this.SysInfo("$('tbConInfo').focus();");
	}

	protected void CollectDataM()
	{
		for (int i = 0; i < this.GridView2.Rows.Count; i++)
		{
			TextBox textBox = this.GridView2.Rows[i].FindControl("tbPrice") as TextBox;
			TextBox textBox2 = this.GridView2.Rows[i].FindControl("tbRemark") as TextBox;
			CheckBox checkBox = this.GridView2.Rows[i].FindControl("cbCusConf") as CheckBox;
			DataTable gridViewSourceM = this.GridViewSourceM;
			gridViewSourceM.Rows[i]["Total"] = textBox.Text;
			gridViewSourceM.Rows[i]["Remark"] = FunLibrary.ChkInput(textBox2.Text);
			gridViewSourceM.Rows[i]["bCusConf"] = checkBox.Checked;
		}
	}

	protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		this.CollectDataM();
		this.GridViewSourceM.Rows[e.RowIndex].Delete();
		this.BindDataM();
	}

	private void BindDataM()
	{
		this.GridView2.DataSource = this.GridViewSourceM;
		this.GridView2.DataBind();
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
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
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALServices dALServices = new DALServices();
		ServicesInfo servicesInfo = new ServicesInfo();
		servicesInfo.ID = this.id;
		string str = "";
		this.CollectDataM();
		DataTable gridViewSourceM = this.GridViewSourceM;
		int operatorID = 0;
		int.TryParse((string)this.Session["Session_wtUserBID"], out operatorID);
		if (gridViewSourceM.Rows.Count > 0)
		{
			List<ServiceOfferInfo> list = new List<ServiceOfferInfo>();
			for (int i = 0; i < gridViewSourceM.Rows.Count; i++)
			{
				if (int.Parse(gridViewSourceM.Rows[i]["ItemID"].ToString()) > 0)
				{
					list.Add(new ServiceOfferInfo
					{
						OperatorID = operatorID,
						SellerID = int.Parse(this.ddlOperator.SelectedValue),
						_Date = this.tbDate.Text,
						ItemID = int.Parse(gridViewSourceM.Rows[i]["ItemID"].ToString()),
						bCusConf = bool.Parse(gridViewSourceM.Rows[i]["bCusConf"].ToString()),
						dAmount = decimal.Parse(gridViewSourceM.Rows[i]["Total"].ToString()),
						Remark = gridViewSourceM.Rows[i]["Remark"].ToString()
					});
				}
			}
			servicesInfo.ServiceOfferInfos = list;
		}
		List<string[]> list2 = new List<string[]>();
		if (this.hfdellist1.Value != string.Empty)
		{
			list2.Add(new string[]
			{
				"ServiceOffer",
				this.hfdellist1.Value
			});
		}
		int num = dALServices.UpdateAddO(servicesInfo, list2, out str);
		if (num == 0)
		{
			this.SysInfo("window.alert('操作成功！服务报价已保存');parent.CloseDialog('1');");
		}
		else
		{
			this.SysInfo("window.alert('" + str + "');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
