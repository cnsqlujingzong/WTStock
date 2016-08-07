<%@ page language="C#"  CodeFile="warningmod.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Stock_WarningMod" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body onload="ChkSetFocus('tbDownwarning');">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="main">
        <div class="maincon">
        <div id="sa" style="width:466px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                        <td align="right" class="red">仓库：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbStockName" runat="server" CssClass="pinb"></asp:TextBox></td>
                        <td align="right">编号：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbGoodsNO" runat="server" CssClass="pinb"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">名称：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbName" runat="server" CssClass="pinb"></asp:TextBox></td>
                        <td align="right" class="sysred">库存：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbStock" runat="server" CssClass="pinb"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>成本均价：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbCost" runat="server" CssClass="pinb"></asp:TextBox></td>
                        <td align="right" class="sysred">仓位：</td>
                        <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlStockLoc" runat="server" CssClass="pindl" onchange="NewStockLoc('1');">
                        </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>警戒下限：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbDownwarning" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td>警戒上限：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbUpwarning" runat="server" CssClass="pin"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">备注：</td>
                        <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="341"></asp:TextBox></td>
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
                <td>
                    <asp:Label ID="lbMod" runat="server"></asp:Label>
                    <asp:HiddenField ID="hfStockLoc" runat="server" />
                    <span style="display:none;">
                        <asp:Button ID="btnStockLoc" runat="server" Text="StockLoc" OnClick="btnStockLoc_Click" /></span>
                </td>
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
                    <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog();"/>
                </td>
            </tr>
            </table>
         </div>
        </div>
        </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
function ChkAdd()
{
    if(!isNull($("tbDownwarning").value))
    {
        if(!isMoney($("tbDownwarning").value))
        {
            window.alert("操作失败！警戒下限格式不正确");
            $("tbDownwarning").focus();
            return false
        }
    }
    
    if(!isNull($("tbUpwarning").value))
    {
        if(!isMoney($("tbUpwarning").value))
        {
            window.alert("操作失败！警戒上限格式不正确");
            $("tbUpwarning").focus();
            return false
        }
    }
}
</script>
