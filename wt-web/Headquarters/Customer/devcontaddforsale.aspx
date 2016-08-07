<%@ page language="C#"  CodeFile="devcontaddforsale.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Customer_DevContAddForSale" theme="Themes" enableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../../Public/Style/winsub.css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="main">
    <div class="maincon">
    <div id="sa" style="width:806px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" RenderMode="Inline">
        <ContentTemplate>
        <div class="fdivs">
        <div class="sdivs"  style="padding:3px 0 3px 0px; width:802px;">
        <table cellpadding="0" cellspacing="0" class="tb1">
            <tr>
                <td align="right">��ͬ��ţ�</td>
                <td style="padding-left:0px;">
                <asp:TextBox ID="tbContract" runat="server" CssClass="pin3" ></asp:TextBox>
                </td>
                <td align="right">ǩԼ���ڣ�</td>
                <td style="padding-left:0px;">
                <asp:TextBox ID="tbDate" runat="server" CssClass="Wdate3" onfocus="WdatePicker()"></asp:TextBox>
                </td>
                <td align="right" colspan="2">
                ҵ��Ա��</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl3">
                    </asp:DropDownList>
                </td>
                <td align="right">
                ��ͬ���</td>
                <td style="padding-left:0px;">
                    <asp:DropDownList ID="ddlType" runat="server" CssClass="pindl3">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
            <td class="sysred" align="right">�ͻ����ƣ�</td>
            <td style="padding-left:0px;" colspan="3">
                <div class="isinDiv">
                <asp:TextBox ID="tbCusName" runat="server" CssClass="pin autot" Width="311" onmousedown="getSearchResult('../Customer/SchCusList.aspx','tbCusName','hfCusID','1','btnCusInfo',event);" onkeyup="getSearchResult('../Customer/SchCusList.aspx','tbCusName','hfCusID','1','btnCusInfo',event);" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
            </td>
            <td style="padding:0px;"><input id="btnSlt" type="button" value="" onclick="SltCus();" class="bview"/></td>
            <td align="right">
            ��ϵ�ˣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin3"></asp:TextBox></td>
            <td align="right">
            ��ϵ�绰��</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin3"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right">��ַ��</td>
            <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin3" Width="311"></asp:TextBox></td>
            <td colspan="4">
                <a href="#" onclick="ViewCus();">>>��ϸ��Ϣ</a>
                <a href="#" onclick="ViewHistory();">>>�����ʷ</a>
            </td>
        </tr>
            <tr>
                <td align="right">��ʼ���ڣ�</td>
                <td style="padding-left:0px;">
                <asp:TextBox ID="tbStartDate" runat="server" CssClass="Wdate3" onfocus="WdatePicker()"></asp:TextBox>
                </td>
                <td align="right">
                ��ֹ���ڣ�</td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbEndDate" runat="server" CssClass="Wdate3" onfocus="WdatePicker()"></asp:TextBox>
                </td>
                <td align="right" colspan="2"></td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbAmount1" runat="server" CssClass="pin3" style="display:none;"></asp:TextBox>
                </td>
                <td align="right" class="sysred">
                </td>
                <td style="padding-left:0px;">
                    <asp:TextBox ID="tbInCash" runat="server" CssClass="pin3" style="display:none;" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">��ͬ���</td>
                <td style="padding-left:0px; height:46px;" colspan="3">
                <asp:TextBox ID="tbSummary" runat="server" CssClass="pin3" Width="311" Height="32" TextMode="MultiLine" ></asp:TextBox>
                </td>
                <td align="right" colspan="2">��ע��</td>
                <td style="padding-left:0px; height:46px;" colspan="3">
                <asp:TextBox ID="tbRemark" runat="server" CssClass="pin3" Width="311" Height="32" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">��ͬ������</td>
                <td style="padding-left:0px;">
                   <a href="#" style="color:#0000ff" title="�ϴ���ͬ����" onclick="ChkUpload();">�ϴ���ͬ����</a>
                </td>
                <td style="padding-left:0px;" colspan="6">
                <div id="dUpload"></div>
                <asp:HiddenField ID="hfUpload" runat="server" />
                </td>
            </tr>
       </table>
        
        </div>
        </div>
      </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnCusInfo" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    <div class="divh"></div>
       <div id="cndiv" style="height:200px;">
        <div id="fdiv" class="fdiv">
            <div id="sdiv" class="sdiv">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvdata_RowDataBound" OnRowDeleting="gvdata_RowDeleting">
                        <Columns>
                        <asp:BoundField HeaderText="ID" DataField="GoodsID" />
                        <asp:BoundField HeaderText="UnitID" DataField="UnitID" />
                        <asp:BoundField HeaderText="��" />
                        <asp:BoundField HeaderText="��Ʒ���" DataField="GoodsNO" />
                        <asp:BoundField HeaderText="����" DataField="_Name" />
                        <asp:BoundField HeaderText="���" DataField="Spec" />
                        <asp:BoundField HeaderText="Ʒ��" DataField="ProductBrand" />
                        <asp:BoundField HeaderText="��λ" DataField="Unit" />
                        <asp:TemplateField HeaderText="����">
                            <ItemTemplate>
                                <asp:TextBox ID="tbQty" runat="server" Text='<%# Eval("Qty") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="����">
                            <ItemTemplate>
                                <asp:TextBox ID="tbPrice" runat="server" Text='<%# Eval("Price") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�ۿ�">
                            <ItemTemplate>
                                <asp:TextBox ID="tbDis" runat="server" Text='<%# Eval("Dis") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���">
                            <ItemTemplate>
                                <asp:Label ID="lbAmount" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="˰��">
                            <ItemTemplate>
                                <asp:TextBox ID="tbTaxRate" runat="server" Text='<%# Eval("TaxRate") %>' CssClass="tbstyle" onfocus="select();"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="˰��">
                            <ItemTemplate>
                                <asp:Label ID="lbTaxAmount" runat="server" Text='<%# Eval("TaxAmount") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="��˰�ϼ�">
                            <ItemTemplate>
                                <asp:Label ID="lbGoodsAmount" runat="server" Text='<%# Eval("GoodsAmount") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="MainTenancePeriod" HeaderText="������" />
                        <asp:TemplateField HeaderText="��ע">
                            <ItemTemplate>
                                <asp:TextBox ID="tbRemark" runat="server" CssClass="tbstyle" Text='<%# Eval("Remark") %>' Width="200" onfocus="select();"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ɾ��">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbDel" TabIndex="-1" runat="server" CausesValidation="False"  CommandName="Delete" Text="ɾ��" style="color:#0000ff;"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:HiddenField ID="hfRecID" runat="server" Value="-1" />
                    <asp:HiddenField ID="hfreclist" runat="server" />
                    <asp:HiddenField ID="hfRecIDs" runat="server" Value="-1" />
                    <asp:HiddenField ID="hfName" runat="server" />
                    <asp:HiddenField ID="hfUnitID" runat="server" />
                    <asp:HiddenField ID="hfCusID" runat="server" />
                    <asp:HiddenField ID="hfPrintID" runat="server" />
                     <span style="display:none;">
                     <asp:Button ID="btnId" runat="server" Text="..." OnClick="btnId_Click" />
                     <asp:Button ID="btnSure" runat="server" Text="..." OnClick="btnSure_Click" />
                     <asp:Button ID="btnCusInfo" runat="server" Text="..."  OnClick="btnCusInfo_Click"/>
                     </span>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
                </Triggers>
             </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div class="divh"></div>
    <div class="tdiv">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <table cellpadding="0" cellspacing="0" class="tb3">
        <tr>
            <td style="padding-left:15px;">
                <asp:DropDownList ID="ddlSchFld" runat="server" CssClass="pindl" Width="70">
                    <asp:ListItem Value="BarCode">������</asp:ListItem>
                    <asp:ListItem Value="GoodsNO">�����</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td><asp:TextBox ID="tbCon" runat="server" CssClass="pin" onkeydown="EnterTextBox(event, this);" ToolTip="������ɺ�س����"></asp:TextBox></td>
            <td><input id="tbSltGoods" type="button" value="ѡ���Ʒ" class="bt1" onclick="parent.ShowDialog1(800, 520, 'Stock/SltGoods.aspx', 'ѡ���Ʒ');" /></td>
            <td style="padding-left:10px;">�ϼ�������</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbAQty" runat="server" CssClass="pinbr" ReadOnly="true" Width="100"></asp:TextBox></td>
            <td style="padding-left:10px;">�ϼƽ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbAmount" runat="server" CssClass="pinbr" ReadOnly="true" Width="100"></asp:TextBox></td>
            <td style="padding-left:10px;">��˰�ϼƣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbGoodsAmount" runat="server" CssClass="pinbr" ReadOnly="true" Width="100"></asp:TextBox></td>
        </tr>
    </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnClean" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnId" EventName="Click" />
        <asp:AsyncPostBackTrigger ControlID="btnSure" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    
    <div class="ftool">
    <table cellpadding="0" cellspacing="0" class="tb2" width="100%">
        <tr>
            <td><span class="si1">���ֹ������Ż����룬������ɺ�س�</span></td>
            <td align="right" style="padding-right:20px;">
                <asp:Button ID="btnAdd" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;"  OnClick="btnAdd_Click"/>
                <asp:Button ID="btnClean" runat="server" Text="���" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkClean()==false)return false;" OnClick="btnClean_Click"/>
                <input id="btnCls" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog();" />
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
<script language="javascript" type="text/javascript">
var processtip=1;
function ChkSave()
{
    if(isNull($("tbContract").value))
    {
        window.alert("����ʧ�ܣ���ͬ��Ų���Ϊ��");
        $("tbContract").focus();
        return false
    }
    
    if(isNull($("tbDate").value))
    {
        window.alert("����ʧ�ܣ�ǩԼ���ڲ���Ϊ��");
        $("tbDate").focus();
        return false
    }
    
   if($("ddlOperator").value=="-1")
    {
        window.alert("����ʧ�ܣ�ҵ��Ա����Ϊ��");
        $("ddlOperator").focus();
        return false
    }
     if($("ddlType").value=="-1")
    {
        window.alert("����ʧ�ܣ���ͬ�����Ϊ��");
        $("ddlType").focus();
        return false
    }
    
//    if(isNull($("tbAmount").value))
//    {
//        window.alert("����ʧ�ܣ�����Ϊ��");
//        $("tbAmount").focus();
//        return false
//    }
//    if(!isMoney($("tbAmount").value))
//    {
//        window.alert("����ʽ����ȷ");
//        $("tbAmount").focus();
//        return false
//    }
    
    if(isNull($("tbStartDate").value))
    {
        window.alert("����ʧ�ܣ���ʼ���ڲ���Ϊ��");
        $("tbStartDate").focus();
        return false
    }
    
    if(isNull($("tbEndDate").value))
    {
        window.alert("����ʧ�ܣ���ֹ���ڲ���Ϊ��");
        $("tbEndDate").focus();
        return false
    }
    
}

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

function ChkUpload()
{   
    if($("dUpload").innerHTML=="")
    {
        parent.ShowDialog1(600, 380, 'Customer/DocUpload.aspx', '�ϴ���ͬ����');
    }
    else
    {
        if(confirm("�Ѿ�����һ����ͬ�����������ϴ����滻�ø������Ƿ������"))
        {
            parent.ShowDialog1(600, 380, 'Customer/DocUpload.aspx', '�ϴ���ͬ����');   
        }
    }
}

function SltCus()
{
    parent.ShowDialog1(800, 500, 'Lease/SltCus.aspx?f=2&strname='+escape($("tbCusName").value), 'ѡ��ͻ�');
}

function SltDev()
{
    parent.ShowDialog1(800, 500, 'Customer/SltDev.aspx?x=1&f=1&strname='+escape($("tbCusName").value)+'&cid='+$("hfCusID").value, 'ѡ���������');
}

function ViewCus()
{
    var cusid=$("hfCusID").value;
    if(cusid=="")
    {
        //�½��ͻ�
        parent.ShowDialog1(600, 450, '../Headquarters/Customer/CusAdd.aspx?f=1', '�½��ͻ�');
    }
    else
    {
        //�޸Ŀͻ�
        parent.ShowDialog1(600, 450, '../Headquarters/Customer/CusMod.aspx?f=1&id=' + cusid, '�ͻ���Ϣ');
    }
}

function ViewHistory()
{
    var cusid=$("hfCusID").value;
    if(cusid=="")
    {
        alert("��ѡ��ͻ���鿴��");
        return false;
    }
    parent.ShowDialog1(800, 520, '../Headquarters/Customer/CusHistory.aspx?f=1&cusid='+cusid, '���ҵ��');
}

function onClientClick(selectedId,id)
{
    var inputs = document.getElementById("<%=gvdata.ClientID%>").getElementsByTagName("input");
    for(var i=0; i <inputs.length; i++)
    {
        if(inputs[i].type=="radio")
        {
            if(inputs[i].id==selectedId)
                inputs[i].checked = true;
            else
                inputs[i].checked = false;
           
        }
    }
    $("hfRecID").value=id;
}
</script>
