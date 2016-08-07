<%@ page language="C#"  CodeFile="nomod.aspx.cs"     autoeventwireup="true" inherits="Headquarters_System_NOMod" enableEventValidation="false" %>
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
    <div id="sa" style="width:386px;">
    <div class="fdiv">
    <div class="sdiv">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
    <ContentTemplate>
    <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td>单据类型：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbType" runat="server" CssClass="pin" Width="100" ReadOnly="true"></asp:TextBox></td>
            <td>单据代号：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbCode" runat="server" CssClass="pin" Width="100" onblur="getMoedl();"></asp:TextBox></td>
            
        </tr>
        <tr>
            <td>编号方式：</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlStyle" runat="server" CssClass="pindl" Width="106" onchange="getMoedl();">
                    <asp:ListItem Value="">自定义</asp:ListItem>
                    <asp:ListItem Value="年">年</asp:ListItem>
                    <asp:ListItem Value="年月">年月</asp:ListItem>
                    <asp:ListItem Value="月年">月年</asp:ListItem>
                    <asp:ListItem Value="年月日">年月日</asp:ListItem>
                    <asp:ListItem Value="月日年">月日年</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td align="right">分割符：</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlTally" runat="server" CssClass="pindl" Width="106" onchange="getMoedl();">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="-">-</asp:ListItem>
                    <asp:ListItem Value=".">.</asp:ListItem>
                </asp:DropDownList>
           </td>
        </tr>
        <tr>
            <td>起始编号：</td>
            <td style="padding-left:0px;" colspan="3">
                <asp:DropDownList ID="ddlFrist" runat="server" CssClass="pindl" Width="282" onchange="getMoedl();">
                    <asp:ListItem Value="001">001</asp:ListItem>
                    <asp:ListItem Value="0001">0001</asp:ListItem>
                    <asp:ListItem Value="00001">00001</asp:ListItem>
                    <asp:ListItem Value="000001">000001</asp:ListItem>
                    <asp:ListItem Value="0000001">0000001</asp:ListItem>
                    <asp:ListItem Value="00000001">00000001</asp:ListItem>
                    <asp:ListItem Value="000000001">000000001</asp:ListItem>
                    <asp:ListItem Value="0000000001">0000000001</asp:ListItem>
                    <asp:ListItem Value="00000000001">00000000001</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">例子：</td>
            <td style="padding-left:0px;" colspan="3"><asp:TextBox ID="tbModel" runat="server" CssClass="pin" Width="276"></asp:TextBox></td>
        </tr>
    </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td><asp:Label ID="lbMod" runat="server"></asp:Label></td>
        <td align="right">
            <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnSave_Click"/>
            <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog1();" />
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
function getMoedl()
{
    var mcenter;
    var years=new Date().getYear().toString().substr(2,4);
    var months=new Date().getMonth()+1;
    var days=new Date().getDate().toString();
    if($("ddlStyle").value=="年")
        mcenter=years;
        
     if($("ddlStyle").value=="年月")
        {
            if(parseInt(months)>9)
                mcenter=years+months;
             else
                mcenter=years+"0"+months;
        }
    if($("ddlStyle").value=="月年")
        {
            if(parseInt(months)>9)
                mcenter=months+years;
             else
                mcenter="0"+months+years;
        }
    
    if($("ddlStyle").value=="年月日")
       {
            if(parseInt(months)<10)
                months="0"+months;
                
             if(parseInt(days)<10)
                months="0"+days;
                
            mcenter=years+months+days;
       }
     if($("ddlStyle").value=="月日年")
        {
            if(parseInt(months)<10)
                months="0"+months;
                
             if(parseInt(days)<10)
                months="0"+days;

             mcenter=months+days+years;
        }
        
    if($("ddlStyle").value!="")
        $("tbModel").value=$("tbCode").value+$("ddlTally").value+mcenter+$("ddlTally").value+$("ddlFrist").value;
    else
        $("tbModel").value=$("tbCode").value+$("ddlTally").value+$("ddlFrist").value;
}
</script>
