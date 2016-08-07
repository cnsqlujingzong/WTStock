<%@ page language="C#"  CodeFile="sltcoor.aspx.cs"     autoeventwireup="true" inherits="Branch_Customer_SltCoor" enableEventValidation="false" %>
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
        <td class="red">���У�</td>
        <td style="padding-left:0px; width:140px;">
            <div class="isinDiv">
            <asp:TextBox ID="tbCity" runat="server" CssClass="pin pinin"></asp:TextBox>
            <asp:DropDownList ID="ddlCity" runat="server" CssClass="pininsl" onchange="document.getElementById('tbCity').value=this.options[this.selectedIndex].text;" style="height:18px;">
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
            </asp:DropDownList>
            </div>
        </td>
        <td>���ң�</td>
        <td style="padding-left:0px;">
            <asp:TextBox ID="tbCon" runat="server" CssClass="pin"></asp:TextBox>
        </td>
        <td align="left">
            <input id="btnSch" type="button" value="��ѯ" class="bt1" onclick="getschmap();" />
         </td>
        </tr>
      </table>
    </div>
    <div class="ftoolright" style="padding-right:20px;">
        <table cellpadding="0" cellspacing="0" class="tb2">
        <tr>
        <td class="red">��ͼ���꣺</td>
        <td style="padding-left:0px;">
            <asp:TextBox ID="tbCoordinates" runat="server" CssClass="pin" Width="140"></asp:TextBox>
        </td>
        <td>
           <input id="btnSlt" type="button" value="ȷ��" class="bt1" onclick="ChkSave();" />
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
