<%@ page language="C#"  CodeFile="modd.aspx.cs"     autoeventwireup="true" inherits="Branch_Services_ModD" enableEventValidation="false" %>
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
        <div id="sa" style="width:446px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                        <td align="right">名称：</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbName" runat="server" CssClass="pin"></asp:TextBox>
                        </td>
                        <td align="right">参数：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbParameter" runat="server" CssClass="pin"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">序列号：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbSN" runat="server" CssClass="pin"></asp:TextBox></td>
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
                        <td align="right">购买日期：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbBuyDate" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td align="right">截止日期：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbMaintenanceEnd" runat="server" CssClass="pin"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">备注：</td>
                        <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="341"></asp:TextBox></td>
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
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
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
function ChkAdd()
{
    if(isNull($("tbName").value))
    {
        window.alert("操作失败！名称不能为空");
        $("tbName").focus();
        return false
    }
}

</script>
