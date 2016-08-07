<%@ page language="C#"  CodeFile="stsermap.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Basic_StSerMap" enableEventValidation="false" %>
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
    
    map.centerAndZoom(point,10);
    
    
    map.addControl(new BMap.NavigationControl());
    map.addControl(new BMap.ScaleControl());// ��ӱ����߿ؼ�
    map.addControl(new BMap.OverviewMapControl());//������Ե�ͼ�ؼ�

// ��д�Զ��庯��,������ע
function addMarker(point, createtime){
  var statusimg="android_icon1.jpg";
  map.centerAndZoom(point,15);  
  var myIcon = new BMap.Icon("../../Public/Images/android_icon1.png", new BMap.Size(18, 20), {
    offset: new BMap.Size(0, 0),// ָ����λλ��
    imageOffset: new BMap.Size(0, 0)   // ����ͼƬƫ��
  });
  
  var marker = new BMap.Marker(point, {icon: myIcon});
  var sContent =
"<h4 style='margin:0 0 5px 0;padding:0.2em 0;color:#ff0000;'>�ϴ�λ�õ�ʱ�䣺</h4>" + 
"<p style='margin:0;line-height:1.5;font-size:13px;'>"+createtime+"</p>" + 
"</div>";
var infoWindow = new BMap.InfoWindow(sContent);// ������Ϣ���ڶ���

map.addOverlay(marker);
marker.addEventListener("click", function(){                                        
   this.openInfoWindow(infoWindow);
});

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
    $("fbon").innerHTML=parent.DrawInfo("Ա�����ڵ�ͼ");
}
</script>
