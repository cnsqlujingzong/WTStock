<%@ page language="C#"  CodeFile="viewsn.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Stock_ViewSN" theme="Themes" enableEventValidation="false" %>
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
    <div id="sad" style="width:386px;">
    <div class="fdivs" style="width:384px; height:245px;">
    <div class="sdivs"  style="width:382px; height:243px;">
      <asp:GridView ID="gvdata" runat="server" SkinID="gv3" AutoGenerateColumns="False" OnRowDataBound="gvdata_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="序"/>
                <asp:BoundField HeaderText="序列号" DataField="SN" />
            </Columns>
        </asp:GridView>
        <asp:HiddenField ID="hfSN" runat="server" />
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="right">
                <input id="btnPrint" runat="server" type="button" value="打印" class="bt1" onclick="PrintSN();" />
                <input id="btnClose" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog1();" />
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
function PrintSN()
{
    if($("hfSN").value=="")
    {
        window.alert("操作失败！没有序列号需要打印");
        return;
    }
    
    var w=(window.screen.width-750)/2;
    var num=Math.round(Math.random()*10000);
    window.open("../Print/interface_print.aspx?type=Print&obj=CPSN&ids=" + escape($("hfSN").value)+"&a="+num,"","width=750,height=580,toolbar=no,left="+w+",top=20,location=no,directories=yes,status=yes,menubar=yes,resizable=yes,scrollbars=yes");
}
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog1();}catch(e){}}}
</script>
