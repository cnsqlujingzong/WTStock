<%@ page language="C#"  CodeFile="softreg.aspx.cs"     autoeventwireup="true" inherits="Headquarters_System_SoftReg" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sa" style="width:586px;">
    <div id="tdiv1">
        <div class="fdiv">
        <div class="sdiv" style="height:230px;background:#fff;">
        <div style="height:228px; overflow:auto;">
        <p style="font-size:14px;">第一步：按照我们提供的汇款方式汇款。</p>
        <p>====================================================</p>
        
        <p><span>1、软件注册费用</span><br />
           <span style="color:#4b4b4b; padding-left:20px;">请来电咨询，或者咨询当地代理商。</span></p>
           
        <p><span>2、为什么要注册</span><br />
           <span style="color:#4b4b4b; padding-left:20px; line-height:150%;">您的注册是对我们工作的支持，也是我们开发的动力，注册后可以得到更为周到的售后服务，注册后软件将不作任何限制。</span></p>
        
        <p><span>3、我们可以接受的汇款方式</span><br /></p>
        <p style="line-height:150%;">   
            ■招商银行一卡通<br />
            户名：刘义，帐号：6225 8857 1264 3923<br />
            开户行：杭州市招商银行<br /><br />
            
            ■工商银行牡丹灵通卡<br />
            户名：刘义，帐号：1202020101016876557<br /><br />
            
            ■建设银行龙卡<br />
            户名：刘义<br />
            卡号：4367 4215 4080 0070 331<br /><br />
            
            ■农业银行<br />
            户名：刘义，帐号：95599 8032 00598 26216<br />
            开户行：杭州市农业银行<br /><br />
            
            ■通过邮局电汇<br />
            地址：杭州市西湖区西湖科技园振中路210号艾成科技园6号楼三楼<br />
            邮编：310012<br />
            收款人：刘义<br /><br />
            
            ■您也可以通过我们的代理商完成注册，为了安全，请先通过电话向我们核对代理商信息。</p>
            
        <p><span>4、联系我们</span><br /></p>
        <p style="line-height:150%;">
        电子邮件：liuyi@differsoft.com 或 huadog@yeah.net<br />
        电话：0571-88223317，88223312，13157103546<br />    
        主页：http://www.differsoft.com<br />
        联系人：刘先生  <br />
        </p>
           
        </div>
        </div>
        </div>
        
        <div class="divh"></div>
        <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="right">
                <input id="btnStep2" type="button" value="下一步:递交用户信息" onclick="ChkPane('tdiv2');document.getElementById('tbName').select();"/>
            </td>
        </tr>
        </table>
        
    </div>
    
    <div id="tdiv2" style=" display:none;">
    
    <div style="font-size:14px; padding:5px">第二步：递交用户信息，注册信息必须和系统设置里信息一致。</div>
    <div class="fdiv">
    <div class="sdiv" style="background:#ffffff;height:203px;">
        <div style="padding:5px 0px 0px 0px; height:200px;">
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td>公司名称：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbName" runat="server" CssClass="pin" Width="200"></asp:TextBox>
                <span style="color:#ff0000">*</span>
                </td>
            </tr>
            <tr>
                <td>联系电话：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin" Width="200"></asp:TextBox>
                <span style="color:#ff0000">*</span>
                </td>
            </tr>
            <tr>
                <td>邮政编码：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbZip" runat="server" CssClass="pin" Width="200"></asp:TextBox>
                <span style="color:#ff0000">*</span>
                </td>
            </tr>
            <tr>
                <td align="right">地址：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin" Width="200"></asp:TextBox>
                <span style="color:#ff0000">*</span>
                </td>
            </tr>
            <tr>
                <td align="right">
                <asp:DropDownList ID="ddlbSim" runat="server" CssClass="pindl" Width="60px">
                <asp:ListItem Value="0">用户数</asp:ListItem>
                <asp:ListItem Value="1">并发数</asp:ListItem>
                </asp:DropDownList>：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBranchNum" runat="server" CssClass="pin pbb" Width="200"></asp:TextBox>
                <span style="color:#ff0000">*</span>
                </td>
            </tr>
            <tr>
                <td align="right">Web模块：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlWeb" runat="server" CssClass="pindl">
                        <asp:ListItem Value="0">未购买Web模块</asp:ListItem>
                        <asp:ListItem Value="1">已购买Web模块</asp:ListItem>
                    </asp:DropDownList>
                <span style="color:#ff0000">*</span>
                </td>
            </tr>
        </table>
        </div> 
    </div>
    </div>
    
    <div class="divh"></div>
        <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td><asp:Button ID="btnSave" runat="server" Text="在线递交注册信息:" style="color:#ff0000" UseSubmitBehavior="false" OnClientClick="if(Chk('1')==false)return false;" OnClick="btnSave_Click" />
            </td>
            <td align="right">
                <input id="Button1" type="button" value="下一步:获得注册码" onclick="if(Chk('')!=false){ChkPane('tdiv3');}"/>
            </td>
        </tr>
        </table>
    </div>
   
    
    <div id="tdiv3" style=" display:none;">
    
    <div style="font-size:14px; padding:5px">
    <span style="color:#666">在线递交注册信息的用户，可以直接获得注册码。</span>
    <asp:Button ID="btnGet" runat="server" Text="点此获得注册码:"  UseSubmitBehavior="false" OnClick="btnGet_Click" />
    </div>
    <div class="fdiv">
    <div class="sdiv" style="height:198px; background:#ffffff">
        <div style="height:195px;padding:5px 0px 0px 0px;">
        <table cellpadding="0" cellspacing="0" class="tb3" style="margin-top:10px;">
            <tr>
                <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                <ContentTemplate>
                    输入注册码:
                    <asp:TextBox ID="tbRegCode" runat="server" Width="250"></asp:TextBox>
                  </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnGet" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
                </Triggers>
                </asp:UpdatePanel>   
                                 
                </td>
                <td>
                <asp:Button ID="btnFsh" runat="server" Text="完成注册:"  UseSubmitBehavior="false" OnClick="btnFsh_Click"/>
                <img src="../../Public/Images/ok.gif" alt="" />
                </td>
            </tr>
        </table>
    </div>
    </div>
    </div>
        
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td><input id="Button2" type="button" value="上一步:递交用户信息" onclick="ChkPane('tdiv2');document.getElementById('tbName').select();"/></td>
    </tr>
    </table>
    </div>
    
    </div>
    </div>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/menu.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
function Chk(f)
{
    if(isNull($("tbName").value))
    {
        window.alert("操作失败！公司名不能为空");
        $("tbName").select();
        return false;
    }
    if(isNull($("tbTel").value))
    {
        window.alert("操作失败！联系电话不能为空");
        $("tbTel").select();
        return false;
    }
    if(isNull($("tbZip").value))
    {
        window.alert("操作失败！邮政编码不能为空");
        $("tbZip").select();
        return false;
    }
    if(isNull($("tbAdr").value))
    {
        window.alert("操作失败！地址不能为空");
        $("tbAdr").select();
        return false;
    }
    
    if(isNull($("tbBranchNum").value))
    {
        window.alert("操作失败！用户数不能为空");
        $("tbBranchNum").select();
        return false;
    }
    if(!isNull($("tbBranchNum").value))
    {
        if(!isDigit($("tbBranchNum").value))
        {
            window.alert("用户数格式不正确.");
            $("tbBranchNum").select();
            return false;
        }
    }
    if(f=="1"){
    return confirm("确定要递交注册信息吗？如果已经递交过，请不要重复递交");}
}

function ChkPane(mdiv)
{
    $(mdiv).style.display="block";
    for(var i=1;i<=3;i++)
    {
        if(("tdiv"+i)!=mdiv)
        {
            $("tdiv"+i).style.display="none";
        }
    }
}
</script>
