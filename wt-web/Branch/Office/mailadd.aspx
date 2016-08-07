<%@ page language="C#"  CodeFile="mailadd.aspx.cs"     autoeventwireup="true" inherits="Branch_Office_MailAdd" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body onload="ChkSetFocus('tbTitle');">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="main">
        <div class="maincon">
        <div id="sa" style="width:684px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
               <table cellpadding="0" cellspacing="0" class="tb3">
                   <tr>
                        <td align="right">�ռ��ˣ�</td>
                        <td style="padding-left:0px;">
                          <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="padding:0px;"><asp:TextBox ID="tbRcv" CssClass="pin" Width="400" runat="server"></asp:TextBox></td>
                                <td style="padding-left:5px;"><input id="btnEmp" tabindex="-1" type="button" class="man" title="ѡ��Ա��" onclick="parent.ShowDialog1(400, 500, 'Office/SltRcv.aspx', '�ռ���');" /></td>
                            </tr>
                          </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">�ʼ����⣺</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbTitle" CssClass="pin" Width="400" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height:305px;">
                            <asp:TextBox ID="tbContent" CssClass="pin" TextMode="MultiLine" style="width:633px; height:290px;" runat="server" onfocus="ChkRcv(this);"></asp:TextBox>
                        </td>
                    </tr>
                    </table>
                    
                    <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                        <td>
                            <img src="../../Public/Images/li4.gif" />
                            <a href="#" style="color:#0000ff" title="�ϴ�����" onclick="ChkUpload();">�ϴ�����</a>
                            
                            <asp:HiddenField ID="hfUpload1" runat="server" />
                            
                            <asp:HiddenField ID="hfUpload2" runat="server" />
                            
                            <asp:HiddenField ID="hfUpload3" runat="server" />
                        </td>
                        <td>
                            <div runat="server" id="dUpload"></div>
                        </td>
                    </tr>    
                </table>
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSend" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>
            </div>
            </div>
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td align="right">
                    <asp:Button ID="btnSend" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnSend_Click"/>
                    <asp:Button ID="btnAdd" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnAdd_Click"  />
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
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
function ChkSave()
{
    if(isNull($("tbRcv").value))
    {
        window.alert("����ʧ�ܣ�����д�ռ�������");
        $("tbRcv").focus();
        return false
    }
    
    if(isNull($("tbTitle").value))
    {
        window.alert("����ʧ�ܣ�����д�ʼ�����");
        $("tbTitle").focus();
        return false
    }
}

function ChkImg()
{
    $("gdiv").innerHTML="";
    $("hfDoc").value="";
}

function ChkUpload()
{   
    if($("hfUpload3").value!="")
    {
        window.alert("��ǰ�汾���ֻ֧������������");
        return false;
    }
    else if($("hfUpload2").value!="")
    {
        parent.ShowDialog1(600, 380, 'Office/MailUpload.aspx?p=3', '�ϴ�����');
    }
    else if($("hfUpload1").value!="")
    {
        parent.ShowDialog1(600, 380, 'Office/MailUpload.aspx?p=2', '�ϴ�����');
    }
    else
    {
        parent.ShowDialog1(600, 380, 'Office/MailUpload.aspx?p=1', '�ϴ�����');
    }
}

function ChkRcv(obj)
{
    var rcv=$("tbRcv").value;
    if(rcv.indexOf(",")==-1&&!isNull(rcv))
    {
        obj.value=obj.value.replace(obj.getAttribute("old"),$("tbRcv").value);
        obj.setAttribute("old",$("tbRcv").value);
    }
}
</script>
