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
    <div class="item"><span style="padding-right:30px;">��������</span><span id="span_info" style="display:none;"></span>
    </div>
    <div class="tool"></div>
    </div>
    <!-- -->
        <div style="padding-top:10px; padding-left:20px;">
        <p class="pt1">������Ϣ</p> 
        <table cellpadding="0" cellspacing="0" class="tb1">
                    <tr>
                    <td align="right">
                    ��ϵ�ˣ�</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbName" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td align="right">�������ţ�</td>
                    <td style="padding-left:0px;">
                          <asp:TextBox ID="tbDept" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td align="right">��ϵ�绰��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">�ֻ����룺</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbTel2" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right">���棺</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbFax" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right">�ʱࣺ</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbZip" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr>
                <tr>
                    
                    <td align="right">��ϵ��ַ��</td>
                    <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin" Width="365"></asp:TextBox></td>
                </tr>
            <tr>
                <td align="right" style="color:#800000;">������ţ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbDeviceNO" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td align="right" style="color:#800000;">����Ʒ�ƣ�</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbBrand" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td align="right">�������</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbClass" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td align="right">�����ͺţ�</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbModel" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td align="right" style="color:#800000;">���к�1��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSN1" runat="server" CssClass="pin"></asp:TextBox></td>
                <td align="right">���к�2��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSN2" runat="server" CssClass="pin"></asp:TextBox></td>
                
            </tr>
            <tr>
                <td align="right">������ۣ�</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbAspect" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td align="right">����ʱ�䣺</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBuyDate" runat="server" CssClass="pin"></asp:TextBox></td>
                <td align="right">�����̣�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBuyFrom" runat="server" CssClass="pin"></asp:TextBox></td>
                
            </tr>
            <tr>
                <td align="right">����Ʊ��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbInvoice" runat="server" CssClass="pin"></asp:TextBox></td>
                <td align="right">�����ڣ�</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbProt" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td align="right">���������</td>
                <td align="right" style="padding-left:0px;">
                    <asp:TextBox ID="tbRepStatus" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                
            </tr>
            
            <tr>
                <td align="right">ά�޴�����</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbRepNum" runat="server" CssClass="pin"></asp:TextBox></td>
                <td>���ұ��޿�ʼ��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbWStart" runat="server" CssClass="pin"></asp:TextBox></td>
                <td>���ұ��޽�ֹ��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbWEnd" runat="server" CssClass="pin"></asp:TextBox></td>
                
            </tr> 
             <tr>
                <td>���ά��ʱ�䣺</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbLastDate" runat="server" CssClass="pin"></asp:TextBox></td>
                <td>��ͬ���޿�ʼ��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbPStart" runat="server" CssClass="pin"></asp:TextBox></td>
                <td>��ͬ���޽�ֹ��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbPEnd" runat="server" CssClass="pin"></asp:TextBox></td>
                
            </tr>
            <tr>
                <td>ά�ޱ��޽�ֹ��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbFinD" runat="server" CssClass="pin"></asp:TextBox></td>
                <td>ά�޺�ͬ��ţ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbContractNO" runat="server" CssClass="pin"></asp:TextBox></td>
                <td align="right">��װ���ڣ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbInStall" runat="server" CssClass="pin"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">��ע��</td>
                <td colspan="5" style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="365"></asp:TextBox></td>
            </tr>
        </table>
        
        <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style=" padding-left:98px; padding-top:10px;">
                <input id="btnback" onclick="javascript:history.back();" type="button" value="����" class="bt1 bt8" />
            </td>
        </tr>
        </table>
        <br />
        <p class="pt1">��ط���</p> 
        <div class="list" id="list" style="height:135px; overflow:auto;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" EnableViewState="false" GridLines="None" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="���񵥺�" DataField="BillID" />
                <asp:BoundField HeaderText="����ʱ��" DataField="Time_Make" />
                <asp:BoundField HeaderText="��ǰ״̬" DataField="curStatus" />
                <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
                <asp:BoundField HeaderText="��������" DataField="UsePersonDept" />
                <asp:BoundField HeaderText="�ͺ�" DataField="ProductModel" />
                <asp:BoundField HeaderText="Ʒ��" DataField="ProductBrand" />
                <asp:BoundField HeaderText="���" DataField="ProductClass" />
                <asp:BoundField HeaderText="���к�" DataField="ProductSN1" />
                
                <asp:TemplateField HeaderText="����"></asp:TemplateField>
                
            </Columns>
        </asp:GridView>
        </div>
        </div>
 <!--end-->
    </form>
</body>
</html>
