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

public partial class Branch_BeginAccount_CusBeginArr : Page, IRequiresSessionState
{
	

	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("CusNO", typeof(string)));
				dataTable.Columns.Add(new DataColumn("_Name", typeof(string)));
				dataTable.Columns.Add(new DataColumn("LinkMan", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Tel", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Rec", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Due", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("CusID", typeof(int)));
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
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "qc_r2"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			this.AddEmpty();
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
		dataRow[4] = 0;
		dataRow[5] = 0;
		dataRow[6] = 0;
		gridViewSource.Rows.Add(dataRow);
		this.GridViewSource = gridViewSource;
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
			e.Row.Cells[1].Attributes.Add("style", "background:#ECE9D8;padding-right:10px;padding-right:10px;text-align:center;");
			e.Row.Cells[8].Attributes.Add("style", "padding-left:10px;padding-right:10px;text-align:center;");
			e.Row.Cells[6].Attributes.Add("class", "tbbg");
			e.Row.Cells[7].Attributes.Add("class", "tbbg");
		}
	}

	protected void btnSure_Click(object sender, EventArgs e)
	{
		string str = FunLibrary.ChkInput(this.tbCon.Text.Trim());
		DataTable gridViewSource = this.GridViewSource;
		DataTable dataTable = DALCommon.GetDataList("ks_customer", "", this.ddlSchFld.SelectedValue + "='" + str + "'").Tables[0];
		string text = "$('" + this.tbCon.ClientID + "').select();";
		if (dataTable.Rows.Count > 0)
		{
			this.CollectData();
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				bool flag = true;
				for (int j = 0; j < gridViewSource.Rows.Count; j++)
				{
					if (gridViewSource.Rows[j]["CusID"].ToString() == dataTable.Rows[i]["ID"].ToString())
					{
						flag = false;
					}
				}
				if (flag)
				{
					DataRow dataRow = gridViewSource.NewRow();
					dataRow[0] = dataTable.Rows[i]["CustomerNO"].ToString();
					dataRow[1] = dataTable.Rows[i]["_Name"].ToString();
					dataRow[2] = dataTable.Rows[i]["LinkMan"].ToString();
					dataRow[3] = dataTable.Rows[i]["Tel"].ToString();
					dataRow[4] = 0;
					dataRow[5] = 0;
					dataRow[6] = int.Parse(dataTable.Rows[i]["ID"].ToString());
					gridViewSource.Rows.Add(dataRow);
				}
			}
			this.BindData();
		}
		else
		{
			text += "window.alert('没有该客户信息！');";
		}
		this.SysInfo(text);
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
		DataTable gridViewSource = this.GridViewSource;
		if (text != string.Empty)
		{
			DataTable dataTable = DALCommon.GetDataList("ks_customer", "", " [ID] in(" + text + ") ").Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.CollectData();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					bool flag = true;
					for (int j = 1; j < gridViewSource.Rows.Count; j++)
					{
						if (gridViewSource.Rows[j]["CusID"].ToString() == dataTable.Rows[i]["ID"].ToString())
						{
							flag = false;
						}
					}
					if (flag)
					{
						DataRow dataRow = gridViewSource.NewRow();
						dataRow[0] = dataTable.Rows[i]["CustomerNO"].ToString();
						dataRow[1] = dataTable.Rows[i]["_Name"].ToString();
						dataRow[2] = dataTable.Rows[i]["LinkMan"].ToString();
						dataRow[3] = dataTable.Rows[i]["Tel"].ToString();
						dataRow[4] = 0;
						dataRow[5] = 0;
						dataRow[6] = int.Parse(dataTable.Rows[i]["ID"].ToString());
						gridViewSource.Rows.Add(dataRow);
					}
				}
				this.BindData();
			}
		}
		this.SysInfo("$('tbCon').focus();");
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
			TextBox textBox = this.gvdata.Rows[i].FindControl("tbRec") as TextBox;
			TextBox textBox2 = this.gvdata.Rows[i].FindControl("tbDue") as TextBox;
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i]["Rec"] = textBox.Text;
			gridViewSource.Rows[i]["Due"] = textBox2.Text;
		}
	}

	protected void gvdata_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		this.CollectData();
		this.GridViewSource.Rows[e.RowIndex].Delete();
		this.BindData();
	}

	protected void btnClean_Click(object sender, EventArgs e)
	{
		this.GridViewSource.Clear();
		this.AddEmpty();
	}

	protected void btnChk_Click(object sender, EventArgs e)
	{
		this.CollectData();
		if (this.GridViewSource.Rows.Count == 1)
		{
			ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "sysinfo", "window.alert('操作失败！请添加客户');$('" + this.tbCon.ClientID + "').select();", true);
		}
		else
		{
			BeginArrearageInfo beginArrearageInfo = new BeginArrearageInfo();
			DataTable gridViewSource = this.GridViewSource;
			if (gridViewSource.Rows.Count > 0)
			{
				List<BeginArrDetailInfo> list = new List<BeginArrDetailInfo>();
				for (int i = 0; i < gridViewSource.Rows.Count; i++)
				{
					if (decimal.Parse(gridViewSource.Rows[i]["Rec"].ToString()) > 0m || decimal.Parse(gridViewSource.Rows[i]["Due"].ToString()) > 0m)
					{
						list.Add(new BeginArrDetailInfo
						{
							DeptID = int.Parse((string)this.Session["Session_wtBranchID"]),
							CustomerID = int.Parse(gridViewSource.Rows[i]["CusID"].ToString()),
							CusType = 1,
							dRec = decimal.Parse(gridViewSource.Rows[i]["Rec"].ToString()),
							dDue = decimal.Parse(gridViewSource.Rows[i]["Due"].ToString())
						});
					}
				}
				beginArrearageInfo.BeginArrDetailInfos = list;
			}
			DALBeginArrearage dALBeginArrearage = new DALBeginArrearage();
			string empty = string.Empty;
			int iOperator = 0;
			int.TryParse((string)this.Session["Session_wtUserBID"], out iOperator);
			int num = dALBeginArrearage.Update(beginArrearageInfo, int.Parse((string)this.Session["Session_wtBranchID"]), 1, iOperator, out empty);
			if (num == 0)
			{
				this.SysInfo("window.alert('操作成功！期初客户应收应付已建立');");
				this.ClearText();
			}
			else
			{
				this.SysInfo("window.alert('" + empty + "');");
			}
		}
	}

	protected void ClearText()
	{
		this.GridViewSource.Clear();
		this.AddEmpty();
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
