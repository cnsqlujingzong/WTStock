<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Prores.aspx.cs" Inherits="CodingPages_online_Prores" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../js/jquery-1.7.2.min.js"></script>
        <link rel="stylesheet" href="../js/prettyphoto/prettyPhoto.css" type="text/css" />	
    <script src="../js/prettyphoto/jquery.prettyPhoto.js"></script>
    
		    <script type="text/javascript">
		        $(document).ready(function () {
		            $("a[rel^='prettyPhoto']").prettyPhoto();
		        });
           </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:1000px;margin:0px auto;">
       <h3>产品号：<asp:Label ID="lb_pn" runat="server" Text="Label"></asp:Label></h3>
        <div>
            <h4>产品图片</h4>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div style="float:left; margin-right:5px; "><a href="<%#Eval("ImgSrc") %>"  rel="prettyPhoto[gallery]"><img style="width:200px; height:200px" src="<%#Eval("ImgSrc") %>" alt=""/></a></div>
            </ItemTemplate>           
        </asp:Repeater>
            <div style="clear:both;"></div>
            </div>
         <div>
            <h4>产品文档</h4>
             <table cellspacing="0" cellpadding="0" border="1">
                 <tr>
                     <td>序号</td>
                     <td>文件</td>
                 </tr>
                    <asp:Repeater ID="Repeater2" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td style="text-align:center; padding:5px 10px;">
                                    <%#Eval("ID") %>
                                </td>
                                 <td style="width:500px;padding:5px 10px;">
                                     <a href='<%#Eval("FileSrc") %>'><%#(Eval("FileSrc")).ToString().Substring(Eval("FileSrc").ToString().LastIndexOf("/")+1) %></a>
                                    
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
             </table>
         
            </div>
    </div>
    </form>
</body>
</html>
