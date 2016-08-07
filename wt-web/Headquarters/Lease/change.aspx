<%@ page language="C#"  CodeFile="change.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Lease_Change" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sad" style="width:444px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <fieldset style=" border: 1px #808080 solid; padding:5px 0; width:440px;">
      <legend>新机信息</legend>
      
      <table cellpadding="0" cellspacing="0" class="tb5">
            <tr>
                <td align="right">机器编号：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbDeviceNO" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td align="right">机器品牌：</td>
                    <td style="padding-left:0px; width:136px;">
                        <div class="isinDiv">
                            <asp:TextBox ID="tbBrand" runat="server" CssClass="pin pinin" AutoCompleteType="Disabled" onblur="ChkPBrand();"></asp:TextBox>
                            <asp:DropDownList ID="ddlBrand" runat="server" CssClass="pininsl" onchange="document.getElementById('tbBrand').value=this.options[this.selectedIndex].text;NewProductBrands('1');" AutoPostBack="True" OnSelectedIndexChanged="ddlBrand_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </td>
                    
            </tr>
            <tr>
                <td align="right">类别：</td>
                    <td style="padding-left:0px;">
                        <div class="isinDiv">
                            <asp:TextBox ID="tbClass" runat="server" CssClass="pin pinin" AutoCompleteType="Disabled" onblur="ChkPClass();">
                            </asp:TextBox>
                            <asp:DropDownList ID="ddlClass" runat="server" onchange="document.getElementById('tbClass').value=this.options[this.selectedIndex].text;NewProductClasss('1');" CssClass="pininsl" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </td>
                <td align="right">型号：</td>
                    <td style="padding-left:0px;">
                        <div class="isinDiv">
                            <asp:TextBox ID="tbModel" runat="server" CssClass="pin pinin" AutoCompleteType="Disabled" onblur="ChkPModel();"></asp:TextBox>
                            <asp:DropDownList ID="ddlModel" runat="server" CssClass="pininsl" onchange="document.getElementById('tbModel').value=this.options[this.selectedIndex].text;NewProductModels('1');" AutoPostBack="True" OnSelectedIndexChanged="ddlModel_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </td>
            </tr>
            <tr>
                <td align="right">序列号：</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbSN" runat="server" CssClass="pin" onblur="sngetgds();"></asp:TextBox>
                </td>
                <td align="right"><asp:Label ID="lbCount" runat="server" Text="计数器："></asp:Label></td>
                <td align="left" style="padding-left:0px;"><a href="#" id="edit" runat="server" onclick="EditQty('tbQty');">编辑计数器</a>
                <span style="display:none;">
                <asp:TextBox ID="tbQty" runat="server"></asp:TextBox></span>
                <asp:TextBox ID="tbOutCount" runat="server" CssClass="pin" Visible="false"></asp:TextBox></td>
            </tr>
            <tr runat="server" id="tr">
                <td align="right">
                    出库单价：
                </td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbOutPrice" runat="server" CssClass="pin"></asp:TextBox>
                </td>
            </tr>
       </table>
      </fieldset>
      <fieldset style=" border: 1px #808080 solid; padding:5px 0; width:440px;">
      <legend>旧机入库</legend>
        <table cellpadding="0" cellspacing="0" class="tb5">
            <tr>
                <td>
                    入库设备：
                </td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbInGoodsNO" runat="server" CssClass="pinb" ReadOnly="true"></asp:TextBox>
                </td>
                <td>
                    入库仓库：
                </td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlInStock" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
                
            </tr>
            <tr>
                <td>
                    入库金额：
                </td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbPrice" runat="server" CssClass="pin"></asp:TextBox>
                </td>
                <td>
                    <asp:HiddenField ID="hfType" runat="server" />
                    <asp:HiddenField ID="hfGoodsID" runat="server" />
                     <asp:HiddenField ID="hfGoodsNO" runat="server" />
                    <asp:HiddenField ID="hfPrintID" runat="server" />
                    <asp:HiddenField ID="hfSNID" runat="server" />
                    <asp:HiddenField ID="hfSN" runat="server" />
                    <span style="display:none;">
                        <asp:Button ID="btngetgds" runat="server" Text="..."  OnClick="btngetgds_Click"/>
                        <asp:Button ID="btnsngetgds" runat="server" Text="..."  OnClick="btnsngetgds_Click"/>
                    </span>
                    入库数量：
                </td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbInCount" runat="server" CssClass="pin"></asp:TextBox>
                </td>
            </tr>
        </table>
      </fieldset>
      <fieldset style=" border: 1px #808080 solid; padding:5px 0; width:440px;">
      <legend>新机出库</legend>
      <table cellpadding="0" cellspacing="0" class="tb5">
            <tr>
                <td>
                    租赁设备：
                </td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbGoodsNO" runat="server" CssClass="pin" Width="114" onblur="getgdsinfo();"></asp:TextBox>
                </td>
                <td style="padding:0px;"><input id="tbSltGoods" type="button" class="bview" onclick="parent.ShowDialog1(800, 520, 'Stock/SltGoods.aspx?f=2', '选择租赁设备');" /></td>
                <td>
                    出库仓库：
                </td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlStock" runat="server" CssClass="pindl">
                    </asp:DropDownList>
                </td>
            </tr>
      </table>
      </fieldset>
      </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnRefBrand" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnRefModel" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnRefClass" EventName="Click" />
        </Triggers>
        </asp:UpdatePanel>
      <div class="divh"></div>
        <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:HiddenField ID="hfBrand" runat="server" />
                <asp:HiddenField ID="hfClass" runat="server" />
                <asp:HiddenField ID="hfModelID" runat="server" />
                <span style="display:none;">
                        <asp:Button ID="btnRefModel" runat="server" Text="GetPModel" OnClick="btnRefModel_Click" />
                        <asp:Button ID="btnRefBrand" runat="server" Text="RefBrand" OnClick="btnRefBrand_Click" />
                        <asp:Button ID="btnRefClass" runat="server" Text="RefClass" OnClick="btnRefClass_Click" />
                </span>
            </td>
            <td align="right">
                <asp:Button ID="btnAdd" runat="server" Text="确定" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
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
<script language="javascript" type="text/javascript" src="../../Public/Script/detailslt.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/detail.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript">
function ChkAdd()
{
   if($("hfType").value=="租赁")
    {
        if($("ddlInStock").value=="-1")
        {
            window.alert("操作失败！入库仓库不能为空");
            $("ddlInStock").focus();
            return false
        }
        if(isNull($("tbPrice").value))
        {
            window.alert("操作失败！入库金额不能为空");
            $("tbPrice").focus();
            return false
        }
        if(!isMoney($("tbPrice").value))
        {
            window.alert("入库金额格式不正确");
            $("tbPrice").focus();
            return false
        }
        if(isNull($("tbGoodsNO").value))
        {
            window.alert("操作失败！租赁设备不能为空");
            $("tbGoodsNO").focus();
            return false
        }
        if($("ddlStock").value=="-1")
        {
            window.alert("操作失败！出库仓库不能为空");
            $("ddlStock").focus();
            return false
        }
    }
}
function getgdsinfo()
{
    var strsn=$("tbGoodsNO").value;
    if($("hfGoodsNO").value!=strsn)
    {
        $("hfGoodsNO").value=$("tbGoodsNO").value;
        if(!isNull(strsn))
            $("btngetgds").click();
        else
            {$("hfGoodsID").value="";}
    }
}

function sngetgds()
{
    var strsn=$("tbSN").value;
    if($("hfSN").value!=strsn)
    {
        $("hfSN").value=$("tbSN").value;
        if(!isNull(strsn))
            $("btnsngetgds").click();
        else
            {$("hfSNID").value="";}
    }
}
function EditQty(tbqty)
{
    parent.ShowDialog1(600, 380, 'Lease/EditQty.aspx?tbqty='+tbqty+'&qtyvalue='+escape($(tbqty).value), '编辑计数器');
}
function SltSN()
{
    var gdsid=$("hfGoodsID").value;
    parent.ShowDialog1(800, 520, 'Stock/SltSN.aspx?gid='+gdsid+'&iflag=1&fid=iframeDialog', '选择序列号');
}
</script>
