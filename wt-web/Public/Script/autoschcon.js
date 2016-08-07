// JScript 文件
var xmlHttp = false;
var currentLine = - 1;
var divtable;
var txtname;
var txtnameid;
var btntgetinfo;

//校验是否为空
function isNullT(s) 
{ 
    var patrn=/^\s*$/;
    if(!patrn.exec(s)) return false;
    return true;
}
function createXMLHttpRequest(){
    xmlHttp = false;
    if(window.XMLHttpRequest){        //for Mozilla
        xmlHttp = new XMLHttpRequest();
        if(xmlHttp.overrideMimeType){
            xmlHttp.overrideMimeType("text/xml");
        }
    }
    else if(window.ActiveXObject){   //for IE
        try{
            xmlHttp = new ActiveXObject("Msxml2.XMLHTTP");
        }catch(e){
            try{
                xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
            }catch(e){}
        }
    }
}

//获取查询结果
function getSearchResult(queryurl,tbname,hfnameid,iflag,btngetinfo,event)
{
    txtname=tbname;
    txtnameid=hfnameid;
    btntgetinfo=btngetinfo;

    if(event.keyCode!=38 && event.keyCode!=40 && event.keyCode!=32 && event.keyCode!=9 && event.keyCode!=13)
    {
       createXMLHttpRequest();
       if(!xmlHttp)
        {
            window.alert("Cannot create XMLHttpRequest instance!");
            return false;
        }
       var parmurl="keydata="+escape($(txtname).value);
       if(iflag==1){parmurl+="&f=1";}
       xmlHttp.onreadystatechange = callback;
       xmlHttp.open("POST", queryurl, true);
       xmlHttp.setRequestHeader("Content-Type","application/x-www-form-urlencoded;"); 
       xmlHttp.send(parmurl);
    }
}

//返回查询信息
function callback()
{
   if(xmlHttp.readyState == 4)
   {
      if(xmlHttp.status == 200)
      {
        if(xmlHttp.responseText.trim() == "")
        {
        if($("contents"))
            document.body.removeChild(divtable);
        }
        else
        {
            createTable(xmlHttp.responseText); 
        }
      }else
        {
	        window.alert("未知错误！");
	        return false;
	    }
   }
}

//创建装载返回结果的DIV
function createTable(strtable,divheight)
{
    if($("contents"))
    document.body.removeChild(divtable);
    divtable = window.document.createElement("div");
    divtable.setAttribute("id","contents");
    divtable.style.position="absolute";
    divtable.style.border="1px solid #817F82";
    divtable.style.background="#fff";
    divtable.innerHTML="";
    var strcon="<iframe style=\"position: absolute;z-index: -2;height:235px;width:380px;\" frameborder=\"0\"></iframe>";
    divtable.innerHTML=strcon+strtable;
    divtable.zIndex="800";
    divtable.style.width="auto";
    divtable.style.overflow="hidden";
    divtable.style.height="235px";
    divtable.style.top=$(txtname).offsetTop + $(txtname).offsetHeight + "px";
    divtable.style.left=$(txtname).offsetLeft + "px";
    
    document.body.appendChild(divtable);
}

//捕捉键盘按钮
document.onkeydown = function(e)
{
    if(document.getElementById("gvice"))
    {
       e = window.event || e;
       switch(e.keyCode)
       {
          case 38 :
             // 上方向键
             currentLine -- ;
             changeItem();
             break;
          case 40 :
             // 下方向键
             currentLine ++ ;
             changeItem();
             break;
             // Backspace
          case 32:
             MoveDivTable();
             break;
             // Tab
          case 9:
             MoveDivTable();
             // Enter
          case 13:
             MoveDivTable();
             break;
          default :
             break;
       }
   }
}

// 选择行
function changeItem()
{
   var it = document.getElementById("gvice");
   for(var j = 0; j < it.rows.length; j ++ )
   {
      it.rows[j].className = "bsltrowc";
   }
   if(currentLine < 0)
   {
      currentLine = it.rows.length - 1;
   }
   if(currentLine == it.rows.length)
   {
      currentLine = 0;
   }
   if(it.rows.length==1)
   {
      currentLine = 0;
   }

   if(it.rows[currentLine])
   {
       it.rows[currentLine].className = "sltrowc";
       $(txtnameid).value = it.rows[currentLine].id;
       $(txtname).value = it.rows[currentLine].cells[1].innerHTML.split('-')[0];
   }
}

//单击取值
function clickItem(clicktLine)
{
   if(document.all)
   {
      var it = document.getElementById("gvice").children[0];
   }
   else
   {
      var it = document.getElementById("gvice");
   }
   for(i = 0; i < it.rows.length; i ++ )
   {
      it.rows[i].className = "bsltrowc";
   }
   
   it.rows[clicktLine].className = "sltrowc";
   $(txtnameid).value = it.rows[clicktLine].id;
   $(txtname).value = it.rows[clicktLine].cells[1].innerHTML;//.split('-')[0];
   currentLine = clicktLine;
   
   if(btntgetinfo!=null&&btntgetinfo!="")
    $(btntgetinfo).click();
}

//移除Div
function MoveDivTable()
{
    if($("contents"))
       document.body.removeChild(divtable);
    
    if(btntgetinfo!=null&&btntgetinfo!="")
    $(btntgetinfo).click();
}