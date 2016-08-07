<%@ page language="C#"  CodeFile="report.aspx.cs"     autoeventwireup="true" inherits="Web_Report" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="public/css/mysub.css" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div id="idiv">
    <div class="item"><span style="padding-right:30px;">��Ҫ����</span><span id="span_info" style="display:none;"></span>
        <asp:Label ID="lbInfo" runat="server" style="color:#ff0000;"></asp:Label>
    </div>
    <div class="tool"></div>
    </div>
    
    <!-- -->
        <div style="padding-top:10px; padding-left:20px;">
        
        <p class="pt1">ѡ��������</p> 
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td>����ʱ�䣺</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbTimeTake" runat="server" CssClass="pin pin3" ReadOnly="true"></asp:TextBox>
                </td>
                <td>�������</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                <td>��������:</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlBranch" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        
        <p class="pt1">��д�ͻ���Ϣ</p>      
        <table cellpadding="0" cellspacing="0" class="tb1">
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
                        <asp:TextBox ID="tbDept" runat="server" CssClass="pin pinin"></asp:TextBox>
                          <asp:DropDownList ID="ddlDept" runat="server" onchange="document.getElementById('tbDept').value=this.options[this.selectedIndex].text" CssClass="pininsl">
                          </asp:DropDownList>
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
        
        <p class="pt1">��д������Ϣ</p>
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td align="right" style="color:#800000;">������ţ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbDeviceNO" runat="server" CssClass="pin"></asp:TextBox>
                <input id="Button1" type="button" value="" onclick="openWin('SltDev.aspx','800','530');" class="bview"/>
                </td>
                <td align="right" style="color:#800000;">����Ʒ�ƣ�</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbBrand" runat="server" CssClass="pin pinin" AutoCompleteType="Disabled" onblur="ChkPBrand();"></asp:TextBox>
                        <asp:DropDownList ID="ddlBrand" runat="server" CssClass="pininsl" onchange="document.getElementById('tbBrand').value=this.options[this.selectedIndex].text;" AutoPostBack="True" OnSelectedIndexChanged="ddlBrand_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </td>
                <td align="right">�������</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbClass" runat="server" CssClass="pin pinin" AutoCompleteType="Disabled" onblur="ChkPClass();">
                        </asp:TextBox>
                        <asp:DropDownList ID="ddlClass" runat="server" onchange="document.getElementById('tbClass').value=this.options[this.selectedIndex].text;" CssClass="pininsl" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="right">�����ͺţ�</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbModel" runat="server" CssClass="pin pinin" AutoCompleteType="Disabled" onblur="ChkPModel();"></asp:TextBox>
                        <asp:DropDownList ID="ddlModel" runat="server" CssClass="pininsl" onchange="document.getElementById('tbModel').value=this.options[this.selectedIndex].text;" AutoPostBack="True" OnSelectedIndexChanged="ddlModel_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </td>
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
                <td style="padding:0px;"><input id="btnSltDev" type="button" value="" onclick="openWin('SltDev.aspx','800','530');" class="bview"/></td>
            </tr>
            <tr>
                <td align="right">���к�2��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSN2" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td align="right">���������</td>
                <td style="padding-left:0px;" colspan="3"><asp:TextBox ID="tbAcc" runat="server" CssClass="pin" Width="341"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">����ʱ�䣺</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBuyTime" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
                </td>
                <td align="right">�����̣�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBuyFrom" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td align="right">����Ʊ��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBuyInvoice" runat="server" CssClass="pin"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="color:#800000;" rowspan="2">����������</td>
                <td colspan="3" style="padding-left:0px;" rowspan="2"><asp:TextBox ID="tbFault" Height="42" TextMode="MultiLine" runat="server" CssClass="pin" Width="341"></asp:TextBox>
                <input id="Button2" type="button" value="" onclick="openWin('SltDevNO.aspx','418','500');" class="bview"/>
                </td>
                <td align="right" style="color:#800000;">���������</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlRepStatus" runat="server" CssClass="pindl">
                        <asp:ListItem Value=""></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>���񼶱�</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlPRI" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
        <p class="pt1">��д������Ϣ</p>      
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td>ԤԼʱ�䣺</td>
                <td style="padding:0px;"><asp:TextBox ID="tbSubTime" runat="server" CssClass="pin" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
                </td>
                <td>���˷�ʽ��</td>
                <td style="padding:0px;">
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
        <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td style=" padding-left:74px; height:40px;">
                <asp:Button ID="btnAdd" runat="server" Text="�ύ" CssClass="bt1 bt8" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnAdd_Click"  />
            </td>
        </tr>
        </table>
            <asp:HiddenField ID="hfDevID" runat="server" />
    <!--end-->
    </div>
 
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../public/script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="public/script/common.js"></script>
<script language="javascript" type="text/javascript" src="public/script/validator.js"></script>
<script language="javascript" type="text/javascript">
function openWin(u,w,h) {
    var l = (screen.width - w) / 2;
    var t = (screen.height - h) / 2;
    var s = 'width=' + w + ', height=' + h + ', top=' + t + ', left=' + l;
    s += ', toolbar=no, scrollbars=no, menubar=no, location=no, resizable=no';
    open(u, 'oWin', s);
}

function ChkSave()
{
    if(isNull($("tbCusName").value))
    {
        window.alert("����ʧ�ܣ��ͻ����Ʋ���Ϊ��");
        $("tbCusName").focus();
        return false
    }
    if(isNull($("tbLinkMan").value))
    {
        window.alert("����ʧ�ܣ���ϵ�˲���Ϊ��");
        $("tbLinkMan").focus();
        return false
    }
    if(isNull($("tbTel").value))
    {
        window.alert("����ʧ�ܣ���ϵ�绰����Ϊ��");
        $("tbTel").focus();
        return false
    }
    if(isNull($("tbArea").value))
    {
        window.alert("����ʧ�ܣ�����������Ϊ��");
        $("tbArea").focus();
        return false
    }
    if(isNull($("tbBrand").value))
    {
        window.alert("����ʧ�ܣ���ƷƷ�Ʋ���Ϊ��");
        $("tbBrand").focus();
        return false
    }
    if(isNull($("tbFault").value))
    {
        window.alert("����ʧ�ܣ�������������Ϊ��");
        $("tbFault").focus();
        return false
    }
    if(isNull($("ddlRepStatus").value))
    {
        window.alert("����ʧ�ܣ������������Ϊ��");
        $("ddlRepStatus").focus();
        return false
    }
    if(!isNull($("tbPostage").value))
    {
        if(!isMoney($("tbPostage").value))
        {
            window.alert("�������ø�ʽ����ȷ");
            $("tbPostage").focus();
            return false
        }   
    }
}
</script>
