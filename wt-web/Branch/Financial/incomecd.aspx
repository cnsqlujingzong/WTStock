<%@ page language="C#"  CodeFile="incomecd.aspx.cs"     autoeventwireup="true" inherits="Branch_Financial_IncomeCd" enableEventValidation="false" %>
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
        <div id="sa" style="width:456px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
               <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                    <td align="right">ҵ�����ڣ�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbDateB" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                    <td align="right">����</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbDateE" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">������ڣ�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbDateChkB" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                    <td align="right">����</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbDateChkE" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">�����ˣ�</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">����ˣ�</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlChkOperator" runat="server" CssClass="pindl">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    
                </tr>
                <tr>
                    <td align="right">�������</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlType" runat="server" CssClass="pindl">
                            <asp:ListItem Value=""></asp:ListItem>
                            <asp:ListItem Value="�տ">�տ</asp:ListItem>
                            <asp:ListItem Value="���">���</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">�ʿ����ͣ�</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlRecType" runat="server" CssClass="pindl">
                            <asp:ListItem Value=""></asp:ListItem>
                            <asp:ListItem Value="Ӧ�տ�">Ӧ�տ�</asp:ListItem>
                            <asp:ListItem Value="Ԥ�տ�">Ԥ�տ�</asp:ListItem>
                            <asp:ListItem Value="�����տ�">�����տ�</asp:ListItem>
                            <asp:ListItem Value="Ӧ����">Ӧ����</asp:ListItem>
                            <asp:ListItem Value="Ԥ����">Ԥ����</asp:ListItem>
                            <asp:ListItem Value="��������">��������</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">���㣺</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlBranch" runat="server" CssClass="pindl">
                        </asp:DropDownList>
                    </td>
                    <td align="right">������λ��</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbCusName" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">���㷽ʽ��</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlChargeStyle" runat="server" CssClass="pindl">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">�����ʻ���</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlChargeAccount" runat="server" CssClass="pindl">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    
                    <td align="right">��Ʊ���</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlInvoiceClass" runat="server" CssClass="pindl">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">��֧��Ŀ��</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlItem" runat="server" CssClass="pindl">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">����״̬��</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="pindl">
                            <asp:ListItem Value=""></asp:ListItem>
                            <asp:ListItem Value="�����">�����</asp:ListItem>
                            <asp:ListItem Value="�����">�����</asp:ListItem>
                            <asp:ListItem Value="������">������</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">��ע��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin"></asp:TextBox></td>
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
