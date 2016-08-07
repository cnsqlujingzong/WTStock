// Decompiled with JetBrains decompiler
// Type: Branch_Services_SchBack
// Assembly: wt.web, Version=0.0.0.0, Culture=neutral
// MVID: D3272D05-C02C-47E6-9FBF-767A521D8A35
// Assembly location: C:\Users\Administrator\Desktop\wt_itfiles\wt_itfiles\wt_files\bin\wt.web.dll

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

public partial class Branch_Services_SchBack : Page, IRequiresSessionState
{
    private int id;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        FunLibrary.ChkBran();
        int.TryParse(this.Request["id"], out this.id);
        if (this.id == 0)
            this.Response.End();
        if (this.IsPostBack)
            return;
        int RightID = int.Parse((string)this.Session["Session_wtPurBID"]);
        if (RightID > 0 && !new DALRight().GetRight(RightID, "gd_r19"))
            this.btnAdd.Enabled = false;
        DataTable dataTable = DALCommon.GetDataList("ServicesList", "", "ID=" + (object)this.id).Tables[0];
        string str1 = dataTable.Rows[0]["curStatus"].ToString().Trim();
        string str2 = dataTable.Rows[0]["RepairStatus"].ToString().Trim();
        int num = 7;
        switch (str1)
        {
            case "已结束":
                num = 7;
                break;
            case "已取消":
                num = 7;
                break;
            case "待审核":
                num = 6;
                break;
            case "待结算":
                num = 5;
                break;
            case "送修":
                if (str2.Equals("待送修收货"))
                {
                    num = 4;
                    break;
                }
                if (str2.Equals("待送修发货"))
                {
                    num = 3;
                    break;
                }
                break;
            case "待确认":
                num = 2;
                break;
            case "待处理":
                num = 1;
                break;
            default:
                num = 1;
                break;
        }
        this.hfBeginStep.Value = num.ToString();
        if (num > 6)
            this.ddlBackTo.Items.Add(new ListItem("审核关闭", "6"));
        string str3 = dataTable.Rows[0]["CancelReason"].ToString().Trim();
        if (num > 5 && str3.Equals(""))
            this.ddlBackTo.Items.Add(new ListItem("完工结算", "5"));
        if (num > 4 && str3.Equals("") && !str2.Equals(""))
            this.ddlBackTo.Items.Add(new ListItem("收货结算", "4"));
        if (num > 3 && str3.Equals("") && !str2.Equals(""))
            this.ddlBackTo.Items.Add(new ListItem("送修发货", "3"));
        if (num > 1)
            this.ddlBackTo.Items.Add(new ListItem("服务中心", "1"));
        if (this.ddlBackTo.Items.Count == 0)
            this.btnAdd.Enabled = false;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string strMsg = string.Empty;
        new DALServices().BackSteps(this.id, int.Parse((string)this.Session["Session_wtUserBID"]), int.Parse(this.hfBeginStep.Value), int.Parse(this.ddlBackTo.SelectedValue), FunLibrary.ChkInput(this.tbReason.Text), out strMsg);
        this.SysInfo("parent.CloseDialog('1');window.alert('" + strMsg + "');");
    }

    protected void SysInfo(string str)
    {
        ScriptManager.RegisterClientScriptBlock((Control)this.UpdatePanel1, this.UpdatePanel1.GetType(), "sysinfo", str, true);
    }
}
