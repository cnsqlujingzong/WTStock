<%@ page language="C#"  CodeFile="devplanmodify.aspx.cs"     autoeventwireup="true" inherits="Branch_Customer_DevPlanModify" enableEventValidation="false" %>

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
        <div id="sa" style="width:456px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                        <td align="right">名称：</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbName" runat="server" CssClass="pin"></asp:TextBox>
                        </td>
                        <td align="right">提前提醒：</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbRemindDay" runat="server" CssClass="pin" Width="110"></asp:TextBox>
                            <span class="red">天</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">起始日期：</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbStartDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
                        </td>
                        <td align="right">终止日期：</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbEndDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">计时方式：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlTimingStyle" runat="server" CssClass="pindl" onchange="ChkCycle();">
                                <asp:ListItem Value="固定周期">固定周期</asp:ListItem>
                                <asp:ListItem Value="固定日期">固定日期</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right"><asp:Label ID="lbType" runat="server" Text="保养周期"></asp:Label>：</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbMaintenanceCycle" runat="server" CssClass="pin" Width="110"></asp:TextBox>
                            <asp:Label ID="lbDay" runat="server" CssClass="red" Text="天"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">备注：</td>
                        <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="341"></asp:TextBox></td>
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
                    <asp:Button ID="btnAdd" runat="server" Text="确定" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
var isfocus=1;
var processtip=1;
function ChkAdd()
{
    if(isNull($("tbName").value))
    {
        window.alert("操作失败！名称不能为空");
        $("tbName").focus();
        return false
    }
    if(isNull($("tbRemindDay").value))
    {
        window.alert("操作失败！提前提醒不能为空");
        $("tbRemindDay").focus();
        return false
    }
    if(parseFloat($("tbRemindDay").value)<=0)
    {
        window.alert("操作失败！提前提醒必须大于0");
        $("tbRemindDay").focus();
        return false
    }
    if(!isDigit($("tbRemindDay").value))
    {
        window.alert("操作失败！提前提醒格式不正确");
        $("tbRemindDay").focus();
        return false
    }
    
    if(isNull($("tbStartDate").value))
    {
        window.alert("操作失败！起始日期不能为空");
        $("tbStartDate").focus();
        return false
    }
    
    if(isNull($("tbEndDate").value))
    {
        window.alert("操作失败！终止日期不能为空");
        $("tbEndDate").focus();
        return false
    }
    if(isNull($("tbMaintenanceCycle").value))
    {
        window.alert("操作失败！"+$("lbType").innerHTML+"不能为空");
        $("tbMaintenanceCycle").focus();
        return false
    }
    if(parseFloat($("tbMaintenanceCycle").value)<=0)
    {
        window.alert("操作失败！"+$("lbType").innerHTML+"必须大于0");
        $("tbMaintenanceCycle").focus();
        return false
    }
    if(!isDigit($("tbMaintenanceCycle").value))
    {
        window.alert("操作失败！"+$("lbType").innerHTML+"格式不正确");
        $("tbMaintenanceCycle").focus();
        return false
    }
}
function ChkCycle()
{
    if($("ddlTimingStyle").value=="固定日期")
    {
        $("lbType").innerHTML="保养日期";
        $("lbDay").innerHTML="号";
    }
    else
    {
        $("lbType").innerHTML="保养周期";
        $("lbDay").innerHTML="天";
    }
}
</script>
