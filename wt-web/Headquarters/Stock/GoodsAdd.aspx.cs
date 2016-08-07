using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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

public partial class Headquarters_Stock_GoodsAdd : Page, IRequiresSessionState
{
	private string f;

	private string d;

	private int classid;

	private string strstkloc;

	private DataTable GridViewSource1
	{
		get
		{
			if (this.ViewState["List1"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("ID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("单位ID", typeof(string)));
				dataTable.Columns.Add(new DataColumn("名称", typeof(string)));
				dataTable.Columns.Add(new DataColumn("关系", typeof(string)));
				dataTable.Columns.Add(new DataColumn("条码", typeof(string)));
				dataTable.Columns.Add(new DataColumn("零售价", typeof(string)));
				dataTable.Columns.Add(new DataColumn("进货价", typeof(string)));
				dataTable.Columns.Add(new DataColumn("内部价", typeof(string)));
				dataTable.Columns.Add(new DataColumn("旧货价", typeof(string)));
				dataTable.Columns.Add(new DataColumn("替代价", typeof(string)));
				dataTable.Columns.Add(new DataColumn("列表价", typeof(string)));
				this.ViewState["List1"] = dataTable;
			}
			return (DataTable)this.ViewState["List1"];
		}
		set
		{
			this.ViewState["List1"] = value;
		}
	}

	private DataTable GridViewSource2
	{
		get
		{
			if (this.ViewState["List2"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("ID", typeof(string)));
				dataTable.Columns.Add(new DataColumn("编号", typeof(string)));
				dataTable.Columns.Add(new DataColumn("名称", typeof(string)));
				dataTable.Columns.Add(new DataColumn("属性", typeof(string)));
				dataTable.Columns.Add(new DataColumn("规格", typeof(string)));
				dataTable.Columns.Add(new DataColumn("品牌", typeof(string)));
				dataTable.Columns.Add(new DataColumn("保修期", typeof(string)));
				dataTable.Columns.Add(new DataColumn("定额数量", typeof(string)));
				this.ViewState["List2"] = dataTable;
			}
			return (DataTable)this.ViewState["List2"];
		}
		set
		{
			this.ViewState["List2"] = value;
		}
	}

	private DataTable GridViewSource3
	{
		get
		{
			if (this.ViewState["List3"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("ID", typeof(string)));
				dataTable.Columns.Add(new DataColumn("名称", typeof(string)));
				dataTable.Columns.Add(new DataColumn("仓位", typeof(string)));
				dataTable.Columns.Add(new DataColumn("仓位ID", typeof(string)));
				dataTable.Columns.Add(new DataColumn("仓库ID", typeof(string)));
				this.ViewState["List3"] = dataTable;
			}
			return (DataTable)this.ViewState["List3"];
		}
		set
		{
			this.ViewState["List3"] = value;
		}
	}

	public string Str_F
	{
		get
		{
			return this.d;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		this.f = base.Request["f"];
		int.TryParse(base.Request["classid"], out this.classid);
		if (this.f == null || this.f == "")
		{
			this.f = "";
			this.d = "";
		}
		else if (this.f == "2")
		{
			this.d = "2";
		}
		else
		{
			this.d = "1";
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "ck_r3"))
				{
					this.btnAdd.Enabled = false;
					this.btnImgDel.Enabled = false;
					this.btnImg.Disabled = true;
				}
			}
			int userID = 0;
			int.TryParse((string)this.Session["Session_wtUserID"], out userID);
			DALSys dALSys = new DALSys();
			DataTable dataTable = dALSys.GetLayoutDetail(1, 1, 1, 0, userID).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				DataRow[] array = dataTable.Select("FieldName='userdef1'");
				if (array.Length > 0)
				{
					this.lbuserdef1.Text = array[0]["TitleName"].ToString().Trim();
				}
				DataRow[] array2 = dataTable.Select("FieldName='userdef2'");
				if (array2.Length > 0)
				{
					this.lbuserdef2.Text = array2[0]["TitleName"].ToString().Trim();
				}
				DataRow[] array3 = dataTable.Select("FieldName='userdef3'");
				if (array3.Length > 0)
				{
					this.lbuserdef3.Text = array3[0]["TitleName"].ToString().Trim();
				}
				DataRow[] array4 = dataTable.Select("FieldName='userdef4'");
				if (array4.Length > 0)
				{
					this.lbuserdef4.Text = array4[0]["TitleName"].ToString().Trim();
				}
				DataRow[] array5 = dataTable.Select("FieldName='userdef5'");
				if (array5.Length > 0)
				{
					this.lbuserdef5.Text = array5[0]["TitleName"].ToString().Trim();
				}
				DataRow[] array6 = dataTable.Select("FieldName='userdef6'");
				if (array6.Length > 0)
				{
					this.lbuserdef6.Text = array6[0]["TitleName"].ToString().Trim();
				}
			}
			int num2 = 0;
			this.slGdsClass.Items.Add(new ListItem("", "0"));
			DataTable dt = DALCommon.GetList_HL(0, "GoodsClass", "", 0, 0, "", " Array Asc", out num2).Tables[0];
			OtherFunction.BindDrpClass("-1", dt, "├", "0", this.slGdsClass);
			for (int i = 0; i < this.slGdsClass.Items.Count; i++)
			{
				if (this.slGdsClass.Items[i].Value == this.classid.ToString())
				{
					this.slGdsClass.Items[i].Selected = true;
					this.tbGdsClass.Value = this.slGdsClass.Items[i].Text.Replace("├", "").Replace("│", "").Replace(HttpUtility.HtmlDecode("&nbsp;&nbsp;"), "");
					break;
				}
			}
			DALSysParm dALSysParm = new DALSysParm();
			SysParmInfo model = dALSysParm.GetModel(1);
			if (model.CostModel != 0)
			{
				this.ddlCostMode.SelectedValue = model.CostModel.ToString();
			}
			else
			{
				this.ddlCostMode.Items.Insert(0, new ListItem("", ""));
			}
			OtherFunction.BindUnit(this.ddlUnit);
			OtherFunction.BindStock(this.ddlStock, " DeptID=1 and bStop=0 ");
			this.BindStockList();
			if (this.f != "")
			{
				this.ddlUnit.Items.Remove(new ListItem("新建...", "0"));
				this.ddlStock.Items.Remove(new ListItem("新建...", "0"));
			}
		}
	}

	protected void BindStockList()
	{
		int num = 0;
		DataTable dataTable = DALCommon.GetList_HL(0, "StockList", "[ID],[_Name]", 0, 0, "DeptID=1 and bStop=0", " [ID] Desc", out num).Tables[0];
		DataTable gridViewSource = this.GridViewSource3;
		for (int i = 0; i < dataTable.Rows.Count; i++)
		{
			DataRow dataRow = gridViewSource.NewRow();
			dataRow[0] = i.ToString();
			dataRow[1] = dataTable.Rows[i]["_Name"].ToString();
			dataRow[2] = "";
			dataRow[3] = "";
			dataRow[4] = dataTable.Rows[i]["ID"].ToString();
			gridViewSource.Rows.Add(dataRow);
		}
		this.BindData3();
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		GoodsInfo goodsInfo = new GoodsInfo();
		goodsInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
		goodsInfo.pyCode = FunLibrary.CVT(FunLibrary.ChkInput(this.tbName.Text));
		goodsInfo.GoodsNO = FunLibrary.ChkInput(this.tbGdsNO.Text);
		goodsInfo.ClassID = new int?(int.Parse(this.slGdsClass.Items[this.slGdsClass.SelectedIndex].Value));
		goodsInfo.Attr = FunLibrary.ChkInput(this.ddlAttr.SelectedItem.Text);
		goodsInfo.Spec = FunLibrary.ChkInput(this.tbSpec.Text);
		int value = 0;
		int.TryParse(this.hfBrand.Value, out value);
		goodsInfo.BrandID = new int?(value);
		goodsInfo.MainTenancePeriod = FunLibrary.ChkInput(this.tbProt.Value);
		goodsInfo.CostMode = int.Parse(this.ddlCostMode.SelectedValue);
		goodsInfo.ForProducts = FunLibrary.ChkInput(this.tbForProducts.Text);
		goodsInfo.StockID = new int?(int.Parse(this.ddlStock.SelectedValue));
		int value2 = 0;
		int.TryParse(this.hfSupplier.Value, out value2);
		goodsInfo.ProvID = new int?(value2);
		int value3 = 0;
		int.TryParse(this.tbValid.Text, out value3);
		goodsInfo.Valid = new int?(value3);
		goodsInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		goodsInfo.bIncrement = this.cbIncrement.Checked;
		goodsInfo.bStock = this.cbStock.Checked;
		goodsInfo.bStop = this.cbStop.Checked;
		goodsInfo.bSNTrack = this.cbSNTrack.Checked;
		goodsInfo.PicPath = this.hfImgName.Value;
		goodsInfo.userdef1 = FunLibrary.ChkInput(this.tbuserdef1.Text);
		goodsInfo.userdef2 = FunLibrary.ChkInput(this.tbuserdef2.Text);
		goodsInfo.userdef3 = FunLibrary.ChkInput(this.tbuserdef3.Text);
		goodsInfo.userdef4 = FunLibrary.ChkInput(this.tbuserdef4.Text);
		goodsInfo.userdef5 = FunLibrary.ChkInput(this.tbuserdef5.Text);
		goodsInfo.userdef6 = FunLibrary.ChkInput(this.tbuserdef6.Text);
        goodsInfo.PCB = FunLibrary.ChkInput(this.txt_pcb.Text);
		List<GoodsUnitInfo> list = new List<GoodsUnitInfo>();
		GoodsUnitInfo goodsUnitInfo = new GoodsUnitInfo();
		decimal num = 0m;
		goodsUnitInfo.UnitID = new int?(int.Parse(this.ddlUnit.SelectedValue));
		goodsUnitInfo.UnitRelation = new decimal?(1m);
		goodsUnitInfo.BarCode = FunLibrary.ChkInput(this.tbBarCode.Text);
		goodsUnitInfo.bBase = true;
		decimal.TryParse(this.tbPriceDetail.Text, out num);
		goodsUnitInfo.PriceDetail = new decimal?(num);
		decimal.TryParse(this.tbPriceCost.Text, out num);
		goodsUnitInfo.PriceCost = new decimal?(num);
		decimal.TryParse(this.tbPriceInner.Text, out num);
		goodsUnitInfo.PriceInner = new decimal?(num);
		decimal.TryParse(this.tbPriceWholeSale1.Text, out num);
		goodsUnitInfo.PriceWholesale1 = new decimal?(num);
		decimal.TryParse(this.tbPriceWholeSale2.Text, out num);
		goodsUnitInfo.PriceWholesale2 = new decimal?(num);
		decimal.TryParse(this.tbPriceWholeSale3.Text, out num);
		goodsUnitInfo.PriceWholesale3 = new decimal?(num);
		decimal.TryParse(this.tbPriceLow.Text, out num);
		goodsUnitInfo.LowPrice = num;
		list.Add(goodsUnitInfo);
		DataTable dataTable = this.GridViewSource1;
		if (dataTable.Rows.Count > 0)
		{
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				GoodsUnitInfo goodsUnitInfo2 = new GoodsUnitInfo();
				goodsUnitInfo2.UnitID = new int?(int.Parse(dataTable.Rows[i]["单位ID"].ToString()));
				decimal.TryParse(dataTable.Rows[i]["关系"].ToString(), out num);
				goodsUnitInfo2.UnitRelation = new decimal?(num);
				goodsUnitInfo2.BarCode = dataTable.Rows[i]["条码"].ToString();
				goodsUnitInfo2.bBase = false;
				decimal.TryParse(dataTable.Rows[i]["零售价"].ToString(), out num);
				goodsUnitInfo2.PriceDetail = new decimal?(num);
				decimal.TryParse(dataTable.Rows[i]["进货价"].ToString(), out num);
				goodsUnitInfo2.PriceCost = new decimal?(num);
				decimal.TryParse(dataTable.Rows[i]["内部价"].ToString(), out num);
				goodsUnitInfo2.PriceInner = new decimal?(num);
				decimal.TryParse(dataTable.Rows[i]["旧货价"].ToString(), out num);
				goodsUnitInfo2.PriceWholesale1 = new decimal?(num);
				decimal.TryParse(dataTable.Rows[i]["替代价"].ToString(), out num);
				goodsUnitInfo2.PriceWholesale2 = new decimal?(num);
				decimal.TryParse(dataTable.Rows[i]["列表价"].ToString(), out num);
				goodsUnitInfo2.PriceWholesale3 = new decimal?(num);
				list.Add(goodsUnitInfo2);
			}
		}
		goodsInfo.GoodsUnitInfos = list;
		dataTable.Clear();
		dataTable = this.GridViewSource2;
		if (dataTable.Rows.Count > 0)
		{
			List<DisMountingInfo> list2 = new List<DisMountingInfo>();
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				DisMountingInfo disMountingInfo = new DisMountingInfo();
				disMountingInfo.GoodsID = int.Parse(dataTable.Rows[i]["ID"].ToString());
				decimal.TryParse(dataTable.Rows[i]["定额数量"].ToString(), out num);
				disMountingInfo.Qty = num;
				list2.Add(disMountingInfo);
			}
			goodsInfo.DisMountingInfos = list2;
		}
		dataTable.Clear();
		dataTable = this.GridViewSource3;
		if (dataTable.Rows.Count > 0)
		{
			List<StockDeptInfo> list3 = new List<StockDeptInfo>();
			int num2 = 0;
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				StockDeptInfo stockDeptInfo = new StockDeptInfo();
				stockDeptInfo.DeptID = 1;
				int.TryParse(dataTable.Rows[i]["仓库ID"].ToString(), out num2);
				stockDeptInfo.StockID = num2;
				int.TryParse(dataTable.Rows[i]["仓位ID"].ToString(), out num2);
				stockDeptInfo.StockLocID = num2;
				if (num2 > 0)
				{
					list3.Add(stockDeptInfo);
				}
			}
			goodsInfo.StockDeptInfos = list3;
		}
		DALGoods dALGoods = new DALGoods();
		string str;
		int num4;
		int num3 = dALGoods.Add(goodsInfo, this.cbsys.Checked, out str, out num4);
		if (num3 == 0)
		{
			if (this.f == "")
			{
				if (this.cbClose.Checked)
				{
					this.SysInfo("parent.CloseDialog('1');");
				}
				else
				{
					this.SysInfo("ChkTab('1');$('tbName').value='';$('tbName').select();");
					this.ClearText();
				}
			}
			else if (this.f == "2")
			{
				this.SysInfo("parent.iframeDialog1.$(\"btnClr\").click();parent.CloseDialog2();");
			}
			else
			{
				this.SysInfo("parent.iframeDialog.$(\"btnClr\").click();parent.CloseDialog1();");
			}
		}
		else if (num3 == -1)
		{
			this.SysInfo("window.alert(\"" + str + "\");");
		}
		else
		{
			this.SysInfo("window.alert('系统错误！请查看错误日志');");
		}
	}

	protected void ClearText()
	{
		this.tbBarCode.Text = (this.tbForProducts.Text = (this.tbGdsClass.Value = (this.tbGdsNO.Text = (this.tbName.Text = (this.tbPriceCost.Text = (this.tbPriceDetail.Text = (this.tbPriceInner.Text = (this.tbPriceWholeSale1.Text = string.Empty))))))));
		this.tbPriceWholeSale2.Text = (this.tbPriceWholeSale3.Text = (this.tbProt.Value = (this.tbRemark.Text = (this.tbSpec.Text = (this.tbValid.Text = string.Empty)))));
		this.cbIncrement.Checked = false;
		this.cbStock.Checked = false;
		this.cbStop.Checked = false;
		this.ddlAttr.ClearSelection();
		this.ddlAttr.Items.FindByText("").Selected = true;
		this.ddlUnit.ClearSelection();
		this.ddlUnit.Items.FindByText("").Selected = true;
		this.ddlStock.ClearSelection();
		this.ddlStock.Items.FindByText("").Selected = true;
		this.GridViewSource1.Clear();
		this.BindData1();
		this.GridViewSource2.Clear();
		this.BindData2();
		this.GridViewSource3.Clear();
		this.BindData3();
		this.tbuserdef1.Text = (this.tbuserdef2.Text = (this.tbuserdef3.Text = (this.tbuserdef4.Text = (this.tbuserdef5.Text = (this.tbuserdef6.Text = "")))));
		this.BindStockList();
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "u" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('u" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "c" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
	}

	protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			this.strstkloc = e.Row.Cells[3].Text.Replace("&nbsp;", "");
			e.Row.Attributes.Add("id", "s" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkID3('s",
				e.Row.Cells[0].Text,
				"');$(\"hfStockLoc\").value='",
				this.strstkloc,
				"'"
			}));
			e.Row.Attributes.Add("ondblclick", "ModStockLoc();");
			e.Row.Cells[1].Attributes.Add("id", "ts" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}

	private void BindData1()
	{
		this.GridView1.DataSource = this.GridViewSource1;
		this.GridView1.DataBind();
	}

	private void BindData2()
	{
		this.GridView2.DataSource = this.GridViewSource2;
		this.GridView2.DataBind();
	}

	private void BindData3()
	{
		this.GridView3.DataSource = this.GridViewSource3;
		this.GridView3.DataBind();
	}

	protected void CollectData()
	{
		for (int i = 0; i < this.GridView2.Rows.Count; i++)
		{
			TextBox textBox = this.GridView2.Rows[i].FindControl("tbQty") as TextBox;
			DataTable gridViewSource = this.GridViewSource2;
			gridViewSource.Rows[i][7] = FunLibrary.ChkInput(textBox.Text);
		}
	}

	protected void btnAddUnit_Click(object sender, EventArgs e)
	{
		DataTable gridViewSource = this.GridViewSource1;
		DataRow dataRow = gridViewSource.NewRow();
		string[] array = this.hfMUnit.Value.Split(new char[]
		{
			','
		});
		for (int i = 0; i < gridViewSource.Rows.Count; i++)
		{
			if (gridViewSource.Rows[i]["名称"].ToString() == array[1].ToString())
			{
				this.SysInfoUnit("window.alert(\"操作失败！单位名称已存在\");ChkID('" + gridViewSource.Rows[i]["ID"].ToString() + "');");
				return;
			}
		}
		dataRow[0] = gridViewSource.Rows.Count.ToString();
		dataRow[1] = array[0].ToString();
		dataRow[2] = array[1].ToString();
		dataRow[3] = array[2].ToString();
		dataRow[4] = array[3].ToString();
		dataRow[5] = array[4].ToString();
		dataRow[6] = array[5].ToString();
		dataRow[7] = array[6].ToString();
		dataRow[8] = array[7].ToString();
		dataRow[9] = array[8].ToString();
		dataRow[10] = array[9].ToString();
		gridViewSource.Rows.Add(dataRow);
		this.BindData1();
	}

	protected void btnModUnit_Click(object sender, EventArgs e)
	{
		DataTable gridViewSource = this.GridViewSource1;
		int index;
		int.TryParse(this.hfRecID.Value.Replace("u", ""), out index);
		string[] array = this.hfMUnit.Value.Split(new char[]
		{
			','
		});
		for (int i = 0; i < gridViewSource.Rows.Count; i++)
		{
			if (gridViewSource.Rows[i]["ID"].ToString() != this.hfRecID.Value.Replace("u", ""))
			{
				if (gridViewSource.Rows[i]["名称"].ToString() == array[1].ToString())
				{
					this.SysInfoUnit("window.alert(\"操作失败！单位名称已存在\");ChkID('" + gridViewSource.Rows[i]["ID"].ToString() + "');");
					return;
				}
			}
		}
		gridViewSource.Rows[index][1] = array[0].ToString();
		gridViewSource.Rows[index][2] = array[1].ToString();
		gridViewSource.Rows[index][3] = array[2].ToString();
		gridViewSource.Rows[index][4] = array[3].ToString();
		gridViewSource.Rows[index][5] = array[4].ToString();
		gridViewSource.Rows[index][6] = array[5].ToString();
		gridViewSource.Rows[index][7] = array[6].ToString();
		gridViewSource.Rows[index][8] = array[7].ToString();
		gridViewSource.Rows[index][9] = array[8].ToString();
		gridViewSource.Rows[index][10] = array[9].ToString();
		this.BindData1();
		this.SysInfoUnit("ChkID('" + this.hfRecID.Value + "');");
	}

	protected void btnDelUnit_Click(object sender, EventArgs e)
	{
		if (!(this.hfRecID.Value == "-1"))
		{
			DataTable gridViewSource = this.GridViewSource1;
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				if (gridViewSource.Rows[i]["ID"].ToString() == this.hfRecID.Value.Replace("u", ""))
				{
					gridViewSource.Rows.RemoveAt(i);
				}
			}
			this.BindData1();
			this.hfRecID.Value = "-1";
		}
	}

	protected void btnShowUnit_Click(object sender, EventArgs e)
	{
		DataTable gridViewSource = this.GridViewSource1;
		DataRow[] array = gridViewSource.Select(" ID= " + this.hfRecID.Value.Replace("u", ""));
		if (array.Length > 0)
		{
			this.hfMUnit.Value = array[0]["单位ID"].ToString() + ",";
			HiddenField expr_72 = this.hfMUnit;
			expr_72.Value = expr_72.Value + array[0]["名称"].ToString() + ",";
			HiddenField expr_A0 = this.hfMUnit;
			expr_A0.Value = expr_A0.Value + array[0]["关系"].ToString() + ",";
			HiddenField expr_CE = this.hfMUnit;
			expr_CE.Value = expr_CE.Value + array[0]["条码"].ToString() + ",";
			HiddenField expr_FC = this.hfMUnit;
			expr_FC.Value = expr_FC.Value + array[0]["零售价"].ToString() + ",";
			HiddenField expr_12A = this.hfMUnit;
			expr_12A.Value = expr_12A.Value + array[0]["进货价"].ToString() + ",";
			HiddenField expr_158 = this.hfMUnit;
			expr_158.Value = expr_158.Value + array[0]["内部价"].ToString() + ",";
			HiddenField expr_186 = this.hfMUnit;
			expr_186.Value = expr_186.Value + array[0]["旧货价"].ToString() + ",";
			HiddenField expr_1B4 = this.hfMUnit;
			expr_1B4.Value = expr_1B4.Value + array[0]["替代价"].ToString() + ",";
			HiddenField expr_1E2 = this.hfMUnit;
			expr_1E2.Value += array[0]["列表价"].ToString();
		}
		this.BindData1();
		this.SysInfoUnit("ChkID('" + this.hfRecID.Value + "');");
	}

	protected void SysInfoUnit(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel3, this.UpdatePanel3.GetType(), "SysInfo", str, true);
	}

	protected void btnSure_Click(object sender, EventArgs e)
	{
		string str = FunLibrary.ChkInput(this.tbCon.Text.Trim());
		DataTable gridViewSource = this.GridViewSource2;
		DataTable dataTable = DALCommon.GetDataList("ck_goods", "", this.ddlSchFld.SelectedValue + "='" + str + "'").Tables[0];
		string text = "$('" + this.tbCon.ClientID + "').select();";
		if (dataTable.Rows.Count > 0)
		{
			this.CollectData();
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				bool flag = true;
				for (int j = 0; j < gridViewSource.Rows.Count; j++)
				{
					if (gridViewSource.Rows[j]["ID"].ToString() == dataTable.Rows[i]["ID"].ToString())
					{
						flag = false;
					}
				}
				if (flag)
				{
					DataRow dataRow = gridViewSource.NewRow();
					dataRow[0] = dataTable.Rows[i]["ID"].ToString();
					dataRow[1] = dataTable.Rows[i]["GoodsNO"].ToString();
					dataRow[2] = dataTable.Rows[i]["_Name"].ToString();
					dataRow[3] = dataTable.Rows[i]["Attr"].ToString();
					dataRow[4] = dataTable.Rows[i]["Spec"].ToString();
					dataRow[5] = dataTable.Rows[i]["ProductBrand"].ToString();
					dataRow[6] = dataTable.Rows[i]["MaintenancePeriod"].ToString();
					dataRow[7] = "1";
					gridViewSource.Rows.Add(dataRow);
				}
			}
			this.BindData2();
		}
		else
		{
			text += "window.alert('操作失败！没有该产品信息');";
		}
		this.SysInfoDis(text);
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
		DataTable gridViewSource = this.GridViewSource2;
		if (text != string.Empty)
		{
			DataTable dataTable = DALCommon.GetDataList("ck_goods", "", " [ID] in(" + text + ") ").Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.CollectData();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					bool flag = true;
					for (int j = 0; j < gridViewSource.Rows.Count; j++)
					{
						if (gridViewSource.Rows[j]["ID"].ToString() == dataTable.Rows[i]["ID"].ToString())
						{
							flag = false;
						}
					}
					if (flag)
					{
						DataRow dataRow = gridViewSource.NewRow();
						dataRow[0] = dataTable.Rows[i]["ID"].ToString();
						dataRow[1] = dataTable.Rows[i]["GoodsNO"].ToString();
						dataRow[2] = dataTable.Rows[i]["_Name"].ToString();
						dataRow[3] = dataTable.Rows[i]["Attr"].ToString();
						dataRow[4] = dataTable.Rows[i]["Spec"].ToString();
						dataRow[5] = dataTable.Rows[i]["ProductBrand"].ToString();
						dataRow[6] = dataTable.Rows[i]["MaintenancePeriod"].ToString();
						dataRow[7] = "1";
						gridViewSource.Rows.Add(dataRow);
					}
				}
				this.BindData2();
			}
		}
		this.SysInfoDis("$('btnSltGds').focus();");
	}

	protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		this.CollectData();
		this.GridViewSource2.Rows[e.RowIndex].Delete();
		this.BindData2();
	}

	protected void SysInfoDis(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel4, this.UpdatePanel4.GetType(), "SysInfo", str, true);
	}

	protected void btnModStockLoc_Click(object sender, EventArgs e)
	{
		DataTable gridViewSource = this.GridViewSource3;
		int index;
		int.TryParse(this.hfRecID3.Value.Replace("s", ""), out index);
		string[] array = this.hfStockLoc.Value.Split(new char[]
		{
			','
		});
		gridViewSource.Rows[index][3] = array[0].ToString();
		gridViewSource.Rows[index][2] = array[1].ToString();
		this.BindData3();
		this.SysInfoStockLoc("ChkID3('" + this.hfRecID.Value + "');");
	}

	protected void btnDelStkl_Click(object sender, EventArgs e)
	{
		if (!(this.hfRecID3.Value == "-1"))
		{
			DataTable gridViewSource = this.GridViewSource3;
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				if (gridViewSource.Rows[i]["ID"].ToString() == this.hfRecID3.Value.Replace("s", ""))
				{
					gridViewSource.Rows[i][2] = "";
					gridViewSource.Rows[i][3] = "";
				}
			}
			this.BindData3();
			this.hfRecID3.Value = "-1";
		}
	}

	protected void SysInfoStockLoc(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "SysInfo", str, true);
	}

	protected void btnRefBrand_Click(object sender, EventArgs e)
	{
		if (this.hfBrand.Value != string.Empty)
		{
		}
	}

	protected void btnRefUnit_Click(object sender, EventArgs e)
	{
		if (this.hfUnit.Value != string.Empty)
		{
			OtherFunction.BindUnit(this.ddlUnit);
			this.ddlUnit.ClearSelection();
			this.ddlUnit.Items.FindByText(this.hfUnit.Value).Selected = true;
		}
	}

	protected void btnRefStock_Click(object sender, EventArgs e)
	{
		if (this.hfStock.Value != string.Empty)
		{
			OtherFunction.BindStock(this.ddlStock, " DeptID=1 and bStop=0");
			this.ddlStock.ClearSelection();
			this.ddlStock.Items.FindByText(this.hfStock.Value).Selected = true;
		}
	}

	protected void btnRefSupplier_Click(object sender, EventArgs e)
	{
		if (this.hfSupplier.Value != string.Empty)
		{
		}
	}

	protected void btnImgDel_Click(object sender, EventArgs e)
	{
		if (this.hfImgName.Value != "")
		{
			string path = base.Server.MapPath("../Images") + "\\" + this.hfImgName.Value;
			File.Delete(path);
			this.SysInfo("ChkImg();");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
