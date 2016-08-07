<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="CodingPages_Cd_Product_ProductList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../js/jquery-1.11.2.js"></script>
    <script src="../js/Base.js"></script>
    <script>
        $(function () {
            var tid=Base.getQueryString("id");
            $("#GridView1 tr").each(function () {
                var id = $(this).children("td:first").html();
                if (Validata.isInteger(id)) {
                    $(this).append('<td><a href="/CodingPages/Cd_ProImg/addimg.aspx?id=' + id + '">图片</a></td>');
                    $(this).append('<td><a href="/CodingPages/Cd_ProductFiles/AddFile.aspx?id=' + id + '">文件</a></td>');
                    $(this).append('<td><a onclick="delPro('+id+','+tid+')"  href="javascript:void(0)">删除</a></td>');
                    $(this).append('<td><a onclick="modPro(' + id + ',' + tid + ')"  href="javascript:void(0)">修改</a></td>');

                } else {
                    $(this).append('<th scope="col"></th><th scope="col"></th><th scope="col"></th><th scope="col"></th>');
                }


            });
            var bg;
            $("#GridView1 tr").hover(function () {
                bg = $(this).css("background");
                $(this).css("background", "#d0d0d0");
            }, function () {
                $(this).css("background", bg);
            });

        });
        function delPro(id,tid)
        {
            if (confirm('确认要删除？'))
            {
                window.location.href = "/CodingPages/Cd_Product/delpro.aspx?id="+ id+"&&tid="+tid;
            }
        }
        function modPro(id, tid) {           
                window.location.href = "/CodingPages/Cd_Product/modpro.aspx?id=" + id + "&&tid=" + tid;         
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" margin:0px auto">
        <asp:Label ID="Label1" runat="server" Text="Label" Font-Size="16" Font-Bold="True"></asp:Label>&nbsp;&nbsp;
        <a href="../Cd_ProType/ProTypeList.aspx">返回产品型号列表</a>
              <br />      <br />
        <div style="padding:5px">关键字：<asp:TextBox ID="txt_keyword" runat="server"></asp:TextBox><asp:Button ID="Button1" runat="server" Text="搜索" OnClick="Button1_Click" /></div>

          <asp:GridView ID="GridView1" runat="server" Width="100%" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnRowDataBound="GridView1_RowDataBound" >
          
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
         
        </asp:GridView>


    </div>
    </form>
</body>
</html>
