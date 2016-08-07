<%@ page language="C#"  CodeFile="sltunit.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Stock_SltUnit" theme="Themes" enableEventValidation="false" %>
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
    <div class="sdiv2" style="height:145px;">
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false" Width="90%">
        <Columns>
            <asp:BoundField HeaderText="序" DataField="ID" />
            <asp:BoundField HeaderText="单位" DataField="_Name" />
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
<script language="javascript" type="text/javascript">
function ChkID(id,name)
{
    ClrBaseID(id);
    $("hfName").value=name;
}

function ChkSltList()
{
    var list=document.getElementById("hfRecID").value;
        
    if(list==""||list=="-1")
    {
        alert("操作失败！请选择后操作.");return false;
    }else{
    try{
    parent.<%=Str_Fid %>.$("hfRecIDs").value=list;
    parent.<%=Str_Fid %>.$("hfName").value=$("hfName").value;
    parent.<%=Str_Fid %>.document.getElementById("btnSltUnit").click();
    }catch(e){alert("系统错误！请刷新后重试");}
    parent.CloseDialog<%=Str_F %>();
    }
}
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog<%=Str_F %>();}catch(e){}}}
</script>
