using Coding.Stock.Common;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CodingPages_Cd_Product_inputData : System.Web.UI.Page
{
    Coding.Stock.DAL.Cd_ProTypeAttr bll = new Coding.Stock.DAL.Cd_ProTypeAttr();
    Coding.Stock.DAL.Cd_productType bll2 = new Coding.Stock.DAL.Cd_productType();
    Coding.Stock.DAL.Cd_ProAtts bll3 = new Coding.Stock.DAL.Cd_ProAtts();
    DataTable proTypeAttr; string id;
    protected void Page_Load(object sender, EventArgs e)
    {
       id=  Request.QueryString["id"];
       proTypeAttr = bll.GetList(" ProTypeID=" + id).Tables[0];
       Repeater1.DataSource = proTypeAttr;
      Repeater1.DataBind();

      lb_protype.Text = bll2.GetModel(Convert.ToInt32(id)).TypeName + "   产品格式";
    }
    MemoryStream ms = new MemoryStream();
    byte[] buffer = new byte[4096];
    protected void Button1_Click(object sender, EventArgs e)
    {
        HttpPostedFile file = FileUpload1.PostedFile;
        if (string.IsNullOrEmpty(file.FileName))
        {
            MessageBox.Show(this,"请选择导入的文件");
            return;
        }
        string attName = file.FileName.Substring(file.FileName.IndexOf("."));
        if (attName.ToLower() != ".xls")
        {
            MessageBox.Show(this,"文件格式不正确，请选择Excel文件");
            return;
        }
        //string FileName = file.FileName.Substring(0, file.FileName.IndexOf("."));
        //string sname = string.Format("{0:yyyyMMddhhmmss}", DateTime.Now);
        //string vname = "../excel/" + FileName + sname + attName;
        //string rname = Server.MapPath("../excel/" + FileName + sname + attName);
        //file.SaveAs(rname);   

        try
        {
            //FileStream fs = new FileStream(rname, FileMode.Open, FileAccess.Read);          
            HSSFWorkbook wk = new HSSFWorkbook(file.InputStream);
            ISheet sheet = wk.GetSheetAt(0);
           
            //最后一列的标号
            int rowCount = sheet.LastRowNum;

            string atts = "ProTypeID";//proTypeAttr  bll3
            string valus = "";
            for (int y = 0; y < proTypeAttr.Rows.Count; y++)
            {
                atts += "," + proTypeAttr.Rows[y]["AttName"].ToString();
            }

            for (int i = 1; i < rowCount + 1; i++)
            {
                string v=sheet.GetRow(i).GetCell(0) == null ? "" : sheet.GetRow(i).GetCell(0).ToString().Trim();
                    if(!string.IsNullOrEmpty(id.ToString())&&!string.IsNullOrEmpty(v) )
                    {
                     bll3.Delete(" ProTypeID="+id +" and A100_1='"+v+"'");
                    }
                //ProTypeID
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into Cd_ProAtts(");
                strSql.Append(atts + ")");
                strSql.Append(" values ("+id);
                for (int o = 0; o < proTypeAttr.Rows.Count; o++)
			    {
			      valus += ",'" + (sheet.GetRow(i).GetCell(o) == null ? "" : sheet.GetRow(i).GetCell(o).ToString().Trim())+"'";
			    }
             
                strSql.Append(valus);
                strSql.Append(")");
                bll3.runSQL(strSql.ToString());
                valus = "";
            }
            //fs.Close();
            //fs.Dispose();
            wk.Close();
            MessageBox.ShowAndRedirect(this,"数据导入完成","ProductList.aspx?id="+id);

        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message);
            Literror.Text = "<h3>" + ex.Message + "</h3><br/>" + ex.StackTrace;
            Literror.DataBind();
        }





    }
}