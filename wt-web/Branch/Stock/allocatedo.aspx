<%@ page language="C#"  CodeFile="allocatedo.aspx.cs"     autoeventwireup="true" inherits="Branch_Stock_AllocateDo" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:446px; overflow:hidden;">
    <div class="fdivs">
    <div class="sdivs" style="padding:5px 0 5px 0px;width:442px;">
    <table cellpadding="0" cellspacing="0" class="tb4">
        <tr>
            <td style="padding-left:15px;">
            差异原因：</td>
            <td style="padding-left:0px;">
                <asp:RadioButton ID="r1" runat="server" GroupName="1" Checked="true" /> 少发
                <asp:RadioButton ID="r2" runat="server" GroupName="1" /> 损坏
                <asp:RadioButton ID="r3" runat="server" GroupName="1" /> 错发
            </td>
        </tr>
    </table>
    
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td><asp:Label ID="lbMod" runat="server" CssClass="si2">自动调整库存和帐款.</asp:Label></td>
            <td align="right">
                <asp:Button ID="btnAdd" runat="server" Text="确定" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnAdd_Click"/>
                <input id="btnClose" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog();" />
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    </div>
    </div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
