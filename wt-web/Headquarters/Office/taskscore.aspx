<%@ page language="C#"  CodeFile="taskscore.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Office_TaskScore" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sa" style="width:456px;">
    
        <div class="fdiv">
        <div class="sdiv">
            <table cellpadding="0" cellspacing="0" class="tb3">
            <tr>
                <td align="right" class="sysred">
                    完成率：
                </td>
                <td style="padding-left:0px;" colspan="3">
                    <asp:DropDownList ID="ddlCompleteRate" runat="server" CssClass="pindl">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem Value="10%">10%</asp:ListItem>
                        <asp:ListItem Value="20%">20%</asp:ListItem>
                        <asp:ListItem Value="30%">30%</asp:ListItem>
                        <asp:ListItem Value="40%">40%</asp:ListItem>
                        <asp:ListItem Value="50%">50%</asp:ListItem>
                        <asp:ListItem Value="60%">60%</asp:ListItem>
                        <asp:ListItem Value="70%">70%</asp:ListItem>
                        <asp:ListItem Value="80%">80%</asp:ListItem>
                        <asp:ListItem Value="90%">90%</asp:ListItem>
                        <asp:ListItem Value="100%">100%</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    执行情况：
                </td>
                <td style="padding-left:0px; height:84px;" colspan="3">
                    <asp:TextBox ID="tbexecuteRemark" runat="server" CssClass="pin" Width="341" Height="70" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
         </table>
        </div>
        </div>
    <div class="divh"></div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
        <div class="fdiv">
        <div class="sdiv">
            <table cellpadding="0" cellspacing="0" class="tb3">
            <tr>
                <td align="right">
                    任务评价：
                </td>
                <td style="padding-left:0px; height:84px;" colspan="3">
                    <asp:TextBox ID="tbScore" runat="server" CssClass="pin" Width="341" Height="70" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
         </table>
        </div>
        </div>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>
            <asp:Label ID="lbMod" runat="server"></asp:Label>
        </td>
        <td align="right">
            <asp:Button ID="btnAdd" runat="server" Text="确定" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnAdd_Click" />
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
<script language="javascript" type="text/javascript" src="../../Public/Script/detailslt.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/detail.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
var processtip=1;
function ChkSave()
{


}

</script>
