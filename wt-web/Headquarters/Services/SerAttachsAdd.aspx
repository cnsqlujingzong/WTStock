<%@ page language="C#"  CodeFile="SerAttachsAdd.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Services_SerAttachsAdd" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="main">
        <div class="maincon">
        <div id="sa" style="width:436px;">
            <div class="fdiv">
            <div class="sdiv">
            <table cellpadding="0" cellspacing="0" class="tb5">
                    <tr>
                    <td align="right">附件：</td>
                    <td style="padding-left:0px;">
                        <asp:FileUpload ID="FileUpload1" runat="server" style="height:22px; width:300px;" onchange="preview()"/>
                <asp:Button ID="btnUpfile" runat="server" Text="上传"  CssClass="bt1" OnClick="btnUpfile_Click" />
                    </td>
                    </tr>
            </table>
            </div>
            </div>
            
            <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                <asp:Label ID="Label1" runat="server" style="color:#ff0000;"></asp:Label>
            <asp:HiddenField ID="hfPath" runat="server" Value="-1" />
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
    var x = document.getElementById("FileUpload1");
    if(!x || !x.value)
        return;
    var patn = /\.docx$|\.doc$|\.rar$|\.zip$|\.jpg$|\.jpeg$|\.gif$|\.bmp$|\.tiff$|\.pdf$|\.tmp$|\.xls$|\.xlsx$/i;
    if(patn.test(x.value))
    {
        
    }
    else
    {
        alert("只能上传扩展名为.docx .doc .rar .zip .jpg .jpeg .gif .bmp .tiff .pdf .xls .xlsx的附件");
    }
}
</script>
