<%@ page language="C#"  CodeFile="setting.aspx.cs"     autoeventwireup="true" inherits="Headquarters_System_Setting" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/tab.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sa22" style="width:606px;">
    <div id="mytabs">
            <span id="tabs_l1"></span>
            <span id="tabs1" onclick="ChkTab('1');">��������</span>
            <span id="tabs_r1"></span>
            <span id="tabs_l4"></span>
            <span id="tabs4" onclick="ChkTab('4');">��������2</span>
            <span id="tabs_r4"></span>
            <span id="tabs_l2"></span>
            <span id="tabs2" onclick="ChkTab('2');">�ʼ�/��¼����</span>
            <span id="tabs_r2"></span>
            <span id="tabs_l3"></span>
            <span id="tabs3" onclick="ChkTab('3');">�Զ�����</span>
            <span id="tabs_r3"></span>
            <span id="tabs_l5" ></span>
            <span id="tabs5" onclick="ChkTab('5');">��������</span>
            <span id="tabs_r5" ></span>
            
     </div>
    <div id="info1" style="padding:3px 0px 0px 3px; overflow:hidden;">
    <div id="divinfo1" class="divinfo" style="height:371px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb3">
            <tr>
                <td>��˾���ƣ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbName" runat="server" CssClass="pin" Width="200"></asp:TextBox></td>
                <td>��ϵ�绰��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin" Width="200"></asp:TextBox></td>
            </tr>
            <tr>
                <td>�������룺</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbZip" runat="server" CssClass="pin" Width="200"></asp:TextBox></td>
                <td align="right">��ַ��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin" Width="200"></asp:TextBox></td>
            </tr>
            
            <tr>
                <td class="sysred">ϵͳ���ƣ�</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbsysName" runat="server" CssClass="pin" Width="200"></asp:TextBox>
                </td>
                <td class="sysred" align="right">
                    <asp:Label ID="lbRegType" runat="server" Text="�û���"></asp:Label>��</td>
                <td style="padding-left:0px;">
                <asp:TextBox ID="tbBranchNum" runat="server" CssClass="pin" Width="130"></asp:TextBox>
                <asp:Label ID="lbreg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
        <table cellpadding="0" cellspacing="0" class="tb3" width="580">
            <tr><td>
        <fieldset style="padding:5px 0;">
        <legend style="color:#0000ff">��������</legend>
        <table cellpadding="0" cellspacing="0" class="tb3">
            <tr>
                <td align="right">Ĭ�ϵ����۸�</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddl_parm1" runat="server" CssClass="pindl">
                        <asp:ListItem Value="1">���ۼ�</asp:ListItem>
                        <asp:ListItem Value="2">������</asp:ListItem>
                        <asp:ListItem Value="3">�ڲ���</asp:ListItem>
                        <asp:ListItem Value="4">�ɻ���</asp:ListItem>
                        <asp:ListItem Value="5">�����</asp:ListItem>
                        <asp:ListItem Value="6">�б��</asp:ListItem>
                        <asp:ListItem Value="7">������</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">Ĭ�ϱ������ڣ�</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tb_parm2" runat="server" CssClass="pin" Text='30'></asp:TextBox>
                    ��
                </td>
            </tr>
            <tr>
                <td align="right">����ͻ����ϣ�</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddl_parm3" runat="server" CssClass="pindl">
                        <asp:ListItem Value="1">������</asp:ListItem>
                        <asp:ListItem Value="2">����</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">Ӧ��Ӧ���������ڣ�</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbRecDue" runat="server" CssClass="pin" Text='30'></asp:TextBox>
                    ��
                </td>
            </tr>
            <tr>
               <td align="right" colspan="2">�����½�������Ŀ������ɹر� <asp:CheckBox ID="cbbItemExit" runat="server" /></td>
                
                <td align="right">������֤�룺</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tb_parm9" runat="server" CssClass="pin"></asp:TextBox></td>
            </tr>
            
            <tr>
            <td align="right" colspan="2">������Ŀȫ���깤�������ɹر� <asp:CheckBox ID="cbbFinish" runat="server" /></td>
                
                <td>��������Ĭ�ϴ���ʽ��</td>
                <td style="padding-left:0px;"><asp:DropDownList ID="ddlServicesDo" runat="server" CssClass="pindl">
                        <asp:ListItem Value="0">�����ɹ�</asp:ListItem>
                        <asp:ListItem Value="1">��ɹر�</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
            <td align="right" colspan="2">���ۺ���Ŀ���һ�²�����ɹر�<asp:CheckBox ID="cbbFinish2" runat="server" /></td>
               
               
               <td>
               �����ͼĬ����ʾ����
               </td>
               <td style="padding-left:0px;">
                   <div class="isinDiv">
                    <asp:TextBox ID="tbCity" runat="server" CssClass="pin pinin"></asp:TextBox>
                    <asp:DropDownList ID="ddlCity" runat="server" CssClass="pininsl" onchange="document.getElementById('tbCity').value=this.options[this.selectedIndex].text;">
                        <asp:ListItem Value="����">����</asp:ListItem>
                        <asp:ListItem Value="�Ϻ�">�Ϻ�</asp:ListItem>
                        <asp:ListItem Value="���">���</asp:ListItem>
                        <asp:ListItem Value="����">����</asp:ListItem>
                        <asp:ListItem Value="�Ϸ�">�Ϸ�</asp:ListItem>
                        <asp:ListItem Value="����">����</asp:ListItem>
                        <asp:ListItem Value="����">����</asp:ListItem>
                        <asp:ListItem Value="����">����</asp:ListItem>
                        <asp:ListItem Value="����">����</asp:ListItem>
                        <asp:ListItem Value="ʯ��ׯ">ʯ��ׯ</asp:ListItem>
                        <asp:ListItem Value="������">������</asp:ListItem>
                        <asp:ListItem Value="�人">�人</asp:ListItem>
                        <asp:ListItem Value="��ɳ">��ɳ</asp:ListItem>
                        <asp:ListItem Value="�Ͼ�">�Ͼ�</asp:ListItem>
                        <asp:ListItem Value="�ϲ�">�ϲ�</asp:ListItem>
                        <asp:ListItem Value="����">����</asp:ListItem>
                        <asp:ListItem Value="����">����</asp:ListItem>
                        <asp:ListItem Value="̫ԭ">̫ԭ</asp:ListItem>
                        <asp:ListItem Value="�ɶ�">�ɶ�</asp:ListItem>
                        <asp:ListItem Value="����">����</asp:ListItem>
                        <asp:ListItem Value="����">����</asp:ListItem>
                        <asp:ListItem Value="��³ľ��">��³ľ��</asp:ListItem>
                    </asp:DropDownList>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="2">���񵥼���ԱΪ��ʱ������ɹر� <asp:CheckBox ID="cbbTec" runat="server" /></td>
                <td colspan="2">
                   ���� <asp:TextBox ID="tbiRepair" runat="server" CssClass="pin" Width="60"></asp:TextBox>
                   �����ٴ�ά�޵�Ϊ����
                </td>
            </tr>
            <tr>
                <td align="right" colspan="2">����Ӧ�ս��Ϊ�������깤���㻷�� <asp:CheckBox ID="cbbBln" runat="server" /></td>
                <td colspan="2">
                    <label for="cbPurSep">�ɹ����ŷ���</label><asp:CheckBox ID="cbPurSep" runat="server" />
                    <label for="cbSellSep">���۵��ŷ���</label><asp:CheckBox ID="cbSellSep" runat="server" />
                    <label for="cbSerBillSeparate">���񵥺ŷ���</label><asp:CheckBox ID="cbSerBillSeparate" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" colspan="2">
                   �ܲ�����<asp:CheckBox ID="cbHead" runat="server" />���ƹ��Ͻ�ֹ�ֶ����� <asp:CheckBox ID="cbFaultNoInput" runat="server" /></td>
                <td align="left" colspan="2">�����ʩ/�����ֹ�ֶ����� <asp:CheckBox ID="cbTakeStepsNoInput" runat="server" /></td>
            </tr>
            <tr>
                <td colspan="4">������ɹر�ʱǿ�����빤������������ʱ��/����ʱ��/���ʱ��/����ԭ�� <asp:CheckBox ID="cbEnforceInput" runat="server" /></td>
            </tr>
        </table>
    </fieldset>
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
<div id="info2" style="padding:3px 0px 0px 3px;">
    <div id="div2" class="divinfo" style="height:371px;">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb3" width="580">
            <tr><td>
        <fieldset style="padding:5px 0;">
        <legend style="color:#0000ff">�ʼ�����</legend>
            <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                    <td align="right">�ʼ���������</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tb_parm5" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td align="right">��½�û�����</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tb_parm6" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td align="right">��½���룺</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tb_parm7" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td align="right">�ʼ���ַ��</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tb_parm8" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    
                </tr>
            </table>
        </fieldset>
         <fieldset style="padding:5px 0;">
        <legend style="color:#0000ff">��¼����</legend>
        <table cellpadding="0" cellspacing="0" class="tb3">
            <tr>
                <td align="right" style="padding-left:40px;">��¼����ʾ������</td>
                <td style="padding-left:0px;">
                    <asp:CheckBox ID="cbLoginDLL" runat="server" />
                </td>
                <td align="right">��¼����ʾ��֤�룺</td>
                <td style="padding-left:0px;">
                    <asp:CheckBox ID="cbVerifyCode" runat="server" onclick="checkCode(this)" />
                </td>
                <td align="right">��¼����ʾ��ס���룺</td>
                <td style="padding-left:0px;">
                    <asp:CheckBox ID="cbRememberPassword" runat="server" onclick="checkCode(this)" />
                </td>
            </tr>
            <tr>
                <td align="right">��¼�����ֻ���֤��</td>
                <td style="padding-left:0px;">
                    <asp:CheckBox ID="cbPhone" runat="server" onclick="needPhoneChk();"/>
                </td>
            </tr>
            </table>
            </fieldset>
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
    <div id="info3" style="height:380px;">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
         <ContentTemplate>
        <asp:GridView ID="GridView1" runat="server" SkinID="gv4" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="id" DataField="id" />
                <asp:BoundField HeaderText="��" />
                <asp:BoundField HeaderText="��������" DataField="Type" />
                <asp:BoundField HeaderText="���ݴ���" DataField="Code" />
                <asp:BoundField HeaderText="��ŷ�ʽ" DataField="Style" />
                <asp:BoundField HeaderText="�ָ���" DataField="Tally" />
                <asp:BoundField HeaderText="��ʼ���" DataField="BeginNO" />
                <asp:BoundField HeaderText="����" DataField="Model" />
            </Columns>
        </asp:GridView>
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
        <span style="display:none;">
            <asp:Button ID="btnRef" runat="server" Text="btnRef" OnClick="btnRef_Click" /></span>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnRef" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
    </div>
    
    <div id="info4" style="padding:3px 0px 0px 3px; overflow:hidden;">
    <div id="divinfo4" class="divinfo" style="height:371px;">
        <table cellpadding="0" cellspacing="0" class="tb3" width="580">
            <tr><td>
        <fieldset style="padding:5px 0;">
        <legend style="color:#0000ff">��������</legend>
        <table cellpadding="0" cellspacing="0" class="tb3" style="width:100%;">
            <tr>
            <td align="right" colspan="2" style="width:270px;">�ɹ��������Ʋɹ����� <asp:CheckBox ID="cbPlanControl" runat="server" /></td>
            <td colspan="2" style="width:270px;">�ɹ����Ϊ0ʱ��ֹ��� <asp:CheckBox ID="cbbZeroPurchase" runat="server" /></td>
            </tr>
            <tr>
            <td align="right" colspan="2">��װ��ϵ���� <asp:CheckBox ID="cbDisblingControl" runat="server" /></td>
            <td align="right" style="width:100px;">�Զ�����ʱ�䣺</td>
            <td align="left" style="padding:0px;width:150px;">
                <asp:TextBox ID="tbLockTime" runat="server" Width="50"></asp:TextBox>��</td>
            </tr>
            <tr>
            <td align="right" colspan="2">��ͬ����Ψһ <asp:CheckBox ID="cbDeviceOnly" runat="server" /></td>
            <td></td>
            </tr>
            <tr>
                <td align="right">�½���Ʒ�ɱ��㷨</td>
                <td><asp:DropDownList ID="ddlCostMode" runat="server">
                    <asp:ListItem Value="2">�ƶ���Ȩƽ����</asp:ListItem>
                    <asp:ListItem Value="1">�Ƚ��ȳ���</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
        </table>
        </fieldset>
        </td>
        </tr>
        </table>
    </div>
    </div>
    <div id="info5" style="padding:3px 0px 0px 3px;">
    <div id="div3" class="divinfo" style="height:371px;">
        <fieldset style="padding:5px 0;">
           <legend style="color:#0000ff">�������IP��ַ����(����IP)</legend> 
            <table style="margin:auto;">
            <tr>
            <td>IP��ʼ��ַ</td>
            <td><asp:TextBox ID="tbIPStar" runat="server" ></asp:TextBox></td>
            <td>IP������ַ</td>
            <td><asp:TextBox ID="tbIPEnd" runat="server" ></asp:TextBox></td>
            </tr>
            </table>
        </fieldset>
        <fieldset style="padding:5px 0;">
           <legend style="color:#0000ff">������������û�����</legend> 
            <table style="margin:auto;">
            <tr>
            <td align="center">�û���</td>
            <td align="center">��ע</td>
            </tr>
            <tr>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>--��ѡ��--</asp:ListItem>
                </asp:DropDownList></td>
            <td><asp:TextBox ID="TextBox1" runat="server" Width="240px" ></asp:TextBox></td>
            </tr>
            <tr>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server">
                <asp:ListItem>--��ѡ��--</asp:ListItem>
                </asp:DropDownList></td>
            <td><asp:TextBox ID="TextBox2" runat="server" Width="240px" ></asp:TextBox></td>
            </tr>
            <tr>
            <td>
                <asp:DropDownList ID="DropDownList3" runat="server">
                <asp:ListItem>--��ѡ��--</asp:ListItem>
                </asp:DropDownList></td>
            <td><asp:TextBox ID="TextBox3" runat="server" Width="240px" ></asp:TextBox></td>
            </tr>
            <tr>
            <td>
                <asp:DropDownList ID="DropDownList4" runat="server">
                <asp:ListItem>--��ѡ��--</asp:ListItem>
                </asp:DropDownList></td>
            <td><asp:TextBox ID="TextBox4" runat="server" Width="240px" ></asp:TextBox></td>
            </tr>
            <tr>
            <td>
                <asp:DropDownList ID="DropDownList5" runat="server">
                <asp:ListItem>--��ѡ��--</asp:ListItem>
                </asp:DropDownList></td>
            <td><asp:TextBox ID="TextBox5" runat="server" Width="240px" ></asp:TextBox></td>
            </tr>
            <tr>
            <td>
                <asp:DropDownList ID="DropDownList6" runat="server">
                <asp:ListItem>--��ѡ��--</asp:ListItem>
                </asp:DropDownList></td>
            <td><asp:TextBox ID="TextBox6" runat="server" Width="240px" ></asp:TextBox></td>
            </tr>
            <tr>
            <td>
                <asp:DropDownList ID="DropDownList7" runat="server">
                <asp:ListItem>--��ѡ��--</asp:ListItem>
                </asp:DropDownList></td>
            <td><asp:TextBox ID="TextBox7" runat="server" Width="240px" ></asp:TextBox></td>
            </tr>
            <tr>
            <td>
                <asp:DropDownList ID="DropDownList8" runat="server">
                <asp:ListItem>--��ѡ��--</asp:ListItem>
                </asp:DropDownList></td>
            <td><asp:TextBox ID="TextBox8" runat="server" Width="240px" ></asp:TextBox></td>
            </tr>
            </table>
        </fieldset>
        <table style="margin:auto;" width="85%">
            <tr>
                <td align="right"> ��������:<asp:CheckBox ID="CheckBox1" runat="server" /><label for="CheckBox1" style="font-size:large;color:Red">����</label>
                </td>
            </tr>
            <tr><td align="left" style="font-size:small;color:Red;">*����IP��ַ�β������ã����������òŻ���Ч</td></tr>
        </table>
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td></td>
        <td align="right">
            <asp:Button ID="btnSave" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnSave_Click" />
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
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
var tabnum=6;
function ChkID(id)
{
    ClrBaseID(id);
}
function ChkSave()
{
    if(!isNull($("tbBranchNum").value))
    {
        if(!isDigit($("tbBranchNum").value))
        {
            window.alert("�û�����ʽ����ȷ.");
            ChkTab('1');
            $("tbBranchNum").select();
            return false
        }
    }
    
    if(!isNull($("tb_parm2").value))
    {
        if(!isDigit($("tb_parm2").value))
        {
            window.alert("��������(Ĭ��ά�ޱ�������)��ʽ����ȷ.");
            ChkTab('1');
            $("tb_parm2").select();
            return false
        }
    }
    if(!isNull($("tbRecDue").value))
    {
        if(!isDigit($("tbRecDue").value))
        {
            window.alert("��������(Ӧ��Ӧ����ǰ����)��ʽ����ȷ.");
            ChkTab('1');
            $("tbRecDue").select();
            return false
        }
    }
}
function EidtNO()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("��ѡ��һ����¼�������");
    }else
    {
        parent.ShowDialog1(400, 178, 'System/NOMod.aspx?id='+id, '�޸�');
    }
}
function needPhoneChk()
{
    if(document.getElementById("cbPhone").checked==false)
    {
        document.getElementById("cbVerifyCode").checked=true;
        document.getElementById("cbRememberPassword").checked=true;
    }
}
function checkCode(obj)
{
    if(obj.checked==false)
    {
        document.getElementById("cbPhone").checked=true;
    }
}
</script>
