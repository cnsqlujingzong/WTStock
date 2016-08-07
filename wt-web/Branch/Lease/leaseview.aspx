<%@ page language="C#"  CodeFile="leaseview.aspx.cs"     autoeventwireup="true" inherits="Branch_Lease_LeaseView" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:786px;">
    <div class="fdivs">
    <div class="sdivs" style="padding:3px 0 3px 0px; overflow:hidden;">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb4">
            <tr>
            <td>业务单号：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbBillID" runat="server" CssClass="pinb" ReadOnly="true" Width="115"></asp:TextBox></td>
            <td align="right">日期：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDate" runat="server" CssClass="Wdate" Width="117" onfocus="WdatePicker()"></asp:TextBox></td>
            <td align="right">业务员：</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl" Width="121">
                </asp:DropDownList>
            </td>
            <td class="sysred" align="right">业务类别：</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbType" runat="server" CssClass="pinb" Width="101" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="sysred" align="right">客户名称：</td>
            <td colspan="3" style="padding-left:0px;">
                <div class="isinDiv">
                    <asp:TextBox ID="tbCusName" runat="server" CssClass="pin autot" Width="306" onmousedown="getSearchResult('../Customer/SchCusList.aspx','tbCusName','hfCusID','1','btnCusInfo',event);" onkeyup="getSearchResult('../Customer/SchCusList.aspx','tbCusName','hfCusID','1','btnCusInfo',event);" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
            </td>
            <td align="right">
            联系人：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin" Width="115"></asp:TextBox></td>
            <td class="sysred" align="right">
            联系电话：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin" Width="99"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right">地址：</td>
            <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin" Width="306"></asp:TextBox></td>
            <td colspan="5">
                <a href="#" onclick="ViewCus();">>>详细信息</a>
                <a href="#" onclick="ViewHistory();">>>相关历史</a>
            </td>
        </tr>
        <tr>
            <td align="right">合同编号：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbAutoNO" runat="server" CssClass="pin" Width="115"></asp:TextBox></td>
            <td align="right">起始日期：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbStartDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="117"></asp:TextBox></td>
            <td align="right">终止日期：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbEndDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="117"></asp:TextBox></td>
            <td align="right">结算周期：</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbChargeCycle" runat="server" CssClass="pin" Width="99"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td align="right">基础月租：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbRent" runat="server" CssClass="pin" Width="115"></asp:TextBox></td>
            <td align="right">押金：</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbDeposit" runat="server" CssClass="pin" Width="115"></asp:TextBox>
            </td>
            <td align="right">备注：</td>
            <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="290"></asp:TextBox></td>
        </tr>
        <tr>
             <td style="padding-left:0px;" align="right">
                <a href="#" onclick="ChkUpload();">上传附件</a>
            </td>
            <td style="padding-left:0px;" colspan="6">
                <div id="dUpload" runat="server"></div>
            </td>
            <td>
                <asp:HiddenField ID="hfPath" runat="server" />
                <asp:HiddenField ID="hfCusID" runat="server" />
                <asp:HiddenField ID="hfPrintID" runat="server" />
                <span style="display:none;">
                    <asp:Button ID="btnCusInfo" runat="server" Text="..."  OnClick="btnCusInfo_Click"/>
                </span>
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
    <div id="cndiv" style="height:228px;">
        <div class="fdivs" style="height:226px;">
            <div class="sdivs" style="height:224px;background:#ffffff;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvdata_RowDataBound">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="序"/>
                            <asp:BoundField HeaderText="机器状态" DataField="DevStatus" />
                            <asp:BoundField HeaderText="仓库" DataField="StockName" />
                            <asp:BoundField HeaderText="租赁机器" DataField="GoodsNO" />
                            <asp:BoundField HeaderText="租赁数量" DataField="iCount" />
                            <asp:BoundField HeaderText="租机单价" DataField="LeasePrice" />
                            <asp:BoundField HeaderText="机器编号" DataField="DeviceNO" />
                            <asp:BoundField HeaderText="机器品牌" DataField="Brand" />
                            <asp:BoundField HeaderText="类别" DataField="Class" />
                            <asp:BoundField HeaderText="型号" DataField="Model" />
                            <asp:BoundField HeaderText="序列号" DataField="ProductSN1" />
                            <asp:BoundField HeaderText="序列号2" DataField="ProductSN2" />
                            <asp:BoundField HeaderText="计数器"/>
                            <asp:BoundField HeaderText="备注" DataField="Remark" />
                        </Columns>
                    </asp:GridView>
               </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                </Triggers>
             </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:Label ID="lbMod" runat="server"></asp:Label>
            </td>
            <td align="right">
                <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;"  OnClick="btnAdd_Click"/>
                <input id="btnPrint" runat="server" type="button" value="打印" class="bt1" onclick="ChkPrint('ZLD');" />
                <input id="btnClose" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog<%=Str_F %>();" />
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
<script language="javascript" type="text/javascript" src="../../Public/Script/AutoSchCon.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">

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

function ChkUpload()
{   
    if($("dUpload").innerHTML=="")
    {
        parent.ShowDialog1(600, 380, 'Lease/UpLoad.aspx', '上传合同附件');
    }
    else
    {
        if(confirm("已经存在一个附件，继续上传将替换该附件，是否继续？"))
        {
            parent.ShowDialog1(600, 380, 'Lease/UpLoad.aspx', '上传合同附件');
        }
    }
}

function ViewCus()
{
    var cusid=$("hfCusID").value;
    if(cusid=="")
    {
        //新建客户
        parent.ShowDialog1(600, 450, '../Branch/Customer/CusAdd.aspx?f=1', '新建客户');
    }
    else
    {
        //修改客户
        parent.ShowDialog1(600, 450, '../Branch/Customer/CusMod.aspx?f=1&id='+cusid, '客户信息');
    }
}
function ViewQty(id)
{
    parent.ShowDialog3(400, 300,'Lease/ViewQty.aspx?id='+id, '查看计数器');
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
</script>
