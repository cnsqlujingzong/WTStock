<%@ page language="C#"  CodeFile="sermod.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Services_SerMod" theme="Themes" enableeventvalidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/tab.css" />
    <script src="../../Public/jsAddress.js" type="text/javascript"></script>
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
                <td width="310"></td>
                <td class="tser">����</td>
                <td>���񵥺ţ�</td>
                <td style="padding-left:0px;">
                <asp:TextBox ID="tbBillID" runat="server" CssClass="pinbst" ReadOnly="true" Width="150"></asp:TextBox>
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
                </td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                      <asp:TextBox ID="tbDept" runat="server" CssClass="pin2 pinin2" onmousedown="GetCusDept();" onkeyup="GetCusDept();" AutoCompleteType="disabled" Visible="False"></asp:TextBox>
                      <asp:DropDownList ID="ddlDept" runat="server" onchange="document.getElementById('tbDept').value=this.options[this.selectedIndex].text" CssClass="pininsl2" AutoPostBack="True" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged" Visible="False">
                      </asp:DropDownList>
                    </div>
                </td>
                <td align="right"></td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbArea" runat="server" CssClass="pin2 pinin2" Visible="False" ></asp:TextBox>
                        <asp:DropDownList ID="ddlArea" runat="server" CssClass="pininsl2" onchange="document.getElementById('tbArea').value=this.options[this.selectedIndex].text;NewAreas('3');" Visible="False">
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>
                    <tr>
                <td class="auto-style3">ʡ�ݣ�</td>
                   <td style="padding:0px;">
                          <div class="isinDiv" >
                       <asp:DropDownList ID="cmbProvince" runat="server" Height="22px" Width="120px" AutoPostBack="True" OnSelectedIndexChanged="cmbProvince_SelectedIndexChanged">
                           <asp:ListItem value="">-��ѡ��-</asp:ListItem> 
                    <asp:ListItem value="������">������</asp:ListItem>
                    <asp:ListItem value="�Ϻ���">�Ϻ���</asp:ListItem>
                    <asp:ListItem value="�����">�����</asp:ListItem>
                    <asp:ListItem value="������">������</asp:ListItem>
                    <asp:ListItem value="�ӱ�ʡ">�ӱ�ʡ</asp:ListItem> 
                    <asp:ListItem value="ɽ��ʡ">ɽ��ʡ</asp:ListItem> 
                    <asp:ListItem value="���ɹ�������">���ɹ�</asp:ListItem> 
                    <asp:ListItem value="����ʡ">����ʡ</asp:ListItem> 
                    <asp:ListItem value="����ʡ">����ʡ</asp:ListItem> 
                    <asp:ListItem value="������ʡ">������ʡ</asp:ListItem> 
                    <asp:ListItem value="����ʡ">����ʡ</asp:ListItem> 
                    <asp:ListItem value="�㽭ʡ">�㽭ʡ</asp:ListItem> 
                    <asp:ListItem value="����ʡ">����ʡ</asp:ListItem> 
                    <asp:ListItem value="����ʡ">����ʡ</asp:ListItem> 
                    <asp:ListItem value="����ʡ">����ʡ</asp:ListItem> 
                    <asp:ListItem value="ɽ��ʡ">ɽ��ʡ</asp:ListItem> 
                    <asp:ListItem value="����ʡ">����ʡ</asp:ListItem> 
                    <asp:ListItem value="����ʡ">����ʡ</asp:ListItem> 
                    <asp:ListItem value="����ʡ">����ʡ</asp:ListItem> 
                    <asp:ListItem value="�㶫ʡ">�㶫ʡ</asp:ListItem> 
                    <asp:ListItem value="����׳��������">����ʡ</asp:ListItem> 
                    <asp:ListItem value="����ʡ">����ʡ</asp:ListItem> 
                    <asp:ListItem value="�Ĵ�ʡ">�Ĵ�ʡ</asp:ListItem> 
                    <asp:ListItem value="����ʡ">����ʡ</asp:ListItem> 
                    <asp:ListItem value="����ʡ">����ʡ</asp:ListItem> 
                    <asp:ListItem value="����������">����</asp:ListItem> 
                    <asp:ListItem value="����ʡ">����ʡ</asp:ListItem> 
                    <asp:ListItem value="����ʡ">����ʡ</asp:ListItem> 
                    <asp:ListItem value="���Ļ���������">����</asp:ListItem> 
                    <asp:ListItem value="�ຣʡ">�ຣʡ</asp:ListItem> 
                    <asp:ListItem value="�½�ά�����������">�½�</asp:ListItem> 
                    <asp:ListItem value="����ر�������">���</asp:ListItem> 
                    <asp:ListItem value="�����ر�������">����</asp:ListItem> 
                    <asp:ListItem value="̨��ʡ">̨��ʡ</asp:ListItem> 
                    <asp:ListItem value="����">����</asp:ListItem> 
                       </asp:DropDownList></div>
                </td>
                   <td>���У�</td>
                   <td style="padding:0px;">
                       <asp:DropDownList ID="cmbCity" runat="server" Height="22px" Width="120px">
                              <asp:ListItem value="">��ѡ��-</asp:ListItem>
                       </asp:DropDownList>
                </td>
                   <td></td>
                   <td class="auto-style4"><select id="cmbArea" style="display:none"></select></td>
                   <td></td>
                   <td></td>
                   <td></td>
            </tr>
            <tr>
                <td>��ϵ��ַ��</td>
                <td colspan="3" style="padding-left:0px;">
                    <asp:TextBox ID="tbAdr" runat="server" CssClass="pin2" Width="333"></asp:TextBox>
                </td>
                <td colspan="2">�ͻ�����</td>
                <td style="padding-left:0px;"><asp:TextBox runat="server" ID="tbCusLevel" CssClass="pin2" Enabled="false"></asp:TextBox></td>
                <td colspan="3">
                <a href="#" onclick="ViewCus();">>>��ϸ��Ϣ</a>
                <a href="#" onclick="SltDev();">>>��������</a>
                <a href="#" onclick="ViewHistory();">>>���ҵ��</a>
                </td>
                
            </tr>
               <tr>
            <td align="right"  style="padding:0px" class="auto-style3">ѡ������:</td>
                 <!---ѡ������ by coding-->
            <td style="padding-left:0px;">  
                <div class="isinDiv">
                 <asp:TextBox ID="tbwangdian" onchange="taxChange()"  runat="server" CssClass="pin autot" onmousedown="getSearchResult('../Customer/c_getbrandch.aspx','tbwangdian','hfwangdianID','1','btnwangdian',event);" onkeyup="getSearchResult('../Customer/c_getbrandch.aspx','btnwangdian','hfwangdianID','1','btnwangdian',event);" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

            </td>
           <td align="right"  style="padding:0px">����˰��:</td>
              <td style="padding-left:0px;"> <div class="isinDiv">      
                  <asp:DropDownList ID="ddl_branchFax" runat="server" Width="150" AutoPostBack="True" OnSelectedIndexChanged="ddl_branchFax_SelectedIndexChanged">
                      <asp:ListItem Value="no-0" Selected="True">����˰</asp:ListItem>
                  </asp:DropDownList></div></td>
               <td style="padding:0px"></td>
               <td style="padding:0px" class="auto-style4"></td>
               <td style="padding:0px">       <asp:HiddenField ID="hfwangdianID" runat="server" /></td>
               <td style="padding:0px"><div style="display:none"><asp:Button ID="btnwangdian" runat="server" Text="..." OnClick="btnWangdian_Click"/></div></td>
               <td style="padding:0px"></td>
           </tr>
        </table>
        </div>
        </div>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChkDev" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChkSN" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnValiCus" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnRef" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    <div class="divh"></div>
     <div id="mytabs">
        <span id="tabs_l1"></span>
        <span id="tabs1" onclick="ChkTab('1');">������Ϣ</span>
        <span id="tabs_r1"></span>
        <span id="tabs_l2"></span>
        <span id="tabs2" onclick="ChkTab('2');">��������</span>
        <span id="tabs_r2"></span>
        <span id="tabs_l3"></span>
        <span id="tabs3" onclick="ChkTab('3');">������Ϣ</span>
        <span id="tabs_r3"></span>
     </div>
    <div id="info1" style="padding:3px 0px 0px 3px; overflow:hidden;" >
         <div id="divinfo1" class="divinfo" style="height:100%;">
         <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td align="right" style="padding-left:12px;" class="red">������ţ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbDeviceNO" runat="server" CssClass="pin2"></asp:TextBox></td>
                <td align="right" class="red">����Ʒ�ƣ�</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbBrand" runat="server" CssClass="pin2 pinin2" AutoCompleteType="Disabled" onblur="ChkPBrand();" onmousedown="getSearchResult1('../Customer/SchBrand.aspx','tbBrand','hfBrand','1','',event);" onkeyup="getSearchResult1('../Customer/SchBrand.aspx','tbBrand','hfBrand','1','',event);"></asp:TextBox>
                        <asp:DropDownList ID="ddlBrand" runat="server" CssClass="pininsl2" onchange="document.getElementById('tbBrand').value=this.options[this.selectedIndex].text;NewProductBrands('1');" AutoPostBack="True" OnSelectedIndexChanged="ddlBrand_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </td>
                <td align="right" colspan="2">�������</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbClass" runat="server" CssClass="pin2 pinin2" AutoCompleteType="Disabled" onblur="ChkPClass();" onmousedown="getSearchResult1('../Customer/SchClass.aspx','tbClass','hfClass','1','',event);" onkeyup="getSearchResult1('../Customer/SchClass.aspx','tbClass','hfClass','1','',event);">
                        </asp:TextBox>
                        <asp:DropDownList ID="ddlClass" runat="server" onchange="document.getElementById('tbClass').value=this.options[this.selectedIndex].text;NewProductClasss('1');" CssClass="pininsl2" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </td>
                <td align="right">�����ͺţ�</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbModel" runat="server" CssClass="pin2 pinin2" AutoCompleteType="Disabled" onblur="ChkPModel();" onmousedown="getSearchResult1('../Customer/SchModel.aspx','tbModel','hfModelID','1','',event);" onkeyup="getSearchResult1('../Customer/SchModel.aspx','tbModel','hfModelID','1','',event);"></asp:TextBox>
                        <asp:DropDownList ID="ddlModel" runat="server" CssClass="pininsl2" onchange="document.getElementById('tbModel').value=this.options[this.selectedIndex].text;NewProductModels('1');" AutoPostBack="True" OnSelectedIndexChanged="ddlModel_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </td>
                 <td style="padding:0px;"><input id="Button1" type="button" onclick="SltModel();" class="bview"/></td>
            </tr>
            <tr>
                <td align="right" style="padding-left:12px;" class="red">���к�1��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSN1" runat="server" CssClass="pin2"></asp:TextBox>
                </td>
                <td align="right">���к�2��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSN2" runat="server" CssClass="pin2"></asp:TextBox>
                </td>
                <td class="red" align="right" colspan="2">���������</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlRepStatus" runat="server" CssClass="pindl2" onchange="NewRepStatus('1');">
                        <asp:ListItem Value=""></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">������ۣ�</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbAspect" runat="server" CssClass="pin2 pinin2"></asp:TextBox>
                         <asp:DropDownList ID="ddlAspect" runat="server" onchange="document.getElementById('tbAspect').value=this.options[this.selectedIndex].text;" CssClass="pininsl2">
                         </asp:DropDownList>
                    </div>
                </td>
                <td style="padding:0px;"><input id="btnSltAsp" type="button" onclick="SltAsp();" class="bview"/></td>
            </tr>
            <tr>
                <td align="right" style="padding-left:12px;" rowspan="2" class="red">���ƹ��ϣ�</td>
                <td colspan="3" rowspan="2" style="padding-left:0px;">
                    <asp:TextBox ID="tbFault" runat="server" CssClass="pin2" Width="321" Height="42" TextMode="MultiLine"></asp:TextBox>
                    <asp:HiddenField ID="hfFault" runat="server" /></td>
                <td style="padding:0px;" rowspan="2"><input id="btnFaultAttch" title="���ƹ��ϸ���" type="button" onclick="FaultAttach();" class="battach"/><br />
                <input id="btnSltFault" type="button" onclick="SltFault();" class="bview"/></td>
                <td align="right">���������</td>
                <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbAcc" runat="server" CssClass="pin2" Width="321"></asp:TextBox></td>
                <td style="padding:0px;"><input id="btnSltAcc" type="button" onclick="SltAcc();" class="bview"/></td>                
            </tr>
            <tr>
                <td align="right">���񼶱�</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlPRI" runat="server" CssClass="pindl2">
                    </asp:DropDownList>
                </td>
                <td align="right">�����̣�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBuyFrom" runat="server" CssClass="pin2"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" style="padding-left:12px;">����ʱ�䣺</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBuyTime" runat="server" CssClass="Wdate2" onfocus="WdatePicker()"></asp:TextBox>
                </td>
                <td align="right">����Ʊ��</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBuyInvoice" runat="server" CssClass="pin2"></asp:TextBox></td>
                 <td align="right" colspan="2">���֣�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbPoint" runat="server" CssClass="pin2"></asp:TextBox>
                </td>
                <td align="right">�Ƿ��ޣ�</td>
                <td style="padding-left:0px;"><asp:CheckBox ID="cbRe" runat="server" Text="" />
                �Ƿ����ޣ�<asp:CheckBox ID="cbAgain" runat="server" Text="" />
                    <asp:HiddenField ID="hfCusID" runat="server" />
                    <asp:HiddenField ID="hfDevID" runat="server" />
                    <asp:HiddenField ID="hfArea" runat="server" />
                    <asp:HiddenField ID="hfBrand" runat="server" />
                    <asp:HiddenField ID="hfClass" runat="server" />
                    <asp:HiddenField ID="hfWarranty" runat="server" />
                    <asp:HiddenField ID="hfModelID" runat="server" />
                    <asp:HiddenField ID="hfSN" runat="server" />
                    <asp:HiddenField ID="hfDept" runat="server" />
                    <span style="display:none;">
                        <asp:Button ID="btnChkDev" runat="server" Text="ChkDev" OnClick="btnChkDev_Click" />
                        <asp:Button ID="btnChkSN" runat="server" Text="ChkSN" OnClick="btnChkSN_Click" />
                        <asp:Button ID="btnRefModel" runat="server" Text="GetPModel" OnClick="btnRefModel_Click" />
                        <asp:Button ID="btnRef" runat="server" Text="Ref" OnClick="btnRef_Click" />
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
      </div>
    </div>
    <div id="info2" >
    <div id="divconf" style="height:129px;">
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
        <asp:HiddenField ID="hfID" runat="server" /><asp:HiddenField ID="hfRecID" runat="server" />
        <asp:HiddenField ID="hfdellist" runat="server" />
            <span style="display: none;">
                <asp:Button ID="btnValiCus" runat="server" OnClick="btnValiCus_Click" Text="..." UseSubmitBehavior="false" />
                <asp:Button ID="btnSure" runat="server" OnClick="btnSure_Click" Text="...." UseSubmitBehavior="false" />
                <asp:Button ID="btnId" runat="server" OnClick="btnId_Click" Text="...." UseSubmitBehavior="false" />
            </span>
        </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnId" EventName="Click"/>
                <asp:AsyncPostBackTrigger ControlID="btnSure" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnAddEmpty" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnChkSN" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnChkDev" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>    
    </div>
    <div id="devtemadd">
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
    <div id="info3" style="padding:3px 0px 0px 3px; overflow:hidden;height:156px;" >
         <div id="divinfo2" class="divinfo" style="height:100%;">
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
            
             <td>ԤԼȡ����</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbSubContTime" runat="server" CssClass="Wdate2" onfocus="WdatePicker()"></asp:TextBox>
            </td>
            <td>����Ա��</td>
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
            <td>Ԥ�շѣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbSubCharge" runat="server" CssClass="pinb2" ReadOnly="true"></asp:TextBox></td>
            <td>��ע��</td>
            <td colspan="2" style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin2" Width="200"></asp:TextBox></td>
            <td>
                <a href="#" onclick="ChkUpload();">�ϴ�����</a>
            </td>
            <td>Ԥ�����ʱ��:</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbCmpTime" runat="server" CssClass="Wdate2" onfocus="WdatePicker()"></asp:TextBox></td>
            <td style="padding-left:0px;">
                <div id="dUpload" runat="server"></div>
                <asp:HiddenField ID="hfPath" runat="server" />
                <asp:HiddenField ID="hfAttachs" runat="server" />
            </td>
        </tr>
    </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
            </td>
            <td align="right">
                <asp:Button ID="btnAdd" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;"  OnClick="btnAdd_Click"/>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/AutoSchCon1.js"></script>
<script language="javascript" type="text/javascript">
var tabnum=4;

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
    if($("ddlBrand").value=="-1")
    {
        window.alert("����ʧ�ܣ�����Ʒ�Ʋ���Ϊ��");
        $("tbBrand").focus();
        return false
    }
    if(isNull($("tbFault").value))
    {
        window.alert("����ʧ�ܣ����ƹ��ϲ���Ϊ��");
        $("tbFault").focus();
        return false
    }
    if($("ddlRepStatus").value=="-1")
    {
        window.alert("����ʧ�ܣ������������Ϊ��");
        $("ddlRepStatus").focus();
        return false
    }
    if(!isNull($("tbPoint").value))
    {
        if(!isMoney($("tbPoint").value))
        {
            window.alert("���ָ�ʽ����ȷ");
            $("tbPoint").focus();
            return false
        }   
    }
    if(!isNull($("tbSubCharge").value))
    {
        if(!isMoney($("tbSubCharge").value))
        {
            window.alert("Ԥ�շѸ�ʽ����ȷ");
            $("tbSubCharge").focus();
            return false
        }   
    }
    if (isNull($("tbwangdian").value)) {
        window.alert("����ʧ�ܣ����㲻��Ϊ��");
        $("tbwangdian").focus();
        return false
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
function SltCus()
{
    parent.ShowDialog1(800, 500, 'Services/SltCus.aspx?f=1&strname='+escape($("tbCusName").value), 'ѡ��ͻ�');
}
function ChkSN()
{
    if($("hfDevID").value=="")
    {
        var strsn=$("tbSN1").value;
        if($("hfSN").value!=strsn)
        {
            $("hfSN").value=$("tbSN1").value;
            if(!isNull(strsn))
                $("btnChkSN").click();
        }
    }
}
function ConfInfo()
{
    if(confirm("�����кŴ��ڶ���������Ϣ���Ƿ�ѡ��"))
    {
        SltDev();
    }
}
function ConfCusInfo()
{
    if(confirm("�ÿͻ����ƴ��ڶ����ͻ���Ϣ���Ƿ�ѡ��"))
    {
        SltCus();
    }
}
function FaultAttach()
{
    var ids=$("hfAttachs").value;
    parent.ShowDialog1(480, 243, 'Services/SerAttachs.aspx?t=1&aids='+ids, '���ƹ��ϸ���');
}
function SltDev()
{
    var cusid=$("hfCusID").value;
    if(cusid=="")
    {
        parent.ShowDialog1(800, 500, '../Headquarters/Customer/SltDev.aspx?f=1&psn='+escape($("tbSN1").value)+'&strname='+escape($("tbCusName").value), 'ѡ���������');
    }
    else
    {
        parent.ShowDialog1(800, 500, '../Headquarters/Customer/SltDev.aspx?f=1&psn='+escape($("tbSN1").value)+'&strname='+escape($("tbCusName").value)+'&cusid='+cusid, 'ѡ���������');
    }
}
function SltModel()
{
    parent.ShowDialog1(400, 510, '../Headquarters/Services/SltModel.aspx?f=1&sBrand='+escape($("tbBrand").value)+'&sClass='+escape($("tbClass").value), 'ѡ���ͺ�');
}
function SltAsp()
{
    parent.ShowDialog1(400, 510, 'Basic/SltAsp.aspx?f=1', '�������');
}
function SltAcc()
{
    parent.ShowDialog1(400, 510, 'Basic/SltAcc.aspx?f=1', '�������');
}
function SltFault()
{
    parent.ShowDialog1(600, 510, 'Basic/SltFault.aspx?f=1', '��������');
}
function SltTec()
{
    parent.ShowDialog1(400, 510, 'Services/SltTec.aspx?f=1', '����Ա');
}
function SltTemp()
{
    parent.ShowDialog1(800, 520, 'Basic/SltDevConfItem.aspx?f=1', 'ѡ������');
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
<script type="text/javascript">
     function GetCusDept() {
        var cusname = document.getElementById("tbCusName").value;
        if (cusname=="") {
            alert("����ѡ��ͻ�!");
            return false;
        }
        var cusid = document.getElementById("hfCusID").value;
        getSearchResult1('../Customer/SchDepartment.aspx','tbDept','hfDept','1|'+cusid,'',event);
     }
</script>
