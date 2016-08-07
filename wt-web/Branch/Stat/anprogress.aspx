<%@ page language="C#"  CodeFile="anprogress.aspx.cs"     autoeventwireup="true" inherits="Branch_Stat_AnProgress" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/frame.css" />
</head>
<body onload="ChkGetImg()" onclick="parent.Sethidden1();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="ftool">
        <div class="ftoolleft">
          <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td class="red">网点：</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlBranch" runat="server" CssClass="pindl" Width="100">
                </asp:DropDownList>
            </td>
            <td>年份:
                <asp:DropDownList ID="ddlYear" runat="server">
                </asp:DropDownList>
            </td>
            <td>月份:
                <asp:DropDownList ID="ddlMonth" runat="server">
                </asp:DropDownList>
            </td>
            <td><input id="btnSch" type="button" value="确定" class="bt1" onclick="ChkGetImg();"  />
            </tr>
          </table>
        </div>
        <div class="ftoolright">

        </div>
        <div class="clearfloat"></div>
    </div>
    <img id="img" src="../../Public/Images/li1.gif" title="工作进度分析" alt="统计图" galleryimg="no"/> 
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
function ChkGetImg()
{
    var num=Math.round(Math.random()*10000);
    var dept=document.getElementById("ddlBranch").value;
    var year=document.getElementById("ddlYear").value;
    var month=document.getElementById("ddlMonth").value;
    var widths=window.screen.availWidth;
    var heights=document.body.clientHeight;
    document.getElementById("img").src="../../Public/Handler/PicProgress.ashx?dept="+dept+"&year="+year+"&month="+month+"&width="+widths+"&height="+heights+"&c="+num;
}
</script>
