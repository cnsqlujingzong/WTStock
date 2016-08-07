<%@ page language="C#"  CodeFile="taskadd.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Office_TaskAdd" enableEventValidation="false" %>
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
                <td align="right">
                    ִ�����ڣ�
                </td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbDoDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
                </td>
                <td align="right" style="width:60px;">
                    ִ���ˣ�
                </td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlDoOperator" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                
            </tr>
            <tr>
                <td align="right" class="sysred">
                    ����ժҪ��
                </td>
                <td style="padding-left:0px;" colspan="3">
                    <asp:TextBox ID="tbSummary" runat="server" CssClass="pin" Width="341"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    ����������
                </td>
                <td style="padding-left:0px; height:84px;" colspan="3">
                    <asp:TextBox ID="tbTaskRemark" runat="server" CssClass="pin" Width="341" Height="70" TextMode="MultiLine"></asp:TextBox>
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
    if(isNull($("tbDoDate").value))
    {
        window.alert("����ʧ�ܣ�ִ�����ڲ���Ϊ��");
        $("tbDoDate").focus();
        return false
    }
    
    if($("ddlDoOperator").value=="-1")
    {
        window.alert("����ʧ�ܣ�ִ���˲���Ϊ��");
        $("ddlDoOperator").focus();
        return false
    }
    
    if(isNull($("tbSummary").value))
    {
        window.alert("����ʧ�ܣ�����ժҪ����Ϊ��");
        $("tbSummary").focus();
        return false
    }

}

</script>
