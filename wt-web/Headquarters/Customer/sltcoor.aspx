<%@ page language="C#"  CodeFile="sltcoor.aspx.cs"     autoeventwireup="true" inherits="Headquarters_Customer_SltCoor" enableEventValidation="false" %>
<!DOCTYPE html>
<html>
<head runat="server">
<meta http-equiv="content-type" content="text/html; charset=utf-8" />
<title></title>
<link rel="Stylesheet" type="text/css" href="../../Public/Style/sub.css" />
<link rel="Stylesheet" type="text/css" href="../../Public/Style/frame.css" />
<script type="text/javascript" src="http://api.map.baidu.com/api?v=1.2"></script>	
<style type="text/css">
        #divmap { height:480px; width:800px; margin:0 auto;}
</style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="ftool">
    <div class="ftoolleft">
       <table cellpadding="0" cellspacing="0" class="tb2">
        <tr>
        <td class="red">城市：</td>
        <td style="padding-left:0px; width:140px;">
            <div class="isinDiv">
            <asp:TextBox ID="tbCity" runat="server" CssClass="pin pinin"></asp:TextBox>
            <asp:DropDownList ID="ddlCity" runat="server" CssClass="pininsl" onchange="document.getElementById('tbCity').value=this.options[this.selectedIndex].text;" style="height:18px;">
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
            </asp:DropDownList>
            </div>
        </td>
        <td>查找：</td>
        <td style="padding-left:0px;">
            <asp:TextBox ID="tbCon" runat="server" CssClass="pin"></asp:TextBox>
        </td>
        <td align="left">
            <input id="btnSch" type="button" value="查询" class="bt1" onclick="getschmap();" />
         </td>
        </tr>
      </table>
    </div>
    <div class="ftoolright" style="padding-right:20px;">
        <table cellpadding="0" cellspacing="0" class="tb2">
        <tr>
        <td class="red">地图坐标：</td>
        <td style="padding-left:0px;">
            <asp:TextBox ID="tbCoordinates" runat="server" CssClass="pin" Width="140"></asp:TextBox>
        </td>
        <td>
           <input id="btnSlt" type="button" value="确定" class="bt1" onclick="ChkSave();" />
        </td>
        </tr>
        </table>
    </div>
    <div class="clearfloat"></div>
</div>
<div id="cndiv" style="height:480px; width:800px;">
<div id="divmap">
</div>
<script type="text/javascript">
    var map = new BMap.Map("divmap");
    map.enableScrollWheelZoom();
    var point = new BMap.Point(116.395645,39.929986);
    map.centerAndZoom(point,5);
    map.addControl(new BMap.NavigationControl());
    
    map.addEventListener("click", function(e){   
      document.getElementById("tbCoordinates").value = e.point.lng + "," + e.point.lat;
    });
    
//    map.addEventListener("dblclick", function(e){   
//      ChkSave();      
//    });
    
function getschmap()
{
    var city=document.getElementById("tbCity").value;
    map.centerAndZoom(city);
    
    var local = new BMap.LocalSearch(map, {
      renderOptions: {map: map, panel: "results"}
    });
    var strcon=document.getElementById("tbCon").value;
    local.search(strcon);
}

function ChkSave()
{
    parent.<%=str_Fid %>.document.getElementById("tbCoordinates").value = document.getElementById("tbCoordinates").value;
    parent.CloseDialog<%=str_F %>();
}
</script>
</div>
    </form>
</body>
</html>
