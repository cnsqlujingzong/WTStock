<%@ page language="C#"  CodeFile="inpayview.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Financial_InPayView" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:656px;">
    <div class="fdivs">
    <div class="sdivs" style="padding:3px 0 3px 0px;width:652px;">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
       <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td>
                <asp:Label ID="lbType" runat="server" Text=""></asp:Label>�ţ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbBillID" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox></td>
            <td align="right">���ڣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDate" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox></td>
            <td align="right" class="red">�����ˣ�</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl" Enabled="false">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" class="sysred">�ʿ����ͣ�</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbRecType" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox>
            </td>
            <td class="sysred">������λ��</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbCusName" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox>
            </td>
            <td align="right">Ӧ<asp:Label ID="lbsy1" runat="server" Text=""></asp:Label>�</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbAmount" runat="server" CssClass="pinb" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>�Żݽ�</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbYAmount" runat="server" CssClass="pinb" ></asp:TextBox>
            </td>
            <td align="right">ʵ<asp:Label ID="lbsy2" runat="server" Text=""></asp:Label>�</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbRealAmount" runat="server" CssClass="pinb" ></asp:TextBox>
            </td>
            <td>���㷽ʽ��</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlChargeStyle" runat="server" CssClass="pindl">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>�����ʻ���</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlChargeAccount" runat="server" CssClass="pindl">
                </asp:DropDownList>
            </td>
            <td align="right">��Ʊ���ڣ�</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbInvoiceDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
            </td>
            <td align="right">��Ʊ��</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbInvoiceAmount" runat="server" CssClass="pin" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">��Ʊ���룺</td>
            <td style="padding-left:0px;">
            <asp:TextBox ID="tbInvoiceNO" runat="server" CssClass="pin"></asp:TextBox>
            </td>
            <td>��Ʊ���</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlInvoiceClass" runat="server" CssClass="pindl">
                </asp:DropDownList>
            </td>
            <td align="right">֧Ʊ���룺</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbCheckNO" runat="server" CssClass="pin" ></asp:TextBox>
            </td>
             
        </tr>
        <tr>
            <td>ƾ֤���룺</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbVoucherNO" runat="server" CssClass="pin" ></asp:TextBox>
            </td>
            <td>��֧��Ŀ��</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlItem" runat="server" CssClass="pindl">
                </asp:DropDownList>
            </td>
            <td align="right">��ע��</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbRemark" runat="server" CssClass="pin"></asp:TextBox>
            </td>
        </tr>
    </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td><asp:Label ID="lbMod" runat="server"></asp:Label><asp:HiddenField ID="hfPrintID" runat="server" />
            </td>
            <td align="right">
                <asp:Button ID="btnSave" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnSave_Click" />
                <input id="btnClose" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog<%=str_flag %>();" />
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
