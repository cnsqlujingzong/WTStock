<%@ page language="C#"  CodeFile="addo.aspx.cs"     autoeventwireup="true" inherits="Branch_Services_AddO" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:486px;">
    <div class="fdivs" style="width:484px; height:40px;">
    <div class="sdivs" style="width:482px; height:38px;">
    <div class="divh"></div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" class="tb5">
                <tr>
                     <td align="right">报价日期：</td>
                    <td style="padding-left:0px;">
                    <asp:TextBox ID="tbDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
                    </td>
                    <td align="right">
                    报价人：</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl">
                        </asp:DropDownList>
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
    <div class="fdivs" style="height:206px; width:484px;">
    <div class="sdivs" style="height:204px; width:482px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <ContentTemplate>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView2_RowDataBound" OnRowDeleting="GridView2_RowDeleting">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ItemID" />
                <asp:BoundField HeaderText="序" />
                <asp:BoundField HeaderText="名称" DataField="_Name" />
                <asp:TemplateField HeaderText="金额">
                    <ItemTemplate>
                        <asp:TextBox ID="tbPrice" runat="server" Text='<%# Eval("Total") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="客户确认">
                    <ItemTemplate>
                        <asp:CheckBox ID="cbCusConf" runat="server" Checked='<%# Eval("bCusConf") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="备注">
                    <ItemTemplate>
                        <asp:TextBox ID="tbRemark" runat="server" Text='<%# Eval("Remark") %>' Width="170" CssClass="tbstyle"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="删除">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDel" TabIndex="-1" runat="server" CausesValidation="False"  CommandName="Delete" Text="删除" style="color:#0000ff;"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
            <asp:HiddenField ID="hfdellist1" runat="server" />
            <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
            <asp:HiddenField ID="hfreclist" runat="server" />
             <span style="display:none;">
             <asp:Button ID="btnId" runat="server" Text="..." OnClick="btnId_Click" />
             <asp:Button ID="btnSure" runat="server" Text="..." OnClick="btnSure_Click" />
             </span>
        </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>    
    </div>
    </div>
    <div id="Div5" class="devtemadd">
        <table cellpadding="0" cellspacing="0" class="tb4">
            <tr>
             <td style="padding-left:15px;">
                <asp:DropDownList ID="ddlSchFld" runat="server" CssClass="pindl" Width="70">
                    <asp:ListItem Value="_Name">按名称</asp:ListItem>
                </asp:DropDownList>
            </td>
                <td>
                   <asp:TextBox ID="tbConInfo" runat="server" CssClass="pin" onkeydown="EnterTextBoxGds(event, this);" ToolTip="输入完成后回车添加"></asp:TextBox>
                </td>
                <td>
                    <input id="tbSltGoods" type="button" value="选择项目" class="bt1" onclick="parent.ShowDialog1(400, 510, 'Basic/SltOfferItem.aspx', '选择报价项目');" />
                </td>
            </tr>
        </table>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/detailslt.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/detail.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
var processtip=1;
function EnterTextBoxGds(event, obj)
{
    if(event.keyCode == 13&&!isNull(obj.value))
    {
        if(!isNull(obj.value))
        {
            $("btnSure").click();
        }
    }
}
function ChkAdd()
{
    if(isNull($("tbDate").value))
    {
        window.alert("操作失败！报价日期不能为空");
        $("tbDate").focus();
        return false
    }
    if($("ddlOperator").value=="-1")
    {
        window.alert("操作失败！报价人不能为空");
        $("ddlOperator").focus();
        return false
    }
}

</script>
