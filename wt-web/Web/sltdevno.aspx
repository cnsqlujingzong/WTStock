<%@ page language="C#"  CodeFile="sltdevno.aspx.cs"     autoeventwireup="true" inherits="Web_SltDevNO" theme="themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>选择机器故障</title>
    <link rel="Stylesheet" type="text/css" href="../Public/Style/sub.css" />
    <link rel="Stylesheet" type="text/css" href="../Public/Style/page.css" />
    
    <style type="text/css">
        .tb3 td{ padding-left:3px; color:#fff;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="tool" style="height:28px;">
        <table cellpadding="0" cellspacing="0" border="0" class="tb3">
            <tr>
                <td>
                    <asp:DropDownList ID="ddlkey" runat="server" CssClass="slt1">
                    <asp:ListItem Value="Summary">=按故障名称查询=</asp:ListItem>
                    <asp:ListItem Value="-1">=查询全部=</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox ID="tbcon" runat="server" CssClass="in1"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnsch" runat="server" Text="查 询" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnsch_Click"/>
                    <input id="btnAdd" type="button" value="确定" class="bt1" onclick="ChkPass();" /></td>
                    
            </tr>
        </table>
        </div>
        <div style="padding-left:2px;">
        <div class="fdiv">
        <div class="sdiv" style="height:430px; width:410px; overflow:auto; background:#ffffff; padding:0px;">
        <asp:GridView ID="GridView1" runat="server" SkinID="gv1" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" EnableViewState="false" ShowFooter="true">
            <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="故障名称" DataField="Summary" />
            </Columns>
        </asp:GridView>
        <div id="d_page" runat="server">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td align="right" style=" padding-right:5px;">
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <td><webdiyer:aspnetpager id="jsPager" runat="server" onpagechanged="jsPager_PageChanged"  CssClass="tdPage"  ShowInputBox="Never" /></td>
                            <td style="padding-left:8px;"><asp:Label ID="lbPage" runat="server" ToolTip="当页显示数"></asp:Label></td>
                            <td style="padding-left:8px;"><asp:Label ID="lbCount" runat="server" ToolTip="总记录数"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        </div>
        <div id="d_empty" runat="server"><p class="p1" runat="server" id="p1">无相应的机器档案!</p></div>
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
        <asp:HiddenField ID="hfcusid" runat="server" />
        <asp:HiddenField ID="hfFault" runat="server" Value="" />
        </div>
        </div>
        </div>
        </ContentTemplate>
        </asp:UpdatePanel>
        <div style=" height:5px; font-size:0px;"></div>
        <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td><span class="si2">双击记录进行选择</span></td>
        </tr>
        </table>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
function ChkID(id)
{
    ClrID(id);
}

function ChkValue(Fault)
{
    $("hfFault").value=Fault;
}

function ChkPass()
{
    if($("hfRecID").value==""||$("hfRecID").value=="-1")
    {
        alert("请点击选择一条记录后操作！");
        return;
    }
    opener.$("tbFault").value +=$("hfFault").value+"    ";
 
    window.close();
}
</script>
