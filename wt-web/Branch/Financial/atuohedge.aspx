<%@ page language="C#"  CodeFile="atuohedge.aspx.cs"     autoeventwireup="true" inherits="Branch_Financial_AtuoHedge" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:446px;">
    <div class="fdivs">
    <div class="sdivs" style="padding:3px 0 3px 0px;width:442px;">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
       <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td align="right">
                应收款：</td>
            <td style="padding-left:0px; height:40px;"><asp:TextBox ID="tbRec" runat="server" CssClass="pinbbr" ReadOnly="true"></asp:TextBox></td>
            <td align="right">应付款：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDue" runat="server" CssClass="pinbbr" ReadOnly="true"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right">对冲金额：</td>
            <td style="padding-left:0px; height:40px;">
                <asp:TextBox ID="tbMoney" runat="server" CssClass="pin"></asp:TextBox>
            </td>
            <td>对冲帐户：</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlAccount" runat="server" CssClass="pindl">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="color:#666;">*对冲后将自动生成收款单和付款单</td>
        </tr>
        <tr>
            <td colspan="4" style="color:#666;">*对冲帐户即为收款账户和付款帐户</td>
        </tr>
   </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td><asp:Label ID="lbMod" runat="server"></asp:Label>
            </td>
            <td align="right">
                <asp:Button ID="btnSave" runat="server" Text="确定" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnSave_Click" />
                <input id="btnClose" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog();" />
            </td>
        </tr>
    </table>
    </div>
    </div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/detail.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
function ChkSave()
{
    if(!isMoney($("tbMoney").value))
    {
        window.alert("操作失败！对冲金额格式不正确");
        $("tbMoney").focus();
        return false
    }else
    {
        if(parseFloat($("tbMoney").value)>0)
        {}
        else
        {
            window.alert("操作失败！对冲金额必须大于零");
            $("tbMoney").focus();
            return false
        }
    }
    
    if($("ddlAccount").value=="-1")
    {
        window.alert("操作失败！对冲帐户不能为空");
        $("ddlAccount").focus();
        return false
    }
}
</script>
