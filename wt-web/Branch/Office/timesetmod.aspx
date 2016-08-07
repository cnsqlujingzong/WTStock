<%@ page language="C#"  CodeFile="timesetmod.aspx.cs"     autoeventwireup="true" inherits="Branch_Office_TimeSetMod" enableEventValidation="false" %>
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
        <div id="sa" style="width:456px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
               <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                    <td align="right">星期：</td>
                    <td style="padding-left:0px;" colspan="2">
                        <asp:DropDownList ID="ddlWeek" runat="server" CssClass="pindl">
                            <asp:ListItem Value="星期一">星期一</asp:ListItem>
                            <asp:ListItem Value="星期二">星期二</asp:ListItem>
                            <asp:ListItem Value="星期三">星期三</asp:ListItem>
                            <asp:ListItem Value="星期四">星期四</asp:ListItem>
                            <asp:ListItem Value="星期五">星期五</asp:ListItem>
                            <asp:ListItem Value="星期六">星期六</asp:ListItem>
                            <asp:ListItem Value="星期天">星期天</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:HiddenField ID="hfTemp" runat="server" />
                    </td>
                </tr>

                <tr>
                    <td align="right">上班时间：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbStartDate" runat="server" CssClass="Wdate" onfocus="WdatePicker({dateFmt:'HH:mm:ss'})"></asp:TextBox></td>
                    <td align="right">下班时间：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbEndDate" runat="server" CssClass="Wdate" onfocus="WdatePicker({dateFmt:'HH:mm:ss'})"></asp:TextBox></td>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
var processtip=1;
function ChkSave()
{
    if(isNull($("tbStartDate").value))
    {
        window.alert("操作失败！上班时间不能为空");
        $("tbStartDate").focus();
        return false
    }
    if(isNull($("tbEndDate").value))
    {
        window.alert("操作失败！下班时间不能为空");
        $("tbEndDate").focus();
        return false
    }
}

</script>
