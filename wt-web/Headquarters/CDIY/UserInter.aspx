<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserInter.aspx.cs" Inherits="Headquarters_CDIY_UserInter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>员工</td>
                <td>  <asp:DropDownList ID="ddl_user" runat="server" Width="150px" DataSourceID="DataSource" DataTextField="uName" DataValueField="ID" AutoPostBack="True"></asp:DropDownList></td>
                <td>数量</td>
                <td>
                    <asp:TextBox ID="tb_qty" runat="server">1</asp:TextBox></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td colspan="8">
                    <asp:Button ID="btn_xin" runat="server" Text="心" OnClientClick="checkData()" OnClick="btn_xin_Click" />&nbsp;
               <asp:Button ID="btn_shouOK" runat="server" Text="手OK" OnClientClick="checkData()" OnClick="btn_shouOK_Click"/>&nbsp;
                <asp:Button ID="btn_shouHao" runat="server" Text="手好" OnClientClick="checkData()" OnClick="btn_shouHao_Click"/>&nbsp;
                 <asp:Button ID="btn_you" runat="server" Text="优" OnClientClick="checkData()" OnClick="btn_you_Click"/>&nbsp;
                 <asp:Button ID="btn_qiHao" runat="server" Text="旗好" OnClientClick="checkData()" OnClick="btn_qiHao_Click"/>&nbsp;
                 <asp:Button ID="btn_xingxing" runat="server" Text="星星" OnClientClick="checkData()" OnClick="btn_xingxing_Click"/>&nbsp;
                 <asp:Button ID="btn_hua" runat="server" Text="红花" OnClientClick="checkData()" OnClick="btn_hua_Click"/>&nbsp;
                <asp:Button ID="btn_xiaolian" runat="server" Text="笑脸" OnClientClick="checkData()" OnClick="btn_xiaolian_Click"/></td>&nbsp;
            </tr>
        </table>
        </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID" DataSourceID="ds_getsource" ForeColor="#333333" GridLines="None" OnRowDataBound="GridView1_RowDataBound">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="编号" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="IntType" HeaderText="类型" SortExpression="IntType" />
                    <asp:BoundField DataField="IntQty" HeaderText="数量" SortExpression="IntQty" />
                    <asp:BoundField DataField="Datetime" DataFormatString="{0:yyyy-MM-dd hh:mm:ss}" HeaderText="授予时间" SortExpression="Datetime" />
                    <asp:TemplateField ShowHeader="False">
                        <EditItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="更新"></asp:LinkButton>
                            &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消"></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Delete" Text="删除"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <asp:SqlDataSource ID="ds_getsource" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Cd_UserInt] WHERE [ID] = @original_ID " InsertCommand="INSERT INTO [Cd_UserInt] ([ID], [UserID], [IntType], [IntQty], [Datetime], [UpUser]) VALUES (@ID, @UserID, @IntType, @IntQty, @Datetime, @UpUser)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Cd_UserInt] WHERE ([UserID] = @UserID)" UpdateCommand="UPDATE [Cd_UserInt] SET [UserID] = @UserID, [IntType] = @IntType, [IntQty] = @IntQty, [Datetime] = @Datetime, [UpUser] = @UpUser WHERE [ID] = @original_ID AND [UserID] = @original_UserID AND (([IntType] = @original_IntType) OR ([IntType] IS NULL AND @original_IntType IS NULL)) AND (([IntQty] = @original_IntQty) OR ([IntQty] IS NULL AND @original_IntQty IS NULL)) AND (([Datetime] = @original_Datetime) OR ([Datetime] IS NULL AND @original_Datetime IS NULL)) AND (([UpUser] = @original_UpUser) OR ([UpUser] IS NULL AND @original_UpUser IS NULL))">
                <DeleteParameters>
                    <asp:Parameter Name="original_ID" Type="Int32" />
                    <asp:Parameter Name="original_UserID" Type="Int32" />
                    <asp:Parameter Name="original_IntType" Type="String" />
                    <asp:Parameter Name="original_IntQty" Type="Decimal" />
                    <asp:Parameter Name="original_Datetime" Type="DateTime" />
                    <asp:Parameter Name="original_UpUser" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="ID" Type="Int32" />
                    <asp:Parameter Name="UserID" Type="Int32" />
                    <asp:Parameter Name="IntType" Type="String" />
                    <asp:Parameter Name="IntQty" Type="Decimal" />
                    <asp:Parameter Name="Datetime" Type="DateTime" />
                    <asp:Parameter Name="UpUser" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddl_user" DefaultValue="-1" Name="UserID" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="UserID" Type="Int32" />
                    <asp:Parameter Name="IntType" Type="String" />
                    <asp:Parameter Name="IntQty" Type="Decimal" />
                    <asp:Parameter Name="Datetime" Type="DateTime" />
                    <asp:Parameter Name="UpUser" Type="String" />
                    <asp:Parameter Name="original_ID" Type="Int32" />
                    <asp:Parameter Name="original_UserID" Type="Int32" />
                    <asp:Parameter Name="original_IntType" Type="String" />
                    <asp:Parameter Name="original_IntQty" Type="Decimal" />
                    <asp:Parameter Name="original_Datetime" Type="DateTime" />
                    <asp:Parameter Name="original_UpUser" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </div>
             <asp:SqlDataSource ID="DataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [ID], [_Name]+'('+[RightName]+')' AS uName  FROM [xt_usermanage]  WHERE _Name<>'超级用户' "></asp:SqlDataSource>
 
    </form>
</body>
</html>
<script>
    function checkData()
    {
        var qty = document.getElementById("tb_qty").value;
        if (isInteger(qty)) {
            return true;
        } else {
            alert("数量必须为正整数");
            return false;
        }
    }
    function isInteger(value)
    {
        var reg = new RegExp("^[0-9]+$");
        if (!reg.test(value)) {
            return false;
        } else {
            return true;
        }
    }
</script>