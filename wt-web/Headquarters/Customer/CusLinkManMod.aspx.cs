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

public partial class Headquarters_Customer_CusLinkManMod : Page, IRequiresSessionState
{

	private string strc;

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
		FunLibrary.ChkHead(btel);
		this.f = base.Request["f"];
		if (this.f == "1")
		{
			this.d = "2";
		}
		else
		{
			this.d = "1";
		}
		this.strc = base.Request["str"];
		if (this.strc == null)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			string[] array = this.strc.Split(new char[]
			{
				','
			});
			this.tbName.Text = array[0].ToString();
			this.tbDept.Text = array[1].ToString();
			this.tbSex.Value = array[2].ToString();
			this.tbPosition.Value = array[3].ToString();
			this.tbTel1.Text = array[4].ToString();
			this.tbTel2.Text = array[5].ToString();
			this.tbTel3.Text = array[6].ToString();
			this.tbFax.Text = array[7].ToString();
			this.tbBirthDay.Text =string.Format("{0:yyyy-MM-dd}",array[8]);
			this.tbEmail.Text = array[9].ToString();
			this.tbAdr.Text = array[10].ToString();
			this.tbRemark.Text = array[11].ToString();

            this.tbmoblie.Text = array[12].ToString();
            this.tbmoblie2.Text = array[13].ToString();
            this.tbQQ.Text = array[14].ToString();
            this.tbWeixin.Text = array[15].ToString();
            this.tbprivateAdr.Text = array[16].ToString();

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
            text += FunLibrary.ChkInput(this.tbRemark.Text) + ",";

            text += FunLibrary.ChkInput(this.tbmoblie.Text) + ",";
            text += FunLibrary.ChkInput(this.tbmoblie2.Text) + ",";
            text += FunLibrary.ChkInput(this.tbQQ.Text) + ",";
            text += FunLibrary.ChkInput(this.tbWeixin.Text) + ",";
            text += FunLibrary.ChkInput(this.tbprivateAdr.Text);
			this.SysInfo("ChkAdd('" + text + "');");
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
