<%@ page language="C#"  CodeFile="otherinadd.aspx.cs"     autoeventwireup="true" inherits="Branch_Financial_OtherInAdd" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body onload="Chkset();" onclick="parent.Sethidden1();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="cndiv" style="height:1px;">
    <div class="tldiv">
        其他收款
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td>收款单号：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBillID" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox></td>
                <td align="right">日期：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                <td align="right">经办人：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                
            </tr>
            <tr>
               <td class="sysred">往来单位：</td>
                <td style="padding-left:0px;" colspan="3">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbCusName" runat="server" CssClass="pin autot" onmousedown="getSearchResult('../Customer/SchCusList2.aspx','tbCusName','hfCusID','1','',event);" onkeyup="getSearchResult('../Customer/SchCusList2.aspx','tbCusName','hfCusID','1','',event);" AutoCompleteType="Disabled" Width="341"></asp:TextBox>
                    </div>
                </td>
                <td align="right" class="sysred">金额：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbMoney" runat="server" CssClass="pin"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>结算方式：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlChargeStyle" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                <td>结算帐户：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlChargeAccount" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                <td align="right">开票日期：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbInvoiceDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td align="right">开票金额：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbInvoiceAmount" runat="server" CssClass="pin" ></asp:TextBox>
                </td>
                
                <td align="right">发票号码：</td>
                <td style="padding-left:0px;">
                <asp:TextBox ID="tbInvoiceNO" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td align="right">发票类别：</td>
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
                <td>收支项目：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlItem" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                
            </tr>
            <tr>
                <td align="right">备注：</td>
                <td colspan="3" style="padding-left:0px;">
                    <asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="341"></asp:TextBox>
                </td>
            </tr>
         </table>
        <asp:HiddenField ID="hfCusID" runat="server" />
        <asp:HiddenField ID="hfType" runat="server" Value="1"/>
        <asp:HiddenField ID="hfPrintID" runat="server" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div class="divh"></div>
    <div class="ftool">
    <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
        <tr>
            <td></td>
            <td align="right" style="padding-right:20px;">
                <asp:Button ID="btnChk" runat="server" Text="审核" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSaves()==false)return false;" OnClick="btnChk_Click"  />
                <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnAdd_Click" />
                <input id="btnPrint" runat="server" type="button" value="打印" class="bt1" onclick="ChkPrint('SKD');" />
                <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseWin();" />
            </td>
        </tr>
    </table>
    </div>
    
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
        $("tbCusName").focus();
        return false
    }
        
    if(!isMoney($("tbMoney").value))
    {
        window.alert("操作失败！预收金额格式不正确");
        $("tbMoney").focus();
        return false
    }else
    {
        if(parseFloat($("tbMoney").value)>0)
        {}
        else
        {
            window.alert("操作失败！预收金额必须大于零");
            $("tbMoney").focus();
            return false
        }
    }
}

function Chkset()
{
    Chkwh6();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("其他收款");
}
</script>
