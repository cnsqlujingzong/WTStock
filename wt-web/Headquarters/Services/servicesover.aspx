<%@ page language="C#"  CodeFile="servicesover.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Services_ServicesOver" theme="Themes" enableEventValidation="false" %>
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
            <asp:Button ID="btnChkClose" runat="server" Text="审核" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkClose()==false) return false" OnClick="btnChkClose_Click"/>
            <input id="btnRepair" type="button" value="驳回" class="bt1" onclick="ChkBack();" runat="server" />
            <span style="display:none;">
                <asp:Button ID="btnClr" runat="server" Text="保留选中" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                <asp:Button ID="btnOrder" runat="server" Text="排序" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                <asp:Button ID="btnShow" runat="server" Text="显示" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnShow_Click"/>
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
                    <asp:ListItem Value="20">按送修厂商查询</asp:ListItem>
                    <asp:ListItem Value="19">按备注查询</asp:ListItem>
                    <asp:ListItem Value="-1">查询全部</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server" CssClass="pink" ToolTip="输入查询关键字"></asp:TextBox>
            </td><td align="left">
            <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
            <td style="padding:0px;"><input id="btnSchsH" type="button" value="高级查询" class="bsch" onclick="parent.ShowDialog(470,428, 'Services/SerCd.aspx', '高级查询');" /></td>
            </tr>
            </table>   
        </div>
        <div class="clearfloat"></div>
    </div>
    
    <div id="cndiv" style="float:left;height:1px;">
    <div id="divtop" style="overflow:auto;">
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
            <asp:BoundField HeaderText="取消原因" DataField="CancelReason" />
            <asp:BoundField HeaderText="服务单号" DataField="BillID" />
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
            <asp:BoundField HeaderText="返修" DataField="bRepair" />
            <asp:BoundField HeaderText="取消原因" DataField="CancelReason" />
            <asp:BoundField HeaderText="备注" DataField="Remark" />
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
    <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
    <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfTbTitle" runat="server" />
    <asp:HiddenField ID="hfTbField" runat="server" />
    <asp:HiddenField ID="hfcbID" runat="server" />
    <asp:HiddenField ID="hfParm" runat="server" Value="-1" />
    <asp:HiddenField ID="hfPurDept" runat="server" Value="0" />
    <asp:HiddenField ID="hfPurOPDept" runat="server" Value="0" />
    <asp:HiddenField ID="hfTecDept" runat="server" Value="0" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChkClose" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div id="divbottom" style="overflow:hidden;">
    <div id="divdetail" runat="server">
        <div class="ftool2">
        <div id="mytabs">
            <span id="tabs_l1" class="tabs_activeleft"></span>
            <span id="tabs1" class="tabs_active" >提成明细</span>
            <span id="tabs_r1" class="tabs_activeright"></span>
        </div>
        </div>
        <div style=" height:123px;background:#ECE9D8;">
        <div style="border-bottom:#808080 1px solid;">
              <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                   <input id="btnNew" type="button" value="新建" class="bt1" onclick="NewDeduct();" />
                   <input id="btnMod" type="button" value="修改" class="bt1" onclick="ModDeduct();" />
                   <asp:Button ID="btnDel" runat="server" Text="删除" CssClass="bt1" OnClientClick="if(ChkDel2('提成明细')==false) return false;"  UseSubmitBehavior="false" OnClick="btnDel_Click"/>
                </td>
                </tr>
              </table>
        </div>
        <div class="cndiv2" id="cndiv2" style="height:90px;">
           <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView2_RowDataBound" EnableViewState="false">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" />
                        <asp:BoundField HeaderText="序"/>
                        <asp:BoundField HeaderText="工号" DataField="JobNO" />
                        <asp:BoundField HeaderText="姓名" DataField="_Name" />
                        <asp:BoundField HeaderText="日期" DataField="Time_Finish" />
                        <asp:BoundField HeaderText="金额" DataField="Deduct" />
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
                <asp:AsyncPostBackTrigger ControlID="btnChkClose" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>
        </div>
        </div>
        </div>
    </div>
    </div>
    
    <div id="lncn" class="uw"></div>
    <div id="divright" style ="float:right;">
    <div class="divh"></div>
    <div id="rightcon">
    <fieldset style=" border: 1px #808080 solid; padding:5px 0;width:288px;">
      <legend>维修信息</legend>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb5">
            <tr>
                <td align="right">
                技术员：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbDOperator" runat="server" CssClass="pinksb" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">机器品牌：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbBrand" runat="server" CssClass="pinksb" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                机器类别：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbClass" runat="server" CssClass="pinksb" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                机器型号：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbModel" runat="server" CssClass="pinksb" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td>故障描述：</td>
                <td style="padding-left:0px; height:40px;"><asp:TextBox ID="tbFault" runat="server" CssClass="pinksb" Width="200" TextMode="MultiLine" Height="30" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="sysred" align="center">处理措施<br />
                    /结果：</td>
                <td style="padding-left:0px; height:40px;"><asp:TextBox ID="tbTakeSteps" runat="server" CssClass="pinksb" Width="200" TextMode="MultiLine" Height="30" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td style="padding-left:0px;"><a href="#" class="newr" onclick="ChkMod(700, 435,'Repository/RepositoryAdd.aspx','新建知识');">存为知识</a></td>
            </tr>
        </table>
      </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
      </fieldset>
        <fieldset style=" border: 1px #808080 solid; padding:5px 0;width:288px;">
      <legend>其他信息</legend>
      <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb5">
            <tr>
                <td align="right">
                工分：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbdPoint" runat="server" CssClass="pinksb"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                预报价格：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSubPrice" runat="server" CssClass="pinksb" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                材料费用：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbFee_Materail" runat="server" CssClass="pinksb" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                维修费用：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbFee_Labor" runat="server" CssClass="pinksb" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                附加费：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSurCharge" runat="server" CssClass="pinksb" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                合计：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbTotal" runat="server" CssClass="pinksb" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                取消原因：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbCancelReason" runat="server" CssClass="pinksb" ReadOnly="true" Width="200"></asp:TextBox></td>
            </tr>
            <tr>
                <td>备注信息：</td>
                <td style="padding-left:0px;height:40px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pinksb" Width="200" TextMode="MultiLine" Height="30"></asp:TextBox></td>
            </tr>
       </table>
       </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
       </fieldset>
    </div>
    </div>
    <div class="clearfloat"></div>    
    <div class="fbom">  
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td><div id="fbon" class="fbon"></div></td>
            <td>
                <span class="sgay">被取消</span>
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
<script language="javascript" type="text/javascript">
var noOpen=1;
var isfocus=2;
function ChkID(id)
{
    ClrID(id);
    $("btnShow").click();
}

function NewDeduct()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("请选择一条服务单后操作！");
        return false;
    }
    parent.ShowDialog(420, 120, 'Services/NewDeduct.aspx?id='+id+'&iflag=1', '新建提成明细');
}

function ModDeduct()
{
    var id=document.getElementById("hfRecID2").value.replace("d","");
    if(id=="-1")
    {
        alert("请选择一条提成明细后操作！");
    }
    else
    {
        parent.ShowDialog(420, 120,'Services/ModDeduct.aspx?id='+id, '修改提成明细');
    }
}

function ChkBack()
{
    var id=$("hfcbID").value;
    if(id=="")
        id=$("hfRecID").value;
        
    if(ChkSltValue()!=false)
    {    
        parent.ShowDialog(460,124, 'Services/OverBack.aspx?id='+id, '驳回');
    }else{return false;}
}

function ChkClose()
{
    if(ChkSltValue()!=false)
    {
        return confirm("确认要审核关闭已选择的服务单吗？");
    }else{return false;}
}

function ChkView()
{
    ChkMod(860,444, 'Services/SerView.aspx', '服务单');
}

function Chkset()
{
    Chkwhv2();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("审核关闭");
}
</script>
