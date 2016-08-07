<%@ page language="C#"  CodeFile="schcuslist2.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Customer_SchCusList2" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="schlist">
    <asp:GridView ID="gvice" runat="server" AutoGenerateColumns="false" SkinID="sch" ShowHeader="false" OnRowDataBound="gvice_RowDataBound" EnableViewState="false" Width="100%">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="CustomerID" />
            <asp:BoundField HeaderText="客户编号" DataField="CustomerNO" />
            <asp:BoundField HeaderText="客户名称" DataField="_Name" />
            <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
            <asp:BoundField HeaderText="联系电话" DataField="Tel" />
            <asp:BoundField HeaderText="type" DataField="CusType" />
        </Columns>
    </asp:GridView>
    </div>
    <div class="schftool">
    <table cellpadding="0" cellspacing="0" class="schtb" width="100%">
        <tr>
            <td align="right" style="padding-right:10px;">
                <input id="btnNewSup" type="button" value="新建厂商" class="bt1" onclick="parent.ShowDialog<%=Str_F %>(540, 290, '../Headquarters/Basic/SupplierAdd.aspx?f=<%=Str_F %>', '新建厂商');MoveDivTable();" />
                <input id="btnNew" type="button" value="新建客户" class="bt1" onclick="parent.ShowDialog<%=Str_F %>(600, 400, '../Headquarters/Customer/CusAdd.aspx?f=<%=Str_F %>', '新建客户');MoveDivTable();" />
                <input id="btnCls" type="button" value="关闭" class="bt1" onclick="MoveDivTable();" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
