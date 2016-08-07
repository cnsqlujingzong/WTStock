<%@ page language="C#"  CodeFile="faultadd.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Basic_FaultAdd" enableEventValidation="false" %>
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
        <div id="sa" style="width:526px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                        <td>产品类别：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlClass" runat="server" CssClass="pindl">
                            </asp:DropDownList>
                        </td>
                        <td>维修类别：</td>
                        <td colspan="2" style="padding-left:0px;">
                            <asp:DropDownList ID="ddlRepair" runat="server" CssClass="pindl">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>故障类别：</td>
                        <td style="padding-left:0px;">
                            <div class="isinDiv">
                            <input type="text" id="tbTroubClass" runat="server" class="pin pinin" readonly="readonly" />
                                <select id="slTroubClass" runat="server" onchange="getclassvalue('tbTroubClass',this.options[this.selectedIndex].text);" class="pininsl">
                                </select>
                            </div>
                        </td>
                        <td>故障编号：</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbTroubleNO" runat="server" Enabled="false" CssClass="pin"></asp:TextBox>
                        </td>
                        <td style="color:#ff0000; padding-left:0px;">
                            <asp:CheckBox ID="cbsys" runat="server" Checked="true" Text="系统默认" onclick="ChkSysNO();" /></td>
                    </tr>
                    <tr>
                        <td>故障名称：</td>
                        <td colspan="4" style="padding-left:0px; height:80px;"><asp:TextBox ID="tbName" runat="server" CssClass="pin" Width="408" TextMode="MultiLine" Height="70"></asp:TextBox></td>
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
                <td style="color:#0000ff">
                    <asp:CheckBox ID="cbClose" runat="server" Text="保存后关闭窗口" Checked="true" /></td>
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
                    <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog2('1');"/>
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
function ChkAdd()
{
    if($("ddlClass").value=="-1")
    {
        window.alert("操作失败！产品类别不能为空");
        $("ddlClass").focus();
        return false
    }
    if($("ddlRepair").value=="-1")
    {
        window.alert("操作失败！维修类别不能为空");
        $("ddlRepair").focus();
        return false
    }
    if(isNull($("slTroubClass").value))
    {
        window.alert("操作失败！故障类别不能为空");
        $("slTroubClass").focus();
        return false
    }
    if(!$("cbsys").checked)
    {
        if(isNull($("tbTroubleNO").value))
        {
            window.alert("操作失败！故障编号不能为空");
            $("tbTroubleNO").focus();
            return false
        }
    }
    if(isNull($("tbName").value))
    {
        window.alert("操作失败！故障不能为空");
        $("tbName").focus();
        return false
    }
}

function ChkSysNO()
{
    if(!$("cbsys").checked)
    {
        $("tbTroubleNO").disabled=false;
        $("tbTroubleNO").focus();
    }else
    {
        $("tbTroubleNO").disabled=true;
    }
}
</script>
