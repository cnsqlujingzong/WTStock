<%@ page language="C#"  CodeFile="schsuplist.aspx.cs"     autoeventwireup="true" inherits="Branch_Basic_SchSupList" theme="Themes" enableEventValidation="false" %>
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
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="厂商编号" DataField="SupNO" />
            <asp:BoundField HeaderText="厂商名称" DataField="_Name" />
            <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
            <asp:BoundField HeaderText="电话" DataField="Tel" />
        </Columns>
    </asp:GridView>
    </div>
    <div class="schftool">
    <table cellpadding="0" cellspacing="0" class="schtb" width="100%">
        <tr>
            <td align="right" style="padding-right:10px;">
                <input id="btnNew" type="button" value="新建" class="bt1" onclick="parent.ShowDialog<%=Str_F %>(540, 290, 'Basic/SupplierAdd.aspx?f=<%=Str_F %>', '新建厂商');MoveDivTable();" />
                <input id="btnCls" type="button" value="关闭" class="bt1" onclick="MoveDivTable();" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
