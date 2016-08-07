<%@ page language="C#"  CodeFile="usermanagemod.aspx.cs"     autoeventwireup="true" inherits="Branch_System_UserManageMod" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="main">
        <div class="maincon">
        <div id="sa" style="width:686px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                    <td align="right">用户名：</td>
                    <td style="padding-left:0px;">
                        <div class="isinDiv">
                        <asp:TextBox ID="tbName" runat="server" CssClass="pin pinin" Width="186" onblur="ChkStaff();"></asp:TextBox>
                        <asp:DropDownList ID="ddlStaff" runat="server" style="width:206px;height:20px;clip: rect(auto auto auto 189px); position: absolute;" onchange="document.getElementById('tbName').value=this.options[this.selectedIndex].text;">
                        </asp:DropDownList>
                        </div>
                    </td>
                    <td><span class="si2">(用户名即员工的姓名，每个用户对应着一位员工)</span></td>
                </tr>
                <tr>
                    <td align="right">密码：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbPsw" runat="server" CssClass="pin" Width="200" TextMode="Password"></asp:TextBox>
                    </td>
                    <td><asp:CheckBox ID="cb_ps" runat="server" onclick="ChkPwd(this);" TabIndex="-1" /> 修改密码</td>
                </tr>
                <tr>
                    <td align="right">权限组：</td>
                    <td style="padding-left:0px;" colspan="2">
                        <asp:DropDownList ID="ddlRight" runat="server" CssClass="pindl" Width="206">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>当前状态：</td>
                    <td style="padding-left:0px;" colspan="2">
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="pindl" Width="206">
                            <asp:ListItem Value="正常">正常</asp:ListItem>
                            <asp:ListItem Value="锁定">锁定</asp:ListItem>
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
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:Label ID="lbInfo" runat="server" Visible="false" style=" background:#dd0000; color:#ffffff; padding:2px 15px;"></asp:Label>
                    <asp:HiddenField ID="hfTemp" runat="server" />
                </td>
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="确定" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
                    <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog('1');"/>
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
    if(isNull($("tbName").value))
    {
        window.alert("操作失败！用户名不能为空");
        $("tbName").focus();
        return false
    }
    if($("tbPsw").value.length==0||$("tbPsw").value.length>20)
    {
        window.alert("操作失败！密码长度必须在1-20位之间");
        $("tbPsw").focus();
        return false
    }
    if($("ddlRight").value=="-1")
    {
        window.alert("操作失败！请选择所属权限组");
        $("ddlRight").focus();
        return false
    }
}

function ChkStaff()
{
    var bnull=true;
    if(!isNull($("tbName").value))
    {
        var ddlgradelevel=$("ddlStaff");
        if($("tbName").value!=ddlgradelevel.options[ddlgradelevel.selectedIndex].text)
        {
            for(var i=0;i<ddlgradelevel.options.length;i++)
            {
                if(ddlgradelevel.options[i].value!="0")
                {
                    if(ddlgradelevel.options[i].text==$("tbName").value)
                    {
                        ddlgradelevel.options[i].selected=true;
                        bnull=false;
                    }
                }else{$("tbName").value="";}
            }
            
            if(bnull)
            {
                for(var i=0;i<ddlgradelevel.options.length;i++)
                {
                    if(ddlgradelevel.options[i].text=="")
                    {
                        ddlgradelevel.options[i].selected=true;
                    }
                }
                $("tbName").value="";
            }
        }
    }
}

function ChkPwd(obj)
{
    $("tbPsw").value=obj.checked?"":"**********";
    if(obj.checked){$("tbPsw").disabled=false;$("tbPsw").select();}else{$("tbPsw").disabled=true;};
}
</script>
