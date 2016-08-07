
/*--------------初始化Tab------------*/
function StartTab(num)
{
     for(i=1; i <num; i++)
     {
          if(i==1)
          {
               document.getElementById("tabs_l1").className="tabs_activeleft";
               document.getElementById("tabs1").className="tabs_active";
               document.getElementById("tabs_r1").className="tabs_activeright";
               document.getElementById("info1").className="swb";
          }
          else
          {
               document.getElementById("tabs_l"+i).className="tabs_left";
               document.getElementById("tabs"+i).className="tabs";
               document.getElementById("tabs_r"+i).className="tabs_right";
               document.getElementById("info"+i).className="hd";
               
//               document.getElementById("tabs"+i).attachEvent("onmouseover",function(){methodover(3);});
//               document.getElementById("tabs"+i).attachEvent("onmouseout",function(){methodout(3);});
               
//               var td_value = document.getElementById("tabs"+i);
//                if(window.addEventListener){ // Mozilla, Netscape, Firefox
//                    td_value.addEventListener('mouseover', alert(i), false);
//                    td_value.addEventListener('mouseout', alert(i), false);
//                } else { // IE
//                    td_value.attachEvent('onmouseover',  function(){alert(i);});
//                    td_value.attachEvent('onmouseout',  function(){alert(i);});
//                }
          }
     }
}
function StartTab2(num)
{
     for(i=1; i <num; i++)
     {
          if(i==1)
          {
               document.getElementById("tabs_l21").className="tabs_activeleft";
               document.getElementById("tabs21").className="tabs_active";
               document.getElementById("tabs_r21").className="tabs_activeright";
               document.getElementById("infos1").className="swb";
          }
          else
          {
               document.getElementById("tabs_l2"+i).className="tabs_left";
               document.getElementById("tabs2"+i).className="tabs";
               document.getElementById("tabs_r2"+i).className="tabs_right";
               document.getElementById("infos"+i).className="hd";
               
//               document.getElementById("tabs"+i).attachEvent("onmouseover",function(){methodover(3);});
//               document.getElementById("tabs"+i).attachEvent("onmouseout",function(){methodout(3);});
               
//               var td_value = document.getElementById("tabs"+i);
//                if(window.addEventListener){ // Mozilla, Netscape, Firefox
//                    td_value.addEventListener('mouseover', alert(i), false);
//                    td_value.addEventListener('mouseout', alert(i), false);
//                } else { // IE
//                    td_value.attachEvent('onmouseover',  function(){alert(i);});
//                    td_value.attachEvent('onmouseout',  function(){alert(i);});
//                }
          }
     }
}
/*--------------End------------*/

/*--------------切换Tab函数------------*/
function ChkTab(tabg)
{ 
     for(i=1; i <tabnum; i++)
     {
          if (i==tabg)
          { 
               document.getElementById("tabs_l"+i).className="tabs_activeleft";
               document.getElementById("tabs"+i).className="tabs_active";
               document.getElementById("tabs_r"+i).className="tabs_activeright";
               document.getElementById("info"+i).className="swb";
          }
          else
          {
               document.getElementById("tabs_l"+i).className="tabs_left";
               document.getElementById("tabs"+i).className="tabs";
               document.getElementById("tabs_r"+i).className="tabs_right";
               document.getElementById("info"+i).className="hd";
          }
     }
}

function ChkTab2(tabg)
{ 
     for(i=1; i <tabnum2; i++)
     {
          if (i==tabg)
          { 
               document.getElementById("tabs_l2"+i).className="tabs_activeleft";
               document.getElementById("tabs2"+i).className="tabs_active";
               document.getElementById("tabs_r2"+i).className="tabs_activeright";
               document.getElementById("infos"+i).className="swb";
          }
          else
          {
               document.getElementById("tabs_l2"+i).className="tabs_left";
               document.getElementById("tabs2"+i).className="tabs";
               document.getElementById("tabs_r2"+i).className="tabs_right";
               document.getElementById("infos"+i).className="hd";
          }
     }
}
function methodover(i)
{
    document.getElementById("tabs_l"+i).className="tabs_hoverleft";
    document.getElementById("tabs"+i).className="tabs_hover";
    document.getElementById("tabs_r"+i).className="tabs_hoverright";
}
function methodout(i)
{
    document.getElementById("tabs_l"+i).className="tabs_left";
    document.getElementById("tabs"+i).className="tabs";
    document.getElementById("tabs_r"+i).className="tabs_right";
}
/*--------------End------------*/

////检测标签是否存在某样式
//function hasClass(element, className) {
//var reg = new RegExp('(\\s|^)'+className+'(\\s|$)');
//return element.className.match(reg);
//}

////给标签添加样式
//function addClass(element, className) {
//if (!this.hasClass(element, className))
//{
//element.className += " "+className;
//}
//}

////标签样式
//function removeClass(element, className) {
//if (hasClass(element, className)) {
//var reg = new RegExp('(\\s|^)'+className+'(\\s|$)');
//element.className = element.className.replace(reg,' ');
//}
//}

//function AttachEvent(target, eventName, handler, argsObject)   
//{
//    var eventHandler = handler;
//    if(argsObject)
//    {
//        eventHander = function(e)
//        {
//            handler.call(argsObject, e);
//        }
//    }
//    if(window.attachEvent)//IE
//        target.attachEvent("on" + eventName, eventHander );
//    else//FF
//        target.addEventListener(eventName, eventHander, false);
//}
//function mouseeventover()
//{
//    if(this.obj.className == "main_menu jt_u")
//    {
//        this.obj.className = "main_menu s_menu_bg";
//        this.oldobj.className = "jt_s";
//    }
//    if(this.obj.className == "main_menu jt_u_inblock")
//    {
//        this.obj.className = "main_menu s_menu_bg";
//        this.oldobj.className = "jt_s_inblock";
//    }
//}
//var args = new Object();   
//args.obj = obj;   
//args.oldobj = oldobj;   
//AttachEvent(obj,"mouseover",mouseeventover,args);  