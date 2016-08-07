<%@ page language="C#"  CodeFile="devaccmod.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Customer_DevAccMod" enableEventValidation="false" %>
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
        <div id="sa" style="width:486px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
               <table cellpadding="0" cellspacing="0" class="tb3">
               <tr>
               <td align="right">�����ˣ�</td>
               <td style="padding-left:0px;" colspan="2">
                    <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl2" Width="153px">
                    </asp:DropDownList>
               </td>
               </tr>
               <tr>
               <td align="right">����ʱ�䣺</td>
               <td style="padding-left:0px;" colspan="2">
                    <asp:TextBox ID="tbDate" runat="server" CssClass="Wdate2" Width="150px" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
               </td>
               </tr>
                <tr>
                    <td align="right">�������ƣ�</td>
                    <td style="padding-left:0px;" colspan="2"><asp:TextBox ID="tbName" runat="server" CssClass="pin" Width="200"></asp:TextBox></td>
                </tr>

                <tr>
                    <td align="right">����ժҪ��</td>
                    <td style="padding-left:0px;" colspan="2"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="330"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:HiddenField ID="hfUpload" runat="server" /></td>
                    <td style="padding-left:0px;"><a href="#" style="color:#0000ff" title="�ϴ�����" onclick="ChkUpload();">�ϴ�����</a>
                    </td>
                    <td style="width:260px;">
                        <div id="dUpload" runat="server"></div>
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
                    <asp:Button ID="btnAdd" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnAdd_Click"/>
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
<script language="javascript" type="text/javascript">
var isfocus=1;
var processtip=1;
function ChkSave()
{
    if($("ddlOperator").value=="-1")
    {
        window.alert("����ʧ�ܣ������˲���Ϊ��");
        $("ddlOperator").focus();
        return false;
    }
    if($("tbDate").value=="")
    {
        window.alert("����ʧ�ܣ�����ʱ�䲻��Ϊ��");
        $("tbDate").focus();
        return false;
    }
    if(isNull($("tbName").value))
    {
        window.alert("����ʧ�ܣ��������Ʋ���Ϊ��");
        $("tbName").focus();
        return false
    }
    if(isNull($("tbRemark").value))
    {
        window.alert("����ʧ�ܣ�����д����ժҪ");
        $("tbRemark").focus();
        return false
    }
    if($("dUpload").innerHTML=="")
     {
         if(!confirm("�ø�����û���ϴ����Ƿ񱣴棿"))
         {
            return false;
         }
     }
}

function ChkUpload()
{   
    if($("dUpload").innerHTML=="")
    {
        parent.ShowDialog1(600, 380, 'Customer/DocUpload.aspx', '�ϴ�����');
    }
    else
    {
        if(confirm("�Ѿ�����һ�������������ϴ����滻�ø������Ƿ������"))
        {
            parent.ShowDialog1(600, 380, 'Customer/DocUpload.aspx', '�ϴ�����');   
        }
    }
}
</script>
