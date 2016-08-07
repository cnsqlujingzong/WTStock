<%@ page language="C#"  CodeFile="servicesop.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Services_ServicesOp" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/tab.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="main">
        <div class="maincon">
        <div id="sad" style="width:706px;">
        <div id="mytabs">
            <span id="tabs_l1"></span>
            <span id="tabs1" onclick="ChkTab('1');">��������</span>
            <span id="tabs_r1"></span>
            <span id="tabs_l5"></span>
            <span id="tabs5" onclick="ChkTab('5');">������</span>
            <span id="tabs_r5"></span>
            <span id="tabs_l2"></span>
            <span id="tabs2" onclick="ChkTab('2');">����/�Ĳ�</span>
            <span id="tabs_r2"></span>
            <span id="tabs_l3"></span>
            <span id="tabs3" onclick="ChkTab('3');">������Ŀ</span>
            <span id="tabs_r3"></span>
            <span id="tabs_l4"></span>
            <span id="tabs4" onclick="ChkTab('4');">��������</span>
            <span id="tabs_r4"></span>
        </div>
       <div id="info1" style="height:415px;padding:3px 0px 0px 3px; overflow:hidden;">
            <div id="divinfo1" class="divinfo" style="height:100%;padding:0px; padding-left:10px;">
            <fieldset style=" border: 1px #808080 solid; padding:5px 0; width:680px;">
            <legend>����</legend>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" class="tb5">
                <tr>
                    <td align="right">
                    �����ˣ�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right">�����˵绰��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right">
                    ʹ���ˣ�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbUsePerson" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr>
                <tr>
                   <td align="right">
                    �������ţ�</td>
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
                    <td align="right">
                    ʹ���˵绰��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbUsePersonTel" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right" class="red">����Ʒ�ƣ�</td>
                    <td style="padding-left:0px;">
                      <div class="isinDiv">
                        <asp:TextBox ID="tbBrand" runat="server" CssClass="pin pinin" AutoCompleteType="Disabled" onblur="ChkPBrand();"></asp:TextBox>
                        <asp:DropDownList ID="ddlBrand" runat="server" CssClass="pininsl" onchange="document.getElementById('tbBrand').value=this.options[this.selectedIndex].text;NewProductBrands('1');" AutoPostBack="True" OnSelectedIndexChanged="ddlBrand_SelectedIndexChanged">
                        </asp:DropDownList>
                     </div>
                    </td>
                </tr>
                <tr>
                    <td align="right">�������</td>
                    <td style="padding-left:0px;">
                        <div class="isinDiv">
                        <asp:TextBox ID="tbClass" runat="server" CssClass="pin pinin" AutoCompleteType="Disabled" onblur="ChkPClass();">
                        </asp:TextBox>
                        <asp:DropDownList ID="ddlClass" runat="server" onchange="document.getElementById('tbClass').value=this.options[this.selectedIndex].text;NewProductClasss('1');" CssClass="pininsl" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                        </asp:DropDownList>
                        </div>
                    </td>
                    <td align="right">�����ͺţ�</td>
                    <td style="padding-left:0px;">
                      <div class="isinDiv">
                        <asp:TextBox ID="tbModel" runat="server" CssClass="pin pinin" AutoCompleteType="Disabled" onblur="ChkPModel();"></asp:TextBox>
                        <asp:DropDownList ID="ddlModel" runat="server" CssClass="pininsl" onchange="document.getElementById('tbModel').value=this.options[this.selectedIndex].text;NewProductModels('1');" AutoPostBack="True" OnSelectedIndexChanged="ddlModel_SelectedIndexChanged">
                        </asp:DropDownList>
                      </div>
                    </td>
                    <td align="right" class="red">���к�1��</td>
                    <td style="padding-left:0px;">
                      <asp:TextBox ID="tbSN1" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">���к�2��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbSN2" runat="server" CssClass="pin"></asp:TextBox></td>
                    <td align="right">���������</td>
                    <td style="padding-left:0px;" colspan="3">
                      <asp:TextBox ID="tbAcc" runat="server" CssClass="pin" Width="341"></asp:TextBox>
                    </td>
                    <td style="padding:0px;"><input id="btnSltAcc" type="button" value="" onclick="SltAcc();" class="bview"/></td>
                </tr>
                <tr>
                    <td align="right">���������</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlRepStatus" runat="server" CssClass="pindl" onchange="NewRepStatus('1');">
                            <asp:ListItem Value=""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td align="right">����Ʊ��</td>
                    <td style="padding-left:0px;">
                      <asp:TextBox ID="tbBuyInvoice" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td>
                        <asp:HiddenField ID="hfBrand" runat="server" />
                        <asp:HiddenField ID="hfClass" runat="server" />
                        <asp:HiddenField ID="hfWarranty" runat="server" />
                        <asp:HiddenField ID="hfModelID" runat="server" />
                        <asp:HiddenField ID="hfDevID" runat="server" />
                        <asp:HiddenField ID="hfCusID" runat="server" />
                        <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
                        <span style="display:none;">
                            <asp:Button ID="btnRefModel" runat="server" Text="GetPModel" OnClick="btnRefModel_Click" />
                            <asp:Button ID="btnRefBrand" runat="server" Text="RefBrand" OnClick="btnRefBrand_Click" />
                            <asp:Button ID="btnRefClass" runat="server" Text="RefClass" OnClick="btnRefClass_Click" />
                            <asp:Button ID="btnRefWarranty" runat="server" Text="RefWarranty" OnClick="btnRefWarranty_Click" />
                        </span>
                    </td>
                </tr>
                </table>
                </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            </Triggers>
            </asp:UpdatePanel>
            </fieldset>
            
                <fieldset style=" border: 1px #808080 solid; padding:5px 0; width:680px;">
                <legend>����</legend>
                 <table cellpadding="0" cellspacing="0" class="tb5">
                <tr>
                    <td align="right">�浵���ţ�</td>
                    <td style="padding-left:0px;">
                      <asp:TextBox ID="tbSaveID" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td align="right">ԤԼʱ�䣺</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbSubTime" runat="server" CssClass="pin" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox></td>
                    <td align="right">ȡ��ʱ�䣺</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbSubContTime" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right" class="sysred">����Ա��</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbDisposal" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox>
                    </td>
                    <td style="padding-left:10px;">���޳ɱ���</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbRepCost" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                    <td>����ɱ���</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbCostExtra" runat="server" CssClass="pin"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">���Ϸѣ�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbCost1" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox></td>
                    <td align="right">ά�޷ѣ�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbCost2" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox></td>
                    <td align="right">���ӷѣ�</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbCost3" runat="server" CssClass="pin"></asp:TextBox></td>
                </tr>
                </table>
                </fieldset>
                <fieldset style=" border: 1px #808080 solid; padding:5px 0; width:680px;">
                <legend>����</legend>
                <table cellpadding="0" cellspacing="0" class="tb5">
                <tr>
                    <td>����������</td>
                    <td style="padding-left:0px;height:42px;" colspan="3"><asp:TextBox ID="tbFault" runat="server" CssClass="pinb" ReadOnly="true" Height="32" Width="343"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">��ע��</td>
                    <td style="padding-left:0px;height:42px;" colspan="3"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Height="32" Width="341"></asp:TextBox></td>
                </tr>
             </table>
             </fieldset>
            </div>
       </div>
       <div id="info2" style="height:418px;overflow:hidden;">
            <div id="div1" class="divinfo" style="height:100%;padding:0px; overflow:auto;">
                <div id="div4" style="height:385px; overflow:auto;">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                <ContentTemplate>
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView2_RowDataBound" OnRowDeleting="GridView2_RowDeleting">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="GoodsID" />
                        <asp:BoundField HeaderText="UnitID" DataField="UnitID" />
                        <asp:BoundField HeaderText="��" />
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
                        <asp:TemplateField HeaderText="˰��">
                            <ItemTemplate>
                                <asp:TextBox ID="tbTaxRate" runat="server" Text='<%# Eval("TaxRate") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="˰��">
                            <ItemTemplate>
                                <asp:Label ID="lbTaxAmount" runat="server" Text='<%# Eval("TaxAmount") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���">
                            <ItemTemplate>
                                <asp:Label ID="lbAmount" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="������">
                            <ItemTemplate>
                                <asp:TextBox ID="tbPeriod" runat="server" Text='<%# Eval("MaintenancePeriod") %>' Width="100" CssClass="tbstyle"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="��ֹ����">
                            <ItemTemplate>
                                <asp:TextBox ID="tbPeriodEndDate" runat="server" Text='<%# Eval("PeriodEndDate") %>' Width="100" CssClass="tbstyle"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���㷽ʽ">
                            <ItemTemplate>
                                <asp:TextBox ID="tbChargeStyle" runat="server" Text='<%# Eval("ChargeStyle") %>' style="display:none;"></asp:TextBox>
                                <asp:DropDownList ID="ddlChargeStyle" runat="server">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�Ƿ��⹺">
                            <ItemTemplate>
                                <asp:CheckBox ID="cbOutSourcing" runat="server" Checked='<%# Eval("OutSourcing") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�⹺����">
                            <ItemTemplate>
                                <asp:TextBox ID="tbOutPrice" runat="server" Text='<%# Eval("OutCostPrice") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="��ע">
                            <ItemTemplate>
                                <asp:TextBox ID="tbRemark" runat="server" Text='<%# Eval("Remark") %>' Width="170" CssClass="tbstyle"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ɾ��">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbDel" TabIndex="-1" runat="server" CausesValidation="False"  CommandName="Delete" Text="ɾ��" style="color:#0000ff;"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                    <asp:HiddenField ID="hfdellist1" runat="server" />
                    <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
                    <asp:HiddenField ID="hfreclist" runat="server" />
                    <asp:HiddenField ID="hfRecIDs" runat="server" Value="-1" />
                    <asp:HiddenField ID="hfName" runat="server" />
                    <asp:HiddenField ID="hfUnitID" runat="server" />
                     <span style="display:none;">
                     <asp:Button ID="btnId1" runat="server" Text="..." OnClick="btnId1_Click" />
                     <asp:Button ID="btnSure1" runat="server" Text="..." OnClick="btnSure1_Click" />
                     <asp:Button ID="btnSltUnit" runat="server" Text="..." OnClick="btnSltUnit_Click" />
                     </span>
                </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>    
            </div>
            <div id="Div5" class="devtemadd">
                <table cellpadding="0" cellspacing="0" class="tb4">
                    <tr>
                     <td style="padding-left:15px;">
                        <asp:DropDownList ID="ddlSchFld" runat="server" CssClass="pindl" Width="70">
                            <asp:ListItem Value="GoodsNO">�����</asp:ListItem>
                            <asp:ListItem Value="BarCode">������</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                        <td>
                           <asp:TextBox ID="tbConInfo" runat="server" CssClass="pin" onkeydown="EnterTextBoxGds(event, this);" ToolTip="������ɺ�س����"></asp:TextBox>
                        </td>
                        <td>
                            <input id="tbSltGoods" type="button" value="ѡ���Ʒ" class="bt1" onclick="parent.ShowDialog1(800, 520, 'Stock/SltGoods.aspx?flag=1', 'ѡ���Ʒ');" />
                        </td>
                    </tr>
                </table>
            </div>
            </div>
       </div>
       <div id="info3" style="height:418px;overflow:hidden;">
            <div id="div2" class="divinfo" style="height:100%;padding:0px; overflow:auto;">
                <div id="div6" style="height:385px;overflow:auto;">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView3_RowDataBound" OnRowDeleting="GridView3_RowDeleting">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ItemID" />
                        <asp:BoundField HeaderText="��"/>
                        <asp:BoundField HeaderText="��Ŀ���" DataField="ItemNO" />
                        <asp:BoundField HeaderText="����" DataField="_Name" />
                        <asp:TemplateField HeaderText="���">
                            <ItemTemplate>
                                <asp:TextBox ID="tbPrice" runat="server" Text='<%# Eval("Price") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="��ʱ">
                            <ItemTemplate>
                                <asp:TextBox ID="tbdPoint" runat="server" Text='<%# Eval("dPoint") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���">
                            <ItemTemplate>
                                <asp:TextBox ID="tbTecDeduct" runat="server" Text='<%# Eval("TecDeduct") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="����Ա">
                            <ItemTemplate>
                                <asp:TextBox ID="tbTec" runat="server" Text='<%# Eval("Tec") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                                <input id="btnsch" name="btnsch" type="button" value="" runat="server" class="sch_btn" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���㷽ʽ">
                            <ItemTemplate>
                                <asp:TextBox ID="tbChargeStyle" runat="server" Text='<%# Eval("ChargeStyle") %>' style="display:none;"></asp:TextBox>
                                <asp:DropDownList ID="ddlChargeStyle" runat="server">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="��ע">
                            <ItemTemplate>
                                <asp:TextBox ID="tbRemark" runat="server" Text='<%# Eval("Remark") %>' CssClass="tbstyle" Width="170"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ɾ��">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbDel" TabIndex="-1" runat="server" CausesValidation="False"  CommandName="Delete" Text="ɾ��" style="color:#0000ff;"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                    <asp:HiddenField ID="hfdellist2" runat="server" />
                    <asp:HiddenField ID="hfreclist2" runat="server" Value="-1" />
                     <span style="display:none;">
                     <asp:Button ID="btnId2" runat="server" Text="..." OnClick="btnId2_Click" />
                     <asp:Button ID="btnSure2" runat="server" Text="..." OnClick="btnSure2_Click" />
                     </span>
                </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>    
            </div>
            <div id="Div7" class="devtemadd">
                <table cellpadding="0" cellspacing="0" class="tb4">
                    <tr>
                     <td style="padding-left:15px;">
                        <asp:DropDownList ID="ddlSchFld2" runat="server" CssClass="pindl" Width="70">
                            <asp:ListItem Value="ItemNO">�����</asp:ListItem>
                            <asp:ListItem Value="_Name">������</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                        <td>
                           <asp:TextBox ID="tbConInfo2" runat="server" CssClass="pin" onkeydown="EnterTextBoxItem(event, this);" ToolTip="������ɺ�س����"></asp:TextBox>
                        </td>
                        <td>
                            <input id="btnSltItem" type="button" value="ѡ����Ŀ" class="bt1" onclick="parent.ShowDialog1(800, 520, 'Basic/SltSerItem.aspx?flag=1', 'ѡ����Ŀ');" />
                        </td>
                    </tr>
                </table>
            </div>
            </div>
       </div>
       <div id="info4" style="height:418px;overflow:hidden;">
            <div id="div3" class="divinfo" style="height:100%;padding:0px; overflow:auto;">
                <div id="divconf" style="height:385px;overflow:auto;">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID" />
                        <asp:BoundField HeaderText="��"/>
                        <asp:TemplateField HeaderText="����">
                            <ItemTemplate>
                                <asp:TextBox ID="tbName" runat="server" Text='<%# Eval("_Name") %>' Width="100"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="����">
                            <ItemTemplate>
                                <asp:TextBox ID="tbParameter" runat="server" Text='<%# Eval("Parameter") %>' Width="100"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���к�">
                            <ItemTemplate>
                                <asp:TextBox ID="tbSN" runat="server" Text='<%# Eval("SN") %>' Width="100"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="������">
                            <ItemTemplate>
                                <asp:TextBox ID="tbPeriod" runat="server" Text='<%# Eval("MaintenancePeriod") %>' Width="100"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="��ֹ����">
                            <ItemTemplate>
                                <asp:TextBox ID="tbMaintenanceEnd" runat="server" Text='<%# Eval("MaintenanceEnd") %>' Width="100"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="��������">
                            <ItemTemplate>
                                <asp:TextBox ID="tbBuyDate" runat="server" Text='<%# Eval("BuyDate") %>' Width="100" ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="��ע">
                            <ItemTemplate>
                                <asp:TextBox ID="tbRemark" runat="server" Text='<%# Eval("Remark") %>' Width="170"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ɾ��">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbDel" TabIndex="-1" runat="server" CausesValidation="False"  CommandName="Delete" Text="ɾ��" style="color:#0000ff;"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:HiddenField ID="hfID" runat="server" /><asp:HiddenField ID="hfRecIDsd" runat="server" />
                <asp:HiddenField ID="hfdellist" runat="server" />
                    <span style="display: none;">
                        <asp:Button ID="btnSure" runat="server" OnClick="btnSure_Click" Text="...." UseSubmitBehavior="false" />
                        <asp:Button ID="btnId" runat="server" OnClick="btnId_Click" Text="...." UseSubmitBehavior="false" />
                    </span>
                </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnId" EventName="Click"/>
                        <asp:AsyncPostBackTrigger ControlID="btnSure" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnAddEmpty" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>    
            </div>
            <div id="devtemadd" class="devtemadd">
                <table cellpadding="0" cellspacing="0" class="tb1">
                    <tr>
                        <td>��Ʒ���</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbCon" runat="server" CssClass="pin" Width="160" onkeydown="EnterTextBox(event, this);" ToolTip="�����Ʒ���"></asp:TextBox></td>
                        <td style="padding-left:5px;">
                            <input id="btnSltTemp" type="button" value="ѡ������" class="bt1" onclick="SltTemp();"/>
                        </td>
                        <td style="padding-left:10px;">
                            <asp:Button ID="btnAddEmpty" runat="server" Text="���" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnAddEmpty_Click"/>
                        </td>
                    </tr>
                </table>
            </div>
            </div>
       </div>
       
       <div id="info5" style="height:418px;overflow:hidden;">
            <div id="divinfo2" class="divinfo" style="height:100%;padding:0px; padding-left:10px;">
                <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                <table cellpadding="0" cellspacing="0" class="tb5">
                <tr>
                    <td class="sysred" align="center">�����ʩ<br />
                    /�����</td>
                    <td style="padding-left:0px;height:84px;" colspan="3">
                        <asp:TextBox ID="tbTakeSteps" runat="server" TextMode="multiLine" CssClass="pin" Height="70" Width="384"></asp:TextBox>
                        <asp:HiddenField ID="hfTakeSteps" runat="server" />
                        <asp:HiddenField ID="hfTSAttachs" runat="server" />
                        <asp:HiddenField ID="hfAttachs" runat="server" />
                        <asp:HiddenField ID="hfReasonAttachs" runat="server" />
                        <asp:HiddenField ID="hfProcID" runat="server" />
                    </td>
                    <td style="padding:0px; text-align:left; vertical-align:bottom; padding-bottom:5px;"><input id="btnTSAttch" title="�����ʩ/�������" type="button" onclick="TSAttachs();" class="battach"/><br />
                    <input id="Button1" type="button" onclick="SltTroubleSteps();" class="bview"/></td>
                </tr>
                <tr>
                    <td align="right">����ʱ�䣺</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbDoorDate" runat="server" CssClass="pin" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox></td>
                    <td>����ʱ����</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbDay" runat="server" CssClass="pin" Width="60"></asp:TextBox> ��
                        <asp:TextBox ID="tbHour" runat="server" CssClass="pin" Width="60"></asp:TextBox> Сʱ
                    </td>
                </tr>
                <tr>
                    <td align="right" class="sysred">���ʱ�䣺</td>
                    <td style="padding-left:0px;"><asp:TextBox ID="tbArrDate" runat="server" CssClass="pin" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox></td>
                    <td align="right">����ԭ��</td>
                    <td style="padding-left:0px;">
                        <div class="isinDiv">
                            <input type="text" id="tbReason" runat="server" class="pin" style="width:163px;position: absolute;"/>
                            <asp:DropDownList ID="ddlTroubleReason" runat="server" onchange="document.getElementById('tbReason').value=this.options[this.selectedIndex].text" style="width:180px;clip: rect(auto auto auto 162px); position: absolute;height:20px;">
                            </asp:DropDownList>
                        </div>
                    </td>
                    <td style="padding:0px;"><input id="btnRSAttach" title="����ԭ�򸽼�" type="button" onclick="ReasonAttachs();" class="battach"/></td>
                </tr>
                <tr>
                    <td align="right">ִ�й��̣�</td>
                    <td style="padding-left:0px;" colspan="4"><asp:TextBox ID="tbCourse" runat="server" CssClass="pin" Width="385"></asp:TextBox></td>
                </tr>
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </div>
       </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="right">
            <asp:Button ID="btnAdd" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
            <input id="btnCls" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog();"/>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
var tabnum=6;
var processtip=1;
function ChkID(id)
{
    ClrID(id);
}

function FaultAttach()
{
    var ids=$("hfAttachs").value;
    parent.ShowDialog1(480, 243, 'Services/SerAttachs.aspx?m=0&t=1&aids='+ids, '���ƹ��ϸ���');
}
function TSAttachs()
{
    var ids=$("hfTSAttachs").value;
    parent.ShowDialog1(480, 243, 'Services/SerAttachs.aspx?t=2&aids='+ids, '�����ʩ/�������');
}
function ReasonAttachs()
{
    var ids=$("hfReasonAttachs").value;
    parent.ShowDialog1(480, 243, 'Services/SerAttachs.aspx?t=3&aids='+ids, '����ԭ�򸽼�');
}
function ChkIDs(id,unitid)
{
    ClrID4(id);
    $("hfUnitID").value=unitid;
}
function ChkAdd()
{
    if(isNull($("tbTel").value))
    {
        window.alert("����ʧ�ܣ������˵绰����Ϊ��");
        ChkTab('1');
        $("tbTel").focus();
        return false
    }
    if($("ddlBrand").value=="-1")
    {
        window.alert("����ʧ�ܣ�����Ʒ�Ʋ���Ϊ��");
        ChkTab('1');
        $("tbBrand").focus();
        return false
    }
    if(isNull($("tbSN1").value))
    {
        window.alert("����ʧ�ܣ����к�1����Ϊ��");
        ChkTab('1');
        $("tbSN1").focus();
        return false
    }
    if($("ddlRepStatus").value=="-1")
    {
        window.alert("����ʧ�ܣ������������Ϊ��");
        ChkTab('1');
        $("ddlRepStatus").focus();
        return false
    }
    if(!isNull($("tbRepCost").value))
    {
        if(!isMoney($("tbRepCost").value))
        {
            window.alert("���޳ɱ���ʽ����ȷ");
            ChkTab('1');
            $("tbRepCost").focus();
            return false
        }   
    }
    if(!isNull($("tbCostExtra").value))
    {
        if(!isMoney($("tbCostExtra").value))
        {
            window.alert("����ɱ���ʽ����ȷ");
            ChkTab('1');
            $("tbCostExtra").focus();
            return false
        }   
    }
    if(!isNull($("tbCost3").value))
    {
        if(!isMoney($("tbCost3").value))
        {
            window.alert("���ӷѸ�ʽ����ȷ");
            ChkTab('1');
            $("tbCost3").focus();
            return false
        }
    }
}

function EnterTextBoxGds(event, obj)
{
    if(event.keyCode == 13&&!isNull(obj.value))
    {
        if(!isNull(obj.value))
        {
            $("btnSure1").click();
        }
    }
}
function EnterTextBoxItem(event, obj)
{
    if(event.keyCode == 13&&!isNull(obj.value))
    {
        if(!isNull(obj.value))
        {
            $("btnSure2").click();
        }
    }
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

function EditSN(goodsid,unitid,SN,nums)
{
   var gdsnum=$(nums).value;
   if(gdsnum<=0)
   {
        alert("����ʧ�ܣ��������Ʒ����");
        return false;
   }
  
   parent.ShowDialog1(400, 300, 'Stock/EditSN.aspx?iflag=2&goodsid='+goodsid+'&unitid='+unitid+'&snvalue='+escape($(SN).value)+'&snid='+SN+'&gdsnum='+escape(gdsnum), '�༭���к�');
}

function SltAcc()
{
    parent.ShowDialog1(400, 510, 'Basic/SltAcc.aspx?f=1', '�������');
}

function SltTemp()
{
    parent.ShowDialog1(800, 520, 'Basic/SltDevConfItem.aspx?f=1', 'ѡ������');
}
function SltTec(strid)
{
    parent.ShowDialog1(400, 510, 'Services/SltTec.aspx?f=1&x=1&strid='+strid, '����Ա');
}

function SltTroubleSteps()
{
    parent.ShowDialog1(500, 510, 'Services/SltoubleStepsList.aspx', '�����ʩ');
}
</script>
