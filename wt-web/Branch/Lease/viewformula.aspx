<%@ page language="C#"  CodeFile="viewformula.aspx.cs"     autoeventwireup="true" inherits="Branch_Lease_ViewFormula" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:386px;">
    <div class="fdivs" style="width:384px; height:238px;">
    <div class="sdivs"  style="width:382px; height:236px;">
      <asp:GridView ID="gvdata" runat="server" SkinID="gv3" AutoGenerateColumns="False" OnRowDataBound="gvdata_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="��"/>
                <asp:BoundField HeaderText="��ʼ����" DataField="StartQty" />
                <asp:BoundField HeaderText="��ֹ����" DataField="EndQty" />
                <asp:BoundField HeaderText="����" DataField="Price" />
            </Columns>
        </asp:GridView>
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
        <asp:HiddenField ID="hfFormula" runat="server" />
    </div>
    </div>
    <div class="divh">
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                
            </td>
            <td align="right">
                <input id="btnClose" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog<%=Str_F %>();" />
            </td>
        </tr>
    </table>
    </div>
    </div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog<%=Str_F %>();}catch(e){}}}
</script>
