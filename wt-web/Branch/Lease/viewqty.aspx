<%@ page language="C#"  CodeFile="viewqty.aspx.cs"     autoeventwireup="true" inherits="Branch_Lease_ViewQty" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:386px;">
    <div class="fdivs" style="width:384px; height:238px;">
    <div class="sdivs"  style="width:382px; height:236px;">
      <asp:GridView ID="gvdata" runat="server" SkinID="gv3" AutoGenerateColumns="False" OnRowDataBound="gvdata_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="序"/>
                <asp:BoundField HeaderText="计数器类型" DataField="QtyTypeName" />
                <asp:BoundField HeaderText="期初计数" DataField="BeginQty" />
                <asp:BoundField HeaderText="计费方式" DataField="ChargeStyle" />
                <asp:TemplateField HeaderText="额定量">
                    <ItemTemplate>
                        <asp:TextBox ID="tbRated" runat="server" Text='<%# Eval("Rated") %>' Width="80" CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="超张费">
                    <ItemTemplate>
                        <asp:TextBox ID="tbSuperZhangFee" runat="server" CssClass="tbstyle" Text='<%# Eval("SuperZhangFee") %>' onfocus="select();"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="单张成本">
                    <ItemTemplate>
                        <asp:TextBox ID="tbCostPrice" runat="server" CssClass="tbstyle" Text='<%# Eval("CostPrice") %>' onfocus="select();"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
        <asp:HiddenField ID="hfFormula" runat="server" />
    </div>
    </div>
    <div class="divh">
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                
            </td>
            <td align="right">
                <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="bt1" OnClick="btnSave_Click" />
                <input id="btnClose" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog<%=Str_F %>();" />
            </td>
        </tr>
    </table>
    </div>
    </div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog<%=Str_F %>();}catch(e){}}}
function ViewFormula(id)
{
    parent.ShowDialog3(400, 300,'Lease/ViewFormula.aspx?id='+id, '查看公式');
}
</script>
