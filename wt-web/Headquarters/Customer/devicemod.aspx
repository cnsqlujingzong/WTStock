<%@ page language="C#"  CodeFile="devicemod.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Customer_DeviceMod" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sa" style="width:736px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
        <div class="fdiv">
        <div class="sdiv">
            <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                    <td align="right" class="red">�ͻ����ƣ�</td>
                    <td style="padding-left:0px;">
                    <div class="isinDiv">
                    <asp:TextBox ID="tbCusName" runat="server" CssClass="pin autot" onmousedown="getSearchResult('../Customer/SchCusList.aspx','tbCusName','hfCusID','1','btnCusInfo',event);" onkeyup="getSearchResult('../Customer/SchCusList.aspx','tbCusName','hfCusID','1','btnCusInfo',event);" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                    </td>
                    <td style="padding:0px;"><input id="btnSlt" type="button" value="" onclick="SltCus();" class="bview"/></td>
                    <td align="right">
                    ��ϵ�ˣ�</td>
                    <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbName" runat="server" CssClass="pin pinin"></asp:TextBox>
                        <asp:DropDownList ID="ddlLinkMan" runat="server" onchange="document.getElementById('tbName').value=this.options[this.selectedIndex].text" CssClass="pininsl" AutoPostBack="True" OnSelectedIndexChanged="ddlLinkMan_SelectedIndexChanged">
                            <asp:ListItem></asp:ListItem>
                          </asp:DropDownList>
                    </div>
                    </td>
                    <td align="right">�������ţ�</td>
                    <td style="padding-left:0px;">
                      <div class="isinDiv">
                          <asp:TextBox ID="tbDept" runat="server" CssClass="pin pinin"></asp:TextBox>
                          <asp:DropDownList ID="ddlDept" runat="server" onchange="document.getElementById('tbDept').value=this.options[this.selectedIndex].text" CssClass="pininsl">
                          </asp:DropDownList>
                      </div>
                    </td>
                </tr>
                <tr>
                    <td align="right">��ϵ�绰��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td colspan="2" align="right">�ֻ����룺</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbTel2" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right">���棺</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbFax" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">����Ա��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbDisposal" runat="server" CssClass="pin"></asp:TextBox>
            </td>
            <td style="padding:0px;"><input id="btnSltStaff" type="button" value="" onclick="SltTec();" class="bview"/></td>
                    <td align="right">�ʱࣺ</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbZip" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right">��ϵ��ַ��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right" class="red">������ţ�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbDeviceNO" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td colspan="2" align="right">����Ʒ�ƣ�</td>
                    <td style="padding-left:0px;">
                        <div class="isinDiv">
                            <asp:TextBox ID="tbBrand" runat="server" CssClass="pin pinin" AutoCompleteType="Disabled" onblur="ChkPBrand();"></asp:TextBox>
                            <asp:DropDownList ID="ddlBrand" runat="server" CssClass="pininsl" onchange="document.getElementById('tbBrand').value=this.options[this.selectedIndex].text;NewProductBrands('1');" AutoPostBack="True" OnSelectedIndexChanged="ddlBrand_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </td>
                    <td align="right">�������</td>
                    <td style="padding-left:0px;">
                        <div class="isinDiv">
                            <asp:TextBox ID="tbClass" runat="server" CssClass="pin pinin" AutoCompleteType="Disabled" onblur="ChkPClass();">
                            </asp:TextBox>
                            <asp:DropDownList ID="ddlClass" runat="server" onchange="document.getElementById('tbClass').value=this.options[this.selectedIndex].text;NewProductClasss('1');" CssClass="pininsl" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="right">�����ͺţ�</td>
                    <td style="padding-left:0px;">
                        <div class="isinDiv">
                            <asp:TextBox ID="tbModel" runat="server" CssClass="pin pinin" AutoCompleteType="Disabled" onblur="ChkPModel();"></asp:TextBox>
                            <asp:DropDownList ID="ddlModel" runat="server" CssClass="pininsl" onchange="document.getElementById('tbModel').value=this.options[this.selectedIndex].text;NewProductModels('1');" AutoPostBack="True" OnSelectedIndexChanged="ddlModel_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </td>
                    <td align="right" colspan="2" class="red">���к�1��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbSN1" runat="server" CssClass="pin pin2"></asp:TextBox></td>
                    <td align="right">���к�2��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbSN2" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">������ۣ�</td>
                    <td style="padding-left:0px;">
                    <div class="isinDiv">
                    <input type="text" id="tbAspect" runat="server" class="pin pinin" />
                         <asp:DropDownList ID="ddlAspect" runat="server" onchange="document.getElementById('tbAspect').value=this.options[this.selectedIndex].text;" CssClass="pininsl">
                         </asp:DropDownList>
                    </div>
                    </td>
                    <td colspan="2" align="right">��Ȩ��</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlProperty" runat="server" CssClass="pindl">
                            <asp:ListItem Value="1">�ͻ���</asp:ListItem>
                            <asp:ListItem Value="2">���л�</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">����ʱ�䣺</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbBuyDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">����۸�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbBuyPrice" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right" colspan="2">�����̣�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbBuyFrom" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right">����Ʊ��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbInvoice" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">�����ڣ�</td>
                    <td style="padding-left:0px;">
                      <div class="isinDiv">
                        <input type="text" id="tbProt" runat="server" class="pin pinin" />
                            <select id="Select1" onchange="document.getElementById('tbProt').value=this.options[this.selectedIndex].value" class="pininsl">
                                <option value="" selected="selected"></option>
                                <option value="�ޱ���">�ޱ���</option>
                                <option value="һ����">һ����</option>
                                <option value="������">������</option>
                                <option value="������">������</option>
                                <option value="һ��">һ��</option>
                                <option value="����">����</option>
                                <option value="����">����</option>
                                <option value="����">����</option>
                                <option value="����">����</option>
                            </select>
                        </div>
                    </td>
                    <td align="right" colspan="2">���������</td>
                    <td style="padding-left:0px;">
                       <asp:DropDownList ID="ddlRepStatus" runat="server" onchange="NewRepStatus('1');" CssClass="pindl">
                       </asp:DropDownList>
                    </td>
                    <td align="right">ά�޴�����</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbRepNum" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr> 
     
                 <tr>
                    <td align="right">���ұ��޿�ʼ��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbWStart" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                    <td colspan="2" align="right">���ұ��޽�ֹ��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbWEnd" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                    <td align="right">���ά��ʱ�䣺</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbLastDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">��ͬ���޿�ʼ��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbPStart" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                    <td colspan="2" align="right">��ͬ���޽�ֹ��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbPEnd" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                    <td align="right">ά�ޱ��޽�ֹ��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbFinD" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">ά�޺�ͬ��ţ�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbContractNO" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td colspan="2" align="right">��װ���ڣ�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbInStall" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                    <td align="right">
                        <asp:Label ID="lbuserdef1" runat="server" Text="Label"></asp:Label>��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbuserdef1" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right"><asp:Label ID="lbuserdef2" runat="server" Text="Label"></asp:Label>��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbuserdef2" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td colspan="2" align="right"><asp:Label ID="lbuserdef3" runat="server" Text="Label"></asp:Label>��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbuserdef3" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right"><asp:Label ID="lbuserdef4" runat="server" Text="Label"></asp:Label>��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbuserdef4" runat="server" CssClass="pin"></asp:TextBox></td>
                    
                </tr>
                <tr>
                    <td align="right"><asp:Label ID="lbuserdef5" runat="server" Text="Label"></asp:Label>��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbuserdef5" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td colspan="2" align="right">��ע��</td>
                    <td style="padding-left:0px;" colspan="3"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="365"></asp:TextBox>
                    <asp:HiddenField ID="hfBrand" runat="server" />
                    <asp:HiddenField ID="hfClass" runat="server" />
                    <asp:HiddenField ID="hfWarranty" runat="server" />
                    <asp:HiddenField ID="hfCusID" runat="server" />
                    <asp:HiddenField ID="hfModelID" runat="server" />
                    <asp:HiddenField ID="hfSN" runat="server" />
                    <asp:HiddenField ID="hfDeviceNO" runat="server" />
                    <asp:HiddenField ID="hfbAddBCM" runat="server" Value="111"/>
                    <span style="display:none;">
                        <asp:Button ID="btnRefModel" runat="server" Text="GetPModel" OnClick="btnRefModel_Click" />
                        <asp:Button ID="btnRefBrand" runat="server" Text="RefBrand" OnClick="btnRefBrand_Click" />
                        <asp:Button ID="btnRefClass" runat="server" Text="RefClass" OnClick="btnRefClass_Click" />
                        <asp:Button ID="btnRefWarranty" runat="server" Text="RefWarranty" OnClick="btnRefWarranty_Click" />
                    </span>
                    </td>
                </tr>
            </table>
        </div>
        </div>
     </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnCusInfo" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>
            <span style="display:none;">
                <asp:TextBox ID="tbCusNO" runat="server" CssClass="pin"></asp:TextBox>
                <asp:Button ID="btnCusInfo" runat="server" Text="CusInfo" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnCusInfo_Click"/>
            </span>
        </td>
        <td align="right">
            <asp:Button ID="btnAdd" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnAdd_Click" />
            <input id="btnCls" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog<%=Str_F %>();"/>
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
<script language="javascript" type="text/javascript">
var isfocus=1;
var processtip=1;
function ChkSave()
{
    if(isNull($("tbCusName").value))
    {
        window.alert("����ʧ�ܣ��ͻ����Ʋ���Ϊ��");
        $("tbCusName").focus();
        return false
    }
    if(isNull($("tbSN1").value))
    {
        window.alert("����ʧ�ܣ����к�1����Ϊ��");
        $("tbSN1").focus();
        return false
    }
    var dateWStart=$("tbWStart").value;
    var dateWEnd=$("tbWEnd").value;
    if(dateWStart!=""&&dateWEnd!=""&&dateWStart>dateWEnd)
    {
        alert("����ʧ�ܣ����ұ��޽�ֹ���ڲ������ڳ��ұ��޿�ʼ����");
        $("tbWEnd").focus();
        return false;
    }
    var datePStart=$("tbPStart").value;
    var datePEnd=$("tbPEnd").value;
    if(datePStart!=""&&datePEnd!=""&&datePStart>datePEnd)
    {
        alert("����ʧ�ܣ���ͬ���޽�ֹ���ڲ������ں�ͬ���޿�ʼ����");
        $("tbPEnd").focus();
        return false;
    }
    var dateWXStart=$("tbLastDate").value;
    var dateWXEnd=$("tbFinD").value
    if(dateWXStart!=""&&dateWXEnd!=""&&dateWXStart>dateWXEnd)
    {
        alert("����ʧ�ܣ�ά�ޱ��޽�ֹ���ڲ����������ά������");
        $("tbFinD").focus();
        return false;
    }
}

function SltTec()
{
    parent.ShowDialog1(400, 510, '../Headquarters/Services/SltTec.aspx?f=1', '����Ա');
}
function SltCus()
{
    parent.ShowDialog1(800, 500, '../Headquarters/Customer/SltCus.aspx?f=1', 'ѡ��ͻ�');
}
</script>
