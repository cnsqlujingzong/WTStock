<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProConfig.aspx.cs" Inherits="CodingPages_Cd_Product_ProConfig" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script src="../js/jquery-1.11.2.js"></script>
     <script src="../js/Base.js"></script>
    <style>
        td {
        text-align: center;
        padding:5px;
        }
    </style>
    <script>
        var allAttr = [ 'A100_2', 'A100_3', 'A100_4', 'A100_5', 'A100_6', 'A100_7', 'A100_8', 'A100_9', 'A100_10', 'A100_11', 'A100_12', 'A100_13', 'A100_14', 'A100_15', 'A100_16', 'A100_17', 'A100_18', 'A100_19', 'A100_20', 'A100_21', 'A100_22', 'A100_23', 'A100_24', 'A100_25', 'A100_26', 'A100_27', 'A100_28', 'A100_29', 'A100_30', 'A100_31', 'A100_32', 'A100_33', 'A100_34', 'A100_35', 'A100_36', 'A100_37', 'A100_38', 'A100_39', 'A100_40', 'A100_41', 'A100_42', 'A100_43', 'A100_44', 'A100_45', 'A100_46', 'A100_47', 'A100_48', 'A100_49', 'A100_50', ];
        console.log(allAttr.length);
        $(function ()
        {
            Base.ShowModal();
            var ptype=Base.getQueryString("id");
            Base.ajaxPost("/CodingPages/Cd_Product/GetHasConfig.ashx", { id: ptype }, function (data) {
                if (data.r == true) {
                    var d = JSON.parse(data.msg);
                    if (d.length > 0)
                    {
                        var rs = [];
                        for (var i = 0; i < d.length; i++)
                        {
                            if (d[i].AttName == "A100_1") {
                                $("#A100_1_dn").val(d[i].AttDisplay);
                                $("#A100_1_ob").val(d[i].AttOB);
                            }
                            else {
                                var row = '<tr class="row" attr="' + d[i].AttName + '"><td class="xu"></td><td class="attrName">' + d[i].AttName + '</td><td class="attrDName"><input  type="text" class="dn" value="' + d[i].AttDisplay + '"/></td><td class="attrOB"><input  type="text" class="ob" value="' + d[i].AttOB + '"/></td> <td><a href="javascript:void(0)" class="delrow">删除</a></td></tr>';
                                rs.push(row);
                              
                            }
                        }
                        $("#rows").append(rs.join(""));
                    }
                  
                } else {
                    alert("配置失败:" + data.msg);                      
                }
                bindDel();
                resetXu();
                Base.HideModal();
            });
           
            $("#addrow").click(function ()
            {
                var currAttr="";
                for (var i = 0; i < allAttr.length; i++)
                {
                    var a = allAttr[i];
                    var ishas=false;
                                    $(".row").each(function () {
                                        var b = $(this).attr("attr");
                                        if (a == b)
                                        {
                                            ishas = true;
                                        }
                                    });
                                    if (!ishas)
                                    {
                                        currAttr = a;
                                        break;
                                    }
                }
                if (currAttr == "")
                {
                    alert("没有可用的数据列了");
                } else {
                    var row = '<tr class="row" attr="' + currAttr + '"><td class="xu"></td><td class="attrName">' + currAttr + '</td><td class="attrDName"><input  type="text" class="dn"/></td><td class="attrOB"><input  type="text" class="ob"/></td> <td><a href="javascript:void(0)" class="delrow">删除</a></td></tr>';
                    $("#rows").append(row);
                    bindDel();
                    resetXu();
                }
            });
            $("#save").click(function () {
                var iscross = true;
                $(".dn").each(function () {
                    if (Validata.isNull(Base.Trim($(this).val())))
                    {
                        iscross = false;
                        alert("属性名称不能为空");
                        return false;
                    }
                });
                $(".ob").each(function () {
                    if (Validata.isNull(Base.Trim($(this).val()))) {
                        iscross = false;
                        alert("排序不能为空");
                        return false;
                    }
                    if (!Validata.isInteger(Base.Trim($(this).val()))) {
                        iscross = false;
                        alert("排序必须为数字");
                        return false;
                    }
                });
                if (iscross == true)
                {
                    var list = [];
                    $(".row").each(function () {
                        var obj = {
                            AttrName: $(this).children(".attrName").html(),
                            AttrDisplay: $(this).children(".attrDName").children(".dn").val(),
                            AttrOderBy: $(this).children(".attrOB").children(".ob").val(),
                        }
                        list.push(obj);                      
                    });                 
                    var obj2 = {
                        proTypeID: Base.getQueryString("id"),
                        AttrList: list
                    }
                    Base.ajaxPost("/CodingPages/Cd_Product/Prohx.ashx", { prams: JSON.stringify(obj2) }, function (data) {
                        if (data.r == true) {
                            alert("配置成功");
                            window.location.href = "/CodingPages/Cd_ProType/ProTypeList.aspx";
                        } else {
                            alert("配置失败:" + data.msg);
                        }

                    });

                }
            });
            $("#cancel").click(function () {
                window.location.href = "/CodingPages/Cd_ProType/ProTypeList.aspx";
            });
        })
        //删除绑定事件
        function bindDel()
        {
            $(".delrow").unbind("click");
            $(".delrow").click(function () {
                $(this).parent().parent().remove();
                 resetXu();
            });
         
        }
        function resetXu()
        {
            var i = 1;
            $(".xu").each(function () {
                $(this).html(i);
                i++;
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
          <a href="../Cd_ProType/ProTypeList.aspx">返回产品型号列表</a>
    <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
        <tr>
            <td class="tdbg">
                
<table cellSpacing="0" cellPadding="0" width="100%" border="0" align="center">
	<thead>
        <tr style="text-align:center;" >
            <td>序号</td>
            <td>数据列</td>
            <td>属性名</td>
            <td>排序</td>      
             <td>操作</td>       
        </tr>
	</thead>
    <tbody id="rows">
        <tr class="row" attr="A100_1">
            <td class="xu">1</td>
            <td class="attrName" >A100_1</td>
            <td class="attrDName"><input  id="A100_1_dn" type="text" class="dn"/></td>
            <td class="attrOB"><input id="A100_1_ob" type="text" class="ob"/></td>      
             <td><a href="javascript:void(0)" id="addrow">添加</a></td>    
        </tr>
    </tbody>
</table>

            </td>
        </tr>
        <tr>
            <td class="tdbg" align="center" valign="bottom">
                <input id="save" type="button" value="保存" class="inputbutton" />
                <input type="button" value="取消" class="inputbutton" id ="cancel" />
            </td>
        </tr>
    </table>
</asp:Content>

