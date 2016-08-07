<%@ page language="C#"  CodeFile="suppliermod.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Basic_SupplierMod" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="main">
        <div class="maincon">
        <div id="sa" style="width:526px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                    <td class="blue">�������ƣ�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbName" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td class="blue">���̱�ţ�</td>
                    <td style="padding-left:0px; width: 137px;"><asp:TextBox ID="tbSupNO" runat="server" CssClass="pin" Enabled="false"></asp:TextBox></td>
                    <td style="padding-left:5px;" class="sysred">
                        <asp:CheckBox ID="cbsys" runat="server" Text="ϵͳĬ��" Checked="true" onclick="ChkSysNO();"/></td>
                    </tr>
                    <tr>
                       <td>�������</td>
                        <td style="padding-left:0px;">
                            <div class="isinDiv">
                            <input type="text" id="tbSupClass" runat="server" class="pin pinin" readonly="readonly" />
                                <select id="slSupClass" runat="server" onchange="getclassvalue('tbSupClass',this.options[this.selectedIndex].text);" class="pininsl">
                                </select>
                            </div>
                         </td>
                         <td align="right">��ϵ�ˣ�</td>
                        <td style="padding-left:0px; width: 137px;"><asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>��ϵ�绰��</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td>�ֻ����룺</td>
                        <td style="padding-left:0px; width: 137px;"><asp:TextBox ID="tbTel2" runat="server" CssClass="pin"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">���棺</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbFax" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td align="right">�ʱࣺ</td>
                        <td style="padding-left:0px; width: 137px;"><asp:TextBox ID="tbZip" runat="server" CssClass="pin"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">Email��</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbEmail" runat="server" CssClass="pin"></asp:TextBox>
                        </td>
                        <td align="right">�ʻ���</td>
                        <td style="padding-left:0px; width: 137px;"><asp:TextBox ID="tbAccount" runat="server" CssClass="pin"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">��ַ��</td>
                        <td colspan="4" style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin" Width="341"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">��ע��</td>
                        <td colspan="4" style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="341"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td colspan="4" style="padding-left:0px;">
                            <asp:CheckBox ID="cbTransmitCorp" runat="server" /> ���޳���
                            <asp:CheckBox ID="cbSupplier" runat="server" /> ��Ʒ��Ӧ��
                            <asp:CheckBox ID="cbChargeCorp" runat="server" /> ��Լά�޽��㳧��
                            <asp:CheckBox ID="cbStop" runat="server" /> <span class="sysred">ͣ�ñ�־</span>
                            <asp:HiddenField ID="hfTemp" runat="server" />
                            <asp:HiddenField ID="hfsuplierclass" runat="server" />
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
        window.alert("����ʧ�ܣ��������Ʋ���Ϊ��");
        $("tbName").focus();
        return false
    }
    
    if(!$("cbsys").checked)
    {
        if(isNull($("tbSupNO").value))
        {
            window.alert("����ʧ�ܣ����̱�Ų���Ϊ��");
            $("tbSupNO").focus();
            return false
        }
    }
}

function ChkSysNO()
{
    if(!$("cbsys").checked)
    {
        $("tbSupNO").disabled=false;
        $("tbSupNO").focus();
    }else
    {
        $("tbSupNO").disabled=true;
    }
}
</script>
