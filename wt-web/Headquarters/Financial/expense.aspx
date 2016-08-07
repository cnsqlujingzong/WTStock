<%@ page language="C#"  CodeFile="expense.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Financial_Expense" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body onload="Chkset();" onclick="parent.Sethidden1();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="divh2"></div>
    <div class="tldiv">
        ��������
    </div>
    <div id="ctdiv">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td align="right">�������ڣ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                <td align="right">�����ˣ�</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">ժҪ��</td>
                <td colspan="3" style="padding-left:0px;">
                    <asp:TextBox ID="tbSummary" runat="server" CssClass="pin" Width="341"></asp:TextBox>
                </td>
                <td align="right">����ҵ��</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbRelatedServices" runat="server" CssClass="pin"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">�����ص㣺</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbFromAdr" runat="server" CssClass="pin"></asp:TextBox></td>
                <td align="right">Ŀ�ĵص㣺</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbToAdr" runat="server" CssClass="pin"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">��ע��</td>
                <td style="padding-left:0px;" colspan="3">
                    <asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="341"></asp:TextBox>
                </td>
                <td align="right">���븽����</td>
                <td style="padding-left:0px;">
                   <a href="#" style="color:#0000ff" title="�ϴ����븽��" onclick="ChkUpload();">�ϴ����븽��</a>
                </td>
                <td style="padding-left:0px;" >
                <div id="dUpload"></div>
                <asp:HiddenField ID="hfPath" runat="server" />
                </td>
            </tr>
         </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    <div class="divh"></div>
    </div>
    
    <div id="cndiv" style="height:1px;">
        <div id="fdiv" class="fdiv">
            <div id="sdiv" class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvdata_RowDataBound" OnRowDeleting="gvdata_RowDeleting">
                        <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ItemID" />
                        <asp:BoundField HeaderText="��" />
                        <asp:BoundField HeaderText="��Ŀ����" DataField="_Name" />
                        <asp:TemplateField HeaderText="���">
                            <ItemTemplate>
                                <asp:TextBox ID="tbAmount" runat="server" CssClass="tbstyle" Text='<%# Eval("Total") %>' onfocus="select();" Width="100"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="��ע">
                            <ItemTemplate>
                                <asp:TextBox ID="tbRemark" runat="server" CssClass="tbstyle" Text='<%# Eval("Remark") %>' Width="200" onfocus="select();"></asp:TextBox>
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
                    <asp:HiddenField ID="hfRecIDs" runat="server" Value="-1" />
                     <span style="display:none;">
                     <asp:Button ID="btnId" runat="server" Text="..." OnClick="btnId_Click" />
                     <asp:Button ID="btnSure" runat="server" Text="..." OnClick="btnSure_Click" />
                     </span>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
                </Triggers>
             </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div class="divh"></div>
    <div class="tdiv">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <table cellpadding="0" cellspacing="0" class="tb3">
        <tr>
            <td style="padding-left:15px;">
                <asp:DropDownList ID="ddlSchFld" runat="server" CssClass="pindl" Width="70">
                    <asp:ListItem Value="_Name">����Ŀ����</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td><asp:TextBox ID="tbCon" runat="server" CssClass="pin" onkeydown="EnterTextBox(event, this);" ToolTip="������ɺ�س����"></asp:TextBox></td>
            <td><input id="tbSltGoods" type="button" value="ѡ����Ŀ" class="bt1" onclick="SltItem();" /></td>
            <td>�ϼƽ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbAmount" runat="server" CssClass="pinbr" ReadOnly="true" Width="100"></asp:TextBox></td>
        </tr>
    </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnId" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSure" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div class="ftool">
    <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
        <tr>
            <td><span class="si1">���ֹ�������Ŀ���ƣ�������ɺ�س�</span></td>
            <td align="right" style="padding-right:20px;">
                <asp:Button ID="btnChk" runat="server" Text="���" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnChk_Click"  />
                <asp:Button ID="btnAdd" runat="server" Text="ȷ��" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnAdd_Click" />
                <asp:Button ID="btnClean" runat="server" Text="���" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkClean()==false)return false;" OnClick="btnClean_Click"/>
                <input id="btnCls" type="button" value="�ر�" class="bt1" onclick="parent.CloseWin();" />
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
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/detail.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;

function ChkSave()
{
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

function ValidateMoneyee(obj)
{
    if(isNull(obj.value))
    {
        obj.value=obj.obj.getAttribute("oldNum");
    }
    
    if(isMoney(obj.value))
    {
        var b=parseFloat($("tbAmount").value)+parseFloat(obj.value)-obj.getAttribute("oldNum");
        $("tbAmount").value=cc(b.toString());
        
        obj.setAttribute("oldNum",obj.value);
   }
    else
    {
        window.alert("��ʽ����ȷ�������ǽ��");
        obj.value=obj.getAttribute("oldNum");
        obj.select();
        return false;
    }
}

function ChkAmountee(obj,tt)
{
    var b=parseFloat($("tbAmount").value)-parseFloat($(tt).value);
    $("tbAmount").value=cc(b.toString());
}

function cc(s)
{
    if(/[^0-9\.]/.test(s)) return "invalid value";
    s=s.replace(/^(\d*)$/,"$1.");
    s=(s+"00").replace(/(\d*\.\d\d)\d*/,"$1");
    s=s.replace(/,(\d\d)$/,".$1");
    return s.replace(/^\./,"0.");
}
function SltItem()
{
    parent.ShowDialog(500, 520, 'Basic/SltExpenseItem.aspx', 'ѡ����Ŀ');
}
function Chkset()
{
    Chkwh10(264);
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("��������");
}
function ChkUpload()
{   
    if($("dUpload").innerHTML=="")
    {
        parent.ShowDialog(600, 380, 'Lease/UpLoad.aspx', '�ϴ����븽��');
    }
    else
    {
        if(confirm("�Ѿ�����һ�����븽���������ϴ����滻�ø������Ƿ������"))
        {
            parent.ShowDialog(600, 380, 'Lease/UpLoad.aspx', '�ϴ����븽��');   
        }
    }
}
</script>
