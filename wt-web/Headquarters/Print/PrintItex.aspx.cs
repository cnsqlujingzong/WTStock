using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Headquarters_Print_PrintItex : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        /**
                    <asp:ListItem Value="sthx">盛唐和讯公章</asp:ListItem>
                    <asp:ListItem Value="fc">凡驰传动公章</asp:ListItem>
                    <asp:ListItem Value="fcht">凡驰传动合同章</asp:ListItem>
                    <asp:ListItem Value="mfy">美褔洋公章</asp:ListItem>
                    <asp:ListItem Value="mfyht">美褔洋合同章</asp:ListItem>
         * **/
        //xsdd
       string oid= Request.QueryString["oid"];
       string type = Request.QueryString["ptype"];
     //  string ztype = dl_tuzhang.SelectedValue;
       PrintDoc p = new PrintDoc();
       MemoryStream stream=new MemoryStream ();
       string filename = "打印";
        if(type=="xsdd")
        {
            string s = "销售订单";
            stream = p.PrintXSDD(oid,out s);
            filename = s+".pdf";
        }else
            if (type == "xsdd2")
            {
                string s = "销售合同";
                stream = p.PrintXSDD2(oid, out s);
                filename = s + ".pdf";
            }
            if (type == "xsd")
            {
                string s = "销售合同";
                stream = p.PrintXSD(oid,out s);
                filename = s+".pdf";
            }else
                if (type == "plht")
                {
                    stream = p.PrintPLHT(oid);
                    filename = "批量合同.pdf";
                }
                else
                    if (type == "wxbj")
                    {
                        stream = p.PrintFWBJ(oid);
                        filename = "维修报价.pdf";
                    }
                    else
                        if (type == "wxht")
                        {
                            stream = p.PrintPLHT(oid);
                            filename = "维修合同.pdf";
                        }
                        else
                            if (type == "wxbg")
                            {
                                stream = p.PrintPLHT(oid);
                                filename = "维修报告.pdf";
                            }
       var response = this.Context.Response;
       response.Clear();
       response.Cache.SetCacheability(HttpCacheability.NoCache);
       response.ContentType = "application/octet-stream";
       response.AddHeader("Content-Disposition", "attachment;   filename=" + HttpUtility.HtmlEncode(filename));
       stream.WriteTo(response.OutputStream);
       stream.Dispose();
    }
}