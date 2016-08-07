<%@ page language="C#"  CodeFile="newdeduct.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Services_NewDeduct" enableEventValidation="false" %>
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
        <div id="sa" style="width:406px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                        <td align="right">网点：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlDept" runat="server" CssClass="pindl" AutoPostBack="true" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td align="right">姓名：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl">
                            </asp:DropDownList>
                        </td>
                        
                    </tr>
                    <tr>
                        <td align="right">日期：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbDate" CssClass="Wdate" runat="server" onfocus="WdatePicker()"></asp:TextBox></td>
                        <td align="right">提成：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbDeduct" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td>
                            <asp:HiddenField ID="hfDept" runat="server" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ddlDept" EventName="SelectedIndexChanged" />
            </Triggers>
            </asp:UpdatePanel>
            </div>
            </div>
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>

<script language="javascript" type="text/javascript">
var processtip=1;
function ChkAdd()
{
    if($("ddlOperator").value=="-1")
    {
        window.alert("操作失败！姓名不能为空");
        $("ddlOperator").focus();
        return false
    }
    if(isNull($("tbDate").value))
    {
        window.alert("操作失败！日期不能为空");
        $("tbDate").focus();
        return false
    }
    if(isNull($("tbDeduct").value))
    {
        window.alert("操作失败！提成不能为空");
        $("tbDeduct").focus();
        return false
    }
}
</script>
