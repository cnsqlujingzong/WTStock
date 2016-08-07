<%@ page language="C#"  CodeFile="sltprice.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Stock_SltPrice" theme="Themes" enableEventValidation="false" %>
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
    <div id="sa" style="width:246px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <div class="fdiv" >
    <div class="sdiv2" style="height:205px;">
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="gvdata_RowDataBound" Width="90%">
        <Columns>
            <asp:BoundField HeaderText="序" />
            <asp:BoundField HeaderText="价格类型" DataField="_Name" />
            <asp:BoundField HeaderText="单价" DataField="Price" HtmlEncode="false" DataFormatString="{0:f0}" />
        </Columns>
    </asp:GridView>
    <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
    <asp:HiddenField ID="hfName" runat="server" />
    </div>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="right">
            <input id="btnAdd" type="button" value="确定" class="bt1" onclick="ChkSltList();"/>
            <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog<%=Str_F %>();"/> 
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
<script language="javascript" type="text/javascript" src="../../Public/Script/detail.js"></script>
<script language="javascript" type="text/javascript">
function ChkID(id,name)
{
    ClrBaseID(id);
    $("hfName").value=name;
}

function ChkSltList()
{
    try{
    parent.<%=Str_Fid %>.$('<%=Str_Price %>').value=$("hfName").value;
    parent.<%=Str_Fid %>.$('<%=Str_Price %>').select();
    }catch(e){alert("系统错误！请刷新后重试");}
    parent.CloseDialog<%=Str_F %>();
}
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog<%=Str_F %>();}catch(e){}}}
</script>
