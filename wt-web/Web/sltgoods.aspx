<%@ page language="C#"  CodeFile="sltgoods.aspx.cs"     autoeventwireup="true" inherits="Web_SltGoods" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link rel="Stylesheet" type="text/css" href="../Public/Style/sub.css" />
<link rel="Stylesheet" type="text/css" href="../Public/Style/frame.css" />
<link rel="Stylesheet" type="text/css" href="../Public/Style/page.css" />
<link rel="Stylesheet" type="text/css" href="../Public/Style/tab.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   <div class="ftool">
        <div class="ftoolleft">
        <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                   <asp:DropDownList ID="ddlKey" runat="server" onchange="document.getElementById('tbCon').focus();">
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
                        <asp:ListItem Value="-1">��ѯȫ��</asp:ListItem>
                    </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="tbCon" runat="server" onkeydown="EnterTextBoxSch(event, this);" CssClass="pink" ToolTip="�����ѯ�ؼ���"></asp:TextBox>
            </td><td align="left">
                <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" />
                <input  style="display:none;"id="btnNew" type="button" value="�½�" class="bt1" onclick="parent.ShowDialog1(620, 425, 'Stock/GoodsAdd.aspx?f=1', '�½���Ʒ');"/>
                </td>
                <td>
                    <input id="btnAdd" type="button" value="ȷ��" class="bt1" onclick="ChkValue();"/>
                </td>
             </tr>
            </table>   
        </div>
        <div class="ftoolright" style="display:none;">
            <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td>
                <span style="display:none;">
                    <asp:Button ID="btnClr" runat="server" Text="����ѡ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                </span>
            </td>
            <td style="padding-right:80px;">
                
            </td>
            </tr>
            </table>
        </div>
        <div class="clearfloat"></div>
    </div>
    <div id="lndiv" class="lndiv" style="height:1px;"></div>
    <div id="cndiv" style="float:left;height:385px;width:790px;overflow:auto;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvgds" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvgds_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="cb" runat="server" />
                </ItemTemplate>
                <HeaderTemplate>
                    <input id="cball" type="checkbox" class="cb1" onclick="allcb();" title="ȫѡ/ȡ��ȫѡ"/>
                </HeaderTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="��Ʒ����" DataField="ClassName" />
            <asp:BoundField HeaderText="��Ʒ���" DataField="GoodsNO" />
            <asp:BoundField HeaderText="����" DataField="_Name" />
            <asp:BoundField HeaderText="���" DataField="Spec" />
            <asp:BoundField HeaderText="Ʒ��" DataField="ProductBrand" />
            <asp:BoundField HeaderText="��λ" DataField="Unit" />
            <asp:BoundField HeaderText="���ۼ�" DataField="PriceDetail" />
            <asp:BoundField HeaderText="������" DataField="MaintenancePeriod" />
            <asp:BoundField HeaderText="����" DataField="Attr" />
            <asp:BoundField HeaderText="��ע" DataField="Remark" />
            <asp:BoundField HeaderText="ͼƬ��Ϣ" DataField="PicPath" />
        </Columns>
    </asp:GridView>
    <table cellpadding="0" cellspacing="0" class="pages">
        <tr>
            <td><webdiyer:aspnetpager id="jsPager" runat="server" onpagechanged="jsPager_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="��ת:" /></td>
            <td style="padding-left:8px;"><asp:Label ID="lbPage" runat="server" ToolTip="��ҳ��ʾ��"></asp:Label></td>
            <td style="padding-left:8px;"><asp:Label ID="lbCount" runat="server" ToolTip="�ܼ�¼��"></asp:Label></td>
        </tr>
    </table>
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
        <asp:HiddenField ID="hfreclist" runat="server" />
        <asp:HiddenField ID="hfClass" runat="server" />
        <asp:HiddenField ID="hfClassID" runat="server" />
        <asp:HiddenField ID="hfPurCost" runat="server" Value="0" />
        <asp:HiddenField ID="hfPurProv" runat="server" Value="0" />
        <asp:HiddenField ID="hfStock" runat="server" Value="0" />
        <asp:HiddenField ID="hfStockR" runat="server" Value="0" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div id="Div1" style="float:left;height:120px;width:635px;display:none;">
        <div class="ftool2">
            <div id="mytabs" style="padding-left:2px;">
                <span id="tabs_l1" class="tabs_activeleft"></span>
                <span id="tabs1" class="tabs_active" >�ֲֿ��</span>
                <span id="tabs_r1" class="tabs_activeright"></span>
            </div>
        </div>
        <div class="cndiv2" id="cndiv2" style="height:90px;width:635px;">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView1_RowDataBound"  EnableViewState="false">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="�ֿ�" DataField="StockName" />
                    <asp:BoundField HeaderText="����" DataField="Reject" />
                    <asp:BoundField HeaderText="���" DataField="Stock" />
                    <asp:BoundField HeaderText="��λ" DataField="StockLocName" />
                </Columns>
            </asp:GridView>
            <asp:HiddenField ID="hfRecID2" runat="server" Value="-1" />
            <span style="display:none;">
            <asp:Button ID="btnStockDept" runat="server" Text="StockDept" UseSubmitBehavior="false" OnClick="btnStockDept_Click" /></span>
            </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnStockDept" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
    </div>
    <div class="clearfloat"></div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
var isfocus=2;
function ChkID(id)
{
    ClrID(id);
     $("btnStockDept").click();
}
function ChkID2(id)
{
    ClrID2(id);
}
function ChkSltList()
{
    
//    var list=document.getElementById("hfreclist").value;
//    
//    if(list=="")
//        list=document.getElementById("hfRecID").value;
//        
//    if(list==""||list=="-1")
//    {
//        alert("����ʧ�ܣ���ѡ������.");return false;
//    }else{
//    try{
//     if(<%=Str_Ifd %>=="1")
//     {
//        parent.<%=Str_Fid %>.$("hfreclist").value=list;
//        if(<%=Str_Flag %>=="2")
//            parent.<%=Str_Fid %>.document.getElementById("btnId").click();
//        else
//            parent.<%=Str_Fid %>.document.getElementById("btnId1").click();
//      }else
//      {
//         var gdsno=parent.<%=Str_Fid %>.$("tbGoodsNO");
//         if(gdsno!=null)
//            gdsno.value="";
//         parent.<%=Str_Fid %>.$("hfGoodsID").value=document.getElementById("hfRecID").value;
//         parent.<%=Str_Fid %>.document.getElementById("btngetgds").click();
//      }
//    }catch(e){alert("ϵͳ������ˢ�º�����");}
//    parent.CloseDialog<%=Str_F %>();
//    }
}

function ChkValue()
{
    var tb=document.getElementById("gvgds");
    var ids="";
    for(i=1;i<tb.rows.length;i++)
    {
        var chk=tb.rows[i].getElementsByTagName("input")[0];
        if(null!=chk&&chk.checked==true)
        {
            var id=chk.id.replace(/^cb(\d+)$/,"$1");
            ids+=id+",";
        }
    }
    if(ids=="")
    {
        alert("�빴ѡ��¼��");
        return;
    }
    ids=ids.replace(/(^,*)|(,*$)/g,"");
    window.opener.document.getElementById("hfGoodsNO").value = ids;
    window.opener.document.getElementById("btnAddGoods").click();
    window.close();
}
//document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog<%=Str_F %>();}catch(e){}}}
</script>
