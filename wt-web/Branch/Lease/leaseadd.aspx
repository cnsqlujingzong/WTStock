<%@ page language="C#"  CodeFile="leaseadd.aspx.cs"     autoeventwireup="true" inherits="Branch_Lease_LeaseAdd" theme="Themes" enableEventValidation="false" %>
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
        新建业务
    </div>
    <div id="ctdiv">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td>业务单号：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbBillID" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox></td>
            <td align="right">日期：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
            <td colspan="2" align="right">业务员：</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl">
                </asp:DropDownList>
            </td>
            <td class="sysred" align="right">业务类别：</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlType" runat="server" CssClass="pindl" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value="1">抄表类租赁</asp:ListItem>
                    <asp:ListItem Value="2">非抄表类租赁</asp:ListItem>
                    <asp:ListItem Value="3">全保</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="sysred" align="right">客户名称：</td>
            <td colspan="3" style="padding-left:0px;">
                <div class="isinDiv">
                <asp:TextBox ID="tbCusName" runat="server" CssClass="pin autot" Width="341" onmousedown="getSearchResult('../Customer/SchCusList.aspx','tbCusName','hfCusID','','btnCusInfo',event);" onkeyup="getSearchResult('../Customer/SchCusList.aspx','tbCusName','hfCusID','','btnCusInfo',event);" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
            </td>
            <td style="padding:0px;"><input id="btnSlt" type="button" value="" onclick="SltCus();" class="bview"/></td>
            <td align="right">
            联系人：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin"></asp:TextBox></td>
            <td class="sysred" align="right">
            联系电话：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right">地址：</td>
            <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin" Width="341"></asp:TextBox></td>
            <td colspan="4">
                <a href="#" onclick="ViewCus();">>>详细信息</a>
                <a href="#" onclick="ViewHistory();">>>相关历史</a>
            </td>
            
        </tr>
        <tr>
            <td align="right">合同编号：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbAutoNO" runat="server" CssClass="pin"></asp:TextBox></td>
            <td align="right">起始日期：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbStartDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
            <td align="right" colspan="2">终止日期：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbEndDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
            <td align="right">结算周期：</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbChargeCycle" runat="server" CssClass="pin"></asp:TextBox>
                <span class="red">天</span>
            </td>
            
        </tr>
        <tr>
            <td align="right"><asp:Label ID="lbRent" runat="server" Text="基础月租："></asp:Label></td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbRent" runat="server" CssClass="pin"></asp:TextBox></td>
            <td align="right">押金：</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbDeposit" runat="server" CssClass="pin"></asp:TextBox>
            </td>
            <td align="right" colspan="2">备注：</td>
            <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="341"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right">合同附件：</td>
            <td style="padding-left:0px;">
                <a href="#" onclick="ChkUpload();">上传合同附件</a>
            </td>
            <td style="padding-left:0px;" colspan="6">
                <div id="dUpload"></div>
                <asp:HiddenField ID="hfPath" runat="server" />
                <asp:HiddenField ID="hfCusID" runat="server" />
                <asp:HiddenField ID="hfPrintID" runat="server" />
                <span style="display:none;">
                    <asp:Button ID="btnCusInfo" runat="server" Text="..."  OnClick="btnCusInfo_Click"/>
                    <asp:DropDownList ID="ddlStock" runat="server">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlBrand" runat="server">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlClass" runat="server">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlModel" runat="server">
                    </asp:DropDownList>
                </span>
            </td>
        </tr>
     </table>
     </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSltBill" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="ddlType" EventName="SelectedIndexChanged" />
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
                        <asp:BoundField HeaderText="序" />
                        <asp:TemplateField HeaderText="仓库">
                            <ItemTemplate>
                                <asp:TextBox ID="tbStock" runat="server" Text='<%# Eval("Stock") %>' style="display:none;"></asp:TextBox>
                                <asp:DropDownList ID="ddlStock" runat="server" CssClass="pindl" Width="80">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="租赁机器" DataField="GoodsNO" />
                        <asp:TemplateField HeaderText="数量">
                            <ItemTemplate>
                                <asp:TextBox ID="tbCount" runat="server" CssClass="pin" Width="80" Text='<%# Eval("iCount") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="租机单价">
                            <ItemTemplate>
                                <asp:TextBox ID="tbPrice" runat="server" CssClass="pin" Width="80" Text='<%# Eval("dPrice") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="金额">
                            <ItemTemplate>
                                <asp:Label ID="tbTotal" runat="server" CssClass="pin" Width="80" Text='<%# Eval("dTotal") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="机器编号">
                            <ItemTemplate>
                                <asp:TextBox ID="tbDeviceNO" runat="server" CssClass="pin" Width="80" Text='<%# Eval("DeviceNO") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="机器品牌">
                            <ItemTemplate>
                                <asp:TextBox ID="tbBrand" runat="server" Text='<%# Eval("Brand") %>' ></asp:TextBox>
                                <asp:DropDownList ID="ddlBrand" runat="server" CssClass="pindl" Width="80" style="display:none;">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="类别">
                            <ItemTemplate>
                                <asp:TextBox ID="tbClass" runat="server" Text='<%# Eval("Class") %>' ></asp:TextBox>
                                <asp:DropDownList ID="ddlClass" runat="server" CssClass="pindl" Width="80" style="display:none;">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="型号">
                            <ItemTemplate>
                                <asp:TextBox ID="tbModel" runat="server" Text='<%# Eval("Model") %>' ></asp:TextBox>
                                <asp:DropDownList ID="ddlModel" runat="server" CssClass="pindl" Width="120" style="display:none;">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="序列号">
                            <ItemTemplate>
                                <asp:TextBox ID="tbSN1" runat="server" CssClass="pin" Width="80" Text='<%# Eval("SN1") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="计数器">
                            <ItemTemplate>
                                <asp:TextBox ID="tbstrQty" runat="server" style="display:none;" Text='<%# Eval("strQty") %>'></asp:TextBox>
                                <asp:HyperLink ID="hlstrQty" runat="server" NavigateUrl="#d" ToolTip="编辑计数器">编辑计数器</asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="序列号2">
                            <ItemTemplate>
                                <asp:TextBox ID="tbSN2" runat="server" CssClass="pin" Width="80" Text='<%# Eval("SN2") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="备注">
                            <ItemTemplate>
                                <asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Text='<%# Eval("Remark") %>' Width="160"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="删除">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbDel" TabIndex="-1" runat="server" CausesValidation="False"  CommandName="Delete" Text="删除" style="color:#0000ff;"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:HiddenField ID="hfreclist" runat="server" />
                    <asp:HiddenField ID="hfSltID" runat="server" />
                    <asp:HiddenField ID="hfvalue" runat="Server" Value="0" />
                     <span style="display:none;">
                         <asp:Button ID="btnId" runat="server" Text="..." OnClick="btnId_Click" />
                         <asp:Button ID="btnSure" runat="server" Text="..." OnClick="btnSure_Click" />
                         <asp:Button ID="btnsngetgds" runat="server" Text="..." OnClick="btnsngetgds_Click" />
                         <asp:Button ID="btnSltBill" runat="server" Text="..." OnClick="btnSltBill_Click" />
                     </span>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnSltBill" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="ddlType" EventName="SelectedIndexChanged" />
                </Triggers>
             </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div class="divh"></div>
    <div class="tdiv">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <table cellpadding="0" cellspacing="0" class="tb4">
        <tr>
            <td style="padding-left:15px;">
                <asp:DropDownList ID="ddlSchFld" runat="server" CssClass="pindl" Width="70">
                    <asp:ListItem Value="SN">按序列号</asp:ListItem>
                    <asp:ListItem Value="BarCode">按条码</asp:ListItem>
                    <asp:ListItem Value="GoodsNO">按编号</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td><asp:TextBox ID="tbCon" runat="server" CssClass="pin" onkeydown="EnterTextBox(event, this);" ToolTip="输入完成后回车添加"></asp:TextBox></td>
            <td><input id="tbSltGoods" type="button" value="选择产品" class="bt1" onclick="parent.ShowDialog(800, 520, 'Stock/SltGoods.aspx', '选择产品');" /></td>
            <td><input id="btnSltSN" type="button" value="选择SN" class="bt1" onclick="parent.ShowDialog(800, 520, 'Stock/SltSN.aspx', '选择序列号');" /></td>
            <td><input id="btnLease" type="button" value="历史业务" class="bt1" onclick="parent.ShowDialog(800, 520, 'Lease/SltLease.aspx', '选择历史业务单');" /></td>
        </tr>
    </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    
    <asp:HiddenField ID="hfClass" runat="server" Value="-1" />
    <asp:HiddenField ID="hfBrand" runat="server" Value="-1" />
    <asp:HiddenField ID="hfModel" runat="server" Value="-1" />
    
    <div class="ftool">
    <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
        <tr>
            <td><span class="si1">若手工输入编号或条码，输入完成后回车</span>
            <td align="right" style="padding-right:20px;">
                <asp:Button ID="btnChk" runat="server" Text="审核" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;"  OnClick="btnChk_Click"/>
                <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;"  OnClick="btnAdd_Click"/>
                <asp:Button ID="btnClean" runat="server" Text="清空" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkClean()==false)return false;" OnClick="btnClean_Click"/>
                <input id="btnPrint" runat="server" type="button" value="打印" class="bt1" onclick="ChkPrint('ZLD');" />
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
<script language="javascript" type="text/javascript" src="../../Public/Script/detail.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/AutoSchCon.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/AutoSchCon1.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;

function ChkID(id)
{
    ClrID(id);
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
        window.alert("操作失败！业务员不能为空");
        $("ddlOperator").focus();
        return false
    }
    if(isNull($("tbCusName").value))
    {
        window.alert("操作失败！客户名称不能为空");
        $("tbCusName").focus();
        return false
    }

    if(isNull($("tbTel").value))
    {
        window.alert("操作失败！联系电话不能为空");
        $("tbTel").focus();
        return false
    }
    if(isNull($("tbStartDate").value))
    {
        window.alert("操作失败！起始日期不能为空");
        $("tbStartDate").focus();
        return false
    }
    
    if(isNull($("tbEndDate").value))
    {
        window.alert("操作失败！终止日期不能为空");
        $("tbEndDate").focus();
        return false
    }
    if(isNull($("tbRent").value))
    {
        window.alert("操作失败！基础月租不能为空");
        $("tbRent").focus();
        return false
    }
    if(isNull($("tbDeposit").value))
    {
        window.alert("操作失败！押金不能为空");
        $("tbDeposit").focus();
        return false
    }
    if(!isMoney($("tbRent").value))
    {
        window.alert("基础月租格式不正确");
        $("tbRent").focus();
        return false
    }
    if(!isMoney($("tbDeposit").value))
    {
        window.alert("押金格式不正确");
        $("tbDeposit").focus();
        return false
    }
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
function ChkUpload()
{   
    if($("dUpload").innerHTML=="")
    {
        parent.ShowDialog(600, 380, 'Lease/UpLoad.aspx', '上传合同附件');
    }
    else
    {
        if(confirm("已经存在一个附件，继续上传将替换该附件，是否继续？"))
        {
            parent.ShowDialog(600, 380, 'Lease/UpLoad.aspx', '上传合同附件');
        }
    }
}

function SltCus()
{
    parent.ShowDialog1(800, 500, 'Lease/SltCus.aspx?f=2&fid='+parent.$("hfActiveWin").value+'&strname='+escape($("tbCusName").value), '选择客户');
}

function ConfCusInfo()
{
    if(confirm("该客户名称存在多条客户信息，是否选择？"))
    {
        SltCus();
    }
}
function ViewCus()
{
    var cusid=$("hfCusID").value;
    if(cusid=="")
    {
        //新建客户
        parent.ShowDialog1(600, 430, '../Branch/Customer/CusAdd.aspx?f=1', '新建客户');
    }
    else
    {
        //修改客户
        parent.ShowDialog1(600, 430, '../Branch/Customer/CusMod.aspx?f=1&id='+cusid, '客户信息');
    }
}

function ViewHistory()
{
    var cusid=$("hfCusID").value;
    if(cusid=="")
    {
        alert("请选择客户后查看！");
        return false;
    }
    parent.ShowDialog1(800, 520, '../Branch/Customer/CusHistory.aspx?f=1&cusid='+cusid, '相关业务');
}

function EditQty(tbqty)
{
    parent.ShowDialog(600, 380, 'Lease/EditQty.aspx?tbqty='+tbqty+'&qtyvalue='+escape($(tbqty).value), '编辑计数器');
}

function Chkset()
{
    Chkwh11();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("新建业务");
}
function calcAmountByPrice(obj,tbcount,lbrent)
{
    var price = parseFloat(obj.value);
    var count = parseInt(document.getElementById(tbcount).value);
    
    if(obj.value !="" && document.getElementById(tbcount).value != "")
    {
        document.getElementById(lbrent).innerHTML = price * count;
    }
}
function calcAmountByCount(obj,tbprice,lbrent)
{
    var price = parseFloat(document.getElementById(tbprice).value);
    var count = parseInt(obj.value);
    
    if(obj.value !="" && document.getElementById(tbprice).value != "")
    {
        document.getElementById(lbrent).innerHTML = price * count;
    }
}
function Caculate()
{
    var tb=$("gvdata");
    var summoney=0;
    for(i=1;i<tb.rows.length;i++)
    {
        var total=tb.rows[i].cells[5].getElementsByTagName("span")[0].innerHTML;
        if(!isNaN(total))
        {
            summoney+=parseFloat(total);
        }
    }
    $("tbRent").value=summoney
}
function getSchModel(b,c,m)
{
    getSearchResult1('../Customer/SchModel.aspx',''+m.id+'','hfModel','1','' + b.value + '^' + c.value + '',event);
    
}
</script>
