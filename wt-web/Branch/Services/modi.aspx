<%@ page language="C#"  CodeFile="modi.aspx.cs"     autoeventwireup="true" inherits="Branch_Services_ModI" enableEventValidation="false" %>
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
                        <td align="right">项目编号：</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbItemNO" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td align="right">名称：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbName" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">金额：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbPrice" runat="server" CssClass="pin" onblur="ValidateMoney1();"></asp:TextBox></td>
                        <td align="right">工时：</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbdPoint" runat="server" CssClass="pin" onblur="ValidateMoney2();"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">提成：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbDed" runat="server" CssClass="pin" onblur="ValidateMoney3();"></asp:TextBox></td>
                        <td align="right" style="display:none;">技术员：</td>
                        <td style="padding-left:0px;display:none;"><asp:TextBox ID="tbDisposal" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td style="padding:0px;display:none;"><input id="btnSltStaff" type="button" value="" onclick="SltTec();" class="bview"/></td>
                    </tr>
                    <tr>
                        <td align="right">结算方式：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlChargeStyle" runat="server" CssClass="pindl">
                                <asp:ListItem Value="客付">客付</asp:ListItem>
                                <asp:ListItem Value="厂付">厂付</asp:ListItem>
                                <asp:ListItem Value="免费">免费</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right">是否完工：</td>
                        <td style="padding-left:0px;">
                            <asp:CheckBox ID="cbbComplete" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">备注：</td>
                        <td style="padding-left:0px;" colspan="4"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="341"></asp:TextBox></td>
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
                    <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnAdd_Click"/>
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
var isfocus=1;
var processtip=1;

//检查输入
function ValidateMoney1()
{
    if(!isMoney($("tbPrice").value))
    {
        window.alert("输入格式不正确！请重新输入");
        $("tbPrice").select();
        return false;
    }
}

function ValidateMoney2()
{
    if(!isMoney($("tbdPoint").value))
    {
        window.alert("输入格式不正确！请重新输入");
        $("tbdPoint").select();
        return false;
    }
}

function ValidateMoney3()
{
    if(!isMoney($("tbDed").value))
    {
        window.alert("输入格式不正确！请重新输入");
        $("tbDed").select();
        return false;
    }
}

function SltTec()
{
    parent.ShowDialog1(400, 510, 'Services/SltTec.aspx?f=1', '技术员');
}
</script>
