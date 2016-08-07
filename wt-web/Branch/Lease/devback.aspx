<%@ page language="C#"  CodeFile="devback.aspx.cs"     autoeventwireup="true" inherits="Branch_Lease_DevBack" enableEventValidation="false" %>
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
    <div id="sad" style="width:444px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
      <fieldset style=" border: 1px #808080 solid; padding:5px 0; width:440px;">
      <legend>机器入库</legend>
        <table cellpadding="0" cellspacing="0" class="tb5">
            <tr>
                <td>
                    入库设备：
                </td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlGoodsName" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                <td>
                    入库仓库：
                </td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlInStock" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                
            </tr>
            <tr>
                <td>
                    入库金额：
                </td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbPrice" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td>
                    <asp:HiddenField ID="hfType" runat="server" />
                </td>
                <td colspan="2">
                    <a href="javascript:parent.ShowDialog(617,310,'Lease/DevBackBat.aspx?id=<%=ID %>','批量退机');">批量退机</a>
                </td>
            </tr>
            <tr>
                <td>入库数量：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbCount" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td></td>
                <td></td>
            </tr>
        </table>
      </fieldset>
      </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
      <div class="divh"></div>
        <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
            </td>
            <td align="right">
                <asp:Button ID="btnAdd" runat="server" Text="确定" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
                <input id="btnCls" type="button" value="取消" class="bt1" onclick="parent.CloseDialog();"/>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/detailslt.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/detail.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
function ChkAdd()
{
   if($("hfType").value=="租赁")
    {
        if($("ddlInStock").value=="-1")
        {
            window.alert("操作失败！入库仓库不能为空");
            $("ddlInStock").focus();
            return false
        }
        if(isNull($("tbPrice").value))
        {
            window.alert("操作失败！入库金额不能为空");
            $("tbPrice").focus();
            return false
        }
        if(!isMoney($("tbPrice").value))
        {
            window.alert("入库金额格式不正确");
            $("tbPrice").focus();
            return false
        }
        if(!isDigit($("tbCount").value))
        {
            window.alert("输入内容必须为数字");
            $("tbCount").focus();
            return false
        }
    }
}
</script>
