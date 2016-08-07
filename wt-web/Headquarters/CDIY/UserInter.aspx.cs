using Coding.Stock.Model;
using System;
using System.Web.UI.WebControls;
public partial class Headquarters_CDIY_UserInter : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private bool SavaInter(string type) 
    {
        string uid = ddl_user.SelectedValue;
        string qty = tb_qty.Text.Trim();
        Cd_UserInt m=new Cd_UserInt ();     
        m.Datetime = DateTime.Now;
        m.IntQty = Convert.ToDecimal(qty);        
        m.UserID = Convert.ToInt32(uid);
        m.IntType = type;
        Coding.Stock.DAL.Cd_UserInt dal = new Coding.Stock.DAL.Cd_UserInt();
       return  dal.Add(m);       
    }
    protected void btn_xin_Click(object sender, EventArgs e)
    {
        SavaInter("xin");    //心
        GridView1.DataBind();
    }
    protected void btn_shouOK_Click(object sender, EventArgs e)
    {
        SavaInter("ok");    //手OK
        GridView1.DataBind();
    }
    protected void btn_shouHao_Click(object sender, EventArgs e)
    {
        SavaInter("good");    //手好
        GridView1.DataBind();
    }
    protected void btn_you_Click(object sender, EventArgs e)
    {
        SavaInter("you");    //优
        GridView1.DataBind();
    }
    protected void btn_qiHao_Click(object sender, EventArgs e)
    {
        SavaInter("qgood");    //旗好
        GridView1.DataBind();
    }
    protected void btn_xingxing_Click(object sender, EventArgs e)
    {
        SavaInter("xing");    //星星
        GridView1.DataBind();
    }
    protected void btn_hua_Click(object sender, EventArgs e)
    {
        SavaInter("hua");    //花
        GridView1.DataBind();
    }
    protected void btn_xiaolian_Click(object sender, EventArgs e)
    {
        SavaInter("xiao");    //笑脸
        GridView1.DataBind();
    }
    protected void GridView1_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton btnDelete = (LinkButton)e.Row.FindControl("LinkButton2");
            btnDelete.Attributes.Add("onclick", "javascript:return confirm('你确认要删除吗?')");
            switch (e.Row.Cells[1].Text)
            {
                case "xin":
                    e.Row.Cells[1].Text = "心";
                    break;
                case "ok":
                    e.Row.Cells[1].Text = "手OK";
                    break;
                case "good":
                    e.Row.Cells[1].Text = "手好";
                    break;
                case "you":
                    e.Row.Cells[1].Text = "优";
                    break;
                case "qgood":
                    e.Row.Cells[1].Text = "旗好";
                    break;
                case "xing":
                    e.Row.Cells[1].Text = "星星";
                    break;
                case "hua":
                    e.Row.Cells[1].Text = "花";
                    break;
                case "xiao":
                    e.Row.Cells[1].Text = "笑脸";
                    break;
            }
            
        }
    }
}