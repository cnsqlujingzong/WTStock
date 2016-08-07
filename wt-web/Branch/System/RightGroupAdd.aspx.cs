using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using wt.Model;

public partial class Branch_System_RightGroupAdd : Page, IRequiresSessionState
{
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
		if (!base.IsPostBack)
		{
			if ((string)this.Session["Session_wtPurB"] != "ϵͳ����Ա")
			{
				base.Response.Redirect("~/Headquarters/Pur.aspx?p=Right");
				base.Response.End();
			}
			DALRight dALRight = new DALRight();
			this._bcg = dALRight.ChkBranchPurchase(int.Parse(this.Session["Session_wtBranchID"].ToString()));
			this._bga = dALRight.BranchAddGoods(0, int.Parse(this.Session["Session_wtBranchID"].ToString()));
		}
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		if (FunLibrary.ChkInput(this.tbName.Text) == "ϵͳ����Ա")
		{
			this.SysInfo("window.alert('����ʧ�ܣ���Ȩ����������');");
		}
		else
		{
			RightInfo rightInfo = new RightInfo();
			DALRight dALRight = new DALRight();
			rightInfo.DeptID = int.Parse((string)this.Session["Session_wtBranchID"]);
			rightInfo._Name = FunLibrary.ChkInput(this.tbName.Text);
			List<RightDetailInfo> list = new List<RightDetailInfo>();
			for (int i = 1; i <= 79; i++)
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
			for (int i = 1; i <= 19; i++)
			{
				string text = "xs_r" + i;
				CheckBox checkBox = this.FindControl(text) as CheckBox;
				list.Add(new RightDetailInfo
				{
					bValue = checkBox.Checked,
					RightCode = text
				});
			}
			for (int i = 1; i <= 23; i++)
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
			for (int i = 1; i <= 32; i++)
			{
				string text = "kh_r" + i;
				CheckBox checkBox = this.FindControl(text) as CheckBox;
				list.Add(new RightDetailInfo
				{
					bValue = checkBox.Checked,
					RightCode = text
				});
			}
			for (int i = 1; i <= 23; i++)
			{
				string text = "zk_r" + i;
				CheckBox checkBox = this.FindControl(text) as CheckBox;
				list.Add(new RightDetailInfo
				{
					bValue = checkBox.Checked,
					RightCode = text
				});
			}
			for (int i = 1; i <= 28; i++)
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
			for (int i = 1; i <= 17; i++)
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
			int num2;
			int num = dALRight.Add(rightInfo, out num2);
			if (num == 0)
			{
				this.SysInfo("window.alert('����ɹ���Ȩ���������');parent.CloseDialog('1');");
			}
			else
			{
				this.SysInfo("window.alert('ϵͳ������鿴������־');");
			}
		}
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
