<%@ page language="C#"  CodeFile="printbill.aspx.cs"     autoeventwireup="true" inherits="Branch_Services_PrintBill" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:366px;">
    <div class="fdivs" style="width:364px;height:42px;">
    <div class="sdivs" style="width:362px; height:40px;">
    <div class="divh" style="height:10px;"></div>
         <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="padding-left:5px;"><img src="../../Public/Images/print.gif" title="打印凭证" /></td>
                <td style=" padding:3px 10px 0 3px;"><a href="#" tabindex="-1" onclick="ChkPrint('PZD');parent.CloseDialog();">凭证单</a></td>
                <td style="padding-top:2px;"><img src="../../Public/Images/print.gif" title="打印派工单"/></td>
                <td style=" padding:3px 10px 0 3px;"><a href="#" tabindex="-1" onclick="ChkPrint('PGD');parent.CloseDialog();">派工单</a></td>
                <td style="padding-top:2px;"><img src="../../Public/Images/print.gif" title="打印随机单"/></td>
                <td style=" padding:3px 10px 0 3px;"><a href="#" tabindex="-1" onclick="ChkPrint('SJD');parent.CloseDialog();">随机单</a></td>
                <td style="padding-top:2px;"><img src="../../Public/Images/print.gif" title="打印报价单"/></td>
                <td style=" padding:3px 10px 0 3px;"><a href="#" tabindex="-1" onclick="ChkPrint('BJD');parent.CloseDialog();">报价单</a></td>
                <td style="padding-top:2px;"><img src="../../Public/Images/print.gif" title="打印结算单"/></td>
                <td style=" padding:3px 10px 0 3px;"><a href="#" tabindex="-1" onclick="ChkPrint('JSD');parent.CloseDialog();">结算单</a></td>
            </tr>
        </table>
        <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
    </div>
    </div>
    
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="right">
            <input id="btnCls" type="button" value="取消" class="bt1" onclick="parent.CloseDialog();"/>
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
