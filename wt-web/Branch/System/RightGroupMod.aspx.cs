using System;
using System.Collections.Generic;
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

public partial class Branch_System_RightGroupMod : Page, IRequiresSessionState
{
	
	private int ids;

	private bool _bcg;

	private bool _bga;

	

	public bool bCG
	{
		get
		{
			return this._bcg;
		}
	}

	public bool bGA
	{
		get
		{
			return this._bga;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		FunLibrary.ChkBran();
		int.TryParse(base.Request["id"], out this.ids);
		if (this.ids == 0)
		{
			base.Response.End();
		}
		if (!base.IsPostBack)
		{
			if ((string)this.Session["Session_wtPurB"] != "系统管理员")
			{
				base.Response.Redirect("~/Headquarters/Pur.aspx?p=Right");
				base.Response.End();
			}
			DALRight dALRight = new DALRight();
			this._bcg = dALRight.ChkBranchPurchase(int.Parse(this.Session["Session_wtBranchID"].ToString()));
			this._bga = dALRight.BranchAddGoods(0, int.Parse(this.Session["Session_wtBranchID"].ToString()));
			DataTable dataTable = DALCommon.GetDataList("[Right]", "", " [ID]=" + this.ids.ToString()).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				this.tbName.Text = dataTable.Rows[0]["_Name"].ToString();
			}
			DataTable dataTable2 = DALCommon.GetDataList("RightDetail", "", " RightID=" + this.ids.ToString()).Tables[0];
			if (dataTable2.Rows.Count > 0)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					CheckBox checkBox = this.FindControl(dataTable2.Rows[i]["RightCode"].ToString()) as CheckBox;
					bool @checked = false;
					bool.TryParse(dataTable2.Rows[i]["bValue"].ToString(), out @checked);
					if (checkBox != null)
					{
						checkBox.Checked = @checked;
					}
				}
			}
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		if (FunLibrary.ChkInput(this.tbName.Text) == "系统管理员")
		{
			this.SysInfo("window.alert('操作失败！该权限名不可用');");
		}
		else
		{
			RightInfo rightInfo = new RightInfo();
			DALRight dALRight = new DALRight();
			rightInfo.ID = this.ids;
			rightInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
			List<RightDetailInfo> list = new List<RightDetailInfo>();
			for (int i = 1; i <= 84; i++)
			{
				string text = "ck_r" + i;
				CheckBox checkBox = this.FindControl(text) as CheckBox;
				list.Add(new RightDetailInfo
				{
					bValue = checkBox.Checked,
					RightCode = text
				});
			}
			for (int i = 1; i <= 18; i++)
			{
				string text = "cg_r" + i;
				CheckBox checkBox = this.FindControl(text) as CheckBox;
				list.Add(new RightDetailInfo
				{
					bValue = checkBox.Checked,
					RightCode = text
				});
			}
			for (int i = 1; i <= 20; i++)
			{
				string text = "xs_r" + i;
				CheckBox checkBox = this.FindControl(text) as CheckBox;
				list.Add(new RightDetailInfo
				{
					bValue = checkBox.Checked,
					RightCode = text
				});
			}
			for (int i = 1; i <= 30; i++)
			{
				string text = "gd_r" + i;
				CheckBox checkBox = this.FindControl(text) as CheckBox;
				list.Add(new RightDetailInfo
				{
					bValue = checkBox.Checked,
					RightCode = text
				});
			}
			for (int i = 1; i <= 27; i++)
			{
				string text = "zl_r" + i;
				CheckBox checkBox = this.FindControl(text) as CheckBox;
				list.Add(new RightDetailInfo
				{
					bValue = checkBox.Checked,
					RightCode = text
				});
			}
			for (int i = 1; i <= 33; i++)
			{
				string text = "kh_r" + i;
				CheckBox checkBox = this.FindControl(text) as CheckBox;
				list.Add(new RightDetailInfo
				{
					bValue = checkBox.Checked,
					RightCode = text
				});
			}
			for (int i = 1; i <= 24; i++)
			{
				string text = "zk_r" + i;
				CheckBox checkBox = this.FindControl(text) as CheckBox;
				list.Add(new RightDetailInfo
				{
					bValue = checkBox.Checked,
					RightCode = text
				});
			}
			for (int i = 1; i <= 29; i++)
			{
				string text = "bg_r" + i;
				CheckBox checkBox = this.FindControl(text) as CheckBox;
				list.Add(new RightDetailInfo
				{
					bValue = checkBox.Checked,
					RightCode = text
				});
			}
			for (int i = 1; i <= 4; i++)
			{
				string text = "fh_r" + i;
				CheckBox checkBox = this.FindControl(text) as CheckBox;
				list.Add(new RightDetailInfo
				{
					bValue = checkBox.Checked,
					RightCode = text
				});
			}
			for (int i = 1; i <= 5; i++)
			{
				string text = "qc_r" + i;
				CheckBox checkBox = this.FindControl(text) as CheckBox;
				list.Add(new RightDetailInfo
				{
					bValue = checkBox.Checked,
					RightCode = text
				});
			}
			for (int i = 1; i <= 63; i++)
			{
				string text = "tj_r" + i;
				CheckBox checkBox = this.FindControl(text) as CheckBox;
				list.Add(new RightDetailInfo
				{
					bValue = checkBox.Checked,
					RightCode = text
				});
			}
			for (int i = 1; i <= 18; i++)
			{
				string text = "jc_r" + i;
				CheckBox checkBox = this.FindControl(text) as CheckBox;
				list.Add(new RightDetailInfo
				{
					bValue = checkBox.Checked,
					RightCode = text
				});
			}
			rightInfo.RightDetailInfos = list;
			string text2 = "";
			int num = dALRight.Update(rightInfo, out text2);
			if (num == 0)
			{
				this.SysInfo("window.alert('保存成功！权限组已更新');parent.CloseDialog('1');");
			}
			else
			{
				this.SysInfo("window.alert('系统错误！请查看错误日志');");
			}
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
