using System;
using System.Data;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.DB;
using wt.Model;

public partial class Branch_Default : Page, IRequiresSessionState
{
	
	protected string[] module = new string[20];

	protected string[] modulc = new string[20];

	protected int[] modulh = new int[20];

	protected int[] modulh_s = new int[50];

	protected int[] modulh_h = new int[10];

	protected int[] menu_s = new int[10];

	protected string[] menu_h = new string[10];

	protected string[] menu = new string[300];

	protected string[] moduln = new string[20];

	protected int[] modulm = new int[20];

	private int toolheight = 85;

	private int sysheight = 85;

	private bool showol = false;

	private bool showno = false;

	private string strtitle = "网点平台";

	
	protected string strTitle
	{
		get
		{
			return this.strtitle;
		}
	}

	protected int toolHeight
	{
		get
		{
			return this.toolheight;
		}
	}

	protected int sysHeight
	{
		get
		{
			return this.sysheight;
		}
	}

	protected string showOL
	{
		get
		{
			string result;
			if (this.showol)
			{
				result = "";
			}
			else
			{
				result = "none";
			}
			return result;
		}
	}

	protected string showNO
	{
		get
		{
			string result;
			if (this.showno)
			{
				result = "";
			}
			else
			{
				result = "none";
			}
			return result;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		if (this.Session["Session_wtUserB"] == null || this.Session["Session_wtUserBID"] == null)
		{
			base.Response.Write("<Script>top.location.href = '../Headquarters/Tip.html';</Script>");
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			this.hfServerDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
			this.hfUser.Value = (string)this.Session["Session_wtUserB"];
			this.hfPurview.Value = (string)this.Session["Session_wtPurB"];
			this.strtitle = "网点平台-" + (string)this.Session["Session_wtBranch"];
			DALSysParm dALSysParm = new DALSysParm();
			SysParmInfo model = dALSysParm.GetModel(1);
			if (model != null)
			{
				if (model.SysName != string.Empty)
				{
					this.strtitle = (string)this.Session["Session_wtBranch"] + "-" + model.SysName + "网点平台";
				}
			}
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num == 0)
			{
				this.modulh[0] = 255;
				this.modulh[1] = 106;
				this.modulh[2] = 106;
				this.modulh[3] = 149;
				this.modulh[4] = 150;
				this.modulh[5] = 148;
				this.modulh[6] = 128;
				this.modulh[7] = 85;
				this.modulh[8] = 232;
				this.modulh[9] = 63;
				this.modulh[10] = 168;
				this.modulh[11] = 210;
				this.modulh[12] = 85;
				this.modulh[13] = 85;
				this.modulh[14] = 85;
				int[] array = new int[]
				{
					26,
					86,
					146,
					206,
					266,
					326,
					386,
					446,
					506,
					561,
					621,
					681,
					741,
					801,
					836
				};
				DALRight dALRight = new DALRight();
				if (!dALRight.ChkBranchPurchase(int.Parse(this.Session["Session_wtBranchID"].ToString())))
				{
					this.module[1] = "return false;";
					this.modulc[1] = "style=\"color:#aaa;\"";
					this.moduln[1] = "style=\"display:none;\"";
					array[14] = 776;
					for (int i = 13; i > 1; i--)
					{
						array[i] = array[i - 1];
					}
				}
				for (int i = 0; i < array.Length; i++)
				{
					this.modulm[i] = array[i];
				}
			}
			else
			{
				DataSet dataSet = DALCommon.aa_getright(num);
				DataTable dataTable = dataSet.Tables[0];
				int count = dataTable.Rows.Count;
				if (count > 0)
				{
					string text = string.Empty;
					for (int i = 1; i <= count; i++)
					{
						text = dataTable.Rows[i - 1]["pur"].ToString();
						if (text == "0")
						{
							this.module[i - 1] = "return false;";
							this.modulc[i - 1] = "style=\"color:#aaa;\"";
							this.moduln[i - 1] = "style=\"display:none;\"";
						}
						this.modulm[i - 1] = int.Parse(text);
					}
					this.modulm[12] = 1;
					this.modulm[13] = 1;
					this.modulm[14] = 1;
					int[] array = new int[]
					{
						26,
						86,
						146,
						206,
						266,
						326,
						386,
						446,
						506,
						561,
						621,
						681,
						741,
						801,
						861
					};
					int num2 = 0;
					int num3 = this.modulm[0];
					for (int j = 0; j < this.modulm.Length; j++)
					{
						if (num3 > 0)
						{
							if (this.modulm[j] > 0)
							{
								if (j > 13)
								{
									this.modulm[j] = array[num2] - 25;
								}
								else
								{
									this.modulm[j] = array[num2];
								}
								num2++;
							}
						}
						else if (this.modulm[j] > 0)
						{
							if (j > 13)
							{
								this.modulm[j] = array[num2] - 25;
							}
							else
							{
								this.modulm[j] = array[num2];
							}
							num2++;
						}
					}
					this.modulh[0] = 255;
					this.modulh[1] = 106;
					this.modulh[2] = 106;
					this.modulh[3] = 129;
					this.modulh[4] = 150;
					this.modulh[5] = 148;
					this.modulh[6] = 128;
					this.modulh[7] = 85;
					this.modulh[8] = 212;
					this.modulh[9] = 63;
					this.modulh[10] = 168;
					this.modulh[11] = 190;
					this.modulh[12] = 85;
					this.modulh[13] = 85;
					this.modulh[14] = 85;
					this.menu[205] = "style=\"display:none;\"";
				}
			}
			if (model.bSim)
			{
				this.toolheight = 107;
				this.modulh[13] = 107;
				this.showol = true;
			}
			if (model.bPurSep || model.bSellSep || model.bSerSep)
			{
				this.sysheight = 107;
				this.modulh[12] = 107;
				this.showno = true;
			}
			int iStaffid = int.Parse((string)this.Session["Session_wtUserBID"]);
			int iDeptid = int.Parse((string)this.Session["Session_wtBranchID"]);
			this.rptool.DataSource = DALCommon.aa_gettoolbar(iDeptid, iStaffid).Tables[0];
			this.rptool.DataBind();
			DataTable dataTable2 = DALCommon.GetDataList("SysParm", "bSim", "ID=1 and bSim=1").Tables[0];
			if (dataTable2.Rows.Count > 0)
			{
				this.btnRefreshOnline_Click(sender, e);
			}
		}
	}

	protected void btnExit_Click(object sender, EventArgs e)
	{
		int num;
		int.TryParse((string)this.Session["Session_wtUserBID"], out num);
		DALUserManage dALUserManage = new DALUserManage();
		dALUserManage.Logout(num);
		DbHelperSQL.InsertErrorLogs(1, num, 0, "退出系统", 0);
		this.Session.Remove("Session_wtUserB");
		this.Session.Remove("Session_wtPurB");
		this.Session.Remove("Session_wtUserBID");
		base.Response.Write("<Script>top.location.href = '../Default.aspx';</Script>");
	}

	protected void btnRefreshOnline_Click(object sender, EventArgs e)
	{
		int iD = int.Parse(this.Session["Session_wtUserBID"].ToString());
		string text = string.Empty;
		if (this.Session["OperCode"] == null)
		{
			base.Response.Redirect("../Headquarters/Tip.html");
		}
		else
		{
			text = this.Session["OperCode"].ToString().Trim();
			if (!text.Equals(""))
			{
				DALUserManage dALUserManage = new DALUserManage();
				int num = dALUserManage.RefreshOnline(iD, text);
				if (num == 1)
				{
					ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.UpdatePanel1.GetType(), "ftime", "setTimeout('document.getElementById(\"btnRefreshOnline\").click();',30000);", true);
				}
				else
				{
					base.Response.Redirect("../Headquarters/Tip.html");
				}
			}
			else
			{
				base.Response.Redirect("../Headquarters/Tip.html");
			}
		}
	}
}
