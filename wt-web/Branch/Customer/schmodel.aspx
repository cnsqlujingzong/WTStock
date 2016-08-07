<%@ page language="C#"  CodeFile="schmodel.aspx.cs"     autoeventwireup="true" inherits="Branch_Customer_SchModel" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="schlist" style="overflow-y:auto;height:200px;width=135px;">
    <asp:GridView ID="gvice" runat="server" AutoGenerateColumns="false" SkinID="sch" ShowHeader="false" OnRowDataBound="gvice_RowDataBound" EnableViewState="false" Width="100%">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="机器型号" DataField="_Name" />
        </Columns>
    </asp:GridView>
    </div>
    <div style="width:135px;">
    <table cellpadding="0" cellspacing="0" class="schtb" width="135px">
        <tr>
            <td align="right" style="padding-right:10px;">
                <input id="btnCls" type="button" value="关闭" class="bt1" onclick="MoveDivTable();" />
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
