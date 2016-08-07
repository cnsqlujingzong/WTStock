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

public partial class Headquarters_Customer_CusAdd : Page, IRequiresSessionState
{
	private string f;

	private string d;

	private int classid;

	private DataTable GridViewSource1
	{
		get
		{
			if (this.ViewState["List1"] == null)
			{
				DataTable dataTable = new DataTable();
				dataTable.Columns.Add(new DataColumn("ID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("姓名", typeof(string)));
				dataTable.Columns.Add(new DataColumn("部门", typeof(string)));
				dataTable.Columns.Add(new DataColumn("性别", typeof(string)));
				dataTable.Columns.Add(new DataColumn("职位", typeof(string)));
				dataTable.Columns.Add(new DataColumn("办公电话", typeof(string)));
				dataTable.Columns.Add(new DataColumn("宅电", typeof(string)));
				dataTable.Columns.Add(new DataColumn("移动电话", typeof(string)));
				dataTable.Columns.Add(new DataColumn("传真", typeof(string)));
				dataTable.Columns.Add(new DataColumn("生日", typeof(string)));
				dataTable.Columns.Add(new DataColumn("Email", typeof(string)));
				dataTable.Columns.Add(new DataColumn("地址", typeof(string)));
				dataTable.Columns.Add(new DataColumn("备注", typeof(string)));
				this.ViewState["List1"] = dataTable;
			}
			return (DataTable)this.ViewState["List1"];
		}
		set
		{
			this.ViewState["List1"] = value;
		}
	}

	public string Str_F
	{
		get
		{
			return this.f;
		}
	}

	public string Str_D
	{
		get
		{
			return this.d;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		bool btel = false;
		if (base.Request.QueryString["itel"] != null)
		{
			btel = true;
		}
		FunLibrary.ChkHead(btel);
		int.TryParse(base.Request["classid"], out this.classid);
		this.f = base.Request["f"];
		if (this.f == "1")
		{
			this.d = "2";
		}
		else if (this.f == "2")
		{
			this.d = "3";
		}
		else
		{
			this.d = "1";
			this.f = "";
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "kh_r3"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			int userID = 0;
			int.TryParse((string)this.Session["Session_wtUserID"], out userID);
			DALSys dALSys = new DALSys();
			DataTable dataTable = dALSys.GetLayoutDetail(1, 1, 15, 0, userID).Tables[0];
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
			this.slCusClass.Items.Add(new ListItem("", "0"));
			DataTable dt = DALCommon.GetList_HL(0, "CustomerClass", "", 0, 0, "", " Array Asc", out num2).Tables[0];
			OtherFunction.BindDrpClass("-1", dt, "├", "0", this.slCusClass);
			for (int i = 0; i < this.slCusClass.Items.Count; i++)
			{
				if (this.slCusClass.Items[i].Value == this.classid.ToString())
				{
					this.slCusClass.Items[i].Selected = true;
					this.tbCusClass.Value = this.slCusClass.Items[i].Text.Replace("├", "").Replace("│", "").Replace(HttpUtility.HtmlDecode("&nbsp;&nbsp;"), "");
					break;
				}
			}
			OtherFunction.BindBranch(this.ddlBranch);
			this.ddlBranch.Items.Remove(this.ddlBranch.Items.FindByText("总部"));
			this.ddlBranch.Items.Insert(0, new ListItem("", "0"));
			OtherFunction.BindArea(this.ddlArea);
			OtherFunction.BindFrom(this.ddlFrom);
			OtherFunction.BindStaff(this.ddlSeller, "bSeller=1 and DeptID=1 ");
            ddlSeller.SelectedValue = Session["Session_wtUserID"].ToString();
			OtherFunction.BindMember(this.ddlMember);
			OtherFunction.BindCustomerStatus(this.ddlStatus);
			if (this.d == "2" || this.d == "3")
			{
				this.ddlArea.Items.Remove(new ListItem("新建...", "0"));
				this.ddlFrom.Items.Remove(new ListItem("新建...", "0"));
			}
		}
   
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		CustomerListInfo customerListInfo = new CustomerListInfo();
		DALCustomerList dALCustomerList = new DALCustomerList();
		customerListInfo.DeptID = new int?(1);
		customerListInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
		customerListInfo.pyCode = FunLibrary.CVT(FunLibrary.ChkInput(this.tbName.Text));
        customerListInfo.jieshao = FunLibrary.ChkInput(this.txtjieshao.Text);
		customerListInfo.ClassID = new int?(int.Parse(this.slCusClass.Items[this.slCusClass.SelectedIndex].Value));
		customerListInfo.CustomerNO = FunLibrary.ChkInput(this.tbCusNO.Text);
		customerListInfo.LinkMan = FunLibrary.ChkInput(this.tbLinkMan.Text);
		customerListInfo.Tel = FunLibrary.ChkInput(this.tbTel.Text);
		customerListInfo.Tel2 = FunLibrary.ChkInput(this.tbTel2.Text);
		customerListInfo.Fax = FunLibrary.ChkInput(this.tbFax.Text);
		customerListInfo.Zip = FunLibrary.ChkInput(this.tbZip.Text);
		customerListInfo.Email = FunLibrary.ChkInput(this.tbEmail.Text);
		customerListInfo.Area = FunLibrary.ChkInput(this.tbArea.Text);
		customerListInfo.FromID = new int?(int.Parse(this.ddlFrom.SelectedValue));
		customerListInfo.SellerID = new int?(int.Parse(this.ddlSeller.SelectedValue));
		customerListInfo.Account = FunLibrary.ChkInput(this.tbAccount.Text);
		customerListInfo.Adr = FunLibrary.ChkInput(this.tbAdr.Text);
		customerListInfo.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
		customerListInfo.bStop = this.cbStop.Checked;
		customerListInfo.bCall = this.cbCall.Checked;
		customerListInfo.Coordinates = FunLibrary.ChkInput(this.tbCoordinates.Text);
		customerListInfo.MemberID = int.Parse(this.ddlMember.SelectedValue);
		customerListInfo.StatusID = int.Parse(this.ddlStatus.SelectedValue);
		customerListInfo.userdef1 = FunLibrary.ChkInput(this.tbuserdef1.Text);
		customerListInfo.userdef2 = FunLibrary.ChkInput(this.tbuserdef2.Text);
		customerListInfo.userdef3 = FunLibrary.ChkInput(this.tbuserdef3.Text);
		customerListInfo.userdef4 = FunLibrary.ChkInput(this.tbuserdef4.Text);
		customerListInfo.userdef5 = FunLibrary.ChkInput(this.tbuserdef5.Text);
		customerListInfo.userdef6 = FunLibrary.ChkInput(this.tbuserdef6.Text);
		customerListInfo.QQ = FunLibrary.ChkInput(this.tbQQ.Text);
        customerListInfo.TrackOperatorID =int.Parse(this.ddlSeller.SelectedValue) ;//int.Parse((string)this.Session["Session_wtUserID"]);
		customerListInfo.OperatorID = int.Parse((string)this.Session["Session_wtUserID"]);
		customerListInfo.BranchID = int.Parse(this.ddlBranch.SelectedValue);
		decimal num = 0m;
		customerListInfo.PositionAmount = (decimal.TryParse(this.tbPosition.Text, out num) ? num : 0m);
		customerListInfo.bTrack = this.cbTrack.Checked;
		DataTable gridViewSource = this.GridViewSource1;
		if (gridViewSource.Rows.Count > 0)
		{
			List<CustomerLinkManInfo> list = new List<CustomerLinkManInfo>();
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				CustomerLinkManInfo customerLinkManInfo = new CustomerLinkManInfo();
				if (gridViewSource.Rows[i]["姓名"].ToString() != string.Empty)
				{
					customerLinkManInfo._Name = gridViewSource.Rows[i]["姓名"].ToString();
					customerLinkManInfo.LinkManDept = gridViewSource.Rows[i]["部门"].ToString();
					customerLinkManInfo.Sex = gridViewSource.Rows[i]["性别"].ToString();
					customerLinkManInfo.Posit = gridViewSource.Rows[i]["职位"].ToString();
					customerLinkManInfo.tel_Office = gridViewSource.Rows[i]["办公电话"].ToString();
					customerLinkManInfo.tel_Home = gridViewSource.Rows[i]["宅电"].ToString();
					customerLinkManInfo.tel_Mobile = gridViewSource.Rows[i]["移动电话"].ToString();
					customerLinkManInfo.Fax = gridViewSource.Rows[i]["传真"].ToString();
					customerLinkManInfo.Birthday = gridViewSource.Rows[i]["生日"].ToString();
					customerLinkManInfo.Email = gridViewSource.Rows[i]["Email"].ToString();
					customerLinkManInfo.Adr = gridViewSource.Rows[i]["地址"].ToString();
					customerLinkManInfo.Remark = gridViewSource.Rows[i]["备注"].ToString();
					list.Add(customerLinkManInfo);
				}
			}
			customerListInfo.CustomerLinkManInfos = list;
		}
		DALCustomerList dALCustomerList2 = new DALCustomerList();
		string str;
		int num3;
		int num2 = dALCustomerList2.Add(customerListInfo, this.cbsys.Checked, out str, out num3);
		if (num2 == 0)
		{
			if (this.cbClose.Checked)
			{
				if (this.f == "2")
				{
					this.SysInfo("parent.iframeDialog1.$(\"btnClr\").click();parent.CloseDialog" + this.f + "('1');");
				}
				else if (this.f == "1")
				{
					this.SysInfo("parent.CloseDialog1();");
				}
				else
				{
					this.SysInfo("parent.CloseDialog" + this.f + "('1');");
				}
			}
			else
			{
				if (this.f == "2")
				{
					this.SysInfo("parent.iframeDialog1.$(\"btnClr\").click();");
				}
				this.SysInfo("ChkTab('1');$('tbName').value='';$('tbName').select();");
				this.ClearText();
			}
		}
		else if (num2 == -1)
		{
			this.SysInfo("window.alert('" + str + "');");
		}
		else
		{
			this.SysInfo("window.alert('系统错误！请查看错误日志');");
		}
	}

	protected void ClearText()
	{
		this.tbQQ.Text = (this.tbAccount.Text = (this.tbAdr.Text = (this.tbCusNO.Text = (this.tbEmail.Text = (this.tbFax.Text = (this.tbLinkMan.Text = (this.tbName.Text = (this.tbRemark.Text = (this.tbTel.Text = (this.tbTel2.Text = (this.tbZip.Text = (this.tbPosition.Text = string.Empty))))))))))));
		this.ddlArea.ClearSelection();
		this.ddlArea.Items.FindByText("").Selected = true;
		this.tbCusClass.Value = string.Empty;
		this.ddlFrom.ClearSelection();
		this.ddlFrom.Items.FindByText("").Selected = true;
		this.ddlMember.ClearSelection();
		this.ddlMember.Items.FindByText("").Selected = true;
		this.ddlStatus.ClearSelection();
		this.ddlStatus.Items.FindByText("").Selected = true;
		this.ddlSeller.ClearSelection();
		this.ddlSeller.Items.FindByText("").Selected = true;
		this.tbuserdef1.Text = (this.tbuserdef2.Text = (this.tbuserdef3.Text = (this.tbuserdef4.Text = (this.tbuserdef5.Text = (this.tbuserdef6.Text = "")))));
		this.GridViewSource1.Clear();
		this.BindData1();
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "l" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ChkID('l" + e.Row.Cells[0].Text + "');");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
			e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1);
		}
	}

	protected void btnAddLinkMan_Click(object sender, EventArgs e)
	{
		DataTable gridViewSource = this.GridViewSource1;
		DataRow dataRow = gridViewSource.NewRow();
		string[] array = this.hfLinkMan.Value.Split(new char[]
		{
			','
		});
		for (int i = 0; i < gridViewSource.Rows.Count; i++)
		{
			if (gridViewSource.Rows[i]["姓名"].ToString() == array[0].ToString())
			{
				this.SysInfoLinkMan("window.alert(\"操作失败！联系人已存在\");ChkID('" + gridViewSource.Rows[i]["ID"].ToString() + "');");
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
		dataRow[11] = array[10].ToString();
		dataRow[12] = array[11].ToString();
		gridViewSource.Rows.Add(dataRow);
		this.BindData1();
	}

	protected void btnModLinkMan_Click(object sender, EventArgs e)
	{
		DataTable gridViewSource = this.GridViewSource1;
		int index;
		int.TryParse(this.hfRecID.Value.Replace("l", ""), out index);
		string[] array = this.hfLinkMan.Value.Split(new char[]
		{
			','
		});
		for (int i = 0; i < gridViewSource.Rows.Count; i++)
		{
			if (gridViewSource.Rows[i]["ID"].ToString() != this.hfRecID.Value.Replace("l", ""))
			{
				if (gridViewSource.Rows[i]["姓名"].ToString() == array[0].ToString())
				{
					this.SysInfoLinkMan("window.alert(\"操作失败！联系人已存在\");ChkID('" + gridViewSource.Rows[i]["ID"].ToString() + "');");
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
		gridViewSource.Rows[index][11] = array[10].ToString();
		gridViewSource.Rows[index][12] = array[11].ToString();
		this.BindData1();
		this.SysInfoLinkMan("ChkID('" + this.hfRecID.Value + "');");
	}

	protected void btnShowLinkMan_Click(object sender, EventArgs e)
	{
		DataTable gridViewSource = this.GridViewSource1;
		DataRow[] array = gridViewSource.Select(" ID= " + this.hfRecID.Value.Replace("l", ""));
		if (array.Length > 0)
		{
			this.hfLinkMan.Value = array[0]["姓名"].ToString() + ",";
			HiddenField expr_72 = this.hfLinkMan;
			expr_72.Value = expr_72.Value + array[0]["部门"].ToString() + ",";
			HiddenField expr_A0 = this.hfLinkMan;
			expr_A0.Value = expr_A0.Value + array[0]["性别"].ToString() + ",";
			HiddenField expr_CE = this.hfLinkMan;
			expr_CE.Value = expr_CE.Value + array[0]["职位"].ToString() + ",";
			HiddenField expr_FC = this.hfLinkMan;
			expr_FC.Value = expr_FC.Value + array[0]["办公电话"].ToString() + ",";
			HiddenField expr_12A = this.hfLinkMan;
			expr_12A.Value = expr_12A.Value + array[0]["宅电"].ToString() + ",";
			HiddenField expr_158 = this.hfLinkMan;
			expr_158.Value = expr_158.Value + array[0]["移动电话"].ToString() + ",";
			HiddenField expr_186 = this.hfLinkMan;
			expr_186.Value = expr_186.Value + array[0]["传真"].ToString() + ",";
			HiddenField expr_1B4 = this.hfLinkMan;
			expr_1B4.Value = expr_1B4.Value + array[0]["Email"].ToString() + ",";
			HiddenField expr_1E2 = this.hfLinkMan;
			expr_1E2.Value = expr_1E2.Value + array[0]["生日"].ToString() + ",";
			HiddenField expr_210 = this.hfLinkMan;
			expr_210.Value = expr_210.Value + array[0]["地址"].ToString() + ",";
			HiddenField expr_23E = this.hfLinkMan;
			expr_23E.Value += array[0]["备注"].ToString();
		}
		this.BindData1();
		this.SysInfoLinkMan("ChkID('" + this.hfRecID.Value + "');");
	}

	private void BindData1()
	{
		this.GridView1.DataSource = this.GridViewSource1;
		this.GridView1.DataBind();
	}

	protected void SysInfoLinkMan(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel3, this.UpdatePanel3.GetType(), "SysInfo", str, true);
	}

	protected void btnDelLink_Click(object sender, EventArgs e)
	{
		if (!(this.hfRecID.Value == "-1"))
		{
			DataTable gridViewSource = this.GridViewSource1;
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				if (gridViewSource.Rows[i]["ID"].ToString() == this.hfRecID.Value.Replace("l", ""))
				{
					gridViewSource.Rows.RemoveAt(i);
				}
			}
			this.BindData1();
			this.hfRecID.Value = "-1";
		}
	}

	protected void btnRef_Click(object sender, EventArgs e)
	{
		OtherFunction.BindArea(this.ddlArea);
		if (this.hfArea.Value != string.Empty)
		{
			this.ddlArea.ClearSelection();
			this.ddlArea.Items.FindByText(this.hfArea.Value).Selected = true;
			this.tbArea.Text = this.ddlArea.SelectedItem.Text;
		}
	}

	protected void btnRefFrom_Click(object sender, EventArgs e)
	{
		OtherFunction.BindFrom(this.ddlFrom);
		if (this.hfCusFrom.Value != string.Empty)
		{
			this.ddlFrom.ClearSelection();
			this.ddlFrom.Items.FindByText(this.hfCusFrom.Value).Selected = true;
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
