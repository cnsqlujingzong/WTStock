<%@ page language="C#"  CodeFile="sltdev.aspx.cs"     autoeventwireup="true" inherits="Branch_Lease_sltDev" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>选择机器</title>
<link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/frame.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/page.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/tab.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div class="ftool">
    <div class="ftoolleft">
            <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
                <tr>
                <td>
                   <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="0">模糊查询</asp:ListItem>
                    <asp:ListItem Value="6">按入库设备查询</asp:ListItem>
                    <asp:ListItem Value="1">按机器编号查询</asp:ListItem>
                    <asp:ListItem Value="2">按品牌查询</asp:ListItem>
                    <asp:ListItem Value="3">按类别查询</asp:ListItem>
                    <asp:ListItem Value="4">按型号查询</asp:ListItem>
                    <asp:ListItem Value="5">按序列号1查询</asp:ListItem>
                    <asp:ListItem Value="-1">查询全部</asp:ListItem>
                </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="tbCon" runat="server" onkeydown="EnterTextBoxSch(event, this);" CssClass="pink" ToolTip="输入查询关键字"></asp:TextBox>
                </td><td align="left">
                    <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" />
                    </td>
                <td align="right">
                    <input type="button" value="确定" onclick="AddDev();" class="bt1" />
                </td>
                 </tr>
            </table>   
    </div>
    </div>
    <div id="cndiv" style="height:370px; width:478px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false">
        <Columns>
        <asp:BoundField HeaderText="ID" DataField="ID" />
        <asp:BoundField HeaderText="BillID" DataField="BillID" />
            <asp:TemplateField>
                <ItemTemplate>
                    <input id="cb<%#Eval("ID") %>" type="checkbox" class="cb1" onclick="cbone(this);"/>
                </ItemTemplate>
                <HeaderTemplate>
                    <input id="cball" type="checkbox" class="cb1" onclick="allcb();" title="全选/取消全选"/>
                </HeaderTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="入库设备" DataField="GoodsNO" />
            <asp:BoundField HeaderText="机器编号" DataField="DeviceNO" />
            <asp:BoundField HeaderText="品牌" DataField="Brand" />
            <asp:BoundField HeaderText="类别" DataField="Class" />
            <asp:BoundField HeaderText="型号" DataField="Model" />
            <asp:BoundField HeaderText="机器编号" DataField="DeviceNO" />
            <asp:BoundField HeaderText="序列号1" DataField="ProductSN1" />
            <asp:BoundField HeaderText="序列号2" DataField="ProductSN2" />
            <asp:BoundField HeaderText="备注" DataField="Remark" />
        </Columns>
    </asp:GridView>
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
        <asp:HiddenField ID="hfIDList" runat="server" Value="-1" />
        <asp:HiddenField ID="hfreclist" runat="server" Value="-1" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
function AddDev()
{ 
    var tbgv=$("gvdata");
    var idlist="";
    if(tbgv)
    {
        for(i=1;i<tbgv.rows.length;i++)
        {
            var rid=tbgv.rows[i].id;
            if($("cb"+rid)&&$("cb"+rid).checked==true)
            idlist+=rid+",";
        }
    }
    idlist=idlist.replace(/(^[,\s]*)|([,\s]*$)/g,"");
    parent.iframeDialog.$("hfidlist").value=idlist;
    parent.iframeDialog.$("btnSltIDs").click();
    parent.CloseDialog1();
}
</script>
