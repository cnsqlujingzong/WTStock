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

public partial class Headquarters_Customer_TrackAdd : Page, IRequiresSessionState
{
	private int id;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"], out this.id);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "kh_r14"))
				{
					this.lbMod.Text = "你没有操作权限";
					this.lbMod.Attributes.Add("class", "si3");
					this.btnAdd.Enabled = false;
				}
			}
			OtherFunction.BindStaff(this.ddlOperator, " DeptID=1 and Status<>1 ");
			string b = (string)this.Session["Session_wtUser"];
			for (int i = 0; i < this.ddlOperator.Items.Count; i++)
			{
				if (this.ddlOperator.Items[i].Text == b)
				{
					this.ddlOperator.Items[i].Selected = true;
					break;
				}
			}
			this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
			OtherFunction.BindTrackStyle(this.ddlTrackStyle);
			OtherFunction.BindTrackType(this.ddlTrackType);
			DataTable dataTable = DALCommon.GetDataList("CustomerList", "LinkMan,Tel,Tel2,TrackOperatorID", " [ID]=" + this.id).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbLinkMan.Text = dataTable.Rows[0]["LinkMan"].ToString();
				this.tbTel.Text = dataTable.Rows[0]["Tel"].ToString();
				if (this.tbTel.Text == "")
				{
					this.tbTel.Text = dataTable.Rows[0]["Tel2"].ToString();
				}
				DataTable dataSource = DALCommon.GetList("CustomerLinkMan", "[ID],_Name", " CustomerID=" + this.id).Tables[0];
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
		DataTable dataTable = DALCommon.GetList("CustomerLinkMan", "[ID],LinkManDept,tel_Office,tel_Mobile,Fax,Adr", string.Concat(new object[]
		{
			" CustomerID=",
			this.id,
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
		customerTrackInfo.CustomerID = this.id;
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
		dALCustomerTrack.Add(customerTrackInfo);
		this.SysInfo("parent.CloseDialog('1');");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
