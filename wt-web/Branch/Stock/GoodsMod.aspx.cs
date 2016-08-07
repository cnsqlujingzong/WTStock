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
using wt.OtherLibrary;

public partial class Branch_Stock_GoodsMod : Page, IRequiresSessionState
{
	
	private int id;

	private string ids;

	

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
				dataTable.Columns.Add(new DataColumn("RecID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("iFlag", typeof(int)));
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
				dataTable.Columns.Add(new DataColumn("RecID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("iFlag", typeof(int)));
				this.ViewState["List2"] = dataTable;
			}
			return (DataTable)this.ViewState["List2"];
		}
		set
		{
			this.ViewState["List2"] = value;
		}
	}

	public string Str_ID
	{
		get
		{
			return this.id.ToString();
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		int.TryParse(base.Request["id"], out this.id);
		this.ids = base.Request["ids"];
		if (this.id == 0 && this.ids == null)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			int userID = 0;
			int.TryParse((string)this.Session["Session_wtUserBID"], out userID);
			DALSys dALSys = new DALSys();
			DataTable dataTable = dALSys.GetLayoutDetail(1, int.Parse(this.Session["Session_wtBranchID"].ToString()), 2, 0, userID).Tables[0];
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
			DataTable dataTable2 = DALCommon.GetList_HL(0, "GoodsClass", "", 0, 0, "", " ID Asc", out num2).Tables[0];
			OtherFunction.BindDrpClass("-1", dataTable2, "├", "0", this.slGdsClass);
			OtherFunction.BindProductBrand(this.ddlBrand);
			OtherFunction.BindUnit(this.ddlUnit);
			DALGoods dALGoods = new DALGoods();
			if (this.id == 0)
			{
				this.id = dALGoods.GetID(this.ids);
			}
			GoodsInfo model = dALGoods.GetModel(this.id);
			if (model != null)
			{
				OtherFunction.BindSupplier(this.ddlProvider, "bSupplier=1 and bStop=0 and [ID]=" + model.ProvID.ToString());
				this.ddlProvider.Items.Remove(new ListItem("新建...", "0"));
				this.tbName.Text = model._Name;
				this.hfTemp.Value = (this.tbGdsNO.Text = model.GoodsNO);
				this.hfGoodsUnit.Value = model.GoodsUnitID.ToString();
				this.tbGdsClass.Value = model.Class;
				for (int i = 0; i < this.slGdsClass.Items.Count; i++)
				{
					if (this.slGdsClass.Items[i].Value == model.ClassID.ToString())
					{
						this.slGdsClass.Items[i].Selected = true;
						break;
					}
				}
				for (int i = 0; i < this.ddlAttr.Items.Count; i++)
				{
					if (this.ddlAttr.Items[i].Text == model.Attr)
					{
						this.ddlAttr.Items[i].Selected = true;
						break;
					}
				}
				if (model.Attr == "耗材")
				{
					this.lbMain.Text = "寿命";
				}
				this.tbSpec.Text = model.Spec;
				for (int i = 0; i < this.slGdsClass.Items.Count; i++)
				{
					if (this.slGdsClass.Items[i].Value == model.ClassID.ToString())
					{
						this.slGdsClass.Items[i].Selected = true;
						break;
					}
				}
				for (int i = 0; i < this.ddlBrand.Items.Count; i++)
				{
					if (this.ddlBrand.Items[i].Value == model.BrandID.ToString())
					{
						this.ddlBrand.Items[i].Selected = true;
						break;
					}
				}
				for (int i = 0; i < this.ddlUnit.Items.Count; i++)
				{
					if (this.ddlUnit.Items[i].Value == model.UnitID.ToString())
					{
						this.ddlUnit.Items[i].Selected = true;
						break;
					}
				}
				this.tbPriceDetail.Text = model.PriceDetail.ToString();
				this.tbPriceCost.Text = model.PriceCost.ToString();
				this.tbPriceInner.Text = model.PriceInner.ToString();
				this.tbPriceWholeSale1.Text = model.PriceWholesale1.ToString();
				this.tbPriceWholeSale2.Text = model.PriceWholesale2.ToString();
				this.tbPriceWholeSale3.Text = model.PriceWholesale3.ToString();
				this.tbBarCode.Text = model.BarCode;
				this.tbProt.Value = model.MainTenancePeriod;
				this.ddlCostMode.Items.FindByValue(model.CostMode.ToString()).Selected = true;
				this.tbForProducts.Text = model.ForProducts;
				this.tbuserdef1.Text = model.userdef1;
				this.tbuserdef2.Text = model.userdef2;
				this.tbuserdef3.Text = model.userdef3;
				this.tbuserdef4.Text = model.userdef4;
				this.tbuserdef5.Text = model.userdef5;
				this.tbuserdef6.Text = model.userdef6;
				for (int i = 0; i < this.ddlStock.Items.Count; i++)
				{
					if (this.ddlStock.Items[i].Value == model.StockID.ToString())
					{
						this.ddlStock.Items[i].Selected = true;
						break;
					}
				}
				for (int i = 0; i < this.ddlProvider.Items.Count; i++)
				{
					if (this.ddlProvider.Items[i].Value == model.ProvID.ToString())
					{
						this.ddlProvider.Items[i].Selected = true;
						break;
					}
				}
				if (model.Valid > 0)
				{
					this.tbValid.Text = model.Valid.ToString();
				}
				if (num > 0)
				{
					DALRight dALRight = new DALRight();
					if (dALRight.GetRight(num, "jc_r12"))
					{
						this.tbPriceCost.Visible = false;
						this.hfPurCost.Value = "1";
					}
					if (dALRight.GetRight(num, "jc_r13"))
					{
						this.ddlProvider.Visible = false;
					}
				}
				this.tbRemark.Text = model.Remark;
				this.cbIncrement.Checked = model.bIncrement;
				this.cbStock.Checked = model.bStock;
				this.cbStop.Checked = model.bStop;
				this.cbSNTrack.Checked = model.bSNTrack;
				this.hfImgName.Value = model.PicPath;
				if (model.PicPath != string.Empty)
				{
					this.gdiv.InnerHtml = "<img src=\"../../Headquarters/Images/" + model.PicPath + "\" width=\"130\" style=\"margin-top:5px;\" />";
				}
				dataTable2 = DALCommon.GetDataList("ck_goodsunit", "", " bBase=0 and GoodsID=" + this.id.ToString()).Tables[0];
				if (dataTable2.Rows.Count > 0)
				{
					DataTable dataTable3 = this.GridViewSource1;
					for (int i = 0; i < dataTable2.Rows.Count; i++)
					{
						DataRow dataRow = dataTable3.NewRow();
						dataRow[0] = i.ToString();
						dataRow[1] = dataTable2.Rows[i]["UnitID"].ToString();
						dataRow[2] = dataTable2.Rows[i]["_Name"].ToString();
						dataRow[3] = dataTable2.Rows[i]["UnitRelation"].ToString();
						dataRow[4] = dataTable2.Rows[i]["BarCode"].ToString();
						dataRow[5] = dataTable2.Rows[i]["PriceDetail"].ToString();
						dataRow[6] = dataTable2.Rows[i]["PriceCost"].ToString();
						dataRow[7] = dataTable2.Rows[i]["PriceInner"].ToString();
						dataRow[8] = dataTable2.Rows[i]["PriceWholesale1"].ToString();
						dataRow[9] = dataTable2.Rows[i]["PriceWholesale2"].ToString();
						dataRow[10] = dataTable2.Rows[i]["PriceWholesale3"].ToString();
						dataRow[11] = int.Parse(dataTable2.Rows[i]["ID"].ToString());
						dataRow[12] = 1;
						dataTable3.Rows.Add(dataRow);
					}
					this.BindData1();
				}
				dataTable2 = DALCommon.GetDataList("ck_dismounting", "", " DisMountingID=" + this.id.ToString()).Tables[0];
				if (dataTable2.Rows.Count > 0)
				{
					DataTable dataTable3 = this.GridViewSource2;
					for (int i = 0; i < dataTable2.Rows.Count; i++)
					{
						DataRow dataRow = dataTable3.NewRow();
						dataRow[0] = i.ToString();
						dataRow[1] = dataTable2.Rows[i]["GoodsNO"].ToString();
						dataRow[2] = dataTable2.Rows[i]["_Name"].ToString();
						dataRow[3] = dataTable2.Rows[i]["Attr"].ToString();
						dataRow[4] = dataTable2.Rows[i]["Spec"].ToString();
						dataRow[5] = dataTable2.Rows[i]["ProductBrand"].ToString();
						dataRow[6] = dataTable2.Rows[i]["MaintenancePeriod"].ToString();
						dataRow[7] = dataTable2.Rows[i]["Qty"].ToString();
						dataRow[8] = int.Parse(dataTable2.Rows[i]["ID"].ToString());
						dataRow[9] = 1;
						dataTable3.Rows.Add(dataRow);
					}
					this.BindData2();
				}
				this.ddlCostMode.Enabled = false;
			}
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (this.hfPurCost.Value == "1")
		{
			e.Row.Cells[5].Visible = false;
		}
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
}
