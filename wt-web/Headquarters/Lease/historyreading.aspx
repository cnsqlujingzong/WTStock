<%@ page language="C#"  CodeFile="historyreading.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Lease_HistoryReading" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/frame.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="ftool">
        <div class="ftoolleft">
        <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td class="red">
                   ���������ͣ�
                </td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlQtyType" runat="server" Width="100">
                    </asp:DropDownList>
                </td>
                <td>
                    �������ڣ�
                </td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbDateB" runat="server" CssClass="Wdate3" onfocus="WdatePicker()"></asp:TextBox>
                </td>
                <td style="padding-left:3px;">����</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbDateD" runat="server" CssClass="Wdate3" onfocus="WdatePicker()"></asp:TextBox>
                </td>
                <td align="left">
                    <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
                 </tr>
            </table>   
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td>
                <span style="display:none;">
                    <asp:Button ID="btnClr" runat="server" Text="����ѡ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                    <asp:Button ID="btnOrder" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                </span>
            </td>
            </tr>
            </table>
        </div>
        <div class="clearfloat"></div>
    </div>
    <div id="cndiv" style="height:435px; width:700px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="�������" DataField="DeviceNO" />
            <asp:BoundField HeaderText="�������к�" DataField="ProductSN1" />
            <asp:BoundField HeaderText="��������" DataField="_Date" />
            <asp:BoundField HeaderText="������" DataField="Operator" />
            <asp:BoundField HeaderText="����������" DataField="_Name" />
            <asp:BoundField HeaderText="����" DataField="Qty" />
            <asp:BoundField HeaderText="��ע"  DataField="WRemark"/>
        </Columns>
    </asp:GridView>
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
        <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
        <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
        <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div style="background:#ECE9D8;" >
    <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
        <tr>
            <td align="right" style="padding-right:20px;">
                <input id="btnCls" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog1();" />
            </td>
        </tr>
    </table>
    </div>
    <div class="clearfloat"></div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
function ChkID(id)
{
    ClrID(id);
}

document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog1();}catch(e){}}}
</script>
