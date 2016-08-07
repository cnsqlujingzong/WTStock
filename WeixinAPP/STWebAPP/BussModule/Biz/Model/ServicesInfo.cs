using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussModule.Biz.Model
{
   public class ServicesInfo
    {
       public fw_services ServiceDetail { get; set; }//服务详情
       public List<fw_servicesprocess> ServiceProcess { get; set; }//服务处理
       public List<fw_servicesmaterial> ServiceMaterial { get; set; }//服务备件
       public List<fw_servicesitem> ServiceItem { get; set; }//服务项目
       public List<ServicesDeviceConf> ServicesDeviceConfig { get; set; }//机器配置
       public List<fw_servicesoffer> ServiceOffer { get; set; }//服务报价
       public List<fw_servicespush> ServicePush { get; set; }//催单
       public List<ks_qtylist> KSQty { get; set; }//计数器
       public List<Cd_ImgStock> ImgStock { get; set; }//图片
       public List<fw_serviceslog> ServiceLog { get; set; }//日志





    }
}
