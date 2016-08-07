<%@ page language="C#"  CodeFile="reportview.aspx.cs"     autoeventwireup="true" inherits="Web_ReportView" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" href="public/css/mysub.css" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div id="idiv">
    <div class="item"><span style="padding-right:30px;">工单详细</span><span id="span_info" style="display:none;"></span>
    </div>
    <div class="tool"></div>
    </div>
    
    <!-- -->
        <div style="padding-top:10px; padding-left:20px;">
        
        <p class="pt1">基本信息</p> 
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
            <td>报修会员：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbName" runat="server" CssClass="pin"></asp:TextBox>
            </td>
            <td>报修时间：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbTimeTake" runat="server" CssClass="pin"></asp:TextBox>
            </td>
            <td align="right">服务类别：</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlType" runat="server" CssClass="pindl">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="color:#800000;">客户名称：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbCusName" runat="server" CssClass="pin"></asp:TextBox>
                <asp:HiddenField ID="hfCusID" runat="server" />
            </td>
            <td align="right">报修人：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin"></asp:TextBox></td>
            <td align="right">报修人电话：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">使用人：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbUsePerson" runat="server" CssClass="pin"></asp:TextBox></td>
            <td>所属部门：</td>
            <td style="padding-left:0px;">
                <div class="isinDiv">
                    <input type="text" id="tbDept" runat="server" class="pin pinin"/>
                    <select id="slDept" onchange="document.getElementById('tbDept').value=this.options[this.selectedIndex].value" class="pininsl">
                        <option value="" selected="selected"></option>
                        <option value="销售部">销售部</option>
                        <option value="市场部">市场部</option>
                        <option value="人事部">人事部</option>
                    </select>
                </div>
            </td>
            <td>使用人电话：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbUsePersonTel" runat="server" CssClass="pin"></asp:TextBox></td>
        </tr>
        <tr>
            <td>所属区域：</td>
            <td style="padding-left:0px;">
                <div class="isinDiv">
                    <asp:TextBox ID="tbArea" runat="server" CssClass="pin pinin"></asp:TextBox>
                    <asp:DropDownList ID="ddlArea" runat="server" CssClass="pininsl" onchange="document.getElementById('tbArea').value=this.options[this.selectedIndex].text;">
                    </asp:DropDownList>
                </div>
            </td>
            <td>联系地址：</td>
            <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin" Width="353"></asp:TextBox>
            </td>
        </tr>
        </table>        
        
        <p class="pt1">机器信息</p>  
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td align="right" style="color:#800000;">机器编号：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbDeviceNO" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td align="right" style="color:#800000;">机器品牌：</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbBrand" runat="server" CssClass="pin pinin" AutoCompleteType="Disabled"></asp:TextBox>
                        <asp:DropDownList ID="ddlBrand" runat="server" CssClass="pininsl" onchange="document.getElementById('tbBrand').value=this.options[this.selectedIndex].text;">
                        </asp:DropDownList>
                    </div>
                </td>
                <td align="right">机器类别：</td>
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
                <td align="right">机器型号：</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbModel" runat="server" CssClass="pin pinin" AutoCompleteType="Disabled"></asp:TextBox>
                        <asp:DropDownList ID="ddlModel" runat="server" CssClass="pininsl" onchange="document.getElementById('tbModel').value=this.options[this.selectedIndex].text;">
                        </asp:DropDownList>
                    </div>
                </td>
                <td align="right">机器外观：</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbAspect" runat="server" CssClass="pin pinin"></asp:TextBox>
                         <asp:DropDownList ID="ddlAspect" runat="server" onchange="document.getElementById('tbAspect').value=this.options[this.selectedIndex].text;" CssClass="pininsl">
                         </asp:DropDownList>
                    </div>
                </td>
                <td align="right" style="color:#800000;">序列号1：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSN1" runat="server" CssClass="pin"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">序列号2：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSN2" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td align="right">随机附件：</td>
                <td style="padding-left:0px;" colspan="3"><asp:TextBox ID="tbAcc" runat="server" CssClass="pin" Width="341"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">购买时间：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBuyTime" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td align="right">经销商：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBuyFrom" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td align="right">购买发票：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBuyInvoice" runat="server" CssClass="pin"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="color:#800000;" rowspan="2">故障描述：</td>
                <td colspan="3" style="padding-left:0px;" rowspan="2"><asp:TextBox ID="tbFault" Height="42" TextMode="MultiLine" runat="server" CssClass="pin" Width="341"></asp:TextBox>
                </td>
                <td align="right" style="color:#800000;">保修情况：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlRepStatus" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>服务级别：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlPRI" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>货运方式：</td>
                <td style="padding:0px;">
                    <asp:DropDownList ID="ddlSndStyle" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                <td>预约时间：</td>
                <td style="padding:0px;"><asp:TextBox ID="tbSubTime" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td>物流单号：</td>
                <td style="padding:0px;"><asp:TextBox ID="tbPostNO" runat="server" CssClass="pin" ></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td>
                    物流费用：
                </td>
                <td style="padding:0px;">
                    <asp:TextBox ID="tbPostage" runat="server" CssClass="pin" ></asp:TextBox>
                </td>
                <td>备注信息：</td>
                <td colspan="5" style="padding:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="341"></asp:TextBox></td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style=" padding-left:74px;padding-top:10px;">
                <input id="btnback" onclick="javascript:history.back();" type="button" value="返回" class="bt1 bt8" />
            </td>
        </tr>
        </table>
    
    <!--end-->
    </div>
 
    </form>
</body>
</html>
