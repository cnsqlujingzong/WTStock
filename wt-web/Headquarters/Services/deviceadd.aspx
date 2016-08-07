<%@ page language="C#"  CodeFile="deviceadd.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Services_DeviceAdd" enableEventValidation="false" %>
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
        <div id="sa" style="width:446px;">
            <div class="fdivs">
            <div class="sdivs" style="width:442px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
               <table cellpadding="0" cellspacing="0" class="tb1">
                    <tr>
                        <td align="right" class="red">机器编号：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbDeviceNO" runat="server" CssClass="pin2" onkeydown="EnterTextBoxNO(event, this);" onblur="ChkNO();"></asp:TextBox></td>
                        <td align="right" class="red">机器品牌：</td>
                        <td style="padding-left:0px;">
                            <div class="isinDiv">
                                <asp:TextBox ID="tbBrand" runat="server" CssClass="pin2 pinin2" AutoCompleteType="Disabled" onblur="ChkPBrand();"></asp:TextBox>
                                <asp:DropDownList ID="ddlBrand" runat="server" CssClass="pininsl2" onchange="document.getElementById('tbBrand').value=this.options[this.selectedIndex].text;NewProductBrands('2');" AutoPostBack="True" OnSelectedIndexChanged="ddlBrand_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </td>
                        
                        
                    </tr>
                    <tr>
                        <td align="right">机器类别：</td>
                        <td style="padding-left:0px;">
                            <div class="isinDiv">
                                <asp:TextBox ID="tbClass" runat="server" CssClass="pin2 pinin2" AutoCompleteType="Disabled" onblur="ChkPClass();">
                                </asp:TextBox>
                                <asp:DropDownList ID="ddlClass" runat="server" onchange="document.getElementById('tbClass').value=this.options[this.selectedIndex].text;NewProductClasss('2');" CssClass="pininsl2" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </td>
                        <td align="right">机器型号：</td>
                        <td style="padding-left:0px;">
                            <div class="isinDiv">
                                <asp:TextBox ID="tbModel" runat="server" CssClass="pin2 pinin2" AutoCompleteType="Disabled" onblur="ChkPModel();"></asp:TextBox>
                                <asp:DropDownList ID="ddlModel" runat="server" CssClass="pininsl2" onchange="document.getElementById('tbModel').value=this.options[this.selectedIndex].text;NewProductModels('2');" AutoPostBack="True" OnSelectedIndexChanged="ddlModel_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </td>
                        
                        
                    </tr>
                    <tr>
                        <td align="right" class="red">序列号1：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbSN1" runat="server" CssClass="pin2" onkeydown="EnterTextBoxSN(event, this);" onblur="ChkSN();"></asp:TextBox>
                        </td>
                        <td align="right">序列号2：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbSN2" runat="server" CssClass="pin2"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="red" align="right">保修情况：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlRepStatus" runat="server" CssClass="pindl2" onchange="NewRepStatus('1');">
                                <asp:ListItem Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right">机器外观：</td>
                        <td style="padding-left:0px;">
                            <div class="isinDiv">
                                <asp:TextBox ID="tbAspect" runat="server" CssClass="pin2 pinin2"></asp:TextBox>
                                 <asp:DropDownList ID="ddlAspect" runat="server" onchange="document.getElementById('tbAspect').value=this.options[this.selectedIndex].text;" CssClass="pininsl2">
                                 </asp:DropDownList>
                            </div>
                        </td>
                        <td style="padding:0px;"><input id="btnSltAsp" type="button" onclick="SltAsp();" class="bview"/></td>
                   </tr>
                   <tr>
                        <td align="right">随机附件：</td>
                        <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbAcc" runat="server" CssClass="pin2" Width="321"></asp:TextBox></td>
                        <td style="padding:0px;"><input id="btnSltAcc" type="button" onclick="SltAcc();" class="bview"/></td>
                   </tr>
                   <tr>
                        <td align="right" class="red">报称故障：</td>
                        <td colspan="3"style="padding-left:0px; height:56px;">
                            <asp:TextBox ID="tbFault" runat="server" CssClass="pin2" Width="321" Height="42" TextMode="MultiLine"></asp:TextBox>
                            <asp:HiddenField ID="hfFault" runat="server" /></td>
                        <td style="padding:0px;"><input id="btnSltFault" type="button" onclick="SltFault();" class="bview"/></td>
                        </tr>
                        <tr>
                    </tr>
                    <tr>
                        <td align="right">服务级别：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlPRI" runat="server" CssClass="pindl2">
                            </asp:DropDownList>
                        </td>
                        <td align="right">经销商：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbBuyFrom" runat="server" CssClass="pin2"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">购买时间：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbBuyTime" runat="server" CssClass="Wdate2" onfocus="WdatePicker()"></asp:TextBox>
                        </td>
                        <td align="right">购买发票：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbBuyInvoice" runat="server" CssClass="pin2"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">工分：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbPoint" runat="server" CssClass="pin2"></asp:TextBox>
                        </td>
                        <td align="right">是否再修：</td>
                        <td style="padding-left:0px;"><asp:CheckBox ID="cbRe" runat="server" Text="" />
                            <asp:HiddenField ID="hfDevID" runat="server" />
                            <asp:HiddenField ID="hfModelID" runat="server" />
                            <asp:HiddenField ID="hfSN" runat="server" />
                            <asp:HiddenField ID="hfNO" runat="server" />
                            <span style="display:none;">
                                <asp:Button ID="btnChkSN" runat="server" Text="ChkSN" OnClick="btnChkSN_Click" />
                                <asp:Button ID="btnChkNO" runat="server" Text="ChkNO" OnClick="btnChkNO_Click" />
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
            <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="padding-left:5px;color:#0000ff">
                    <asp:CheckBox ID="cbClose" runat="server" Text="保存后关闭窗口" Checked="true" /></td>
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnAdd_Click"/>
                    <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog1();"/>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/detail.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
var processtip=1;
function ChkSave()
{
    if($("ddlBrand").value=="-1")
    {
        window.alert("操作失败！机器品牌不能为空");
        $("tbBrand").focus();
        return false
    }
    if($("ddlRepStatus").value=="-1")
    {
        window.alert("操作失败！保修情况不能为空");
        $("ddlRepStatus").focus();
        return false
    }
    if(isNull($("tbFault").value))
    {
        window.alert("操作失败！报称故障不能为空");
        $("tbFault").focus();
        return false
    }
    if(!isNull($("tbPoint").value))
    {
        if(!isMoney($("tbPoint").value))
        {
            window.alert("工分格式不正确");
            $("tbPoint").focus();
            return false
        }   
    }
}
function EnterTextBoxSN(event, obj)
{
    if(event.keyCode == 13&&!isNull(obj.value))
    {
        if(!isNull(obj.value))
        {
            ChkSN();
        }
    }
}

function EnterTextBoxNO(event, obj)
{
    if(event.keyCode == 13&&!isNull(obj.value))
    {
        if(!isNull(obj.value))
        {
            ChkNO();
        }
    }
}

function ChkNO()
{
    var strno=$("tbDeviceNO").value;
    if($("hfNO").value!=strno)
    {
        $("hfNO").value=$("tbDeviceNO").value;
        if(!isNull(strno))
            $("btnChkNO").click();
    }
}
function ChkSN()
{
    if($("hfDevID").value=="")
    {
        var strsn=$("tbSN1").value;
        if($("hfSN").value!=strsn)
        {
            $("hfSN").value=$("tbSN1").value;
            if(!isNull(strsn))
                $("btnChkSN").click();
        }
    }
}
function ConfInfo()
{
    if(confirm("该序列号存在多条机器信息，是否选择？"))
    {
        SltDev();
    }
}
function SltAsp()
{
    parent.ShowDialog2(400, 510, '../Headquarters/Basic/SltAsp.aspx?f=x', '机器外观');
}
function SltAcc()
{
    parent.ShowDialog2(400, 510, '../Headquarters/Basic/SltAcc.aspx?f=x', '随机附件');
}
function SltFault()
{
    parent.ShowDialog2(600, 510, '../Headquarters/Basic/SltFault.aspx?f=x', '常见故障');
}
function ChkAdd(str)
{
    parent.iframeDialog.$("hfDevice").value=str;
    parent.iframeDialog.$("btnAddD").click();
    
    if($("cbClose").checked)
        parent.CloseDialog1();
}
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog1();}catch(e){}}}
</script>
