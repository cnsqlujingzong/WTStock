<%@ page language="C#"  CodeFile="leasemod.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Lease_LeaseMod" theme="Themes" enableEventValidation="false" %>
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
    <div id="sad" style="width:786px;">
    <div class="fdivs">
    <div class="sdivs" style="padding:3px 0 3px 0px; overflow:hidden;">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
        <table cellpadding="0" cellspacing="0" class="tb4">
            <tr>
            <td>ҵ�񵥺ţ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbBillID" runat="server" CssClass="pinb" ReadOnly="true" Width="115"></asp:TextBox></td>
            <td align="right">���ڣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbDate" runat="server" CssClass="Wdate" Width="117" onfocus="WdatePicker()"></asp:TextBox></td>
            <td align="right">ҵ��Ա��</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlOperator" runat="server" CssClass="pindl" Width="121">
                </asp:DropDownList>
            </td>
            <td class="sysred" align="right">ҵ�����</td>
            <td style="padding-left:0px;">
                <asp:DropDownList ID="ddlType" runat="server" CssClass="pindl" Width="106" OnSelectedIndexChanged="ddlType_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Value="1">����������</asp:ListItem>
                    <asp:ListItem Value="2">�ǳ���������</asp:ListItem>
                    <asp:ListItem Value="3">ȫ��</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="sysred" align="right">�ͻ����ƣ�</td>
            <td colspan="3" style="padding-left:0px;">
                <div class="isinDiv">
                    <asp:TextBox ID="tbCusName" runat="server" CssClass="pin autot" Width="306" onmousedown="getSearchResult('../Customer/SchCusList.aspx','tbCusName','hfCusID','1','btnCusInfo',event);" onkeyup="getSearchResult('../Customer/SchCusList.aspx','tbCusName','hfCusID','1','btnCusInfo',event);" AutoCompleteType="Disabled"></asp:TextBox>
                </div>
            </td>
            <td align="right">
            ��ϵ�ˣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbLinkMan" runat="server" CssClass="pin" Width="115"></asp:TextBox></td>
            <td class="sysred" align="right">
            ��ϵ�绰��</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbTel" runat="server" CssClass="pin" Width="99"></asp:TextBox></td>
        </tr>
        <tr>
            <td align="right">��ַ��</td>
            <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbAdr" runat="server" CssClass="pin" Width="306"></asp:TextBox></td>
            <td colspan="5">
                <a href="#" onclick="ViewCus();">>>��ϸ��Ϣ</a>
                <a href="#" onclick="ViewHistory();">>>�����ʷ</a>
            </td>
        </tr>
        <tr>
            <td align="right">��ͬ��ţ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbAutoNO" runat="server" CssClass="pin" Width="115"></asp:TextBox></td>
            <td align="right">��ʼ���ڣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbStartDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="117"></asp:TextBox></td>
            <td align="right">��ֹ���ڣ�</td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbEndDate" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="117"></asp:TextBox></td>
            <td align="right">�������ڣ�</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbChargeCycle" runat="server" CssClass="pin" Width="99"></asp:TextBox>
            </td>
            
        </tr>
        <tr>
            <td align="right"><asp:Label ID="lbRent" runat="server" Text="�������⣺"></asp:Label></td>
            <td style="padding-left:0px;"><asp:TextBox ID="tbRent" runat="server" CssClass="pin" Width="115"></asp:TextBox></td>
            <td align="right">Ѻ��</td>
            <td style="padding-left:0px;">
                <asp:TextBox ID="tbDeposit" runat="server" CssClass="pin" Width="115"></asp:TextBox>
            </td>
            <td align="right">��ע��</td>
            <td colspan="3" style="padding-left:0px;"><asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Width="290"></asp:TextBox></td>
        </tr>
        <tr>
             <td style="padding-left:0px;" align="right">
                <a href="#" onclick="ChkUpload();">�ϴ�����</a>
            </td>
            <td style="padding-left:0px;" colspan="6">
                <div id="dUpload" runat="server"></div>
            </td>
            <td>
                <asp:HiddenField ID="hfPath" runat="server" />
                <asp:HiddenField ID="hfCusID" runat="server" />
                <asp:HiddenField ID="hfPrintID" runat="server" />
                <span style="display:none;">
                    <asp:DropDownList ID="ddlStock" runat="server">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlBrand" runat="server">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlClass" runat="server">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlModel" runat="server">
                    </asp:DropDownList>
                    <asp:Button ID="btnCusInfo" runat="server" Text="..."  OnClick="btnCusInfo_Click"/>
                </span>
            </td>
        </tr>
     </table>
     </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="ddlType" EventName="SelectedIndexChanged" />
        </Triggers>
     </asp:UpdatePanel>
    </div>
    </div>
    <div class="divh"></div>
    <div id="cndiv" style="height:198px;">
        <div class="fdivs" style="height:196px;">
            <div class="sdivs" style="height:194px;background:#ffffff;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="gvdata" runat="server" AutoGenerateColumns="false" SkinID="gv3" OnRowDataBound="gvdata_RowDataBound" OnRowDeleting="gvdata_RowDeleting">
                        <Columns>
                        <asp:BoundField HeaderText="��" />
                        <asp:TemplateField HeaderText="�ֿ�">
                            <ItemTemplate>
                                <asp:TextBox ID="tbStock" runat="server" Text='<%# Eval("Stock") %>' style="display:none;"></asp:TextBox>
                                <asp:DropDownList ID="ddlStock" runat="server" CssClass="pindl" Width="80">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="���޻���" DataField="GoodsNO" />
                        <asp:TemplateField HeaderText="����">
                            <ItemTemplate>
                                <asp:TextBox ID="tbCount" runat="server" CssClass="pin" Width="80" Text='<%# Eval("iCount") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�������">
                            <ItemTemplate>
                                <asp:TextBox ID="tbPrice" runat="server" CssClass="pin" Width="80" Text='<%# Eval("dPrice") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���">
                            <ItemTemplate>
                                <asp:Label ID="tbTotal" runat="server" CssClass="pin" Width="80" Text='<%# Eval("dTotal") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�������">
                            <ItemTemplate>
                                <asp:TextBox ID="tbDeviceNO" runat="server" CssClass="pin" Width="80" Text='<%# Eval("DeviceNO") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="����Ʒ��">
                            <ItemTemplate>
                                <asp:TextBox ID="tbBrand" runat="server" Text='<%# Eval("Brand") %>' ></asp:TextBox>
                                <asp:DropDownList ID="ddlBrand" runat="server" CssClass="pindl" Width="80" style="display:none;">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���">
                            <ItemTemplate>
                                <asp:TextBox ID="tbClass" runat="server" Text='<%# Eval("Class") %>' ></asp:TextBox>
                                <asp:DropDownList ID="ddlClass" runat="server" CssClass="pindl" Width="80" style="display:none;">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="�ͺ�">
                            <ItemTemplate>
                                <asp:TextBox ID="tbModel" runat="server" Text='<%# Eval("Model") %>' ></asp:TextBox>
                                <asp:DropDownList ID="ddlModel" runat="server" CssClass="pindl" Width="120" style="display:none;">
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���к�">
                            <ItemTemplate>
                                <asp:TextBox ID="tbSN1" runat="server" CssClass="pin" Width="80" Text='<%# Eval("SN1") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="������">
                            <ItemTemplate>
                                <asp:TextBox ID="tbstrQty" runat="server" style="display:none;" Text='<%# Eval("strQty") %>'></asp:TextBox>
                                <asp:HyperLink ID="hlstrQty" runat="server" NavigateUrl="#d" ToolTip="�༭������">�༭������</asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="���к�2">
                            <ItemTemplate>
                                <asp:TextBox ID="tbSN2" runat="server" CssClass="pin" Width="80" Text='<%# Eval("SN2") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="��ע">
                            <ItemTemplate>
                                <asp:TextBox ID="tbRemark" runat="server" CssClass="pin" Text='<%# Eval("Remark") %>' Width="160"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ɾ��">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbDel" TabIndex="-1" runat="server" CausesValidation="False"  CommandName="Delete" Text="ɾ��" style="color:#0000ff;"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <asp:HiddenField ID="hfreclist" runat="server" />
                    <asp:HiddenField ID="hfdellist" runat="server" />
                    <asp:HiddenField ID="hfSltID" runat="server" />
                     <span style="display:none;">
                         <asp:Button ID="btnId" runat="server" Text="..." OnClick="btnId_Click" />
                         <asp:Button ID="btnSure" runat="server" Text="..." OnClick="btnSure_Click" />
                         <asp:Button ID="btnsngetgds" runat="server" Text="..." OnClick="btnsngetgds_Click" />
                         <asp:Button ID="btnSltBill" runat="server" Text="..." OnClick="btnSltBill_Click" />
                     </span>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="btnSltBill" EventName="Click" />
                    <asp:AsyncPostBackTrigger ControlID="ddlType" EventName="SelectedIndexChanged" />
                </Triggers>
             </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <div class="tdiv">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <table cellpadding="0" cellspacing="0" class="tb4">
        <tr>
            <td style="padding-left:15px;">
                <asp:DropDownList ID="ddlSchFld" runat="server" CssClass="pindl" Width="70">
                    <asp:ListItem Value="SN">�����к�</asp:ListItem>
                    <asp:ListItem Value="BarCode">������</asp:ListItem>
                    <asp:ListItem Value="GoodsNO">�����</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td><asp:TextBox ID="tbCon" runat="server" CssClass="pin" onkeydown="EnterTextBox(event, this);" ToolTip="������ɺ�س����"></asp:TextBox></td>
            <td><input id="tbSltGoods" type="button" value="ѡ���Ʒ" class="bt1" onclick="parent.ShowDialog1(800, 520, 'Stock/SltGoods.aspx', 'ѡ���Ʒ');" /></td>
            <td><input id="btnSltSN" type="button" value="ѡ��SN" class="bt1" onclick="parent.ShowDialog1(800, 520, 'Stock/SltSN.aspx?ff=1', 'ѡ�����к�');" /></td>
            <td><input id="btnLease" type="button" value="��ʷҵ��" class="bt1" onclick="parent.ShowDialog1(800, 520, 'Lease/SltLease.aspx', 'ѡ����ʷҵ��');" /></td>
        </tr>
    </table>
    </ContentTemplate>
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    
    <asp:HiddenField ID="hfClass" runat="server" Value="-1" />
    <asp:HiddenField ID="hfBrand" runat="server" Value="-1" />
    <asp:HiddenField ID="hfModel" runat="server" Value="-1" />
    
    <div class="divh"></div>
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:Label ID="lbMod" runat="server"></asp:Label>
            </td>
            <td align="right">
                <asp:Button ID="btnAdd" runat="server" Text="����" CssClass="bt1" UseSubmitBehavior="false" OnClientClick="if(ChkSave()==false)return false;"  OnClick="btnAdd_Click"/>
                <input id="btnPrint" runat="server" type="button" value="��ӡ" class="bt1" onclick="ChkPrint('ZLD');" />
                <input id="btnClose" type="button" value="�ر�" class="bt1" onclick="parent.CloseDialog<%=Str_F %>();" />
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
<script language="javascript" type="text/javascript" src="../../Public/Script/AutoSchCon.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/AutoSchCon1.js"></script>
<script language="javascript" type="text/javascript">
function ChkID(id)
{
    ClrID(id);
}
function ChkSave()
{
    if(isNull($("tbDate").value))
    {
        window.alert("����ʧ�ܣ����ڲ���Ϊ��");
        $("tbDate").focus();
        return false
    }
    
    if($("ddlOperator").value=="-1")
    {
        window.alert("����ʧ�ܣ�ҵ��Ա����Ϊ��");
        $("ddlOperator").focus();
        return false
    }
    if(isNull($("tbCusName").value))
    {
        window.alert("����ʧ�ܣ��ͻ����Ʋ���Ϊ��");
        $("tbCusName").focus();
        return false
    }

    if(isNull($("tbTel").value))
    {
        window.alert("����ʧ�ܣ���ϵ�绰����Ϊ��");
        $("tbTel").focus();
        return false
    }
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
    if(isNull($("tbRent").value))
    {
        window.alert("����ʧ�ܣ��������ⲻ��Ϊ��");
        $("tbRent").focus();
        return false
    }
    if(isNull($("tbDeposit").value))
    {
        window.alert("����ʧ�ܣ�Ѻ����Ϊ��");
        $("tbDeposit").focus();
        return false
    }
    if(!isMoney($("tbRent").value))
    {
        window.alert("���������ʽ����ȷ");
        $("tbRent").focus();
        return false
    }
    if(!isMoney($("tbDeposit").value))
    {
        window.alert("Ѻ���ʽ����ȷ");
        $("tbDeposit").focus();
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
        parent.ShowDialog1(600, 380, 'Lease/UpLoad.aspx', '�ϴ���ͬ����');
    }
    else
    {
        if(confirm("�Ѿ�����һ�������������ϴ����滻�ø������Ƿ������"))
        {
            parent.ShowDialog1(600, 380, 'Lease/UpLoad.aspx', '�ϴ���ͬ����');
        }
    }
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
        parent.ShowDialog1(600, 450, '../Headquarters/Customer/CusMod.aspx?f=1&id='+cusid, '�ͻ���Ϣ');
    }
}
function EditQty(tbqty)
{
    if(location.href.indexOf('&f=2&')>0)
        parent.ShowDialog3(600, 380, 'Lease/EditQty.aspx?f=3&fid=iframeDialog2&ff=1&tbqty='+tbqty+'&qtyvalue='+escape($(tbqty).value), '�༭������');
    else
        parent.ShowDialog1(600, 380, 'Lease/EditQty.aspx?ff=1&tbqty='+tbqty+'&qtyvalue='+escape($(tbqty).value), '�༭������');
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
function calcAmountByPrice(obj,tbcount,lbrent)
{
    var price = parseFloat(obj.value);
    var count = parseInt(document.getElementById(tbcount).value);
    
    if(obj.value !="" && document.getElementById(tbcount).value != "")
    {
        document.getElementById(lbrent).innerHTML = price * count;
    }
}
function calcAmountByCount(obj,tbprice,lbrent)
{
    var price = parseFloat(document.getElementById(tbprice).value);
    var count = parseInt(obj.value);
    
    if(obj.value !="" && document.getElementById(tbprice).value != "")
    {
        document.getElementById(lbrent).innerHTML = price * count;
    }
}
function Caculate()
{
    var tb=$("gvdata");
    var summoney=0;
    for(i=1;i<tb.rows.length;i++)
    {
        var total=tb.rows[i].cells[5].getElementsByTagName("span")[0].innerHTML;
        if(!isNaN(total))
        {
            summoney+=parseFloat(total);
        }
    }
    $("tbRent").value=summoney
}
</script>
