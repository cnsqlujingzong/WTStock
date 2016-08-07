<%@ page language="C#"  CodeFile="toolbar.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Tool_ToolBar" theme="Themes" enableEventValidation="false" %>
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
    <div id="sad" style="width:626px;">
        <div class="fdiv">
        <div class="sdiv" style="height:420px;padding:0px;background:#fff; overflow:auto;">
        <div style="width:240px; height:418px; overflow:auto; float:left;">
            <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false">
                <Columns>
                    <asp:BoundField HeaderText="选择" DataField="ID" />
                    <asp:BoundField HeaderText="图标" DataField="FieldValue" />
                    <asp:BoundField HeaderText="操作" DataField="FieldText" />
                </Columns>
            </asp:GridView>
            <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
            <asp:HiddenField ID="hfreclist" runat="server" />
        </div>
        <div id="lncn" class="uw" style="height:418px"></div>
        <div style="width:80px; height:418px; overflow:auto; float:left;">
            <table cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td height="418" width="80" align="center" valign="middle">
                        <asp:Button ID="btnGo" runat="server" Text=">>" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnGo_Click" />
                    </td>
                </tr>
            </table>
            
        </div>
        <div id="Div1" class="uw" style="height:418px"></div>
        <div style="width:290px; height:418px; overflow:auto; float:left;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="gvdatauser" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvdatauser_RowDataBound" OnRowDeleting="gvdatauser_RowDeleting">
                        <Columns>
                            <asp:BoundField HeaderText="图标" DataField="Img" />
                            <asp:BoundField HeaderText="操作" DataField="Oper" />
                            <asp:TemplateField HeaderText="排序">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbArray" runat="server" Text='<%# Eval("Array") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="删除">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbDel" TabIndex="-1" runat="server" CausesValidation="False"  CommandName="Delete" Text="删除" style="color:#0000ff;"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:HiddenField ID="hfdellist" runat="server" />
                </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnGo" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>
        </div>
        
        </div>
        </div>
        <div class="divh"></div>        
        <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:Label ID="lbMod" runat="server" CssClass="si1" Text="勾选后双击选择"></asp:Label>
            </td>
            <td align="right">
                <asp:Button ID="btnClean" runat="server" Text="清除定义" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkConf()==false)return false;" OnClick="btnClean_Click"/>
                <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnAdd_Click"/>
                <input id="btnClose" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog();" />
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
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
function ChkID(id)
{
    ClrID(id);
}
function ChkGo()
{
    document.getElementById("btnGo").click();
}

function ChkConf()
{
    if(confirm("确定要清楚该工具栏定义吗？"))
    {
        return true;
    }else
    return false;
}
</script>
