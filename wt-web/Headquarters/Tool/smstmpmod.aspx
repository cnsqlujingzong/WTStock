<%@ page language="C#"  CodeFile="smstmpmod.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Tool_SmsTmpMod" enableEventValidation="false" %>
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
    <div id="sad" style="width:586px;">
    <div class="fdiv" style="height:206px;">
    <div class="sdiv" style="background:#ECE9D8;height:201px; padding-top:3px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb4">
            <tr>
                <td>模板标题：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbTitle" runat="server" CssClass="pin" Width="180"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" style="height:28px;">
                <input id="it1" type="button" value="客户名称" class="bt1" onclick="Instr('{客户名称}');" />
                <input id="it2" type="button" value="客户电话" class="bt1" onclick="Instr('{客户电话}');" />
                <input id="it3" type="button" value="客户地址" class="bt1" onclick="Instr('{客户地址}');" />
                <input id="it4" type="button" value="联系人" class="bt1" onclick="Instr('{联系人}');" />
                <input id="it5" type="button" value="机器品牌" class="bt1" onclick="Instr('{机器品牌}');" />
                <input id="it6" type="button" value="机器类别" class="bt1" onclick="Instr('{机器类别}');" />
                <input id="it7" type="button" value="机器型号" class="bt1" onclick="Instr('{机器型号}');" />
                <input id="it22" type="button" value="服务级别" class="bt1" onclick="Instr('{服务级别}');" />
                </td>
            </tr>
            
            <tr>
                <td colspan="2"style="height:28px;">
                
                <input id="it8" type="button" value="序列号" class="bt1" onclick="Instr('{序列号}');" />
                <input id="it9" type="button" value="故障描述" class="bt1" onclick="Instr('{故障描述}');" />
                <input id="it10" type="button" value="预报价" class="bt1" onclick="Instr('{预报价}');" />
                <input id="it11" type="button" value="保修情况" class="bt1" onclick="Instr('{保修情况}');" />
                <input id="it12" type="button" value="购买日期" class="bt1" onclick="Instr('{购买日期}');" />
                <input id="it13" type="button" value="技术员" class="bt1" onclick="Instr('{技术员}');" />
                    <input id="it14" type="button" value="货运方式" class="bt1" onclick="Instr('{货运方式}');" />
                </td>
            </tr>
            <tr>
                <td colspan="2"style="height:28px;">
                    
                    <input id="it15" type="button" value="物流单号" class="bt1" onclick="Instr('{物流单号}');" />
                    <input id="it16" type="button" value="货品摘要" class="bt1" onclick="Instr('{货品摘要}');" />
                    <input id="it17" type="button" value="技术员电话" class="bt1" onclick="Instr('{技术员电话}');" />
                    <input id="it18" type="button" value="网点名称" class="bt1" onclick="Instr('{网点名称}');" />
                    <input id="it19" type="button" value="网点联系人" class="bt1" onclick="Instr('{网点联系人}');" />
                    <input id="it20" type="button" value="网点电话" class="bt1" onclick="Instr('{网点电话}');" />
                    <input id="it21" type="button" value="预约时间" class="bt1" onclick="Instr('{预约时间}');" />
                </td>

            </tr>
            <tr>
                <td>模板内容：</td>
                <td style="padding-left:0px; height:80px;"><asp:TextBox ID="tbContent" runat="server" TextMode="MultiLine" CssClass="pin" Height="70" Width="450"></asp:TextBox></td>
            </tr>
        </table>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="right">
            <asp:Button ID="btnSave" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnSave_Click" />
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
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
function ChkSave()
{
    if(isNull($("tbTitle").value))
    {
        window.alert("操作失败！模板标题不能为空");
        $("tbTitle").focus();
        return false
    }
    if(isNull($("tbContent").value))
    {
        window.alert("操作失败！模板内容不能为空");
        $("tbContent").focus();
        return false
    }
}
function Instr(str)
{
    var tc = document.getElementById("tbContent");
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
