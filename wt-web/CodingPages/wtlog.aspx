<%@ Page Language="C#" AutoEventWireup="true" CodeFile="wtlog.aspx.cs" Inherits="CodingPages_wtlog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style=" margin:0px auto">
    
      <h2>日志操作记录</h2>
              <br />      <br />
        <div style="padding:5px">单号：<asp:TextBox ID="txt_keyword" runat="server"></asp:TextBox><asp:Button ID="Button1" runat="server" Text="搜索" OnClick="Button1_Click" /></div>

          <asp:GridView ID="GridView1" runat="server" Width="100%" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" AutoGenerateColumns="False"  >
          
              <Columns>
                  <asp:BoundField DataField="ID" HeaderText="序号" />
                  <asp:BoundField DataField="source" HeaderText="来源" />
                  <asp:BoundField DataField="billnum" HeaderText="单号" />
                  <asp:BoundField DataField="opt" HeaderText="操作" />
                  <asp:BoundField DataField="decribe" HeaderText="描述" />
                  <asp:BoundField DataField="common" HeaderText="备注" />
                  <asp:BoundField DataField="person" HeaderText="操作人" />
                  <asp:BoundField DataField="logtime" HeaderText="操作时间" />
                  <asp:BoundField DataField="personID" HeaderText="操作人编号" />
                  <asp:BoundField DataField="BillID" HeaderText="单号ID" />
              </Columns>
          
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
