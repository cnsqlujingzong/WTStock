<%@ page language="C#"  CodeFile="servicesaddbat.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Services_ServicesAddBat" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/tab.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:856px;">
    <div class="tldiv2">
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td width="310"><a  href="#" onclick="parent.ShowDialog(870,600, '../Headquarters/Services/ServicesAdd.aspx', '服务受理');">切换到标准模式</a></td>
                <td class="tser">批量受理</td>
                <td>服务单号：</td>
                <td style="padding-left:0px;">
                <asp:TextBox ID="tbBillID" runat="server" CssClass="pinbst" ReadOnly="true" Width="110"></asp:TextBox>
                </td>
                
                <td align="right" style="padding-left:0px;">
                制单时间：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbDate" CssClass="pinbst" runat="server" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
                </td>
                </tr>
        </table>
    </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
    <div class="fdivs" style="border-bottom:none;">
    <div class="sdivs" style="padding:3px 0 3px 0px;width:852px;border-bottom:none;">
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td align="right">服务类别：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="pindl2">
                    </asp:DropDownList>
                </td>
                <td align="right" style="width:87px; padding:0px;">受理方式：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlTake" runat="server" CssClass="pindl2">
                    </asp:DropDownList>
                </td>
                <td align="right" class="sysred" style="width:79px; padding:0px;">
                受理人：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl2">
                    </asp:DropDownList>
                </td>
                 <td align="right" style="width:87px; padding:0px;">受理时间：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbTakeTime" runat="server" CssClass="pin2" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox></td>
                
            </tr>
       </table>
       </div>
       </div>
       <div class="fdivs">
    <div class="sdivs" style="padding:3px 0 3px 0px;width:852px;">
    
       <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td align="right" class="sysred">客户名称：</td>
                <td colspan="3" style="padding-left:0px;">
                   <div class="isinDiv" style="width: 321px; float:left;">
                    <asp:TextBox ID="tbCusName" runat="server" CssClass="pin2 autot2" Width="333" onmousedown="getSearchResult('../Customer/SchCusList.aspx','tbCusName','hfCusID','1','btnValiCus',event);" onkeyup="getSearchResult('../Customer/SchCusList.aspx','tbCusName','hfCusID','1','btnValiCus',event);" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                </td>
                <td style="padding:0px;"><input id="btnSlt" type="button" value="" onclick="SltCus();" class="bview"/></td>
                <td align="right">
                报修人：</td>
                <td style="padding-left:0px;width:126px;">
                <div class="isinDiv">
                    <asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin2 pinin"></asp:TextBox>
                    <asp:DropDownList ID="ddlLinkMan" runat="server" onchange="document.getElementById('tbLinkMan').value=this.options[this.selectedIndex].text" CssClass="pininsl2" AutoPostBack="True" OnSelectedIndexChanged="ddlLinkMan_SelectedIndexChanged">
                        <asp:ListItem></asp:ListItem>
                      </asp:DropDownList>
                </div>
                </td>
                <td align="right" class="red">报修人电话：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin2"></asp:TextBox></td>
            </tr>
            
            <tr>
                <td align="right" style="padding-left:0px;">
                使用人：</td>
                <td style="padding-left:0px;width:126px;">
                <div class="isinDiv">
                    <asp:TextBox ID="tbUsePerson" runat="server" CssClass="pin2 pinin"></asp:TextBox>
                    <asp:DropDownList ID="ddlUsePerson" runat="server" onchange="document.getElementById('tbUsePerson').value=this.options[this.selectedIndex].text" CssClass="pininsl2" AutoPostBack="True" OnSelectedIndexChanged="ddlUsePerson_SelectedIndexChanged">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </div>
                </td>
                <td align="right">
                使用人电话：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbUsePersonTel" runat="server" CssClass="pin2"></asp:TextBox></td>
                <td align="right" style="padding-left:0px;" colspan="2">
                所属部门：</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                      <asp:TextBox ID="tbDept" runat="server" CssClass="pin2 pinin2"></asp:TextBox>
                      <asp:DropDownList ID="ddlDept" runat="server" onchange="document.getElementById('tbDept').value=this.options[this.selectedIndex].text" CssClass="pininsl2" AutoPostBack="True" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged">
                      </asp:DropDownList>
                    </div>
                </td>
                <td align="right">所属区域：</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbArea" runat="server" CssClass="pin2 pinin2"></asp:TextBox>
                        <asp:DropDownList ID="ddlArea" runat="server" CssClass="pininsl2" onchange="document.getElementById('tbArea').value=this.options[this.selectedIndex].text;NewAreas('3');">
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>
            
            <tr>
                <td>联系地址：</td>
                <td colspan="3" style="padding-left:0px;">
                    <asp:TextBox ID="tbAdr" runat="server" CssClass="pin2" Width="333"></asp:TextBox>
                </td>
                <td colspan="5">
                <a href="#" onclick="ViewCus();">>>详细信息</a>
                <a href="#" onclick="ViewHistory();">>>相关业务</a>
                </td>
                
            </tr>
        </table>
        </div>
        </div>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnValiCus" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnRef" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
        <div class="divh"></div>
         <div id="mytabs">
            <span id="tabs_l1"></span>
            <span id="tabs1" onclick="ChkTab('1');">机器列表</span>
            <span id="tabs_r1"></span>
            <span id="tabs_l2"></span>
            <span id="tabs2" onclick="ChkTab('2');">物流信息</span>
            <span id="tabs_r2"></span>
         </div>
         <div id="info1" style="padding:3px 0px 0px 3px; overflow:hidden;height:196px;" >
         <div id="divinfo1" class="divinfo" style="height:100%; padding-top:0px;">
         <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="devtemadd">
                <table cellpadding="0" cellspacing="0" class="tb1" width="100%">
                    <tr>
                        <td style="padding-left:5px;">
                            <input id="btnNewD" type="button" value="新建" class="bt1" onclick="parent.ShowDialog1(460, 353, '../Headquarters/Services/DeviceAdd.aspx', '新建机器');"/>
                            <input id="btnEditD" type="button" value="修改" class="bt1" onclick="ModD();"/>
                            <asp:Button ID="btnDelD" runat="server" Text="删除" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnDelD_Click"/>
                        </td>
                        <td align="right" style="padding-right:10px;">
                            <asp:TextBox ID="tbCount" runat="server" CssClass="pin" Width="40"></asp:TextBox>
                            <asp:Button ID="btnCopy" runat="server" Text="复制机器" CssClass="bcopy" UseSubmitBehavior="false" OnClick="btnCopy_Click"/>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divconf" style="height:160px; border:#c0c0c0 1px solid;">
                <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="False" SkinID="gv3" OnRowDataBound="gvdata_RowDataBound">
                        <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" />
                        <asp:BoundField HeaderText="机器编号" DataField="DeviceNO" />
                        <asp:BoundField HeaderText="机器品牌" DataField="Brand" />
                        <asp:BoundField HeaderText="机器类别" DataField="Class" />
                        <asp:BoundField HeaderText="机器型号" DataField="Model" />
                        <asp:BoundField HeaderText="序列号1" DataField="SN1" />
                        <asp:BoundField HeaderText="序列号2" DataField="SN2" />
                        <asp:BoundField HeaderText="保修情况" DataField="Warranty" />
                        <asp:BoundField HeaderText="机器外观" DataField="Aspect" />
                        <asp:BoundField HeaderText="报称故障" DataField="Fault" />
                        <asp:BoundField HeaderText="随机附件" DataField="Accessory" />
                        <asp:BoundField HeaderText="服务级别" DataField="ServiceLevel" />
                        <asp:BoundField HeaderText="经销商" DataField="BuyFrom" />
                        <asp:BoundField HeaderText="购买时间" DataField="BuyDate" />
                        <asp:BoundField HeaderText="购买发票" DataField="BuyInvoice" />
                        <asp:BoundField HeaderText="工分" DataField="dPoint" />
                            <asp:TemplateField HeaderText="是否再修">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbre" runat="server" Checked='<%# Bind("bRepair") %>' Enabled="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                <asp:HiddenField ID="hfCusID" runat="server" />
                <asp:HiddenField ID="hfArea" runat="server" />
                <asp:HiddenField ID="hfPrintID" runat="server" />
                <asp:HiddenField ID="hfDevice" runat="server" />
                <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
                <asp:HiddenField ID="hfCount" runat="server" Value="0" />
                <span style="display:none;">
                    <asp:Button ID="btnRef" runat="server" Text="Ref" OnClick="btnRef_Click" />
                    <asp:Button ID="btnAddD" runat="server" Text="AddD" OnClick="btnAddD_Click" />
                    <asp:Button ID="btnModD" runat="server" Text="ModD" OnClick="btnModD_Click" />
                    <asp:Button ID="btnShowD" runat="server" Text="ModD" OnClick="btnShowD_Click" />
                    <asp:Button ID="btnValiCus" runat="server" OnClick="btnValiCus_Click" Text="..." UseSubmitBehavior="false" />
                </span>
            </div>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
        </div>
        </div>
   <div id="info2" style="padding:3px 0px 0px 3px; overflow:hidden;height:196px;" >
         <div id="divinfo2" class="divinfo" style="height:100%;">
         <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            <table cellpadding="0" cellspacing="0" class="tb1">
                <tr>
                    <td align="right" style="padding-left:12px;">货运方式：</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlSndStyle" runat="server" CssClass="pindl2">
                        </asp:DropDownList>
                    </td>
                    <td align="right">物流单号：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbPostNO" runat="server" CssClass="pin2"></asp:TextBox>
                    </td>
                    <td align="right">物流费用：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbPostage" runat="server" CssClass="pin2"></asp:TextBox>
                    </td>
                </tr>
            </table>
            </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
         </div>
    </div>
    <div class="divh"></div>
    <div class="fdivs">
    <div class="sdivs" style="padding:3px 0 3px 0px;width:852px;">
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
           <td>存档单号：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbSaveID" runat="server" CssClass="pin2"></asp:TextBox></td>
            <td>预约时间：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbSubTime" runat="server" CssClass="pin2" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
            </td>
            
             <td align="right">预约取机：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbSubContTime" runat="server" CssClass="Wdate2" onfocus="WdatePicker()"></asp:TextBox>
            </td>
            <td align="right">技术员：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDisposal" runat="server" CssClass="pin2"></asp:TextBox>
            </td>
            <td style="padding:0px;"><input id="btnSltStaff" type="button" value="" onclick="SltTec();" class="bview"/></td>
        </tr>    
        <tr>
            <td>厂商单号：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbCorpID" runat="server" CssClass="pin2"></asp:TextBox></td>
            <td>结算厂商：</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlChargeCorp" runat="server" CssClass="pindl2">
                </asp:DropDownList>
            </td>
            <td>销售合同号：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbContNO" runat="server" CssClass="pin2"></asp:TextBox>
                </td>
            <td>预报价格：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbSubPrice" runat="server" CssClass="pin2"></asp:TextBox></td>
            
          </tr>    
        <tr>
            <td align="right">预收费：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbSubCharge" runat="server" CssClass="pin2"></asp:TextBox></td>
            <td align="right">备注：</td>
            <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin2" Width="333"></asp:TextBox></td>
            <td>
                <a href="#" onclick="ChkUpload();">上传附件</a>
            </td>
            <td style="padding-left:0px;">
                <div id="dUpload"></div>
                <asp:HiddenField ID="hfPath" runat="server" />
            </td>
        </tr>
    </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="right">
                <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnAdd_Click" />
                <asp:Button ID="btnClean" runat="server" Text="清空" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkClean()==false)return false;" OnClick="btnClean_Click" />
<%--                <input id="btnPrint" runat="server" type="button" value="打印" class="bt1" onclick="ChkPrint('PLPZD');" />
--%>                <input id="btnClose" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog();" />
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
<script language="javascript" type="text/javascript" src="../../Public/Script/AutoSchCon.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
var tabnum=3;

function ChkSave()
{
    if(isNull($("tbTakeTime").value))
    {
        window.alert("操作失败！受理时间不能为空");
        $("tbTakeTime").focus();
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
        window.alert("操作失败！报修人电话不能为空");
        $("tbTel").focus();
        return false
    }
    
    if($("ddlOperator").value=="-1")
    {
        window.alert("操作失败！经办人不能为空");
        $("ddlOperator").focus();
        return false
    }
    if(isNull($("tbDate").value))
    {
        window.alert("操作失败！制单时间不能为空");
        $("tbDate").focus();
        return false
    }
    if(!isNull($("tbPostage").value))
    {
        if(!isMoney($("tbPostage").value))
        {
            window.alert("物流费用格式不正确");
            ChkTab('3');
            $("tbPostage").focus();
            return false
        }   
    }
}
function ChkID(id)
{
    ClrID(id);
    $("btnShowD").click();
}
function ModD()
{
    if(ChkSlt()!=false)
    {
        var str=document.getElementById("hfDevice").value;
        parent.ShowDialog1(460, 353,'../Headquarters/Services/DeviceMod.aspx?str='+escape(str),'修改机器');
    }
}

function SltCus()
{
    parent.ShowDialog1(800, 500, '../Headquarters/Services/SltCus.aspx?f=1&strname='+escape($("tbCusName").value), '选择客户');
}

function ConfCusInfo()
{
    if(confirm("该客户名称存在多条客户信息，是否选择？"))
    {
        SltCus();
    }
}
function SltTec()
{
    parent.ShowDialog1(400, 510, '../Headquarters/Services/SltTec.aspx?f=1', '技术员');
}

function ViewCus()
{
    var cusid=$("hfCusID").value;
    if(cusid=="")
    {
        //新建客户
        parent.ShowDialog1(600, 450, '../Headquarters/Customer/CusAdd.aspx?f=1', '新建客户');
    }
    else
    {
        //修改客户
        parent.ShowDialog1(600, 450, '../Headquarters/Customer/CusMod.aspx?f=1&id=' + cusid, '客户信息');
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
    parent.ShowDialog1(800, 520, '../Headquarters/Customer/CusHistory.aspx?f=1&cusid='+cusid, '相关业务');
}
function ChkUpload()
{   
    if($("dUpload").innerHTML=="")
    {
        parent.ShowDialog1(600, 380, '../Headquarters/Services/UpLoad.aspx', '上传附件');
    }
    else
    {
        if(confirm("已经存在一个附件，继续上传将替换该附件，是否继续？"))
        {
            parent.ShowDialog1(600, 380, '../Headquarters/Services/UpLoad.aspx', '上传附件');
        }
    }
}
</script>
