<%@ page language="C#"  CodeFile="leaseadd.aspx.cs"     autoeventwireup="true" inherits="Web_LeaseAdd" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../Public/Style/winsub.css" />
</head>
<body onload="Chkset();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="divh2"></div>
    <div class="tldiv">
        �½�ҵ��
    </div>
    <div id="ctdiv">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td>ҵ�񵥺ţ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbBillID" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox></td>
            <td align="right">���ڣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
            <td colspan="2" align="right" style="display:none;">ҵ��Ա��</td>
            <td style="padding-left:0px;display:none;">
                <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl">
                </asp:DropDownList>
            </td>
            <td class="sysred" align="right">ҵ�����</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlType" runat="server" CssClass="pindl">
                    <asp:ListItem Value="1">����</asp:ListItem>
                    <asp:ListItem Value="2">ȫ��</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="sysred" align="right">�ͻ����ƣ�</td>
            <td colspan="3" style="padding-left:0px;">
                <div class="isinDiv">
                <asp:TextBox ID="tbCusName" runat="server" CssClass="pin autot" Width="341"></asp:TextBox>
                </div>
            </td>
            <td align="right">
            ��ϵ�ˣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin"></asp:TextBox></td>
            <td class="sysred" align="right">
            ��ϵ�绰��</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right">��ַ��</td>
            <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin" Width="341"></asp:TextBox></td>
           
        </tr>
        <tr>
            <td align="right">��ͬ��ţ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbAutoNO" runat="server" CssClass="pin"></asp:TextBox></td>
            <td align="right">��ʼ���ڣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbStartDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
            <td align="right">��ֹ���ڣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbEndDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
            <td align="right">�������ڣ�</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbChargeCycle" runat="server" CssClass="pin"></asp:TextBox>
                <span class="red">��</span>
            </td>
            
        </tr>
        <tr>
            <td align="right">�������⣺</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbRent" runat="server" CssClass="pin"></asp:TextBox></td>
            <td align="right">Ѻ��</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbDeposit" runat="server" CssClass="pin"></asp:TextBox>
            </td>
            <td align="right">��ע��</td>
            <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="341"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="padding-left:0px;display:none;" colspan="6">
                <div id="dUpload"></div>
                <asp:HiddenField ID="hfPath" runat="server" />
                <asp:HiddenField ID="hfCusID" runat="server" />
                <asp:HiddenField ID="hfPrintID" runat="server" />
                <span style="display:none;">
                    <asp:Button ID="btnCusInfo" runat="server" Text="..."  OnClick="btnCusInfo_Click"/>
                    <asp:DropDownList ID="ddlStock" runat="server">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlBrand" runat="server">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlClass" runat="server">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlModel" runat="server">
                    </asp:DropDownList>
                </span>
            </td>
        </tr>
     </table>
     </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSltBill" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    <div class="divh"></div>
    </div>
    <div id="cndiv" style="height:1px;">
        <div id="fdiv" class="fdiv">
            <div id="sdiv" class="sdiv" style="overflow:auto;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvdata_RowDataBound" OnRowDeleting="gvdata_RowDeleting">
                        <Columns>
                        <asp:BoundField HeaderText="��" />
                        <asp:BoundField HeaderText="���޻���" DataField="GoodsNO" />
                        <asp:TemplateField HeaderText="��ע">
                            <ItemTemplate>
                                <asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Text='<%# Eval("Remark") %>' Width="160"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ɾ��">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbDel" TabIndex="-1" runat="server" CausesValidation="False"  CommandName="Delete" Text="ɾ��" style="color:#0000ff;"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:HiddenField ID="hfreclist" runat="server" />
                    <asp:HiddenField ID="hfSltID" runat="server" />
                     <span style="display:none;">
                         <asp:Button ID="btnId" runat="server" Text="..." OnClick="btnId_Click" />
                         <asp:Button ID="btnSure" runat="server" Text="..." OnClick="btnSure_Click" />
                         <asp:Button ID="btnsngetgds" runat="server" Text="..." OnClick="btnsngetgds_Click" />
                         <asp:Button ID="btnSltBill" runat="server" Text="..." OnClick="btnSltBill_Click" />
                         <asp:Button ID="btnAddGoods" runat="server" Text="..." OnClick="btnAddGoods_Click" />
                     </span>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnSltBill" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
                </Triggers>
             </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div class="divh"></div>
    <div class="tdiv">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <table cellpadding="0" cellspacing="0" class="tb4">
        <tr>
            <td style="padding-left:15px;display:none;">
                <asp:DropDownList ID="ddlSchFld" runat="server" CssClass="pindl" Width="70">
                    <asp:ListItem Value="SN">�����к�</asp:ListItem>
                    <asp:ListItem Value="BarCode">������</asp:ListItem>
                    <asp:ListItem Value="GoodsNO">�����</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="display:none;"><asp:TextBox ID="tbCon" runat="server" CssClass="pin" onkeydown="EnterTextBox(event, this);" ToolTip="������ɺ�س����"></asp:TextBox></td>
            <td><input id="tbSltGoods" type="button" value="ѡ���Ʒ" class="bt1" onclick="openWin('SltGoods.aspx',800, 415);" /></td>
            <td style="display:none;"><input id="btnSltSN" type="button" value="ѡ��SN" class="bt1" onclick="parent.ShowDialog(800, 520, 'Stock/SltSN.aspx', 'ѡ�����к�');" /></td>
            <td style="display:none;"><input id="btnLease" type="button" value="��ʷҵ��" class="bt1" onclick="parent.ShowDialog(800, 520, 'Lease/SltLease.aspx', 'ѡ����ʷҵ��');" /></td>
        </tr>
    </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    
    <asp:HiddenField ID="hfClass" runat="server" Value="-1" />
    <asp:HiddenField ID="hfBrand" runat="server" Value="-1" />
    <asp:HiddenField ID="hfModel" runat="server" Value="-1" />
    <asp:HiddenField ID="hfGoodsNO" runat="server" Value="-1" />
    
    <div class="ftool">
    <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
        <tr>
            <td style="display:none;"><span class="si1">���ֹ������Ż����룬������ɺ�س�</span></td>
            <td align="right" style="padding-right:20px;">
                <asp:Button ID="btnChk" runat="server" style="display:none;" Text="���" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;"  OnClick="btnChk_Click"/>
                <asp:Button ID="btnAdd" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;"  OnClick="btnAdd_Click"/>
                <asp:Button ID="btnClean" runat="server" Text="���" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkClean()==false)return false;" OnClick="btnClean_Click"/>
                <input id="btnPrint" runat="server" type="button" style="display:none;" value="��ӡ" class="bt1" onclick="ChkPrint('ZLD');" />
                <input id="btnCls" type="button" value="�ر�" class="bt1" style="display:none;" onclick="parent.CloseWin();" />
            </td>
        </tr>
    </table>
    </div>
    <div class="fbom">
        <div id="fbon" class="fbon"></div> 
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../Public/Script/detail.js"></script>
<script language="javascript" type="text/javascript" src="../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../Public/Script/AutoSchCon.js"></script>
<script language="javascript" type="text/javascript" src="../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="../Public/Script/AutoSchCon1.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;

function ChkID(id)
{
    ClrID(id);
}

function ChkSave()
{
    if(isNull($("tbDate").value))
    {
        window.alert("����ʧ�ܣ����ڲ���Ϊ��");
        $("tbDate").focus();
        return false
    }

    if(isNull($("tbTel").value))
    {
        window.alert("����ʧ�ܣ���ϵ�绰����Ϊ��");
        $("tbTel").focus();
        return false
    }
    if(isNull($("tbStartDate").value))
    {
        window.alert("����ʧ�ܣ���ʼ���ڲ���Ϊ��");
        $("tbStartDate").focus();
        return false
    }
    
    if(isNull($("tbEndDate").value))
    {
        window.alert("����ʧ�ܣ���ֹ���ڲ���Ϊ��");
        $("tbEndDate").focus();
        return false
    }
    if(isNull($("tbRent").value))
    {
        window.alert("����ʧ�ܣ��������ⲻ��Ϊ��");
        $("tbRent").focus();
        return false
    }
    if(isNull($("tbDeposit").value))
    {
        window.alert("����ʧ�ܣ�Ѻ����Ϊ��");
        $("tbDeposit").focus();
        return false
    }
    if(!isMoney($("tbRent").value))
    {
        window.alert("���������ʽ����ȷ");
        $("tbRent").focus();
        return false
    }
    if(!isMoney($("tbDeposit").value))
    {
        window.alert("Ѻ���ʽ����ȷ");
        $("tbDeposit").focus();
        return false
    }
}
function EnterTextBox(event, obj)
{
    if(event.keyCode == 13&&!isNull(obj.value))
    {
        if(!isNull(obj.value))
        {
            $("btnSure").click();
        }
    }
}
function ChkUpload()
{   
    if($("dUpload").innerHTML=="")
    {
        parent.ShowDialog(600, 380, 'Lease/UpLoad.aspx', '�ϴ���ͬ����');
    }
    else
    {
        if(confirm("�Ѿ�����һ�������������ϴ����滻�ø������Ƿ������"))
        {
            parent.ShowDialog(600, 380, 'Lease/UpLoad.aspx', '�ϴ���ͬ����');
        }
    }
}

function SltCus()
{
    parent.ShowDialog1(800, 500, 'Lease/SltCus.aspx?f=2&fid='+parent.$("hfActiveWin").value+'&strname='+escape($("tbCusName").value), 'ѡ��ͻ�');
}

function ConfCusInfo()
{
    if(confirm("�ÿͻ����ƴ��ڶ����ͻ���Ϣ���Ƿ�ѡ��"))
    {
        SltCus();
    }
}
function ViewCus()
{
    var cusid=$("hfCusID").value;
    if(cusid=="")
    {
        //�½��ͻ�
        parent.ShowDialog1(600, 450, '../Headquarters/Customer/CusAdd.aspx?f=1', '�½��ͻ�');
    }
    else
    {
        //�޸Ŀͻ�
        parent.ShowDialog1(600, 450, '../Headquarters/Customer/CusMod.aspx?f=1&id=' + cusid, '�ͻ���Ϣ');
    }
}

function ViewHistory()
{
    var cusid=$("hfCusID").value;
    if(cusid=="")
    {
        alert("��ѡ��ͻ���鿴��");
        return false;
    }
    parent.ShowDialog1(800, 520, '../Headquarters/Customer/CusHistory.aspx?f=1&cusid='+cusid, '���ҵ��');
}

function EditQty(tbqty)
{
    parent.ShowDialog(600, 380, 'Lease/EditQty.aspx?tbqty='+tbqty+'&qtyvalue='+escape($(tbqty).value), '�༭������');
}

function Chkset()
{
    Chkwh11();
    Chkbom(); 
}
function Chkbom()
{
    
}
function openWin(u,w,h) {
    var l = (screen.width - w) / 2;
    var t = (screen.height - h) / 2;
    var s = 'width=' + w + ', height=' + h + ', top=' + t + ', left=' + l;
    s += ', toolbar=no, scrollbars=no, menubar=no, location=no, resizable=no';
    open(u, 'oWin', s);
}
</script>
