<%@ page language="C#"  CodeFile="repairrcvcal.aspx.cs"     autoeventwireup="true" inherits="Branch_Services_RepairRcvCal" theme="Themes" enableEventValidation="false" %>
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
    <div id="sad" style="width:666px;">
    <div class="fdivs">
    <div class="sdivs" style="padding:5px 0 5px 0px;width:662px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
    <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td>送修类别：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbRepairType" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox>
                </td>
                <td>送修厂商：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbRepairCorp" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>收货日期：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
                </td>
                <td class="red">维修费用：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbRMoney" runat="server" CssClass="pin pbr"></asp:TextBox>
                </td>
            </tr>
        </table>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnAvg" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    </div>
    <div class="divh"></div>
    <div class="fdivs">
    <div class="sdivs" style="width:662px; height:253px; overflow:auto; background:#ffffff;">
     <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
        <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvdata_RowDataBound">
            <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:BoundField HeaderText="序" />
            <asp:BoundField HeaderText="服务单号" DataField="BillID" />
            <asp:BoundField HeaderText="发货日期" DataField="RepairSndDate" DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="false" />
            <asp:TemplateField HeaderText="维修费用" HeaderStyle-ForeColor="#ff0000">
                <ItemTemplate>
                    <asp:TextBox ID="tbCost" runat="server" Text='<%# Eval("Cost") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="机器型号" DataField="ProductModel" />
            <asp:BoundField HeaderText="序列号1" DataField="ProductSN1" />
            <asp:BoundField HeaderText="品牌" DataField="ProductBrand" />
            <asp:BoundField HeaderText="类别" DataField="ProductClass" />
            <asp:TemplateField HeaderText="备注">
                <ItemTemplate>
                    <asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Text='<%# Eval("Remark") %>' Width="200" BorderWidth="0" ReadOnly="true"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnAvg" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="right">
                <asp:Button ID="btnAvg" runat="server" Text="平均分配" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnAvg_Click"/>
                <asp:Button ID="btnSave" runat="server" Text="确定" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnSave_Click"/>
                <input id="btnClose" type="button" value="取消" class="bt1" onclick="parent.CloseDialog();" />
            </td>
        </tr>
    </table>
    </div>
    </div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/menu.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
function ChkSave()
{
    if(isNull($("tbDate").value))
    {
        window.alert("操作失败！收货日期不能为空");
        $("tbDate").focus();
        return false
    }
    if(isNull($("tbRMoney").value))
    {
        window.alert("操作失败！维修费用不能为空");
        $("tbRMoney").focus();
        return false
    }
    if(!isMoney($("tbRMoney").value))
    {
        window.alert("操作失败！维修费用格式不正确");
        $("tbRMoney").focus();
        return false
    }
}
</script>

