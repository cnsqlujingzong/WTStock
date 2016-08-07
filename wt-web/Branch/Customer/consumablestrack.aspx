<%@ page language="C#"  CodeFile="consumablestrack.aspx.cs"     autoeventwireup="true" inherits="Branch_Customer_ConsumablesTrack" theme="Themes" enableEventValidation="false" %>
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
                    <asp:CheckBox ID="cbHidden" runat="server" AutoPostBack="True" OnCheckedChanged="cbHidden_CheckedChanged" /> 隐藏已过期
                </td>
                <td>
                    <asp:Button ID="btnExcel" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" /></td>
                <td>
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="pindl" Width="100">
                        <asp:ListItem Value="1">待跟踪</asp:ListItem>
                        <asp:ListItem Value="2">已跟踪</asp:ListItem>
                        <asp:ListItem Value="3">被取消</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="CustomerName">按客户名称查询</asp:ListItem>
                    <asp:ListItem Value="BillID">按业务单号查询</asp:ListItem>
                    <asp:ListItem Value="LinkMan">按联系人查询</asp:ListItem>
                    <asp:ListItem Value="Tel">按联系电话查询</asp:ListItem>
                    <asp:ListItem Value="QtyTypeName">按计数器类型查询</asp:ListItem>
                    <asp:ListItem Value="_Date">按创建日期查询</asp:ListItem>
                    <asp:ListItem Value="TrackDate">按跟踪日期查询</asp:ListItem>
                    <asp:ListItem Value="TrackOperator">按跟踪人查询</asp:ListItem>
                    <asp:ListItem Value="Result">按跟踪结果查询</asp:ListItem>
                    <asp:ListItem Value="Remark">按备注人查询</asp:ListItem>
                    <asp:ListItem Value="-1">查询全部</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server" CssClass="pink" ToolTip="输入查询关键字"></asp:TextBox>
            </td><td align="left">
            <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
            </tr>
            </table>   
        </div>
        <div class="clearfloat"></div>
    </div>
    
    <div id="cndiv" style="height:1px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:CheckBox ID="cb" runat="server" />
                </ItemTemplate>
                <HeaderTemplate>
                    <input id="cball" type="checkbox" class="cb1" onclick="SltAllValue();" title="全选/取消全选"/>
                </HeaderTemplate>
            </asp:TemplateField>
            
            <asp:BoundField HeaderText="预警日期" DataField="WarringDate" />
            <asp:BoundField HeaderText="业务类别" DataField="Type" />
            <asp:BoundField HeaderText="业务单号" DataField="BillID" />
            <asp:BoundField HeaderText="客户名称" DataField="CustomerName" />
            <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
            <asp:BoundField HeaderText="联系电话" DataField="Tel" />
            <asp:BoundField HeaderText="计数器类型" DataField="QtyTypeName" />
            <asp:BoundField HeaderText="创建日期" DataField="_Date" />
            <asp:BoundField HeaderText="操作人" DataField="Operator" />
            <asp:BoundField HeaderText="跟踪人" DataField="TrackOperator" />
            <asp:BoundField HeaderText="跟踪日期" DataField="TrackDate" />
            <asp:BoundField HeaderText="跟踪结果" DataField="Result" />
            <asp:BoundField HeaderText="再次跟踪" DataField="bAgain" />
            <asp:BoundField HeaderText="跟踪派工" DataField="bAllot" />
            <asp:BoundField HeaderText="派工单号" DataField="OperationID" />
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
    <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
    <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfTbTitle" runat="server" />
    <asp:HiddenField ID="hfTbField" runat="server" />
    <asp:HiddenField ID="hfcbID" runat="server" />
    <asp:HiddenField ID="hfParm" runat="server" Value="-1" />
    <asp:HiddenField ID="hfPurArea" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="cbHidden" EventName="CheckedChanged" />
    </Triggers>       
    </asp:UpdatePanel>
    </div>
    
    <div id="cnbut">
        <div class="ftool2">
            <div id="mytabs" style="padding-left:2px;">
                <span id="tabs_l1" class="tabs_activeleft"></span>
                <span id="tabs1" class="tabs_active" >耗材跟踪</span>
                <span id="tabs_r1" class="tabs_activeright"></span>
            </div>
        </div>
        <div class="cndiv2" id="cndiv2">
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" class="tb5">
                <tr>
                    <td align="right">
                    跟踪人：</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl">
                        </asp:DropDownList>
                    </td>
                    <td>跟踪日期：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbDate" CssClass="Wdates" runat="server" onfocus="WdatePicker()"></asp:TextBox>
                    </td>
                    <td style="padding-left:5px;">
                        <input id="btntel" type="button" class="btel2" onclick="ChkMod(600, 350, 'Tool/SmsAdm.aspx?f=1','发送短信');" value="发送短信" /></td>
                </tr>
               <tr>
                    <td align="right">跟踪结果：</td>
                    <td style="padding-left:0px;height:80px;" colspan="3">
                    <asp:TextBox ID="tbRemark" runat="server" CssClass="pin" TextMode="MultiLine" Height="70" Width="343"></asp:TextBox></td>
                    <td valign="top" style="padding-left:5px;">
                        <input id="btntrack" type="button" class="btrack" onclick="ChkAllot();" value="跟踪派工" /></td>
               </tr>
            </table>
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="left" style="padding-left:350px;">
                        <asp:CheckBox ID="cbagain" runat="server" /> <span class="sysblue">需再次跟踪</span>
                        <asp:Button ID="btnSave" runat="server" Text="确认" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false) return false" OnClick="btnSave_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="取消" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkCancel()==false) return false" OnClick="btnCancel_Click"/>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div class="fbom">
        <div id="fbon" class="fbon"></div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;
var isfocus=2;
function ChkID(id)
{
    ClrID(id);
}

function Chkset()
{
    Chkwh2();
    Chkbom(); 
}

function ChkAllot()
{
    if(ChkSlt()!=false)
    {
        parent.ShowDialog(480, 185, 'Customer/TrackAllot.aspx?id='+$("hfRecID").value+'&str='+escape($("tbRemark").value), '跟踪派工');
    }else{return false;}
}
function ChkCancel()
{
    if(ChkSltValue()!=false)
    {
        return confirm("确认要取消[耗材跟踪]吗？");
    }else{return false;}
}

function ChkSave()
{
    if(ChkSlt()!=false)
    {
        if($("ddlOperator").value=="-1")
        {
            window.alert("操作失败！跟踪人不能为空");
            $("ddlOperator").focus();
            return false
        }
         if(isNull($("tbDate").value))
        {
            window.alert("操作失败！跟踪日期不能为空");
            $("tbDate").focus();
            return false
        }
        if(isNull($("tbRemark").value))
        {
            window.alert("操作失败！跟踪结果不能为空");
            $("tbRemark").focus();
            return false
        }
        if($("cbagain").checked)
        {
            parent.ShowDialog(300, 95, 'Customer/AgainTrack.aspx?id='+$("hfRecID").value+'&str='+escape($("tbRemark").value)+'&stroper='+escape($("ddlOperator").value)+'&strdate='+escape($("tbDate").value), '再次跟踪处理');
            return false;
        }
    }else{return false;}
}
function Sell(id,title)
{
    parent.ShowDialog(800, 480,'Sell/SellMod.aspx?ids='+id,title);
}
function Lease(id)
{
    parent.ShowDialog(800, 480,'Lease/LeaseMod.aspx?ids='+id,'业务单');
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("耗材跟踪");
}

</script>
