<%@ page language="C#"  CodeFile="user.aspx.cs"     autoeventwireup="true" inherits="Web_User" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="public/css/mysub.css" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div id="idiv">
    <div class="item"><span style="padding-right:30px;">�ҵ���Ϣ</span><span id="span_info" style="display:none;"></span>
        <asp:Label ID="lbInfo" runat="server" style="color:#ff0000;"></asp:Label>
    </div>
    <div class="tool"></div>
    </div>
    
    <!-- -->
        <div style="padding-top:10px; padding-left:20px;">
        <p class="pt1">ע�����Ϣ</p> 
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td style="color:#800000;">��Ա���ƣ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbname" runat="server" CssClass="pin" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>��λ���ƣ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbcorp" runat="server" CssClass="pin"></asp:TextBox></td>
                <td align="right">��ϵ�ˣ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbman" runat="server" CssClass="pin"></asp:TextBox></td>
                <td align="right">Email��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbemail" runat="server" CssClass="pin"></asp:TextBox></td>
                
            </tr>
            <tr>
                <td>��ϵ�绰��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbatel" runat="server" CssClass="pin" ></asp:TextBox></td>
                <td align="right">��ַ��</td>
                <td style="padding-left:0px;" colspan="3"><asp:TextBox ID="tbaadr" runat="server" CssClass="pin" Width="326"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td colspan="3" style="padding-left:0px;">
                <asp:Button ID="btnAdd" runat="server" Text="�����޸�" CssClass="bt1 bt8" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnAdd_Click"  />
                </td>
            </tr>
        </table>
        
        <p class="pt1">�����Ŀͻ�</p>      
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td style="color:#800000;">�ͻ����ƣ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbCusName" runat="server" CssClass="pin"></asp:TextBox>
                    <asp:HiddenField ID="hfCusID" runat="server" />
                </td>
                <td align="right">��ϵ�ˣ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin"></asp:TextBox></td>
                <td>��ϵ�绰��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>��������</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbArea" runat="server" CssClass="pin"></asp:TextBox></td>
                <td>��ϵ��ַ��</td>
                <td style="padding-left:0px;" colspan="3"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin" Width="341"></asp:TextBox>
                </td>
            </tr>     
        </table> 
    <!--end-->
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="public/script/common.js"></script>
<script language="javascript" type="text/javascript" src="public/script/validator.js"></script>
<script language="javascript" type="text/javascript">
function ChkSave()
{
   if(isNull($("tbcorp").value))
   {
        alert("��λ���Ʋ���Ϊ��.");
        $("tbcorp").select();
        return false;
   }
      if(isNull($("tbman").value))
   {
        alert("��ϵ�˲���Ϊ��.");
        $("tbman").select();
        return false;
   }
      if(isNull($("tbatel").value))
   {
        alert("��ϵ�绰����Ϊ��.");
        $("tbatel").select();
        return false;
   }
      if(isNull($("tbaadr").value))
   {
        alert("��ַ����Ϊ��.");
        $("tbaadr").select();
        return false;
   }
   
         if(!isMail($("tbemail").value))
   {
        alert("Email��ʽ����ȷ.");
        $("tbemail").select();
        return false;
   }
}

// ����Ƿ�Ϊ��Ч��email
function isMail(str)
{
  var myReg = /^[_\-\.a-zA-Z0-9]+@([_\-a-zA-Z0-9]+\.)+[a-zA-Z0-9]{2,3}$/;
  if(myReg.test(str)) 
  	return true;
  return false;
}
</script>
