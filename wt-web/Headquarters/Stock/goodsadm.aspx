<%@ page language="C#"  CodeFile="goodsadm.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Stock_GoodsAdm" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/frame.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/page.css" />
    <style>
        #GridView1 th {
        padding :5px 10px;
        }
         #GridView1 td {
        padding :5px 0px;
        width:100px;
        }
        
    </style>
</head>
<body onload="Chkset();" onclick="parent.Sethidden1();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="ftool">
        <div class="ftoolleft">
         <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td>
                <asp:Button ID="btnFsh" runat="server" Text="ˢ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnFsh_Click"/>
                <input id="btnNew" type="button" value="�½�" class="bt1" onclick="NewGoods();" />
                <input id="btnMod" type="button" value="�޸�" class="bt1" onclick="ChkMod(620, 500,'Stock/GoodsMod.aspx','�޸Ĳ�Ʒ');" />
                <asp:Button ID="btnDel" runat="server" Text="ɾ��" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkDelGds()==false) return false;" OnClick="btnDel_Click"/>
                <span style="display:none;">
                    <asp:Button ID="btnClr" runat="server" Text="����ѡ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                    <asp:Button ID="btnOrder" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                </span>
            </td>
            </tr>
            </table>
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                    <input id="btnPrint" runat="server" type="button" value="��ӡ" class="iprint" onclick="BatchPrint('TM');" />
                    <input id="btnprice" runat="server" type="button" class="bprice" value="��������" onclick="ChkpriceAsjustClass();" />
                    <input id="btnClass" runat="server" type="button" class="bclass" value="�����޸�" onclick="ChkEditClass();" />
                    <input id="btnInput" runat="server" type="button" class="binput" value="����" onclick="ChkInput();" />
                </td>
                <td>
                    <asp:Button ID="btnExcel" runat="server" Text="����" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" />
                </td>
                <td>
                    <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                        <asp:ListItem Value="0">ģ����ѯ</asp:ListItem>
                        <asp:ListItem Value="1">����Ų�ѯ</asp:ListItem>
                        <asp:ListItem Value="2">�����Ʋ�ѯ</asp:ListItem>
                        <asp:ListItem Value="3">������ѯ</asp:ListItem>
                        <asp:ListItem Value="4">�����Բ�ѯ</asp:ListItem>
                        <asp:ListItem Value="5">����Ӧ�̲�ѯ</asp:ListItem>
                        <asp:ListItem Value="6">��Ʒ�Ʋ�ѯ</asp:ListItem>
                        <asp:ListItem Value="7">�������ڲ�ѯ</asp:ListItem>
                        <asp:ListItem Value="8">��Ĭ�ϲֿ��ѯ</asp:ListItem>
                        <asp:ListItem Value="9">����ע��ѯ</asp:ListItem>
                        <asp:ListItem Value="10">�����ò�Ʒ��ѯ</asp:ListItem>
                        <asp:ListItem Value="-1">��ѯȫ��</asp:ListItem>
                    </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="tbCon" runat="server" CssClass="pink" ToolTip="�����ѯ�ؼ���"></asp:TextBox>
            </td><td align="left">
                <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td></tr>
            </table>   
        </div>
        <div class="clearfloat"></div>
    </div>
    
    <div id="lndiv" class="lndiv" style="height:1px;">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:TreeView ID="tvgds" runat="server" ShowLines="True" OnSelectedNodeChanged="tvgds_SelectedNodeChanged" OnTreeNodeExpanded="tvgds_TreeNodeExpanded">
            <SelectedNodeStyle BackColor="#7d8abe" BorderColor="White" />
        </asp:TreeView>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="tvgds" EventName="SelectedNodeChanged" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div id="lncn" class="uw"></div>
    <div id="cndiv" style="float:left; height:1px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvgds" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvgds_RowDataBound" EnableViewState="false">
    
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="Flag" DataField="bStop" />
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:CheckBox ID="cb" runat="server" />
                </ItemTemplate>
                <HeaderTemplate>
                    <input id="cball" type="checkbox" class="cb1" onclick="SltAllValue();" title="ȫѡ/ȡ��ȫѡ"/>
                </HeaderTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="��Ʒ����" DataField="ClassName" />
            <asp:BoundField HeaderText="��Ʒ���" DataField="GoodsNO" />
            <asp:BoundField HeaderText="��Ʒ����" DataField="_Name" />
            <asp:BoundField HeaderText="���" DataField="Spec" />
            <asp:BoundField HeaderText="Ʒ��" DataField="ProductBrand" />
            <asp:BoundField HeaderText="��λ" DataField="Unit" />
            <asp:BoundField HeaderText="���ۼ�" DataField="PriceDetail" />
            <asp:BoundField HeaderText="�ɹ���" DataField="PriceCost" />
            <asp:BoundField HeaderText="�ڲ���" DataField="PriceInner" />
            <asp:BoundField HeaderText="�ɻ���" DataField="PriceWholesale1" />
            <asp:BoundField HeaderText="�����" DataField="PriceWholesale2" />
            <asp:BoundField HeaderText="�б��" DataField="PriceWholesale3" />
            <asp:BoundField HeaderText="������" DataField="MaintenancePeriod" />
            <asp:BoundField HeaderText="����" DataField="Attr" />
              <asp:BoundField HeaderText="PCB" DataField="PCB" />
            <asp:BoundField HeaderText="���ò�Ʒ" DataField="ForProducts" />
            <asp:BoundField HeaderText="�ɱ�ģʽ" DataField="CostMode" />
            <asp:BoundField HeaderText="Ĭ�ϲֿ�" DataField="StockName" />
            <asp:BoundField HeaderText="��Ӧ��" DataField="Provider" />
            <asp:BoundField HeaderText="�������" DataField="bStock" />
            <asp:BoundField HeaderText="��Ч��(��)" DataField="Valid" />
            <asp:BoundField HeaderText="��ֵ��Ʒ" DataField="bIncrement" />
            <asp:BoundField HeaderText="����" DataField="barCode" />
          
            <asp:BoundField HeaderText="�Զ���1" DataField="userdef1" />
            <asp:BoundField HeaderText="�Զ���2" DataField="userdef2" />
            <asp:BoundField HeaderText="�Զ���3" DataField="userdef3" />
            <asp:BoundField HeaderText="�Զ���4" DataField="userdef4" />
            <asp:BoundField HeaderText="�Զ���5" DataField="userdef5" />
            <asp:BoundField HeaderText="�Զ���6" DataField="userdef6" />
            <asp:BoundField HeaderText="ͣ��" DataField="bStop" />
            <asp:BoundField HeaderText="��ע" DataField="Remark" />
        </Columns>
    </asp:GridView>
      <%-- HeaderText="���ۼ�" DataField="PriceDetail" />
        HeaderText="������" DataField="PriceCost" />
       HeaderText="�ڲ���" DataField="PriceInner" />
         HeaderText="�ɻ���" DataField="PriceWholesale1" />
          HeaderText="�����" DataField="PriceWholesale2" />
          HeaderText="�б��" DataField="PriceWholesale3" />--%>
    <table cellpadding="0" cellspacing="0" class="pages">
        <tr>
            <td><webdiyer:aspnetpager id="jsPager" runat="server" onpagechanged="jsPager_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="��ת:" /></td>
            <td style="padding-left:8px;"><asp:Label ID="lbPage" runat="server" ToolTip="��ҳ��ʾ��"></asp:Label></td>
            <td style="padding-left:8px;"><asp:Label ID="lbCountText" runat="server" ToolTip="�ܼ�¼��" Text="�ܼ�¼:"></asp:Label><asp:Label ID="lbCount" runat="server" ToolTip="�ܼ�¼��"></asp:Label></td>
        </tr>
    </table>     
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
        <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
        <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
        <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
        <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
        <asp:HiddenField ID="hfSql" runat="server" />
        <asp:HiddenField ID="hfClass" runat="server" />
        <asp:HiddenField ID="hfClassID" runat="server" />
        <asp:HiddenField ID="hfTbTitle" runat="server" />
        <asp:HiddenField ID="hfTbField" runat="server" />
        <asp:HiddenField ID="hfPurCost" runat="server" Value="0" />
        <asp:HiddenField ID="hfPurProv" runat="server" Value="0" />
        <asp:HiddenField ID="hfcbID" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="tvgds" EventName="SelectedNodeChanged" />
    </Triggers>
    </asp:UpdatePanel>
        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional"  style="position:absolute; bottom:40px;">
            <ContentTemplate>
                <div style="display:none">
                    <asp:Button ID="btn_getdetail" runat="server" Text="Button" OnClick="btn_getdetail_Click" />
                 
                </div>
            
                <asp:Literal ID="lit_pdetail" runat="server"></asp:Literal>
               <asp:GridView ID="GridView1" runat="server"   BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="10" HorizontalAlign="Center" >
          
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#ffffff"  HorizontalAlign="Center" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
         
        </asp:GridView>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btn_getdetail" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
           <asp:HiddenField ID="hid_pid" runat="server" />
    </div>
          
    <div class="clearfloat"></div>
    <div class="fbom">  
    <div id="fbon" class="fbon">
    </div>
    </div>
       
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;
var isfocus=2;
function ChkID(id,m)
{
    ClrID(id);
    $("hid_pid").value = m;
    $("btn_getdetail").click();
}
function ChkInput()
{
    parent.ShowDialog(620, 528,'Stock/InputGoods.aspx', '�����Ʒ����');
}
function NewGoods()
{
    var classid=$("hfClassID").value;
    parent.ShowDialog(620, 500, 'Stock/GoodsAdd.aspx?classid='+classid, '�½���Ʒ');
}
function ChkEditClass()
{
    var id=$("hfcbID").value;
    if(id=="")
        id=$("hfRecID").value;
    if(ChkSltValue()!=false)
    {
        parent.ShowDialog(340, 212,'Stock/EditGdsClass.aspx?id='+id,'�����޸Ĳ�Ʒ��Ϣ');
    }
}
function ChkDelGds()
{
    if(ChkSltValue()!=false)
    {
        return confirm("ȷ��Ҫɾ����ѡ���[��Ʒ��Ϣ]��");
    }else{return false;}
}
function Chkset()
{
    Chkwh3();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("��ƷĿ¼");
}
function ChkpriceAsjustClass()
{
    var id=$("hfcbID").value;
    if(id=="")
        id=$("hfRecID").value;
    if(ChkSltValue()!=false)
    {
        parent.ShowDialog(470, 300,'Stock/GoodsPriceAdjust.aspx?id='+id,'��������');
    }
}
//������ӡ
function BatchPrint(name)
{
    var id=$("hfcbID").value;
    if(id=="")
        id=$("hfRecID").value;
    
    if(id=="")
    {
        window.alert("���ȹ�ѡ��¼���ٴ�ӡ...!");
        return false;
    }
    
    if(id=="-1")
    {
        window.alert("����ѡ��һ����¼���ٴ�ӡ...!");
        return false;
    } 
    else
    {
        var w=(window.screen.width-750)/2;
        var num=Math.round(Math.random()*10000);
        window.open("../../Headquarters/Print/interface_print.aspx?type=Print&obj="+name+"&id="+id+"&a="+num,"","width=750,height=580,toolbar=no,left="+w+",top=20,location=no,directories=yes,status=yes,menubar=yes,resizable=yes,scrollbars=yes");
    }
}

</script>
