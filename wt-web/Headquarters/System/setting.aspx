<%@ page language="C#"  CodeFile="setting.aspx.cs"     autoeventwireup="true" inherits="Headquarters_System_Setting" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/tab.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sa22" style="width:606px;">
    <div id="mytabs">
            <span id="tabs_l1"></span>
            <span id="tabs1" onclick="ChkTab('1');">基本设置</span>
            <span id="tabs_r1"></span>
            <span id="tabs_l4"></span>
            <span id="tabs4" onclick="ChkTab('4');">基本设置2</span>
            <span id="tabs_r4"></span>
            <span id="tabs_l2"></span>
            <span id="tabs2" onclick="ChkTab('2');">邮件/登录设置</span>
            <span id="tabs_r2"></span>
            <span id="tabs_l3"></span>
            <span id="tabs3" onclick="ChkTab('3');">自定义编号</span>
            <span id="tabs_r3"></span>
            <span id="tabs_l5" ></span>
            <span id="tabs5" onclick="ChkTab('5');">访问设置</span>
            <span id="tabs_r5" ></span>
            
     </div>
    <div id="info1" style="padding:3px 0px 0px 3px; overflow:hidden;">
    <div id="divinfo1" class="divinfo" style="height:371px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb3">
            <tr>
                <td>公司名称：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbName" runat="server" CssClass="pin" Width="200"></asp:TextBox></td>
                <td>联系电话：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin" Width="200"></asp:TextBox></td>
            </tr>
            <tr>
                <td>邮政编码：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbZip" runat="server" CssClass="pin" Width="200"></asp:TextBox></td>
                <td align="right">地址：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin" Width="200"></asp:TextBox></td>
            </tr>
            
            <tr>
                <td class="sysred">系统名称：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbsysName" runat="server" CssClass="pin" Width="200"></asp:TextBox>
                </td>
                <td class="sysred" align="right">
                    <asp:Label ID="lbRegType" runat="server" Text="用户数"></asp:Label>：</td>
                <td style="padding-left:0px;">
                <asp:TextBox ID="tbBranchNum" runat="server" CssClass="pin" Width="130"></asp:TextBox>
                <asp:Label ID="lbreg" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    
        <table cellpadding="0" cellspacing="0" class="tb3" width="580">
            <tr><td>
        <fieldset style="padding:5px 0;">
        <legend style="color:#0000ff">参数设置</legend>
        <table cellpadding="0" cellspacing="0" class="tb3">
            <tr>
                <td align="right">默认调拨价格：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddl_parm1" runat="server" CssClass="pindl">
                        <asp:ListItem Value="1">零售价</asp:ListItem>
                        <asp:ListItem Value="2">进货价</asp:ListItem>
                        <asp:ListItem Value="3">内部价</asp:ListItem>
                        <asp:ListItem Value="4">旧货价</asp:ListItem>
                        <asp:ListItem Value="5">替代价</asp:ListItem>
                        <asp:ListItem Value="6">列表价</asp:ListItem>
                        <asp:ListItem Value="7">库存均价</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">默认保修周期：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tb_parm2" runat="server" CssClass="pin" Text='30'></asp:TextBox>
                    天
                </td>
            </tr>
            <tr>
                <td align="right">共享客户资料：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddl_parm3" runat="server" CssClass="pindl">
                        <asp:ListItem Value="1">不共享</asp:ListItem>
                        <asp:ListItem Value="2">共享</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">应收应付提醒周期：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbRecDue" runat="server" CssClass="pin" Text='30'></asp:TextBox>
                    天
                </td>
            </tr>
            <tr>
               <td align="right" colspan="2">必须新建服务项目才能完成关闭 <asp:CheckBox ID="cbbItemExit" runat="server" /></td>
                
                <td align="right">短信验证码：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tb_parm9" runat="server" CssClass="pin"></asp:TextBox></td>
            </tr>
            
            <tr>
            <td align="right" colspan="2">服务项目全部完工后才能完成关闭 <asp:CheckBox ID="cbbFinish" runat="server" /></td>
                
                <td>工单处理默认处理方式：</td>
                <td style="padding-left:0px;"><asp:DropDownList ID="ddlServicesDo" runat="server" CssClass="pindl">
                        <asp:ListItem Value="0">升级派工</asp:ListItem>
                        <asp:ListItem Value="1">完成关闭</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
            <td align="right" colspan="2">报价和项目金额一致才能完成关闭<asp:CheckBox ID="cbbFinish2" runat="server" /></td>
               
               
               <td>
               服务地图默认显示区域：
               </td>
               <td style="padding-left:0px;">
                   <div class="isinDiv">
                    <asp:TextBox ID="tbCity" runat="server" CssClass="pin pinin"></asp:TextBox>
                    <asp:DropDownList ID="ddlCity" runat="server" CssClass="pininsl" onchange="document.getElementById('tbCity').value=this.options[this.selectedIndex].text;">
                        <asp:ListItem Value="北京">北京</asp:ListItem>
                        <asp:ListItem Value="上海">上海</asp:ListItem>
                        <asp:ListItem Value="天津">天津</asp:ListItem>
                        <asp:ListItem Value="重庆">重庆</asp:ListItem>
                        <asp:ListItem Value="合肥">合肥</asp:ListItem>
                        <asp:ListItem Value="福州">福州</asp:ListItem>
                        <asp:ListItem Value="兰州">兰州</asp:ListItem>
                        <asp:ListItem Value="广州">广州</asp:ListItem>
                        <asp:ListItem Value="深圳">深圳</asp:ListItem>
                        <asp:ListItem Value="石家庄">石家庄</asp:ListItem>
                        <asp:ListItem Value="哈尔滨">哈尔滨</asp:ListItem>
                        <asp:ListItem Value="武汉">武汉</asp:ListItem>
                        <asp:ListItem Value="长沙">长沙</asp:ListItem>
                        <asp:ListItem Value="南京">南京</asp:ListItem>
                        <asp:ListItem Value="南昌">南昌</asp:ListItem>
                        <asp:ListItem Value="沈阳">沈阳</asp:ListItem>
                        <asp:ListItem Value="西安">西安</asp:ListItem>
                        <asp:ListItem Value="太原">太原</asp:ListItem>
                        <asp:ListItem Value="成都">成都</asp:ListItem>
                        <asp:ListItem Value="杭州">杭州</asp:ListItem>
                        <asp:ListItem Value="温州">温州</asp:ListItem>
                        <asp:ListItem Value="乌鲁木齐">乌鲁木齐</asp:ListItem>
                    </asp:DropDownList>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="2">服务单技术员为空时可以完成关闭 <asp:CheckBox ID="cbbTec" runat="server" /></td>
                <td colspan="2">
                   服务单 <asp:TextBox ID="tbiRepair" runat="server" CssClass="pin" Width="60"></asp:TextBox>
                   天内再次维修的为返修
                </td>
            </tr>
            <tr>
                <td align="right" colspan="2">服务单应收金额为零跳过完工结算环节 <asp:CheckBox ID="cbbBln" runat="server" /></td>
                <td colspan="2">
                    <label for="cbPurSep">采购单号分离</label><asp:CheckBox ID="cbPurSep" runat="server" />
                    <label for="cbSellSep">销售单号分离</label><asp:CheckBox ID="cbSellSep" runat="server" />
                    <label for="cbSerBillSeparate">服务单号分离</label><asp:CheckBox ID="cbSerBillSeparate" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" colspan="2">
                   总部结算<asp:CheckBox ID="cbHead" runat="server" />报称故障禁止手动输入 <asp:CheckBox ID="cbFaultNoInput" runat="server" /></td>
                <td align="left" colspan="2">处理措施/结果禁止手动输入 <asp:CheckBox ID="cbTakeStepsNoInput" runat="server" /></td>
            </tr>
            <tr>
                <td colspan="4">工单完成关闭时强制输入工单处理中上门时间/处理时长/完成时间/故障原因 <asp:CheckBox ID="cbEnforceInput" runat="server" /></td>
            </tr>
        </table>
    </fieldset>
        </td>
        </tr>
        </table>
      </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    </div>
<div id="info2" style="padding:3px 0px 0px 3px;">
    <div id="div2" class="divinfo" style="height:371px;">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb3" width="580">
            <tr><td>
        <fieldset style="padding:5px 0;">
        <legend style="color:#0000ff">邮件设置</legend>
            <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                    <td align="right">邮件服务器：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tb_parm5" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td align="right">登陆用户名：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tb_parm6" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    
                </tr>
                <tr>
                    <td align="right">登陆密码：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tb_parm7" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td align="right">邮件地址：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tb_parm8" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    
                </tr>
            </table>
        </fieldset>
         <fieldset style="padding:5px 0;">
        <legend style="color:#0000ff">登录设置</legend>
        <table cellpadding="0" cellspacing="0" class="tb3">
            <tr>
                <td align="right" style="padding-left:40px;">登录不显示下拉框：</td>
                <td style="padding-left:0px;">
                    <asp:CheckBox ID="cbLoginDLL" runat="server" />
                </td>
                <td align="right">登录不显示验证码：</td>
                <td style="padding-left:0px;">
                    <asp:CheckBox ID="cbVerifyCode" runat="server" onclick="checkCode(this)" />
                </td>
                <td align="right">登录不显示记住密码：</td>
                <td style="padding-left:0px;">
                    <asp:CheckBox ID="cbRememberPassword" runat="server" onclick="checkCode(this)" />
                </td>
            </tr>
            <tr>
                <td align="right">登录无需手机验证：</td>
                <td style="padding-left:0px;">
                    <asp:CheckBox ID="cbPhone" runat="server" onclick="needPhoneChk();"/>
                </td>
            </tr>
            </table>
            </fieldset>
            </td>
            </tr>
            </table>
       </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    </div>
    <div id="info3" style="height:380px;">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
         <ContentTemplate>
        <asp:GridView ID="GridView1" runat="server" SkinID="gv4" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="id" DataField="id" />
                <asp:BoundField HeaderText="序" />
                <asp:BoundField HeaderText="单据类型" DataField="Type" />
                <asp:BoundField HeaderText="单据代号" DataField="Code" />
                <asp:BoundField HeaderText="编号方式" DataField="Style" />
                <asp:BoundField HeaderText="分隔符" DataField="Tally" />
                <asp:BoundField HeaderText="起始编号" DataField="BeginNO" />
                <asp:BoundField HeaderText="例子" DataField="Model" />
            </Columns>
        </asp:GridView>
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
        <span style="display:none;">
            <asp:Button ID="btnRef" runat="server" Text="btnRef" OnClick="btnRef_Click" /></span>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnRef" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
    </div>
    
    <div id="info4" style="padding:3px 0px 0px 3px; overflow:hidden;">
    <div id="divinfo4" class="divinfo" style="height:371px;">
        <table cellpadding="0" cellspacing="0" class="tb3" width="580">
            <tr><td>
        <fieldset style="padding:5px 0;">
        <legend style="color:#0000ff">参数设置</legend>
        <table cellpadding="0" cellspacing="0" class="tb3" style="width:100%;">
            <tr>
            <td align="right" colspan="2" style="width:270px;">采购订单控制采购数量 <asp:CheckBox ID="cbPlanControl" runat="server" /></td>
            <td colspan="2" style="width:270px;">采购金额为0时禁止审核 <asp:CheckBox ID="cbbZeroPurchase" runat="server" /></td>
            </tr>
            <tr>
            <td align="right" colspan="2">拆装关系控制 <asp:CheckBox ID="cbDisblingControl" runat="server" /></td>
            <td align="right" style="width:100px;">自动锁定时间：</td>
            <td align="left" style="padding:0px;width:150px;">
                <asp:TextBox ID="tbLockTime" runat="server" Width="50"></asp:TextBox>分</td>
            </tr>
            <tr>
            <td align="right" colspan="2">合同机器唯一 <asp:CheckBox ID="cbDeviceOnly" runat="server" /></td>
            <td></td>
            </tr>
            <tr>
                <td align="right">新建商品成本算法</td>
                <td><asp:DropDownList ID="ddlCostMode" runat="server">
                    <asp:ListItem Value="2">移动加权平均法</asp:ListItem>
                    <asp:ListItem Value="1">先进先出法</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
        </table>
        </fieldset>
        </td>
        </tr>
        </table>
    </div>
    </div>
    <div id="info5" style="padding:3px 0px 0px 3px;">
    <div id="div3" class="divinfo" style="height:371px;">
        <fieldset style="padding:5px 0;">
           <legend style="color:#0000ff">允许访问IP地址设置(外网IP)</legend> 
            <table style="margin:auto;">
            <tr>
            <td>IP起始地址</td>
            <td><asp:TextBox ID="tbIPStar" runat="server" ></asp:TextBox></td>
            <td>IP结束地址</td>
            <td><asp:TextBox ID="tbIPEnd" runat="server" ></asp:TextBox></td>
            </tr>
            </table>
        </fieldset>
        <fieldset style="padding:5px 0;">
           <legend style="color:#0000ff">例外允许访问用户设置</legend> 
            <table style="margin:auto;">
            <tr>
            <td align="center">用户名</td>
            <td align="center">备注</td>
            </tr>
            <tr>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>--请选择--</asp:ListItem>
                </asp:DropDownList></td>
            <td><asp:TextBox ID="TextBox1" runat="server" Width="240px" ></asp:TextBox></td>
            </tr>
            <tr>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server">
                <asp:ListItem>--请选择--</asp:ListItem>
                </asp:DropDownList></td>
            <td><asp:TextBox ID="TextBox2" runat="server" Width="240px" ></asp:TextBox></td>
            </tr>
            <tr>
            <td>
                <asp:DropDownList ID="DropDownList3" runat="server">
                <asp:ListItem>--请选择--</asp:ListItem>
                </asp:DropDownList></td>
            <td><asp:TextBox ID="TextBox3" runat="server" Width="240px" ></asp:TextBox></td>
            </tr>
            <tr>
            <td>
                <asp:DropDownList ID="DropDownList4" runat="server">
                <asp:ListItem>--请选择--</asp:ListItem>
                </asp:DropDownList></td>
            <td><asp:TextBox ID="TextBox4" runat="server" Width="240px" ></asp:TextBox></td>
            </tr>
            <tr>
            <td>
                <asp:DropDownList ID="DropDownList5" runat="server">
                <asp:ListItem>--请选择--</asp:ListItem>
                </asp:DropDownList></td>
            <td><asp:TextBox ID="TextBox5" runat="server" Width="240px" ></asp:TextBox></td>
            </tr>
            <tr>
            <td>
                <asp:DropDownList ID="DropDownList6" runat="server">
                <asp:ListItem>--请选择--</asp:ListItem>
                </asp:DropDownList></td>
            <td><asp:TextBox ID="TextBox6" runat="server" Width="240px" ></asp:TextBox></td>
            </tr>
            <tr>
            <td>
                <asp:DropDownList ID="DropDownList7" runat="server">
                <asp:ListItem>--请选择--</asp:ListItem>
                </asp:DropDownList></td>
            <td><asp:TextBox ID="TextBox7" runat="server" Width="240px" ></asp:TextBox></td>
            </tr>
            <tr>
            <td>
                <asp:DropDownList ID="DropDownList8" runat="server">
                <asp:ListItem>--请选择--</asp:ListItem>
                </asp:DropDownList></td>
            <td><asp:TextBox ID="TextBox8" runat="server" Width="240px" ></asp:TextBox></td>
            </tr>
            </table>
        </fieldset>
        <table style="margin:auto;" width="85%">
            <tr>
                <td align="right"> 访问限制:<asp:CheckBox ID="CheckBox1" runat="server" /><label for="CheckBox1" style="font-size:large;color:Red">开启</label>
                </td>
            </tr>
            <tr><td align="left" style="font-size:small;color:Red;">*设置IP地址段并且启用，该例外设置才会生效</td></tr>
        </table>
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td></td>
        <td align="right">
            <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnSave_Click" />
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
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
var tabnum=6;
function ChkID(id)
{
    ClrBaseID(id);
}
function ChkSave()
{
    if(!isNull($("tbBranchNum").value))
    {
        if(!isDigit($("tbBranchNum").value))
        {
            window.alert("用户数格式不正确.");
            ChkTab('1');
            $("tbBranchNum").select();
            return false
        }
    }
    
    if(!isNull($("tb_parm2").value))
    {
        if(!isDigit($("tb_parm2").value))
        {
            window.alert("参数设置(默认维修保修周期)格式不正确.");
            ChkTab('1');
            $("tb_parm2").select();
            return false
        }
    }
    if(!isNull($("tbRecDue").value))
    {
        if(!isDigit($("tbRecDue").value))
        {
            window.alert("参数设置(应收应付提前提醒)格式不正确.");
            ChkTab('1');
            $("tbRecDue").select();
            return false
        }
    }
}
function EidtNO()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("请选择一条记录后操作！");
    }else
    {
        parent.ShowDialog1(400, 178, 'System/NOMod.aspx?id='+id, '修改');
    }
}
function needPhoneChk()
{
    if(document.getElementById("cbPhone").checked==false)
    {
        document.getElementById("cbVerifyCode").checked=true;
        document.getElementById("cbRememberPassword").checked=true;
    }
}
function checkCode(obj)
{
    if(obj.checked==false)
    {
        document.getElementById("cbPhone").checked=true;
    }
}
</script>
