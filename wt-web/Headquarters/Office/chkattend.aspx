<%@ page language="C#"  CodeFile="chkattend.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Office_ChkAttend" enableEventValidation="false" %>
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
        <div id="sa" style="width:436px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
               <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                    <td align="right">类别：</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlType" runat="server" CssClass="pindl" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td align="right">扣款金额：</td>
                    <td style="padding-left:0px;">
                    <asp:TextBox ID="tbMoney" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">备注：</td>
                    <td style="padding-left:0px;" colspan="3"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="341"></asp:TextBox></td>
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
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnAdd_Click"/>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
function ChkSave()
{
    if(isNull($("ddlType").value))
    {
        window.alert("操作失败！类别不能为空");
        $("ddlType").focus();
        return false
    }
    if(isNull($("tbMoney").value))
    {
        window.alert("操作失败！扣款金额不能为空");
        $("tbMoney").focus();
        return false
    }
}

</script>
