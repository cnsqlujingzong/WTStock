<%@ page language="C#"  CodeFile="manualhedge.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Financial_ManualHedge" theme="Themes" enableEventValidation="false" %>
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
    <div id="sad" style="width:846px;">
        <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td align="right">
            对冲金额：
            </td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbAmount" runat="server" CssClass="pin"></asp:TextBox></td>
            <td>对冲帐户：</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlAccount" runat="server" CssClass="pindl">
                </asp:DropDownList>
            </td>
            <td style="color:#666; padding-left:5px;">*帐款对冲后将自动生成收款单和付款单 *对冲帐户即为收款帐户和付款帐户</td>
        </tr>
        </table>
        
        <div class="divh"></div>
        <div class="fdivs" style="height:200px; width:846px">
            <div class="sdivs" style="height:198px; width:844px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvdata_RowDataBound" OnRowDeleting="gvdata_RowDeleting">
                            <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="序" />
                            <asp:BoundField HeaderText="单据类别" DataField="Type" />
                            <asp:BoundField HeaderText="单据编号" DataField="BillID" />
                            <asp:BoundField HeaderText="日期" DataField="_Date" />
                            <asp:BoundField HeaderText="经办人" DataField="Operator" />
                            <asp:BoundField HeaderText="总金额" DataField="Amount" />
                            <asp:BoundField HeaderText="已结算金额" DataField="HaveAmount" />
                            <asp:BoundField HeaderText="未结算金额" DataField="NotChargeAmount" />
                            <asp:TemplateField HeaderText="本次结算" HeaderStyle-ForeColor="#ff0000">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbChargeMoney" runat="server" Text='<%# Eval("ChargeAmount") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="备注">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbRemark" runat="server" BorderWidth="0" Text='<%# Eval("Remark") %>' ReadOnly="true" Width="200" onfocus="select();"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="删除">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbDel" TabIndex="-1" runat="server" CausesValidation="False"  CommandName="Delete" Text="删除" style="color:#0000ff;"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
                        <asp:HiddenField ID="hfreclist" runat="server" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnAuto" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnSltID" EventName="Click" />
                    </Triggers>
                 </asp:UpdatePanel>
            </div>
        </div>
        <div class="divh"></div>
        
        <div class="tdiv">
        <table cellpadding="0" cellspacing="0" class="tb3">
            <tr>
                <td style="padding-left:15px; height:29px;">
                 <input id="Button1" type="button" value="选择单据" class="bt1" onclick="SltBill('1');" />
                </td>
            </tr>
        </table>
        </div>
        
        <div class="divh"></div>
        <div class="fdivs" style="height:200px; width:846px">
            <div class="sdivs" style="height:198px; width:844px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="gvdata2" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvdata2_RowDataBound" OnRowDeleting="gvdata2_RowDeleting">
                            <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="序" />
                            <asp:BoundField HeaderText="单据类别" DataField="Type" />
                            <asp:BoundField HeaderText="单据编号" DataField="BillID" />
                            <asp:BoundField HeaderText="日期" DataField="_Date" />
                            <asp:BoundField HeaderText="经办人" DataField="Operator" />
                            <asp:BoundField HeaderText="总金额" DataField="Amount" />
                            <asp:BoundField HeaderText="已结算金额" DataField="HaveAmount" />
                            <asp:BoundField HeaderText="未结算金额" DataField="NotChargeAmount" />
                            <asp:TemplateField HeaderText="本次结算" HeaderStyle-ForeColor="#ff0000">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbChargeMoney" runat="server" Text='<%# Eval("ChargeAmount") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="备注">
                                <ItemTemplate>
                                    <asp:TextBox ID="tbRemark" runat="server" BorderWidth="0" Text='<%# Eval("Remark") %>' ReadOnly="true" Width="200" onfocus="select();"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="删除">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbDel" TabIndex="-1" runat="server" CausesValidation="False"  CommandName="Delete" Text="删除" style="color:#0000ff;"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:HiddenField ID="hfRecID2" runat="server" Value="-1" />
                        <asp:HiddenField ID="hfreclist2" runat="server" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnSltID" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnAuto" EventName="Click" />
                    </Triggers>
                 </asp:UpdatePanel>
            </div>
        </div>
        <div class="divh"></div>
        <div class="tdiv">
        <table cellpadding="0" cellspacing="0" class="tb3">
            <tr>
                <td style="padding-left:15px; height:29px;">
                 <input id="tbSltGoods" type="button" value="选择单据" class="bt1" onclick="SltBill('2');" />
                </td>
            </tr>
        </table>
        </div>
        
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td><asp:Label ID="lbMod" runat="server"></asp:Label>
                    <asp:HiddenField ID="hfCusID" runat="server" />
                    <asp:HiddenField ID="hfCusType" runat="server" />
                    <asp:HiddenField ID="hfType" runat="server" />
                     <span style="display:none;">
                     <asp:Button ID="btnSltID" runat="server" Text="..." UseSubmitBehavior="false" OnClick="btnSltID_Click" />
                     </span>
                </td>
                <td align="right">
                    <asp:Button ID="btnAuto" runat="server" Text="自动分配" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnAuto_Click"/>
                    <asp:Button ID="btnSave" runat="server" Text="确定" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnSave_Click"/>
                    <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog('1');"/>
                </td>
            </tr>
            </table>
    </div>
    
    </div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/detail.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
function ChkSave()
{
    if(!isMoney($("tbAmount").value))
    {
        window.alert("操作失败！对冲金额格式不正确");
        $("tbAmount").focus();
        return false
    }else
    {
        if(parseFloat($("tbAmount").value)>0)
        {}
        else
        {
            window.alert("操作失败！对冲金额必须大于零");
            $("tbAmount").focus();
            return false
        }
    }
    
    if($("ddlAccount").value=="-1")
    {
        window.alert("操作失败！对冲帐户不能为空");
        $("ddlAccount").focus();
        return false
    }
}

function SltBill(iflag)
{
    var cusid=$("hfCusID").value;
    $("hfType").value=iflag;
    parent.ShowDialog1(800, 520, 'Financial/SltBill.aspx?iFlag='+iflag+'&custype='+$("hfCusType").value+'&cusid='+cusid, '选择单据');
}
</script>
