<%@ page language="C#"  CodeFile="cuslistadm.aspx.cs"     autoeventwireup="true" inherits="Branch_Customer_CusListAdm" theme="Themes" enableEventValidation="false" %>
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
                <input id="btnNew" type="button" value="新建" class="bt1" onclick="NewCus();" />
                <input id="btnMod" type="button" value="修改" class="bt1" onclick="ChkMod(600, 430,'Customer/CusMod.aspx','修改客户');" />
                <asp:Button ID="btnDel" runat="server" Text="删除" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkDelCus()==false) return false;" OnClick="btnDel_Click"/>
                <input id="btnAllot" runat="server" type="button" value="分派" class="bt1" onclick="ChkAllot();" />
                <input id="btnMerge" runat="server" type="button" value="合并" class="bt1" onclick="ChkMerge();" />
                <span style="display:none;">
                    <asp:Button ID="btnClr" runat="server" Text="保留选中" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                    <asp:Button ID="btnOrder" runat="server" Text="排序" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                    <asp:Button ID="btnShow" runat="server" Text="show" CssClass="bt1" OnClick="btnShow_Click" UseSubmitBehavior="False" />
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
                    <input id="btnClass" runat="server" type="button" class="bclass" value="批量修改" onclick="ChkEditClass();" />
                    <input id="btntel" runat="server" type="button" class="btel" value="群发" onclick="SmsSndCBat();" />
                </td>
                <td>
                    <input id="btnInput" runat="server" type="button" class="binput" value="导入" onclick="ChkInput();" />
                </td>
                <td>
                    <asp:Button ID="btnExcel" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" />
                </td>
                <td>
                    <asp:DropDownList ID="ddlKey" runat="server" onchange="document.getElementById('tbCon').focus();" CssClass="pindl" Width="120">
                        <asp:ListItem Value="0">模糊查询</asp:ListItem>
                        <asp:ListItem Value="1">按客户编号查询</asp:ListItem>
                        <asp:ListItem Value="2">按客户名称查询</asp:ListItem>
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
                        <asp:ListItem Value="13">按备注查询</asp:ListItem>
                        <asp:ListItem Value="-1">查询全部</asp:ListItem>
                    </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="tbCon" runat="server" onkeydown="EnterTextBoxSch(event, this);" CssClass="pink" ToolTip="输入查询关键字" Width="100"></asp:TextBox>
            </td><td align="left">
                <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
                    <td>
                <input id="btnSchsH" type="button" value="高级查询" class="bsch" onclick="parent.ShowDialog(460,313, 'Customer/SchHCus.aspx', '高级查询');" />
            </td></tr>
            </table>   
        </div>
        <div class="clearfloat"></div>
    </div>
    
    <div id="lndiv" class="lndiv">
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
    <div id="lncn" class="uwl" onclick="changleft();"></div>
    <div id="cndiv" style="float:left;height:1px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvcus" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvcus_RowDataBound" EnableViewState="false">
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
            <asp:BoundField HeaderText="会员级别" DataField="Member" />
            <asp:BoundField HeaderText="客户状态" DataField="Status" />
            <asp:BoundField HeaderText="跟踪人" DataField="TrackOperator" />
            <asp:BoundField HeaderText="登记部门" DataField="DeptID" />
            <asp:BoundField HeaderText="登记时间" DataField="_Date" />
            <asp:BoundField HeaderText="自定义1" DataField="userdef1" />
            <asp:BoundField HeaderText="自定义2" DataField="userdef2" />
            <asp:BoundField HeaderText="自定义3" DataField="userdef3" />
            <asp:BoundField HeaderText="自定义4" DataField="userdef4" />
            <asp:BoundField HeaderText="自定义5" DataField="userdef5" />
            <asp:BoundField HeaderText="自定义6" DataField="userdef6" />
            <asp:BoundField HeaderText="回访标志" DataField="bCall" />
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
        <asp:HiddenField ID="hfSltType" runat="server" Value="1" />
        <asp:HiddenField ID="hfPurDev" runat="server" Value="1" />
        <asp:HiddenField ID="hfPurSer" runat="server" Value="1" />
        <asp:HiddenField ID="hfPurSel" runat="server" Value="1" />
        <asp:HiddenField ID="hfPurCont" runat="server" Value="1" />
        <asp:HiddenField ID="hfPurLea" runat="server" Value="1" />
        <asp:HiddenField ID="hfPurArea" runat="server" />
        <asp:HiddenField ID="hfCusTrack" runat="server"/>
        <asp:HiddenField ID="hfPur1" runat="server" />
        <asp:HiddenField ID="hfPur2" runat="server" />
        <asp:HiddenField ID="hfPur3" runat="server" />
        <asp:HiddenField ID="hfPur4" runat="server" />
        <asp:HiddenField ID="hfcbID" runat="server" />
        <asp:HiddenField ID="hfParm" runat="server" Value="-1" />
        <asp:HiddenField ID="hfPurTDev" runat="server" />
        <asp:HiddenField ID="hfPurDept" runat="server" Value="0" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="tvcus" EventName="SelectedNodeChanged" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    
    <div id="cnbut" style="overflow:hidden;">
        <div class="ftool2">
        <div id="mytabs">
            <span id="tabs_l1"></span>
            <span id="tabs1" onclick="ChkTab('1');ChkSltD('1');">机器档案</span>
            <span id="tabs_r1"></span>
            <span id="tabs_l2"></span>
            <span id="tabs2" onclick="ChkTab('2');ChkSltD('2');">联系人组</span>
            <span id="tabs_r2"></span>
            <span id="tabs_l3"></span>
            <span id="tabs3" onclick="ChkTab('3');ChkSltD('3');">下属部门</span>
            <span id="tabs_r3"></span>
            <span id="tabs_l9"></span>
            <span id="tabs9" onclick="ChkTab('9');ChkSltD('9');">客户跟踪</span>
            <span id="tabs_r9"></span>
            <span id="tabs_l4"></span>
            <span id="tabs4" onclick="ChkTab('4');ChkSltD('4');">服务合同</span>
            <span id="tabs_r4"></span>
            <span id="tabs_l5"></span>
            <span id="tabs5" onclick="ChkTab('5');ChkSltD('5');">附件列表</span>
            <span id="tabs_r5"></span>
            <span id="tabs_l6"></span>
            <span id="tabs6" onclick="ChkTab('6');ChkSltD('6');">服务单</span>
            <span id="tabs_r6"></span>
            <span id="tabs_l7"></span>
            <span id="tabs7" onclick="ChkTab('7');ChkSltD('7');">销售单</span>
            <span id="tabs_r7"></span>
            <span id="tabs_l8"></span>
            <span id="tabs8" onclick="ChkTab('8');ChkSltD('8');">租赁/全保</span>
            <span id="tabs_r8"></span>
            <span id="tabs_l10"></span>
            <span id="tabs10" onclick="ChkTab('10');ChkSltD('10');">分派记录</span>
            <span id="tabs_r10"></span>
            <span class="cbnoshow">
                <asp:CheckBox ID="cbNoShow" runat="server" Text="搜索不显示明细" Checked="true" /></span>
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
                   <input id="btnNewD" type="button" value="新建" class="bt1" onclick="NewD();" />
                   <input id="btnModD" type="button" value="修改" class="bt1" onclick="ModD();" />
                   <asp:Button ID="btnDelD" runat="server" Text="删除" CssClass="bt1" OnClientClick="if(ChkDel2('机器档案')==false) return false;" UseSubmitBehavior="false" OnClick="btnDelD_Click" />
                </td>
                </tr>
               </table>
            </div>
            <div class="cndiv2" id="cndiv21" style="height:145px;">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:GridView ID="gvtrouble" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvtrouble_RowDataBound" EnableViewState="false">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="机器编号" DataField="DeviceNO" />
                            <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
                            <asp:BoundField HeaderText="所属部门" DataField="CusDept" />
                            <asp:BoundField HeaderText="联系电话" DataField="Tel" />
                            <asp:BoundField HeaderText="手机号码" DataField="Tel2" />
                            <asp:BoundField HeaderText="传真" DataField="Fax" />
                            <asp:BoundField HeaderText="邮编" DataField="Zip" />
                            <asp:BoundField HeaderText="地址" DataField="Adr" />
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
                            <asp:BoundField HeaderText="厂家保修截至" DataField="WarrantyEnd" />
                            <asp:BoundField HeaderText="维修次数" DataField="RepairTimes" />
                            <asp:BoundField HeaderText="最近维修时间" DataField="Repairlately" />
                            <asp:BoundField HeaderText="维修保修截至" DataField="RepairWarrantyEnd" />
                            <asp:BoundField HeaderText="合同保修开始" DataField="ContractWarrantyStart" />
                            <asp:BoundField HeaderText="合同保修截至" DataField="ContractWarrantyEnd" />
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
                            <td><webdiyer:aspnetpager id="jsPagerd" runat="server" onpagechanged="jsPagerd_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="跳转:" /></td>
                            <td style="padding-left:8px;"><asp:Label ID="lbPaged" runat="server" ToolTip="当页显示数"></asp:Label></td>
                            <td style="padding-left:8px;"><asp:Label ID="lbCountTextd" runat="server" Visible="false" ToolTip="总记录数" Text="总记录:"></asp:Label><asp:Label ID="lbCountd" runat="server" ToolTip="总记录数"></asp:Label></td>
                        </tr>
                    </table>
                    
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnDelD" EventName="Click" />
                         <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="tvcus" EventName="SelectedNodeChanged" />
                        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
                    </Triggers>       
                    </asp:UpdatePanel>
            </div>
        </div>
        
        <div id="info2" style="height:175px;background:#ECE9D8;">
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
            <div class="cndiv2" id="cndiv22" style="height:145px;">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView1_RowDataBound" EnableViewState="false">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="姓名" DataField="_Name" />
                            <asp:BoundField HeaderText="所属部门" DataField="LinkManDept" />
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
                         <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="tvcus" EventName="SelectedNodeChanged" />
                        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
                    </Triggers>       
                    </asp:UpdatePanel>
            </div>
        </div>
        
        <div id="info3" style="height:175px;background:#ECE9D8;">
            <div style="border-bottom:#808080 1px solid;">
               <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                   <input id="btnNewDept" type="button" value="新建" class="bt1" onclick="NewDept();" />
                   <input id="btnModDept" type="button" value="修改" class="bt1" onclick="ModDept();" />
                   <asp:Button ID="btnDelDept" runat="server" Text="删除" CssClass="bt1" OnClientClick="if(ChkDel2('下属部门')==false) return false;"  UseSubmitBehavior="false" OnClick="btnDelDept_Click" />
                </td>
                </tr>
               </table>
            </div>
            <div class="cndiv2" id="cndiv23" style="height:145px;">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView2_RowDataBound" EnableViewState="false" Width="60%">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="部门" DataField="_Name" />
                            <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
                            <asp:BoundField HeaderText="联系电话" DataField="Tel" />
                            <asp:BoundField HeaderText="备注" DataField="Remark" />
                        </Columns>
                    </asp:GridView>

                    <table cellpadding="0" cellspacing="0" class="pages">
                        <tr>
                            <td><webdiyer:aspnetpager id="jsPagerp" runat="server" onpagechanged="jsPagerp_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="跳转:" /></td>
                            <td style="padding-left:8px;"><asp:Label ID="lbPagep" runat="server" ToolTip="当页显示数"></asp:Label></td>
                            <td style="padding-left:8px;"><asp:Label ID="lbCountTextp" runat="server" Visible="false" ToolTip="总记录数" Text="总记录:"></asp:Label><asp:Label ID="lbCountp" runat="server" ToolTip="总记录数"></asp:Label></td>
                        </tr>
                    </table>
                    
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnDelDept" EventName="Click" />
                         <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="tvcus" EventName="SelectedNodeChanged" />
                        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
                    </Triggers>       
                    </asp:UpdatePanel>
            </div>
        </div>
        <div id="info9" style="height:175px;background:#ECE9D8;">
            <div style="border-bottom:#808080 1px solid;">
               <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                   <input id="btnNewT" runat="server" type="button" value="新建" class="bt1" onclick="NewT();" />
                   <input id="btnModT" runat="server" type="button" value="修改" class="bt1" onclick="ModT();" />
                   <asp:Button ID="btnDelT" runat="server" Text="删除" CssClass="bt1" OnClientClick="if(ChkDel2('跟踪信息')==false) return false;"  UseSubmitBehavior="false" OnClick="btnDelT_Click" />
                </td>
                <td align="right">
                    <asp:Button ID="btnExeclRecord" runat="server" CssClass="bt1" Text="导出" OnClientClick=" return chkRecord();" OnClick="btnExeclRecord_Click" />
                </td>
                </tr>
               </table>
            </div>
            <div class="cndiv2" id="cndiv29">
                <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView8_RowDataBound" EnableViewState="false">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="跟踪日期" DataField="_Date" />
                            <asp:BoundField HeaderText="跟踪人" DataField="Operator" />
                            <asp:BoundField HeaderText="跟踪内容" DataField="Content" />
                            <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
                            <asp:BoundField HeaderText="联系电话" DataField="Tel" />
                            <asp:BoundField HeaderText="跟踪方式" DataField="TrackStyle" />
                            <asp:BoundField HeaderText="跟踪类别" DataField="TrackType" />
                            <asp:BoundField HeaderText="跟踪结果" DataField="Result" />
                            <asp:BoundField HeaderText="下次跟踪日期" DataField="NextTrack" />
                            <asp:BoundField HeaderText="不再跟踪" DataField="bTrack" />
                        </Columns>
                    </asp:GridView>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnDelT" EventName="Click" />
                         <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="tvcus" EventName="SelectedNodeChanged" />
                        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
                    </Triggers>       
                    </asp:UpdatePanel>
            </div>
        </div>
        <div id="info4" style="height:175px;background:#ECE9D8;">
            <div style="border-bottom:#808080 1px solid;">
               <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                   <input id="btnNewCont" type="button" value="新建" class="bt1" onclick="NewCont();" />
                   <input id="btnModCont" type="button" value="修改" class="bt1" onclick="ModCont();" />
                   <asp:Button ID="btnDelCont" runat="server" Text="删除" CssClass="bt1" OnClientClick="if(ChkDel2('服务合同')==false) return false;"  UseSubmitBehavior="false" OnClick="btnDelCont_Click" />
                    <input id="btnCancel" runat="server" type="button" value="终止" class="bt1" onclick="ChkCancel();" />
                </td>
                </tr>
               </table>
            </div>
            <div class="cndiv2" id="cndiv24" style="height:145px;">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView7_RowDataBound" EnableViewState="false">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="状态" DataField="Status" />
                            <asp:BoundField HeaderText="合同类别" DataField="ContractType" />
                            <asp:BoundField HeaderText="签约日期" DataField="_Date" />
                            <asp:BoundField HeaderText="合同编号" DataField="ContractNO" />
                            <asp:BoundField HeaderText="起始日期" DataField="StartDate" />
                            <asp:BoundField HeaderText="终止日期" DataField="EndDate" />
                            <asp:BoundField HeaderText="金额" DataField="dAmount" />
                            <asp:BoundField HeaderText="现结金额" DataField="dInCash" />
                            <asp:BoundField HeaderText="附件" DataField="Accessory" />
                            <asp:BoundField HeaderText="业务员" DataField="Seller" />
                            <asp:BoundField HeaderText="经办人" DataField="Operator" />
                            <asp:BoundField HeaderText="合同条款" DataField="Summary" />
                            <asp:BoundField HeaderText="客户名称" DataField="CustomerName" />
                            <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
                            <asp:BoundField HeaderText="联系电话" DataField="Tel" />
                            <asp:BoundField HeaderText="地址" DataField="Adr" />
                            <asp:BoundField HeaderText="备注" DataField="Remark" />
                            <asp:BoundField HeaderText="终止原因" DataField="termRemark" />
                        </Columns>
                    </asp:GridView>

                    <table cellpadding="0" cellspacing="0" class="pages">
                        <tr>
                            <td><webdiyer:aspnetpager id="jsPagerc" runat="server" onpagechanged="jsPagerc_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="跳转:" /></td>
                            <td style="padding-left:8px;"><asp:Label ID="lbPagec" runat="server" ToolTip="当页显示数"></asp:Label></td>
                            <td style="padding-left:8px;"><asp:Label ID="lbCountTextc" runat="server" Visible="false" ToolTip="总记录数" Text="总记录:"></asp:Label><asp:Label ID="lbCountc" runat="server" ToolTip="总记录数"></asp:Label></td>
                        </tr>
                    </table>
                    
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnDelCont" EventName="Click" />
                         <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="tvcus" EventName="SelectedNodeChanged" />
                        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
                    </Triggers>       
                    </asp:UpdatePanel>
            </div>
        </div>
        <div id="info5" style="height:175px;background:#ECE9D8;">
            <div style="border-bottom:#808080 1px solid;">
               <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                   <input id="btnAccAdd" type="button" value="新建" class="bt1" onclick="NewAcc();" />
                   <input id="btnAccMod" type="button" value="修改" class="bt1" onclick="ModAcc();" />
                   <asp:Button ID="btnDelAcc" runat="server" Text="删除" CssClass="bt1" OnClientClick="if(ChkDel2('客户附件')==false) return false;"  UseSubmitBehavior="false" OnClick="btnDelAcc_Click" />
                </td>
                </tr>
               </table>
            </div>
            <div class="cndiv2" id="cndiv25" style="height:145px;">
                <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView6_RowDataBound" EnableViewState="false">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="名称" DataField="_Name" />
                            <asp:BoundField HeaderText="摘要" DataField="Remark" />
                            <asp:BoundField HeaderText="附件" DataField="Path" />
                            <asp:BoundField HeaderText="创建日期" DataField="_Date" />
                            <asp:BoundField HeaderText="创建人" DataField="Operator" />
                        </Columns>
                    </asp:GridView>

                    <table cellpadding="0" cellspacing="0" class="pages">
                        <tr>
                            <td><webdiyer:aspnetpager id="jsPagera" runat="server" onpagechanged="jsPagera_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="跳转:" /></td>
                            <td style="padding-left:8px;"><asp:Label ID="lbPagea" runat="server" ToolTip="当页显示数"></asp:Label></td>
                            <td style="padding-left:8px;"><asp:Label ID="lbCountTexta" runat="server" Visible="false" ToolTip="总记录数" Text="总记录:"></asp:Label><asp:Label ID="lbCounta" runat="server" ToolTip="总记录数"></asp:Label></td>
                        </tr>
                    </table>
                    
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnDelAcc" EventName="Click" />
                         <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="tvcus" EventName="SelectedNodeChanged" />
                        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
                    </Triggers>       
                    </asp:UpdatePanel>
            </div>
        </div>
        
        <div id="info6" style="height:175px;background:#ECE9D8;">
            <div style="border-bottom:#808080 1px solid;">
               <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                   <input id="btnSerV" type="button" value="查看" class="bt1" onclick="SerV();" />
                </td>
                </tr>
               </table>
            </div>
            <div class="cndiv2" id="cndiv26" style="height:145px;">
                <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView3_RowDataBound" EnableViewState="false">
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

                    <table cellpadding="0" cellspacing="0" class="pages">
                        <tr>
                            <td><webdiyer:aspnetpager id="jsPagerb" runat="server" onpagechanged="jsPagerb_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="跳转:" /></td>
                            <td style="padding-left:8px;"><asp:Label ID="lbPageb" runat="server" ToolTip="当页显示数"></asp:Label></td>
                            <td style="padding-left:8px;"><asp:Label ID="lbCountTextb" runat="server" Visible="false" ToolTip="总记录数" Text="总记录:"></asp:Label><asp:Label ID="lbCountb" runat="server" ToolTip="总记录数"></asp:Label></td>
                        </tr>
                    </table>
                    
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                         <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="tvcus" EventName="SelectedNodeChanged" />
                        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
                    </Triggers>       
                    </asp:UpdatePanel>
            </div>
        </div>
        
        <div id="info7" style="height:175px;background:#ECE9D8;">
            <div style="border-bottom:#808080 1px solid;">
               <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                   <input id="btnSellV" type="button" value="查看" class="bt1" onclick="SellV();" />
                </td>
                </tr>
               </table>
            </div>
            <div class="cndiv2" id="cndiv27" style="height:145px;">
                <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView4_RowDataBound" EnableViewState="false">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="单据状态" DataField="Status" />
                            <asp:BoundField HeaderText="单据类别" DataField="Type" />
                            <asp:BoundField HeaderText="单据编号" DataField="BillID" />
                            <asp:BoundField HeaderText="日期" DataField="_Date" />
                            <asp:BoundField HeaderText="业务员" DataField="Operator" />
                            <asp:BoundField HeaderText="客户名称" DataField="_Name" />
                            <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
                            <asp:BoundField HeaderText="联系电话" DataField="Tel" />
                            <asp:BoundField HeaderText="地址" DataField="Adr" />
                            <asp:BoundField HeaderText="送货人" DataField="SndOperator" />
                            <asp:BoundField HeaderText="现结金额" DataField="InCash" />
                            <asp:BoundField HeaderText="审核日期" DataField="ChkDate" />
                            <asp:BoundField HeaderText="审核人" DataField="ChkOperator" />
                            <asp:BoundField HeaderText="自编号" DataField="AutoNO" />
                            <asp:BoundField HeaderText="引用单号" DataField="OperationID" />
                            <asp:BoundField HeaderText="制单人" DataField="Person" />
                            <asp:BoundField HeaderText="备注" DataField="Remark" />
                        </Columns>
                    </asp:GridView>

                    <table cellpadding="0" cellspacing="0" class="pages">
                        <tr>
                            <td><webdiyer:aspnetpager id="jsPagers" runat="server" onpagechanged="jsPagers_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="跳转:" /></td>
                            <td style="padding-left:8px;"><asp:Label ID="lbPages" runat="server" ToolTip="当页显示数"></asp:Label></td>
                            <td style="padding-left:8px;"><asp:Label ID="lbCountTexts" runat="server" Visible="false" ToolTip="总记录数" Text="总记录:"></asp:Label><asp:Label ID="lbCounts" runat="server" ToolTip="总记录数"></asp:Label></td>
                        </tr>
                    </table>
                    
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                         <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="tvcus" EventName="SelectedNodeChanged" />
                        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
                    </Triggers>       
                    </asp:UpdatePanel>
            </div>
        </div>
        <div id="info8" style="height:175px;background:#ECE9D8;">
            <div style="border-bottom:#808080 1px solid;">
               <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                   <input id="btnLeaseV" type="button" value="查看" class="bt1" onclick="LeaseV();" />
                </td>
                </tr>
               </table>
            </div>
            <div class="cndiv2" id="cndiv28">
                <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                    <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView5_RowDataBound" EnableViewState="false">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="业务类别" DataField="Type" />
                            <asp:BoundField HeaderText="业务状态" DataField="curStatus" />
                            <asp:BoundField HeaderText="业务编号" DataField="BillID" />
                            <asp:BoundField HeaderText="客户名称" DataField="CustomerName" />
                            <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
                             <asp:BoundField HeaderText="联系电话" DataField="Tel" />
                            <asp:BoundField HeaderText="地址" DataField="Adr" />
                            <asp:BoundField HeaderText="基础月租" DataField="Rent" />
                            <asp:BoundField HeaderText="起始日期" DataField="StartDate" />
                            <asp:BoundField HeaderText="终止日期" DataField="EndDate" />
                            <asp:BoundField HeaderText="结算周期" DataField="ChargeCycle" />
                            <asp:BoundField HeaderText="合同编号" DataField="ContractNO" />
                            <asp:BoundField HeaderText="押金" DataField="Deposit" />
                            <asp:BoundField HeaderText="日期" DataField="_Date" />
                            <asp:BoundField HeaderText="制单人" DataField="Operator" />
                            <asp:BoundField HeaderText="业务员" DataField="Seller" />
                            <asp:BoundField HeaderText="备注" DataField="Remark" />
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
                        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                         <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="tvcus" EventName="SelectedNodeChanged" />
                        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
                    </Triggers>       
                    </asp:UpdatePanel>
            </div>
        </div>
        <div id="info10" style="height:175px;background:#ECE9D8;">
        <div class="cndiv2" id="cndiv210" style="height:175px;">
        <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridView9" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView9_RowDataBound" EnableViewState="false">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="序"/>
                    <asp:BoundField HeaderText="日期" DataField="_Date" />
                    <asp:BoundField HeaderText="分派网点" DataField="AllotDept" />
                    <asp:BoundField HeaderText="分派人" DataField="Operator" />
                    <asp:BoundField HeaderText="跟踪网点" DataField="Dept" />
                    <asp:BoundField HeaderText="跟踪人" DataField="TrackOperator" />
                    <asp:BoundField HeaderText="分派原因"  DataField="Remark"/>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                         <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="tvcus" EventName="SelectedNodeChanged" />
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
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;
var isfocus=2;
var tabnum=11;
function ChkID(id)
{
    ClrID(id);
    $("btnShow").click();
}

function ChkSltD(flag)
{
    $("hfSltType").value=flag;
    $("btnShow").click();
}
function NewCus()
{
    var classid=$("hfClassID").value;
    parent.ShowDialog(600, 400, 'Customer/CusAdd.aspx?classid='+classid, '新建客户');
}
function ChkEditClass()
{
    var id=$("hfcbID").value;
    if(id=="")
        id=$("hfRecID").value;
    if(ChkSltValue()!=false)
    {
        parent.ShowDialog(300, 330,'Customer/EditCusClass.aspx?id='+id,'批量修改客户信息');
    }
}
function SmsSndCBat()
{
    if($("hfTbTitle").value=="")
    {
        window.alert("操作失败！请查询出要发送短信的客户列表.");
        return false;
    }
    parent.ShowDialog(500, 275,'Tool/SmsSndCBat.aspx', '短信群发');
}
function ChkCancel()
{
    id=$("hfRecID2").value.substr(1);
    if(id=="-1")
    {
        alert("请选择一条合同后操作！");
        return;
    }
    parent.ShowDialog(460, 95, 'Customer/MaitenTerminate.aspx?fp=cus&id='+id, '终止合同');
}
function NewD()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("请选择一条客户记录后操作！");
        return false;
    }
    parent.ShowDialog(750, 430, 'Customer/DeviceAdd.aspx?id='+id, '新建机器档案');
}

function ModD()
{
    var id=document.getElementById("hfRecID2").value.replace("d","");
    if(id=="-1")
    {
        alert("请选择一条机器档案后操作！");
    }
    else
    {
        parent.ShowDialog(750, 430,'Customer/DeviceMod.aspx?id='+id, '修改机器档案');
    }
}

function NewLink()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("请选择一条客户记录后操作！");
        return false;
    }
    parent.ShowDialog(460, 263, 'Customer/LinkManAdd.aspx?id='+id, '新建联系人');
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
        parent.ShowDialog(460, 263,'Customer/LinkManMod.aspx?id='+id, '修改联系人');
    }
}

function NewDept()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("请选择一条客户记录后操作！");
        return false;
    }
    parent.ShowDialog(400, 175, 'Customer/DeptAdd.aspx?id='+id, '新建客户部门');
}

function ModDept()
{
    var id=document.getElementById("hfRecID2").value.replace("p","");
    if(id=="-1")
    {
        alert("请选择一条客户部门后操作！");
    }
    else
    {
        parent.ShowDialog(400, 175,'Customer/DeptMod.aspx?id='+id, '修改客户部门');
    }
}
function NewT()
{
    var id=$("hfRecID").value;
    if(id==""||id=="-1")
    {
        alert("请选择一条客户记录后操作！");
        return false;
    }
     parent.ShowDialog(470, 290, 'Customer/TrackAdd.aspx?id='+id, '新建跟踪');
}

function ModT()
{
    var id=document.getElementById("hfRecID2").value.replace("t","");
    if(id=="-1")
    {
        alert("请选择一条跟踪明细后操作！");
    }
    else
    {
        parent.ShowDialog(470, 290,'Customer/TrackMod.aspx?id='+id, '修改跟踪');
    }
}
function ShowTC(id)
{
    parent.ShowDialog(470, 360,'Customer/ShowTC.aspx?id='+id, '跟踪内容');
}
function ShowTR(id)
{
    parent.ShowDialog(470, 360,'Customer/ShowTR.aspx?id='+id, '跟踪结果');
}
function NewAcc()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("请选择一条客户记录后操作！");
        return false;
    }
    parent.ShowDialog(500, 150, 'Customer/CusAccAdd.aspx?id='+id, '新建附件');
}

function ModAcc()
{
    var id=document.getElementById("hfRecID2").value.replace("a","");
    if(id=="-1")
    {
        alert("请选择一条附件记录后操作！");
    }
    else
    {
        parent.ShowDialog(500, 150,'Customer/CusAccMod.aspx?id='+id, '修改附件');
    }
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

function SellV()
{
    var id=document.getElementById("hfRecID2").value.replace("s","");
    if(id=="-1")
    {
        alert("请选择一条销售单后操作！");
    }
    else
    {
        parent.ShowDialog(800, 480,'Sell/SellMod.aspx?id='+id, '销售单');
    }
}

function LeaseV()
{
    var id=document.getElementById("hfRecID2").value.replace("le","");
    if(id=="-1")
    {
        alert("请选择一条业务单后操作！");
    }
    else
    {
        parent.ShowDialog(800, 480,'Lease/LeaseMod.aspx?id='+id,'业务单');
    }
}

function NewCont()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("请选择一条客户记录后操作！");
        return false;
    }
    parent.ShowDialog(820, 510, 'Customer/DevContAdd.aspx?id='+id, '新建服务合同')
}

function ModCont()
{
    var id=document.getElementById("hfRecID2").value.replace("c","");
    if(id=="-1")
    {
        alert("请选择一条服务合同后操作！");
    }
    else
    {
        parent.ShowDialog(820, 510, 'Customer/DevContMod.aspx?id='+id, '修改服务合同');
    }
}
function ChkAllot()
{
    var id=$("hfcbID").value;
    if(id=="")
        id=$("hfRecID").value;
    if(ChkSltValue()!=false)
    {
        parent.ShowDialog(300, 155,'Customer/CusAllot.aspx?id='+id,'分派客户');
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
        parent.ShowDialog(500, 360,'Customer/CusMerge.aspx?id='+id,'合并客户');
    }
}
function ChkInput()
{
    parent.ShowDialog(600, 473,'Customer/InputCus.aspx', '导入客户资料');
}
function Chkset()
{
    Chkwhcus();
    Chkbom(); 
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
function changleft()
{
    var startw=$("lndiv").style.width;
    if(startw=="")
        startw="1px";
    if(startw!="0px")
    {
        var h1=document.body.clientHeight-54;//表格高度
        var w1=window.screen.availWidth;//屏幕可用工作区宽度
        var h2=h1-200;//固定占用高度
        var w2=20;//滑条宽度
        $("lndiv").style.width="0px";
        $("cndiv").style.width=w1-w2+"px";
        $("cnbut").style.width=w1-w2+"px";
        $("lncn").className="uwr";
    }
    else
    {
        var h1=document.body.clientHeight-54;//表格高度
        var w1=window.screen.availWidth;//屏幕可用工作区宽度
        var h2=h1-200;//固定占用高度
        var w2=190;//滑条宽度
        $("lndiv").style.width="160px";
        $("cndiv").style.width=w1-w2+"px";
        $("cnbut").style.width=w1-w2+"px";
        $("lncn").className="uwl";
    }
}
function CloseTrack()
{
    var id=$("hfcbID").value;
    if(id=="")
        id=$("hfRecID").value;
    if(ChkSltValue()!=false)
    {
        parent.ShowDialog(300, 95,'Customer/CloseTrack.aspx?id='+id,'关闭跟踪');
    }
}
function ChkDelCus()
{
    if(ChkSltValue()!=false)
    {
        return confirm("确认要删除已选择的[客户档案]吗？");
    }else{return false;}
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("客户档案");
}
function chkRecord()
{
    var recid = document.getElementById("hfRecID").value;
    if(recid==""||recid=="-1")
    {
        alert("请选择一条记录！");
        return false;
    }
}
</script>
