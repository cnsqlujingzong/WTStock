<%@ page language="C#"  CodeFile="servicesaddbat.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Services_ServicesAddBat" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/tab.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:856px;">
    <div class="tldiv2">
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td width="310"><a  href="#" onclick="parent.ShowDialog(870,600, '../Headquarters/Services/ServicesAdd.aspx', '��������');">�л�����׼ģʽ</a></td>
                <td class="tser">��������</td>
                <td>���񵥺ţ�</td>
                <td style="padding-left:0px;">
                <asp:TextBox ID="tbBillID" runat="server" CssClass="pinbst" ReadOnly="true" Width="110"></asp:TextBox>
                </td>
                
                <td align="right" style="padding-left:0px;">
                �Ƶ�ʱ�䣺</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbDate" CssClass="pinbst" runat="server" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
                </td>
                </tr>
        </table>
    </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
    <div class="fdivs" style="border-bottom:none;">
    <div class="sdivs" style="padding:3px 0 3px 0px;width:852px;border-bottom:none;">
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td align="right">�������</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="pindl2">
                    </asp:DropDownList>
                </td>
                <td align="right" style="width:87px; padding:0px;">����ʽ��</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlTake" runat="server" CssClass="pindl2">
                    </asp:DropDownList>
                </td>
                <td align="right" class="sysred" style="width:79px; padding:0px;">
                �����ˣ�</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl2">
                    </asp:DropDownList>
                </td>
                 <td align="right" style="width:87px; padding:0px;">����ʱ�䣺</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbTakeTime" runat="server" CssClass="pin2" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox></td>
                
            </tr>
       </table>
       </div>
       </div>
       <div class="fdivs">
    <div class="sdivs" style="padding:3px 0 3px 0px;width:852px;">
    
       <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td align="right" class="sysred">�ͻ����ƣ�</td>
                <td colspan="3" style="padding-left:0px;">
                   <div class="isinDiv" style="width: 321px; float:left;">
                    <asp:TextBox ID="tbCusName" runat="server" CssClass="pin2 autot2" Width="333" onmousedown="getSearchResult('../Customer/SchCusList.aspx','tbCusName','hfCusID','1','btnValiCus',event);" onkeyup="getSearchResult('../Customer/SchCusList.aspx','tbCusName','hfCusID','1','btnValiCus',event);" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                </td>
                <td style="padding:0px;"><input id="btnSlt" type="button" value="" onclick="SltCus();" class="bview"/></td>
                <td align="right">
                �����ˣ�</td>
                <td style="padding-left:0px;width:126px;">
                <div class="isinDiv">
                    <asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin2 pinin"></asp:TextBox>
                    <asp:DropDownList ID="ddlLinkMan" runat="server" onchange="document.getElementById('tbLinkMan').value=this.options[this.selectedIndex].text" CssClass="pininsl2" AutoPostBack="True" OnSelectedIndexChanged="ddlLinkMan_SelectedIndexChanged">
                        <asp:ListItem></asp:ListItem>
                      </asp:DropDownList>
                </div>
                </td>
                <td align="right" class="red">�����˵绰��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin2"></asp:TextBox></td>
            </tr>
            
            <tr>
                <td align="right" style="padding-left:0px;">
                ʹ���ˣ�</td>
                <td style="padding-left:0px;width:126px;">
                <div class="isinDiv">
                    <asp:TextBox ID="tbUsePerson" runat="server" CssClass="pin2 pinin"></asp:TextBox>
                    <asp:DropDownList ID="ddlUsePerson" runat="server" onchange="document.getElementById('tbUsePerson').value=this.options[this.selectedIndex].text" CssClass="pininsl2" AutoPostBack="True" OnSelectedIndexChanged="ddlUsePerson_SelectedIndexChanged">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </div>
                </td>
                <td align="right">
                ʹ���˵绰��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbUsePersonTel" runat="server" CssClass="pin2"></asp:TextBox></td>
                <td align="right" style="padding-left:0px;" colspan="2">
                �������ţ�</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                      <asp:TextBox ID="tbDept" runat="server" CssClass="pin2 pinin2"></asp:TextBox>
                      <asp:DropDownList ID="ddlDept" runat="server" onchange="document.getElementById('tbDept').value=this.options[this.selectedIndex].text" CssClass="pininsl2" AutoPostBack="True" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged">
                      </asp:DropDownList>
                    </div>
                </td>
                <td align="right">��������</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbArea" runat="server" CssClass="pin2 pinin2"></asp:TextBox>
                        <asp:DropDownList ID="ddlArea" runat="server" CssClass="pininsl2" onchange="document.getElementById('tbArea').value=this.options[this.selectedIndex].text;NewAreas('3');">
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>
            
            <tr>
                <td>��ϵ��ַ��</td>
                <td colspan="3" style="padding-left:0px;">
                    <asp:TextBox ID="tbAdr" runat="server" CssClass="pin2" Width="333"></asp:TextBox>
                </td>
                <td colspan="5">
                <a href="#" onclick="ViewCus();">>>��ϸ��Ϣ</a>
                <a href="#" onclick="ViewHistory();">>>���ҵ��</a>
                </td>
                
            </tr>
        </table>
        </div>
        </div>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnValiCus" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnRef" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
        <div class="divh"></div>
         <div id="mytabs">
            <span id="tabs_l1"></span>
            <span id="tabs1" onclick="ChkTab('1');">�����б�</span>
            <span id="tabs_r1"></span>
            <span id="tabs_l2"></span>
            <span id="tabs2" onclick="ChkTab('2');">������Ϣ</span>
            <span id="tabs_r2"></span>
         </div>
         <div id="info1" style="padding:3px 0px 0px 3px; overflow:hidden;height:196px;" >
         <div id="divinfo1" class="divinfo" style="height:100%; padding-top:0px;">
         <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="devtemadd">
                <table cellpadding="0" cellspacing="0" class="tb1" width="100%">
                    <tr>
                        <td style="padding-left:5px;">
                            <input id="btnNewD" type="button" value="�½�" class="bt1" onclick="parent.ShowDialog1(460, 353, '../Headquarters/Services/DeviceAdd.aspx', '�½�����');"/>
                            <input id="btnEditD" type="button" value="�޸�" class="bt1" onclick="ModD();"/>
                            <asp:Button ID="btnDelD" runat="server" Text="ɾ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnDelD_Click"/>
                        </td>
                        <td align="right" style="padding-right:10px;">
                            <asp:TextBox ID="tbCount" runat="server" CssClass="pin" Width="40"></asp:TextBox>
                            <asp:Button ID="btnCopy" runat="server" Text="���ƻ���" CssClass="bcopy" UseSubmitBehavior="false" OnClick="btnCopy_Click"/>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="divconf" style="height:160px; border:#c0c0c0 1px solid;">
                <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="False" SkinID="gv3" OnRowDataBound="gvdata_RowDataBound">
                        <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" />
                        <asp:BoundField HeaderText="�������" DataField="DeviceNO" />
                        <asp:BoundField HeaderText="����Ʒ��" DataField="Brand" />
                        <asp:BoundField HeaderText="�������" DataField="Class" />
                        <asp:BoundField HeaderText="�����ͺ�" DataField="Model" />
                        <asp:BoundField HeaderText="���к�1" DataField="SN1" />
                        <asp:BoundField HeaderText="���к�2" DataField="SN2" />
                        <asp:BoundField HeaderText="�������" DataField="Warranty" />
                        <asp:BoundField HeaderText="�������" DataField="Aspect" />
                        <asp:BoundField HeaderText="���ƹ���" DataField="Fault" />
                        <asp:BoundField HeaderText="�������" DataField="Accessory" />
                        <asp:BoundField HeaderText="���񼶱�" DataField="ServiceLevel" />
                        <asp:BoundField HeaderText="������" DataField="BuyFrom" />
                        <asp:BoundField HeaderText="����ʱ��" DataField="BuyDate" />
                        <asp:BoundField HeaderText="����Ʊ" DataField="BuyInvoice" />
                        <asp:BoundField HeaderText="����" DataField="dPoint" />
                            <asp:TemplateField HeaderText="�Ƿ�����">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbre" runat="server" Checked='<%# Bind("bRepair") %>' Enabled="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                <asp:HiddenField ID="hfCusID" runat="server" />
                <asp:HiddenField ID="hfArea" runat="server" />
                <asp:HiddenField ID="hfPrintID" runat="server" />
                <asp:HiddenField ID="hfDevice" runat="server" />
                <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
                <asp:HiddenField ID="hfCount" runat="server" Value="0" />
                <span style="display:none;">
                    <asp:Button ID="btnRef" runat="server" Text="Ref" OnClick="btnRef_Click" />
                    <asp:Button ID="btnAddD" runat="server" Text="AddD" OnClick="btnAddD_Click" />
                    <asp:Button ID="btnModD" runat="server" Text="ModD" OnClick="btnModD_Click" />
                    <asp:Button ID="btnShowD" runat="server" Text="ModD" OnClick="btnShowD_Click" />
                    <asp:Button ID="btnValiCus" runat="server" OnClick="btnValiCus_Click" Text="..." UseSubmitBehavior="false" />
                </span>
            </div>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
        </div>
        </div>
   <div id="info2" style="padding:3px 0px 0px 3px; overflow:hidden;height:196px;" >
         <div id="divinfo2" class="divinfo" style="height:100%;">
         <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            <table cellpadding="0" cellspacing="0" class="tb1">
                <tr>
                    <td align="right" style="padding-left:12px;">���˷�ʽ��</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlSndStyle" runat="server" CssClass="pindl2">
                        </asp:DropDownList>
                    </td>
                    <td align="right">�������ţ�</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbPostNO" runat="server" CssClass="pin2"></asp:TextBox>
                    </td>
                    <td align="right">�������ã�</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbPostage" runat="server" CssClass="pin2"></asp:TextBox>
                    </td>
                </tr>
            </table>
            </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
         </div>
    </div>
    <div class="divh"></div>
    <div class="fdivs">
    <div class="sdivs" style="padding:3px 0 3px 0px;width:852px;">
    <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
           <td>�浵���ţ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbSaveID" runat="server" CssClass="pin2"></asp:TextBox></td>
            <td>ԤԼʱ�䣺</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbSubTime" runat="server" CssClass="pin2" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
            </td>
            
             <td align="right">ԤԼȡ����</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbSubContTime" runat="server" CssClass="Wdate2" onfocus="WdatePicker()"></asp:TextBox>
            </td>
            <td align="right">����Ա��</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDisposal" runat="server" CssClass="pin2"></asp:TextBox>
            </td>
            <td style="padding:0px;"><input id="btnSltStaff" type="button" value="" onclick="SltTec();" class="bview"/></td>
        </tr>    
        <tr>
            <td>���̵��ţ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbCorpID" runat="server" CssClass="pin2"></asp:TextBox></td>
            <td>���㳧�̣�</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlChargeCorp" runat="server" CssClass="pindl2">
                </asp:DropDownList>
            </td>
            <td>���ۺ�ͬ�ţ�</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbContNO" runat="server" CssClass="pin2"></asp:TextBox>
                </td>
            <td>Ԥ���۸�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbSubPrice" runat="server" CssClass="pin2"></asp:TextBox></td>
            
          </tr>    
        <tr>
            <td align="right">Ԥ�շѣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbSubCharge" runat="server" CssClass="pin2"></asp:TextBox></td>
            <td align="right">��ע��</td>
            <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin2" Width="333"></asp:TextBox></td>
            <td>
                <a href="#" onclick="ChkUpload();">�ϴ�����</a>
            </td>
            <td style="padding-left:0px;">
                <div id="dUpload"></div>
                <asp:HiddenField ID="hfPath" runat="server" />
            </td>
        </tr>
    </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="right">
                <asp:Button ID="btnAdd" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnAdd_Click" />
                <asp:Button ID="btnClean" runat="server" Text="���" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkClean()==false)return false;" OnClick="btnClean_Click" />
<%--                <input id="btnPrint" runat="server" type="button" value="��ӡ" class="bt1" onclick="ChkPrint('PLPZD');" />
--%>                <input id="btnClose" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog();" />
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
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
var tabnum=3;

function ChkSave()
{
    if(isNull($("tbTakeTime").value))
    {
        window.alert("����ʧ�ܣ�����ʱ�䲻��Ϊ��");
        $("tbTakeTime").focus();
        return false
    }
    if(isNull($("tbCusName").value))
    {
        window.alert("����ʧ�ܣ��ͻ����Ʋ���Ϊ��");
        $("tbCusName").focus();
        return false
    }
    if(isNull($("tbTel").value))
    {
        window.alert("����ʧ�ܣ������˵绰����Ϊ��");
        $("tbTel").focus();
        return false
    }
    
    if($("ddlOperator").value=="-1")
    {
        window.alert("����ʧ�ܣ������˲���Ϊ��");
        $("ddlOperator").focus();
        return false
    }
    if(isNull($("tbDate").value))
    {
        window.alert("����ʧ�ܣ��Ƶ�ʱ�䲻��Ϊ��");
        $("tbDate").focus();
        return false
    }
    if(!isNull($("tbPostage").value))
    {
        if(!isMoney($("tbPostage").value))
        {
            window.alert("�������ø�ʽ����ȷ");
            ChkTab('3');
            $("tbPostage").focus();
            return false
        }   
    }
}
function ChkID(id)
{
    ClrID(id);
    $("btnShowD").click();
}
function ModD()
{
    if(ChkSlt()!=false)
    {
        var str=document.getElementById("hfDevice").value;
        parent.ShowDialog1(460, 353,'../Headquarters/Services/DeviceMod.aspx?str='+escape(str),'�޸Ļ���');
    }
}

function SltCus()
{
    parent.ShowDialog1(800, 500, '../Headquarters/Services/SltCus.aspx?f=1&strname='+escape($("tbCusName").value), 'ѡ��ͻ�');
}

function ConfCusInfo()
{
    if(confirm("�ÿͻ����ƴ��ڶ����ͻ���Ϣ���Ƿ�ѡ��"))
    {
        SltCus();
    }
}
function SltTec()
{
    parent.ShowDialog1(400, 510, '../Headquarters/Services/SltTec.aspx?f=1', '����Ա');
}

function ViewCus()
{
    var cusid=$("hfCusID").value;
    if(cusid=="")
    {
        //�½��ͻ�
        parent.ShowDialog1(600, 450, '../Headquarters/Customer/CusAdd.aspx?f=1', '�½��ͻ�');
    }
    else
    {
        //�޸Ŀͻ�
        parent.ShowDialog1(600, 450, '../Headquarters/Customer/CusMod.aspx?f=1&id=' + cusid, '�ͻ���Ϣ');
    }
}

function ViewHistory()
{
    var cusid=$("hfCusID").value;
    if(cusid=="")
    {
        alert("��ѡ��ͻ���鿴��");
        return false;
    }
    parent.ShowDialog1(800, 520, '../Headquarters/Customer/CusHistory.aspx?f=1&cusid='+cusid, '���ҵ��');
}
function ChkUpload()
{   
    if($("dUpload").innerHTML=="")
    {
        parent.ShowDialog1(600, 380, '../Headquarters/Services/UpLoad.aspx', '�ϴ�����');
    }
    else
    {
        if(confirm("�Ѿ�����һ�������������ϴ����滻�ø������Ƿ������"))
        {
            parent.ShowDialog1(600, 380, '../Headquarters/Services/UpLoad.aspx', '�ϴ�����');
        }
    }
}
</script>
