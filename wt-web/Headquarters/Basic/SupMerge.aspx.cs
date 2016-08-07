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

public partial class Headquarters_Basic_SupMerge : Page, IRequiresSessionState
{

	private string ids = string.Empty;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		if (base.Request.QueryString["id"] != null)
		{
			this.ids = base.Request.QueryString["id"].Trim().Trim(new char[]
			{
				','
			});
		}
		if (!base.IsPostBack)
		{
			int num = int.Parse((string)this.Session["Session_wtPurID"]);
			if (num > 0)
			{
				DALRight dALRight = new DALRight();
				if (!dALRight.GetRight(num, "jc_r34"))
				{
					this.btnAdd.Enabled = false;
				}
			}
			if (this.ids.Equals(""))
			{
				this.SysInfo("parent.CloseDialog();");
			}
			DataSet list = DALCommon.GetList("SupplierList", "ID,_Name,LinkMan,Tel,Adr,Remark", string.Format("ID in({0})", this.ids));
			this.ddlAdr.DataSource = list;
			this.ddlAdr.DataTextField = "Adr";
			this.ddlAdr.DataValueField = "Adr";
			this.ddlAdr.DataBind();
			while (this.ddlAdr.Items.FindByText("") != null)
			{
				this.ddlAdr.Items.Remove(this.ddlAdr.Items.FindByText(""));
			}
			this.ddlAdr.Items.Insert(0, new ListItem("", ""));
			this.ddlCusName.DataSource = list;
			this.ddlCusName.DataTextField = "_Name";
			this.ddlCusName.DataValueField = "_Name";
			this.ddlCusName.DataBind();
			while (this.ddlCusName.Items.FindByText("") != null)
			{
				this.ddlCusName.Items.Remove(this.ddlAdr.Items.FindByText(""));
			}
			this.ddlCusName.Items.Insert(0, new ListItem("", ""));
			this.ddlLinkMan.DataSource = list;
			this.ddlLinkMan.DataTextField = "LinkMan";
			this.ddlLinkMan.DataValueField = "LinkMan";
			this.ddlLinkMan.DataBind();
			while (this.ddlLinkMan.Items.FindByText("") != null)
			{
				this.ddlLinkMan.Items.Remove(this.ddlAdr.Items.FindByText(""));
			}
			this.ddlLinkMan.Items.Insert(0, new ListItem("", ""));
			this.ddlLinkTel.DataSource = list;
			this.ddlLinkTel.DataTextField = "Tel";
			this.ddlLinkTel.DataValueField = "Tel";
			this.ddlLinkTel.DataBind();
			while (this.ddlLinkTel.Items.FindByText("") != null)
			{
				this.ddlLinkTel.Items.Remove(this.ddlAdr.Items.FindByText(""));
			}
			this.ddlLinkTel.Items.Insert(0, new ListItem("", ""));
			this.ddlRemark.DataSource = list;
			this.ddlRemark.DataTextField = "Remark";
			this.ddlRemark.DataValueField = "Remark";
			this.ddlRemark.DataBind();
			while (this.ddlRemark.Items.FindByText("") != null)
			{
				this.ddlRemark.Items.Remove(this.ddlAdr.Items.FindByText(""));
			}
			this.ddlRemark.Items.Insert(0, new ListItem("", ""));
			this.gvdata.DataSource = list;
			this.gvdata.DataBind();
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		int num = 0;
		int.TryParse(this.hfID.Value, out num);
		if (num <= 0)
		{
			this.SysInfo("alert('请选择要合并为哪个厂商');");
		}
		else
		{
			DALSupplierList dALSupplierList = new DALSupplierList();
			bool flag = dALSupplierList.SupMerge(num, this.ids, this.tbCusName.Text.Trim(), this.tbLinkMan.Text.Trim(), this.tbLinkTel.Text.Trim(), this.tbAdr.Text.Trim(), this.tbRemark.Text.Trim());
			if (flag)
			{
				this.SysInfo("alert('合并成功！');parent.CloseDialog('1');");
			}
			else
			{
				this.SysInfo("alert('合并失败！');");
			}
		}
	}

	protected void gvdata_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes["id"] = e.Row.Cells[0].Text;
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
