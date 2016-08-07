<%@ page language="C#"  CodeFile="uploadpic.aspx.cs"    autoeventwireup="true" inherits="Public_Editor_UploadPic" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>图片上传</title>
    <link rel="Stylesheet" type="text/css" href="../Style/sub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
        <div class="maincon">
        <div id="sad" style="width:586px;">
        <div class="fdiv">
        <div class="sdiv" style="height:315px;">
            <div style="margin:10px;">
                <asp:FileUpload ID="FileUpload1" runat="server" Width="300" Height="23" onchange="preview();" />
                <asp:Button ID="btnadd" runat="server" Text="上传" CssClass="bt1" OnClientClick="return chkadd();" OnClick="btnadd_Click" />
                <br />
                <asp:Label ID="lbNotice" runat="server" style="color:#ff0000;"></asp:Label>
                <br />
                <img id="Img1" width="200" alt=""/>
            </div>
        </div>
        </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>            
            <asp:HiddenField ID="hfPath" runat="server" Value="-1" />
            <span style="color:#666;">(*点浏览选择要上传图片，再点上传，图片文件大小最好不要超过1MB)</span> 
        </td>
        <td align="right">
            <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog1();"/> 
        </td>
    </tr>
    </table>
    </div>
    </div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
function $() 
{ 
    var elements = new Array(); 
    for (var i = 0; i < arguments.length; i++) 
    { 
        var element = arguments[i]; 
        if (typeof element == 'string') 
            element = document.getElementById(element); 
        if(arguments.length == 1) 
            return element; 
        elements.push(element); 
    } 
    return elements; 
}
function preview()
{
    var x = $("FileUpload1");
    var y = $("Img1");
    if(!x || !x.value || !y)
        return;
    var patn = /\.jpg$|\.jpeg$|\.gif$/i;
    if(patn.test(x.value))
    {
        y.src = "file://localhost/" + x.value;
    }
    else
    {
        alert("您选择的不是图像文件.");
        x.outerHTML=x.outerHTML;
    }
}
function chkadd()
{
    if($("FileUpload1").value==""){alert("请选择要上传的图片.");$("FileUpload1").focus();return false;}
}
</script>
