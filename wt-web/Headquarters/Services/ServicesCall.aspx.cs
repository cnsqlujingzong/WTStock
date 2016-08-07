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
using wt.OtherLibrary;
using Wuqi.Webdiyer;

public partial class Headquarters_Services_ServicesCall : Page, IRequiresSessionState
{

	private int pageSize = 20;

	private bool blayout = false;

	private int itake = 13;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "gd_r1"))
				{
					base.Response.Redirect("~/Headquarters/Pur.aspx?p=11");
					base.Response.End();
				}
				if (!dALRight.GetRight(num, "gd_r17"))
				{
					this.btnExcel.Enabled = false;
				}
				if (!dALRight.GetRight(num, "gd_r21"))
				{
					this.btnCancelCall.Enabled = false;
					this.btnSave.Enabled = false;
				}
				if (dALRight.GetRight(num, "gd_r36"))
				{
					this.hfTecDept.Value = "1";
				}
			}
			this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
			this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
			OtherFunction.BindStaff(this.ddlOperator, "DeptID=1 and Status=0");
			string b = (string)this.Session["Session_wtUser"];
			for (int i = 0; i < this.ddlOperator.Items.Count; i++)
			{
				if (this.ddlOperator.Items[i].Text == b)
				{
					this.ddlOperator.Items[i].Selected = true;
					break;
				}
			}
			OtherFunction.BindVisitStyle(this.ddlVisitStyle);
			int num2 = 0;
			DataTable dt = DALCommon.GetList_HL(0, "fw_visitcontent", "", 0, 0, " bStop=0", " ID Asc", out num2).Tables[0];
			this.tv.Nodes.Clear();
			TreeNode treeNode = new TreeNode();
			treeNode.Text = "<span style=\"color:#0000ff;\">回访内容</span>";
			treeNode.Value = "-1";
			treeNode.SelectAction = TreeNodeSelectAction.None;
			this.tv.Nodes.Add(treeNode);
			this.BindTreeNode(treeNode, dt, "-1", 0);
		}
	}

	protected void BindTreeNode(TreeNode node, DataTable dt, string parentid, int iFlag)
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
					"\" type=\"radio\" onclick=\"SltVisitValue('",
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
				this.BindTreeNode(treeNode, dt, dataRow["ID"].ToString(), 1);
			}
		}
	}

	protected void btnClr_Click(object sender, EventArgs e)
	{
		this.hfcbID.Value = "";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
		if (this.hfRecID.Value != "-1")
		{
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
		DataTable dataTable = dALSys.GetLayoutDetail(1, 1, 12, 0, userID).Tables[0];
		if (dataTable.Rows.Count > 0)
		{
			this.gvdata.Columns.Clear();
			BoundField boundField = new BoundField();
			boundField.DataField = "ID";
			boundField.HeaderText = "ID";
			this.gvdata.Columns.Add(boundField);
			TemplateField templateField = new TemplateField();
			templateField.ItemTemplate = new MyTemplate("", DataControlRowType.DataRow);
			this.gvdata.Columns.Add(templateField);
			this.itake = 0;
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				BoundField boundField2 = new BoundField();
				boundField2.DataField = dataTable.Rows[i]["FieldName"].ToString();
				boundField2.HeaderText = dataTable.Rows[i]["TitleName"].ToString();
				if (dataTable.Rows[i]["FieldName"].ToString() == "TakeSteps")
				{
					this.itake = i + 2;
				}
				this.gvdata.Columns.Add(boundField2);
			}
			this.blayout = true;
		}
	}

	protected void FillData(string sortExpression, string direction)
	{
		this.LoadField();
		int recordCount = 0;
		string text = (this.hfParm.Value == "-1") ? this.strParm() : (this.hfParm.Value + " and bcall='√' and curStatus='已结束' ");
		string fldSort = sortExpression + " " + direction;
		if (this.hfTecDept.Value == "1")
		{
			text = text + " and (DisposalOper in(select _Name from StaffList where bTechnician=1 and StaffDeptID=(select StaffDeptID from StaffList where ID=" + (string)this.Session["Session_wtUserID"] + ")) or DisposalOper is null)";
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
				if (i > 1)
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
					if (dataField != "ID")
					{
						if (this.hfTbTitle.Value == string.Empty)
						{
							this.hfTbTitle.Value = text2;
						}
						else
						{
							HiddenField expr_321 = this.hfTbTitle;
							expr_321.Value = expr_321.Value + "," + text2;
						}
						if (this.hfTbField.Value == string.Empty)
						{
							this.hfTbField.Value = dataField;
						}
						else
						{
							HiddenField expr_371 = this.hfTbField;
							expr_371.Value = expr_371.Value + "," + dataField;
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
		string text = "  bcall='√' and curStatus='已结束' ";
		string text2 = FunLibrary.ChkInput(this.tbCon.Text);
		if (this.hfSch.Value == "0")
		{
			if (this.ddlKey.SelectedValue != "-1")
			{
				int schid = 0;
				int.TryParse(this.ddlKey.SelectedValue, out schid);
				if (text2 != "")
				{
					DALServices dALServices = new DALServices();
					text += dALServices.GetSchWhere(schid, text2);
				}
			}
		}
		return text;
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		string empty = string.Empty;
		string[] array = this.hfcbID.Value.Split(new char[]
		{
			','
		});
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
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
			if (this.blayout)
			{
				if (this.itake > 2)
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

	protected void btnCancelCall_Click(object sender, EventArgs e)
	{
		string empty = string.Empty;
		DALServices dALServices = new DALServices();
		int num = 0;
		int num2 = 0;
		string value = this.hfcbID.Value;
		if (value == "")
		{
			value = this.hfRecID.Value;
		}
		string[] array = value.Split(new char[]
		{
			','
		});
		int num3 = 0;
		for (int i = 0; i < array.Length; i++)
		{
			int.TryParse(array[i].ToString(), out num3);
			if (num3 != 0)
			{
				int num4 = dALServices.OverCall(num3, int.Parse((string)this.Session["Session_wtUserID"]), out empty);
				if (num4 == 0)
				{
					num2++;
				}
				else
				{
					num++;
				}
			}
		}
		if (num == 0)
		{
			this.SysInfo("window.alert('操作成功！" + num2.ToString() + "条服务单已回访完毕');");
		}
		else if (num2 == 0)
		{
			this.SysInfo("window.alert('操作失败！" + num.ToString() + "条服务单状态已变化，请刷新后操作！');");
		}
		else
		{
			this.SysInfo(string.Concat(new string[]
			{
				"window.alert('",
				num2.ToString(),
				"条服务单已回访完毕；",
				num.ToString(),
				"条服务单状态已变化，请刷新后操作！');"
			}));
		}
		this.hfRecID.Value = "-1";
		this.hfcbID.Value = "";
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		int num;
		int.TryParse(this.hfRecID.Value, out num);
		if (num > 0)
		{
			DALServices dALServices = new DALServices();
			DALServicesVisit dALServicesVisit = new DALServicesVisit();
			ServicesVisitInfo servicesVisitInfo = new ServicesVisitInfo();
			int num2 = dALServicesVisit.ExistsGetValue(num);
			servicesVisitInfo.ID = num2;
			servicesVisitInfo.BillID = num;
			servicesVisitInfo._Date = FunLibrary.ChkInput(this.tbDate.Text);
			servicesVisitInfo.OperatorID = int.Parse(this.ddlOperator.SelectedValue);
			servicesVisitInfo.VisitStyleID = int.Parse(this.ddlVisitStyle.SelectedValue);
			servicesVisitInfo.CusName = FunLibrary.ChkInput(this.tbVisitOperator.Text);
			servicesVisitInfo.Opinion = FunLibrary.ChkInput(this.tbCusOpinon.Text);
			servicesVisitInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
			servicesVisitInfo.Score = 0m;
			DALVisitResult dALVisitResult = new DALVisitResult();
			string[] array = this.hfvidlist.Value.TrimStart(new char[]
			{
				','
			}).Split(new char[]
			{
				','
			});
			if (array.Length > 0)
			{
				List<ServicesVisitResultInfo> list = new List<ServicesVisitResultInfo>();
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i].ToString() != "")
					{
						ServicesVisitResultInfo servicesVisitResultInfo = new ServicesVisitResultInfo();
						int choise = this.GetChoise(array[i].ToString());
						if (choise > 0)
						{
							if (num2 > 0)
							{
								servicesVisitResultInfo.ID = dALServicesVisit.ExistsMXGetValue(num2, int.Parse(array[i].ToString()));
							}
							servicesVisitResultInfo.VisitResultID = choise;
							list.Add(servicesVisitResultInfo);
							servicesVisitInfo.Score += dALVisitResult.getScore(int.Parse(array[i].ToString()), choise);
						}
					}
				}
				servicesVisitInfo.ServicesVisitResultInfos = list;
			}
			string text = "";
			int num3;
			if (num2 == 0)
			{
				num3 = dALServicesVisit.Add(servicesVisitInfo, out num);
			}
			else
			{
				num3 = dALServicesVisit.Update(servicesVisitInfo, out text);
			}
			if (num3 == 0)
			{
				this.SysInfo("window.alert('操作成功！回访信息已保存！');ChkID('" + this.hfRecID.Value + "');");
			}
			else
			{
				this.SysInfo(string.Concat(new string[]
				{
					"window.alert('",
					text,
					"');ChkID('",
					this.hfRecID.Value,
					"');"
				}));
			}
		}
		this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
	}

	protected int GetChoise(string n)
	{
		int result = 0;
		string[] array = this.hfrdID.Value.TrimStart(new char[]
		{
			'|'
		}).Split(new char[]
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
				int.TryParse(array2[1].ToString(), out result);
			}
		}
		return result;
	}

	protected void btnShow_Click(object sender, EventArgs e)
	{
		if (this.hfRecID.Value != "-1")
		{
			DataTable dataTable = DALCommon.GetDataList("ServicesVisit", "", " [BillID]=" + this.hfRecID.Value).Tables[0];
			this.hfrdID.Value = "";
			if (dataTable.Rows.Count > 0)
			{
				DateTime dateTime = default(DateTime);
				DateTime.TryParse(dataTable.Rows[0]["_Date"].ToString(), out dateTime);
				this.tbDate.Text = dateTime.ToString("yyyy-MM-dd");
				this.ddlOperator.ClearSelection();
				for (int i = 0; i < this.ddlOperator.Items.Count; i++)
				{
					if (this.ddlOperator.Items[i].Value == dataTable.Rows[0]["OperatorID"].ToString())
					{
						this.ddlOperator.Items[i].Selected = true;
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
				this.tbRemark.Text = dataTable.Rows[0]["Remark"].ToString();
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
			else
			{
				this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
				string b = (string)this.Session["Session_wtUser"];
				this.ddlOperator.ClearSelection();
				for (int i = 0; i < this.ddlOperator.Items.Count; i++)
				{
					if (this.ddlOperator.Items[i].Text == b)
					{
						this.ddlOperator.Items[i].Selected = true;
						break;
					}
				}
				this.ddlVisitStyle.ClearSelection();
				for (int i = 0; i < this.ddlVisitStyle.Items.Count; i++)
				{
					if (this.ddlVisitStyle.Items[i].Text == "")
					{
						this.ddlVisitStyle.Items[i].Selected = true;
						break;
					}
				}
				this.tbVisitOperator.Text = "";
				this.tbCusOpinon.Text = "";
				this.tbRemark.Text = "";
			}
			int num = 0;
			DataTable dt = DALCommon.GetList_HL(0, "fw_visitcontent", "", 0, 0, " bStop=0", " ID Asc", out num).Tables[0];
			this.tv.Nodes.Clear();
			TreeNode treeNode = new TreeNode();
			treeNode.Text = "<span style=\"color:#0000ff;\">回访内容</span>";
			treeNode.Value = "-1";
			treeNode.SelectAction = TreeNodeSelectAction.None;
			this.tv.Nodes.Add(treeNode);
			this.hfvidlist.Value = "";
			this.BindTreeNode2(treeNode, dt, "-1", 0);
			this.tv.ExpandAll();
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
				this.hfvidlist.Value = this.hfvidlist.Value + "," + dataRow["ID"].ToString();
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
}
