<%@ page language="C#"  CodeFile="branchadd.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Basic_BranchAdd" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="main">
        <div class="maincon">
        <div id="sa" style="width:576px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                        <td align="right" class="blue">��������</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbName" runat="server" CssClass="pin pin2 pbb"></asp:TextBox>
                        </td>
                        <td class="blue">�����ţ�</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbBranchNO" runat="server" CssClass="pin" Enabled="false"></asp:TextBox></td>
                        <td class="sysred" style="padding-left:5px;">
                            <asp:CheckBox ID="cbsys" runat="server" Text="ϵͳĬ��" Checked="true" onclick="ChkSysNO();" /></td>
                    </tr>
                    <tr>
                        <td align="right">��˾����</td>
                        <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbCorp" runat="server" CssClass="pin" Width="341"></asp:TextBox></td>
                        <td class="sysred" style="padding-left:5px;"><asp:CheckBox ID="cbBranchPurchase" runat="server" Text="�����ɹ�" onclick="if(this.checked==false) $('cbGoodsAdd').checked=false;" /></td>
                    </tr>
                    <tr>
                        <td align="right">��ϵ�ˣ�</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbMan" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td align="right">�绰��</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td class="sysred" style="padding-left:5px;"><asp:CheckBox ID="cbGoodsAdd" runat="server" Text="�½���Ʒ" onclick="if(this.checked==true) $('cbBranchPurchase').checked=true;" /></td>
                    </tr>
                    <tr>
                        <td align="right">�ʱࣺ</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbZip" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td align="right">���棺</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbFax" runat="server" CssClass="pin"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">Email��</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbEmail" runat="server" CssClass="pin"></asp:TextBox></td>
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
                        <td align="right">���������</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="txt_js_TaxRate" runat="server"></asp:TextBox></td>
                        <td align="right">��ֵ˰����</td>
                        <td style="padding-left:0px;"> <asp:TextBox ID="txt_zzsxx_TaxRate" runat="server"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td align="right">��ֵ˰����</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="txt_zzsjx_TaxRate" runat="server"></asp:TextBox></td>
                        <td align="right">��ͨ��Ʊ</td>
                        <td style="padding-left:0px;"> <asp:TextBox ID="txt_ptfp_TaxRate" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">��ַ��</td>
                        <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin" Width="341"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">�ʺţ�</td>
                        <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbAccount" runat="server" CssClass="pin" Width="341"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">��ע��</td>
                        <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="341"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td style="padding-left:0px;"><asp:CheckBox ID="bStop" runat="server" /> <span class="sysred">ͣ�ñ�־</span>
                         <asp:HiddenField ID="hfArea" runat="server" />
                        <span style="display:none;">
                            <asp:Button ID="btnRef" runat="server" Text="Ref" OnClick="btnRef_Click" /></span>
                        </td>
                        <td align="right">
                            ����
                        </td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbArray" runat="server" CssClass="pin"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnRef" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>
            </div>
            </div>
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="padding-left:5px;color:#0000ff">
                    <asp:CheckBox ID="cbClose" runat="server" Text="�����رմ���" Checked="true" /><asp:HiddenField ID="hfOverFlag" runat="server" Value="-1"></asp:HiddenField></td>
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
var isfocus=1;
var processtip=1;
function ChkAdd()
{
    if(isNull($("tbName").value))
    {
        window.alert("����ʧ�ܣ�����������Ϊ��");
        $("tbName").focus();
        return false
    }
    if(!isDigit($("tbArray").value))
    {
        window.alert("����ʧ�ܣ������ֶα���Ϊ����");
        $("tbArray").focus();
        return false;
    }
    
    if($("hfOverFlag").value=="0")
    {
        alert("����ϵͳ���û����Ѵﵽ���ޣ��½�����ʱ��Ĭ�����ӳ����û��������½��û�ϵͳ�ᱻ������");
        return false;
    }
}
function SltCus()
{
    parent.ShowDialog1(800, 500, '../Headquarters/Services/SltCus.aspx?f=1&strname='+escape($("tbCusName").value), 'ѡ��ͻ�');
}
function ChkSysNO()
{
    if(!$("cbsys").checked)
    {
        $("tbBranchNO").disabled=false;
        $("tbBranchNO").focus();
    }else
    {
        $("tbBranchNO").disabled=true;
    }
}
</script>
