<%@ page language="C#"  CodeFile="sltunitqty.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Stock_SltUnitQty" theme="Themes" enableEventValidation="false" %>
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
    <div id="sa" style="width:246px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <div class="fdiv" >
    <div class="sdiv2" style="height:145px;">
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="gvdata_RowDataBound" Width="90%">
        <Columns>
            <asp:BoundField HeaderText="序" DataField="ID" />
            <asp:BoundField HeaderText="单位名称" DataField="_Name" />
            <asp:TemplateField HeaderText="数量">
                <ItemTemplate>
                    <asp:TextBox ID="tbQty" runat="server" Width="50" BorderWidth="0" Height="15" onfocus="select();"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="单位关系" DataField="UnitRelation" HtmlEncode="false" DataFormatString="{0:f0}" />
        </Columns>
    </asp:GridView>
    <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
    <asp:HiddenField ID="hfName" runat="server" />
    </div>
    </div>
    </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnConf" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="right">
            <asp:Button ID="btnConf" runat="server" Text="确定" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnConf_Click" />
            <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog<%=Str_F %>();"/> 
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
<script language="javascript" type="text/javascript" src="../../Public/Script/detail.js"></script>
<script language="javascript" type="text/javascript">
function ChkID(id)
{
    ClrID4(id);
}

function ChkSltList(qty)
{
    try{
    parent.<%=Str_Fid %>.$('<%=Str_tbqty %>').value=cc(qty.toString());
//    parent.<%=Str_Fid %>.$('<%=Str_tbqty %>').setAttribute("oldNum",qty);
    parent.<%=Str_Fid %>.$('<%=Str_tbqty %>').select();
    }catch(e){alert("系统错误！请刷新后重试");}
    parent.CloseDialog<%=Str_F %>();
}
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog<%=Str_F %>();}catch(e){}}}
</script>
