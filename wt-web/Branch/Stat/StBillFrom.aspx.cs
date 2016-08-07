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

public partial class Branch_Stat_StBillFrom : Page, IRequiresSessionState
{


	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "tj_r28"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			this.ddlBranch.Items.Add(new ListItem((string)this.Session["Session_wtBranch"], (string)this.Session["Session_wtBranchID"]));
			this.tbDateB.Text = DateTime.Now.ToString("yyyy-MM-") + "01";
			this.tbDateE.Text = DateTime.Now.ToString("yyyy-MM-dd");
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
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
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void FillData(string sortExpression, string direction)
	{
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add(new DataColumn("��", typeof(int)));
		dataTable.Columns.Add(new DataColumn("��������", typeof(string)));
		dataTable.Columns.Add(new DataColumn("��ȷ��", typeof(string)));
		dataTable.Columns.Add(new DataColumn("������", typeof(string)));
		dataTable.Columns.Add(new DataColumn("������ȷ��", typeof(string)));
		dataTable.Columns.Add(new DataColumn("������", typeof(string)));
		dataTable.Columns.Add(new DataColumn("������", typeof(string)));
		dataTable.Columns.Add(new DataColumn("���ط�", typeof(string)));
		dataTable.Columns.Add(new DataColumn("�����", typeof(string)));
		dataTable.Columns.Add(new DataColumn("�ѽ���", typeof(string)));
		dataTable.Columns.Add(new DataColumn("��ȡ��", typeof(string)));
		dataTable.Columns.Add(new DataColumn("����", typeof(string)));
		for (int i = 0; i <= 1; i++)
		{
			DataRow dataRow = dataTable.NewRow();
			dataRow["��������"] = 0;
			dataRow["��ȷ��"] = 0;
			dataRow["������"] = 0;
			dataRow["������ȷ��"] = 0;
			dataRow["������"] = 0;
			dataRow["������"] = 0;
			dataRow["���ط�"] = 0;
			dataRow["�����"] = 0;
			dataRow["�ѽ���"] = 0;
			dataRow["��ȡ��"] = 0;
			dataRow["����"] = 0;
			dataRow["��"] = i + 1;
			dataTable.Rows.Add(dataRow);
		}
		string text = this.strParm();
		this.hfSql.Value = text;
		DataTable dataTable2 = DALCommon.GetDataList("ServicesList", "[Time_TakeOver],[Time_Over],[Time_Payee],[Time_BackSee],[Time_Close],[curStatus]", text).Tables[0];
		string columnName = string.Empty;
		if (dataTable2.Rows.Count > 0)
		{
			for (int i = 0; i < dataTable2.Rows.Count; i++)
			{
				dataTable.Rows[0]["��������"] = int.Parse(dataTable.Rows[0]["��������"].ToString()) + 1;
				columnName = dataTable2.Rows[i]["curStatus"].ToString();
				dataTable.Rows[0][columnName] = int.Parse(dataTable.Rows[0][columnName].ToString()) + 1;
			}
		}
		dataTable.Rows[1]["��������"] = "����(%)";
		float num = float.Parse(dataTable.Rows[0]["��������"].ToString());
		if (num != 0f)
		{
			if (dataTable.Rows[0]["��ȷ��"].ToString() != "0")
			{
				dataTable.Rows[1]["��ȷ��"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["��ȷ��"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["������"].ToString() != "0")
			{
				dataTable.Rows[1]["������"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["������"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["������ȷ��"].ToString() != "0")
			{
				dataTable.Rows[1]["������ȷ��"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["������ȷ��"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["������"].ToString() != "0")
			{
				dataTable.Rows[1]["������"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["������"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["������"].ToString() != "0")
			{
				dataTable.Rows[1]["������"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["������"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["���ط�"].ToString() != "0")
			{
				dataTable.Rows[1]["���ط�"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["���ط�"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["�����"].ToString() != "0")
			{
				dataTable.Rows[1]["�����"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["�����"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["�ѽ���"].ToString() != "0")
			{
				dataTable.Rows[1]["�ѽ���"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["�ѽ���"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["��ȡ��"].ToString() != "0")
			{
				dataTable.Rows[1]["��ȡ��"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["��ȡ��"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["����"].ToString() != "0")
			{
				dataTable.Rows[1]["����"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["����"].ToString()) / num).ToString("#00%");
			}
		}
		this.gvdata.DataSource = dataTable;
		this.gvdata.DataBind();
		this.hfTbTitle.Value = (this.hfTbField.Value = string.Empty);
		if (this.gvdata.Rows.Count > 0)
		{
			for (int i = 0; i < this.gvdata.HeaderRow.Cells.Count; i++)
			{
				string dataField = ((BoundField)this.gvdata.Columns[i]).DataField;
				string text2 = this.gvdata.HeaderRow.Cells[i].Text;
				if (this.hfTbTitle.Value == string.Empty)
				{
					this.hfTbTitle.Value = text2;
				}
				else
				{
					HiddenField expr_998 = this.hfTbTitle;
					expr_998.Value = expr_998.Value + "," + text2;
				}
				if (this.hfTbField.Value == string.Empty)
				{
					this.hfTbField.Value = dataField;
				}
				else
				{
					HiddenField expr_9E8 = this.hfTbField;
					expr_9E8.Value = expr_9E8.Value + "," + dataField;
				}
			}
		}
	}

	protected string strParm()
	{
		string str = " ID>0 ";
		if (this.ddlBranch.SelectedValue != "-1")
		{
			str = str + " and DisposalID=" + this.ddlBranch.SelectedValue;
		}
		if (this.tbDateB.Text.Trim() != string.Empty && this.tbDateE.Text.Trim() != string.Empty)
		{
			str = str + " and Time_TakeOver>='" + FunLibrary.ChkInput(this.tbDateB.Text) + "'";
			str = str + " and Time_TakeOver<='" + FunLibrary.ChkInput(this.tbDateE.Text) + " 23:59:59'";
		}
		return str + " order by ID Asc ";
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		string text = FunLibrary.ChkInput(this.tbDateB.Text);
		string text2 = FunLibrary.ChkInput(this.tbDateE.Text);
		string selectedValue = this.ddlBranch.SelectedValue;
		string text3 = string.Concat(new string[]
		{
			text,
			",",
			text2,
			",",
			selectedValue
		});
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Cells[0].Text = Convert.ToDouble(e.Row.RowIndex + 1).ToString();
			e.Row.Attributes.Add("id", text3);
			e.Row.Attributes.Add("onclick", "ChkID('" + text3 + "');");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[0].Attributes.Add("style", "width:20px;padding-right:0px;text-align:center;");
			e.Row.Attributes.Add("ondblclick", "ChkView();");
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		DataTable dataTable = new DataTable();
		dataTable.Columns.Add(new DataColumn("��", typeof(int)));
		dataTable.Columns.Add(new DataColumn("��������", typeof(string)));
		dataTable.Columns.Add(new DataColumn("��ȷ��", typeof(string)));
		dataTable.Columns.Add(new DataColumn("������", typeof(string)));
		dataTable.Columns.Add(new DataColumn("������ȷ��", typeof(string)));
		dataTable.Columns.Add(new DataColumn("������", typeof(string)));
		dataTable.Columns.Add(new DataColumn("������", typeof(string)));
		dataTable.Columns.Add(new DataColumn("���ط�", typeof(string)));
		dataTable.Columns.Add(new DataColumn("�����", typeof(string)));
		dataTable.Columns.Add(new DataColumn("�ѽ���", typeof(string)));
		dataTable.Columns.Add(new DataColumn("��ȡ��", typeof(string)));
		dataTable.Columns.Add(new DataColumn("����", typeof(string)));
		for (int i = 0; i <= 1; i++)
		{
			DataRow dataRow = dataTable.NewRow();
			dataRow["��������"] = 0;
			dataRow["��ȷ��"] = 0;
			dataRow["������"] = 0;
			dataRow["������ȷ��"] = 0;
			dataRow["������"] = 0;
			dataRow["������"] = 0;
			dataRow["���ط�"] = 0;
			dataRow["�����"] = 0;
			dataRow["�ѽ���"] = 0;
			dataRow["��ȡ��"] = 0;
			dataRow["����"] = 0;
			dataRow["��"] = i + 1;
			dataTable.Rows.Add(dataRow);
		}
		string text = this.strParm();
		this.hfSql.Value = text;
		DataTable dataTable2 = DALCommon.GetDataList("ServicesList", "[Time_TakeOver],[Time_Over],[Time_Payee],[Time_BackSee],[Time_Close],[curStatus]", text).Tables[0];
		string columnName = string.Empty;
		if (dataTable2.Rows.Count > 0)
		{
			for (int i = 0; i < dataTable2.Rows.Count; i++)
			{
				dataTable.Rows[0]["��������"] = int.Parse(dataTable.Rows[0]["��������"].ToString()) + 1;
				columnName = dataTable2.Rows[i]["curStatus"].ToString();
				dataTable.Rows[0][columnName] = int.Parse(dataTable.Rows[0][columnName].ToString()) + 1;
			}
		}
		dataTable.Rows[1]["��������"] = "����(%)";
		float num = float.Parse(dataTable.Rows[0]["��������"].ToString());
		if (num != 0f)
		{
			if (dataTable.Rows[0]["��ȷ��"].ToString() != "0")
			{
				dataTable.Rows[1]["��ȷ��"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["��ȷ��"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["������"].ToString() != "0")
			{
				dataTable.Rows[1]["������"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["������"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["������ȷ��"].ToString() != "0")
			{
				dataTable.Rows[1]["������ȷ��"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["������ȷ��"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["������"].ToString() != "0")
			{
				dataTable.Rows[1]["������"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["������"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["������"].ToString() != "0")
			{
				dataTable.Rows[1]["������"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["������"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["���ط�"].ToString() != "0")
			{
				dataTable.Rows[1]["���ط�"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["���ط�"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["�����"].ToString() != "0")
			{
				dataTable.Rows[1]["�����"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["�����"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["�ѽ���"].ToString() != "0")
			{
				dataTable.Rows[1]["�ѽ���"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["�ѽ���"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["��ȡ��"].ToString() != "0")
			{
				dataTable.Rows[1]["��ȡ��"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["��ȡ��"].ToString()) / num).ToString("#00%");
			}
			if (dataTable.Rows[0]["����"].ToString() != "0")
			{
				dataTable.Rows[1]["����"] = Convert.ToDouble(float.Parse(dataTable.Rows[0]["����"].ToString()) / num).ToString("#00%");
			}
		}
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dataTable, tbTitle, Guid.NewGuid().ToString() + ".xls", "BillFrom", out flag, out empty);
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
