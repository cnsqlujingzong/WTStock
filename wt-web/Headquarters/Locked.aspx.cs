using System;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;

public partial class Headquarters_Locked : Page, IRequiresSessionState
{
	protected void Page_Load(object sender, EventArgs e)
	{
	}

	protected void btnUnLock_Click(object sender, EventArgs e)
	{
		if (this.tbLockCode.Text.Trim() != string.Empty)
		{
			try
			{
				string a = FunLibrary.StrDecode(this.tbLockCode.Text.Trim());
				string b = DateTime.Now.ToString("yyyy-MM-dd").Replace("-", "") + "differ";
				if (a == b)
				{
					DALSysVali dALSysVali = new DALSysVali();
					dALSysVali.Update("ITEM3", FunLibrary.StrEncode("running"));
					dALSysVali.Update("ITEM6", "SXHSRTSRXSRHSTRSRHSTFSTISTFSVSSVVSVSSVXSVHSFTSVJSVJSFISGXSGTSGFSGVSGXSGVSGI");
					dALSysVali.Update("ITEM5", DateTime.Today.ToString("yyyy-MM-dd"));
					this.lb1.Text = "解锁成功";
					this.btnUnLock.Enabled = false;
				}
				else
				{
					this.lb1.Text = "解锁码错误";
				}
			}
			catch
			{
				this.lb1.Text = "解锁码错误";
			}
		}
	}
}
