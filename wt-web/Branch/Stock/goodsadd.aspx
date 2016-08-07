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
                <td class="blue">��Ʒ���ƣ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbName" runat="server" CssClass="pin" Width="230"></asp:TextBox></td>
                <td class="blue">��Ʒ��ţ�</td>
                <td style="padding-left:0px;"><asp:TextBox ID="tbGdsNO" runat="server" CssClass="pin" Enabled="false"></asp:TextBox></td>
                <td class="sysred" style="padding-left:5px;">
                    <asp:CheckBox ID="cbsys" runat="server" Text="ϵͳĬ��" Checked="true" onclick="ChkSysNO();" /></td>
            </tr>
         </table>
        <div class="divh"></div>
        <div id="mytabs">
            <span id="tabs_l1"></span>
            <span id="tabs1" onclick="ChkTab('1');">������Ϣ</span>
            <span id="tabs_r1"></span>
            <span id="tabs_l2"></span>
            <span id="tabs2" onclick="ChkTab('2');">�൥λ</span>
            <span id="tabs_r2"></span>
            <span id="tabs_l3"></span>
            <span id="tabs3" onclick="ChkTab('3');">��װ��ϵ</span>
            <span id="tabs_r3"></span>
            <span id="tabs_l4"></span>
            <span id="tabs4" onclick="ChkTab('4');">�ֿ��б�</span>
            <span id="tabs_r4"></span>
            <span id="tabs_l5"></span>
            <span id="tabs5" onclick="ChkTab('5');">�Զ���</span>
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
                       <td align="right">��Ʒ���</td>
                        <td style="padding-left:0px;">
                            <div class="isinDiv">
                            <input type="text" id="tbGdsClass" runat="server" class="pin pinin" readonly="readonly" />
                                <select id="slGdsClass" runat="server" onchange="getclassvalue('tbGdsClass',this.options[this.selectedIndex].text);" class="pininsl">
                                </select>
                            </div>
                         </td>
                         <td align="right">���ԣ�</td>
                        <td style="padding-left:0px;">
                        <asp:DropDownList ID="ddlAttr" runat="server" CssClass="pindl" onchange="ChkMain();">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem Value="����">����</asp:ListItem>
                            <asp:ListItem Value="����">����</asp:ListItem>
                            <asp:ListItem Value="�Ĳ�">�Ĳ�</asp:ListItem>
                            <asp:ListItem Value="����">����</asp:ListItem>
                            <asp:ListItem Value="����">����</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    </tr>
                    <tr>
                        <td align="right">���</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbSpec" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td align="right">Ʒ�ƣ�</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlBrand" runat="server" onchange="NewProductBrand();" CssClass="pindl">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">��λ��</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlUnit" runat="server" onchange="NewUnit();" CssClass="pindl">
                            </asp:DropDownList>
                        </td>
                        <td align="right">���ۼۣ�</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbPriceDetail" runat="server" CssClass="pin" old="" onblur="ChkMoney(this);"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">�����ۣ�</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbPriceCost" runat="server" CssClass="pin" old="" onblur="ChkMoney(this);"></asp:TextBox>
                        </td>
                        <td align="right">�ڲ��ۣ�</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbPriceInner" runat="server" CssClass="pin" old="" onblur="ChkMoney(this);"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">�ɻ��ۣ�</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbPriceWholeSale1" runat="server" CssClass="pin" old="" onblur="ChkMoney(this);"></asp:TextBox></td>
                        <td align="right">����ۣ�</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbPriceWholeSale2" runat="server" CssClass="pin" old="" onblur="ChkMoney(this);"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right">�б�ۣ�</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbPriceWholeSale3" runat="server" CssClass="pin" old="" onblur="ChkMoney(this);"></asp:TextBox></td>
                        <td align="right"><asp:Label ID="lbMain" runat="server" Text="������"></asp:Label>��</td>
                        <td style="padding-left:0px;">
                            <div class="isinDiv">
                            <input type="text" id="tbProt" runat="server" class="pin pinin" />
                                <select id="slProt" onchange="document.getElementById('tbProt').value=this.options[this.selectedIndex].value" class="pininsl">
                                    <option value="" selected="selected"></option>
                                    <option value="�ޱ���">�ޱ���</option>
                                    <option value="һ����">һ����</option>
                                    <option value="������">������</option>
                                    <option value="������">������</option>
                                    <option value="һ��">һ��</option>
                                    <option value="����">����</option>
                                    <option value="����">����</option>
                                    <option value="����">����</option>
                                    <option value="����">����</option>
                                </select>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">���룺</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbBarCode" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td align="right" class="red">�ɱ�ģʽ��</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlCostMode" runat="server" CssClass="pindl">
                                <asp:ListItem Value="2">�ƶ���Ȩƽ����</asp:ListItem>
                                <asp:ListItem Value="1">�Ƚ��ȳ���</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">���ò�Ʒ��</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbForProducts" runat="server" CssClass="pin"></asp:TextBox></td>
                        <td align="right" class="red">Ĭ�ϲֿ⣺</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlStock" runat="server" CssClass="pindl" onchange="NewStock();">
                        </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">��Ӧ�̣�</td>
                        <td style="padding-left:0px;">
                            <asp:DropDownList ID="ddlProvider" runat="server" CssClass="pindl" onchange="NewSupplier();">
                            </asp:DropDownList>
                        </td>
                        <td align="right">��Ч�ڣ�</td>
                        <td style="padding-left:0px;">
                            <asp:TextBox ID="tbValid" runat="server" CssClass="pin" Width="110" ToolTip="��" onblur="ValidateNums(this);"></asp:TextBox>
                            <span class="red">��</span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">��ע��</td>
                        <td colspan="3" style="padding-left:0px;">
                             <asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="341"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right"></td>
                        <td colspan="3" style="padding-left:0px;">
                             <asp:CheckBox ID="cbIncrement" runat="server" Text="" /> ��ֵ��Ʒ
                             <asp:CheckBox ID="cbSNTrack" runat="server" Text="" /> ���кŸ���
                             <asp:CheckBox ID="cbStock" runat="server" Text="" /> �������
                             <asp:CheckBox ID="cbStop" runat="server" /> <span class="sysred">ͣ�ñ�־</span>
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
                            <input id="btnImg" type="button" runat="server" class="img" onclick="parent.ShowDialog1(600, 380, 'Stock/GoodsImg.aspx', '��ƷͼƬ');" title="�ϴ���ƷͼƬ" />
                            <input id="btnView" type="button" class="view" onclick="ChkBImg();" title="�Ŵ�ͼƬ" />
                            <asp:Button ID="btnImgDel" runat="server" CssClass="del" UseSubmitBehavior="false" OnClientClick="if(ChkDelPic()==false)return false;" OnClick="btnImgDel_Click" ToolTip="ɾ��ͼƬ"/>
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
                            <asp:BoundField HeaderText="��λ����" DataField="����"/>
                            <asp:BoundField HeaderText="��λ��ϵ" DataField="��ϵ"/>
                            <asp:BoundField HeaderText="����" DataField="����"/>
                            <asp:BoundField HeaderText="���ۼ�" DataField="���ۼ�"/>
                            <asp:BoundField HeaderText="������" DataField="������"/>
                            <asp:BoundField HeaderText="�ڲ���" DataField="�ڲ���"/>
                            <asp:BoundField HeaderText="�ɻ���" DataField="�ɻ���"/>
                            <asp:BoundField HeaderText="�����" DataField="�����"/>
                            <asp:BoundField HeaderText="�б��" DataField="�б��"/>
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
                    <input id="btnNewUnit" type="button" value="�½�" class="bt1" onclick="parent.ShowDialog1(480, 205, 'Stock/UnitAdd.aspx', '�½���Ʒ��λ');"/>
                    <input id="btnEditUnit" type="button" value="�޸�" class="bt1" onclick="ModUnit(480, 205,'Stock/UnitMod.aspx','�޸Ĳ�Ʒ��λ');"/>
                    <asp:Button ID="btnDelUnit" runat="server" Text="ɾ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnDelUnit_Click"/>
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
                        <asp:BoundField HeaderText="���" DataField="���"/>
                        <asp:BoundField HeaderText="����" DataField="����"/>
                        <asp:BoundField HeaderText="����" DataField="����"/>
                        <asp:BoundField HeaderText="���" DataField="���"/>
                        <asp:BoundField HeaderText="Ʒ��" DataField="Ʒ��"/>
                        <asp:BoundField HeaderText="������" DataField="������"/>
                        <asp:TemplateField HeaderText="��������">
                            <ItemTemplate>
                                <asp:TextBox ID="tbQty" runat="server" Text='<%# Eval("��������") %>' Width="100"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ɾ��">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbDel" TabIndex="-1" runat="server" CausesValidation="False"  CommandName="Delete" Text="ɾ��" style="color:#0000ff;"></asp:LinkButton>
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
                                    <asp:ListItem Value="GoodsNO">�����</asp:ListItem>
                                    <asp:ListItem Value="BarCode">������</asp:ListItem>
                                </asp:DropDownList></td>
                            <td>
                                <asp:TextBox ID="tbCon" runat="server" CssClass="pin" Width="160" onkeydown="EnterTextBox(event, this);" ToolTip="������ɺ�س����"></asp:TextBox>
                            </td>
                            <td style="padding-left:5px;">
                                <input id="btnSltGds" type="button" value="ѡ���Ʒ" class="bt1" onclick="parent.ShowDialog1(800, 520, 'Stock/SltGoods.aspx', 'ѡ���Ʒ');"/>
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
                        <asp:BoundField HeaderText="��" DataField="ID"/>
                        <asp:BoundField HeaderText="����" DataField="����"/>
                        <asp:BoundField HeaderText="��λ" DataField="��λ"/>
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
                    <input id="btnStkl" type="button" value="�޸�" class="bt1" onclick="ModStockLoc();"/>
                    <asp:Button ID="btnDelStkl" runat="server" Text="ɾ��" CssClass="bt1" UseSubmitBehavior="false" OnClick="btnDelStkl_Click"/>
                    </td>
                    </tr>
                </table>
            </div>
          </div>
          <div id="info5" style="padding:3px 0px 0px 3px; overflow:hidden;">
            <div id="div2" class="divinfo" style="height:307px;">
                <table cellpadding="0" cellspacing="0" class="tb3">
                    <tr>
                        <td align="right"><asp:Label ID="lbuserdef1" runat="server" Text="��Ʒ�Զ���1"></asp:Label>��</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbuserdef1" runat="server" CssClass="pin" Width="300"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right"><asp:Label ID="lbuserdef2" runat="server" Text="��Ʒ�Զ���2"></asp:Label>��</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbuserdef2" runat="server" CssClass="pin" Width="300"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right"><asp:Label ID="lbuserdef3" runat="server" Text="��Ʒ�Զ���3"></asp:Label>��</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbuserdef3" runat="server" CssClass="pin" Width="300"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right"><asp:Label ID="lbuserdef4" runat="server" Text="��Ʒ�Զ���4"></asp:Label>��</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbuserdef4" runat="server" CssClass="pin" Width="300"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right"><asp:Label ID="lbuserdef5" runat="server" Text="��Ʒ�Զ���5"></asp:Label>��</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbuserdef5" runat="server" CssClass="pin" Width="300"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="right"><asp:Label ID="lbuserdef6" runat="server" Text="��Ʒ�Զ���6"></asp:Label>��</td>
                        <td style="padding-left:0px;"><asp:TextBox ID="tbuserdef6" runat="server" CssClass="pin" Width="300"></asp:TextBox></td>
                    </tr>
                </table>
            </div>
            </div>
            <div class="divh"></div>
            <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="padding-left:5px;color:#0000ff">
                    <asp:CheckBox ID="cbClose" runat="server" Text="�����رմ���" Checked="true" />
                </td>
                <td align="right">
                    <asp:Button ID="btnAdd" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkAdd()==false)return false;" OnClick="btnAdd_Click"/>
                    <input id="btnCls" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog<%=Str_F %>('1');"/>
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
        window.alert("����ʧ�ܣ���Ʒ���Ʋ���Ϊ��");
        $("tbName").focus();
        return false
    }
    
    if($("ddlStock").value=="-1")
    {
        ChkTab('1');
        $("ddlStock").focus();
        window.alert("����ʧ�ܣ�Ĭ�ϲֿⲻ��Ϊ��");
        return false
    }
    if(!$("cbsys").checked)
    {
        if(isNull($("tbGdsNO").value))
        {
            window.alert("����ʧ�ܣ���Ʒ��Ų���Ϊ��");
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
    if($("ddlAttr").value=="�Ĳ�")
        $("lbMain").innerHTML="����";
    else
        $("lbMain").innerHTML="������";
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
        parent.ShowDialog1(600, 380, 'Stock/GoodsBImg.aspx', '��ƷͼƬ');
    }
}

function ChkDelPic()
{
    if($("hfImgName").value!="")
    {
        return confirm("ȷ��Ҫɾ���ò�ƷͼƬ��");
    }
}
//-----------������Ϣ----------------//
//�޸�
function ModUnit(w,h,url,title)
{
    if(ChkSlt()!=false)
    {
        var str=document.getElementById("hfMUnit").value;
        parent.ShowDialog1(w,h,url+"?str="+escape(str),title);
    }
}

//�޸�
function ModDis(w,h,url,title)
{
    if(ChkSlt2()!=false)
    {   
        var str=document.getElementById("hfDisMounting").value;
        parent.ShowDialog1(w,h,url+"?str="+escape(str),title);
    }
}

//�޸�
function ModStockLoc()
{
    if(ChkSlt3()!=false)
    {   
        var str=document.getElementById("hfStockLoc").value;
        parent.ShowDialog1(300, 93,'Stock/StockLocMod.aspx?f=1&str='+escape(str),'�޸Ĳ�λ');
    }
}
//--------End----------------//

function SltSup()
{
    parent.ShowDialog1(800, 500, 'Customer/SltSup.aspx?f=1&pname=ddlProvider', 'ѡ��Ӧ��');
}
</script>
