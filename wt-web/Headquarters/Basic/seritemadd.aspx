<%@ page language="C#"  CodeFile="seritemadd.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Basic_SerItemAdd" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body onload="ChkSetFocus('tbName');">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="main">
        <div class="maincon">
        <div id="sa" style="width:426px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                        <td class="blue" align="right">编号：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbItemID" runat="server" CssClass="pin"></asp:TextBox>
                        </td>
                        <td colspan="2" style="padding-left:5px;color:#ff0000;">
                            <asp:CheckBox ID="cbsys" runat="server" Text="系统默认" Checked="true" onclick="ChkSysNO();" /><asp:HiddenField ID="hfTemp" runat="server" /></td>
                    </tr>
                    <tr>
                        <td align="right" class="red">名称：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbName" runat="server" CssClass="pin"></asp:TextBox>
                        </td>
                        <td align="right">员工提成：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbDeduct" runat="server" CssClass="pin" onblur="ChkMoney(this);"></asp:TextBox>
                    </tr>
                    <tr>
                        <td align="right">价格：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbPrice" runat="server" CssClass="pin" onblur="ChkMoney(this);"></asp:TextBox>
                        </td>
                        <td align="right">保内价格：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbPricew" runat="server" CssClass="pin" onblur="ChkMoney(this);"></asp:TextBox>
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
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">

function ChkAdd()
{
        if(!$("cbsys").checked)
        {
            if(isNull($("tbItemID").value))
            {
                window.alert("操作失败！编号不能为空");
                $("tbItemID").focus();
                return false
            }
        }
        if(isNull($("tbName").value))
        {
            window.alert("操作失败！名称不能为空");
            $("tbName").focus();
            return false
        }
}

function ChkSysNO()
{
    if(!$("cbsys").checked)
    {
        $("tbItemID").disabled=false;
        $("tbItemID").focus();
    }else
    {
        $("tbItemID").disabled=true;
    }
}
function ChkMoney(obj)
{
    if(!isNull(obj.value))
    {
        if(!isMoney(obj.value))
        {
            alert("格式不正确，输入将被撤消");
            obj.value="";
            obj.focus();
            obj.select();
        }
    }
}

document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog<%=Str_F %>();}catch(e){}}}
</script>
