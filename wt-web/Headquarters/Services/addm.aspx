<%@ page language="C#"  CodeFile="addm.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Services_AddM" theme="themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:786px;">
    <div class="fdivs" style="height:316px; width:784px;">
    <div class="sdivs" style="height:314px; width:782px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <ContentTemplate>
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView2_RowDataBound" OnRowDeleting="GridView2_RowDeleting">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="GoodsID" />
                <asp:BoundField HeaderText="UnitID" DataField="UnitID" />
                <asp:BoundField HeaderText="序" />
                <asp:BoundField HeaderText="产品编号" DataField="GoodsNO" />
                <asp:BoundField HeaderText="名称" DataField="_Name" />
                <asp:BoundField HeaderText="规格" DataField="Spec" />
                <asp:BoundField HeaderText="品牌" DataField="ProductBrand" />
                <asp:BoundField HeaderText="单位" DataField="Unit" />
                <asp:TemplateField HeaderText="数量">
                    <ItemTemplate>
                        <asp:TextBox ID="tbQty" runat="server" Text='<%# Eval("Qty") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                        <asp:TextBox ID="tbSN" runat="server" Text='<%# Eval("SN") %>' style="display:none;" ></asp:TextBox>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="序列号" />
                <asp:TemplateField HeaderText="单价">
                    <ItemTemplate>
                        <asp:TextBox ID="tbPrice" runat="server" Text='<%# Eval("Price") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                        <input id="btnsch" name="btnsch" type="button" value="" runat="server" class="sch_btn" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="税率">
                    <ItemTemplate>
                        <asp:TextBox ID="tbTaxRate" runat="server" Text='<%# Eval("TaxRate") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="税额">
                    <ItemTemplate>
                        <asp:Label ID="lbTaxAmount" runat="server" Text='<%# Eval("TaxAmount") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="金额">
                    <ItemTemplate>
                        <asp:Label ID="lbAmount" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="保修期">
                    <ItemTemplate>
                        <asp:TextBox ID="tbPeriod" runat="server" Text='<%# Eval("MaintenancePeriod") %>' Width="100" CssClass="tbstyle"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="截止日期">
                    <ItemTemplate>
                        <asp:TextBox ID="tbPeriodEndDate" runat="server" Text='<%# Eval("PeriodEndDate") %>' Width="100" CssClass="tbstyle"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="结算方式">
                    <ItemTemplate>
                        <asp:TextBox ID="tbChargeStyle" runat="server" Text='<%# Eval("ChargeStyle") %>' style="display:none;"></asp:TextBox>
                        <asp:DropDownList ID="ddlChargeStyle" runat="server">
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="是否外购">
                    <ItemTemplate>
                        <asp:CheckBox ID="cbOutSourcing" runat="server" Checked='<%# Eval("OutSourcing") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="外购单价">
                    <ItemTemplate>
                        <asp:TextBox ID="tbOutPrice" runat="server" Text='<%# Eval("OutCostPrice") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
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
            <asp:HiddenField ID="hfRecIDs" runat="server" Value="-1" />
            <asp:HiddenField ID="hfName" runat="server" />
            <asp:HiddenField ID="hfUnitID" runat="server" />
            <asp:HiddenField ID="hfCusID" runat="server" />
             <span style="display:none;">
             <asp:Button ID="btnId" runat="server" Text="..." OnClick="btnId_Click" />
             <asp:Button ID="btnSure" runat="server" Text="..." OnClick="btnSure_Click" />
             <asp:Button ID="btnSltUnit" runat="server" Text="..." OnClick="btnSltUnit_Click" />
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
                    <asp:ListItem Value="BarCode">按条码</asp:ListItem>
                    <asp:ListItem Value="GoodsNO">按编号</asp:ListItem>
                </asp:DropDownList>
            </td>
                <td>
                   <asp:TextBox ID="tbConInfo" runat="server" CssClass="pin" onkeydown="EnterTextBoxGds(event, this);" ToolTip="输入完成后回车添加"></asp:TextBox>
                </td>
                <td>
                    <input id="tbSltGoods" type="button" value="选择产品" class="bt1" onclick="parent.ShowDialog1(800, 520, 'Stock/SltGoods.aspx', '选择产品');" />
                </td>
            </tr>
        </table>
    </div>
    
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="right">
            <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnAdd_Click"/>
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
<script language="javascript" type="text/javascript">
var processtip=1;
function ChkID(id)
{
    ClrID(id);
}

function ChkIDs(id,unitid)
{
    ClrID4(id);
    $("hfUnitID").value=unitid;
}

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

function EditSN(goodsid,unitid,SN,nums)
{
   var gdsnum=$(nums).value;
   if(gdsnum<=0)
   {
        alert("操作失败！请输入产品数量");
        return false;
   }
  
   parent.ShowDialog1(400, 300, 'Stock/EditSN.aspx?iflag=2&goodsid='+goodsid+'&unitid='+unitid+'&snvalue='+escape($(SN).value)+'&snid='+SN+'&gdsnum='+escape(gdsnum), '编辑序列号');
}

</script>
