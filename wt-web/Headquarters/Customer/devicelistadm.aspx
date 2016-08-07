<%@ page language="C#"  CodeFile="devicelistadm.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Customer_DeviceListAdm" theme="Themes" enableeventvalidation="false" %>
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
                <input id="btnNew" type="button" value="新建" class="bt1" onclick="parent.ShowDialog(750, 430, 'Customer/DeviceAdd.aspx', '新建机器档案');" />
                <input id="btnMod" type="button" value="修改" class="bt1" onclick="ChkMod(750, 430,'Customer/DeviceMod.aspx','修改机器档案');" />
                <asp:Button ID="btnDel" runat="server" Text="删除" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkDel('机器档案')==false) return false;ChkValue();" OnClick="btnDel_Click"/>
                <span style="display:none;">
                    <asp:Button ID="btnClr" runat="server" Text="保留选中" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                    <asp:Button ID="btnOrder" runat="server" Text="排序" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                    <asp:Button ID="btnShow" runat="server" Text="显示" CssClass="bt1" OnClick="btnShow_Click" UseSubmitBehavior="false"/>
                    <asp:Button ID="btnSchH" runat="server" Text="高级查询" CssClass="bt1" OnClick="btnSchH_Click" UseSubmitBehavior="False" />
                </span>
            </td>
            </tr>
        </table>
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                    <input id="btnInput" runat="server" type="button" class="binput" value="导入" onclick="ChkInput();" />
                </td>
                <td>
                    <asp:Button ID="btnExcel" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" />
                </td>
                <td>
                <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="0">模糊查询</asp:ListItem>
                    <asp:ListItem Value="1">按机器编号查询</asp:ListItem>
                    <asp:ListItem Value="2">按客户名称查询</asp:ListItem>
                    <asp:ListItem Value="3">按联系人查询</asp:ListItem>
                    <asp:ListItem Value="4">按联系电话查询</asp:ListItem>
                    <asp:ListItem Value="5">按品牌查询</asp:ListItem>
                    <asp:ListItem Value="6">按类别查询</asp:ListItem>
                    <asp:ListItem Value="7">按型号查询</asp:ListItem>
                    <asp:ListItem Value="8">按序列号查询</asp:ListItem>
                    <asp:ListItem Value="9">按保养计划状态查询</asp:ListItem>
                    <asp:ListItem Value="-1">查询全部</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server" onkeydown="EnterTextBoxSch(event, this);" CssClass="pink" ToolTip="输入查询关键字"></asp:TextBox>
            </td><td align="left">
            <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
            <td style="padding:0px;"><input id="btnSchsH" type="button" value="高级查询" class="bsch" onclick="parent.ShowDialog(510,425, 'Customer/DeviceCd.aspx', '高级查询');" /></td>
            </tr>
            </table>   
        </div>
        <div class="clearfloat"></div>
    </div>
    
    <div id="cndiv" style="height:1px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvtrouble" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvtrouble_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:TemplateField HeaderText="选择" >
                <HeaderTemplate>
                <input type="checkbox" id="chkall" onclick="ChkALL()"/>选择
                </HeaderTemplate>
                <ItemTemplate>
                <asp:CheckBox ID="cb" runat="server" />
                </ItemTemplate>
             </asp:TemplateField>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="客户编号" DataField="CustomerNO" />
            <asp:BoundField HeaderText="客户分类" DataField="ClassName" />
            <asp:BoundField HeaderText="客户名称" DataField="_Name" />
            <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
            <asp:BoundField HeaderText="所属部门" DataField="CusDept" />
            <asp:BoundField HeaderText="联系电话" DataField="Tel" />
            <asp:BoundField HeaderText="手机号码" DataField="Tel2" />
            <asp:BoundField HeaderText="传真" DataField="Fax" />
            <asp:BoundField HeaderText="邮编" DataField="Zip" />
            <asp:BoundField HeaderText="地址" DataField="Adr" />
            <asp:BoundField HeaderText="机器编号" DataField="DeviceNO" />
            <asp:BoundField HeaderText="品牌" DataField="ProductBrand" />
            <asp:BoundField HeaderText="类别" DataField="ProductClass" />
            <asp:BoundField HeaderText="型号" DataField="ProductModel" />
            <asp:BoundField HeaderText="序列号1" DataField="ProductSN1" />
            <asp:BoundField HeaderText="序列号2" DataField="ProductSN2" />
            <asp:BoundField HeaderText="外观" DataField="ProductAspect" />
            <asp:BoundField HeaderText="产权" DataField="Property" />
            <asp:BoundField HeaderText="购买时间" DataField="BuyDate" />
            <asp:BoundField HeaderText="购买价格" DataField="BuyPrice" />
            <asp:BoundField HeaderText="经销商" DataField="BuyFrom" />
            <asp:BoundField HeaderText="购买发票" DataField="BuyInvoice" />
            <asp:BoundField HeaderText="安装日期" DataField="InstallDate" />
            <asp:BoundField HeaderText="保修期" DataField="MaintenancePeriod" />
            <asp:BoundField HeaderText="保修情况" DataField="Warranty" />
            <asp:BoundField HeaderText="厂家保修开始" DataField="WarrantyStart" />
            <asp:BoundField HeaderText="厂家保修截止" DataField="WarrantyEnd" />
            <asp:BoundField HeaderText="维修次数" DataField="RepairTimes" />
            <asp:BoundField HeaderText="最近维修时间" DataField="Repairlately" />
            <asp:BoundField HeaderText="维修保修截止" DataField="RepairWarrantyEnd" />
            <asp:BoundField HeaderText="合同保修开始" DataField="ContractWarrantyStart" />
            <asp:BoundField HeaderText="合同保修截止" DataField="ContractWarrantyEnd" />
            <asp:BoundField HeaderText="维修合同编号" DataField="ContractNO" />
            <asp:BoundField HeaderText="自定义1" DataField="userdef1" />
            <asp:BoundField HeaderText="自定义2" DataField="userdef2" />
            <asp:BoundField HeaderText="自定义3" DataField="userdef3" />
            <asp:BoundField HeaderText="自定义4" DataField="userdef4" />
            <asp:BoundField HeaderText="自定义5" DataField="userdef5" />
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
    <asp:HiddenField ID="hfcbID" runat="server" Value="-1" />
    <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
    <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
    <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfTbTitle" runat="server" />
    <asp:HiddenField ID="hfTbField" runat="server" />
    <asp:HiddenField ID="hfParm" runat="server" Value="-1" />
    <asp:HiddenField ID="hfPurArea" runat="server" />
    <asp:HiddenField ID="hfPur1" runat="server" />
    <asp:HiddenField ID="hfPurDept" runat="server" Value="0" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    
    <div id="cnbut" style="overflow:hidden;">
        <div class="ftool2">
        <div id="mytabs" style="padding-left:2px;">
            <span id="tabs_l1"></span>
            <span id="tabs1" onclick="ChkTab('1');">保养计划</span>
            <span id="tabs_r1"></span>
            <span id="tabs_l2"></span>
            <span id="tabs2" onclick="ChkTab('2');">机器配置</span>
            <span id="tabs_r2"></span>
            <span id="tabs_l3"></span>
            <span id="tabs3" onclick="ChkTab('3');">附件列表</span>
            <span id="tabs_r3"></span>
            <span id="tabs_l4"></span>
            <span id="tabs4" onclick="ChkTab('4');">计数器</span>
            <span id="tabs_r4"></span>
            <span id="tabs_l5"></span>
            <span id="tabs5" onclick="ChkTab('5');">抄表记录</span>
            <span id="tabs_r5"></span>
            <span id="tabs_l6"></span>
            <span id="tabs6" onclick="ChkTab('6');">服务单</span>
            <span id="tabs_r6"></span>
            <span class="changwin">
                <input id="btnMin" type="button" value="" class="changmin" onclick="changmin();"/>
                <input id="btnRed" type="button" value="" class="changred" onclick="changred();" style="display:none;" />
                <input id="btnMax" type="button" value="" class="changmax" onclick="changmax();"/></span>
        </div>
        </div>
        <div id="info1" style="height:163px;background:#ECE9D8;">
          <div style="border-bottom:#808080 1px solid;">
           <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td>
               <input id="btnNewPlan" type="button" value="新建" class="bt1" onclick="NewDevPlan();" />
               <input id="btnModPlan" type="button" value="修改" class="bt1" onclick="EditDevPlan();" />
               <input id="btnEditPlan" type="button" value="终止" class="bt1" onclick="ModDevPlan();" />
               <asp:Button ID="btnDelPlan" runat="server" CssClass="bt1" Text="删除" OnClick="btnDelPlan_Click" OnClientClick="if(ChkDelPlan()==false) return false;"/>
            </td>
            </tr>
            </table>
            </div>
            <div class="cndiv2" id="cndiv21" style="height:116px;">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView1_RowDataBound" EnableViewState="false" Width="70%">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" />
                        <asp:BoundField HeaderText="序"/>
                        <asp:BoundField HeaderText="名称" DataField="_Name" />
                        <asp:BoundField HeaderText="提前提醒(天)" DataField="RemindDay" />
                        <asp:BoundField HeaderText="起始日期" DataField="StartDate" />
                        <asp:BoundField HeaderText="终止日期" DataField="EndDate" />
                        <asp:BoundField HeaderText="计时方式" DataField="TimingStyle" />
                        <asp:BoundField HeaderText="周期/日期" DataField="MaintenanceCycle" />
                        <asp:BoundField HeaderText="当前状态" DataField="Status" />
                        <asp:BoundField HeaderText="终止原因" DataField="Reason" />
                        <asp:BoundField HeaderText="备注" DataField="Remark" />
                    </Columns>
                </asp:GridView>
                <asp:HiddenField ID="hfRecID3" runat="server" Value="-1" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnDelPlan" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>
            </div>
        </div>
        <div id="info2" style="height:163px;background:#ECE9D8;">
        <div style="border-bottom:#808080 1px solid;">
       <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
        <tr>
        <td>
           <input id="btnNewConf" type="button" value="新建" class="bt1" onclick="NewDevConf();" />
           <input id="btnModConf" type="button" value="修改" class="bt1" onclick="ModDevConf();" />
           <asp:Button ID="btnDelConf" runat="server" Text="删除" CssClass="bt1" OnClientClick="if(ChkDel2('机器配置')==false) return false;"  UseSubmitBehavior="false" OnClick="btnDelConf_Click" />
        </td>
        <td align="right" style="padding-right:30px;">
            <input id="btnIntputDevConf" runat="server" type="button" class="binput" value="批量导入" style="width:75px;" onclick="ChkInputDevConfAll();" />
           <input id="btnInDevConf" runat="server" type="button" class="binput" value="导入" onclick="ChkInputDevConf();" />
        </td>
        </tr>
        </table>
        </div>
        <div class="cndiv2" id="cndiv22" style="height:116px;">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView2_RowDataBound" EnableViewState="false" Width="70%">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="序"/>
                    <asp:BoundField HeaderText="名称" DataField="_Name" />
                    <asp:BoundField HeaderText="参数" DataField="Parameter" />
                    <asp:BoundField HeaderText="序列号" DataField="SN" />
                    <asp:BoundField HeaderText="保修期" DataField="MaintenancePeriod" />
                    <asp:BoundField HeaderText="购买日期" DataField="BuyDate" />
                    <asp:BoundField HeaderText="截止日期" DataField="MaintenanceEnd" />
                    <asp:BoundField HeaderText="备注" DataField="Remark" />
                </Columns>
            </asp:GridView>
            
            <asp:HiddenField ID="hfRecID2" runat="server" Value="-1" />

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnDelConf" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
        </div>
        <div id="info3" style="height:163px;background:#ECE9D8;">
        <div style="border-bottom:#808080 1px solid;">
              <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
                <tr>
                <td>
                   <input id="btnAccAdd" type="button" value="新建" class="bt1" onclick="NewAcc();" />
                   <input id="btnAccMod" type="button" value="修改" class="bt1" onclick="ModAcc();" />
                   <asp:Button ID="btnDelAcc" runat="server" Text="删除" CssClass="bt1" OnClientClick="if(ChkDel2('机器附件')==false) return false;"  UseSubmitBehavior="false" OnClick="btnDelAcc_Click" />
                </td>
                <td align="right" style="padding-right:30px;">
                    <asp:Button ID="btnAccExcel" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkAccToExcel()==false)return false;" OnClick="btnAccExcel_Click" />
                </td>
                </tr>
              </table>
        </div>
        <div class="cndiv2" id="cndiv23" style="height:116px;">
        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView4_RowDataBound" EnableViewState="false">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="序"/>
                    <asp:BoundField HeaderText="名称" DataField="_Name" />
                    <asp:BoundField HeaderText="摘要" DataField="Remark" />
                    <asp:BoundField HeaderText="附件" DataField="Path" />
                    <asp:BoundField HeaderText="创建日期" DataField="_Date" />
                    <asp:BoundField HeaderText="创建人" DataField="Operator" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnDelAcc" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
        </div>
        <div id="info4" style="height:163px;background:#ECE9D8;">
        <div style="border-bottom:#808080 1px solid;">
              <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                   <input id="btnQtyNew" type="button" value="新建" class="bt1" onclick="NewQty();" />
                   <input id="btnQtyMod" type="button" value="修改" class="bt1" onclick="ModQty();" />
                   <asp:Button ID="btnDelQty" runat="server" Text="删除" CssClass="bt1" OnClientClick="if(ChkDel2('计数器')==false) return false;"  UseSubmitBehavior="false" OnClick="btnDelQty_Click" />
                </td>
                </tr>
              </table>
        </div>
        <div class="cndiv2" id="cndiv24" style="height:116px;">
        <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView3_RowDataBound" EnableViewState="false">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="序"/>
                    <asp:BoundField HeaderText="计数日期" DataField="_Date" />
                    <asp:BoundField HeaderText="计数人" DataField="Operator" />
                    <asp:BoundField HeaderText="类型" DataField="QtyType" />
                    <asp:BoundField HeaderText="计数" DataField="Qty" />
                    <asp:BoundField HeaderText="余量" DataField="Allowance" />
                    <asp:BoundField HeaderText="备注"  DataField="Remark"/>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnDelQty" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
        </div>
        <div id="info5" style="height:163px;background:#ECE9D8;">
        <div class="cndiv2" id="cndiv25" style="height:146px;">
        <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView5_RowDataBound" EnableViewState="false">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="序"/>
                    <asp:BoundField HeaderText="读数日期" DataField="_Date" />
                    <asp:BoundField HeaderText="读数人" DataField="Operator" />
                    <asp:BoundField HeaderText="计数器类型" DataField="_Name" />
                    <asp:BoundField HeaderText="计数" DataField="Qty" />
                    <asp:BoundField HeaderText="损耗张数" DataField="Loss" />
                    <asp:BoundField HeaderText="备注"  DataField="WRemark"/>
                </Columns>
            </asp:GridView>
            
            <table cellpadding="0" cellspacing="0" class="pages">
                <tr>
                    <td><webdiyer:aspnetpager id="jsPagerle" runat="server" onpagechanged="jsPagerle_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="跳转:" /></td>
                    <td style="padding-left:8px;"><asp:Label ID="lbPagele" runat="server" ToolTip="当页显示数"></asp:Label></td>
                    <td style="padding-left:8px;"><asp:Label ID="lbCountTextle" runat="server" Visible="false" ToolTip="总记录数" Text="总记录:"></asp:Label><asp:Label ID="lbCountle" runat="server" ToolTip="总记录数"></asp:Label></td>
                </tr>
            </table>
                    
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
        </div>
        
        <div id="info6" style="height:163px;background:#ECE9D8;">
        <div style="border-bottom:#808080 1px solid;">
           <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
            <tr>
            <td>
               <input id="btnSerV" type="button" value="查看" class="bt1" onclick="SerV();" />
               </td>
            <td align="right" style="padding-right:30px;">
                <asp:Button ID="btnExcelSer" runat="server" Text="导出" CssClass="bexcel" OnClick="btnExcelSer_Click" />
                <input type ="button" onclick="ChkValue();" value="确定" />
            </td>
            </tr>
           </table>
        </div>
        <div class="cndiv2" id="cndiv26" style="height:116px;">
           <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView6_RowDataBound" EnableViewState="false">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="服务单号" DataField="BillID" />
                    <asp:BoundField HeaderText="服务状态" DataField="curStatus" />
                    <asp:BoundField HeaderText="服务类别" DataField="ServicesType" />
                    <asp:BoundField HeaderText="受理人" DataField="Operator" />
                    <asp:BoundField HeaderText="受理时间" DataField="Time_TakeOver" />
                    <asp:BoundField HeaderText="处理时间" DataField="Speding" />
                    <asp:BoundField HeaderText="受理方式" DataField="TakeStyle" />
                    <asp:BoundField HeaderText="受理单位" DataField="TakeDept" />
                    <asp:BoundField HeaderText="服务级别" DataField="_PRI" />
                    <asp:BoundField HeaderText="技术员" DataField="DisposalOper" />  
                    <asp:BoundField HeaderText="客户名称" DataField="CustomerName" />
                    <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
                    <asp:BoundField HeaderText="联系电话" DataField="Tel" />
                    <asp:BoundField HeaderText="机器型号" DataField="ProductModel" />
                    <asp:BoundField HeaderText="品牌" DataField="ProductBrand" />
                    <asp:BoundField HeaderText="类别" DataField="ProductClass" />
                    <asp:BoundField HeaderText="序列号1" DataField="ProductSN1" />
                    <asp:BoundField HeaderText="序列号2" DataField="ProductSN2" />
                    <asp:BoundField HeaderText="故障" DataField="Fault" />
                    <asp:BoundField HeaderText="处理措施/结果" DataField="TakeSteps" />
                    <asp:BoundField HeaderText="计数器" DataField="QtyType" />
                    <asp:BoundField HeaderText="保修情况" DataField="Warranty" />
                    <asp:BoundField HeaderText="预约时间" DataField="SubscribeTime" />
                    <asp:BoundField HeaderText="预报价" DataField="SubscribePrice" />
                    <asp:BoundField HeaderText="预收费" DataField="PreCharge" />
                    <asp:BoundField HeaderText="返修" DataField="bRepair" />
                    <asp:BoundField HeaderText="备注" DataField="Remark" />
                </Columns>
            </asp:GridView>
             <asp:HiddenField ID="hfSql2" runat="server" />
             <asp:HiddenField ID="hfTbTitle2" runat="server" />
            <asp:HiddenField ID="hfTbField2" runat="server" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
            </Triggers>       
            </asp:UpdatePanel>
        </div>
        </div>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;
var isfocus=2;
var tabnum=7;
function ChkID(id)
{
    ClrID(id);
    $("btnShow").click();
}
function Chkset()
{
    Chkwh2();
    Chkbom(); 
}

function NewDevConf()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("请选择一条机器档案后操作");
        return false;
    }
    parent.ShowDialog(680, 390, 'Customer/DevConfAdd.aspx?id='+id, '新建机器配置')
}

function ModDevConf()
{
    var id=document.getElementById("hfRecID2").value;
    if(id=="-1")
    {
        alert("请选择一条机器配置明细后操作！");
    }
    else
    {
        parent.ShowDialog(480, 175, 'Customer/DevConfMod.aspx?id='+id, '修改机器配置');
    }
}

function NewDevPlan()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("请选择一条机器档案后操作！");
        return false;
    }
    parent.ShowDialog(470, 175, 'Customer/DevPlanAdd.aspx?id='+id, '新建保养计划')
}

function ChkInputDevConf()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("请选择一条机器档案后操作！");
        return false;
    }
    parent.ShowDialog(480, 250, 'Customer/InputDevConf.aspx?id='+id, '导入机器配置')
}
function ChkInputDevConfAll()
{
    parent.ShowDialog(480, 275, 'Customer/InputDevConf_All.aspx', '批量导入机器配置')
}
function ChkDelPlan()
{
    var id=document.getElementById("hfRecID3").value;
    if(id=="-1")
    {
        alert("请选择一条保养计划后操作！");
        return false;
    }
    else
    {
        return confirm("确认要删除该保养计划吗？");
    }
}
function ModDevPlan()
{
    var id=document.getElementById("hfRecID3").value;
    if(id=="-1")
    {
        alert("请选择一条保养计划后操作！");
    }
    else
    {
        parent.ShowDialog(400, 93, 'Customer/DevPlanMod.aspx?id='+id, '终止保养计划');
    }
}
function EditDevPlan()
{
    var id=document.getElementById("hfRecID3").value;
    if(id=="-1")
    {
        alert("请选择一条保养计划后操作！");
    }
    else
    {
        parent.ShowDialog(470, 175, 'Customer/DevPlanModify.aspx?id='+id, '修改保养计划');
    }
}

function NewAcc()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("请选择一条机器档案后操作！");
        return false;
    }
    parent.ShowDialog(500, 200, 'Customer/DevAccAdd.aspx?id='+id, '新建附件');
}

function ModAcc()
{
    var id=document.getElementById("hfRecID2").value.replace("a","");
    if(id=="-1")
    {
        alert("请选择一条机器档案后操作！");
    }
    else
    {
        parent.ShowDialog(500, 200,'Customer/DevAccMod.aspx?id='+id, '修改附件');
    }
}

function NewQty()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("请选择一条机器档案后操作！");
        return false;
    }
    parent.ShowDialog(455, 150, 'Customer/QtyAdd.aspx?id='+id+'&iflag=1', '计数器');
}

function ModQty()
{
    var id=document.getElementById("hfRecID2").value.replace("q","");
    if(id=="-1")
    {
        alert("请选择一条计数器后操作！");
    }
    else
    {
        parent.ShowDialog(455, 150,'Customer/QtyMod.aspx?id='+id, '计数器');
    }
}

function ChkInput()
{
    parent.ShowDialog(750, 475,'Customer/InputDev.aspx', '导入机器档案');
}
function SerV()
{
    var id=document.getElementById("hfRecID2").value.replace("b","");
    if(id=="-1")
    {
        alert("请选择一条服务单后操作！");
    }
    else
    {
        parent.ShowDialog(860,444, 'Services/SerView.aspx?id='+id, '服务单');
    }
}
//调整窗口为默认大小
function changred()
{
    var h1=document.body.clientHeight-54;//表格高度
    var h2=h1-200;//固定占用高度
    $("cndiv").style.height=h2+"px";
    $("cnbut").style.height="200px";
    
    $("btnRed").style.display="none";
    $("btnMax").style.display="inline";
    $("btnMin").style.display="inline";
    
    if(typeof(tabnum)!="undefined")
    {
        for(i=1; i <tabnum; i++)
         {
             $("info"+i).style.height="153px";
             $("cndiv2"+i).style.height="116px";
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
    $("cndiv").style.height=h2+"px";
    $("cnbut").style.height="23px";
    
    $("btnRed").style.display="inline";
    $("btnMax").style.display="inline";
    $("btnMin").style.display="none";
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("机器档案");
}
function ChkAccToExcel()
{
    if($("hfRecID").value=="-1")
    {
        alert("请选择一条机器档案后操作！");
        return false;
    }
    return true;
}
/////
function ChkALL()
{
    var tb=document.getElementById("gvtrouble");
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
    var tb=document.getElementById("gvtrouble");
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
