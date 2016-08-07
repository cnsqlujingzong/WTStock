// Decompiled with JetBrains decompiler
// Type: Headquarters_Stock_StockrAdm
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
using wt.OtherLibrary;
using Wuqi.Webdiyer;

public partial class Headquarters_Stock_StockrAdm : Page, IRequiresSessionState
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
            if (!dalRight.GetRight(RightID, "ck_r6"))
            {
                this.Response.Redirect("~/Headquarters/Pur.aspx?p=6");
                this.Response.End();
            }
            if (dalRight.GetRight(RightID, "jc_r27"))
                this.hfPurCost.Value = "1";
            if (dalRight.GetRight(RightID, "jc_r28"))
                this.hfPurProv.Value = "1";
        }
        this.LoadClass();
        OtherFunction.BindBranch(this.ddlBranch);
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
        Headquarters_Stock_StockrAdm.BindTreeNode(treeNode, dt, treeNode.Value);
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
            Headquarters_Stock_StockrAdm.BindTreeNode(treeNode, dt, dataRow["ID"].ToString());
        }
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

    protected void btnClr_Click(object sender, EventArgs e)
    {
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
        if (!(this.hfRecID.Value != "-1"))
            return;
        this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
        this.GetStockDept();
    }

    protected void btnSch_Click(object sender, EventArgs e)
    {
        this.hfSch.Value = "0";
        this.hfRecID.Value = "-1";
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
    }

    protected void btnOrder_Click(object sender, EventArgs e)
    {
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
        if (this.hfOrder.Value != "ID")
            this.SysInfo("ClrHeaderOrder('" + this.hfOrderName.Value + "');");
        if (!(this.hfRecID.Value != "-1"))
            return;
        this.SysInfo("ChkID('" + this.hfRecID.Value + "');");
    }

    protected void LoadField()
    {
        int result = 0;
        int.TryParse((string)this.Session["Session_wtUserID"], out result);
        DataTable dataTable = new DALSys().GetLayoutDetail(1, 1, 3, 0, result).Tables[0];
        if (dataTable.Rows.Count <= 0)
            return;
        this.gvgds.Columns.Clear();
        BoundField boundField1 = new BoundField();
        boundField1.DataField = "ID";
        boundField1.HeaderText = "ID";
        this.gvgds.Columns.Add((DataControlField)boundField1);
        for (int index = 0; index < dataTable.Rows.Count; ++index)
        {
            BoundField boundField2 = new BoundField();
            boundField2.DataField = dataTable.Rows[index]["FieldName"].ToString();
            boundField2.HeaderText = dataTable.Rows[index]["TitleName"].ToString();
            if ((!(this.hfPurCost.Value == "1") || !(boundField2.DataField == "PriceCost")) && (!(this.hfPurProv.Value == "1") || !(boundField2.DataField == "Provider")))
            {
                this.ilayout = true;
                this.gvgds.Columns.Add((DataControlField)boundField2);
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
        this.gvgds.DataSource = (object)DALCommon.GetList_HL(1, "ck_stock", "", this.pageSize, this.jsPager.CurrentPageIndex, strCondition, fldSort, out count);
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
            string dataField = ((BoundField)this.gvgds.Columns[index]).DataField;
            string text = this.gvgds.HeaderRow.Cells[index].Text;
            this.gvgds.HeaderRow.Cells[index].Attributes.Add("id", dataField);
            this.gvgds.HeaderRow.Cells[index].Attributes.Add("onclick", "HeaderOrder('" + dataField + "','" + text + "');");
            this.gvgds.HeaderRow.Cells[index].Attributes.Add("onmouseover", "this.style.cursor='default';");
            if (dataField != "ID" && (this.ilayout || (!(this.hfPurCost.Value == "1") || !(dataField == "PriceCost")) && (!(this.hfPurProv.Value == "1") || !(dataField == "Provider"))))
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

    protected void jsPager_PageChanged(object sender, EventArgs e)
    {
        this.hfRecID.Value = "-1";
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
    }

    protected string strParm()
    {
        string str = " DeptID =" + this.ddlBranch.SelectedValue;
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
        if (this.cbzerostk.Checked)
            str += " and Stockr<>0 ";
        return str;
    }

    protected void gvgds_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        if (!this.ilayout)
        {
            if (this.hfPurCost.Value == "1")
                e.Row.Cells[10].Visible = false;
            if (this.hfPurProv.Value == "1")
                e.Row.Cells[19].Visible = false;
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "ChkID('" + e.Row.Cells[0].Text + "');");
            e.Row.Attributes.Add("ondblclick", "ShowGds();");
            e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
        }
        if (e.Row.RowType != DataControlRowType.Footer)
            return;
        this.lbPage.Text = "当前页:" + this.gvgds.Rows.Count.ToString();
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
        this.hfClass.Value = this.tvgds.SelectedNode.ToolTip;
        this.hfClassID.Value = this.tvgds.SelectedNode.Value;
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
    }

    protected void cbzerostk_CheckedChanged(object sender, EventArgs e)
    {
        this.hfRecID.Value = "-1";
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
    }

    protected void btnExcel_Click(object sender, EventArgs e)
    {
        DataTable dt = DALCommon.GetDataList("ck_stock", this.hfTbField.Value, this.hfSql.Value + " order by " + this.hfOrderName.Value + " " + this.hfOrder.Value).Tables[0];
        string[] TbTitle = this.hfTbTitle.Value.Split(',');
        string result = string.Empty;
        bool iFlag = false;
        DataToExcel.DataTableToExcel(dt, TbTitle, Guid.NewGuid().ToString() + ".xls", "废品库存", out iFlag, out result);
        if (iFlag)
            return;
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
        this.SysInfo("window.alert(\"" + result + "\");");
    }

    protected void ddlBranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.FillData(this.hfOrderName.Value, this.hfOrder.Value);
        this.hfRecID.Value = "-1";
    }

    protected void btnStockDept_Click(object sender, EventArgs e)
    {
        this.GetStockDept();
    }

    protected void GetStockDept()
    {
        string str = " and DeptID=" + this.ddlBranch.SelectedValue;
        if (this.cbzerostk.Checked)
            str += " and Stock<>0 ";
        this.GridView1.DataSource = (object)DALCommon.GetDataList("ck_stockdept", "", "bReject=1 and GoodsID=" + this.hfRecID.Value + str).Tables[0];
        this.GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[0].Visible = false;
        e.Row.Cells[0].Attributes.Add("style", "padding:auto 5px;");
        if (e.Row.RowType != DataControlRowType.DataRow)
            return;
        e.Row.Attributes.Add("id", "s" + e.Row.Cells[0].Text);
        e.Row.Attributes.Add("onclick", "ChkID2('s" + e.Row.Cells[0].Text + "');");
        e.Row.Attributes.Add("ondblclick", "ChkWarming();");
        e.Row.Attributes.Add("onmouseover", "this.style.cursor='default';");
        e.Row.Cells[2].Attributes.Add("style", "font-weight:bold;");
        double result1 = 0.0;
        double result2 = 0.0;
        double result3 = 0.0;
        double.TryParse(e.Row.Cells[2].Text, out result1);
        double.TryParse(e.Row.Cells[4].Text, out result2);
        double.TryParse(e.Row.Cells[5].Text, out result3);
        if (result1 < result2)
            e.Row.Attributes.Add("style", "color:#ff0000");
        else if (result1 > result3)
            e.Row.Attributes.Add("style", "color:#0000ff");
    }
}
