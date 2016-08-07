<%@ page language="C#"  CodeFile="ansatiscusclass.aspx.cs"     autoeventwireup="true" inherits="Branch_Stat_AnSatisCusClass" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/frame.css" />
</head>
<body onload="ChkGetImg();" onclick="parent.Sethidden1();">
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
            <td>
            时间:</td>
            <td><asp:TextBox ID="tbDateB" runat="server" CssClass="Wdate" onfocus="WdatePicker();" Width="110"></asp:TextBox></td>
            <td> 至:</td>
            <td><asp:TextBox ID="tbDateE" runat="server" CssClass="Wdate" onfocus="WdatePicker();" Width="110"></asp:TextBox></td>
            <td><input id="btnSch" type="button" value="确定" class="bt1" onclick="ChkGetImg();"  />
            </tr>
          </table>
        </div>
        <div class="ftoolright">

        </div>
        <div class="clearfloat"></div>
    </div>
    <img id="img" src="../../Public/Images/li1.gif" title="客户类别分析" alt="统计图" galleryimg="no"/> 
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
function ChkGetImg()
{
    var num=Math.round(Math.random()*10000);
    var dept=document.getElementById("ddlBranch").value;
    var timeb=document.getElementById("tbDateB").value;
    var timee=document.getElementById("tbDateE").value;
    if(isNull(timeb)){alert("请选择一个起始时间.");document.getElementById("tbDateB").focus();return;}
    if(isNull(timee)){alert("请选择一个结束时间.");document.getElementById("tbDateE").focus();return;}
    var widths=window.screen.availWidth;
    var heights=document.body.clientHeight;
    
    document.getElementById("img").src="../../Public/Handler/PicSatisCusClass.ashx?dept="+escape(dept)+"&timeb="+timeb+"&timee="+timee+"&width="+widths+"&height="+heights+"&c="+num;
}
</script>
