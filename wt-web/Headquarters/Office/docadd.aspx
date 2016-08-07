<%@ page language="C#"  CodeFile="docadd.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Office_DocAdd" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body onload="ChkSetFocus('tbName');">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="main">
        <div class="maincon">
        <div id="sa" style="width:486px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                    <td>文档分类：</td>
                    <td colspan="2" style="padding-left:0px;">
                        <asp:DropDownList ID="ddlClass" runat="server" CssClass="pindl">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td>文档摘要：</td>
                    <td colspan="2" style="padding-left:0px;"><asp:TextBox ID="tbName" runat="server" CssClass="pin" Width="330"></asp:TextBox></td>
                </tr>
                <tr>
                <td></td>
                <td style="padding-left:0px;"><a href="#" style="color:#0000ff" title="上传文档" onclick="ChkUpload();">上传文档</a>
                    <asp:HiddenField ID="hfUpload" runat="server" />
                    <asp:HiddenField ID="hfFileSize" runat="server" />
                </td>
                <td>
                    <div id="dUpload"></div>
                </td>
            </tr>
            </table>
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>
            </div>
            </div>
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
function ChkAdd()
{
    if(isNull($("tbName").value))
    {
        window.alert("操作失败！请填写文档摘要");
        $("tbName").focus();
        return false
    }
     if($("dUpload").innerHTML=="")
     {
         if(!confirm("该文档还没有上传，是否保存？"))
         {
            return false;
         }
     }
}

function ChkImg()
{
    $("gdiv").innerHTML="";
    $("hfDoc").value="";
}

function ChkUpload()
{   
    if($("dUpload").innerHTML=="")
    {
        parent.ShowDialog1(600, 380, 'Office/DocUpload.aspx', '上传文档');
    }
    else
    {
        if(confirm("已经存在一个文档，继续上传将替换该文档，是否继续？"))
        {
            parent.ShowDialog1(600, 380, 'Office/DocUpload.aspx', '上传文档');   
        }
    }
}
</script>
