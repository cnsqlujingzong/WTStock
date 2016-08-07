<%@ page language="C#"  CodeFile="trackallot.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Customer_TrackAllot" enableEventValidation="false" %>
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
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
               <table cellpadding="0" cellspacing="0" class="tb5">
                <tr>
                    <td align="right">
                    技术员：</td>
                    <td style="padding-left:0px; width:130px;">
                        <asp:TextBox ID="tbDisposal" runat="server" CssClass="pinks"></asp:TextBox>
                    </td>
                    <td style="padding:0px; text-align:left;"><input id="btnSltStaff" type="button" value="" onclick="SltTec();" class="bview"/></td>
                    <td align="right">服务级别：</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlPRI" runat="server" CssClass="pindl">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
               </tr>
               <tr>
                    <td align="right">备注：</td>
                    <td style="padding-left:0px;height:90px;" colspan="4">
                    <asp:TextBox ID="tbRemark" runat="server" CssClass="pin" TextMode="MultiLine" Height="74" Width="358"></asp:TextBox></td>
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
                <td>
                    <asp:Label ID="lbMod" runat="server" Text=""></asp:Label>
                </td>
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="确定" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnAdd_Click"/>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
function SltTec()
{
    parent.ShowDialog1(400, 510, 'Services/SltTec.aspx?f=1', '技术员');
}
</script>
