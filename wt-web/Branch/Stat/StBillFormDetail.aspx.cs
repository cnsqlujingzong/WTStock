using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class Branch_Services_StBillFormDetail : Page, IRequiresSessionState
{


	private string strQuerys;

	private string[] strs;

	private string dateStart;

	private string dateEnd;

	private string disposalID;



	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		this.strQuerys = base.Request["id"];
		this.strs = this.strQuerys.Split(new char[]
		{
			','
		});
		this.dateStart = this.strs[0];
		this.dateEnd = this.strs[1];
		this.disposalID = this.strs[2];
		if (!base.IsPostBack)
		{
			this.FillData();
		}
	}

	protected void btnSch_Click(object sender, EventArgs e)
	{
		string str = this.strParm();
		string selectedValue = this.ddlSch.SelectedValue;
		string text = selectedValue;
		if (text != null)
		{
			if (!(text == "1"))
			{
				if (!(text == "2"))
				{
					if (!(text == "3"))
					{
						if (!(text == "4"))
						{
							if (!(text == "5"))
							{
								if (text == "6")
								{
									str = str + " and Fault like '%" + FunLibrary.ChkInput(this.tbWhere.Text) + "%'";
								}
							}
							else
							{
								str = str + " and Tel like '%" + FunLibrary.ChkInput(this.tbWhere.Text) + "%'";
							}
						}
						else
						{
							str = str + " and LinkMan like '%" + FunLibrary.ChkInput(this.tbWhere.Text) + "%'";
						}
					}
					else
					{
						str = str + " and DisposalOper like '%" + FunLibrary.ChkInput(this.tbWhere.Text) + "%'";
					}
				}
				else
				{
					str = str + " and curStatus like '%" + FunLibrary.ChkInput(this.tbWhere.Text) + "%'";
				}
			}
			else
			{
				str = str + " and CustomerName like '%" + FunLibrary.ChkInput(this.tbWhere.Text) + "%'";
			}
		}
		this.gvdata.DataSource = DALCommon.GetList("serviceslist", "*", str + "order by ID desc ");
		this.gvdata.DataBind();
	}

	protected void FillData()
	{
		string str = this.strParm();
		this.gvdata.DataSource = DALCommon.GetList("serviceslist", "*", str + "order by ID desc ");
		this.gvdata.DataBind();
	}

	protected string strParm()
	{
		string text = " 1=1 ";
		this.dateStart = FunLibrary.ChkInput(this.dateStart);
		this.dateEnd = FunLibrary.ChkInput(this.dateEnd);
		text = text + " and Time_TakeOver>='" + this.dateStart + "'";
		text = text + " and Time_TakeOver<='" + this.dateEnd + " 23:59:59'";
		if (this.disposalID != "-1")
		{
			text = text + " and DisposalID = '" + this.disposalID + "'";
		}
		return text;
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
