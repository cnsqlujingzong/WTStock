<%@ page language="C#"  CodeFile="editcusclass.aspx.cs"     autoeventwireup="true" inherits="Branch_Customer_EditCusClass" enableEventValidation="false" %>
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
             <td><asp:CheckBox ID="CheckBox1" runat="server" onclick="check_a()"/></td>
                <td align="right">�ͻ����</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                    <input type="text" id="tbGdsClass" runat="server" class="pin pinin" readonly="readonly" />
                        <select id="slGdsClass" runat="server" onchange="getclassvalue('tbGdsClass',this.options[this.selectedIndex].text);" class="pininsl">
                        </select>
                    </div>
                 </td>
            </tr>
            <tr>
             <td><asp:CheckBox ID="CheckBox2" runat="server" onclick="check_b()"/></td>
                <td align="right">�ͻ�״̬��</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:DropDownList ID="ddlStatus" runat="server" Width="136px">
                        </asp:DropDownList>
                    </div>
                 </td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="CheckBox3" runat="server" onclick="check_c()"/></td>
                <td align="right">�ͻ�����</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                          <asp:DropDownList ID="ddlArea" runat="server" Width="136px">
                        </asp:DropDownList>
                    </div>
                 </td>
            </tr>
            <tr>
            <td><asp:CheckBox ID="CheckBox4" runat="server" onclick="check_d()"/></td>
                <td align="right">��Ա����</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:DropDownList ID="ddlMember" runat="server" Width="136px">
                        </asp:DropDownList>
                    </div>
                 </td>
            </tr>
                        <tr>
                        <td><asp:CheckBox ID="CheckBox5" runat="server" onclick="check_e()"/></td>
                <td align="right">�طñ�־��</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:DropDownList ID="ddlSeeBack" runat="server" Width="136px">
                        <asp:ListItem Value=""> </asp:ListItem>
                            <asp:ListItem Value="1">��</asp:ListItem>
                            <asp:ListItem Value="0">��</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                 </td>
            </tr>
                        <tr>
                        <td><asp:CheckBox ID="CheckBox6" runat="server" onclick="check_f()"/></td>
                <td align="right">���ٱ�־��</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:DropDownList ID="ddlbTrace" runat="server" Width="136px">
                        <asp:ListItem Value=""> </asp:ListItem>
                            <asp:ListItem Value="1">��</asp:ListItem>
                            <asp:ListItem Value="0">��</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                 </td>
            </tr>
            <tr>
                        <td><asp:CheckBox ID="CheckBox7" runat="server" onclick="check_g()"/></td>
                <td align="right">ҵ��Ա��</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:DropDownList ID="ddlSeller" runat="server" Width="136px">
                        </asp:DropDownList>
                    </div>
                 </td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="CheckBox8" runat="server" onclick="check_h()"/></td>
                <td align="right">�Ƿ�ͣ�ã�</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:DropDownList ID="ddlStop" runat="server" Width="136px">
                        <asp:ListItem Value=""></asp:ListItem>
                            <asp:ListItem Value="1">��</asp:ListItem>
                            <asp:ListItem Value="2">��</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                 </td>
            </tr>
            <td><asp:CheckBox ID="CheckBox9" runat="server" onclick="check_i()"/></td>
                <td align="right">������ȣ�</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbDisposition" runat="server"></asp:TextBox>
                 </td>
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
        if($("slGdsClass").value=="0")
        {
            if(confirm("δѡ��ͻ���������ȷ�����޸Ŀͻ����Ϊ�գ�����ȡ��������"))
            {
            }else
            {        
                return false
            }
        }
    }
    if(document.getElementById("CheckBox2").checked==true)
    {
        if($("ddlStatus").value=="-1")
        {
             if(confirm("δѡ��ͻ�״̬�������ȷ�����޸�'�ͻ�״̬'Ϊ�գ�����ȡ��������"))
            {
            }else
            {        
                return false
            }
        }
    }
    if(document.getElementById("CheckBox3").checked==true)
    {
        if($("ddlArea").value=="-1")
        {
            if(confirm("δѡ��'����'�������ȷ�����޸�'����'Ϊ�գ�����ȡ��������"))
            {
            }else
            {        
                return false
            }
        }
    }
    if(document.getElementById("CheckBox4").checked==true)
    {
        if($("ddlMember").value=="-1")
        {
            if(confirm("δѡ��'��Ա����'�������ȷ�����޸�'��Ա����'Ϊ�գ�����ȡ��������"))
            {
            }else
            {        
                return false
            }
        }
    }
    if(document.getElementById("CheckBox5").checked==true)
    {
        if($("ddlSeeBack").value=="")
        {
            if(confirm("δѡ��'�Ƿ�ط�'�������ȷ�����޸�'�Ƿ�ط�'Ϊ�񣬷���ȡ��������"))
            {
            }else
            {        
                return false
            }
        }
    }
    if(document.getElementById("CheckBox6").checked==true)
    {
        if($("ddlbTrace").value=="")
        {
            if(confirm("δѡ��'�Ƿ����'�������ȷ�����޸�'�Ƿ����'Ϊ�񣬷���ȡ��������"))
            {
            }else
            {        
                return false
            }
        }
    }
    if(document.getElementById("CheckBox9").checked==true)
    {
        if(!isMoney($("tbDisposition").value))
        {
            window.alert("������ȱ���Ϊ����");
            $("tbDisposition").foucs();
            return false;
        }
    }
    if (document.getElementById("CheckBox1").checked==false && document.getElementById("CheckBox2").checked==false && document.getElementById("CheckBox3").checked==false && document.getElementById("CheckBox4").checked==false && document.getElementById("CheckBox5").checked==false&& document.getElementById("CheckBox6").checked==false&& document.getElementById("CheckBox7").checked==false&& document.getElementById("CheckBox8").checked==false&& document.getElementById("CheckBox9").checked==false)
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
    document.getElementById("ddlStop").disabled=true;
    document.getElementById("tbDisposition").disabled=true;
}

function check_a()
{
    if(document.getElementById("CheckBox1").checked==true)
    {
        document.getElementById('slGdsClass').disabled=false;
    }    
    else
    {
        document.getElementById('slGdsClass').disabled=true;
    }
}
function check_b()
{
    if(document.getElementById("CheckBox2").checked==true)
    {
        document.getElementById('ddlStatus').disabled=false;
    }   
    else
    {
        document.getElementById('ddlStatus').disabled=true;
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
function check_h()
{
    if(document.getElementById("CheckBox8").checked==true)
    {
        document.getElementById('ddlStop').disabled=false;
    }   
    else
    {
        document.getElementById('ddlStop').disabled=true;
    }  
}
function check_i()
{
    if(document.getElementById("CheckBox9").checked==true)
    {
        document.getElementById('tbDisposition').disabled=false;
    }   
    else
    {
        document.getElementById('tbDisposition').disabled=true;
    }  
}
</script>
