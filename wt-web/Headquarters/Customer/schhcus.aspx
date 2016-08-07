<%@ page language="C#"  CodeFile="schhcus.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Customer_SchHCus" enableEventValidation="false" %>

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
        <div id="sa" style="width:446px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
               <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                    <td align="right">客户编号：</td>
                    <td style="padding-left:0px;">
                         <asp:TextBox ID="tbCusID" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td align="right">客户类别：</td>
                    <td style="padding-left:0px;">
                        <div class="isinDiv">
                            <input type="text" id="tbCusClass" runat="server" class="pin pinin" readonly="readonly" />
                                <select id="slCusClass" runat="server" onchange="getclassvalue('tbCusClass',this.options[this.selectedIndex].text);" class="pininsl">
                                </select>
                            </div>
                    </td>
                </tr>
                <tr>
                    <td align="right">客户状态：</td>
                    <td style="padding-left:0px;">
                          <asp:DropDownList ID="ddlStatus" runat="server" CssClass="pindl">
                            </asp:DropDownList>
                    </td>
                    <td align="right">联系人：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">联系电话：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right">QQ/MSN：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbQQ" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">客户来源：</td>
                    <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlFrom" runat="server" CssClass="pindl" onchange="NewFrom();">
                            </asp:DropDownList>
                    </td>
                    <td align="right">客户区域：</td>
                    <td style="padding-left:0px;">
                        <div class="isinDiv">
                        <asp:TextBox ID="tbArea" runat="server" CssClass="pin pinin"></asp:TextBox>
                        <asp:DropDownList ID="ddlArea" runat="server" CssClass="pininsl" onchange="document.getElementById('tbArea').value=this.options[this.selectedIndex].text;NewArea('1');">
                        </asp:DropDownList>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right">业务员：</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlSeller" runat="server" CssClass="pindl">
                        </asp:DropDownList>
                    </td>
                    <td align="right">会员级别：</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlMember" runat="server" CssClass="pindl">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                <td align="right">登记时间：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbDate_Begin" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                   <td align="right">至：</td>
                   <td style="padding-left:0px;"><asp:TextBox ID="tbDate_End" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                </tr> 
                <tr>
                    <td align="right">地址：</td>
                     <td style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server"  CssClass="pin"></asp:TextBox></td>
                    <td align="left" colspan="2" >回访:<asp:CheckBox ID="chkBaack" runat="server" />&nbsp;&nbsp;&nbsp;跟踪:<asp:CheckBox ID="chkTrace" runat="server" /></td>
                </tr>
                <tr>
                    <td colspan="2" align="center">超过 <asp:TextBox ID="tbDateOver" runat="server" CssClass="pin" Width="50">0</asp:TextBox> 天无业务往来</td>
                    <td align="right">保养计划：</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlMPlan" runat="server" CssClass="pindl">
                        <asp:ListItem Value="0">全部</asp:ListItem>
                        <asp:ListItem Value="1">有</asp:ListItem>
                        <asp:ListItem Value="2">无</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:TextBox ID="tbDays" runat="server" CssClass="pin" Width="30">0</asp:TextBox>天内维修<asp:TextBox ID="tbCounts" runat="server" CssClass="pin" Width="20">0</asp:TextBox>次以上
                    </td>
                </tr>
            </table>
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>
            </div>
            </div>
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td align="right">
                    <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnSch_Click"/>
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
