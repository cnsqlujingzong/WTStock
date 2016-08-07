<%@ page language="C#"  CodeFile="devbackbat.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Lease_DevBackBat" theme="Themes" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:604px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <div class="fdivs">
        <div class="sdivs" style="width:600px; height:255px; overflow:auto; background:#ffffff;">
        <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvdata_RowDataBound" OnRowDeleting="gvdata_RowDeleting">
            <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="StockID" DataField="StockID" />
            <asp:BoundField HeaderText="入库设备" DataField="GoodsNO" />
            <asp:TemplateField HeaderText="删除">
                <ItemTemplate>
                    <asp:LinkButton ID="lbDel" TabIndex="-1" runat="server" CausesValidation="False"  CommandName="Delete" Text="删除" style="color:#0000ff;"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="入库仓库">
            <ItemTemplate>
                <asp:DropDownList ID="ddlStock" runat="server"  CssClass="pindl">
                </asp:DropDownList>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="入库金额">
            <ItemTemplate>
                <asp:TextBox ID="tbMoney" runat="server" Text='<%# Eval("InMoney") %>' CssClass="tbstyle" oldNum='<%# Eval("InMoney") %>' onfocus="select();"></asp:TextBox>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="入库数量">
            <ItemTemplate>
                <asp:TextBox ID="tbInCount" runat="server" Text='<%# Eval("InCount") %>' CssClass="tbstyle" oldNum='<%# Eval("InCount") %>' onfocus="select();"></asp:TextBox>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="机器编号" DataField="DeviceNO" />
            <asp:BoundField HeaderText="序列号1" DataField="ProductSN1" />
            </Columns>
        </asp:GridView>
        </div>
        </div>
        </ContentTemplate>
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSltIDs" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <div class="divh"></div>
        <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="left">
                <asp:Button ID="btnClear" runat="server" Text="清空" OnClick="btnClear_Click" CssClass="bt1" />
                <input id="btnSlt" type="button" value="选择机器" class="bt1" onclick="sltDev()"/>
                <span style="display:none;">
                    <asp:Button ID="btnSltIDs" runat="server" Text="选中机器" OnClick="btnSltIDs_Click" CssClass="bt1" />
                    <asp:HiddenField ID="hfidlist" runat="server" />
                </span>
            </td>
            <td align="right">
                <asp:Button ID="btnAdd" runat="server" Text="确定" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
                <input id="btnCls" type="button" value="取消" class="bt1" onclick="parent.CloseDialog();"/>
            </td>
        </tr>
        </table>
    </div>
    </div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/detailslt.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/detail.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
function ChkAdd()
{
    var ddls=document.getElementsByTagName("select");
    for(i=0;i<ddls.length;i++)
    {
        if(ddls[i].value=="-1")
        {
            ddls[i].focus();
            alert("请选择入库仓库！");
            return false;
        }
    }
    var txts=document.getElementsByTagName("input");
    for(i=0;i<txts.length;i++)
    {
        if(txts[i].type=="text"&&!(/^\d+(\.\d+)?$/).test(txts[i].value))
        {
            txts[i].focus();
            alert("请输入数字！");
            return false;
        }
    }
    
    return true;
}
function sltDev()
{
    var ids="";
    var tbgv=$("gvdata");
    if(tbgv)
    for(i=1;i<tbgv.rows.length;i++)
    {
        ids+=tbgv.rows[i].cells[0].innerHTML+",";
    }
    ids=ids.replace(/(^,*)|(,*$)/g,"");
    parent.ShowDialog1(477,410,'Lease/SltDev.aspx?id=<%=ID %>&ids='+ids,'选择机器');
}
</script>
