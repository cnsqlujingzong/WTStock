<%@ page language="C#"  CodeFile="SchExpenseCd.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Financial_SchExpenseCd" enableeventvalidation="false" %>

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
        <div id="sa" style="width:456px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
               <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                    <td align="right">�������ڣ�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbDateB" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                    <td align="right">����</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbDateE" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">������ڣ�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbChkDateB" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                    <td align="right">����</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbChkDateE" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">�������ڣ�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbPaymentDateB" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                    <td align="right">����</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbPaymentDateE" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">��ǰ״̬��</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="pindl">
                            <asp:ListItem Value=""></asp:ListItem>
                            <asp:ListItem Value="1">�����</asp:ListItem>
                            <asp:ListItem Value="2">������</asp:ListItem>
                            <asp:ListItem Value="3">�����</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">����ҵ��</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbRelatedBusiness" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">�����ˣ�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbOperator" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right">ժҪ��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbSummary" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">��Χ��</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbMoneyL" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td align="right">����</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbMoneyH" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">�����ʻ���</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlAccount" runat="server" CssClass="pindl">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">����ˣ�</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbChkOperator" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">�����ˣ�</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbPaymentOper" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td align="right">��ע��</td>
                    <td style="padding-left:0px;" colspan="3"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin"></asp:TextBox></td>
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
                    <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnSch_Click"/>
                    <input id="btnCls" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog();"/>
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
