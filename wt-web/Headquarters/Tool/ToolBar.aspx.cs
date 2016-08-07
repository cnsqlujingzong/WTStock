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

public partial class Headquarters_Tool_ToolBar : Page, IRequiresSessionState
{

	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("Img", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Oper", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Array", typeof(int)));
				dataTable.Columns.Add(new DataColumn("Comm", typeof(string)));
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
		if (!base.IsPostBack)
		{
			this.gvdata.DataSource = DALCommon.GetDataList("ToolBar", "", " DeptID=1 and iOperator is null order by Array asc");
			this.gvdata.DataBind();
			int num = int.Parse((string)this.Session["Session_wtUserID"]);
			DataTable dataTable = DALCommon.GetDataList("ToolBar", "", " DeptID=1 and iOperator=" + num + " order by Array asc").Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				DataTable gridViewSource = this.GridViewSource;
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					DataRow dataRow = gridViewSource.NewRow();
					dataRow[0] = dataTable.Rows[i]["FieldValue"].ToString();
					dataRow[1] = dataTable.Rows[i]["FieldText"].ToString();
					dataRow[2] = dataTable.Rows[i]["Array"].ToString();
					dataRow[3] = dataTable.Rows[i]["Command"].ToString();
					dataRow[4] = int.Parse(dataTable.Rows[i]["ID"].ToString());
					gridViewSource.Rows.Add(dataRow);
				}
				this.BindData();
			}
		}
	}

	protected void btnGo_Click(object sender, EventArgs e)
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
		if (text == "")
		{
			text = this.hfRecID.Value;
		}
		if (!(text == "") && !(text == "-1"))
		{
			DataTable gridViewSource = this.GridViewSource;
			if (gridViewSource.Rows.Count > 16)
			{
				this.SysInfo("window.alert('添加失败！工具栏数量最多不能超过16个.');");
				this.BindData();
			}
			else
			{
				DataTable dataTable = DALCommon.GetDataList("ToolBar", "", " [ID] in(" + text + ") ").Tables[0];
				if (dataTable.Rows.Count > 0)
				{
					this.CollectData();
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						bool flag = true;
						for (int j = 0; j < gridViewSource.Rows.Count; j++)
						{
							if (gridViewSource.Rows[j]["Oper"].ToString() == dataTable.Rows[i]["FieldText"].ToString())
							{
								flag = false;
							}
						}
						if (flag)
						{
							DataRow dataRow = gridViewSource.NewRow();
							dataRow[0] = dataTable.Rows[i]["FieldValue"].ToString();
							dataRow[1] = dataTable.Rows[i]["FieldText"].ToString();
							dataRow[2] = dataTable.Rows[i]["Array"].ToString();
							dataRow[3] = dataTable.Rows[i]["Command"].ToString();
							dataRow[4] = 0;
							gridViewSource.Rows.Add(dataRow);
						}
					}
					this.BindData();
				}
			}
		}
	}

	private void BindData()
	{
		this.gvdatauser.DataSource = this.GridViewSource;
		this.gvdatauser.DataBind();
	}

	protected void gvdatauser_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		this.CollectData();
		DataTable gridViewSource = this.GridViewSource;
		for (int i = 0; i < gridViewSource.Rows.Count; i++)
		{
			if (i == e.RowIndex)
			{
				if (int.Parse(gridViewSource.Rows[i]["ID"].ToString()) > 0)
				{
					if (this.hfdellist.Value == string.Empty)
					{
						this.hfdellist.Value = gridViewSource.Rows[i]["ID"].ToString();
					}
					else
					{
						HiddenField expr_AA = this.hfdellist;
						expr_AA.Value = expr_AA.Value + "," + gridViewSource.Rows[i]["ID"].ToString();
					}
				}
			}
		}
		this.GridViewSource.Rows[e.RowIndex].Delete();
		this.BindData();
	}

	protected void CollectData()
	{
		for (int i = 0; i < this.gvdatauser.Rows.Count; i++)
		{
			TextBox textBox = this.gvdatauser.Rows[i].FindControl("tbArray") as TextBox;
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i]["Array"] = textBox.Text;
		}
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		string[] array = this.hfreclist.Value.Split(new char[]
		{
			','
		});
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ChkGo();");
			e.Row.Cells[0].Attributes.Add("style", "width:20px;padding-right:0px;");
			e.Row.Cells[1].Attributes.Add("style", "padding-right:5px; text-align:center;");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[0].Text = "<input id=\"cb" + e.Row.Cells[0].Text + "\" type=\"checkbox\" onclick=\"cbone(this);\"/>";
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].ToString() == e.Row.Cells[0].Text)
				{
					e.Row.Cells[0].Text = "<input id=\"cb" + e.Row.Cells[0].Text + "\" type=\"checkbox\" checked=\"checked\" onclick=\"cbone(this);\"/>";
					e.Row.Attributes.Add("style", "background:#D6F1F8;");
					break;
				}
			}
			e.Row.Cells[1].Text = "<img src='../../Public/Images/Tool/" + e.Row.Cells[1].Text + "'/>";
		}
	}

	protected void gvdatauser_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[0].Attributes.Add("style", "padding-right:5px; text-align:center;");
			e.Row.Cells[0].Text = "<img src='../../Public/Images/Tool/" + e.Row.Cells[0].Text + "'/>";
			e.Row.Cells[2].Attributes.Add("class", "tbbg");
			e.Row.Cells[3].Attributes.Add("style", "padding-right:5px; text-align:center;");
		}
	}

	protected void btnClean_Click(object sender, EventArgs e)
	{
		string str = "";
		int num = DALCommon.DeteleData("ToolBar", " DeptID=1 and iOperator=" + (string)this.Session["Session_wtUserID"], out str);
		if (num == 0)
		{
			this.SysInfo("window.alert('操作成功！工具栏已清除！');");
			this.GridViewSource.Clear();
			this.BindData();
		}
		else
		{
			this.SysInfo("window.alert('操作失败！" + str + "');");
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		this.CollectData();
		DataTable gridViewSource = this.GridViewSource;
		List<string[]> list = new List<string[]>();
		for (int i = 0; i < gridViewSource.Rows.Count; i++)
		{
			string[] array = new string[4];
			if (gridViewSource.Rows[i]["ID"].ToString() == "0")
			{
				string text = "DeptID";
				string text2 = "1";
				text += ",iOperator";
				text2 = text2 + "," + (string)this.Session["Session_wtUserID"];
				text += ",FieldValue";
				text2 = text2 + ",'" + gridViewSource.Rows[i]["Img"].ToString() + "'";
				text += ",FieldText";
				text2 = text2 + ",'" + gridViewSource.Rows[i]["Oper"].ToString() + "'";
				text += ",Command";
				text2 = text2 + ",'" + FunLibrary.ChkInput(gridViewSource.Rows[i]["Comm"].ToString()) + "'";
				text += ",Array";
				text2 = text2 + "," + gridViewSource.Rows[i]["Array"].ToString();
				array[0] = text;
				array[1] = text2;
				array[2] = "xt_gl_add";
				array[3] = "0";
			}
			else
			{
				string text2 = "Array=" + gridViewSource.Rows[i]["Array"].ToString();
				array[0] = "ToolBar";
				array[1] = text2;
				array[2] = " [ID]=" + gridViewSource.Rows[i]["ID"].ToString();
				array[3] = gridViewSource.Rows[i]["ID"].ToString();
			}
			list.Add(array);
		}
		List<string[]> list2 = new List<string[]>();
		if (this.hfdellist.Value != string.Empty)
		{
			list2.Add(new string[]
			{
				"ToolBar",
				" ID in(" + this.hfdellist.Value + ")"
			});
		}
		DALToolBar dALToolBar = new DALToolBar();
		string str = "";
		int num = dALToolBar.Update(list, list2, out str);
		if (num == 0)
		{
			this.SysInfo("window.alert('操作成功！工具栏已成功保存！');parent.CloseDialog();");
		}
		else
		{
			this.SysInfo("window.alert('操作失败！" + str + "');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
