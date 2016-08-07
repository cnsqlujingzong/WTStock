<%@ Page Language="C#" AutoEventWireup="true" CodeFile="modpro.aspx.cs" Inherits="CodingPages_Cd_Product_modpro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../js/jquery-1.11.2.js"></script>
    <script src="../js/Base.js"></script>
    <script>
        var id = Base.getQueryString("id");
        var tid = Base.getQueryString("tid");
        $(function () {
            $("#hid").val(id);
            $("#htid").val(tid);
            Base.ShowModal();
            Base.ajaxPost("modprohdl.ashx", { id: id, tid: tid }, function (data) {
                if (data.r)
                {
                    var d = JSON.parse(data.d);
                    for (var i = 0; i < d.length; i++)
                    {
                        $("#datas").append("<tr><td>" + d[i].attDisName + "</td><td><input type='text' value='" + d[i].value + "' name='" + d[i].attName + "'></td></tr>");
                        /**
                        public string  attName { get; set; }
                        public string  attDisName { get; set; }
                        public string value { get; set; }
                        **/
                    }

                }
                Base.HideModal();
            });

        })

        function ret()
        {
            window.location.href = "/CodingPages/Cd_Product/ProductList.aspx?id="+tid;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <input type="hidden" id="hid" name="hid"/>
        <input type="hidden" id="htid" name="htid"/>
    <div style="width:800px;margin:0px auto;">
        <table border="1">
            <thead>
            <tr>
                <td style="text-align:center; background:#d0d0d0">属性名</td>
                <td style="text-align:center;background:#d0d0d0"" >值</td>
            </tr>
           </thead>
            <tbody id="datas">

            </tbody>
            <tfoot>
                <tr>
                    <td colspan="2" style="text-align:center;">
                <asp:Button ID="Button1" runat="server" Text="修改" OnClick="Button1_Click" />
                        <button onclick="ret()">取消</button>                        
                    </tr>
            </tfoot>
        </table>
       
    </div>
    </form>
</body>
</html>
