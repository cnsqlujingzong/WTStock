<%@ page language="C#"  CodeFile="assadd.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Customer_AssAdd" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body onload="ChkParm();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="main">
        <div class="maincon">
        <div id="sa" style="width:386px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
               <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                    <td align="right" class="sysred">初始密码：</td>
                    <td style="padding-left:0px; width:130px;">
                    <asp:TextBox ID="tbPwd" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td class="blue">短信通知：</td>
                    <td style="padding-left:0px;width:80px;">
                    <asp:CheckBox runat="server" ID="cbSms" AutoPostBack="True" OnCheckedChanged="cbSms_CheckedChanged" Checked="True"></asp:CheckBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">短信模版：</td>
                    <td style="padding-left:0px;" colspan="3">
                        <asp:DropDownList runat="server" ID="ddlTmp" CssClass="pindl" AutoPostBack="True" OnSelectedIndexChanged="ddlTmp_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="padding-left:5px; height:94px;">
                        <asp:TextBox runat="server" ID="tbContent" Height="82" Width="354px" TextMode="MultiLine"></asp:TextBox>
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
                <td>
                    <asp:Label ID="lbMod" runat="server" CssClass="si1" Text="联系人为会员名称"></asp:Label>
                    <asp:HiddenField ID="hfSql" runat="server" />
                </td>
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="确定" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnAdd_Click"/>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
function ChkSave()
{
    if(isNull($("tbPwd").value))
    {
        window.alert("操作失败！初始密码不能为空");
        $("tbPwd").focus();
        return false
    }
    if($("cbSms").checked)
    {
       if(isNull($("tbContent").value))
        {
            window.alert("操作失败！发送内容不能为空");
            $("tbContent").focus();
            return false
        }
    }
}
function ChkParm()
{
    $("hfSql").value=parent.iframeDialog.$("hfSql").value;
}
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog1();}catch(e){}}}
</script>
