<%@ page language="C#"  CodeFile="modm.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Services_ModM" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <div class="main">
        <div class="maincon">
        <div id="sa" style="width:466px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                        <td align="right">产品编号：</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbGoodsNO" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td align="right">名称：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbName" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">规格：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbSpec" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox></td>
                        <td align="right">品牌：</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbBrand" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">单位：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbUnit" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox></td>
                        <td align="right">数量：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbQty" runat="server" CssClass="pin" onblur="ValidateMoney('1');"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">单价：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbPrice" runat="server" CssClass="pin" onblur="ValidateMoney('2');"></asp:TextBox></td>
                        <td align="right">税率：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbTaxRate" runat="server" CssClass="pin" onblur="ValidateMoney('3');"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">税额：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbTaxAmount" runat="server" CssClass="pinb"></asp:TextBox></td>
                        <td align="right">金额：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbAmount" runat="server" CssClass="pinb"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">序列号：</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbSN" runat="server" CssClass="pin"></asp:TextBox>
                        </td>
                        <td align="right">保修期：</td>
                        <td style="padding-left:0px;">
                            <div class="isinDiv">
                            <input type="text" id="tbProt" runat="server" class="pin pinin" />
                                <select id="Select1" onchange="document.getElementById('tbProt').value=this.options[this.selectedIndex].value" class="pininsl">
                                    <option value="" selected="selected"></option>
                                    <option value="无保修">无保修</option>
                                    <option value="一个月">一个月</option>
                                    <option value="三个月">三个月</option>
                                    <option value="六个月">六个月</option>
                                    <option value="一年">一年</option>
                                    <option value="两年">两年</option>
                                    <option value="三年">三年</option>
                                    <option value="五年">五年</option>
                                    <option value="终生">终生</option>
                                </select>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">截至日期：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbProtEnd" runat="server" CssClass="pin"></asp:TextBox></td>                    
                        <td align="right">结算方式：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlChargeStyle" runat="server" CssClass="pindl">
                                <asp:ListItem Value="客付">客付</asp:ListItem>
                                <asp:ListItem Value="厂付">厂付</asp:ListItem>
                                <asp:ListItem Value="免费">免费</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">是否外购：</td>
                        <td style="padding-left:0px;">
                            <asp:CheckBox ID="cbOutSourcing" runat="server" />
                        </td>
                        <td align="right">外购单价：</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbOutPrice" runat="server" CssClass="pin" onfocus="select();"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">备注：</td>
                        <td style="padding-left:0px;" colspan="3"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="341"></asp:TextBox></td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>
            </div>
            </div>
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td><asp:Label ID="lbMod" runat="server"></asp:Label></td>
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnAdd_Click"/>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
var isfocus=1;
var processtip=1;

//检查输入
function ValidateMoney(flag)
{
    if(isMoney($("tbQty").value))
    {
        if(isMoney($("tbPrice").value))
        {
            if(isMoney($("tbPrice").value))
            {
                var a=parseFloat($("tbPrice").value)*parseFloat($("tbQty").value);
                var taxa=a*parseFloat($("tbTaxRate").value);
                var amt=a+taxa;
                $("tbTaxAmount").value=cc(taxa.toString());
                $("tbAmount").value=cc(amt.toString());
            }else
            {
                window.alert("输入格式不正确！请重新输入");
                if(flag=="1")
                    $("tbQty").select();
                else if(flag="2")
                    $("tbPrice").select();
                else
                    $("tbTaxRate").select();
                return false;
            }
        }else
        {
            window.alert("输入格式不正确！请重新输入");
            if(flag=="1")
                $("tbQty").select();
            else if(flag="2")
                $("tbPrice").select();
            else
                $("tbTaxRate").select();
        }
    }
    else
    {
        window.alert("输入格式不正确！请重新输入");
        if(flag=="1")
            $("tbQty").select();
        else if(flag="2")
            $("tbPrice").select();
        else
            $("tbTaxRate").select();
        return false;
    }
}

function cc(s)
{
    if(/[^0-9\.]/.test(s)) return "invalid value";
    s=s.replace(/^(\d*)$/,"$1.");
    s=(s+"00").replace(/(\d*\.\d\d)\d*/,"$1");
    s=s.replace(/,(\d\d)$/,".$1");
    return s.replace(/^\./,"0.");
}
</script>
