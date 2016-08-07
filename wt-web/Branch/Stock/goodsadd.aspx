<%@ page language="C#"  CodeFile="goodsadd.aspx.cs"     autoeventwireup="true" inherits="Branch_Stock_GoodsAdd" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/tab.css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="main">
        <div class="maincon">
        <div id="sad" style="width:606px;">
         <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td class="blue">产品名称：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbName" runat="server" CssClass="pin" Width="230"></asp:TextBox></td>
                <td class="blue">产品编号：</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbGdsNO" runat="server" CssClass="pin" Enabled="false"></asp:TextBox></td>
                <td class="sysred" style="padding-left:5px;">
                    <asp:CheckBox ID="cbsys" runat="server" Text="系统默认" Checked="true" onclick="ChkSysNO();" /></td>
            </tr>
         </table>
        <div class="divh"></div>
        <div id="mytabs">
            <span id="tabs_l1"></span>
            <span id="tabs1" onclick="ChkTab('1');">基本信息</span>
            <span id="tabs_r1"></span>
            <span id="tabs_l2"></span>
            <span id="tabs2" onclick="ChkTab('2');">多单位</span>
            <span id="tabs_r2"></span>
            <span id="tabs_l3"></span>
            <span id="tabs3" onclick="ChkTab('3');">拆装关系</span>
            <span id="tabs_r3"></span>
            <span id="tabs_l4"></span>
            <span id="tabs4" onclick="ChkTab('4');">仓库列表</span>
            <span id="tabs_r4"></span>
            <span id="tabs_l5"></span>
            <span id="tabs5" onclick="ChkTab('5');">自定义</span>
            <span id="tabs_r5"></span>
        </div>
        <div id="info1" style="padding:3px 0px 0px 3px; overflow:hidden;">
        <div id="divinfo1" class="divinfo" style="height:307px;overflow:auto;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
            <ContentTemplate>
            <table cellpadding="0" cellspacing="0">
            <tr>
                <td align="left">
                <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                       <td align="right">产品类别：</td>
                        <td style="padding-left:0px;">
                            <div class="isinDiv">
                            <input type="text" id="tbGdsClass" runat="server" class="pin pinin" readonly="readonly" />
                                <select id="slGdsClass" runat="server" onchange="getclassvalue('tbGdsClass',this.options[this.selectedIndex].text);" class="pininsl">
                                </select>
                            </div>
                         </td>
                         <td align="right">属性：</td>
                        <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlAttr" runat="server" CssClass="pindl" onchange="ChkMain();">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Value="备件">备件</asp:ListItem>
                            <asp:ListItem Value="整机">整机</asp:ListItem>
                            <asp:ListItem Value="耗材">耗材</asp:ListItem>
                            <asp:ListItem Value="材料">材料</asp:ListItem>
                            <asp:ListItem Value="其他">其他</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    </tr>
                    <tr>
                        <td align="right">规格：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbSpec" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td align="right">品牌：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlBrand" runat="server" onchange="NewProductBrand();" CssClass="pindl">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">单位：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlUnit" runat="server" onchange="NewUnit();" CssClass="pindl">
                            </asp:DropDownList>
                        </td>
                        <td align="right">零售价：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbPriceDetail" runat="server" CssClass="pin" old="" onblur="ChkMoney(this);"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">进货价：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbPriceCost" runat="server" CssClass="pin" old="" onblur="ChkMoney(this);"></asp:TextBox>
                        </td>
                        <td align="right">内部价：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbPriceInner" runat="server" CssClass="pin" old="" onblur="ChkMoney(this);"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">旧货价：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbPriceWholeSale1" runat="server" CssClass="pin" old="" onblur="ChkMoney(this);"></asp:TextBox></td>
                        <td align="right">替代价：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbPriceWholeSale2" runat="server" CssClass="pin" old="" onblur="ChkMoney(this);"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">列表价：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbPriceWholeSale3" runat="server" CssClass="pin" old="" onblur="ChkMoney(this);"></asp:TextBox></td>
                        <td align="right"><asp:Label ID="lbMain" runat="server" Text="保修期"></asp:Label>：</td>
                        <td style="padding-left:0px;">
                            <div class="isinDiv">
                            <input type="text" id="tbProt" runat="server" class="pin pinin" />
                                <select id="slProt" onchange="document.getElementById('tbProt').value=this.options[this.selectedIndex].value" class="pininsl">
                                    <option value="" selected="selected"></option>
                                    <option value="无保修">无保修</option>
                                    <option value="一个月">一个月</option>
                                    <option value="三个月">三个月</option>
                                    <option value="六个月">六个月</option>
                                    <option value="一年">一年</option>
                                    <option value="两年">两年</option>
                                    <option value="三年">三年</option>
                                    <option value="五年">五年</option>
                                    <option value="终生">终生</option>
                                </select>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">条码：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbBarCode" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td align="right" class="red">成本模式：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlCostMode" runat="server" CssClass="pindl">
                                <asp:ListItem Value="2">移动加权平均法</asp:ListItem>
                                <asp:ListItem Value="1">先进先出法</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">适用产品：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbForProducts" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td align="right" class="red">默认仓库：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlStock" runat="server" CssClass="pindl" onchange="NewStock();">
                        </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">供应商：</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlProvider" runat="server" CssClass="pindl" onchange="NewSupplier();">
                            </asp:DropDownList>
                        </td>
                        <td align="right">有效期：</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbValid" runat="server" CssClass="pin" Width="110" ToolTip="天" onblur="ValidateNums(this);"></asp:TextBox>
                            <span class="red">天</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">备注：</td>
                        <td colspan="3" style="padding-left:0px;">
                             <asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="341"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right"></td>
                        <td colspan="3" style="padding-left:0px;">
                             <asp:CheckBox ID="cbIncrement" runat="server" Text="" /> 增值产品
                             <asp:CheckBox ID="cbSNTrack" runat="server" Text="" /> 序列号跟踪
                             <asp:CheckBox ID="cbStock" runat="server" Text="" /> 允许负库存
                             <asp:CheckBox ID="cbStop" runat="server" /> <span class="sysred">停用标志</span>
                             <asp:HiddenField ID="hfBrand" runat="server" />
                             <asp:HiddenField ID="hfUnit" runat="server" />
                             <asp:HiddenField ID="hfStock" runat="server" />
                             <asp:HiddenField ID="hfSupplier" runat="server" />
                             <span style="display:none;">
                                <asp:Button ID="btnRefBrand" runat="server" Text="RefBrand" OnClick="btnRefBrand_Click" />
                                <asp:Button ID="btnRefUnit" runat="server" Text="RefUnit" OnClick="btnRefUnit_Click" />
                                <asp:Button ID="btnRefStock" runat="server" Text="RefStock" OnClick="btnRefStock_Click" />
                                <asp:Button ID="btnRefSupplier" runat="server" Text="RefSupplier" OnClick="btnRefSupplier_Click" />
                            </span>
                        </td>
                    </tr>
                </table>
                </td>
                <td valign="top" align="center">
                <table cellpadding="0" cellspacing="0" style="margin-left:12px; margin-top:5px;">
                    <tr>
                        <td><div  class="gdsimg" id="gdiv"></div></td>
                    </tr>
                    <tr>
                        <td align="left">
                            <div style="margin-top:3px;">
                            <input id="btnImg" type="button" runat="server" class="img" onclick="parent.ShowDialog1(600, 380, 'Stock/GoodsImg.aspx', '产品图片');" title="上传产品图片" />
                            <input id="btnView" type="button" class="view" onclick="ChkBImg();" title="放大图片" />
                            <asp:Button ID="btnImgDel" runat="server" CssClass="del" UseSubmitBehavior="false" OnClientClick="if(ChkDelPic()==false)return false;" OnClick="btnImgDel_Click" ToolTip="删除图片"/>
                            </div>
                            <asp:HiddenField ID="hfImgName" runat="server" />
                        </td>
                    </tr>
                </table>
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
            <div id="info2">
                <div class="divcon" style="height:286px;">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                <ContentTemplate>
                    <asp:GridView ID="GridView1" runat="server" SkinID="gv4" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
                        <Columns>
                            <asp:BoundField HeaderText="ID" DataField="ID" />
                            <asp:BoundField HeaderText="单位名称" DataField="名称"/>
                            <asp:BoundField HeaderText="单位关系" DataField="关系"/>
                            <asp:BoundField HeaderText="条码" DataField="条码"/>
                            <asp:BoundField HeaderText="零售价" DataField="零售价"/>
                            <asp:BoundField HeaderText="进货价" DataField="进货价"/>
                            <asp:BoundField HeaderText="内部价" DataField="内部价"/>
                            <asp:BoundField HeaderText="旧货价" DataField="旧货价"/>
                            <asp:BoundField HeaderText="替代价" DataField="替代价"/>
                            <asp:BoundField HeaderText="列表价" DataField="列表价"/>
                        </Columns>
                    </asp:GridView>
                    <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
                    <asp:HiddenField ID="hfMUnit" runat="server" Value="-1" />
              </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnAddUnit" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnShowUnit" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnModUnit" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnDelUnit" EventName="Click" />
                </Triggers>
              </asp:UpdatePanel>
              </div>
              <div class="fbombtn">
              <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                    <td style="padding-left:0px;">
                    <input id="btnNewUnit" type="button" value="新建" class="bt1" onclick="parent.ShowDialog1(480, 205, 'Stock/UnitAdd.aspx', '新建产品单位');"/>
                    <input id="btnEditUnit" type="button" value="修改" class="bt1" onclick="ModUnit(480, 205,'Stock/UnitMod.aspx','修改产品单位');"/>
                    <asp:Button ID="btnDelUnit" runat="server" Text="删除" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnDelUnit_Click"/>
                    </td>
                    </tr>
                </table>
              </div>
            </div>
            <div id="info3">
                <div class="divcon" style="height:286px;">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                <ContentTemplate>
                   <asp:GridView ID="GridView2" runat="server" SkinID="gv3" AutoGenerateColumns="False" OnRowDataBound="GridView2_RowDataBound" OnRowDeleting="GridView2_RowDeleting">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID"/>
                        <asp:BoundField HeaderText="编号" DataField="编号"/>
                        <asp:BoundField HeaderText="名称" DataField="名称"/>
                        <asp:BoundField HeaderText="属性" DataField="属性"/>
                        <asp:BoundField HeaderText="规格" DataField="规格"/>
                        <asp:BoundField HeaderText="品牌" DataField="品牌"/>
                        <asp:BoundField HeaderText="保修期" DataField="保修期"/>
                        <asp:TemplateField HeaderText="定额数量">
                            <ItemTemplate>
                                <asp:TextBox ID="tbQty" runat="server" Text='<%# Eval("定额数量") %>' Width="100"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="删除">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbDel" TabIndex="-1" runat="server" CausesValidation="False"  CommandName="Delete" Text="删除" style="color:#0000ff;"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                   </asp:GridView>
                   <asp:HiddenField ID="hfreclist" runat="server"/>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnSure" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnId" EventName="Click" />
                </Triggers>
                </asp:UpdatePanel>
                </div>
                <div class="fbombtn">
                    <table cellpadding="0" cellspacing="0" class="tb2">
                        <tr>
                            <td style="padding-left:0px;">
                                <asp:DropDownList ID="ddlSchFld" runat="server" CssClass="pindl" Width="60">
                                    <asp:ListItem Value="GoodsNO">按编号</asp:ListItem>
                                    <asp:ListItem Value="BarCode">按条码</asp:ListItem>
                                </asp:DropDownList></td>
                            <td>
                                <asp:TextBox ID="tbCon" runat="server" CssClass="pin" Width="160" onkeydown="EnterTextBox(event, this);" ToolTip="输入完成后回车添加"></asp:TextBox>
                            </td>
                            <td style="padding-left:5px;">
                                <input id="btnSltGds" type="button" value="选择产品" class="bt1" onclick="parent.ShowDialog1(800, 520, 'Stock/SltGoods.aspx', '选择产品');"/>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div id="info4">
             <div class="divcon" style="height:286px;">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" RenderMode="Inline">
                <ContentTemplate>
                   <asp:GridView ID="GridView3" runat="server" SkinID="gv4" AutoGenerateColumns="False" OnRowDataBound="GridView3_RowDataBound" Width="70%">
                    <Columns>
                        <asp:BoundField HeaderText="ID" DataField="ID"/>
                        <asp:BoundField HeaderText="序" DataField="ID"/>
                        <asp:BoundField HeaderText="名称" DataField="名称"/>
                        <asp:BoundField HeaderText="仓位" DataField="仓位"/>
                    </Columns>
                   </asp:GridView>
                   <asp:HiddenField ID="hfStockLoc" runat="server" />
                   <asp:HiddenField ID="hfRecID3" runat="server" Value="-1" />
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnDelStkl" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnModStockLoc" EventName="Click" />
                </Triggers>
                </asp:UpdatePanel>
                </div>
                <div class="fbombtn">
                <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                    <td style="padding-left:0px;">
                    <input id="btnStkl" type="button" value="修改" class="bt1" onclick="ModStockLoc();"/>
                    <asp:Button ID="btnDelStkl" runat="server" Text="删除" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnDelStkl_Click"/>
                    </td>
                    </tr>
                </table>
            </div>
          </div>
          <div id="info5" style="padding:3px 0px 0px 3px; overflow:hidden;">
            <div id="div2" class="divinfo" style="height:307px;">
                <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                        <td align="right"><asp:Label ID="lbuserdef1" runat="server" Text="产品自定义1"></asp:Label>：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbuserdef1" runat="server" CssClass="pin" Width="300"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right"><asp:Label ID="lbuserdef2" runat="server" Text="产品自定义2"></asp:Label>：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbuserdef2" runat="server" CssClass="pin" Width="300"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right"><asp:Label ID="lbuserdef3" runat="server" Text="产品自定义3"></asp:Label>：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbuserdef3" runat="server" CssClass="pin" Width="300"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right"><asp:Label ID="lbuserdef4" runat="server" Text="产品自定义4"></asp:Label>：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbuserdef4" runat="server" CssClass="pin" Width="300"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right"><asp:Label ID="lbuserdef5" runat="server" Text="产品自定义5"></asp:Label>：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbuserdef5" runat="server" CssClass="pin" Width="300"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right"><asp:Label ID="lbuserdef6" runat="server" Text="产品自定义6"></asp:Label>：</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbuserdef6" runat="server" CssClass="pin" Width="300"></asp:TextBox></td>
                    </tr>
                </table>
            </div>
            </div>
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="padding-left:5px;color:#0000ff">
                    <asp:CheckBox ID="cbClose" runat="server" Text="保存后关闭窗口" Checked="true" />
                </td>
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="保存" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
                    <input id="btnCls" type="button" value="关闭" class="bt1" onclick="parent.CloseDialog<%=Str_F %>('1');"/>
                </td>
            </tr>
            </table>
         </div>
        </div>
        </div>
        
        <span style="display:none;">
           <asp:Button ID="btnAddUnit" runat="server" Text="AddUnit" OnClick="btnAddUnit_Click" />
           <asp:Button ID="btnShowUnit" runat="server" Text="ShowUnit" OnClick="btnShowUnit_Click" />
           <asp:Button ID="btnModUnit" runat="server" Text="ModUnit" OnClick="btnModUnit_Click" />
           <asp:Button ID="btnSure" runat="server" Text="btnSure" OnClick="btnSure_Click" />
           <asp:Button ID="btnId" runat="server" Text="btnId" OnClick="btnId_Click" />
           <asp:Button ID="btnModStockLoc" runat="server" Text="ModStockLoc" OnClick="btnModStockLoc_Click" />
         </span>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/validator.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/tab.js"></script>
<script language="javascript" type="text/javascript">
var tabnum=6;
var isfocus=1;
var processtip=1;
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
function ChkID(id)
{
    ClrID(id);
    $("btnShowUnit").click();
}

function ChkID2(id)
{
    ClrID2(id);
    $("btnShowDev").click();
}

function ChkID3(id)
{
    ClrBaseID3(id);
    //$("btnShowUnit").click();
}
function ChkAdd()
{
    if(isNull($("tbName").value))
    {
        window.alert("操作失败！产品名称不能为空");
        $("tbName").focus();
        return false
    }
    
    if($("ddlStock").value=="-1")
    {
        ChkTab('1');
        $("ddlStock").focus();
        window.alert("操作失败！默认仓库不能为空");
        return false
    }
    if(!$("cbsys").checked)
    {
        if(isNull($("tbGdsNO").value))
        {
            window.alert("操作失败！产品编号不能为空");
            $("tbGdsNO").focus();
            return false
        }
    }
}

function ChkSysNO()
{
    if(!$("cbsys").checked)
    {
        $("tbGdsNO").disabled=false;
        $("tbGdsNO").focus();
    }else
    {
        $("tbGdsNO").disabled=true;
    }
}

function ChkMain()
{
    if($("ddlAttr").value=="耗材")
        $("lbMain").innerHTML="寿命";
    else
        $("lbMain").innerHTML="保修期";
}

function ChkImg()
{
    $("gdiv").innerHTML="";
    $("hfImgName").value="";
}

function ChkBImg()
{
    if($("hfImgName").value!="")
    {
        parent.ShowDialog1(600, 380, 'Stock/GoodsBImg.aspx', '产品图片');
    }
}

function ChkDelPic()
{
    if($("hfImgName").value!="")
    {
        return confirm("确定要删除该产品图片吗？");
    }
}
//-----------其他信息----------------//
//修改
function ModUnit(w,h,url,title)
{
    if(ChkSlt()!=false)
    {
        var str=document.getElementById("hfMUnit").value;
        parent.ShowDialog1(w,h,url+"?str="+escape(str),title);
    }
}

//修改
function ModDis(w,h,url,title)
{
    if(ChkSlt2()!=false)
    {   
        var str=document.getElementById("hfDisMounting").value;
        parent.ShowDialog1(w,h,url+"?str="+escape(str),title);
    }
}

//修改
function ModStockLoc()
{
    if(ChkSlt3()!=false)
    {   
        var str=document.getElementById("hfStockLoc").value;
        parent.ShowDialog1(300, 93,'Stock/StockLocMod.aspx?f=1&str='+escape(str),'修改仓位');
    }
}
//--------End----------------//

function SltSup()
{
    parent.ShowDialog1(800, 500, 'Customer/SltSup.aspx?f=1&pname=ddlProvider', '选择供应商');
}
</script>
