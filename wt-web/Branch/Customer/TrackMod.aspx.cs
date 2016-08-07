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
using wt.OtherLibrary;

public partial class Branch_Customer_TrackMod : Page, IRequiresSessionState
{
	

	private int id;

	private string f;



	public string Str_F
	{
		get
		{
			return this.f;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		this.f = base.Request["f"];
		if (this.f == null || this.f == "")
		{
			this.f = "";
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "kh_r18"))
				{
					this.lbMod.Text = "你没有操作权限";
					this.lbMod.Attributes.Add("class", "si3");
					this.btnAdd.Enabled = false;
				}
			}
			OtherFunction.BindStaff(this.ddlOperator, " DeptID=" + (string)this.Session["Session_wtBranchID"]);
			string b = (string)this.Session["Session_wtUserB"];
			for (int i = 0; i < this.ddlOperator.Items.Count; i++)
			{
				if (this.ddlOperator.Items[i].Text == b)
				{
					this.ddlOperator.Items[i].Selected = true;
					break;
				}
			}
			OtherFunction.BindTrackStyle(this.ddlTrackStyle);
			OtherFunction.BindTrackType(this.ddlTrackType);
			DataTable dataTable = DALCommon.GetDataList("ks_customertrack", "", " [ID]=" + this.id).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbDate.Text = dataTable.Rows[0]["_Date"].ToString();
				for (int i = 0; i < this.ddlOperator.Items.Count; i++)
				{
					if (this.ddlOperator.Items[i].Text == dataTable.Rows[0]["Operator"].ToString())
					{
						this.ddlOperator.Items[i].Selected = true;
						break;
					}
				}
				for (int i = 0; i < this.ddlTrackStyle.Items.Count; i++)
				{
					if (this.ddlTrackStyle.Items[i].Text == dataTable.Rows[0]["TrackStyle"].ToString())
					{
						this.ddlTrackStyle.Items[i].Selected = true;
						break;
					}
				}
				for (int i = 0; i < this.ddlTrackType.Items.Count; i++)
				{
					if (this.ddlTrackType.Items[i].Text == dataTable.Rows[0]["TrackType"].ToString())
					{
						this.ddlTrackType.Items[i].Selected = true;
						break;
					}
				}
				this.tbLinkMan.Text = dataTable.Rows[0]["LinkMan"].ToString();
				this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString();
				this.tbContent.Text = dataTable.Rows[0]["Content"].ToString();
				this.tbResult.Text = dataTable.Rows[0]["Result"].ToString();
				this.tbNextDate.Text = dataTable.Rows[0]["NextTrack"].ToString();
				if (dataTable.Rows[0]["bTrack"].ToString() != "")
				{
					this.cbTrack.Checked = true;
				}
				this.hfCusID.Value = dataTable.Rows[0]["CustomerID"].ToString();
				DataTable dataSource = DALCommon.GetList("CustomerLinkMan", "[ID],_Name", " CustomerID=" + this.hfCusID.Value).Tables[0];
				this.ddlLinkMan.DataSource = dataSource;
				this.ddlLinkMan.DataTextField = "_Name";
				this.ddlLinkMan.DataValueField = "ID";
				this.ddlLinkMan.DataBind();
				this.ddlLinkMan.Items.Insert(0, new ListItem("", ""));
			}
		}
	}

	protected void ddlLinkMan_SelectedIndexChanged(object sender, EventArgs e)
	{
		DataTable dataTable = DALCommon.GetList("CustomerLinkMan", "[ID],LinkManDept,tel_Office,tel_Mobile,Fax,Adr", string.Concat(new string[]
		{
			" CustomerID=",
			this.hfCusID.Value,
			" and _Name='",
			FunLibrary.ChkInput(this.tbLinkMan.Text),
			"'"
		})).Tables[0];
		if (dataTable.Rows.Count > 0)
		{
			this.tbTel.Text = dataTable.Rows[0]["tel_Office"].ToString();
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		CustomerTrackInfo customerTrackInfo = new CustomerTrackInfo();
		customerTrackInfo.ID = this.id;
		customerTrackInfo._Date = DateTime.Parse(this.tbDate.Text);
		customerTrackInfo.OperatorID = int.Parse(this.ddlOperator.SelectedValue);
		customerTrackInfo.TrackStyleID = int.Parse(this.ddlTrackStyle.SelectedValue);
		customerTrackInfo.TrackTypeID = int.Parse(this.ddlTrackType.SelectedValue);
		customerTrackInfo.LinkMan = this.tbLinkMan.Text;
		customerTrackInfo.Tel = this.tbTel.Text;
		customerTrackInfo.Content = this.tbContent.Text;
		customerTrackInfo.Result = this.tbResult.Text;
		if (this.tbNextDate.Text != "")
		{
			customerTrackInfo.NextTrack = this.tbNextDate.Text;
		}
		customerTrackInfo.bTrack = this.cbTrack.Checked;
		DALCustomerTrack dALCustomerTrack = new DALCustomerTrack();
		dALCustomerTrack.Update(customerTrackInfo);
		this.SysInfo("parent.CloseDialog('1');");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
