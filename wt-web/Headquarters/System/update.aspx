<%@ page language="C#"  CodeFile="update.aspx.cs"     autoeventwireup="true" inherits="Headquarters_System_Update" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
   <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sa" style="width:486px;">
    <div class="fdiv">
    <div class="sdiv" style="padding:5px 0 5px 5px;">
        <div style="background:url(../../Public/Images/logo.gif) no-repeat left center">
            <table cellpadding="0" cellspacing="0" class="tb3" style="margin-left:140px;">
                <tr>
                    <td style="height:20px;"><span>当前版本：</span><asp:Label ID="lbVer" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="height:30px;">
                         <div style="width:302px; height:20px; border:1px #000 solid; padding:1px;">
                            <div style=" background:#0000ff; height:20px; width:0;" id="bar"></div>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="color:#999;">在线升级取决网速原因，需要一点时间，请耐心等待.
                    </td>
                </tr>
            </table>
        </div>
        <textarea id="tbupdate" cols="20" rows="2" style="width:460px; height:50px; background:#e9e7e3; color:#ff0000;" runat="server">
        可升级版本:
        </textarea>
        <asp:HiddenField ID="hfver" runat="server" />
        </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="right">
            <asp:Button ID="btnUpdate" runat="server" Text="升级" OnClientClick="BeginBar();" CssClass="bt1" OnClick="btnUpdate_Click" />
            <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog();" />
        </td>
    </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
            <asp:HiddenField ID="hfu" runat="server" />
        </ContentTemplate>
        <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
    </div>
    </div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
var i=0;
var ti;
function ShowBar()
{
    i=i+1;
    if(i<=300)
    {
        document.getElementById("bar").style.width=i+"px";
    }
    else
    {
        document.getElementById("bar").style.width=302+"px";
        clearInterval(ti);
        if(document.getElementById("hfu").value=="1")
        {
            alert("升级成功，系统需要重新登录.");
            parent.CloseDialog();
            
        }
        else
        {
            alert("升级失败.");
            
        }
    }
}
function BeginBar()
{
    document.getElementById("hfu").value="";
    document.getElementById("bar").style.width="1px";
    i=0;
    ti=window.setInterval('ShowBar();',100);
}
</script>
