<%@ page language="C#"  CodeFile="serview.aspx.cs"     autoeventwireup="true" inherits="Web_SerView" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
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
                <td style="color:#800000">报修时间：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbTakeTime" runat="server" CssClass="pin" ReadOnly="true"></asp:TextBox>
                </td>
                <td>业务类别：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlOpType" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                <td>完成时间：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbTakeOver" runat="server" CssClass="pin" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="color:#800000">处理状态：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlcurStatus" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                <td >服务级别：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlServiceLevel" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>        
        <p class="pt1">机器信息</p>  
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td align="right" style="padding-left:0px;">
                报修人：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbUsePerson" runat="server" CssClass="pin"></asp:TextBox></td>
                
                <td align="right">
                报修电话：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbUsePersonTel" runat="server" CssClass="pin"></asp:TextBox></td>
                <td align="right" style="padding-left:0px;">
                所属部门：</td>
                <td style="padding-left:0px;">
                          <asp:TextBox ID="tbDept" runat="server" CssClass="pin"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">所属区域：</td>
                <td style="padding-left:0px;">
                        <asp:TextBox ID="tbArea" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td>联系地址：</td>
                <td colspan="3" style="padding-left:0px;">
                    <asp:TextBox ID="tbAdr" runat="server" CssClass="pin2" Width="341"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="color:#800000;">机器编号：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbDeviceNO" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td style="color:#800000">机器品牌：</td>
                <td style="padding-left:0px;">
                    <input type="text" id="tbBrand" runat="server" class="pin" />
                </td>
                <td>机器类别：</td>
                <td style="padding-left:0px;">
                    <input type="text" id="tbType" runat="server" class="pin" />
                </td>
                
            </tr>
            <tr>
                <td>机器型号：</td>
                <td style="padding-left:0px;">
                    <input type="text" id="tbStyle" runat="server" class="pin"/>
                </td>
                <td>机器外观：</td>
                <td style="padding-left:0px;">
                    <input type="text" id="tbAspect" runat="server" class="pin" />
                </td>
                <td align="right" style="color:#800000">序列号1：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSN1" runat="server" CssClass="pin"></asp:TextBox></td>
                
            </tr>
            <tr>
                <td align="right">序列号2：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSN2" runat="server" CssClass="pin"></asp:TextBox></td>
                <td>随机附件：</td>
                <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbAcc" runat="server" CssClass="pin" Width="341"></asp:TextBox></td>
                
            </tr>
            <tr>
                <td>购买时间：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBuyDate" runat="server" CssClass="pin"></asp:TextBox></td>
                <td align="right">经销商：</td>
                <td style="padding-left:0px;">
                    <input type="text" id="tbBuyStore" runat="server" class="pin" />
                </td>
                <td>购买发票：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBuyInvoice" runat="server" CssClass="pin"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="color:#800000" rowspan="2">报称故障：</td>
                <td colspan="3" rowspan="2" style="padding-left:0px;"><asp:TextBox ID="tbFault" runat="server" CssClass="pin" Width="341" Height="42" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td style="color:#800000">预约时间：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSubTime" runat="server" CssClass="pin"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="color:#800000">保修情况：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>货运方式：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlSndStyle" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                <td>物流单号：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbPostNO" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td>
                    物流费用：
                </td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbPostage" runat="server" CssClass="pin"></asp:TextBox>
                </td>
            </tr>
        </table>
        
        <p class="pt1">更换备件</p> 
        
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="98%">
            <Columns>
                <asp:BoundField HeaderText="编号" DataField="GoodsNO" />
                <asp:BoundField HeaderText="名称" DataField="_Name" />
                <asp:BoundField HeaderText="数量" DataField="Qty" HtmlEncode="false" DataFormatString="{0:n2}" />
                <asp:BoundField HeaderText="单价" DataField="Price" HtmlEncode="false" DataFormatString="{0:c2}"  />
                <asp:BoundField HeaderText="金额" DataField="Total" HtmlEncode="false" DataFormatString="{0:c2}"  />
                <asp:BoundField HeaderText="保修期" DataField="MaintenancePeriod" />
                <asp:BoundField HeaderText="保修截止日期" DataField="PeriodEndDate" />
            </Columns>
        </asp:GridView>
        
        <p class="pt1">维修项目</p>  
        
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="98%">
            <Columns>
                <asp:BoundField HeaderText="编号" DataField="ItemNO" />
                <asp:BoundField HeaderText="名称" DataField="_Name" />
                <asp:BoundField HeaderText="费用" DataField="Price" />
                <asp:BoundField HeaderText="工时" DataField="dPoint" />
                <asp:BoundField HeaderText="技术员" DataField="Tec" />
            </Columns>
        </asp:GridView>
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
