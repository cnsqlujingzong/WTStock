<%@ page language="C#"  CodeFile="goodspriceadjustupdate.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Stock_GoodsPriceAdjustUpdate" enableEventValidation="false" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:326px;">
    <div class="fdivs">
    <div class="sdivs" style="padding:3px 0 3px 0px;width:322px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
    <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
            <td> 
                   调价公式：
               </td>
           </tr>
           <tr>
               <td> 
                   <asp:DropDownList ID="ddlpricename1" runat="server" Width="70px" CssClass="pindl">
                       <asp:ListItem Value="1">零售价</asp:ListItem>
                       <asp:ListItem Value="2">进货价</asp:ListItem>
                       <asp:ListItem Value="3">内部价</asp:ListItem>
                       <asp:ListItem Value="4">旧货价</asp:ListItem>
                       <asp:ListItem Value="5">替代价</asp:ListItem>
                       <asp:ListItem Value="6">列表价</asp:ListItem>
                   </asp:DropDownList>
                   <asp:Label ID="Label1" runat="server" Text="="></asp:Label>
                   <asp:DropDownList ID="ddlpricename2" runat="server" Width="70px" CssClass="pindl">
                       <asp:ListItem Value="1">零售价</asp:ListItem>
                       <asp:ListItem Value="2">进货价</asp:ListItem>
                       <asp:ListItem Value="3">内部价</asp:ListItem>
                       <asp:ListItem Value="4">旧货价</asp:ListItem>
                       <asp:ListItem Value="5">替代价</asp:ListItem>
                       <asp:ListItem Value="6">列表价</asp:ListItem>
                   </asp:DropDownList>
                   <asp:DropDownList ID="ddlseparator" runat="server" Width="50px" CssClass="pindl">
                   <asp:ListItem></asp:ListItem>
                       <asp:ListItem Value="1">+</asp:ListItem>
                       <asp:ListItem Value="2">*</asp:ListItem>
                   </asp:DropDownList>
                   <asp:TextBox ID="tboxPrice" runat="server" Text="1.2" CssClass="pin" Width="60"></asp:TextBox>
               </td>
           </tr>
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
                <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnAdd_Click"  />
                <input id="btnClose" type="button" value="取消" class="bt1" onclick="parent.CloseDialog1();" />
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
    var strno = document.getElementById('tboxPrice').value;
    if(!isMoney(strno))
    {
            alert('运算值必须为数字格式');
            $("tboxPrice").focus();
            return false;
    }
}
</script>
