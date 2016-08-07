
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
var patrn=/^(-?\d+)(\.\d{1,4})?$/; 
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

//去掉首尾空格
function Trim(str)
{
    return str.replace(/(^\s*)|(\s*$)/g,"");
}

function ChkMoney(obj)
{
    if(!isNull(obj.value))
    {
        if(!isMoney(obj.value))
        {
            window.alert("格式不正确，输入将被撤消");
            if(obj.getAttribute("oldNum"))
            {
                obj.value=obj.getAttribute("oldNum");
            }else
            obj.value=obj.getAttribute("old");
            obj.select()
            return false;
        }
        else
        {
            obj.setAttribute("old",obj.value);
        }
    }
}

//检查输入
function ValidateNums(obj)
{
    if(!isNull(obj.value))
    {
        if(!isDigit(obj.value))
        {
            window.alert("格式不正确，输入格式必须全为数字");
            obj.value="";
            obj.select()
            return false;
        }
    }
}

//检查单位关系
function ValidateUnitR(obj)
{
    if(!isNull(obj.value))
    {
        if(!isDigit(obj.value))
        {
            window.alert("格式不正确，输入格式必须全为数字");
            obj.value="";
            obj.select()
            return false;
        }else
        {
            if(parseInt(obj.value)>1)
            {}
            else
            {
                window.alert("单位关系必须大于1");
                obj.value="";
                obj.select()
                return false;
            }
        }
    }
}
