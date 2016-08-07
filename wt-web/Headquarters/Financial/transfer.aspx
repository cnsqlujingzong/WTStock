<%@ page language="C#"  CodeFile="transfer.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Financial_Transfer" enableEventValidation="false" %>
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
        帐户转账
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td align="right">制单日期：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                <td align="right">经办人：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                <td align="right" class="sysred">付款帐户：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlFAccount" runat="server" CssClass="pindl" AutoPostBack="True" OnSelectedIndexChanged="ddlFAccount_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>帐户余额：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbFBalance" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="sysred">收款帐户：</td>
                <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlSAccount" runat="server" CssClass="pindl" AutoPostBack="True" OnSelectedIndexChanged="ddlSAccount_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>帐户余额：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbSBalance" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox>
                </td>
                 <td class="sysred">转账金额：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbAmount" runat="server" CssClass="pin" ></asp:TextBox>
                </td>
                <td align="right">支票号码：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbCheckNO" runat="server" CssClass="pin" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                 <td>凭证号码：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbVoucherNO" runat="server" CssClass="pin" ></asp:TextBox>
                </td>
                <td align="right">备注：</td>
                <td colspan="5" style="padding-left:0px;">
                    <asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="341"></asp:TextBox>
                </td>
            </tr>
         </table>
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
                <asp:Button ID="btnChk" runat="server" Text="审核" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnChk_Click"  />
                <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnAdd_Click" />
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
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;

function ChkSave()
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
    
    if($("ddlFAccount").value=="-1")
    {
        window.alert("操作失败！付款帐户不能为空");
        $("ddlFAccount").focus();
        return false
    }
    if($("ddlSAccount").value=="-1")
    {
        window.alert("操作失败！收款帐户不能为空");
        $("ddlSAccount").focus();
        return false
    }
    if($("ddlFAccount").value==$("ddlSAccount").value)
    {
        window.alert("操作失败！收付款帐户不能相同");
        $("ddlFAccount").focus();
        return false
    }
    if(!isMoney($("tbAmount").value))
    {
        window.alert("操作失败！金额格式不正确");
        $("tbAmount").focus();
        return false
    }else
    {
        if(parseFloat($("tbAmount").value)>0)
        {}
        else
        {
            window.alert("操作失败！金额必须大于零");
            $("tbAmount").focus();
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
    $("fbon").innerHTML=parent.DrawInfo("帐户转账");
}
</script>
