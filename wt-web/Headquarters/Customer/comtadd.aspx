<%@ page language="C#"  CodeFile="comtadd.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Customer_ComtAdd" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sa" style="width:456px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
        <div class="fdiv">
        <div class="sdiv">
        <table cellpadding="0" cellspacing="0" class="tb3">
            <tr>
                <td align="right">
                    �������ڣ�
                </td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
                </td>
                <td align="right">
                    �����ˣ�
                </td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                
            </tr>
            <tr>
                <td align="right" class="red">�ͻ����ƣ�</td>
                <td style="padding-left:0px;" colspan="3">
                    <asp:TextBox ID="tbCusName" runat="server" CssClass="pin" Width="341"></asp:TextBox>
                </td>
                <td style="padding:0px;"><input id="btnSlt" type="button" value="" onclick="SltCus();" class="bview"/></td>
            </tr>
            <tr>
                <td align="right">
                    ��ϵ�ˣ�
                </td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td align="right">
                    ��ϵ�绰��
                </td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbTel" runat="server" CssClass="pin"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="sysred">
                    Ͷ�����ݣ�
                </td>
                <td style="padding-left:0px; height:56px;" colspan="3">
                    <asp:TextBox ID="tbContent" runat="server" CssClass="pin" Width="341" Height="42" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="sysred">�����ˣ�</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlDoOperator" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                <td align="right">����ҵ��</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbOperationID" runat="server" CssClass="pin"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    ��ע��
                </td>
                <td style="padding-left:0px;" colspan="3">
                    <asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="341"></asp:TextBox>
                </td>
            </tr>
         </table>
          <asp:HiddenField ID="hfCusID" runat="server" Value="-1" />
          <span style="display:none;">
            <asp:Button ID="btnCusInfo" runat="server" Text="..." OnClick="btnCusInfo_Click"/>
          </span>
        </div>
        </div>
        
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="right">
            <asp:Button ID="btnAdd" runat="server" Text="ȷ��" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnAdd_Click" />
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
var processtip=1;
function ChkSave()
{
    if(isNull($("tbDate").value))
    {
        window.alert("����ʧ�ܣ��������ڲ���Ϊ��");
        $("tbDate").focus();
        return false
    }
    
    if($("ddlOperator").value=="-1")
    {
        window.alert("����ʧ�ܣ������˲���Ϊ��");
        $("ddlOperator").focus();
        return false
    }
    
    if(isNull($("tbCusName").value))
    {
        window.alert("����ʧ�ܣ��ͻ���������Ϊ��");
        $("tbCusName").focus();
        return false
    }
    if(isNull($("tbTel").value))
    {
        window.alert("����ʧ�ܣ���ϵ�绰����Ϊ��");
        $("tbTel").focus();
        return false
    }
    if(isNull($("tbContent").value))
    {
        window.alert("����ʧ�ܣ�Ͷ�����ݲ���Ϊ��");
        $("tbContent").focus();
        return false
    }
    
    if($("ddlDoOperator").value=="-1")
    {
        window.alert("����ʧ�ܣ������˲���Ϊ��");
        $("ddlDoOperator").focus();
        return false
    }
}

function SltCus()
{
    parent.ShowDialog1(800, 500, 'Customer/SltCus.aspx?f=2', 'ѡ��ͻ�');
}

</script>
