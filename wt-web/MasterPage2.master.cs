using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage2 : System.Web.UI.MasterPage
{
    public string _tabtitle = "";
    public string TabTitle
    {
        get
        {
            return _tabtitle;
        }
        set
        {
            _tabtitle = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
