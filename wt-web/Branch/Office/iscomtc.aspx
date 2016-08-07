<%@ page language="C#"  CodeFile="iscomtc.aspx.cs"     autoeventwireup="true" inherits="Branch_Office_IsComTc" enableEventValidation="false" %>
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
                        <td >员工姓名：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbName" runat="server" CssClass="pin" ReadOnly="true"></asp:TextBox></td>
                        <td >业务单号：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbBiilNO" runat="server" CssClass="pin" ReadOnly="true"></asp:TextBox></td>
                    </tr>
                    
                    <tr>
                        <td align="right">日期：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbDate" runat="server" CssClass="pin" ReadOnly="true"></asp:TextBox></td>
                        <td align="right">业务类别：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbBillType" runat="server" CssClass="pin" ReadOnly="true"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">所属：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbSuoShu" runat="server" CssClass="pin" ReadOnly="true"></asp:TextBox></td>
                        <td align="right">是否收款：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbIsShouKuan" runat="server" CssClass="pin" ReadOnly="true"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">提成：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbTcAmount" runat="server" CssClass="pin" ReadOnly="true"></asp:TextBox></td>
                        <td style="display:none;" align="right" class="red">提成发放：</td>
                        <td style="padding-left:0px;display:none;">
                            <asp:DropDownList ID="ddlIsCom" runat="server" Width="135px">
                            </asp:DropDownList>
                        </td>
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
                    <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click" />
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
<script language="javascript" type="text/javascript" src="../../Public/Script/detail.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/AutoSchCon.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
function ChkAdd()
{
    if($("ddlIsCom").value=="-1")
    {
        window.alert("请选择发放类别！");
        $("ddlIsCom").focus();
        return false
    }
}
</script>
