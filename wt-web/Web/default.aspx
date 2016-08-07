<%@ page language="C#"  CodeFile="default.aspx.cs"     autoeventwireup="true" inherits="Web_Default" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>在线报修平台</title>
    <link rel="stylesheet" href="public/css/main.css" type="text/css"/>
</head>
<body onload="chkCode();">
    <form id="form1" runat="server">
    <div id="i_main">
		<div id="i_top">
			<div id="i_logo"><a href="Default.aspx">
                <asp:Image ID="imgLogo" runat="server" ImageUrl="~/Web/public/images/logo.jpg" ToolTip="在线报修平台" /></a></div>
			<div id="i_word">
                <asp:Label ID="lbFlack" runat="server" Text="服务不再遥远 报修没有距离"></asp:Label></div>
			<div style=" clear:both;"></div>
		</div>
		
		<div id="i_menu">
			<ul>
				<li class="li1"><a href="Register.aspx" title="免费注册">免费注册</a></li>
			</ul>
		</div>
		
		<div id="i_center">
			<div id="i_left">
				<div id="i_sl"></div>
				<div id="i_sll">
					<table cellpadding="0" cellspacing="0" border="0" class="tb1">
						<tr>
							<td class="t1">帐 号:</td>
							<td>
                                <asp:TextBox ID="tbuser" runat="server" CssClass="in1 in2"></asp:TextBox><br />
								<span class="s1" id="sp_m" runat="server">填写注册时的会员名.</span><br />
							</td>
						</tr>
						<tr>
							<td class="t1">密 码:</td>
							<td><asp:TextBox ID="tbpwd" runat="server" CssClass="in1 in2" TextMode="Password"></asp:TextBox><br />
							<a href="Forget.aspx" title="忘记密码了？" class="s1" style="color:#4a6988;">忘记密码了？</a>
							</td>
						</tr>
						<tr>
							<td class="t1">验 证:</td>
							<td><asp:TextBox ID="tbvalidate" runat="server" CssClass="in1 in2" MaxLength="4" onfocus="this.select();"></asp:TextBox><br />
								<span class="s1">请输入下面看见的数字</span>
							</td>
						</tr>
						<tr><td></td><td><img style="width:100px; height:30px; border:1px #ccc solid;" id="validatepic" alt="validate code" src="public/images/none.gif" onclick="chgCode();"/></td></tr>
						<tr><td></td><td><asp:Button ID="btnlogin" runat="server" Text="登 陆" CssClass="bt1" OnClientClick="return chkInput();" OnClick="btnlogin_Click" /></td></tr>
					</table>
				</div>
				<div id="i_reg">
					我还没有帐号，<a href="Register.aspx" title="马上创建">马上创建</a>
				</div>
				
			</div>
			<div id="i_right">
				<div id="i_sr"></div>
				<div id="i_srr">
					<div id="i_itr">
						<p>
                            <asp:Label ID="lbSay1" runat="server" Text="维通web模块是为了满足用户异地浏览数据、网络报修需要。"></asp:Label></p>
						<p>
                            <asp:Label ID="lbSay2" runat="server" Text="客户通过web端可以方便得进行网上报修、维修服务和机器档案的查询。"></asp:Label></p>
					</div>
					<div id="i_girl" runat="server">
						<ul>
							<li>联系电话：<asp:Label ID="lbtel" runat="server"></asp:Label></li>
							<li>联系地址：<asp:Label ID="lbadr" runat="server"></asp:Label></li>
						</ul>
					</div>
					
				</div>
			</div>
			<div style="clear:both;"></div>
		</div>
		
		<div id="i_foot">
			<ul>
				<li><asp:Label ID="lbcorp" runat="server"></asp:Label> @2011</li>
			</ul>
		</div>
		
	</div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="public/script/common.js"></script>
<script language="javascript" type="text/javascript" src="public/script/validator.js"></script>
<script language="javascript" type="text/javascript">
function chgCode(){ $("validatepic").src="ValidateCode.ashx?t="+Math.random();}
function chkCode(){ $("tbuser").focus();window.setTimeout("chgCode()",1000);}
function chkInput(){
if(isNull($("tbuser").value)){$("sp_m").innerHTML="请输入帐号.";$("sp_m").className="s1_i";$("tbuser").focus();return false;}
if(isNull($("tbpwd").value)){$("sp_m").innerHTML="请输入密码.";$("sp_m").className="s1_i";$("tbpwd").focus();return false;}
if(isNull($("tbvalidate").value)){$("sp_m").innerHTML="请输入验证码.";$("sp_m").className="s1_i";$("tbvalidate").focus();return false;}
}
</script>
