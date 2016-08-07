<%@ page language="C#"  CodeFile="forget.aspx.cs"     autoeventwireup="true" inherits="Web_Forget" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>在线报修平台-取回密码</title>
    <link rel="stylesheet" href="public/css/sub.css" type="text/css"/>
</head>
<body onload="chkCode();">
    <form id="form1" runat="server">
    <div id="r_main">
		<div id="r_top">
			<div id="r_logo"><a href="Default.aspx"><asp:Image ID="imgLogo" runat="server" ImageUrl="~/Web/public/images/logo.jpg" ToolTip="在线报修平台" /></a></div>
			<div id="r_word"></div>
			<div id="r_path"><a href="Default.aspx" title="首页">首页</a><span class="sp1">取回密码</span></div>
			<div style=" clear:both;"></div>
		</div>
		<div id="r_center">
			<div id="r_title">密码将发送到您的email邮箱中</div>
			<div id="r_p">
				<p class="p1">请输入你的email:</p>
                <asp:TextBox ID="tbemail" runat="server" CssClass="in1 in2" Width="200"></asp:TextBox>
                <input id="hfemail" type="hidden" />
				<span class="rsp2" id="rsp1" runat="server">请输入您注册时的邮箱，请务必填写真实邮箱.</span>
				<p class="p1">请输入图片中的数字:</p>
				<table cellpadding="0" cellspacing="0">
				<tr>
				<td>
				<asp:TextBox ID="tbvalidate" runat="server" CssClass="in1 in2" Width="100"  MaxLength="4"></asp:TextBox>
				</td>
				<td style="padding-left:5px;">
				<img style="width:100px; height:30px;" id="validatepic" alt="validate code" src="public/images/none.gif" onclick="chgCode();"/>
				</td>
				<td style="padding-left:5px;">
				<span id="rsp4" runat="server"></span>
				</td>
				</tr>
				</table>
				<p><asp:Button ID="btnsure" runat="server" Text="确 定" CssClass="bt1" OnClientClick="return chkSure();" OnClick="btnsure_Click" /></p>
			</div>
		</div>
	</div>
	<div id="r_foot">
			<ul>
                <li><asp:Label ID="lbcorp" runat="server"></asp:Label> @2009</li>
			</ul>		
	</div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="public/script/common.js"></script>
<script language="javascript" type="text/javascript" src="public/script/validator.js"></script>
<script language="javascript" type="text/javascript">
function chkMail()
{
    if(!isMail($("tbemail").value)){$("rsp1").innerHTML="email格式不正确";$("rsp1").className="rsp1_w";return false;}
    else{$("rsp1").innerHTML="";return true;}
}
function chkNum()
{
    if(isNull($("tbvalidate").value)){$("rsp4").innerHTML="请输入图片中的数字.";$("rsp4").className="rsp1_w";return false;}
    else{$("rsp4").innerHTML="";return true;}
}
function chgCode()
{
    $("validatepic").src="ValidateCode.ashx?t="+Math.random();
}
function chkCode()
{
    window.setTimeout("chgCode()",1000);
}
function chkSure()
{
    if(!chkMail()){return false;}if(!chkNum()){return false;}
}
</script>
