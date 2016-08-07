<%@ page language="C#"  CodeFile="stsermap.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Stat_StSerMap" enableEventValidation="false" %>
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
        <td class="red">网点：</td>
        <td style="padding-left:0px;">
            <asp:DropDownList ID="ddlBranch" runat="server" CssClass="pindl" Width="100">
                <asp:ListItem Value=""></asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
       显示区域：
       </td>
       <td style="padding-left:0px; width:140px;">
           <div class="isinDiv">
            <asp:TextBox ID="tbCity" runat="server" CssClass="pin pinin" Height="16"></asp:TextBox>
            <asp:DropDownList ID="ddlCity" runat="server" CssClass="pininsl" onchange="document.getElementById('tbCity').value=this.options[this.selectedIndex].text;">
                <asp:ListItem Value="北京">北京</asp:ListItem>
                <asp:ListItem Value="上海">上海</asp:ListItem>
                <asp:ListItem Value="天津">天津</asp:ListItem>
                <asp:ListItem Value="重庆">重庆</asp:ListItem>
                <asp:ListItem Value="合肥">合肥</asp:ListItem>
                <asp:ListItem Value="福州">福州</asp:ListItem>
                <asp:ListItem Value="兰州">兰州</asp:ListItem>
                <asp:ListItem Value="广州">广州</asp:ListItem>
                <asp:ListItem Value="深圳">深圳</asp:ListItem>
                <asp:ListItem Value="石家庄">石家庄</asp:ListItem>
                <asp:ListItem Value="哈尔滨">哈尔滨</asp:ListItem>
                <asp:ListItem Value="武汉">武汉</asp:ListItem>
                <asp:ListItem Value="长沙">长沙</asp:ListItem>
                <asp:ListItem Value="南京">南京</asp:ListItem>
                <asp:ListItem Value="南昌">南昌</asp:ListItem>
                <asp:ListItem Value="沈阳">沈阳</asp:ListItem>
                <asp:ListItem Value="西安">西安</asp:ListItem>
                <asp:ListItem Value="太原">太原</asp:ListItem>
                <asp:ListItem Value="成都">成都</asp:ListItem>
                <asp:ListItem Value="杭州">杭州</asp:ListItem>
                <asp:ListItem Value="温州">温州</asp:ListItem>
                <asp:ListItem Value="乌鲁木齐">乌鲁木齐</asp:ListItem>
            </asp:DropDownList>
            </div>
        </td>
        <td>日期从：</td>
        <td style="padding-left:0px;"><asp:TextBox ID="tbDateB" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="100"></asp:TextBox></td>
        <td>到：</td>
        <td style="padding-left:0px;"><asp:TextBox ID="tbDateE" runat="server" CssClass="Wdate" onfocus="WdatePicker()" Width="100"></asp:TextBox></td>
        <td align="left">
            <asp:Button ID="btnSch" runat="server" Text="查询" CssClass="bt1" UseSubmitBehavior="False" OnClick="btnSch_Click" /></td>
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
    map.centerAndZoom(document.getElementById("tbCity").value,13);//设定地图的中心点和坐标并将地图显示在地图容器中
    window.map = map;//将map变量存储在全局
    }else
    {
        map.centerAndZoom(point,5);
    }
    
    map.addControl(new BMap.NavigationControl());
    map.addControl(new BMap.ScaleControl());// 添加比例尺控件
    map.addControl(new BMap.OverviewMapControl());//添加缩略地图控件

// 编写自定义函数,创建标注
function addMarker(point, status,itbid,billid,customer){
  var statusimg="sico1.jpg";
  if(status=="处理中")
    statusimg="sico2.jpg";
    else
    if(status=="送修")
    statusimg="yellow.gif";
    else
    if(status=="待结算")
    statusimg="tin.gif";
    else
    if(status=="待审核")
    statusimg="black.gif";
    else
    if(status=="已结束")
    statusimg="green.gif";
    else
    if(status=="已取消")
    statusimg="gay.gif";
    
  var myIcon = new BMap.Icon("../../Public/Images/"+statusimg, new BMap.Size(14, 13), {
    offset: new BMap.Size(0, 0),// 指定定位位置
    imageOffset: new BMap.Size(0, 0)   // 设置图片偏移
  });
  
  var marker = new BMap.Marker(point, {icon: myIcon});
  var sContent =
"<h4 style='margin:0 0 5px 0;padding:0.2em 0;color:#ff0000;'>服务单号：<a href=\"#\" style=\"color:#0000ff;\" onclick=\"ChkView('"+itbid+"');\">"+billid+"</a></h4>" + 
"<p style='margin:0;line-height:1.5;font-size:13px;'>"+customer+"</p>" + 
"</div>";
var infoWindow = new BMap.InfoWindow(sContent);// 创建信息窗口对象

map.addOverlay(marker);
marker.addEventListener("click", function(){                                        
   this.openInfoWindow(infoWindow);
});

}

function ChkView(itbid)
{
    parent.ShowDialog(860,444, 'Services/SerView.aspx?id='+itbid, '服务单');
}
//--------添加右键菜单----------//
var menu = new BMap.ContextMenu();
var txtMenuItem = [
        {
            text:'放大',
            callback:function(){map.zoomIn()}
        },
        {
            text:'缩小',
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
                    <span class="sred">待处理</span>
                    <span class="sblue">处理中</span>
                    <span class="stin">待结算</span>
                    <span class="sblack">待审核</span>
                    <span class="syellow">送修</span>
                    <span class="sgreen">已结束</span>
                    <span class="sgay">已取消</span>
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
    $("fbon").innerHTML=parent.DrawInfo("服务单地图");
}
</script>
