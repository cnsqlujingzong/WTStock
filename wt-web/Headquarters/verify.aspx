<%@ page language="C#"  CodeFile="verify.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Verify" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>��֤ͨ��</title>
</head>
<body onkeydown="KeyClick();">
    <form id="form1" runat="server">
    <div style="padding-top:50px;text-align:center;">
        <p style="margin:0 auto; text-align:left; border:1px #a1b8d8 solid; padding-left:40px; background:#d8e3f3 url(../Public/Images/ok.gif) no-repeat 18px center; width:505px; line-height:38px; color:#4b4b4b; font-size:12px; font-family:Verdana;">���Ѿ��ɹ�ͨ����֤��ϵͳ������һ���´��ڣ���ȷ������������������ڡ�<a href="#" onclick="ChkWin();" style="color:#0000ff">�������</a></p>
    </div>
    </form>
</body>
</html>
<script type="text/javascript" language="javascript">
    function ChkWin()
    {
        var w_width=screen.availWidth-10;
        var w_height=screen.availHeight-38;
	    var size= "scrollbars=no,top=0,left=0,width="+w_width+",height="+w_height+",resizable=yes,status=no,toolbar=no,menubar=no,location=no";
	    var url="Default.aspx";
        var canopen=window.open(url,"",size);
        if(!canopen)
        alert('�����Ѿ�������,�������IE����ѡ���еĵ�����ֹ������ѡ��Ҫ���ر�վ��!');
        else
        {
            window.opener=null; /*for IE6*/
            window.open("","_self");/*for IE7*/
            window.close();
        }
    }
    
    function KeyClick()     
    {           
        if(event.keyCode==13)     
        {
            event.keyCode=9;
            event.returnValue=false;
            ChkWin();
        }
    }
</script>
