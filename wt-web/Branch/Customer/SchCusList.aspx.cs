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

public partial class Branch_Customer_SchCusList : Page, IRequiresSessionState
{
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
		string text = base.Request.Form["keydata"];
		if (text == null)
		{
			base.Response.End();
		}
		this.f = base.Request.Form["f"];
		if (!base.IsPostBack)
		{
			DALRight dALRight = new DALRight();
			int num = int.Parse((string)this.Session["Session_wtPurBID"]);
			if (num > 0)
			{
				if (!dALRight.GetRight(num, "kh_r1"))
				{
					return;
				}
			}
			text = FunLibrary.ChkInput(text);
			string text2 = " bStop=0 ";
			DALSysParm dALSysParm = new DALSysParm();
			SysParmInfo model = dALSysParm.GetModel(1);
			if (model.CustomerShar == 1)
			{
				text2 = text2 + " and DeptID=" + (string)this.Session["Session_wtBranchID"];
			}
			if (text != string.Empty)
			{
				string text3 = text2;
				text2 = string.Concat(new string[]
				{
					text3,
					" and (CustomerNO like '%",
					text,
					"%' or QQ like '%",
					text,
					"%' or _Name like '%",
					text,
					"%' or pyCode like '%",
					text,
					"%' or LinkMan like '%",
					text,
					"%' or Tel like '%",
					text,
					"%' or Tel2 like '%",
					text,
					"%' or [ID] in(select CustomerID from CustomerLinkMan where tel_Office like '%",
					text,
					"%' or tel_Home like '%",
					text,
					"%' or tel_Mobile like '%",
					text,
					"%'))"
				});
			}
			if (num > 0)
			{
				if (dALRight.GetRight(num, "kh_r10"))
				{
					DataTable dataTable = DALCommon.GetDataList("StaffList", "Area", " [ID]=" + (string)this.Session["Session_wtUserBID"]).Tables[0];
					if (dataTable.Rows.Count > 0)
					{
						string text4 = dataTable.Rows[0]["Area"].ToString();
						if (text4 != "")
						{
							text2 = text2 + " and (CHARINDEX('" + text4 + "',Area)>0 or Area='' or Area is null) ";
						}
					}
				}
				if (dALRight.GetRight(num, "kh_r32"))
				{
					text2 = text2 + " and (SellerID in(select ID from StaffList where StaffDeptID=(select StaffDeptID from StaffList where ID=" + (string)this.Session["Session_wtUserBID"] + ")) or SellerID is null)";
				}
			}
			string str = " order by [ID] Desc ";
			this.gvice.DataSource = DALCommon.GetList("CustomerList", " top 10 [ID],CustomerNO,_Name,LinkMan,Tel", text2 + str);
			this.gvice.DataBind();
		}
	}

	protected void gvice_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = false;
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "clickItem(this.sectionRowIndex);");
			e.Row.Attributes.Add("ondblclick", "MoveDivTable();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
	}
}
