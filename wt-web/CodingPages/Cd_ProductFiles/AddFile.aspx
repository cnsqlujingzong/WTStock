<%@ Page Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="AddFile.aspx.cs" Inherits="CodingPages_Cd_ProductFiles_AddFile" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="/CodingPages/js/imgUpload/uploadify.css" type="text/css" rel="stylesheet" />
    <style>
         .imgDiv {
            float:left; margin:5px;border:2px solid #444
        }
            .imgDiv img {
                width:200px;height:200px;
            }
        .currImg {
        border:4px solid red;
        }
    </style>
    <script type="text/javascript" src="/CodingPages/js/jquery-1.11.2.js"></script>
     <script type="text/javascript" src="/CodingPages/js/Base.js"></script>
      <script type="text/javascript" src="/CodingPages/js/imgUpload/jquery.uploadify.min.js"></script>
<script type="text/javascript" src="/CodingPages/js/imgUpload/uploadswfobject.js"></script>
    <script>
        $(function () {
            var id = Base.getQueryString("id");
            initImgUpload(id);//图片控件初始化
            //删除图片
            $("#delImg").click(function () {
                //partID='" + data[i].PartID + "' currId='" + data[i].ID + "

                var imgid = $("#imgView .currImg").attr("currId");
                Base.ajaxPost("/CodingPages/js/imgUpload/Upload.ashx", { delid: imgid, type: 'profile' }, function (data) {
                    if (data == "1") {
                        window.location.href = window.location.href;
                    } else {
                        alert("请重试");
                    }
                });
            });
            $(".imgDiv").click(function () {
                $(".imgDiv").removeClass("currImg");
                $(this).addClass("currImg");

            });
        })
        //初始化图片上传控件
        function initImgUpload(id) {
            $("#uploadify").uploadify({
                'uploader': '/CodingPages/js/imgUpload/uploadify.swf',
                'script': '/CodingPages/js/imgUpload/Upload.ashx',
                'cancelImg': '/CodingPages/js/imgUpload/images/cancel.png',
                'folder': '/upload/profile',
                'queueID': 'fileQueue',
                'auto': false,
                'multi': true,
                //'fileExt': '*.jpg;*.gif;*.png',
                //'fileDesc': 'Web Image Files (.JPG, .GIF, .PNG)',
                'buttonText': '浏览',
                'onSelect': function (event, queueID, fileObj) {
                    $("#uploadify").uploadifySettings("script", "/CodingPages/js/imgUpload/Upload.ashx?type=profile&&pid=" + id); //动态更新配(执行此处时可获得值)

                },
                'onError': function (event, queueId, fileObj, errorObj) {
                    alert(errorObj.info + "---------" + errorObj.type);
                },
                'onAllComplete': function () {
                    //ShowImg();
                    window.location.href = window.location.href;
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  
    <div>  
     <button id="delImg" class="button">--选中删除--</button>
            <br /><br />
        <form id="formxx" runat="server">           
            <div id="imgView">
                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>
                        <div class='imgDiv' currid='<%# Eval("ID") %>' style="padding:20px; "><a href="<%#Eval("FileSrc") %>" style="border:1px solid #444"><%#Eval("FileName") %></a></div>
                    </ItemTemplate>

                </asp:Repeater>
                  
                

            </div>
            </form>
            <div style="clear:both;"></div>
            <form id="form1"  enctype="multipart/form-data">
                <div>
                    <input type="file" name="uploadify" id="uploadify" />&nbsp;  <a href="javascript:$('#uploadify').uploadifyUpload()">上传</a>| <a href="javascript:$('#uploadify').uploadifyClearQueue()">取消上传</a>
                </div>
                <div id="fileQueue"></div>
                <div style="clear: both;"></div>
            </form>

        </div>
</asp:Content>


