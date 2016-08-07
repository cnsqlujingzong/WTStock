<%@ page language="C#"  CodeFile="password.aspx.cs"     autoeventwireup="true" inherits="Web_Password" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="public/css/mysub.css" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div id="idiv">
    <div class="item"><span style="padding-right:30px;">修改密码</span><span id="span_info" style="display:none;"></span>
        <asp:Label ID="lbInfo" runat="server" style="color:#ff0000;"></asp:Label>
    </div>
    <div class="tool"></div>
    </div>
    <!-- -->
       <div style="padding-top:10px; padding-left:20px;">
        
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td>输入旧密码：</td>
                <td style="padding-left:0px;">
                <asp:TextBox ID="tbPswOld" runat="server" CssClass="pin pin2" Width="200" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>输入新密码：</td>
                <td style="padding-left:0px;">
                <asp:TextBox ID="tbPsw" runat="server" CssClass="pin pin2" Width="200" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>再输入一次：</td>
                <td style="padding-left:0px;">
                <asp:TextBox ID="tbPsw2" runat="server" CssClass="pin pin2" Width="200" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td style="padding-left:0px;"><asp:Button ID="btnAdd" runat="server" Text="保存修改" CssClass="bt1 bt8" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnAdd_Click"  /></td>
            </tr>
        </table>
    <!--end-->
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="public/script/common.js"></script>
<script language="javascript" type="text/javascript" src="public/script/validator.js"></script>
<script language="javascript" type="text/javascript">
function ChkSave()
{
   if(isNull($("tbPswOld").value))
   {
        alert("请输入旧密码.");
        $("tbPswOld").select();
        return false;
   }
   
   if(isNull($("tbPsw").value))
   {
        alert("请输入新密码.");
        $("tbPsw").select();
        return false;
   }
   
    if(!isPwd($("tbPsw").value))
    {
        window.alert("操作失败！密码长度必须在6-32位之间");
        $("tbPsw").focus();
        return false
    }
    
   if(isNull($("tbPsw2").value))
   {
        alert("请再输入一次新密码");
        $("tbPsw2").select();
        return false;
   }
   
   if($("tbPsw2").value!=$("tbPsw").value)
   {
        alert("两次密码输入不一致");
        $("tbPsw").select();
        return false;
   }
}
</script>
