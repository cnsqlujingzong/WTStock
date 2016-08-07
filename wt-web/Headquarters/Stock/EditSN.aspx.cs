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

public partial class Headquarters_Stock_EditSN : Page, IRequiresSessionState
{
	private int goodsid;

	private int unitid;

	private string snvalue;

	private string snid;

	private decimal gdsnum;

	private string fid;

	private string f;

	private int iflag;

	private int count;

	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("SN", typeof(string)));
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

	public string Str_Goodsid
	{
		get
		{
			return this.goodsid.ToString();
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["goodsid"], out this.goodsid);
		int.TryParse(base.Request["unitid"], out this.unitid);
		decimal.TryParse(base.Request["gdsnum"], out this.gdsnum);
		this.snvalue = base.Request["snvalue"];
		this.snid = base.Request["snid"];
		this.fid = base.Request["fid"];
		if (this.unitid == 0)
		{
			base.Response.Write("参数传入错误，请重新打开编辑窗口");
			base.Response.End();
		}
		if (this.fid == null || this.fid == string.Empty)
		{
			this.fid = "iframeDialog";
			this.f = "1";
		}
		else
		{
			this.f = "";
		}
		int.TryParse(base.Request["iflag"], out this.iflag);
		if (!base.IsPostBack)
		{
			this.hfSN.Value = this.snvalue;
			this.AddEmpty();
			this.FillData();
			DataTable dataTable = DALCommon.GetDataList("GoodsUnit", "UnitRelation", " [ID]=" + this.unitid.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				int value = 1;
				int.TryParse(decimal.Parse(dataTable.Rows[0]["UnitRelation"].ToString()).ToString("#0"), out value);
				this.hfNum.Value = Convert.ToDouble(this.gdsnum * value).ToString();
			}
			if (this.iflag == 2)
			{
				this.btnAutoAdd.Visible = false;
				this.btnSltSN.Visible = true;
			}
			else
			{
				this.btnAutoAdd.Visible = true;
				this.btnSltSN.Visible = false;
			}
		}
	}

	private void AddEmpty()
	{
		DataTable gridViewSource = this.GridViewSource;
		DataRow dataRow = gridViewSource.NewRow();
		dataRow[0] = "";
		gridViewSource.Rows.Add(dataRow);
		this.GridViewSource = gridViewSource;
		this.BindData();
	}

	protected void FillData()
	{
		if (this.snvalue != null && this.snvalue != string.Empty)
		{
			string[] array = this.snvalue.Split(new char[]
			{
				','
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
		dataRow[0] = str;
		gridViewSource.Rows.Add(dataRow);
		this.GridViewSource = gridViewSource;
	}

	private void BindData()
	{
		this.gvdata.DataSource = this.GridViewSource;
		this.count = this.GridViewSource.Rows.Count;
		this.gvdata.DataBind();
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DataTable gridViewSource = this.GridViewSource;
		if (FunLibrary.ChkInput(this.tbSN.Text) == "")
		{
			this.SysInfo("window.alert('操作失败！序列号不能为空');$('" + this.tbSN.ClientID + "').select();");
		}
		else
		{
			for (int i = 1; i < gridViewSource.Rows.Count; i++)
			{
				if (gridViewSource.Rows[i]["SN"].ToString() == this.tbSN.Text.Trim())
				{
					this.SysInfo("window.alert('操作失败！不允许存在相同的序列号');$('" + this.tbSN.ClientID + "').select();");
					return;
				}
			}
			int num = gridViewSource.Rows.Count - 1;
			int num2 = 0;
			int.TryParse(this.hfNum.Value, out num2);
			if (num >= num2)
			{
				this.SysInfo("window.alert('操作失败！序列号数量不允许大于产品数量');$('" + this.tbSN.ClientID + "').select();");
			}
			else
			{
				DataRow dataRow = gridViewSource.NewRow();
				dataRow[0] = this.tbSN.Text.Trim();
				gridViewSource.Rows.InsertAt(dataRow, 1);
				this.GridViewSource = gridViewSource;
				this.CrSN();
				this.GridViewSource.Clear();
				this.AddEmpty();
				this.FillData();
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
		DataTable gridViewSource = this.GridViewSource;
		if (text != string.Empty)
		{
			DataTable dataTable = DALCommon.GetDataList("ck_stocksn", "SN", " [ID] in(" + text + ") ").Tables[0];
			int num = gridViewSource.Rows.Count - 1 + dataTable.Rows.Count;
			int num2 = 0;
			int.TryParse(this.hfNum.Value, out num2);
			if (num > num2)
			{
				this.SysInfo("window.alert('操作失败！序列号数量不允许大于产品数量');$('" + this.tbSN.ClientID + "').select();");
				return;
			}
			if (dataTable.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					bool flag = true;
					for (int j = 1; j < gridViewSource.Rows.Count; j++)
					{
						if (gridViewSource.Rows[j]["SN"].ToString() == dataTable.Rows[i]["SN"].ToString())
						{
							flag = false;
						}
					}
					if (flag)
					{
						DataRow dataRow = gridViewSource.NewRow();
						dataRow[0] = dataTable.Rows[i]["SN"].ToString();
						gridViewSource.Rows.Add(dataRow);
					}
				}
			}
		}
		this.CrSN();
		this.GridViewSource.Clear();
		this.AddEmpty();
		this.FillData();
		this.SysInfo("$('" + this.tbSN.ClientID + "').select();");
	}

	protected void btnAutoAdd_Click(object sender, EventArgs e)
	{
		DataTable gridViewSource = this.GridViewSource;
		int num = gridViewSource.Rows.Count - 1;
		int num2 = 0;
		int.TryParse(this.hfNum.Value, out num2);
		if (num >= num2)
		{
			this.SysInfo("window.alert('操作失败！序列号数量不允许大于产品数量');$('" + this.tbSN.ClientID + "').select();");
		}
		else
		{
			int num3 = gridViewSource.Rows.Count - 1;
			for (int i = 0; i < num2 - num3; i++)
			{
				DataRow dataRow = gridViewSource.NewRow();
				dataRow[0] = DALCommon.CreateID(26, 1);
				gridViewSource.Rows.Add(dataRow);
				this.GridViewSource = gridViewSource;
			}
			this.CrSN();
			this.GridViewSource.Clear();
			this.AddEmpty();
			this.FillData();
		}
	}

	protected void gvdata_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		this.GridViewSource.Rows[e.RowIndex].Delete();
		this.CrSN();
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
			e.Row.Cells[0].Text = Convert.ToString(this.count - e.Row.RowIndex);
			e.Row.Cells[0].Attributes.Add("style", "background:#ECE9D8;");
		}
	}

	private void CrSN()
	{
		DataTable gridViewSource = this.GridViewSource;
		string text = "";
		for (int i = 0; i < gridViewSource.Rows.Count; i++)
		{
			if (text == "")
			{
				text = gridViewSource.Rows[i]["SN"].ToString();
			}
			else
			{
				text = text + "," + gridViewSource.Rows[i]["SN"].ToString();
			}
		}
		this.snvalue = text;
		this.hfSN.Value = text;
		string text2 = "";
		if (base.Request.QueryString["tdsn"] != null)
		{
			text2 = string.Concat(new string[]
			{
				"parent.",
				this.fid,
				".document.getElementById(\"",
				base.Request.QueryString["tdsn"],
				"\").innerHTML='",
				base.Server.HtmlEncode(text),
				"';"
			});
		}
		string text3 = text2;
		text2 = string.Concat(new string[]
		{
			text3,
			"parent.",
			this.fid,
			".document.getElementById(\"",
			this.snid,
			"\").value='",
			base.Server.HtmlEncode(text),
			"';$('",
			this.tbSN.ClientID,
			"').value='';$('",
			this.tbSN.ClientID,
			"').select();"
		});
		if (this.snid == "hfSNs")
		{
			text3 = text2;
			text2 = string.Concat(new string[]
			{
				text3,
				"if(parent.",
				this.fid,
				".$('btnChkParts')) parent.",
				this.fid,
				".$('btnChkParts').click();"
			});
		}
		this.SysInfo(text2);
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
