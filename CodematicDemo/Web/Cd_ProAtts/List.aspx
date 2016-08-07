<%@ Page Title="Cd_ProAtts" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Coding.Stock.Web.Cd_ProAtts.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script language="javascript" src="/js/CheckBox.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!--Title -->

            <!--Title end -->

            <!--Add  -->

            <!--Add end -->

            <!--Search -->
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
                            
		<asp:BoundField DataField="ProTypeID" HeaderText="ProTypeID" SortExpression="ProTypeID" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_1" HeaderText="A100_1" SortExpression="A100_1" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_2" HeaderText="A100_2" SortExpression="A100_2" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_3" HeaderText="A100_3" SortExpression="A100_3" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_4" HeaderText="A100_4" SortExpression="A100_4" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_5" HeaderText="A100_5" SortExpression="A100_5" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_6" HeaderText="A100_6" SortExpression="A100_6" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_7" HeaderText="A100_7" SortExpression="A100_7" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_8" HeaderText="A100_8" SortExpression="A100_8" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_9" HeaderText="A100_9" SortExpression="A100_9" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_10" HeaderText="A100_10" SortExpression="A100_10" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_11" HeaderText="A100_11" SortExpression="A100_11" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_12" HeaderText="A100_12" SortExpression="A100_12" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_13" HeaderText="A100_13" SortExpression="A100_13" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_14" HeaderText="A100_14" SortExpression="A100_14" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_15" HeaderText="A100_15" SortExpression="A100_15" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_16" HeaderText="A100_16" SortExpression="A100_16" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_17" HeaderText="A100_17" SortExpression="A100_17" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_18" HeaderText="A100_18" SortExpression="A100_18" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_19" HeaderText="A100_19" SortExpression="A100_19" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_20" HeaderText="A100_20" SortExpression="A100_20" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_21" HeaderText="A100_21" SortExpression="A100_21" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_22" HeaderText="A100_22" SortExpression="A100_22" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_23" HeaderText="A100_23" SortExpression="A100_23" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_24" HeaderText="A100_24" SortExpression="A100_24" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_25" HeaderText="A100_25" SortExpression="A100_25" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_26" HeaderText="A100_26" SortExpression="A100_26" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_27" HeaderText="A100_27" SortExpression="A100_27" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_28" HeaderText="A100_28" SortExpression="A100_28" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_29" HeaderText="A100_29" SortExpression="A100_29" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_30" HeaderText="A100_30" SortExpression="A100_30" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_31" HeaderText="A100_31" SortExpression="A100_31" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_32" HeaderText="A100_32" SortExpression="A100_32" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_33" HeaderText="A100_33" SortExpression="A100_33" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_34" HeaderText="A100_34" SortExpression="A100_34" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_35" HeaderText="A100_35" SortExpression="A100_35" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_36" HeaderText="A100_36" SortExpression="A100_36" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_37" HeaderText="A100_37" SortExpression="A100_37" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_38" HeaderText="A100_38" SortExpression="A100_38" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_39" HeaderText="A100_39" SortExpression="A100_39" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_40" HeaderText="A100_40" SortExpression="A100_40" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_41" HeaderText="A100_41" SortExpression="A100_41" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_42" HeaderText="A100_42" SortExpression="A100_42" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_43" HeaderText="A100_43" SortExpression="A100_43" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_44" HeaderText="A100_44" SortExpression="A100_44" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_45" HeaderText="A100_45" SortExpression="A100_45" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_46" HeaderText="A100_46" SortExpression="A100_46" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_47" HeaderText="A100_47" SortExpression="A100_47" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_48" HeaderText="A100_48" SortExpression="A100_48" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_49" HeaderText="A100_49" SortExpression="A100_49" ItemStyle-HorizontalAlign="Center"  /> 
		<asp:BoundField DataField="A100_50" HeaderText="A100_50" SortExpression="A100_50" ItemStyle-HorizontalAlign="Center"  /> 
                            
                            <asp:HyperLinkField HeaderText="详细" ControlStyle-Width="50" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Show.aspx?id={0}"
                                Text="详细"  />
                            <asp:HyperLinkField HeaderText="编辑" ControlStyle-Width="50" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Modify.aspx?id={0}"
                                Text="编辑"  />
                            <asp:TemplateField ControlStyle-Width="50" HeaderText="删除"   Visible="false"  >
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                         Text="删除"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
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
