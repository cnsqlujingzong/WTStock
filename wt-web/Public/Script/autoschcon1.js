// JScript 文件 // 机器型号，机器类别，机器品牌的收索
var xmlHttp = false;
var currentLine = - 1;
var divtable;
var txtname;
var txtnameid;
var btntgetinfo;

//校验是否为空
function isNullT1(s) 
{ 
    var patrn=/^\s*$/;
    if(!patrn.exec(s)) return false;
    return true;
}
function createXMLHttpRequest1(){
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
function getSearchResult1(queryurl,tbname,hfnameid,iflag,btngetinfo,event)
{
    var cusid="";
    txtname=tbname;
    txtnameid=hfnameid;
    btntgetinfo=btngetinfo;
    if(event.keyCode!=38 && event.keyCode!=40 && event.keyCode!=32 && event.keyCode!=9 && event.keyCode!=13)
    {
       createXMLHttpRequest1();
       if(!xmlHttp)
        {
            window.alert("Cannot create XMLHttpRequest instance!");
            return false;
        }
        var parmurl;
        if(iflag.split('|')[1]!="")
        {
            if(btntgetinfo.split('^').length >1)
            {
                parmurl="keydata="+escape($(txtname).value)+"&cusid="+iflag.split('|')[1]+"&brand="+escape(btntgetinfo.split('^')[0])+"&classes="+escape(btntgetinfo.split('^')[1]);
            }   
            else    
                parmurl="keydata="+escape($(txtname).value)+"&cusid="+iflag.split('|')[1];
        }
        else
        {
            if(btntgetinfo.split('^').length >1)
                parmurl="keydata="+escape($(txtname).value)+"&brand="+escape(btntgetinfo.split('^')[0])+"&classes="+escape(btntgetinfo.split('^')[1]);
            else
                parmurl="keydata="+escape($(txtname).value);
        }
       if(iflag.split('|')[0]==1){parmurl+="&f=1";}
       xmlHttp.onreadystatechange = callback1;
       xmlHttp.open("POST", queryurl, true);
       xmlHttp.setRequestHeader("Content-Type","application/x-www-form-urlencoded;"); 
       xmlHttp.send(parmurl);
    }
}

//返回查询信息
function callback1()
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
            createTable1(xmlHttp.responseText); 
      }else
        {
	        window.alert("未知错误！");
	        return false;
	    }
   }
}

//创建装载返回结果的DIV
function createTable1(strtable,divheight)
{
    if($("contents"))
    document.body.removeChild(divtable);
    divtable = window.document.createElement("div");
    divtable.setAttribute("id","contents");
    divtable.style.position="absolute";
    divtable.style.border="1px solid #817F82";
    divtable.style.background="#fff";
    divtable.innerHTML="";
    var strcon="<iframe style=\"position: absolute;z-index: -5;height:230px;width:380px;\" frameborder=\"0\"></iframe>";
    divtable.innerHTML=strcon+strtable;
    divtable.zIndex="800";
    divtable.style.width="122px";
    divtable.style.overflow="hidden";
    divtable.style.height="230px";
    var tscroll = getScrollTop($(txtname));
    var tsize = window.document.body.offsetHeight;
    //$(txtname).offsetTop + $(txtname).offsetHeight + "px";
    var tp = getTop($(txtname)) + $(txtname).offsetHeight;
    if((tp + 235) > (tsize+tscroll))
    {
        divtable.style.top= tp - 230 - $(txtname).offsetHeight - tscroll + "px"
    }
    else
    {
        divtable.style.top= tp - tscroll + "px";
    }
    var tl = getLeft($(txtname)) + 3;
    var lscroll = getScrollLeft($(txtname));
    divtable.style.left= (tl - lscroll) + "px";
    //$(txtname).offsetLeft + "px";
    
    document.body.appendChild(divtable);
}

function getTop(obj)
{
    var atop=obj.offsetTop;
    while(obj=obj.offsetParent)
    {
        atop=obj.offsetTop+atop;
    }
    return atop;
}

function getLeft(obj)
{
    var aleft = obj.offsetLeft;
    while(obj=obj.offsetParent)
    {
        aleft = obj.offsetLeft + aleft;
    }
    return aleft;
}

function getScrollTop(obj)
{
    var aScrollTop = obj.scrollTop;
    while(obj=obj.offsetParent)
    {
        aScrollTop = obj.scrollTop + aScrollTop;
    }
    return aScrollTop;
}

function getScrollLeft(obj)
{
    var aScrollLeft = obj.scrollLeft;
    while(obj=obj.offsetParent)
    {
        aScrollLeft = obj.scrollLeft + aScrollLeft;
    }
    return aScrollLeft;
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
             changeItem1();
             break;
          case 40 :
             // 下方向键
             currentLine ++ ;
             changeItem1();
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
function changeItem1()
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
       $(txtname).value = it.rows[currentLine].cells[0].innerHTML.split('-')[0];
   }
}

//单击取值
function clickItem1(clicktLine)
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
   $(txtname).value = it.rows[clicktLine].cells[0].innerHTML;//.split('-')[0];
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