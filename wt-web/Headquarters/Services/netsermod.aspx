<%@ page language="C#"  CodeFile="netsermod.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Services_NetSerMod" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:666px;">
    <div class="fdivs">
    <div class="sdivs" style="padding:3px 0 3px 0px;width:662px;">
    <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td>���޻�Ա��</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbName" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox>
            </td>
            <td>����ʱ�䣺</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbTimeTake" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox>
            </td>
            <td>�������</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlType" runat="server" CssClass="pindl">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="color:#800000;">�ͻ����ƣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbCusName" runat="server" CssClass="pin"></asp:TextBox>
                <asp:HiddenField ID="hfCusID" runat="server" />
            </td>
            <td align="right">�����ˣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin"></asp:TextBox></td>
            <td align="right">�����˵绰��</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">ʹ���ˣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbUsePerson" runat="server" CssClass="pin"></asp:TextBox></td>
            <td>�������ţ�</td>
            <td style="padding-left:0px;">
                <div class="isinDiv">
                    <input type="text" id="tbDept" runat="server" class="pin pinin"/>
                    <select id="slDept" onchange="document.getElementById('tbDept').value=this.options[this.selectedIndex].value" class="pininsl">
                        <option value="" selected="selected"></option>
                        <option value="���۲�">���۲�</option>
                        <option value="�г���">�г���</option>
                        <option value="���²�">���²�</option>
                    </select>
                </div>
            </td>
            <td>ʹ���˵绰��</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbUsePersonTel" runat="server" CssClass="pin"></asp:TextBox></td>
        </tr>
        <tr>
            <td>��������</td>
            <td style="padding-left:0px;">
                <div class="isinDiv">
                    <asp:TextBox ID="tbArea" runat="server" CssClass="pin pinin"></asp:TextBox>
                    <asp:DropDownList ID="ddlArea" runat="server" CssClass="pininsl" onchange="document.getElementById('tbArea').value=this.options[this.selectedIndex].text;">
                    </asp:DropDownList>
                </div>
            </td>
            <td>��ϵ��ַ��</td>
            <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin" Width="353"></asp:TextBox>
            </td>
        </tr>
    </table>
    </div>
    </div>
    <div class="divh"></div>
    <div class="fdivs">
    <div class="sdivs" style="padding:3px 0 3px 0px;width:662px;">
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td align="right" style="color:#800000;">����Ʒ�ƣ�</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbBrand" runat="server" CssClass="pin pinin" AutoCompleteType="Disabled"></asp:TextBox>
                        <asp:DropDownList ID="ddlBrand" runat="server" CssClass="pininsl" onchange="document.getElementById('tbBrand').value=this.options[this.selectedIndex].text;">
                        </asp:DropDownList>
                    </div>
                </td>
                <td align="right">�������</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbClass" runat="server" CssClass="pin pinin" AutoCompleteType="Disabled">
                        </asp:TextBox>
                        <asp:DropDownList ID="ddlClass" runat="server" onchange="document.getElementById('tbClass').value=this.options[this.selectedIndex].text;" CssClass="pininsl">
                        </asp:DropDownList>
                    </div>
                </td>
                <td align="right">�����ͺţ�</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbModel" runat="server" CssClass="pin pinin" AutoCompleteType="Disabled"></asp:TextBox>
                        <asp:DropDownList ID="ddlModel" runat="server" CssClass="pininsl" onchange="document.getElementById('tbModel').value=this.options[this.selectedIndex].text;">
                        </asp:DropDownList>
                    </div>
                </td>
                
            </tr>
            <tr>
                <td align="right">������ۣ�</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbAspect" runat="server" CssClass="pin pinin"></asp:TextBox>
                         <asp:DropDownList ID="ddlAspect" runat="server" onchange="document.getElementById('tbAspect').value=this.options[this.selectedIndex].text;" CssClass="pininsl">
                         </asp:DropDownList>
                    </div>
                </td>
                <td align="right" style="color:#800000;">���к�1��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSN1" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td align="right">���к�2��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSN2" runat="server" CssClass="pin"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">���������</td>
                <td style="padding-left:0px;" colspan="3"><asp:TextBox ID="tbAcc" runat="server" CssClass="pin" Width="341"></asp:TextBox></td>
                <td align="right">����ʱ�䣺</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBuyTime" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">�����̣�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBuyFrom" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td align="right">����Ʊ��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBuyInvoice" runat="server" CssClass="pin"></asp:TextBox></td>
                <td align="right" style="color:#800000;">���������</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlRepStatus" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" style="color:#800000;">���񼶱�</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlPRI" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                <td>����������</td>
                <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbFault" runat="server" CssClass="pin" Width="341"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td>ԤԼʱ�䣺</td>
                <td style="padding:0px;"><asp:TextBox ID="tbSubTime" runat="server" CssClass="pin" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
                </td>
                <td align="right">���˷�ʽ��</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlSndStyle" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                <td>�������ţ�</td>
                <td style="padding:0px;"><asp:TextBox ID="tbPostNO" runat="server" CssClass="pin" ></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td>
                    �������ã�
                </td>
                <td style="padding:0px;">
                    <asp:TextBox ID="tbPostage" runat="server" CssClass="pin" ></asp:TextBox>
                </td>
                <td>��ע��Ϣ��</td>
                <td colspan="3" style="padding:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="341"></asp:TextBox></td>
            </tr>
        </table>
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="right">
                <input id="btnClose" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog();" />
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
<script language="javascript" type="text/javascript" src="../../Public/Script/detail.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/AutoSchCon.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>