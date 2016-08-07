<%@ page language="C#"  CodeFile="editgdsclass.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Stock_EditGdsClass" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head2" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body onload="aload()">
    <form id="form2" runat="server">
    <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="Div1" style="width:326px;">
    <div class="fdivs">
    <div class="sdivs" style="padding:3px 0 3px 0px;width:322px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
    <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
             <td align="right"><asp:CheckBox ID="cbGoodType" runat="server" onclick="makesGdsClass()" /></td>
             <td align="right">��Ʒ���</td>
             <td style="padding-left:0px;">
                    <div class="isinDiv">
                    <input type="text" id="tbGdsClass" runat="server" class="pin pinin" readonly="readonly" />
                    <select id="slGdsClass" runat="server" onchange="getclassvalue('tbGdsClass',this.options[this.selectedIndex].text);" class="pininsl"></select>
                    </div>
             </td>
            </tr>
            <tr>
                 <td align="right"><asp:CheckBox ID="cbDefaultstock" runat="server" onclick="makesddlDefaultstock()" /></td>
                 <td align="right">Ĭ�ϲֿ⣺</td>
                 <td style="padding-left:0px;">
                                <asp:DropDownList ID="ddlDefaultstock" runat="server"  Width="136px" Height="20px">
                                </asp:DropDownList>
                 </td>    
            </tr>
            <tr>   
                <td align="right"><asp:CheckBox ID="cbbStock" runat="server" onclick="makesddlBStock()" /></td>   
                <td align="right">������棺</td>
                <td style="padding-left:0px; ">
                                <asp:DropDownList ID="ddlBStock" runat="server" Width="136px" Height="20px">
                                <asp:ListItem Value="1">��</asp:ListItem>
                                <asp:ListItem Value="2">��</asp:ListItem>
                                </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right"><asp:CheckBox ID="cbSNTrack" runat="server" onclick="makesddlSNTrack()"/></td>
                <td align="right">���кŸ��٣�</td>
                <td style="padding-left:0px; ">
                                <asp:DropDownList ID="ddlSNTrack" runat="server" Width="136px" Height="20px"  >
                                <asp:ListItem Value="1">��</asp:ListItem>
                                <asp:ListItem Value="2">��</asp:ListItem>
                                </asp:DropDownList>
                </td
                </tr>
            <tr>      
                <td align="right"><asp:CheckBox ID="cbMainTenancePeriod" runat="server" onclick="makesslProt()" /></td>                       
                <td align="right">�����ڣ�</td>
                <td style="padding-left:0px; ">
                            <div class="isinDiv">
                            <input type="text" id="tbProt" runat="server" class="pin pinin"/>
                            <select id="slProt" runat="server" onchange="document.getElementById('tbProt').value=this.options[this.selectedIndex].value" class="pininsl">
                                    <option value="" selected="selected"></option>
                                    <option value="�ޱ���">�ޱ���</option>
                                    <option value="һ����">һ����</option>
                                    <option value="������">������</option>
                                    <option value="������">������</option>
                                    <option value="һ��">һ��</option>
                                    <option value="����">����</option>
                                    <option value="����">����</option>
                                    <option value="����">����</option>
                                    <option value="����">����</option>
                            </select>
                            </div>
                </td></tr>
        </table>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click"  />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="right">
                <asp:Button ID="btnAdd" runat="server" Text="ȷ��" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnAdd_Click"/>
                <input id="Button2" type="button" value="ȡ��" class="bt1" onclick="parent.CloseDialog();" />
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
    if(document.getElementById("cbGoodType").checked==true)
    {
        if($("slGdsClass").value=="0")
        {
            if(confirm("δѡ���Ʒ��������ȷ�����޸Ĳ�Ʒ���Ϊ�գ�����ȡ��������"))
            {
            }
            else
            {        
                return false
            }
        }
    }
    if(document.getElementById("cbDefaultstock").checked==true)
    {
        if($("ddlDefaultstock").value=="-1")
        {
            window.alert("Ĭ�ϲֿⲻ��Ϊ��");
             $("ddlDefaultstock").focus();
            return false
        }
    }
    if(document.getElementById("cbMainTenancePeriod").checked==true)
    {
        if($("slProt").value=="" && $("tbProt").value=="")
        {
            window.alert("����д�����ڣ�");
            return false
        }
    }      
    if (document.getElementById("cbGoodType").checked==false && document.getElementById("cbDefaultstock").checked==false && document.getElementById("cbbStock").checked==false && document.getElementById("cbSNTrack").checked==false && document.getElementById("cbMainTenancePeriod").checked==false)
    {
       window.alert('������ѡ��һ�');
       return false;
    }
}
function aload()
{
    document.getElementById('slGdsClass').disabled=true;
    document.getElementById('slProt').disabled=true;
    document.getElementById("ddlDefaultstock").disabled=true;
    document.getElementById("ddlBStock").disabled=true;
    document.getElementById("ddlSNTrack").disabled=true;
}
function makesGdsClass()
{
    if(document.getElementById("cbGoodType").checked==true)
    {
        document.getElementById('slGdsClass').disabled=false;
    }    
    else
    {
        document.getElementById('slGdsClass').disabled=true;
    }
}
function makesddlDefaultstock()
{
    if(document.getElementById("cbDefaultstock").checked==true)
    {
        document.getElementById('ddlDefaultstock').disabled=false;
    }   
    else
    {
        document.getElementById('ddlDefaultstock').disabled=true;
    } 
}
function makesddlBStock()
{
    if(document.getElementById("cbbStock").checked==true)
    {
        document.getElementById('ddlBStock').disabled=false;
    }    
    else
    {
        document.getElementById('ddlBStock').disabled=true;
    } 
}
function makesddlSNTrack()
{
    if(document.getElementById("cbSNTrack").checked==true)
    {
        document.getElementById('ddlSNTrack').disabled=false;
    }    
    else
    {
        document.getElementById('ddlSNTrack').disabled=true;
    } 
}
function makesslProt()
{
    if(document.getElementById("cbMainTenancePeriod").checked==true)
    {
        document.getElementById('slProt').disabled=false;
    }   
    else
    {
        document.getElementById('slProt').disabled=true;
    }  
}
</script>
