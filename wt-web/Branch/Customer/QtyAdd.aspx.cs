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

public partial class Branch_Customer_QtyAdd : Page, IRequiresSessionState
{


	private int id;

	private int iflag;

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
		int.TryParse(base.Request["iflag"], out this.iflag);
		this.f = base.Request["f"];
		if (this.f == null || this.f == string.Empty)
		{
			this.f = "";
		}
		else
		{
			this.f = "1";
		}
		if (!base.IsPostBack)
		{
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
			this.tbDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
			OtherFunction.BindQtyType(this.ddlQty);
			if (this.iflag == 1)
			{
				DataTable dataTable = DALCommon.GetDataList("DeviceList", "ProductSN1", "[ID]=" + this.id).Tables[0];
				if (dataTable.Rows.Count > 0)
				{
					this.hfSN.Value = dataTable.Rows[0]["ProductSN1"].ToString();
				}
			}
			else
			{
				DataTable dataTable = DALCommon.GetDataList("ServicesList", "ProductSN1", "[ID]=" + this.id).Tables[0];
				if (dataTable.Rows.Count > 0)
				{
					this.hfSN.Value = dataTable.Rows[0]["ProductSN1"].ToString();
				}
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		DALQtyList dALQtyList = new DALQtyList();
		QtyListInfo qtyListInfo = new QtyListInfo();
		if (this.iflag == 1)
		{
			qtyListInfo.BillID = 0;
			qtyListInfo.DeviceID = this.id;
		}
		else
		{
			qtyListInfo.BillID = this.id;
			qtyListInfo.DeviceID = 0;
		}
		qtyListInfo._Date = DateTime.Parse(this.tbDate.Text);
		qtyListInfo.OperatorID = int.Parse(this.ddlOperator.SelectedValue);
		int qty = 0;
		int.TryParse(this.tbQty.Text, out qty);
		qtyListInfo.Qty = qty;
		qtyListInfo.QtyType = this.ddlQty.SelectedItem.Text;
		qtyListInfo.Remark = this.tbRemark.Text;
		qtyListInfo.SN = this.hfSN.Value;
		qtyListInfo.Allowance = this.tbAllowance.Text;
		dALQtyList.Add(qtyListInfo);
		this.SysInfo("parent.CloseDialog('1');");
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
