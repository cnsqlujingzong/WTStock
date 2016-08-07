function SltStock()
{
    parent.ShowDialog(500, 320, 'Basic/SltStock.aspx', '选择仓库');
}
function SltUnit()
{
    var id=$("hfRecID").value;
    parent.ShowDialog(260, 200, 'Stock/SltUnit.aspx?id='+id, '选择产品单位');
}
function SltUnitQty(tbqty)
{
    var id=$("hfRecID").value;
    var uid=$("hfUnitID").value;
    var qty=$(tbqty).value;
    parent.ShowDialog(260, 200, 'Stock/SltUnitQty.aspx?id='+id+'&uid='+uid+'&qty='+qty+'&tbqty='+tbqty, '产品多单位数量');
}
function SltPrice(flag,tbprice)
{
    var id=$("hfRecID").value;
    var uid=$("hfUnitID").value;
    
    var cusid;
    if($("hfCusID")!=null)
    {
        cusid=$("hfCusID").value;
    }
    else if($("hfSupID")!=null)
    {
        cusid=$("hfSupID").value;
    }
    
    parent.ShowDialog(260, 260, 'Stock/SltPrice.aspx?id='+id+'&uid='+uid+'&tbprice='+tbprice+'&flag='+flag+'&cusid='+cusid, '选择产品单价');
}

function SltStock1()
{
    parent.ShowDialog1(500, 320, 'Basic/SltStock.aspx', '选择仓库');
}
function SltUnit1()
{
    var id=$("hfRecID").value;
    parent.ShowDialog1(260, 200, 'Stock/SltUnit.aspx?id='+id, '选择产品单位');
}
function SltUnitQty1(tbqty)
{
    var id=$("hfRecID").value;
    var uid=$("hfUnitID").value;
    var qty=$(tbqty).value;
    parent.ShowDialog1(260, 200, 'Stock/SltUnitQty.aspx?id='+id+'&uid='+uid+'&qty='+qty+'&tbqty='+tbqty, '产品多单位数量');
}
function SltPrice1(flag,tbprice)
{
    var id=$("hfRecID").value;
    var uid=$("hfUnitID").value;
    parent.ShowDialog1(260, 260, 'Stock/SltPrice.aspx?id='+id+'&uid='+uid+'&tbprice='+tbprice+'&flag='+flag, '选择产品单价');
}
function SltPrice2(flag,tbprice)
{
    var id=$("hfRecID").value;
    var uid=$("hfUnitID").value;
    parent.ShowDialog2(260, 260, 'Stock/SltPrice.aspx?f=2&fid=iframeDialog1&id='+id+'&uid='+uid+'&tbprice='+tbprice+'&flag='+flag, '选择产品单价');
}
function SltPrice3(flag,tbprice)
{
    var id=$("hfRecID").value;
    var uid=$("hfUnitID").value;
    parent.ShowDialog3(260, 260, 'Stock/SltPrice.aspx?f=3&fid=iframeDialog2&id='+id+'&uid='+uid+'&tbprice='+tbprice+'&flag='+flag, '选择产品单价');
}