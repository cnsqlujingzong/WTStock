<%@ page language="C#"  CodeFile="payexpense.aspx.cs"     autoeventwireup="true" inherits="Branch_Financial_PayExpense" theme="Themes" enableeventvalidation="false" %>
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
            <asp:Button ID="btnBack" runat="server" Text="驳回" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnBack_Click" OnClientClick="if(ChkCancel()==false) return false"/>
            <span style="display:none;">
                <asp:Button ID="btnClr" runat="server" Text="保留选中" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                <asp:Button ID="btnOrder" runat="server" Text="排序" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                <asp:Button ID="btnShow" runat="server" Text="显示" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnShow_Click"/>
            </span>
            </td>
            </tr>
        </table>
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                    <input id="btnPrint" runat="server" type="button" value="打印" class="iprint" onclick="ChkPrint('BXD');" />
                </td>
                <td style="padding-left:0px;">
                    <asp:Button ID="btnExcel" runat="server" Text="导出" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" /></td>
                <td>
                <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="Operator">按报销人查询</asp:ListItem>
                    <asp:ListItem Value="_Date">按申请日期查询</asp:ListItem>
                    <asp:ListItem Value="dMoney">按金额查询</asp:ListItem>
                    <asp:ListItem Value="Summary">按摘要查询</asp:ListItem>
                    <asp:ListItem Value="RelatedBusiness">按关联业务</asp:ListItem>
                    <asp:ListItem Value="ChkDate">按审核日期查询</asp:ListItem>
                    <asp:ListItem Value="ChkOperator">按审核人查询</asp:ListItem>
                    <asp:ListItem Value="Remark">按备注查询</asp:ListItem>
                    <asp:ListItem Value="-1">查询全部</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server"  onkeydown="EnterTextBoxSch(event, this);" CssClass="pink" ToolTip="输入查询关键字"></asp:TextBox>
            </td>
            <td align="left">
            <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
            </tr>
            </table>   
        </div>
        <div class="clearfloat"></div>
    </div>
    
    <div id="cndiv" style="float:left;height:1px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="申请日期" DataField="_Date" />
            <asp:BoundField HeaderText="报销人" DataField="Operator" />
            <asp:BoundField HeaderText="金额" DataField="dMoney" />
            <asp:BoundField HeaderText="摘要" DataField="Summary" />
            <asp:BoundField HeaderText="关联业务" DataField="RelatedBusiness" />
            <asp:BoundField HeaderText="审核日期" DataField="ChkDate" />
            <asp:BoundField HeaderText="审核人" DataField="ChkOperator" />
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
    <asp:HiddenField ID="hfHeadBln" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnBack" EventName="Click" />
    </Triggers>       
    </asp:UpdatePanel>
    </div>
    <div id="lncn" class="uw"></div>
    <div id="divright">
    <div class="divh"></div>
    <div id="rightcon">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb5">
            <tr>
                <td align="right">
                发放日期：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbDate" runat="server" CssClass="Wdate1" onfocus="WdatePicker()"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                发放人：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                付款帐户：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlChargeAccount" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                收支项目：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlItem" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">备注：</td>
                <td style="padding-left:0px;height:52px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="200" TextMode="MultiLine" Height="42"></asp:TextBox></td>
            </tr>
        </table>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnBack" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
        <div class="divh"></div>
        <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="right" style="padding-right:20px;">
                <asp:Button ID="btnSave" runat="server" Text="确定" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false) return false" OnClick="btnSave_Click" />
            </td>
        </tr>
        </table>
    </div>
    </div>
    <div class="clearfloat"></div>
    <div class="fbom">
    <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
    <div id="fbon" class="fbon"></div></td>
    <td>
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <span class="bs1" style="color:#0000ff;">金额合计:<asp:Label ID="Label1" runat="server" Text=""></asp:Label></span>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
          <asp:AsyncPostBackTrigger ControlID="btnBack" EventName="Click" />
    </Triggers>       
    </asp:UpdatePanel>
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
    $("btnShow").click();
}

function ChkSave()
{
    if(ChkSlt()!=false)
    {
        if(isNull($("tbDate").value))
        {
            alert("操作失败！发放日期不能为空");
            $("tbDate").focus();
            return false
        }
        if($("ddlOperator").value=="-1")
        {
            alert("操作失败！发放人不能为空");
            $("ddlOperator").focus();
            return false
        }
        if($("ddlChargeAccount").value=="-1")
        {
            alert("操作失败！付款帐户不能为空");
            $("ddlChargeAccount").focus();
            return false
        }
        if($("ddlItem").value=="-1")
        {
            alert("操作失败！收支项目不能为空");
            $("ddlItem").focus();
            return false
        }
    }else
    return false
}
function ChkCancel()
{
    if(ChkSlt()!=false)
    {
        if(confirm("确定要驳回该申请单吗？"))
        {
            if(isNull($("tbDate").value))
            {
                alert("操作失败！发放日期不能为空");
                $("tbDate").focus();
                return false
            }
            if($("ddlOperator").value=="-1")
            {
                alert("操作失败！发放人不能为空");
                $("ddlOperator").focus();
                return false
            }
         return true;
        }
           
         else
            return false;
    }else
    return false
}
function ModBill()
{
    ChkMod(840, 480,'Financial/ExpenseMod.aspx','报销明细');
}

function Chkset()
{
    Chkwhv();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("款项发放");
}
</script>
