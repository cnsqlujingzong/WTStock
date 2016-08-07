<%@ page language="C#"  CodeFile="troubleclassadm.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Basic_TroubleClassAdm" enableEventValidation="false" %>
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
    <div id="sa1s" style="width:586px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="conditional" ChildrenAsTriggers="false">
    <ContentTemplate>
        <div class="fdiv">
        <div class="sdiv2">
            <asp:TreeView ID="TreeView1" runat="server" ShowLines="True" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                <SelectedNodeStyle BackColor="#7d8abe" BorderColor="White" />
            </asp:TreeView>
        </div>
        </div>
    </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdds" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnMod" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="TreeView1" EventName="SelectedNodeChanged" />
        </Triggers>
    </asp:UpdatePanel>
   <div class="divh"></div>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="fdiv">
        <div class="sdiv">
            <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                    <td>
                        分类名：
                    </td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbName" runat="server" CssClass="pin" Width="150"></asp:TextBox>
                    </td>
                    <td>排序：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbArray" runat="server" CssClass="pin" Width="60"></asp:TextBox></td>
                    <td>
                        <asp:HiddenField ID="hfDepth" runat="server" Value="0" />
                        <asp:HiddenField ID="hfValuePath" runat="server" />
                        <asp:HiddenField ID="hfTemp" runat="server" />
                        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
                        <asp:HiddenField ID="hfFather" runat="server" Value="-1" />
                    </td>
                </tr>
            </table>
        </div>
        </div>
        <div class="divh"></div>
        <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:Button ID="btnAdds" runat="server" ToolTip="新建分类" Text="新建分类" CssClass="bt1" OnClientClick="if(ChkAdds()==false)return false;"  UseSubmitBehavior="false" OnClick="btnAdds_Click" />
                <asp:Button ID="btnAdd" runat="server" ToolTip="新建子类" Text="新建子类" CssClass="bt1" OnClientClick="if(ChkAdd()==false)return false;"  UseSubmitBehavior="false" OnClick="btnAdd_Click" />
                <asp:Button ID="btnMod" runat="server" ToolTip="修改" Text="修改"  CssClass="bt1" OnClientClick="if(ChkMod()==false)return false;" UseSubmitBehavior="false" OnClick="btnMod_Click" />
                <asp:Button ID="btnDel" runat="server" ToolTip="删除" Text="删除"  CssClass="bt1" OnClientClick="if(ChkDel('故障类别')==false)return false;" OnClick="btnDel_Click" UseSubmitBehavior="false" />
            </td>
            <td align="right">
                <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog();"/>
            </td>
        </tr>
        </table>
      </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="TreeView1" EventName="SelectedNodeChanged" />
            <asp:AsyncPostBackTrigger ControlID="btnAdds" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnMod" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
    </div>
    </div>
    </div> 
    </form>
</body>
</html>

<script language="javascript" type="text/javascript" src="../../Public/Script/menu.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
function ChkAdds()
{
    if(document.getElementById("btnAdds").value=="保存")
    {
        if(ChkSave()==false)
            return false;
    }
}

function ChkAdd()
{
    if(document.getElementById("hfRecID").value=="-1")
    {
        alert("请选择一条分类后操作！");
        return false;
    }
    if(document.getElementById("btnAdd").value=="保存")
      {
            if(ChkSave()==false)
                return false;
      }
}

function ChkMod()
{
    if(document.getElementById("hfRecID").value=="-1")
    {
        alert("请选择一条分类后操作！");
        return false;
    }
    if(document.getElementById("btnMod").value=="保存")
    {
        if(ChkSave()==false)
            return false;
    }
}

function ChkSave()
{
    if(isNull($("tbName").value))
    {
        window.alert("操作失败！分类名不能为空");
        $("tbName").focus();
        return false
    }
        if(!isNull($("tbArray").value))
    {
        if(!isDigit($("tbArray").value))
        {
            window.alert("排序必须为数字.");
            $("tbArray").select();
            return false
        }
    }
}

function ChkFocus()
{
    $("tbName").select();
}

</script>
