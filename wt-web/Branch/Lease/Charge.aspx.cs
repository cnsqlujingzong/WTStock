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
using wt.Model;

public partial class Branch_Lease_Charge : Page, IRequiresSessionState
{
	

	private int id;

	private decimal dr1 = 0m;

	private decimal dr2 = 0m;

	private decimal dr3 = 0m;

	private decimal dr4 = 0m;

	private decimal dr5 = 0m;

	private decimal dr6 = 0m;

	private decimal dr7 = 0m;

	private decimal dtest = 0m;

	

	private DataTable GridViewSource
	{
		get
		{
			if (this.ViewState["List"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("QtyTypeName", typeof(string)));
				dataTable.Columns.Add(new DataColumn("BQty", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("SQty", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Zhang", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("Rated", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("ZhangFee", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("SuperZhangFee", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("QtyTypeID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("ID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("Ratedd", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("ProductSN", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Loss", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("ChargeStyle", typeof(string)));
				dataTable.Columns.Add(new DataColumn("CStyle", typeof(int)));
				dataTable.Columns.Add(new DataColumn("HZhang", typeof(decimal)));
				dataTable.Columns.Add(new DataColumn("ChargeDate", typeof(string)));
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
		FunLibrary.ChkBran();
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "zl_r4"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
			}
			decimal num2 = 0m;
			decimal d = 30m;
			decimal d2 = 0m;
			decimal num3 = 0m;
			decimal num4 = 0m;
			decimal d3 = 0m;
			decimal num5 = 0m;
			int num6 = 0;
			decimal d4 = 0m;
			decimal num7 = 0m;
			decimal num8 = 0m;
			this.GridViewSource.Clear();
			DataTable gridViewSource = this.GridViewSource;
			DataTable dataTable = DALCommon.GetDataList("Lease", "Rent,ChargeCycle", " [ID]=" + this.id).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				decimal.TryParse(dataTable.Rows[0]["Rent"].ToString(), out num2);
				decimal num9 = num2;
				decimal.TryParse(dataTable.Rows[0]["ChargeCycle"].ToString(), out d);
				decimal d5 = num2 * 3m;
				this.tbCycle.Text = "0";
				DataTable dataTable2 = DALCommon.GetDataList("zl_leasedetail", "QtyType", " DevStatus='正常' and iBillID=" + this.id + " group by QtyType").Tables[0];
				DataTable dataTable3 = DALCommon.GetList("zl_meterreading", "*", " [BillID]=" + this.id + " and Cstyle=7 order by [_Date] desc").Tables[0];
				while (dataTable3.Rows.Count > 0)
				{
					string str = dataTable3.Rows[0]["QtyType"].ToString();
					DataRow[] array = dataTable3.Select("QtyType=" + str, "[_Date] desc");
					if (array.Length == 1)
					{
						int num10 = int.Parse(array[0]["Qty"].ToString()) - int.Parse(array[0]["Loss"].ToString());
						int num11 = (int)num3 * int.Parse(array[0]["Rated"].ToString());
						decimal num12 = (num11 - num10) * decimal.Parse(array[0]["SuperZhangFee"].ToString());
						if (num11 > 0 && num12 > 0m)
						{
							num8 += num12;
						}
					}
					else if (array.Length > 1)
					{
						DateTime d6 = DateTime.Parse(array[1]["_Date"].ToString());
						DateTime d7 = DateTime.Parse(array[0]["_Date"].ToString());
						num3 = decimal.Parse((d7 - d6).Days.ToString()) / d;
						int num11 = (int)num3 * int.Parse(array[0]["Rated"].ToString());
						int num10 = int.Parse(array[0]["Qty"].ToString()) - int.Parse(array[1]["Qty"].ToString()) - int.Parse(array[0]["Loss"].ToString());
						decimal num12 = (num11 - num10) * decimal.Parse(array[0]["SuperZhangFee"].ToString());
						if (num11 > 0 && num12 > 0m)
						{
							num8 += num12;
						}
					}
					for (int i = 0; i < array.Length; i++)
					{
						dataTable3.Rows.Remove(array[i]);
					}
				}
				for (int j = 0; j < dataTable2.Rows.Count; j++)
				{
					decimal d8 = 0m;
					decimal num13 = 0m;
					int num14 = 0;
					DataTable dataTable4 = DALCommon.GetDataList("zl_leasedetail", "", string.Concat(new object[]
					{
						" QtyType=",
						dataTable2.Rows[j]["QtyType"].ToString(),
						" and DevStatus='正常' and iBillID=",
						this.id
					})).Tables[0];
					if (dataTable4.Rows.Count > 0)
					{
						for (int i = 0; i < dataTable4.Rows.Count; i++)
						{
							int num15 = 1;
							int.TryParse(dataTable4.Rows[i]["CStyle"].ToString(), out num15);
							DataTable dataTable5 = DALCommon.GetList("zl_meterreading", " top 2 *", string.Concat(new object[]
							{
								" [BillID]=",
								this.id,
								" and iBillID=",
								dataTable4.Rows[i]["ID"].ToString(),
								" and QtyType=",
								dataTable4.Rows[i]["QtyType"].ToString(),
								" order by [_Date] desc"
							})).Tables[0];
							int count = dataTable5.Rows.Count;
							if (count > 0)
							{
								int num10;
								if (count == 1)
								{
									num10 = int.Parse(dataTable5.Rows[0]["Qty"].ToString()) - int.Parse(dataTable5.Rows[0]["Loss"].ToString());
									this.tbStartDate.Text = dataTable5.Rows[0]["_Date"].ToString();
									this.tbCycle.Text = "0";
									num3 = decimal.Round(num3, 0);
								}
								else
								{
									num10 = int.Parse(dataTable5.Rows[0]["Qty"].ToString()) - int.Parse(dataTable5.Rows[1]["Qty"].ToString()) - int.Parse(dataTable5.Rows[0]["Loss"].ToString()) - int.Parse(dataTable5.Rows[1]["Loss"].ToString());
									this.tbStartDate.Text = dataTable5.Rows[1]["_Date"].ToString();
									this.tbEndDate.Text = dataTable5.Rows[0]["_Date"].ToString();
									DateTime d6 = DateTime.Parse(dataTable5.Rows[1]["_Date"].ToString());
									DateTime d7 = DateTime.Parse(dataTable5.Rows[0]["_Date"].ToString());
									num3 = decimal.Parse((d7 - d6).Days.ToString()) / d;
									num3 = decimal.Round(num3, 0);
									this.tbCycle.Text = num3.ToString();
								}
								if (num3 == 0m)
								{
									num3 = 1m;
								}
								d2 += num3 * int.Parse(dataTable4.Rows[i]["Rated"].ToString());
								decimal num16 = decimal.Parse(dataTable4.Rows[i]["SuperZhangFee"].ToString());
								d3 += num10;
								num6++;
								if (num15 == 3)
								{
									d8 += num10;
									num13 += num3 * int.Parse(dataTable4.Rows[i]["Rated"].ToString());
									num14++;
									d4 = decimal.Parse(dataTable4.Rows[i]["SuperZhangFee"].ToString());
								}
								if (num15 == 6)
								{
									num7 += (num10 - num3 * decimal.Parse(dataTable4.Rows[i]["Rated"].ToString())) * decimal.Parse(dataTable4.Rows[i]["SuperZhangFee"].ToString());
								}
							}
						}
					}
					DataTable dataTable6 = DALCommon.GetDataList("zl_leasedetail", "", string.Concat(new object[]
					{
						" QtyType=",
						dataTable2.Rows[j]["QtyType"].ToString(),
						" and DevStatus='正常' and iBillID=",
						this.id
					})).Tables[0];
					if (dataTable6.Rows.Count > 0)
					{
						for (int i = 0; i < dataTable6.Rows.Count; i++)
						{
							int num15 = 1;
							int.TryParse(dataTable6.Rows[i]["CStyle"].ToString(), out num15);
							DataRow dataRow = gridViewSource.NewRow();
							dataRow[0] = dataTable6.Rows[i]["QtyTypeName"].ToString();
							dataRow[1] = 0;
							dataRow[2] = 0;
							dataRow[11] = 0;
							DataTable dataTable7 = DALCommon.GetList("zl_meterreading", " top 2 *", string.Concat(new object[]
							{
								" [BillID]=",
								this.id,
								" and DeviceID=",
								dataTable6.Rows[i]["DeviceID"].ToString(),
								" and QtyType=",
								dataTable6.Rows[i]["QtyType"].ToString(),
								" order by [_Date] desc"
							})).Tables[0];
							int count2 = dataTable7.Rows.Count;
							if (count2 > 0)
							{
								if (count2 == 1)
								{
									this.tbStartDate.Text = dataTable7.Rows[0]["_Date"].ToString();
									this.tbCycle.Text = "0";
									dataRow[2] = decimal.Parse(dataTable7.Rows[0]["Qty"].ToString());
									dataRow[11] = decimal.Parse(dataTable7.Rows[0]["Loss"].ToString());
									num3 = decimal.Round(num3, 0);
								}
								else
								{
									this.tbStartDate.Text = dataTable7.Rows[1]["_Date"].ToString();
									this.tbEndDate.Text = dataTable7.Rows[0]["_Date"].ToString();
									DateTime d6 = DateTime.Parse(dataTable7.Rows[1]["_Date"].ToString());
									DateTime d7 = DateTime.Parse(dataTable7.Rows[0]["_Date"].ToString());
									num3 = decimal.Parse((d7 - d6).Days.ToString()) / d;
									num3 = decimal.Round(num3, 0);
									this.tbCycle.Text = num3.ToString();
									decimal num17 = decimal.Parse(dataTable7.Rows[0]["Qty"].ToString());
									decimal num18 = decimal.Parse(dataTable7.Rows[1]["Qty"].ToString());
									dataRow[1] = decimal.Parse(dataTable7.Rows[0]["Qty"].ToString());
									dataRow[2] = decimal.Parse(dataTable7.Rows[1]["Qty"].ToString());
									dataRow[11] = decimal.Parse(dataTable7.Rows[0]["Loss"].ToString());
								}
							}
							if (num3 == 0m)
							{
								num3 = 1m;
							}
							dataRow[3] = decimal.Parse(dataRow[1].ToString()) - decimal.Parse(dataRow[2].ToString()) - decimal.Parse(dataRow[11].ToString());
							dataRow[4] = num3 * decimal.Parse(dataTable6.Rows[i]["Rated"].ToString());
							dataRow[5] = decimal.Parse(dataTable6.Rows[i]["SuperZhangFee"].ToString());
							dataRow[6] = (decimal.Parse(dataRow[3].ToString()) - decimal.Parse(dataRow[4].ToString())) * decimal.Parse(dataRow[5].ToString());
							dataRow[7] = int.Parse(dataTable6.Rows[i]["ID"].ToString());
							dataRow[8] = int.Parse(dataTable6.Rows[i]["BillID"].ToString());
							dataRow[9] = decimal.Parse(dataTable6.Rows[i]["Rated"].ToString());
							dataRow[10] = dataTable6.Rows[i]["ProductSN1"].ToString();
							dataRow[12] = dataTable6.Rows[i]["ChargeStyle"].ToString();
							dataRow[13] = dataTable6.Rows[i]["CStyle"].ToString();
							dataRow[14] = 0;
							dataRow[15] = dataTable6.Rows[i]["ChargeDate"].ToString();
							if (num15 == 2)
							{
								int num19 = 0;
								int.TryParse(dataRow[3].ToString(), out num19);
								decimal num20 = 0m;
								int num21 = 0;
								int.TryParse(dataRow[4].ToString(), out num21);
								num19 -= num21;
								int num22 = 0;
								int num23 = 0;
								DataTable dataTable8 = DALCommon.GetDataList("LeaseFormula", "Price,StartQty,EndQty", string.Concat(new string[]
								{
									" BillID=",
									dataTable6.Rows[i]["ID"].ToString(),
									" and StartQty<",
									dataRow[3].ToString(),
									" order by StartQty asc"
								})).Tables[0];
								if (dataTable8.Rows.Count > 0)
								{
									for (int k = 0; k < dataTable8.Rows.Count; k++)
									{
										if (num19 > 0)
										{
											int.TryParse(dataTable8.Rows[k]["StartQty"].ToString(), out num22);
											int.TryParse(dataTable8.Rows[k]["EndQty"].ToString(), out num23);
											int num24 = num23 - num22;
											if (num19 > num24)
											{
												num20 += num24 * decimal.Parse(dataTable8.Rows[k]["Price"].ToString());
											}
											else
											{
												num20 += num19 * decimal.Parse(dataTable8.Rows[k]["Price"].ToString());
											}
											num19 -= num24;
										}
									}
								}
								dataRow[6] = num20;
							}
							if (num15 == 3)
							{
								dataRow[6] = Convert.ToDouble((d8 - num13) * d4 / num14).ToString("#0.00");
							}
							if (num15 == 4)
							{
								if (this.tbEndDate.Text != "")
								{
									DateTime d9 = DateTime.Parse(dataTable6.Rows[i]["ChargeDate"].ToString());
									DateTime d10 = DateTime.Parse(this.tbEndDate.Text);
									decimal num25 = decimal.Parse((d10 - d9).Days.ToString()) / d;
									num25 = decimal.Round(num25, 0);
									if (num25 == 3m)
									{
										string text = d10.AddMonths(-3).ToString("yyyy-MM-dd");
										dataRow[4] = decimal.Parse(dataRow[9].ToString()) * 3m;
										DataTable dataTable9 = DALCommon.GetList("zl_meterreading", " top 1 *", string.Concat(new object[]
										{
											" [BillID]=",
											this.id,
											" and iBillID=",
											dataTable6.Rows[i]["ID"].ToString(),
											" and QtyType=",
											dataTable6.Rows[i]["QtyType"].ToString(),
											" and _Date='",
											text,
											"'"
										})).Tables[0];
										if (dataTable9.Rows.Count > 0)
										{
											dataRow[2] = decimal.Parse(dataTable9.Rows[0]["Qty"].ToString());
											dataRow[3] = decimal.Parse(dataRow[1].ToString()) - decimal.Parse(dataRow[2].ToString()) - decimal.Parse(dataRow[11].ToString());
										}
										dataRow[6] = (decimal.Parse(dataRow[3].ToString()) - decimal.Parse(dataRow[4].ToString())) * decimal.Parse(dataRow[5].ToString());
									}
									else
									{
										dataRow[6] = 0;
									}
								}
								else
								{
									dataRow[6] = 0;
								}
							}
							if (num15 == 5)
							{
								if (this.tbEndDate.Text != "")
								{
									DateTime d9 = DateTime.Parse(dataTable6.Rows[i]["ChargeDate"].ToString());
									DateTime d10 = DateTime.Parse(this.tbEndDate.Text);
									decimal num25 = decimal.Parse((d10 - d9).Days.ToString()) / d;
									num25 = decimal.Round(num25, 0);
									if (num25 == 3m)
									{
										string text = d10.AddMonths(-3).ToString("yyyy-MM-dd");
										dataRow[4] = decimal.Parse(dataRow[9].ToString()) * 3m;
										DataTable dataTable9 = DALCommon.GetList("zl_meterreading", " top 1 *", string.Concat(new object[]
										{
											" [BillID]=",
											this.id,
											" and iBillID=",
											dataTable6.Rows[i]["ID"].ToString(),
											" and QtyType=",
											dataTable6.Rows[i]["QtyType"].ToString(),
											" and _Date='",
											text,
											"'"
										})).Tables[0];
										if (dataTable9.Rows.Count > 0)
										{
											dataRow[2] = decimal.Parse(dataTable9.Rows[0]["Qty"].ToString());
											dataRow[3] = decimal.Parse(dataRow[1].ToString()) - decimal.Parse(dataRow[2].ToString()) - decimal.Parse(dataRow[11].ToString());
										}
										dataRow[6] = (decimal.Parse(dataRow[3].ToString()) - decimal.Parse(dataRow[4].ToString())) * decimal.Parse(dataRow[5].ToString());
									}
									else
									{
										dataRow[6] = 0;
									}
								}
								else
								{
									dataRow[6] = 0;
								}
							}
							if (num15 == 7)
							{
								if (num8 > 0m)
								{
									int num26 = int.Parse(dataRow["BQty"].ToString()) - int.Parse(dataRow["SQty"].ToString()) - int.Parse(dataRow["Loss"].ToString());
									int num27 = int.Parse(dataRow["Rated"].ToString()) - num26;
									if (num27 < 0)
									{
										decimal d11 = num8 / decimal.Parse(dataRow[5].ToString());
										decimal num28 = -num27;
										if (d11 > num28)
										{
											dataRow[3] = num26;
											dataRow[6] = 0;
											num8 -= num28 * decimal.Parse(dataRow["ZhangFee"].ToString());
										}
										else
										{
											dataRow[3] = num26;
											dataRow[6] = (num28 * decimal.Parse(dataRow["ZhangFee"].ToString()) - num8).ToString("f2");
											num8 = 0m;
										}
									}
								}
							}
							if (num15 == 8)
							{
								dataRow[4] = decimal.Parse(dataRow[9].ToString()) * 12m;
								DataTable dataTable9 = DALCommon.GetList("zl_meterreading", " top 1 *", string.Concat(new object[]
								{
									" [BillID]=",
									this.id,
									" and iBillID=",
									dataTable6.Rows[i]["ID"].ToString(),
									" and QtyType=",
									dataTable6.Rows[i]["QtyType"].ToString(),
									" and _Date>'",
									DateTime.Now.ToString("yyyy"),
									"' order by _Date asc"
								})).Tables[0];
								if (dataTable9.Rows.Count > 0)
								{
									decimal d12 = decimal.Parse(dataRow[2].ToString());
									decimal d13 = decimal.Parse(dataTable9.Rows[0]["Qty"].ToString());
									decimal d14 = d12 - d13;
									if (d14 > decimal.Parse(dataRow[4].ToString()))
									{
										dataRow[4] = 0;
										dataRow[3] = decimal.Parse(dataRow[1].ToString()) - decimal.Parse(dataRow[2].ToString()) - decimal.Parse(dataRow[11].ToString());
									}
									else
									{
										dataRow[2] = decimal.Parse(dataTable9.Rows[0]["Qty"].ToString());
										dataRow[3] = decimal.Parse(dataRow[1].ToString()) - decimal.Parse(dataRow[2].ToString()) - decimal.Parse(dataRow[11].ToString());
									}
								}
								dataRow[6] = (decimal.Parse(dataRow[3].ToString()) - decimal.Parse(dataRow[4].ToString())) * decimal.Parse(dataRow[5].ToString());
							}
							if (decimal.Parse(dataRow[6].ToString()) < 0m)
							{
								dataRow[6] = 0;
							}
							if (num15 == 5)
							{
								num5 += decimal.Parse(dataRow[6].ToString());
							}
							else
							{
								num4 += decimal.Parse(dataRow[6].ToString());
							}
							gridViewSource.Rows.Add(dataRow);
						}
					}
					else
					{
						this.tbCycle.Text = "0";
						this.tbStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
					}
				}
				this.tbRent.Text = num9.ToString("#0.00");
				this.tbCycled.Text = this.tbCycle.Text;
				this.tbARent.Text = Convert.ToDouble(decimal.Parse(this.tbCycle.Text) * decimal.Parse(this.tbRent.Text)).ToString("#0.00");
				decimal num29 = 0m;
				decimal.TryParse(this.tbARent.Text, out num29);
				this.tbAARent.Text = this.tbARent.Text;
				if (num5 > 0m)
				{
					if (num5 > d5)
					{
						num4 = num4 + num5 - d5;
					}
				}
				if (num7 > 0m)
				{
					if (num29 > num7)
					{
						num4 -= num7;
					}
					else
					{
						num4 -= num29;
					}
				}
				this.tbAASuperZhangFee.Text = num4.ToString("#0.00");
				decimal num30 = num29 + num4;
				this.tbRec.Text = num30.ToString("#0.00");
				this.GridViewSource = gridViewSource;
				this.BindData();
			}
			else
			{
				this.btnAdd.Enabled = false;
			}
		}
	}

	private void BindData()
	{
		this.gvdata.DataSource = this.GridViewSource;
		this.gvdata.DataBind();
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Cells[0].Text = Convert.ToDouble(e.Row.RowIndex + 1).ToString();
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[0].Attributes.Add("style", "width:20px;padding-right:0px;text-align:center;");
			decimal.TryParse(e.Row.Cells[4].Text, out this.dtest);
			this.dr1 += this.dtest;
			decimal.TryParse(e.Row.Cells[5].Text, out this.dtest);
			this.dr2 += this.dtest;
			decimal.TryParse(e.Row.Cells[6].Text, out this.dtest);
			this.dr3 += this.dtest;
			decimal.TryParse(e.Row.Cells[7].Text, out this.dtest);
			this.dr4 += this.dtest;
			decimal.TryParse(e.Row.Cells[8].Text, out this.dtest);
			this.dr5 += this.dtest;
			decimal.TryParse(e.Row.Cells[9].Text, out this.dtest);
			this.dr6 = this.dtest;
			decimal.TryParse(e.Row.Cells[10].Text, out this.dtest);
			this.dr7 += this.dtest;
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[4].Text = this.dr1.ToString("#0");
			e.Row.Cells[5].Text = this.dr2.ToString("#0");
			e.Row.Cells[6].Text = this.dr3.ToString("#0");
			e.Row.Cells[7].Text = this.dr4.ToString("#0");
			e.Row.Cells[8].Text = this.dr5.ToString("#0");
			e.Row.Cells[10].Text = this.dr7.ToString("#0.00");
			e.Row.Attributes.Add("style", "color:#ff0000;text-align:right;");
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		decimal num5 = 0m;
		decimal.TryParse(this.tbRec.Text, out num5);
		if (num5 <= 0m)
		{
			this.SysInfo("window.alert('操作失败！合计应收必须大于0');");
		}
		else
		{
			LeaseChargeInfo leaseChargeInfo = new LeaseChargeInfo();
			DataTable gridViewSource = this.GridViewSource;
			if (gridViewSource.Rows.Count > 0)
			{
				List<LeaseChargeDetailInfo> list = new List<LeaseChargeDetailInfo>();
				for (int i = 0; i < gridViewSource.Rows.Count; i++)
				{
					LeaseChargeDetailInfo leaseChargeDetailInfo = new LeaseChargeDetailInfo();
					int.TryParse(gridViewSource.Rows[i]["SQty"].ToString(), out num4);
					num += num4;
					int.TryParse(gridViewSource.Rows[i]["BQty"].ToString(), out num4);
					num2 += num4;
					int.TryParse(gridViewSource.Rows[i]["Loss"].ToString(), out num4);
					num3 += num4;
					leaseChargeDetailInfo.DeviceID = int.Parse(gridViewSource.Rows[i]["ID"].ToString());
					leaseChargeDetailInfo.QtyTypeID = int.Parse(gridViewSource.Rows[i]["QtyTypeID"].ToString());
					leaseChargeDetailInfo.BenQty = int.Parse(gridViewSource.Rows[i]["BQty"].ToString());
					leaseChargeDetailInfo.ShangQty = int.Parse(gridViewSource.Rows[i]["SQty"].ToString());
					leaseChargeDetailInfo.LossQty = int.Parse(gridViewSource.Rows[i]["Loss"].ToString());
					leaseChargeDetailInfo.Rated = int.Parse(gridViewSource.Rows[i]["Rated"].ToString());
					leaseChargeDetailInfo.SupperZhangFee = decimal.Parse(gridViewSource.Rows[i]["ZhangFee"].ToString());
					leaseChargeDetailInfo.ZSupperZhangFee = decimal.Parse(gridViewSource.Rows[i]["SuperZhangFee"].ToString());
					leaseChargeDetailInfo.ChargeDate = this.tbEndDate.Text;
					list.Add(leaseChargeDetailInfo);
				}
				leaseChargeInfo.LeaseChargeDetailInfos = list;
			}
			leaseChargeInfo._Date = DateTime.Now.ToString("yyyy-MM-dd");
			int operatorID = 0;
			int.TryParse((string)this.Session["Session_wtUserBID"], out operatorID);
			leaseChargeInfo.OperatorID = operatorID;
			leaseChargeInfo.BillID = this.id;
			int value = 0;
			int.TryParse(this.tbCycle.Text, out value);
			leaseChargeInfo.Cycle = value;
			leaseChargeInfo.dRec = num5;
			leaseChargeInfo.StartDate = this.tbStartDate.Text;
			leaseChargeInfo.EndDate = this.tbEndDate.Text;
			leaseChargeInfo.Status = 1;
			decimal superZhangFee = 0m;
			decimal.TryParse(this.tbAASuperZhangFee.Text, out superZhangFee);
			leaseChargeInfo.SuperZhangFee = superZhangFee;
			leaseChargeInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
			decimal rent = 0m;
			decimal.TryParse(this.tbRent.Text, out rent);
			leaseChargeInfo.Rent = rent;
			leaseChargeInfo.ShangQty = num;
			leaseChargeInfo.BenQty = num2;
			leaseChargeInfo.Loss = num3;
			DALLeaseCharge dALLeaseCharge = new DALLeaseCharge();
			int num7;
			int num6 = dALLeaseCharge.Add(leaseChargeInfo, out num7);
			if (num6 == 0)
			{
				this.SysInfo("window.alert('操作成功！结算单已生成');parent.CloseDialog('1');");
			}
			else
			{
				this.SysInfo("window.alert('系统错误，请查看错误日志！');");
			}
		}
	}

	protected void btncycle_Click(object sender, EventArgs e)
	{
		this.BindData();
	}

	protected void btncycled_Click(object sender, EventArgs e)
	{
		decimal num = 0m;
		decimal d = 30m;
		decimal d2 = 0m;
		decimal num2 = 0m;
		decimal num3 = 0m;
		decimal d3 = 0m;
		int num4 = 0;
		decimal num5 = 0m;
		int num6 = 0;
		decimal num7 = 0m;
		decimal d4 = 0m;
		decimal num8 = 0m;
		this.GridViewSource.Clear();
		DataTable gridViewSource = this.GridViewSource;
		DataTable dataTable = DALCommon.GetDataList("Lease", "Rent,ChargeCycle", " [ID]=" + this.id).Tables[0];
		if (dataTable.Rows.Count > 0)
		{
			decimal.TryParse(dataTable.Rows[0]["Rent"].ToString(), out num);
			decimal num9 = num;
			decimal.TryParse(dataTable.Rows[0]["ChargeCycle"].ToString(), out d);
			decimal d5 = num * 3m;
			this.tbCycle.Text = "0";
			string text = "";
			if (this.tbStartDate.Text != "")
			{
				text = text + " and _Date='" + this.tbStartDate.Text + "'";
			}
			string text2 = "";
			if (this.tbEndDate.Text != "")
			{
				text2 = text2 + " and _Date='" + this.tbEndDate.Text + "'";
			}
			DataTable dataTable2 = DALCommon.GetDataList("zl_leasedetail", "QtyType", " DevStatus='正常' and iBillID=" + this.id + " group by QtyType").Tables[0];
			DataTable dataTable3 = DALCommon.GetList("zl_meterreading", "*", " [BillID]=" + this.id + " and Cstyle=7 order by [_Date] desc").Tables[0];
			while (dataTable3.Rows.Count > 0)
			{
				string str = dataTable3.Rows[0]["QtyType"].ToString();
				DataRow[] array = dataTable3.Select("QtyType=" + str, "[_Date] desc");
				if (array.Length == 1)
				{
					num4 = int.Parse(array[0]["Qty"].ToString()) - int.Parse(array[0]["Loss"].ToString());
					int num10 = (int)num2 * int.Parse(array[0]["Rated"].ToString());
					decimal num11 = (num10 - num4) * decimal.Parse(array[0]["SuperZhangFee"].ToString());
					if (num10 > 0 && num11 > 0m)
					{
						num8 += num11;
					}
				}
				else if (array.Length > 1)
				{
					DateTime d6 = DateTime.Parse(array[1]["_Date"].ToString());
					DateTime d7 = DateTime.Parse(array[0]["_Date"].ToString());
					num2 = decimal.Parse((d7 - d6).Days.ToString()) / d;
					int num10 = (int)num2 * int.Parse(array[0]["Rated"].ToString());
					num4 = int.Parse(array[0]["Qty"].ToString()) - int.Parse(array[1]["Qty"].ToString()) - int.Parse(array[0]["Loss"].ToString());
					decimal num11 = (num10 - num4) * decimal.Parse(array[0]["SuperZhangFee"].ToString());
					if (num10 > 0 && num11 > 0m)
					{
						num8 += num11;
					}
				}
				for (int i = 0; i < array.Length; i++)
				{
					dataTable3.Rows.Remove(array[i]);
				}
			}
			for (int j = 0; j < dataTable2.Rows.Count; j++)
			{
				decimal d8 = 0m;
				decimal num12 = 0m;
				int num13 = 0;
				DataTable dataTable4 = DALCommon.GetDataList("zl_leasedetail", "", string.Concat(new object[]
				{
					" QtyType=",
					dataTable2.Rows[j]["QtyType"].ToString(),
					" and DevStatus='正常' and iBillID=",
					this.id
				})).Tables[0];
				if (dataTable4.Rows.Count > 0)
				{
					for (int i = 0; i < dataTable4.Rows.Count; i++)
					{
						int num14 = 1;
						int.TryParse(dataTable4.Rows[i]["CStyle"].ToString(), out num14);
						DataTable dataTable5 = DALCommon.GetList("zl_meterreading", " top 1 *", string.Concat(new object[]
						{
							" [BillID]=",
							this.id,
							" and iBillID=",
							dataTable4.Rows[i]["ID"].ToString(),
							" and QtyType=",
							dataTable4.Rows[i]["QtyType"].ToString(),
							text,
							" order by [_Date] desc"
						})).Tables[0];
						int count = dataTable5.Rows.Count;
						DataTable dataTable6 = DALCommon.GetList("zl_meterreading", " top 1 *", string.Concat(new object[]
						{
							" [BillID]=",
							this.id,
							" and iBillID=",
							dataTable4.Rows[i]["ID"].ToString(),
							" and QtyType=",
							dataTable4.Rows[i]["QtyType"].ToString(),
							text2,
							" order by [_Date] desc"
						})).Tables[0];
						int count2 = dataTable6.Rows.Count;
						if (count > 0 && count2 > 0)
						{
							num4 = int.Parse(dataTable6.Rows[0]["Qty"].ToString()) - int.Parse(dataTable5.Rows[0]["Qty"].ToString()) - int.Parse(dataTable5.Rows[0]["Loss"].ToString()) - int.Parse(dataTable6.Rows[0]["Loss"].ToString());
							this.tbStartDate.Text = dataTable5.Rows[0]["_Date"].ToString();
							this.tbEndDate.Text = dataTable6.Rows[0]["_Date"].ToString();
							DateTime d6 = DateTime.Parse(dataTable5.Rows[0]["_Date"].ToString());
							DateTime d7 = DateTime.Parse(dataTable6.Rows[0]["_Date"].ToString());
							num2 = decimal.Parse((d7 - d6).Days.ToString()) / d;
							num2 = decimal.Round(num2, 0);
							this.tbCycle.Text = num2.ToString();
						}
						else if (count > 0)
						{
							num4 = int.Parse(dataTable5.Rows[0]["Qty"].ToString()) - int.Parse(dataTable5.Rows[0]["Loss"].ToString());
							this.tbStartDate.Text = dataTable5.Rows[0]["_Date"].ToString();
							this.tbCycle.Text = "0";
						}
						else if (count2 > 0)
						{
							num4 = int.Parse(dataTable6.Rows[0]["Qty"].ToString()) - int.Parse(dataTable6.Rows[0]["Loss"].ToString());
							this.tbEndDate.Text = dataTable6.Rows[0]["_Date"].ToString();
							this.tbCycle.Text = "0";
						}
						if (num2 == 0m)
						{
							num2 = 1m;
						}
						d2 += num2 * int.Parse(dataTable4.Rows[i]["Rated"].ToString());
						decimal num15 = decimal.Parse(dataTable4.Rows[i]["SuperZhangFee"].ToString());
						d3 += num4;
						num6++;
						if (num14 == 3)
						{
							d8 += num4;
							num12 += num2 * int.Parse(dataTable4.Rows[i]["Rated"].ToString());
							num13++;
							d4 = decimal.Parse(dataTable4.Rows[i]["SuperZhangFee"].ToString());
						}
						if (num14 == 6)
						{
							num7 += (num4 - num2 * decimal.Parse(dataTable4.Rows[i]["Rated"].ToString())) * decimal.Parse(dataTable4.Rows[i]["SuperZhangFee"].ToString());
						}
					}
				}
				else
				{
					DateTime d6 = DateTime.Parse(this.tbStartDate.Text);
					DateTime d7 = DateTime.Parse(this.tbEndDate.Text);
					num2 = decimal.Parse((d7 - d6).Days.ToString()) / d;
					num2 = decimal.Round(num2, 0);
					this.tbCycle.Text = num2.ToString();
				}
				DataTable dataTable7 = DALCommon.GetDataList("zl_leasedetail", "", string.Concat(new object[]
				{
					" QtyType=",
					dataTable2.Rows[j]["QtyType"].ToString(),
					" and DevStatus='正常' and iBillID=",
					this.id
				})).Tables[0];
				if (dataTable7.Rows.Count > 0)
				{
					for (int i = 0; i < dataTable7.Rows.Count; i++)
					{
						int num14 = 1;
						int.TryParse(dataTable7.Rows[i]["CStyle"].ToString(), out num14);
						DataRow dataRow = gridViewSource.NewRow();
						dataRow[0] = dataTable7.Rows[i]["QtyTypeName"].ToString();
						dataRow[1] = 0;
						dataRow[2] = 0;
						dataRow[11] = 0;
						DataTable dataTable8 = DALCommon.GetList("zl_meterreading", " top 1 *", string.Concat(new object[]
						{
							" [BillID]=",
							this.id,
							" and iBillID=",
							dataTable7.Rows[i]["ID"].ToString(),
							" and QtyType=",
							dataTable7.Rows[i]["QtyType"].ToString(),
							text,
							" order by [_Date] desc"
						})).Tables[0];
						int count3 = dataTable8.Rows.Count;
						DataTable dataTable9 = DALCommon.GetList("zl_meterreading", " top 1 *", string.Concat(new object[]
						{
							" [BillID]=",
							this.id,
							" and iBillID=",
							dataTable7.Rows[i]["ID"].ToString(),
							" and QtyType=",
							dataTable7.Rows[i]["QtyType"].ToString(),
							text2,
							" order by [_Date] desc"
						})).Tables[0];
						int count4 = dataTable9.Rows.Count;
						if (count3 > 0 && count4 > 0)
						{
							DateTime d6 = DateTime.Parse(dataTable8.Rows[0]["_Date"].ToString());
							DateTime d7 = DateTime.Parse(dataTable9.Rows[0]["_Date"].ToString());
							num2 = decimal.Parse((d7 - d6).Days.ToString()) / d;
							num2 = decimal.Round(num2, 0);
							this.tbCycle.Text = num2.ToString();
							dataRow[1] = decimal.Parse(dataTable9.Rows[0]["Qty"].ToString());
							dataRow[2] = decimal.Parse(dataTable8.Rows[0]["Qty"].ToString());
							dataRow[11] = decimal.Parse(dataTable8.Rows[0]["Loss"].ToString()) + decimal.Parse(dataTable9.Rows[0]["Loss"].ToString());
						}
						else if (count3 > 0)
						{
							dataRow[2] = decimal.Parse(dataTable8.Rows[0]["Qty"].ToString());
							this.tbCycle.Text = "0";
							dataRow[11] = decimal.Parse(dataTable8.Rows[0]["Loss"].ToString());
						}
						else if (count4 > 0)
						{
							dataRow[1] = decimal.Parse(dataTable9.Rows[0]["Qty"].ToString());
							this.tbCycle.Text = "0";
							dataRow[11] = decimal.Parse(dataTable9.Rows[0]["Loss"].ToString());
						}
						if (this.tbStartDate.Text != "" && this.tbEndDate.Text != "")
						{
							DateTime d6 = DateTime.Parse(this.tbStartDate.Text);
							DateTime d7 = DateTime.Parse(this.tbEndDate.Text);
							num2 = decimal.Parse((d7 - d6).Days.ToString()) / d;
							num2 = decimal.Round(num2, 0);
							this.tbCycle.Text = num2.ToString();
						}
						if (num2 == 0m)
						{
							num2 = 1m;
						}
						dataRow[3] = decimal.Parse(dataRow[1].ToString()) - decimal.Parse(dataRow[2].ToString()) - decimal.Parse(dataRow[11].ToString());
						dataRow[4] = num2 * decimal.Parse(dataTable7.Rows[i]["Rated"].ToString());
						dataRow[5] = decimal.Parse(dataTable7.Rows[i]["SuperZhangFee"].ToString());
						dataRow[6] = (decimal.Parse(dataRow[3].ToString()) - decimal.Parse(dataRow[4].ToString())) * decimal.Parse(dataRow[5].ToString());
						dataRow[7] = int.Parse(dataTable7.Rows[i]["ID"].ToString());
						dataRow[8] = int.Parse(dataTable7.Rows[i]["BillID"].ToString());
						dataRow[9] = decimal.Parse(dataTable7.Rows[i]["Rated"].ToString());
						dataRow[10] = dataTable7.Rows[i]["ProductSN1"].ToString();
						dataRow[12] = dataTable7.Rows[i]["ChargeStyle"].ToString();
						dataRow[13] = dataTable7.Rows[i]["CStyle"].ToString();
						dataRow[14] = 0;
						dataRow[15] = dataTable7.Rows[i]["ChargeDate"].ToString();
						if (num14 == 2)
						{
							int num16 = 0;
							int.TryParse(dataRow[3].ToString(), out num16);
							int num17 = 0;
							int.TryParse(dataRow[4].ToString(), out num17);
							num16 -= num17;
							decimal num18 = 0m;
							int num19 = 0;
							int num20 = 0;
							DataTable dataTable10 = DALCommon.GetDataList("LeaseFormula", "Price,StartQty,EndQty", string.Concat(new string[]
							{
								" BillID=",
								dataTable7.Rows[i]["ID"].ToString(),
								" and StartQty<",
								dataRow[3].ToString(),
								" order by StartQty asc"
							})).Tables[0];
							if (dataTable10.Rows.Count > 0)
							{
								for (int k = 0; k < dataTable10.Rows.Count; k++)
								{
									if (num16 > 0)
									{
										int.TryParse(dataTable10.Rows[k]["StartQty"].ToString(), out num19);
										int.TryParse(dataTable10.Rows[k]["EndQty"].ToString(), out num20);
										int num21 = num20 - num19;
										if (num16 > num21)
										{
											num18 += num21 * decimal.Parse(dataTable10.Rows[k]["Price"].ToString());
										}
										else
										{
											num18 += num16 * decimal.Parse(dataTable10.Rows[k]["Price"].ToString());
										}
										num16 -= num21;
									}
								}
							}
							dataRow[6] = num18;
						}
						if (num14 == 3)
						{
							dataRow[6] = Convert.ToDouble((d8 - num12) * d4 / num13).ToString("#0.00");
						}
						if (num14 == 4)
						{
							if (this.tbEndDate.Text != "")
							{
								DateTime d9 = DateTime.Parse(dataTable7.Rows[i]["ChargeDate"].ToString());
								DateTime d10 = DateTime.Parse(this.tbEndDate.Text);
								decimal num22 = decimal.Parse((d10 - d9).Days.ToString()) / d;
								num22 = decimal.Round(num22, 0);
								if (num22 == 3m)
								{
									string text3 = d10.AddMonths(-3).ToString("yyyy-MM-dd");
									dataRow[4] = decimal.Parse(dataRow[9].ToString()) * 3m;
									DataTable dataTable11 = DALCommon.GetList("zl_meterreading", " top 1 *", string.Concat(new object[]
									{
										" [BillID]=",
										this.id,
										" and iBillID=",
										dataTable7.Rows[i]["ID"].ToString(),
										" and QtyType=",
										dataTable7.Rows[i]["QtyType"].ToString(),
										" and _Date='",
										text3,
										"'"
									})).Tables[0];
									if (dataTable11.Rows.Count > 0)
									{
										dataRow[2] = decimal.Parse(dataTable11.Rows[0]["Qty"].ToString());
										dataRow[3] = decimal.Parse(dataRow[1].ToString()) - decimal.Parse(dataRow[2].ToString()) - decimal.Parse(dataRow[11].ToString());
									}
									dataRow[6] = (decimal.Parse(dataRow[3].ToString()) - decimal.Parse(dataRow[4].ToString())) * decimal.Parse(dataRow[5].ToString());
								}
								else
								{
									dataRow[6] = 0;
								}
							}
							else
							{
								dataRow[6] = 0;
							}
						}
						if (num14 == 5)
						{
							if (this.tbEndDate.Text != "")
							{
								DateTime d9 = DateTime.Parse(dataTable7.Rows[i]["ChargeDate"].ToString());
								DateTime d10 = DateTime.Parse(this.tbEndDate.Text);
								decimal num22 = decimal.Parse((d10 - d9).Days.ToString()) / d;
								num22 = decimal.Round(num22, 0);
								if (num22 == 3m)
								{
									string text3 = d10.AddMonths(-3).ToString("yyyy-MM-dd");
									dataRow[4] = decimal.Parse(dataRow[9].ToString()) * 3m;
									DataTable dataTable11 = DALCommon.GetList("zl_meterreading", " top 1 *", string.Concat(new object[]
									{
										" [BillID]=",
										this.id,
										" and iBillID=",
										dataTable7.Rows[i]["ID"].ToString(),
										" and QtyType=",
										dataTable7.Rows[i]["QtyType"].ToString(),
										" and _Date='",
										text3,
										"'"
									})).Tables[0];
									if (dataTable11.Rows.Count > 0)
									{
										dataRow[2] = decimal.Parse(dataTable11.Rows[0]["Qty"].ToString());
										dataRow[3] = decimal.Parse(dataRow[1].ToString()) - decimal.Parse(dataRow[2].ToString()) - decimal.Parse(dataRow[11].ToString());
									}
									dataRow[6] = (decimal.Parse(dataRow[3].ToString()) - decimal.Parse(dataRow[4].ToString())) * decimal.Parse(dataRow[5].ToString());
								}
								else
								{
									dataRow[6] = 0;
								}
							}
							else
							{
								dataRow[6] = 0;
							}
						}
						if (num14 == 7)
						{
							if (num8 > 0m)
							{
								int num23 = int.Parse(dataRow["BQty"].ToString()) - int.Parse(dataRow["SQty"].ToString()) - int.Parse(dataRow["Loss"].ToString());
								int num24 = int.Parse(dataRow["Rated"].ToString()) - num23;
								if (num24 < 0)
								{
									decimal d11 = num8 / decimal.Parse(dataRow[5].ToString());
									decimal num25 = -num24;
									if (d11 > num25)
									{
										dataRow[3] = num23;
										dataRow[6] = 0;
										num8 -= num25 * decimal.Parse(dataRow["ZhangFee"].ToString());
									}
									else
									{
										dataRow[3] = num23;
										dataRow[6] = (num25 * decimal.Parse(dataRow["ZhangFee"].ToString()) - num8).ToString("f2");
										num8 = 0m;
									}
								}
							}
						}
						if (num14 == 8)
						{
							dataRow[4] = decimal.Parse(dataRow[9].ToString()) * 12m;
							DataTable dataTable11 = DALCommon.GetList("zl_meterreading", " top 1 *", string.Concat(new object[]
							{
								" [BillID]=",
								this.id,
								" and iBillID=",
								dataTable7.Rows[i]["ID"].ToString(),
								" and QtyType=",
								dataTable7.Rows[i]["QtyType"].ToString(),
								" and _Date>'",
								DateTime.Now.ToString("yyyy"),
								"' order by _Date asc"
							})).Tables[0];
							if (dataTable11.Rows.Count > 0)
							{
								decimal d12 = decimal.Parse(dataRow[2].ToString());
								decimal d13 = decimal.Parse(dataTable11.Rows[0]["Qty"].ToString());
								decimal d14 = d12 - d13;
								if (d14 > decimal.Parse(dataRow[4].ToString()))
								{
									dataRow[4] = 0;
									dataRow[3] = decimal.Parse(dataRow[1].ToString()) - decimal.Parse(dataRow[2].ToString()) - decimal.Parse(dataRow[11].ToString());
								}
								else
								{
									dataRow[2] = decimal.Parse(dataTable11.Rows[0]["Qty"].ToString());
									dataRow[3] = decimal.Parse(dataRow[1].ToString()) - decimal.Parse(dataRow[2].ToString()) - decimal.Parse(dataRow[11].ToString());
								}
							}
							dataRow[6] = (decimal.Parse(dataRow[3].ToString()) - decimal.Parse(dataRow[4].ToString())) * decimal.Parse(dataRow[5].ToString());
						}
						if (decimal.Parse(dataRow[6].ToString()) < 0m)
						{
							dataRow[6] = 0;
						}
						if (num14 == 5)
						{
							num5 += decimal.Parse(dataRow[6].ToString());
						}
						else
						{
							num3 += decimal.Parse(dataRow[6].ToString());
						}
						gridViewSource.Rows.Add(dataRow);
					}
				}
			}
			this.tbRent.Text = num9.ToString("#0.00");
			this.tbCycled.Text = this.tbCycle.Text;
			this.tbARent.Text = Convert.ToDouble(decimal.Parse(this.tbCycle.Text) * decimal.Parse(this.tbRent.Text)).ToString("#0.00");
			decimal num26 = 0m;
			decimal.TryParse(this.tbARent.Text, out num26);
			this.tbAARent.Text = this.tbARent.Text;
			if (num5 > 0m)
			{
				if (num5 > d5)
				{
					num3 = num3 + num5 - d5;
				}
			}
			if (num7 > 0m)
			{
				if (num26 > num7)
				{
					num3 -= num7;
				}
				else
				{
					num3 -= num26;
				}
			}
			this.tbAASuperZhangFee.Text = num3.ToString("#0.00");
			decimal num27 = num26 + num3;
			this.tbRec.Text = num27.ToString("#0.00");
			this.GridViewSource = gridViewSource;
			this.BindData();
		}
		else
		{
			this.btnAdd.Enabled = false;
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
	}
}
