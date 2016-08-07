<%@ page language="C#"  CodeFile="stocklocmod.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Stock_StockLocMod" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="main">
        <div class="maincon">
        <div id="sa" style="width:286px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                    <td>产品仓位：</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlStockLoc" runat="server" CssClass="pindl" Width="175" onchange="NewStockLoc('2');">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnStockLoc" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>
            </div>
            </div>
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
                    <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog<%=Str_F %>();"/>
                </td>
            </tr>
            </table>
         </div>
        </div>
        </div>
        <asp:HiddenField ID="hfStockLoc" runat="server" />
        <span style="display:none;">
            <asp:Button ID="btnStockLoc" runat="server" Text="StockLoc" OnClick="btnStockLoc_Click" /></span>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript">
function ChkAdd()
{
    if($("ddlStockLoc").value=="-1")
    {
        window.alert("操作失败！产品仓位不能为空");
        $("ddlStockLoc").focus();
        return false
    }
}
function ChkAdds(str)
{
    parent.iframeDialog.$("hfStockLoc").value=str;
    parent.iframeDialog.$("btnModStockLoc").click();
    parent.CloseDialog<%=Str_F %>();
}
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog<%=Str_F %>();}catch(e){}}}
</script>
