<%@ page language="C#"  CodeFile="serview.aspx.cs"     autoeventwireup="true" inherits="Branch_Office_SerView" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/tab.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:846px;">
    <div id="mytabs">
        <span id="tabs_l1"></span>
        <span id="tabs1" onclick="ChkTab('1');">������Ϣ</span>
        <span id="tabs_r1"></span>
        <span id="tabs_l2"></span>
        <span id="tabs2" onclick="ChkTab('2');">��������</span>
        <span id="tabs_r2"></span>
        <span id="tabs_l3"></span>
        <span id="tabs3" onclick="ChkTab('3');">��Ŀ/����/�Ĳ�/������</span>
        <span id="tabs_r3"></span>
        <span id="tabs_l4"></span>
        <span id="tabs4" onclick="ChkTab('4');">�շѽ���</span>
        <span id="tabs_r4"></span>
        <span id="tabs_l10"></span>
        <span id="tabs10" onclick="ChkTab('10');">�����ϸ</span>
        <span id="tabs_r10"></span>
        <span id="tabs_l5"></span>
        <span id="tabs5" onclick="ChkTab('5');">�ط���Ϣ</span>
        <span id="tabs_r5"></span>
        <span id="tabs_l6"></span>
        <span id="tabs6" onclick="ChkTab('6');">�������</span>
        <span id="tabs_r6"></span>
        <span id="tabs_l7"></span>
        <span id="tabs7" onclick="ChkTab('7');">���񱨼�</span>
        <span id="tabs_r7"></span>
        <span id="tabs_l8"></span>
        <span id="tabs8" onclick="ChkTab('8');">�ߵ�</span>
        <span id="tabs_r8"></span>
        <span id="tabs_l9"></span>
        <span id="tabs9" onclick="ChkTab('9');">������־</span>
        <span id="tabs_r9"></span>
        <span id="tabs_l11"></span>
        <span id="tabs11" onclick="ChkTab('11');">����</span>
        <span id="tabs_r11"></span>
     </div>
    <div id="info1" style="padding:3px 0px 0px 3px; overflow:hidden;" >
        <div id="divinfo1" class="divinfo" style="height:100%;">
            <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td>���񵥺�:</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBillID" runat="server" CssClass="pinb" ReadOnly="true" Width="120"></asp:TextBox></td>
                <td>�������</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="pindl" Width="126">
                    </asp:DropDownList>
                </td>
                <td >����ʽ��</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlTake" runat="server" CssClass="pindl" Width="126">
                    </asp:DropDownList>
                </td>
                 <td >����ʱ�䣺</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbTakeTime" runat="server" CssClass="pin" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" Width="120"></asp:TextBox></td>
            </tr>
            <tr>
                <td  class="sysred">�ͻ�����:</td>
                <td colspan="3" style="padding-left:0px;">
                    <asp:TextBox ID="tbCusName" runat="server" CssClass="pin" Width="321" AutoCompleteType="Disabled"></asp:TextBox>
                </td>
                <td>
                �����ˣ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin" Width="120"></asp:TextBox></td>
                <td >�����˵绰��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin" Width="120"></asp:TextBox></td>
            </tr>
            <tr>
                <td >
                ʹ���ˣ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbUsePerson" runat="server" CssClass="pin" Width="120"></asp:TextBox></td>
                <td >
                �������ţ�</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <input type="text" id="tbDept" runat="server" class="pin pinin" Width="106"/>
                        <select id="slDept" onchange="document.getElementById('tbDept').value=this.options[this.selectedIndex].value" class="pininsl" style="width:126px;clip: rect(auto auto auto 107px);">
                            <option value="" selected="selected"></option>
                            <option value="���۲�">���۲�</option>
                            <option value="�г���">�г���</option>
                            <option value="���²�">���²�</option>
                        </select>
                    </div>
                </td>
                <td>
                ʹ���˵绰��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbUsePersonTel" runat="server" CssClass="pin" Width="120"></asp:TextBox></td>
                <td >��������</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbArea" runat="server" CssClass="pin pinin" Width="106"></asp:TextBox>
                        <asp:DropDownList ID="ddlArea" runat="server" CssClass="pininsl" onchange="document.getElementById('tbArea').value=this.options[this.selectedIndex].text;" Width="126" style="clip: rect(auto auto auto 107px);">
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>
            <tr>
                <td>��ϵ��ַ:</td>
                <td colspan="3" style="padding-left:0px;">
                    <asp:TextBox ID="tbAdr" runat="server" CssClass="pin" Width="320"></asp:TextBox>
                </td>
                <td class="sysred" >
                �����ˣ�</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl" Width="126">
                    </asp:DropDownList>
                </td>
                <td class="sysred">
                �Ƶ�ʱ�䣺</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbDate" CssClass="pin" runat="server" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" Width="120"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td >�������:</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbDeviceNO" runat="server" CssClass="pin" Width="120"></asp:TextBox></td>
                <td  class="red">����Ʒ�ƣ�</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbBrand" runat="server" CssClass="pin pinin" Width="106"></asp:TextBox>
                        <asp:DropDownList ID="ddlBrand" runat="server" CssClass="pininsl" Width="126" style="clip: rect(auto auto auto 107px);">
                        </asp:DropDownList>
                    </div>
                </td>
                <td >�������</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbClass" runat="server" CssClass="pin pinin" Width="106">
                        </asp:TextBox>
                        <asp:DropDownList ID="ddlClass" runat="server" CssClass="pininsl" Width="126" style="clip: rect(auto auto auto 107px);">
                        </asp:DropDownList>
                    </div>
                </td>
                <td >�����ͺţ�</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbModel" runat="server" CssClass="pin pinin" Width="106"></asp:TextBox>
                        <asp:DropDownList ID="ddlModel" runat="server" CssClass="pininsl" Width="126" style="clip: rect(auto auto auto 107px);">
                        </asp:DropDownList>
                    </div>
                </td>
                
            </tr>
            <tr>
                <td  class="red">���к�1��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSN1" runat="server" CssClass="pin" Width="120"></asp:TextBox>
                </td>
                <td >���к�2��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSN2" runat="server" CssClass="pin" Width="120"></asp:TextBox>
                </td>
                <td >������ۣ�</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbAspect" runat="server" Width="120"></asp:TextBox>
                </td>
                <td >���������</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbAcc" runat="server" CssClass="pin" Width="120"></asp:TextBox></td>
            </tr>
            <tr>
                <td  rowspan="2">���ƹ���:</td>
                <td colspan="3" rowspan="2" style="padding-left:0px;">
                    <asp:TextBox ID="tbFault" runat="server" CssClass="pin" Width="321" Height="42" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="red">���������</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlRepStatus" runat="server" CssClass="pindl" Width="126">
                    </asp:DropDownList>
                </td>
                <td >���񼶱�</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlPRI" runat="server" CssClass="pindl" Width="126">
                    </asp:DropDownList>
                </td>
                
            </tr>
            <tr>
                <td >�����̣�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBuyFrom" runat="server" CssClass="pin" Width="120"></asp:TextBox></td>
                <td >����ʱ�䣺</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBuyTime" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="120"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>����Ʊ:</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBuyInvoice" runat="server" CssClass="pin" Width="120"></asp:TextBox></td>
                 <td >���֣�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbPoint" runat="server" CssClass="pin" Width="120"></asp:TextBox>
                </td>
                <td >�������ţ�</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbPostNO" runat="server" CssClass="pin" Width="120"></asp:TextBox>
                </td>
                <td >�������ã�</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbPostage" runat="server" CssClass="pin" Width="120"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>�浵����:</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSaveID" runat="server" CssClass="pin" Width="120"></asp:TextBox></td>
                <td>���̵��ţ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbCorpID" runat="server" CssClass="pin" Width="120"></asp:TextBox></td>
                <td >���㳧�̣�</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlChargeCorp" runat="server" CssClass="pindl" Width="126">
                    </asp:DropDownList>
                </td>
                <td >����Ա��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbDisposal" runat="server" CssClass="pin" Width="120"></asp:TextBox>
                </td>
                
            </tr>    
            <tr>
                <td>ԤԼʱ��:</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSubTime" runat="server" CssClass="pin" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" Width="120"></asp:TextBox>
                </td>
                <td>ԤԼȡ����</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSubContTime" runat="server" CssClass="Wdate" Width="120" onfocus="WdatePicker()"></asp:TextBox>
                </td>
                <td >Ԥ���۸�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSubPrice" runat="server" CssClass="pin" Width="120"></asp:TextBox></td>
                <td >Ԥ�շѣ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSubCharge" runat="server" CssClass="pin" Width="120"></asp:TextBox></td>
            </tr>
            <tr>
                <td>��ע��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="120"></asp:TextBox></td>
                <td colspan="2" align="center"><label for="cbRe">����:</label><asp:CheckBox ID="cbRe" runat="server" Text="" />
                 <label for="cbAgain">���ޣ�</label> <asp:CheckBox ID="cbAgain" runat="server" Text="" /></td>
                <td>���ۺ�ͬ��:</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbContNO" runat="server" CssClass="pin2"></asp:TextBox>
                </td>
                <td>Ԥ�����ʱ��:</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbCmpTime" runat="server" CssClass="Wdate" Width="120" onfocus="WdatePicker()"></asp:TextBox>
                 <div id="dUpload" runat="server" style="display:inline;"></div>
                    <asp:HiddenField ID="hfCusID" runat="server" />
                    <asp:HiddenField ID="hfDevID" runat="server" />
                    <asp:HiddenField ID="hfPrintID" runat="server" />
                    <asp:HiddenField ID="hfPath" runat="server" />
                </td>
            </tr>
        </table>
        </div>
    </div>
    <div id="info2" style="overflow:hidden; height:369px;" >
      <div id="div5" class="divinfo" style="height:100%;padding:0px; overflow:auto;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="��"/>
                <asp:BoundField HeaderText="����" DataField="_Name" />
                <asp:BoundField HeaderText="����" DataField="Parameter" />
                <asp:BoundField HeaderText="���к�" DataField="SN" />
                <asp:BoundField HeaderText="������" DataField="MaintenancePeriod" />
                <asp:BoundField HeaderText="��ֹ����" DataField="MaintenanceEnd" />
                <asp:BoundField HeaderText="��������" DataField="BuyDate" />
                <asp:BoundField HeaderText="��ע" DataField="Remark" />
            </Columns>
         </asp:GridView>
      </div>
    </div>
    <div id="info3" style="padding:3px 0px 0px 3px; overflow:hidden; height:366px;" >
        <div id="div1" class="divinfo" style="height:100%; padding-left:15px;">
        <span style=" color:#0046d5">����/�Ĳ�</span> 
        <div class="fdivs" style="width:806px; height:100px;">
        <div class="sdivs" style="width:804px; height:98px;">
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView2_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="��"/>
                    <asp:BoundField HeaderText="��Ʒ���" DataField="GoodsNO" />
                    <asp:BoundField HeaderText="����" DataField="_Name" />
                    <asp:BoundField HeaderText="���" DataField="Spec" />
                    <asp:BoundField HeaderText="Ʒ��" DataField="ProductBrand" />
                    <asp:BoundField HeaderText="��λ" DataField="Unit" />
                    <asp:BoundField HeaderText="����" DataField="Qty" />
                    <asp:BoundField HeaderText="����" DataField="Price" />
                    <asp:BoundField HeaderText="˰��" DataField="TaxRate" />
                    <asp:BoundField HeaderText="˰��" DataField="TaxAmount" />
                    <asp:BoundField HeaderText="���" DataField="Total" />
                    <asp:BoundField HeaderText="���к�" DataField="SN" />
                    <asp:BoundField HeaderText="������" DataField="MaintenancePeriod" />
                    <asp:BoundField HeaderText="��ֹ����" DataField="PeriodEndDate" />
                    <asp:BoundField HeaderText="���㷽ʽ" DataField="ChargeStyle" />
                    <asp:BoundField HeaderText="�Ƿ��⹺" DataField="OutSourcing" />
                    <asp:BoundField HeaderText="�⹺����" DataField="OutCostPrice" />
                    <asp:BoundField HeaderText="��ע" DataField="Remark" />
                </Columns>
             </asp:GridView>
         </div>
         </div>
         <div class="divh" style="height:12px;"></div>
          <div style=" color:#0046d5;">��Ŀ</div>
          <div class="fdivs" style="width:806px; height:100px;">
            <div class="sdivs" style="width:804px; height:98px;">
              <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView3_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="��"/>
                    <asp:BoundField HeaderText="��Ŀ���" DataField="ItemNO" />
                    <asp:BoundField HeaderText="����" DataField="_Name" />
                    <asp:BoundField HeaderText="���" DataField="Price" />
                    <asp:BoundField HeaderText="��ʱ" DataField="dPoint" />
                    <asp:BoundField HeaderText="���" DataField="TecDeduct" />
                    <asp:BoundField HeaderText="����Ա" DataField="Tec" />
                    <asp:BoundField HeaderText="���㷽ʽ" DataField="ChargeStyle" />
                    <asp:BoundField HeaderText="�Ƿ��깤" DataField="bComplete" />
                    <asp:BoundField HeaderText="��ע" DataField="Remark" />
                </Columns>
             </asp:GridView>
            </div>
           </div>
           <div class="divh" style="height:12px;"></div>
          <div style=" color:#0046d5;">������</div>
          <div class="fdivs" style="width:806px; height:80px;">
            <div class="sdivs" style="width:804px; height:78px;">
              <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="��"/>
                    <asp:BoundField HeaderText="��������" DataField="_Date" />
                    <asp:BoundField HeaderText="������" DataField="Operator" />
                    <asp:BoundField HeaderText="����" DataField="QtyType" />
                    <asp:BoundField HeaderText="����" DataField="Qty" />
                    <asp:BoundField HeaderText="����" DataField="Allowance" />
                    <asp:BoundField HeaderText="��ע"  DataField="Remark"/>
                </Columns>
             </asp:GridView>
            </div>
           </div>
        </div>
    </div>
    
    <div id="info4" style="padding:3px 0px 0px 3px; overflow:hidden; height:366px;" >
        <div runat="server" id="div2" class="divinfo" style="height:100%;padding:0px; padding-left:10px;">
            <fieldset style=" border: 1px #808080 solid; padding:5px 0; width:810px;">
                <legend>���úͳɱ�</legend>
                    <table cellpadding="0" cellspacing="0" class="tb1">
                            <tr>
                                <td>���Ϸ��ã�</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbFee_Materail" runat="server" CssClass="pin" Width="110"></asp:TextBox></td>
                                <td>���ӷ��ã�</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbFee_Add" runat="server" CssClass="pin" Width="110"></asp:TextBox></td>
                                <td>ά�޷��ã�</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbFee_Labor" runat="server" CssClass="pin" Width="110"></asp:TextBox></td>
                                <td align="right">�ϼƣ�</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbFee_Total" runat="server" CssClass="pin" ReadOnly="true" Width="110"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>���ϳɱ���</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbCost_Materail" runat="server" CssClass="pin" Width="110"></asp:TextBox></td>
                                <td>���޳ɱ���</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbRepCost" runat="server" CssClass="pin" Width="110"></asp:TextBox>
                                </td>
                                <td>����ɱ���</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbCost_Add" runat="server" CssClass="pin" Width="110"></asp:TextBox></td>
                                <td>ҵ��ë����</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbProfit" runat="server" CssClass="pin" Width="110"></asp:TextBox></td> 
                            </tr>
                    </table>   
                </fieldset>
                <div class="divh"></div>
                <fieldset style=" border: 1px #808080 solid; padding:5px 0; width:810px;">
                <legend>��<asp:Label ID="lbbln" runat="server" Text="�ͻ�"></asp:Label>����</legend>
                    <table cellpadding="0" cellspacing="0" class="tb1">
                            <tr>
                                <td align="right" style="padding-left:26px;">�տ��ˣ�</td>
                                <td style="padding-left:0px;">
                                    <asp:DropDownList ID="ddlRcvMan" runat="server" CssClass="pindl" Width="116">
                                    </asp:DropDownList>
                                </td>
                                <td>�������ڣ�</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbRcvDate" runat="server" CssClass="pin" Width="110"></asp:TextBox></td>
                                <td>Ӧ���</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbChargeValue" runat="server" CssClass="pin" Width="110"></asp:TextBox></td>
                                <td>�Żݽ�</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbPreMoney" runat="server" CssClass="pin" Width="110"></asp:TextBox></td>
                            </tr> 
                            <tr>
                                <td>ʵ���տ</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbRealMoney" runat="server" CssClass="pin" Width="110"></asp:TextBox></td>
                                <td>�ֽ��</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbInCash" runat="server" CssClass="pin" Width="110"></asp:TextBox></td>
                            </tr>
                    </table>
                </fieldset>
                <div class="divh"></div>
                <fieldset style=" border: 1px #808080 solid; padding:5px 0; width:810px;">
                <legend>�Գ��ҽ���</legend>
                    <table cellpadding="0" cellspacing="0" class="tb1">
                            <tr>
                                <td>�������ƣ�</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbFacName" runat="server" CssClass="pin" Width="110"></asp:TextBox></td>
                                <td>�����</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbFacAmount" runat="server" CssClass="pin" Width="110"></asp:TextBox></td>
                            </tr>
                    </table>  
                </fieldset>
                <div class="divh"></div>
                <fieldset style=" border: 1px #808080 solid; padding:5px 0; width:810px;">
                <legend>ά�ޱ���</legend>
                    <table cellpadding="0" cellspacing="0" class="tb1">
                            <tr>
                                <td>���޽�ֹ��</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbEndDate" runat="server" CssClass="pin" Width="110"></asp:TextBox></td>
                                <td>���޷�Χ��</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbEndPlace" runat="server" CssClass="pin" Width="110"></asp:TextBox></td>
                                <td>��Ʒȥ��</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbGone" runat="server" CssClass="pin" Width="110"></asp:TextBox></td>
                                <td>�������ڣ�</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbGoneDate" runat="server" CssClass="pin" Width="110" ></asp:TextBox></td>  
                            </tr>
                    </table>  
                </fieldset>
        </div>
    </div>
    
    <div id="info5" style="padding:3px 0px 0px 3px; overflow:hidden; height:366px;" >
        <div id="div3" class="divinfo" style="height:100%;">
          <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td align="right">
                �ط����ڣ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbVisitDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="122"></asp:TextBox></td>
                <td align="right">
                �ط��ˣ�</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlVisitOperator" runat="server" CssClass="pindl" Width="126">
                    </asp:DropDownList>
                </td>
                <td align="right">�ط���ʽ��</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlVisitStyle" runat="server" CssClass="pindl" Width="126">
                    </asp:DropDownList>
                </td>
                <td align="right">
                ���ط��ˣ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbVisitOperator" runat="server" CssClass="pin" Width="126"></asp:TextBox></td>
            </tr>
            <tr>
                <td>�ͻ������</td>
                <td style="padding-left:0px; height:40px;" colspan="3"><asp:TextBox ID="tbCusOpinon" runat="server" CssClass="pin" Width="309" TextMode="MultiLine" Height="30"></asp:TextBox></td>
                <td>�طñ�ע��</td>
                <td style="padding-left:0px;height:40px;" colspan="3"><asp:TextBox ID="tbVisitRemark" runat="server" CssClass="pin" Width="327" TextMode="MultiLine" Height="30"></asp:TextBox></td>
            </tr>
        </table>
        <div class="divh"></div>
        <div style="padding-left:20px;">
        <div style=" border: 1px #808080 solid; padding:5px 0; height:260px; width:788px; overflow:auto;">
            <asp:TreeView ID="tv" runat="server" ShowLines="True" >
            </asp:TreeView>
            <asp:HiddenField ID="hfrdID" runat="server" />
        </div>
        </div>
        </div>
    </div>
    
    <div id="info6" style="overflow:hidden; height:369px;" >
      <div id="div7" class="divinfo" style="height:100%;padding:0px; overflow:auto;">
            <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="��"/>
                    <asp:BoundField HeaderText="����ʽ" DataField="DoStyle" />
                    <asp:BoundField HeaderText="������" DataField="Person" />
                    <asp:BoundField HeaderText="��������" DataField="Dept" />
                    <asp:BoundField HeaderText="������" DataField="Operator" />
                    <asp:BoundField HeaderText="����ʱ��" DataField="_Date" />
                    <asp:BoundField HeaderText="�����ʩ/���" DataField="TakeSteps" />
                    <asp:BoundField HeaderText="����ʱ��" DataField="StartTime" />
                    <asp:BoundField HeaderText="����ʱ��" DataField="Spending" />
                    <asp:BoundField HeaderText="���ʱ��" DataField="ArrivedTime" />
                    <asp:BoundField HeaderText="����ԭ��" DataField="Reason" />
                    <asp:BoundField HeaderText="�²�������" DataField="DoDept" />
                    <asp:BoundField HeaderText="�²�������" DataField="DoOperator" />
                    <asp:BoundField HeaderText="����ʱ��" DataField="visitdate" />
                    <asp:BoundField HeaderText="�������" DataField="Course" />
                 </Columns>
            </asp:GridView>
        </div>
    </div>
    <div id="info7" style="overflow:hidden; height:369px;" >
      <div id="div8" class="divinfo" style="height:100%;padding:0px; overflow:auto;">
            <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="��"/>
                    <asp:BoundField HeaderText="����" DataField="_Date" />
                    <asp:BoundField HeaderText="������" DataField="Operator" />
                    <asp:BoundField HeaderText="������" DataField="Seller" />
                    <asp:BoundField HeaderText="������Ŀ" DataField="_Name" />
                    <asp:BoundField HeaderText="���" DataField="dAmount" />
                    <asp:BoundField HeaderText="�ͻ�ȷ��" DataField="CusConf" />
                    <asp:BoundField HeaderText="��ע" DataField="Remark" />
                 </Columns>
             </asp:GridView>
        </div>
    </div>
    <div id="info8" style="overflow:hidden; height:369px;" >
      <div id="div9" class="divinfo" style="height:100%;padding:0px; overflow:auto;">
            <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="��"/>
                    <asp:BoundField HeaderText="�ߵ���" DataField="LinkMan" />
                    <asp:BoundField HeaderText="��ϵ�绰" DataField="Tel" />
                    <asp:BoundField HeaderText="�ߵ�ʱ��" DataField="_Date" />
                    <asp:BoundField HeaderText="������" DataField="Operator" />
                    <asp:BoundField HeaderText="������" DataField="Result" />
                 </Columns>
             </asp:GridView>
        </div>
    </div>
    <div id="info9" style="overflow:hidden; height:369px;" >
      <div id="div4" class="divinfo" style="height:100%;padding:0px; overflow:auto;">
            <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="��"/>
                    <asp:BoundField HeaderText="ʱ��" DataField="_Date"/>
                    <asp:BoundField HeaderText="����Ա" DataField="Operator"/>
                    <asp:BoundField HeaderText="�¼�" DataField="Event" />
                </Columns>
             </asp:GridView>
        </div>
    </div>
    <div id="info10" style="overflow:hidden; height:369px;" >
      <div id="div10" class="divinfo" style="height:100%;padding:0px; overflow:auto;">
            <asp:GridView ID="GridView9" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView1_RowDataBound" EnableViewState="false">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="��"/>
                    <asp:BoundField HeaderText="����" DataField="JobNO" />
                    <asp:BoundField HeaderText="����" DataField="_Name" />
                    <asp:BoundField HeaderText="����" DataField="Time_Finish" />
                    <asp:BoundField HeaderText="���" DataField="Deduct" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div id="info11" style="overflow:hidden; height:369px;" >
      <div id="div11" class="divinfo" style="height:100%;padding:0px; overflow:auto;">
            <asp:GridView ID="GridView10" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView10_RowDataBound" EnableViewState="false">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="��"/>
                    <asp:BoundField HeaderText="��������" DataField="iType" />
                    <asp:TemplateField>
                    <HeaderTemplate>
                    ��������
                    </HeaderTemplate>
                    <ItemTemplate>
                    <a href='<%#Eval("FilePath") %><%#Eval("FileName") %>' target="_blank"><%#Eval("FileName") %></a>
                    </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="right">
                <input id="btnPrint" runat="server" type="button" value="��ӡ" class="bt1" onclick="ChkPrint('XD');" />
                <input id="btnClose" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog<%=str_flag %>();" />
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
var tabnum=12;

document.onkeydown=function(){if(event.keyCode==27){try{parent.CloseDialog<%=str_flag %>();}catch(e){}}}
</script>
