<%@ page language="C#"  CodeFile="crelease.aspx.cs"     autoeventwireup="true" inherits="Branch_Lease_CRelease" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="ddd" style="width:586px;">
    <div class="fdivs" style="width:584px; height:40px;">
    <div class="sdivs" style="width:582px; height:38px;">
    <div class="divh"></div>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb5">
            <tr>
                <td>���ֿ⣺</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlStock" runat="server" CssClass="pindl3" Width="120">
                    </asp:DropDownList>
                </td>
                <td align="right">
                �����ˣ�</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl3" Width="120">
                    </asp:DropDownList>
                </td>
                <td align="right">���ڣ�</td>
                <td style="padding-left:0px;">
                <asp:TextBox ID="tbDate" runat="server" CssClass="Wdate3" onfocus="WdatePicker()" Width="120"></asp:TextBox>
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
    <div class="fdivs" style="width:584px; height:237px;">
    <div class="sdivs" style="width:582px; height:235px; overflow:auto; background:#ffffff;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvdata_RowDataBound">
                <Columns>
                <asp:BoundField HeaderText="��" />
                <asp:BoundField HeaderText="id" DataField="ID" />
                <asp:TemplateField HeaderText="�����" HeaderStyle-ForeColor="#ff0000">
                    <ItemTemplate>
                        <asp:TextBox ID="tbPrice" runat="server" Width="80" onfocus="select();"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="���޻���" DataField="GoodsNO" />
                <asp:BoundField HeaderText="����Ʒ��" DataField="Brand" />
                <asp:BoundField HeaderText="���" DataField="Class" />
                <asp:BoundField HeaderText="�ͺ�" DataField="Model" />
                <asp:BoundField HeaderText="���к�" DataField="ProductSN1" />
                </Columns>
            </asp:GridView>
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
            <td align="right">
                <asp:Button ID="btnAdd" runat="server" Text="ȷ��" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
                <input id="btnCls" type="button" value="ȡ��" class="bt1" onclick="parent.CloseDialog();"/>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/detailslt.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/detail.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
function ChkAdd()
{
    if($("ddlStock").value=="-1")
    {
        window.alert("����ʧ�ܣ����ֿⲻ��Ϊ��");
        $("ddlStock").focus();
        return false
    }
    if(isNull($("tbDate").value))
    {
        window.alert("����ʧ�ܣ����ڲ���Ϊ��");
        $("tbDate").focus();
        return false
    }
    if($("ddlOperator").value=="-1")
    {
        window.alert("����ʧ�ܣ������˲���Ϊ��");
        $("ddlOperator").focus();
        return false
    }
}

</script>
