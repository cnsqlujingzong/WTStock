// Decompiled with JetBrains decompiler
// Type: Headquarters_Stock_GoodsAdm
// Assembly: wt.web, Version=0.0.0.0, Culture=neutral
// MVID: D3272D05-C02C-47E6-9FBF-767A521D8A35
// Assembly location: C:\Users\Administrator\Desktop\wt_itfiles\wt_itfiles\wt_files\bin\wt.web.dll

using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using wt.DAL;
using wt.Library;
using Wuqi.Webdiyer;

public partial class Headquarters_Stock_GoodsAdm : Page, IRequiresSessionState
{
    private int pageSize = 20;
    private bool ilayout = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        FunLibrary.ChkHead();
        if (this.IsPostBack)
            return;
        int RightID = int.Parse((string)this.Session["Session_wtPurID"]);
        if (RightID > 0)
        {
            DALRight dalRight = new DALRight();
            if (!dalRight.GetRight(RightID, "ck_r2"))
            {
                this.Response.Redirect("~/Headquarters/Pur.aspx?p=CK_View_Goods");
                this.Response.End();
            }
            if (!dalRight.GetRight(RightID, "ck_r4"))
                this.btnDel.Enabled = false;
            if (dalRight.GetRight(RightID, "jc_r27"))
                this.hfPurCost.Value = "1";
            if (dalRight.GetRight(RightID, "jc_r28"))
                this.hfPurProv.Value = "1";
            if (!dalRight.GetRight(RightID, "ck_r3"))
                this.btnInput.Visible = false;
            if (!dalRight.GetRight(RightID, "ck_r83"))
                this.btnExcel.Enabled = false;
        }
        this.LoadClass();
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
    }

    protected void LoadClass()
    {
        int count = 0;
        DataTable dt = DALCommon.GetList_HL(0, "GoodsClass", "", 0, 0, "Father=-1", " Array Asc", out count).Tables[0];
        this.tvgds.Nodes.Clear();
        TreeNode treeNode = new TreeNode();
        treeNode.Text = "全部(" + count.ToString() + ")";
        treeNode.Value = "-1";
        this.tvgds.Nodes.Add(treeNode);
        Headquarters_Stock_GoodsAdm.BindTreeNode(treeNode, dt, treeNode.Value);
        this.tvgds.Nodes[0].ChildNodes.Add(new TreeNode()
        {
            Value = "0",
            Text = "未分类"
        });
        this.tvgds.Nodes[0].Selected = true;
        this.tvgds.ExpandDepth = 1;
    }

    public static void BindTreeNode(TreeNode node, DataTable dt, string parentid)
    {
        foreach (DataRow dataRow in dt.Select(" Father=" + parentid))
        {
            TreeNode treeNode = new TreeNode();
            treeNode.Text = dataRow["_Name"].ToString();
            treeNode.Value = dataRow["ID"].ToString();
            treeNode.ToolTip = dataRow["_Level"].ToString();
            node.ChildNodes.Add(treeNode);
            Headquarters_Stock_GoodsAdm.BindTreeNode(treeNode, dt, dataRow["ID"].ToString());
        }
    }

    protected void btnClr_Click(object sender, EventArgs e)
    {
        this.hfcbID.Value = "";
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
        if (!(this.hfRecID.Value != "-1"))
            return;
        this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
    }

    protected void btnSch_Click(object sender, EventArgs e)
    {
        this.hfcbID.Value = "";
        this.hfSch.Value = "0";
        this.hfRecID.Value = "-1";
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
    }

    protected void btnOrder_Click(object sender, EventArgs e)
    {
        this.hfcbID.Value = "";
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
        if (this.hfOrder.Value != "ID")
            this.SysInfo("ClrHeaderOrder('" + this.hfOrderName.Value + "');");
        if (!(this.hfRecID.Value != "-1"))
            return;
        this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
    }

    protected void btnFsh_Click(object sender, EventArgs e)
    {
        this.hfcbID.Value = "";
        this.hfSch.Value = "-1";
        this.hfRecID.Value = "-1";
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
    }

    protected void LoadField()
    {
        int result = 0;
        int.TryParse((string)this.Session["Session_wtUserID"], out result);
        DataTable dataTable = new DALSys().GetLayoutDetail(1, 1, 1, 0, result).Tables[0];
        if (dataTable.Rows.Count <= 0)
            return;
        this.gvgds.Columns.Clear();
        BoundField boundField1 = new BoundField();
        boundField1.DataField = "ID";
        boundField1.HeaderText = "ID";
        this.gvgds.Columns.Add((DataControlField)boundField1);
        BoundField boundField2 = new BoundField();
        boundField2.DataField = "bStop";
        boundField2.HeaderText = "Flag";
        this.gvgds.Columns.Add((DataControlField)boundField2);
        TemplateField templateField = new TemplateField();
        templateField.HeaderText = "<input id=\"cball\" type=\"checkbox\" class=\"cb1\" onclick=\"SltAllValue();\" title=\"全选/取消全选\"/>";
        templateField.ItemTemplate = (ITemplate)new MyTemplatexgdsa("", DataControlRowType.DataRow);
        this.gvgds.Columns.Add((DataControlField)templateField);
        for (int index = 0; index < dataTable.Rows.Count; ++index)
        {
            BoundField boundField3 = new BoundField();
            boundField3.DataField = dataTable.Rows[index]["FieldName"].ToString();
            boundField3.HeaderText = dataTable.Rows[index]["TitleName"].ToString();
            if ((!(this.hfPurCost.Value == "1") || !(boundField3.DataField == "PriceCost")) && (!(this.hfPurProv.Value == "1") || !(boundField3.DataField == "Provider")))
            {
                this.ilayout = true;
                this.gvgds.Columns.Add((DataControlField)boundField3);
            }
        }
    }

    protected void FillData(string sortExpression, string direction)
    {
        this.LoadField();
        int count = 0;
        string strCondition = this.strParm();
        string fldSort = sortExpression + " " + direction;
        this.hfSql.Value = strCondition;
        this.gvgds.DataSource = (object)DALCommon.GetList_HL(1, "ck_goods", "", this.pageSize, this.jsPager.CurrentPageIndex, strCondition, fldSort, out count);
        this.gvgds.DataBind();
        this.lbCount.Text = count.ToString();
        if (this.lbCount.Text == "0")
        {
            this.lbCount.Visible = false;
            this.lbPage.Visible = false;
            this.lbCountText.Visible = false;
        }
        else
        {
            this.lbCount.Visible = true;
            this.lbPage.Visible = true;
            this.lbCountText.Visible = true;
        }
        this.jsPager.PageSize = this.pageSize;
        this.jsPager.RecordCount = count;
        this.hfTbTitle.Value = this.hfTbField.Value = string.Empty;
        if (this.gvgds.Rows.Count <= 0)
            return;
        for (int index = 0; index < this.gvgds.HeaderRow.Cells.Count; ++index)
        {
            if (index > 2)
            {
                string dataField = ((BoundField)this.gvgds.Columns[index]).DataField;
                string text = this.gvgds.HeaderRow.Cells[index].Text;
                this.gvgds.HeaderRow.Cells[index].Attributes.Add("id", dataField);
                this.gvgds.HeaderRow.Cells[index].Attributes.Add("onclick", "HeaderOrder('" + dataField + "','" + text + "');");
                this.gvgds.HeaderRow.Cells[index].Attributes.Add("onmouseover", "this.style.cursor='default';");
                if (this.ilayout || (!(this.hfPurCost.Value == "1") || !(dataField == "PriceCost")) && (!(this.hfPurProv.Value == "1") || !(dataField == "Provider")))
                {
                    if (this.hfTbTitle.Value == string.Empty)
                    {
                        this.hfTbTitle.Value = text;
                    }
                    else
                    {
                        HiddenField hiddenField = this.hfTbTitle;
                        string str = hiddenField.Value + "," + text;
                        hiddenField.Value = str;
                    }
                    if (this.hfTbField.Value == string.Empty)
                    {
                        this.hfTbField.Value = dataField;
                    }
                    else
                    {
                        HiddenField hiddenField = this.hfTbField;
                        string str = hiddenField.Value + "," + dataField;
                        hiddenField.Value = str;
                    }
                }
            }
        }
    }

    protected void jsPager_PageChanged(object sender, EventArgs e)
    {
        this.hfRecID.Value = "-1";
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
    }

    protected string strParm()
    {
        string str = " 1=1 ";
        string strcon = FunLibrary.ChkInput(this.tbCon.Text);
        if (this.hfClass.Value != string.Empty && this.hfClass.Value != "-1")
            str = !(this.hfClass.Value == "0") ? str + " and _Level like '" + this.hfClass.Value + "%'" : str + " and ClassID is null ";
        else if (this.hfClassID.Value == "-2")
            str += " and ClassID is null ";
        if (this.hfSch.Value == "0" && this.ddlKey.SelectedValue != "-1")
        {
            int result = 0;
            int.TryParse(this.ddlKey.SelectedValue, out result);
            if (strcon != "")
            {
                DALGoods dalGoods = new DALGoods();
                str += dalGoods.GetSchWhere(result, strcon);
            }
        }
        return str;
    }

    protected void gvgds_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = e.Row.Cells[1].Visible = false;
        if (!this.ilayout)
        {
            if (this.hfPurCost.Value == "1")
                e.Row.Cells[9].Visible = false;
            if (this.hfPurProv.Value == "1")
                e.Row.Cells[19].Visible = false;
        }
        string[] strArray = this.hfcbID.Value.Split(',');
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "','" + e.Row.Cells[4].Text + "');");
            e.Row.Attributes.Add("ondblclick", "ModClick();");
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
            e.Row.Cells[2].Attributes.Add("style", "width:20px;padding-right:5px;");
            if (e.Row.Cells[1].Text == "√")
                e.Row.Attributes.Add("style", "color:#999;");
            e.Row.Cells[2].Text = "<input id=\"cb" + e.Row.Cells[0].Text + "\" type=\"checkbox\" onclick=\"SltValue('" + e.Row.Cells[0].Text + "',this);\"/>";
            for (int index = 0; index < strArray.Length; ++index)
            {
                if (strArray[index].ToString() == e.Row.Cells[0].Text)
                {
                    e.Row.Cells[2].Text = "<input id=\"cb" + e.Row.Cells[0].Text + "\" type=\"checkbox\" checked=\"checked\" onclick=\"SltValue('" + e.Row.Cells[0].Text + "',this);\"/>";
                    break;
                }
            }
        }
        if (e.Row.RowType != DataControlRowType.Footer)
            return;
        this.lbPage.Text = "当前页:" + this.gvgds.Rows.Count.ToString();
    }

    protected void btnDel_Click(object sender, EventArgs e)
    {
        string str = this.hfcbID.Value;
        if (str == "")
            str = this.hfRecID.Value;
        int num1 = 0;
        int num2 = 0;
        string strMsg = string.Empty;
        string[] strArray = str.Split(',');
        int result = 0;
        for (int index = 0; index < strArray.Length; ++index)
        {
            int.TryParse(strArray[index].ToString(), out result);
            if (result != 0)
            {
                if (DALCommon.DeteleData(3, 0, result, out strMsg) == 0)
                    ++num2;
                else
                    ++num1;
            }
        }
        if (num1 > 0)
        {
            if (num2 == 0)
                this.SysInfo("window.alert('操作失败！" + num1.ToString() + "条产品信息" + strMsg + "');");
            else
                this.SysInfo("window.alert('" + num2.ToString() + "条产品信息已删除；" + num1.ToString() + "条产品信息删除失败');");
        }
        this.hfRecID.Value = "-1";
        this.hfcbID.Value = "";
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
    }

    protected void SysInfo(string str)
    {
        ScriptManager.RegisterClientScriptBlock((Control)this.UpdatePanel1, this.UpdatePanel1.GetType(), "SysInfo", str, true);
    }

    protected void tvgds_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.tvgds.SelectedNode.Expanded = new bool?(true);
        this.hfSch.Value = "-1";
        this.hfRecID.Value = "-1";
        this.hfClass.Value = this.tvgds.SelectedNode.ToolTip.ToString();
        this.hfClassID.Value = this.tvgds.SelectedNode.Value;
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
    }

    protected void tvgds_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
    {
        if (e.Node.ChildNodes.Count == 0)
            return;
        this.AddChild(e.Node, e.Node.Value);
    }

    protected void AddChilds(TreeNode node)
    {
        node.ChildNodes.Add(new TreeNode()
        {
            Text = "1",
            Value = "1",
            ToolTip = "1"
        });
    }

    protected void AddChild(TreeNode node, string strID)
    {
        if (strID != "")
        {
            DataTable dataTable = DALCommon.GetList("GoodsClass", "[ID],_Name,_Level,Father", "Father= " + strID + " order by Array Asc").Tables[0];
            if (!dataTable.Rows.Count.Equals(0))
            {
                node.ChildNodes.Clear();
                for (int index = 0; index < dataTable.Rows.Count; ++index)
                {
                    TreeNode treeNode = new TreeNode();
                    treeNode.Text = dataTable.Rows[index]["_Name"].ToString();
                    treeNode.Value = dataTable.Rows[index]["ID"].ToString();
                    treeNode.ToolTip = dataTable.Rows[index]["_Level"].ToString();
                    node.ChildNodes.Add(treeNode);
                    if (!DALCommon.GetList("GoodsClass", "1", " Father=" + dataTable.Rows[index]["ID"].ToString()).Tables[0].Rows.Count.Equals(0))
                        this.AddChilds(treeNode);
                }
            }
        }
        if (node.Depth != 0)
            return;
        this.tvgds.Nodes[0].ChildNodes.Add(new TreeNode()
        {
            Value = "-2",
            Text = "未分类"
        });
        this.tvgds.Nodes[0].Selected = true;
    }

    protected void btnExcel_Click(object sender, EventArgs e)
    {
        DataTable dt = DALCommon.GetDataList("ck_goods", this.hfTbField.Value, this.hfSql.Value + " order by " + this.hfOrderName.Value + " " + this.hfOrder.Value).Tables[0];
        string[] TbTitle = this.hfTbTitle.Value.Split(',');
        string result = string.Empty;
        bool iFlag = false;
        DataToExcel.DataTableToExcel(dt, TbTitle, Guid.NewGuid().ToString() + ".xls", "产品目录", out iFlag, out result);
        if (iFlag)
            return;
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
        this.SysInfo("window.alert(\"" + result + "\");");
    }
    Coding.Stock.DAL.Cd_ProAtts dal = new Coding.Stock.DAL.Cd_ProAtts();
    Coding.Stock.DAL.Cd_ProTypeAttr tdal = new Coding.Stock.DAL.Cd_ProTypeAttr();
    protected void btn_getdetail_Click(object sender, EventArgs e)
    {
        string id = hid_pid.Value;
        if (!string.IsNullOrEmpty(id))
        {

            Coding.Stock.Model.Cd_ProAtts m = dal.GetModel(" A100_1='" + id + "' ");
            if (m != null)
            {
                DataTable tdt = tdal.GetList(" proTypeID=" + m.ProTypeID).Tables[0];
                if (tdt.Rows.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(" select top 1 ID ");
                    for (int i = 0; i < tdt.Rows.Count; i++)
                    {
                        sb.Append("," + tdt.Rows[i]["AttName"].ToString() + " as '" + tdt.Rows[i]["DisplayAttrName"].ToString() + "' ");
                    }
                    sb.Append(" from Cd_ProAtts where A100_1='" + id + "'");
                    DataTable dt=dal.GetListBysql(sb.ToString()).Tables[0];
                    GridView1.DataSource = dt;
                    //GridView1.FooterRow=new TableFooterRow                 
                    GridView1.DataBind();
                    lit_pdetail.Text = "<a href='/CodingPages/online/Prores.aspx?id=" + dt.Rows[0]["ID"].ToString() + "&&pn=" + dt.Rows[0][1].ToString() + "' target='_blank' style='color:blue'><h4>&nbsp;&nbsp;&nbsp;查看图片&文档=></h4></a>&nbsp;&nbsp;";
                }
                else {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }
            else {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }
        else {
            GridView1.DataSource =null;
            GridView1.DataBind();
        }
    }

}
