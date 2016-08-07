<%@ page language="C#"  CodeFile="trackadd.aspx.cs"     autoeventwireup="true" inherits="Branch_Customer_TrackAdd" enableEventValidation="false" %>
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
    <div id="sa" style="width:456px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
        <div class="fdiv">
        <div class="sdiv">
        <table cellpadding="0" cellspacing="0" class="tb3">
            <tr>
                <td align="right">
                    跟踪日期：
                </td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
                </td>
                <td align="right">
                    跟踪人：
                </td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    联系人：
                </td>
                <td style="padding-left:0px;">
                <div class="isinDiv">
                    <asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin pinin"></asp:TextBox>
                    <asp:DropDownList ID="ddlLinkMan" runat="server" onchange="document.getElementById('tbLinkMan').value=this.options[this.selectedIndex].text" CssClass="pininsl" AutoPostBack="True" OnSelectedIndexChanged="ddlLinkMan_SelectedIndexChanged">
                        <asp:ListItem></asp:ListItem>
                      </asp:DropDownList>
                </div>
                </td>
                <td align="right">
                    联系电话：
                </td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbTel" runat="server" CssClass="pin"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="sysred">
                    跟踪内容：
                </td>
                <td style="padding-left:0px;" colspan="3">
                    <asp:TextBox ID="tbContent" runat="server" CssClass="pin" Width="341"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    跟踪方式：
                </td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlTrackStyle" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                <td align="right">
                    跟踪类别：
                </td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlTrackType" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    跟踪结果：
                </td>
                <td style="padding-left:0px; height:86px;" colspan="3">
                    <asp:TextBox ID="tbResult" runat="server" CssClass="pin" Width="341" Height="72" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    下次跟踪：
                </td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbNextDate" runat="server" CssClass="pin" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
                </td>
                <td>
                    不再跟踪：
                </td>
                <td style="padding-left:0px;">
                    <asp:CheckBox ID="cbTrack" runat="server" />
                </td>
            </tr>
         </table>
        </div>
        </div>
        
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>
            <asp:Label ID="lbMod" runat="server"></asp:Label>
        </td>
        <td align="right">
            <asp:Button ID="btnAdd" runat="server" Text="确定" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnAdd_Click" />
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
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/detailslt.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/detail.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
var processtip=1;
function ChkSave()
{
    if(isNull($("tbDate").value))
    {
        window.alert("操作失败！跟踪日期不能为空");
        $("tbDate").focus();
        return false
    }
    
    if($("ddlOperator").value=="-1")
    {
        window.alert("操作失败！跟踪人不能为空");
        $("ddlOperator").focus();
        return false
    }
    if(isNull($("tbTel").value))
    {
        window.alert("操作失败！联系电话不能为空");
        $("tbTel").focus();
        return false
    }
    if(isNull($("tbContent").value))
    {
        window.alert("操作失败！跟踪内容不能为空");
        $("tbContent").focus();
        return false
    }
    if($("ddlTrackStyle").value=="-1")
    {
        window.alert("操作失败！跟踪方式不能为空");
        $("ddlTrackStyle").focus();
        return false
    }
    if($("ddlTrackType").value=="-1")
    {
        window.alert("操作失败！跟踪类别不能为空");
        $("ddlTrackType").focus();
        return false
    }

    if(isNull($("tbResult").value))
    {
        window.alert("操作失败！跟踪结果不能为空");
        $("tbResult").focus();
        return false
    }
}
</script>
