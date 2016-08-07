<%@ page language="C#"  CodeFile="stocklistmod.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Basic_StockListMod" enableEventValidation="false" %>
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
                        <td align="right" class="red">仓库名：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbName" runat="server" CssClass="pin"></asp:TextBox>
                        <asp:HiddenField ID="hfName" runat="server" />
                        </td>
                        <td align="right">管理员：</td>
                        <td style="padding-left:0px;"><asp:DropDownList ID="ddlStkAdm" runat="server"  CssClass="pindl">
                             </asp:DropDownList>
                         </td>
                    </tr>
                    <tr>
                        <td align="right">管理员2：</td>
                        <td style="padding-left:0px;"><asp:DropDownList ID="ddlStkAdm2" runat="server"  CssClass="pindl">
                             </asp:DropDownList>
                         </td>
                         <td align="right" class="red">属性：</td>
                         <td style="padding-left:0px;">
                             <asp:DropDownList ID="ddlAttr" runat="server"  CssClass="pindl" Enabled="false">
                             <asp:ListItem Value="0">良品</asp:ListItem>
                             <asp:ListItem Value="1">废品</asp:ListItem>
                             </asp:DropDownList>
                         </td>
                    </tr>
                    <tr>
                        <td align="right">位置：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td align="right">备注：</td>
                         <td style="padding-left:0px;">
                             <asp:TextBox ID="tbRemark" runat="server" CssClass="pin"></asp:TextBox>
                         </td>
                    </tr>
                    <tr>
                        <td align="right">其他管理员：</td>
                        <td style="padding-left:0px;" colspan="3">
                            <asp:TextBox ID="tbStkAdms" runat="server" TextMode="MultiLine" Width="345px" Height="75px" CssClass="pindl" onfocus="blur();"></asp:TextBox>
                        </td>
                        <td style="padding:0px;text-align:left;"><input id="btnSltStaff" type="button" value="" onclick="SltKeeper();" class="bview"/></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td colspan="3" style="padding-left:0px;">
                            <asp:CheckBox ID="bStop" runat="server" /><span class="sysred">停用标志</span>
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
                <td align="left"><span class="si2">仓库保存后属性将不能修改</span></td>
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
        window.alert("操作失败！仓库名称不能为空");
        $("tbName").focus();
        return false
    }
}
function SltKeeper()
{
    parent.ShowDialog1(400, 510, 'Basic/SltStkAdm.aspx?f=1&fid=iframeDialog', '仓库管理员');
}
</script>
