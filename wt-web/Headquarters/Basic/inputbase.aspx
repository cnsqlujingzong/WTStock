<%@ page language="C#"  CodeFile="inputbase.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Basic_InputBase" enableEventValidation="false" %>
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
        <div id="sa" style="width:466px;">
        <div class="fdiv">
            <div class="sdiv">
            <table cellpadding="0" cellspacing="0" class="tb3">
                <tr>
                    <td align="right">请上传Excel文件：</td>
                    <td style="padding-left:0px;">
                    <a href="#" onclick="ChkUpload();" style="color:#0000ff;">点击上传</a>
                    <asp:HiddenField ID="hfPath" runat="server" />
                    <span style="display:none;">
                        <asp:Button ID="btnUp" runat="server" Text="up" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnUp_Click" /></span>
                    </td>
                </tr>
                <tr>
                    <td align="right">请选择Excel表名：</td>
                    <td style="padding-left:0px;">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                        <asp:DropDownList ID="ddlTableName" runat="server" CssClass="pindl" AutoPostBack="True" OnSelectedIndexChanged="ddlTableName_SelectedIndexChanged" Width="120">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnUp" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                    </td>
                    <td>数据表名：</td>
                    <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlName" runat="server" CssClass="pindl" Width="120">
                            <asp:ListItem Value="Quarters">员工岗位</asp:ListItem>
                            <asp:ListItem Value="AreaList">区域目录</asp:ListItem>
                            <asp:ListItem Value="CustomerStatus">客户状态</asp:ListItem>
                            <asp:ListItem Value="CustomerFrom">客户来源</asp:ListItem>
                            <asp:ListItem Value="TrackStyle">跟踪方式</asp:ListItem>
                            <asp:ListItem Value="TrackType">跟踪类别</asp:ListItem>
                            <asp:ListItem Value="AllotReason">分派原因</asp:ListItem>
                            <asp:ListItem Value="ProductAspect">物品外观</asp:ListItem>
                            <asp:ListItem Value="ProductAccessory">随机附件</asp:ListItem>
                            <asp:ListItem Value="TakeStyle">受理方式</asp:ListItem>
                            <asp:ListItem Value="CancelReason">取消原因</asp:ListItem>
                            <asp:ListItem Value="VisitStyle">回访形式</asp:ListItem>
                            <asp:ListItem Value="ContractType">合同类别</asp:ListItem>
                            <asp:ListItem Value="ChargeMode">结算方式</asp:ListItem>
                            <asp:ListItem Value="InvoiceClass">发票类别</asp:ListItem>
                            <asp:ListItem Value="INStockReason">入库原因</asp:ListItem>
                            <asp:ListItem Value="OUTStockReason">出库原因</asp:ListItem>
                            <asp:ListItem Value="UnitList">计量单位</asp:ListItem>
                            <asp:ListItem Value="StockLocation">货品仓位</asp:ListItem>
                            <asp:ListItem Value="QtyType">计数器类型</asp:ListItem>
                            <asp:ListItem Value="ProductBrand">机器品牌</asp:ListItem>
                            <asp:ListItem Value="ProductClass">机器类别</asp:ListItem>
                            <asp:ListItem Value="RepairClass">维修类别</asp:ListItem>
                            <asp:ListItem Value="TroubleReason">故障原因</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            </div>
            </div>
            <div class="divh"></div>
            <div class="fdiv">
            <div class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" RenderMode="Inline">
               <ContentTemplate>
                <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                       <td align="right">名称：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddl1" runat="server" CssClass="pindl">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">排序：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddl2" runat="server" CssClass="pindl">
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                 </table>
               </ContentTemplate>
               <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="ddlTableName" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
            </div>
            </div>
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="确定" CssClass="bt1" OnClientClick="if(ChkAdd()==false) return;" UseSubmitBehavior="false" OnClick="btnAdd_Click"/>
                    <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog1();"/>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
var processtip=1;

function ChkAdd()
{
    if($("ddlTableName").value=="")
    {
        alert("请选择Excel表名");
        $("ddlTableName").focus();
        return false;
    }
    
    if($("ddl1").value=="")
    {
        alert("请选择名称");
        $("ddl1").focus();
        return false;
    }
}
function ChkUpload()
{
    parent.ShowDialog2(600, 380, 'System/UpLoadExcel.aspx?f=x', '上传Excel');
}
</script>
