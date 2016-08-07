<%@ page language="C#"  CodeFile="deviceview.aspx.cs"     autoeventwireup="true" inherits="Web_DeviceView" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="public/css/mysub.css" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div id="idiv">
    <div class="item"><span style="padding-right:30px;">机器档案</span><span id="span_info" style="display:none;"></span>
    </div>
    <div class="tool"></div>
    </div>
    <!-- -->
        <div style="padding-top:10px; padding-left:20px;">
        <p class="pt1">档案信息</p> 
        <table cellpadding="0" cellspacing="0" class="tb1">
                    <tr>
                    <td align="right">
                    联系人：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbName" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td align="right">所属部门：</td>
                    <td style="padding-left:0px;">
                          <asp:TextBox ID="tbDept" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td align="right">联系电话：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">手机号码：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbTel2" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right">传真：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbFax" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right">邮编：</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbZip" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr>
                <tr>
                    
                    <td align="right">联系地址：</td>
                    <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin" Width="365"></asp:TextBox></td>
                </tr>
            <tr>
                <td align="right" style="color:#800000;">机器编号：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbDeviceNO" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td align="right" style="color:#800000;">机器品牌：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbBrand" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td align="right">机器类别：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbClass" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td align="right">机器型号：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbModel" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td align="right" style="color:#800000;">序列号1：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSN1" runat="server" CssClass="pin"></asp:TextBox></td>
                <td align="right">序列号2：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSN2" runat="server" CssClass="pin"></asp:TextBox></td>
                
            </tr>
            <tr>
                <td align="right">机器外观：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbAspect" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td align="right">购买时间：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBuyDate" runat="server" CssClass="pin"></asp:TextBox></td>
                <td align="right">经销商：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBuyFrom" runat="server" CssClass="pin"></asp:TextBox></td>
                
            </tr>
            <tr>
                <td align="right">购买发票：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbInvoice" runat="server" CssClass="pin"></asp:TextBox></td>
                <td align="right">保修期：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbProt" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td align="right">保修情况：</td>
                <td align="right" style="padding-left:0px;">
                    <asp:TextBox ID="tbRepStatus" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                
            </tr>
            
            <tr>
                <td align="right">维修次数：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbRepNum" runat="server" CssClass="pin"></asp:TextBox></td>
                <td>厂家保修开始：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbWStart" runat="server" CssClass="pin"></asp:TextBox></td>
                <td>厂家保修截止：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbWEnd" runat="server" CssClass="pin"></asp:TextBox></td>
                
            </tr> 
             <tr>
                <td>最近维修时间：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbLastDate" runat="server" CssClass="pin"></asp:TextBox></td>
                <td>合同保修开始：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbPStart" runat="server" CssClass="pin"></asp:TextBox></td>
                <td>合同保修截止：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbPEnd" runat="server" CssClass="pin"></asp:TextBox></td>
                
            </tr>
            <tr>
                <td>维修保修截止：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbFinD" runat="server" CssClass="pin"></asp:TextBox></td>
                <td>维修合同编号：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbContractNO" runat="server" CssClass="pin"></asp:TextBox></td>
                <td align="right">安装日期：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbInStall" runat="server" CssClass="pin"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">备注：</td>
                <td colspan="5" style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="365"></asp:TextBox></td>
            </tr>
        </table>
        
        <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style=" padding-left:98px; padding-top:10px;">
                <input id="btnback" onclick="javascript:history.back();" type="button" value="返回" class="bt1 bt8" />
            </td>
        </tr>
        </table>
        <br />
        <p class="pt1">相关服务单</p> 
        <div class="list" id="list" style="height:135px; overflow:auto;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" EnableViewState="false" GridLines="None" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="服务单号" DataField="BillID" />
                <asp:BoundField HeaderText="报修时间" DataField="Time_Make" />
                <asp:BoundField HeaderText="当前状态" DataField="curStatus" />
                <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
                <asp:BoundField HeaderText="所属部门" DataField="UsePersonDept" />
                <asp:BoundField HeaderText="型号" DataField="ProductModel" />
                <asp:BoundField HeaderText="品牌" DataField="ProductBrand" />
                <asp:BoundField HeaderText="类别" DataField="ProductClass" />
                <asp:BoundField HeaderText="序列号" DataField="ProductSN1" />
                
                <asp:TemplateField HeaderText="操作"></asp:TemplateField>
                
            </Columns>
        </asp:GridView>
        </div>
        </div>
 <!--end-->
    </form>
</body>
</html>
