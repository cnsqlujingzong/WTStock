<%@ page language="C#"  CodeFile="editexpense.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Financial_EditExpense" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body onload="aload()">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:286px;">
    <div class="fdivs">
    <div class="sdivs" style="padding:3px 0 3px 0px;width:282px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
    <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td><asp:CheckBox ID="CheckBox1" runat="server" onclick="check_a()" /></td>
                <td style="padding-left:0px;">���㷽ʽ��</td>
                <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlChargeStyle" runat="server" CssClass="pindl" Enabled ="false">
                </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="CheckBox2" runat="server" onclick="check_b()" /></td>
                <td style="padding-left:0px;">�����ʻ���</td>
                <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlChargeAccount" runat="server" CssClass="pindl" Enabled="false">
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
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="left"><font color="red">*�����״̬�򲻻ᱻ�޸�</font></td>
            <td align="right">
                <asp:Button ID="btnAdd" runat="server" Text="ȷ��" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnAdd_Click"/>
                <input id="btnClose" type="button" value="ȡ��" class="bt1" onclick="parent.CloseDialog();" />
            </td>
        </tr>
    </table>
    </div>
    </div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/menu.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
function ChkSave()
{
    if(document.getElementById("CheckBox1").checked==true )
    {
        if($("ddlChargeStyle").value=="-1")
        {
            if(confirm("δѡ����㷽ʽ�������ȷ�����޸�'���㷽ʽ'Ϊ�գ�����ȡ��������"))
            {
            }else
            {        
                return false
            }
        }
    }
    if(document.getElementById("CheckBox2").checked==true)
    {
        if($("ddlChargeAccount").value=="-1")
        {
             if(confirm("δѡ������ʻ��������ȷ�����޸�'�����ʻ�'Ϊ�գ�����ȡ��������"))
            {
            }else
            {        
                return false
            }
        }
    }
 
    if (document.getElementById("CheckBox1").checked==false && document.getElementById("CheckBox2").checked==false )
    {
       window.alert('������ѡ��һ�');
       return false;
    }
}
function aload()
{
    document.getElementById('slGdsClass').disabled=true;
    document.getElementById('ddlStatus').disabled=true;
    document.getElementById("ddlArea").disabled=true;
    document.getElementById("ddlMember").disabled=true;
    document.getElementById("ddlSeeBack").disabled=true;
    document.getElementById("ddlbTrace").disabled=true;
    document.getElementById("ddlSeller").disabled=true;
}

function check_a()
{
    if(document.getElementById("CheckBox1").checked==true)
    {
        document.getElementById('ddlChargeStyle').disabled=false;
    }    
    else
    {
        document.getElementById('ddlChargeStyle').disabled=true;
    }
}
function check_b()
{
    if(document.getElementById("CheckBox2").checked==true)
    {
        document.getElementById('ddlChargeAccount').disabled=false;
    }   
    else
    {
        document.getElementById('ddlChargeAccount').disabled=true;
    } 
}
function check_c()
{
    if(document.getElementById("CheckBox3").checked==true)
    {
        document.getElementById('ddlArea').disabled=false;
    }    
    else
    {
        document.getElementById('ddlArea').disabled=true;
    } 
}
function check_d()
{
    if(document.getElementById("CheckBox4").checked==true)
    {
        document.getElementById('ddlMember').disabled=false;
    }    
    else
    {
        document.getElementById('ddlMember').disabled=true;
    } 
}
function check_e()
{
    if(document.getElementById("CheckBox5").checked==true)
    {
        document.getElementById('ddlSeeBack').disabled=false;
    }   
    else
    {
        document.getElementById('ddlSeeBack').disabled=true;
    }  
}
function check_f()
{
    if(document.getElementById("CheckBox6").checked==true)
    {
        document.getElementById('ddlbTrace').disabled=false;
    }   
    else
    {
        document.getElementById('ddlbTrace').disabled=true;
    }  
}
function check_g()
{
    if(document.getElementById("CheckBox7").checked==true)
    {
        document.getElementById('ddlSeller').disabled=false;
    }   
    else
    {
        document.getElementById('ddlSeller').disabled=true;
    }  
}
</script>
