<%@ page language="C#"  CodeFile="stseritemdecd.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Stat_StSerItemDeCd" enableEventValidation="false" %>
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
        <div id="sa" style="width:446px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
               <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                    <td align="right">���㣺</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlBranch" runat="server" CssClass="pindl" AutoPostBack="true" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">���㷽ʽ��</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlChargeStyle" runat="server" CssClass="pindl">
                            <asp:ListItem Value="">ȫ��</asp:ListItem>
                            <asp:ListItem Value="�͸�">�͸�</asp:ListItem>
                            <asp:ListItem Value="����">����</asp:ListItem>
                            <asp:ListItem Value="���">���</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">���ڣ�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbDateB" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                    <td align="right">����</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbDateE" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">���ݱ�ţ�</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbBillID" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td align="right">����Ա��</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlTechnician" runat="server" CssClass="pindl">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    
                </tr>
                <tr>
                    <td align="right">�ͻ����ƣ�</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbCusName" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td align="right">��ϵ�ˣ�</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">��Ŀ��ţ�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbItemNO" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right">���ƣ�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbName" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">��ʱ��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbPoint" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right">��ɣ�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbTecDeduct" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbTotalB" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right">����</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbTotalE" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr>
            </table>
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ddlBranch" EventName="SelectedIndexChanged" />
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
