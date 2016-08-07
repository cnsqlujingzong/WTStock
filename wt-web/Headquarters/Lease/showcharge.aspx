<%@ page language="C#"  CodeFile="showcharge.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Lease_ShowCharge" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:686px;">
    
    <fieldset style=" border: 1px #808080 solid; padding:5px 0; width:680px;">
      <legend>基础租金</legend>
      <table cellpadding="0" cellspacing="0" class="tb5">
            <tr>
                <td>结算周期：</td>
                <td style="padding:0px;">
                    <asp:TextBox ID="tbCycle" runat="server" CssClass="pinb" Width="102" ReadOnly="true"></asp:TextBox>
                </td>
                <td style="padding-left:5px;padding-right:5px;">=</td>
                <td style="padding:0px;">
                    <asp:TextBox ID="tbStartDate" runat="server" CssClass="Wdate" Width="120"></asp:TextBox>
                </td>
                <td style="padding-left:5px;padding-right:5px;">至</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbEndDate" runat="server" CssClass="Wdate"  Width="120"></asp:TextBox>
                </td>
            </tr>
       </table>
       <table cellpadding="0" cellspacing="0" class="tb5">   
            <tr>
                <td class="sysred" align="right" width="59">总租金：</td>
                <td style="padding:0px;">
                    <asp:TextBox ID="tbARent" runat="server" CssClass="pin" Width="100"></asp:TextBox>
                </td>
                <td style="padding-left:5px;padding-right:5px;">=</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbCycled" runat="server" CssClass="pinb" Width="122" ReadOnly="true"></asp:TextBox>
                </td>
                <td style="padding-left:3px;padding-right:5px;">×</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbRent" runat="server" CssClass="pinb" Width="122" ReadOnly="true"></asp:TextBox>
                </td>
                <td style="padding-left:5px;" class="layd">
                     (周期×基础租金)
                </td>
            </tr>
        </table>
      </fieldset>
      <div class="divh"></div>
        <div class="fdivs" style="width:684px; height:255px;">
        <div class="sdivs" style="width:682px; height:253px; overflow:auto; background:#ffffff;">
            <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvdata_RowDataBound" ShowFooter="true">
                <Columns>
                <asp:BoundField HeaderText="序" DataField="ID" />
                <asp:BoundField HeaderText="机器序列号" DataField="ProductSN1" />
                <asp:BoundField HeaderText="计数器类型" DataField="QtyTypeName" />
                <asp:BoundField HeaderText="计费方式" DataField="ChargeStyle" />
                <asp:BoundField HeaderText="本期" DataField="BenQty" />
                <asp:BoundField HeaderText="上期" DataField="ShangQty" />
                <asp:BoundField HeaderText="损耗张数" DataField="LossQty" />
                <asp:BoundField HeaderText="张数" DataField="Qty" HeaderStyle-ForeColor="#ff0000" />
                <asp:BoundField HeaderText="额定量" DataField="Rated" />
                <asp:BoundField HeaderText="超张费" DataField="SupperZhangFee" />
                <asp:BoundField HeaderText="总超张费" DataField="ZSupperZhangFee" HeaderStyle-ForeColor="#ff0000" />
                <asp:BoundField HeaderText="机器编号" DataField="DeviceNO" />
                <asp:BoundField HeaderText="机器品牌" DataField="Brand" />
                <asp:BoundField HeaderText="类别" DataField="Class" />
                <asp:BoundField HeaderText="型号" DataField="Model" />
                <asp:BoundField HeaderText="序列号" DataField="ProductSN1" />
                <asp:BoundField HeaderText="仓库" DataField="StockName" />
                <asp:BoundField HeaderText="租赁机器" DataField="GoodsNO" />
                </Columns>
            </asp:GridView>
            <asp:HiddenField ID="hfChargeCycle" runat="server" />
        </div>
        </div>
      <fieldset style=" border: 1px #808080 solid; padding:5px 0; width:680px;">
      <legend>合计应收</legend>
        <table cellpadding="0" cellspacing="0" class="tb5">
            <tr>
                <td>合计应收：</td>
                <td style="padding:0px;">
                    <asp:TextBox ID="tbRec" runat="server" CssClass="pin" Width="100"></asp:TextBox>
                </td>
                <td style="padding-left:5px;padding-right:5px;">=</td>
                <td style="padding:0px;">
                    <asp:TextBox ID="tbAARent" runat="server" CssClass="pinb" Width="122" ReadOnly="true"></asp:TextBox>
                </td>
                <td style="padding-left:3px;padding-right:3px;">+</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbAASuperZhangFee" runat="server" CssClass="pinb" Width="122" ReadOnly="true"></asp:TextBox>
                </td>
                <td style="padding-left:5px;" class="layd">
                    (总租金+总超张费合计)
                </td>
            </tr>
            </table>
            <table cellpadding="0" cellspacing="0" class="tb5">
            <tr>
                <td align="right">结算备注：</td>
                <td colspan="6" style="padding-left:0px;">
                    <asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="386"></asp:TextBox>
                </td>
            </tr>
        </table>
      </fieldset>
      <div class="divh"></div>
        <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="right">
                <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog<%=Str_F %>();"/>
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
