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

public partial class Branch_Customer_CusLinkManAdd : Page, IRequiresSessionState
{
	private string f;

	private string d;

	

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
		FunLibrary.ChkBran(btel);
		this.f = base.Request["f"];
		if (this.f == "1")
		{
			this.d = "2";
		}
		else
		{
			this.d = "1";
		}
		if (!base.IsPostBack)
		{
			if (base.Request.QueryString["cid"] != null)
			{
				DataTable dataSource = DALCommon.GetList("CustomerDept", "[ID],_Name", " CustomerID=" + base.Request.QueryString["cid"]).Tables[0];
				this.ddlDept.DataSource = dataSource;
				this.ddlDept.DataTextField = "_Name";
				this.ddlDept.DataValueField = "ID";
				this.ddlDept.DataBind();
				this.ddlDept.Items.Insert(0, new ListItem("", ""));
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		if (this.tbName.Text.Trim() != string.Empty)
		{
			string text = string.Empty;
			text = FunLibrary.ChkInput(this.tbName.Text) + ",";
			text = text + FunLibrary.ChkInput(this.tbDept.Text) + ",";
			text = text + FunLibrary.ChkInput(this.tbSex.Value) + ",";
			text = text + FunLibrary.ChkInput(this.tbPosition.Value) + ",";
			text = text + FunLibrary.ChkInput(this.tbTel1.Text) + ",";
			text = text + FunLibrary.ChkInput(this.tbTel2.Text) + ",";
			text = text + FunLibrary.ChkInput(this.tbTel3.Text) + ",";
			text = text + FunLibrary.ChkInput(this.tbFax.Text) + ",";
			text = text + FunLibrary.ChkInput(this.tbBirthDay.Text) + ",";
			text = text + FunLibrary.ChkInput(this.tbEmail.Text) + ",";
			text = text + FunLibrary.ChkInput(this.tbAdr.Text) + ",";
			text += FunLibrary.ChkInput(this.tbRemark.Text);
			this.SysInfo("ChkAdd('" + text + "');");
			if (!this.cbClose.Checked)
			{
				this.ClearText();
				this.SysInfo("$(\"tbName\").focus();");
			}
		}
	}

	protected void ClearText()
	{
		this.tbBirthDay.Text = (this.tbDept.Text = (this.tbEmail.Text = (this.tbFax.Text = (this.tbName.Text = (this.tbPosition.Value = (this.tbRemark.Text = (this.tbSex.Value = (this.tbTel1.Text = (this.tbTel2.Text = (this.tbTel3.Text = string.Empty))))))))));
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
