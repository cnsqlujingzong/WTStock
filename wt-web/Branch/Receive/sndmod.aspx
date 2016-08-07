<%@ page language="C#"  CodeFile="sndmod.aspx.cs"     autoeventwireup="true" inherits="Branch_Receive_SndMod" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:710px;">
    <div class="fdivs">
    <div class="sdivs" style="padding:3px 0 3px 0px;width:706px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td>发货单号：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbBillID" runat="server" CssClass="pinb" Width="110" ReadOnly="true"></asp:TextBox></td>
            <td>日期：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDate" runat="server" CssClass="pin" Width="80" ></asp:TextBox></td>
            <td class="red">经办人：</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl" Width="70">
                </asp:DropDownList>
            </td>
            <td>类别：</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlSndType" runat="server" CssClass="pindl" Width="53">
                    <asp:ListItem Value=""></asp:ListItem>
                    <asp:ListItem Value="送修">送修</asp:ListItem>
                    <asp:ListItem Value="返还">返还</asp:ListItem>
                    <asp:ListItem Value="出库">出库</asp:ListItem>
                    <asp:ListItem Value="其它">其它</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="sysred">收货类型：</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlRcvObj" runat="server" CssClass="pindl" Width="53">
                    <asp:ListItem Value="客户">客户</asp:ListItem>
                    <asp:ListItem Value="网点">网点</asp:ListItem>
                    <asp:ListItem Value="厂商">厂商</asp:ListItem> 
                    <asp:ListItem Value="其它">其它</asp:ListItem>
                </asp:DropDownList>
                
            </td>
        </tr>
     </table>
    <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td class="red">公司名称：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbCusName" runat="server" CssClass="pin" Width="250"></asp:TextBox>
            </td>
            <td>收货人：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin" Width="80"></asp:TextBox></td>
            <td>联系电话：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin"></asp:TextBox></td>
        </tr>
        <tr>
            <td>收货地址：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin" Width="250"></asp:TextBox></td>
            <td align="right">邮编：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbZip" runat="server" CssClass="pin" Width="80"></asp:TextBox>
            </td>
            <td class="red">网点名称：</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlBranch" runat="server" Enabled="false" CssClass="pindl" >
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td>货品摘要：</td>
            <td style="padding-left:0px; height:50px;"><asp:TextBox ID="tbSummary" runat="server" CssClass="pin" Width="610" TextMode="MultiLine" Height="42"></asp:TextBox></td>
        </tr>
    </table>
    <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td>货运方式：</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlShipStyle" runat="server" CssClass="pindl">
                </asp:DropDownList>
            </td>
            <td>物流单号：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbSndNo" runat="server" CssClass="pin"></asp:TextBox></td>
            <td>邮资：</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbPostage" runat="server" CssClass="pin"></asp:TextBox></td>
        </tr>
     </table>
    <table cellpadding="0" cellspacing="0" class="tb1">
        <tr>
            <td>备注信息：</td>
            <td style="padding-left:0px;height:50px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="610" TextMode="MultiLine" Height="42"></asp:TextBox></td>
        </tr>
    </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnConfSnd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    </div>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td><asp:HiddenField ID="hfPrintID" runat="server" />
            </td>
            <td align="right">
                <asp:Button ID="btnConfSnd" runat="server" Text="确认发货" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;"  OnClick="btnConfSnd_Click"/>
                <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;"  OnClick="btnAdd_Click"/>
                <input id="btnPrint" type="button" value="打印" class="bt1" onclick="ChkPrint('FHD');" />
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
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
function ChkSave()
{
    if(isNull($("tbDate").value))
    {
        window.alert("操作失败！日期不能为空");
        $("tbDate").focus();
        return false
    }
    
    if($("ddlOperator").value=="-1")
    {
        window.alert("操作失败！经办人不能为空");
        $("ddlOperator").focus();
        return false
    }
    
    if(isNull($("ddlSndType").value))
    {
        window.alert("操作失败！类别不能为空");
        $("ddlSndType").focus();
        return false
    }
    if(isNull($("tbLinkMan").value))
    {
        window.alert("操作失败！联系人不能为空");
        $("tbLinkMan").focus();
        return false
    }
    if(isNull($("tbAdr").value))
    {
        window.alert("操作失败！地址不能为空");
        $("tbAdr").focus();
        return false
    }
    
    if(isNull($("tbSummary").value))
    {
        window.alert("操作失败！货品摘要不能为空");
        $("tbSummary").focus();
        return false
    }  
    
    if(!isNull($("tbPostage").value))
    {
        if(!isMoney($("tbPostage").value))
        {
            window.alert("操作失败！邮资格式不正确");
            $("tbPostage").focus();
            return false
        }
    }
}

</script>
