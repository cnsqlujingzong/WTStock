<%@ page language="C#"  CodeFile="inputsuplierlist.aspx.cs"     autoeventwireup="true" inherits="Branch_Basic_InputSuplierList" enableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="main">
        <div class="maincon">
        <div id="sa" style="width:586px;">
        <div class="fdiv">
            <div class="sdiv">
            <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                    <td align="right">请上传Excel文件：</td>
                    <td style="padding-left:0px;">
                    <a href="#" onclick="ChkUpload();" style="color:#0000ff;">点击上传</a>
                    <asp:HiddenField ID="hfPath" runat="server" />
                    <span style="display:none;">
                        <asp:Button ID="btnUp" runat="server" Text="up" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnUp_Click" /></span>
                    </td>
                </tr>
                <tr>
                    <td align="right">请选择Excel表名：</td>
                    <td style="padding-left:0px;">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                        <asp:DropDownList ID="ddlTableName" runat="server" CssClass="pindl" AutoPostBack="True" OnSelectedIndexChanged="ddlTableName_SelectedIndexChanged">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnUp" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
            </div>
            </div>
            <div class="divh"></div>
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" RenderMode="Inline">
               <ContentTemplate>
                <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                       <td align="right">厂商名称：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddl1" runat="server" CssClass="pindl">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right">厂商编号：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddl2" runat="server" CssClass="pindl">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="sysred" style="padding-left:5px;">
                            <asp:CheckBox ID="cbsys" runat="server" Text="系统默认" />
                        </td>
                    </tr>
                    <tr>
                       <td align=right>厂商类别：</td>
                        <td style="padding-left:0px;">
                              <div class="isinDiv">
                            <input type="text" id="tbSupClass" runat="server" class="pin pinin" readonly="readonly" />
                                <select id="slSupClass" runat="server" onchange="getclassvalue('tbSupClass',this.options[this.selectedIndex].text);" class="pininsl">
                                </select>
                            </div>
                        </td>
                        <td align="right">联系人：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddl3" runat="server" CssClass="pindl">
                            <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="padding-left:5px;"></td>
                    </tr>
                    <tr>
                        <td align="right">联系电话：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddl4" runat="server" CssClass="pindl">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right">手机号：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddl5" runat="server" CssClass="pindl">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>    
                         <td style="padding-left:5px;">
                            </td>    
                    </tr>
                    <tr>
                        <td align="right">传真：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddl6" runat="server" CssClass="pindl">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right">邮箱：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddl7" runat="server" CssClass="pindl">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>   
 <td style="padding-left:5px;">
                            </td> 
                    </tr>
                    <tr>
                        <td align="right">EMail：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddl8" runat="server" CssClass="pindl">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right">账户：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddl9" runat="server" CssClass="pindl">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="padding-left:5px;">
                            </td>
                    </tr>
                    <tr>    
                        <td align="right">地址：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddl10" runat="server" CssClass="pindl">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right">备注：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddl11" runat="server" CssClass="pindl">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="padding-left:5px;">
                            </td>
                    </tr>
                    <tr>
                        <td align="right">送修厂商：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddl12" runat="server" CssClass="pindl">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right">产品供应商：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddl13" runat="server" CssClass="pindl">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="padding-left:5px;"></td>
                    </tr>
                    <tr>
                        <td align="right">
                            特约维修结算厂商：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddl14" runat="server" CssClass="pindl">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="right"></td>
                        <td style="padding-left:0px;"></td>
                        <td style="padding-left:5px;"></td>
                    </tr>
                 </table>
               </ContentTemplate>
               <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="ddlTableName" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
            </div>
            </div>
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="确定" CssClass="bt1" OnClientClick="if(ChkAdd()==false) return;" UseSubmitBehavior="false" OnClick="btnAdd_Click"/>
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
<script language="javascript" type="text/javascript">
var processtip=1;

function ChkAdd()
{
    if($("ddlTableName").value=="")
    {
        alert("请选择Excel表名");
        $("ddlTableName").focus();
        return false;
    }
    
    if($("ddl1").value=="")
    {
        alert("请选择厂商名称");
        $("ddl1").focus();
        return false;
    }
}
function ChkUpload()
{
    parent.ShowDialog1(600, 380, 'System/UpLoadExcel.aspx', '上传Excel');
}
</script>