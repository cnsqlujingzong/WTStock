<%@ page language="C#"  CodeFile="cuslinkmanadd.aspx.cs"     autoeventwireup="true" inherits="Branch_Customer_CusLinkManAdd" enableEventValidation="false" %>
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
        <div id="sa" style="width:446px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
               <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                    <td align="right">姓名：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbName" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right">所属部门：</td>
                    <td style="padding-left:0px;">
                        <div class="isinDiv">
                          <asp:TextBox ID="tbDept" runat="server" CssClass="pin pinin"></asp:TextBox>
                          <asp:DropDownList ID="ddlDept" runat="server" onchange="document.getElementById('tbDept').value=this.options[this.selectedIndex].value" CssClass="pininsl">
                            <asp:ListItem></asp:ListItem>
                          </asp:DropDownList>
                      </div>
                    </td>
                </tr>
                <tr>
                    <td align="right">性别：</td>
                    <td style="padding-left:0px;">
                        <div class="isinDiv">
                        <input type="text" id="tbSex" runat="server" class="pin pinin"/>
                            <select id="slSex" onchange="document.getElementById('tbSex').value=this.options[this.selectedIndex].value" class="pininsl">
                                <option value="" selected="selected"></option>
                                <option value="男">男</option>
                                <option value="女">女</option>
                            </select>
                        </div>
                    </td>
                    <td align="right">职位：</td>
                    <td style="padding-left:0px;">
                        <div class="isinDiv">
                        <input type="text" id="tbPosition" runat="server" class="pin pinin"/>
                            <select id="slPosition" onchange="document.getElementById('tbPosition').value=this.options[this.selectedIndex].value" class="pininsl">
                                <option value="" selected="selected"></option>
                                <option value="技术员">技术员</option>
                                <option value="业务员">业务员</option>
                            </select>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right">办公电话：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbTel1" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right">宅电：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbTel2" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">移动电话：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbTel3" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right">传真：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbFax" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">生日：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbBirthDay" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
                    </td>
                    <td align="right">Email：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbEmail" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">地址：</td>
                    <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin" Width="341"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">备注：</td>
                    <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="341"></asp:TextBox></td>
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
                    <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog<%=Str_D %>();"/>
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
<script language="javascript" type="text/javascript">
var isfocus=1;
var processtip=1;
function ChkSave()
{
    if(isNull($("tbName").value))
    {
        window.alert("操作失败!姓名不能为空");
        $("tbName").focus();
        return false
    }
}

function ChkAdd(str)
{
    parent.iframeDialog<%=Str_F %>.$("hfLinkMan").value=str;
    parent.iframeDialog<%=Str_F %>.$("btnAddLinkMan").click();
    
    if($("cbClose").checked)
        parent.CloseDialog<%=Str_D %>();
}
document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog<%=Str_D %>();}catch(e){}}}
</script>
