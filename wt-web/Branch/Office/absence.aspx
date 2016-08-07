<%@ page language="C#"  CodeFile="absence.aspx.cs"     autoeventwireup="true" inherits="Branch_Office_Absence" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="main">
        <div class="maincon">
        <div id="sa" style="width:386px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
               <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                    <td align="right">班次：</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlType" runat="server" CssClass="pindl">
                            <asp:ListItem Value="上班">上班</asp:ListItem>
                            <asp:ListItem Value="下班">下班</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    
                </tr>
                <tr>
                    <td align="right">姓名：</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">密码：</td>
                    <td style="padding-left:0px;">
                    <asp:TextBox ID="tbPwd" runat="server" CssClass="pin" TextMode="Password"></asp:TextBox></td>
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
                <td>
                    <a href="#" onclick="parent.ShowDialog1(400, 180, 'Office/AbsencePwd.aspx', '考勤密码');" style="color:#0000ff">>>考勤密码</a>
                </td>
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="确定" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnAdd_Click"/>
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
var processtip=1;
function ChkSave()
{
    if($("ddlOperator").value=="-1")
    {
        window.alert("操作失败！请选择姓名");
        $("ddlOperator").focus();
        return false
    }
    if(isNull($("tbPwd").value))
    {
        window.alert("操作失败！考勤密码不能为空");
        $("tbPwd").focus();
        return false
    }
}

</script>
