<%@ page language="C#"  CodeFile="schcuslist.aspx.cs"     autoeventwireup="true" inherits="Branch_Customer_SchCusList" theme="Themes" enableEventValidation="false" %>
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
            <asp:BoundField HeaderText="�ͻ����" DataField="CustomerNO" />
            <asp:BoundField HeaderText="�ͻ�����" DataField="_Name" />
            <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
            <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
        </Columns>
    </asp:GridView>
    </div>
    <div class="schftool">
    <table cellpadding="0" cellspacing="0" class="schtb" width="100%">
        <tr>
            <td align="right" style="padding-right:10px;">
                <input id="btnNew" type="button" value="�½�" class="bt1" onclick="parent.ShowDialog<%=Str_F %>(600, 400, 'Customer/CusAdd.aspx?f=<%=Str_F %>', '�½��ͻ�');MoveDivTable();" />
                <input id="btnCls" type="button" value="�ر�" class="bt1" onclick="MoveDivTable();" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
