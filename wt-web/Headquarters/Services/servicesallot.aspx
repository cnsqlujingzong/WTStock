<%@ page language="C#"  CodeFile="servicesallot.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Services_ServicesAllot" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/frame.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/page.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/tab.css" />
      <link href="/CodingPages/js/imgUpload/uploadify.css" type="text/css" rel="stylesheet" />
    <style>
         .imgDiv {
            float:left; margin:5px;border:2px solid #444
        }
            .imgDiv img {
                width:120px;height:120px;
            }
        .currImg {
        border:4px solid red;
        }
    </style>
    <script type="text/javascript" src="/CodingPages/js/jQuery-1.11.2.js"></script>
     <script type="text/javascript" src="/CodingPages/js/Base.js"></script>
      <script type="text/javascript" src="/CodingPages/js/imgUpload/jQuery.uploadify.min.js"></script>
<script type="text/javascript" src="/CodingPages/js/imgUpload/uploadswfobject.js"></script>
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
            <input id="btnTake" runat="server" type="button" value="服务受理" class="bt1" onclick="parent.ShowDialog(870,600, 'Services/ServicesAdd.aspx', '服务受理');" />
            <input id="btnMod" runat="server" type="button" value="查看修改" class="bt1" onclick="ChkView();" />
            <input id="btnCancel" runat="server" type="button" value="取消" class="bt1" onclick="ChkCancel();" />
            <input id="btnConf" runat="server" type="button" value="确认" visible="false" class="bt1" onclick="ChkConf();"/>
            <span style="display:none;">
                <asp:Button ID="btnClr" runat="server" Text="保留选中" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                <asp:Button ID="btnOrder" runat="server" Text="排序" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                <asp:Button ID="btnSchH" runat="server" Text="高级查询" CssClass="bt1" OnClick="btnSchH_Click" UseSubmitBehavior="False" />
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
                      <a href="#" onclick="printWXBJ()" class="iprint">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;维修报价</a>
                    <a href="#" onclick="printWXHT()" class="iprint">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;维修合同</a>
                     <a href="#" onclick="printPLHT()" class="iprint">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;批量合同</a>
                    <a href="#" onclick="printWXBG()" class="iprint">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;维修报告</a>
                <input id="btnPrint" runat="server" type="button" value="打印" class="iprint" onclick="ChkPrintChoise('PrintBill.aspx');" />
                </td>
                <td style="padding-left:0px;">
                    <asp:Button ID="btnExcel" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" /></td>
                <td>
                <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="0">模糊查询</asp:ListItem>
                    <asp:ListItem Value="1">按服务单号查询</asp:ListItem>
                    <asp:ListItem Value="2">按服务类别查询</asp:ListItem>
                    <asp:ListItem Value="3">按受理部门查询</asp:ListItem>
                    <asp:ListItem Value="4">按处理部门查询</asp:ListItem>
                    <asp:ListItem Value="5">按受理方式查询</asp:ListItem>
                    <asp:ListItem Value="6">按服务级别查询</asp:ListItem>
                    <asp:ListItem Value="7">按受理人查询</asp:ListItem>
                    <asp:ListItem Value="8">按客户名称查询</asp:ListItem>
                    <asp:ListItem Value="9">按联系人查询</asp:ListItem>
                    <asp:ListItem Value="10">按客户电话查询</asp:ListItem>
                    <asp:ListItem Value="11">按客户地址查询</asp:ListItem>
                    <asp:ListItem Value="12">按机器型号查询</asp:ListItem>
                    <asp:ListItem Value="13">按机器品牌查询</asp:ListItem>
                    <asp:ListItem Value="14">按机器类别查询</asp:ListItem>
                    <asp:ListItem Value="15">按机器序列号查询</asp:ListItem>
                    <asp:ListItem Value="16">按维修技术员查询</asp:ListItem>
                    <asp:ListItem Value="17">按故障查询</asp:ListItem>
                    <asp:ListItem Value="18">按保修情况查询</asp:ListItem>
                    <asp:ListItem Value="19">按备注查询</asp:ListItem>
                    <asp:ListItem Value="30">按客户编号查询</asp:ListItem>
                    <asp:ListItem Value="-1">查询全部</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server"  onkeydown="EnterTextBoxSch(event, this);" CssClass="pink" ToolTip="输入查询关键字"></asp:TextBox>
            </td>
            <td align="left">
            <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
            <td style="padding:0px;"><input id="btnSchsH" type="button" value="高级查询" class="bsch" onclick="parent.ShowDialog(470,428, 'Services/SerCd.aspx', '高级查询');" /></td>
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
            <asp:BoundField HeaderText="服务状态" DataField="curStatus" />
            <asp:BoundField HeaderText="预约时间" DataField="SubscribeTime" />
            <asp:BoundField HeaderText="服务单号" DataField="BillID" />
            <asp:BoundField HeaderText="服务状态" DataField="curStatus" />
            <asp:BoundField HeaderText="服务类别" DataField="ServicesType" />
            <asp:BoundField HeaderText="受理人" DataField="Operator" />
            <asp:BoundField HeaderText="受理时间" DataField="Time_TakeOver" />
            <asp:BoundField HeaderText="处理时间" DataField="Speding" />
            <asp:BoundField HeaderText="受理方式" DataField="TakeStyle" />
            <asp:BoundField HeaderText="受理部门" DataField="TakeDept" />
            <asp:BoundField HeaderText="报价确认" DataField="OfferConf" />
            <asp:BoundField HeaderText="项目确认" DataField="SerCount" />
            <asp:BoundField HeaderText="服务级别" DataField="_PRI" />
       <asp:BoundField HeaderText="网点" DataField="BranchName" />
                  <asp:BoundField HeaderText="税种" DataField="BranchRatioType" />
                  <asp:BoundField HeaderText="税率" DataField="BranchRatio" />
            <asp:BoundField HeaderText="技术员" DataField="DisposalOper" />  
            <asp:BoundField HeaderText="客户名称" DataField="CustomerName" />
            <asp:BoundField HeaderText="报修人" DataField="LinkMan" />
            <asp:BoundField HeaderText="报修人电话" DataField="Tel" />
            <asp:BoundField HeaderText="使用人" DataField="UsePerson" />
            <asp:BoundField HeaderText="使用人电话" DataField="UsePersonTel" />
            <asp:BoundField HeaderText="机器编号" DataField="DeviceNO" />
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
            <asp:BoundField HeaderText="再修" DataField="bAgain" />
            <asp:BoundField HeaderText="返修" DataField="bRepair" />
            <asp:BoundField HeaderText="备注" DataField="Remark" />
            <asp:BoundField HeaderText="bTake" DataField="bTake" />
            <asp:BoundField HeaderText="IsDismissed" DataField="IsDismissed" />
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
         <asp:HiddenField ID="hfSerNum" runat="server" Value="-1" />
    <asp:HiddenField ID="hfRecID2" runat="server" Value="-1" />
    <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
    <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfTbTitle" runat="server" />
    <asp:HiddenField ID="hfTbField" runat="server" />
    <asp:HiddenField ID="hfcbID" runat="server" />
    <asp:HiddenField ID="hfParm" runat="server" Value="-1" />
    <asp:HiddenField ID="hfTecPur" runat="server" Value="1" />
    <asp:HiddenField ID="hfPurArea" runat="server" Value="" />
    <asp:HiddenField ID="hfPurDept" runat="server" Value="0" />
    <asp:HiddenField ID="hfPurOPDept" runat="server" Value="0" />
    <asp:HiddenField ID="hfTecDept" runat="server" Value="0" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
    </Triggers>       
    </asp:UpdatePanel>
    </div>
    
    <div id="cnbut" style="overflow:hidden;">
        <div class="ftool2">
        <div id="mytabs" style="padding-left:2px;">
            <span id="tabs_l1"></span>
            <span id="tabs1" onclick="ChkTab('1');">工单处理</span>
            <span id="tabs_r1"></span>
            <span id="tabs_l2"></span>
            <span id="tabs2" onclick="ChkTab('2');">备件/耗材</span>
            <span id="tabs_r2"></span>
            <span id="tabs_l3"></span>
            <span id="tabs3" onclick="ChkTab('3');">服务项目</span>
            <span id="tabs_r3"></span>
            <span id="tabs_l4"></span>
            <span id="tabs4" onclick="ChkTab('4');">机器配置</span>
            <span id="tabs_r4"></span>
            <span id="tabs_l5"></span>
            <span id="tabs5" onclick="ChkTab('5');">服务报价</span>
            <span id="tabs_r5"></span>
            <span id="tabs_l6"></span>
            <span id="tabs6" onclick="ChkTab('6');">催单</span>
            <span id="tabs_r6"></span>
            <span id="tabs_l7"></span>
            <span id="tabs7" onclick="ChkTab('7');">计数器</span>
            <span id="tabs_r7"></span>
             <span id="tabs_l8"></span>
            <span id="tabs8" onclick="ChkTab('8');" >维修图片</span>
            <span id="tabs_r8"></span>
                  <span id="tabs_l9"></span>
            <span id="tabs9" onclick="ChkTab('9');" >日志</span>
            <span id="tabs_r9"></span>
        </div>
        </div>
        <div id="info1" style="height:175px;background:#ECE9D8;">
        <div style="border-bottom:#808080 1px solid;">
            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
            <ContentTemplate>
           <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td>
               <input id="btnNewS" type="button" value="处理" class="bt1" onclick="NewS();" />
               <input id="btnModS" type="button" value="修改" class="bt1" onclick="ModS();" />
               <asp:Button ID="btnDelS" runat="server" Text="删除" CssClass="bt1" OnClientClick="if(ChkDel2('处理')==false) return false;"  UseSubmitBehavior="false" OnClick="btnDelS_Click" />
            </td>
            </tr>
           </table>
           </ContentTemplate>
           <Triggers>
           <asp:AsyncPostBackTrigger ControlID = "btnDelS" EventName = "Click" />
           </Triggers>
           </asp:UpdatePanel>
        </div>
        <div class="cndiv2" id="Div4" style="height:145px;">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="序"/>
                            <asp:BoundField HeaderText="处理方式" DataField="DoStyle" />
                            <asp:BoundField HeaderText="操作人" DataField="Person" />
                            <asp:BoundField HeaderText="处理网点" DataField="Dept" />
                            <asp:BoundField HeaderText="处理人" DataField="Operator" />
                            <asp:BoundField HeaderText="处理时间" DataField="_Date" />
                            <asp:BoundField HeaderText="处理措施/结果" DataField="TakeSteps" />
                            <asp:BoundField HeaderText="到达时间" DataField="StartTime" />
                            <asp:BoundField HeaderText="处理时长" DataField="Spending" />
                            <asp:BoundField HeaderText="完成时间" DataField="ArrivedTime" />
                            <asp:BoundField HeaderText="故障原因" DataField="Reason" />
                            <asp:BoundField HeaderText="下步处理部门" DataField="DoDept" />
                            <asp:BoundField HeaderText="下步处理人" DataField="DoOperator" />
                            <asp:BoundField HeaderText="上门时间" DataField="visitdate" />
                            <asp:BoundField HeaderText="处理过程" DataField="Course" />
                         </Columns>
                    </asp:GridView>
                    </ContentTemplate>
                 <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnDelS" EventName="Click" />
                </Triggers>
                 </asp:UpdatePanel>
            </div>
        </div>
        
        <div id="info2" style="height:175px;background:#ECE9D8;">
        <div style="border-bottom:#808080 1px solid;">
        <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
           <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td>
               <input id="btnNewM" type="button" value="新建" class="bt1" onclick="NewM();" />
               <input id="btnModM" type="button" value="修改" class="bt1" onclick="ModM();" />
               <asp:Button ID="btnDelM" runat="server" Text="删除" CssClass="bt1" OnClientClick="if(ChkDel2('配件')==false) return false;"  UseSubmitBehavior="false" OnClick="btnDelM_Click" />
               <input id="btnBroughtM" type="button" runat="server" value="备件领退" class="bt1" onclick="BroughtM();" />
            </td>
            </tr>
           </table>
           </ContentTemplate>
                 <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnDelM" EventName="Click" />
                </Triggers>
                </asp:UpdatePanel>
        </div>
        <div class="cndiv2" id="cndiv2" style="height:145px;">
            <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView2_RowDataBound" ShowFooter="true">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="序"/>
                            <asp:BoundField HeaderText="产品编号" DataField="GoodsNO" />
                            <asp:BoundField HeaderText="名称" DataField="_Name" />
                            <asp:BoundField HeaderText="规格" DataField="Spec" />
                            <asp:BoundField HeaderText="品牌" DataField="ProductBrand" />
                            <asp:BoundField HeaderText="单位" DataField="Unit" />
                            <asp:BoundField HeaderText="数量" DataField="Qty" />
                            <asp:BoundField HeaderText="已领数量" DataField="LQty" />
                            <asp:BoundField HeaderText="单价" DataField="Price" />
                            <asp:BoundField HeaderText="税率" DataField="TaxRate" />
                            <asp:BoundField HeaderText="税额" DataField="TaxAmount" />
                            <asp:BoundField HeaderText="金额" DataField="Total" />
                            <asp:BoundField HeaderText="序列号" DataField="SN" />
                            <asp:BoundField HeaderText="保修期" DataField="MaintenancePeriod" />
                            <asp:BoundField HeaderText="截止日期" DataField="PeriodEndDate" />
                            <asp:BoundField HeaderText="结算方式" DataField="ChargeStyle" />
                            <asp:BoundField HeaderText="是否外购" DataField="OutSourcing" />
                            <asp:BoundField HeaderText="外购单价" DataField="OutCostPrice" />
                            <asp:BoundField HeaderText="备注" DataField="Remark" />
                         </Columns>
                    </asp:GridView>
                    </ContentTemplate>
                 <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnDelM" EventName="Click" />
                </Triggers>
                 </asp:UpdatePanel>
        </div>
        </div>
        
        <div id="info3" style="height:175px;background:#ECE9D8;">
            <div style="border-bottom:#808080 1px solid;">
               <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                   <input id="btnNewI" type="button" value="新建" class="bt1" onclick="NewI();" />
                   <input id="btnModI" type="button" value="修改" class="bt1" onclick="ModI();" />
                   <asp:Button ID="btnDelI" runat="server" Text="删除" CssClass="bt1" OnClientClick="if(ChkDel2('项目')==false) return false;"  UseSubmitBehavior="false" OnClick="btnDelI_Click" />
                </td>
                </tr>
               </table>
            </div>
            <div class="cndiv2" id="Div1" style="height:116px;">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView3_RowDataBound" ShowFooter="true">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="序"/>
                            <asp:BoundField HeaderText="项目编号" DataField="ItemNO" />
                            <asp:BoundField HeaderText="名称" DataField="_Name" />
                            <asp:BoundField HeaderText="金额" DataField="Price" />
                            <asp:BoundField HeaderText="工时" DataField="dPoint" />
                            <asp:BoundField HeaderText="提成" DataField="TecDeduct" />
                            <asp:BoundField HeaderText="结算方式" DataField="ChargeStyle" />
                            <asp:BoundField HeaderText="是否完工" DataField="bComplete" />
                            <asp:BoundField HeaderText="备注" DataField="Remark" />
                         </Columns>
                    </asp:GridView>
                    </ContentTemplate>
                 <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnDelI" EventName="Click" />
                </Triggers>
                 </asp:UpdatePanel>
            </div>
        </div>
        
        <div id="info4" style="height:175px;background:#ECE9D8;">
            <div style="border-bottom:#808080 1px solid;">
               <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                   <input id="btnNewDevConf" type="button" value="新建" class="bt1" onclick="NewDevConf();" />
                   <input id="btnModDevConf" type="button" value="修改" class="bt1" onclick="ModDevConf();" />
                   <asp:Button ID="btnDelD" runat="server" Text="删除" CssClass="bt1" OnClientClick="if(ChkDel2('机器配置')==false) return false;"  UseSubmitBehavior="false" OnClick="btnDelD_Click" />
                </td>
                </tr>
               </table>
            </div>
            <div class="cndiv2" id="Div2" style="height:116px;">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView4_RowDataBound">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="序"/>
                            <asp:BoundField HeaderText="名称" DataField="_Name" />
                            <asp:BoundField HeaderText="参数" DataField="Parameter" />
                            <asp:BoundField HeaderText="序列号" DataField="SN" />
                            <asp:BoundField HeaderText="保修期" DataField="MaintenancePeriod" />
                            <asp:BoundField HeaderText="截止日期" DataField="MaintenanceEnd" />
                            <asp:BoundField HeaderText="购买日期" DataField="BuyDate" />
                            <asp:BoundField HeaderText="备注" DataField="Remark" />
                         </Columns>
                    </asp:GridView>
                    </ContentTemplate>
                 <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnDelD" EventName="Click" />
                </Triggers>
                 </asp:UpdatePanel>
            </div>
        </div>
        
        <div id="info5" style="height:175px;background:#ECE9D8;">
            <div style="border-bottom:#808080 1px solid;">
               <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                   <input id="btnNewOffer" type="button" value="新建" class="bt1" onclick="NewO();" />
                   <input id="btnModOffer" type="button" value="修改" class="bt1" onclick="ModO();" />
                   <asp:Button ID="btnDelO" runat="server" Text="删除" CssClass="bt1" OnClientClick="if(ChkDel2('服务报价')==false) return false;"  UseSubmitBehavior="false" OnClick="btnDelO_Click" />
                </td>
                </tr>
               </table>
            </div>
            <div class="cndiv2" id="Div5" style="height:116px;">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView6_RowDataBound">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="序"/>
                            <asp:BoundField HeaderText="日期" DataField="_Date" />
                            <asp:BoundField HeaderText="操作人" DataField="Operator" />
                            <asp:BoundField HeaderText="报价人" DataField="Seller" />
                            <asp:BoundField HeaderText="报价项目" DataField="_Name" />
                            <asp:BoundField HeaderText="金额" DataField="dAmount" />
                            <asp:BoundField HeaderText="客户确认" DataField="CusConf" />
                            <asp:BoundField HeaderText="备注" DataField="Remark" />
                         </Columns>
                    </asp:GridView>
                    </ContentTemplate>
                 <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnDelO" EventName="Click" />
                </Triggers>
                 </asp:UpdatePanel>
            </div>
        </div>
        
        <div id="info6" style="height:175px;background:#ECE9D8;">
            <div style="border-bottom:#808080 1px solid;">
               <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                   <input id="btnNewP" type="button" value="新建" class="bt1" onclick="NewP();" />
                   <input id="btnModP" type="button" value="修改" class="bt1" onclick="ModP();" />
                   <asp:Button ID="btnDelP" Visible="false" runat="server" Text="删除" CssClass="bt1" OnClientClick="if(ChkDel2('催单')==false) return false;"  UseSubmitBehavior="false" OnClick="btnDelP_Click" />
                </td>
                </tr>
               </table>
            </div>
            <div class="cndiv2" id="Div3" style="height:116px;">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView5_RowDataBound">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="序"/>
                            <asp:BoundField HeaderText="催单人" DataField="LinkMan" />
                            <asp:BoundField HeaderText="联系电话" DataField="Tel" />
                            <asp:BoundField HeaderText="催单时间" DataField="_Date" />
                            <asp:BoundField HeaderText="受理人" DataField="Operator" />
                            <asp:BoundField HeaderText="处理结果" DataField="Result" />
                         </Columns>
                    </asp:GridView>
                    </ContentTemplate>
                 <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnDelP" EventName="Click" />
                </Triggers>
                 </asp:UpdatePanel>
            </div>
        </div>
        
        <div id="info7" style="height:175px;background:#ECE9D8;">
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
            <div class="cndiv2" id="Div7" style="height:145px;">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView7_RowDataBound">
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
                    <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnDelQty" EventName="Click" />
                </Triggers>
                 </asp:UpdatePanel>
            </div>
        </div>
           <div id="info8" style="height:175px;background:#ECE9D8;">
            <div style="border-bottom:#808080 1px solid;">
            <div style="float:left; width:220px;">
                  <form id="form2"  enctype="multipart/form-data">
                <div style="padding-top:10px; padding-left:15px">

                   <span style="font-size:15px"> 照片类型：</span>
                    <select id="phoType" style="width:120px;height:20px">                   
                          <option value="维修前">维修前</option>
                          <option value="维修中">维修中</option>
                          <option value="维修完">维修完</option>
                    </select>
                    <br /><br />
                    <input type="file" name="uploadify" id="uploadify" />&nbsp;  <a href="javascript:jQuery('#uploadify').uploadifyUpload()">上传</a>| <a href="javascript:jQuery('#uploadify').uploadifyClearQueue()">取消上传</a>
                </div>
                <div id="fileQueue"></div>
                <div style="clear: both;"></div>
            </form>
            </div>        
                <div style="float:left; padding-top:10px; padding-left:15px">
                              <div id="delImg" class="button" style="padding:3px; background:red; color:#fff; width:70px; cursor:pointer">--选中删除--</div>
                     <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
          <div id="imgView">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div class='imgDiv' currid='<%# Eval("ID") %>'><div style="width:100%;text-align:center"><%#Eval("ImgType") %></div><img src='<%# Eval("ImgSrc") %>'  alt/></div>
                    </ItemTemplate>

                </asp:Repeater>
            </div>
                    </ContentTemplate>
                          <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnDelQty" EventName="Click" />
                </Triggers>
                         </asp:UpdatePanel>
                </div>
        <div style="clear:both;">

        </div>        
         </div>
              </div>
        <div id="info9" style="height:175px;background:#ECE9D8;">
            <div>
                    <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                   <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="序"/>
                    <asp:BoundField HeaderText="时间" DataField="_Date"/>
                    <asp:BoundField HeaderText="操作员" DataField="Operator"/>
                    <asp:BoundField HeaderText="事件" DataField="Event" />
                </Columns>
             </asp:GridView>
                       </ContentTemplate>
                     <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnDelQty" EventName="Click" />
                </Triggers>
                         </asp:UpdatePanel>
            </div>
           </div>
    <div class="fbom">  
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td><div id="fbon" class="fbon"></div></td>
            <td>
                <span class="sred">待处理</span>
                <span class="sgreen">处理中</span>
                <span class="sblue">预约提醒</span>
                <span class="syellows">修完未取</span>
                <span class="stin">被驳回</span>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
    var serNum = "";
    var t = "";
    jQuery(function () {
        jQuery.noConflict();    
     
        //删除图片
        jQuery("#delImg").click(function () {         

            var imgid = jQuery("#imgView .currImg").attr("currId");
            Base.ajaxPost("/CodingPages/js/imgUpload/Upload.ashx", { delid: imgid, type: 'imgstock' }, function (data) {
                if (data=="1") {
                    // window.location.href = window.location.href;
                    $("btnShow").click();
                } else {
                    alert("请重试");
                }
            });
        });
        jQuery(".imgDiv").click(function () {
            jQuery(".imgDiv").removeClass("currImg");
            jQuery(this).addClass("currImg");

        });
         t = jQuery("#phoType").val();
         jQuery("#phoType").change(function () {
             t = jQuery("#phoType").val();
             try{
                 jQuery("#uploadify").uploadifySettings("script", "/CodingPages/js/imgUpload/Upload.ashx?type=imgstock&&source=" + t + "&&pid=" + serNum); //动态更新配(执行此处时可获得值)
             }catch(ex){}
        });
       
        jQuery("#uploadify").uploadify({
            'uploader': '/CodingPages/js/imgUpload/uploadify.swf',
            'script': '/CodingPages/js/imgUpload/Upload.ashx',
            'cancelImg': '/CodingPages/js/imgUpload/images/cancel.png',
            'folder': '/upload/ImgStock',
            'queueID': 'fileQueue',
            'auto': false,
            'multi': true,
            'fileExt': '*.jpg;*.gif;*.png',
            'fileDesc': 'Web Image Files (.JPG, .GIF, .PNG)',
            'buttonText': '浏览',
            'onSelect': function (event, queueID, fileObj) {
                jQuery("#uploadify").uploadifySettings("script", "/CodingPages/js/imgUpload/Upload.ashx?type=imgstock&&source=" + t + "&&pid=" + serNum); //动态更新配(执行此处时可获得值)

            },
            'onError': function (event, queueId, fileObj, errorObj) {
                alert(errorObj.info + "---------" + errorObj.type);
            },
            'onAllComplete': function () {
                //ShowImg();
                // window.location.href = window.location.href;
                $("btnShow").click();
            }
        });
    })
    //初始化图片上传控件
    function initImgUpload(id) {
       // var t = jQuery("#phoType").val();
      //  jQuery("#uploadifyUploader").remove();
        jQuery("#uploadify").uploadify({
            'uploader': '/CodingPages/js/imgUpload/uploadify.swf',
            'script': '/CodingPages/js/imgUpload/Upload.ashx',
            'cancelImg': '/CodingPages/js/imgUpload/images/cancel.png',
            'folder': '/upload/ImgStock',
            'queueID': 'fileQueue',
            'auto': false,
            'multi': true,
            'fileExt': '*.jpg;*.gif;*.png',
            'fileDesc': 'Web Image Files (.JPG, .GIF, .PNG)',
            'buttonText': '浏览',
            'onSelect': function (event, queueID, fileObj) {
                jQuery("#uploadify").uploadifySettings("script", "/CodingPages/js/imgUpload/Upload.ashx?type=imgstock&&source=" + t + "&&pid=" + id); //动态更新配(执行此处时可获得值)

            },
            'onError': function (event, queueId, fileObj, errorObj) {
                alert(errorObj.info + "---------" + errorObj.type);
            },
            'onAllComplete': function () {
                //ShowImg();
                // window.location.href = window.location.href;
                $("btnShow").click();
            }
        });
    }

var noOpen=1;
var isfocus=2;
var tabnum = 10;

function ChkID(id,dn)
{
    ClrID(id);
    serNum = dn;
    //initImgUpload(serNum);//图片控件初始化
    try{
        jQuery("#uploadify").uploadifySettings("script", "/CodingPages/js/imgUpload/Upload.ashx?type=imgstock&&source=" + t + "&&pid=" + serNum); //动态更新配(执行此处时可获得值)
    }    catch(ex){}
    document.getElementById("hfSerNum").value = dn;
    $("btnShow").click();
 
 
}
function bingclick()
{
    jQuery(".imgDiv").click(function () {
        jQuery(".imgDiv").removeClass("currImg");
        jQuery(this).addClass("currImg");

    });
}
function NewS()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("请选择一条服务单后操作！");
        return false;
    }
    parent.ShowDialog(520, 354, 'Services/AddS.aspx?id='+id, '工单处理')
}

function ModS()
{
    var id=document.getElementById("hfRecID2").value;
    if(id=="-1")
    {
        alert("请选择一条处理过程明细后操作!");
    }
    else
    {
        parent.ShowDialog(520, 354, 'Services/ModS.aspx?id='+id, '工单处理');
    }
}

function NewM()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("请选择一条服务单后操作！");
        return false;
    }
    parent.ShowDialog(800, 400, 'Services/AddM.aspx?id='+id, '新建配件')
}

function ModM()
{
    var id=document.getElementById("hfRecID2").value;
    if(id=="-1")
    {
        alert("请选择一条使用配件明细后操作!");
    }
    else
    {
        parent.ShowDialog(480, 319, 'Services/ModM.aspx?id='+id, '修改配件');
    }
}

function NewI()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("请选择一条服务单后操作！");
        return false;
    }
    parent.ShowDialog(800, 400, 'Services/AddI.aspx?id='+id, '新建服务项目')
}

function ModI()
{
    var id=document.getElementById("hfRecID2").value;
    if(id=="-1")
    {
        alert("请选择一条服务项目明细后操作!");
    }
    else
    {
        parent.ShowDialog(480, 205, 'Services/ModI.aspx?id='+id, '修改服务项目');
    }
}

function NewDevConf()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("请选择一条服务单后操作！");
        return false;
    }
    parent.ShowDialog(800, 400, 'Services/AddD.aspx?id='+id, '新建机器配置')
}

function ModDevConf()
{
    var id=document.getElementById("hfRecID2").value;
    if(id=="-1")
    {
        alert("请选择一条机器配置明细后操作!");
    }
    else
    {
        parent.ShowDialog(460, 175, 'Services/ModD.aspx?id='+id, '修改机器配置');
    }
}

function NewO()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("请选择一条服务单后操作！");
        return false;
    }
    parent.ShowDialog(500, 340, 'Services/AddO.aspx?id='+id, '服务报价')
}
function NewQty()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("请选择一条机器档案后操作！");
        return false;
    }
    parent.ShowDialog(455, 150, 'Customer/QtyAdd.aspx?id='+id+'&iflag=2', '计数器');
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
function ModO()
{
    var id=document.getElementById("hfRecID2").value;
    if(id=="-1")
    {
        alert("请选择一条使用配件明细后操作!");
    }
    else
    {
        parent.ShowDialog(460, 180, 'Services/ModO.aspx?id='+id, '修改报价');
    }
}


function NewP()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("请选择一条服务单后操作！");
        return false;
    }
    parent.ShowDialog(460, 175, 'Services/AddP.aspx?id='+id, '新建催单')
}

function BroughtM()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("请选择一条服务单后操作！");
        return false;
    }
    parent.ShowDialog(800, 480, 'Stock/BroughtM.aspx?id='+id, '领退开单')
}
function ModP()
{
    var id=document.getElementById("hfRecID2").value;
    if(id=="-1")
    {
        alert("请选择一条使用催单明细后操作!");
    }
    else
    {
        parent.ShowDialog(460, 175, 'Services/ModP.aspx?id='+id, '修改催单');
    }
}

function ChkView()
{
    ChkMod(870,600, 'Services/SerMod.aspx', '修改服务单');
}
function ChkConf()
{
    var id=$("hfcbID").value;
    if(id=="")
        id=$("hfRecID").value;
    if(ChkSltValue()!=false)
    {
        parent.ShowDialog1(460,98, 'Services/SerConf.aspx?id='+id+'&iflag=1', '确认服务单');
    }
}

function ChkCancel()
{
    var id=$("hfcbID").value;
    if(id=="")
        id=$("hfRecID").value;
    if(ChkSltValue()!=false)
    {
        parent.ShowDialog(460, 95, 'Services/SerCancel.aspx?id='+id, '取消服务单');
    }
}
function printPLHT() {
    var oid = $("hfcbID").value;
    if (oid == "")
        oid = $("hfRecID").value;
    if (ChkSltValue() != false) {
        parent.ShowDialog1(400, 300, 'Print/PrintItex.aspx?ptype=plht&&oid=' + oid, '批量打印合同');
    }
}
             function printWXBJ()
             {
                 var oid = $("hfRecID").value;
                 if (isNull(oid)) {
                     window.alert("操作失败！没有选择服务单");
                     return false
                 }
                     parent.ShowDialog1(400, 300, 'Print/PrintItex.aspx?ptype=wxbj&&oid=' + oid, '打印维修报价');
                 
             }
             function printWXHT()
             {
                 var oid = $("hfRecID").value;
                 if (isNull(oid))
                 {
                     window.alert("操作失败！没有选择服务单");  
                     return false
                 }
                 parent.ShowDialog1(400, 300, 'Print/PrintItex.aspx?ptype=wxht&&oid=' + oid, '打印维修合同');
             }
             function printWXBG()
             {
                 var oid = $("hfRecID").value;
                 if (isNull(oid))
                 {
                     window.alert("操作失败！没有选择服务单");  
                     return false
                 }
                 parent.ShowDialog1(400, 300, 'Print/PrintItex.aspx?ptype=wxbg&&oid=' + oid, '打印维修报告');
             }
function ViewSN(strsn)
{
    parent.ShowDialog1(400, 300, 'Stock/ViewSN.aspx?sn='+escape(strsn), '查看序列号');
}

function Chkset()
{
    Chkwhs();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("服务中心");
}
</script>
