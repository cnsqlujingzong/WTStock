<%@ Application Language="C#" %>

<script runat="server">

    protected void Application_Start(Object sender, EventArgs e)
    {
        #region 默认蓝

        Application["1xtop1_bgimage"] = "images/top-1.gif"; //顶框背景图片
        Application["1xtop2_bgimage"] = "images/top-2.gif"; //顶框背景图片
        Application["1xtop3_bgimage"] = "images/top-3.gif"; //顶框背景图片
        Application["1xtop4_bgimage"] = "images/top-4.gif"; //顶框背景图片
        Application["1xtop5_bgimage"] = "images/top-5.gif"; //顶框背景图片
        Application["1xtopbj_bgimage"] = "images/top-bj.gif"; //顶框背景图片

        Application["1xtopbar_bgimage"] = "images/topbar_01.jpg"; //顶框工具条背景图片
        Application["1xfirstpage_bgimage"] = "images/dbsx_01.gif"; //首页背景图片
        Application["1xforumcolor"] = "#f0f4fb";
        Application["1xleft_width"] = "204"; //左框架宽度

        Application["1xtree_bgcolor"] = "#e3eeff"; //左框架树背景色
        Application["1xleft1_bgimage"] = "images/left-1.gif";
        Application["1xleft2_bgimage"] = "images/left-2.gif";
        Application["1xleft3_bgimage"] = "images/left-3.gif";
        Application["1xleftbj_bgimage"] = "images/left-bj.gif";

        Application["1xspliter_color"] = "#6B7DDE"; //分隔块色

        Application["1xdesktop_bj"] = "";//images/right-bj.gif
        Application["1xdesktop_bgimage"] = "images/desktop_01.gif";//right.gif

        Application["1xtable_bgcolor"] = "#F5F9FF"; //最外层表格背景
        Application["1xtable_bordercolorlight"] = "#4F7FC9"; //中层表格亮边框
        Application["1xtable_bordercolordark"] = "#D3D8E0"; //中层表格暗边框
        Application["1xtable_titlebgcolor"] = "#E3EFFF"; //中层表格标题栏

        Application["1xform_requestcolor"] = "#E78A29"; //表单中必填字段*颜色
        Application["1xfirstpage_topimage"] = "images/top_01.gif";
        Application["1xfirstpage_bottomimage"] = "images/bottom_01.gif";
        Application["1xfirstpage_middleimage"] = "images/bg_01.gif";
        #endregion

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  在应用程序关闭时运行的代码

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // 在出现未处理的错误时运行的代码

    }

    protected void Session_Start(Object sender, EventArgs e)
    {
        Session["Style"] = 1;
    }

    void Session_End(object sender, EventArgs e) 
    {
        // 在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
        // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer
        // 或 SQLServer，则不引发该事件。

    }
       
</script>
