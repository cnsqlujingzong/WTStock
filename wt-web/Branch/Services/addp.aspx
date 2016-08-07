<%@ page language="C#"  CodeFile="addp.aspx.cs"     autoeventwireup="true" inherits="Branch_Services_AddP" enableEventValidation="false" %>
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
        <div id="sa" style="width:446px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                        <td align="right">催单人：</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin"></asp:TextBox>
                        </td>
                        <td align="right">联系电话：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">催单时间：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbDate" CssClass="pin" runat="server" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox></td>
                        <td align="right">受理人：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">处理结果：</td>
                        <td colspan="3" style="padding-left:0px; height:52px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="341" Height="42" TextMode="MultiLine"></asp:TextBox></td>
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
    if(isNull($("tbLinkMan").value))
    {
        window.alert("操作失败！催单人不能为空");
        $("tbLinkMan").focus();
        return false
    }
    
    if(isNull($("tbTel").value))
    {
        window.alert("操作失败！联系电话不能为空");
        $("tbTel").focus();
        return false
    }
    
    if(isNull($("tbDate").value))
    {
        window.alert("操作失败！催单时间不能为空");
        $("tbDate").focus();
        return false
    }
    if($("ddlOperator").value=="-1")
    {
        window.alert("操作失败！受理人不能为空");
        $("ddlOperator").focus();
        return false
    }
    if(isNull($("tbRemark").value))
    {
        window.alert("操作失败！处理结果不能为空");
        $("tbRemark").focus();
        return false
    }
}

</script>
