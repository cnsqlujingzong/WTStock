<%@ page language="C#"  CodeFile="upload.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Lease_UpLoad" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional">
            <ContentTemplate>
            
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="main">
        <div class="maincon">
        <div id="sad" style="width:586px;">
        <div class="fdiv">
        <div class="sdiv" style="height:315px;">
            <div style="margin:10px;">
                <asp:FileUpload ID="FileUpload1" runat="server" style="height:22px; width:300px;" onchange="preview()"/>
                <asp:Button ID="btnUpfile" runat="server" Text="�ϴ�"  CssClass="bt1" OnClick="btnUpfile_Click" />
                <br />
                <asp:Label ID="Label1" runat="server" style="color:#ff0000;"></asp:Label>
                <br />
            </div>
        </div>
        </div>   

    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>            
            <asp:HiddenField ID="hfPath" runat="server" Value="-1" />
            <span style="color:#666;">(*�����ѡ��Ҫ�ϴ����ļ����ٵ��ϴ�)</span> 
        </td>
        <td align="right">
            <input id="btnCls" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog<%=Str_F %>();"/> 
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
        alert("ֻ���ϴ���չ��Ϊ.docx .doc .rar .zip .jpg .jpeg .gif .bmp .tiff .pdf .xls .xlsx�ĸ���");
    }
}
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog<%=Str_F %>();}catch(e){}}}
window.onload=function(){document.getElementById("btnCls").focus();}
</script>
