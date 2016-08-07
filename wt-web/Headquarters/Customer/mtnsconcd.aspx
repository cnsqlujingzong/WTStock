<%@ page language="C#"  CodeFile="mtnsconcd.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Customer_Mtnsconcd" enableEventValidation="false" %>

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
        <div id="sa" style="width:456px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
               <table cellpadding="0" cellspacing="0" class="tb3">
               <tr>
                    <td align="right">合同编号：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbContractNO" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td align="right">合同类别：</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlConType" runat="server" CssClass="pindl">
                        </asp:DropDownList>
                    </td>
               </tr>
               <tr>
                    <td align="right">签约日期：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbTakeB" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                    <td align="right">至：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbTakeE" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
               </tr>
               <tr>
                    <td align="right">当前状态：</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="pindl">
                            <asp:ListItem Value=""></asp:ListItem>
                            <asp:ListItem Value="1">将执行</asp:ListItem>
                            <asp:ListItem Value="2">正执行</asp:ListItem>
                            <asp:ListItem Value="3">已过期</asp:ListItem>
                            <asp:ListItem Value="4">已终止</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">客户名称：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbCusName" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
               </tr>
               <tr>
                    <td align="right">联系人：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbLinkman" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right">联系电话：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbLinkTel" runat="server" CssClass="pin"></asp:TextBox></td>
               </tr>
               <tr>
                    <td align="right">起始日期：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbStartB" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                    <td align="right">至：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbStartE" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
               </tr>
               <tr>
                    <td align="right">终止日期：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbEndB" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                    <td align="right">至：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbEndE" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
               </tr>
               <tr>
                    <td align="right">地址：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right">备注：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin"></asp:TextBox></td>
               </tr>
               <tr>
                    <td align="right">业务员：</td>
                    <td style="padding-left:0px;"><asp:DropDownList ID="ddlSeller" runat="server" CssClass="pindl"></asp:DropDownList></td>
                    <td align="right">经办人：</td>
                    <td style="padding-left:0px;"><asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl"></asp:DropDownList></td>
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
