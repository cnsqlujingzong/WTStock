<%@ page language="C#"  CodeFile="nolist.aspx.cs"     autoeventwireup="true" inherits="Branch_System_NOList" theme="Themes" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sd" style="width:604px;">
        <div class="fdiv" style="width:604px;">
        <div class="sdiv" style="padding:0px; overflow:auto; height:170px; border-top:none;background:#fff;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
         <ContentTemplate>
        <asp:GridView ID="GridView1" runat="server" SkinID="gv4" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="id" DataField="id" />
                <asp:BoundField HeaderText="序" />
                <asp:BoundField HeaderText="单据类型" DataField="Type" />
                <asp:BoundField HeaderText="单据代号" DataField="Code" />
                <asp:BoundField HeaderText="编号方式" DataField="Style" />
                <asp:BoundField HeaderText="分隔符" DataField="Tally" />
                <asp:BoundField HeaderText="起始编号" DataField="BeginNO" />
                <asp:BoundField HeaderText="例子" DataField="Model" />
            </Columns>
        </asp:GridView>
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
        <span style="display:none;">
            <asp:Button ID="btnRef" runat="server" Text="btnRef" OnClick="btnRef_Click" /></span>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnRef" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
        </div>
    </div>
    </div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
function ChkID(id)
{
    ClrBaseID(id);
}

function EidtNO()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("请选择一条记录后操作！");
    }else
    {
        parent.ShowDialog1(400, 178, 'System/NOMod.aspx?id='+id, '修改');
    }
}
</script>
