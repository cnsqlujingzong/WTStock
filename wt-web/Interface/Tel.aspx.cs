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

public partial class Interface_Tel : Page, IRequiresSessionState
{
	

	private string tel;

	private string id;

	private string user;

	private string pwd;

	private int pageSize = 1000;

	private string btn;

	private string strbranch = "";



	public string Btn
	{
		get
		{
			return this.btn;
		}
	}

	public string Str_Branch
	{
		get
		{
			return this.strbranch;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		this.id = base.Request["ID"];
		this.tel = base.Request["CID"];
		this.user = base.Request["UserID"];
		this.pwd = base.Request["PWD"];
		this.pwd = base.Server.UrlDecode(this.pwd);
		this.id = base.Server.UrlDecode(this.id);
		this.user = base.Server.UrlDecode(this.user);
		this.btn = "";
		if (this.hfv.Value != "1")
		{
			if (this.user == string.Empty || this.user == null || this.id == string.Empty || this.id == null)
			{
				base.Response.Write("参数不完整.");
				return;
			}
			string text = string.Empty;
			try
			{
				text = Interface_Tel.TelDecode(this.id);
			}
			catch
			{
				base.Response.Write("参数错误.");
				return;
			}
			int num = int.Parse(text.Substring(0, 2));
			int length = int.Parse(text.Substring(2, 2));
			this.pwd = text.Substring(4, num);
			this.tel = text.Substring(4 + num, length);
			DALUserManage dALUserManage = new DALUserManage();
			DALStaffList dALStaffList = new DALStaffList();
			int iD = dALStaffList.GetID(this.user);
			UserManageInfo modelTel = dALUserManage.GetModelTel(iD);
			if (modelTel == null)
			{
				base.Response.Write("用户验证失败.");
				return;
			}
			if (FunLibrary.StrDecode(modelTel.Pwd) != this.pwd)
			{
				base.Response.Write("密码验证失败.");
				return;
			}
			this.hfv.Value = "1";
			if (modelTel.DeptID == 1)
			{
				this.Session["Session_wtUser"] = this.user;
				this.Session["Session_wtUserID"] = iD.ToString();
				this.Session["Session_wtPur"] = modelTel.Right;
				this.Session["Session_wtPurID"] = ((modelTel.Right == "系统管理员") ? "0" : modelTel.RightID.ToString());
				this.hfBranch.Value = "Headquarters";
			}
			else
			{
				DataTable dataTable = DALCommon.GetDataList("BranchList", "_Name", " [ID]=" + modelTel.DeptID.ToString()).Tables[0];
				if (dataTable.Rows.Count <= 0)
				{
					base.Response.Write("用户信息验证失败.");
					return;
				}
				this.Session["Session_wtBranch"] = dataTable.Rows[0]["_Name"].ToString();
				this.Session["Session_wtBranchID"] = modelTel.DeptID.ToString();
				this.Session["Session_wtUserB"] = this.user;
				this.Session["Session_wtUserBID"] = iD.ToString();
				this.Session["Session_wtPurB"] = modelTel.Right;
				this.Session["Session_wtPurBID"] = ((modelTel.Right == "系统管理员") ? "0" : modelTel.RightID.ToString());
				this.hfBranch.Value = "Branch";
			}
			this.ViewState["v_tel"] = this.tel;
			this.btn = string.Empty;
		}
		if (!base.IsPostBack)
		{
			this.TelData();
		}
	}

	protected void btnref_Click(object sender, EventArgs e)
	{
		this.TelData();
	}

	protected void FillData()
	{
		int num = 0;
		string strCondition = " CustomerID=" + this.hfcusid.Value;
		this.GridView1.DataSource = DALCommon.GetList_HL(1, "ks_device", "", this.pageSize, this.jsPager.CurrentPageIndex, strCondition, " ID desc ", out num);
		this.GridView1.DataBind();
		this.jsPager.PageSize = this.pageSize;
		this.jsPager.RecordCount = this.pageSize * num;
		this.lbCount.Text = "总记录:" + num.ToString();
		if (this.lbCount.Text == "总记录:0")
		{
			this.lbCount.Visible = false;
			this.lbPage.Visible = false;
		}
		else
		{
			this.lbCount.Visible = true;
			this.lbPage.Visible = true;
		}
	}

	protected void FillDataD()
	{
		int recordCount = 0;
		string strCondition = " CustomerID=" + this.hfcusid.Value;
		this.GridView2.DataSource = DALCommon.GetList_HL(1, "fw_services", "", this.pageSize, this.jsPagerD.CurrentPageIndex, strCondition, " ID desc ", out recordCount);
		this.GridView2.DataBind();
		this.jsPagerD.PageSize = this.pageSize;
		this.jsPagerD.RecordCount = recordCount;
		this.lbCountD.Text = "总记录:" + recordCount.ToString();
		if (this.lbCountD.Text == "总记录:0")
		{
			this.lbCountD.Visible = false;
			this.lbPageD.Visible = false;
		}
		else
		{
			this.lbCountD.Visible = true;
			this.lbPageD.Visible = true;
		}
	}

	protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID('" + e.Row.Cells[0].Text + "','hfRecID');");
			e.Row.Attributes.Add("ondblclick", "ChkView('hfRecID');");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[1].Attributes.Add("style", "height:17px;padding-left:5px;vertical-align:text-bottom");
			this.lbPage.Text = "当前显示:" + this.GridView1.Rows.Count.ToString();
		}
	}

	protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", "d" + e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "ClrID('d" + e.Row.Cells[0].Text + "','hfRecIDD');");
			e.Row.Attributes.Add("ondblclick", "ChkView('hfRecIDD');");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
		if (e.Row.RowType == DataControlRowType.Footer)
		{
			e.Row.Cells[1].Attributes.Add("style", "height:17px;padding-left:5px;vertical-align:text-bottom");
			this.lbPageD.Text = "当前显示:" + this.GridView2.Rows.Count.ToString();
		}
	}

	protected void btnslt_Click(object sender, EventArgs e)
	{
		this.TelData();
	}

	protected void TelData()
	{
		this.tel = FunLibrary.ChkInput((string)this.ViewState["v_tel"]);
		this.tbTel.Text = this.tel;
		DataTable dataTable = DALCommon.GetDataList("ks_cuslinkdept", "", string.Concat(new string[]
		{
			" Tel like '%",
			this.tel,
			"%' or Tel2 like '%",
			this.tel,
			"%' "
		})).Tables[0];
		if (dataTable.Rows.Count != 0)
		{
			if (dataTable.Rows.Count == 1)
			{
				this.tbCusName.Text = dataTable.Rows[0]["_Name"].ToString();
				this.tbLinkName.Text = dataTable.Rows[0]["LinkMan"].ToString();
				this.tbCusTel.Text = dataTable.Rows[0]["Tel"].ToString();
				if (dataTable.Rows[0]["Tel2"].ToString() != "")
				{
					this.tbCusTel.Text = this.tbCusTel.Text + "(" + dataTable.Rows[0]["Tel2"].ToString() + ")";
				}
				this.tbFax.Text = dataTable.Rows[0]["Fax"].ToString();
				this.tbAdr.Text = dataTable.Rows[0]["Adr"].ToString();
				this.tbCusClass.Text = dataTable.Rows[0]["ClassName"].ToString();
				this.hfcusid.Value = dataTable.Rows[0]["ID"].ToString();
				this.tbArea.Text = dataTable.Rows[0]["Area"].ToString();
				this.tbRemark.Text = dataTable.Rows[0]["Remark"].ToString();
			}
			else
			{
				if (!(this.hfcusid.Value != ""))
				{
					base.ClientScript.RegisterStartupScript(base.GetType(), "", "ShowDialog(800,450,'Customer.aspx?tel=" + base.Server.UrlEncode(this.tel) + "','存在多个相同电话号码的客户,请选择');", true);
					return;
				}
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					if (dataTable.Rows[i]["ID"].ToString() == this.hfcusid.Value)
					{
						this.tbCusName.Text = dataTable.Rows[i]["_Name"].ToString();
						this.tbLinkName.Text = dataTable.Rows[i]["LinkMan"].ToString();
						this.tbCusTel.Text = dataTable.Rows[i]["Tel"].ToString();
						if (dataTable.Rows[i]["Tel2"].ToString() != "")
						{
							this.tbCusTel.Text = this.tbCusTel.Text + "(" + dataTable.Rows[i]["Tel2"].ToString() + ")";
						}
						this.tbFax.Text = dataTable.Rows[i]["Fax"].ToString();
						this.tbAdr.Text = dataTable.Rows[i]["Adr"].ToString();
						this.tbCusClass.Text = dataTable.Rows[i]["ClassName"].ToString();
						break;
					}
				}
			}
			this.FillData();
			this.FillDataD();
		}
	}

	public static string TelDecode(string str)
	{
		string[] array = new string[]
		{
			"S",
			"B",
			"T",
			"R",
			"V",
			"G",
			"F",
			"H",
			"J",
			"I"
		};
		string text = string.Empty;
		string text2 = string.Empty;
		for (int i = 0; i < str.Length; i += 3)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			for (int j = 0; j < array.Length; j++)
			{
				if (str[i].ToString() == array[j])
				{
					num = j;
					break;
				}
			}
			for (int j = 0; j < array.Length; j++)
			{
				if (str[i + 1].ToString() == array[j])
				{
					num2 = j;
					break;
				}
			}
			for (int j = 0; j < array.Length; j++)
			{
				if (str[i + 2].ToString() == array[j])
				{
					num3 = j;
					break;
				}
			}
			text2 = num.ToString() + num2.ToString() + num3.ToString();
			text2 = text2.TrimStart(new char[]
			{
				'0'
			}).TrimStart(new char[]
			{
				'0'
			});
			text += (char)int.Parse(text2);
		}
		return text;
	}
}
