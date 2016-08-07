<%@ page language="C#"  CodeFile="supplieradm.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Basic_SupplierAdm" theme="Themes" enableEventValidation="false" %>
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
<body onload="Chkset();" onclick="parent.Sethidden1();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="ftool">
        <div class="ftoolleft">
         <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td>
                <asp:Button ID="btnFsh" runat="server" Text="刷新" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnFsh_Click"/>
                <input id="btnNew" type="button" value="新建" class="bt1" onclick="NewSup();" />
                <input id="btnMod" type="button" value="修改" class="bt1" onclick="ChkMod(540, 290,'Basic/SupplierMod.aspx','修改厂商');" />
                <asp:Button ID="btnDel" runat="server" Text="删除" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkDel('往来厂商')==false) return false;" OnClick="btnDel_Click"/>
                <input id="btnMerge" runat="server" type="button" value="合并" class="bt1" onclick="ChkMerge();" />
                <span style="display:none;">
                    <asp:Button ID="btnClr" runat="server" Text="保留选中" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                    <asp:Button ID="btnOrder" runat="server" Text="排序" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                    <asp:Button ID="btnShow" runat="server" Text="show" CssClass="bt1" OnClick="btnShow_Click" UseSubmitBehavior="False" />
                </span>
            </td>
            </tr>
            </table>
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                <input id="btnClass" runat="server" type="button" class="bclass" value="批量修改" onclick="ChkEditClass();" />
                    <input id="btntel"   runat="server" type="button" class="btel" value="群发" onclick="SmsSndSBat();" />
                    <input id="btnInput" runat="server" type="button" class="binput" value="导入" onclick="ChkInput();" />
                </td>
                <td>
                    <asp:Button ID="btnExcel" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" />
                </td>
                <td>
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="pindl">
                        <asp:ListItem Value="All">所有厂商</asp:ListItem>
                        <asp:ListItem Value="bTransmitCorp">送修厂商</asp:ListItem>
                        <asp:ListItem Value="bSupplier">产品供应商</asp:ListItem>
                        <asp:ListItem Value="bChargeCorp">特约维修结算厂商</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="ddlKey" runat="server" onchange="document.getElementById('tbCon').focus();" CssClass="pindl">
                        <asp:ListItem Value="0">模糊查询</asp:ListItem>
                        <asp:ListItem Value="1">按厂商名称查询</asp:ListItem>
                        <asp:ListItem Value="2">按厂商编号查询</asp:ListItem>
                        <asp:ListItem Value="3">按联系人查询</asp:ListItem>
                        <asp:ListItem Value="4">按电话查询</asp:ListItem>
                        <asp:ListItem Value="5">按地址查询</asp:ListItem>
                        <asp:ListItem Value="6">按传真查询</asp:ListItem>
                        <asp:ListItem Value="7">按邮编查询</asp:ListItem>
                        <asp:ListItem Value="8">按Email查询</asp:ListItem>
                        <asp:ListItem Value="9">按备注查询</asp:ListItem>
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
    
    <div id="lndiv" class="lndiv">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:TreeView ID="tvsup" runat="server" ShowLines="True" OnSelectedNodeChanged="tvsup_SelectedNodeChanged">
            <SelectedNodeStyle BackColor="#7d8abe" BorderColor="White" />
        </asp:TreeView>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="tvsup" EventName="SelectedNodeChanged" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div id="lncn" class="uw"></div>
    <div id="cndiv" style="float:left;height:1px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="GvData" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="GvData_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="停用" DataField="bStop" />
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:CheckBox ID="cb" runat="server" />
                </ItemTemplate>
                <HeaderTemplate>
                    <input id="cball" type="checkbox" class="cb1" onclick="SltAllValue();" title="全选/取消全选"/>
                </HeaderTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="厂商分类" DataField="ClassName" />
            <asp:BoundField HeaderText="厂商编号" DataField="SupNO" />
            <asp:BoundField HeaderText="厂商名称" DataField="_Name" />
            <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
            <asp:BoundField HeaderText="联系电话" DataField="Tel" />
            <asp:BoundField HeaderText="手机号码" DataField="Tel2" />
            <asp:BoundField HeaderText="传真" DataField="Fax" />
            <asp:BoundField HeaderText="邮编" DataField="Zip" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="帐户" DataField="Account" />
            <asp:BoundField HeaderText="地址" DataField="Adr" />
            <asp:BoundField HeaderText="送修厂商" DataField="bTransmitCorp" />
            <asp:BoundField HeaderText="产品供应商" DataField="bSupplier" />
            <asp:BoundField HeaderText="特约维修结算厂商" DataField="bChargeCorp" />
            <asp:BoundField HeaderText="停用" DataField="bStop" />
            <asp:BoundField HeaderText="备注" DataField="Remark" />
        </Columns>
    </asp:GridView>
    <table cellpadding="0" cellspacing="0" class="pages">
        <tr>
            <td><webdiyer:aspnetpager id="jsPager" runat="server" onpagechanged="jsPager_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="跳转:" /></td>
            <td style="padding-left:8px;"><asp:Label ID="lbPage" runat="server" ToolTip="当页显示数"></asp:Label></td>
            <td style="padding-left:8px;"><asp:Label ID="lbCountText" runat="server" ToolTip="总记录数" Text="总记录:"></asp:Label><asp:Label ID="lbCount" runat="server" ToolTip="总记录数"></asp:Label></td>
        </tr>
    </table>
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
        <asp:HiddenField ID="hfRecID2" runat="server" Value="-1" />
        <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
        <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
        <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
        <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
        <asp:HiddenField ID="hfSql" runat="server" />
        <asp:HiddenField ID="hfClass" runat="server" />
        <asp:HiddenField ID="hfClassID" runat="server" />
        <asp:HiddenField ID="hfTbTitle" runat="server" />
        <asp:HiddenField ID="hfTbField" runat="server" />
        <asp:HiddenField ID="hfcbID" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="tvsup" EventName="SelectedNodeChanged" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div id="cnbut" style="overflow:hidden;">
        <div class="ftool2">
        <div id="mytabs">
            <span id="tabs_l1"></span>
            <span id="tabs1" onclick="ChkTab('1');ChkSltD('1');">联系人组</span>
            <span id="tabs_r1"></span>
            <span class="changwin">
                <input id="btnMin" type="button" value="" class="changmin" onclick="changmin();"/>
                <input id="btnRed" type="button" value="" class="changred" onclick="changred();" style="display:none;" />
                <input id="btnMax" type="button" value="" class="changmax" onclick="changmax();"/></span>
        </div>
        </div>
        <div id="info1" style="height:175px;background:#ECE9D8;">
            <div style="border-bottom:#808080 1px solid;">
            <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                   <input id="btnNewLink" type="button" value="新建" class="bt1" onclick="NewLink();" />
                   <input id="btnModLink" type="button" value="修改" class="bt1" onclick="ModLink();" />
                   <asp:Button ID="btnDelLink" runat="server" Text="删除" CssClass="bt1" OnClientClick="if(ChkDel2('联系人')==false) return false;"  UseSubmitBehavior="false" OnClick="btnDelLink_Click" />
                </td>
                </tr>
               </table>
            </div>
            <div class="cndiv2" id="cndiv21">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView1_RowDataBound" EnableViewState="false">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="姓名" DataField="_Name" />
                            <asp:BoundField HeaderText="性别" DataField="Sex" />
                            <asp:BoundField HeaderText="职位" DataField="Posit" />
                            <asp:BoundField HeaderText="办公电话" DataField="Tel_office" />
                            <asp:BoundField HeaderText="宅电" DataField="Tel_home" />
                            <asp:BoundField HeaderText="移动电话" DataField="Tel_Mobile" />
                            <asp:BoundField HeaderText="传真" DataField="Fax" />
                            <asp:BoundField HeaderText="Email" DataField="Email" />
                            <asp:BoundField HeaderText="生日" DataField="Birthday" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false" />
                            <asp:BoundField HeaderText="地址" DataField="Adr" />
                            <asp:BoundField HeaderText="备注" DataField="Remark" />
                        </Columns>
                    </asp:GridView>

                    <table cellpadding="0" cellspacing="0" class="pages">
                        <tr>
                            <td><webdiyer:aspnetpager id="jsPagerl" runat="server" onpagechanged="jsPagerl_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="跳转:" /></td>
                            <td style="padding-left:8px;"><asp:Label ID="lbPagel" runat="server" ToolTip="当页显示数"></asp:Label></td>
                            <td style="padding-left:8px;"><asp:Label ID="lbCountTextl" runat="server" Visible="false" ToolTip="总记录数" Text="总记录:"></asp:Label><asp:Label ID="lbCountl" runat="server" ToolTip="总记录数"></asp:Label></td>
                        </tr>
                    </table>
                    
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnDelLink" EventName="Click" />
                    </Triggers>       
                    </asp:UpdatePanel>
            </div>
        </div>
    </div>
    
    <div class="clearfloat"></div>
    <div class="fbom">  
    <div id="fbon" class="fbon">
    </div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;
var isfocus=2;
var tabnum=2;
function ChkID(id)
{
    ClrID(id);
    $("btnShow").click();
}
function Chkset()
{
    Chkwhcus();//Chkwh3();
    Chkbom(); 
}
function NewSup()
{
    var classid=$("hfClassID").value;
    parent.ShowDialog(540, 290, 'Basic/SupplierAdd.aspx?classid='+classid, '新建厂商');
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("往来厂商");
}
function ChkInput()
{
    parent.ShowDialog(600, 360,'Basic/InputSuplierList.aspx?iflag=1', '导入仓库');
}
function ChkEditClass()
{
    var id=$("hfcbID").value;
    if(id=="")
        id=$("hfRecID").value;
    if(ChkSltValue()!=false)
    {
        parent.ShowDialog(300, 180,'Basic/EditSuplierInfo.aspx?id='+id,'批量修改厂商信息');
    }
}
function ChkMerge()
{
    var id=$("hfcbID").value;
    if(id==""||id.replace(/(^[\s,]*)|([\s,]*$)/g,"").indexOf(',')<=0)
    {
        alert("请勾选多条记录合并！");
        return;
    }
    if(ChkSltValue()!=false)
    {
        parent.ShowDialog(500, 360,'Basic/SupMerge.aspx?id='+id,'合并客户');
    }
}
//调整窗口为默认大小
function changred()
{
    var h1=document.body.clientHeight-54;//表格高度
    var h2=h1-200;//固定占用高度
    $("lndiv").style.height=h1+"px";
    $("lncn").style.height=h1+"px";
    $("cndiv").style.height=h2+"px";
    $("cnbut").style.height="200px";
    
    $("btnRed").style.display="none";
    $("btnMax").style.display="inline";
    $("btnMin").style.display="inline";
    
    if(typeof(tabnum)!="undefined")
    {
        for(i=1; i <tabnum; i++)
         {
             $("info"+i).style.height="175px";
             $("cndiv2"+i).style.height="145px";
         }
    }
}
//调整窗口为最大化
function changmax()
{
    var h1=document.body.clientHeight-54;//表格高度
    var h2=h1-200;//固定占用高度
    var h3=h1-30;
    var h4=h1-60;
    $("lndiv").style.height=h1+"px";
    $("lncn").style.height=h1+"px";
    $("cndiv").style.height="0px";
    $("cnbut").style.height=h1+"px";
    
    $("btnRed").style.display="inline";
    $("btnMax").style.display="none";
    $("btnMin").style.display="inline";
    
    if(typeof(tabnum)!="undefined")
    {
        for(i=1; i <tabnum; i++)
         {
             $("info"+i).style.height=h3+"px";
             $("cndiv2"+i).style.height=h4+"px";
         }
    }
}
//调整窗口为最小化
function changmin()
{
    var h1=document.body.clientHeight-54;//表格高度
    var h2=h1-23;//固定占用高度
    $("lndiv").style.height=h1+"px";
    $("lncn").style.height=h1+"px";
    $("cndiv").style.height=h2+"px";
    $("cnbut").style.height="23px";
    
    $("btnRed").style.display="inline";
    $("btnMax").style.display="inline";
    $("btnMin").style.display="none";
}
function NewLink()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("请选择一条厂商记录后操作！");
        return false;
    }
    parent.ShowDialog(460, 263, 'Basic/LinkManAdd.aspx?id='+id, '新建联系人');
}
function SmsSndSBat()
{
    if($("hfTbTitle").value=="")
    {
        window.alert("操作失败！请查询出要发送短信的客户列表.");
        return false;
    }
    parent.ShowDialog(500, 275,'Tool/SmsSndSBat.aspx', '短信群发');
}
function ModLink()
{
    var id=document.getElementById("hfRecID2").value.replace("l","");
    if(id=="-1")
    {
        alert("请选择一条联系人后操作！");
    }
    else
    {
        parent.ShowDialog(460, 263,'Basic/LinkManMod.aspx?id='+id, '修改联系人');
    }
}
</script>
