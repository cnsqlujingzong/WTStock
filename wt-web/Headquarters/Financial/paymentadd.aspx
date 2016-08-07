<%@ page language="C#"  CodeFile="paymentadd.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Financial_PaymentAdd" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body onload="Chkset();" onclick="parent.Sethidden1();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="divh2"></div>
    <div class="tldiv">
        付应付款
    </div>
        <div id="ctdiv">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td>付款单号：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBillID" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox></td>
                <td align="right">
                <asp:HiddenField ID="hfCusID" runat="server" />
                <asp:HiddenField ID="hfType" runat="server" Value="1"/>
                <asp:HiddenField ID="hfPrintID" runat="server" />
                日期：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                <td align="right" colspan="2">经办人：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>

            </tr>
            <tr>
                <td class="sysred">往来单位：</td>
                <td style="padding-left:0px;" colspan="3">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbCusName" runat="server" CssClass="pin autot" onmousedown="getSearchResult('../Customer/SchCusList2.aspx','tbCusName','hfCusID','1','btnId',event);" onkeyup="getSearchResult('../Customer/SchCusList2.aspx','tbCusName','hfCusID','1','btnId',event);" AutoCompleteType="Disabled" Width="341"></asp:TextBox>
                    </div>
                </td>
                <td style="padding:0px;"><input id="btnSlt" type="button" onclick="SltCus();" class="bview"/></td>
                <td align="right">往来余额：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbBalance" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox>
                </td>
                <td align="right">应付款：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbRecMoney" runat="server" CssClass="pin" onchange="ValiSFK();"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>优惠金额：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbPreMoney" runat="server" CssClass="pin" onchange="ValiSFK();"></asp:TextBox></td>
                <td  class="sysred" align="right">实付款：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbRealMoney" runat="server" CssClass="pin" onchange="ValiSFKA();"></asp:TextBox></td>
                <td align="right" colspan="2">结算方式：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlChargeStyle" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                <td align="right">结算帐户：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlChargeAccount" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                 
            </tr>
            <tr>
                <td align="right">开票日期：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbInvoiceDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
                </td>
                <td align="right">开票金额：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbInvoiceAmount" runat="server" CssClass="pin" ></asp:TextBox>
                </td>
                <td align="right" colspan="2">发票号码：</td>
                <td style="padding-left:0px;">
                <asp:TextBox ID="tbInvoiceNO" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td>发票类别：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlInvoiceClass" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">支票号码：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbCheckNO" runat="server" CssClass="pin" ></asp:TextBox>
                </td>
                <td align="right">凭证号码：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbVoucherNO" runat="server" CssClass="pin" ></asp:TextBox>
                </td>
                <td colspan="2" align="right">收支项目：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlItem" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                <td align="right">备注：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbRemark" runat="server" CssClass="pin"></asp:TextBox>
                </td>
            </tr>
         </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnAuto" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnId" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
    </div>
    <div class="divh"></div>
    <div id="cndiv2" style="height:1px;">
    <div class="fdiv">
    <div class="sdiv">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvdata_RowDataBound" OnRowDeleting="gvdata_RowDeleting" ShowFooter="true">
                <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="序" />
                <asp:BoundField HeaderText="单据类别" DataField="Type" />
                <asp:BoundField HeaderText="单据编号" DataField="BillID" />
                <asp:BoundField HeaderText="日期" DataField="_Date" />
                <asp:BoundField HeaderText="经办人" DataField="Operator" />
                <asp:BoundField HeaderText="总金额" DataField="Amount" />
                <asp:BoundField HeaderText="已结算金额" DataField="HaveAmount" />
                <asp:BoundField HeaderText="未结算金额" DataField="NotChargeAmount" />
                <asp:TemplateField HeaderText="本次结算" HeaderStyle-ForeColor="#ff0000">
                    <ItemTemplate>
                        <asp:TextBox ID="tbChargeMoney" runat="server" Text='<%# Eval("ChargeAmount") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="备注">
                    <ItemTemplate>
                        <asp:TextBox ID="tbRemark" runat="server" BorderWidth="0" Text='<%# Eval("Remark") %>' ReadOnly="true" Width="200" onfocus="select();"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="删除">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDel" TabIndex="-1" runat="server" CausesValidation="False"  CommandName="Delete" Text="删除" style="color:#0000ff;"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
            <asp:HiddenField ID="hfreclist" runat="server" />
             <span style="display:none;">
             <asp:Button ID="btnId" runat="server" Text="..." OnClick="btnId_Click" />
             <asp:Button ID="btnSltID" runat="server" Text="..." OnClick="btnSltID_Click" />
             </span>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnId" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnSltID" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnAuto" EventName="Click" />
        </Triggers>
     </asp:UpdatePanel>
    </div>
    </div>
    </div>
    <div class="divh"></div>
    <div class="tdiv">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <table cellpadding="0" cellspacing="0" class="tb3">
        <tr>
            <td style="padding-left:15px;">
             <input id="tbSltGoods" type="button" value="选择单据" class="bt1" onclick="SltBill();" />
            </td>
        </tr>
    </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnId" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSltID" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div class="ftool">
    <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
        <tr>
            <td></td>
            <td align="right" style="padding-right:20px;">
                <asp:Button ID="btnAuto" runat="server" Text="自动分配" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnAuto_Click"  />
                <asp:Button ID="btnChk" runat="server" Text="审核" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSaves()==false)return false;" OnClick="btnChk_Click"  />
                <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnAdd_Click" />
                <asp:Button ID="btnClean" runat="server" Text="清空明细" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkClean()==false)return false;" OnClick="btnClean_Click"/>
                <input id="btnPrint" runat="server" type="button" value="打印" class="bt1" onclick="ChkPrint('FKD');" />
                <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseWin();" />
            </td>
        </tr>
    </table>
    </div>
    <div class="fbom">
        <div id="fbon" class="fbon"></div> 
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/detail.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/AutoSchCon.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;

function ChkSave()
{
    if(Chk()==false)
    {
        return false;
    }
}
function ChkSaves()
{
    if(Chk()==false)
    {
        return false;
    }
    if($("ddlChargeAccount").value=="-1")
    {
        window.alert("操作失败！结算帐户不能为空");
        $("ddlChargeAccount").focus();
        return false
    }
}
function Chk()
{
    if(isNull($("tbDate").value))
    {
        window.alert("操作失败！日期不能为空");
        $("tbDate").focus();
        return false
    }
    
    if($("ddlOperator").value=="-1")
    {
        window.alert("操作失败！经办人不能为空");
        $("ddlOperator").focus();
        return false
    }
    
    if(isNull($("hfCusID").value))
    {
        window.alert("操作失败！往来单位不能为空");
        return false
    }
    
    if(!isMoney($("tbRecMoney").value))
    {
        window.alert("操作失败！应付款格式不正确");
        $("tbRecMoney").focus();
        return false
    }else
    {
        if(parseFloat($("tbRecMoney").value)>0)
        {}
        else
        {
            window.alert("操作失败！应付款必须大于零");
            $("tbRecMoney").focus();
            return false
        }
    }
    if(!isMoney($("tbRealMoney").value))
    {
        window.alert("操作失败！实付款格式不正确");
        $("tbRealMoney").focus();
        return false
    }
}
function SltCus()
{
    parent.ShowDialog1(800, 500, 'Financial/SltCus.aspx?f=2&fid='+parent.$("hfActiveWin").value, '选择客户');
}
function Purchase(id)
{
    parent.ShowDialog(800, 480,'Purchase/PurchaseMod.aspx?ids='+id,'采购单');
}
function Sell(id)
{
    parent.ShowDialog(800, 480,'Sell/SellMod.aspx?ids='+id,'销售退货单');
}
function SltBill()
{
    var cusid;
    if(isNull($("hfCusID").value))
    {
        window.alert("请先输入往来单位");
        return false
    }
    cusid=$("hfCusID").value;
    parent.ShowDialog(800, 520, 'Financial/SltBill.aspx?iFlag=2&custype='+$("hfType").value+'&cusid='+cusid, '选择单据');
}

function Chkset()
{
    Chkwh7();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("付应付款");
}
</script>
