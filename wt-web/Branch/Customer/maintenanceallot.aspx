<%@ page language="C#"  CodeFile="maintenanceallot.aspx.cs"     autoeventwireup="true" inherits="Branch_Customer_MaintenanceAllot" theme="Themes" enableEventValidation="false" %>
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
                    <asp:Button ID="btnSchH" runat="server" Text="高级查询" CssClass="bt1" OnClick="btnSchH_Click" UseSubmitBehavior="False" />
                </span>
            </td>
            </tr>
        </table>
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td style="padding-left:0px;">
                    <asp:Button ID="btnExcel" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" /></td>
                <td>
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="pindl" Width="100">
                        <asp:ListItem Value="0">待派工</asp:ListItem>
                        <asp:ListItem Value="1">已派工</asp:ListItem>
                        <asp:ListItem Value="2">被取消</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="0">模糊查询</asp:ListItem>
                    <asp:ListItem Value="1">按客户编号查询</asp:ListItem>
                    <asp:ListItem Value="2">按客户名称查询</asp:ListItem>
                    <asp:ListItem Value="3">按联系人查询</asp:ListItem>
                    <asp:ListItem Value="4">按联系电话查询</asp:ListItem>
                    <asp:ListItem Value="5">按品牌查询</asp:ListItem>
                    <asp:ListItem Value="6">按类别查询</asp:ListItem>
                    <asp:ListItem Value="7">按型号查询</asp:ListItem>
                    <asp:ListItem Value="8">按序列号查询</asp:ListItem>
                    <asp:ListItem Value="-1">查询全部</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server" CssClass="pink" ToolTip="输入查询关键字"></asp:TextBox>
            </td><td align="left">
            <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
            <td style="padding:0px;"><input id="btnSchsH" type="button" value="高级查询" class="bsch" onclick="parent.ShowDialog(510,373, 'Customer/DeviceCd.aspx', '高级查询');" /></td>
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
            <asp:BoundField HeaderText="保养日期" DataField="_Date" />
            <asp:BoundField HeaderText="客户编号" DataField="CustomerNO" />
            <asp:BoundField HeaderText="客户名称" DataField="_Name" />
            <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
            <asp:BoundField HeaderText="所属部门" DataField="CusDept" />
            <asp:BoundField HeaderText="联系电话" DataField="Tel" />
            <asp:BoundField HeaderText="地址" DataField="Adr" />
            <asp:BoundField HeaderText="品牌" DataField="ProductBrand" />
            <asp:BoundField HeaderText="类别" DataField="ProductClass" />
            <asp:BoundField HeaderText="型号" DataField="ProductModel" />
            <asp:BoundField HeaderText="序列号1" DataField="ProductSN1" />
            <asp:BoundField HeaderText="序列号2" DataField="ProductSN2" />
            <asp:BoundField HeaderText="外观" DataField="ProductAspect" />
            <asp:BoundField HeaderText="购买时间" DataField="BuyDate" />
            <asp:BoundField HeaderText="经销商" DataField="BuyFrom" />
            <asp:BoundField HeaderText="购买发票" DataField="BuyInvoice" />
            <asp:BoundField HeaderText="安装日期" DataField="InstallDate" />
            <asp:BoundField HeaderText="保修期" DataField="MaintenancePeriod" />
            <asp:BoundField HeaderText="保修情况" DataField="Warranty" />
            <asp:BoundField HeaderText="厂家保修开始" DataField="WarrantyStart" />
            <asp:BoundField HeaderText="厂家保修截至" DataField="WarrantyEnd" />
            <asp:BoundField HeaderText="维修次数" DataField="RepairTimes" />
            <asp:BoundField HeaderText="最近维修时间" DataField="Repairlately" />
            <asp:BoundField HeaderText="维修保修截至" DataField="RepairWarrantyEnd" />
            <asp:BoundField HeaderText="合同保修开始" DataField="ContractWarrantyStart" />
            <asp:BoundField HeaderText="合同保修截至" DataField="ContractWarrantyEnd" />
            <asp:BoundField HeaderText="维修合同编号" DataField="ContractNO" />
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
        <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
    </Triggers>       
    </asp:UpdatePanel>
    </div>
    
    <div id="cnbut">
        <div class="ftool2">
            <div id="mytabs" style="padding-left:2px;">
                <span id="tabs_l1" class="tabs_activeleft"></span>
                <span id="tabs1" class="tabs_active" >保养派工</span>
                <span id="tabs_r1" class="tabs_activeright"></span>
            </div>
        </div>
        <div class="cndiv2" id="cndiv2">
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" class="tb5">
                <tr>
                    <td align="right" style="width:60px;">
                    技术员：</td>
                    <td style="padding-left:0px; width:130px;">
                        <asp:TextBox ID="tbDisposal" runat="server" CssClass="pinks"></asp:TextBox>
                    </td>
                    <td style="padding:0px; text-align:left;"><input id="btnSltStaff" type="button" value="" onclick="SltTec();" class="bview"/></td>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="0" class="tb5">
                <tr>
                    <td align="right">服务级别：</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlPRI" runat="server" CssClass="pindl">
                            <asp:ListItem Value=""></asp:ListItem>
                            <asp:ListItem Value="普通">普通</asp:ListItem>
                            <asp:ListItem Value="紧急">紧急</asp:ListItem>
                            <asp:ListItem Value="缓慢">缓慢</asp:ListItem>
                        </asp:DropDownList>
                    </td>
               </tr>
               <tr>
                    <td align="right">备注：</td>
                    <td style="padding-left:0px;height:50px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" TextMode="MultiLine" Height="40" Width="300"></asp:TextBox></td>
                </tr>
            </table>
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td align="left" style="padding-left:230px;">
                        <asp:Button ID="btnSave" runat="server" Text="保养处理" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSltValue()==false) return false" OnClick="btnSave_Click" />
                        <asp:Button ID="btnCancel" runat="server" Text="取消任务" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkCancel()==false) return false" OnClick="btnCancel_Click"/>
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

function ChkCancel()
{
    if(ChkSltValue()!=false)
    {
        return confirm("确认要取消保养派工吗？");
    }else{return false;}
}

function SltTec()
{
    parent.ShowDialog1(400, 510, 'Services/SltTec.aspx?f=1&fid='+parent.$("hfActiveWin").value, '技术员');
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("保养派工");
}

</script>
