<%@ page language="C#"  CodeFile="selladd.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Sell_SellAdd" theme="Themes" enableEventValidation="false" %>
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
        ���ۿ���
    </div>
    <div id="ctdiv">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td>���۵��ţ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbBillID" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox></td>
            
            <td align="right">���ڣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDate" runat="server" CssClass="pin" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox></td>
            <td colspan="2" align="right">ҵ��Ա��</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl">
                </asp:DropDownList>
            </td>
            <td align="right">�ͻ��ˣ�</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlSndOperator" runat="server" CssClass="pindl">
                </asp:DropDownList>
            </td>
            <td></td>
        </tr>
        <tr>
            <td align="right">�Ա�ţ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbAutoNO" runat="server" CssClass="pin"></asp:TextBox></td>
            <td class="sysred" align="right">�ͻ����ƣ�</td>
            <td style="padding-left:0px;">
                <div class="isinDiv">
                <asp:TextBox ID="tbCusName" runat="server" CssClass="pin autot" onmousedown="getSearchResult('../Customer/SchCusList.aspx','tbCusName','hfCusID','1','btnCusInfo',event);" onkeyup="getSearchResult('../Customer/SchCusList.aspx','tbCusName','hfCusID','1','btnCusInfo',event);" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
            </td>
            <td style="padding:0px;"><input id="btnSlt" type="button" onclick="SltCus();" class="bview"/></td>
            <td align="right">��ϵ�ˣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbLinkMan" Visible="false" runat="server" CssClass="pin"></asp:TextBox>
                <asp:DropDownList ID="ddl_LinkMan" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_LinkMan_SelectedIndexChanged">
                      <asp:ListItem Value="-1">��ѡ��ͻ���ϵ��</asp:ListItem>
                </asp:DropDownList>
                <input id="btnaddlinkman" type="button" onclick="addCuslink()" class="bview"/>
            </td>
            <td align="right">��ϵ�绰��</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin"></asp:TextBox></td>
              <td>��ַ��<asp:TextBox ID="tbAdr" runat="server" CssClass="pin"></asp:TextBox></td>
        </tr>
            <tr>
                <td>�Ƿ������</td>
                
                <td><asp:DropDownList ID="ddl_isdai" runat="server">
                    <asp:ListItem Value="0" Selected="True">��</asp:ListItem>
                        <asp:ListItem Value="1" >��</asp:ListItem>
                    </asp:DropDownList></td>
                   <td class="sysred" align="right">�ͻ�2��</td>
            <td style="padding-left:0px;">
                <div class="isinDiv">
                <asp:TextBox ID="tbCusName2" runat="server" CssClass="pin autot" onmousedown="getSearchResult('../Customer/SchCusList.aspx','tbCusName2','hfCusID2','1','btnCusInfo2',event);" onkeyup="getSearchResult('../Customer/SchCusList.aspx','tbCusName2','hfCusID2','1','btnCusInfo2',event);" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
            </td>
            <td style="padding:0px;"><input id="btnSlt2" type="button" onclick="SltCus2();" class="bview"/></td>
            <td align="right">��ϵ��2</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbLinkMan2" Visible="false" runat="server" CssClass="pin"></asp:TextBox>
                <asp:DropDownList ID="ddl_LinkMan2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_LinkMan2_SelectedIndexChanged">
                      <asp:ListItem Value="-1">��ѡ��ͻ���ϵ��</asp:ListItem>
                </asp:DropDownList>
                <input id="Button2" type="button" onclick="addCuslink()" class="bview" style="display:none"/>
            </td>
            <td align="right">�绰2��</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbTel2" runat="server" CssClass="pin"></asp:TextBox></td>
                  <td>��ַ2��<asp:TextBox ID="tbAdr2" runat="server" CssClass="pin"></asp:TextBox></td>
            </tr>
        <tr>
           <td align="right">
            �������㣺</td>
            <td style="padding-left:0px;">
                   <div class="isinDiv">             
                        <asp:TextBox ID="tbwangdian"  runat="server" CssClass="pin autot" onmousedown="getSearchResult('../Customer/c_getbrandch.aspx','tbwangdian','hfwangdianID','1','btnwangdian',event);" onkeyup="getSearchResult('../Customer/c_getbrandch.aspx','tbwangdian','hfwangdianID','1','btnwangdian',event);" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
            </td>
           
            <td>���㷽ʽ��</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlChargeStyle" runat="server" CssClass="pindl">
                </asp:DropDownList>
            </td>
            <td colspan="2" align="right">
            ��ע��</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin"></asp:TextBox>
            <span style="display:none;"><asp:Button ID="btnCusInfo" runat="server" Text="..." OnClick="btnCusInfo_Click"/></span>
                 <span style="display:none;"><asp:Button ID="btnCusInfo2" runat="server" Text="..." OnClick="btnCusInfo2_Click"/></span>
            </td>
            <td align="right">
            �����ʻ���</td>
            <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlChargeAccount" runat="server" CssClass="pindl">
                    </asp:DropDownList>
            </td>
              <td></td>
        </tr>
        <tr>
             <td align="right">
            ����˰�ʣ�</td>
          <td style="padding-left:0px;"><%-- <div class="isinDiv">  <asp:TextBox ID="tbwdTaxrate"   runat="server" CssClass="pin autot" AutoCompleteType="Disabled" ReadOnly="True"  ></asp:TextBox>--%>
              <asp:DropDownList ID="ddl_branchFax" runat="server" Width="150" AutoPostBack="True" OnSelectedIndexChanged="ddl_branchFax_SelectedIndexChanged">
                        <asp:ListItem Value="no-0" Selected="True">����˰</asp:ListItem>
              </asp:DropDownList>
              </div>   <asp:DropDownList ID="ddlInvoiceClass" runat="server" CssClass="pindl" Visible="false">
                    </asp:DropDownList></td>          
            <td align="right">
            ��Ʊ���룺</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbInvoiceNO" runat="server" CssClass="pin"></asp:TextBox>
            </td>
            <td align="right" colspan="2">
            ��Ʊ���ڣ�</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbInvoiceDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
            </td>
            <td align="right">
            ��Ʊ��</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbInvoiceAmount" runat="server" CssClass="pin" ></asp:TextBox>
            </td>
              <td></td>
        </tr>

              
     </table>   <span style="display:none;">  <asp:Button ID="btnwangdian" runat="server" Text="..." OnClick="btnWangdian_Click"/></span>
     </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSltBill" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnCusInfo" EventName="Click" />
          <asp:AsyncPostBackTrigger ControlID="btnCusInfo2" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="ddl_LinkMan" EventName="SelectedIndexChanged" />
             <asp:AsyncPostBackTrigger ControlID="ddl_LinkMan2" EventName="SelectedIndexChanged" />
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
                                <asp:TextBox ID="tbSN" runat="server" Text='<%# Eval("SN") %>' style="display:none;" ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="���к�" />
                        <asp:TemplateField HeaderText="����">
                            <ItemTemplate>
                                <asp:TextBox ID="tbPrice" runat="server" Text='<%# Eval("Price") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                                <input id="btnsch" name="btnsch" type="button" value="" runat="server" class="sch_btn" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�ۿ�">
                            <ItemTemplate>
                                <asp:TextBox ID="tbDis" runat="server" Text='<%# Eval("Dis") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���">
                            <ItemTemplate>
                                <asp:Label ID="lbAmount" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="����">
                            <ItemTemplate>
                                <asp:TextBox ID="tbTaxRate" Visible="false" runat="server" Text='<%# Eval("TaxRate") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                                <asp:TextBox ID="tbhuoqi" runat="server" Text='<%# Eval("Huoqi") %>' CssClass="tbstyle huoqi" ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:TemplateField HeaderText="��ɫ">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddl_chengse" runat="server" SelectedValue='<%# string.IsNullOrEmpty(Eval("chengse").ToString())?"99��":Eval("chengse") %>'>
                                    <asp:ListItem Value="99��">99��</asp:ListItem>
                                     <asp:ListItem Value="ԭװ">ԭװ</asp:ListItem>
                                     <asp:ListItem Value="���">���</asp:ListItem>  
                                     <asp:ListItem Value="����">����</asp:ListItem>                                       
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                               <asp:TemplateField HeaderText="��װ">
                            <ItemTemplate>
                               <asp:DropDownList ID="ddl_baozhuang" runat="server" SelectedValue='<%# string.IsNullOrEmpty( Eval("baozhuang").ToString())?"�µ�":Eval("baozhuang") %>'>
                                      <asp:ListItem Value="�µ�">�µ�</asp:ListItem>
                                     <asp:ListItem Value="ԭװ">ԭװ</asp:ListItem>
                                     <asp:ListItem Value="��ͨ">��ͨ</asp:ListItem>  
                                     <asp:ListItem Value="�ɵ�">�ɵ�</asp:ListItem>       
                               </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="˰��">
                            <ItemTemplate>
                                <asp:Label ID="lbTaxAmount" runat="server" Text='<%# Eval("TaxAmount") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="��˰�ϼ�">
                            <ItemTemplate>
                                <asp:Label ID="lbGoodsAmount" runat="server" Text='<%# Eval("GoodsAmount") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="������">
                            <ItemTemplate>
                                <asp:TextBox ID="tbPeriod" runat="server" CssClass="tbstyle" Text='<%# Eval("MainTenancePeriod") %>' Width="100" onfocus="select();"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="��ֹ����">
                            <ItemTemplate>
                                <asp:TextBox ID="tbPeriodEnd" runat="server" CssClass="tbstyle" Text='<%# Eval("PeriodEnd") %>' Width="100" onfocus="WdatePicker()"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
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
                    <asp:HiddenField ID="hfOperationID" runat="server" />
                    <asp:HiddenField ID="hfConstractID" runat="server" />
                    <asp:HiddenField ID="hfSltID" runat="server" />
                    <asp:HiddenField ID="hfSltID1" runat="server" />
                    <asp:HiddenField ID="hfCusID" runat="server" />
                      <asp:HiddenField ID="hfCusID2" runat="server" />
                    <asp:HiddenField ID="hfPrintID" runat="server" />
                        <asp:HiddenField ID="hfwangdianID" runat="server" />
                    <asp:HiddenField ID="hfFlag" runat="server" Value="-1" />
                  <span style="display:none;">
                     <asp:Button ID="btnId" runat="server" Text="..." OnClick="btnId_Click" />
                     <asp:Button ID="btnSure" runat="server" Text="..." OnClick="btnSure_Click" />
                     <asp:Button ID="btnSltUnit" runat="server" Text="..." OnClick="btnSltUnit_Click" />
                     <asp:Button ID="btnSltStock" runat="server" Text="..." OnClick="btnSltStock_Click" />
                     <asp:Button ID="btnSltBill" runat="server" Text="..." OnClick="btnSltBill_Click" />                   
                     </span>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
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
                    <asp:ListItem Value="SN">�����к�</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td><asp:TextBox ID="tbCon" runat="server" CssClass="pin" onkeydown="EnterTextBox(event, this);" ToolTip="������ɺ�س����"></asp:TextBox></td>
            <td><input id="tbSltGoods" type="button" value="ѡ���Ʒ" class="bt1" onclick="parent.ShowDialog(800, 520, 'Stock/SltGoods.aspx', 'ѡ���Ʒ');" /></td>
            <td><input id="btnPurPlan" type="button" value="���۶���" class="bt1" onclick="parent.ShowDialog(800, 520, 'Sell/SltSellPlan.aspx', 'ѡ�����۶���');" /></td>
            <td><input id="btnSaleContract" type="button" value="���ۺ�ͬ" class="bt1" onclick="parent.ShowDialog(800, 520, 'Sell/SltSellContract.aspx', 'ѡ�����ۺ�ͬ');" /></td>
            <td style="padding-left:10px;">�ϼ�������</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbAQty" runat="server" CssClass="pinbr" ReadOnly="true" Width="50"></asp:TextBox></td>
            <td style="padding-left:10px;">�ϼƽ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbAmount" runat="server" CssClass="pinbr" ReadOnly="true" Width="80"></asp:TextBox></td>
            <td style="padding-left:10px;">��˰�ϼƣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbGoodsAmount" runat="server" CssClass="pinbr"  Width="80"></asp:TextBox></td>
            <td style="padding-left:10px;">�ֽ��</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbInCash" runat="server" CssClass="pin pblue" Width="80"></asp:TextBox></td>
        </tr>
    </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnId" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSure" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSltBill" EventName="Click" />
         <asp:AsyncPostBackTrigger ControlID="ddl_branchFax" EventName="SelectedIndexChanged" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    
    <div class="ftool">
    <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
        <tr>
            <td><span class="si1">���ֹ������Ż����룬������ɺ�س�</span>
            </td>
            <td align="right" style="padding-right:20px;">
                <asp:Button ID="btnChk" runat="server" Text="���" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;"  OnClick="btnChk_Click"/>
                <asp:Button ID="btnAdd" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;"  OnClick="btnAdd_Click"/>
                <asp:Button ID="btnClean" runat="server" Text="���" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkClean()==false)return false;" OnClick="btnClean_Click"/>
                <input id="btnPrint" runat="server" type="button" value="��ӡ" class="bt1" onclick="ChkPrint('XSD');" />
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
<script language="javascript" type="text/javascript" src="../../Public/Script/AutoSchCon.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="/codingpages/js/jquery-1.7.2.min.js"></script>
<script language="javascript" type="text/javascript">
    jQuery.noConflict();
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
    if (isNull($("tbwangdian").value))
    {
        window.alert("����ʧ�ܣ����㲻��Ϊ��");
        $("tbwangdian").focus();
        return false
    }
    if(isNull($("tbCusName").value))
    {
        window.alert("����ʧ�ܣ��ͻ����Ʋ���Ϊ��");
        $("tbCusName").focus();
        return false
    }

   if($("ddlOperator").value=="-1")
    {
        window.alert("����ʧ�ܣ�ҵ��Ա����Ϊ��");
        $("ddlOperator").focus();
        return false
   }
   if ($("ddl_LinkMan").value == "-1") {
       window.alert("����ʧ�ܣ��ͻ���ϵ�˲���Ϊ��");
       return false
   }
   if ($("ddl_isdai").value == "1") {
       if ($("ddl_LinkMan2").value == "-1") {
           window.alert("����ʧ�ܣ���ϵ��2����Ϊ��");
           return false
       }
   }
    if(!isMoney($("tbInCash").value))
    {
        alert("����ʧ�ܣ��ֽ����ʽ����ȷ������������");
        $("tbInCash").focus();
        return false;
    }
    if(parseFloat($("tbInCash").value)>parseFloat($("tbGoodsAmount").value))
    {
        if(confirm("�ֽ�����ڼ�˰�ϼ�(Ӧ�ս��),�Ƿ������"))
            return true;
        else
            return false;
    }
    var flage = true;
    jQuery(".huoqi").each(function () {
        if (isNull(jQuery(this).val())) {
            alert("���ڲ���Ϊ��");
            flage = false;
            return false;
        }
    });
    if (!flage) {
        return false;
    }

}
function SltCus()
{
    parent.ShowDialog1(800, 500, 'Customer/SltCus.aspx?f=2&fid='+parent.$("hfActiveWin").value, 'ѡ��ͻ�');
}
function SltCus2() {
    parent.ShowDialog1(800, 500, 'Customer/SltCus2.aspx?f=2&fid=' + parent.$("hfActiveWin").value, 'ѡ��ͻ�');
}

function EditSN(goodsid,unitid,SN,nums)
{
   var gdsnum=$(nums).value;
   if(gdsnum<=0)
   {
        alert("����ʧ�ܣ��������Ʒ����");
        return false;
   }
   parent.ShowDialog(400, 300, 'Stock/EditSN.aspx?iflag=2&goodsid='+goodsid+'&unitid='+unitid+'&snvalue='+escape($(SN).value)+'&snid='+SN+'&gdsnum='+escape(gdsnum), '�༭���к�');
}

function Chkset()
{
    Chkwh10a();
    Chkbom(); 
}
function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("���ۿ���");
}
function addCuslink() {
    //parent.ShowDialog1(800, 500, 'Customer/cuslinkmanadd.aspx?f=2&fid=' + parent.$("hfActiveWin").value, 'ѡ��ͻ�');
    if (isNull($("hfCusID").value)) {
        window.alert("����ʧ�ܣ������ϵ��ǰ������ѡ�ͻ�");
    } else {
        parent.ShowDialog1(460, 350, 'Customer/CusLinkManAdd.aspx?f=&form=xsd&cid=' + $("hfCusID").value, '�½���ϵ��');
    }

}
function Caculate()
{
    var tb=$("gvdata");
    var summoney=0;
    for(i=1;i<tb.rows.length;i++)
    {
        var costprice=tb.rows[i].cells[11].getElementsByTagName("span")[0].innerHTML;
        if(!isNaN(costprice))
        {
            summoney+=parseFloat(costprice);
        }
    }
    $("tbInvoiceAmount").value=summoney
}
</script>
