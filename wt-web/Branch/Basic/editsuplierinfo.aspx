<%@ page language="C#"  CodeFile="editsuplierinfo.aspx.cs"     autoeventwireup="true" inherits="Branch_Basic_EditSuplierInfo" enableEventValidation="false" %>

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
            <td>
                <asp:CheckBox ID="CheckBox1" runat="server" onclick="check_a()" /></td>
                <td align="right">���̷��ࣺ</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                    <asp:DropDownList ID="ddl1" runat="server" Width="136px">
                    </asp:DropDownList>
                 </td>
            </tr>
            <tr>
             <td><asp:CheckBox ID="CheckBox2" runat="server" onclick="check_b()"/></td>
                <td align="right">���޳��̣�</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:DropDownList ID="ddl2" runat="server" Width="136px">
                            <asp:ListItem Value=""></asp:ListItem>
                            <asp:ListItem Value="1">��</asp:ListItem>
                            <asp:ListItem Value="0">��</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                 </td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="CheckBox3" runat="server" onclick="check_c()"/></td>
                <td align="right">��Ʒ��Ӧ�̣�</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                          <asp:DropDownList ID="ddl3" runat="server" Width="136px">
                            <asp:ListItem Value=""></asp:ListItem>
                            <asp:ListItem Value="1">��</asp:ListItem>
                            <asp:ListItem Value="0">��</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                 </td>
            </tr>
            <tr>
            <td><asp:CheckBox ID="CheckBox4" runat="server" onclick="check_d()"/></td>
                <td align="right">��Լά�޹�Ӧ�̣�</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:DropDownList ID="ddl4" runat="server" Width="136px">
                            <asp:ListItem Value=""></asp:ListItem>
                            <asp:ListItem Value="1">��</asp:ListItem>
                            <asp:ListItem Value="0">��</asp:ListItem>
                        </asp:DropDownList>
                    </div>
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
        if($("ddl1").value=="-1")
        {
            if(confirm("δѡ��ͻ���������ȷ�����޸ĳ��̷���Ϊ�գ�����ȡ��������"))
            {
            }else
            {        
                return false
            }
        }
    }
    if(document.getElementById("CheckBox2").checked==true)
    {
        if($("ddl2").value=="")
        {
            if(confirm("δѡ�����޳��̣������ȷ�����޸�'���޳���'Ϊ�񣬷���ȡ��������"))
            {
            }else
            {        
                return false
            }
        }
    }
    if(document.getElementById("CheckBox3").checked==true)
    {
        if($("ddl3").value=="")
        {
            if(confirm("δѡ���Ʒ��Ӧ�̣������ȷ�����޸�'��Ʒ��Ӧ��'Ϊ�񣬷���ȡ��������"))
            {
            }else
            {        
                return false
            }
        }
    }
    if(document.getElementById("CheckBox4").checked==true)
    {
        if($("ddl4").value=="")
        {
            if(confirm("δѡ����Լά�޹�Ӧ�̣������ȷ�����޸�'��Լά�޹�Ӧ��'Ϊ�񣬷���ȡ��������"))
            {
            }else
            {        
                return false
            }
        }
    }
    if (document.getElementById("CheckBox1").checked==false && document.getElementById("CheckBox2").checked==false && document.getElementById("CheckBox3").checked==false && document.getElementById("CheckBox4").checked==false)
    {
       window.alert('������ѡ��һ�');
       return false;
    }
}
function aload()
{
    document.getElementById('ddl1').disabled=true;
    document.getElementById('ddl2').disabled=true;
    document.getElementById("ddl3").disabled=true;
    document.getElementById("ddl4").disabled=true;
}

function check_a()
{
    if(document.getElementById("CheckBox1").checked==true)
    {
        document.getElementById('ddl1').disabled=false;
    }    
    else
    {
        document.getElementById('ddl1').disabled=true;
    }
}
function check_b()
{
    if(document.getElementById("CheckBox2").checked==true)
    {
        document.getElementById('ddl2').disabled=false;
    }   
    else
    {
        document.getElementById('ddl2').disabled=true;
    } 
}
function check_c()
{
    if(document.getElementById("CheckBox3").checked==true)
    {
        document.getElementById('ddl3').disabled=false;
    }    
    else
    {
        document.getElementById('ddl3').disabled=true;
    } 
}
function check_d()
{
    if(document.getElementById("CheckBox4").checked==true)
    {
        document.getElementById('ddl4').disabled=false;
    }    
    else
    {
        document.getElementById('ddl4').disabled=true;
    } 
}

</script>
