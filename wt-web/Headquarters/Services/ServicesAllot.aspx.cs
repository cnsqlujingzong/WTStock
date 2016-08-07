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
using Wuqi.Webdiyer;

public partial class Headquarters_Services_ServicesAllot : Page, IRequiresSessionState
{

	private int pageSize = 20;

	private int iflag;

	private bool blayout = false;

	private int itake = 26;

	private int purid = 0;

	private int count;

	private decimal dtest = 0m;

	private decimal dre1 = 0m;

	private decimal dre2 = 0m;

	private decimal dre3 = 0m;

	private decimal dre4 = 0m;

	private decimal dre5 = 0m;

	private decimal dre6 = 0m;

	private decimal dtestr = 0m;

	private decimal drer1 = 0m;

	private decimal drer2 = 0m;

	private decimal drer3 = 0m;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["iflag"], out this.iflag);
		if (!base.IsPostBack)
		{
			this.purid = int.Parse((string)this.Session["Session_wtPurID"]);
			if (this.purid > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(this.purid, "gd_r7"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
				if (!dALRight.GetRight(this.purid, "gd_r18"))
				{
					this.btnPrint.Visible = false;
				}
				if (!dALRight.GetRight(this.purid, "gd_r17"))
				{
					this.btnExcel.Enabled = false;
				}
				if (!dALRight.GetRight(this.purid, "gd_r22"))
				{
					this.btnDelO.Enabled = false;
				}
				if (!dALRight.GetRight(this.purid, "gd_r23"))
				{
					this.btnCancel.Disabled = true;
				}
				if (!dALRight.GetRight(this.purid, "gd_r6"))
				{
					this.btnTake.Visible = false;
				}
				if (dALRight.GetRight(this.purid, "gd_r20"))
				{
					this.hfTecPur.Value = "0";
				}
				else
				{
					this.hfTecPur.Value = "1";
				}
				if (!dALRight.GetRight(this.purid, "gd_r8"))
				{
					this.btnMod.Visible = false;
				}
				if (!dALRight.GetRight(this.purid, "gd_r9"))
				{
					this.btnDelS.Enabled = false;
					this.btnDelM.Enabled = false;
					this.btnDelI.Enabled = false;
					this.btnDelD.Enabled = false;
					this.btnDelP.Enabled = false;
					this.btnCancel.Visible = false;
					this.btnDelQty.Enabled = false;
				}
				if (dALRight.GetRight(this.purid, "gd_r24"))
				{
					DataTable dataTable = DALCommon.GetDataList("StaffList", "Area", " [ID]=" + (string)this.Session["Session_wtUserID"]).Tables[0];
					if (dataTable.Rows.Count > 0)
					{
						this.hfPurArea.Value = dataTable.Rows[0]["Area"].ToString();
					}
				}
				if (dALRight.GetRight(this.purid, "gd_r25"))
				{
					this.hfPurDept.Value = "1";
				}
				if (dALRight.GetRight(this.purid, "gd_r27"))
				{
					this.hfPurOPDept.Value = "1";
				}
				if (dALRight.GetRight(this.purid, "gd_r36"))
				{
					this.hfTecDept.Value = "1";
				}
			}
			if (this.iflag == 3)
			{
				this.btnConf.Visible = true;
			}
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
	}

	protected void btnClr_Click(object sender, EventArgs e)
	{
		this.hfcbID.Value = "";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		if (this.hfRecID.Value != "-1")
		{
			this.btnShow_Click(sender, e);
			this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
		}
	}

	protected void btnOrder_Click(object sender, EventArgs e)
	{
		this.hfcbID.Value = "";
		this.hfRecID.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		if (this.hfOrder.Value != "ID")
		{
			this.SysInfo("ClrHeaderOrder('" + this.hfOrderName.Value + "');");
		}
		if (this.hfRecID.Value != "-1")
		{
			this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
		}
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		this.hfSch.Value = "0";
		this.hfRecID.Value = "-1";
		this.hfcbID.Value = "";
		this.hfParm.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void btnSchH_Click(object sender, EventArgs e)
	{
		this.hfRecID.Value = "-1";
		this.hfcbID.Value = "";
		if (this.hfParm.Value != "-1")
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		}
	}

	protected void btnFsh_Click(object sender, EventArgs e)
	{
		this.hfSch.Value = "-1";
		this.hfRecID.Value = "-1";
		this.hfcbID.Value = "";
		this.hfParm.Value = "-1";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void LoadField()
	{    
            int userID = 0;
            int.TryParse((string)this.Session["Session_wtUserID"], out userID);
            DALSys dALSys = new DALSys();
            DataTable dataTable = dALSys.GetLayoutDetail(1, 1, 7, 0, userID).Tables[0];
            this.count = dataTable.Rows.Count;
            if (dataTable.Rows.Count > 0)
            {
                this.gvdata.Columns.Clear();
                BoundField boundField = new BoundField();
                boundField.DataField = "ID";
                boundField.HeaderText = "ID";
                this.gvdata.Columns.Add(boundField);
                TemplateField templateField = new TemplateField();
                templateField.ItemTemplate = new MyTemplatex("", DataControlRowType.DataRow);
                templateField.HeaderTemplate = new MyTemplatex("", DataControlRowType.Header);
                this.gvdata.Columns.Add(templateField);
                boundField = new BoundField();
                boundField.DataField = "curStatus";
                boundField.HeaderText = "服务状态";
                this.gvdata.Columns.Add(boundField);
                boundField = new BoundField();
                boundField.DataField = "SubscribeTime";
                boundField.HeaderText = "预约时间";
                this.gvdata.Columns.Add(boundField);
                this.itake = 0;
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    BoundField boundField2 = new BoundField();
                    boundField2.DataField = dataTable.Rows[i]["FieldName"].ToString();
                    boundField2.HeaderText = dataTable.Rows[i]["TitleName"].ToString();
                    if (dataTable.Rows[i]["FieldName"].ToString() == "TakeSteps")
                    {
                        this.itake = i + 4;
                    }
                    this.gvdata.Columns.Add(boundField2);
                }
                boundField = new BoundField();
                boundField.DataField = "bTake";
                boundField.HeaderText = "bTake";
                this.gvdata.Columns.Add(boundField);
                boundField = new BoundField();
                boundField.DataField = "IsDismissed";
                boundField.HeaderText = "IsDismissed";
                this.gvdata.Columns.Add(boundField);
                this.blayout = true;
            }
        
	}

	protected void FillData(string sortExpression, string direction)
	{
		this.LoadField();
		int recordCount = 0;
		string text = (this.hfParm.Value == "-1") ? this.strParm() : (this.hfParm.Value + " and DisposalID=1 and (curStatus='处理中' or curStatus='待处理') ");
		if (this.iflag > 0)
		{
			if (this.iflag == 1)
			{
				text += " and curStatus='待处理'";
			}
			else if (this.iflag == 2)
			{
				text += " and curStatus='处理中'";
			}
		}
		string fldSort = sortExpression + " " + direction;
		if (this.hfPurDept.Value == "1")
		{
			text = text + " and (SellerID in(select ID from StaffList where StaffDeptID=(select StaffDeptID from StaffList where ID=" + (string)this.Session["Session_wtUserID"] + ")) or SellerID is null)";
		}
		if (this.hfPurOPDept.Value == "1")
		{
			text = text + " and (OperatorID in(select ID from StaffList where StaffDeptID=(select StaffDeptID from StaffList where ID=" + (string)this.Session["Session_wtUserID"] + ")) or OperatorID is null)";
		}
		if (this.hfTecPur.Value == "0" || this.iflag == 3)
		{
			text = text + " and CHARINDEX('" + (string)this.Session["Session_wtUser"] + "',DisposalOper)>0 ";
		}
		if (this.hfTecDept.Value == "1")
		{
			text = text + " and (DisposalOper in(select _Name from StaffList where bTechnician=1 and StaffDeptID=(select StaffDeptID from StaffList where ID=" + (string)this.Session["Session_wtUserID"] + ")) or DisposalOper is null)";
		}
		if (this.hfPurArea.Value != "")
		{
			text = text + " and (CHARINDEX('" + this.hfPurArea.Value + "',Area)>0 or Area='' or Area is null) ";
		}
		this.hfSql.Value = text;
		this.gvdata.DataSource = DALCommon.GetList_HL(1, "fw_services", "", this.pageSize, this.jsPager.CurrentPageIndex, text, fldSort, out recordCount);
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
				if (i > 3)
				{
					string dataField = ((BoundField)this.gvdata.Columns[i]).DataField;
					string text2 = this.gvdata.HeaderRow.Cells[i].Text;
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
					if (dataField != "ID" && dataField != "bTake" && dataField != "IsDismissed")
					{
						if (this.hfTbTitle.Value == string.Empty)
						{
							this.hfTbTitle.Value = text2;
						}
						else
						{
							HiddenField expr_4C7 = this.hfTbTitle;
							expr_4C7.Value = expr_4C7.Value + "," + text2;
						}
						if (this.hfTbField.Value == string.Empty)
						{
							this.hfTbField.Value = dataField;
						}
						else
						{
							HiddenField expr_517 = this.hfTbField;
							expr_517.Value = expr_517.Value + "," + dataField;
						}
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
		string text = " DisposalID=1 and (curStatus='处理中' or curStatus='待处理') ";
		string text2 = FunLibrary.ChkInput(this.tbCon.Text);
		if (this.hfSch.Value == "0")
		{
			if (this.ddlKey.SelectedValue != "-1")
			{
				int num = 0;
				int.TryParse(this.ddlKey.SelectedValue, out num);
				if (text2 != "")
				{
					DALServices dALServices = new DALServices();
					if (num == 30)
					{
						text = text + " and CustomerID in (select ID from customerlist where customerno='" + text2 + "')";
					}
					else
					{
						text += dALServices.GetSchWhere(num, text2);
					}
				}
			}
		}
		return text;
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = (e.Row.Cells[2].Visible = (e.Row.Cells[3].Visible = false));
		if (this.count != 0)
		{
			e.Row.Cells[this.count + 4].Visible = (e.Row.Cells[this.count + 5].Visible = false);
		}
		else
		{
			e.Row.Cells[37].Visible = (e.Row.Cells[38].Visible = false);
		}
		string[] array = this.hfcbID.Value.Split(new char[]
		{
			','
		});
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "','"+e.Row.Cells[4].Text+"');");
			e.Row.Attributes.Add("ondblclick", "ChkView();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:5px;");
			e.Row.Cells[1].Text = string.Concat(new string[]
			{
				"<input id=\"cb",
				e.Row.Cells[0].Text,
				"\" type=\"checkbox\" onclick=\"SltValue('",
				e.Row.Cells[0].Text,
				"',this);\"/>"
			});
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].ToString() == e.Row.Cells[0].Text)
				{
					e.Row.Cells[1].Text = string.Concat(new string[]
					{
						"<input id=\"cb",
						e.Row.Cells[0].Text,
						"\" type=\"checkbox\" checked=\"checked\" onclick=\"SltValue('",
						e.Row.Cells[0].Text,
						"',this);\"/>"
					});
					break;
				}
			}
			if (e.Row.Cells[2].Text == "待处理")
			{
				e.Row.Attributes.Add("style", "color:#ff0000");
			}
			else
			{
				e.Row.Attributes.Add("style", "color:#008000");
			}
			if (e.Row.Cells[3].Text != "&nbsp;")
			{
				e.Row.Attributes.Add("style", "color:#0000ff");
			}
			if (this.count != 0)
			{
				if (e.Row.Cells[this.count + 4].Text == "True")
				{
					e.Row.Attributes.Add("style", "color:#AA8855");
				}
				if (e.Row.Cells[this.count + 5].Text == "1")
				{
					e.Row.Attributes.Add("style", "color:#893232");
				}
			}
			else
			{
				if (e.Row.Cells[37].Text == "True")
				{
					e.Row.Attributes.Add("style", "color:#AA8855");
				}
				if (e.Row.Cells[38].Text == "1")
				{
					e.Row.Attributes.Add("style", "color:#893232");
				}
			}
			if (this.blayout)
			{
				if (this.itake > 4)
				{
					if (e.Row.Cells[this.itake].Text.Length > 16)
					{
						e.Row.Cells[this.itake].Text = string.Concat(new string[]
						{
							"<a href=\"#\" style=\"color:#0000ff\" title=\"",
							e.Row.Cells[this.itake].Text,
							"\" onclick=\"ShowTA('",
							e.Row.Cells[0].Text,
							"')\">",
							e.Row.Cells[this.itake].Text.Substring(0, 16),
							"...</a>"
						});
					}
				}
			}
			else if (e.Row.Cells[this.itake].Text.Length > 16)
			{
				e.Row.Cells[this.itake].Text = string.Concat(new string[]
				{
					"<a href=\"#\" style=\"color:#0000ff\" title=\"",
					e.Row.Cells[this.itake].Text,
					"\" onclick=\"ShowTA('",
					e.Row.Cells[0].Text,
					"')\">",
					e.Row.Cells[this.itake].Text.Substring(0, 16),
					"...</a>"
				});
			}
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			this.lbPage.Text = "当前页:" + this.gvdata.Rows.Count.ToString();
		}
	}

	protected void btnShow_Click(object sender, EventArgs e)
	{
		if (this.hfRecID.Value != "-1")
		{
			this.GridView1.DataSource = DALCommon.GetDataList("fw_servicesprocess", "", " [BillID]=" + this.hfRecID.Value).Tables[0];
			this.GridView1.DataBind();
			DataTable dataTable = DALCommon.GetDataList("fw_servicesmaterial", "", " [BillID]=" + this.hfRecID.Value).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.btnBroughtM.Visible = true;
			}
			else
			{
				this.btnBroughtM.Visible = false;
			}
			this.GridView2.DataSource = dataTable;
			this.GridView2.DataBind();
			this.GridView3.DataSource = DALCommon.GetDataList("fw_servicesitem", "", " [BillID]=" + this.hfRecID.Value).Tables[0];
			this.GridView3.DataBind();
			this.GridView4.DataSource = DALCommon.GetDataList("ServicesDeviceConf", "", " [BillID]=" + this.hfRecID.Value).Tables[0];
			this.GridView4.DataBind();
			this.GridView5.DataSource = DALCommon.GetDataList("fw_servicespush", "", " [BillID]=" + this.hfRecID.Value).Tables[0];
			this.GridView5.DataBind();
			this.GridView6.DataSource = DALCommon.GetDataList("fw_servicesoffer", "", " [BillID]=" + this.hfRecID.Value).Tables[0];
			this.GridView6.DataBind();
            this.GridView8.DataSource = DALCommon.GetDataList("fw_serviceslog", "", " [BillID]=" + this.hfRecID.Value).Tables[0];
            this.GridView8.DataBind();
			DataTable dataTable2 = DALCommon.GetDataList("ServicesList", "[CustomerID],ProductSN1", " [ID]=" + this.hfRecID.Value).Tables[0];
			if (dataTable2.Rows.Count > 0)
			{
				this.GridView7.DataSource = DALCommon.GetDataList("ks_qtylist", "", string.Concat(new string[]
				{
					" BillID=",
					this.hfRecID.Value,
					" or SN='",
					dataTable2.Rows[0]["ProductSN1"].ToString(),
					"'"
				}));
				this.GridView7.DataBind();
			}
		}
        if (this.hfSerNum.Value != "-1")
        {
            Coding.Stock.DAL.Cd_ImgStock bll = new Coding.Stock.DAL.Cd_ImgStock();
            DataSet ds = bll.GetList(string.Format(" FlagName='{0}'", this.hfSerNum.Value));
                Repeater1.DataSource = ds.Tables[0];
                Repeater1.DataBind();          
        }
        //bingclick
        this.SysInfo2("bingclick();");
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.Cells[0].Text == "0")
		{
			e.Row.Visible = false;
		}
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "s" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('s" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "ts" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("ondblclick", "ModS();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}

	protected void GridView7_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "q" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('q" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("ondblclick", "ModQty();");
			e.Row.Cells[1].Attributes.Add("id", "tq" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}

	protected void btnDelQty_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		int num = DALCommon.DeteleData("QtyList", " [ID]=" + this.hfRecID2.Value.Replace("q", ""), out empty);
		if (num == 0)
		{
			this.hfRecID2.Value = "-1";
		}
		else if (num == -1)
		{
			this.SysInfo("window.alert('" + empty + "');");
		}
		else
		{
			this.SysInfo("window.alert('系统错误！请查看错误日志');");
		}
		DataTable dataTable = DALCommon.GetDataList("ServicesList", "[CustomerID],ProductSN1", " [ID]=" + this.hfRecID.Value).Tables[0];
		if (dataTable.Rows.Count > 0)
		{
			this.GridView7.DataSource = DALCommon.GetDataList("ks_qtylist", "", string.Concat(new string[]
			{
				" BillID=",
				this.hfRecID.Value,
				" or SN='",
				dataTable.Rows[0]["ProductSN1"].ToString(),
				"'"
			}));
			this.GridView7.DataBind();
		}
	}

	protected void btnDelS_Click(object sender, EventArgs e)
	{
		DALServices dALServices = new DALServices();
		string empty = string.Empty;
		if (int.Parse(this.Session["Session_wtPurID"].ToString()) > 0)
		{
			if (!dALServices.GetSerStatus(int.Parse(this.hfRecID2.Value.Replace("s", ""))))
			{
				this.SysInfoMsg("window.alert('工单未完成关闭，无法删除');");
				return;
			}
		}
		int num = 0;
		int.TryParse(this.hfRecID2.Value.Replace("s", ""), out num);
		int num2 = DALCommon.DeteleData("ServicesProcess", "[ID]=" + num, out empty);
		if (num2 == 0)
		{
			new DalSerAttach().DelAttach(num, "2,3");
			this.hfRecID2.Value = "-1";
		}
		else if (num2 == -1)
		{
			this.SysInfo("window.alert('" + empty + "');");
		}
		else
		{
			this.SysInfo("window.alert('系统错误！请查看错误日志');");
		}
		this.GridView1.DataSource = DALCommon.GetDataList("fw_servicesprocess", "", " [BillID]=" + this.hfRecID.Value).Tables[0];
		this.GridView1.DataBind();
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.Cells[0].Text == "0")
		{
			e.Row.Visible = false;
		}
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "m" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('m" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "tm" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("ondblclick", "ModM();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
			e.Row.Cells[10].Text = e.Row.Cells[10].Text.TrimEnd(new char[]
			{
				'0'
			}).TrimEnd(new char[]
			{
				'.'
			});
			e.Row.Cells[11].Text = e.Row.Cells[11].Text.TrimEnd(new char[]
			{
				'0'
			}).TrimEnd(new char[]
			{
				'.'
			});
			string[] array = e.Row.Cells[11].Text.Split(new char[]
			{
				','
			});
			if (array.Length > 1)
			{
				e.Row.Cells[11].Text = "<a href=\"#\" onclick=\"ViewSN('" + e.Row.Cells[11].Text + "');\">查看序列号</a>";
			}
			decimal.TryParse(e.Row.Cells[7].Text, out this.dtest);
			this.dre1 += this.dtest;
			decimal.TryParse(e.Row.Cells[8].Text, out this.dtest);
			this.dre2 += this.dtest;
			decimal.TryParse(e.Row.Cells[9].Text, out this.dtest);
			this.dre3 += this.dtest;
			decimal.TryParse(e.Row.Cells[12].Text, out this.dtest);
			this.dre4 += this.dtest;
			decimal.TryParse(e.Row.Cells[18].Text, out this.dtest);
			this.dre5 += this.dtest;
			decimal.TryParse(e.Row.Cells[11].Text, out this.dtest);
			this.dre6 += this.dtest;
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[1].Text = "合计";
			e.Row.Cells[1].Attributes.Add("style", "padding:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[7].Text = this.dre1.ToString("#0.00");
			e.Row.Cells[8].Text = this.dre2.ToString("#0.00");
			e.Row.Cells[9].Text = this.dre3.ToString("#0.00");
			e.Row.Cells[12].Text = this.dre4.ToString("#0.00");
			e.Row.Cells[18].Text = this.dre5.ToString("#0.00");
			e.Row.Cells[11].Text = this.dre5.ToString("#0.00");
		}
	}

	protected void btnDelM_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		DataTable dataTable = DALCommon.GetDataList("ServicesMaterial", "LQty", " [ID]=" + this.hfRecID2.Value.Replace("m", "")).Tables[0];
		if (dataTable.Rows.Count > 0)
		{
			decimal d = 0m;
			decimal.TryParse(dataTable.Rows[0]["LQty"].ToString(), out d);
			if (d != 0m)
			{
				this.SysInfoM("window.alert('操作失败！该备件已领料，请退料后再操作！');");
			}
			else
			{
				int num = DALCommon.DeteleData("ServicesMaterial", "[ID]=" + this.hfRecID2.Value.Replace("m", ""), out empty);
				if (num == 0)
				{
					this.hfRecID2.Value = "-1";
				}
				else if (num == -1)
				{
					this.SysInfoM("window.alert('" + empty + "');");
				}
				else
				{
					this.SysInfoM("window.alert('系统错误！请查看错误日志');");
				}
				this.GridView2.DataSource = DALCommon.GetDataList("fw_servicesmaterial", "", " [BillID]=" + this.hfRecID.Value).Tables[0];
				this.GridView2.DataBind();
			}
		}
		this.btnShow_Click(sender, e);
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
		if (e.Row.Cells[0].Text == "0")
		{
			e.Row.Visible = false;
		}
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "i" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('i" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "ti" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("ondblclick", "ModI();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
			decimal.TryParse(e.Row.Cells[4].Text, out this.dtestr);
			this.drer1 += this.dtestr;
			decimal.TryParse(e.Row.Cells[5].Text, out this.dtestr);
			this.drer2 += this.dtestr;
			decimal.TryParse(e.Row.Cells[6].Text, out this.dtestr);
			this.drer3 += this.dtestr;
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[1].Text = "合计";
			e.Row.Cells[1].Attributes.Add("style", "padding:0px;background:#ECE9D8;text-align:center;");
			e.Row.Cells[4].Text = this.drer1.ToString("#0.00");
			e.Row.Cells[5].Text = this.drer2.ToString("#0.00");
			e.Row.Cells[6].Text = this.drer3.ToString("#0.00");
		}
	}

	protected void btnDelI_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		int num = DALCommon.DeteleData("ServicesItem", "[ID]=" + this.hfRecID2.Value.Replace("i", ""), out empty);
		if (num == 0)
		{
			this.hfRecID2.Value = "-1";
		}
		else if (num == -1)
		{
			this.SysInfo("window.alert('" + empty + "');");
		}
		else
		{
			this.SysInfo("window.alert('系统错误！请查看错误日志');");
		}
		this.GridView3.DataSource = DALCommon.GetDataList("fw_servicesitem", "", " [BillID]=" + this.hfRecID.Value).Tables[0];
		this.GridView3.DataBind();
	}

	protected void GridView4_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.Cells[0].Text == "0")
		{
			e.Row.Visible = false;
		}
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "d" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('d" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "td" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("ondblclick", "ModDevConf();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}

	protected void btnDelD_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		int num = DALCommon.DeteleData("ServicesDeviceConf", "[ID]=" + this.hfRecID2.Value.Replace("d", ""), out empty);
		if (num == 0)
		{
			this.hfRecID2.Value = "-1";
		}
		else if (num == -1)
		{
			this.SysInfo("window.alert('" + empty + "');");
		}
		else
		{
			this.SysInfo("window.alert('系统错误！请查看错误日志');");
		}
		this.GridView4.DataSource = DALCommon.GetDataList("ServicesDeviceConf", "", " [BillID]=" + this.hfRecID.Value).Tables[0];
		this.GridView4.DataBind();
	}

	protected void GridView5_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.Cells[0].Text == "0")
		{
			e.Row.Visible = false;
		}
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "p" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('p" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "tp" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("ondblclick", "ModP();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}

	protected void btnDelP_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		int num = DALCommon.DeteleData("ServicesPush", "[ID]=" + this.hfRecID2.Value.Replace("p", ""), out empty);
		if (num == 0)
		{
			this.hfRecID2.Value = "-1";
		}
		else if (num == -1)
		{
			this.SysInfo("window.alert('" + empty + "');");
		}
		else
		{
			this.SysInfo("window.alert('系统错误！请查看错误日志');");
		}
		this.GridView5.DataSource = DALCommon.GetDataList("fw_servicespush", "", " [BillID]=" + this.hfRecID.Value).Tables[0];
		this.GridView5.DataBind();
	}

	protected void GridView6_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.Cells[0].Text == "0")
		{
			e.Row.Visible = false;
		}
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "o" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID2('o" + e.Row.Cells[0].Text + "');");
			e.Row.Cells[1].Attributes.Add("id", "to" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("ondblclick", "ModO();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[1].Attributes.Add("style", "width:20px;padding-right:0px;background:#ECE9D8;");
			e.Row.Cells[1].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}

	protected void btnDelO_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		int num = DALCommon.DeteleData("ServiceOffer", "[ID]=" + this.hfRecID2.Value.Replace("o", ""), out empty);
		if (num == 0)
		{
			this.hfRecID2.Value = "-1";
		}
		else if (num == -1)
		{
			this.SysInfo("window.alert('" + empty + "');");
		}
		else
		{
			this.SysInfo("window.alert('系统错误！请查看错误日志');");
		}
		this.GridView6.DataSource = DALCommon.GetDataList("fw_servicesoffer", "", " [BillID]=" + this.hfRecID.Value).Tables[0];
		this.GridView6.DataBind();
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
		DataTable dt = DALCommon.GetDataList("fw_services", this.hfTbField.Value, strCondition).Tables[0];
		string[] tbTitle = this.hfTbTitle.Value.Split(new char[]
		{
			','
		});
		string empty = string.Empty;
		bool flag = false;
		DataToExcel.DataTableToExcel(dt, tbTitle, Guid.NewGuid().ToString() + ".xls", "Services", out flag, out empty);
		if (!flag)
		{
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.SysInfo("window.alert(\"" + empty + "\");");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
    protected void SysInfo2(string str)
    {
        ScriptManager.RegisterClientScriptBlock(this.UpdatePanel11, this.UpdatePanel11.GetType(), "SysInfo", str, true);
    }
	protected void SysInfoMsg(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel9, this.UpdatePanel9.GetType(), "SysInfo", str, true);
	}

	protected void SysInfoM(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel5, this.UpdatePanel5.GetType(), "SysInfo", str, true);
	}
}
