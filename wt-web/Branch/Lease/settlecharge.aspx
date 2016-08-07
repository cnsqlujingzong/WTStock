<%@ page language="C#"  CodeFile="settlecharge.aspx.cs"     autoeventwireup="true" inherits="Branch_Lease_SettleCharge" theme="Themes" enableEventValidation="false" %>
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
    <div id="sad" style="width:626px;">
    <div class="fdivs" style="width:624px;">
    <div class="sdivs" style="padding:3px 0 3px 0px;width:622px;">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
      <table cellpadding="0" cellspacing="0" class="tb5">
            <tr>
                <td>基础月租：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbRent" runat="server" CssClass="pinb" Width="122" ReadOnly="true"></asp:TextBox>
                </td>
                <td align="right">超张费：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbSuperZhangFee" runat="server" CssClass="pinb" Width="122" ReadOnly="true"></asp:TextBox>
                </td>
                <td>合计应收：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbRec" runat="server" CssClass="pinb" Width="122" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>优惠金额</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbDiscount" runat="server" CssClass="pin" Width="120" onblur="calcAmount();" onfocus="select();"></asp:TextBox>
                </td>
                <td class="red">现收金额：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbInCash" runat="server" CssClass="pin" Width="120" onblur="calcAmount2();" onfocus="select();"></asp:TextBox>
                </td>
                <td>结算帐户：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlAccount" runat="server" CssClass="pindl" Width="126">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>结算日期：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbDate" runat="server" CssClass="Wdate" onfocus="new WdatePicker();" Width="122"></asp:TextBox>
                </td>
                <td align="right">收款人：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl" Width="126">
                    </asp:DropDownList>
                </td>
                <td>结算方式：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlChargeStyle" runat="server" CssClass="pindl" Width="126">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>开票日期：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbInvoiceDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="122"></asp:TextBox>
                </td>
                <td align="right">开票金额：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbInvoiceAmount" runat="server" CssClass="pin" Width="120"></asp:TextBox>
                </td>
                <td>发票号码：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbInvoiceNO" runat="server" CssClass="pin" Width="120"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>发票类别：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlInvoiceClass" runat="server" CssClass="pindl" Width="126">
                    </asp:DropDownList>
                </td>
                <td>收支项目：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlItem" runat="server" CssClass="pindl" Width="126">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">备注：</td>
                <td colspan="5" style="padding-left:0px;">
                    <asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="520"></asp:TextBox>
                </td>
            </tr>
       </table>
       </ContentTemplate>
       <Triggers>
       <asp:AsyncPostBackTrigger ControlID ="gvdata" EventName ="RowDeleting" />
       </Triggers>
        </asp:UpdatePanel>
      </div>
      </div>
      
       <div class="divh"></div>
        <div class="fdivs" style="width:624px; height:218px;">
        <div class="sdivs" style="width:622px; height:216px; overflow:auto; background:#ffffff;">
      <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvdata_RowDataBound" OnRowDeleting = "gvdata_RowDeleting">
                <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="序" />
                <asp:TemplateField HeaderText="剔除">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbDel" TabIndex="-1" runat="server" CausesValidation="False"  CommandName="Delete" Text="剔除" style="color:#0000ff;"></asp:LinkButton>
                            </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="结算单号" DataField="OperationID" />
                <asp:BoundField HeaderText="日期" DataField="_Date" />
                <asp:BoundField HeaderText="经办人" DataField="Operator" />
                <asp:BoundField HeaderText="起始日期" DataField="StartDate" />
                <asp:BoundField HeaderText="终止日期" DataField="EndDate" />
                <asp:BoundField HeaderText="合计应收" DataField="dRec" />
                <asp:TemplateField HeaderText="优惠金额" >
                    <ItemTemplate>
                        <asp:TextBox ID="tbDiscount" runat="server" Text='0' CssClass="tbstyle" Width="100" onfocus="select();"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="现收金额" HeaderStyle-ForeColor="#ff0000">
                    <ItemTemplate>
                        <asp:TextBox ID="tbInCash" runat="server" Text='<%#Eval("InCash") %>' CssClass="tbstyle" Width="100" onfocus="select();"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                </Columns>
            </asp:GridView>
            </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
        </div>
        </div>
        
        <div class="divh"></div>
        <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="right">
                <asp:Button ID="btnAdd" runat="server" Text="确定" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
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
var oldValue;
function ChkAdd()
{
    if(isNull($("tbInCash").value))
    {
        window.alert("操作失败！现结金额不能为空");
        $("tbInCash").focus();
        return false
    }
    if(!isMoney($("tbInCash").value))
    {
        window.alert("现结金额格式不正确");
        $("tbInCash").focus();
        return false
    }
    if(parseFloat($("tbInCash").value)>0)
    {
        if($("ddlAccount").value=="-1")
        {
            window.alert("操作失败！结算帐户不能为空");
            $("ddlAccount").focus();
            return false
        }
    }
    
    if(isNull($("tbDate").value))
    {
        window.alert("操作失败！结算日期不能为空");
        $("tbDate").focus();
        return false
    }
    
   if($("ddlOperator").value=="-1")
    {
        window.alert("操作失败！收款人不能为空");
        $("ddlOperator").focus();
        return false
    }
}
function calcAmount()
{
    var recAmount = parseFloat($("tbRec").value);
    var discountAmount = parseFloat($("tbDiscount").value);
    if(recAmount != NaN && discountAmount != NaN)
    {
        document.getElementById("tbInCash").value = recAmount - discountAmount;
    }
}
function calcAmount2()
{
    var recAmount = parseFloat($("tbRec").value);
    var incashAmount = parseFloat($("tbInCash").value);
    if(recAmount != NaN && incashAmount != NaN)
    {
        document.getElementById("tbDiscount").value = recAmount - incashAmount;
    }
}
function calcAmount1(obj,rec,obj1)
{
    obj.value = rec - parseFloat(obj1.value);
}
function calcAmount3(obj,rec,obj1)
{
    obj1.value = rec - parseFloat(obj.value);
}
</script>
