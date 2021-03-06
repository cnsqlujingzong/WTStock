<%@ page language="C#"  CodeFile="device.aspx.cs"     autoeventwireup="true" inherits="Web_Device" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="public/css/mysub.css" type="text/css"/>
    <link rel="stylesheet" href="public/css/page.css" type="text/css"/>
    <link rel="Stylesheet" type="text/css" href="../Public/Style/sub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
    <div class="item"><span style="padding-right:30px;">我的机器档案</span><span id="span_info" style="display:none;"></span></div>
    <div class="tool">
        <table cellpadding="0" cellspacing="0" border="0" class="tb2">
            <tr>
                <td>
                    <asp:DropDownList ID="ddlkey" runat="server" CssClass="slt1">
                    <asp:ListItem Value="ProductBrand">=按品牌查询=</asp:ListItem>
                    <asp:ListItem Value="ProductClass">=按类别查询=</asp:ListItem>
                    <asp:ListItem Value="ProductModel">=按型号查询=</asp:ListItem>
                    <asp:ListItem Value="ProductSN1">=按序列号查询=</asp:ListItem>
                    <asp:ListItem Value="DeviceNO">=按机器编号查询=</asp:ListItem>
                    <asp:ListItem Value="LinkMan">=按联系人查询=</asp:ListItem>
                    <asp:ListItem Value="CusDept">=按所属部门查询=</asp:ListItem>
                    <asp:ListItem Value="-1">=查询全部=</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="tbcon" runat="server" CssClass="in1"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnsch" runat="server" Text="查 询" CssClass="bt1 bt3" OnClick="btnsch_Click" OnClientClick="cInfo();"/>
                </td>
                <td style=" padding-right:5px;">
                    <asp:Button ID="btnExcel" runat="server" Text="导出" CssClass="bexcel"  OnClick="btnExcel_Click" />
                </td>
            </tr>
        </table>
    </div>
    
    <div class="list" id="list">
    
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" EnableViewState="false" GridLines="None" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderStyle-Width="20">
                    <HeaderTemplate>
                        <input id="cball" type="checkbox" class="cb1" onclick="allcb();"/>
                    </HeaderTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
                <asp:BoundField HeaderText="所属部门" DataField="CusDept" />
                <asp:BoundField HeaderText="机器编号" DataField="DeviceNO" />
                <asp:BoundField HeaderText="类别" DataField="ProductClass" />
                <asp:BoundField HeaderText="品牌" DataField="ProductBrand" />
                <asp:BoundField HeaderText="型号" DataField="ProductModel" />
                <asp:BoundField HeaderText="序列号1" DataField="ProductSN1" />
                <asp:BoundField HeaderText="保修情况" DataField="Warranty" />
                <asp:BoundField HeaderText="维修次" DataField="RepairTimes" />
                <asp:TemplateField HeaderText="操作"></asp:TemplateField>
            </Columns>
        </asp:GridView>
        
        <asp:HiddenField ID="hfrecid" runat="server" />
        <asp:HiddenField ID="hfreclist" runat="server" />
            <asp:HiddenField ID="hfcusid" runat="server" />
            <asp:HiddenField ID="hfSql" runat="server" Value="-1" />
        
        <div id="d_page" runat="server">
        <table cellpadding="0" cellspacing="0" style="width:100%;">
            <tr>
                <td>选择: <a href="javascript:void(0);" onclick="allcbslt(true);">全选</a>  <a href="javascript:void(0);" onclick="allcbslt(false);">不选</a></td>
                <td align="right" style=" padding-right:5px;">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td><webdiyer:aspnetpager id="jsPager" runat="server" onpagechanged="jsPager_PageChanged"  CssClass="tdPage"  ShowInputBox="Never" /></td>
                            <td style="padding-left:8px;"><asp:Label ID="lbPage" runat="server" ToolTip="当页显示数"></asp:Label></td>
                            <td style="padding-left:8px;"><asp:Label ID="lbCount" runat="server" ToolTip="总记录数"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        </div>
        <div id="d_empty" runat="server"><p class="p1" runat="server" id="p1">无相应的机器档案!</p></div>
        
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnsch" EventName="Click" />
        </Triggers>       
        </asp:UpdatePanel>
        
    </div>
    
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="public/script/common.js"></script>
<script language="javascript" type="text/javascript" src="public/script/sub.js"></script>
