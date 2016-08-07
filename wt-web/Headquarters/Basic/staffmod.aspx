<%@ page language="C#"  CodeFile="staffmod.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Basic_StaffMod" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/tab.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="main">
        <div class="maincon">
        <div id="sad" style="width:586px;">
         <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td class="blue">Ա��������</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbName" runat="server" CssClass="pin" Width="220"></asp:TextBox></td>
                <td class="blue">Ա����ţ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbJobNO" runat="server" CssClass="pin" Enabled="false"></asp:TextBox></td>
                <td class="sysred" style="padding-left:5px;">
                    <asp:CheckBox ID="cbsys" runat="server" Text="ϵͳĬ��" Checked="true" onclick="ChkSysNO();" /></td>
            </tr>
         </table>
        <div class="divh"></div>
        <div id="mytabs">
            <span id="tabs_l1"></span>
            <span id="tabs1" onclick="ChkTab('1');">������Ϣ</span>
            <span id="tabs_r1"></span>
            <span id="tabs_l2"></span>
            <span id="tabs2" onclick="ChkTab('2');">ά�����</span>
            <span id="tabs_r2"></span>
            <span id="tabs_l3"></span>
            <span id="tabs3" onclick="ChkTab('3');">�������</span>
            <span id="tabs_r3"></span>
            <span id="tabs_l4"></span>
            <span id="tabs4" onclick="ChkTab('4');">ҵ�����</span>
            <span id="tabs_r4"></span>
        </div>
        <div id="info1" style="padding:3px 0px 0px 3px; overflow:hidden;">
        <div id="divinfo1" class="divinfo" style="height:311px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                        <td align="right">�Ա�</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlSex" runat="server" CssClass="pindl">
                                <asp:ListItem Value=""></asp:ListItem>
                                <asp:ListItem Value="��">��</asp:ListItem>
                                <asp:ListItem Value="Ů">Ů</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right">״̬��</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="pindl">
                                <asp:ListItem Value="0">��ְ</asp:ListItem>
                                <asp:ListItem Value="1">��ְ</asp:ListItem>
                                <asp:ListItem Value="2">�ݼ�</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">�绰��</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td align="right">��λ��</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlQus" runat="server" CssClass="pindl" onchange="NewQuarters();">
                                <asp:ListItem Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">�������£�</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbBirthDay" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
                        </td>
                        <td align="right">���᣺</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbNativePlace" runat="server" CssClass="pin"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">���֤�ţ�</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbCardNO" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td align="right">ѧ����</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlStudy" runat="server" CssClass="pindl">
                                <asp:ListItem Value=""></asp:ListItem>
                                <asp:ListItem Value="��ʿ">��ʿ</asp:ListItem>
                                <asp:ListItem Value="˶ʿ">˶ʿ</asp:ListItem>
                                <asp:ListItem Value="����">����</asp:ListItem>
                                <asp:ListItem Value="��ר">��ר</asp:ListItem>
                                <asp:ListItem Value="����">����</asp:ListItem>
                                <asp:ListItem Value="����">����</asp:ListItem>
                                <asp:ListItem Value="Сѧ">Сѧ</asp:ListItem>
                                <asp:ListItem Value="����">����</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        
                    </tr>
                    <tr>
                        <td align="right">ְλ��</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbSchool" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td align="right">΢�ţ�</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbSpeci" runat="server" CssClass="pin"></asp:TextBox></td>                        
                    </tr>
                    <tr>
                        <td align="right">��ְʱ�䣺</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbJobTime" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
                        </td>
                        <td align="right">����</td>
                        <td style="padding-left:0px;">
                        <div class="isinDiv">
                        <asp:TextBox ID="tbArea" runat="server" CssClass="pin pinin"></asp:TextBox>
                        <asp:DropDownList ID="ddlArea" runat="server" CssClass="pininsl" onchange="document.getElementById('tbArea').value=this.options[this.selectedIndex].text;NewArea('1');">
                        </asp:DropDownList>
                        </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">��н��</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbSalary" runat="server" CssClass="pin"></asp:TextBox>
                        </td>
                        <td align="right">������</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbAllowance" runat="server" CssClass="pin"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">�����ʺţ�</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbAccount" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td align="right">���ţ�</td>
                        <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlStaffDept" runat="server" CssClass="pindl">
                        </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">��ַ��</td>
                        <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin pinw"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">��ע��</td>
                        <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin pinw"></asp:TextBox></td>
                    </tr>
                    </table>
               <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                        <td style="width:30px;">
                            <asp:HiddenField ID="hfQut" runat="server" />
                            <asp:HiddenField ID="hfArea" runat="server" />
                            <asp:HiddenField ID="hfName" runat="server" />
                            <span style="display:none;">
                            <asp:Button ID="btnRefQu" runat="server" Text="Ref" OnClick="btnRefQu_Click" />
                            <asp:Button ID="btnRef" runat="server" Text="Ref" OnClick="btnRef_Click" />
                            </span>
                        </td>
                        <td>
                            
                            <asp:CheckBox ID="cbDestClerk" runat="server" /> ����Ա
                            <asp:CheckBox ID="cbAllot" runat="server" /> �ɹ���Ա
                            <asp:CheckBox ID="cbTechnician" runat="server" /> ����Ա
                            <asp:CheckBox ID="cbSeller" runat="server" /> ҵ��Ա
                            <asp:CheckBox ID="cbAccountant" runat="server" /> ������Ա
                            <asp:CheckBox ID="cbStockMan" runat="server" /> �ֿ����Ա
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnRefQu" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnRef" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>
            </div>
            </div>
           <div id="info2" style="padding:3px 0px 0px 3px; overflow:hidden;">
            <div id="div1" class="divinfo" style="height:311px;">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                <ContentTemplate>
                   <table cellpadding="0" cellspacing="0" class="tb4">
                        <tr>
                            <td>
                                <input id="i1" type="button" value="ҵ���" class="bt1" onclick="BillInstr('{ҵ���}');" />
                                <input id="i2" type="button" value="ë��" class="bt1" onclick="BillInstr('{ë��}');" />
                                <input id="i3" type="button" value="�˹���" class="bt1" onclick="BillInstr('{�˹���}');" />
                                <input id="i4" type="button" value="���Ϸ�" class="bt1" onclick="BillInstr('{���Ϸ�}');" />
                                <input id="i5" type="button" value="���ӷ�" class="bt1" onclick="BillInstr('{���ӷ�}');" />
                                <input id="i6" type="button" value="����" class="bt1" onclick="BillInstr('{����}');" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input id="i7" type="button" value="���ϳɱ�" class="bt1" onclick="BillInstr('{���ϳɱ�}');" />
                                <input id="i8" type="button" value="��Ŀ���" class="bt1" onclick="BillInstr('{��Ŀ���}');" />
                                <input id="i9" type="button" value="���ڵ�" class="bt1" onclick="BillInstr('{���ڵ�}');" />
                                <input id="i10" type="button" value="���ⵥ" class="bt1" onclick="BillInstr('{���ⵥ}');" />
                                <input id="i11" type="button" value="��ʱ(��)" class="bt1" onclick="BillInstr('{��ʱ}');" />
                                <input id="i12" type="button" value="���̽���" class="bt1" onclick="BillInstr('{���̽���}');" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input id="i13" type="button" value="Э������" class="bt1" onclick="BillInstr('{Э������}');" />
                                <input id="e1" type="button" value="+" style="width:20px;" onclick="BillInstr('+');" />
                                <input id="e2" type="button" value="-" style="width:20px;"  onclick="BillInstr('-');" />
                                <input id="e3" type="button" value="*" style="width:20px;"  onclick="BillInstr('*');" />
                                <input id="e4" type="button" value="/" style="width:20px;"  onclick="BillInstr('/');" />
                                <input id="e5" type="button" value="(" style="width:20px;" onclick="BillInstr('(');" />
                                <input id="e6" type="button" value=")" style="width:20px;" onclick="BillInstr(')');" />
                            </td>
                        </tr>
                        <tr>
                            <td><asp:TextBox ID="tbBillDe" runat="server" TextMode="MultiLine" Height="140" Width="420"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>��ʽ����
                                <asp:DropDownList ID="ddlSerFormula" runat="server" CssClass="pindl" AutoPostBack="true" OnSelectedIndexChanged="ddlSerFormula_SelectedIndexChanged">
                                </asp:DropDownList>
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
            <div id="info3" style="padding:3px 0px 0px 3px; overflow:hidden;">
            <div id="div2" class="divinfo" style="height:311px;">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                <ContentTemplate>
                    <table cellpadding="0" cellspacing="0" class="tb4">
                        <tr>
                            <td>
                                <input id="it1" type="button" value="ҵ���" class="bt1" onclick="SellInstr('{ҵ���}');" />
                                <input id="it2" type="button" value="ë��" class="bt1" onclick="SellInstr('{ë��}');" />
                                <input id="et1" type="button" value="+" style="width:20px;" onclick="SellInstr('+');" />
                                <input id="et2" type="button" value="-" style="width:20px;"  onclick="SellInstr('-');" />
                                <input id="et3" type="button" value="*" style="width:20px;"  onclick="SellInstr('*');" />
                                <input id="et4" type="button" value="/" style="width:20px;"  onclick="SellInstr('/');" />
                                <input id="et5" type="button" value="(" style="width:20px;" onclick="SellInstr('(');" />
                                <input id="et6" type="button" value=")" style="width:20px;" onclick="SellInstr(')');" />
                            </td>
                        </tr>
                        <tr>
                            <td><asp:TextBox ID="tbSellDe" runat="server" TextMode="MultiLine" Height="192" Width="420"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>��ʽ����
                                <asp:DropDownList ID="ddlSellFormula" runat="server" CssClass="pindl" AutoPostBack="true" OnSelectedIndexChanged="ddlSellFormula_SelectedIndexChanged">
                                </asp:DropDownList>
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
            <div id="info4" style="overflow:hidden;">
            <div id="div3" class="divinfo" style="padding:0;height:320px;">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
            <div class="divcon" style="height:231px;">
            <asp:GridView ID="GridView1" runat="server" SkinID="gv4" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
            <asp:BoundField DataField="ID" HeaderText="��" />
            <asp:BoundField DataField="Amount" HeaderText="����" />
            <asp:BoundField DataField="Deduct" HeaderText="���" />
            </Columns>
            </asp:GridView>
            </div>
            <table cellpadding="0" cellspacing="0" class="tb3">
            <tr>
                <td align="right">�����</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbAmount" runat="server"></asp:TextBox>
                </td>
                <td align="right">��ɣ�</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbDeduct" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td align="right">������ͣ�</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlType" runat="server" CssClass="pindl">
                    <asp:ListItem Value="1">�̶����</asp:ListItem>
                    <asp:ListItem Value="2">�������̶ֹ����</asp:ListItem>
                    <asp:ListItem Value="3">�ٷֱ�</asp:ListItem>
                    <asp:ListItem Value="4">�������ְٷֱ�</asp:ListItem>
                </asp:DropDownList>
                <asp:HiddenField ID="hfRecID" runat="server" Value="-1"/>
            </td>
            <td align="right">��ʽ������</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlStaffDeduct" runat="server" CssClass="pindl" AutoPostBack="true" OnSelectedIndexChanged="ddlStaffDeduct_SelectedIndexChanged">
                </asp:DropDownList></td>
            </tr>
            <tr>
            <td colspan="4">
                <asp:Button ID="btnMod" runat="server" Text="�޸�" UseSubmitBehavior="false" CssClass="bt1" OnClick="btnMod_Click" OnClientClick="if(chkDeductInput(1)==false)return false;" />
                <asp:Button ID="btnSave" runat="server" Text="���" UseSubmitBehavior="false" CssClass="bt1" OnClick="btnSave_Click" OnClientClick="if(chkDeductInput(0)==false)return false;"/>
                <asp:Button ID="btnDel" runat="server" Text="ɾ��" UseSubmitBehavior="false" CssClass="bt1" OnClick="btnDel_Click" OnClientClick="if(chkDeductDel()==false)return false;" />
            </td>
            </tr>
            </table>
            </ContentTemplate>
            </asp:UpdatePanel>
            </div>
            </div>
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
var tabnum=5;
var isfocus=1;
var processtip=1;
function ChkID(id)
{
    ClrID(id);
    $("tbAmount").value=$(id).cells[0].innerHTML;
    $("tbDeduct").value=$(id).cells[1].innerHTML;
}
function ChkAdd()
{
    if(isNull($("tbName").value))
    {
        window.alert("����ʧ�ܣ�Ա����������Ϊ��");
        $("tbName").focus();
        return false
    }
    
    if(!$("cbsys").checked)
    {
        if(isNull($("tbJobNO").value))
        {
            window.alert("����ʧ�ܣ�Ա����Ų���Ϊ��");
            $("tbJobNO").focus();
            return false
        }
    }
}
function chkDeductInput(m)
{
    if(m==1)
    {
        var id=parseInt($("hfRecID").value,10);
        if(id<=0)
        {
            alert("��ѡ��һ����¼�ٽ��в�����");
            return false;
        }
    }
    if(!(/(^\d+(\.\d+)?$)|(���������)/).test($("tbAmount").value))
    {
        alert("����ʧ�ܣ�����������");
        $("tbAmount").focus();
        return false;
    }
    if(!(/^\d+(\.\d+)?$/).test($("tbDeduct").value))
    {
        alert("����ʧ�ܣ�����������");
        $("tbDeduct").focus();
        return false;
    }
}
function chkDeductDel()
{
    var id=parseInt($("hfRecID").value,10);
    if(id<=0)
    {
        alert("��ѡ��һ����¼�ٽ��в�����");
        return false;
    }
    return confirm("ȷ��Ҫɾ��������������");
}
function ChkSysNO()
{
    if(!$("cbsys").checked)
    {
        $("tbJobNO").disabled=false;
        $("tbJobNO").focus();
    }else
    {
        $("tbJobNO").disabled=true;
    }
}

function SellInstr(str)
{
    var tc = document.getElementById("tbSellDe");
    var tclen = tc.value.length;
    tc.focus();
    if(typeof document.selection != "undefined")
    {
        document.selection.createRange().text = str;
    }
    else
    {
        tc.value = tc.value.substr(0,tc.selectionStart)+str+tc.value.substring(tc.selectionStart,tclen);
    }
}

function BillInstr(str)
{
    var tc = document.getElementById("tbBillDe");
    var tclen = tc.value.length;
    tc.focus();
    if(typeof document.selection != "undefined")
    {
        document.selection.createRange().text = str;
    }
    else
    {
        tc.value = tc.value.substr(0,tc.selectionStart)+str+tc.value.substring(tc.selectionStart,tclen);
    }
}
</script>
