<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="ProTypeList.aspx.cs" Inherits="CodingPages_Cd_ProType_ProTypeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language="javascript" src="js/CheckBox.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!--Title -->

            <!--Title end -->

            <!--Add  -->

            <!--Add end -->

            <!--Search -->
    <a href="ProTypeAdd.aspx"><h4>添加新分类</h4></a>
            <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>
                    <td style="width: 80px" align="right" class="tdbg">
                         <b>关键字：</b>
                    </td>
                    <td class="tdbg">                       
                    <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSearch" runat="server" Text="查询"  OnClick="btnSearch_Click" >
                    </asp:Button>                    
                        
                    </td>
                    <td class="tdbg">
                    </td>
                </tr>
            </table>
            <!--Search end-->
            <br />
            <asp:GridView ID="gridView" runat="server" AllowPaging="True" Width="100%" CellPadding="3"  OnPageIndexChanging ="gridView_PageIndexChanging"
                    BorderWidth="1px" DataKeyNames="Id" OnRowDataBound="gridView_RowDataBound"
                    AutoGenerateColumns="false" PageSize="10"  RowStyle-HorizontalAlign="Center" OnRowCreated="gridView_OnRowCreated">
                    <Columns>
                    <asp:TemplateField ControlStyle-Width="30" HeaderText="选择"    >
                                <ItemTemplate>
                                    <asp:CheckBox ID="DeleteThis" onclick="javascript:CCA(this);" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField> 
                            
		<asp:BoundField DataField="TypeName" HeaderText="类型名称" SortExpression="TypeName" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Desc" HeaderText="描述" SortExpression="Desc" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="Common" HeaderText="备注" SortExpression="Common" ItemStyle-HorizontalAlign="Center"  /> 
                            
                            <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="ProTypeDetail.aspx?id={0}"
                                Text="详细"  />
                            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="ProTypeMod.aspx?id={0}"
                                Text="编辑"  />
                            <asp:TemplateField ControlStyle-Width="50" HeaderText="删除"   Visible="false"  >
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                         Text="删除"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                          <asp:HyperLinkField HeaderText=""  DataNavigateUrlFields="Id" DataNavigateUrlFormatString="/CodingPages/Cd_Product/ProConfig.aspx?id={0}"
                                Text="配置产品"  />
                        <asp:HyperLinkField HeaderText=""  DataNavigateUrlFields="Id" DataNavigateUrlFormatString="/CodingPages/Cd_Product/ProConfigShow.aspx?id={0}"
                                Text="查看配置"  />
                           <asp:HyperLinkField HeaderText=""  DataNavigateUrlFields="Id" DataNavigateUrlFormatString="/CodingPages/Cd_Product/ProductList.aspx?id={0}"
                                Text="查看产品"  />
                           <asp:HyperLinkField HeaderText=""  DataNavigateUrlFields="Id" DataNavigateUrlFormatString="/CodingPages/Cd_Product/inputData.aspx?id={0}"
                                Text="导入产品"  />
                        </Columns>
                </asp:GridView>
               <table border="0" cellpadding="0" cellspacing="1" style="width: 100%;">
                <tr>
                    <td style="width: 1px;">                        
                    </td>
                    <td align="left">
                        <asp:Button ID="btnDelete" runat="server" Text="删除" OnClick="btnDelete_Click"/>                       
                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>
