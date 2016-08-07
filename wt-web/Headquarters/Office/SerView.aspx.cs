using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.OtherLibrary;

public partial class Headquarters_Office_SerView : Page, IRequiresSessionState
{
	private int id;

	private int purid = 0;

	private string flag;

	public string str_flag
	{
		get
		{
			return this.flag;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		string text = base.Request["f"].ToString();
		if (text == string.Empty)
		{
			base.Response.End();
		}
		this.flag = base.Request["iflag"];
		if (this.flag == "" || this.flag == null)
		{
			this.flag = "";
		}
		if (!base.IsPostBack)
		{
			this.purid = int.Parse((string)this.Session["Session_wtPurID"]);
			if (this.purid > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(this.purid, "gd_r1"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
				if (!dALRight.GetRight(this.purid, "gd_r18"))
				{
					this.btnPrint.Visible = false;
				}
				if (dALRight.GetRight(this.purid, "gd_r32"))
				{
					this.div2.Visible = false;
				}
			}
			string strCondition = " BillID='" + text + "'";
			DataTable dataTable = DALCommon.GetDataList("fw_services", "", strCondition).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.id = int.Parse(dataTable.Rows[0]["ID"].ToString());
				this.hfPrintID.Value = this.id.ToString();
				this.tbBillID.Text = dataTable.Rows[0]["BillID"].ToString();
				this.ddlType.Items.Add(new ListItem(dataTable.Rows[0]["ServicesType"].ToString(), dataTable.Rows[0]["ServicesType"].ToString()));
				this.ddlTake.Items.Add(new ListItem(dataTable.Rows[0]["TakeStyle"].ToString(), dataTable.Rows[0]["TakeStyle"].ToString()));
				this.tbTakeTime.Text = dataTable.Rows[0]["Time_TakeOver"].ToString();
				this.hfCusID.Value = dataTable.Rows[0]["CustomerID"].ToString();
				this.tbCusName.Text = dataTable.Rows[0]["CustomerName"].ToString();
				this.tbLinkMan.Text = dataTable.Rows[0]["LinkMan"].ToString();
				this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString();
				this.tbUsePerson.Text = dataTable.Rows[0]["UsePerson"].ToString();
				this.tbUsePersonTel.Text = dataTable.Rows[0]["UsePersonTel"].ToString();
				this.tbDept.Value = dataTable.Rows[0]["UsePersonDept"].ToString();
				this.tbArea.Text = dataTable.Rows[0]["Area"].ToString();
				this.tbAdr.Text = dataTable.Rows[0]["Adr"].ToString();
				this.ddlOperator.Items.Add(new ListItem(dataTable.Rows[0]["Operator"].ToString(), dataTable.Rows[0]["Operator"].ToString()));
				this.tbDate.Text = dataTable.Rows[0]["Time_Make"].ToString();
				this.ddlBrand.Items.Add(new ListItem(dataTable.Rows[0]["ProductBrand"].ToString(), dataTable.Rows[0]["ProductBrand"].ToString()));
				this.tbBrand.Text = this.ddlBrand.SelectedItem.Text;
				this.ddlClass.Items.Add(new ListItem(dataTable.Rows[0]["ProductClass"].ToString(), dataTable.Rows[0]["ProductClass"].ToString()));
				this.tbClass.Text = this.ddlClass.SelectedItem.Text;
				this.ddlModel.Items.Add(new ListItem(dataTable.Rows[0]["ProductModel"].ToString(), dataTable.Rows[0]["ProductModel"].ToString()));
				this.tbModel.Text = this.ddlModel.SelectedItem.Text;
				this.tbAspect.Text = dataTable.Rows[0]["Aspect"].ToString();
				this.tbSN1.Text = dataTable.Rows[0]["ProductSN1"].ToString();
				this.tbSN2.Text = dataTable.Rows[0]["ProductSN2"].ToString();
				this.tbAcc.Text = dataTable.Rows[0]["Accessory"].ToString();
				this.tbFault.Text = dataTable.Rows[0]["Fault"].ToString();
				this.ddlRepStatus.Items.Add(new ListItem(dataTable.Rows[0]["Warranty"].ToString(), dataTable.Rows[0]["Warranty"].ToString()));
				this.ddlPRI.Items.Add(new ListItem(dataTable.Rows[0]["_PRI"].ToString(), dataTable.Rows[0]["_PRI"].ToString()));
				this.tbBuyFrom.Text = dataTable.Rows[0]["BuyFrom"].ToString();
				this.tbBuyTime.Text = dataTable.Rows[0]["BuyDate"].ToString();
				this.tbBuyInvoice.Text = dataTable.Rows[0]["BuyInvoice"].ToString();
				this.tbPoint.Text = dataTable.Rows[0]["dPoint"].ToString();
				this.tbCmpTime.Text = dataTable.Rows[0]["Time_Complete"].ToString();
				if (dataTable.Rows[0]["bRepair"].ToString() != "")
				{
					this.cbRe.Checked = true;
				}
				if (dataTable.Rows[0]["bAgain"].ToString() != "")
				{
					this.cbAgain.Checked = true;
				}
				this.hfPath.Value = dataTable.Rows[0]["Path"].ToString();
				if (this.hfPath.Value != "")
				{
					string text2 = this.hfPath.Value.Substring(this.hfPath.Value.LastIndexOf('/') + 1);
					this.dUpload.InnerHtml = "<img src='../../Public/Images/dmony.gif' /> <a href=\"" + this.hfPath.Value + "\" target=_blank >附件</a>";
				}
				this.tbContNO.Text = dataTable.Rows[0]["ContractNO"].ToString();
				this.tbSaveID.Text = dataTable.Rows[0]["SaveID"].ToString();
				this.tbCorpID.Text = dataTable.Rows[0]["SupplierID"].ToString();
				this.ddlChargeCorp.Items.Add(new ListItem(dataTable.Rows[0]["ChargeCorp"].ToString(), dataTable.Rows[0]["ChargeCorp"].ToString()));
				this.tbDisposal.Text = dataTable.Rows[0]["DisposalOper"].ToString();
				this.tbSubTime.Text = dataTable.Rows[0]["SubscribeTime"].ToString();
				this.tbSubContTime.Text = dataTable.Rows[0]["SubscribeConnectTime"].ToString();
				this.tbSubPrice.Text = dataTable.Rows[0]["SubscribePrice"].ToString();
				this.tbSubCharge.Text = dataTable.Rows[0]["PreCharge"].ToString();
				this.tbRemark.Text = dataTable.Rows[0]["Remark"].ToString();
				this.tbPostage.Text = dataTable.Rows[0]["Postage"].ToString();
				this.tbPostNO.Text = dataTable.Rows[0]["PostNO"].ToString();
				this.tbFee_Materail.Text = dataTable.Rows[0]["Fee_Materail"].ToString();
				this.tbFee_Add.Text = dataTable.Rows[0]["Fee_Add"].ToString();
				this.tbFee_Labor.Text = dataTable.Rows[0]["Fee_Labor"].ToString();
				this.tbFee_Total.Text = dataTable.Rows[0]["Fee_Total"].ToString();
				this.tbCost_Materail.Text = dataTable.Rows[0]["MaterailCost"].ToString();
				this.tbRepCost.Text = dataTable.Rows[0]["RepairCost"].ToString();
				this.tbCost_Add.Text = dataTable.Rows[0]["ExtraCost"].ToString();
				this.tbProfit.Text = dataTable.Rows[0]["Profit"].ToString();
				this.tbInCash.Text = dataTable.Rows[0]["InCash"].ToString();
				this.ddlRcvMan.Items.Add(new ListItem(dataTable.Rows[0]["PayeeOper"].ToString(), dataTable.Rows[0]["PayeeOper"].ToString()));
				this.tbRcvDate.Text = dataTable.Rows[0]["Time_Payee"].ToString();
				this.tbChargeValue.Text = dataTable.Rows[0]["ChargeValue"].ToString();
				this.tbPreMoney.Text = dataTable.Rows[0]["PreMoney"].ToString();
				this.tbRealMoney.Text = dataTable.Rows[0]["RealMoney"].ToString();
				this.tbFacName.Text = dataTable.Rows[0]["ChargeCorp"].ToString();
				this.tbFacAmount.Text = dataTable.Rows[0]["WarrantyChargeValue"].ToString();
				this.tbEndDate.Text = dataTable.Rows[0]["WarrantyEndDate"].ToString();
				this.tbEndPlace.Text = dataTable.Rows[0]["WarrantyBound"].ToString();
				this.tbGone.Text = dataTable.Rows[0]["GoodsTo"].ToString();
				this.tbGoneDate.Text = dataTable.Rows[0]["ConnectDate"].ToString();
				this.tbDeviceNO.Text = dataTable.Rows[0]["DeviceNO"].ToString();
				this.GridView8.DataSource = DALCommon.GetDataList("ks_qtylist", "", string.Concat(new object[]
				{
					" BillID=",
					this.id,
					" or SN='",
					dataTable.Rows[0]["ProductSN1"].ToString(),
					"'"
				}));
				this.GridView8.DataBind();
				OtherFunction.BindStaff(this.ddlVisitOperator, "DeptID=1 and Status=0");
				OtherFunction.BindVisitStyle(this.ddlVisitStyle);
				dataTable = DALCommon.GetDataList("ServicesVisit", "", " [BillID]=" + this.id.ToString()).Tables[0];
				if (dataTable.Rows.Count > 0)
				{
					DateTime dateTime = default(DateTime);
					DateTime.TryParse(dataTable.Rows[0]["_Date"].ToString(), out dateTime);
					this.tbVisitDate.Text = dateTime.ToString("yyyy-MM-dd");
					this.ddlVisitOperator.ClearSelection();
					for (int i = 0; i < this.ddlVisitOperator.Items.Count; i++)
					{
						if (this.ddlVisitOperator.Items[i].Value == dataTable.Rows[0]["OperatorID"].ToString())
						{
							this.ddlVisitOperator.Items[i].Selected = true;
							break;
						}
					}
					this.ddlVisitStyle.ClearSelection();
					for (int i = 0; i < this.ddlVisitStyle.Items.Count; i++)
					{
						if (this.ddlVisitStyle.Items[i].Value == dataTable.Rows[0]["VisitStyleID"].ToString())
						{
							this.ddlVisitStyle.Items[i].Selected = true;
							break;
						}
					}
					this.tbVisitOperator.Text = dataTable.Rows[0]["CusName"].ToString();
					this.tbCusOpinon.Text = dataTable.Rows[0]["Opinion"].ToString();
					this.tbVisitRemark.Text = dataTable.Rows[0]["Remark"].ToString();
					DataTable dataTable2 = DALCommon.GetDataList("fw_visitresult", "", " [VisitID]=" + dataTable.Rows[0]["ID"].ToString()).Tables[0];
					for (int j = 0; j < dataTable2.Rows.Count; j++)
					{
						this.hfrdID.Value = string.Concat(new string[]
						{
							this.hfrdID.Value,
							"|",
							dataTable2.Rows[j]["ContentID"].ToString(),
							",",
							dataTable2.Rows[j]["VisitResultID"].ToString()
						});
					}
				}
				int num = 0;
				DataTable dt = DALCommon.GetList_HL(0, "fw_visitcontent", "", 0, 0, "", " ID Asc", out num).Tables[0];
				this.tv.Nodes.Clear();
				TreeNode treeNode = new TreeNode();
				treeNode.Text = "<span style=\"color:#0000ff;\">回访内容</span>";
				treeNode.Value = "-1";
				treeNode.SelectAction = TreeNodeSelectAction.None;
				this.tv.Nodes.Add(treeNode);
				this.BindTreeNode2(treeNode, dt, "-1", 0);
				this.tv.ExpandAll();
			}
			this.GridView1.DataSource = DALCommon.GetDataList("ServicesDeviceConf", "", " [BillID]=" + this.id.ToString()).Tables[0];
			this.GridView1.DataBind();
			this.GridView2.DataSource = DALCommon.GetDataList("fw_servicesmaterial", "", " [BillID]=" + this.id.ToString()).Tables[0];
			this.GridView2.DataBind();
			this.GridView3.DataSource = DALCommon.GetDataList("fw_servicesitem", "", " [BillID]=" + this.id.ToString()).Tables[0];
			this.GridView3.DataBind();
			this.GridView4.DataSource = DALCommon.GetDataList("fw_serviceslog", "", " [BillID]=" + this.id.ToString()).Tables[0];
			this.GridView4.DataBind();
			this.GridView6.DataSource = DALCommon.GetDataList("fw_servicespush", "", " [BillID]=" + this.id.ToString()).Tables[0];
			this.GridView6.DataBind();
			this.GridView5.DataSource = DALCommon.GetDataList("fw_servicesprocess", "", " [BillID]=" + this.id.ToString()).Tables[0];
			this.GridView5.DataBind();
			this.GridView7.DataSource = DALCommon.GetDataList("fw_servicesoffer", "", " [BillID]=" + this.id.ToString()).Tables[0];
			this.GridView7.DataBind();
			this.GridView9.DataSource = DALCommon.GetDataList("fw_deduct", "", " BillID=" + this.id.ToString());
			this.GridView9.DataBind();
			this.GridView10.DataSource = DALCommon.GetDataList("SerAttach", "", string.Format(" ((BillID={0} and iType =1) or(BillID in(select ID from ServicesProcess where BillID={0}) and iType in(2,3)) or (BillID in(select ID from ServicesLog where BillID={0}) and iType in(4,5)))", this.id));
			this.GridView10.DataBind();
		}
	}

	protected void BindTreeNode2(TreeNode node, DataTable dt, string parentid, int iFlag)
	{
		DataRow[] array = dt.Select(" Father=" + parentid);
		DataRow[] array2 = array;
		for (int i = 0; i < array2.Length; i++)
		{
			DataRow dataRow = array2[i];
			TreeNode treeNode = new TreeNode();
			if (iFlag == 0)
			{
				treeNode.Text = dataRow["_Name"].ToString();
			}
			else
			{
				treeNode.Text = string.Concat(new string[]
				{
					"<input id=\"rd",
					dataRow["ID"].ToString(),
					"\" name=\"",
					parentid,
					"\" ",
					this.GetChoise(parentid, dataRow["ID"].ToString()),
					" type=\"radio\" onclick=\"SltVisitValue('",
					dataRow["ID"].ToString(),
					"','",
					parentid,
					"',this);\"/>",
					dataRow["_Name"].ToString()
				});
			}
			treeNode.Value = dataRow["ID"].ToString();
			treeNode.SelectAction = TreeNodeSelectAction.None;
			node.ChildNodes.Add(treeNode);
			if (iFlag == 0)
			{
				this.BindTreeNode2(treeNode, dt, dataRow["ID"].ToString(), 1);
			}
		}
	}

	protected string GetChoise(string n, string id)
	{
		string result = "";
		string[] array = this.hfrdID.Value.Split(new char[]
		{
			'|'
		});
		for (int i = 0; i < array.Length; i++)
		{
			string[] array2 = array[i].Split(new char[]
			{
				','
			});
			if (array2[0] == n)
			{
				if (id == array2[1].ToString())
				{
					result = "checked=\"checked\"";
				}
			}
		}
		return result;
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}

	protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		DALRight dALRight = new DALRight();
		this.purid = int.Parse((string)this.Session["Session_wtPurID"]);
		if (this.purid > 0)
		{
			if (dALRight.GetRight(this.purid, "gd_r31"))
			{
				e.Row.Cells[4].Visible = false;
			}
		}
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
			e.Row.Cells[9].Text = e.Row.Cells[9].Text.TrimEnd(new char[]
			{
				'0'
			}).TrimEnd(new char[]
			{
				'.'
			});
			e.Row.Cells[10].Text = e.Row.Cells[10].Text.TrimEnd(new char[]
			{
				'0'
			}).TrimEnd(new char[]
			{
				'.'
			});
		}
	}

	protected void GridView10_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
			e.Row.Cells[2].Text = this.AttachType(e.Row.Cells[2].Text.Trim());
		}
	}

	public string AttachType(string itype)
	{
		string result = string.Empty;
		if (itype != null)
		{
			if (itype == "1")
			{
				result = "报称故障";
				return result;
			}
			if (itype == "2")
			{
				result = "处理措施/结果";
				return result;
			}
			if (itype == "3")
			{
				result = "故障原因附件";
				return result;
			}
			if (itype == "4")
			{
				result = "网点确认";
				return result;
			}
			if (itype == "5")
			{
				result = "网点建议";
				return result;
			}
		}
		result = "";
		return result;
	}
}
