<%@ page language="C#"  CodeFile="staffmod.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Basic_StaffMod" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/tab.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="main">
        <div class="maincon">
        <div id="sad" style="width:586px;">
         <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td class="blue">员工姓名：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbName" runat="server" CssClass="pin" Width="220"></asp:TextBox></td>
                <td class="blue">员工编号：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbJobNO" runat="server" CssClass="pin" Enabled="false"></asp:TextBox></td>
                <td class="sysred" style="padding-left:5px;">
                    <asp:CheckBox ID="cbsys" runat="server" Text="系统默认" Checked="true" onclick="ChkSysNO();" /></td>
            </tr>
         </table>
        <div class="divh"></div>
        <div id="mytabs">
            <span id="tabs_l1"></span>
            <span id="tabs1" onclick="ChkTab('1');">基本信息</span>
            <span id="tabs_r1"></span>
            <span id="tabs_l2"></span>
            <span id="tabs2" onclick="ChkTab('2');">维修提成</span>
            <span id="tabs_r2"></span>
            <span id="tabs_l3"></span>
            <span id="tabs3" onclick="ChkTab('3');">销售提成</span>
            <span id="tabs_r3"></span>
            <span id="tabs_l4"></span>
            <span id="tabs4" onclick="ChkTab('4');">业绩提成</span>
            <span id="tabs_r4"></span>
        </div>
        <div id="info1" style="padding:3px 0px 0px 3px; overflow:hidden;">
        <div id="divinfo1" class="divinfo" style="height:311px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                        <td align="right">性别：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlSex" runat="server" CssClass="pindl">
                                <asp:ListItem Value=""></asp:ListItem>
                                <asp:ListItem Value="男">男</asp:ListItem>
                                <asp:ListItem Value="女">女</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right">状态：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlStatus" runat="server" CssClass="pindl">
                                <asp:ListItem Value="0">在职</asp:ListItem>
                                <asp:ListItem Value="1">离职</asp:ListItem>
                                <asp:ListItem Value="2">休假</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">电话：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td align="right">岗位：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlQus" runat="server" CssClass="pindl" onchange="NewQuarters();">
                                <asp:ListItem Value=""></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">出生年月：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbBirthDay" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
                        </td>
                        <td align="right">籍贯：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbNativePlace" runat="server" CssClass="pin"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">身份证号：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbCardNO" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td align="right">学历：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlStudy" runat="server" CssClass="pindl">
                                <asp:ListItem Value=""></asp:ListItem>
                                <asp:ListItem Value="博士">博士</asp:ListItem>
                                <asp:ListItem Value="硕士">硕士</asp:ListItem>
                                <asp:ListItem Value="本科">本科</asp:ListItem>
                                <asp:ListItem Value="大专">大专</asp:ListItem>
                                <asp:ListItem Value="高中">高中</asp:ListItem>
                                <asp:ListItem Value="初中">初中</asp:ListItem>
                                <asp:ListItem Value="小学">小学</asp:ListItem>
                                <asp:ListItem Value="其他">其他</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        
                    </tr>
                    <tr>
                        <td align="right">职位：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbSchool" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td align="right">微信：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbSpeci" runat="server" CssClass="pin"></asp:TextBox></td>                        
                    </tr>
                    <tr>
                        <td align="right">入职时间：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbJobTime" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
                        </td>
                        <td align="right">区域：</td>
                        <td style="padding-left:0px;">
                        <div class="isinDiv">
                        <asp:TextBox ID="tbArea" runat="server" CssClass="pin pinin"></asp:TextBox>
                        <asp:DropDownList ID="ddlArea" runat="server" CssClass="pininsl" onchange="document.getElementById('tbArea').value=this.options[this.selectedIndex].text;NewArea('1');">
                        </asp:DropDownList>
                        </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">底薪：</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbSalary" runat="server" CssClass="pin"></asp:TextBox>
                        </td>
                        <td align="right">津贴：</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbAllowance" runat="server" CssClass="pin"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">工资帐号：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbAccount" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td align="right">部门：</td>
                        <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlStaffDept" runat="server" CssClass="pindl">
                        </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">地址：</td>
                        <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin pinw"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">备注：</td>
                        <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin pinw"></asp:TextBox></td>
                    </tr>
                    </table>
               <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                        <td style="width:30px;">
                            <asp:HiddenField ID="hfQut" runat="server" />
                            <asp:HiddenField ID="hfArea" runat="server" />
                            <asp:HiddenField ID="hfName" runat="server" />
                            <span style="display:none;">
                            <asp:Button ID="btnRefQu" runat="server" Text="Ref" OnClick="btnRefQu_Click" />
                            <asp:Button ID="btnRef" runat="server" Text="Ref" OnClick="btnRef_Click" />
                            </span>
                        </td>
                        <td>
                            
                            <asp:CheckBox ID="cbDestClerk" runat="server" /> 受理员
                            <asp:CheckBox ID="cbAllot" runat="server" /> 派工人员
                            <asp:CheckBox ID="cbTechnician" runat="server" /> 技术员
                            <asp:CheckBox ID="cbSeller" runat="server" /> 业务员
                            <asp:CheckBox ID="cbAccountant" runat="server" /> 财务人员
                            <asp:CheckBox ID="cbStockMan" runat="server" /> 仓库管理员
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnRefQu" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnRef" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>
            </div>
            </div>
           <div id="info2" style="padding:3px 0px 0px 3px; overflow:hidden;">
            <div id="div1" class="divinfo" style="height:311px;">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                <ContentTemplate>
                   <table cellpadding="0" cellspacing="0" class="tb4">
                        <tr>
                            <td>
                                <input id="i1" type="button" value="业务额" class="bt1" onclick="BillInstr('{业务额}');" />
                                <input id="i2" type="button" value="毛利" class="bt1" onclick="BillInstr('{毛利}');" />
                                <input id="i3" type="button" value="人工费" class="bt1" onclick="BillInstr('{人工费}');" />
                                <input id="i4" type="button" value="材料费" class="bt1" onclick="BillInstr('{材料费}');" />
                                <input id="i5" type="button" value="附加费" class="bt1" onclick="BillInstr('{附加费}');" />
                                <input id="i6" type="button" value="工分" class="bt1" onclick="BillInstr('{工分}');" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input id="i7" type="button" value="材料成本" class="bt1" onclick="BillInstr('{材料成本}');" />
                                <input id="i8" type="button" value="项目提成" class="bt1" onclick="BillInstr('{项目提成}');" />
                                <input id="i9" type="button" value="保内单" class="bt1" onclick="BillInstr('{保内单}');" />
                                <input id="i10" type="button" value="保外单" class="bt1" onclick="BillInstr('{保外单}');" />
                                <input id="i11" type="button" value="工时(天)" class="bt1" onclick="BillInstr('{工时}');" />
                                <input id="i12" type="button" value="厂商结算" class="bt1" onclick="BillInstr('{厂商结算}');" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <input id="i13" type="button" value="协作人数" class="bt1" onclick="BillInstr('{协作人数}');" />
                                <input id="e1" type="button" value="+" style="width:20px;" onclick="BillInstr('+');" />
                                <input id="e2" type="button" value="-" style="width:20px;"  onclick="BillInstr('-');" />
                                <input id="e3" type="button" value="*" style="width:20px;"  onclick="BillInstr('*');" />
                                <input id="e4" type="button" value="/" style="width:20px;"  onclick="BillInstr('/');" />
                                <input id="e5" type="button" value="(" style="width:20px;" onclick="BillInstr('(');" />
                                <input id="e6" type="button" value=")" style="width:20px;" onclick="BillInstr(')');" />
                            </td>
                        </tr>
                        <tr>
                            <td><asp:TextBox ID="tbBillDe" runat="server" TextMode="MultiLine" Height="140" Width="420"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>公式拷贝
                                <asp:DropDownList ID="ddlSerFormula" runat="server" CssClass="pindl" AutoPostBack="true" OnSelectedIndexChanged="ddlSerFormula_SelectedIndexChanged">
                                </asp:DropDownList>
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
            <div id="info3" style="padding:3px 0px 0px 3px; overflow:hidden;">
            <div id="div2" class="divinfo" style="height:311px;">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                <ContentTemplate>
                    <table cellpadding="0" cellspacing="0" class="tb4">
                        <tr>
                            <td>
                                <input id="it1" type="button" value="业务额" class="bt1" onclick="SellInstr('{业务额}');" />
                                <input id="it2" type="button" value="毛利" class="bt1" onclick="SellInstr('{毛利}');" />
                                <input id="et1" type="button" value="+" style="width:20px;" onclick="SellInstr('+');" />
                                <input id="et2" type="button" value="-" style="width:20px;"  onclick="SellInstr('-');" />
                                <input id="et3" type="button" value="*" style="width:20px;"  onclick="SellInstr('*');" />
                                <input id="et4" type="button" value="/" style="width:20px;"  onclick="SellInstr('/');" />
                                <input id="et5" type="button" value="(" style="width:20px;" onclick="SellInstr('(');" />
                                <input id="et6" type="button" value=")" style="width:20px;" onclick="SellInstr(')');" />
                            </td>
                        </tr>
                        <tr>
                            <td><asp:TextBox ID="tbSellDe" runat="server" TextMode="MultiLine" Height="192" Width="420"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>公式拷贝
                                <asp:DropDownList ID="ddlSellFormula" runat="server" CssClass="pindl" AutoPostBack="true" OnSelectedIndexChanged="ddlSellFormula_SelectedIndexChanged">
                                </asp:DropDownList>
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
            <div id="info4" style="overflow:hidden;">
            <div id="div3" class="divinfo" style="padding:0;height:320px;">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
            <div class="divcon" style="height:231px;">
            <asp:GridView ID="GridView1" runat="server" SkinID="gv4" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
            <asp:BoundField DataField="ID" HeaderText="序" />
            <asp:BoundField DataField="Amount" HeaderText="利润" />
            <asp:BoundField DataField="Deduct" HeaderText="提成" />
            </Columns>
            </asp:GridView>
            </div>
            <table cellpadding="0" cellspacing="0" class="tb3">
            <tr>
                <td align="right">利润金额：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbAmount" runat="server"></asp:TextBox>
                </td>
                <td align="right">提成：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbDeduct" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
            <td align="right">提成类型：</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlType" runat="server" CssClass="pindl">
                    <asp:ListItem Value="1">固定提成</asp:ListItem>
                    <asp:ListItem Value="2">超过部分固定提成</asp:ListItem>
                    <asp:ListItem Value="3">百分比</asp:ListItem>
                    <asp:ListItem Value="4">超过部分百分比</asp:ListItem>
                </asp:DropDownList>
                <asp:HiddenField ID="hfRecID" runat="server" Value="-1"/>
            </td>
            <td align="right">公式拷贝：</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlStaffDeduct" runat="server" CssClass="pindl" AutoPostBack="true" OnSelectedIndexChanged="ddlStaffDeduct_SelectedIndexChanged">
                </asp:DropDownList></td>
            </tr>
            <tr>
            <td colspan="4">
                <asp:Button ID="btnMod" runat="server" Text="修改" UseSubmitBehavior="false" CssClass="bt1" OnClick="btnMod_Click" OnClientClick="if(chkDeductInput(1)==false)return false;" />
                <asp:Button ID="btnSave" runat="server" Text="添加" UseSubmitBehavior="false" CssClass="bt1" OnClick="btnSave_Click" OnClientClick="if(chkDeductInput(0)==false)return false;"/>
                <asp:Button ID="btnDel" runat="server" Text="删除" UseSubmitBehavior="false" CssClass="bt1" OnClick="btnDel_Click" OnClientClick="if(chkDeductDel()==false)return false;" />
            </td>
            </tr>
            </table>
            </ContentTemplate>
            </asp:UpdatePanel>
            </div>
            </div>
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
var tabnum=5;
var isfocus=1;
var processtip=1;
function ChkID(id)
{
    ClrID(id);
    $("tbAmount").value=$(id).cells[0].innerHTML;
    $("tbDeduct").value=$(id).cells[1].innerHTML;
}
function ChkAdd()
{
    if(isNull($("tbName").value))
    {
        window.alert("操作失败！员工姓名不能为空");
        $("tbName").focus();
        return false
    }
    
    if(!$("cbsys").checked)
    {
        if(isNull($("tbJobNO").value))
        {
            window.alert("操作失败！员工编号不能为空");
            $("tbJobNO").focus();
            return false
        }
    }
}
function chkDeductInput(m)
{
    if(m==1)
    {
        var id=parseInt($("hfRecID").value,10);
        if(id<=0)
        {
            alert("请选择一条记录再进行操作！");
            return false;
        }
    }
    if(!(/(^\d+(\.\d+)?$)|(超过后提成)/).test($("tbAmount").value))
    {
        alert("操作失败！请输入数字");
        $("tbAmount").focus();
        return false;
    }
    if(!(/^\d+(\.\d+)?$/).test($("tbDeduct").value))
    {
        alert("操作失败！请输入数字");
        $("tbDeduct").focus();
        return false;
    }
}
function chkDeductDel()
{
    var id=parseInt($("hfRecID").value,10);
    if(id<=0)
    {
        alert("请选择一条记录再进行操作！");
        return false;
    }
    return confirm("确认要删除该利润区间吗？");
}
function ChkSysNO()
{
    if(!$("cbsys").checked)
    {
        $("tbJobNO").disabled=false;
        $("tbJobNO").focus();
    }else
    {
        $("tbJobNO").disabled=true;
    }
}

function SellInstr(str)
{
    var tc = document.getElementById("tbSellDe");
    var tclen = tc.value.length;
    tc.focus();
    if(typeof document.selection != "undefined")
    {
        document.selection.createRange().text = str;
    }
    else
    {
        tc.value = tc.value.substr(0,tc.selectionStart)+str+tc.value.substring(tc.selectionStart,tclen);
    }
}

function BillInstr(str)
{
    var tc = document.getElementById("tbBillDe");
    var tclen = tc.value.length;
    tc.focus();
    if(typeof document.selection != "undefined")
    {
        document.selection.createRange().text = str;
    }
    else
    {
        tc.value = tc.value.substr(0,tc.selectionStart)+str+tc.value.substring(tc.selectionStart,tclen);
    }
}
</script>
