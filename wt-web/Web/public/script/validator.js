
//校验是否为空
function isNull(s) 
{ 
var patrn=/^\s*$/;
if(!patrn.exec(s)) return false;
return true;
} 
//校验是否全由数字组成 
function isDigit(s) 
{ 
var patrn=/^[0-9]{1,20}$/; 
if(!patrn.exec(s)) return false;
return true;
} 
//校验是否全金额 
function isMoney(s) 
{ 
var patrn=/^(-?\d+)(\.\d{1,2})?$/; 
if(!patrn.exec(s)) return false;
return true;
} 

//校验是否日期格式 
function isDate(s)   
{   
    var r = s.match(/^(\d{4})(-|\/)(\d{1,2})\2(\d{1,2})$/);     
    if(r==null)return false;
    var d  =  new Date(r[1], r[3]-1, r[4]);     
    return(d.getFullYear()==r[1]&&(d.getMonth()+1)==r[3]&&d.getDate()==r[4]);   
}

// 检查是否为有效的email
function isMail(str)
{
  var myReg = /^[_\-\.a-zA-Z0-9]+@([_\-a-zA-Z0-9]+\.)+[a-zA-Z0-9]{2,3}$/;
  if(myReg.test(str)) 
  	return true;
  return false;
}
//去掉首尾空格
function Trim(str)
{
    return str.replace(/(^\s*)|(\s*$)/g,"");
}
//检测密码
function isPwd(str)
{
	var reg = /^[\x00-\x7f]+$/;
	if (! reg.test(str))
	{
		return false;
	}
	
	if (str.length < 6 || str.length > 32)
	{
		return false;	
	}
	return true;
}

function ChkPBrand()
{
    var bnull=true;
    if(!isNull($("tbBrand").value))
    {
        var ddlgradelevel=$("ddlBrand");
        if($("tbBrand").value!=ddlgradelevel.options[ddlgradelevel.selectedIndex].text)
        {
            for(var i=0;i<ddlgradelevel.options.length;i++)
            {
                if(ddlgradelevel.options[i].value!="0")
                {
                    if(ddlgradelevel.options[i].text==$("tbBrand").value)
                    {
                        ddlgradelevel.options[i].selected=true;
                        bnull=false;
                    }
                }else{$("tbBrand").value="";}
            }
            
            if(bnull)
            {
                for(var i=0;i<ddlgradelevel.options.length;i++)
                {
                    if(ddlgradelevel.options[i].text=="")
                    {
                        ddlgradelevel.options[i].selected=true;
                    }
                }
                $("tbBrand").value="";
            }
        }
    }
}


function ChkPClass()
{
    var bnull=true;
    if(!isNull($("tbClass").value))
    {
        var ddlgradelevel=$("ddlClass");
        if($("tbClass").value!=ddlgradelevel.options[ddlgradelevel.selectedIndex].text)
        {
            for(var i=0;i<ddlgradelevel.options.length;i++)
            {
                if(ddlgradelevel.options[i].value!="0")
                {
                    if(ddlgradelevel.options[i].text==$("tbClass").value)
                    {
                        ddlgradelevel.options[i].selected=true;
                        bnull=false;
                    }
                }else{$("tbClass").value="";}
            }
            
            if(bnull)
            {
                for(var i=0;i<ddlgradelevel.options.length;i++)
                {
                    if(ddlgradelevel.options[i].text=="")
                    {
                        ddlgradelevel.options[i].selected=true;
                    }
                }
                $("tbClass").value="";
            }
        }
    }
}

function ChkPModel()
{
    var bnull=true;
    if(!isNull($("tbModel").value))
    {
        var ddlgradelevel=$("ddlModel");
        if($("tbModel").value!=ddlgradelevel.options[ddlgradelevel.selectedIndex].text)
        {
            for(var i=0;i<ddlgradelevel.options.length;i++)
            {
                if(ddlgradelevel.options[i].value!="0")
                {
                    if(ddlgradelevel.options[i].text==$("tbModel").value)
                    {
                        ddlgradelevel.options[i].selected=true;
                        bnull=false;
                    }
                }else{$("tbModel").value="";}
            }
            
            if(bnull)
            {
                for(var i=0;i<ddlgradelevel.options.length;i++)
                {
                    if(ddlgradelevel.options[i].text=="")
                    {
                        ddlgradelevel.options[i].selected=true;
                    }
                }
                $("tbModel").value="";
                
             }
        }
    }
}