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
    <div class="item"><span style="padding-right:30px;">������ϸ</span><span id="span_info" style="display:none;"></span>
    </div>
    <div class="tool"></div>
    </div>
    
    <!-- -->
        <div style="padding-top:10px; padding-left:20px;">
        
        <p class="pt1">������Ϣ</p> 
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td style="color:#800000">����ʱ�䣺</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbTakeTime" runat="server" CssClass="pin" ReadOnly="true"></asp:TextBox>
                </td>
                <td>ҵ�����</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlOpType" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                <td>���ʱ�䣺</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbTakeOver" runat="server" CssClass="pin" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="color:#800000">����״̬��</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlcurStatus" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                <td >���񼶱�</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlServiceLevel" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>        
        <p class="pt1">������Ϣ</p>  
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td align="right" style="padding-left:0px;">
                �����ˣ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbUsePerson" runat="server" CssClass="pin"></asp:TextBox></td>
                
                <td align="right">
                ���޵绰��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbUsePersonTel" runat="server" CssClass="pin"></asp:TextBox></td>
                <td align="right" style="padding-left:0px;">
                �������ţ�</td>
                <td style="padding-left:0px;">
                          <asp:TextBox ID="tbDept" runat="server" CssClass="pin"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">��������</td>
                <td style="padding-left:0px;">
                        <asp:TextBox ID="tbArea" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td>��ϵ��ַ��</td>
                <td colspan="3" style="padding-left:0px;">
                    <asp:TextBox ID="tbAdr" runat="server" CssClass="pin2" Width="341"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="color:#800000;">������ţ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbDeviceNO" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td style="color:#800000">����Ʒ�ƣ�</td>
                <td style="padding-left:0px;">
                    <input type="text" id="tbBrand" runat="server" class="pin" />
                </td>
                <td>�������</td>
                <td style="padding-left:0px;">
                    <input type="text" id="tbType" runat="server" class="pin" />
                </td>
                
            </tr>
            <tr>
                <td>�����ͺţ�</td>
                <td style="padding-left:0px;">
                    <input type="text" id="tbStyle" runat="server" class="pin"/>
                </td>
                <td>������ۣ�</td>
                <td style="padding-left:0px;">
                    <input type="text" id="tbAspect" runat="server" class="pin" />
                </td>
                <td align="right" style="color:#800000">���к�1��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSN1" runat="server" CssClass="pin"></asp:TextBox></td>
                
            </tr>
            <tr>
                <td align="right">���к�2��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSN2" runat="server" CssClass="pin"></asp:TextBox></td>
                <td>���������</td>
                <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbAcc" runat="server" CssClass="pin" Width="341"></asp:TextBox></td>
                
            </tr>
            <tr>
                <td>����ʱ�䣺</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBuyDate" runat="server" CssClass="pin"></asp:TextBox></td>
                <td align="right">�����̣�</td>
                <td style="padding-left:0px;">
                    <input type="text" id="tbBuyStore" runat="server" class="pin" />
                </td>
                <td>����Ʊ��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBuyInvoice" runat="server" CssClass="pin"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="color:#800000" rowspan="2">���ƹ��ϣ�</td>
                <td colspan="3" rowspan="2" style="padding-left:0px;"><asp:TextBox ID="tbFault" runat="server" CssClass="pin" Width="341" Height="42" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td style="color:#800000">ԤԼʱ�䣺</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSubTime" runat="server" CssClass="pin"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="color:#800000">���������</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>���˷�ʽ��</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlSndStyle" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                <td>�������ţ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbPostNO" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td>
                    �������ã�
                </td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbPostage" runat="server" CssClass="pin"></asp:TextBox>
                </td>
            </tr>
        </table>
        
        <p class="pt1">��������</p> 
        
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="98%">
            <Columns>
                <asp:BoundField HeaderText="���" DataField="GoodsNO" />
                <asp:BoundField HeaderText="����" DataField="_Name" />
                <asp:BoundField HeaderText="����" DataField="Qty" HtmlEncode="false" DataFormatString="{0:n2}" />
                <asp:BoundField HeaderText="����" DataField="Price" HtmlEncode="false" DataFormatString="{0:c2}"  />
                <asp:BoundField HeaderText="���" DataField="Total" HtmlEncode="false" DataFormatString="{0:c2}"  />
                <asp:BoundField HeaderText="������" DataField="MaintenancePeriod" />
                <asp:BoundField HeaderText="���޽�ֹ����" DataField="PeriodEndDate" />
            </Columns>
        </asp:GridView>
        
        <p class="pt1">ά����Ŀ</p>  
        
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="98%">
            <Columns>
                <asp:BoundField HeaderText="���" DataField="ItemNO" />
                <asp:BoundField HeaderText="����" DataField="_Name" />
                <asp:BoundField HeaderText="����" DataField="Price" />
                <asp:BoundField HeaderText="��ʱ" DataField="dPoint" />
                <asp:BoundField HeaderText="����Ա" DataField="Tec" />
            </Columns>
        </asp:GridView>
        <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style=" padding-left:74px;padding-top:10px;">
                <input id="btnback" onclick="javascript:history.back();" type="button" value="����" class="bt1 bt8" />
            </td>
        </tr>
        </table>
    
    <!--end-->
    </div>
 
    </form>
</body>
</html>
