<%@ page language="C#"  CodeFile="servicesover.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Services_ServicesOver" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title></title>
<link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/frame.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/page.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/tab.css" />
</head>
<body onload="Chkset();" onclick="parent.Sethidden1();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="ftool">
        <div class="ftoolleft">
        <table cellpadding="0" cellspacing="0" class="tb2">
            <tr>
            <td>
            <asp:Button ID="btnFsh" runat="server" Text="ˢ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnFsh_Click"/>
            <asp:Button ID="btnChkClose" runat="server" Text="���" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkClose()==false) return false" OnClick="btnChkClose_Click"/>
            <input id="btnRepair" type="button" value="����" class="bt1" onclick="ChkBack();" runat="server" />
            <span style="display:none;">
                <asp:Button ID="btnClr" runat="server" Text="����ѡ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnClr_Click" />
                <asp:Button ID="btnOrder" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnOrder_Click" />
                <asp:Button ID="btnShow" runat="server" Text="��ʾ" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnShow_Click"/>
                <asp:Button ID="btnSchH" runat="server" Text="�߼���ѯ" CssClass="bt1" OnClick="btnSchH_Click" UseSubmitBehavior="False" />
            </span>
            </td>
            </tr>
        </table>
        </div>
        <div class="ftoolright">
            <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                <input id="btnPrint" runat="server" type="button" value="��ӡ" class="iprint" onclick="ChkPrintChoise('PrintBill.aspx');" />
                </td>
                <td style="padding-left:0px;">
                    <asp:Button ID="btnExcel" runat="server" Text="����" CssClass="bexcel" OnClientClick="if(ChkToExcel()==false)return false;" OnClick="btnExcel_Click" /></td>
                <td>
                <asp:DropDownList ID="ddlKey" runat="server" CssClass="pindl" onchange="document.getElementById('tbCon').focus();">
                    <asp:ListItem Value="0">ģ����ѯ</asp:ListItem>
                    <asp:ListItem Value="1">�����񵥺Ų�ѯ</asp:ListItem>
                    <asp:ListItem Value="2">����������ѯ</asp:ListItem>
                    <asp:ListItem Value="3">�������Ų�ѯ</asp:ListItem>
                    <asp:ListItem Value="4">�������Ų�ѯ</asp:ListItem>
                    <asp:ListItem Value="5">������ʽ��ѯ</asp:ListItem>
                    <asp:ListItem Value="6">�����񼶱��ѯ</asp:ListItem>
                    <asp:ListItem Value="7">�������˲�ѯ</asp:ListItem>
                    <asp:ListItem Value="8">���ͻ����Ʋ�ѯ</asp:ListItem>
                    <asp:ListItem Value="9">����ϵ�˲�ѯ</asp:ListItem>
                    <asp:ListItem Value="10">���ͻ��绰��ѯ</asp:ListItem>
                    <asp:ListItem Value="11">���ͻ���ַ��ѯ</asp:ListItem>
                    <asp:ListItem Value="12">�������ͺŲ�ѯ</asp:ListItem>
                    <asp:ListItem Value="13">������Ʒ�Ʋ�ѯ</asp:ListItem>
                    <asp:ListItem Value="14">����������ѯ</asp:ListItem>
                    <asp:ListItem Value="15">���������кŲ�ѯ</asp:ListItem>
                    <asp:ListItem Value="16">��ά�޼���Ա��ѯ</asp:ListItem>
                    <asp:ListItem Value="17">�����ϲ�ѯ</asp:ListItem>
                    <asp:ListItem Value="18">�����������ѯ</asp:ListItem>
                    <asp:ListItem Value="20">�����޳��̲�ѯ</asp:ListItem>
                    <asp:ListItem Value="19">����ע��ѯ</asp:ListItem>
                    <asp:ListItem Value="-1">��ѯȫ��</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
            <asp:TextBox ID="tbCon" runat="server" CssClass="pink" ToolTip="�����ѯ�ؼ���"></asp:TextBox>
            </td><td align="left">
            <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
            <td style="padding:0px;"><input id="btnSchsH" type="button" value="�߼���ѯ" class="bsch" onclick="parent.ShowDialog(470,428, 'Services/SerCd.aspx', '�߼���ѯ');" /></td>
            </tr>
            </table>   
        </div>
        <div class="clearfloat"></div>
    </div>
    
    <div id="cndiv" style="float:left;height:1px;">
    <div id="divtop" style="overflow:auto;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv1" OnRowDataBound="gvdata_RowDataBound" EnableViewState="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:CheckBox ID="cb" runat="server" />
                </ItemTemplate>
                <HeaderTemplate>
                    <input id="cball" type="checkbox" class="cb1" onclick="SltAllValue();" title="ȫѡ/ȡ��ȫѡ"/>
                </HeaderTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="ȡ��ԭ��" DataField="CancelReason" />
            <asp:BoundField HeaderText="���񵥺�" DataField="BillID" />
            <asp:BoundField HeaderText="�������" DataField="ServicesType" />
            <asp:BoundField HeaderText="������" DataField="Operator" />
            <asp:BoundField HeaderText="����ʱ��" DataField="Time_TakeOver" />
            <asp:BoundField HeaderText="����ʱ��" DataField="Speding" />
            <asp:BoundField HeaderText="����ʽ" DataField="TakeStyle" />
            <asp:BoundField HeaderText="����λ" DataField="TakeDept" />
            <asp:BoundField HeaderText="���񼶱�" DataField="_PRI" />
            <asp:BoundField HeaderText="����Ա" DataField="DisposalOper" />  
            <asp:BoundField HeaderText="�ͻ�����" DataField="CustomerName" />
            <asp:BoundField HeaderText="��ϵ��" DataField="LinkMan" />
            <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
            <asp:BoundField HeaderText="�������" DataField="DeviceNO" />
            <asp:BoundField HeaderText="�����ͺ�" DataField="ProductModel" />
            <asp:BoundField HeaderText="Ʒ��" DataField="ProductBrand" />
            <asp:BoundField HeaderText="���" DataField="ProductClass" />
            <asp:BoundField HeaderText="���к�1" DataField="ProductSN1" />
            <asp:BoundField HeaderText="���к�2" DataField="ProductSN2" />
            <asp:BoundField HeaderText="����" DataField="Fault" />
            <asp:BoundField HeaderText="�����ʩ/���" DataField="TakeSteps" />
            <asp:BoundField HeaderText="������" DataField="QtyType" />
            <asp:BoundField HeaderText="�������" DataField="Warranty" />
            <asp:BoundField HeaderText="ԤԼʱ��" DataField="SubscribeTime" />
            <asp:BoundField HeaderText="Ԥ����" DataField="SubscribePrice" />
            <asp:BoundField HeaderText="Ԥ�շ�" DataField="PreCharge" />
            <asp:BoundField HeaderText="����" DataField="bRepair" />
            <asp:BoundField HeaderText="ȡ��ԭ��" DataField="CancelReason" />
            <asp:BoundField HeaderText="��ע" DataField="Remark" />
            <asp:BoundField HeaderText="IsDismissed" DataField="IsDismissed" />
        </Columns>
    </asp:GridView>
    
    <table cellpadding="0" cellspacing="0" class="pages">
        <tr>
            <td><webdiyer:aspnetpager id="jsPager" runat="server" onpagechanged="jsPager_PageChanged" ShowBoxThreshold="1" CssClass="tdPage" InputBoxClass="page_input" SubmitButtonText="��ת:" /></td>
            <td style="padding-left:8px;"><asp:Label ID="lbPage" runat="server" ToolTip="��ҳ��ʾ��"></asp:Label></td>
            <td style="padding-left:8px;"><asp:Label ID="lbCountText" runat="server" ToolTip="�ܼ�¼��" Text="�ܼ�¼:"></asp:Label><asp:Label ID="lbCount" runat="server" ToolTip="�ܼ�¼��"></asp:Label></td>
        </tr>
    </table>
    
    <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
    <asp:HiddenField ID="hfSch" runat="server" Value="-1" />
    <asp:HiddenField ID="hfOrderName" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrderTitle" runat="server" Value="ID" />
    <asp:HiddenField ID="hfOrder" runat="server" Value="Desc" />
    <asp:HiddenField ID="hfSql" runat="server" />
    <asp:HiddenField ID="hfTbTitle" runat="server" />
    <asp:HiddenField ID="hfTbField" runat="server" />
    <asp:HiddenField ID="hfcbID" runat="server" />
    <asp:HiddenField ID="hfParm" runat="server" Value="-1" />
    <asp:HiddenField ID="hfPurDept" runat="server" Value="0" />
    <asp:HiddenField ID="hfPurOPDept" runat="server" Value="0" />
    <asp:HiddenField ID="hfTecDept" runat="server" Value="0" />
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnOrder" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChkClose" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSchH" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    <div id="divbottom" style="overflow:hidden;">
    <div id="divdetail" runat="server">
        <div class="ftool2">
        <div id="mytabs">
            <span id="tabs_l1" class="tabs_activeleft"></span>
            <span id="tabs1" class="tabs_active" >�����ϸ</span>
            <span id="tabs_r1" class="tabs_activeright"></span>
        </div>
        </div>
        <div style=" height:123px;background:#ECE9D8;">
        <div style="border-bottom:#808080 1px solid;">
              <table cellpadding="0" cellspacing="0" class="tb2">
                <tr>
                <td>
                   <input id="btnNew" type="button" value="�½�" class="bt1" onclick="NewDeduct();" />
                   <input id="btnMod" type="button" value="�޸�" class="bt1" onclick="ModDeduct();" />
                   <asp:Button ID="btnDel" runat="server" Text="ɾ��" CssClass="bt1" OnClientClick="if(ChkDel2('�����ϸ')==false) return false;"  UseSubmitBehavior="false" OnClick="btnDel_Click"/>
                </td>
                </tr>
              </table>
        </div>
        <div class="cndiv2" id="cndiv2" style="height:90px;">
           <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView2_RowDataBound" EnableViewState="false">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" />
                        <asp:BoundField HeaderText="��"/>
                        <asp:BoundField HeaderText="����" DataField="JobNO" />
                        <asp:BoundField HeaderText="����" DataField="_Name" />
                        <asp:BoundField HeaderText="����" DataField="Time_Finish" />
                        <asp:BoundField HeaderText="���" DataField="Deduct" />
                    </Columns>
                </asp:GridView>
                <asp:HiddenField ID="hfRecID2" runat="server" Value="-1" />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnFsh" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnClr" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnDel" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnSch" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnChkClose" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>
        </div>
        </div>
        </div>
    </div>
    </div>
    
    <div id="lncn" class="uw"></div>
    <div id="divright" style ="float:right;">
    <div class="divh"></div>
    <div id="rightcon">
    <fieldset style=" border: 1px #808080 solid; padding:5px 0;width:288px;">
      <legend>ά����Ϣ</legend>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb5">
            <tr>
                <td align="right">
                ����Ա��</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbDOperator" runat="server" CssClass="pinksb" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">����Ʒ�ƣ�</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbBrand" runat="server" CssClass="pinksb" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                �������</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbClass" runat="server" CssClass="pinksb" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                �����ͺţ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbModel" runat="server" CssClass="pinksb" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td>����������</td>
                <td style="padding-left:0px; height:40px;"><asp:TextBox ID="tbFault" runat="server" CssClass="pinksb" Width="200" TextMode="MultiLine" Height="30" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="sysred" align="center">�����ʩ<br />
                    /�����</td>
                <td style="padding-left:0px; height:40px;"><asp:TextBox ID="tbTakeSteps" runat="server" CssClass="pinksb" Width="200" TextMode="MultiLine" Height="30" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td style="padding-left:0px;"><a href="#" class="newr" onclick="ChkMod(700, 435,'Repository/RepositoryAdd.aspx','�½�֪ʶ');">��Ϊ֪ʶ</a></td>
            </tr>
        </table>
      </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
      </fieldset>
        <fieldset style=" border: 1px #808080 solid; padding:5px 0;width:288px;">
      <legend>������Ϣ</legend>
      <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb5">
            <tr>
                <td align="right">
                ���֣�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbdPoint" runat="server" CssClass="pinksb"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                Ԥ���۸�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSubPrice" runat="server" CssClass="pinksb" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                ���Ϸ��ã�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbFee_Materail" runat="server" CssClass="pinksb" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                ά�޷��ã�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbFee_Labor" runat="server" CssClass="pinksb" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                ���ӷѣ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSurCharge" runat="server" CssClass="pinksb" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                �ϼƣ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbTotal" runat="server" CssClass="pinksb" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                ȡ��ԭ��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbCancelReason" runat="server" CssClass="pinksb" ReadOnly="true" Width="200"></asp:TextBox></td>
            </tr>
            <tr>
                <td>��ע��Ϣ��</td>
                <td style="padding-left:0px;height:40px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pinksb" Width="200" TextMode="MultiLine" Height="30"></asp:TextBox></td>
            </tr>
       </table>
       </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
       </fieldset>
    </div>
    </div>
    <div class="clearfloat"></div>    
    <div class="fbom">  
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td><div id="fbon" class="fbon"></div></td>
            <td>
                <span class="sgay">��ȡ��</span>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;
var isfocus=2;
function ChkID(id)
{
    ClrID(id);
    $("btnShow").click();
}

function NewDeduct()
{
    var id=$("hfRecID").value;
    if(id=="-1")
    {
        alert("��ѡ��һ�����񵥺������");
        return false;
    }
    parent.ShowDialog(420, 120, 'Services/NewDeduct.aspx?id='+id+'&iflag=1', '�½������ϸ');
}

function ModDeduct()
{
    var id=document.getElementById("hfRecID2").value.replace("d","");
    if(id=="-1")
    {
        alert("��ѡ��һ�������ϸ�������");
    }
    else
    {
        parent.ShowDialog(420, 120,'Services/ModDeduct.aspx?id='+id, '�޸������ϸ');
    }
}

function ChkBack()
{
    var id=$("hfcbID").value;
    if(id=="")
        id=$("hfRecID").value;
        
    if(ChkSltValue()!=false)
    {    
        parent.ShowDialog(460,124, 'Services/OverBack.aspx?id='+id, '����');
    }else{return false;}
}

function ChkClose()
{
    if(ChkSltValue()!=false)
    {
        return confirm("ȷ��Ҫ��˹ر���ѡ��ķ�����");
    }else{return false;}
}

function ChkView()
{
    ChkMod(860,444, 'Services/SerView.aspx', '����');
}

function Chkset()
{
    Chkwhv2();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("��˹ر�");
}
</script>
