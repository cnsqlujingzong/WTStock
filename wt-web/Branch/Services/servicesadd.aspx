<%@ page language="C#"  CodeFile="servicesadd.aspx.cs"     autoeventwireup="true" inherits="Branch_Services_ServicesAdd" theme="Themes" enableeventvalidation="false" %>
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
                <td width="310"><a href="#" onclick="parent.ShowDialog(870,555, '../Branch/Services/ServicesAddBat.aspx?tel=<%=Str_Tel %>&cusid=<%=Str_CusID %>', '批量受理');">切换到批量模式</a></td>
                <td class="tser">服务受理</td>
                <td>服务单号：</td>
                <td style="padding-left:0px;">
                <asp:TextBox ID="tbBillID" runat="server" CssClass="pinbst" ReadOnly="true" Width="150"></asp:TextBox>
                </td>
                
                <td align="right" style="padding-left:0px;">
                制单时间：</td>
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
                <td align="right">服务类别：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="pindl2">
                    </asp:DropDownList>
                </td>
                <td align="right" style="width:87px; padding:0px;">受理方式：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlTake" runat="server" CssClass="pindl2">
                    </asp:DropDownList>
                </td>
                <td align="right" class="sysred" style="width:79px; padding:0px;">
                受理人：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl2">
                    </asp:DropDownList>
                </td>
                 <td align="right" style="width:87px; padding:0px;">受理时间：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbTakeTime" runat="server" CssClass="pin2" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox></td>
                
            </tr>
       </table>
       </div>
       </div>
       <div class="fdivs">
    <div class="sdivs" style="padding:3px 0 3px 0px;width:852px;">
    
       <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td align="right" class="sysred">客户名称：</td>
                <td colspan="3" style="padding-left:0px;">
                   <div class="isinDiv" style="width: 321px; float:left;">
                    <asp:TextBox ID="tbCusName" runat="server" CssClass="pin2 autot2" Width="333" onmousedown="getSearchResult('../Customer/SchCusList.aspx','tbCusName','hfCusID','1','btnValiCus',event);" onkeyup="getSearchResult('../Customer/SchCusList.aspx','tbCusName','hfCusID','1','btnValiCus',event);" AutoCompleteType="Disabled"></asp:TextBox>
                    </div>
                </td>
                <td style="padding:0px;"><input id="btnSlt" type="button" value="" onclick="SltCus();" class="bview"/></td>
                <td align="right">
                报修人：</td>
                <td style="padding-left:0px;width:126px;">
                <div class="isinDiv">
                    <asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin2 pinin"></asp:TextBox>
                    <asp:DropDownList ID="ddlLinkMan" runat="server" onchange="document.getElementById('tbLinkMan').value=this.options[this.selectedIndex].text" CssClass="pininsl2" AutoPostBack="True" OnSelectedIndexChanged="ddlLinkMan_SelectedIndexChanged">
                        <asp:ListItem></asp:ListItem>
                      </asp:DropDownList>
                </div>
                </td>
                <td align="right" class="red">报修人电话：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin2"></asp:TextBox></td>
            </tr>
            
            <tr>
                <td align="right" style="padding-left:0px;">
                使用人：</td>
                <td style="padding-left:0px;width:126px;">
                <div class="isinDiv">
                    <asp:TextBox ID="tbUsePerson" runat="server" CssClass="pin2 pinin"></asp:TextBox>
                    <asp:DropDownList ID="ddlUsePerson" runat="server" onchange="document.getElementById('tbUsePerson').value=this.options[this.selectedIndex].text" CssClass="pininsl2" AutoPostBack="True" OnSelectedIndexChanged="ddlUsePerson_SelectedIndexChanged">
                        <asp:ListItem></asp:ListItem>
                    </asp:DropDownList>
                </div>
                </td>
                <td align="right">
                使用人电话：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbUsePersonTel" runat="server" CssClass="pin2"></asp:TextBox></td>
                <td align="right" style="padding-left:0px;" colspan="2">
                所属部门：</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                      <asp:TextBox ID="tbDept" runat="server" CssClass="pin2 pinin2" onmousedown="GetCusDept();" onkeyup="GetCusDept();" AutoCompleteType="disabled"></asp:TextBox>
                      <asp:DropDownList ID="ddlDept" runat="server" onchange="document.getElementById('tbDept').value=this.options[this.selectedIndex].text" CssClass="pininsl2" AutoPostBack="True" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged">
                      </asp:DropDownList>
                    </div>
                </td>
                <td align="right">所属区域：</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbArea" runat="server" CssClass="pin2 pinin2"></asp:TextBox>
                        <asp:DropDownList ID="ddlArea" runat="server" CssClass="pininsl2" onchange="document.getElementById('tbArea').value=this.options[this.selectedIndex].text;NewAreas('3');">
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>
            
            <tr>
                <td>联系地址：</td>
                <td colspan="3" style="padding-left:0px;">
                    <asp:TextBox ID="tbAdr" runat="server" CssClass="pin2" Width="333"></asp:TextBox>
                </td>
                <td colspan="2">客户级别：</td>
                <td style="padding-left:0px;"><asp:TextBox runat="server" ID="tbCusLevel" CssClass="pin2" Enabled="false"></asp:TextBox></td>
                <td colspan="3">
                <a href="#" onclick="ViewCus();">>>详细信息</a>
                <a href="#" onclick="SltDev();">>>机器档案</a>
                <a href="#" onclick="ViewHistory();">>>相关业务</a>
                </td>
                
            </tr>
        </table>
        </div>
        </div>
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChkDev" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChkSN" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChkNO" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnValiCus" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnRef" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
        <div class="divh"></div>
         <div id="mytabs">
            <span id="tabs_l1"></span>
            <span id="tabs1" onclick="ChkTab('1');">机器信息</span>
            <span id="tabs_r1"></span>
            <span id="tabs_l2"></span>
            <span id="tabs2" onclick="ChkTab('2');">机器配置</span>
            <span id="tabs_r2"></span>
            <span id="tabs_l3"></span>
            <span id="tabs3" onclick="ChkTab('3');">物流信息</span>
            <span id="tabs_r3"></span>
         </div>
         <div id="info1" style="padding:3px 0px 0px 3px; overflow:hidden;" >
         <div id="divinfo1" class="divinfo" style="height:100%;">
         <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td align="right" style="padding-left:12px;" class="red">机器编号：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbDeviceNO" runat="server" CssClass="pin2" onkeydown="EnterTextBoxNO(event, this);" onblur="ChkNO();"></asp:TextBox></td>
                <td align="right" class="red">机器品牌：</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbBrand" runat="server" CssClass="pin2 pinin2" AutoCompleteType="Disabled" onblur="ChkPBrand();" onmousedown="getSearchResult1('../Customer/SchBrand.aspx','tbBrand','hfBrand','1','',event);" onkeyup="getSearchResult1('../Customer/SchBrand.aspx','tbBrand','hfBrand','1','',event);"></asp:TextBox>
                        <asp:DropDownList ID="ddlBrand" runat="server" CssClass="pininsl2" onchange="document.getElementById('tbBrand').value=this.options[this.selectedIndex].text;NewProductBrands('1');" AutoPostBack="True" OnSelectedIndexChanged="ddlBrand_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </td>
                <td align="right" colspan="2">机器类别：</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbClass" runat="server" CssClass="pin2 pinin2" AutoCompleteType="Disabled" onblur="ChkPClass();" onmousedown="getSearchResult1('../Customer/SchClass.aspx','tbClass','hfClass','1','',event);" onkeyup="getSearchResult1('../Customer/SchClass.aspx','tbClass','hfClass','1','',event);">
                        </asp:TextBox>
                        <asp:DropDownList ID="ddlClass" runat="server" onchange="document.getElementById('tbClass').value=this.options[this.selectedIndex].text;NewProductClasss('1');" CssClass="pininsl2" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </td>
                <td align="right">机器型号：</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbModel" runat="server" CssClass="pin2 pinin2" AutoCompleteType="Disabled" onblur="ChkPModel();" onmousedown="getSchModel();" onkeyup="getSchModel();"></asp:TextBox>
                        <asp:DropDownList ID="ddlModel" runat="server" CssClass="pininsl2" onchange="document.getElementById('tbModel').value=this.options[this.selectedIndex].text;NewProductModels('1');" AutoPostBack="True" OnSelectedIndexChanged="ddlModel_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </td>
                <td style="padding:0px;"><input id="Button1" type="button" onclick="SltModel();" class="bview"/></td>
            </tr>
            <tr>
                <td align="right" style="padding-left:12px;" class="red">序列号1：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSN1" runat="server" CssClass="pin2" onkeydown="EnterTextBoxSN(event, this);" onblur="ChkSN();"></asp:TextBox>
                </td>
                <td align="right">序列号2：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSN2" runat="server" CssClass="pin2"></asp:TextBox>
                </td>
                <td class="red" align="right" colspan="2">保修情况：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlRepStatus" runat="server" CssClass="pindl2" onchange="NewRepStatus('1');">
                        <asp:ListItem Value=""></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td align="right">机器外观：</td>
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
                <td align="right" style="padding-left:12px;" rowspan="2" class="red">报称故障：</td>
                <td colspan="3" rowspan="2" style="padding-left:0px;">
                    <asp:TextBox ID="tbFault" runat="server" CssClass="pin2" Width="321" Height="42" TextMode="MultiLine"></asp:TextBox>
                    <asp:HiddenField ID="hfFault" runat="server" /></td>
                <td style="padding:0px;" rowspan="2"><input id="btnFaultAttch" title="报称故障附件" type="button" onclick="FaultAttach();" class="battach"/><br />
                <input id="btnSltFault" type="button" onclick="SltFault();" class="bview"/></td>
                <td align="right">随机附件：</td>
                <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbAcc" runat="server" CssClass="pin2" Width="321"></asp:TextBox></td>
                <td style="padding:0px;"><input id="btnSltAcc" type="button" onclick="SltAcc();" class="bview"/></td>                
            </tr>
            <tr>
                <td align="right">服务级别：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlPRI" runat="server" CssClass="pindl2">
                    </asp:DropDownList>
                </td>
                <td align="right">经销商：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBuyFrom" runat="server" CssClass="pin2"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" style="padding-left:12px;">购买时间：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBuyTime" runat="server" CssClass="Wdate2" onfocus="WdatePicker()"></asp:TextBox>
                </td>
                <td align="right">购买发票：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBuyInvoice" runat="server" CssClass="pin2"></asp:TextBox></td>
                 <td align="right" colspan="2">工分：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbPoint" runat="server" CssClass="pin2"></asp:TextBox>
                </td>
                <td align="right">是否再修：</td>
                <td style="padding-left:0px;"><asp:CheckBox ID="cbRe" runat="server" Text="" />
                &nbsp;<asp:Label ID="lbRepCount" runat="server" Text=""></asp:Label>
                    <asp:HiddenField ID="hfCusID" runat="server" />
                    <asp:HiddenField ID="hfDevID" runat="server" />
                    <asp:HiddenField ID="hfArea" runat="server" />
                    <asp:HiddenField ID="hfBrand" runat="server" />
                    <asp:HiddenField ID="hfClass" runat="server" />
                    <asp:HiddenField ID="hfWarranty" runat="server" />
                    <asp:HiddenField ID="hfModelID" runat="server" />
                    <asp:HiddenField ID="hfSN" runat="server" />
                    <asp:HiddenField ID="hfNO" runat="server" />
                    <asp:HiddenField ID="hfPrintID" runat="server" />
                    <asp:HiddenField ID="hfDept" runat="server" />
                    <asp:HiddenField ID="hfAddCus" runat="server" Value="-1" />
                    <span style="display:none;">
                        <asp:Button ID="btnChkDev" runat="server" Text="ChkDev" OnClick="btnChkDev_Click" />
                        <asp:Button ID="btnChkSN" runat="server" Text="ChkSN" OnClick="btnChkSN_Click" />
                        <asp:Button ID="btnChkNO" runat="server" Text="ChkNO" OnClick="btnChkNO_Click" />
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
        <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
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
                <asp:BoundField HeaderText="序"/>
                <asp:TemplateField HeaderText="名称">
                    <ItemTemplate>
                        <asp:TextBox ID="tbName" runat="server" Text='<%# Eval("_Name") %>' Width="100"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="参数">
                    <ItemTemplate>
                        <asp:TextBox ID="tbParameter" runat="server" Text='<%# Eval("Parameter") %>' Width="100"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="序列号">
                    <ItemTemplate>
                        <asp:TextBox ID="tbSN" runat="server" Text='<%# Eval("SN") %>' Width="100"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="保修期">
                    <ItemTemplate>
                        <asp:TextBox ID="tbPeriod" runat="server" Text='<%# Eval("MaintenancePeriod") %>' Width="100"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="截止日期">
                    <ItemTemplate>
                        <asp:TextBox ID="tbMaintenanceEnd" runat="server" Text='<%# Eval("MaintenanceEnd") %>' Width="100"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="购买日期">
                    <ItemTemplate>
                        <asp:TextBox ID="tbBuyDate" runat="server" Text='<%# Eval("BuyDate") %>' Width="100" ></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="备注">
                    <ItemTemplate>
                        <asp:TextBox ID="tbRemark" runat="server" Text='<%# Eval("Remark") %>' Width="170"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="删除">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbDel" TabIndex="-1" runat="server" CausesValidation="False"  CommandName="Delete" Text="删除" style="color:#0000ff;"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ConfID">
                    <ItemTemplate>
                        <asp:TextBox ID="tbConfID" runat="server" Text='<%# Eval("DevConfID") %>' Width="170"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:HiddenField ID="hfID" runat="server" /><asp:HiddenField ID="hfRecID" runat="server" />
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
                <asp:AsyncPostBackTrigger ControlID="btnChkNO" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnChkDev" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <div id="devtemadd">
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td>产品类别：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbCon" runat="server" CssClass="pin" Width="160" onkeydown="EnterTextBox(event, this);" ToolTip="输入产品类别"></asp:TextBox></td>
                <td style="padding-left:5px;">
                    <input id="btnSltTemp" type="button" value="选择配置" class="bt1" onclick="SltTemp();"/>
                </td>
                <td style="padding-left:10px;">
                    <asp:Button ID="btnAddEmpty" runat="server" Text="添加" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnAddEmpty_Click"/>
                </td>
            </tr>
        </table>
    </div>
    </div>
   <div id="info3" style="padding:3px 0px 0px 3px; overflow:hidden;height:156px;" >
         <div id="divinfo2" class="divinfo" style="height:100%;">
         <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            <table cellpadding="0" cellspacing="0" class="tb1">
                <tr>
                    <td align="right" style="padding-left:12px;">货运方式：</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlSndStyle" runat="server" CssClass="pindl2">
                        </asp:DropDownList>
                    </td>
                    <td align="right">物流单号：</td>
                    <td style="padding-left:0px;">
                        <asp:TextBox ID="tbPostNO" runat="server" CssClass="pin2"></asp:TextBox>
                    </td>
                    <td align="right">物流费用：</td>
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
           <td>存档单号：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbSaveID" runat="server" CssClass="pin2"></asp:TextBox></td>
            <td>预约时间：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbSubTime" runat="server" CssClass="pin2" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
            </td>
            
             <td >预约取机：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbSubContTime" runat="server" CssClass="Wdate2" onfocus="WdatePicker()"></asp:TextBox>
            </td>
            <td >技术员：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDisposal" runat="server" CssClass="pin2"></asp:TextBox>
            </td>
            <td style="padding:0px;"><input id="btnSltStaff" type="button" value="" onclick="SltTec();" class="bview"/></td>
        </tr>    
        <tr>
            <td>厂商单号：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbCorpID" runat="server" CssClass="pin2"></asp:TextBox></td>
            <td>结算厂商：</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlChargeCorp" runat="server" CssClass="pindl2">
                </asp:DropDownList>
            </td>
            <td>销售合同号：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbContNO" runat="server" CssClass="pin2"></asp:TextBox>
                </td>
            <td>预报价格：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbSubPrice" runat="server" CssClass="pin2"></asp:TextBox></td>
            
          </tr>    
        <tr>
            <td >预收费：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbSubCharge" runat="server" CssClass="pin2"></asp:TextBox></td>
            <td >备注：</td>
            <td colspan="2" style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin2" Width="200"></asp:TextBox></td>
            <td>
                <a href="#" onclick="ChkUpload();">上传附件</a>
            </td>
            <td>预计完成时间:</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbCmpTime" runat="server" CssClass="Wdate2" onfocus="WdatePicker()"></asp:TextBox></td>
            <td style="padding-left:0px;">
                <div id="dUpload"></div>
                <asp:HiddenField ID="hfPath" runat="server" />
                <asp:HiddenField ID="hfAttachs" runat="server" />
            </td>
        </tr>
    </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChkSN" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChkNO" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnChkDev" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="right">
                <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnAdd_Click" />
                <asp:Button ID="btnClean" runat="server" Text="清空" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkClean()==false)return false;" OnClick="btnClean_Click" />
                <input id="btnPrint" runat="server" type="button" value="打印" class="bt1" onclick="ChkPrint('PZD');" />
                <input id="btnClose" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog();" />
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
var strtel="";
var uri=location.href;
if(uri.indexOf("itel=1")>0)
    strtel="&itel=1";
function FaultAttach()
{
    var ids=$("hfAttachs").value;
    parent.ShowDialog1(480, 243, '../Branch/Services/SerAttachs.aspx?t=1&aids='+ids+strtel, '报称故障附件');
}
function ChkSave()
{
    if(isNull($("tbTakeTime").value))
    {
        window.alert("操作失败！受理时间不能为空");
        $("tbTakeTime").focus();
        return false
    }
    if(isNull($("tbCusName").value))
    {
        window.alert("操作失败！客户名称不能为空");
        $("tbCusName").focus();
        return false
    }
    if(isNull($("tbTel").value))
    {
        window.alert("操作失败！报修人电话不能为空");
        $("tbTel").focus();
        return false
    }
    
    if($("ddlOperator").value=="-1")
    {
        window.alert("操作失败！经办人不能为空");
        $("ddlOperator").focus();
        return false
    }
    if(isNull($("tbDate").value))
    {
        window.alert("操作失败！制单时间不能为空");
        $("tbDate").focus();
        return false
    }
    if($("ddlBrand").value=="-1")
    {
        window.alert("操作失败！机器品牌不能为空");
        $("tbBrand").focus();
        return false
    }
    if(isNull($("tbFault").value))
    {
        window.alert("操作失败！报称故障不能为空");
        $("tbFault").focus();
        return false
    }
    
    if($("ddlRepStatus").value=="-1")
    {
        window.alert("操作失败！保修情况不能为空");
        $("ddlRepStatus").focus();
        return false
    }
    if(!isNull($("tbPoint").value))
    {
        if(!isMoney($("tbPoint").value))
        {
            window.alert("工分格式不正确");
            $("tbPoint").focus();
            return false
        }   
    }
    if(!isNull($("tbSubCharge").value))
    {
        if(!isMoney($("tbSubCharge").value))
        {
            window.alert("预收费格式不正确");
            $("tbSubCharge").focus();
            return false
        }   
    }
    if(!isNull($("tbPostage").value))
    {
        if(!isMoney($("tbPostage").value))
        {
            window.alert("物流费用格式不正确");
            ChkTab('3');
            $("tbPostage").focus();
            return false
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

function EnterTextBoxSN(event, obj)
{
    if(event.keyCode == 13&&!isNull(obj.value))
    {
        if(!isNull(obj.value))
        {
            ChkSN();
        }
    }
}

function EnterTextBoxNO(event, obj)
{
    if(event.keyCode == 13&&!isNull(obj.value))
    {
        if(!isNull(obj.value))
        {
            ChkNO();
        }
    }
}
function SltModel()
{
    parent.ShowDialog1(400, 510, '../Branch/Services/SltModel.aspx?f=1&sBrand='+escape($("tbBrand").value)+'&sClass='+escape($("tbClass").value)+strtel, '选择型号');
}
function SltCus()
{
    parent.ShowDialog1(800, 500, '../Branch/Services/SltCus.aspx?f=1&strname='+escape($("tbCusName").value)+strtel, '选择客户');
}
function ChkNO()
{
    var strno=$("tbDeviceNO").value;
    if($("hfNO").value!=strno)
    {
        $("hfNO").value=$("tbDeviceNO").value;
        if(!isNull(strno))
            $("btnChkNO").click();
    }
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
    if(confirm("该序列号存在多条机器信息，是否选择？"))
    {
        SltDev();
    }
}
function ConfCusInfo()
{
    if(confirm("该客户名称存在多条客户信息，是否选择？"))
    {
        SltCus();
    }
}
function SltDev()
{
    var cusid=$("hfCusID").value;
    if(cusid=="")
    {
        parent.ShowDialog1(800, 500, '../Branch/Customer/SltDev.aspx?f=1&psn='+escape($("tbSN1").value)+'&strname='+escape($("tbCusName").value)+strtel, '选择机器档案');
    }
    else
    {
        parent.ShowDialog1(800, 500, '../Branch/Customer/SltDev.aspx?f=1&psn='+escape($("tbSN1").value)+'&strname='+escape($("tbCusName").value)+'&cusid='+cusid+strtel, '选择机器档案');
    }
}
function SltAsp()
{
    parent.ShowDialog1(400, 510, '../Branch/Basic/SltAsp.aspx?f=1'+strtel, '机器外观');
}
function SltAcc()
{
    parent.ShowDialog1(400, 510, '../Branch/Basic/SltAcc.aspx?f=1'+strtel, '随机附件');
}
function SltFault()
{
    parent.ShowDialog1(600, 510, '../Branch/Basic/SltFault.aspx?f=1'+strtel, '常见故障');
}
function SltTec()
{
    parent.ShowDialog1(400, 510, '../Branch/Services/SltTec.aspx?f=1'+strtel, '技术员');
}
function SltTemp()
{
    parent.ShowDialog1(800, 520, '../Branch/Basic/SltDevConfItem.aspx?f=1'+strtel, '选择配置');
}
function ViewCus()
{
    var cusid=$("hfCusID").value;
    if(cusid=="")
    {
        //新建客户
        parent.ShowDialog1(600, 450, '../Branch/Customer/CusAdd.aspx?f=1'+strtel, '新建客户');
    }
    else
    {
        //修改客户
        parent.ShowDialog1(600, 450, '../Branch/Customer/CusMod.aspx?f=1&id='+cusid+strtel, '客户信息');
    }
}

function ViewHistory()
{
    var cusid=$("hfCusID").value;
    if(cusid=="")
    {
        alert("请选择客户后查看！");
        return false;
    }
    parent.ShowDialog1(800, 520, '../Branch/Customer/CusHistory.aspx?f=1&cusid='+cusid+strtel, '相关业务');
}
function ChkUpload()
{   
    if($("dUpload").innerHTML=="")
    {
        parent.ShowDialog1(600, 380, '../Branch/Services/UpLoad.aspx?p=1'+strtel, '上传附件');
    }
    else
    {
        if(confirm("已经存在一个附件，继续上传将替换该附件，是否继续？"))
        {
            parent.ShowDialog1(600, 380, '../Branch/Services/UpLoad.aspx?p=1'+strtel, '上传附件');
        }
    }
}
function getSchModel()
{
    var brand=document.getElementById("tbBrand").value;
    var classes=document.getElementById("tbClass").value;
    getSearchResult1('../Customer/SchModel.aspx','tbModel','hfModelID','1',''+brand+'^'+classes+'',event)
}
</script>
<script type="text/javascript">
     function GetCusDept() {
        var cusname = document.getElementById("tbCusName").value;
        if (cusname=="") {
            alert("请先选择客户!");
            return false;
        }
        var cusid = document.getElementById("hfCusID").value;
        getSearchResult1('../Customer/SchDepartment.aspx','tbDept','hfDept','1|'+cusid,'',event);
     }
</script>
