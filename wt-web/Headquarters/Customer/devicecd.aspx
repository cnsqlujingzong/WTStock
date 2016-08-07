<%@ page language="C#" CodeFile="devicecd.aspx.cs"   autoeventwireup="true" inherits="Headquarters_Customer_DeviceCd" enableEventValidation="false" %>
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
        <div id="sa" style="width:496px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
               <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                    <td align="right">客户名称：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbCusName" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td style="padding:0px;"><input id="btnSlt" type="button" value="" onclick="SltCus();" class="bview"/></td>
                    <td align="right">机器编号：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbCusNO" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">联系人：</td>
                    <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin pinin"></asp:TextBox>
                        <asp:DropDownList ID="ddlLinkMan" runat="server" onchange="document.getElementById('tbLinkMan').value=this.options[this.selectedIndex].text" CssClass="pininsl">
                            <asp:ListItem></asp:ListItem>
                          </asp:DropDownList>
                    </div>
                    </td>
                    <td align="right" colspan="2">所属部门：</td>
                    <td style="padding-left:0px;">
                      <div class="isinDiv">
                          <asp:TextBox ID="tbDept" runat="server" CssClass="pin pinin"></asp:TextBox>
                          <asp:DropDownList ID="ddlDept" runat="server" onchange="document.getElementById('tbDept').value=this.options[this.selectedIndex].text" CssClass="pininsl">
                            <asp:ListItem></asp:ListItem>
                          </asp:DropDownList>
                      </div>
                    </td>
                </tr>
                <tr>
                    <td align="right">联系电话：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right" colspan="2">地址：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">品牌：</td>
                    <td style="padding-left:0px;">
                        <div class="isinDiv">
                        <asp:TextBox ID="tbBrand" runat="server" CssClass="pin pinin" AutoCompleteType="Disabled"></asp:TextBox>
                        <asp:DropDownList ID="ddlBrand" runat="server" CssClass="pininsl" onchange="document.getElementById('tbBrand').value=this.options[this.selectedIndex].text;">
                        </asp:DropDownList>
                        </div>
                    </td>
                    <td align="right" colspan="2">类别：</td>
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
                    <td align="right" colspan="2">序列号：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbSN" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">保修期：</td>
                    <td style="padding-left:0px;">
                        <div class="isinDiv">
                        <input type="text" id="tbProt" runat="server" class="pin pinin" />
                            <select id="Select1" onchange="document.getElementById('tbProt').value=this.options[this.selectedIndex].value" class="pininsl">
                                <option value="" selected="selected"></option>
                                <option value="无保修">无保修</option>
                                <option value="一个月">一个月</option>
                                <option value="三个月">三个月</option>
                                <option value="六个月">六个月</option>
                                <option value="一年">一年</option>
                                <option value="两年">两年</option>
                                <option value="三年">三年</option>
                                <option value="五年">五年</option>
                                <option value="终生">终生</option>
                            </select>
                        </div>
                    </td>
                    <td align="right" colspan="2">保修情况：</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlRepStatus" runat="server" CssClass="pindl">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">外观：</td>
                    <td style="padding-left:0px;">
                        <div class="isinDiv">
                            <input type="text" id="tbAspect" runat="server" class="pin pinin" />
                             <asp:DropDownList ID="ddlAspect" runat="server" onchange="document.getElementById('tbAspect').value=this.options[this.selectedIndex].text;" CssClass="pininsl">
                             </asp:DropDownList>
                        </div>
                    </td>
                    <td align="right" colspan="2">经销商：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbBuyFrom" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">厂家保修开始：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbWStart" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                    <td align="right" colspan="2">厂家保修截至：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbWEnd" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">最近维修时间：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbLastDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                    <td align="right" colspan="2">维修保修截至：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbFinD" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">合同保修开始：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbPStart" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                    <td align="right" colspan="2">合同保修截至：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbPEnd" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">维修合同编号：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbContractNO" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right" colspan="2">备注：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">客户类别：</td>
                    <td style="padding-left:0px;">
                            <div class="isinDiv">
                                <input type="text" id="tbCusClass" runat="server" class="pin pinin" readonly="readonly" />
                                    <select id="slCusClass" runat="server" onchange="getclassvalue('tbCusClass',this.options[this.selectedIndex].text);" class="pininsl">
                                    </select>
                                </div>
                            </td>
                    <td align="right" colspan="2">客户区域：</td>
                        <td style="padding-left:0px;">
                        <div class="isinDiv">
                        <asp:TextBox ID="tbArea" runat="server" CssClass="pin pinin"></asp:TextBox>
                        <asp:DropDownList ID="ddlArea" runat="server" CssClass="pininsl" onchange="document.getElementById('tbArea').value=this.options[this.selectedIndex].text;NewArea('1');">
                        </asp:DropDownList>
                        </div>
                        </td>
                </tr>
                <tr>
                    <td align="right">保养计划：</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlMPlan" runat="server" CssClass="pindl">
                        <asp:ListItem Value="0">全部</asp:ListItem>
                        <asp:ListItem Value="3">正常</asp:ListItem>
                        <asp:ListItem Value="4">终止</asp:ListItem>
                        <asp:ListItem Value="5">已过期</asp:ListItem>
                        <asp:ListItem Value="2">无</asp:ListItem>
                        </asp:DropDownList></td>
                    <td colspan="3" align="center">
                        <asp:TextBox ID="tbDays" runat="server" CssClass="pin" Width="30">0</asp:TextBox>天内维修<asp:TextBox ID="tbCounts" runat="server" CssClass="pin" Width="20">0</asp:TextBox>次以上
                    </td>
                </tr>
            </table>
            </ContentTemplate>
            <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnCusInfo" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>
            </div>
            </div>
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hfCusID" runat="server" />
                    <span style="display:none;">
                        <asp:Button ID="btnCusInfo" runat="server" Text="CusInfo" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnCusInfo_Click"/>
                    </span>
                </td>
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
<script language="javascript" type="text/javascript">

function SltCus()
{
    parent.ShowDialog1(800, 500, 'Customer/SltCus.aspx?f=2', '选择客户');
}

</script>
>