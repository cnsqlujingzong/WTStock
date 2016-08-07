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
        <span id="tabs1" onclick="ChkTab('1');">基本信息</span>
        <span id="tabs_r1"></span>
        <span id="tabs_l2"></span>
        <span id="tabs2" onclick="ChkTab('2');">机器配置</span>
        <span id="tabs_r2"></span>
        <span id="tabs_l3"></span>
        <span id="tabs3" onclick="ChkTab('3');">项目/备件/耗材/计数器</span>
        <span id="tabs_r3"></span>
        <span id="tabs_l4"></span>
        <span id="tabs4" onclick="ChkTab('4');">收费结算</span>
        <span id="tabs_r4"></span>
        <span id="tabs_l10"></span>
        <span id="tabs10" onclick="ChkTab('10');">提成明细</span>
        <span id="tabs_r10"></span>
        <span id="tabs_l5"></span>
        <span id="tabs5" onclick="ChkTab('5');">回访信息</span>
        <span id="tabs_r5"></span>
        <span id="tabs_l6"></span>
        <span id="tabs6" onclick="ChkTab('6');">处理过程</span>
        <span id="tabs_r6"></span>
        <span id="tabs_l7"></span>
        <span id="tabs7" onclick="ChkTab('7');">服务报价</span>
        <span id="tabs_r7"></span>
        <span id="tabs_l8"></span>
        <span id="tabs8" onclick="ChkTab('8');">催单</span>
        <span id="tabs_r8"></span>
        <span id="tabs_l9"></span>
        <span id="tabs9" onclick="ChkTab('9');">操作日志</span>
        <span id="tabs_r9"></span>
        <span id="tabs_l11"></span>
        <span id="tabs11" onclick="ChkTab('11');">附件</span>
        <span id="tabs_r11"></span>
     </div>
    <div id="info1" style="padding:3px 0px 0px 3px; overflow:hidden;" >
        <div id="divinfo1" class="divinfo" style="height:100%;">
            <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td>服务单号:</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBillID" runat="server" CssClass="pinb" ReadOnly="true" Width="120"></asp:TextBox></td>
                <td>服务类别：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="pindl" Width="126">
                    </asp:DropDownList>
                </td>
                <td >受理方式：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlTake" runat="server" CssClass="pindl" Width="126">
                    </asp:DropDownList>
                </td>
                 <td >受理时间：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbTakeTime" runat="server" CssClass="pin" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" Width="120"></asp:TextBox></td>
            </tr>
            <tr>
                <td  class="sysred">客户名称:</td>
                <td colspan="3" style="padding-left:0px;">
                    <asp:TextBox ID="tbCusName" runat="server" CssClass="pin" Width="321" AutoCompleteType="Disabled"></asp:TextBox>
                </td>
                <td>
                报修人：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin" Width="120"></asp:TextBox></td>
                <td >报修人电话：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin" Width="120"></asp:TextBox></td>
            </tr>
            <tr>
                <td >
                使用人：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbUsePerson" runat="server" CssClass="pin" Width="120"></asp:TextBox></td>
                <td >
                所属部门：</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <input type="text" id="tbDept" runat="server" class="pin pinin" Width="106"/>
                        <select id="slDept" onchange="document.getElementById('tbDept').value=this.options[this.selectedIndex].value" class="pininsl" style="width:126px;clip: rect(auto auto auto 107px);">
                            <option value="" selected="selected"></option>
                            <option value="销售部">销售部</option>
                            <option value="市场部">市场部</option>
                            <option value="人事部">人事部</option>
                        </select>
                    </div>
                </td>
                <td>
                使用人电话：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbUsePersonTel" runat="server" CssClass="pin" Width="120"></asp:TextBox></td>
                <td >所属区域：</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbArea" runat="server" CssClass="pin pinin" Width="106"></asp:TextBox>
                        <asp:DropDownList ID="ddlArea" runat="server" CssClass="pininsl" onchange="document.getElementById('tbArea').value=this.options[this.selectedIndex].text;" Width="126" style="clip: rect(auto auto auto 107px);">
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>
            <tr>
                <td>联系地址:</td>
                <td colspan="3" style="padding-left:0px;">
                    <asp:TextBox ID="tbAdr" runat="server" CssClass="pin" Width="320"></asp:TextBox>
                </td>
                <td class="sysred" >
                受理人：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl" Width="126">
                    </asp:DropDownList>
                </td>
                <td class="sysred">
                制单时间：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbDate" CssClass="pin" runat="server" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" Width="120"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td >机器编号:</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbDeviceNO" runat="server" CssClass="pin" Width="120"></asp:TextBox></td>
                <td  class="red">机器品牌：</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbBrand" runat="server" CssClass="pin pinin" Width="106"></asp:TextBox>
                        <asp:DropDownList ID="ddlBrand" runat="server" CssClass="pininsl" Width="126" style="clip: rect(auto auto auto 107px);">
                        </asp:DropDownList>
                    </div>
                </td>
                <td >机器类别：</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbClass" runat="server" CssClass="pin pinin" Width="106">
                        </asp:TextBox>
                        <asp:DropDownList ID="ddlClass" runat="server" CssClass="pininsl" Width="126" style="clip: rect(auto auto auto 107px);">
                        </asp:DropDownList>
                    </div>
                </td>
                <td >机器型号：</td>
                <td style="padding-left:0px;">
                    <div class="isinDiv">
                        <asp:TextBox ID="tbModel" runat="server" CssClass="pin pinin" Width="106"></asp:TextBox>
                        <asp:DropDownList ID="ddlModel" runat="server" CssClass="pininsl" Width="126" style="clip: rect(auto auto auto 107px);">
                        </asp:DropDownList>
                    </div>
                </td>
                
            </tr>
            <tr>
                <td  class="red">序列号1：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSN1" runat="server" CssClass="pin" Width="120"></asp:TextBox>
                </td>
                <td >序列号2：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSN2" runat="server" CssClass="pin" Width="120"></asp:TextBox>
                </td>
                <td >机器外观：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbAspect" runat="server" Width="120"></asp:TextBox>
                </td>
                <td >随机附件：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbAcc" runat="server" CssClass="pin" Width="120"></asp:TextBox></td>
            </tr>
            <tr>
                <td  rowspan="2">报称故障:</td>
                <td colspan="3" rowspan="2" style="padding-left:0px;">
                    <asp:TextBox ID="tbFault" runat="server" CssClass="pin" Width="321" Height="42" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="red">保修情况：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlRepStatus" runat="server" CssClass="pindl" Width="126">
                    </asp:DropDownList>
                </td>
                <td >服务级别：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlPRI" runat="server" CssClass="pindl" Width="126">
                    </asp:DropDownList>
                </td>
                
            </tr>
            <tr>
                <td >经销商：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBuyFrom" runat="server" CssClass="pin" Width="120"></asp:TextBox></td>
                <td >购买时间：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBuyTime" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="120"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>购买发票:</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbBuyInvoice" runat="server" CssClass="pin" Width="120"></asp:TextBox></td>
                 <td >工分：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbPoint" runat="server" CssClass="pin" Width="120"></asp:TextBox>
                </td>
                <td >物流单号：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbPostNO" runat="server" CssClass="pin" Width="120"></asp:TextBox>
                </td>
                <td >物流费用：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbPostage" runat="server" CssClass="pin" Width="120"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>存档单号:</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSaveID" runat="server" CssClass="pin" Width="120"></asp:TextBox></td>
                <td>厂商单号：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbCorpID" runat="server" CssClass="pin" Width="120"></asp:TextBox></td>
                <td >结算厂商：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlChargeCorp" runat="server" CssClass="pindl" Width="126">
                    </asp:DropDownList>
                </td>
                <td >技术员：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbDisposal" runat="server" CssClass="pin" Width="120"></asp:TextBox>
                </td>
                
            </tr>    
            <tr>
                <td>预约时间:</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSubTime" runat="server" CssClass="pin" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})" Width="120"></asp:TextBox>
                </td>
                <td>预约取机：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSubContTime" runat="server" CssClass="Wdate" Width="120" onfocus="WdatePicker()"></asp:TextBox>
                </td>
                <td >预报价格：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSubPrice" runat="server" CssClass="pin" Width="120"></asp:TextBox></td>
                <td >预收费：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbSubCharge" runat="server" CssClass="pin" Width="120"></asp:TextBox></td>
            </tr>
            <tr>
                <td>备注：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="120"></asp:TextBox></td>
                <td colspan="2" align="center"><label for="cbRe">返修:</label><asp:CheckBox ID="cbRe" runat="server" Text="" />
                 <label for="cbAgain">再修：</label> <asp:CheckBox ID="cbAgain" runat="server" Text="" /></td>
                <td>销售合同号:</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbContNO" runat="server" CssClass="pin2"></asp:TextBox>
                </td>
                <td>预计完成时间:</td>
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
                <asp:BoundField HeaderText="序"/>
                <asp:BoundField HeaderText="名称" DataField="_Name" />
                <asp:BoundField HeaderText="参数" DataField="Parameter" />
                <asp:BoundField HeaderText="序列号" DataField="SN" />
                <asp:BoundField HeaderText="保修期" DataField="MaintenancePeriod" />
                <asp:BoundField HeaderText="截止日期" DataField="MaintenanceEnd" />
                <asp:BoundField HeaderText="购买日期" DataField="BuyDate" />
                <asp:BoundField HeaderText="备注" DataField="Remark" />
            </Columns>
         </asp:GridView>
      </div>
    </div>
    <div id="info3" style="padding:3px 0px 0px 3px; overflow:hidden; height:366px;" >
        <div id="div1" class="divinfo" style="height:100%; padding-left:15px;">
        <span style=" color:#0046d5">备件/耗材</span> 
        <div class="fdivs" style="width:806px; height:100px;">
        <div class="sdivs" style="width:804px; height:98px;">
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView2_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="序"/>
                    <asp:BoundField HeaderText="产品编号" DataField="GoodsNO" />
                    <asp:BoundField HeaderText="名称" DataField="_Name" />
                    <asp:BoundField HeaderText="规格" DataField="Spec" />
                    <asp:BoundField HeaderText="品牌" DataField="ProductBrand" />
                    <asp:BoundField HeaderText="单位" DataField="Unit" />
                    <asp:BoundField HeaderText="数量" DataField="Qty" />
                    <asp:BoundField HeaderText="单价" DataField="Price" />
                    <asp:BoundField HeaderText="税率" DataField="TaxRate" />
                    <asp:BoundField HeaderText="税额" DataField="TaxAmount" />
                    <asp:BoundField HeaderText="金额" DataField="Total" />
                    <asp:BoundField HeaderText="序列号" DataField="SN" />
                    <asp:BoundField HeaderText="保修期" DataField="MaintenancePeriod" />
                    <asp:BoundField HeaderText="截止日期" DataField="PeriodEndDate" />
                    <asp:BoundField HeaderText="结算方式" DataField="ChargeStyle" />
                    <asp:BoundField HeaderText="是否外购" DataField="OutSourcing" />
                    <asp:BoundField HeaderText="外购单价" DataField="OutCostPrice" />
                    <asp:BoundField HeaderText="备注" DataField="Remark" />
                </Columns>
             </asp:GridView>
         </div>
         </div>
         <div class="divh" style="height:12px;"></div>
          <div style=" color:#0046d5;">项目</div>
          <div class="fdivs" style="width:806px; height:100px;">
            <div class="sdivs" style="width:804px; height:98px;">
              <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView3_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="序"/>
                    <asp:BoundField HeaderText="项目编号" DataField="ItemNO" />
                    <asp:BoundField HeaderText="名称" DataField="_Name" />
                    <asp:BoundField HeaderText="金额" DataField="Price" />
                    <asp:BoundField HeaderText="工时" DataField="dPoint" />
                    <asp:BoundField HeaderText="提成" DataField="TecDeduct" />
                    <asp:BoundField HeaderText="技术员" DataField="Tec" />
                    <asp:BoundField HeaderText="结算方式" DataField="ChargeStyle" />
                    <asp:BoundField HeaderText="是否完工" DataField="bComplete" />
                    <asp:BoundField HeaderText="备注" DataField="Remark" />
                </Columns>
             </asp:GridView>
            </div>
           </div>
           <div class="divh" style="height:12px;"></div>
          <div style=" color:#0046d5;">计数器</div>
          <div class="fdivs" style="width:806px; height:80px;">
            <div class="sdivs" style="width:804px; height:78px;">
              <asp:GridView ID="GridView8" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="序"/>
                    <asp:BoundField HeaderText="计数日期" DataField="_Date" />
                    <asp:BoundField HeaderText="计数人" DataField="Operator" />
                    <asp:BoundField HeaderText="类型" DataField="QtyType" />
                    <asp:BoundField HeaderText="计数" DataField="Qty" />
                    <asp:BoundField HeaderText="余量" DataField="Allowance" />
                    <asp:BoundField HeaderText="备注"  DataField="Remark"/>
                </Columns>
             </asp:GridView>
            </div>
           </div>
        </div>
    </div>
    
    <div id="info4" style="padding:3px 0px 0px 3px; overflow:hidden; height:366px;" >
        <div runat="server" id="div2" class="divinfo" style="height:100%;padding:0px; padding-left:10px;">
            <fieldset style=" border: 1px #808080 solid; padding:5px 0; width:810px;">
                <legend>费用和成本</legend>
                    <table cellpadding="0" cellspacing="0" class="tb1">
                            <tr>
                                <td>材料费用：</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbFee_Materail" runat="server" CssClass="pin" Width="110"></asp:TextBox></td>
                                <td>附加费用：</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbFee_Add" runat="server" CssClass="pin" Width="110"></asp:TextBox></td>
                                <td>维修费用：</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbFee_Labor" runat="server" CssClass="pin" Width="110"></asp:TextBox></td>
                                <td align="right">合计：</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbFee_Total" runat="server" CssClass="pin" ReadOnly="true" Width="110"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>材料成本：</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbCost_Materail" runat="server" CssClass="pin" Width="110"></asp:TextBox></td>
                                <td>送修成本：</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbRepCost" runat="server" CssClass="pin" Width="110"></asp:TextBox>
                                </td>
                                <td>额外成本：</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbCost_Add" runat="server" CssClass="pin" Width="110"></asp:TextBox></td>
                                <td>业务毛利：</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbProfit" runat="server" CssClass="pin" Width="110"></asp:TextBox></td> 
                            </tr>
                    </table>   
                </fieldset>
                <div class="divh"></div>
                <fieldset style=" border: 1px #808080 solid; padding:5px 0; width:810px;">
                <legend>对<asp:Label ID="lbbln" runat="server" Text="客户"></asp:Label>结算</legend>
                    <table cellpadding="0" cellspacing="0" class="tb1">
                            <tr>
                                <td align="right" style="padding-left:26px;">收款人：</td>
                                <td style="padding-left:0px;">
                                    <asp:DropDownList ID="ddlRcvMan" runat="server" CssClass="pindl" Width="116">
                                    </asp:DropDownList>
                                </td>
                                <td>结算日期：</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbRcvDate" runat="server" CssClass="pin" Width="110"></asp:TextBox></td>
                                <td>应结金额：</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbChargeValue" runat="server" CssClass="pin" Width="110"></asp:TextBox></td>
                                <td>优惠金额：</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbPreMoney" runat="server" CssClass="pin" Width="110"></asp:TextBox></td>
                            </tr> 
                            <tr>
                                <td>实际收款：</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbRealMoney" runat="server" CssClass="pin" Width="110"></asp:TextBox></td>
                                <td>现结金额：</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbInCash" runat="server" CssClass="pin" Width="110"></asp:TextBox></td>
                            </tr>
                    </table>
                </fieldset>
                <div class="divh"></div>
                <fieldset style=" border: 1px #808080 solid; padding:5px 0; width:810px;">
                <legend>对厂家结算</legend>
                    <table cellpadding="0" cellspacing="0" class="tb1">
                            <tr>
                                <td>厂商名称：</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbFacName" runat="server" CssClass="pin" Width="110"></asp:TextBox></td>
                                <td>结算金额：</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbFacAmount" runat="server" CssClass="pin" Width="110"></asp:TextBox></td>
                            </tr>
                    </table>  
                </fieldset>
                <div class="divh"></div>
                <fieldset style=" border: 1px #808080 solid; padding:5px 0; width:810px;">
                <legend>维修保修</legend>
                    <table cellpadding="0" cellspacing="0" class="tb1">
                            <tr>
                                <td>保修截止：</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbEndDate" runat="server" CssClass="pin" Width="110"></asp:TextBox></td>
                                <td>保修范围：</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbEndPlace" runat="server" CssClass="pin" Width="110"></asp:TextBox></td>
                                <td>物品去向：</td>
                                <td style="padding-left:0px;"><asp:TextBox ID="tbGone" runat="server" CssClass="pin" Width="110"></asp:TextBox></td>
                                <td>交接日期：</td>
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
                回访日期：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbVisitDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="122"></asp:TextBox></td>
                <td align="right">
                回访人：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlVisitOperator" runat="server" CssClass="pindl" Width="126">
                    </asp:DropDownList>
                </td>
                <td align="right">回访形式：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlVisitStyle" runat="server" CssClass="pindl" Width="126">
                    </asp:DropDownList>
                </td>
                <td align="right">
                被回访人：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbVisitOperator" runat="server" CssClass="pin" Width="126"></asp:TextBox></td>
            </tr>
            <tr>
                <td>客户意见：</td>
                <td style="padding-left:0px; height:40px;" colspan="3"><asp:TextBox ID="tbCusOpinon" runat="server" CssClass="pin" Width="309" TextMode="MultiLine" Height="30"></asp:TextBox></td>
                <td>回访备注：</td>
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
                    <asp:BoundField HeaderText="序"/>
                    <asp:BoundField HeaderText="处理方式" DataField="DoStyle" />
                    <asp:BoundField HeaderText="操作人" DataField="Person" />
                    <asp:BoundField HeaderText="处理网点" DataField="Dept" />
                    <asp:BoundField HeaderText="处理人" DataField="Operator" />
                    <asp:BoundField HeaderText="处理时间" DataField="_Date" />
                    <asp:BoundField HeaderText="处理措施/结果" DataField="TakeSteps" />
                    <asp:BoundField HeaderText="到达时间" DataField="StartTime" />
                    <asp:BoundField HeaderText="处理时长" DataField="Spending" />
                    <asp:BoundField HeaderText="完成时间" DataField="ArrivedTime" />
                    <asp:BoundField HeaderText="故障原因" DataField="Reason" />
                    <asp:BoundField HeaderText="下步处理部门" DataField="DoDept" />
                    <asp:BoundField HeaderText="下步处理人" DataField="DoOperator" />
                    <asp:BoundField HeaderText="上门时间" DataField="visitdate" />
                    <asp:BoundField HeaderText="处理过程" DataField="Course" />
                 </Columns>
            </asp:GridView>
        </div>
    </div>
    <div id="info7" style="overflow:hidden; height:369px;" >
      <div id="div8" class="divinfo" style="height:100%;padding:0px; overflow:auto;">
            <asp:GridView ID="GridView7" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="序"/>
                    <asp:BoundField HeaderText="日期" DataField="_Date" />
                    <asp:BoundField HeaderText="操作人" DataField="Operator" />
                    <asp:BoundField HeaderText="报价人" DataField="Seller" />
                    <asp:BoundField HeaderText="报价项目" DataField="_Name" />
                    <asp:BoundField HeaderText="金额" DataField="dAmount" />
                    <asp:BoundField HeaderText="客户确认" DataField="CusConf" />
                    <asp:BoundField HeaderText="备注" DataField="Remark" />
                 </Columns>
             </asp:GridView>
        </div>
    </div>
    <div id="info8" style="overflow:hidden; height:369px;" >
      <div id="div9" class="divinfo" style="height:100%;padding:0px; overflow:auto;">
            <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="序"/>
                    <asp:BoundField HeaderText="催单人" DataField="LinkMan" />
                    <asp:BoundField HeaderText="联系电话" DataField="Tel" />
                    <asp:BoundField HeaderText="催单时间" DataField="_Date" />
                    <asp:BoundField HeaderText="受理人" DataField="Operator" />
                    <asp:BoundField HeaderText="处理结果" DataField="Result" />
                 </Columns>
             </asp:GridView>
        </div>
    </div>
    <div id="info9" style="overflow:hidden; height:369px;" >
      <div id="div4" class="divinfo" style="height:100%;padding:0px; overflow:auto;">
            <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView1_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="序"/>
                    <asp:BoundField HeaderText="时间" DataField="_Date"/>
                    <asp:BoundField HeaderText="操作员" DataField="Operator"/>
                    <asp:BoundField HeaderText="事件" DataField="Event" />
                </Columns>
             </asp:GridView>
        </div>
    </div>
    <div id="info10" style="overflow:hidden; height:369px;" >
      <div id="div10" class="divinfo" style="height:100%;padding:0px; overflow:auto;">
            <asp:GridView ID="GridView9" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView1_RowDataBound" EnableViewState="false">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="序"/>
                    <asp:BoundField HeaderText="工号" DataField="JobNO" />
                    <asp:BoundField HeaderText="姓名" DataField="_Name" />
                    <asp:BoundField HeaderText="日期" DataField="Time_Finish" />
                    <asp:BoundField HeaderText="金额" DataField="Deduct" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <div id="info11" style="overflow:hidden; height:369px;" >
      <div id="div11" class="divinfo" style="height:100%;padding:0px; overflow:auto;">
            <asp:GridView ID="GridView10" runat="server" AutoGenerateColumns="false" SkinID="gv4" OnRowDataBound="GridView10_RowDataBound" EnableViewState="false">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="ID" />
                    <asp:BoundField HeaderText="序"/>
                    <asp:BoundField HeaderText="附件类型" DataField="iType" />
                    <asp:TemplateField>
                    <HeaderTemplate>
                    附件名称
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
                <input id="btnPrint" runat="server" type="button" value="打印" class="bt1" onclick="ChkPrint('XD');" />
                <input id="btnClose" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog<%=str_flag %>();" />
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
