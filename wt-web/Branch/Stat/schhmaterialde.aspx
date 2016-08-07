<%@ page language="C#"  CodeFile="schhmaterialde.aspx.cs"     autoeventwireup="true" inherits="Branch_Stat_SchHMaterialDe" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="main">
        <div class="maincon">
        <div id="sa" style="width:486px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
               <table cellpadding="0" cellspacing="0" class="tb3">
               <tr>
                    <td align="right">业务编号：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbNO" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td align="right">客户名称：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbCusName" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">联系人：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td align="right">联系电话：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbTel" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">使用人：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbDUser" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td align="right">使用人电话：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbDUsePeoTel" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">受理时间：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbAcceptTimeBegin" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
                    </td>
                    <td align="right">至：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbAcceptTimeEnd" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">机器名称：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbDName" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td align="right">机器参数：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbDPra" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">机器序列号：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbDSN" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td align="right">机器购买日期：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbBuydate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">备件编号：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbMNO" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td align="right">备件名称：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbMName" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                </tr>
                                <tr>
                    <td align="right">备件数量：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbMQty" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td align="right">备件价格：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbMPrice" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">备件总额：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbMtotal" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td align="right">备件序列号：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbMSN" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">备件成本：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbMChengben" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td align="right"></td>
                    <td style="padding-left:0px;">
                    </td>
                </tr>
            </table>
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>
            </div>
            </div>
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td align="right">
                    <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false) return false" OnClick="btnSch_Click"/>
                    <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog();"/>
                </td>
            </tr>
            </table>
         </div>
        </div>
        </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
function SltTec()
{
    parent.ShowDialog1(400, 510, '../Headquarters/Stat/SltOperator.aspx?f=1&x=1&strid=tbOperators&bSell=1', '业务员');
}
function  ChkAdd()
{
    if(!isNull($("tbMQty").value))
    {
        if(!isDigit($("tbMQty").value))
        {
            window.alert("数量格式不正确");
            $("tbMQty").focus();
            return false
        }
    }
    if(!isNull($("tbMPrice").value))
    {
        if(!isMoney($("tbMPrice").value))
        {
            window.alert("价格格式不正确");
            $("tbMPrice").focus();
            return false
        }
    }
    if(!isNull($("tbMtotal").value))
    {
        if(!isMoney($("tbMtotal").value))
        {
            window.alert("金额格式不正确");
            $("tbMtotal").focus();
            return false
        }
    }
    if(!isNull($("tbMChengben").value))
    {
        if(!isMoney($("tbMChengben").value))
        {
            window.alert("金成本格式不正确");
            $("tbMChengben").focus();
            return false
        }
    }
 }
</script>
