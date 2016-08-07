<%@ page language="C#"  CodeFile="sellmod.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Sell_SellMod" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
        <style>
        .sdivs,table {
        width:100%;
        }
            td {
                padding-left: 0px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:960px;">
    <div class="fdivs">
    <div class="sdivs" style="padding:3px 0 3px 0px;">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td style="padding-left:0px;"> <asp:Label ID="lbType" runat="server" Text="����"></asp:Label>���ţ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbBillID" runat="server" CssClass="pinb" ReadOnly="true" Width="102"></asp:TextBox></td>
            <td align="right" style="padding-left:0px;">���ڣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDate" runat="server" CssClass="pin" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" Width="100"></asp:TextBox></td>
            <td colspan="2" align="right" style="padding-left:0px;">ҵ��Ա��</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl" Width="106">
                </asp:DropDownList>
            </td>
            <td align="right" style="padding-left:0px;">�ͻ��ˣ�</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlSndOperator" runat="server" CssClass="pindl" Width="106">
                </asp:DropDownList>
            </td>
            <td style="padding-left:0px;">�Ա�ţ�</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbAutoNO" runat="server" CssClass="pin" Width="100"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" style="padding-left:0px;"></td>
            <td style="padding-left:0px;">&nbsp;</td>
            <td class="sysred" align="right" style="padding-left:0px;">�ͻ����ƣ�</td>
            <td style="padding-left:0px;">
                <div class="isinDiv">
                <asp:TextBox ID="tbCusName" runat="server"  Width="120" CssClass="pin autot" onmousedown="getSearchResult('../Customer/SchCusList.aspx','tbCusName','hfCusID','1','btnCusInfo',event);" onkeyup="getSearchResult('../Customer/SchCusList.aspx','tbCusName','hfCusID','1','btnCusInfo',event);" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
            </td>
            <td style="padding:0px;"><input id="btnSlt" type="button" value="" onclick="SltCus();" class="bview"/></td>
            <td align="right" style="padding-left:0px;">��ϵ�ˣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbLinkMan" Visible="false" runat="server" CssClass="pin" Width="100"></asp:TextBox>
                    <asp:DropDownList ID="ddl_LinkMan" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_LinkMan_SelectedIndexChanged">
                      <asp:ListItem Value="-1">��ѡ��ͻ���ϵ��</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td align="right" style="padding-left:0px;">��ϵ�绰��</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin" Width="100"></asp:TextBox></td>
              <td style="padding-left:0px;">��ַ:</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin" Width="100"></asp:TextBox></td>
        </tr>
             <tr>
                <td>������</td>
                <td><asp:DropDownList ID="ddl_isdai" runat="server">
                    <asp:ListItem Value="0" Selected="True">��</asp:ListItem>
                        <asp:ListItem Value="1" >��</asp:ListItem>
                    </asp:DropDownList></td>
                   <td class="sysred" align="right">�ͻ�2��</td>
            <td style="padding-left:0px;">
                <div class="isinDiv">
                    <asp:TextBox ID="tbCusName2" runat="server"  Width="120" CssClass="pin autot" onmousedown="getSearchResult('../Customer/SchCusList.aspx','tbCusName2','hfCusID2','1','btnCusInfo2',event);" onkeyup="getSearchResult('../Customer/SchCusList.aspx','tbCusName2','hfCusID2','1','btnCusInfo2',event);" AutoCompleteType="Disabled"></asp:TextBox>
                <%--<asp:TextBox ID="tbCusName2" runat="server" CssClass="pin autot"  Width="120" onmousedown="getSearchResult('../Customer/SchCusList.aspx','tbCusName2','hfCusID2','1','btnCusInfo2',event);" onkeyup="getSearchResult('../Customer/SchCusList.aspx','tbCusName2','hfCusID2','1','btnCusInfo2',event);" AutoCompleteType="Disabled"></asp:TextBox>--%>
                </div>
            </td>
            <td style="padding:0px;"><input id="btnSlt2" type="button" onclick="SltCus2();" class="bview"/></td>
            <td align="right">��ϵ��2</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbLinkMan2" Visible="false" runat="server" CssClass="pin"  Width="120"></asp:TextBox>
                <asp:DropDownList ID="ddl_LinkMan2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_LinkMan2_SelectedIndexChanged">
                      <asp:ListItem Value="-1">��ѡ��ͻ���ϵ��</asp:ListItem>
                </asp:DropDownList>
                <input id="Button2" type="button" onclick="addCuslink()" class="bview" style="display:none"/>
            </td>
            <td align="right">�绰2��</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbTel2" runat="server" CssClass="pin"  Width="100"></asp:TextBox></td>
                  <td>��ַ2��</td>
                 <td  style="padding-left:0px;">
                     <asp:TextBox ID="tbAdr2" runat="server" CssClass="pin" Width="100"></asp:TextBox>
                 </td>
            </tr>
        <tr>
            <td style="padding-left:0px;">��������:</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbwangdian" runat="server" Width="100" AutoCompleteType="Disabled" CssClass="pin" onkeyup="getSearchResult('../Customer/c_getbrandch.aspx','btnwangdian','hfwangdianID','1','btnwangdian',event);" onmousedown="getSearchResult('../Customer/c_getbrandch.aspx','tbwangdian','hfwangdianID','1','btnwangdian',event);"></asp:TextBox>
            </td>
            <td align="right" style="padding-left:0px;">
                ����˰��</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddl_branchFax" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_branchFax_SelectedIndexChanged" Width="120">
                    <asp:ListItem Selected="True" Value="no-0">����˰</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td colspan="2" align="right" style="padding-left:0px;">
                ���㷽ʽ��</td>
            <td style="padding-left:0px;">
            <span style="display:none;"><asp:Button ID="btnCusInfo" runat="server" Text="..." OnClick="btnCusInfo_Click"/></span>
                   <span style="display:none;"> <asp:Button ID="btnCusInfo2" runat="server" Text="..." OnClick="btnCusInfo2_Click"/></span>
                  <span style="display:none;">  <asp:Button ID="btnwangdian" runat="server" Text="..." OnClick="btnWangdian_Click"/>
                
                </span><asp:DropDownList ID="ddlChargeStyle" runat="server" CssClass="pindl" Width="106">
                </asp:DropDownList>
            </td>
            <td align="right" style="padding-left:0px;">
            �����ʻ���</td>
            <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlChargeAccount" runat="server" Width="106" CssClass="pindl">
                    </asp:DropDownList>
            </td>
              <td style="padding-left:0px;">��ע��</td>
            <td style="padding-left:0px;">     
                <asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="100"></asp:TextBox>
                <asp:DropDownList ID="ddlInvoiceClass" runat="server" CssClass="pindl" Width="106"  Visible="false">
                    </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="right" style="padding-left:0px;">
                &nbsp;</td>
            <td style="padding-left:0px;">&nbsp;</td>
            <td align="right" style="padding-left:2px;">
                &nbsp;</td>
            <td style="padding-left:0px;">
                &nbsp;</td>
            <td align="right" colspan="2" style="padding-left:0px;">
                ��Ʊ����</td>
            <td style="padding-left:0px;" >
                <asp:TextBox ID="tbInvoiceNO" runat="server" CssClass="pin" Width="100"></asp:TextBox>
            </td>
            <td align="right" style="padding-left:0px;">
                ��Ʊ���ڣ�</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbInvoiceDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="102"></asp:TextBox>
            </td>
              <td style="padding-left:0px;">��Ʊ��</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbInvoiceAmount" runat="server" CssClass="pin" Width="100"></asp:TextBox>
            </td>
        </tr>
          
     </table>
     </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnCusInfo" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnCusInfo2" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="ddl_LinkMan" EventName="SelectedIndexChanged" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    </div>
    <div class="divh"></div>
    <div id="cndiv" style="height:250px;">
        <div class="fdivs" style="height:248px;">
            <div class="sdivs" style="height:246px;background:#ffffff;">
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
                                  <asp:TextBox ID="tbhuoqi"  runat="server" Text='<%# Eval("Huoqi") %>' CssClass="tbstyle huoqi" ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                                <asp:TemplateField HeaderText="��ɫ">
                            <ItemTemplate>
                                <asp:DropDownList ID="ddl_chengse" runat="server" SelectedValue='<%# Eval("chengse") %>' >
                                    <asp:ListItem Value=""></asp:ListItem>
                                    <asp:ListItem Value="99��">99��</asp:ListItem>
                                     <asp:ListItem Value="ԭװ">ԭװ</asp:ListItem>
                                     <asp:ListItem Value="���">���</asp:ListItem>  
                                     <asp:ListItem Value="����">����</asp:ListItem>                                       
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                               <asp:TemplateField HeaderText="��װ" >
                            <ItemTemplate>
                               <asp:DropDownList ID="ddl_baozhuang" runat="server" SelectedValue='<%# Eval("baozhuang") %>' >
                                   <asp:ListItem Value=""></asp:ListItem>
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
                    <asp:HiddenField ID="hfdellist" runat="server" />
                    <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
                    <asp:HiddenField ID="hfreclist" runat="server" />
                    <asp:HiddenField ID="hfRecIDs" runat="server" Value="-1" />
                    <asp:HiddenField ID="hfName" runat="server" />
                    <asp:HiddenField ID="hfUnitID" runat="server" />
                    <asp:HiddenField ID="hfOperationID" runat="server" />
                    <asp:HiddenField ID="hfSltID" runat="server" />
                    <asp:HiddenField ID="hfCusID" runat="server" />
                         <asp:HiddenField ID="hfCusID2" runat="server" />
                      <asp:HiddenField ID="hfwangdianID" runat="server" />
                    <asp:HiddenField ID="hfPrintID" runat="server" />
                     <span style="display:none;">
                     <asp:Button ID="btnId" runat="server" Text="..." OnClick="btnId_Click" />
                     <asp:Button ID="btnSure" runat="server" Text="..." OnClick="btnSure_Click" />
                     <asp:Button ID="btnSltStock" runat="server" Text="..." OnClick="btnSltStock_Click" />
                     <asp:Button ID="btnSltUnit" runat="server" Text="..." OnClick="btnSltUnit_Click" />
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
    <div class="fdivs">
    <div class="sdivs" style="padding:1px 0 1px 0px;">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <table cellpadding="0" cellspacing="0" class="tb4">
        <tr>
            <td style="padding-left:10px;" align="right">�ϼ�������</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbAQty" runat="server" CssClass="pinbr" ReadOnly="true" Width="100"></asp:TextBox></td>
            <td style="padding-left:10px;">�ϼƽ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbAmount" runat="server" CssClass="pinbr" ReadOnly="true" Width="100"></asp:TextBox></td>
            <td>��˰�ϼƣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbGoodsAmount" runat="server" CssClass="pinbr" Width="100"></asp:TextBox></td>
            <td style="padding-left:10px;">�ֽ��</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbInCash" runat="server" CssClass="pin pblue" Width="100"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="padding-left:15px;">
                <asp:DropDownList ID="ddlSchFld" runat="server" CssClass="pindl" Width="60">
                    <asp:ListItem Value="BarCode">������</asp:ListItem>
                    <asp:ListItem Value="GoodsNO">�����</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td colspan="2"><asp:TextBox ID="tbCon" runat="server" CssClass="pin" onkeydown="EnterTextBox(event, this);" ToolTip="������ɺ�س����" Width="150"></asp:TextBox></td>
            <td style="padding-left:0px;"><input id="tbSltGoods" type="button" value="ѡ���Ʒ" class="bt1" onclick="parent.ShowDialog1(800, 520, 'Stock/SltGoods.aspx', 'ѡ���Ʒ');" /></td>
        </tr>
    </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChk" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnId" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSure" EventName="Click" />
           <asp:AsyncPostBackTrigger ControlID="ddl_branchFax" EventName="SelectedIndexChanged" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:Label ID="lbMod" runat="server"></asp:Label>
            </td>
            <td align="right">
                <asp:Button ID="btnChk" runat="server" Text="���" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;"  OnClick="btnChk_Click"/>
                <asp:Button ID="btnAdd" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;"  OnClick="btnAdd_Click"/>
                <asp:Button ID="btnClean" runat="server" Text="���" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkClean()==false)return false;" OnClick="btnClean_Click"/>
                <input id="btnPrint" runat="server" type="button" value="��ӡ" class="bt1" onclick="ChkPrint('XSD');" />
                <input id="btnClose" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog<%=Str_F %>();" />
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
<script language="javascript" type="text/javascript" src="../../Public/Script/detailslt.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/detail.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/AutoSchCon.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="/codingpages/js/jquery-1.7.2.min.js"></script>
<script language="javascript" type="text/javascript">
    jQuery.noConflict();
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
   if($("ddlOperator").value=="-1")
    {
        window.alert("����ʧ�ܣ�ҵ��Ա����Ϊ��");
        $("ddlOperator").focus();
        return false
    }
    
    if(isNull($("tbCusName").value))
    {
        window.alert("����ʧ�ܣ��ͻ����Ʋ���Ϊ��");
        $("tbCusName").focus();
        return false
    }
    if ($("ddl_LinkMan").value == "-1") {
        window.alert("����ʧ�ܣ��ͻ���ϵ�˲���Ϊ��");
        return false
    }
    var flage= true;
    jQuery(".huoqi").each(function () {
        if (isNull(jQuery(this).val()))
        {
            alert("���ڲ���Ϊ��");
            flage = false;
            return false;
        }
    });
    if (!flage)
    {
        return false;
    }
    var str="Ӧ��";
    if($("lbType").innerHTML!="����")
        str="Ӧ��";
    if(!isMoney($("tbInCash").value))
    {
        alert("����ʧ�ܣ��ֽ����ʽ����ȷ������������");
        $("tbInCash").focus();
        return false;
    }
    if(parseFloat($("tbInCash").value)>parseFloat($("tbGoodsAmount").value))
    {
        if(confirm("�ֽ�����ڼ�˰�ϼ�("+str+"���),�Ƿ������"))
            return true;
        else
            return false;
    }
}

function EditSN(goodsid,unitid,SN,nums)
{
   var gdsnum=$(nums).value;
   if(gdsnum<=0)
   {
        alert("����ʧ�ܣ��������Ʒ����");
        return false;
   }
   var iflag="2";
   if(document.getElementById("lbType").innerHTML=="�˻�")
   iflag="1";
   
   parent.ShowDialog1(400, 300, 'Stock/EditSN.aspx?iflag='+iflag+'&goodsid='+goodsid+'&unitid='+unitid+'&snvalue='+escape($(SN).value)+'&snid='+SN+'&gdsnum='+escape(gdsnum), '�༭���к�');
}
function SltCus()
{
    parent.ShowDialog1(800, 500, 'Customer/SltCus.aspx?f=2', 'ѡ��ͻ�');
}
function SltCus2()
{
    parent.ShowDialog1(800, 500, 'Customer/SltCus2.aspx?f=2', 'ѡ��ͻ�');
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
