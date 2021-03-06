<%@ page language="C#"  CodeFile="disbiling.aspx.cs"     autoeventwireup="true" inherits="Branch_Stock_DisBiling" theme="Themes" enableEventValidation="false" %>
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
        拆装开单
    </div>
    <div id="ctdiv">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td>拆装单号：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbBillID" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox></td>
            <td align="right">日期：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
            <td align="right" colspan="2">经办人：</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl">
                </asp:DropDownList>
            </td>
            <td class="sysred">类别：</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlType" runat="server" CssClass="pindl" onchange="chktype();">
                    <asp:ListItem Value="1">拆卸</asp:ListItem>
                    <asp:ListItem Value="2">组装</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="sysred" align="right">
                <asp:Label ID="lbType" runat="server" Text="出"></asp:Label>库仓库：</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlStock" runat="server" CssClass="pindl">
                </asp:DropDownList>
            </td>
            <td class="sysred">产品编号：</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbGoodsNO" runat="server" CssClass="pin" onblur="chkgoods();"></asp:TextBox>
            </td>
            <td style="padding:0px;"><input id="btnSlt" type="button" value="" onclick="SltGds();" class="bview"/></td>
            <td align="right">名称：</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbGoodsName" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox>
            </td>
            <td>规格：</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbSpec" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:CheckBox ID="cbStockOut" runat="server" Text="拆卸出库" Visible="false" />
            </td>
            
        </tr>
        <tr>
            <td align="right">品牌：</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbBrand" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox>
            </td>
            <td align="right">单价：</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbPrice" runat="server" CssClass="pin"></asp:TextBox>
            </td>
            <td class="sysred" align="right" colspan="2">数量：</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbQty" runat="server" CssClass="pin" onblur="chkgdsqty();"></asp:TextBox>
            </td>
            <td>备注：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin"></asp:TextBox></td>
            <td>
                <asp:HiddenField ID="hfSNs" runat="server" />
                <a href="javascript:void(0);" onclick="EditSN($('hfGoodsID').value,$('hfUnitsID').value,'hfSNs','tbQty',0);">编辑序列号</a>
            </td>
        </tr>
     </table>
     </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnchkgdsqty" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnchkgoods" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
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
                                <asp:HiddenField ID="hfSN" runat="server" Value='<%#Eval("SN") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="序列号" />
                        <asp:TemplateField HeaderText="单价">
                            <ItemTemplate>
                                <asp:TextBox ID="tbPrice" runat="server" Text='<%# Eval("Price") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                                <input id="btnsch" name="btnsch" type="button" value="" runat="server" class="sch_btn" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="金额">
                            <ItemTemplate>
                                <asp:Label ID="lbAmount" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="MainTenancePeriod" HeaderText="保修期" />
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
                    <asp:HiddenField ID="hfGoodsID" runat="server" />
                    <asp:HiddenField ID="hfUnitsID" runat="server" />
                    <asp:HiddenField ID="hfGoodsNO" runat="server" />
                    <asp:HiddenField ID="hfQty" runat="server" />
                    <asp:HiddenField ID="hfPrintID" runat="server" />
                    <asp:HiddenField ID="hfControl" runat="server" Value="0" />
                     <span style="display:none;">
                     <asp:Button ID="btnId" runat="server" Text="..." OnClick="btnId_Click" />
                     <asp:Button ID="btnSure" runat="server" Text="..." OnClick="btnSure_Click" />
                     <asp:Button ID="btnSltStock" runat="server" Text="..." OnClick="btnSltStock_Click" />
                     <asp:Button ID="btnSltUnit" runat="server" Text="..." OnClick="btnSltUnit_Click" />
                     <asp:Button ID="btnchkgoods" runat="server" Text="..." OnClick="btnchkgoods_Click" />
                     <asp:Button ID="btnchkgdsqty" runat="server" Text="..." OnClick="btnchkgdsqty_Click" />
                     <asp:Button ID="btnChkParts" runat="server" Text="..." OnClick="btnChkParts_Click" />
                     </span>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnchkgoods" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnchkgdsqty" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnChkParts" EventName="Click" />
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
                </asp:DropDownList>
            </td>
            <td><asp:TextBox ID="tbCon" runat="server" CssClass="pin" onkeydown="EnterTextBox(event, this);" ToolTip="输入完成后回车添加"></asp:TextBox></td>
            <td><input id="tbSltGoods" type="button" value="选择产品" class="bt1" onclick="SltGoods();" /></td>
            <td style="padding-left:10px;">合计数量：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbAQty" runat="server" CssClass="pinbr" ReadOnly="true" Width="100"></asp:TextBox></td>
            <td>合计金额：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbAmount" runat="server" CssClass="pinbr" ReadOnly="true" Width="100"></asp:TextBox></td>
        </tr>
    </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnchkgoods" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnchkgdsqty" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnId" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSure" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChkParts" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    
    <div class="ftool">
    <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
        <tr>
            <td><span class="si1">若手工输入编号或条码，输入完成后回车</span></td>
            <td align="right" style="padding-right:20px;">
                <asp:Button ID="btnChk" runat="server" Text="审核" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;"  OnClick="btnChk_Click"/>
                <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;"  OnClick="btnAdd_Click"/>
                <asp:Button ID="btnClean" runat="server" Text="清空" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkClean()==false)return false;" OnClick="btnClean_Click"/>
                <input id="btnPrint" runat="server" type="button" value="打印" class="bt1" onclick="ChkPrint('CZD');" />
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
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
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
    
   if($("ddlOperator").value=="-1")
    {
        window.alert("操作失败！经办人不能为空");
        $("ddlOperator").focus();
        return false
    }
    
    if($("ddlStock").value=="-1")
    {
        window.alert("操作失败！仓库不能为空");
        $("ddlStock").focus();
        return false
    }
    
    if(isNull($("tbPrice").value))
    {
        window.alert("操作失败！单价不能为空");
        $("tbPrice").focus();
        return false
    }
    if(!isMoney($("tbPrice").value))
    {
        window.alert("单价格式不正确");
        $("tbPrice").focus();
        return false
    }
    var amount=parseFloat($("tbPrice").value)*parseFloat($("tbQty").value)
    if(amount!=parseFloat($("tbAmount").value))
    {
        if(confirm("拆装产品金额与实际产品明细不符，是否继续？"))
            return true;
        else
            return false;
    }
}
function chkgoods()
{
    if(!isNull($("tbGoodsNO").value))
    {
        if($("tbGoodsNO").value!=$("hfGoodsNO").value)
            $("btnchkgoods").click();
    }
}
function chkgdsqty()
{
    if(isMoney($("tbQty").value))
    {
        if(parseFloat($("tbQty").value)>=1)
        {
            if($("tbQty").value!=$("hfQty").value)
            $("btnchkgdsqty").click();
        }
        else
        {alert("输入数量必须大于1，请从新输入！");$("tbQty").focus();}
    }
    else{alert("输入格式不正确，请从新输入！");$("tbQty").focus();}
}
function chktype()
{
    chkcx();
    var ctrls=document.getElementsByTagName("input");
    for(i=0;i<ctrls.length;i++)
    {
        if(ctrls[i].type=="hidden"&&ctrls[i].id.indexOf('hfSN')>=0)
        {
            ctrls[i].value="";
        } 
    }
}
function chkcx()
{
    if($("ddlType").value=="1")
    {
        $("lbType").innerHTML="出";
        if($("hfControl").value=="1")
        {
            $("cbStockOut").disabled=false;
            $("tbQty").className="pinb";
            $("tbQty").value="1";
            $("tbQty").readOnly=true;
        }
    }
    else
    {
        $("lbType").innerHTML="入";
        if($("hfControl").value=="1")
        {
            $("cbStockOut").checked=false;
            $("cbStockOut").disabled=true;
            $("tbQty").className="pin";
            $("tbQty").value="1";
            $("tbQty").readOnly=false;
        }
    }
}
chkcx();
function SltGds()
{
    parent.ShowDialog(800, 520, 'Stock/SltDisbGoods.aspx', '选择产品');
}
function SltGoods()
{
    if(!isNull($("hfGoodsID").value))
    parent.ShowDialog(800, 520, 'Stock/SltGoods.aspx', '选择产品');
    else
    {
        alert("请先选择要["+$("ddlType").options[$("ddlType").selectedIndex].innerText+"]的产品");
        $("tbGoodsNO").focus();
    }
}
function Chkset()
{
    Chkwh10();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("拆装开单");
}
function EditSN(goodsid,unitid,SN,nums,flag)
{
   var gdsnum=$(nums).value;
   var gsunit=parseInt(unitid);
   if(gsunit<=0)
   {
        alert("操作失败！请先选择产品");
        return false;
   }
   if(gdsnum<=0)
   {
        alert("操作失败！请输入产品数量");
        return false;
   }
   var url='Stock/EditSN.aspx?unitid='+unitid+'&snvalue='+escape($(SN).value)+'&snid='+SN+'&gdsnum='+escape(gdsnum);
   if(($("ddlType").value=="1"&&flag==0)||($("ddlType").value=="2"&&flag==1))
   {
        url=url+"&iflag=2&goodsid="+goodsid;
   }
   parent.ShowDialog(400, 300,url , '编辑序列号');
}
</script>
