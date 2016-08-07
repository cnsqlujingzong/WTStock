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
                <td align="right">客户类别：</td>
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
                <td align="right">客户状态：</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:DropDownList ID="ddlStatus" runat="server" Width="136px">
                        </asp:DropDownList>
                    </div>
                 </td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="CheckBox3" runat="server" onclick="check_c()"/></td>
                <td align="right">客户区域：</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                          <asp:DropDownList ID="ddlArea" runat="server" Width="136px">
                        </asp:DropDownList>
                    </div>
                 </td>
            </tr>
            <tr>
            <td><asp:CheckBox ID="CheckBox4" runat="server" onclick="check_d()"/></td>
                <td align="right">会员级别：</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:DropDownList ID="ddlMember" runat="server" Width="136px">
                        </asp:DropDownList>
                    </div>
                 </td>
            </tr>
                        <tr>
                        <td><asp:CheckBox ID="CheckBox5" runat="server" onclick="check_e()"/></td>
                <td align="right">回访标志：</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:DropDownList ID="ddlSeeBack" runat="server" Width="136px">
                        <asp:ListItem Value=""> </asp:ListItem>
                            <asp:ListItem Value="1">是</asp:ListItem>
                            <asp:ListItem Value="0">否</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                 </td>
            </tr>
                        <tr>
                        <td><asp:CheckBox ID="CheckBox6" runat="server" onclick="check_f()"/></td>
                <td align="right">跟踪标志：</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:DropDownList ID="ddlbTrace" runat="server" Width="136px">
                        <asp:ListItem Value=""> </asp:ListItem>
                            <asp:ListItem Value="1">是</asp:ListItem>
                            <asp:ListItem Value="0">否</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                 </td>
            </tr>
            <tr>
                        <td><asp:CheckBox ID="CheckBox7" runat="server" onclick="check_g()"/></td>
                <td align="right">业务员：</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:DropDownList ID="ddlSeller" runat="server" Width="136px">
                        </asp:DropDownList>
                    </div>
                 </td>
            </tr>
            <tr>
                <td><asp:CheckBox ID="CheckBox8" runat="server" onclick="check_h()"/></td>
                <td align="right">是否停用：</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:DropDownList ID="ddlStop" runat="server" Width="136px">
                        <asp:ListItem Value=""></asp:ListItem>
                            <asp:ListItem Value="1">是</asp:ListItem>
                            <asp:ListItem Value="2">否</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                 </td>
            </tr>
            <td><asp:CheckBox ID="CheckBox9" runat="server" onclick="check_i()"/></td>
                <td align="right">信誉额度：</td>
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
                <asp:Button ID="btnAdd" runat="server" Text="确定" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnAdd_Click"/>
                <input id="btnClose" type="button" value="取消" class="bt1" onclick="parent.CloseDialog();" />
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
            if(confirm("未选择客户类别，若点击确定将修改客户类别为空，否则取消操作！"))
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
             if(confirm("未选择客户状态，若点击确定将修改'客户状态'为空，否则取消操作！"))
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
            if(confirm("未选择'区域'，若点击确定将修改'区域'为空，否则取消操作！"))
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
            if(confirm("未选择'会员级别'，若点击确定将修改'会员级别'为空，否则取消操作！"))
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
            if(confirm("未选择'是否回访'，若点击确定将修改'是否回访'为否，否则取消操作！"))
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
            if(confirm("未选择'是否跟踪'，若点击确定将修改'是否跟踪'为否，否则取消操作！"))
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
            window.alert("信誉额度必须为数字");
            $("tbDisposition").foucs();
            return false;
        }
    }
    if (document.getElementById("CheckBox1").checked==false && document.getElementById("CheckBox2").checked==false && document.getElementById("CheckBox3").checked==false && document.getElementById("CheckBox4").checked==false && document.getElementById("CheckBox5").checked==false&& document.getElementById("CheckBox6").checked==false&& document.getElementById("CheckBox7").checked==false&& document.getElementById("CheckBox8").checked==false&& document.getElementById("CheckBox9").checked==false)
    {
       window.alert('请至少选择一项！');
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
