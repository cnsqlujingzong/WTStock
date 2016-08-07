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

public partial class Headquarters_Services_AddM : Page, IRequiresSessionState
{
	private int id;

	private DataTable GridViewSourceM
	{
		get
		{
			if (this.ViewState["ListM"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("GoodsNO", typeof(string)));
				dataTable.Columns.Add(new DataColumn("_Name", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Spec", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ProductBrand", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Unit", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Qty", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Price", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Total", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("SN", typeof(string)));
				dataTable.Columns.Add(new DataColumn("MainTenancePeriod", typeof(string)));
				dataTable.Columns.Add(new DataColumn("PeriodEndDate", typeof(string)));
				dataTable.Columns.Add(new DataColumn("ChargeStyle", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Remark", typeof(string)));
				dataTable.Columns.Add(new DataColumn("GoodsID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("UnitID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("RecID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("iFlag", typeof(int)));
				dataTable.Columns.Add(new DataColumn("OutSourcing", typeof(bool)));
				dataTable.Columns.Add(new DataColumn("OutCostPrice", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("TaxRate", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("TaxAmount", typeof(decimal)));
				this.ViewState["ListM"] = dataTable;
			}
			return (DataTable)this.ViewState["ListM"];
		}
		set
		{
			this.ViewState["ListM"] = value;
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
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "gd_r9"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			this.AddEmptyM();
			DataTable dataTable = DALCommon.GetDataList("fw_services", "CustomerID", " [ID]=" + this.id).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.hfCusID.Value = dataTable.Rows[0]["CustomerID"].ToString();
			}
		}
	}

	private void AddEmptyM()
	{
		DataTable gridViewSourceM = this.GridViewSourceM;
		DataRow dataRow = gridViewSourceM.NewRow();
		dataRow[0] = "";
		dataRow[1] = "";
		dataRow[2] = "";
		dataRow[3] = "";
		dataRow[4] = "";
		dataRow[5] = 0;
		dataRow[6] = 0;
		dataRow[7] = 0;
		dataRow[8] = "";
		dataRow[9] = "";
		dataRow[10] = "";
		dataRow[11] = "";
		dataRow[12] = "";
		dataRow[13] = 0;
		dataRow[14] = 0;
		dataRow[15] = 0;
		dataRow[16] = 0;
		dataRow[17] = false;
		dataRow[18] = 0;
		dataRow[19] = 0;
		dataRow[20] = 0;
		gridViewSourceM.Rows.Add(dataRow);
		this.GridViewSourceM = gridViewSourceM;
		this.BindDataM();
	}

	   protected void btnSure_Click(object sender, EventArgs e)
    {
        string str = FunLibrary.ChkInput(this.tbConInfo.Text.Trim());
        DataTable gridViewSourceM = this.GridViewSourceM;
        DataTable table2 = DALCommon.GetDataList("ck_goods", "", this.ddlSchFld.SelectedValue + "='" + str + "'").Tables[0];
        decimal num = 0M;
        decimal result = 1M;
        string str2 = "零售价";
        if (this.hfCusID.Value != "")
        {
            DataTable table3 = DALCommon.GetDataList("ks_customer", "Price,Dis", " [ID]=" + this.hfCusID.Value).Tables[0];
            if ((table3.Rows.Count > 0) && (table3.Rows[0]["Price"].ToString() != ""))
            {
                str2 = table3.Rows[0]["Price"].ToString();
                decimal.TryParse(table3.Rows[0]["Dis"].ToString(), out result);
                if (result == 0M)
                {
                    result = 1M;
                }
            }
        }
        string str3 = "$('" + this.tbConInfo.ClientID + "').select();";
        if (table2.Rows.Count > 0)
        {
            this.CollectDataM();
            for (int i = 0; i < table2.Rows.Count; i++)
            {
                switch (str2)
                {
                    case "零售价":
                        num = decimal.Parse(table2.Rows[i]["PriceDetail"].ToString());
                        break;

                    case "进货价":
                        num = decimal.Parse(table2.Rows[i]["PriceCost"].ToString());
                        break;

                    case "内部价":
                        num = decimal.Parse(table2.Rows[i]["PriceInner"].ToString());
                        break;

                    case "旧货价":
                        num = decimal.Parse(table2.Rows[i]["PriceWholesale1"].ToString());
                        break;

                    case "替代价":
                        num = decimal.Parse(table2.Rows[i]["PriceWholesale2"].ToString());
                        break;

                    case "列表价":
                        num = decimal.Parse(table2.Rows[i]["PriceWholesale3"].ToString());
                        break;

                    default:
                        num = decimal.Parse(table2.Rows[i]["PriceDetail"].ToString());
                        break;
                }
                bool flag2 = true;
                for (int j = 0; j < gridViewSourceM.Rows.Count; j++)
                {
                    if (gridViewSourceM.Rows[j]["GoodsID"].ToString() == table2.Rows[i]["ID"].ToString())
                    {
                        decimal Qty = decimal.Parse(gridViewSourceM.Rows[j]["Qty"].ToString()); ++Qty; gridViewSourceM.Rows[j]["Qty"] = Qty;
                        gridViewSourceM.Rows[j]["Total"] = decimal.Parse(gridViewSourceM.Rows[j]["Total"].ToString()) + decimal.Parse(gridViewSourceM.Rows[j]["Price"].ToString());
                        flag2 = false;
                    }
                }
                if (flag2)
                {
                    DataRow row = gridViewSourceM.NewRow();
                    row[0] = table2.Rows[i]["GoodsNO"].ToString();
                    row[1] = table2.Rows[i]["_Name"].ToString();
                    row[2] = table2.Rows[i]["Spec"].ToString();
                    row[3] = table2.Rows[i]["ProductBrand"].ToString();
                    row[4] = table2.Rows[i]["Unit"].ToString();
                    row[5] = 1;
                    row[6] = Convert.ToDouble((decimal) (num * result)).ToString("#0.00");
                    row[7] = Convert.ToDouble((decimal) (num * result)).ToString("#0.00");
                    row[8] = "";
                    row[9] = table2.Rows[i]["MainTenancePeriod"].ToString();
                    row[10] = "";
                    row[11] = "客付";
                    row[12] = "";
                    row[13] = int.Parse(table2.Rows[i]["ID"].ToString());
                    row[14] = int.Parse(table2.Rows[i]["GoodsUnitID"].ToString());
                    row[15] = 0;
                    row[0x10] = 0;
                    row[0x11] = false;
                    row[0x12] = 0;
                    row[0x13] = 0;
                    row[20] = 0;
                    gridViewSourceM.Rows.Add(row);
                }
            }
            this.BindDataM();
        }
        else
        {
            str3 = str3 + "window.alert('操作失败！没有该产品信息');";
        }
        this.SysInfo(str3);
    }

       protected void btnId_Click(object sender, EventArgs e)
       {
           string str = string.Empty;
           if (this.hfreclist.Value.EndsWith(","))
           {
               str = this.hfreclist.Value.Remove(this.hfreclist.Value.LastIndexOf(','));
           }
           else
           {
               str = this.hfreclist.Value;
           }
           decimal num = 0M;
           decimal result = 1M;
           string str2 = "零售价";
           if (this.hfCusID.Value != "")
           {
               DataTable table = DALCommon.GetDataList("ks_customer", "Price,Dis", " [ID]=" + this.hfCusID.Value).Tables[0];
               if ((table.Rows.Count > 0) && (table.Rows[0]["Price"].ToString() != ""))
               {
                   str2 = table.Rows[0]["Price"].ToString();
                   decimal.TryParse(table.Rows[0]["Dis"].ToString(), out result);
                   if (result == 0M)
                   {
                       result = 1M;
                   }
               }
           }
           DataTable gridViewSourceM = this.GridViewSourceM;
           if (str != string.Empty)
           {
               DataTable table3 = DALCommon.GetDataList("ck_goods", "", " [ID] in(" + str + ") ").Tables[0];
               if (table3.Rows.Count > 0)
               {
                   this.CollectDataM();
                   for (int i = 0; i < table3.Rows.Count; i++)
                   {
                       switch (str2)
                       {
                           case "零售价":
                               num = decimal.Parse(table3.Rows[i]["PriceDetail"].ToString());
                               break;

                           case "进货价":
                               num = decimal.Parse(table3.Rows[i]["PriceCost"].ToString());
                               break;

                           case "内部价":
                               num = decimal.Parse(table3.Rows[i]["PriceInner"].ToString());
                               break;

                           case "旧货价":
                               num = decimal.Parse(table3.Rows[i]["PriceWholesale1"].ToString());
                               break;

                           case "替代价":
                               num = decimal.Parse(table3.Rows[i]["PriceWholesale2"].ToString());
                               break;

                           case "列表价":
                               num = decimal.Parse(table3.Rows[i]["PriceWholesale3"].ToString());
                               break;

                           default:
                               num = decimal.Parse(table3.Rows[i]["PriceDetail"].ToString());
                               break;
                       }
                       bool flag2 = true;
                       for (int j = 1; j < gridViewSourceM.Rows.Count; j++)
                       {
                           if (gridViewSourceM.Rows[j]["GoodsID"].ToString() == table3.Rows[i]["ID"].ToString())
                           {
                               string str4 = gridViewSourceM.Rows[i]["Qty"].ToString();
                               decimal Qty = decimal.Parse(gridViewSourceM.Rows[j]["Qty"].ToString()); ++Qty; gridViewSourceM.Rows[j]["Qty"] = Qty;
                               gridViewSourceM.Rows[j]["Total"] = decimal.Parse(gridViewSourceM.Rows[j]["Total"].ToString()) + decimal.Parse(gridViewSourceM.Rows[j]["Price"].ToString());
                               flag2 = false;
                           }
                       }
                       if (flag2)
                       {
                           DataRow row = gridViewSourceM.NewRow();
                           row[0] = table3.Rows[i]["GoodsNO"].ToString();
                           row[1] = table3.Rows[i]["_Name"].ToString();
                           row[2] = table3.Rows[i]["Spec"].ToString();
                           row[3] = table3.Rows[i]["ProductBrand"].ToString();
                           row[4] = table3.Rows[i]["Unit"].ToString();
                           row[5] = 1;
                           row[6] = Convert.ToDouble((decimal)(num * result)).ToString("#0.00");
                           row[7] = Convert.ToDouble((decimal)(num * result)).ToString("#0.00");
                           row[8] = "";
                           row[9] = table3.Rows[i]["MainTenancePeriod"].ToString();
                           row[10] = "";
                           row[11] = "客付";
                           row[12] = "";
                           row[13] = int.Parse(table3.Rows[i]["ID"].ToString());
                           row[14] = int.Parse(table3.Rows[i]["GoodsUnitID"].ToString());
                           row[15] = 0;
                           row[0x10] = 0;
                           row[0x11] = false;
                           row[0x12] = 0;
                           row[0x13] = 0;
                           row[20] = 0;
                           gridViewSourceM.Rows.Add(row);
                       }
                   }
                   this.BindDataM();
               }
           }
           this.SysInfo("$('tbConInfo').focus();");
       }

	protected void btnSltUnit_Click(object sender, EventArgs e)
	{
		this.CollectDataM();
		DataTable gridViewSourceM = this.GridViewSourceM;
		for (int i = 0; i < gridViewSourceM.Rows.Count; i++)
		{
			if (gridViewSourceM.Rows[i]["GoodsID"].ToString() == this.hfRecID.Value.Replace("u", ""))
			{
				gridViewSourceM.Rows[i][4] = this.hfName.Value;
				gridViewSourceM.Rows[i][14] = int.Parse(this.hfRecIDs.Value);
			}
		}
		this.BindDataM();
	}

	protected void CollectDataM()
	{
		for (int i = 0; i < this.GridView2.Rows.Count; i++)
		{
			TextBox textBox = this.GridView2.Rows[i].FindControl("tbQty") as TextBox;
			TextBox textBox2 = this.GridView2.Rows[i].FindControl("tbSN") as TextBox;
			TextBox textBox3 = this.GridView2.Rows[i].FindControl("tbPrice") as TextBox;
			TextBox textBox4 = this.GridView2.Rows[i].FindControl("tbRemark") as TextBox;
			TextBox textBox5 = this.GridView2.Rows[i].FindControl("tbPeriod") as TextBox;
			TextBox textBox6 = this.GridView2.Rows[i].FindControl("tbPeriodEndDate") as TextBox;
			DropDownList dropDownList = this.GridView2.Rows[i].FindControl("ddlChargeStyle") as DropDownList;
			CheckBox checkBox = this.GridView2.Rows[i].FindControl("cbOutSourcing") as CheckBox;
			TextBox textBox7 = this.GridView2.Rows[i].FindControl("tbOutPrice") as TextBox;
			TextBox textBox8 = this.GridView2.Rows[i].FindControl("tbTaxRate") as TextBox;
			DataTable gridViewSourceM = this.GridViewSourceM;
			gridViewSourceM.Rows[i]["Qty"] = textBox.Text;
			gridViewSourceM.Rows[i]["SN"] = textBox2.Text;
			gridViewSourceM.Rows[i]["Price"] = textBox3.Text;
			decimal d = decimal.Parse(textBox.Text) * decimal.Parse(textBox3.Text);
			decimal num = d * decimal.Parse(textBox8.Text);
			decimal num2 = d + num;
			gridViewSourceM.Rows[i]["Total"] = num2;
			gridViewSourceM.Rows[i]["Remark"] = FunLibrary.ChkInput(textBox4.Text);
			gridViewSourceM.Rows[i]["MaintenancePeriod"] = FunLibrary.ChkInput(textBox5.Text);
			gridViewSourceM.Rows[i]["PeriodEndDate"] = FunLibrary.ChkInput(textBox6.Text);
			gridViewSourceM.Rows[i]["ChargeStyle"] = dropDownList.SelectedItem.Text;
			gridViewSourceM.Rows[i]["OutSourcing"] = checkBox.Checked;
			gridViewSourceM.Rows[i]["OutCostPrice"] = textBox7.Text;
			gridViewSourceM.Rows[i]["TaxRate"] = textBox8.Text;
			gridViewSourceM.Rows[i]["TaxAmount"] = num;
		}
	}

	protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		this.CollectDataM();
		DataTable gridViewSourceM = this.GridViewSourceM;
		for (int i = 0; i < gridViewSourceM.Rows.Count; i++)
		{
			if (i == e.RowIndex)
			{
				if (int.Parse(gridViewSourceM.Rows[i]["iFlag"].ToString()) == 1)
				{
					if (this.hfdellist1.Value == string.Empty)
					{
						this.hfdellist1.Value = gridViewSourceM.Rows[i]["RecID"].ToString();
					}
					else
					{
						HiddenField expr_AA = this.hfdellist1;
						expr_AA.Value = expr_AA.Value + "," + gridViewSourceM.Rows[i]["RecID"].ToString();
					}
				}
			}
		}
		this.GridViewSourceM.Rows[e.RowIndex].Delete();
		this.BindDataM();
	}

	private void BindDataM()
	{
		this.GridView2.DataSource = this.GridViewSourceM;
		this.GridView2.DataBind();
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.Cells[0].Text == "0")
		{
			e.Row.Visible = false;
		}
		e.Row.Cells[0].Visible = (e.Row.Cells[1].Visible = false);
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			TextBox textBox = e.Row.FindControl("tbQty") as TextBox;
			TextBox textBox2 = e.Row.FindControl("tbPrice") as TextBox;
			Label label = e.Row.FindControl("lbAmount") as Label;
			TextBox textBox3 = e.Row.FindControl("tbChargeStyle") as TextBox;
			TextBox textBox4 = e.Row.FindControl("tbSN") as TextBox;
			TextBox textBox5 = e.Row.FindControl("tbTaxRate") as TextBox;
			Label label2 = e.Row.FindControl("lbTaxAmount") as Label;
			textBox.Attributes.Add("oldNum", textBox.Text);
			textBox2.Attributes.Add("oldNum", textBox2.Text);
			label.Attributes.Add("oldNum", label.Text);
			textBox.Attributes.Add("onblur", string.Concat(new string[]
			{
				"ValidateNumsm(this,'",
				textBox2.ClientID,
				"','",
				textBox5.ClientID,
				"','",
				label2.ClientID,
				"','",
				label.ClientID,
				"');"
			}));
			textBox2.Attributes.Add("onblur", string.Concat(new string[]
			{
				"ValidateMoneysm(this,'",
				textBox.ClientID,
				"','",
				textBox5.ClientID,
				"','",
				label2.ClientID,
				"','",
				label.ClientID,
				"');"
			}));
			textBox5.Attributes.Add("onblur", string.Concat(new string[]
			{
				"ValidateTaxsm(this,'",
				textBox.ClientID,
				"','",
				textBox2.ClientID,
				"','",
				label2.ClientID,
				"','",
				label.ClientID,
				"');"
			}));
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[2].Text = Convert.ToString(e.Row.RowIndex);
			e.Row.Cells[2].Attributes.Add("style", "background:#ECE9D8;");
			e.Row.Cells[7].Attributes.Add("id", "u" + e.Row.Cells[0].Text);
			e.Row.Cells[7].Attributes.Add("onclick", "ChkID('u" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[7].Attributes.Add("ondblclick", "SltUnit1();");
			e.Row.Cells[8].Attributes.Add("id", "q" + e.Row.Cells[0].Text);
			e.Row.Cells[8].Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkIDs('q",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');"
			}));
			e.Row.Cells[8].Attributes.Add("ondblclick", "SltUnitQty1('" + textBox.ClientID + "');");
			HtmlInputButton htmlInputButton = e.Row.FindControl("btnsch") as HtmlInputButton;
			e.Row.Cells[10].Attributes.Add("id", "p" + e.Row.Cells[0].Text);
			htmlInputButton.Attributes.Add("onclick", string.Concat(new string[]
			{
				"ChkIDs('p",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"');SltPrice1('2','",
				textBox2.ClientID,
				"');"
			}));
			e.Row.Cells[9].Text = string.Concat(new string[]
			{
				"<a href=\"#\" onclick=\"EditSN('",
				e.Row.Cells[0].Text,
				"','",
				e.Row.Cells[1].Text,
				"','",
				textBox4.ClientID,
				"','",
				textBox.ClientID,
				"');\">编辑序列号</a>"
			});
			DropDownList dropDownList = e.Row.FindControl("ddlChargeStyle") as DropDownList;
			dropDownList.Items.Add(new ListItem("客付", "客付"));
			dropDownList.Items.Add(new ListItem("厂付", "厂付"));
			dropDownList.Items.Add(new ListItem("免费", "免费"));
			for (int i = 0; i < dropDownList.Items.Count; i++)
			{
				if (dropDownList.Items[i].Text == textBox3.Text)
				{
					dropDownList.Items[i].Selected = true;
					break;
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALServices dALServices = new DALServices();
		ServicesInfo servicesInfo = new ServicesInfo();
		servicesInfo.ID = this.id;
		string str = "";
		this.CollectDataM();
		DataTable gridViewSourceM = this.GridViewSourceM;
		if (gridViewSourceM.Rows.Count > 0)
		{
			List<ServicesMaterialInfo> list = new List<ServicesMaterialInfo>();
			for (int i = 0; i < gridViewSourceM.Rows.Count; i++)
			{
				if (int.Parse(gridViewSourceM.Rows[i]["GoodsID"].ToString()) > 0)
				{
					list.Add(new ServicesMaterialInfo
					{
						ID = int.Parse(gridViewSourceM.Rows[i]["RecID"].ToString()),
						GoodsID = int.Parse(gridViewSourceM.Rows[i]["GoodsID"].ToString()),
						UnitID = int.Parse(gridViewSourceM.Rows[i]["UnitID"].ToString()),
						Qty = decimal.Parse(gridViewSourceM.Rows[i]["Qty"].ToString()),
						Price = decimal.Parse(gridViewSourceM.Rows[i]["Price"].ToString()),
						MaintenancePeriod = gridViewSourceM.Rows[i]["MaintenancePeriod"].ToString(),
						PeriodEndDate = gridViewSourceM.Rows[i]["PeriodEndDate"].ToString(),
						ChargeStyle = gridViewSourceM.Rows[i]["ChargeStyle"].ToString(),
						Remark = gridViewSourceM.Rows[i]["Remark"].ToString(),
						SN = gridViewSourceM.Rows[i]["SN"].ToString(),
						OutSourcing = bool.Parse(gridViewSourceM.Rows[i]["OutSourcing"].ToString()),
						CostPrice = decimal.Parse(gridViewSourceM.Rows[i]["OutCostPrice"].ToString()),
						TaxRate = decimal.Parse(gridViewSourceM.Rows[i]["TaxRate"].ToString())
					});
				}
			}
			servicesInfo.ServicesMaterialInfos = list;
		}
		List<string[]> list2 = new List<string[]>();
		if (this.hfdellist1.Value != string.Empty)
		{
			list2.Add(new string[]
			{
				"ServicesMaterial",
				this.hfdellist1.Value
			});
		}
		int num = dALServices.UpdateAddM(servicesInfo, list2, out str);
		if (num == 0)
		{
			DbHelperSQL.InsertErrorLogs(2, int.Parse((string)this.Session["Session_wtUserID"]), this.id, "添加使用备件", 0);
			this.SysInfo("window.alert('操作成功！服务单使用配件已保存');parent.CloseDialog('1');");
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
}
