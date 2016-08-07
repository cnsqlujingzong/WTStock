<%@ Page Language="C#" AutoEventWireup="true" CodeFile="inputData.aspx.cs" Inherits="CodingPages_Cd_Product_inputData" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
  <form id="form1" runat="server">
    <div style="margin:0px auto; width:1000px;">
                <a href="../Cd_ProType/ProTypeList.aspx">返回产品型号列表</a>
        <br />
        <br />

        <asp:Label ID="Label1" runat="server" Text="Excel文件请用.xls 文件，office 07及以上版本可以打开Excel-&gt;另存为--&gt;选择Excel 97-2003工作薄 保存" Font-Bold="True" ForeColor="Red"></asp:Label>
        
        <br />
        <span style="color:red;">导入的Excel文件字段数量，顺序必须与以下格式相同，否则将会出现数据错乱</span>
        <br />
        <br />
        <asp:Label ID="lb_protype" runat="server" Font-Bold="True" Font-Size="16pt"></asp:Label>
    
        <table border="1">
            <tr>
               <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <td style="padding:5px 10px;"><%#Eval("DisplayAttrName") %></td>
                        </ItemTemplate>
                    </asp:Repeater>
            </tr>
        </table>
         <br />
        <br />



      选择文件：  <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="Button1" runat="server" Text="导入" OnClick="Button1_Click" />
        <br />
        <asp:Literal ID="Literror" runat="server"></asp:Literal>
    </div> 
    </form>
</body>
</html>
