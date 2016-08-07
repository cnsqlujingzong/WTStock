<%@ page language="C#"  CodeFile="stsermap.aspx.cs"     autoeventwireup="true" inherits="Branch_Stat_StSerMap" enableEventValidation="false" %>
<!DOCTYPE>
<html>
<head id="Head1" runat="server">
<meta http-equiv="content-type" content="text/html; charset=utf-8" />
<title></title>
<link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/frame.css" />
<script type="text/javascript" src="http://api.map.baidu.com/api?key=&v=1.2"></script>	
<style type="text/css">
        #divmap { height:400px; width:600px; margin:0 auto;}
</style>
</head>
<body onload="Chkset();" onclick="parent.Sethidden1();">
<form id="form1" runat="server">
<div class="ftool">
    <div class="ftoolleft">
      <table cellpadding="0" cellspacing="0" class="tb2">
        <tr>
        <td class="red">���㣺</td>
        <td style="padding-left:0px;">
            <asp:DropDownList ID="ddlBranch" runat="server" CssClass="pindl" Width="100">
            </asp:DropDownList>
        </td>
        <td>
       ��ʾ����
       </td>
       <td style="padding-left:0px; width:140px;">
           <div class="isinDiv">
            <asp:TextBox ID="tbCity" runat="server" CssClass="pin pinin" Height="16"></asp:TextBox>
            <asp:DropDownList ID="ddlCity" runat="server" CssClass="pininsl" onchange="document.getElementById('tbCity').value=this.options[this.selectedIndex].text;">
                <asp:ListItem Value="����">����</asp:ListItem>
                <asp:ListItem Value="�Ϻ�">�Ϻ�</asp:ListItem>
                <asp:ListItem Value="���">���</asp:ListItem>
                <asp:ListItem Value="����">����</asp:ListItem>
                <asp:ListItem Value="�Ϸ�">�Ϸ�</asp:ListItem>
                <asp:ListItem Value="����">����</asp:ListItem>
                <asp:ListItem Value="����">����</asp:ListItem>
                <asp:ListItem Value="����">����</asp:ListItem>
                <asp:ListItem Value="����">����</asp:ListItem>
                <asp:ListItem Value="ʯ��ׯ">ʯ��ׯ</asp:ListItem>
                <asp:ListItem Value="������">������</asp:ListItem>
                <asp:ListItem Value="�人">�人</asp:ListItem>
                <asp:ListItem Value="��ɳ">��ɳ</asp:ListItem>
                <asp:ListItem Value="�Ͼ�">�Ͼ�</asp:ListItem>
                <asp:ListItem Value="�ϲ�">�ϲ�</asp:ListItem>
                <asp:ListItem Value="����">����</asp:ListItem>
                <asp:ListItem Value="����">����</asp:ListItem>
                <asp:ListItem Value="̫ԭ">̫ԭ</asp:ListItem>
                <asp:ListItem Value="�ɶ�">�ɶ�</asp:ListItem>
                <asp:ListItem Value="����">����</asp:ListItem>
                <asp:ListItem Value="����">����</asp:ListItem>
                <asp:ListItem Value="��³ľ��">��³ľ��</asp:ListItem>
            </asp:DropDownList>
            </div>
        </td>
        <td>���ڴӣ�</td>
        <td style="padding-left:0px;"><asp:TextBox ID="tbDateB" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="100"></asp:TextBox></td>
        <td>����</td>
        <td style="padding-left:0px;"><asp:TextBox ID="tbDateE" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="100"></asp:TextBox></td>
        <td align="left">
            <asp:Button ID="btnSch" runat="server" Text="��ѯ" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
        </tr>
      </table>
    </div>
    <div class="ftoolright">
        
    </div>
    <div class="clearfloat"></div>
</div>
<div id="cndiv" style="height:1px;">
<div id="divmap">
</div>


<script type="text/javascript">
    var map = new BMap.Map("divmap");
    map.enableScrollWheelZoom();
    var point = new BMap.Point(90.616413,38.849316);
    
    if(document.getElementById("tbCity").value!="")
    {
    map.centerAndZoom(document.getElementById("tbCity").value,13);//�趨��ͼ�����ĵ�����겢����ͼ��ʾ�ڵ�ͼ������
    window.map = map;//��map�����洢��ȫ��
    }else
    {
        map.centerAndZoom(point,5);
    }
    
    map.addControl(new BMap.NavigationControl());
    map.addControl(new BMap.ScaleControl());// ��ӱ����߿ؼ�
    map.addControl(new BMap.OverviewMapControl());//������Ե�ͼ�ؼ�

// ��д�Զ��庯��,������ע
function addMarker(point, status,itbid,billid,customer){
  var statusimg="sico1.jpg";
  if(status=="������")
    statusimg="sico2.jpg";
    else
    if(status=="����")
    statusimg="yellow.gif";
    else
    if(status=="������")
    statusimg="tin.gif";
    else
    if(status=="�����")
    statusimg="black.gif";
    else
    if(status=="�ѽ���")
    statusimg="green.gif";
    else
    if(status=="��ȡ��")
    statusimg="gay.gif";
    
  var myIcon = new BMap.Icon("../../Public/Images/"+statusimg, new BMap.Size(14, 13), {
    offset: new BMap.Size(0, 0),// ָ����λλ��
    imageOffset: new BMap.Size(0, 0)   // ����ͼƬƫ��
  });
  
  var marker = new BMap.Marker(point, {icon: myIcon});
  var sContent =
"<h4 style='margin:0 0 5px 0;padding:0.2em 0;color:#ff0000;'>���񵥺ţ�<a href=\"#\" style=\"color:#0000ff;\" onclick=\"ChkView('"+itbid+"');\">"+billid+"</a></h4>" + 
"<p style='margin:0;line-height:1.5;font-size:13px;'>"+customer+"</p>" + 
"</div>";
var infoWindow = new BMap.InfoWindow(sContent);// ������Ϣ���ڶ���

map.addOverlay(marker);
marker.addEventListener("click", function(){                                        
   this.openInfoWindow(infoWindow);
});

}

function ChkView(itbid)
{
    parent.ShowDialog(860,444, 'Services/SerView.aspx?id='+itbid, '����');
}
//--------����Ҽ��˵�----------//
var menu = new BMap.ContextMenu();
var txtMenuItem = [
        {
            text:'�Ŵ�',
            callback:function(){map.zoomIn()}
        },
        {
            text:'��С',
            callback:function(){map.zoomOut()}
        }
    ];
for(var i=0; i < txtMenuItem.length; i++){
    menu.addItem(new BMap.MenuItem(txtMenuItem[i].text,txtMenuItem[i].callback,100));
}
map.addContextMenu(menu);
//--------End------------------//
</script>

</div>
<div class="fbom">
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td><div id="fbon" class="fbon"></div></td>
                <td>
                    <span class="sred">������</span>
                    <span class="sblue">������</span>
                    <span class="stin">������</span>
                    <span class="sblack">�����</span>
                    <span class="syellow">����</span>
                    <span class="sgreen">�ѽ���</span>
                    <span class="sgay">��ȡ��</span>
                </td>
            </tr>
        </table>
    </div>
</form>
</body>
</html>
<script language="javascript" type="text/javascript" src="../../Public/Script/ProcessTip-.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/common.js"></script>
<script language="javascript" type="text/javascript" src="../../Public/Script/My97DatePicker/WdatePicker.js"></script>
<script language="javascript" type="text/javascript">
var noOpen=1;
function ChkID(id)
{
    ClrID(id);
}
function Chkset()
{
    Chkwhmap();
    Chkbom(); 
}

function Chkbom()
{
    $("fbon").innerHTML=parent.DrawInfo("���񵥵�ͼ");
}
</script>
