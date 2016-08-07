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
using Wuqi.Webdiyer;

public partial class Headquarters_Stock_SchAllocate : Page, IRequiresSessionState
{
	private int pageSize = 15;

	private int iflag;

	private decimal dqty = 0m;

	private decimal tqty = 0m;

	private decimal dprice = 0m;

	private decimal dtotal = 0m;

	private decimal dtotals = 0m;

	private decimal dqtys = 0m;

	private decimal tqtys = 0m;

	private decimal tqtyr = 0m;

	private decimal dqtyr = 0m;

	private decimal dtotalr = 0m;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["iflag"], out this.iflag);
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "ck_r43"))
				{
					this.btnExcel.Enabled = false;
				}
				if (!dALRight.GetRight(num, "ck_r44"))
				{
					this.btnPrint.Visible = false;
				}
				if (!dALRight.GetRight(num, "ck_r42"))
				{
					this.btnDel.Enabled = false;
				}
			}
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
	}

	protected void btnClr_Click(object sender, EventArgs e)
	{
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		if (this.hfRecID.Value != "-1")
		{
			this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
			this.ShowDetail();
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
			this.ShowDetail();
		}
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		this.hfSch.Value = "0";
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void btnFsh_Click(object sender, EventArgs e)
	{
		this.hfSch.Value = "-1";
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void FillData(string sortExpression, string direction)
	{
		int recordCount = 0;
		string text = this.strParm();
		string fldSort = sortExpression + " " + direction;
		if (this.iflag == 1)
		{
			text += " and FromDeptID=1 and Status=6 ";
		}
		this.hfSql.Value = text;
		this.gvdata.DataSource = DALCommon.GetList_HL(1, "ck_allocate", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
		this.gvdata.DataBind();
		this.lbCount.Text = recordCount.ToString();
		if (this.lbCount.Text == "0")
		{
			this.lbCount.Visible = false;
			this.lbPage.Visible = false;
			this.lbCountText.Visible = false;
		}
		else
		{
			this.lbCount.Visible = true;
			this.lbPage.Visible = true;
			this.lbCountText.Visible = true;
		}
		this.jsPager.PageSize = this.pageSize;
		this.jsPager.RecordCount = recordCount;
		this.hfTbTitle.Value = (this.hfTbField.Value = string.Empty);
		if (this.gvdata.Rows.Count > 0)
		{
			for (int i = 0; i < this.gvdata.HeaderRow.Cells.Count; i++)
			{
				string dataField = ((BoundField)this.gvdata.Columns[i]).DataField;
				string text2 = this.gvdata.HeaderRow.Cells[i].Text;
				if (dataField != "" && dataField != "ID")
				{
					this.gvdata.HeaderRow.Cells[i].Attributes.Add("id", dataField);
					this.gvdata.HeaderRow.Cells[i].Attributes.Add("onclick", string.Concat(new string[]
					{
						"HeaderOrder('",
						dataField,
						"','",
						text2,
						"');"
					}));
					this.gvdata.HeaderRow.Cells[i].Attributes.Add("onmouseover", "this.style.cursor='default';");
					if (this.hfTbTitle.Value == string.Empty)
					{
						this.hfTbTitle.Value = text2;
					}
					else
					{
						HiddenField expr_2C5 = this.hfTbTitle;
						expr_2C5.Value = expr_2C5.Value + "," + text2;
					}
					if (this.hfTbField.Value == string.Empty)
					{
						this.hfTbField.Value = dataField;
					}
					else
					{
						HiddenField expr_315 = this.hfTbField;
						expr_315.Value = expr_315.Value + "," + dataField;
					}
				}
			}
		}
	}

	protected void jsPager_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected string strParm()
	{
		string text = " 1=1 ";
		string text2 = FunLibrary.ChkInput(this.tbCon.Text);
		if (this.hfSch.Value == "0")
		{
			if (this.ddlKey.SelectedValue != "-1")
			{
				int schid = 0;
				int.TryParse(this.ddlKey.SelectedValue, out schid);
				if (text2 != "")
				{
					DALAllocate dALAllocate = new DALAllocate();
					text += dALAllocate.GetSchWhere(schid, text2);
				}
			}
		}
		return text;
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ModBill();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			if (e.Row.Cells[2].Text == "�ѽ���")
			{
				e.Row.Attributes.Add("style", "color:#008000");
				e.Row.Cells[1].Attributes.Add("class", "tgreen");
			}
			else if (e.Row.Cells[2].Text == "������")
			{
				e.Row.Attributes.Add("style", "color:#0000ff");
				e.Row.Cells[1].Attributes.Add("class", "tblue");
			}
			else if (e.Row.Cells[2].Text == "�����")
			{
				e.Row.Attributes.Add("style", "color:#ff0000");
				e.Row.Cells[1].Attributes.Add("class", "tred");
			}
			else if (e.Row.Cells[2].Text == "������")
			{
				e.Row.Attributes.Add("style", "color:#848284");
				e.Row.Cells[1].Attributes.Add("class", "tgay");
			}
			else if (e.Row.Cells[2].Text == "��ǩ��")
			{
				e.Row.Attributes.Add("style", "color:#8a4000");
				e.Row.Cells[1].Attributes.Add("class", "tyellow");
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "��ǰҳ:" + this.gvdata.Rows.Count.ToString();
		}
	}

	protected void btnChk_Click(object sender, EventArgs e)
	{
		int num = 0;
		int.TryParse(this.hfRecID.Value, out num);
		DALAllocate dALAllocate = new DALAllocate();
		AllocateInfo model = dALAllocate.GetModel(num);
		string text = string.Empty;
		if (model != null)
		{
			if (model.FromDept == 1)
			{
				if (model.Status == 6)
				{
					dALAllocate.UpdateChk(num);
					text = "�����ɹ����õ������ѡ����µݽ�����";
				}
				else
				{
					text = "����ʧ�ܣ�ֻ�б����صĵ��������ܡ��ݽ���ˡ���";
				}
			}
			else
			{
				text = "����ʧ�ܣ�ֻ�ܡ��ݽ���ˡ������ŵĵ�������";
			}
		}
		else
		{
			text = "����ʧ�ܣ���ǰ��Ϣ�����ڣ���ˢ�º������";
		}
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		this.SysInfo(string.Concat(new string[]
		{
			"window.alert('",
			text,
			"');ChkID('",
			this.hfRecID.Value,
			"');"
		}));
	}

	protected void btnDel_Click(object sender, EventArgs e)
	{
		int iTbid = 0;
		int.TryParse(this.hfRecID.Value, out iTbid);
		DALAllocate dALAllocate = new DALAllocate();
		string empty = string.Empty;
		int iOperator = 0;
		int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
		int num = dALAllocate.Delete(1, iTbid, iOperator, out empty);
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		if (num == 0)
		{
			this.hfRecID.Value = "-1";
		}
		else
		{
			this.SysInfo(string.Concat(new string[]
			{
				"window.alert('",
				empty,
				"');ChkID('",
				this.hfRecID.Value,
				"');"
			}));
			this.ShowDetail();
		}
	}

	protected void btnExcel_Click(object sender, EventArgs e)
	{
		string strCondition = string.Concat(new string[]
		{
			this.hfSql.Value,
			" order by ",
			this.hfOrderName.Value,
			" ",
			this.hfOrder.Value
		});
		DataTable dt = DALCommon.GetDataList("ck_allocate", this.hfTbField.Value, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "������", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert(\"" + empty + "\");");
		}
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "d" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('d" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "td" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:40px;padding:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
			decimal.TryParse(e.Row.Cells[8].Text, out this.tqty);
			decimal.TryParse(e.Row.Cells[9].Text, out this.tqtys);
			decimal.TryParse(e.Row.Cells[10].Text, out this.tqtyr);
			decimal.TryParse(e.Row.Cells[11].Text, out this.dprice);
			this.dqty += this.tqty;
			this.dqtys += this.tqtys;
			this.dqtyr += this.tqtyr;
			this.dtotal += this.tqty * this.dprice;
			this.dtotals += this.tqtys * this.dprice;
			this.dtotalr += this.tqtyr * this.dprice;
			string[] array = e.Row.Cells[15].Text.Split(new char[]
			{
				','
			});
			if (array.Length > 1)
			{
				e.Row.Cells[15].Text = "<a href=\"#\" onclick=\"ViewSN('" + e.Row.Cells[15].Text + "');\">�鿴���к�</a>";
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[1].Text = "�ϼ�";
			e.Row.Cells[1].Attributes.Add("style", "padding:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[8].Text = this.dqty.ToString("#0.00");
			e.Row.Cells[9].Text = this.dqtys.ToString("#0.00");
			e.Row.Cells[10].Text = this.dqtyr.ToString("#0.00");
			e.Row.Cells[12].Text = this.dtotal.ToString("#0.00");
			e.Row.Cells[13].Text = this.dtotals.ToString("#0.00");
			e.Row.Cells[14].Text = this.dtotalr.ToString("#0.00");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void btnShow_Click(object sender, EventArgs e)
	{
		this.ShowDetail();
	}

	protected void ShowDetail()
	{
		this.GridView2.DataSource = DALCommon.GetDataList("ck_allocatedetail", "", " BillID=" + this.hfRecID.Value);
		this.GridView2.DataBind();
	}

	protected void btnEx_Click(object sender, EventArgs e)
	{
		DataTable dt = DALCommon.GetDataList("ck_allocatedetail", "GoodsNO,_Name,Attr,Spec,ProductBrand,Unit,AppQty,SndQty,RecQty,Price,Total,Totals,Totalr,SN,MainTenancePeriod,Remark", " BillID=" + this.hfRecID.Value).Tables[0];
		string[] tbTitle = new string[]
		{
			"��Ʒ���",
			"����",
			"����",
			"���",
			"Ʒ��",
			"��λ",
			"��������",
			"��������",
			"ǩ������",
			"����",
			"������",
			"�������",
			"ǩ�ս��",
			"���к�",
			"������",
			"��ע"
		};
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "������", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert(\"" + empty + "\");");
		}
	}
}
