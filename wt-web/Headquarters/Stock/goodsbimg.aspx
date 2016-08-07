<%@ page language="C#"  CodeFile="goodsbimg.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Stock_GoodsBImg" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body onload="preview();">
    <form id="form1" runat="server">
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:586px;">
        <div class="fdiv">
        <div class="sdiv" style="height:315px;">
            <div>
                <div id="dpic"></div>
            </div>
        </div>
        </div>   

        <div class="divh"></div>
        <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="right">
                <input id="btnCls" type="button" value="¹Ø±Õ" class="bt1" onclick="parent.CloseDialog1();"/> 
            </td>
        </tr>
        </table>
     </div>
    </div>
    </div>     
    </form>
</body>
</html>

<script type="text/javascript" language="javascript">
function preview()
{
    var m=parent.iframeDialog.document.getElementById("hfImgName").value;
    document.getElementById("dpic").innerHTML="<a href='../Images/" + m + "' target='_blank'><img src='../Images/" + m + "' border='0' /></a>";
    document.getElementById("btnCls").focus();
}
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog1();}catch(e){}}}
</script>
