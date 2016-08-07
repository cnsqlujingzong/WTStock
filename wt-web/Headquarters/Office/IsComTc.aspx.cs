using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.DB;
using wt.Library;

public partial class Headquarters_Office_IsComTc : Page, IRequiresSessionState
{

	private int id;

	private string strTypes;

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkHead();
		int.TryParse(base.Request["id"], out this.id);
		this.strTypes = base.Server.UrlDecode(base.Request["type"]);
		if (this.id == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			DataTable dataTable = DALCommon.GetDataList("tc_detail", "", string.Concat(new object[]
			{
				" [ID]=",
				this.id,
				"and Type='",
				this.strTypes,
				"'"
			})).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbName.Text = dataTable.Rows[0]["Operator"].ToString();
				this.tbBiilNO.Text = dataTable.Rows[0]["BillID"].ToString();
				this.tbDate.Text = dataTable.Rows[0]["Time_Finish"].ToString();
				this.tbBillType.Text = dataTable.Rows[0]["Type"].ToString();
				this.tbSuoShu.Text = dataTable.Rows[0]["Dept"].ToString();
				this.tbIsShouKuan.Text = dataTable.Rows[0]["Types"].ToString();
				this.tbTcAmount.Text = dataTable.Rows[0]["Deduct"].ToString();
			}
		}
	}

	public void Update(int ID, string strTabName)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("update " + strTabName + " set ");
		stringBuilder.Append("IsComIssued=@IsComIssued");
		stringBuilder.Append(" where ID=@ID");
		SqlParameter[] array = new SqlParameter[]
		{
			new SqlParameter("@ID", SqlDbType.Int, 4),
			new SqlParameter("@IsComIssued", SqlDbType.VarChar, 50)
		};
		array[0].Value = ID;
		array[1].Value = "已发放";
		DbHelperSQL.ExecuteSql(stringBuilder.ToString(), array);
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		if (this.tbBillType.Text == "服务")
		{
			this.Update(this.id, "BillDeduct");
		}
		if (this.tbBillType.Text == "销售")
		{
			this.Update(this.id, "SellDeduct");
		}
		this.SysInfo("window.alert('操作成功！');parent.CloseDialog('1');");
	}
}
