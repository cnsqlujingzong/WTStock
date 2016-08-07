<%@ page language="C#"  CodeFile="smssndcbat.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Tool_SmsSndCBat" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/tab.css" />
</head>
<body onload="ChkParm();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sa22" style="width:486px;">
    <div class="ftool2">
        <div id="mytabs">
            <span id="tabs_l1"></span>
            <span id="tabs1" onclick="ChkTab('1');">短信内容</span>
            <span id="tabs_r1"></span>
            <span id="tabs_l2"></span>
            <span id="tabs2" onclick="ChkTab('2');">发送列表</span>
            <span id="tabs_r2"></span>
        </div>
    </div>
    <div id="info1" style="height:200px;background:#ECE9D8;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                    <td>群发：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin" style="color:#0000ff; font-weight:bold;" Width="180"></asp:TextBox></td>
                    <td style="padding-left:30px;">模版：</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlTmp" runat="server" CssClass="pindl" AutoPostBack="True" OnSelectedIndexChanged="ddlTmp_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="height:165px">
                        <asp:TextBox ID="tbSmsContent" runat="server" TextMode="MultiLine" Height="150" Width="434"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSnd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="jsPager" EventName="pagechanged" />
        <asp:AsyncPostBackTrigger ControlID="ddlSendTo" EventName="SelectedIndexChanged" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div id="info2" style="height:200px;background:#ECE9D8;">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
        <div style="border-bottom:#808080 1px solid;">
           <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td>
                <asp:DropDownList ID="ddlSendTo" runat="server" OnSelectedIndexChanged="ddlSendTo_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Value="1">仅发送给客户</asp:ListItem>
                <asp:ListItem Value="2">仅发送给联系人</asp:ListItem>
                <asp:ListItem Value="0">发送给客户及联系人</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:TextBox ID="tbSchWord" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnSch" runat="server" Text="搜索" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnSch_Click" />
            </td>
            </tr>
           </table>
        </div>
        <div style="width:100%;height:143px;overflow:auto;">
        <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false">
        <Columns>
        <asp:BoundField DataField="t" />
        <asp:BoundField DataField="lid" />
        <asp:TemplateField>
        <ItemTemplate>
            <input type="checkbox" id="ck<%#Eval("t") %><%#Eval("lid") %>" style="display:none;" <%#Eval("bexcept").ToString().Trim().Equals("1")?"checked='checked'":"" %> />
            <div id="d<%#Eval("t") %><%#Eval("lid") %>" onclick="chkRemove('<%#Eval("t") %><%#Eval("lid") %>');" onmouseover="chkOver('<%#Eval("t") %><%#Eval("lid") %>')" onmouseout="chkOut('<%#Eval("t") %><%#Eval("lid") %>')" class="<%#Eval("bexcept").ToString().Trim().Equals("1")?"dOff":"dOn" %>"></div>
        </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="cusname" HeaderText="客户" />
        <asp:BoundField DataField="linkman" HeaderText="联系人" />
        <asp:BoundField DataField="tel" HeaderText="号码" />
        </Columns>
        </asp:GridView>
        </div>
            <asp:HiddenField ID="hfSndCount" runat="server" Value="" />
        <table cellpadding="0" cellspacing="0" class="pages">
        <tr>
            <td><webdiyer:aspnetpager id="jsPager" runat="server" onpagechanged="jsPager_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="跳转:" /></td>
            <td style="padding-left:8px;"><asp:Label ID="lbPage" runat="server" ToolTip="当页显示数"></asp:Label></td>
            <td style="padding-left:8px;"><asp:Label ID="lbCountText" runat="server" ToolTip="总记录数" Text="总记录:"></asp:Label><asp:Label ID="lbCount" runat="server" ToolTip="总记录数"></asp:Label></td>
        </tr>
    </table>
        </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>
            <asp:HiddenField ID="hfSql" runat="server" />
            <asp:HiddenField ID="hfExcept" runat="server" Value="," />
            <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
        </td>
        <td align="right">
            <asp:Button ID="btnSnd" runat="server" Text="发送" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnSnd_Click"/>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript">
var tabnum=3;
function ChkParm()
{
    //document.getElementById("tbTel").value="发送到"+parent.<%=Str_Fid %>.document.getElementById("lbCount").innerHTML+"个客户.";
    document.getElementById("hfSql").value=parent.<%=Str_Fid %>.document.getElementById("hfSql").value;
    $("btnSch").click();
}
function chkRemove(id)
{
    var o=$("ck"+id);
    var oDiv=$("d"+id);
    var elist=$("hfExcept").value;
    var strid=","+id+",";
    var nowcount=parseInt($("hfSndCount").value,10);
    if(o.checked)
    {
        if(elist.indexOf(strid)>=0)
        {
            elist=elist.replace(strid,",")
        }
        o.checked=false;
        oDiv.className="dOn";
        $(id).className="tdRow4";
        nowcount=nowcount+1;
    }else
    {
        if(elist.indexOf(strid)<0)
        {
            elist+=id+",";
        }
        oDiv.className="dOff";
        o.checked=true;
        $(id).className="trcross";
        nowcount=nowcount-1;
    }
    $("hfSndCount").value=nowcount;
    $("tbTel").value="发送到"+nowcount+"个客户.";
    $("hfExcept").value=elist;
}
function chkOver(id)
{
    var o=$("ck"+id);
    var oDiv=$("d"+id);
    if(o.checked)
    {
        oDiv.className="dOffOver";
    }else
    {
        oDiv.className="dOnOver";
    }
}
function chkOut(id)
{
    var o=$("ck"+id);
    var oDiv=$("d"+id);
    if(o.checked)
    {
        oDiv.className="dOff";
    }else
    {
        oDiv.className="dOn";
    }
}
ChkParm()
</script>
