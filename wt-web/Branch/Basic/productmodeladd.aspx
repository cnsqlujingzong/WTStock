<%@ page language="C#"  CodeFile="productmodeladd.aspx.cs"     autoeventwireup="true" inherits="Branch_Basic_ProductModelAdd" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body onload="ChkSetFocus('tbName');">
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
                <table cellpadding="0" cellspacing="0" class="tb4">
            <tr>
                <td>Ʒ�ƣ�</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlBrand" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                <td align="right">���</td>
                <td style="padding-left:0px;">              
                    <asp:DropDownList ID="ddlClass" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>�ͺţ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbName" runat="server" CssClass="pin" ToolTip="�����ͺ�����"></asp:TextBox>
                    <asp:HiddenField ID="hfTemp" runat="server" />
                </td>
                <td align="right">�����ڣ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbPeriod" runat="server" CssClass="pin" ToolTip="���뱣����"></asp:TextBox>
                    ��
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
                    <asp:Button ID="btnAdd" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
                    <input id="btnCls" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog<%=Str_F %>();"/>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
function ChkAdd()
{
    if($("ddlBrand").value=="-1")
    {
        window.alert("����ʧ�ܣ�Ʒ�Ʋ���Ϊ��");
        $("ddlBrand").focus();
        return false
    }
    if($("ddlClass").value=="-1")
    {
        window.alert("����ʧ�ܣ������Ϊ��");
        $("ddlClass").focus();
        return false
    }
    if(isNull($("tbName").value))
    {
        window.alert("����ʧ�ܣ��ͺŲ���Ϊ��");
        $("tbName").focus();
        return false
    }
}
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog<%=Str_F %>();}catch(e){}}}
</script>
