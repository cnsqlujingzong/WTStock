<%@ page language="C#"  CodeFile="sltcus.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Services_SltCus" theme="themes" enableEventValidation="false" %>
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
                    <asp:DropDownList ID="ddlKey" runat="server" onchange="document.getElementById('tbCon').focus();" CssClass="pindl">
                        <asp:ListItem Value="0">模糊查询</asp:ListItem>
                        <asp:ListItem Value="2">按客户名称查询</asp:ListItem>
                        <asp:ListItem Value="1">按客户编号查询</asp:ListItem>
                        <asp:ListItem Value="3">按联系人查询</asp:ListItem>
                        <asp:ListItem Value="4">按电话查询</asp:ListItem>
                        <asp:ListItem Value="5">按地址查询</asp:ListItem>
                        <asp:ListItem Value="6">按邮编查询</asp:ListItem>
                        <asp:ListItem Value="7">按传真查询</asp:ListItem>
                        <asp:ListItem Value="8">按Email查询</asp:ListItem>
                        <asp:ListItem Value="9">按客户区域查询</asp:ListItem>
                        <asp:ListItem Value="10">按登记部门查询</asp:ListItem>
                        <asp:ListItem Value="11">按客户来源查询</asp:ListItem>
                        <asp:ListItem Value="12">按业务员查询</asp:ListItem>
                        <asp:ListItem Value="-1">查询全部</asp:ListItem>
                    </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="tbCon" runat="server" CssClass="pink" onkeydown="EnterTextBoxSch(event, this);" ToolTip="输入查询关键字"></asp:TextBox>
            </td><td align="left">
                <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" />
                <input id="btnNew" type="button" value="新建" class="bt1" onclick="NewCus();"/>
                </td>
               <td><asp:CheckBox ID="cbDept" runat="server" AutoPostBack="true" OnCheckedChanged="cbDept_CheckedChanged" Checked="true" /><span style="color:#0000ff">只显示本部门的客户</span></td> 
             </tr>
            </table>   
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td style="padding-right:50px;">
                <input id="btnAdd" type="button" value="确定" class="bt1" onclick="ChkCus();"/>
            </td>
            <td>
                <span style="display:none;">
                    <asp:Button ID="btnClr" runat="server" Text="保留选中" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                    <asp:Button ID="btnOrder" runat="server" Text="排序" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                </span>
            </td>
            </tr>
            </table>
        </div>
        <div class="clearfloat"></div>
    </div>
    
    <div id="lndiv" class="lndiv" style="height:460px">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:TreeView ID="tvcus" runat="server" ShowLines="True" OnSelectedNodeChanged="tvcus_SelectedNodeChanged">
            <SelectedNodeStyle BackColor="#7d8abe" BorderColor="White" />
        </asp:TreeView>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="tvcus" EventName="SelectedNodeChanged" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div id="lncn" class="uw" style="height:460px"></div>
    <div id="cndiv" style="float:left;height:460px; width:635px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvcus" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvcus_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="客户分类" DataField="ClassName" />
            <asp:BoundField HeaderText="客户编号" DataField="CustomerNO" />
            <asp:BoundField HeaderText="客户名称" DataField="_Name" />
            <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
            <asp:BoundField HeaderText="联系电话" DataField="Tel" />
            <asp:BoundField HeaderText="手机号码" DataField="Tel2" />
            <asp:BoundField HeaderText="地址" DataField="Adr" />
            <asp:BoundField HeaderText="邮编" DataField="Zip" />
            <asp:BoundField HeaderText="传真" DataField="Fax" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="QQ/MSN" DataField="QQ" />
            <asp:BoundField HeaderText="帐户" DataField="Account" />
            <asp:BoundField HeaderText="客户区域" DataField="Area" />
            <asp:BoundField HeaderText="客户来源" DataField="CusFrom" />
            <asp:BoundField HeaderText="业务员" DataField="Seller" />
            <asp:BoundField HeaderText="登记部门" DataField="DeptID" />
            <asp:BoundField HeaderText="登记时间" DataField="_Date" />
            <asp:BoundField HeaderText="备注" DataField="Remark" />
            <asp:BoundField HeaderText="会员级别" DataField="Member" />
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
        <asp:HiddenField ID="hfClass" runat="server" />
        <asp:HiddenField ID="hfCusName" runat="server" />
        <asp:HiddenField ID="hfLinkMan" runat="server" />
        <asp:HiddenField ID="hfTel" runat="server" />
        <asp:HiddenField ID="hfArea" runat="server" />
        <asp:HiddenField ID="hfAdr" runat="server" />
        <asp:HiddenField ID="hfPurArea" runat="server" />
        <asp:HiddenField ID="hfPur1" runat="server" />
        <asp:HiddenField ID="hfPurDept" runat="server" Value="0" />
        <asp:HiddenField ID="hfMember" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="tvcus" EventName="SelectedNodeChanged" />
        <asp:AsyncPostBackTrigger ControlID="cbDept" EventName="CheckedChanged" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div class="clearfloat"></div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>

<script language="javascript" type="text/javascript">
var isfocus=2;
var strtel="";
var uri=location.href;
if(uri.indexOf("itel=1")>0)
    strtel="&itel=1";
function ChkID(id)
{
    ClrID(id);
}
function ChkIDCus(strname,strlinkman,strtel,strarea,stradr,strmember)
{
    $("hfCusName").value=strname;
    $("hfLinkMan").value=strlinkman;
    $("hfTel").value=strtel;
    $("hfArea").value=strarea;
    $("hfAdr").value=stradr;
    $("hfMember").value=strmember;
}
function ChkCus()
{
    if(ChkSlt()==false)
     return;
    
    try{
    parent.<%=Str_Fid %>.$("hfCusID").value=$("hfRecID").value;
    parent.<%=Str_Fid %>.$("tbCusName").value=$("hfCusName").value;
    parent.<%=Str_Fid %>.$("tbLinkMan").value=$("hfLinkMan").value;
    parent.<%=Str_Fid %>.$("tbTel").value=$("hfTel").value;
    parent.<%=Str_Fid %>.$("tbArea").value=$("hfArea").value;
    parent.<%=Str_Fid %>.$("tbAdr").value=$("hfAdr").value;
    parent.<%=Str_Fid %>.$("tbCusLevel").value=$("hfMember").value;
    parent.<%=Str_Fid %>.$("btnValiCus").click();
    }catch(e){}
    parent.CloseDialog1();
}
function NewCus()
{
    parent.ShowDialog2(600, 400, '../Headquarters/Customer/CusAdd.aspx?f=2'+strtel, '新建客户');
}
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog1();}catch(e){}}}
</script>
