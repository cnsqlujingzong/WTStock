<%@ page language="C#"  CodeFile="cusbln.aspx.cs"     autoeventwireup="true" inherits="Branch_Services_CusBln" theme="Themes" enableEventValidation="false" %>
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
    <div id="sad" style="width:866px;">
    <fieldset style=" border: 1px #808080 solid; padding:5px 0; width:862px;">
      <legend>�������</legend>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" class="tb5">
                <tr>
                    <td align="right">�ͻ����ƣ�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbCusName" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox></td>
                    <td align="right">
                    Ӧ�ս�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbAmount" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox></td>
                    <td align="right" class="red">
                    �Żݽ�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbPreMoney" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox></td>
                    <td align="right" class="red">
                    ʵ�ս�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbRealMoney" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right" class="red">
                    �ֽ��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbChargeMoney" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td>���㷽ʽ��</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlChargeStyle" runat="server" CssClass="pindl">
                        </asp:DropDownList>
                    </td>
                    <td>�����ʻ���</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlChargeAccount" runat="server" CssClass="pindl">
                            </asp:DropDownList>
                        </td>
                    <td>�������ڣ�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" class="red">�տ��ˣ�</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl">
                        </asp:DropDownList> 
                    </td>
                <td>��Ʊ���ڣ�</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbInvoiceDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
                </td>
                <td align="right">��Ʊ��</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbInvoiceAmount" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td>��Ʊ���룺</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbInvoiceNO" runat="server" CssClass="pin"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>��Ʊ���</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlInvoiceClass" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                <td align="right">ƾ֤���룺</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbVoucherNO" runat="server" CssClass="pin" ></asp:TextBox>
                </td>
                <td align="right">��ע��</td>
                <td style="padding-left:0px;" colspan="3"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="341"></asp:TextBox></td>
            </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
    </fieldset>
    <div class="divh"></div>
    <div class="fdivs">
    <div class="sdivs" style="width:862px; height:255px; overflow:auto; background:#ffffff;">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
            <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvdata_RowDataBound">
                <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="��" />
                <asp:BoundField HeaderText="���񵥺�" DataField="BillID" />
                <asp:TemplateField HeaderText="Ӧ�ս��">
                    <ItemTemplate>
                        <asp:Label ID="lbAmount" runat="server" Text='<%# Eval("Amount") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="�Żݽ��" HeaderStyle-ForeColor="#ff0000">
                    <ItemTemplate>
                        <asp:TextBox ID="tbPreMoney" runat="server" Text='<%# Eval("PreMoney") %>' CssClass="tbstyle" oldNum='<%# Eval("PreMoney") %>' onfocus="select();"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="�ֽ���" HeaderStyle-ForeColor="#ff0000">
                    <ItemTemplate>
                        <asp:TextBox ID="tbChargeValue" runat="server" Text='<%# Eval("ChargeValue") %>' CssClass="tbstyle" oldNum='<%# Eval("ChargeValue") %>' onfocus="select();"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="���Ϸ�" DataField="Fee_Materail" />
                <asp:BoundField HeaderText="ά�޷�" DataField="Fee_Labor" />
                <asp:TemplateField HeaderText="���ӷ�" HeaderStyle-ForeColor="#ff0000">
                    <ItemTemplate>
                        <asp:TextBox ID="tbFeeAdd" runat="server" Text='<%# Eval("Fee_Add") %>' CssClass="tbstyle" oldNum='<%# Eval("Fee_Add") %>' onfocus="select();"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="����ɱ�" HeaderStyle-ForeColor="#ff0000">
                    <ItemTemplate>
                        <asp:TextBox ID="tbCostAdd" runat="server" Text='<%# Eval("ExtraCost") %>' CssClass="tbstyle" oldNum='<%# Eval("ExtraCost") %>' onfocus="select();"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="����" HeaderStyle-ForeColor="#ff0000">
                    <ItemTemplate>
                        <asp:TextBox ID="tbPoint" runat="server" Text='<%# Eval("dPoint") %>' CssClass="tbstyle" oldNum='<%# Eval("dPoint") %>' onfocus="select();"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ά�ޱ��޽�ֹ" HeaderStyle-ForeColor="#ff0000">
                    <ItemTemplate>
                        <asp:TextBox ID="tbWarrantyEndDate" runat="server" Text='<%# Eval("WarrantyEndDate") %>' CssClass="tbstyle" onfocus="WdatePicker()" Width="100"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="���޷�Χ" HeaderStyle-ForeColor="#ff0000">
                    <ItemTemplate>
                        <asp:TextBox ID="tbWarrantyBound" runat="server" CssClass="tbstyle" onfocus="select();" Width="120"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="��ע">
                    <ItemTemplate>
                        <asp:TextBox ID="tbRemark" runat="server" CssClass="tbstyle" Text='<%# Eval("Remark") %>' Width="200"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
    </div>
    </div>
    <fieldset style=" border: 1px #808080 solid; padding:5px 0; width:862px;">
      <legend>ȡ������</legend>
            <table cellpadding="0" cellspacing="0" class="tb5">
            <tr>
                <td>��Ʒȥ��</td>
                <td style="padding-left:0px;width:136px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbGoneType" runat="server" CssClass="pin pinin"></asp:TextBox>
                        <asp:DropDownList ID="ddlGoneType" runat="server" CssClass="pininsl" onchange="document.getElementById('tbGoneType').value=this.options[this.selectedIndex].text;">
                        </asp:DropDownList>
                    </div>
                </td>
                <td>�������ڣ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbGoneDate" runat="server" CssClass="Wdate" onfocus="new WdatePicker();"></asp:TextBox>
                </td>
            </tr>
        </table>
    </fieldset>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/detail.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
var processtip=1;
function ChkAdd()
{
    if(!isMoney($("tbChargeMoney").value))
    {
        window.alert("����ʧ�ܣ��ֽ����ʽ����ȷ");
        $("tbChargeMoney").focus();
        return false
    }
    if(parseFloat($("tbChargeMoney").value)>0)
    {
        if(parseFloat($("tbChargeMoney").value)>parseFloat($("tbRealMoney").value))
        {
            window.alert("����ʧ�ܣ��ֽ���ܴ���ʵ�ս��");
            $("tbChargeMoney").focus();
            return false
        }
        
        if($("ddlChargeAccount").value=="-1")
        {
            window.alert("����ʧ�ܣ������ʻ�����Ϊ��");
            $("ddlChargeAccount").focus();
            return false
        }
    }
    if(isNull($("tbDate").value))
    {
        window.alert("����ʧ�ܣ��������ڲ���Ϊ��");
        $("tbDate").focus();
        return false
    }
    if($("ddlOperator").value=="-1")
    {
        window.alert("����ʧ�ܣ��տ��˲���Ϊ��");
        $("ddlOperator").focus();
        return false
    }
    if(isNull($("tbGoneDate").value))
    {
        window.alert("����ʧ�ܣ��������ڲ���Ϊ��");
        $("tbGoneDate").focus();
        return false
    }
}
</script>
