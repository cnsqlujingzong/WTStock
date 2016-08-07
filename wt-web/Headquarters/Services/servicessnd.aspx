<%@ page language="C#"  CodeFile="servicessnd.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Services_ServicesSnd" theme="Themes" enableEventValidation="false" %>
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
                <input id="btnView" type="button" value="明细" class="bt1" onclick="ChkView();" />
                <input id="btnBackAllot" type="button" value="驳回" class="bt1" onclick="ChkMod(460,98,'Services/SndBackAllot.aspx','驳回');"/>
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
                <td>
                <input id="btnPrint" runat="server" type="button" value="打印" class="iprint" onclick="ChkPrintChoise('PrintBill.aspx');" />
                </td>
                <td style="padding-left:0px;">
                    <asp:Button ID="btnExcel" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" /></td>
                <td>
                <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="0">模糊查询</asp:ListItem>
                    <asp:ListItem Value="1">按服务单号查询</asp:ListItem>
                    <asp:ListItem Value="20">按送修厂商查询</asp:ListItem>
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
    
    <div id="lndiv" class="lndiv" style="height:1px;">
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
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="送修厂商ID" DataField="RepairCorpID" />
            <asp:BoundField HeaderText="送修厂商" DataField="RepairCorp" />
            <asp:BoundField HeaderText="预约时间" DataField="SubscribeTime" />
            <asp:BoundField HeaderText="服务单号" DataField="BillID" />
            <asp:BoundField HeaderText="服务类别" DataField="ServicesType" />
            <asp:BoundField HeaderText="送修类别" DataField="RepairType" />
            <asp:BoundField HeaderText="送修厂商" DataField="RepairCorp" />
            <asp:BoundField HeaderText="受理人" DataField="Operator" />
            <asp:BoundField HeaderText="受理时间" DataField="Time_TakeOver" />
            <asp:BoundField HeaderText="处理时间" DataField="Speding" />
            <asp:BoundField HeaderText="受理方式" DataField="TakeStyle" />
            <asp:BoundField HeaderText="受理部门" DataField="TakeDept" />
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
        <asp:HiddenField ID="hfClass" runat="server" />
        <asp:HiddenField ID="hfTbTitle" runat="server" />
        <asp:HiddenField ID="hfTbField" runat="server" />
        <asp:HiddenField ID="hfSup" runat="server" />
        <asp:HiddenField ID="hfSupID" runat="server" />
        <asp:HiddenField ID="hfRecList" runat="server" />
        <asp:HiddenField ID="hfRecsList" runat="server" />
        <asp:HiddenField ID="hfParm" runat="server" Value="-1" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="tvsup" EventName="SelectedNodeChanged" />
        <asp:AsyncPostBackTrigger ControlID="btnBackAll" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnGo" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnGoAll" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSnd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnBack" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnNO" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div id="divlbut" style="height:200px;float:left;">
        <div id="cnbut" style="overflow:hidden; border-bottom:#808080 1px solid;">
          <table cellpadding="0" cellspacing="0" class="tb3">
            <tr>
            <td style="padding-left:0px;">
            <span style="display:none;">
                <asp:Button ID="btnNO" runat="server" Text="btnNO" OnClick="btnNO_Click"/>
                <asp:Button ID="btnGo" runat="server" OnClientClick="if(ChkJoin()==false)return false;" Text=">" UseSubmitBehavior="false"  OnClick="btnGo_Click"/>
                <asp:Button ID="btnBack" runat="server" Text="<" UseSubmitBehavior="false" OnClick="btnBack_Click" />
            </span>
            </td>
            <td>
                <asp:Button ID="btnGoAll" runat="server" Text="全选" UseSubmitBehavior="false" ToolTip="点击选择全部" CssClass="bt1" OnClick="btnGoAll_Click"/>
            </td>
            <td>
                <asp:Button ID="btnBackAll" runat="server" Text="全撤销" UseSubmitBehavior="false" ToolTip="点击撤销全部选择" CssClass="bt1" OnClick="btnBackAll_Click"/>
            </td>
            <td>序列号：</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbSNO" runat="server" CssClass="pin" onkeydown="EnterTextBox(event, this);"></asp:TextBox>
            </td>
            <td style="color:#0000ff;">
                输入机器序列号后回车加入待发货列表。建议采用扫描枪快捷输入。
            </td>
            </tr>
          </table>
        </div>
        <div id="divlbutcon">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" EnableViewState="false" OnRowDataBound="GridView2_RowDataBound" SkinID="gv4">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" />
                        <asp:BoundField HeaderText="服务单号" DataField="BillID" />
                        <asp:BoundField HeaderText="服务类别" DataField="ServicesType" />
                        <asp:BoundField HeaderText="经办人" DataField="Operator" />
                        <asp:BoundField HeaderText="受理时间" DataField="Time_TakeOver" />
                        <asp:BoundField HeaderText="处理时间" DataField="Speding" />
                        <asp:BoundField HeaderText="受理方式" DataField="TakeStyle" />
                        <asp:BoundField HeaderText="受理部门" DataField="TakeDept" />
                        <asp:BoundField HeaderText="优先级" DataField="_PRI" />
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
                        <asp:BoundField HeaderText="保修情况" DataField="Warranty" />
                        <asp:BoundField HeaderText="预约时间" DataField="SubscribeTime" />
                        <asp:BoundField HeaderText="预报价" DataField="SubscribePrice" />
                        <asp:BoundField HeaderText="预收费" DataField="PreCharge" />
                        <asp:BoundField HeaderText="返修" DataField="bRepair" />
                    </Columns>
                </asp:GridView>
                <span style="padding-right: 5px; padding-left: 5px; padding-bottom: 5px; padding-top: 5px">
                    <asp:Label ID="lbsCount" runat="server" Style="color: #0000ff"></asp:Label></span>
                <asp:HiddenField ID="hfRecID2" runat="server" Value="-1" />
                <asp:HiddenField ID="hflist" runat="server" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnBack" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnBackAll" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnGo" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnGoAll" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnSnd" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnNO" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        </div>
        <div id="divlbutdo">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            <table cellpadding="0" cellspacing="0" class="tb3">
            <tr>
                <td>送修厂商：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlRepairCorp" runat="server" CssClass="pindl">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>发货日期：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbSndDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
                </td>
                <td>收货人：</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                          <asp:TextBox ID="tbLinkman" runat="server" CssClass="pin pinin" Width="100"></asp:TextBox>
                          <asp:DropDownList ID="ddlLinkman" runat="server" onchange="document.getElementById('tbLinkman').value=this.options[this.selectedIndex].text" style="width:103px;clip: rect(auto auto auto 86px);width:105px\9;clip: rect(auto auto auto 88px)\9;height:20px; position: absolute;" OnSelectedIndexChanged="ddlLinkman_SelectedIndexChanged" AutoPostBack="true">
                          </asp:DropDownList>
                      </div>
                </td>
                <td>收货地址：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbAdr" runat="server" CssClass="pin"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>货运方式：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlSndStyle" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                <td>物流单号：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbPostNO" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td>邮资：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbPostage" runat="server" Width="100"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnSnd" runat="server" Text="确认发货" CssClass="bt1"  UseSubmitBehavior="False" OnClientClick="if(chkReturn()==false)return false;" OnClick="btnSnd_Click" />
                </td>
            </tr>
          </table>
          </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnBack" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnBackAll" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnGo" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnGoAll" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnSnd" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnNO" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        </div>
    </div>
    <div class="clearfloat"></div>
    <div class="fbom">  
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td><div id="fbon" class="fbon"></div></td>
            <td>
                <span class="sblue">预约提醒</span>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;
var isfocus=2;
function ChkID(id)
{
    ClrID(id);
}
function Chkset()
{
    Chkwhser2();
    Chkbom(); 
}

function EnterTextBox(event, obj)
{
    if(event.keyCode == 13&&!isNull(obj.value))
    {
        if(!isNull(obj.value))
        {
            $("btnNO").click();
        }
    }
}
function ChkSupplier(supplier,supid)
{
    $("hfSup").value=supplier;
    $("hfSupID").value=supid;
}
function ChkJoin()
{
    if($("ddlRepairCorp").value!="")
    {
        if($("ddlRepairCorp").options[$("ddlRepairCorp").selectedIndex].text!=$("hfSup").value&&$("ddlRepairCorp").value!=$("hfSupID").value)
        {
            alert("同一待送修列表不允许存在不同的送修厂商！");
            return false
        }
    }
}

function ChkGo()
{
    $("btnGo").click();
}
function ChkBack()
{
    $("btnBack").click();
}

function chkReturn()
{
    var list=$("hflist").value;
    if(list==""||list=="-1")
    {
        alert("操作失败！请添加送修机器");return false;
    }
    
    if(!isNull($("tbPostage").value))
    {
        if(!isMoney($("tbPostage").value))
        {
            window.alert("操作失败！邮资格式不正确");
            $("tbPostage").focus();
            return false
        }
    }
    
    if(isNull($("tbSndDate").value))
    {
        window.alert("操作失败！发货日期不能为空");
        $("tbSndDate").focus();
        return false
    }
    
    if($("ddlSndStyle").value=="-1")
    {
        window.alert("操作失败！货运方式不能为空");
        $("ddlSndStyle").focus();
        return false
    }
}
function ChkView()
{
    ChkMod(860,444, 'Services/SerView.aspx', '服务单');
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("送修发货");
}
</script>
