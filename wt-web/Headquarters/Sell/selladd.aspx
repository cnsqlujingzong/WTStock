<%@ page language="C#"  CodeFile="selladd.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Sell_SellAdd" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body onload="Chkset();" onclick="parent.Sethidden1();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="divh2"></div>
    <div class="tldiv">
        销售开单
    </div>
    <div id="ctdiv">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td>销售单号：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbBillID" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox></td>
            
            <td align="right">日期：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDate" runat="server" CssClass="pin" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox></td>
            <td colspan="2" align="right">业务员：</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl">
                </asp:DropDownList>
            </td>
            <td align="right">送货人：</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlSndOperator" runat="server" CssClass="pindl">
                </asp:DropDownList>
            </td>
            <td></td>
        </tr>
        <tr>
            <td align="right">自编号：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbAutoNO" runat="server" CssClass="pin"></asp:TextBox></td>
            <td class="sysred" align="right">客户名称：</td>
            <td style="padding-left:0px;">
                <div class="isinDiv">
                <asp:TextBox ID="tbCusName" runat="server" CssClass="pin autot" onmousedown="getSearchResult('../Customer/SchCusList.aspx','tbCusName','hfCusID','1','btnCusInfo',event);" onkeyup="getSearchResult('../Customer/SchCusList.aspx','tbCusName','hfCusID','1','btnCusInfo',event);" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
            </td>
            <td style="padding:0px;"><input id="btnSlt" type="button" onclick="SltCus();" class="bview"/></td>
            <td align="right">联系人：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbLinkMan" Visible="false" runat="server" CssClass="pin"></asp:TextBox>
                <asp:DropDownList ID="ddl_LinkMan" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_LinkMan_SelectedIndexChanged">
                      <asp:ListItem Value="-1">请选择客户联系人</asp:ListItem>
                </asp:DropDownList>
                <input id="btnaddlinkman" type="button" onclick="addCuslink()" class="bview"/>
            </td>
            <td align="right">联系电话：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin"></asp:TextBox></td>
              <td>地址：<asp:TextBox ID="tbAdr" runat="server" CssClass="pin"></asp:TextBox></td>
        </tr>
            <tr>
                <td>是否代发货</td>
                
                <td><asp:DropDownList ID="ddl_isdai" runat="server">
                    <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
                        <asp:ListItem Value="1" >是</asp:ListItem>
                    </asp:DropDownList></td>
                   <td class="sysred" align="right">客户2：</td>
            <td style="padding-left:0px;">
                <div class="isinDiv">
                <asp:TextBox ID="tbCusName2" runat="server" CssClass="pin autot" onmousedown="getSearchResult('../Customer/SchCusList.aspx','tbCusName2','hfCusID2','1','btnCusInfo2',event);" onkeyup="getSearchResult('../Customer/SchCusList.aspx','tbCusName2','hfCusID2','1','btnCusInfo2',event);" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
            </td>
            <td style="padding:0px;"><input id="btnSlt2" type="button" onclick="SltCus2();" class="bview"/></td>
            <td align="right">联系人2</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbLinkMan2" Visible="false" runat="server" CssClass="pin"></asp:TextBox>
                <asp:DropDownList ID="ddl_LinkMan2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_LinkMan2_SelectedIndexChanged">
                      <asp:ListItem Value="-1">请选择客户联系人</asp:ListItem>
                </asp:DropDownList>
                <input id="Button2" type="button" onclick="addCuslink()" class="bview" style="display:none"/>
            </td>
            <td align="right">电话2：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbTel2" runat="server" CssClass="pin"></asp:TextBox></td>
                  <td>地址2：<asp:TextBox ID="tbAdr2" runat="server" CssClass="pin"></asp:TextBox></td>
            </tr>
        <tr>
           <td align="right">
            结算网点：</td>
            <td style="padding-left:0px;">
                   <div class="isinDiv">             
                        <asp:TextBox ID="tbwangdian"  runat="server" CssClass="pin autot" onmousedown="getSearchResult('../Customer/c_getbrandch.aspx','tbwangdian','hfwangdianID','1','btnwangdian',event);" onkeyup="getSearchResult('../Customer/c_getbrandch.aspx','tbwangdian','hfwangdianID','1','btnwangdian',event);" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
            </td>
           
            <td>结算方式：</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlChargeStyle" runat="server" CssClass="pindl">
                </asp:DropDownList>
            </td>
            <td colspan="2" align="right">
            备注：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin"></asp:TextBox>
            <span style="display:none;"><asp:Button ID="btnCusInfo" runat="server" Text="..." OnClick="btnCusInfo_Click"/></span>
                 <span style="display:none;"><asp:Button ID="btnCusInfo2" runat="server" Text="..." OnClick="btnCusInfo2_Click"/></span>
            </td>
            <td align="right">
            结算帐户：</td>
            <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlChargeAccount" runat="server" CssClass="pindl">
                    </asp:DropDownList>
            </td>
              <td></td>
        </tr>
        <tr>
             <td align="right">
            网点税率：</td>
          <td style="padding-left:0px;"><%-- <div class="isinDiv">  <asp:TextBox ID="tbwdTaxrate"   runat="server" CssClass="pin autot" AutoCompleteType="Disabled" ReadOnly="True"  ></asp:TextBox>--%>
              <asp:DropDownList ID="ddl_branchFax" runat="server" Width="150" AutoPostBack="True" OnSelectedIndexChanged="ddl_branchFax_SelectedIndexChanged">
                        <asp:ListItem Value="no-0" Selected="True">不含税</asp:ListItem>
              </asp:DropDownList>
              </div>   <asp:DropDownList ID="ddlInvoiceClass" runat="server" CssClass="pindl" Visible="false">
                    </asp:DropDownList></td>          
            <td align="right">
            发票号码：</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbInvoiceNO" runat="server" CssClass="pin"></asp:TextBox>
            </td>
            <td align="right" colspan="2">
            开票日期：</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbInvoiceDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
            </td>
            <td align="right">
            开票金额：</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbInvoiceAmount" runat="server" CssClass="pin" ></asp:TextBox>
            </td>
              <td></td>
        </tr>

              
     </table>   <span style="display:none;">  <asp:Button ID="btnwangdian" runat="server" Text="..." OnClick="btnWangdian_Click"/></span>
     </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSltBill" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnCusInfo" EventName="Click" />
          <asp:AsyncPostBackTrigger ControlID="btnCusInfo2" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="ddl_LinkMan" EventName="SelectedIndexChanged" />
             <asp:AsyncPostBackTrigger ControlID="ddl_LinkMan2" EventName="SelectedIndexChanged" />
    </Triggers>
    </asp:UpdatePanel>
    <div class="divh"></div>
    </div>
    <div id="cndiv" style="height:1px;">
        <div id="fdiv" class="fdiv">
            <div id="sdiv" class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvdata_RowDataBound" OnRowDeleting="gvdata_RowDeleting">
                        <Columns>
                        <asp:BoundField HeaderText="ID" DataField="GoodsID" />
                        <asp:BoundField HeaderText="UnitID" DataField="UnitID" />
                        <asp:BoundField HeaderText="序" />
                        <asp:BoundField HeaderText="仓库" DataField="StockName" />
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
                        <asp:TemplateField HeaderText="折扣">
                            <ItemTemplate>
                                <asp:TextBox ID="tbDis" runat="server" Text='<%# Eval("Dis") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="金额">
                            <ItemTemplate>
                                <asp:Label ID="lbAmount" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="货期">
                            <ItemTemplate>
                                <asp:TextBox ID="tbTaxRate" Visible="false" runat="server" Text='<%# Eval("TaxRate") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                                <asp:TextBox ID="tbhuoqi" runat="server" Text='<%# Eval("Huoqi") %>' CssClass="tbstyle huoqi" ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="成色">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddl_chengse" runat="server" SelectedValue='<%# string.IsNullOrEmpty(Eval("chengse").ToString())?"99成":Eval("chengse") %>'>
                                    <asp:ListItem Value="99成">99成</asp:ListItem>
                                     <asp:ListItem Value="原装">原装</asp:ListItem>
                                     <asp:ListItem Value="拆机">拆机</asp:ListItem>  
                                     <asp:ListItem Value="坏的">坏的</asp:ListItem>                                       
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                               <asp:TemplateField HeaderText="包装">
                            <ItemTemplate>
                               <asp:DropDownList ID="ddl_baozhuang" runat="server" SelectedValue='<%# string.IsNullOrEmpty( Eval("baozhuang").ToString())?"新的":Eval("baozhuang") %>'>
                                      <asp:ListItem Value="新的">新的</asp:ListItem>
                                     <asp:ListItem Value="原装">原装</asp:ListItem>
                                     <asp:ListItem Value="普通">普通</asp:ListItem>  
                                     <asp:ListItem Value="旧的">旧的</asp:ListItem>       
                               </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="税额">
                            <ItemTemplate>
                                <asp:Label ID="lbTaxAmount" runat="server" Text='<%# Eval("TaxAmount") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="价税合计">
                            <ItemTemplate>
                                <asp:Label ID="lbGoodsAmount" runat="server" Text='<%# Eval("GoodsAmount") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="保修期">
                            <ItemTemplate>
                                <asp:TextBox ID="tbPeriod" runat="server" CssClass="tbstyle" Text='<%# Eval("MainTenancePeriod") %>' Width="100" onfocus="select();"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="截止日期">
                            <ItemTemplate>
                                <asp:TextBox ID="tbPeriodEnd" runat="server" CssClass="tbstyle" Text='<%# Eval("PeriodEnd") %>' Width="100" onfocus="WdatePicker()"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="备注">
                            <ItemTemplate>
                                <asp:TextBox ID="tbRemark" runat="server" CssClass="tbstyle" Text='<%# Eval("Remark") %>' Width="200" onfocus="select();"></asp:TextBox>
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
                    <asp:HiddenField ID="hfRecIDs" runat="server" Value="-1" />
                    <asp:HiddenField ID="hfName" runat="server" />
                    <asp:HiddenField ID="hfUnitID" runat="server" />
                    <asp:HiddenField ID="hfOperationID" runat="server" />
                    <asp:HiddenField ID="hfConstractID" runat="server" />
                    <asp:HiddenField ID="hfSltID" runat="server" />
                    <asp:HiddenField ID="hfSltID1" runat="server" />
                    <asp:HiddenField ID="hfCusID" runat="server" />
                      <asp:HiddenField ID="hfCusID2" runat="server" />
                    <asp:HiddenField ID="hfPrintID" runat="server" />
                        <asp:HiddenField ID="hfwangdianID" runat="server" />
                    <asp:HiddenField ID="hfFlag" runat="server" Value="-1" />
                  <span style="display:none;">
                     <asp:Button ID="btnId" runat="server" Text="..." OnClick="btnId_Click" />
                     <asp:Button ID="btnSure" runat="server" Text="..." OnClick="btnSure_Click" />
                     <asp:Button ID="btnSltUnit" runat="server" Text="..." OnClick="btnSltUnit_Click" />
                     <asp:Button ID="btnSltStock" runat="server" Text="..." OnClick="btnSltStock_Click" />
                     <asp:Button ID="btnSltBill" runat="server" Text="..." OnClick="btnSltBill_Click" />                   
                     </span>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
                </Triggers>
             </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div class="divh"></div>
    <div class="tdiv">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <table cellpadding="0" cellspacing="0" class="tb3">
        <tr>
            <td style="padding-left:15px;">
                <asp:DropDownList ID="ddlSchFld" runat="server" CssClass="pindl" Width="70">
                    <asp:ListItem Value="BarCode">按条码</asp:ListItem>
                    <asp:ListItem Value="GoodsNO">按编号</asp:ListItem>
                    <asp:ListItem Value="SN">按序列号</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td><asp:TextBox ID="tbCon" runat="server" CssClass="pin" onkeydown="EnterTextBox(event, this);" ToolTip="输入完成后回车添加"></asp:TextBox></td>
            <td><input id="tbSltGoods" type="button" value="选择产品" class="bt1" onclick="parent.ShowDialog(800, 520, 'Stock/SltGoods.aspx', '选择产品');" /></td>
            <td><input id="btnPurPlan" type="button" value="销售订单" class="bt1" onclick="parent.ShowDialog(800, 520, 'Sell/SltSellPlan.aspx', '选择销售订单');" /></td>
            <td><input id="btnSaleContract" type="button" value="销售合同" class="bt1" onclick="parent.ShowDialog(800, 520, 'Sell/SltSellContract.aspx', '选择销售合同');" /></td>
            <td style="padding-left:10px;">合计数量：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbAQty" runat="server" CssClass="pinbr" ReadOnly="true" Width="50"></asp:TextBox></td>
            <td style="padding-left:10px;">合计金额：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbAmount" runat="server" CssClass="pinbr" ReadOnly="true" Width="80"></asp:TextBox></td>
            <td style="padding-left:10px;">价税合计：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbGoodsAmount" runat="server" CssClass="pinbr"  Width="80"></asp:TextBox></td>
            <td style="padding-left:10px;">现结金额：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbInCash" runat="server" CssClass="pin pblue" Width="80"></asp:TextBox></td>
        </tr>
    </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnId" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSure" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSltBill" EventName="Click" />
         <asp:AsyncPostBackTrigger ControlID="ddl_branchFax" EventName="SelectedIndexChanged" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    
    <div class="ftool">
    <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
        <tr>
            <td><span class="si1">若手工输入编号或条码，输入完成后回车</span>
            </td>
            <td align="right" style="padding-right:20px;">
                <asp:Button ID="btnChk" runat="server" Text="审核" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;"  OnClick="btnChk_Click"/>
                <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;"  OnClick="btnAdd_Click"/>
                <asp:Button ID="btnClean" runat="server" Text="清空" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkClean()==false)return false;" OnClick="btnClean_Click"/>
                <input id="btnPrint" runat="server" type="button" value="打印" class="bt1" onclick="ChkPrint('XSD');" />
                <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseWin();" />
            </td>
        </tr>
    </table>
    </div>
    <div class="fbom">
        <div id="fbon" class="fbon"></div> 
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/detailslt.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/detail.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/AutoSchCon.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="/codingpages/js/jquery-1.7.2.min.js"></script>
<script language="javascript" type="text/javascript">
    jQuery.noConflict();
var noOpen=1;

function ChkID(id)
{
    ClrID(id);
}

function ChkIDs(id,unitid)
{
    ClrID4(id);
    $("hfUnitID").value=unitid;
}

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

function ChkSave()
{
    if(isNull($("tbDate").value))
    {
        window.alert("操作失败！日期不能为空");
        $("tbDate").focus();
        return false
    }
    if (isNull($("tbwangdian").value))
    {
        window.alert("操作失败！网点不能为空");
        $("tbwangdian").focus();
        return false
    }
    if(isNull($("tbCusName").value))
    {
        window.alert("操作失败！客户名称不能为空");
        $("tbCusName").focus();
        return false
    }

   if($("ddlOperator").value=="-1")
    {
        window.alert("操作失败！业务员不能为空");
        $("ddlOperator").focus();
        return false
   }
   if ($("ddl_LinkMan").value == "-1") {
       window.alert("操作失败！客户联系人不能为空");
       return false
   }
   if ($("ddl_isdai").value == "1") {
       if ($("ddl_LinkMan2").value == "-1") {
           window.alert("操作失败！联系人2不能为空");
           return false
       }
   }
    if(!isMoney($("tbInCash").value))
    {
        alert("操作失败！现结金额格式不正确，请重新输入");
        $("tbInCash").focus();
        return false;
    }
    if(parseFloat($("tbInCash").value)>parseFloat($("tbGoodsAmount").value))
    {
        if(confirm("现结金额大于价税合计(应收金额),是否继续？"))
            return true;
        else
            return false;
    }
    var flage = true;
    jQuery(".huoqi").each(function () {
        if (isNull(jQuery(this).val())) {
            alert("货期不能为空");
            flage = false;
            return false;
        }
    });
    if (!flage) {
        return false;
    }

}
function SltCus()
{
    parent.ShowDialog1(800, 500, 'Customer/SltCus.aspx?f=2&fid='+parent.$("hfActiveWin").value, '选择客户');
}
function SltCus2() {
    parent.ShowDialog1(800, 500, 'Customer/SltCus2.aspx?f=2&fid=' + parent.$("hfActiveWin").value, '选择客户');
}

function EditSN(goodsid,unitid,SN,nums)
{
   var gdsnum=$(nums).value;
   if(gdsnum<=0)
   {
        alert("操作失败！请输入产品数量");
        return false;
   }
   parent.ShowDialog(400, 300, 'Stock/EditSN.aspx?iflag=2&goodsid='+goodsid+'&unitid='+unitid+'&snvalue='+escape($(SN).value)+'&snid='+SN+'&gdsnum='+escape(gdsnum), '编辑序列号');
}

function Chkset()
{
    Chkwh10a();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("销售开单");
}
function addCuslink() {
    //parent.ShowDialog1(800, 500, 'Customer/cuslinkmanadd.aspx?f=2&fid=' + parent.$("hfActiveWin").value, '选择客户');
    if (isNull($("hfCusID").value)) {
        window.alert("操作失败！添加联系人前必须先选客户");
    } else {
        parent.ShowDialog1(460, 350, 'Customer/CusLinkManAdd.aspx?f=&form=xsd&cid=' + $("hfCusID").value, '新建联系人');
    }

}
function Caculate()
{
    var tb=$("gvdata");
    var summoney=0;
    for(i=1;i<tb.rows.length;i++)
    {
        var costprice=tb.rows[i].cells[11].getElementsByTagName("span")[0].innerHTML;
        if(!isNaN(costprice))
        {
            summoney+=parseFloat(costprice);
        }
    }
    $("tbInvoiceAmount").value=summoney
}
</script>
