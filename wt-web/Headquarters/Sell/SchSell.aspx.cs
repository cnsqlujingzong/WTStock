using EF;
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

public partial class Headquarters_Sell_SchSell : Page, IRequiresSessionState
{
	private int pageSize = 15;

	private static bool isLowPricePower = true;

	private decimal dqty = 0m;

	private decimal tqty = 0m;

	private decimal dprice = 0m;

	private decimal dtotal = 0m;

	private decimal dre1 = 0m;

	private decimal dre2 = 0m;

	private decimal dtaxamount = 0m;

	private decimal dgoodsamount = 0m;
    private DataTable sell;
	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num == 0)
			{
				this.btnChk1.Visible = false;
			}
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "xs_r3"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
				if (!dALRight.GetRight(num, "xs_r5"))
				{
					this.btnChk.Enabled = false;
				}
				if (dALRight.GetRight(num, "xs_r20"))
				{
					this.hfOperatorID.Value = "1";
				}
				if (!dALRight.GetRight(num, "xs_r6"))
				{
					this.btnChkU.Enabled = false;
				}
				if (!dALRight.GetRight(num, "xs_r7"))
				{
					this.btnDel.Enabled = false;
				}
				if (!dALRight.GetRight(num, "xs_r8"))
				{
					this.btnExcel.Enabled = false;
				}
				if (!dALRight.GetRight(num, "xs_r9"))
				{
					this.btnPrint.Visible = false;
				}
				if (dALRight.GetRight(num, "xs_r19"))
				{
					this.hfPurDept.Value = "1";
				}
				if (dALRight.GetRight(num, "ck_r84"))
				{
					this.btnChk.Visible = false;
				}
				else
				{
					this.btnChk1.Visible = false;
				}
				if (dALRight.GetRight(num, "jc_r37"))
				{
					Headquarters_Sell_SchSell.isLowPricePower = false;
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
		this.hfParm.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void btnSchH_Click(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		if (this.hfParm.Value != "-1")
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
	}

	protected void btnFsh_Click(object sender, EventArgs e)
	{
		this.hfSch.Value = "-1";
		this.hfRecID.Value = "-1";
		this.hfParm.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void FillData(string sortExpression, string direction)
	{
		int recordCount = 0;
		string text = (this.hfParm.Value == "-1") ? this.strParm() : this.hfParm.Value;
		string fldSort = sortExpression + " " + direction;
		if (this.hfPurDept.Value == "1")
		{
			text = text + " and (OperatorID in(select ID from StaffList where StaffDeptID=(select StaffDeptID from StaffList where ID=" + (string)this.Session["Session_wtUserID"] + ")) or OperatorID is null)";
		}
		int num = 0;
		int.TryParse(this.ddlStatus.SelectedValue, out num);
		if (num > 0)
		{
			text = text + " and Status='" + this.ddlStatus.SelectedItem.Text.Trim() + "' ";
		}
		this.hfSql.Value = text;
		this.gvdata.DataSource = DALCommon.GetList_HL(1, "v_xs_selldetail", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
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
						HiddenField expr_364 = this.hfTbTitle;
						expr_364.Value = expr_364.Value + "," + text2;
					}
					if (this.hfTbField.Value == string.Empty)
					{
						this.hfTbField.Value = dataField;
					}
					else
					{
						HiddenField expr_3B4 = this.hfTbField;
						expr_3B4.Value = expr_3B4.Value + "," + dataField;
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
		string text = " DeptID=1 ";
		if (this.hfOperatorID.Value == "1")
		{
			text = text + " and Operator='" + this.Session["Session_wtUser"].ToString() + "' ";
		}
		string text2 = FunLibrary.ChkInput(this.tbCon.Text);
		if (this.hfSch.Value == "0")
		{
			if (this.ddlKey.SelectedValue != "-1")
			{
				int schid = 0;
				int.TryParse(this.ddlKey.SelectedValue, out schid);
				if (text2 != "")
				{
					DALSell dALSell = new DALSell();
					text += dALSell.GetSchWhere(schid, text2);
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
			if (e.Row.Cells[1].Text == "�����")
			{
				e.Row.Attributes.Add("style", "color:#ff0000");
			}
			else if (e.Row.Cells[1].Text == "�����")
			{
				e.Row.Attributes.Add("style", "color:#008000");
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
		DALSell dALSell = new DALSell();
		string empty = string.Empty;
		int iOperator = 0;
		int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
		bool flag = new DALSell().comparePrice(num);
		if (!Headquarters_Sell_SchSell.isLowPricePower)
		{
			if (!flag)
			{
				this.SysInfo("window.alert('���ʧ�ܣ�û�С��������������ۼ۳��⡱��Ȩ��');");
				this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
				return;
			}
		}
		int num2 = dALSell.ChkSell(1, num, iOperator, out empty);
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		string text = "";
		if (num2 != 0)
		{
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"window.alert('",
				empty,
				"');ChkID('",
				this.hfRecID.Value,
				"');"
			});
            WTLog.WriteLog("���۵�", this.hfRecID.Value, "������۵�", "���ʧ��", empty);
		}
		else
		{
			text = "ChkID('" + this.hfRecID.Value + "');";
            WTLog.WriteLog("���۵�", this.hfRecID.Value,"������۵�","��˳ɹ�");
            //by coding  ����������
     

       
            RcvSndInfo rcvSndInfo = new RcvSndInfo();
            rcvSndInfo.DeptID = new int?(1);
            rcvSndInfo._Date = DateTime.Now.ToString("yyyy-MM-dd");
            rcvSndInfo.OperatorID = new int?(int.Parse(Session["Session_wtUserID"].ToString()));
            rcvSndInfo.PersonID = new int?(int.Parse(this.Session["Session_wtUserID"].ToString()));  //Session["Session_wtUser"]
            rcvSndInfo.OperationType = "����";
            rcvSndInfo.RcvType = "�ͻ�";
            rcvSndInfo.RcvDeptID = -1;//new int?(int.Parse(this.ddlBranch.SelectedValue));
            DataTable spn;
            DataTable spd;
            string summary = "";
      
                spn = DALCommon.GetDataList("xs_sell", "", " [ID]=" +num).Tables[0];
                summary += "������ͬ��" + spn.Rows[0]["BillID"].ToString() + "           ";
                spd = DALCommon.GetDataList("xs_selldetail", "", " [BillID]=" + spn.Rows[0]["ID"]).Tables[0];
                if (spd.Rows.Count > 0)
                {
                    summary += "��Ʒ��Ϣ��";
                    foreach (DataRow item in spd.Rows)
                    {
                        summary += item["_Name"].ToString() + " x " + item["Qty"] + "��";
                    }
                    summary = summary.Substring(0, summary.Length - 1);
                }
                if (string.IsNullOrEmpty(spn.Rows[0]["isDai"].ToString()) || spn.Rows[0]["isDai"].ToString()=="0")
                {
                    rcvSndInfo.CorpName = spn.Rows[0]["_Name"].ToString();
                    rcvSndInfo.LinkMan = spn.Rows[0]["LinkMan"].ToString();
                    rcvSndInfo.Tel = spn.Rows[0]["Tel"].ToString();
                    rcvSndInfo.Adr = spn.Rows[0]["Adr"].ToString();
                }
                if (spn.Rows[0]["isDai"].ToString() == "0")
                {
                    rcvSndInfo.CorpName = spn.Rows[0]["_Name2"].ToString();
                    rcvSndInfo.LinkMan = spn.Rows[0]["LinkMan2"].ToString();
                    rcvSndInfo.Tel = spn.Rows[0]["Tel2"].ToString();
                    rcvSndInfo.Adr = spn.Rows[0]["Adr2"].ToString();
                }
             
                rcvSndInfo.Zip = "";
                rcvSndInfo.Summary = summary;
                rcvSndInfo.SndStyleID = 1;
                rcvSndInfo.PostNO = "";
                rcvSndInfo.Postage = 0;
                rcvSndInfo.Remark = "";
                DALRcvSnd dALRcvSnd = new DALRcvSnd();
                int iTbid = 0;
                int result = dALRcvSnd.Add(rcvSndInfo, out iTbid);

                WTLog.WriteLog("���ⵥ", iTbid.ToString(), "������۵�:" + spn.Rows[0]["BillID"].ToString() + "�Զ�����", "������ͬ��" + spn.Rows[0]["BillID"].ToString());


		}
		this.SysInfo(text);
	}

	protected void btnChk1_Click(object sender, EventArgs e)
	{
		int num = 0;
		int.TryParse(this.hfRecID.Value, out num);
		DALSell dALSell = new DALSell();
		string empty = string.Empty;
		int iOperator = 0;
		int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
		bool flag = new DALSell().comparePrice(num);
		if (!Headquarters_Sell_SchSell.isLowPricePower)
		{
			if (!flag)
			{
				this.SysInfo("window.alert('���ʧ�ܣ�û�С��������������ۼ۳��⡱��Ȩ��');");
				this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
				return;
			}
		}
		int num2 = dALSell.ChkSell1(1, num, iOperator, out empty);
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		string text = "";
		if (num2 != 0)
		{
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"window.alert('",
				empty,
				"');ChkID('",
				this.hfRecID.Value,
				"');"
			});
		}
		else
		{
			text = "ChkID('" + this.hfRecID.Value + "');";
            //by coding  ����������



            RcvSndInfo rcvSndInfo = new RcvSndInfo();
            rcvSndInfo.DeptID = new int?(1);
            rcvSndInfo._Date = DateTime.Now.ToString("yyyy-MM-dd");
            rcvSndInfo.OperatorID = new int?(int.Parse(Session["Session_wtUserID"].ToString()));
            rcvSndInfo.PersonID = new int?(int.Parse(this.Session["Session_wtUserID"].ToString()));  //Session["Session_wtUser"]
            rcvSndInfo.OperationType = "����";
            rcvSndInfo.RcvType = "�ͻ�";
            rcvSndInfo.RcvDeptID = -1;//new int?(int.Parse(this.ddlBranch.SelectedValue));
            DataTable spn;
            DataTable spd;
            string summary = "";

            spn = DALCommon.GetDataList("xs_sell", "", " [ID]=" + num).Tables[0];
            summary += "������ͬ��" + spn.Rows[0]["BillID"].ToString() + "           ";
            spd = DALCommon.GetDataList("xs_selldetail", "", " [BillID]=" + spn.Rows[0]["ID"]).Tables[0];
            if (spd.Rows.Count > 0)
            {
                summary += "��Ʒ��Ϣ��";
                foreach (DataRow item in spd.Rows)
                {
                    summary += item["_Name"].ToString() + " x " + item["Qty"] + "��";
                }
                summary = summary.Substring(0, summary.Length - 1);
            }

            rcvSndInfo.CorpName = spn.Rows[0]["_Name"].ToString();//�����ͻ����人��˹���������޹�˾
            rcvSndInfo.LinkMan = spn.Rows[0]["LinkMan"].ToString();
            rcvSndInfo.Tel = spn.Rows[0]["Tel"].ToString();
            rcvSndInfo.Adr = spn.Rows[0]["Adr"].ToString();
            rcvSndInfo.Zip = "";
            rcvSndInfo.Summary = summary;
            rcvSndInfo.SndStyleID = 1;
            rcvSndInfo.PostNO = "";
            rcvSndInfo.Postage = 0;
            rcvSndInfo.Remark = "";
            DALRcvSnd dALRcvSnd = new DALRcvSnd();
            int iTbid = 0;
            int result = dALRcvSnd.Add(rcvSndInfo, out iTbid);
            
		}
		this.SysInfo(text);
	}

	protected void btnChkU_Click(object sender, EventArgs e)
	{
		int iTbid = 0;
		int.TryParse(this.hfRecID.Value, out iTbid);
		DALSell dALSell = new DALSell();
		string empty = string.Empty;
		int iOperator = 0;
		int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
		int num = dALSell.ChkSellU(1, iTbid, iOperator, out empty);
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		string text = "";
		if (num != 0)
		{
			string text2 = text;
			text = string.Concat(new string[]
			{
				text2,
				"window.alert('",
				empty,
				"');ChkID('",
				this.hfRecID.Value,
				"');"
			});
            WTLog.WriteLog("���۵�", iTbid.ToString(), "��������۵�", "�����ʧ��",empty);
		}
		else
		{
			text = "ChkID('" + this.hfRecID.Value + "');";
            WTLog.WriteLog("���۵�", iTbid.ToString(), "��������۵�", "����˳ɹ�");
		}
		this.SysInfo(text);
	}

	protected void btnDel_Click(object sender, EventArgs e)
	{
		int iTbid = 0;
		int.TryParse(this.hfRecID.Value, out iTbid);
		DALSell dALSell = new DALSell();
		string empty = string.Empty;
		int iOperator = 0;
		int.TryParse((string)this.Session["Session_wtUserID"], out iOperator);
		int num = dALSell.Delete(1, iTbid, iOperator, out empty);
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		if (num == 0)
		{
			this.hfRecID.Value = "-1";
            WTLog.WriteLog("���۵�", iTbid.ToString(), "ɾ�����۵�", "�ɹ�");
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
            WTLog.WriteLog("���۵�", iTbid.ToString(), "ɾ�����۵�", "ʧ��",empty);
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
		DataTable dt = DALCommon.GetDataList("v_xs_selldetail", this.hfTbField.Value, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "���۵�", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert(\"" + empty + "\");");
		}
	}

	protected void btnExcelDe_Click(object sender, EventArgs e)
	{
		DataTable dt = DALCommon.GetDataList("xs_selldetail", this.hfTbFieldDe.Value, " BillID=" + this.hfRecID.Value).Tables[0];
		string[] tbTitle = this.hfTbTitleDe.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "���۵���ϸ", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.ShowDetail();
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
			e.Row.Cells[1].Attributes.Add("style", "width:30px;padding:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
			decimal.TryParse(e.Row.Cells[8].Text, out this.tqty);
			decimal.TryParse(e.Row.Cells[9].Text, out this.dprice);
			this.dqty += this.tqty;
			this.dtotal += this.tqty * this.dprice;
			string[] array = e.Row.Cells[15].Text.Split(new char[]
			{
				','
			});
			if (array.Length > 1)
			{
				e.Row.Cells[15].Text = "<a href=\"#\" onclick=\"ViewSN('" + e.Row.Cells[15].Text + "');\">�鿴���к�</a>";
			}
			decimal.TryParse(e.Row.Cells[13].Text, out this.dre1);
			this.dtaxamount += this.dre1;
			decimal.TryParse(e.Row.Cells[14].Text, out this.dre2);
			this.dgoodsamount += this.dre2;
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[1].Text = "�ϼ�";
			e.Row.Cells[1].Attributes.Add("style", "padding:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[8].Text = this.dqty.ToString("#0.00");
			e.Row.Cells[11].Text = this.dtotal.ToString("#0.00");

            string tax =this.dtaxamount.ToString("#0.00");
            string totle =this.dgoodsamount.ToString("#0.00");         
            if (sell != null && sell.Rows.Count > 0)
            {
              //  tax = (this.dgoodsamount * Convert.ToDecimal(sell.Rows[0]["BrandTaxRate"])).ToString("#0.00");
          //      totle = (this.dgoodsamount *(1+ Convert.ToDecimal(sell.Rows[0]["BrandTaxRate"]))).ToString("#0.00");
            }
           // e.Row.Cells[13].Text = tax;
            e.Row.Cells[14].Text = totle;
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
		this.GridView2.DataSource = DALCommon.GetDataList("xs_selldetail", "", " BillID=" + this.hfRecID.Value);
         sell = DALCommon.GetDataList("Sell", " top 1 BrandName,BrandTaxRate,BrandTaxRateType", " ID=" + this.hfRecID.Value).Tables[0];
		this.GridView2.DataBind();
		this.hfTbFieldDe.Value = (this.hfTbTitleDe.Value = string.Empty);
		if (this.GridView2.Rows.Count > 0)
		{
			for (int i = 0; i < this.GridView2.HeaderRow.Cells.Count; i++)
			{
				string dataField = ((BoundField)this.GridView2.Columns[i]).DataField;
				string text = this.GridView2.HeaderRow.Cells[i].Text;
				if (dataField != "" && dataField != "ID")
				{
					if (this.hfTbTitleDe.Value == string.Empty)
					{
						this.hfTbTitleDe.Value = text;
					}
					else
					{
						HiddenField expr_120 = this.hfTbTitleDe;
						expr_120.Value = expr_120.Value + "," + text;
					}
					if (this.hfTbFieldDe.Value == string.Empty)
					{
						this.hfTbFieldDe.Value = dataField;
					}
					else
					{
						HiddenField expr_16F = this.hfTbFieldDe;
						expr_16F.Value = expr_16F.Value + "," + dataField;
					}
				}
			}
		}
	}
}
