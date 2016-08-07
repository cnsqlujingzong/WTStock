using EF.DAL;
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

public partial class Headquarters_Customer_CusLinkManAdd : Page, IRequiresSessionState
{
	private string f;

	private string d;

	public string Str_F
	{
		get
		{
			return this.f;
		}
	}

	public string Str_D
	{
		get
		{
			return this.d;
		}
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		bool btel = false;
		if (base.Request.QueryString["itel"] != null)
		{
			btel = true;
		}
		FunLibrary.ChkHead(btel);
		this.f = base.Request["f"];
		if (this.f == "1")
		{
			this.d = "2";
		}
		else
		{
			this.d = "1";
		}
		if (!base.IsPostBack)
		{
			if (base.Request.QueryString["cid"] != null)
			{
				DataTable dataSource = DALCommon.GetList("CustomerDept", "[ID],_Name", " CustomerID=" + base.Request.QueryString["cid"]).Tables[0];
				this.ddlDept.DataSource = dataSource;
				this.ddlDept.DataTextField = "_Name";
				this.ddlDept.DataValueField = "ID";
				this.ddlDept.DataBind();
				this.ddlDept.Items.Insert(0, new ListItem("", ""));
			}
		}
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
        //form=xsdd
        string form = Request.QueryString["form"];
        string cid=Request.QueryString["cid"];
        if (form == "xsdd" || form == "xsd")
        {
            CustomerLinkManInfo model = new CustomerLinkManInfo();
            if (!string.IsNullOrEmpty(FunLibrary.ChkInput(this.tbName.Text)))
            {
                model.CustomerID=int.Parse(cid);
                model._Name = FunLibrary.ChkInput(this.tbName.Text);
                model.LinkManDept = FunLibrary.ChkInput(this.tbDept.Text);
                model.Sex =FunLibrary.ChkInput(this.tbSex.Value);
                model.Posit = FunLibrary.ChkInput(this.tbPosition.Value);
                model.tel_Office = FunLibrary.ChkInput(this.tbTel1.Text);
                model.tel_Home = FunLibrary.ChkInput(this.tbTel2.Text);
                model.tel_Mobile = FunLibrary.ChkInput(this.tbTel3.Text);
                model.Fax = FunLibrary.ChkInput(this.tbFax.Text);
                model.Tel_mobile1 = FunLibrary.ChkInput(this.tbmoblie.Text);
                model.Tel_mobile2 = FunLibrary.ChkInput(this.tbmoblie2.Text);
                model.Tel_qq = FunLibrary.ChkInput(this.tbQQ.Text);
                model.Tel_weixin = FunLibrary.ChkInput(this.tbWeixin.Text);
                if (!string.IsNullOrEmpty(this.tbBirthDay.Text))
                {

                    model.Birthday = FunLibrary.ChkInput(this.tbBirthDay.Text);
                }
                else {
                    model.Birthday = DateTime.Now.ToString("yyyy-MM-dd");
                }
                model.Email = FunLibrary.ChkInput(this.tbEmail.Text);
                model.Adr = FunLibrary.ChkInput(this.tbAdr.Text);
                model.Tel_padr= FunLibrary.ChkInput(this.tbprivateAdr.Text);
                model.Remark = FunLibrary.ChkInput(this.tbRemark.Text);
                CusLinkManDAL dal = new CusLinkManDAL();
               bool r= dal.Add(model);
               if (r)
               {
                   if (form == "xsdd")
                   {
       this.SysInfo("alert('添加成功');parent.parent.document.getElementById('Newxsdd_FCon').contentWindow.document.getElementById('btnCusInfo').click();");
          
                   }
                   if (form == "xsd")
                   {
                       this.SysInfo("alert('添加成功');parent.parent.document.getElementById('Newxskd_FCon').contentWindow.document.getElementById('btnCusInfo').click();");

                   }

                   ClearText();


                 }
               else {
                   this.SysInfo("alert('添加失败，请重试');");
               }
            }
            else
            {
             this.SysInfo("alert('联系人姓名不能为空');");

            }
          
         
        }
        else {
            if (this.tbName.Text.Trim() != string.Empty)
            {
                string text = string.Empty;
                text = FunLibrary.ChkInput(this.tbName.Text) + ",";
                text = text + FunLibrary.ChkInput(this.tbDept.Text) + ",";
                text = text + FunLibrary.ChkInput(this.tbSex.Value) + ",";
                text = text + FunLibrary.ChkInput(this.tbPosition.Value) + ",";
                text = text + FunLibrary.ChkInput(this.tbTel1.Text) + ",";
                text = text + FunLibrary.ChkInput(this.tbTel2.Text) + ",";
                text = text + FunLibrary.ChkInput(this.tbTel3.Text) + ",";
                text = text + FunLibrary.ChkInput(this.tbFax.Text) + ",";
                text = text + FunLibrary.ChkInput(this.tbBirthDay.Text) + ",";
                text = text + FunLibrary.ChkInput(this.tbEmail.Text) + ",";
                text = text + FunLibrary.ChkInput(this.tbAdr.Text) + ",";

                text += FunLibrary.ChkInput(this.tbRemark.Text) + ",";
                text = text + FunLibrary.ChkInput(this.tbmoblie.Text) + ",";
                text = text + FunLibrary.ChkInput(this.tbmoblie2.Text) + ",";
                text = text + FunLibrary.ChkInput(this.tbQQ.Text) + ",";
                text = text + FunLibrary.ChkInput(this.tbWeixin.Text) + ",";
                text = text + FunLibrary.ChkInput(this.tbprivateAdr.Text);
                this.SysInfo("ChkAdd('" + text + "');");
                if (!this.cbClose.Checked)
                {
                    this.ClearText();
                    this.SysInfo("$(\"tbName\").focus();");
                }
            }
		}
	}

	protected void ClearText()
	{
		this.tbBirthDay.Text = (this.tbDept.Text = (this.tbEmail.Text = (this.tbFax.Text = (this.tbName.Text = (this.tbPosition.Value = (this.tbRemark.Text = (this.tbSex.Value = (this.tbTel1.Text = (this.tbTel2.Text = (this.tbTel3.Text = string.Empty))))))))));
	}

	protected void SysInfo(string str)
	{
		ScriptManager.RegisterClientScriptBlock(this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
	}
}
