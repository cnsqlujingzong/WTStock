<%@ page language="C#"  CodeFile="servicescall.aspx.cs"     autoeventwireup="true" inherits="Web_ServicesCall" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="public/css/mysub.css" type="text/css"/>
    <link rel="stylesheet" href="public/css/page.css" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
    <div class="item"><span style="padding-right:30px;">���޻ط�</span><span id="span_info" style="display:none;"></span></div>
    <div class="tool">
        <table cellpadding="0" cellspacing="0" border="0" class="tb2">
            <tr>
                <td>
                    <asp:DropDownList ID="ddlkey" runat="server" CssClass="slt1">
                        <asp:ListItem Value="ProductBrand">=��Ʒ��=</asp:ListItem>
                        <asp:ListItem Value="ProductClass">=�����=</asp:ListItem>
                        <asp:ListItem Value="ProductName">=���ͺ�=</asp:ListItem>
                        <asp:ListItem Value="ProductSN1">=�����к�=</asp:ListItem>
                        <asp:ListItem Value="curStatus">=����ǰ״̬=</asp:ListItem>
                        <asp:ListItem Value="-1">=��ѯȫ��=</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="tbcon" runat="server" CssClass="in1"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnsch" runat="server" Text="�� ѯ" CssClass="bt1 bt3" OnClick="btnsch_Click" OnClientClick="cInfo();"/>
                </td>
                <td style=" padding-right:5px;"></td>
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
                <asp:BoundField HeaderText="RecID" DataField="RecID" />
                <asp:BoundField HeaderText="����" DataField="ID" />
                <asp:BoundField HeaderText="����ʱ��" DataField="Time_TakeOver" HtmlEncode="false" DataFormatString="{0:yyyy-MM-dd}" />
                <asp:BoundField HeaderText="��ǰ״̬" DataField="curStatus" />
                <asp:BoundField HeaderText="�ͺ�" DataField="ProductName" />
                <asp:BoundField HeaderText="Ʒ��" DataField="ProductBrand" />
                <asp:BoundField HeaderText="���" DataField="ProductClass" />
                <asp:BoundField HeaderText="���к�" DataField="ProductSN1" />
                
                <asp:TemplateField HeaderText="����" HeaderStyle-Width="105"></asp:TemplateField>
                
            </Columns>
        </asp:GridView>
        
        <asp:HiddenField ID="hfrecid" runat="server" />
        <asp:HiddenField ID="hfreclist" runat="server" />
            <asp:HiddenField ID="hfcusid" runat="server" />
        
        <div id="d_page" runat="server">
        <table cellpadding="0" cellspacing="0" style="width:100%;">
            <tr>
                <td>ѡ��: <a href="javascript:void(0);" onclick="allcbslt(true);">ȫѡ</a>  <a href="javascript:void(0);" onclick="allcbslt(false);">��ѡ</a></td>
                <td align="right" style=" padding-right:5px;">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td><webdiyer:aspnetpager id="jsPager" runat="server" onpagechanged="jsPager_PageChanged"  CssClass="tdPage"  ShowInputBox="Never" /></td>
                            <td style="padding-left:8px;"><asp:Label ID="lbPage" runat="server" ToolTip="��ҳ��ʾ��"></asp:Label></td>
                            <td style="padding-left:8px;"><asp:Label ID="lbCount" runat="server" ToolTip="�ܼ�¼��"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        </div>
        <div id="d_empty" runat="server"><p class="p1" runat="server" id="p1">����Ӧ�ķ���!</p></div>
        
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
