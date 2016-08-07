<%@ page language="C#"  CodeFile="devconfadd.aspx.cs"     autoeventwireup="true" inherits="Branch_Customer_DevConfAdd" theme="Themes" enableEventValidation="false" %>
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
    <div id="sa" style="width:666px;">
    <div class="fdiv">
    <div class="sdiv2" style="height:290px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting">
        <Columns>
            <asp:BoundField HeaderText="序"/>
            <asp:TemplateField HeaderText="名称">
                <ItemTemplate>
                    <asp:TextBox ID="tbName" runat="server" Text='<%# Eval("_Name") %>' Width="80"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="参数">
                <ItemTemplate>
                    <asp:TextBox ID="tbParameter" runat="server" Text='<%# Eval("Parameter") %>' Width="80"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="序列号">
                <ItemTemplate>
                    <asp:TextBox ID="tbSN" runat="server" Text='<%# Eval("SN") %>' Width="80"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="保修期">
                <ItemTemplate>
                    <asp:TextBox ID="tbPeriod" runat="server" Text='<%# Eval("MaintenancePeriod") %>' Width="80"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="截止日期">
                <ItemTemplate>
                    <asp:TextBox ID="tbMaintenanceEnd" runat="server" Text='<%# Eval("MaintenanceEnd") %>' Width="80"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="购买日期">
                <ItemTemplate>
                    <asp:TextBox ID="tbBuyDate" runat="server" Text='<%# Eval("BuyDate") %>' Width="80" ></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="备注">
                <ItemTemplate>
                    <asp:TextBox ID="tbRemark" runat="server" Text='<%# Eval("Remark") %>' Width="100"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="删除">
                <ItemTemplate>
                    <asp:LinkButton ID="lbDel" TabIndex="-1" runat="server" CausesValidation="False"  CommandName="Delete" Text="删除" style="color:#0000ff;"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:HiddenField ID="hfID" runat="server" />
    <asp:HiddenField ID="hfRecID" runat="server" />
        <span style="display:none;">
           <asp:Button ID="btnSure" runat="server" Text="...." UseSubmitBehavior="false" OnClick="btnSure_Click" />
           <asp:Button ID="btnId" runat="server" Text="...." UseSubmitBehavior="false" OnClick="btnId_Click" />
        </span>
    </ContentTemplate>
        <Triggers>
           <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    </div>
    </div>
    <div class="divh"></div>
    <div class="fdiv">
    <div class="sdiv">
    <table cellpadding="0" cellspacing="0" class="tb3">
        <tr>
            <td>产品类别：</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbCon" runat="server" CssClass="pin" Width="160" onkeydown="EnterTextBox(event, this);" ToolTip="输入产品类别"></asp:TextBox>
            </td>
            <td style="padding-left:5px;">
                <input id="btnSltTemp" type="button" value="选择配置" class="bt1" onclick="parent.ShowDialog1(800, 520, 'Basic/SltDevConfItem.aspx', '选择配置');"/>
            </td>
            <td style="padding-left:10px;">
                <asp:Button ID="btnAdd" runat="server" Text="添加" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnAdd_Click"/>
            </td>
        </tr>
    </table>
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td><span class="si1">若手工输入产品类别，输入完成后回车</span></td>
        <td align="right">
            <asp:Button ID="btnSave" runat="server" Text="保存" UseSubmitBehavior="false" CssClass="bt1" OnClick="btnSave_Click" />
            <asp:Button ID="btnClean" runat="server" Text="清空" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkClean()==false)return false;" OnClick="btnClean_Click"/>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
var processtip=1;
function EnterTextBox(event, obj)
{
    if(event.keyCode == 13&&!isNull(obj.value))
    {
        if(!isNull(obj.value))
        {
            $("btnSure").click();
        }
    }
}
function ChkClean()
{
    return confirm("确认要清空明细数据吗？"); 
}
</script>
