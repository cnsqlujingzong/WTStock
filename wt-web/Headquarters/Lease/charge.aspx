<%@ page language="C#"  CodeFile="charge.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Lease_Charge" theme="Themes" enableEventValidation="false" %>
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
    <div id="sad" style="width:686px;">
    
    <fieldset style=" border: 1px #808080 solid; padding:5px 0; width:680px;">
      <legend>��������</legend>
      <table cellpadding="0" cellspacing="0" class="tb5">
            <tr>
                <td>�������ڣ�</td>
                <td style="padding:0px;">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:TextBox ID="tbCycle" runat="server" CssClass="pinb" Width="102" ReadOnly="true"></asp:TextBox>
               
               </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btncycled" EventName="Click" />
                </Triggers>
                </asp:UpdatePanel>
                </td>
                <td style="padding-left:5px;padding-right:5px;">=</td>
                <td style="padding:0px;">
                    <asp:TextBox ID="tbStartDate" runat="server" CssClass="Wdate" onchange="getcycled();" onfocus="new WdatePicker();" Width="120"></asp:TextBox>
                </td>
                <td style="padding-left:5px;padding-right:5px;">��</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbEndDate" runat="server" CssClass="Wdate" onchange="getcycled();" onfocus="new WdatePicker();" Width="120"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnCalc" runat="server" Text="������" OnClick="btnCalc_Click"/>
                </td>
            </tr>
       </table>
       <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
       <table cellpadding="0" cellspacing="0" class="tb5">   
            <tr>
                <td class="sysred" align="right" width="59">�����</td>
                <td style="padding:0px;">
                    <asp:TextBox ID="tbARent" runat="server" CssClass="pin" Width="100"  onblur="getamount();"></asp:TextBox>
                </td>
                <td style="padding-left:5px;padding-right:5px;">=</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbCycled" runat="server" CssClass="pinb" Width="122" ReadOnly="true"></asp:TextBox>
                </td>
                <td style="padding-left:3px;padding-right:5px;">��</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbRent" runat="server" CssClass="pinb" Width="122" ReadOnly="true"></asp:TextBox>
                </td>
                <td style="padding-left:5px;" class="layd">
                     (���ڡ���������)
                </td>
            </tr>
        </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btncycle" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btncycled" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
      </fieldset>
      
      <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
      <div class="divh"></div>
        <div class="fdivs" style="width:684px; height:255px;">
        <div class="sdivs" style="width:682px; height:253px; overflow:auto; background:#ffffff;">
            <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvdata_RowDataBound" ShowFooter="true">
                <Columns>
                <asp:BoundField HeaderText="��" DataField="ID" />
                <asp:BoundField HeaderText="�������к�" DataField="ProductSN" />
                <asp:BoundField HeaderText="����������" DataField="QtyTypeName" />
                <asp:BoundField HeaderText="�Ʒѷ�ʽ" DataField="ChargeStyle" />
                <asp:BoundField HeaderText="����" DataField="BQty" />
                <asp:BoundField HeaderText="����" DataField="SQty" />
                <asp:BoundField HeaderText="�������" DataField="Loss" />
                <asp:BoundField HeaderText="����" DataField="Zhang" HeaderStyle-ForeColor="#ff0000" />
                <asp:BoundField HeaderText="���" DataField="Rated" />
                <asp:BoundField HeaderText="���ŷ�" DataField="ZhangFee" />
                <asp:BoundField HeaderText="�ܳ��ŷ�" DataField="SuperZhangFee" HeaderStyle-ForeColor="#ff0000" />
                </Columns>
            </asp:GridView>
            <asp:HiddenField ID="hfChargeCycle" runat="server" />
            <span style="display:none;">
                <asp:Button ID="btncycle" runat="server" Text="..." OnClick="btncycle_Click" />
                <asp:Button ID="btncycled" runat="server" Text="..." OnClick="btncycled_Click" />
            </span>
        </div>
        </div>
      
      <fieldset style=" border: 1px #808080 solid; padding:5px 0; width:680px;">
      <legend>�ϼ�Ӧ��</legend>
        <table cellpadding="0" cellspacing="0" class="tb5">
            <tr>
                <td>�ϼ�Ӧ�գ�</td>
                <td style="padding:0px;">
                    <asp:TextBox ID="tbRec" runat="server" CssClass="pin" Width="100"></asp:TextBox>
                </td>
                <td style="padding-left:5px;padding-right:5px;">=</td>
                <td style="padding:0px;">
                    <asp:TextBox ID="tbAARent" runat="server" CssClass="pinb" Width="122" ReadOnly="true"></asp:TextBox>
                </td>
                <td style="padding-left:3px;padding-right:3px;">+</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbAASuperZhangFee" runat="server" CssClass="pinb" Width="122" ReadOnly="true"></asp:TextBox>
                </td>
                <td style="padding-left:5px;" class="layd">
                    (�����+�ܳ��ŷѺϼ�)
                </td>
            </tr>
            </table>
            <table cellpadding="0" cellspacing="0" class="tb5">
            <tr>
                <td align="right">���㱸ע��</td>
                <td colspan="6" style="padding-left:0px;">
                    <asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="386"></asp:TextBox>
                </td>
            </tr>
        </table>
      </fieldset>
      </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
      <div class="divh"></div>
        <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="right">
                <asp:Button ID="btnAdd" runat="server" Text="ȷ��" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/detailslt.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/detail.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">

function ChkAdd()
{
    if(isNull($("tbCycle").value))
    {
        window.alert("����ʧ�ܣ����ڲ���Ϊ��");
        $("tbCycle").focus();
        return false
    }
    if(!isMoney($("tbCycle").value))
    {
        window.alert("���ڸ�ʽ����ȷ");
        $("tbCycle").focus();
        return false
    }
    
    if(isNull($("tbARent").value))
    {
        window.alert("����ʧ�ܣ��������Ϊ��");
        $("tbARent").focus();
        return false
    }
    if(!isMoney($("tbARent").value))
    {
        window.alert("������ʽ����ȷ");
        $("tbARent").focus();
        return false
    }
    
    if(isNull($("tbRec").value))
    {
        window.alert("����ʧ�ܣ��ϼ�Ӧ�ղ���Ϊ��");
        $("tbRec").focus();
        return false
    }
    if(!isMoney($("tbRec").value))
    {
        window.alert("�ϼ�Ӧ�ո�ʽ����ȷ");
        $("tbRec").focus();
        return false
    }
}

function getcycled()
{
    $("btncycled").click();
}

function getamount()
{
    if(isNull($("tbARent").value))
    {
        window.alert("����ʧ�ܣ��������Ϊ��");
        $("tbARent").focus();
        return false
    }
    if(!isMoney($("tbARent").value))
    {
        window.alert("������ʽ����ȷ");
        $("tbARent").focus();
        return false
    }
    $("tbAARent").value=$("tbARent").value;
    var a=parseFloat($("tbARent").value)+parseFloat($("tbAASuperZhangFee").value);
    $("tbRec").value=cc(a.toString());
}
</script>
