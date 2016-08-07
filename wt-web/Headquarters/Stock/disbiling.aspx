<%@ page language="C#"  CodeFile="disbiling.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Stock_DisBiling" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body onload="Chkset();" onclick="parent.Sethidden1();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="divh2"></div>
    <div class="tldiv">
        ��װ����
    </div>
    <div id="ctdiv">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td>��װ���ţ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbBillID" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox></td>
            <td align="right">���ڣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDate" runat="server" CssClass="pin" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox></td>
            <td align="right" colspan="2">�����ˣ�</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl">
                </asp:DropDownList>
            </td>
            <td class="sysred">���</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlType" runat="server" CssClass="pindl" onchange="chktype();">
                    <asp:ListItem Value="1">��ж</asp:ListItem>
                    <asp:ListItem Value="2">��װ</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="sysred" align="right">
                <asp:Label ID="lbType" runat="server" Text="��"></asp:Label>��ֿ⣺</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlStock" runat="server" CssClass="pindl">
                </asp:DropDownList>
            </td>
            <td class="sysred">��Ʒ��ţ�</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbGoodsNO" runat="server" CssClass="pin" onblur="chkgoods();"></asp:TextBox>
            </td>
            <td style="padding:0px;"><input id="btnSlt" type="button" value="" onclick="SltGds();" class="bview"/></td>
            <td align="right">���ƣ�</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbGoodsName" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox>
            </td>
            <td>���</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbSpec" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox>
            </td>
            <td>
                <asp:CheckBox ID="cbStockOut" runat="server" Text="��ж����" Visible="false" />
            </td>
        </tr>
        <tr>
            <td align="right">Ʒ�ƣ�</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbBrand" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox>
            </td>
            <td align="right">���ۣ�</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbPrice" runat="server" CssClass="pin"></asp:TextBox>
            </td>
            <td class="sysred" align="right" colspan="2">������</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbQty" runat="server" CssClass="pin" onblur="chkgdsqty();"></asp:TextBox>
            </td>
            <td>��ע��</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin"></asp:TextBox></td>
            <td>
                <asp:HiddenField ID="hfSNs" runat="server" />
                <a href="javascript:void(0);" onclick="EditSN($('hfGoodsID').value,$('hfUnitsID').value,'hfSNs','tbQty',0);">�༭���к�</a>
            </td>
        </tr>
     </table>
     </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnchkgdsqty" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnchkgoods" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChkParts" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    <div class="divh"></div>
    </div>
    <div id="cndiv" style="height:1px;">
        <div id="fdiv" class="fdiv">
            <div id="sdiv" class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvdata_RowDataBound" OnRowDeleting="gvdata_RowDeleting">
                        <Columns>
                        <asp:BoundField HeaderText="ID" DataField="GoodsID" />
                        <asp:BoundField HeaderText="UnitID" DataField="UnitID" />
                        <asp:BoundField HeaderText="��" />
                        <asp:BoundField HeaderText="�ֿ�" DataField="StockName" />
                        <asp:BoundField HeaderText="��Ʒ���" DataField="GoodsNO" />
                        <asp:BoundField HeaderText="����" DataField="_Name" />
                        <asp:BoundField HeaderText="���" DataField="Spec" />
                        <asp:BoundField HeaderText="Ʒ��" DataField="ProductBrand" />
                        <asp:BoundField HeaderText="��λ" DataField="Unit" />
                        <asp:TemplateField HeaderText="����">
                            <ItemTemplate>
                                <asp:TextBox ID="tbQty" runat="server" Text='<%# Eval("Qty") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                                <asp:HiddenField ID="hfSN" runat="server" Value='<%#Eval("SN") %>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="���к�" />
                        <asp:TemplateField HeaderText="����">
                            <ItemTemplate>
                                <asp:TextBox ID="tbPrice" runat="server" Text='<%# Eval("Price") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                                <input id="btnsch" name="btnsch" type="button" value="" runat="server" class="sch_btn" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���">
                            <ItemTemplate>
                                <asp:Label ID="lbAmount" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="MainTenancePeriod" HeaderText="������" />
                        <asp:TemplateField HeaderText="��ע">
                            <ItemTemplate>
                                <asp:TextBox ID="tbRemark" runat="server" CssClass="tbstyle" Text='<%# Eval("Remark") %>' Width="200" onfocus="select();"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ɾ��">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbDel" TabIndex="-1" runat="server" CausesValidation="False"  CommandName="Delete" Text="ɾ��" style="color:#0000ff;"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
                    <asp:HiddenField ID="hfreclist" runat="server" />
                    <asp:HiddenField ID="hfRecIDs" runat="server" Value="-1" />
                    <asp:HiddenField ID="hfName" runat="server" />
                    <asp:HiddenField ID="hfUnitID" runat="server" />
                    <asp:HiddenField ID="hfGoodsID" runat="server" />
                    <asp:HiddenField ID="hfUnitsID" runat="server" Value="-1" />
                    <asp:HiddenField ID="hfGoodsNO" runat="server" />
                    <asp:HiddenField ID="hfQty" runat="server" />
                    <asp:HiddenField ID="hfPrintID" runat="server" />
                    <asp:HiddenField ID="hfControl" runat="server" Value="0" />
                     <span style="display:none;">
                     <asp:Button ID="btnId" runat="server" Text="..." OnClick="btnId_Click" />
                     <asp:Button ID="btnSure" runat="server" Text="..." OnClick="btnSure_Click" />
                     <asp:Button ID="btnSltStock" runat="server" Text="..." OnClick="btnSltStock_Click" />
                     <asp:Button ID="btnSltUnit" runat="server" Text="..." OnClick="btnSltUnit_Click" />
                     <asp:Button ID="btnchkgoods" runat="server" Text="..." OnClick="btnchkgoods_Click" />
                     <asp:Button ID="btnchkgdsqty" runat="server" Text="..." OnClick="btnchkgdsqty_Click" />
                     <asp:Button ID="btnChkParts" runat="server" Text="..." OnClick="btnChkParts_Click" />
                     </span>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnchkgoods" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnchkgdsqty" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnChkParts" EventName="Click" />
                </Triggers>
             </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div class="divh"></div>
    <div class="tdiv">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <table cellpadding="0" cellspacing="0" class="tb3">
        <tr>
            <td style="padding-left:15px;">
                <asp:DropDownList ID="ddlSchFld" runat="server" CssClass="pindl" Width="70">
                    <asp:ListItem Value="BarCode">������</asp:ListItem>
                    <asp:ListItem Value="GoodsNO">�����</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td><asp:TextBox ID="tbCon" runat="server" CssClass="pin" onkeydown="EnterTextBox(event, this);" ToolTip="������ɺ�س����"></asp:TextBox></td>
            <td><input id="tbSltGoods" type="button" value="ѡ���Ʒ" class="bt1" onclick="SltGoods();" /></td>
            <td style="padding-left:10px;">�ϼ�������</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbAQty" runat="server" CssClass="pinbr" ReadOnly="true" Width="100"></asp:TextBox></td>
            <td>�ϼƽ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbAmount" runat="server" CssClass="pinbr" ReadOnly="true" Width="100"></asp:TextBox></td>
        </tr>
    </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnchkgoods" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnchkgdsqty" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnId" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSure" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChkParts" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    
    <div class="ftool">
    <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
        <tr>
            <td><span class="si1">���ֹ������Ż����룬������ɺ�س�</span></td>
            <td align="right" style="padding-right:20px;">
                <asp:Button ID="btnChk" runat="server" Text="���" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;"  OnClick="btnChk_Click"/>
                <asp:Button ID="btnAdd" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;"  OnClick="btnAdd_Click"/>
                <asp:Button ID="btnClean" runat="server" Text="���" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkClean()==false)return false;" OnClick="btnClean_Click"/>
                <input id="btnPrint" runat="server" type="button" value="��ӡ" class="bt1" onclick="ChkPrint('CZD');" />
                <input id="btnCls" type="button" value="�ر�" class="bt1" onclick="parent.CloseWin();" />
            </td>
        </tr>
    </table>
    </div>
    <div class="fbom">
        <div id="fbon" class="fbon"></div> 
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/detailslt.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/detail.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;

function ChkID(id)
{
    ClrID(id);
}

function ChkIDs(id,unitid)
{
    ClrID4(id);
    $("hfUnitID").value=unitid;
}

function EnterTextBox(event, obj)
{
    if(event.keyCode == 13&&!isNull(obj.value))
    {
        if(!isNull(obj.value))
        {
            $("btnSure").click();
        }
    }
}

function ChkSave()
{
    if(isNull($("tbDate").value))
    {
        window.alert("����ʧ�ܣ����ڲ���Ϊ��");
        $("tbDate").focus();
        return false
    }
    
   if($("ddlOperator").value=="-1")
    {
        window.alert("����ʧ�ܣ������˲���Ϊ��");
        $("ddlOperator").focus();
        return false
    }
    
    if($("ddlStock").value=="-1")
    {
        window.alert("����ʧ�ܣ��ֿⲻ��Ϊ��");
        $("ddlStock").focus();
        return false
    }
    
    if(isNull($("tbPrice").value))
    {
        window.alert("����ʧ�ܣ����۲���Ϊ��");
        $("tbPrice").focus();
        return false
    }
    if(!isMoney($("tbPrice").value))
    {
        window.alert("���۸�ʽ����ȷ");
        $("tbPrice").focus();
        return false
    }
    var amount=parseFloat($("tbPrice").value)*parseFloat($("tbQty").value)
    if(amount!=parseFloat($("tbAmount").value))
    {
        if(confirm("��װ��Ʒ�����ʵ�ʲ�Ʒ��ϸ�������Ƿ������"))
            return true;
        else
            return false;
    }
}
function chkgoods()
{
    if(!isNull($("tbGoodsNO").value))
    {
        if($("tbGoodsNO").value!=$("hfGoodsNO").value)
            $("btnchkgoods").click();
    }
}
function chkgdsqty()
{
    if(isMoney($("tbQty").value))
    {
        if(parseFloat($("tbQty").value)>=1)
        {
            if($("tbQty").value!=$("hfQty").value)
            $("btnchkgdsqty").click();
        }
        else
        {alert("���������������1����������룡");$("tbQty").focus();}
    }
    else{alert("�����ʽ����ȷ����������룡");$("tbQty").focus();}
}
function chktype()
{
    chkcx();
    var ctrls=document.getElementsByTagName("input");
    for(i=0;i<ctrls.length;i++)
    {
        if(ctrls[i].type=="hidden"&&ctrls[i].id.indexOf('hfSN')>=0)
        {
            ctrls[i].value="";
        } 
    }
}
function chkcx()
{
    if($("ddlType").value=="1")
    {
        $("lbType").innerHTML="��";
        if($("hfControl").value=="1")
        {
            $("cbStockOut").disabled=false;
            $("tbQty").className="pinb";
            $("tbQty").value="1";
            $("tbQty").readOnly=true;
        }
    }
    else
    {
        $("lbType").innerHTML="��";
        if($("hfControl").value=="1")
        {
            $("cbStockOut").checked=false;
            $("cbStockOut").disabled=true;
            $("tbQty").className="pin";
            $("tbQty").value="1";
            $("tbQty").readOnly=false;
        }
    }
}
chkcx();
function SltGds()
{
    parent.ShowDialog(800, 520, 'Stock/SltDisbGoods.aspx', 'ѡ���Ʒ');
}
function SltGoods()
{
    if(!isNull($("hfGoodsID").value))
    parent.ShowDialog(800, 520, 'Stock/SltGoods.aspx', 'ѡ���Ʒ');
    else
    {
        alert("����ѡ��Ҫ["+$("ddlType").options[$("ddlType").selectedIndex].innerText+"]�Ĳ�Ʒ");
        $("tbGoodsNO").focus();
    }
}
function Chkset()
{
    Chkwh10();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("��װ����");
}
function EditSN(goodsid,unitid,SN,nums,flag)
{
   var gdsnum=$(nums).value;
   var gsunit=parseInt(unitid);
   if(gsunit<=0)
   {
        alert("����ʧ�ܣ�����ѡ���Ʒ");
        return false;
   }
   if(gdsnum<=0)
   {
        alert("����ʧ�ܣ��������Ʒ����");
        return false;
   }
   var url='Stock/EditSN.aspx?unitid='+unitid+'&snvalue='+escape($(SN).value)+'&snid='+SN+'&gdsnum='+escape(gdsnum);
   if(($("ddlType").value=="1"&&flag==0)||($("ddlType").value=="2"&&flag==1))
   {
        url=url+"&iflag=2&goodsid="+goodsid;
   }
   parent.ShowDialog(400, 300,url , '�༭���к�');
}
</script>
