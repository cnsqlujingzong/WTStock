<%@ page language="C#"  CodeFile="assadm.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Customer_AssAdm" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/frame.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/page.css" />
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
                <input id="btnNew" type="button" value="关联审核" class="bt1" onclick="ChkMod(550,120,'Customer/AssMod.aspx','关联审核');" />
                <input id="btnMod" type="button" value="设置" class="bt1" onclick="ChkMod(550,120,'Customer/AssSet.aspx','设置');" />
                <asp:Button ID="btnDel" runat="server" Text="删除" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkDel('会员信息')==false) return false;ChkValue();" OnClick="btnDel_Click"/>
                <a href="#" class="sh2" title="从客户生成" onclick="parent.ShowDialog(800, 500, 'Customer/SltCus.aspx?x=1', '从客户生成会员');">>>从客户生成会员</a>
                <a href="../../web/default.aspx" target="_blank" class="sh2" title="打开报修平台">>>打开报修平台</a>
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
                    <asp:Button ID="btnExcel" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" />
                </td>
               <td>
                    <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                        <asp:ListItem Value="_Name">按会员名查询</asp:ListItem>
                        <asp:ListItem Value="Company">按单位名称查询</asp:ListItem>
                        <asp:ListItem Value="LinkMan">按联系人查询</asp:ListItem>
                        <asp:ListItem Value="Tel">按电话查询</asp:ListItem>
                        <asp:ListItem Value="Adr">按地址查询</asp:ListItem>
                        <asp:ListItem Value="CustomerNO">按关联客户编号查询</asp:ListItem>
                        <asp:ListItem Value="CustomerName">按关联客户名称查询</asp:ListItem>
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
    
    <div id="cndiv" style="height:1px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:TemplateField HeaderText="选择" >
                <HeaderTemplate>
                <input type="checkbox" id="chkall" onclick="ChkALL()"/>选择
                </HeaderTemplate>
                <ItemTemplate>
                <input type="checkbox" id="chk<%#Eval("ID") %>"/>
                </ItemTemplate>
             </asp:TemplateField>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="CustomerID" DataField="CustomerID" />
            <asp:BoundField HeaderText="会员名" DataField="_Name" />
            <asp:BoundField HeaderText="单位名称" DataField="Company" />
            <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
            <asp:BoundField HeaderText="电话" DataField="Tel" />
            <asp:BoundField HeaderText="地址" DataField="Adr" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="关联客户编号" DataField="CustomerNO" />
            <asp:BoundField HeaderText="关联客户名称" DataField="CustomerName" />
            <asp:BoundField HeaderText="状态" DataField="Status" />
        </Columns>
    </asp:GridView>
    
    <table cellpadding="0" cellspacing="0" class="pages">
        <tr>
            <td><webdiyer:aspnetpager id="jsPager" runat="server" onpagechanged="jsPager_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="跳转:" /></td>
            <td style="padding-left:8px;"><asp:Label ID="lbPage" runat="server" ToolTip="当页显示数"></asp:Label></td>
            <td style="padding-left:8px;"><asp:Label ID="lbCountText" runat="server" ToolTip="总记录数" Text="总记录:"></asp:Label><asp:Label ID="lbCount" runat="server" ToolTip="总记录数"></asp:Label></td>
        </tr>
    </table>
    <asp:HiddenField ID="hfcbID" runat="server" Value="-1" />
    <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
    <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
    <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfTbTitle" runat="server" />
    <asp:HiddenField ID="hfTbField" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
    </Triggers>       
    </asp:UpdatePanel>
    </div>
       
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
function ChkID(id)
{
    ClrID(id);
}
function ShowCus(id)
{
    parent.ShowDialog(600, 450, 'Customer/CusMod.aspx?id=' + id, '客户信息');
}
function Chkset()
{
    Chkwh();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("报修会员管理");
}
/////
function ChkALL()
{
    var tb=document.getElementById("gvdata");
    var cb = document.getElementById("chkall");
    if(cb.checked == true)
    {
        for(i=0;i<tb.rows.length;i++)
       {
            var chk=tb.rows[i].getElementsByTagName("input")[0];
            if(chk != null)
            {
                 chk.checked = true;
            }
        }
    }
    else
    {
        for(i=0;i<tb.rows.length;i++)
       {
            var chk=tb.rows[i].getElementsByTagName("input")[0];
            if(chk != null)
            {
                 chk.checked = false;
            }
        }
    }
    
}
 ///
function ChkValue()
{
    var tb=document.getElementById("gvdata");
    var ids="";
    for(i=1;i<tb.rows.length;i++)
    {
        var chk=tb.rows[i].getElementsByTagName("input")[0];
        if(null!=chk&&chk.checked==true)
        {
            var id=chk.id.replace(/^chk(\d+)$/,"$1");
            ids+=id+",";
        }
    }
    if(ids=="")
    {
        alert("请勾选记录！");
        return;
    }
    ids=ids.replace(/(^,*)|(,*$)/g,"");
    document.getElementById("hfcbID").value = ids;
}
</script>
