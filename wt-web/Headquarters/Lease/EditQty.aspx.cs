using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.Library;
using wt.OtherLibrary;

public partial class Headquarters_Lease_EditQty : Page, IRequiresSessionState
{

	private string tbqty;

	private string qtyvalue;

	private string fid;

	private string f;

	private int ff;

	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("QtyType", typeof(string)));
				dataTable.Columns.Add(new DataColumn("BeginQty", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Rated", typeof(string)));
				dataTable.Columns.Add(new DataColumn("SuperZhangFee", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ChargeStyle", typeof(int)));
				dataTable.Columns.Add(new DataColumn("QtyTypeID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("Formula", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CostPrice", typeof(string)));
				this.ViewState["List"] = dataTable;
			}
			return (DataTable)this.ViewState["List"];
		}
		set
		{
			this.ViewState["List"] = value;
		}
	}

	public string Str_Fid
	{
		get
		{
			return this.fid;
		}
	}

	public string Str_F
	{
		get
		{
			return this.f;
		}
	}

	public string Str_FF
	{
		get
		{
			return this.ff.ToString();
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		this.tbqty = base.Request["tbqty"];
		this.qtyvalue = base.Request["qtyvalue"];
		this.fid = base.Request["fid"];
		int.TryParse(base.Request["ff"], out this.ff);
		if (this.tbqty == null || this.qtyvalue == null)
		{
			base.Response.Write("参数传入错误，请重新打开编辑窗口");
			base.Response.End();
		}
		if (this.fid == null || this.fid == string.Empty)
		{
			this.fid = "iframeDialog";
			this.f = "1";
		}
		else if (base.Request.QueryString["f"] == null)
		{
			this.f = "";
		}
		else
		{
			this.f = base.Request.QueryString["f"];
		}
		if (!base.IsPostBack)
		{
			OtherFunction.BindQtyType(this.ddlQtyType);
			this.hfFormula.Value = this.qtyvalue;
			this.AddEmpty();
			this.FillData();
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
		dataRow[4] = 1;
		dataRow[5] = 0;
		dataRow[6] = "";
		gridViewSource.Rows.Add(dataRow);
		this.GridViewSource = gridViewSource;
		this.BindData();
	}

	protected void CollectData()
	{
		for (int i = 0; i < this.gvdata.Rows.Count; i++)
		{
			TextBox textBox = this.gvdata.Rows[i].FindControl("tbRated") as TextBox;
			TextBox textBox2 = this.gvdata.Rows[i].FindControl("tbBeginQty") as TextBox;
			TextBox textBox3 = this.gvdata.Rows[i].FindControl("tbSuperZhangFee") as TextBox;
			DropDownList dropDownList = this.gvdata.Rows[i].FindControl("ddlCalStyle") as DropDownList;
			TextBox textBox4 = this.gvdata.Rows[i].FindControl("tbFormula") as TextBox;
			TextBox textBox5 = this.gvdata.Rows[i].FindControl("tbCostPrice") as TextBox;
			DataTable gridViewSource = this.GridViewSource;
			gridViewSource.Rows[i]["Rated"] = FunLibrary.ChkInput(textBox.Text);
			gridViewSource.Rows[i]["BeginQty"] = FunLibrary.ChkInput(textBox2.Text);
			gridViewSource.Rows[i]["SuperZhangFee"] = FunLibrary.ChkInput(textBox3.Text);
			gridViewSource.Rows[i]["ChargeStyle"] = dropDownList.SelectedItem.Value;
			gridViewSource.Rows[i]["Formula"] = FunLibrary.ChkInput(textBox4.Text);
			gridViewSource.Rows[i]["CostPrice"] = FunLibrary.ChkInput(textBox5.Text);
		}
	}

	protected void FillData()
	{
		if (this.qtyvalue != null && this.qtyvalue != string.Empty)
		{
			string[] array = this.qtyvalue.Split(new char[]
			{
				';'
			});
			for (int i = 0; i < array.Length; i++)
			{
				this.NewRow(i, array[i]);
			}
		}
		this.BindData();
	}

	protected void NewRow(int id, string str)
	{
		DataTable gridViewSource = this.GridViewSource;
		DataRow dataRow = gridViewSource.NewRow();
		string[] array = str.Split(new char[]
		{
			','
		});
		dataRow[0] = array[0].ToString();
		dataRow[1] = array[1].ToString();
		dataRow[2] = array[2].ToString();
		dataRow[3] = array[3].ToString();
		dataRow[4] = array[4].ToString();
		dataRow[5] = array[5].ToString();
		if (array.Length == 8)
		{
			dataRow[6] = array[7].ToString();
		}
		else
		{
			dataRow[6] = 0;
		}
		dataRow[7] = array[6].ToString();
		gridViewSource.Rows.Add(dataRow);
		this.GridViewSource = gridViewSource;
	}

	private void BindData()
	{
		this.gvdata.DataSource = this.GridViewSource;
		this.gvdata.DataBind();
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		this.CollectData();
		DataTable gridViewSource = this.GridViewSource;
		int num = int.Parse(this.ddlQtyType.SelectedValue);
		for (int i = 0; i < gridViewSource.Rows.Count; i++)
		{
			if (gridViewSource.Rows[i]["QtyTypeID"].ToString() == num.ToString())
			{
				this.SysInfo("window.alert('当期计数器类型已存在，请重新选择计数器类型！');$(\"ddlQtyType\").focus();");
				return;
			}
		}
		DataRow dataRow = gridViewSource.NewRow();
		int num2 = 0;
		int num3 = 0;
		decimal num4 = 0m;
		int.TryParse(this.tbStartQty.Text, out num2);
		int.TryParse(this.tbRated.Text, out num3);
		decimal.TryParse(this.tbSuperZhangFee.Text, out num4);
		decimal num5 = 0m;
		decimal.TryParse(this.tbCostPrice.Text, out num5);
		dataRow[0] = this.ddlQtyType.SelectedItem.Text;
		dataRow[1] = num2;
		dataRow[2] = num3;
		dataRow[3] = num4;
		dataRow[4] = int.Parse(this.ddlCalStyle.SelectedItem.Value);
		dataRow[5] = num;
		dataRow[6] = "";
		dataRow[7] = num5;
		gridViewSource.Rows.Add(dataRow);
		this.GridViewSource = gridViewSource;
		this.CrFormula();
		this.GridViewSource.Clear();
		this.AddEmpty();
		this.FillData();
	}

	protected void btnConf_Click(object sender, EventArgs e)
	{
		this.CollectData();
		string text = "";
		DataTable gridViewSource = this.GridViewSource;
		int i;
		for (i = 1; i < gridViewSource.Rows.Count; i++)
		{
			if (text == "")
			{
				text = string.Concat(new string[]
				{
					gridViewSource.Rows[i]["QtyType"].ToString(),
					",",
					gridViewSource.Rows[i]["BeginQty"].ToString(),
					",",
					gridViewSource.Rows[i]["Rated"].ToString(),
					",",
					gridViewSource.Rows[i]["SuperZhangFee"].ToString(),
					",",
					gridViewSource.Rows[i]["ChargeStyle"].ToString(),
					",",
					gridViewSource.Rows[i]["QtyTypeID"].ToString(),
					",",
					gridViewSource.Rows[i]["CostPrice"].ToString(),
					",",
					gridViewSource.Rows[i]["Formula"].ToString()
				});
			}
			else
			{
				text = string.Concat(new string[]
				{
					text,
					";",
					gridViewSource.Rows[i]["QtyType"].ToString(),
					",",
					gridViewSource.Rows[i]["BeginQty"].ToString(),
					",",
					gridViewSource.Rows[i]["Rated"].ToString(),
					",",
					gridViewSource.Rows[i]["SuperZhangFee"].ToString(),
					",",
					gridViewSource.Rows[i]["ChargeStyle"].ToString(),
					",",
					gridViewSource.Rows[i]["QtyTypeID"].ToString(),
					",",
					gridViewSource.Rows[i]["CostPrice"].ToString(),
					",",
					gridViewSource.Rows[i]["Formula"].ToString()
				});
			}
		}
		this.qtyvalue = text;
		this.hfFormula.Value = text;
		this.GridViewSource.Clear();
		this.AddEmpty();
		this.FillData();
		DataTable gridViewSource2 = this.GridViewSource;
		i = 1;
		while (i < gridViewSource2.Rows.Count)
		{
			if (gridViewSource2.Rows[i]["BeginQty"].ToString() == "")
			{
				this.SysInfo("window.alert('操作失败！第" + i.ToString() + "行【期初计数】不能为空');");
			}
			else if (gridViewSource2.Rows[i]["Rated"].ToString() == "")
			{
				this.SysInfo("window.alert('操作失败！第" + i.ToString() + "行【额定量】不能为空');");
			}
			else
			{
				if (!(gridViewSource2.Rows[i]["SuperZhangFee"].ToString() == ""))
				{
					if (gridViewSource2.Rows[i]["ChargeStyle"].ToString() == "2")
					{
						if (gridViewSource2.Rows[i]["Formula"].ToString() == "")
						{
							this.SysInfo("window.alert('操作失败！第" + i.ToString() + "行为【阶梯式算法】计算公式不能为空');");
							return;
						}
					}
					i++;
					continue;
				}
				this.SysInfo("window.alert('操作失败！第" + i.ToString() + "行【超张费】不能为空');");
			}
			return;
		}
		this.SysInfo(string.Concat(new string[]
		{
			"parent.",
			this.fid,
			".document.getElementById(\"",
			this.tbqty,
			"\").value='",
			base.Server.HtmlEncode(text),
			"';parent.CloseDialog",
			this.f,
			"();"
		}));
	}

	protected void gvdata_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		this.GridViewSource.Rows[e.RowIndex].Delete();
		this.CrFormula();
		this.GridViewSource.Clear();
		this.AddEmpty();
		this.FillData();
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowIndex == 0)
		{
			e.Row.Visible = false;
		}
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			TextBox textBox = e.Row.FindControl("tbChargeStyle") as TextBox;
			e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex);
			e.Row.Cells[0].Attributes.Add("style", "background:#ECE9D8;");
			HyperLink hyperLink = e.Row.FindControl("hlFormula") as HyperLink;
			TextBox textBox2 = e.Row.FindControl("tbFormula") as TextBox;
			DropDownList dropDownList = e.Row.FindControl("ddlCalStyle") as DropDownList;
			dropDownList.Attributes.Add("onchange", string.Concat(new string[]
			{
				"ChkStyle('",
				dropDownList.ClientID,
				"','",
				hyperLink.ClientID,
				"');"
			}));
			hyperLink.Attributes.Add("onclick", "EditFormula('" + textBox2.ClientID + "')");
			dropDownList.Items.Add(new ListItem("标准计费法", "1"));
			dropDownList.Items.Add(new ListItem("阶梯计费法", "2"));
			dropDownList.Items.Add(new ListItem("合并计费法", "3"));
			dropDownList.Items.Add(new ListItem("打包计费法", "6"));
			dropDownList.Items.Add(new ListItem("未印费用抵充法", "7"));
			dropDownList.Items.Add(new ListItem("包季度(超量)计费法", "4"));
			dropDownList.Items.Add(new ListItem("包季度(超费用)计费法", "5"));
			dropDownList.Items.Add(new ListItem("全年印量平均法", "8"));
			for (int i = 0; i < dropDownList.Items.Count; i++)
			{
				if (dropDownList.Items[i].Value == textBox.Text)
				{
					dropDownList.Items[i].Selected = true;
					if (textBox.Text == "2")
					{
						hyperLink.Attributes.Add("style", "display:inline");
					}
					else
					{
						hyperLink.Attributes.Add("style", "display:none");
					}
					break;
				}
			}
		}
	}

	private void CrFormula()
	{
		DataTable gridViewSource = this.GridViewSource;
		string text = "";
		for (int i = 1; i < gridViewSource.Rows.Count; i++)
		{
			if (text == "")
			{
				text = string.Concat(new string[]
				{
					gridViewSource.Rows[i]["QtyType"].ToString(),
					",",
					gridViewSource.Rows[i]["BeginQty"].ToString(),
					",",
					gridViewSource.Rows[i]["Rated"].ToString(),
					",",
					gridViewSource.Rows[i]["SuperZhangFee"].ToString(),
					",",
					gridViewSource.Rows[i]["ChargeStyle"].ToString(),
					",",
					gridViewSource.Rows[i]["QtyTypeID"].ToString(),
					",",
					gridViewSource.Rows[i]["CostPrice"].ToString(),
					",",
					gridViewSource.Rows[i]["Formula"].ToString()
				});
			}
			else
			{
				text = string.Concat(new string[]
				{
					text,
					";",
					gridViewSource.Rows[i]["QtyType"].ToString(),
					",",
					gridViewSource.Rows[i]["BeginQty"].ToString(),
					",",
					gridViewSource.Rows[i]["Rated"].ToString(),
					",",
					gridViewSource.Rows[i]["SuperZhangFee"].ToString(),
					",",
					gridViewSource.Rows[i]["ChargeStyle"].ToString(),
					",",
					gridViewSource.Rows[i]["QtyTypeID"].ToString(),
					",",
					gridViewSource.Rows[i]["CostPrice"].ToString(),
					",",
					gridViewSource.Rows[i]["Formula"].ToString()
				});
			}
		}
		this.qtyvalue = text;
		this.hfFormula.Value = text;
		this.SysInfo(string.Concat(new string[]
		{
			"parent.",
			this.fid,
			".document.getElementById(\"",
			this.tbqty,
			"\").value='",
			base.Server.HtmlEncode(text),
			"';"
		}));
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
