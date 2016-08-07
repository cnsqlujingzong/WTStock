<%@ page language="C#"  CodeFile="register.aspx.cs"     autoeventwireup="true" inherits="Web_Register" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>���߱���ƽ̨-ע���»�Ա</title>
    <link rel="stylesheet" href="public/css/sub.css" type="text/css"/>
</head>
<body onload="chkCode();">
    <form id="form1" runat="server">
    <div id="r_main">
		<div id="r_top">
			<div id="r_logo"><a href="Default.aspx"><asp:Image ID="imgLogo" runat="server" ImageUrl="~/Web/public/images/logo.jpg" ToolTip="���߱���ƽ̨" /></a></div>
			<div id="r_word"></div>
			<div id="r_path"><a href="Default.aspx" title="��ҳ">��ҳ</a><span class="sp1">ע��</span></div>
			<div style=" clear:both;"></div>
		</div>
		
		<div id="r_center">
			<div id="r_title">��дע����Ϣ</div>
			<div id="r_p">
				<p class="p1">��Ա��:<span style="color:#ff0000">*</span></p>
				<asp:TextBox ID="tbName" runat="server" CssClass="in1 in2" Width="200" onblur="chkName();"></asp:TextBox>
				<span class="rsp2" id="rsp5" runat="server"> Ϊ�Լ�ȡһ���ƺ��������������.</span>
				
				<p class="p1">��½����:<span style="color:#ff0000">*</span></p>
				<asp:TextBox ID="tbpwd" runat="server" CssClass="in1 in2" Width="200" TextMode="Password" onblur="chkPwd();"></asp:TextBox>
				<span class="rsp2" id="rsp2"> ���볤�ȱ����� 6-32 ���ַ�֮��.</span>
				
				<p class="p1">ȷ������:<span style="color:#ff0000">*</span></p>
				<asp:TextBox ID="tbpwd2" runat="server" CssClass="in1 in2" Width="200" TextMode="Password" onblur="chkPwd2();"></asp:TextBox>
				<span class="rsp2" id="rsp3">������һ������.</span>
				
                <p class="p1">Email:<span style="color:#ff0000">*</span></p>
				<asp:TextBox ID="tbemail" runat="server" CssClass="in1 in2" Width="200" onblur="chkEmail();"></asp:TextBox>
				<span class="rsp2" id="Span5">Email��������ȡ������.</span>
				
			    <p class="p1">��λ����:<span style="color:#ff0000">*</span></p>
				<asp:TextBox ID="tbcorp" runat="server" CssClass="in1 in2" Width="200" onblur="chkCorp();"></asp:TextBox>
				<span class="rsp2" id="Span1"> ����Ǹ��˿ͻ�������д��������.</span>
				
				<p class="p1">��ϵ��:<span style="color:#ff0000">*</span></p>
				<asp:TextBox ID="tbman" runat="server" CssClass="in1 in2" Width="200" onblur="chkMan();"></asp:TextBox>
				<span class="rsp2" id="Span2"></span>
				
				<p class="p1">��ϵ�绰:<span style="color:#ff0000">*</span></p>
				<asp:TextBox ID="tbtel" runat="server" CssClass="in1 in2" Width="200" onblur="chkTel();"></asp:TextBox>
				<span class="rsp2" id="Span3"></span>
				
				<p class="p1">��ϵ��ַ:<span style="color:#ff0000">*</span></p>
				<asp:TextBox ID="tbadr" runat="server" CssClass="in1 in2" Width="400" onblur="chkAdr();"></asp:TextBox>
				<span class="rsp2" id="Span4"></span>
				
				<p class="p1">������ͼƬ�е�����:<span style="color:#ff0000">*</span></p>
				<table cellpadding="0" cellspacing="0">
				<tr>
				<td>
				<asp:TextBox ID="tbvalidate" runat="server" CssClass="in1 in2" Width="100" onblur="chkNum();" MaxLength="4"></asp:TextBox>
				</td>
				<td style="padding-left:5px;">
				<img style="width:100px; height:30px;" id="validatepic" alt="validate code" src="public/images/none.gif" onclick="chgCode();"/>
				</td>
				<td style="padding-left:5px;">
				<span id="rsp4" runat="server"></span>
				</td>
				</tr>
				</table>
				<p><asp:Button ID="btnreg" runat="server" Text="ע ��" CssClass="bt1" OnClientClick="return chkReg();" OnClick="btnreg_Click" /></p>
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

function chkPwd()
{
    if(!isPwd($("tbpwd").value)){$("rsp2").innerHTML="�����ʽ����ȷ,���ܰ��������ַ�,����6-30.";$("rsp2").className="rsp1_w";return false;}
    else{$("rsp2").innerHTML="���������ʹ��";$("rsp2").className="rsp1_r";return true;}
}
function chkPwd2()
{
    if($("tbpwd").value!=$("tbpwd2").value){$("rsp3").innerHTML="�����������벻һ��.";$("rsp3").className="rsp1_w";return false;}
    else{$("rsp3").innerHTML="";return true;}
}
function chkEmail()
{
    if(!isMail($("tbemail").value)){$("Span5").innerHTML="Email��ʽ����ȷ.";$("Span5").className="rsp1_w";return false;}
    else{$("Span5").innerHTML="";return true;}
}
function chkNum()
{
    if(isNull($("tbvalidate").value)){$("rsp4").innerHTML="������ͼƬ�е�����.";$("rsp4").className="rsp1_w";return false;}
    else{$("rsp4").innerHTML="";return true;}
}
function chkName()
{
    if(isNull($("tbName").value)){$("rsp5").innerHTML="��Ա������Ϊ��.";$("rsp5").className="rsp1_w";return false;}
    else{$("rsp5").innerHTML="";return true;}
}
function chkCorp()
{
    if(isNull($("tbcorp").value)){$("Span1").innerHTML="��˾���Ʋ���Ϊ��.";$("Span1").className="rsp1_w";return false;}
    else{$("Span1").innerHTML="";return true;}
}

function chkMan()
{
    if(isNull($("tbman").value)){$("Span2").innerHTML="��ϵ�˲���Ϊ��.";$("Span2").className="rsp1_w";return false;}
    else{$("Span2").innerHTML="";return true;}
}

function chkTel()
{
    if(isNull($("tbtel").value)){$("Span3").innerHTML="��ϵ�绰����Ϊ��.";$("Span3").className="rsp1_w";return false;}
    else{$("Span3").innerHTML="";return true;}
}

function chkAdr()
{
    if(isNull($("tbadr").value)){$("Span4").innerHTML="��ϵ��ַ����Ϊ��.";$("Span4").className="rsp1_w";return false;}
    else{$("Span4").innerHTML="";return true;}
}

function chgCode()
{
    $("validatepic").src="ValidateCode.ashx?t="+Math.random();
}
function chkCode()
{
    window.setTimeout("chgCode()",1000);
}
function chkReg()
{
    if(!chkName()){return false;}
    if(!chkPwd()){return false;}
    if(!chkPwd2()){return false;}
    if(!chkEmail()){return false;}
    if(!chkCorp()){return false;}
    if(!chkMan()){return false;}
    if(!chkTel()){return false;}
    if(!chkAdr()){return false;}
    if(!chkNum()){return false;}
}
// ����Ƿ�Ϊ��Ч��email
function isMail(str)
{
  var myReg = /^[_\-\.a-zA-Z0-9]+@([_\-a-zA-Z0-9]+\.)+[a-zA-Z0-9]{2,3}$/;
  if(myReg.test(str)) 
  	return true;
  return false;
}
</script>
