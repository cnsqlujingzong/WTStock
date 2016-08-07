<%@ page language="C#"  CodeFile="printtmp.aspx.cs"     autoeventwireup="true" inherits="Branch_Tool_Printtmp" theme="Themes" enableEventValidation="false" %>
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
    <div id="sad" style="width:586px;">
        <div class="fdiv">
        <div class="sdiv" style="height:250px;padding:0px;background:#fff; overflow:auto;">
        <asp:GridView ID="GridView1" runat="server" SkinID="gv4" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" Width="90%">
            <Columns>
                <asp:BoundField HeaderText="序" DataField="RecID" />
                <asp:BoundField HeaderText="单据名称" DataField="BillName" />
                <asp:BoundField HeaderText="模板名称" DataField="TmpName" />
            </Columns>
        </asp:GridView>
                
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
        <asp:HiddenField ID="hfTName" runat="server" Value="" />
        </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>
            <input id="btnMod" type="button" value="编辑" class="bt1" onclick="ChkTmp('Modify');"/>
            <input id="Button3" type="button" value="下载" class="bt1" onclick="ChkTmp('Download');"/>
            <input id="Button2" type="button" value="还原" class="bt1" onclick="ChkTmp('Reduce');"/>
        </td>
        <td align="right">
            <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog();"/> 
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
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
function ChkID(id)
{
    ClrBaseID(id);
}
function ChkTmp(act)
{
    var aname=$("hfTName").value;
    var arr=aname.split(".");
    if(arr[0]==""){
        alert("请选择一个模板.");
        return;
    }
    var w=(window.screen.width-750)/2;
    var num=Math.round(Math.random()*10000);
    window.open("../../Headquarters/Print/interface_print.aspx?type="+act+"&obj="+arr[0]+"&a="+num,"","width=1024,height=768,toolbar=no,left="+w+",top=20,location=no,directories=yes,status=yes,menubar=yes,resizable=yes,scrollbars=yes");
}
function ChkTname(tname)
{
    $("hfTName").value=tname;
}
</script>
