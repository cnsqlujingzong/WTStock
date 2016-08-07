using System;
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

public partial class Headquarters_Basic_BaseInfo : Page, IRequiresSessionState
{

	private int pageSize = 10;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "jc_r1"))
				{
					this.btnAdd.Enabled = false;
					this.btnDel.Enabled = false;
					this.btnMod.Enabled = false;
				}
			}
			this.lbName.Text = "员工岗位";
			this.hfTbName.Value = "Quarters";
			this.tvBaseInfo.Nodes[0].ImageUrl = "~/Public/Images/notice.gif";
			this.FillData();
			this.SetEnable();
		}
	}

	protected void LoadField()
	{
		this.GridView1.Columns.Clear();
		BoundField boundField = new BoundField();
		boundField.DataField = "ID";
		boundField.HeaderText = "ID";
		this.GridView1.Columns.Add(boundField);
		boundField = new BoundField();
		boundField.DataField = "";
		boundField.HeaderText = "序";
		this.GridView1.Columns.Add(boundField);
		boundField = new BoundField();
		boundField.DataField = "_Name";
		boundField.HeaderText = this.lbName.Text;
		this.GridView1.Columns.Add(boundField);
		boundField = new BoundField();
		boundField.DataField = "Array";
		boundField.HeaderText = "排序";
		this.GridView1.Columns.Add(boundField);
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Cells[1].Attributes.Add("id", "t" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1 + (this.jsPager.CurrentPageIndex - 1) * 10);
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.GridView1.Rows.Count.ToString();
		}
	}

	protected void FillData()
	{
		this.LoadField();
		string strCondition = string.Empty;
		int num = 0;
		int.TryParse(this.hfType.Value, out num);
		switch (num)
		{
		case 1:
			strCondition = " DeptID=1 ";
			break;
		case 2:
			strCondition = " bDefault=0 ";
			break;
		default:
			strCondition = string.Empty;
			break;
		}
		int recordCount = 0;
		this.GridView1.DataSource = DALCommon.GetList_HL(1, this.hfTbName.Value, "", this.pageSize, this.jsPager.CurrentPageIndex, strCondition, " Array asc ", out recordCount);
		this.GridView1.DataBind();
		this.lbCount.Text = "总记录:" + recordCount.ToString();
		if (this.lbCount.Text == "总记录:0")
		{
			this.lbCount.Visible = false;
			this.lbPage.Visible = false;
		}
		else
		{
			this.lbCount.Visible = true;
			this.lbPage.Visible = true;
		}
		this.jsPager.PageSize = this.pageSize;
		this.jsPager.RecordCount = recordCount;
	}

	protected void jsPager_PageChanged(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.FillData();
	}

	protected void CleanText()
	{
		this.tbName.Text = string.Empty;
		this.tbArray.Text = string.Empty;
	}

	protected void SetEnable()
	{
		this.tbName.Enabled = false;
		this.tbArray.Enabled = false;
	}

	protected void SetDisEnable()
	{
		this.tbName.Enabled = true;
		this.tbArray.Enabled = true;
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		if (this.btnAdd.Text == "新建")
		{
			this.btnAdd.Text = "保存";
			this.SetDisEnable();
			this.CleanText();
			this.btnMod.Enabled = false;
			this.btnDel.Enabled = false;
			this.hfRecID.Value = "-1";
			this.SysInfo("ChkFocus();");
		}
		else
		{
			BaseInfo baseInfo = new BaseInfo();
			DALBaseInfo dALBaseInfo = new DALBaseInfo();
			baseInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
			baseInfo.pyCode = FunLibrary.CVT(FunLibrary.ChkInput(this.tbName.Text));
			int array = 0;
			int.TryParse(this.tbArray.Text, out array);
			baseInfo.Array = array;
			baseInfo.DeptID = new int?(1);
			if (this.hfRecID.Value == "-1")
			{
				this.hfTemp.Value = baseInfo._Name;
				bool bDept = false;
				if (this.hfType.Value == "1")
				{
					bDept = true;
				}
				string str;
				int num2;
				int num = dALBaseInfo.Add(this.hfTbName.Value, baseInfo, this.lbName.Text, bDept, out str, out num2);
				if (num == 0)
				{
					this.hfRecID.Value = num2.ToString();
				}
				else
				{
					if (num == -1)
					{
						this.SysInfo("window.alert('" + str + "');$('tbName').select();");
						return;
					}
					this.SysInfo("window.alert('系统错误！请查看错误日志');$('tbName').select();");
					return;
				}
			}
			else
			{
				baseInfo.ID = int.Parse(this.hfRecID.Value);
				string text = string.Empty;
				if (baseInfo._Name != this.hfTemp.Value)
				{
					if (this.hfType.Value == "1")
					{
						text = " DeptID=1 and ";
					}
					text = text + " _Name='" + baseInfo._Name + "'";
				}
				string str;
				int num = dALBaseInfo.Update(this.hfTbName.Value, baseInfo, text, out str);
				if (num == 0)
				{
					this.hfRecID.Value = baseInfo.ID.ToString();
				}
				else
				{
					if (num == -1)
					{
						this.SysInfo("window.alert('" + str + "');$('tbName').select();");
						return;
					}
					this.SysInfo("window.alert('系统错误！请查看错误日志');$('tbName').select();");
					return;
				}
			}
			this.FillData();
			this.btnAdd.Text = "新建";
			this.SetEnable();
			this.btnMod.Enabled = true;
			this.btnDel.Enabled = true;
			if (this.hfRecID.Value != "-1")
			{
				this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
			}
		}
	}

	protected void btnMod_Click(object sender, EventArgs e)
	{
		string str = string.Empty;
		if (this.btnMod.Text == "修改")
		{
			this.btnMod.Text = "保存";
			this.SetDisEnable();
			this.btnAdd.Enabled = false;
			this.btnDel.Enabled = false;
			str = "ChkFocus();ChkID('" + this.hfRecID.Value + "');";
		}
		else
		{
			BaseInfo baseInfo = new BaseInfo();
			DALBaseInfo dALBaseInfo = new DALBaseInfo();
			baseInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
			baseInfo.pyCode = FunLibrary.CVT(FunLibrary.ChkInput(this.tbName.Text));
			baseInfo.ID = int.Parse(this.hfRecID.Value);
			int array = 0;
			int.TryParse(this.tbArray.Text, out array);
			baseInfo.Array = array;
			string text = string.Empty;
			if (baseInfo._Name != this.hfTemp.Value)
			{
				if (this.hfType.Value == "1")
				{
					text = " DeptID=1 and ";
				}
				text = text + " _Name='" + baseInfo._Name + "'";
			}
			string str2;
			int num = dALBaseInfo.Update(this.hfTbName.Value, baseInfo, text, out str2);
			if (num == 0)
			{
				this.hfRecID.Value = baseInfo.ID.ToString();
				this.FillData();
				this.btnMod.Text = "修改";
				this.SetEnable();
				this.btnAdd.Enabled = true;
				this.btnDel.Enabled = true;
				str = "ChkID('" + this.hfRecID.Value + "');";
			}
			else
			{
				if (num == -1)
				{
					this.SysInfo("window.alert('" + str2 + "');$('tbName').select();");
					return;
				}
				this.SysInfo("window.alert('系统错误！请查看错误日志');$('tbName').select();");
				return;
			}
		}
		this.SysInfo(str);
	}

	protected void btnDel_Click(object sender, EventArgs e)
	{
		int iD = int.Parse(this.hfRecID.Value);
		DALBaseInfo dALBaseInfo = new DALBaseInfo();
		string empty = string.Empty;
		int num = dALBaseInfo.Delete(this.hfTbName.Value, iD, out empty);
		if (num == 0)
		{
			this.hfRecID.Value = "-1";
		}
		else if (num == -1)
		{
			this.SysInfo("window.alert('" + empty + "');");
		}
		else
		{
			this.SysInfo("window.alert('系统错误！请查看错误日志');");
		}
		this.FillData();
		this.hfRecID.Value = "-1";
		this.CleanText();
	}

	protected void btnShow_Click(object sender, EventArgs e)
	{
		if (this.hfRecID.Value != "-1")
		{
			DALBaseInfo dALBaseInfo = new DALBaseInfo();
			BaseInfo model = dALBaseInfo.GetModel(this.hfTbName.Value, int.Parse(this.hfRecID.Value));
			if (model != null)
			{
				this.tbName.Text = model._Name;
				this.hfTemp.Value = model._Name;
				this.tbArray.Text = model.Array.ToString();
			}
		}
	}

	protected void btnRef_Click(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.FillData();
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void tvBaseInfo_SelectedNodeChanged(object sender, EventArgs e)
	{
		this.lbName.Text = this.tvBaseInfo.SelectedNode.Text;
		int num = 0;
		int.TryParse(this.tvBaseInfo.SelectedNode.Value, out num);
		int num2 = num;
		if (num2 <= 31)
		{
			switch (num2)
			{
			case 1:
				this.hfTbName.Value = "InvoiceClass";
				this.hfType.Value = "";
				break;
			case 2:
				this.hfTbName.Value = "AreaList";
				this.hfType.Value = "";
				break;
			case 3:
				this.hfTbName.Value = "ChargeMode";
				this.hfType.Value = "";
				break;
			case 4:
				this.hfTbName.Value = "ContractType";
				this.hfType.Value = "";
				break;
			case 5:
			case 6:
			case 11:
			case 12:
			case 13:
			case 14:
			case 17:
			case 19:
			case 20:
			case 22:
				break;
			case 7:
				this.hfTbName.Value = "StockLocation";
				this.hfType.Value = "1";
				break;
			case 8:
				this.hfTbName.Value = "INStockReason";
				this.hfType.Value = "2";
				break;
			case 9:
				this.hfTbName.Value = "OUTStockReason";
				this.hfType.Value = "2";
				break;
			case 10:
				this.hfTbName.Value = "Quarters";
				this.hfType.Value = "";
				break;
			case 15:
				this.hfTbName.Value = "ProductAspect";
				this.hfType.Value = "";
				break;
			case 16:
				this.hfTbName.Value = "ProductAccessory";
				this.hfType.Value = "";
				break;
			case 18:
				this.hfTbName.Value = "TakeStyle";
				this.hfType.Value = "";
				break;
			case 21:
				this.hfTbName.Value = "CancelReason";
				this.hfType.Value = "";
				break;
			case 23:
				this.hfTbName.Value = "SatisfactionDegree";
				this.hfType.Value = "";
				break;
			case 24:
				this.hfTbName.Value = "VisitStyle";
				this.hfType.Value = "";
				break;
			default:
				if (num2 == 31)
				{
					this.hfTbName.Value = "CustomerFrom";
					this.hfType.Value = "";
				}
				break;
			}
		}
		else
		{
			switch (num2)
			{
			case 40:
				this.hfTbName.Value = "UnitList";
				this.hfType.Value = "";
				break;
			case 41:
				this.hfTbName.Value = "QtyType";
				this.hfType.Value = "";
				break;
			default:
				switch (num2)
				{
				case 55:
					this.hfTbName.Value = "TrackStyle";
					this.hfType.Value = "";
					break;
				case 56:
					this.hfTbName.Value = "TrackType";
					this.hfType.Value = "";
					break;
				case 57:
					this.hfTbName.Value = "CustomerStatus";
					this.hfType.Value = "";
					break;
				case 58:
					this.hfTbName.Value = "AllotReason";
					this.hfType.Value = "";
					break;
				}
				break;
			}
		}
		for (int i = 0; i < this.tvBaseInfo.Nodes.Count; i++)
		{
			if (this.tvBaseInfo.Nodes[i].Selected)
			{
				this.tvBaseInfo.SelectedNode.ImageUrl = "~/Public/Images/notice.gif";
			}
			else
			{
				this.tvBaseInfo.Nodes[i].ImageUrl = "~/Public/Images/folderclose.gif";
			}
		}
		this.FillData();
		this.hfRecID.Value = "-1";
	}
}
