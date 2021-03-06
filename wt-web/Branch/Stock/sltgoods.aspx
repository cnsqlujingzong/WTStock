<%@ page language="C#"  CodeFile="sltgoods.aspx.cs"     autoeventwireup="true" inherits="Branch_Stock_SltGoods" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/frame.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/page.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/tab.css" />
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
                        <asp:ListItem Value="-1">查询全部</asp:ListItem>
                    </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="tbCon" runat="server" onkeydown="EnterTextBoxSch(event, this);" CssClass="pink" ToolTip="输入查询关键字"></asp:TextBox>
            </td><td align="left">
                <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" />
                <input id="btnNew" type="button" value="新建" class="bt1" style="<%=bGA==true?"":"display:none" %>" onclick="parent.ShowDialog1(620, 425, 'Stock/GoodsAdd.aspx?f=1', '新建产品');"/></td>
             </tr>
            </table>   
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td>
                <span style="display:none;">
                    <asp:Button ID="btnClr" runat="server" Text="保留选中" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                </span>
            </td>
            <td style="padding-right:80px;">
                <input id="btnAdd" type="button" value="确定" class="bt1" onclick="ChkSltList();"/>
            </td>
            </tr>
            </table>
        </div>
        <div class="clearfloat"></div>
    </div>
    
    <div id="lndiv" class="lndiv" style="height:480px">
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
    <div id="lncn" class="uw" style="height:480px"></div>
    <div id="cndiv" style="float:left;height:360px;width:635px;">
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
                    <input id="cball" type="checkbox" class="cb1" onclick="allcb();" title="全选/取消全选"/>
                </HeaderTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="产品分类" DataField="ClassName" />
            <asp:BoundField HeaderText="产品编号" DataField="GoodsNO" />
            <asp:BoundField HeaderText="名称" DataField="_Name" />
            <asp:BoundField HeaderText="规格" DataField="Spec" />
            <asp:BoundField HeaderText="品牌" DataField="ProductBrand" />
            <asp:BoundField HeaderText="单位" DataField="Unit" />
            <asp:BoundField HeaderText="零售价" DataField="PriceDetail" />
            <asp:BoundField HeaderText="进货价" DataField="PriceCost" />
            <asp:BoundField HeaderText="内部价" DataField="PriceInner" />
            <asp:BoundField HeaderText="批发价1" DataField="PriceWholesale1" />
            <asp:BoundField HeaderText="批发价2" DataField="PriceWholesale2" />
            <asp:BoundField HeaderText="批发价3" DataField="PriceWholesale3" />
            <asp:BoundField HeaderText="保修期" DataField="MaintenancePeriod" />
            <asp:BoundField HeaderText="属性" DataField="Attr" />
            <asp:BoundField HeaderText="供应商" DataField="Provider" />
            <asp:BoundField HeaderText="允许负库存" DataField="bStock" />
            <asp:BoundField HeaderText="成本模式" DataField="CostMode" />
            <asp:BoundField HeaderText="有效期(天)" DataField="Valid" />
            <asp:BoundField HeaderText="增值产品" DataField="bIncrement" />
            <asp:BoundField HeaderText="条码" DataField="barCode" />
            <asp:BoundField HeaderText="备注" DataField="Remark" />
        </Columns>
    </asp:GridView>
    <table cellpadding="0" cellspacing="0" class="pages">
        <tr>
            <td><webdiyer:aspnetpager id="jsPager" runat="server" onpagechanged="jsPager_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="跳转:" /></td>
            <td style="padding-left:8px;"><asp:Label ID="lbPage" runat="server" ToolTip="当页显示数"></asp:Label></td>
            <td style="padding-left:8px;"><asp:Label ID="lbCount" runat="server" ToolTip="总记录数"></asp:Label></td>
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
        <asp:AsyncPostBackTrigger ControlID="tvgds" EventName="SelectedNodeChanged" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div id="Div1" style="float:left;height:120px;width:635px;">
        <div class="ftool2">
            <div id="mytabs" style="padding-left:2px;">
                <span id="tabs_l1" class="tabs_activeleft"></span>
                <span id="tabs1" class="tabs_active" >分仓库存</span>
                <span id="tabs_r1" class="tabs_activeright"></span>
            </div>
        </div>
        <div class="cndiv2" id="cndiv2" style="height:90px;width:635px;">
        <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView1_RowDataBound"  EnableViewState="false">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="仓库" DataField="StockName" />
                    <asp:BoundField HeaderText="属性" DataField="Reject" />
                    <asp:BoundField HeaderText="库存" DataField="Stock" />
                    <asp:BoundField HeaderText="仓位" DataField="StockLocName" />
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
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
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
    var list=document.getElementById("hfreclist").value;
    
    if(list=="")
        list=document.getElementById("hfRecID").value;
        
    if(list==""||list=="-1")
    {
        alert("操作失败！请选择后操作.");return false;
    }else{
    try{
     if(<%=Str_Ifd %>=="1")
     {
        parent.<%=Str_Fid %>.$("hfreclist").value=list;
        if(<%=Str_Flag %>=="2")
            parent.<%=Str_Fid %>.document.getElementById("btnId").click();
        else
            parent.<%=Str_Fid %>.document.getElementById("btnId1").click();
      }else
      {
         var gdsno=parent.<%=Str_Fid %>.$("tbGoodsNO");
         if(gdsno!=null)
            gdsno.value="";
         parent.<%=Str_Fid %>.$("hfGoodsID").value=document.getElementById("hfRecID").value;
         parent.<%=Str_Fid %>.document.getElementById("btngetgds").click();
      }
    }catch(e){alert("系统错误！请刷新后重试");}
    parent.CloseDialog<%=Str_F %>();
    }
}
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog<%=Str_F %>();}catch(e){}}}
</script>
