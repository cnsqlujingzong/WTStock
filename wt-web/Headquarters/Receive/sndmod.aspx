<%@ page language="C#"  CodeFile="sndmod.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Receive_SndMod" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:710px;">
    <div class="fdivs">
    <div class="sdivs" style="padding:3px 0 3px 0px;width:706px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td>�������ţ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbBillID" runat="server" CssClass="pinb" Width="110" ReadOnly="true"></asp:TextBox></td>
            <td>���ڣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDate" runat="server" CssClass="pin" Width="80" ></asp:TextBox></td>
            <td class="red">�����ˣ�</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl" Width="70">
                </asp:DropDownList>
            </td>
            <td>���</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlSndType" runat="server" CssClass="pindl" Width="53">
                    <asp:ListItem Value=""></asp:ListItem>
                    <asp:ListItem Value="����">����</asp:ListItem>
                    <asp:ListItem Value="����">����</asp:ListItem>
                    <asp:ListItem Value="����">����</asp:ListItem>
                    <asp:ListItem Value="����">����</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="sysred">�ջ����ͣ�</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlRcvObj" runat="server" CssClass="pindl" Width="53">
                    <asp:ListItem Value="�ͻ�">�ͻ�</asp:ListItem>
                    <asp:ListItem Value="����">����</asp:ListItem>
                    <asp:ListItem Value="����">����</asp:ListItem> 
                    <asp:ListItem Value="����">����</asp:ListItem>
                </asp:DropDownList>
                
            </td>
        </tr>
     </table>
    <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td class="red">��˾���ƣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbCusName" runat="server" CssClass="pin" Width="250"></asp:TextBox>
            </td>
            <td>�ջ��ˣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin" Width="80"></asp:TextBox></td>
            <td>��ϵ�绰��</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin"></asp:TextBox></td>
        </tr>
        <tr>
            <td>�ջ���ַ��</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin" Width="250"></asp:TextBox></td>
            <td align="right">�ʱࣺ</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbZip" runat="server" CssClass="pin" Width="80"></asp:TextBox>
            </td>
            <td class="red">�������ƣ�</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlBranch" runat="server" Enabled="false" CssClass="pindl" >
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td>��ƷժҪ��</td>
            <td style="padding-left:0px; height:50px;"><asp:TextBox ID="tbSummary" runat="server" CssClass="pin" Width="610" TextMode="MultiLine" Height="42"></asp:TextBox></td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td>���˷�ʽ��</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlShipStyle" runat="server" CssClass="pindl">
                </asp:DropDownList>
            </td>
            <td>�������ţ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbSndNo" runat="server" CssClass="pin"></asp:TextBox></td>
            <td>���ʣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbPostage" runat="server" CssClass="pin"></asp:TextBox></td>
        </tr>
     </table>
    <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td>��ע��Ϣ��</td>
            <td style="padding-left:0px;height:50px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="610" TextMode="MultiLine" Height="42"></asp:TextBox></td>
        </tr>
    </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnConfSnd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td><asp:HiddenField ID="hfPrintID" runat="server" />
            </td>
            <td align="right">
                <asp:Button ID="btnConfSnd" runat="server" Text="ȷ�Ϸ���" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;"  OnClick="btnConfSnd_Click"/>
                <asp:Button ID="btnAdd" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;"  OnClick="btnAdd_Click"/>
                <input id="btnPrint" type="button" value="��ӡ" class="bt1" onclick="ChkPrint('FHD');" />
                <input id="btnClose" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog();" />
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
<script language="javascript" type="text/javascript" src="../../Public/Script/detail.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
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
    
    if(isNull($("ddlSndType").value))
    {
        window.alert("����ʧ�ܣ������Ϊ��");
        $("ddlSndType").focus();
        return false
    }
    if(isNull($("tbLinkMan").value))
    {
        window.alert("����ʧ�ܣ���ϵ�˲���Ϊ��");
        $("tbLinkMan").focus();
        return false
    }
    if(isNull($("tbAdr").value))
    {
        window.alert("����ʧ�ܣ���ַ����Ϊ��");
        $("tbAdr").focus();
        return false
    }
    
    if(isNull($("tbSummary").value))
    {
        window.alert("����ʧ�ܣ���ƷժҪ����Ϊ��");
        $("tbSummary").focus();
        return false
    }  
    
    if(!isNull($("tbPostage").value))
    {
        if(!isMoney($("tbPostage").value))
        {
            window.alert("����ʧ�ܣ����ʸ�ʽ����ȷ");
            $("tbPostage").focus();
            return false
        }
    }
}

</script>
