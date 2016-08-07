<%@ page language="C#"  CodeFile="sltsn.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Stock_SltSN" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/frame.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/page.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   <div class="ftool">
        <div class="ftoolleft">
        <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                   <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="SN">按序列号查询</asp:ListItem>
                    <asp:ListItem Value="GoodsNO">按产品编号查询</asp:ListItem>
                    <asp:ListItem Value="_Name">按产品名称查询</asp:ListItem>
                    <asp:ListItem Value="Spec">按产品规格查询</asp:ListItem>
                    <asp:ListItem Value="Brand">按产品品牌查询</asp:ListItem>
                    <asp:ListItem Value="BillID">按入库单号查询</asp:ListItem>
                    <asp:ListItem Value="_Date">按入库日期查询</asp:ListItem>
                    <asp:ListItem Value="Type">按入库业务类别查询</asp:ListItem>
                    <asp:ListItem Value="-1">查询全部</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="tbCon" runat="server" onkeydown="EnterTextBoxSch(event, this);" CssClass="pink" ToolTip="输入查询关键字"></asp:TextBox>
            </td><td align="left">
                <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnSch_Click" /></td>
             </tr>
            </table>   
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td>
                <span style="display:none;">
                    <asp:Button ID="btnClr" runat="server" Text="保留选中" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                    <asp:Button ID="btnOrder" runat="server" Text="排序" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                </span>
            </td>
            <td style="padding-right:80px;">
                <input id="btnAdd" type="button" value="确定" class="bt1" onclick="SltBill();"/>
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
    <div id="cndiv" style="float:left;height:480px;width:635px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false">
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
            <asp:BoundField HeaderText="序列号" DataField="SN" />
            <asp:BoundField HeaderText="产品编号" DataField="GoodsNO" />
            <asp:BoundField HeaderText="名称" DataField="_Name" />
            <asp:BoundField HeaderText="规格" DataField="Spec" />
            <asp:BoundField HeaderText="品牌" DataField="Brand" />
            <asp:BoundField HeaderText="所属仓库" DataField="StockName" />
            <asp:BoundField HeaderText="仓库属性" DataField="Reject" />
            <asp:BoundField HeaderText="仓位" DataField="StockLocName" />
            <asp:BoundField HeaderText="入库价" DataField="Price" />
            <asp:BoundField HeaderText="仓库均价" DataField="CostPrice" />
            <asp:BoundField HeaderText="入库单号" DataField="BillID" />
            <asp:BoundField HeaderText="入库日期" DataField="_Date" />
            <asp:BoundField HeaderText="入库业务类别" DataField="Type" />
            <asp:BoundField HeaderText="入库业务单号" DataField="OperationID" />
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
        <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
        <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
        <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
        <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
        <asp:HiddenField ID="hfSql" runat="server" />
        <asp:HiddenField ID="hfreclist" runat="server" />
        <asp:HiddenField ID="hfClass" runat="server" />
        <asp:HiddenField ID="hfClassID" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="tvgds" EventName="SelectedNodeChanged" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
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
}

function SltBill()
{
    var list=document.getElementById("hfreclist").value;
    if(list=="")
        list=document.getElementById("hfRecID").value;
        
    if(list==""||list=="-1")
    {
        alert("操作失败！请选择后操作.");return false;
    }else{
    try{
      if("<%=Str_Cls %>"=="")
      {
        parent.<%=Str_Fid %>.document.getElementById("hfreclist").value=list;
        parent.<%=Str_Fid %>.document.getElementById("btnId").click(); 
        
        parent.CloseDialog<%=Str_F=="" ? "1" : Convert.ToDouble(int.Parse(Str_F)+1).ToString() %>();
       }
       else
       {
            parent.<%=Str_Fid %>.document.getElementById("hfreclist").value=list;
            parent.<%=Str_Fid %>.document.getElementById("btnsngetgds").click(); 
            parent.CloseDialog<%=Str_F=="" ? "" : "1" %>();
       }
    }catch(e){alert("系统错误！请刷新后重试");}
    }
}

document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog<%=Str_F=="" ? "1" : Convert.ToDouble(int.Parse(Str_F)+1).ToString() %>();}catch(e){}}}
</script>
