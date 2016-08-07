<%@ page language="C#"  CodeFile="readingmod.aspx.cs"     autoeventwireup="true" inherits="Branch_Lease_ReadingMod" enableEventValidation="false" %>
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
    <div class="fdivs" style="width:444px;">
    <div class="sdivs" style="width:442px; padding:3px 0px 3px 0px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
      <table cellpadding="0" cellspacing="0" class="tb5">
            <tr>
                <tr>
                     <td align="right">读数日期：</td>
                    <td style="padding-left:0px;">
                    <asp:TextBox ID="tbDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
                    </td>
                    <td align="right">
                    读数人：</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl">
                        </asp:DropDownList>
                    </td>
                </tr>
            </tr>
            <tr>
                <td align="right">计数器类型：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbQtyType" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox>
                    </td>
                <td align="right">计数：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbQty" runat="server" CssClass="pin"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">损耗张数：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbLoss" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td align="right">备注：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbRemark" runat="server" CssClass="pin"></asp:TextBox>
                </td>
            </tr>
       </table>
      </ContentTemplate>
      </asp:UpdatePanel>
      </div>
      </div>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
function ChkAdd()
{
   if(isNull($("tbDate").value))
    {
        window.alert("操作失败！读数日期不能为空");
        $("tbDate").focus();
        return false
    }
    if($("ddlOperator").value=="-1")
    {
        window.alert("操作失败！读数人不能为空");
        $("ddlOperator").focus();
        return false
    }
    if(isNull($("tbQty").value))
    {
        window.alert("操作失败！计数不能为空");
        $("tbQty").focus();
        return false
    }
    if(!isMoney($("tbQty").value))
    {
        window.alert("计数格式不正确");
        $("tbQty").focus();
        return false
    }
}
</script>
