<%@ page language="C#"  CodeFile="allocateview.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Stock_AllocateView" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:786px;">
    <div class="fdivs">
    <div class="sdivs" style="padding:3px 0 3px 0px;">
        <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td>�������ţ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbBillID" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox></td>
            <td>���ڣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDate" runat="server" CssClass="pin"></asp:TextBox></td>
            <td>�����ˣ�</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>�������㣺</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlBranch" runat="server" CssClass="pindl">
                </asp:DropDownList>
            </td>
            <td>��ע��</td>
            <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="328"></asp:TextBox></td>
        </tr>
     </table>
    </div>
    </div>
    <div class="divh"></div>
    <div id="cndiv" style="height:310px;">
        <div class="fdivs" style="height:308px;">
            <div class="sdivs" style="height:306px;background:#ffffff;">
            <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="gvdata_RowDataBound">
                <Columns>
                <asp:BoundField HeaderText="��" />
                <asp:BoundField HeaderText="��Ʒ���" DataField="GoodsNO" />
                <asp:BoundField HeaderText="����" DataField="_Name" />
                <asp:BoundField HeaderText="���" DataField="Spec" />
                <asp:BoundField HeaderText="Ʒ��" DataField="ProductBrand" />
                <asp:BoundField HeaderText="��λ" DataField="Unit" />
                <asp:BoundField HeaderText="����" DataField="AppQty" />
                <asp:BoundField DataField="MainTenancePeriod" HeaderText="������" />
                <asp:TemplateField HeaderText="��ע">
                    <ItemTemplate>
                        <asp:TextBox ID="tbRemark" runat="server" BorderWidth="0" Width="200" Text='<%# Eval("Remark") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </div>
        </div>
    </div>
    <div class="divh"></div>
    <div class="fdivs">
    <div class="sdivs" style="padding:1px 0 1px 0px;">
    <table cellpadding="0" cellspacing="0" class="tb4">
        <tr>
            <td style="padding-left:15px;">
                <asp:DropDownList ID="ddlSchFld" runat="server" CssClass="pindl" Width="70">
                    <asp:ListItem Value="GoodsNO">�����</asp:ListItem>
                    <asp:ListItem Value="BarCode">������</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td><asp:TextBox ID="tbCon" runat="server" CssClass="pin" Enabled="false" ToolTip="������ɺ�س����"></asp:TextBox></td>
            <td><input id="tbSltGoods" type="button" value="ѡ���Ʒ" class="bt1" /></td>
            <td style="padding-left:10px;">�ϼ�������</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbAQty" runat="server" CssClass="pinbbr" ReadOnly="true" Width="100"></asp:TextBox></td>
        </tr>
    </table>
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:Label ID="lbMod" runat="server"></asp:Label>
                <asp:HiddenField ID="hfPrintID" runat="server" />
            </td>
            <td align="right">
                <input id="btnPrint" runat="server" type="button" value="��ӡ" class="bt1" onclick="ChkPrint('DBD');" />
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
