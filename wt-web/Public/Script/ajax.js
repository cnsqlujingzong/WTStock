//创建XML对象
function createXMLHttps(){
var ret = null;
try {ret = new ActiveXObject('Msxml2.XMLHTTP')}
catch (e) {
	try {ret = new ActiveXObject('Microsoft.XMLHTTP')}
        catch (ee) {ret = null}
	}
if (!ret&&typeof XMLHttpRequest !='undefined') ret = new XMLHttpRequest();
return ret;
}

//LoadType=0:无加载效果，=1局部插入加载文字居左，=2全局加载
//AjaxType=0:提示,=1直接插入
function AjaxGet(URL,DivId,AjaxType,LoadType) {
if(LoadType==1){$(DivId).innerHTML="<div style='padding:10px;text-align:left'><img src='../Public/images/loading2.gif' align=absmiddle> 正在加载数据...</div>"}
else if(LoadType==2){Loading("star")}
var xmlhttp = createXMLHttps();
xmlhttp.open("GET",URL,true);
//xmlhttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
xmlhttp.onreadystatechange = function() {
	//alert(xmlhttp.responseText)
	if (xmlhttp.readyState==4&&xmlhttp.status==404) {E("404文件不存在："+URL,0);return}
	if (xmlhttp.readyState==4&&xmlhttp.status==500) {alert("500错误提示:\n\n"+xmlhttp.responseText);return}
	if (xmlhttp.readyState==4&&xmlhttp.status==200) {
		var ajaxHtml=xmlhttp.responseText;
			switch (AjaxType){
				case 1:
				$(DivId).innerHTML=ajaxHtml;
				Loading("over");
				break;
			}
		}
	}
xmlhttp.send(null);
}
function Loading(LoadType){
if(LoadType=="star"){$("Loading").style.display=""}
if(LoadType=="over"){$("Loading").style.display="none"}
}