<%@ page language="C#"  CodeFile="devaccadd.aspx.cs"     autoeventwireup="true" inherits="Branch_Customer_DevAccAdd" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="main">
        <div class="maincon">
        <div id="sa" style="width:486px;">
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
               <table cellpadding="0" cellspacing="0" class="tb3">
               <tr>
               <td align="right">创建人：</td>
               <td style="padding-left:0px;" colspan="2">
                    <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl2" Width="153px">
                    </asp:DropDownList>
               </td>
               </tr>
               <tr>
               <td align="right">创建时间：</td>
               <td style="padding-left:0px;" colspan="2">
                    <asp:TextBox ID="tbDate" runat="server" CssClass="Wdate2" Width="150px" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm:ss'})"></asp:TextBox>
               </td>
               </tr>
                <tr>
                    <td align="right">附件名称：</td>
                    <td style="padding-left:0px;" colspan="2"><asp:TextBox ID="tbName" runat="server" CssClass="pin" Width="200"></asp:TextBox></td>
                </tr>

                <tr>
                    <td align="right">附件摘要：</td>
                    <td style="padding-left:0px;" colspan="2"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="330"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:HiddenField ID="hfUpload" runat="server" /></td>
                    <td style="padding-left:0px;"><a href="#" style="color:#0000ff" title="上传附件" onclick="ChkUpload();">上传附件</a>
                    </td>
                    <td style="width:260px;">
                        <div id="dUpload"></div>
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
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;" OnClick="btnAdd_Click"/>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
var isfocus=1;
var processtip=1;
function ChkSave()
{
    if($("ddlOperator").value=="-1")
    {
        window.alert("操作失败！创建人不能为空");
        $("ddlOperator").focus();
        return false;
    }
    if($("tbDate").value=="")
    {
        window.alert("操作失败！创建时间不能为空");
        $("tbDate").focus();
        return false;
    }
    if(isNull($("tbName").value))
    {
        window.alert("操作失败！附件名称不能为空");
        $("tbName").focus();
        return false
    }
    if(isNull($("tbRemark").value))
    {
        window.alert("操作失败！请填写附件摘要");
        $("tbRemark").focus();
        return false
    }
    if($("dUpload").innerHTML=="")
     {
         if(!confirm("该附件还没有上传，是否保存？"))
         {
            return false;
         }
     }
}

function ChkUpload()
{   
    if($("dUpload").innerHTML=="")
    {
        parent.ShowDialog1(600, 380, 'Customer/DocUpload.aspx', '上传附件');
    }
    else
    {
        if(confirm("已经存在一个附件，继续上传将替换该附件，是否继续？"))
        {
            parent.ShowDialog1(600, 380, 'Customer/DocUpload.aspx', '上传附件');   
        }
    }
}
</script>
