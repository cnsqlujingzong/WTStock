using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
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

public partial class CusMod : Page, IRequiresSessionState
{

	private int id;

	private string f;

	private string d;
    Coding.Stock.DAL.Cd_CusTree treeBll = new Coding.Stock.DAL.Cd_CusTree();
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
				dataTable.Columns.Add(new DataColumn("备注", typeof(string)));
				dataTable.Columns.Add(new DataColumn("RecID", typeof(int)));
				dataTable.Columns.Add(new DataColumn("iFlag", typeof(int)));
				dataTable.Columns.Add(new DataColumn("地址", typeof(string)));
                dataTable.Columns.Add(new DataColumn("个人手机", typeof(string)));
                dataTable.Columns.Add(new DataColumn("第二手机", typeof(string)));
                dataTable.Columns.Add(new DataColumn("QQ", typeof(string)));
                dataTable.Columns.Add(new DataColumn("微信", typeof(string)));
                dataTable.Columns.Add(new DataColumn("个人地址", typeof(string)));
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

	public string Cid
	{
		get
		{
			return base.Request.QueryString["id"].Trim();
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
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
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
				if (!dALRight.GetRight(num, "kh_r4"))
				{
					this.btnAdd.Enabled = false;
				}
				this.ddlDeptID.Enabled = false;
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
			DataTable dataTable2 = DALCommon.GetList_HL(0, "CustomerClass", "", 1, 1, "", " ID Asc", out num2).Tables[0];
			OtherFunction.BindDrpClass("-1", dataTable2, "├", "0", this.slCusClass);
			OtherFunction.BindBranch(this.ddlBranch);
			this.ddlBranch.Items.Remove(this.ddlBranch.Items.FindByText("总部"));
			this.ddlBranch.Items.Insert(0, new ListItem("", "0"));
			OtherFunction.BindBranch(this.ddlDeptID);
			OtherFunction.BindArea(this.ddlArea);
			OtherFunction.BindFrom(this.ddlFrom);
			OtherFunction.BindMember(this.ddlMember);
			OtherFunction.BindCustomerStatus(this.ddlStatus);
			if (this.f != "")
			{
				this.ddlArea.Items.Remove(new ListItem("新建...", "0"));
				this.ddlFrom.Items.Remove(new ListItem("新建...", "0"));
			}
			OtherFunction.BindStaff(this.ddlSeller, "bSeller=1 and DeptID=1 and Status<>1 ");
			DALCustomerList dALCustomerList = new DALCustomerList();
			CustomerListInfo model = dALCustomerList.GetModel(this.id);
			if (model != null)
			{
				this.tbName.Text = model._Name;
				this.hfTemp.Value = (this.tbCusNO.Text = model.CustomerNO);
				this.tbCusClass.Value = model.Class;
				for (int i = 0; i < this.slCusClass.Items.Count; i++)
				{
					if (this.slCusClass.Items[i].Value == model.ClassID.ToString())
					{
						this.slCusClass.Items[i].Selected = true;
						break;
					}
				}
				this.tbLinkMan.Text = model.LinkMan;
				this.tbTel.Text = model.Tel;
				this.tbTel2.Text = model.Tel2;
				this.tbFax.Text = model.Fax;
				this.tbZip.Text = model.Zip;
				this.tbEmail.Text = model.Email;
				this.tbArea.Text = model.Area;
                //tb_xyed.Text = model.PositionAmount.ToString("#0.00");
				this.ddlBranch.SelectedValue = model.BranchID.ToString();
				this.ddlDeptID.SelectedValue = model.DeptID.ToString();
				for (int i = 0; i < this.ddlSeller.Items.Count; i++)
				{
					if (this.ddlSeller.Items[i].Value == model.SellerID.ToString())
					{
						this.ddlSeller.Items[i].Selected = true;
						break;
					}
				}
				for (int i = 0; i < this.ddlFrom.Items.Count; i++)
				{
					if (this.ddlFrom.Items[i].Value == model.FromID.ToString())
					{
						this.ddlFrom.Items[i].Selected = true;
						break;
					}
				}
				for (int i = 0; i < this.ddlMember.Items.Count; i++)
				{
					if (this.ddlMember.Items[i].Value == model.MemberID.ToString())
					{
						this.ddlMember.Items[i].Selected = true;
						break;
					}
				}
				for (int i = 0; i < this.ddlStatus.Items.Count; i++)
				{
					if (this.ddlStatus.Items[i].Value == model.StatusID.ToString())
					{
						this.ddlStatus.Items[i].Selected = true;
						break;
					}
				}
				this.tbAccount.Text = model.Account;
				this.tbAdr.Text = model.Adr;
				this.tbRemark.Text = model.Remark;
				this.cbStop.Checked = model.bStop;
				this.cbCall.Checked = model.bCall;
				this.cbTrack.Checked = model.bTrack;
				this.tbCoordinates.Text = model.Coordinates;
				this.tbuserdef1.Text = model.userdef1;
				this.tbuserdef2.Text = model.userdef2;
				this.tbuserdef3.Text = model.userdef3;
				this.tbuserdef4.Text = model.userdef4;
				this.tbuserdef5.Text = model.userdef5;
				this.tbuserdef6.Text = model.userdef6;
                this.tb_cus_info.Text = model.pay_info;
                this.tb_cus_paytype.Text = model.pay_type;
                this.tb_cus_ver.Text = model.pay_yanshou;
                this.tb_cus_date.Text = model.pay_date;
                this.tb_cus_tiexi.Text = model.pay_tiexi;
                this.tb_cus_piao.Text = model.pay_fapiao;
                this.tb_cus_ren.Text = model.pay_ren;
                  
				this.tbQQ.Text = model.QQ;
				dataTable2 = DALCommon.GetDataList("CustomerLinkMan", "", "CustomerID=" + this.id.ToString()).Tables[0];
				if (dataTable2.Rows.Count > 0)
				{
					DataTable gridViewSource = this.GridViewSource1;
					for (int i = 0; i < dataTable2.Rows.Count; i++)
					{
						DataRow dataRow = gridViewSource.NewRow();
						dataRow[0] = i.ToString();
						dataRow[1] = dataTable2.Rows[i]["_Name"].ToString();
						dataRow[2] = dataTable2.Rows[i]["LinkManDept"].ToString();
						dataRow[3] = dataTable2.Rows[i]["Sex"].ToString();
						dataRow[4] = dataTable2.Rows[i]["Posit"].ToString();
						dataRow[5] = dataTable2.Rows[i]["Tel_office"].ToString();
						dataRow[6] = dataTable2.Rows[i]["Tel_home"].ToString();
						dataRow[7] = dataTable2.Rows[i]["Tel_Mobile"].ToString();
						dataRow[8] = dataTable2.Rows[i]["Fax"].ToString();
						dataRow[9] =string.IsNullOrEmpty(dataTable2.Rows[i]["Birthday"].ToString())?"":string.Format("{0:yyyy-MM-dd}",Convert.ToDateTime( dataTable2.Rows[i]["Birthday"]));
						dataRow[10] = dataTable2.Rows[i]["Email"].ToString();
						dataRow[11] = dataTable2.Rows[i]["Remark"].ToString();
						dataRow[12] = int.Parse(dataTable2.Rows[i]["ID"].ToString());
						dataRow[13] = 1;
						dataRow[14] = dataTable2.Rows[i]["Adr"].ToString();

                        dataRow[15] = dataTable2.Rows[i]["tel_Mobile1"].ToString();
                        dataRow[16] = dataTable2.Rows[i]["tel_Mobile2"].ToString();
                        dataRow[17] = dataTable2.Rows[i]["tel_QQ"].ToString();
                        dataRow[18] = dataTable2.Rows[i]["tel_weixin"].ToString();
                        dataRow[19] = dataTable2.Rows[i]["tel_padr"].ToString();
                        
						gridViewSource.Rows.Add(dataRow);
					}
					this.BindData1();
				}
			}
          //  ddlSeller.SelectedValue = Session["Session_wtUserID"].ToString();
            getNode();
		}
    
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		CustomerListInfo customerListInfo = new CustomerListInfo();
		customerListInfo.ID = this.id;
		customerListInfo.CustomerNO = FunLibrary.ChkInput(this.tbCusNO.Text);
		customerListInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
		customerListInfo.pyCode = FunLibrary.CVT(FunLibrary.ChkInput(this.tbName.Text));
		customerListInfo.ClassID = new int?(int.Parse(this.slCusClass.Items[this.slCusClass.SelectedIndex].Value));
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
		customerListInfo.bTrack = this.cbTrack.Checked;
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
		customerListInfo.BranchID = int.Parse(this.ddlBranch.SelectedValue);
		customerListInfo.DeptID = new int?(int.Parse(this.ddlDeptID.SelectedValue));
        customerListInfo.pay_info = FunLibrary.ChkInput(this.tb_cus_info.Text);
        customerListInfo.pay_type = FunLibrary.ChkInput(this.tb_cus_paytype.Text);
        customerListInfo.pay_date = FunLibrary.ChkInput(this.tb_cus_date.Text);
        customerListInfo.pay_yanshou = FunLibrary.ChkInput(this.tb_cus_ver.Text);
        customerListInfo.pay_tiexi = FunLibrary.ChkInput(this.tb_cus_tiexi.Text);
        customerListInfo.pay_fapiao = FunLibrary.ChkInput(this.tb_cus_piao.Text);
        customerListInfo.pay_ren = FunLibrary.ChkInput(this.tb_cus_ren.Text);
		decimal num = 0m;
        customerListInfo.PositionAmount =(decimal.TryParse(tb_xyed.Text, out num) ? num : 0m);
		DataTable gridViewSource = this.GridViewSource1;
		if (gridViewSource.Rows.Count > 0)
		{
			List<CustomerLinkManInfo> list = new List<CustomerLinkManInfo>();
			for (int i = 0; i < gridViewSource.Rows.Count; i++)
			{
				CustomerLinkManInfo customerLinkManInfo = new CustomerLinkManInfo();
				if (gridViewSource.Rows[i]["姓名"].ToString() != string.Empty)
				{
					customerLinkManInfo.ID = int.Parse(gridViewSource.Rows[i]["RecID"].ToString());
					customerLinkManInfo._Name = FunLibrary.ChkInput(gridViewSource.Rows[i]["姓名"].ToString());
					customerLinkManInfo.LinkManDept = FunLibrary.ChkInput(gridViewSource.Rows[i]["部门"].ToString());
					customerLinkManInfo.Sex = FunLibrary.ChkInput(gridViewSource.Rows[i]["性别"].ToString());
					customerLinkManInfo.Posit = FunLibrary.ChkInput(gridViewSource.Rows[i]["职位"].ToString());
					customerLinkManInfo.tel_Office = FunLibrary.ChkInput(gridViewSource.Rows[i]["办公电话"].ToString());
					customerLinkManInfo.tel_Home = FunLibrary.ChkInput(gridViewSource.Rows[i]["宅电"].ToString());
					customerLinkManInfo.tel_Mobile = FunLibrary.ChkInput(gridViewSource.Rows[i]["移动电话"].ToString());
					customerLinkManInfo.Fax = FunLibrary.ChkInput(gridViewSource.Rows[i]["传真"].ToString());
					customerLinkManInfo.Birthday = FunLibrary.ChkInput(gridViewSource.Rows[i]["生日"].ToString());
					customerLinkManInfo.Email = FunLibrary.ChkInput(gridViewSource.Rows[i]["Email"].ToString());
					customerLinkManInfo.Remark = FunLibrary.ChkInput(gridViewSource.Rows[i]["备注"].ToString());
					customerLinkManInfo.Adr = FunLibrary.ChkInput(gridViewSource.Rows[i]["地址"].ToString());

                    customerLinkManInfo.Tel_mobile1 = FunLibrary.ChkInput(gridViewSource.Rows[i]["个人手机"].ToString());
                    customerLinkManInfo.Tel_mobile2 = FunLibrary.ChkInput(gridViewSource.Rows[i]["第二手机"].ToString());
                    customerLinkManInfo.Tel_qq = FunLibrary.ChkInput(gridViewSource.Rows[i]["QQ"].ToString());
                    customerLinkManInfo.Tel_weixin = FunLibrary.ChkInput(gridViewSource.Rows[i]["微信"].ToString());
                    customerLinkManInfo.Tel_padr = FunLibrary.ChkInput(gridViewSource.Rows[i]["个人地址"].ToString());



					list.Add(customerLinkManInfo);
				}
			}
			customerListInfo.CustomerLinkManInfos = list;
		}
		bool bsys = false;
		string chkfld = string.Empty;
		if (customerListInfo.CustomerNO != this.hfTemp.Value)
		{
			if (this.cbsys.Checked)
			{
				bsys = true;
			}
			chkfld = " CustomerNO='" + customerListInfo.CustomerNO + "'";
		}
		List<string[]> list2 = new List<string[]>();
		if (this.hfdellist1.Value != string.Empty)
		{
			list2.Add(new string[]
			{
				"CustomerLinkMan",
				this.hfdellist1.Value
			});
		}
		DALCustomerList dALCustomerList = new DALCustomerList();
		string str;
		int num2 = dALCustomerList.Update(customerListInfo, bsys, chkfld, list2, out str);
		if (num2 == 0)
		{
			this.SysInfo("parent.CloseDialog" + this.f + "('1');");
			if (this.cbUpdate.Checked)
			{
				dALCustomerList.UpdateCusInfo(this.id);
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
		dataRow[12] = 0;
		dataRow[13] = 0;
		dataRow[14] = array[11].ToString();

        dataRow[15] = array[12].ToString();
        dataRow[16] = array[13].ToString();
        dataRow[17] = array[14].ToString();
        dataRow[18] = array[15].ToString();
        dataRow[19] = array[16].ToString();
        

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
        //0 ID,1 姓名 ，2 部门，3性别，4职位，5办公，6宅电，7移动，8传真，9生日，
        //10 email 11备注 12recID 13iflag 14地址  15个人手机 16 第二手机 17 qq 18 威信 19 个人地址
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
		gridViewSource.Rows[index][14] = array[10].ToString();
		gridViewSource.Rows[index][11] = array[11].ToString();

        gridViewSource.Rows[index][15] = array[12].ToString();
        gridViewSource.Rows[index][16] = array[13].ToString();
        gridViewSource.Rows[index][17] = array[14].ToString();
        gridViewSource.Rows[index][18] = array[15].ToString();
        gridViewSource.Rows[index][19] = array[16].ToString();

		this.BindData1();
		this.SysInfoLinkMan("ChkID('" + this.hfRecID.Value + "');");
	}

	protected void btnShowLinkMan_Click(object sender, EventArgs e)
	{
		DataTable gridViewSource = this.GridViewSource1;
		DataRow[] array = gridViewSource.Select(" ID= " + this.hfRecID.Value.Replace("l", ""));
		if (array.Length > 0)
		{
            StringBuilder sb = new StringBuilder();
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
			expr_1B4.Value = expr_1B4.Value + array[0]["生日"].ToString() + ",";
			HiddenField expr_1E2 = this.hfLinkMan;
			expr_1E2.Value = expr_1E2.Value + array[0]["Email"].ToString() + ",";
            HiddenField expr_23E = this.hfLinkMan;
            expr_23E.Value += array[0]["备注"].ToString() + ","; 
			HiddenField expr_210 = this.hfLinkMan;
			expr_210.Value = expr_210.Value + array[0]["地址"].ToString() + ",";
		

            HiddenField expr_24E = this.hfLinkMan;
            expr_24E.Value += array[0]["个人手机"].ToString() + ",";
            HiddenField expr_25E = this.hfLinkMan;
            expr_25E.Value += array[0]["第二手机"].ToString() + ",";
            HiddenField expr_26E = this.hfLinkMan ;
            expr_26E.Value += array[0]["QQ"].ToString() + ",";
            HiddenField expr_27E = this.hfLinkMan;
            expr_27E.Value += array[0]["微信"].ToString() + ",";
            HiddenField expr_28E = this.hfLinkMan;
            expr_28E.Value += array[0]["个人地址"].ToString() + ",";
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
					if (int.Parse(gridViewSource.Rows[i]["iFlag"].ToString()) == 1)
					{
						if (this.hfdellist1.Value == string.Empty)
						{
							this.hfdellist1.Value = gridViewSource.Rows[i]["RecID"].ToString();
						}
						else
						{
							HiddenField expr_F8 = this.hfdellist1;
							expr_F8.Value = expr_F8.Value + "," + gridViewSource.Rows[i]["RecID"].ToString();
						}
					}
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
    //添加节点
    protected void btnAddNode_Click(object sender, EventArgs e)
    {
        string pid = TreeView1.SelectedValue;//string.IsNullOrEmpty(hid_parentid.Value.Trim()) ? "-1" : hid_parentid.Value.Trim();
        string pzhiwu = tb_zhiwu.Text.Trim();
        string ppname = tb_renming.Text.Trim();
        if (string.IsNullOrEmpty(pid))//顶级节点
        {
            int qty = treeBll.GetRecordCount(" CusID=" + this.id);
            if (qty > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.UpdatePanel2, this.UpdatePanel2.GetType(), "SysInfo", "<script>alert('已经有最高职务，请选择上级职务')</script>", true);
            }
            else
            {
                AddNode("-1", pzhiwu, ppname);
               
            }
        }
        else 
        {
            AddNode(pid, pzhiwu, ppname);         

        }
        getNode();
       
    }
    private bool AddNode(string pid,string job,string name)
    {
        Coding.Stock.Model.Cd_CusTree c = new Coding.Stock.Model.Cd_CusTree();
        c.CusID = this.id;
        c.Pid =Convert.ToInt32( pid);
        c.PJob = job;
        c.PName = name;
       int r= treeBll.Add(c);
       if (r > 0)
       {
           tb_zhiwu.Text = "";
           tb_renming.Text = "";
           lb_parentNode.Text = "";
           return true;
       }
       else 
       {
           return false;
       }
   
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        lb_parentNode.Text = TreeView1.SelectedNode.Text;
        tb_ezhiwu.Text=TreeView1.SelectedNode.Text.Substring(0,TreeView1.SelectedNode.Text.IndexOf("【"));
        tb_erenming.Text = TreeView1.SelectedNode.Text.Substring(TreeView1.SelectedNode.Text.IndexOf("【") + 1, TreeView1.SelectedNode.Text.IndexOf("】") - TreeView1.SelectedNode.Text.IndexOf("【")-1);
    }
    private void getNode()
    {
        TreeView1.Nodes.Clear();
        Coding.Stock.Model.Cd_CusTree c = treeBll.GetModel(" CusID=" + this.id + " and Pid=-1");
        if (c != null)
        {
            TreeNode r = new TreeNode();
            r.Text = c.PJob + "【" + c.PName + "】";
            r.Value = c.ID.ToString();
          
            r = eachNode(r, r.Value);
            r.ExpandAll();
            TreeView1.Nodes.Add(r);
         
        }
    }
    private TreeNode eachNode(TreeNode pNode, string pid)
    {
        DataTable dt = treeBll.GetList(" CusID=" + this.id + " and Pid="+pid).Tables[0];
        if (dt.Rows.Count > 0)
        {
            TreeNode n;
            foreach (DataRow r in dt.Rows)
            {
                n= new TreeNode();
                n.Text = r["PJob"].ToString() + "【" + r["PName"].ToString() + "】";
                n.Value=r["ID"].ToString();
                pNode.ChildNodes.Add(n);
                eachNode(n, r["ID"].ToString());
            }
        }
        return pNode;
    }
    protected void btnDelNode_Click(object sender, EventArgs e)
    {
        string id=TreeView1.SelectedValue;
        if (!string.IsNullOrEmpty(id))
        {
            treeBll.Delete(Convert.ToInt32(id));
            getNode();
        }
    }
    protected void btnEditNode_Click(object sender, EventArgs e)
    {
        string pid = TreeView1.SelectedValue;
        string pzhiwu = tb_ezhiwu.Text.Trim();
        string ppname = tb_erenming.Text.Trim();
        if (!string.IsNullOrEmpty(pid)&&!string.IsNullOrEmpty(pzhiwu)&&!string.IsNullOrEmpty(ppname))
        {
            Coding.Stock.Model.Cd_CusTree c = treeBll.GetModel(" CusID=" + this.id + " and ID="+pid);
            c.PJob = pzhiwu;
            c.PName = ppname;
            treeBll.Update(c);
            getNode();
        }
    }
}
