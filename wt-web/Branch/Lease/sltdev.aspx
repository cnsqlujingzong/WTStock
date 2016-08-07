<%@ page language="C#"  CodeFile="sltdev.aspx.cs"     autoeventwireup="true" inherits="Branch_Lease_sltDev" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ѡ�����</title>
<link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/frame.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/page.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/tab.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div class="ftool">
    <div class="ftoolleft">
            <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
                <tr>
                <td>
                   <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="0">ģ����ѯ</asp:ListItem>
                    <asp:ListItem Value="6">������豸��ѯ</asp:ListItem>
                    <asp:ListItem Value="1">��������Ų�ѯ</asp:ListItem>
                    <asp:ListItem Value="2">��Ʒ�Ʋ�ѯ</asp:ListItem>
                    <asp:ListItem Value="3">������ѯ</asp:ListItem>
                    <asp:ListItem Value="4">���ͺŲ�ѯ</asp:ListItem>
                    <asp:ListItem Value="5">�����к�1��ѯ</asp:ListItem>
                    <asp:ListItem Value="-1">��ѯȫ��</asp:ListItem>
                </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="tbCon" runat="server" onkeydown="EnterTextBoxSch(event, this);" CssClass="pink" ToolTip="�����ѯ�ؼ���"></asp:TextBox>
                </td><td align="left">
                    <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" />
                    </td>
                <td align="right">
                    <input type="button" value="ȷ��" onclick="AddDev();" class="bt1" />
                </td>
                 </tr>
            </table>   
    </div>
    </div>
    <div id="cndiv" style="height:370px; width:478px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false">
        <Columns>
        <asp:BoundField HeaderText="ID" DataField="ID" />
        <asp:BoundField HeaderText="BillID" DataField="BillID" />
            <asp:TemplateField>
                <ItemTemplate>
                    <input id="cb<%#Eval("ID") %>" type="checkbox" class="cb1" onclick="cbone(this);"/>
                </ItemTemplate>
                <HeaderTemplate>
                    <input id="cball" type="checkbox" class="cb1" onclick="allcb();" title="ȫѡ/ȡ��ȫѡ"/>
                </HeaderTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="����豸" DataField="GoodsNO" />
            <asp:BoundField HeaderText="�������" DataField="DeviceNO" />
            <asp:BoundField HeaderText="Ʒ��" DataField="Brand" />
            <asp:BoundField HeaderText="���" DataField="Class" />
            <asp:BoundField HeaderText="�ͺ�" DataField="Model" />
            <asp:BoundField HeaderText="�������" DataField="DeviceNO" />
            <asp:BoundField HeaderText="���к�1" DataField="ProductSN1" />
            <asp:BoundField HeaderText="���к�2" DataField="ProductSN2" />
            <asp:BoundField HeaderText="��ע" DataField="Remark" />
        </Columns>
    </asp:GridView>
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
        <asp:HiddenField ID="hfIDList" runat="server" Value="-1" />
        <asp:HiddenField ID="hfreclist" runat="server" Value="-1" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
function AddDev()
{ 
    var tbgv=$("gvdata");
    var idlist="";
    if(tbgv)
    {
        for(i=1;i<tbgv.rows.length;i++)
        {
            var rid=tbgv.rows[i].id;
            if($("cb"+rid)&&$("cb"+rid).checked==true)
            idlist+=rid+",";
        }
    }
    idlist=idlist.replace(/(^[,\s]*)|([,\s]*$)/g,"");
    parent.iframeDialog.$("hfidlist").value=idlist;
    parent.iframeDialog.$("btnSltIDs").click();
    parent.CloseDialog1();
}
</script>
