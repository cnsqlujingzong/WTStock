<%@ page language="C#"  CodeFile="manualhedge.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Financial_ManualHedge" theme="Themes" enableEventValidation="false" %>
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
    <div id="sad" style="width:846px;">
        <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td align="right">
            �Գ��
            </td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbAmount" runat="server" CssClass="pin"></asp:TextBox></td>
            <td>�Գ��ʻ���</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlAccount" runat="server" CssClass="pindl">
                </asp:DropDownList>
            </td>
            <td style="color:#666; padding-left:5px;">*�ʿ�Գ���Զ������տ�͸�� *�Գ��ʻ���Ϊ�տ��ʻ��͸����ʻ�</td>
        </tr>
        </table>
        
        <div class="divh"></div>
        <div class="fdivs" style="height:200px; width:846px">
            <div class="sdivs" style="height:198px; width:844px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvdata_RowDataBound" OnRowDeleting="gvdata_RowDeleting">
                            <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="��" />
                            <asp:BoundField HeaderText="�������" DataField="Type" />
                            <asp:BoundField HeaderText="���ݱ��" DataField="BillID" />
                            <asp:BoundField HeaderText="����" DataField="_Date" />
                            <asp:BoundField HeaderText="������" DataField="Operator" />
                            <asp:BoundField HeaderText="�ܽ��" DataField="Amount" />
                            <asp:BoundField HeaderText="�ѽ�����" DataField="HaveAmount" />
                            <asp:BoundField HeaderText="δ������" DataField="NotChargeAmount" />
                            <asp:TemplateField HeaderText="���ν���" HeaderStyle-ForeColor="#ff0000">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbChargeMoney" runat="server" Text='<%# Eval("ChargeAmount") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="��ע">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbRemark" runat="server" BorderWidth="0" Text='<%# Eval("Remark") %>' ReadOnly="true" Width="200" onfocus="select();"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ɾ��">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbDel" TabIndex="-1" runat="server" CausesValidation="False"  CommandName="Delete" Text="ɾ��" style="color:#0000ff;"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
                        <asp:HiddenField ID="hfreclist" runat="server" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnAuto" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnSltID" EventName="Click" />
                    </Triggers>
                 </asp:UpdatePanel>
            </div>
        </div>
        <div class="divh"></div>
        
        <div class="tdiv">
        <table cellpadding="0" cellspacing="0" class="tb3">
            <tr>
                <td style="padding-left:15px; height:29px;">
                 <input id="Button1" type="button" value="ѡ�񵥾�" class="bt1" onclick="SltBill('1');" />
                </td>
            </tr>
        </table>
        </div>
        
        <div class="divh"></div>
        <div class="fdivs" style="height:200px; width:846px">
            <div class="sdivs" style="height:198px; width:844px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="gvdata2" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvdata2_RowDataBound" OnRowDeleting="gvdata2_RowDeleting">
                            <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="��" />
                            <asp:BoundField HeaderText="�������" DataField="Type" />
                            <asp:BoundField HeaderText="���ݱ��" DataField="BillID" />
                            <asp:BoundField HeaderText="����" DataField="_Date" />
                            <asp:BoundField HeaderText="������" DataField="Operator" />
                            <asp:BoundField HeaderText="�ܽ��" DataField="Amount" />
                            <asp:BoundField HeaderText="�ѽ�����" DataField="HaveAmount" />
                            <asp:BoundField HeaderText="δ������" DataField="NotChargeAmount" />
                            <asp:TemplateField HeaderText="���ν���" HeaderStyle-ForeColor="#ff0000">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbChargeMoney" runat="server" Text='<%# Eval("ChargeAmount") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="��ע">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbRemark" runat="server" BorderWidth="0" Text='<%# Eval("Remark") %>' ReadOnly="true" Width="200" onfocus="select();"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ɾ��">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbDel" TabIndex="-1" runat="server" CausesValidation="False"  CommandName="Delete" Text="ɾ��" style="color:#0000ff;"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:HiddenField ID="hfRecID2" runat="server" Value="-1" />
                        <asp:HiddenField ID="hfreclist2" runat="server" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSltID" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnAuto" EventName="Click" />
                    </Triggers>
                 </asp:UpdatePanel>
            </div>
        </div>
        <div class="divh"></div>
        <div class="tdiv">
        <table cellpadding="0" cellspacing="0" class="tb3">
            <tr>
                <td style="padding-left:15px; height:29px;">
                 <input id="tbSltGoods" type="button" value="ѡ�񵥾�" class="bt1" onclick="SltBill('2');" />
                </td>
            </tr>
        </table>
        </div>
        
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td><asp:Label ID="lbMod" runat="server"></asp:Label>
                    <asp:HiddenField ID="hfCusID" runat="server" />
                    <asp:HiddenField ID="hfCusType" runat="server" />
                    <asp:HiddenField ID="hfType" runat="server" />
                     <span style="display:none;">
                     <asp:Button ID="btnSltID" runat="server" Text="..." UseSubmitBehavior="false" OnClick="btnSltID_Click" />
                     </span>
                </td>
                <td align="right">
                    <asp:Button ID="btnAuto" runat="server" Text="�Զ�����" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnAuto_Click"/>
                    <asp:Button ID="btnSave" runat="server" Text="ȷ��" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnSave_Click"/>
                    <input id="btnCls" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog('1');"/>
                </td>
            </tr>
            </table>
    </div>
    
    </div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/detail.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
function ChkSave()
{
    if(!isMoney($("tbAmount").value))
    {
        window.alert("����ʧ�ܣ��Գ����ʽ����ȷ");
        $("tbAmount").focus();
        return false
    }else
    {
        if(parseFloat($("tbAmount").value)>0)
        {}
        else
        {
            window.alert("����ʧ�ܣ��Գ�����������");
            $("tbAmount").focus();
            return false
        }
    }
    
    if($("ddlAccount").value=="-1")
    {
        window.alert("����ʧ�ܣ��Գ��ʻ�����Ϊ��");
        $("ddlAccount").focus();
        return false
    }
}

function SltBill(iflag)
{
    var cusid=$("hfCusID").value;
    $("hfType").value=iflag;
    parent.ShowDialog1(800, 520, 'Financial/SltBill.aspx?iFlag='+iflag+'&custype='+$("hfCusType").value+'&cusid='+cusid, 'ѡ�񵥾�');
}
</script>
