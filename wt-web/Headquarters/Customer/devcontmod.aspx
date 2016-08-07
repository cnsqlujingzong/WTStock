<%@ page language="C#"  CodeFile="devcontmod.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Customer_DevContMod" theme="Themes" enableEventValidation="false" %>
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
    <div id="sa" style="width:806px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
        <div class="fdivs">
        <div class="sdivs"  style="padding:3px 0 3px 0px; width:802px;">
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td align="right">合同编号：</td>
                <td style="padding-left:0px;">
                <asp:TextBox ID="tbContract" runat="server" CssClass="pin3" ></asp:TextBox>
                </td>
                <td align="right">签约日期：</td>
                <td style="padding-left:0px;">
                <asp:TextBox ID="tbDate" runat="server" CssClass="Wdate3" onfocus="WdatePicker()"></asp:TextBox>
                </td>
                <td align="right">
                业务员：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl3">
                    </asp:DropDownList>
                </td>
                <td align="right">
                合同类别：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="pindl3">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
            <td class="sysred" align="right">客户名称：</td>
            <td style="padding-left:0px;" colspan="3">
                <asp:TextBox ID="tbCusName" runat="server" CssClass="pinb" Width="313" ReadOnly="true"></asp:TextBox>
            </td>
            <td style="padding:0px;display:none;"><input id="btnSlt" type="button" value="" onclick="SltCus();" class="bview"/></td>
            <td align="right">
            联系人：</td> 
            <td style="padding-left:0px;"><asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin3"></asp:TextBox></td>
            <td align="right">
            联系电话：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin3"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right">地址：</td>
            <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin3" Width="311"></asp:TextBox></td>
            <td colspan="4">
                <a href="#" onclick="ViewCus();">>>详细信息</a>
                <a href="#" onclick="ViewHistory();">>>相关历史</a>
            </td>
        </tr>
            <tr>
                <td align="right">
                金额：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbAmount" runat="server" CssClass="pinb3" ReadOnly="true"></asp:TextBox>
                </td>
                <td align="right" class="sysred">
                现收金额：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbInCash" runat="server" CssClass="pinb3" ReadOnly="true" ></asp:TextBox>
                </td>
                <td align="right">起始日期：</td>
                <td style="padding-left:0px;">
                <asp:TextBox ID="tbStartDate" runat="server" CssClass="pinb3" ReadOnly="true"></asp:TextBox>
                </td>
                <td align="right">
                终止日期：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbEndDate" runat="server" CssClass="pinb3" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">合同条款：</td>
                <td style="padding-left:0px; height:46px;" colspan="3">
                <asp:TextBox ID="tbSummary" runat="server" CssClass="pin3" Width="311" Height="32" TextMode="MultiLine" ></asp:TextBox>
                </td>
                <td align="right">备注：</td>
                <td style="padding-left:0px; height:46px;" colspan="3">
                <asp:TextBox ID="tbRemark" runat="server" CssClass="pin3" Width="311" Height="32" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">合同附件：</td>
                <td style="padding-left:0px;">
                   <a href="#" style="color:#0000ff" title="上传合同附件" onclick="ChkUpload();">上传合同附件</a>
                </td>
                <td style="padding-left:0px;" colspan="6">
                <div id="dUpload" runat="server"></div>
                <asp:HiddenField ID="hfUpload" runat="server" />
                </td>
            </tr>
       </table>
        
        </div>
        </div>
      </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnCusInfo" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    <div class="divh"></div>
    <div id="cndiv" style="height:200px;">
        <div class="fdivs" style="height:198px;">
            <div class="sdivs" style="height:196px;background:#ffffff; width:802px">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvdata_RowDataBound" OnRowDeleting="gvdata_RowDeleting">
                        <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" />
                        <asp:BoundField HeaderText="序" />
                        <asp:BoundField HeaderText="机器品牌" DataField="Brand" />
                        <asp:BoundField HeaderText="类别" DataField="Class" />
                        <asp:BoundField HeaderText="型号" DataField="Model" />
                        <asp:BoundField HeaderText="序列号" DataField="SN" />
                        <asp:BoundField HeaderText="机器编号" DataField="DeviceNO" />
                        <asp:TemplateField HeaderText="服务级别">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlLevel" runat="server" CssClass="pindl3" Width="80">
                                </asp:DropDownList>
                                <asp:TextBox ID="tbLevel" runat="server" Text='<%# Eval("Level") %>' style="display:none;"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="免维修费">
                            <ItemTemplate>
                                <asp:CheckBox ID="cbRepair" runat="server"  Checked='<%# Eval("bRepair") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="免耗材费">
                            <ItemTemplate>
                                <asp:CheckBox ID="cbConsumables" runat="server"  Checked='<%# Eval("bConsumables") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="免备件费">
                            <ItemTemplate>
                                <asp:CheckBox ID="cbMaterial" runat="server"  Checked='<%# Eval("bMaterial") %>'/>
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
                    <asp:HiddenField ID="hfdellist" runat="server" />
                    <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
                    <asp:HiddenField ID="hfPrintID" runat="server" />
                    <asp:HiddenField ID="hfCusID" runat="server" />
                    <asp:HiddenField ID="hfDevID" runat="server" />
                    <span style="display:none;">
                        <asp:Button ID="btnCusInfo" runat="server" Text="..."  OnClick="btnCusInfo_Click"/>
                        <asp:Button ID="btnChkDev" runat="server" Text="..." OnClick="btnChkDev_Click" />
                        <asp:Button ID="btnSure" runat="server" Text="..." OnClick="btnSure_Click" />
                        <asp:DropDownList ID="ddlServiceLevel" runat="server" CssClass="pindl3">
                    </asp:DropDownList>
                    </span>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
                </Triggers>
             </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div class="divh"></div>
    <div class="fdivs">
    <div class="sdivs" style="padding:1px 0 1px 0px; width:802px;">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <table cellpadding="0" cellspacing="0" class="tb3">
        <tr>
            <td style="padding-left:15px;">
                <asp:DropDownList ID="ddlSchFld" runat="server" CssClass="pindl" Width="70">
                    <asp:ListItem Value="SN">按序列号</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td><asp:TextBox ID="tbCon" runat="server" CssClass="pin" onkeydown="EnterTextBox(event, this);" ToolTip="输入完成后回车添加"></asp:TextBox></td>
            <td><input id="tbSltGoods" type="button" value="选择机器" class="bt1" onclick="SltDev();" /></td>
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
        <td>
            <asp:Label ID="lbMod" runat="server" CssClass="si1" Text="若手工输入机器序列号，输入完成后回车"></asp:Label>
        </td>
        <td align="right">
            <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnAdd_Click" />
            <asp:Button ID="btnClean" runat="server" Text="清空" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkClean()==false)return false;" OnClick="btnClean_Click"/>
            <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog<%=Str_F %>();"/>
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
<script language="javascript" type="text/javascript">
var processtip=1;
function ChkSave()
{
    if(isNull($("tbContract").value))
    {
        window.alert("操作失败！合同编号不能为空");
        $("tbContract").focus();
        return false
    }
    
    if(isNull($("tbDate").value))
    {
        window.alert("操作失败！签约日期不能为空");
        $("tbDate").focus();
        return false
    }
    
   if($("ddlOperator").value=="-1")
    {
        window.alert("操作失败！业务员不能为空");
        $("ddlOperator").focus();
        return false
    }
     if($("ddlType").value=="-1")
    {
        window.alert("操作失败！合同类别不能为空");
        $("ddlType").focus();
        return false
    }
    
    if(isNull($("tbAmount").value))
    {
        window.alert("操作失败！金额不能为空");
        $("tbAmount").focus();
        return false
    }
    if(!isMoney($("tbAmount").value))
    {
        window.alert("金额格式不正确");
        $("tbAmount").focus();
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
        parent.ShowDialog1(600, 380, 'Customer/DocUpload.aspx', '上传合同附件');
    }
    else
    {
        if(confirm("已经存在一个合同附件，继续上传将替换该附件，是否继续？"))
        {
            parent.ShowDialog1(600, 380, 'Customer/DocUpload.aspx', '上传合同附件');   
        }
    }
}

function SltCus()
{
    parent.ShowDialog1(800, 500, 'Lease/SltCus.aspx?f=2&strname='+escape($("tbCusName").value), '选择客户');
}

function SltDev()
{
    parent.ShowDialog1(800, 500, 'Customer/SltDev.aspx?x=1&f=1&strname='+escape($("tbCusName").value)+'&cid='+$("hfCusID").value, '选择机器档案');
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
        parent.ShowDialog1(600, 450, '../Headquarters/Customer/CusMod.aspx?f=1&id='+cusid, '客户信息');
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
</script>
