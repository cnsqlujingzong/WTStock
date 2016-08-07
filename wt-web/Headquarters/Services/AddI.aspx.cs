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
using wt.DB;
using wt.Library;
using wt.Model;

public partial class Headquarters_Services_AddI : Page, IRequiresSessionState
{

	private int id;

	private int purid = 0;

	private bool isSepRepair = false;

	private DataTable GridViewSourceI
	{
		get
		{
			if (this.ViewState["ListI"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("ItemNO", typeof(string)));
				dataTable.Columns.Add(new DataColumn("_Name", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Price", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("dPoint", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Tec", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ChargeStyle", typeof(string)));
				dataTable.Columns.Add(new DataColumn("TecDeduct", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ItemID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("RecID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("iFlag", typeof(int)));
				dataTable.Columns.Add(new DataColumn("bComplete", typeof(bool)));
				this.ViewState["ListI"] = dataTable;
			}
			return (DataTable)this.ViewState["ListI"];
		}
		set
		{
			this.ViewState["ListI"] = value;
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
		int supID = new DALServices().GetSupID(this.id);
		if (supID != 0)
		{
			SupplierListInfo model = new DALSupplierList().GetModel(supID);
			if (model != null)
			{
				this.isSepRepair = model.bChargeCorp;
			}
		}
		if (!base.IsPostBack)
		{
			DALRight dALRight = new DALRight();
			this.purid = int.Parse((string)this.Session["Session_wtPurID"]);
			if (this.purid > 0)
			{
				if (!dALRight.GetRight(this.purid, "gd_r9"))
				{
					this.btnAdd.Enabled = false;
				}
				if (dALRight.GetRight(this.purid, "gd_r26"))
				{
					this.hfmoddet.Value = "1";
				}
			}
			this.AddEmptyI();
			DataTable dataTable = DALCommon.GetDataList("fw_servicesitem", "", " [BillID]=" + this.id.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				DataTable gridViewSourceI = this.GridViewSourceI;
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					DataRow dataRow = gridViewSourceI.NewRow();
					dataRow[0] = dataTable.Rows[i]["ItemNO"].ToString();
					dataRow[1] = dataTable.Rows[i]["_Name"].ToString();
					dataRow[2] = decimal.Parse(dataTable.Rows[i]["Price"].ToString());
					if (this.purid > 0)
					{
						if (dALRight.GetRight(this.purid, "gd_r31"))
						{
							dataRow[2] = 0;
						}
					}
					dataRow[3] = decimal.Parse(dataTable.Rows[i]["dPoint"].ToString());
					dataRow[4] = dataTable.Rows[i]["Tec"].ToString();
					dataRow[5] = dataTable.Rows[i]["ChargeStyle"].ToString();
					dataRow[6] = decimal.Parse(dataTable.Rows[i]["TecDeduct"].ToString());
					dataRow[7] = dataTable.Rows[i]["Remark"].ToString();
					dataRow[8] = int.Parse(dataTable.Rows[i]["ItemID"].ToString());
					dataRow[9] = int.Parse(dataTable.Rows[i]["ID"].ToString());
					dataRow[10] = 1;
					if (dataTable.Rows[i]["bComplete"].ToString() == "")
					{
						dataRow[11] = false;
					}
					else
					{
						dataRow[11] = true;
					}
					gridViewSourceI.Rows.Add(dataRow);
				}
				this.GridViewSourceI = gridViewSourceI;
				this.BindDataI();
			}
		}
	}

	private void AddEmptyI()
	{
		DataTable gridViewSourceI = this.GridViewSourceI;
		DataRow dataRow = gridViewSourceI.NewRow();
		dataRow[0] = "";
		dataRow[1] = "";
		dataRow[2] = 0;
		dataRow[3] = 0;
		dataRow[4] = "";
		dataRow[5] = "";
		dataRow[6] = 0;
		dataRow[7] = "";
		dataRow[8] = 0;
		dataRow[9] = 0;
		dataRow[10] = 0;
		dataRow[11] = false;
		gridViewSourceI.Rows.Add(dataRow);
		this.GridViewSourceI = gridViewSourceI;
		this.BindDataI();
	}

	protected void btnSure2_Click(object sender, EventArgs e)
	{
		string str = FunLibrary.ChkInput(this.tbConInfo2.Text.Trim());
		DataTable gridViewSourceI = this.GridViewSourceI;
		DataTable dataTable = DALCommon.GetDataList("ServicesItemList", "", this.ddlSchFld2.SelectedValue + "='" + str + "'").Tables[0];
		string text = "$('" + this.tbConInfo2.ClientID + "').select();";
		if (dataTable.Rows.Count > 0)
		{
			this.CollectDataI();
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				bool flag = true;
				for (int j = 0; j < gridViewSourceI.Rows.Count; j++)
				{
					if (gridViewSourceI.Rows[j]["ItemID"].ToString() == dataTable.Rows[i]["ID"].ToString())
					{
						flag = false;
					}
				}
				if (flag)
				{
					DataRow dataRow = gridViewSourceI.NewRow();
					dataRow[0] = dataTable.Rows[i]["ItemNO"].ToString();
					dataRow[1] = dataTable.Rows[i]["_Name"].ToString();
					dataRow[2] = decimal.Parse(dataTable.Rows[i]["Price"].ToString());
					dataRow[3] = 0;
					dataRow[4] = "";
					dataRow[5] = "客付";
					dataRow[6] = decimal.Parse(dataTable.Rows[i]["TecDeduct"].ToString());
					dataRow[7] = "";
					dataRow[8] = int.Parse(dataTable.Rows[i]["ID"].ToString());
					dataRow[9] = 0;
					dataRow[10] = 0;
					dataRow[11] = false;
					gridViewSourceI.Rows.Add(dataRow);
				}
			}
			this.BindDataI();
		}
		else
		{
			text += "window.alert('操作失败！没有该服务项目');";
		}
		this.SysInfo(text);
	}

	protected void btnId2_Click(object sender, EventArgs e)
	{
		string text = string.Empty;
		if (this.hfreclist2.Value.EndsWith(","))
		{
			text = this.hfreclist2.Value.Remove(this.hfreclist2.Value.LastIndexOf(','));
		}
		else
		{
			text = this.hfreclist2.Value;
		}
		DataTable gridViewSourceI = this.GridViewSourceI;
		if (text != string.Empty)
		{
			DataTable dataTable = DALCommon.GetDataList("ServicesItemList", "", " [ID] in(" + text + ") ").Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.CollectDataI();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					bool flag = true;
					for (int j = 1; j < gridViewSourceI.Rows.Count; j++)
					{
						if (gridViewSourceI.Rows[j]["ItemID"].ToString() == dataTable.Rows[i]["ID"].ToString())
						{
							flag = false;
						}
					}
					if (flag)
					{
						DataRow dataRow = gridViewSourceI.NewRow();
						dataRow[0] = dataTable.Rows[i]["ItemNO"].ToString();
						dataRow[1] = dataTable.Rows[i]["_Name"].ToString();
						if (this.isSepRepair)
						{
							dataRow[2] = decimal.Parse(dataTable.Rows[i]["WarrantyPrice"].ToString());
						}
						else
						{
							dataRow[2] = decimal.Parse(dataTable.Rows[i]["Price"].ToString());
						}
						dataRow[3] = 0;
						dataRow[4] = "";
						dataRow[5] = "客付";
						dataRow[6] = decimal.Parse(dataTable.Rows[i]["TecDeduct"].ToString());
						dataRow[7] = "";
						dataRow[8] = int.Parse(dataTable.Rows[i]["ID"].ToString());
						dataRow[9] = 0;
						dataRow[10] = 0;
						dataRow[11] = false;
						gridViewSourceI.Rows.Add(dataRow);
					}
				}
				this.BindDataI();
			}
		}
		this.SysInfo("$('tbConInfo2').focus();");
	}

	protected void CollectDataI()
	{
		for (int i = 0; i < this.GridView2.Rows.Count; i++)
		{
			TextBox textBox = this.GridView2.Rows[i].FindControl("tbPrice") as TextBox;
			TextBox textBox2 = this.GridView2.Rows[i].FindControl("tbRemark") as TextBox;
			TextBox textBox3 = this.GridView2.Rows[i].FindControl("tbdPoint") as TextBox;
			TextBox textBox4 = this.GridView2.Rows[i].FindControl("tbTecDeduct") as TextBox;
			TextBox textBox5 = this.GridView2.Rows[i].FindControl("tbTec") as TextBox;
			CheckBox checkBox = this.GridView2.Rows[i].FindControl("cbbComplete") as CheckBox;
			DropDownList dropDownList = this.GridView2.Rows[i].FindControl("ddlChargeStyle") as DropDownList;
			DataTable gridViewSourceI = this.GridViewSourceI;
			gridViewSourceI.Rows[i]["Price"] = textBox.Text;
			gridViewSourceI.Rows[i]["dPoint"] = textBox3.Text;
			gridViewSourceI.Rows[i]["Remark"] = FunLibrary.ChkInput(textBox2.Text);
			gridViewSourceI.Rows[i]["TecDeduct"] = textBox4.Text;
			gridViewSourceI.Rows[i]["Tec"] = FunLibrary.ChkInput(textBox5.Text);
			gridViewSourceI.Rows[i]["ChargeStyle"] = dropDownList.SelectedItem.Text;
			gridViewSourceI.Rows[i]["bComplete"] = checkBox.Checked;
		}
	}

	protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		this.CollectDataI();
		DataTable gridViewSourceI = this.GridViewSourceI;
		for (int i = 0; i < gridViewSourceI.Rows.Count; i++)
		{
			if (i == e.RowIndex)
			{
				if (int.Parse(gridViewSourceI.Rows[i]["iFlag"].ToString()) == 1)
				{
					if (this.hfdellist2.Value == string.Empty)
					{
						this.hfdellist2.Value = gridViewSourceI.Rows[i]["RecID"].ToString();
					}
					else
					{
						HiddenField expr_AA = this.hfdellist2;
						expr_AA.Value = expr_AA.Value + "," + gridViewSourceI.Rows[i]["RecID"].ToString();
					}
				}
			}
		}
		this.GridViewSourceI.Rows[e.RowIndex].Delete();
		this.BindDataI();
	}

	private void BindDataI()
	{
		this.GridView2.DataSource = this.GridViewSourceI;
		this.GridView2.DataBind();
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.Cells[0].Text == "0")
		{
			e.Row.Visible = false;
		}
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[7].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			TextBox textBox = e.Row.FindControl("tbChargeStyle") as TextBox;
			TextBox textBox2 = e.Row.FindControl("tbTec") as TextBox;
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex);
			HtmlInputButton htmlInputButton = e.Row.FindControl("btnsch") as HtmlInputButton;
			htmlInputButton.Attributes.Add("onclick", "SltTec('" + textBox2.ClientID + "');");
			DropDownList dropDownList = e.Row.FindControl("ddlChargeStyle") as DropDownList;
			dropDownList.Items.Add(new ListItem("客付", "客付"));
			dropDownList.Items.Add(new ListItem("厂付", "厂付"));
			dropDownList.Items.Add(new ListItem("免费", "免费"));
			for (int i = 0; i < dropDownList.Items.Count; i++)
			{
				if (dropDownList.Items[i].Text == textBox.Text)
				{
					dropDownList.Items[i].Selected = true;
					break;
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALRight dALRight = new DALRight();
		this.purid = int.Parse((string)this.Session["Session_wtPurID"]);
		if (this.purid > 0)
		{
			if (dALRight.GetRight(this.purid, "gd_r31"))
			{
				this.SysInfo("window.alert('保存失败，权限不足，请取消《禁止查看项目金额》之后再操作');");
				return;
			}
		}
		DALServices dALServices = new DALServices();
		ServicesInfo servicesInfo = new ServicesInfo();
		servicesInfo.ID = this.id;
		this.CollectDataI();
		DataTable gridViewSourceI = this.GridViewSourceI;
		if (gridViewSourceI.Rows.Count > 0)
		{
			List<ServicesItemInfo> list = new List<ServicesItemInfo>();
			for (int i = 0; i < gridViewSourceI.Rows.Count; i++)
			{
				if (int.Parse(gridViewSourceI.Rows[i]["ItemID"].ToString()) > 0)
				{
					list.Add(new ServicesItemInfo
					{
						ID = int.Parse(gridViewSourceI.Rows[i]["RecID"].ToString()),
						ItemID = int.Parse(gridViewSourceI.Rows[i]["ItemID"].ToString()),
						TecDeduct = decimal.Parse(gridViewSourceI.Rows[i]["TecDeduct"].ToString()),
						Price = decimal.Parse(gridViewSourceI.Rows[i]["Price"].ToString()),
						dPoint = decimal.Parse(gridViewSourceI.Rows[i]["dPoint"].ToString()),
						Tec = gridViewSourceI.Rows[i]["Tec"].ToString(),
						ChargeStyle = gridViewSourceI.Rows[i]["ChargeStyle"].ToString(),
						Remark = gridViewSourceI.Rows[i]["Remark"].ToString(),
						bComplete = bool.Parse(gridViewSourceI.Rows[i]["bComplete"].ToString())
					});
				}
			}
			servicesInfo.ServicesItemInfos = list;
		}
		List<string[]> list2 = new List<string[]>();
		if (this.hfdellist2.Value != string.Empty)
		{
			list2.Add(new string[]
			{
				"ServicesItem",
				this.hfdellist2.Value
			});
		}
		string str;
		int num = dALServices.UpdateAddI(servicesInfo, list2, out str);
		if (num == 0)
		{
			DbHelperSQL.InsertErrorLogs(2, int.Parse((string)this.Session["Session_wtUserID"]), this.id, "添加服务项目", 0);
			this.SysInfo("window.alert('操作成功！服务项目已保存');parent.CloseDialog('1');");
		}
		else
		{
			this.SysInfo("window.alert(\"" + str + "\");");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}

	public string strFocus()
	{
		string result;
		if (this.hfmoddet.Value == "1")
		{
			result = "blur();";
		}
		else
		{
			result = "select();";
		}
		return result;
	}
}
