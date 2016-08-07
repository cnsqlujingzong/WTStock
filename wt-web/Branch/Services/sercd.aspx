<%@ page language="C#"  CodeFile="sercd.aspx.cs"     autoeventwireup="true" inherits="Branch_Services_SerCd" enableEventValidation="false" %>
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
        <div id="sa" style="width:456px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
               <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                    <td align="right">受理时间：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbTakeB" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                    <td align="right">至：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbTakeE" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">制单时间：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbMakeB" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                    <td align="right">至：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbMakeE" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">受理部门：</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlTake" runat="server" CssClass="pindl">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">处理部门：</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlDisposal" runat="server" CssClass="pindl">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">服务单号：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbBillID" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right">受理方式：</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlTakeStyle" runat="server" CssClass="pindl">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">厂商单号：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbSupplierNO" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right">制单人：</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlMakeOper" runat="server" CssClass="pindl">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">存档单号：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbSaveNO" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right">受理人：</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">客户名称：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbCusName" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td align="right">报修人：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">报修人电话：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right">地址：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">机器品牌：</td>
                    <td style="padding-left:0px;">
                        <div class="isinDiv">
                        <asp:TextBox ID="tbBrand" runat="server" CssClass="pin pinin" AutoCompleteType="Disabled"></asp:TextBox>
                        <asp:DropDownList ID="ddlBrand" runat="server" CssClass="pininsl" onchange="document.getElementById('tbBrand').value=this.options[this.selectedIndex].text;">
                        </asp:DropDownList>
                        </div>
                    </td>
                    <td align="right">类别：</td>
                    <td style="padding-left:0px;">
                        <div class="isinDiv">
                        <asp:TextBox ID="tbClass" runat="server" CssClass="pin pinin" AutoCompleteType="Disabled">
                        </asp:TextBox>
                        <asp:DropDownList ID="ddlClass" runat="server" onchange="document.getElementById('tbClass').value=this.options[this.selectedIndex].text;" CssClass="pininsl">
                        </asp:DropDownList>
                    </div>
                    </td>
                </tr>
                <tr>
                    <td align="right">型号：</td>
                    <td style="padding-left:0px;">
                        <div class="isinDiv">
                        <asp:TextBox ID="tbModel" runat="server" CssClass="pin pinin" AutoCompleteType="Disabled"></asp:TextBox>
                        <asp:DropDownList ID="ddlModel" runat="server" CssClass="pininsl" onchange="document.getElementById('tbModel').value=this.options[this.selectedIndex].text;">
                        </asp:DropDownList>
                        </div>
                    </td>
                    <td align="right">序列号：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbSN" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">保修情况：</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlRepStatus" runat="server" CssClass="pindl">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">技术员：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbDisposalOper" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">服务级别：</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlPRI" runat="server" CssClass="pindl">
                            <asp:ListItem Value=""></asp:ListItem>
                            <asp:ListItem Value="普通">普通</asp:ListItem>
                            <asp:ListItem Value="紧急">紧急</asp:ListItem>
                            <asp:ListItem Value="缓慢">缓慢</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">是否返修：</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlbRepair" runat="server" CssClass="pindl">
                            <asp:ListItem Value=""></asp:ListItem>
                            <asp:ListItem Value="√">是</asp:ListItem>
                            <asp:ListItem Value="">否</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">故障：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbFault" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right">备注：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin"></asp:TextBox></td>
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
