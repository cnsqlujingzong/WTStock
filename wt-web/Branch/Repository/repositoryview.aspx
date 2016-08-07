<%@ page language="C#"  CodeFile="repositoryview.aspx.cs"     autoeventwireup="true" inherits="Branch_Repository_RepositoryView" enableviewstate="false" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>查看知识</title>
    <style type="text/css">
    body{ font:14px Verdana,sans-serif,宋体; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
        <div style="font-weight:bold; text-align:center;"><%#Server.HtmlEncode(Eval("Title").ToString()) %></div>
        <div style="text-align:center; font-size:12px;"><span>发布时间：<%#Eval("_Date") %></span><span style=" padding-left:20px;">发布者：<%#Server.HtmlEncode(Eval("Author").ToString())%></span></div>
        <div style="padding:10px; margin-top:5px; background:#e8e8e8; border:1px #ccc solid;"><%#Eval("Content") %></div>
        </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
