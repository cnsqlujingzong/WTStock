<%@ page language="C#"  CodeFile="snstockin.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Stock_SNStockIN" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/tab.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="divh"></div>
    <div class="ftool2">
        <div id="mytabs" style="padding-left:2px;">
            <span class="tabs_activeleft"></span>
            <span class="tabs_active" >入库明细</span>
            <span class="tabs_activeright"></span>
        </div>
    </div>
    <div class="fdivs" style="height:233px;width:800px; border-top:none;">
        <div class="sdivs" style="height:231px;width:797px;border-top:none; background:#ffffff;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
          <ContentTemplate>
            <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvdata_RowDataBound" OnRowDeleting="gvdata_RowDeleting">
                <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="序" />
                <asp:BoundField HeaderText="业务类别" DataField="Type" />
                <asp:BoundField HeaderText="入库单号" DataField="BillID" />
                <asp:BoundField HeaderText="入库原因" DataField="Reason" />
                <asp:BoundField HeaderText="业务编号" DataField="OperationID" />
                <asp:BoundField HeaderText="产品编号" DataField="GoodsNO" />
                <asp:BoundField HeaderText="名称" DataField="_Name" />
                <asp:BoundField HeaderText="规格" DataField="Spec" />
                <asp:BoundField HeaderText="数量" DataField="Qty" />
                <asp:TemplateField HeaderText="删除">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDel" TabIndex="-1" runat="server" CausesValidation="False"  CommandName="Delete" Text="删除" style="color:#0000ff;"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
            </asp:GridView>
              <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
            <asp:HiddenField ID="hfreclist" runat="server" />
            <span style="display:none;">
                 <asp:Button ID="btnId" runat="server" Text="..." OnClick="btnId_Click" />
            </span>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
    </div>
    <div class="divh"></div>
    <div class="ftool2">
        <div id="mytabs2" style="padding-left:2px;">
            <span class="tabs_activeleft"></span>
            <span class="tabs_active" >入库序列号</span>
            <span class="tabs_activeright"></span>
        </div>
    </div>
    <div class="fdivs" style="height:163px;width:800px;border-top:none;">
        <div class="sdivs" style="height:161px;width:797px;border-top:none; background:#ffffff;">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="gvSN" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvSN_RowDataBound">
                <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="序" />
                <asp:TemplateField HeaderText="序列号">
                    <ItemTemplate>
                        <asp:TextBox ID="tbSN" Text='<%# Eval("SN") %>' runat="server" Width="200" ></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="系统默认">
                    <ItemTemplate>
                        <asp:CheckBox ID="cbSys" runat="server" Checked=<%# Eval("bSys") %> />
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <span style="display:none;">
                <asp:Button ID="btnShow" runat="server" Text="..." OnClick="btnShow_Click" />
            </span>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="gvdata" EventName="RowDeleting" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
    </div>
    <div class="ftool">
    <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
        <tr>
            <td align="right" style="padding-right:7px;">
                <asp:CheckBox ID="cbSys" runat="server" Text="全部系统默认" style="color:#0000ff;"/>
                <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnAdd_Click" />
                <input id="tbSlt" type="button" value="入库明细" class="bt1" onclick="parent.ShowDialog1(800, 500, 'Stock/SltStockIN.aspx', '选择入库明细');" />
                <asp:Button ID="btnClean" runat="server" Text="清空" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkClean()==false)return false;" OnClick="btnClean_Click"/>
                <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog();" />
            </td>
        </tr>
    </table>
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
    ClrBaseID(id);
    $("btnShow").click();
}
function ChkSysSN(bsys,sn)
{
    if($(bsys).checked)
    {
        $(sn).disabled=true;
    }
    else
    {
        $(sn).disabled=false;
    }
}

function ChkClean()
{
    if(confirm("确定要清空当前数据吗？"))
    {
        return true;
    }
    else
    {
        return false;
    }
}
</script>
