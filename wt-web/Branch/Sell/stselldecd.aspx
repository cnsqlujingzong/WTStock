<%@ page language="C#"  CodeFile="stselldecd.aspx.cs"     autoeventwireup="true" inherits="Branch_Sell_StSellDeCd" enableEventValidation="false" %>
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
                        <asp:DropDownList ID="ddlBranch" runat="server" CssClass="pindl" OnSelectedIndexChanged ="ddlBranch_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">�ֿ⣺</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlStock" runat="server" CssClass="pindl">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">�Ƶ��ˣ�</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlPerson" runat="server" CssClass="pindl">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>    
                    <td align="right">ҵ��Ա��</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl" OnSelectedIndexChanged="ddlOperator_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">�������ţ�</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlDept" runat="server" CssClass="pindl">
                            <asp:ListItem Value=""></asp:ListItem>
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
                    <td align="right">�ͻ����ƣ�</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbCusName" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td align="right">����ˣ�</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlChkOperator" runat="server" CssClass="pindl">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">������ڣ�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbChkDateB" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                    <td align="right">����</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbChkDateE" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">��Ʒ��ţ�</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbGoodsNO" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td align="right">���ƣ�</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbName" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">���</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbSpec" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right">Ʒ�ƣ�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbBrand" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbTotalB" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right">����</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbTotalE" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">�ͻ��ˣ�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbSndOper" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right">����״̬��</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="pindl">
                        <asp:ListItem Value="0">ȫ��</asp:ListItem>
                        <asp:ListItem Value="�����">�����</asp:ListItem>
                        <asp:ListItem Value="�����">�����</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ddlOperator" EventName="SelectedIndexChanged" />
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
