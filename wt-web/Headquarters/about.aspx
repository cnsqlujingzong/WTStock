<%@ page language="C#"  CodeFile="about.aspx.cs"     autoeventwireup="true" inherits="Headquarters_About" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
    <div class="maincon">
    <div id="sa" style="width:486px;">
    <div class="fdiv">
    <div class="sdiv" style="padding:5px 0 5px 5px;">
        <div style="background:url(../Public/Images/logo.gif) no-repeat left center">
            <table cellpadding="0" cellspacing="0" class="tba" style="margin-left:140px;">
                <tr>
                    <td>������ƣ�άͨ.net(ITר��) 10.1</td>
                </tr>
                <tr>
                    <td>����ƽ̨��.NET2.0+IIS+SQL2000</td>
                </tr>
                <tr>
                    <td>����֧�֣����ݵѷ�������޹�˾</td>
                </tr>
                <tr>
                    <td>�ٷ���ַ��<a href="http://www.differsoft.com" target="_blank" style="color:#0000ff">http://www.differsoft.com</a></td>
                </tr>
                <tr>
                    <td>��ϵ�绰��0571-88223309��0571-88223317</td>
                </tr>
            </table>
        </div>
<textarea id="tbupdate" cols="20" rows="2" style="width:460px; height:50px; background:#e9e7e3;color:#ff0000;" readonly="readonly">
�汾��:<%=Version%>
</textarea>
        </div>
    </div>
    
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="right">
            <input id="btnCls" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog();"/>
        </td>
    </tr>
    </table>
    </div>
    </div>
    </div>
    </form>
</body>
</html>
