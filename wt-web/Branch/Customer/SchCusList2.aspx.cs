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

public partial class Branch_Customer_SchCusList2 : Page, IRequiresSessionState
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
			text = FunLibrary.ChkInput(text);
			string text2 = " 1=1 ";
			DALSysParm dALSysParm = new DALSysParm();
			SysParmInfo model = dALSysParm.GetModel(1);
			if (model.CustomerShar == 1)
			{
				text2 = " (DeptID=" + (string)this.Session["Session_wtBranchID"] + " or DeptID=0)";
			}
			text = FunLibrary.ChkInput(text);
			if (text != string.Empty)
			{
				string text3 = text2;
				text2 = string.Concat(new string[]
				{
					text3,
					" and (CustomerNO like '%",
					text,
					"%' or _Name like '%",
					text,
					"%' or pyCode like '%",
					text,
					"%' or LinkMan like '%",
					text,
					"%' or Tel like '%",
					text,
					"%') "
				});
			}
			if (num > 0)
			{
				if (!dALRight.GetRight(num, "kh_r1"))
				{
					text2 += " and CusType<>1 ";
				}
				if (!dALRight.GetRight(num, "jc_r13"))
				{
					text2 += " and CusType<>2 ";
				}
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
			}
			string str = " order by [CustomerID] Desc ";
			this.gvice.DataSource = DALCommon.GetList("ks_customer2", " top 10 [CustomerID],CustomerNO,_Name,LinkMan,Tel,Type,CusType", text2 + str);
			this.gvice.DataBind();
		}
	}

	protected void gvice_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		e.Row.Cells[0].Visible = (e.Row.Cells[5].Visible = false);
		if (e.Row.RowType == DataControlRowType.DataRow)
		{
			e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
			e.Row.Attributes.Add("onclick", "$(\"hfType\").value='" + e.Row.Cells[5].Text + "';clickItem(this.sectionRowIndex);");
			e.Row.Attributes.Add("ondblclick", "MoveDivTable();");
			e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
		}
	}
}
