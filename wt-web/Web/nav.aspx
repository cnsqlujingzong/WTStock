<%@ page language="C#"  CodeFile="nav.aspx.cs"     autoeventwireup="true" inherits="Web_Nav" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
     body{ margin:0; padding:0; font-size:12px; font-family:Verdana,"宋体";}
    .item{ font-weight:bold; font-size:14px; padding:22px 0 6px 35px; color:#008000;}
    ul,li{ margin:0; padding:0; list-style:none;}
    li{ height:23px; color:#666;}
    .li1{ padding:0 15px; background:url(../public/images/li9.gif) no-repeat 0px 2px;}
    .sp1{ padding:0 10px; background:url(../public/images/arrow1.gif) no-repeat;}
    #nt a{ color:#666;}
    #nt a:hover{ color:#ff0000;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="item">
        <asp:Label ID="lbwelcome" runat="server" Text=""></asp:Label></div>
    <div style="padding:10px 35px 0px 35px;">
        <ul>
            <li>你当前的服务单数量：<a style="color:#0000ff; font-weight:bold;" href="ServicesList.aspx" title="查看工单"><%=Nstr1 %></a></li>
            <li>你当前的机器档案数量：<a style="color:#0000ff; font-weight:bold;" href="Device.aspx" title="查看机器档案"><%=Nstr2 %></a></li>
        </ul>
    </div>
    <div style=" margin:0 20px 10px 20px;">
        <a href="http://www.differsoft.com" target="_blank">
            <img id="ImgAdver" src="Public/images/banner.jpg" style="border-width:0px;" />
        </a>
    </div>
    </form>
</body>
</html>
