<%@ page language="C#" autoeventwireup="true" CodeFile="default.aspx.cs" Inherits="_Default" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%=sTitle%></title>
    <link rel="Stylesheet" type="text/css" href="Public/Style/login.css" />
</head>
<body onload="Init();" scroll="no">
    <form id="form1" runat="server" style="height:100%;">
    <div id="main">
    <div id="dhdiv">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnLogin" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div id="cndiv">
    <div id="divborder">
        <div id="banner"></div>
        <div id="login">
            <div class="thdiv">
            <asp:HiddenField ID="hfValiCode" Value="0" runat="server" />
            <asp:HiddenField ID="hfLoginDdl" Value="0" runat="server" />
            </div>
             <table cellpadding="0" cellspacing="0" border="0" width="100%" class="tlogin">
	            <tr>
                    <td rowspan="5" valign="top" align="center">
                        <table border="0" cellpadding="0" cellspacing="0" class="tb_branch">
                            <tr>
                                <td align="center">
                                    <div id="branch_user"></div>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="height:25px;">
                                   <span class="branch">网点登陆</span></td>
                            </tr>
                            <tr>
                            <td align="center" style="height:25px;">
		                    <asp:DropDownList TabIndex="-1" ID="ddlBranch" runat="server" CssClass="pindl" onchange="$('tbName').focus();" AutoPostBack="True" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
		                    </asp:DropDownList>
		                    </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                    <table>
                    <tr>
		            <td><img src="Public/Images/Login/user.gif"/></td><td align="right">用户：</td>
		            <td align="left">
		            <div <%=Str_LoginDdl %>>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                    <ContentTemplate>
                        <asp:TextBox ID="tbName" runat="server" AutoCompleteType="Disabled" onchange="GetPwd();"></asp:TextBox>
                        <asp:DropDownList ID="ddlStaff" runat="server" CssClass="pininsl" onchange="document.getElementById('tbName').value=this.options[this.selectedIndex].text;GetPwd();">
                        </asp:DropDownList>
                        <asp:HiddenField ID="hfAdmin" Value="0" runat="server" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="ddlBranch" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="btnLogin" EventName="Click" />
                    </Triggers>
                    </asp:UpdatePanel>
                    </div>
		            </td>
		            </tr>
	            <tr>
		            <td ><img  src="Public/Images/Login/pwd.gif"/></td><td align="right">密码：</td>
		            <td align="left"><asp:TextBox ID="tbPassword" runat="server" CssClass="pin" ToolTip="登陆密码" TextMode="Password" autocomplete="off" onkeydown="EnterTextBox(event, this);"></asp:TextBox></td>
	            </tr>
	            <tr>
		            <td <%=Str_Vali %>><img  src="Public/Images/Login/vali.gif"/></td><td align="right" <%=Str_Vali %>>验证：</td>
		            <td align="left" <%=Str_Vali %>>
		                <table cellpadding="0" cellspacing="0" border="0">
		                    <tr>
		                        <td><asp:TextBox ID="tbZCode" runat="server" CssClass="pin" Width="74" autocomplete="off" ToolTip="输入旁边的数字" onkeydown="EnterTextBox(event, this);"></asp:TextBox></td>
		                        <td style="padding-left:4px;"><img id="CodeImg" onclick="ChkImg();" style="cursor:hand;" alt="check" title="点击更新验证码" /></td>
		                    </tr>
		                </table>
		            </td>
	            </tr>
	            <tr <%=Str_Phone %>>
	                <td></td>
	                <td>验证码：</td>
	                <td>
                        <asp:TextBox ID="tbPhone" runat="server" CssClass="pin"></asp:TextBox>
                        <input type="button" value="发送" onclick="getCode();" />
                    </td>
	            </tr>
	            <tr <%=Str_Remember %>>
		            <td colspan="2"></td>
		            <td align="left">
                        <asp:CheckBox ID="cbRememberPassword" runat="server" Text=" 记住我的密码" />
		            </td>
	            </tr>
                <tr>
                    <td colspan="3" style="height: 35px" align="center">
                    <asp:Button ID="btnLogin" runat="server" CssClass="bt_login" Text="" OnClientClick="if(ChkLogin()==false)return false;" OnClick="btnLogin_Click" UseSubmitBehavior="false" />
                    <input id="btnCancel" type="reset" value="" class="bt_cancel" />
                </td>
                </tr>
                </table>
                </td>
                </tr>
            </table>
            <div class="thdiv"<%=Str_Height %>></div>
            <div id="div_bottom">技术支持：杭州笛佛软件公司 &nbsp;&nbsp;官方网站：<a href="http://www.differsoft.com/" target="_blank" title="杭州笛佛软件有限公司">http://www.differsoft.com/</a></div>
			</div>
			</div>
        </div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
function ChkLogin()
{
    if(isNull($("tbName").value))
    {
        window.alert("请选择或输入用户名.");
        $("tbName").focus();
        return false;
    }
    
    if("<%=Str_ValiCode %>"=="0")
    {
        if(isNull($("tbZCode").value))
        {
            window.alert("请输入验证码，右下角4位数字.");
            $("tbZCode").focus();
            return false;
        }
    }
    if("<%=Str_PhoneValue %>"=="0")
    {
        if(isNull($("tbPhone").value))
        {
            window.alert("请输入手机验证码");
            $("tbPhone").focus();
            return false;
        }
    }
}

function ChkStaff()
{
    var bnull=true;
    if(!isNull($("tbName").value))
    {
        var ddlgradelevel=$("ddlStaff");
        if($("tbName").value!=ddlgradelevel.options[ddlgradelevel.selectedIndex].text)
        {
            for(var i=0;i<ddlgradelevel.options.length;i++)
            {
                if(ddlgradelevel.options[i].value!="0")
                {
                    if(ddlgradelevel.options[i].text==$("tbName").value)
                    {
                        ddlgradelevel.options[i].selected=true;
                        bnull=false;
                        break;
                    }
                }else{$("tbName").value="";}
            }
            
            if(bnull)
            {
                for(var i=0;i<ddlgradelevel.options.length;i++)
                {
                    if(ddlgradelevel.options[i].text=="")
                    {
                        ddlgradelevel.options[i].selected=true;
                    }
                }
                $("tbName").value="";
            }
        }
    }
}

function Init()
{
    $("tbName").focus();
    if("<%=Str_ValiCode %>"=="0")
        ChkImg();
}

function ChkCln()
{
    $('tbPassword').value="";
    if("<%=Str_ValiCode %>"=="0")
        $('tbZCode').value="";
}
function ChkImg()
{
    $("CodeImg").src="Public/Handler/RndImg.aspx?tmp="+Math.random();
}
function $(id){ return document.getElementById(id);}
function isNull(s) 
{ 
var patrn=/^\s*$/;
if(!patrn.exec(s)) return false;
return true;
} 
function EnterTextBox(event, obj)
{
    if(event.keyCode == 13&&!isNull(obj.value))
    {
        if(!isNull(obj.value))
        {
            $("btnLogin").click();
        }
    }
}

//写cookies函数
function SetCookie(name,value)
{
    var Days = 30;
    var exp  = new Date();
    exp.setTime(exp.getTime() + Days*24*60*60*1000);
    document.cookie = name + "="+ escape (value) + ";expires=" + exp.toGMTString();
}
function getCookie(name)//取cookies函数        
{
    var arr = document.cookie.match(new RegExp("(^| )"+name+"=([^;]*)(;|$)"));
     if(arr != null) return unescape(arr[2]); return null;
}
        
function GetPwd()
{
   if(getCookie($("tbName").value+$("ddlBranch").value)!=null)
    {
        $("tbPassword").value=getCookie($("tbName").value+$("ddlBranch").value);
        $("cbRememberPassword").checked=true;
    }
}
function SetCk()
{
    if($("cbRememberPassword").checked)
    {
        SetCookie($("tbName").value+$("ddlBranch").value,$("tbPassword").value);
    }else
    {
        document.cookie = $("tbName").value+$("ddlBranch").value + "=; expires=Fri, 31 Dec 1999 23:59:59 GMT;";
    }
}

var xmlHttp = false;
function getCode()
{
    if(isNull($("tbName").value))
    {
        window.alert("请选择或输入用户名");
        $("tbName").focus();
        return false;
    }
    setXmlHttp();
    var url = "Interface/GetPhoneCode.ashx?username="+escape($("tbName").value)+"&branch="+escape($("ddlBranch").value)+"&c="+Math.round(Math.random()*10000);
    // 连接到服务器。 
    xmlHttp.open("GET", url, false);
    // 设置回调函数。 
    xmlHttp.onreadystatechange = callBack_CheckCode;
    // 发送请求。 
    xmlHttp.send(null); 
}
// 创建XMLHttpRequest 对象。 
function setXmlHttp() {
    try {
        xmlHttp = new ActiveXObject("Msxml2.XMLHTTP");
    } catch (e) {

        try {
            xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
        } catch (e2) {

            xmlHttp = false;
        }
    }
    if (!xmlHttp && typeof XMLHttpRequest != 'undefined') {
        xmlHttp = new XMLHttpRequest();
    }
}
function callBack_CheckCode()  
{ 
    if(xmlHttp.readyState == 4)  
    {
        var isValid = xmlHttp.responseText;
        alert(isValid);
    } 
}
</script>