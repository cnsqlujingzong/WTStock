<%@ page language="C#"  CodeFile="unitadd.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Stock_UnitAdd" enableEventValidation="false" %>
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
        <div id="sa" style="width:466px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
               <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                    <td align="right">单位名称：</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlUnit" runat="server" onchange="NewUnit('2');" CssClass="pindl">
                        </asp:DropDownList>
                    </td>
                    <td align="right">单位关系：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbRel" runat="server" CssClass="pin" onblur="ValidateUnitR(this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">条码：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbBarCode" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td align="right">零售价：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbPriceDetail" runat="server" CssClass="pin" old="" onblur="ChkMoney(this);"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">进货价：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbPriceCost" runat="server" CssClass="pin" old="" onblur="ChkMoney(this);"></asp:TextBox></td>
                    <td align="right">内部价：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbPriceInner" runat="server" CssClass="pin" old="" onblur="ChkMoney(this);"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">旧货价：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbPriceWho1" runat="server" CssClass="pin" old="" onblur="ChkMoney(this);"></asp:TextBox></td>
                    <td align="right">替代价：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbPriceWho2" runat="server" CssClass="pin" old="" onblur="ChkMoney(this);"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">列表价：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbPriceWho3" runat="server" CssClass="pin" old="" onblur="ChkMoney(this);"></asp:TextBox>
                    </td>
                    <td align="right"></td>
                    <td>
                        <asp:HiddenField ID="hfUnit" runat="server" />
                        <span style="display:none;">
                            <asp:Button ID="btnRefUnit" runat="server" Text="RefUnit" OnClick="btnRefUnit_Click" />
                        </span>
                    </td>
                </tr>
            </table>
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>
            </div>
            </div>
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="padding-left:5px;color:#0000ff">
                    <asp:CheckBox ID="cbClose" runat="server" Text="保存后关闭窗口" Checked="true" /></td>
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnAdd_Click"/>
                    <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog1();"/>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
var processtip=1;
function ChkSave()
{
    if($("ddlUnit").value=="-1")
    {
        window.alert("操作失败!单位名称不能为空");
        $("ddlUnit").focus();
        return false
    }
    
    if(isNull($("tbRel").value))
    {
        window.alert("操作失败!单位关系不能为空");
        $("tbRel").focus();
        return false
    }
}

function ChkAdd(str)
{
    parent.iframeDialog.$("hfMUnit").value=str;
    parent.iframeDialog.$("btnAddUnit").click();
    
    if($("cbClose").checked)
        parent.CloseDialog1();
}
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog1();}catch(e){}}}
</script>
