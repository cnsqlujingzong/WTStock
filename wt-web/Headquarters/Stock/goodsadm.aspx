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
                <asp:Button ID="btnFsh" runat="server" Text="刷新" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnFsh_Click"/>
                <input id="btnNew" type="button" value="新建" class="bt1" onclick="NewGoods();" />
                <input id="btnMod" type="button" value="修改" class="bt1" onclick="ChkMod(620, 500,'Stock/GoodsMod.aspx','修改产品');" />
                <asp:Button ID="btnDel" runat="server" Text="删除" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkDelGds()==false) return false;" OnClick="btnDel_Click"/>
                <span style="display:none;">
                    <asp:Button ID="btnClr" runat="server" Text="保留选中" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                    <asp:Button ID="btnOrder" runat="server" Text="排序" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                </span>
            </td>
            </tr>
            </table>
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                    <input id="btnPrint" runat="server" type="button" value="打印" class="iprint" onclick="BatchPrint('TM');" />
                    <input id="btnprice" runat="server" type="button" class="bprice" value="批量调价" onclick="ChkpriceAsjustClass();" />
                    <input id="btnClass" runat="server" type="button" class="bclass" value="批量修改" onclick="ChkEditClass();" />
                    <input id="btnInput" runat="server" type="button" class="binput" value="导入" onclick="ChkInput();" />
                </td>
                <td>
                    <asp:Button ID="btnExcel" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" />
                </td>
                <td>
                    <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                        <asp:ListItem Value="0">模糊查询</asp:ListItem>
                        <asp:ListItem Value="1">按编号查询</asp:ListItem>
                        <asp:ListItem Value="2">按名称查询</asp:ListItem>
                        <asp:ListItem Value="3">按规格查询</asp:ListItem>
                        <asp:ListItem Value="4">按属性查询</asp:ListItem>
                        <asp:ListItem Value="5">按供应商查询</asp:ListItem>
                        <asp:ListItem Value="6">按品牌查询</asp:ListItem>
                        <asp:ListItem Value="7">按保修期查询</asp:ListItem>
                        <asp:ListItem Value="8">按默认仓库查询</asp:ListItem>
                        <asp:ListItem Value="9">按备注查询</asp:ListItem>
                        <asp:ListItem Value="10">按适用产品查询</asp:ListItem>
                        <asp:ListItem Value="-1">查询全部</asp:ListItem>
                    </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="tbCon" runat="server" CssClass="pink" ToolTip="输入查询关键字"></asp:TextBox>
            </td><td align="left">
                <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td></tr>
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
                    <input id="cball" type="checkbox" class="cb1" onclick="SltAllValue();" title="全选/取消全选"/>
                </HeaderTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="产品分类" DataField="ClassName" />
            <asp:BoundField HeaderText="产品编号" DataField="GoodsNO" />
            <asp:BoundField HeaderText="产品名称" DataField="_Name" />
            <asp:BoundField HeaderText="规格" DataField="Spec" />
            <asp:BoundField HeaderText="品牌" DataField="ProductBrand" />
            <asp:BoundField HeaderText="单位" DataField="Unit" />
            <asp:BoundField HeaderText="零售价" DataField="PriceDetail" />
            <asp:BoundField HeaderText="采购价" DataField="PriceCost" />
            <asp:BoundField HeaderText="内部价" DataField="PriceInner" />
            <asp:BoundField HeaderText="旧货价" DataField="PriceWholesale1" />
            <asp:BoundField HeaderText="替代价" DataField="PriceWholesale2" />
            <asp:BoundField HeaderText="列表价" DataField="PriceWholesale3" />
            <asp:BoundField HeaderText="保修期" DataField="MaintenancePeriod" />
            <asp:BoundField HeaderText="属性" DataField="Attr" />
              <asp:BoundField HeaderText="PCB" DataField="PCB" />
            <asp:BoundField HeaderText="适用产品" DataField="ForProducts" />
            <asp:BoundField HeaderText="成本模式" DataField="CostMode" />
            <asp:BoundField HeaderText="默认仓库" DataField="StockName" />
            <asp:BoundField HeaderText="供应商" DataField="Provider" />
            <asp:BoundField HeaderText="允许负库存" DataField="bStock" />
            <asp:BoundField HeaderText="有效期(天)" DataField="Valid" />
            <asp:BoundField HeaderText="增值产品" DataField="bIncrement" />
            <asp:BoundField HeaderText="条码" DataField="barCode" />
          
            <asp:BoundField HeaderText="自定义1" DataField="userdef1" />
            <asp:BoundField HeaderText="自定义2" DataField="userdef2" />
            <asp:BoundField HeaderText="自定义3" DataField="userdef3" />
            <asp:BoundField HeaderText="自定义4" DataField="userdef4" />
            <asp:BoundField HeaderText="自定义5" DataField="userdef5" />
            <asp:BoundField HeaderText="自定义6" DataField="userdef6" />
            <asp:BoundField HeaderText="停用" DataField="bStop" />
            <asp:BoundField HeaderText="备注" DataField="Remark" />
        </Columns>
    </asp:GridView>
      <%-- HeaderText="零售价" DataField="PriceDetail" />
        HeaderText="进货价" DataField="PriceCost" />
       HeaderText="内部价" DataField="PriceInner" />
         HeaderText="旧货价" DataField="PriceWholesale1" />
          HeaderText="替代价" DataField="PriceWholesale2" />
          HeaderText="列表价" DataField="PriceWholesale3" />--%>
    <table cellpadding="0" cellspacing="0" class="pages">
        <tr>
            <td><webdiyer:aspnetpager id="jsPager" runat="server" onpagechanged="jsPager_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="跳转:" /></td>
            <td style="padding-left:8px;"><asp:Label ID="lbPage" runat="server" ToolTip="当页显示数"></asp:Label></td>
            <td style="padding-left:8px;"><asp:Label ID="lbCountText" runat="server" ToolTip="总记录数" Text="总记录:"></asp:Label><asp:Label ID="lbCount" runat="server" ToolTip="总记录数"></asp:Label></td>
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
    parent.ShowDialog(620, 528,'Stock/InputGoods.aspx', '导入产品资料');
}
function NewGoods()
{
    var classid=$("hfClassID").value;
    parent.ShowDialog(620, 500, 'Stock/GoodsAdd.aspx?classid='+classid, '新建产品');
}
function ChkEditClass()
{
    var id=$("hfcbID").value;
    if(id=="")
        id=$("hfRecID").value;
    if(ChkSltValue()!=false)
    {
        parent.ShowDialog(340, 212,'Stock/EditGdsClass.aspx?id='+id,'批量修改产品信息');
    }
}
function ChkDelGds()
{
    if(ChkSltValue()!=false)
    {
        return confirm("确认要删除已选择的[产品信息]吗？");
    }else{return false;}
}
function Chkset()
{
    Chkwh3();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("产品目录");
}
function ChkpriceAsjustClass()
{
    var id=$("hfcbID").value;
    if(id=="")
        id=$("hfRecID").value;
    if(ChkSltValue()!=false)
    {
        parent.ShowDialog(470, 300,'Stock/GoodsPriceAdjust.aspx?id='+id,'批量调价');
    }
}
//批量打印
function BatchPrint(name)
{
    var id=$("hfcbID").value;
    if(id=="")
        id=$("hfRecID").value;
    
    if(id=="")
    {
        window.alert("请先勾选记录后再打印...!");
        return false;
    }
    
    if(id=="-1")
    {
        window.alert("请先选择一条记录后再打印...!");
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
