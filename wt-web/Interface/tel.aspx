<%@ page language="C#"  CodeFile="tel.aspx.cs"     autoeventwireup="true" inherits="Interface_Tel" theme="Themes" enableEventValidation="false" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>来电受理接口</title>
    <link rel="Stylesheet" type="text/css" href="../Public/Style/tel.css" />
    <script language="javascript" type="text/javascript" src="../Public/Script/tel.js"></script>
</head>
<body style="overflow:hidden;">
    <form id="form1" runat="server">
    
    <div class="tl1">
    <div style="padding:5px 10px;">

    <div class="tl2">来电受理</div>
    <fieldset class="tl3">
    <legend>来电信息</legend>
    <table cellpadding="0" cellspacing="0" class="tb1">
    <tr><td>来电号码：</td>
        <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="in1 in2 pbb" Width="200"></asp:TextBox></td>
    </tr>
    </table>  
    <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
            <td>客户名称：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbCusName" runat="server" CssClass="in1 in2" Width="300"></asp:TextBox></td>
            <td align="right">客户类别：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbCusClass" runat="server"  CssClass="in1 in2"></asp:TextBox></td>
            </tr><tr>
            <td>联系电话：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbCusTel" runat="server"  CssClass="in1 in2" Width="300"></asp:TextBox></td>
            <td align="right">联系人：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbLinkName" runat="server"  CssClass="in1 in2"></asp:TextBox></td>
            </tr><tr>
            <td align="right">地址：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server"  CssClass="in1 in2" Width="300"></asp:TextBox></td>
            <td align="right">传真：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbFax" runat="server"  CssClass="in1 in2"></asp:TextBox>
                <asp:HiddenField ID="hfv" runat="server" />
                <asp:HiddenField ID="hfcusid" runat="server" />
                <span style=" display:none;">
                <asp:Button ID="btnslt" runat="server" Text="cus"  UseSubmitBehavior="false" OnClick="btnslt_Click" />
                </span>
                <asp:HiddenField ID="hfBranch" runat="server" />
            </td>
            </tr>
            <tr>
            <td align="right">备注：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="in1 in2" Width="300"></asp:TextBox></td>
            <td align="right">客户区域：</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbArea" runat="server"  CssClass="in1 in2"></asp:TextBox>
            </td>
            </tr>
    </table>
    </fieldset>
    
    <fieldset style=" border: 1px #808080 solid; padding:10px">
    <legend>相关业务</legend>
    
    <div id="odiv1" style="margin-top:10px;">
    <div>
    <span class="uspan">历史服务单</span>
    <span class="bspan" onclick="ChkPane('odiv2');">机器档案</span>
    </div>
    <div class="fdiv">
    <div class="sw">

    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView2_RowDataBound" EnableViewState="false">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="服务状态" DataField="curStatus" />
                <asp:BoundField HeaderText="服务单号" DataField="BillID" />
                <asp:BoundField HeaderText="服务类别" DataField="ServicesType" />
                <asp:BoundField HeaderText="受理人" DataField="Operator" />
                <asp:BoundField HeaderText="受理时间" DataField="Time_TakeOver" />
                <asp:BoundField HeaderText="处理时间" DataField="Speding" />
                <asp:BoundField HeaderText="受理方式" DataField="TakeStyle" />
                <asp:BoundField HeaderText="受理单位" DataField="TakeDept" />
                <asp:BoundField HeaderText="服务级别" DataField="_PRI" />
                <asp:BoundField HeaderText="技术员" DataField="DisposalOper" />  
                <asp:BoundField HeaderText="客户名称" DataField="CustomerName" />
                <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
                <asp:BoundField HeaderText="联系电话" DataField="Tel" />
                <asp:BoundField HeaderText="机器型号" DataField="ProductModel" />
                <asp:BoundField HeaderText="品牌" DataField="ProductBrand" />
                <asp:BoundField HeaderText="类别" DataField="ProductClass" />
                <asp:BoundField HeaderText="序列号1" DataField="ProductSN1" />
                <asp:BoundField HeaderText="序列号2" DataField="ProductSN2" />
                <asp:BoundField HeaderText="故障" DataField="Fault" />
                <asp:BoundField HeaderText="保修情况" DataField="Warranty" />
                <asp:BoundField HeaderText="预约时间" DataField="SubscribeTime" />
                <asp:BoundField HeaderText="预报价" DataField="SubscribePrice" />
                <asp:BoundField HeaderText="预收费" DataField="PreCharge" />
                <asp:BoundField HeaderText="返修" DataField="bRepair" />
            </Columns>
        </asp:GridView>
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td><webdiyer:aspnetpager id="jsPagerD" runat="server" ShowBoxThreshold="1" ShowInputBox="Never" Visible="false" /></td>
                <td style="padding-left:8px;"><asp:Label ID="lbPageD" runat="server" ToolTip="当页显示数"></asp:Label></td>
                <td style="padding-left:8px;"><asp:Label ID="lbCountD" runat="server" ToolTip="总记录数"></asp:Label></td>
            </tr>
        </table>
        <asp:HiddenField ID="hfRecIDD" runat="server" Value="-1" />
        
    </div>
    </div>
    </div>
    
    <div id="odiv2" style="display:none;margin-top:10px; ">
    <div>
    <span class="bspan" onclick="ChkPane('odiv1');">历史服务单</span>
    <span class="uspan">机器档案</span>
    </div>
    <div class="fdiv">
    <div class="sdiv sw">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="GridView1_RowDataBound" EnableViewState="false">
            <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="客户编号" DataField="CustomerNO" />
                <asp:BoundField HeaderText="客户名称" DataField="_Name" />
                <asp:BoundField HeaderText="联系人" DataField="LinkMan" />
                <asp:BoundField HeaderText="所属部门" DataField="CusDept" />
                <asp:BoundField HeaderText="联系电话" DataField="Tel" />
                <asp:BoundField HeaderText="手机号码" DataField="Tel2" />
                <asp:BoundField HeaderText="传真" DataField="Fax" />
                <asp:BoundField HeaderText="邮编" DataField="Zip" />
                <asp:BoundField HeaderText="地址" DataField="Adr" />
                <asp:BoundField HeaderText="品牌" DataField="ProductBrand" />
                <asp:BoundField HeaderText="类别" DataField="ProductClass" />
                <asp:BoundField HeaderText="型号" DataField="ProductModel" />
                <asp:BoundField HeaderText="序列号1" DataField="ProductSN1" />
                <asp:BoundField HeaderText="序列号2" DataField="ProductSN2" />
                <asp:BoundField HeaderText="外观" DataField="ProductAspect" />
                <asp:BoundField HeaderText="购买时间" DataField="BuyDate" />
                <asp:BoundField HeaderText="经销商" DataField="BuyFrom" />
                <asp:BoundField HeaderText="购买发票" DataField="BuyInvoice" />
                <asp:BoundField HeaderText="安装日期" DataField="InstallDate" />
                <asp:BoundField HeaderText="保修期" DataField="MaintenancePeriod" />
                <asp:BoundField HeaderText="保修情况" DataField="Warranty" />
                <asp:BoundField HeaderText="厂家保修开始" DataField="WarrantyStart" />
                <asp:BoundField HeaderText="厂家保修截至" DataField="WarrantyEnd" />
                <asp:BoundField HeaderText="维修次" DataField="RepairTimes" />
                <asp:BoundField HeaderText="最近维修时间" DataField="Repairlately" />
                <asp:BoundField HeaderText="维修保修截至" DataField="RepairWarrantyEnd" />
                <asp:BoundField HeaderText="合同保修开始" DataField="ContractWarrantyStart" />
                <asp:BoundField HeaderText="合同保修截至" DataField="ContractWarrantyEnd" />
                <asp:BoundField HeaderText="维修合同编号" DataField="ContractNO" />
            </Columns>
        </asp:GridView>
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td><webdiyer:aspnetpager id="jsPager" runat="server"  ShowBoxThreshold="1" CssClass="tdPage" ShowInputBox="Never" Visible="False" /></td>
                <td style="padding-left:8px;"><asp:Label ID="lbPage" runat="server" ToolTip="当页显示数"></asp:Label></td>
                <td style="padding-left:8px;"><asp:Label ID="lbCount" runat="server" ToolTip="总记录数"></asp:Label></td>
            </tr>
        </table>
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
    
    </div>
    </div>
    </div>
    
    </fieldset>
    <div style=" margin-top:5px;">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:Button ID="btnref" runat="server" Text="刷新" CssClass="bt1"  UseSubmitBehavior="false" OnClick="btnref_Click" />
            </td>
            <td align="right">
                <input id="btnNew" type="button" value="服务受理" class="bt1" onclick="ChkBill();" <%=Btn %>/>
                <input id="btnCls" type="button" value="关闭" class="bt1" onclick="chkurl();" />
            </td>
        </tr>
    </table>
    
    </div>    
    </div>
    </div>
    
    
<div id="fcolor" class="fcolor" style="display:none;">Font</div>
 <div id="main">
 
    <div id="divDialog1" style="display: none; visibility: hidden; position: absolute; z-index:8997">
        <div id="divTitle1" style="cursor:default; display:block;">
        <div style="float:left;" id="divIco1"><div id="divTitleName1"></div></div>
         	<div id="divClose1" style="float: right;" onclick="CloseDialog1();">
         		<img alt="关闭" src="../Public/Images/close.gif" style="margin:2px 2px 0 0; cursor: default;" title="关闭" />
         	</div>
         	<div style=" clear:both;"></div>
        </div>
        <iframe id="iframeDialog1" name="iframeDialog1" scrolling="no" frameborder="0"></iframe>  		
    </div>
    <div id="divBackground1" style="position: absolute; z-index: 7996; visibility: hidden; display: none; top: 0px; left: 0px; width: 100%; height: 100%; filter: alpha(opacity=0);">
        <iframe height="100%" name="iframeBackground" src="about:blank" width="100%"></iframe>
    </div>
    <div id="divDialog2" style="display: none; visibility: hidden; position: absolute; z-index:8997">
        <div id="divTitle2" style="cursor:default; display:block;">
        <div style="float:left;" id="divIco2"><div id="divTitleName2"></div></div>
         	<div id="divClose2" style="float: right;" onclick="CloseDialog2();">
         		<img alt="关闭" src="../Public/Images/close.gif" style="margin:2px 2px 0 0; cursor: default;" title="关闭" />
         	</div>
         	<div style=" clear:both;"></div>
        </div>
        <iframe id="iframeDialog2" name="iframeDialog2" scrolling="no" frameborder="0"></iframe>  		
    </div>
    <div id="divBackground2" style="position: absolute; z-index: 7996; visibility: hidden; display: none; top: 0px; left: 0px; width: 100%; height: 100%; filter: alpha(opacity=0);">
        <iframe height="100%" name="iframeBackground" src="about:blank" width="100%"></iframe>
    </div>
	<div id="divDialog" style="display: none; visibility: hidden; position: absolute; z-index:6995">
        <div id="divTitle" style="cursor:default; display:block;">
        	<div style="float:left;" id="divIco"><div id="divTitleName"></div></div>
         	<div id="divClose" style="float: right;" onclick="CloseDialog();">
         		<img alt="关闭" src="../Public/Images/close.gif" style="margin:2px 2px 0 0; cursor: default;" title="关闭" />
         	</div>
         	<div style=" clear:both;"></div>
        </div>
		<iframe id="iframeDialog" name="iframeDialog" scrolling="no"  frameborder="0"></iframe>  
    </div>
    
    <div id="divBackground" style="position: absolute; z-index: 5994; visibility: hidden; display: none; top: 0px; left: 0px; width: 100%; height: 100%; filter: alpha(opacity=0);">
        <iframe height="100%" name="iframeBackground" src="about:blank" width="100%"></iframe>
    </div> 
    
        <div id="test" style="width:190px; position:absolute; top:13px; right:10px; display:none; z-index:9999; background:#e9e7e3; border:1px #16397f solid; padding:5px;">
                <img src="../Public/Images/load.gif" alt="loading" />
                <span style="color:#0000ff">正处理数据,请稍候...</span>
                <a id="btntest" href="#" style="padding-left:5px; color:#000;">取消</a>
    </div>
     
</div>

</form>
</body>
</html>
<script language="javascript" type="text/javascript">
window.onload=function() 
{ 
　var obj = document.getElementById("divTitleName");
  var target = document.getElementById("divDialog");
  drag(obj, target);
  var obj1 = document.getElementById("divTitleName1");
  var target1 = document.getElementById("divDialog1");
  drag(obj1, target1);
}

function ChkView(hid)
{
    var id=document.getElementById(hid).value.replace("d","");
    var branch=document.getElementById("hfBranch").value;
    if(hid=="hfRecID"){
    ShowDialog(750, 430, '../'+branch+'/Customer/DeviceMod.aspx?itel=1&id='+id, '机器档案');
    }else{
    ShowDialog(860,444, '../'+branch+'/Services/SerView.aspx?itel=1&id='+id, '服务单');
    }
}
function ChkBill()
{
    var cid=document.getElementById("hfcusid").value;
    var tel=document.getElementById("tbTel").value;
    var branch=document.getElementById("hfBranch").value;
    if(cid==""){
    ShowDialog(870,600, '../'+branch+'/Services/ServicesAdd.aspx?itel=1&tel='+escape(tel), '服务受理');
    }else{
    ShowDialog(870,600, '../'+branch+'/Services/ServicesAdd.aspx?itel=1&cusid='+cid, '服务受理');    
    }
}
function chkurl()
{
    location.href='../Interface/Tel.aspx#close';
}
</script>
