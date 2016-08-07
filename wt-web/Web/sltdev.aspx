<%@ page language="C#"  CodeFile="sltdev.aspx.cs"     autoeventwireup="true" inherits="Web_SltDev" theme="themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>ѡ���������</title>
    <link rel="Stylesheet" type="text/css" href="../Public/Style/sub.css" />
    <link rel="Stylesheet" type="text/css" href="../Public/Style/page.css" />
    
    <style type="text/css">
        .tb3 td{ padding-left:3px; color:#fff;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="tool" style="height:28px;">
        <table cellpadding="0" cellspacing="0" border="0" class="tb3">
            <tr>
                <td>
                    <asp:DropDownList ID="ddlkey" runat="server" CssClass="slt1">
                    <asp:ListItem Value="ProductBrand">=��Ʒ�Ʋ�ѯ=</asp:ListItem>
                    <asp:ListItem Value="ProductClass">=������ѯ=</asp:ListItem>
                    <asp:ListItem Value="ProductModel">=���ͺŲ�ѯ=</asp:ListItem>
                    <asp:ListItem Value="ProductSN1">=�����кŲ�ѯ=</asp:ListItem>
                    <asp:ListItem Value="DeviceNO">=��������Ų�ѯ=</asp:ListItem>
                    <asp:ListItem Value="-1">=��ѯȫ��=</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="tbcon" runat="server" CssClass="in1"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnsch" runat="server" Text="�� ѯ" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnsch_Click"/>
                    
                </td>
                <td style="width:80px;"></td>
                <td>
                    <input id="btnAdd" type="button" value="ȷ��" class="bt1" onclick="ChkPass();" /></td>
            </tr>
        </table>
        </div>
        <div style="padding-left:2px;">
        <div class="fdiv">
        <div class="sdiv" style="height:470px; width:796px; overflow:auto; background:#ffffff; padding:0px;">
        <asp:GridView ID="GridView1" runat="server" SkinID="gv1" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" EnableViewState="false">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="�������" DataField="DeviceNo" />
                <asp:BoundField HeaderText="���" DataField="ProductClass" />
                <asp:BoundField HeaderText="Ʒ��" DataField="ProductBrand" />
                <asp:BoundField HeaderText="�ͺ�" DataField="ProductModel" />
                <asp:BoundField HeaderText="���к�1" DataField="ProductSN1" />
                <asp:BoundField HeaderText="���к�2" DataField="ProductSN2" />
                <asp:BoundField HeaderText="������" DataField="MaintenancePeriod" />
                <asp:BoundField HeaderText="����״̬" DataField="Warranty" />
                <asp:BoundField HeaderText="���" DataField="ProductAspect" />
                <asp:BoundField HeaderText="����ʱ��" DataField="BuyDate" />
                <asp:BoundField HeaderText="������" DataField="BuyFrom" />
                <asp:BoundField HeaderText="����Ʊ" DataField="BuyInvoice" />
                <asp:BoundField HeaderText="ά�޴�" DataField="RepairTimes" />
                <asp:BoundField HeaderText="���ά��ʱ��" DataField="Repairlately"/>
            </Columns>
        </asp:GridView>
        <div id="d_page" runat="server">
        <table cellpadding="0" cellspacing="0" style="width:100%;">
            <tr>
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
        <div id="d_empty" runat="server"><p class="p1" runat="server" id="p1">����Ӧ�Ļ�������!</p></div>
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
        <asp:HiddenField ID="hfcusid" runat="server" />
        <asp:HiddenField ID="hfBrand" runat="server" Value="" />
        <asp:HiddenField ID="hfDeviceNO" runat="server" Value="" />
        <asp:HiddenField ID="hfClass" runat="server" Value="" />
        <asp:HiddenField ID="hfName" runat="server" Value="" />
        <asp:HiddenField ID="hfSN1" runat="server" Value="" />
        <asp:HiddenField ID="hfSN2" runat="server" Value="" />
        <asp:HiddenField ID="hfAss" runat="server" Value="" />
        <asp:HiddenField ID="hfBuyDate" runat="server" Value="" />
        <asp:HiddenField ID="hfBuyFrom" runat="server" Value="" />
        <asp:HiddenField ID="hfNO" runat="server" Value="" />
        <asp:HiddenField ID="hfWarr" runat="server" Value="" />
        </div>
        </div>
        </div>
        </ContentTemplate>
        </asp:UpdatePanel>
        <div style=" height:5px; font-size:0px;"></div>
        <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td><span class="si2">˫����¼����ѡ��</span></td>
        </tr>
        </table>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript">
function ChkID(id)
{
    ClrID(id);
}

function ChkValue(cls,brand,name,sn1,sn2,ass,buydate,buyfrom,no,warr,deviceno)
{
    $("hfClass").value=cls;
    $("hfBrand").value=brand;
    $("hfName").value=name;
    $("hfSN1").value=sn1;
    $("hfSN2").value=sn2;
    $("hfAss").value=ass;
    $("hfBuyDate").value=buydate;
    $("hfBuyFrom").value=buyfrom;
    $("hfNO").value=no;
    $("hfWarr").value=warr;
    $("hfDeviceNO").value=deviceno;
}

function ChkPass()
{
    if($("hfRecID").value==""||$("hfRecID").value=="-1")
    {
        alert("����ѡ��һ����¼�������");
        return;
    }
    opener.$("tbClass").value=$("hfClass").value;
    opener.$("tbBrand").value=$("hfBrand").value;
    opener.$("tbModel").value=$("hfName").value;
    var ddlgradelevel=opener.$("ddlBrand");
    if($("hfBrand").value!=ddlgradelevel.options[ddlgradelevel.selectedIndex].text)
    {
        for(var i=0;i<ddlgradelevel.options.length;i++)
        {
            if(ddlgradelevel.options[i].value!="0")
            {
                if(ddlgradelevel.options[i].text==$("hfBrand").value)
                {
                    ddlgradelevel.options[i].selected=true;
                    bnull=false;
                    break;
                }
            }
        }
        if(bnull)
        {
            for(var i=0;i<ddlgradelevel.options.length;i++)
            {
                if(ddlgradelevel.options[i].text=="")
                {
                    ddlgradelevel.options[i].selected=true;
                    break;
                }
            }
        }
    }
    ddlgradelevel=opener.$("ddlClass");
    if($("hfClass").value!=ddlgradelevel.options[ddlgradelevel.selectedIndex].text)
    {
        for(var i=0;i<ddlgradelevel.options.length;i++)
        {
            if(ddlgradelevel.options[i].value!="0")
            {
                if(ddlgradelevel.options[i].text==$("hfClass").value)
                {
                    ddlgradelevel.options[i].selected=true;
                    bnull=false;
                    break;
                }
            }
        }
        if(bnull)
        {
            for(var i=0;i<ddlgradelevel.options.length;i++)
            {
                if(ddlgradelevel.options[i].text=="")
                {
                    ddlgradelevel.options[i].selected=true;
                    break;
                }
            }
        }
    }
    
    ddlgradelevel=opener.$("ddlModel");
    if($("hfName").value!=ddlgradelevel.options[ddlgradelevel.selectedIndex].text)
    {
        for(var i=0;i<ddlgradelevel.options.length;i++)
        {
            if(ddlgradelevel.options[i].value!="0")
            {
                if(ddlgradelevel.options[i].text==$("hfName").value)
                {
                    ddlgradelevel.options[i].selected=true;
                    bnull=false;
                    break;
                }
            }
        }
        if(bnull)
        {
            for(var i=0;i<ddlgradelevel.options.length;i++)
            {
                if(ddlgradelevel.options[i].text=="")
                {
                    ddlgradelevel.options[i].selected=true;
                    break;
                }
            }
        }
    }
    opener.$("tbSN1").value=$("hfSN1").value;
    opener.$("tbSN2").value=$("hfSN2").value;
    opener.$("tbAspect").value=$("hfAss").value;
    opener.$("tbBuyTime").value=$("hfBuyDate").value;
    opener.$("tbBuyFrom").value=$("hfBuyFrom").value;
    opener.$("tbBuyInvoice").value=$("hfNO").value;
    opener.$("tbDeviceNO").value=$("hfDeviceNO").value;
    ddlgradelevel=opener.$("ddlRepStatus");
    if($("hfWarr").value!=ddlgradelevel.options[ddlgradelevel.selectedIndex].text)
    {
        for(var i=0;i<ddlgradelevel.options.length;i++)
        {
            if(ddlgradelevel.options[i].value!="0")
            {
                if(ddlgradelevel.options[i].text==$("hfWarr").value)
                {
                    ddlgradelevel.options[i].selected=true;
                    bnull=false;
                    break;
                }
            }
        }
        if(bnull)
        {
            for(var i=0;i<ddlgradelevel.options.length;i++)
            {
                if(ddlgradelevel.options[i].text=="")
                {
                    ddlgradelevel.options[i].selected=true;
                    break;
                }
            }
        }
    }
    
    window.close();
}
</script>
