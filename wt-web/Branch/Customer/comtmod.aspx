<%@ page language="C#"  CodeFile="comtmod.aspx.cs"     autoeventwireup="true" inherits="Branch_Customer_ComtMod" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sa" style="width:456px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
        <div class="fdiv">
        <div class="sdiv">
        <table cellpadding="0" cellspacing="0" class="tb3">
            <tr>
                <td align="right">
                    受理日期：
                </td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()"></asp:TextBox>
                </td>
                <td align="right">
                    受理人：
                </td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                
            </tr>
            <tr>
                <td align="right" class="red">客户名称：</td>
                <td style="padding-left:0px;" colspan="3">
                    <asp:TextBox ID="tbCusName" runat="server" CssClass="pin" Width="341"></asp:TextBox>
                </td>
                <td style="padding:0px;"><input id="btnSlt" type="button" value="" onclick="SltCus();" class="bview"/></td>
            </tr>
            <tr>
                <td align="right">
                    联系人：
                </td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td align="right">
                    联系电话：
                </td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbTel" runat="server" CssClass="pin"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="sysred">
                    投诉内容：
                </td>
                <td style="padding-left:0px; height:56px;" colspan="3">
                    <asp:TextBox ID="tbContent" runat="server" CssClass="pin" Width="341" Height="42" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="sysred">处理人：</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlDoOperator" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                <td align="right">关联业务：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbOperationID" runat="server" CssClass="pin"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    备注：
                </td>
                <td style="padding-left:0px;" colspan="3">
                    <asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="341"></asp:TextBox>
                </td>
            </tr>
         </table>
          <asp:HiddenField ID="hfCusID" runat="server" />
          <span style="display:none;">
            <asp:Button ID="btnCusInfo" runat="server" Text="..." OnClick="btnCusInfo_Click"/>
          </span>
        </div>
        </div>
        
        </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>
            <asp:Label ID="lbMod" runat="server"></asp:Label>
        </td>
        <td align="right">
            <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnAdd_Click" />
            <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog();"/>
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
<script language="javascript" type="text/javascript">
var processtip=1;
function ChkSave()
{
    if(isNull($("tbDate").value))
    {
        window.alert("操作失败！受理日期不能为空");
        $("tbDate").focus();
        return false
    }
    
    if($("ddlOperator").value=="-1")
    {
        window.alert("操作失败！受理人不能为空");
        $("ddlOperator").focus();
        return false
    }
    
    if(isNull($("tbCusName").value))
    {
        window.alert("操作失败！客户姓名不能为空");
        $("tbCusName").focus();
        return false
    }
    if(isNull($("tbTel").value))
    {
        window.alert("操作失败！联系电话不能为空");
        $("tbTel").focus();
        return false
    }
    if(isNull($("tbContent").value))
    {
        window.alert("操作失败！投诉内容不能为空");
        $("tbContent").focus();
        return false
    }
    
    if($("ddlDoOperator").value=="-1")
    {
        window.alert("操作失败！处理人不能为空");
        $("ddlDoOperator").focus();
        return false
    }
}

function SltCus()
{
    parent.ShowDialog1(800, 500, 'Customer/SltCus.aspx?f=2', '选择客户');
}

</script>
