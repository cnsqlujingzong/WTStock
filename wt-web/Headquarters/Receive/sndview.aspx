<%@ page language="C#"  CodeFile="sndview.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Receive_SndView" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:710px;">
    <div class="fdivs">
    <div class="sdivs" style="padding:3px 0 3px 0px;width:706px;">
        <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td>�������ţ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbBillID" runat="server" CssClass="pinb" Width="110" ReadOnly="true"></asp:TextBox></td>
            <td>���ڣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDate" runat="server" CssClass="pin" Width="80" ></asp:TextBox></td>
            <td class="red">�����ˣ�</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl" Width="70">
                </asp:DropDownList>
            </td>
            <td>���</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlSndType" runat="server" CssClass="pindl" Width="53">
                    <asp:ListItem Value=""></asp:ListItem>
                    <asp:ListItem Value="����">����</asp:ListItem>
                    <asp:ListItem Value="����">����</asp:ListItem>
                    <asp:ListItem Value="����">����</asp:ListItem>
                    <asp:ListItem Value="����">����</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="sysred">�ջ����ͣ�</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlRcvObj" runat="server" CssClass="pindl" Width="53">
                    <asp:ListItem Value="�ͻ�">�ͻ�</asp:ListItem>
                    <asp:ListItem Value="����">����</asp:ListItem>
                    <asp:ListItem Value="����">����</asp:ListItem> 
                    <asp:ListItem Value="����">����</asp:ListItem>
                </asp:DropDownList>
                
            </td>
        </tr>
     </table>
    <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td class="red">��˾���ƣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbCusName" runat="server" CssClass="pin" Width="250"></asp:TextBox>
            </td>
            <td>�ջ��ˣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin" Width="80"></asp:TextBox></td>
            <td>��ϵ�绰��</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin"></asp:TextBox></td>
        </tr>
        <tr>
            <td>�ջ���ַ��</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin" Width="250"></asp:TextBox></td>
            <td align="right">�ʱࣺ</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbZip" runat="server" CssClass="pin" Width="80"></asp:TextBox>
            </td>
            <td class="red">�������ƣ�</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlBranch" runat="server" CssClass="pindl" >
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td>��ƷժҪ��</td>
            <td style="padding-left:0px; height:50px;"><asp:TextBox ID="tbSummary" runat="server" CssClass="pin" Width="610" TextMode="MultiLine" Height="42"></asp:TextBox></td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td>���˷�ʽ��</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlShipStyle" runat="server" CssClass="pindl">
                </asp:DropDownList>
            </td>
            <td>�������ţ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbSndNo" runat="server" CssClass="pin"></asp:TextBox></td>
            <td>���ʣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbPostage" runat="server" CssClass="pin"></asp:TextBox></td>
        </tr>
     </table>
    <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td>��ע��Ϣ��</td>
            <td style="padding-left:0px;height:50px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="610" TextMode="MultiLine" Height="42"></asp:TextBox></td>
        </tr>
    </table>
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td><span class="si1">�������޷��޸ģ�ֻ��ͨ��ȡ������</span><asp:HiddenField ID="hfPrintID" runat="server" />
            </td>
            <td align="right">
                <asp:Button ID="btnSave" runat="server" Text="���汸ע" CssClass="bt1" OnClick="btnSave_Click" />
                <input id="btnPrint" type="button" value="��ӡ" class="bt1" onclick="ChkPrint('FHD');" />
                <input id="btnClose" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog();" />
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
