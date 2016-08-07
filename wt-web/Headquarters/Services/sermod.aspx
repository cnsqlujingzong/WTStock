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
                <td class="tser">服务单</td>
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
                <td class="auto-style3">省份：</td>
                   <td style="padding:0px;">
                          <div class="isinDiv" >
                       <asp:DropDownList ID="cmbProvince" runat="server" Height="22px" Width="120px" AutoPostBack="True" OnSelectedIndexChanged="cmbProvince_SelectedIndexChanged">
                           <asp:ListItem value="">-请选择-</asp:ListItem> 
                    <asp:ListItem value="北京市">北京市</asp:ListItem>
                    <asp:ListItem value="上海市">上海市</asp:ListItem>
                    <asp:ListItem value="天津市">天津市</asp:ListItem>
                    <asp:ListItem value="重庆市">重庆市</asp:ListItem>
                    <asp:ListItem value="河北省">河北省</asp:ListItem> 
                    <asp:ListItem value="山西省">山西省</asp:ListItem> 
                    <asp:ListItem value="内蒙古自治区">内蒙古</asp:ListItem> 
                    <asp:ListItem value="辽宁省">辽宁省</asp:ListItem> 
                    <asp:ListItem value="吉林省">吉林省</asp:ListItem> 
                    <asp:ListItem value="黑龙江省">黑龙江省</asp:ListItem> 
                    <asp:ListItem value="江苏省">江苏省</asp:ListItem> 
                    <asp:ListItem value="浙江省">浙江省</asp:ListItem> 
                    <asp:ListItem value="安徽省">安徽省</asp:ListItem> 
                    <asp:ListItem value="福建省">福建省</asp:ListItem> 
                    <asp:ListItem value="江西省">江西省</asp:ListItem> 
                    <asp:ListItem value="山东省">山东省</asp:ListItem> 
                    <asp:ListItem value="河南省">河南省</asp:ListItem> 
                    <asp:ListItem value="湖北省">湖北省</asp:ListItem> 
                    <asp:ListItem value="湖南省">湖南省</asp:ListItem> 
                    <asp:ListItem value="广东省">广东省</asp:ListItem> 
                    <asp:ListItem value="广西壮族自治区">广西省</asp:ListItem> 
                    <asp:ListItem value="海南省">海南省</asp:ListItem> 
                    <asp:ListItem value="四川省">四川省</asp:ListItem> 
                    <asp:ListItem value="贵州省">贵州省</asp:ListItem> 
                    <asp:ListItem value="云南省">云南省</asp:ListItem> 
                    <asp:ListItem value="西藏自治区">西藏</asp:ListItem> 
                    <asp:ListItem value="陕西省">陕西省</asp:ListItem> 
                    <asp:ListItem value="甘肃省">甘肃省</asp:ListItem> 
                    <asp:ListItem value="宁夏回族自治区">宁夏</asp:ListItem> 
                    <asp:ListItem value="青海省">青海省</asp:ListItem> 
                    <asp:ListItem value="新疆维吾尔族自治区">新疆</asp:ListItem> 
                    <asp:ListItem value="香港特别行政区">香港</asp:ListItem> 
                    <asp:ListItem value="澳门特别行政区">澳门</asp:ListItem> 
                    <asp:ListItem value="台湾省">台湾省</asp:ListItem> 
                    <asp:ListItem value="其它">其它</asp:ListItem> 
                       </asp:DropDownList></div>
                </td>
                   <td>城市：</td>
                   <td style="padding:0px;">
                       <asp:DropDownList ID="cmbCity" runat="server" Height="22px" Width="120px">
                              <asp:ListItem value="">请选择-</asp:ListItem>
                       </asp:DropDownList>
                </td>
                   <td></td>
                   <td class="auto-style4"><select id="cmbArea" style="display:none"></select></td>
                   <td></td>
                   <td></td>
                   <td></td>
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
               <tr>
            <td align="right"  style="padding:0px" class="auto-style3">选择网点:</td>
                 <!---选择网点 by coding-->
            <td style="padding-left:0px;">  
                <div class="isinDiv">
                 <asp:TextBox ID="tbwangdian" onchange="taxChange()"  runat="server" CssClass="pin autot" onmousedown="getSearchResult('../Customer/c_getbrandch.aspx','tbwangdian','hfwangdianID','1','btnwangdian',event);" onkeyup="getSearchResult('../Customer/c_getbrandch.aspx','btnwangdian','hfwangdianID','1','btnwangdian',event);" AutoCompleteType="Disabled"></asp:TextBox>
                </div>

            </td>
           <td align="right"  style="padding:0px">网点税率:</td>
              <td style="padding-left:0px;"> <div class="isinDiv">      
                  <asp:DropDownList ID="ddl_branchFax" runat="server" Width="150" AutoPostBack="True" OnSelectedIndexChanged="ddl_branchFax_SelectedIndexChanged">
                      <asp:ListItem Value="no-0" Selected="True">不含税</asp:ListItem>
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
                <td style="padding-left:0px;"><asp:TextBox ID="tbDeviceNO" runat="server" CssClass="pin2"></asp:TextBox></td>
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
                        <asp:TextBox ID="tbModel" runat="server" CssClass="pin2 pinin2" AutoCompleteType="Disabled" onblur="ChkPModel();" onmousedown="getSearchResult1('../Customer/SchModel.aspx','tbModel','hfModelID','1','',event);" onkeyup="getSearchResult1('../Customer/SchModel.aspx','tbModel','hfModelID','1','',event);"></asp:TextBox>
                        <asp:DropDownList ID="ddlModel" runat="server" CssClass="pininsl2" onchange="document.getElementById('tbModel').value=this.options[this.selectedIndex].text;NewProductModels('1');" AutoPostBack="True" OnSelectedIndexChanged="ddlModel_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </td>
                 <td style="padding:0px;"><input id="Button1" type="button" onclick="SltModel();" class="bview"/></td>
            </tr>
            <tr>
                <td align="right" style="padding-left:12px;" class="red">序列号1：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSN1" runat="server" CssClass="pin2"></asp:TextBox>
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
                <td align="right">是否返修：</td>
                <td style="padding-left:0px;"><asp:CheckBox ID="cbRe" runat="server" Text="" />
                是否再修：<asp:CheckBox ID="cbAgain" runat="server" Text="" />
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
            
             <td>预约取机：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbSubContTime" runat="server" CssClass="Wdate2" onfocus="WdatePicker()"></asp:TextBox>
            </td>
            <td>技术员：</td>
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
            <td>预收费：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbSubCharge" runat="server" CssClass="pinb2" ReadOnly="true"></asp:TextBox></td>
            <td>备注：</td>
            <td colspan="2" style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin2" Width="200"></asp:TextBox></td>
            <td>
                <a href="#" onclick="ChkUpload();">上传附件</a>
            </td>
            <td>预计完成时间:</td>
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
                <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;"  OnClick="btnAdd_Click"/>
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
    if (isNull($("tbwangdian").value)) {
        window.alert("操作失败！网点不能为空");
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
    parent.ShowDialog1(800, 500, 'Services/SltCus.aspx?f=1&strname='+escape($("tbCusName").value), '选择客户');
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
function FaultAttach()
{
    var ids=$("hfAttachs").value;
    parent.ShowDialog1(480, 243, 'Services/SerAttachs.aspx?t=1&aids='+ids, '报称故障附件');
}
function SltDev()
{
    var cusid=$("hfCusID").value;
    if(cusid=="")
    {
        parent.ShowDialog1(800, 500, '../Headquarters/Customer/SltDev.aspx?f=1&psn='+escape($("tbSN1").value)+'&strname='+escape($("tbCusName").value), '选择机器档案');
    }
    else
    {
        parent.ShowDialog1(800, 500, '../Headquarters/Customer/SltDev.aspx?f=1&psn='+escape($("tbSN1").value)+'&strname='+escape($("tbCusName").value)+'&cusid='+cusid, '选择机器档案');
    }
}
function SltModel()
{
    parent.ShowDialog1(400, 510, '../Headquarters/Services/SltModel.aspx?f=1&sBrand='+escape($("tbBrand").value)+'&sClass='+escape($("tbClass").value), '选择型号');
}
function SltAsp()
{
    parent.ShowDialog1(400, 510, 'Basic/SltAsp.aspx?f=1', '机器外观');
}
function SltAcc()
{
    parent.ShowDialog1(400, 510, 'Basic/SltAcc.aspx?f=1', '随机附件');
}
function SltFault()
{
    parent.ShowDialog1(600, 510, 'Basic/SltFault.aspx?f=1', '常见故障');
}
function SltTec()
{
    parent.ShowDialog1(400, 510, 'Services/SltTec.aspx?f=1', '技术员');
}
function SltTemp()
{
    parent.ShowDialog1(800, 520, 'Basic/SltDevConfItem.aspx?f=1', '选择配置');
}

function ViewCus()
{
    var cusid=$("hfCusID").value;
    if(cusid=="")
    {
        //新建客户
        parent.ShowDialog1(600, 450, '../Headquarters/Customer/CusAdd.aspx?f=1', '新建客户');
    }
    else
    {
        //修改客户
        parent.ShowDialog1(600, 450, '../Headquarters/Customer/CusMod.aspx?f=1&id=' + cusid, '客户信息');
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
    parent.ShowDialog1(800, 520, '../Headquarters/Customer/CusHistory.aspx?f=1&cusid='+cusid, '相关业务');
}
function ChkUpload()
{   
    if($("dUpload").innerHTML=="")
    {
        parent.ShowDialog1(600, 380, '../Headquarters/Services/UpLoad.aspx', '上传附件');
    }
    else
    {
        if(confirm("已经存在一个附件，继续上传将替换该附件，是否继续？"))
        {
            parent.ShowDialog1(600, 380, '../Headquarters/Services/UpLoad.aspx', '上传附件');
        }
    }
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
