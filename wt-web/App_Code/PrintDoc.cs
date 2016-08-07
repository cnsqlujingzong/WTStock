using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using wt.DAL;
using System.Data;
using iTextSharp.text.pdf;
using System.IO;
using Coding.Stock.Common;
/// <summary>
/// PrintDoc 的摘要说明
/// </summary>
public class PrintDoc
{
	public PrintDoc()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//    
	}
    //指定字体库，并创建字体  华文中宋 STZHONGS.TTF  STSONG.TTF
    BaseFont baseFont = BaseFont.CreateFont(System.Web.HttpContext.Current.Server.MapPath("~/dll/STSONG.TTF"), BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
    /// <summary>
    /// 销售订单
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public MemoryStream PrintXSDD(string num,out string fname)
    {
        int MaxCount = 6;

        DataTable spn = DALCommon.GetDataList("xs_sellplan", "", " [ID]=" + num).Tables[0];
        DataTable spd = DALCommon.GetDataList("xs_sellplandetail", "", " [BillID]=" + num).Tables[0];


        MemoryStream stream = new MemoryStream();
        
        iTextSharp.text.Font FontBig = new iTextSharp.text.Font(baseFont, 16f); FontBig.IsBold();
        iTextSharp.text.Font FontNorm = new iTextSharp.text.Font(baseFont, 10f);
        iTextSharp.text.Font FontSmall = new iTextSharp.text.Font(baseFont, 8f);
        iTextSharp.text.Font FontTitle = new iTextSharp.text.Font(baseFont, 12f,Font.BOLD);
        
      //  iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 8.5f);
         //页面大小
         Document doc = new Document(PageSize.A4);
        doc.SetMargins(0f, 0f, 10f, 0f);    
        //文件流
        PdfWriter pdfWritey = PdfWriter.GetInstance(doc, stream);
        pdfWritey.CloseStream = false;
        doc.Open();
    
        //标题三行
        Paragraph title;
        title = new Paragraph(spn.Rows[0]["BillID"].ToString() + " " + spn.Rows[0]["_Name"].ToString(), FontSmall);
        title.IndentationLeft = 30;
        doc.Add(title);
        fname = spn.Rows[0]["BillID"].ToString() + " " + spn.Rows[0]["_Name"].ToString();
        string cname = spn.Rows[0]["BrandName"].ToString() == "总部" ? "北京盛唐和讯科技有限公司" : spn.Rows[0]["BrandName"].ToString();
        title = new Paragraph(cname, FontBig);
        title.Alignment=Element.ALIGN_CENTER;
        doc.Add(title);
        title = new Paragraph("报价单", FontBig);
        title.Alignment = Element.ALIGN_CENTER;
       Paragraph t2=  new Paragraph("  ", FontBig);
        doc.Add(title);
        doc.Add(t2);
        //内容
        PdfPTable table = new PdfPTable(4) { WidthPercentage = 90 };//根据列配置确定表格列数量
        
        PdfPCell[] cellBody = new PdfPCell[4];
        int[] ws=new[]{13,47,13,27};
        table.SetWidths(ws);
        cellBody[0] = new PdfPCell(new Phrase("买方(甲方)：", FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
          // Width = Utilities.MillimetersToPoints(10),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment=Element.ALIGN_LEFT
        };

        cellBody[1] = new PdfPCell(new Phrase(spn.Rows[0]["_Name"].ToString(), FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
          //  Width = Utilities.MillimetersToPoints(20),
            BorderColor = BaseColor.WHITE,
              HorizontalAlignment=Element.ALIGN_LEFT
        };

        cellBody[2] = new PdfPCell(new Phrase("合同编号", FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            //Width = Utilities.MillimetersToPoints(10),
            BorderColor = BaseColor.WHITE,
              HorizontalAlignment=Element.ALIGN_RIGHT
        };
        cellBody[3] = new PdfPCell(new Phrase(spn.Rows[0]["BillID"].ToString(), FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            //Width = Utilities.MillimetersToPoints(20),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_LEFT
        };
        PdfPRow rowBody = new PdfPRow(cellBody);
        table.Rows.Add(rowBody);


        cellBody = new PdfPCell[4];
        cellBody[0] = new PdfPCell(new Phrase("卖方(乙方)：", FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_LEFT
        };
        //"北京盛唐和讯科技有限公司"
        cellBody[1] = new PdfPCell(new Phrase(cname, FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_LEFT
        };

        cellBody[2] = new PdfPCell(new Phrase("签订地点", FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_RIGHT
        };
        cellBody[3] = new PdfPCell(new Phrase("北京", FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_LEFT
        };
         rowBody = new PdfPRow(cellBody);
         table.Rows.Add(rowBody);
         doc.Add(table);
        //条款
         string t1 = "  根据《中华人民共和国合同法》及有关相关法规，经双方充分协商，特订立本合同，共同遵守。";
         string t11 = "  第一条 产品规格、数量、价格、备注：";
         doc.Add(new Paragraph(t1, FontNorm) { IndentationLeft=30});
         doc.Add(new Paragraph(t11, FontNorm) { IndentationLeft =30 });
         doc.Add(new Paragraph(" ", FontNorm));
        //产品详细
         PdfPTable detail_table = new PdfPTable(10) { WidthPercentage = 90 };//根据列配置确定表格列数量       
         int[] ws2 = new[] { 5, 13, 13,12,7,7,8,10,8,12 };
         detail_table.SetWidths(ws2);
         PdfPCell[] detail_cell = new PdfPCell[10];
         detail_cell[0] = new PdfPCell(new Phrase("序号", FontNorm))
         {
             BorderWidth = 1,
             MinimumHeight = Utilities.MillimetersToPoints(6),
             BorderColor = BaseColor.BLACK,
             HorizontalAlignment = Element.ALIGN_CENTER,
             VerticalAlignment = Element.ALIGN_MIDDLE
         };
         detail_cell[1] = new PdfPCell(new Phrase("订货号", FontNorm))
         {
             BorderWidth = 1,
             MinimumHeight = Utilities.MillimetersToPoints(6),
             BorderColor = BaseColor.BLACK,
             HorizontalAlignment = Element.ALIGN_CENTER,
                 VerticalAlignment = Element.ALIGN_MIDDLE
         };
         detail_cell[2] = new PdfPCell(new Phrase("型号", FontNorm))
         {
             BorderWidth = 1,
             MinimumHeight = Utilities.MillimetersToPoints(6),
             BorderColor = BaseColor.BLACK,
             HorizontalAlignment = Element.ALIGN_CENTER,
             VerticalAlignment = Element.ALIGN_MIDDLE
         };
         detail_cell[3] = new PdfPCell(new Phrase("名称", FontNorm))
         {
             BorderWidth = 1,
             MinimumHeight = Utilities.MillimetersToPoints(6),
             BorderColor = BaseColor.BLACK,
             HorizontalAlignment = Element.ALIGN_CENTER,
             VerticalAlignment = Element.ALIGN_MIDDLE
         };
         detail_cell[4] = new PdfPCell(new Phrase("品牌", FontNorm))
         {
             BorderWidth = 1,
             MinimumHeight = Utilities.MillimetersToPoints(6),
             BorderColor = BaseColor.BLACK,
             HorizontalAlignment = Element.ALIGN_CENTER,
             VerticalAlignment = Element.ALIGN_MIDDLE
         };
         detail_cell[5] = new PdfPCell(new Phrase("数量", FontNorm))
         {
             BorderWidth = 1,
             MinimumHeight = Utilities.MillimetersToPoints(6),
             BorderColor = BaseColor.BLACK,
             HorizontalAlignment = Element.ALIGN_CENTER,
             VerticalAlignment = Element.ALIGN_MIDDLE
         };
         detail_cell[6] = new PdfPCell(new Phrase("单价", FontNorm))
         {
             BorderWidth = 1,
             MinimumHeight = Utilities.MillimetersToPoints(6),
             BorderColor = BaseColor.BLACK,
             HorizontalAlignment = Element.ALIGN_CENTER,
             VerticalAlignment = Element.ALIGN_MIDDLE
         };
         detail_cell[7] = new PdfPCell(new Phrase("小计", FontNorm))
         {
             BorderWidth = 1,
             MinimumHeight = Utilities.MillimetersToPoints(6),
             BorderColor = BaseColor.BLACK,
             HorizontalAlignment = Element.ALIGN_CENTER,
             VerticalAlignment = Element.ALIGN_MIDDLE
         };
         detail_cell[8] = new PdfPCell(new Phrase("货期", FontNorm))
         {
             BorderWidth = 1,
             MinimumHeight = Utilities.MillimetersToPoints(6),
             BorderColor = BaseColor.BLACK,
             HorizontalAlignment = Element.ALIGN_CENTER,
             VerticalAlignment = Element.ALIGN_MIDDLE
         };
         detail_cell[9] = new PdfPCell(new Phrase("备注", FontNorm))
         {
             BorderWidth = 1,
             MinimumHeight = Utilities.MillimetersToPoints(6),
             BorderColor = BaseColor.BLACK,
             HorizontalAlignment = Element.ALIGN_CENTER,
             VerticalAlignment = Element.ALIGN_MIDDLE
         };
         PdfPRow drowBody = new PdfPRow(detail_cell);
         detail_table.Rows.Add(drowBody);

         decimal OrderPrice = 0;
         if (spd.Rows.Count <= MaxCount)
         {
             for (int i = 0; i < spd.Rows.Count; i++)
             {
                 OrderPrice += Convert.ToDecimal(spd.Rows[i]["Total"]);
                 detail_cell = new PdfPCell[10];
                 detail_cell[0] = new PdfPCell(new Phrase((i + 1).ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                 detail_cell[1] = new PdfPCell(new Phrase(spd.Rows[i]["GoodsNO"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                 detail_cell[2] = new PdfPCell(new Phrase(spd.Rows[i]["spec"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                 detail_cell[3] = new PdfPCell(new Phrase(spd.Rows[i]["_Name"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                 detail_cell[4] = new PdfPCell(new Phrase(spd.Rows[i]["ProductBrand"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                 detail_cell[5] = new PdfPCell(new Phrase(spd.Rows[i]["Qty"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                 detail_cell[6] = new PdfPCell(new Phrase(spd.Rows[i]["Price"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                 detail_cell[7] = new PdfPCell(new Phrase(spd.Rows[i]["Total"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                 detail_cell[8] = new PdfPCell(new Phrase(spd.Rows[i]["huoqi"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                 detail_cell[9] = new PdfPCell(new Phrase(spd.Rows[i]["Remark"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                 drowBody = new PdfPRow(detail_cell);
                 detail_table.Rows.Add(drowBody);
             }
             //for (int ii = 0; ii < MaxCount - spd.Rows.Count; ii++)
             //{
             //    detail_cell = new PdfPCell[10];
             //    detail_cell[0] = new PdfPCell(new Phrase("", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
             //    detail_cell[1] = new PdfPCell(new Phrase("", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
             //    detail_cell[2] = new PdfPCell(new Phrase("", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
             //    detail_cell[3] = new PdfPCell(new Phrase("", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
             //    detail_cell[4] = new PdfPCell(new Phrase("", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
             //    detail_cell[5] = new PdfPCell(new Phrase("", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
             //    detail_cell[6] = new PdfPCell(new Phrase("", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
             //    detail_cell[7] = new PdfPCell(new Phrase("", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
             //    detail_cell[8] = new PdfPCell(new Phrase("", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
             //    detail_cell[9] = new PdfPCell(new Phrase("", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
              
             //    drowBody = new PdfPRow(detail_cell);
             //    detail_table.Rows.Add(drowBody);
             //}
             //合计
             detail_cell = new PdfPCell[10];
             detail_cell[0] = new PdfPCell(new Phrase("总计", FontNorm)) { Colspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
             detail_cell[2] = new PdfPCell(new Phrase("（大写）：" + UpperRMB.CmycurD(OrderPrice.ToString()), FontNorm)) { Colspan = 4, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
             detail_cell[6] = new PdfPCell(new Phrase("（小写）：" + OrderPrice.ToString(), FontNorm)) { Colspan = 4, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
             drowBody = new PdfPRow(detail_cell);
             detail_table.Rows.Add(drowBody);
             doc.Add(detail_table);
         }
         else {
             for (int i = 0; i < spd.Rows.Count; i++)
             {
                 OrderPrice += Convert.ToDecimal(spd.Rows[i]["Total"]);
             }

             PdfPTable table2 = new PdfPTable(4) { WidthPercentage = 90 };//根据列配置确定表格列数量       
             int[] tab2w = new[] { 10,35,30,25};
             table2.SetWidths(tab2w);
             PdfPRow row2 ;
             PdfPCell[] dcell2 = new PdfPCell[4];
             dcell2[0] = new PdfPCell(new Phrase("序号", FontNorm));
             dcell2[1] = new PdfPCell(new Phrase("产品型号", FontNorm));
             dcell2[2] = new PdfPCell(new Phrase("总合计", FontNorm));
             dcell2[3] = new PdfPCell(new Phrase("交货期", FontNorm));
             row2 = new PdfPRow(dcell2);
             table2.Rows.Add(row2);

             dcell2 = new PdfPCell[4];
             dcell2[0] = new PdfPCell(new Phrase("1", FontNorm));
             dcell2[1] = new PdfPCell(new Phrase("详细见合同附件\"货物清单\"", FontNorm));
             dcell2[2] = new PdfPCell(new Phrase(OrderPrice.ToString(".00"), FontNorm));
             dcell2[3] = new PdfPCell(new Phrase("2~3周", FontNorm));
             row2 = new PdfPRow(dcell2);
             table2.Rows.Add(row2);

             List<PdfPRow> rowList2 = table2.Rows;
             foreach (var row in rowList2)
             {
                  PdfPCell[] cells= row.GetCells();
                   foreach (PdfPCell item in cells)
                   {
                      item.BorderWidth = 1;
                     item.MinimumHeight = Utilities.MillimetersToPoints(6);
                     item.BorderColor = BaseColor.BLACK;
                     item.HorizontalAlignment = Element.ALIGN_CENTER;
                     item.VerticalAlignment = Element.ALIGN_MIDDLE;
                   }
             }
             doc.Add(table2);
             //title = new Paragraph("详细列表见下页", FontTitle);
             //title.IndentationLeft = 30;
             //doc.Add(title);
             //doc.Add(new Paragraph(" ", FontNorm));
         }
        string t3 = @"第二条 质量标准：厂家标准。        
第三条 出卖人对质量保证的条件及期限：见清单。            
第四条 包装标准、包装物的供应与回收：无。    
第五条 合理损耗标准及计算方法：无。                
第六条 标的物所有权自买受人付款时时转移，买受人未履行完支付价款义务的，标的物属于出卖人单位所有。 
第七条 交（提）货时间：预计发货日期 , 货期以定货款到帐后开始计算。 
第八条 运输方式及送货地址：         
收货地址：{0}                               
收货人：{1} 电话：{2}。        
第九条 检验标准、方法、地点及期限：按厂家标准。          
第十条 结算方式、时间及地点：，                             
第十一条 发票类型：{3}。              
第十二条 付款信息：     
{4}
第十三条 本合同解除的条件：质保期满。            
第十四条 违约责任：质量。   
第十五条 合同争议的解决方式：当地法院仲裁。     
第十六条 本合同一式贰份，双方各执壹份，自双方签字盖章之日起生效，传真件与原件具有同等法律效力。";
        string payinfo = "";
        DataTable dt_branch;//网点信息
        string lm_phone = "";
        string lm_fax = "";
        string lm_mail = "";

        string sell_phone1 = "";
        string sell_phone2 = "";
        string sell_fax = "";
        string sell_mail = "";
        string sell_adr = "";
        if (spn.Rows[0]["BrandName"].ToString() == "总部")
        {
            payinfo = "开户行:中国民生银行股份有限公司北京上地支行 账号: 0110014170025222 所有者：北京盛唐和迅科技有限公司  ";

        }
        else 
        {
            dt_branch = DALCommon.GetDataList("BranchList", "", " [_Name]='" + spn.Rows[0]["BrandName"].ToString() + "' ").Tables[0];
            if (dt_branch.Rows.Count>0)
            { 
                payinfo=dt_branch.Rows[0]["Account"].ToString();
                sell_phone1 = dt_branch.Rows[0]["Tel"].ToString();
                sell_fax = dt_branch.Rows[0]["Fax"].ToString();
                sell_mail = dt_branch.Rows[0]["Email"].ToString();
                sell_adr = dt_branch.Rows[0]["Adr"].ToString();
            }
        }
        //spn.Rows[0]["Operator"].ToString()  销售员信息
        DataTable sellinfo = DALCommon.GetDataList("jc_staff", "", " [_Name]='" + spn.Rows[0]["Operator"].ToString() + "' ").Tables[0];
       if (sellinfo.Rows.Count>0)
        {
            sell_phone2 = sellinfo.Rows[0]["Tel"].ToString();          
        }
       DataTable cuinfo = DALCommon.GetDataList("CustomerList", "", " [LinkMan]='" + spn.Rows[0]["LinkMan"].ToString() + "' and [_Name]='" + spn.Rows[0]["_Name"].ToString() + "' ").Tables[0];
       if (cuinfo.Rows.Count>0)
       {
           lm_phone = cuinfo.Rows[0]["Tel2"].ToString();
           lm_fax = cuinfo.Rows[0]["Fax"].ToString();
           lm_mail = cuinfo.Rows[0]["Email"].ToString();        
       }

        string ratioType="";
        if(spn.Rows[0]["BrandTaxRateType"].ToString()=="无" || Convert.ToDecimal(spn.Rows[0]["BrandTaxRate"])==0 )
        {
            ratioType = "不含税";
        }else{
            ratioType = spn.Rows[0]["BrandTaxRateType"].ToString() + "：" + Math.Round(Convert.ToDecimal(spn.Rows[0]["BrandTaxRate"]) * 100, 0).ToString() + "%";
        }
            Chunk beginning = new Chunk(string.Format(t3, spn.Rows[0]["Adr"].ToString(), spn.Rows[0]["LinkMan"].ToString(), spn.Rows[0]["Tel"].ToString(), ratioType, payinfo,""), FontNorm);
        Phrase p1 = new Phrase(beginning);
        Paragraph p = new Paragraph();
        p.Add(p1);
        p.IndentationLeft = 30;
      doc.Add(p);
      doc.Add(t2);//空白行
        //发货联系

      PdfPTable tb_cat = new PdfPTable(4);//根据列配置确定表格列数量   WidthPercentage = 90
      PdfPCell[] cell_cat = new PdfPCell[4];
      PdfPRow row_cat;
      int[] ws_cat = new[] { 15, 35, 15, 35 };
      tb_cat.SetWidths(ws_cat);
       cell_cat[0] = new PdfPCell(new Phrase("买方单位名称", FontNorm));
      cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["_Name"].ToString(), FontNorm));
      cell_cat[2] = new PdfPCell(new Phrase("卖方单位名称", FontNorm));
      cell_cat[3] = new PdfPCell(new Phrase(cname, FontNorm));
      row_cat = new PdfPRow(cell_cat);
      tb_cat.Rows.Add(row_cat);

      cell_cat = new PdfPCell[4];
      cell_cat[0] = new PdfPCell(new Phrase("单位地址", FontNorm));
      cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["Adr"].ToString(), FontNorm));
      cell_cat[2] = new PdfPCell(new Phrase("单位地址", FontNorm));
      cell_cat[3] = new PdfPCell(new Phrase(sell_adr, FontNorm));
      row_cat = new PdfPRow(cell_cat);
      tb_cat.Rows.Add(row_cat);

      cell_cat = new PdfPCell[4];
      cell_cat[0] = new PdfPCell(new Phrase("法定代表人", FontNorm));
      cell_cat[1] = new PdfPCell(new Phrase("", FontNorm));
      cell_cat[2] = new PdfPCell(new Phrase("法定代表人", FontNorm));
      cell_cat[3] = new PdfPCell(new Phrase("鲁春宝", FontNorm));
      row_cat = new PdfPRow(cell_cat);
      tb_cat.Rows.Add(row_cat);

      cell_cat = new PdfPCell[4];
      cell_cat[0] = new PdfPCell(new Phrase("委托代理人", FontNorm));
      cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["LinkMan"].ToString(), FontNorm));
      cell_cat[2] = new PdfPCell(new Phrase("委托代理人", FontNorm));
      cell_cat[3] = new PdfPCell(new Phrase(spn.Rows[0]["Operator"].ToString(), FontNorm));
      row_cat = new PdfPRow(cell_cat);
      tb_cat.Rows.Add(row_cat);

      cell_cat = new PdfPCell[4];
      cell_cat[0] = new PdfPCell(new Phrase("联系人手机", FontNorm));
      cell_cat[1] = new PdfPCell(new Phrase(lm_phone, FontNorm));
      cell_cat[2] = new PdfPCell(new Phrase("联系人手机", FontNorm));
      cell_cat[3] = new PdfPCell(new Phrase(sell_phone2, FontNorm));
      row_cat = new PdfPRow(cell_cat);
      tb_cat.Rows.Add(row_cat);

      cell_cat = new PdfPCell[4];
      cell_cat[0] = new PdfPCell(new Phrase("电话", FontNorm));
      cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["Tel"].ToString(), FontNorm));
      cell_cat[2] = new PdfPCell(new Phrase("电话", FontNorm));
      cell_cat[3] = new PdfPCell(new Phrase(sell_phone1, FontNorm));
      row_cat = new PdfPRow(cell_cat);
      tb_cat.Rows.Add(row_cat);

      cell_cat = new PdfPCell[4];
      cell_cat[0] = new PdfPCell(new Phrase("传真", FontNorm));
      cell_cat[1] = new PdfPCell(new Phrase(lm_fax, FontNorm));
      cell_cat[2] = new PdfPCell(new Phrase("传真", FontNorm));
      cell_cat[3] = new PdfPCell(new Phrase(sell_fax, FontNorm));
      row_cat = new PdfPRow(cell_cat);
      tb_cat.Rows.Add(row_cat);

      cell_cat = new PdfPCell[4];
      cell_cat[0] = new PdfPCell(new Phrase("邮箱", FontNorm));
      cell_cat[1] = new PdfPCell(new Phrase(lm_mail, FontNorm));
      cell_cat[2] = new PdfPCell(new Phrase("邮箱", FontNorm));
      cell_cat[3] = new PdfPCell(new Phrase(sell_mail, FontNorm));
      row_cat = new PdfPRow(cell_cat);
      tb_cat.Rows.Add(row_cat);

      foreach (PdfPRow row in tb_cat.Rows)
	{        
       PdfPCell[] cells= row.GetCells();
       foreach (PdfPCell item in cells)
       {
          item.BorderWidth = 1;
         item.MinimumHeight = Utilities.MillimetersToPoints(6);
         item.BorderColor = BaseColor.BLACK;
         item.HorizontalAlignment = Element.ALIGN_CENTER;
         item.VerticalAlignment = Element.ALIGN_MIDDLE;
       }
	}
        //doc.PageSize.Width - 36f - 200f, 130f
    tb_cat.TotalWidth = 560f;
    tb_cat.WriteSelectedRows(0, -1, doc.PageSize.Width - 36f - 540f,160f,pdfWritey.DirectContent);


  Image img;
  string wdName = cname;//spn.Rows[0]["BrandName"].ToString();
  if (wdName.IndexOf("凡驰") >=0)
  {
      img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "fc.jpg");
  }
  else if (wdName.IndexOf("美福洋") >=0)
  {
      img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "mfy.jpg");
  }
  else if (wdName.IndexOf("盛唐") >= 0)
  {
      img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "sthx.jpg");
  }
  else if (wdName.IndexOf("贝利") >= 0)
  {
      img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "bl.png");
  }
  else if (wdName.IndexOf("华宇") >= 0)
  {
      img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "hy.png");
  }
  else
  {
      img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "null.png");
  }
  img.ScaleToFit(150f, 150f);
  img.SetAbsolutePosition(doc.PageSize.Width - 36f - 200f, 20f);
  //if (spd.Rows.Count > MaxCount)
  //{
  //    //大于5在第一页固定位置
  //    img.SetAbsolutePosition(doc.PageSize.Width - 36f - 200f, 130f);
  //}
  //else {
  //    img.SetAbsolutePosition(doc.PageSize.Width - 36f - 200f, 20f);
  //}
  doc.Add(img);
  if (spd.Rows.Count > MaxCount)
  {
      doc.NewPage();
      title = new Paragraph("附件合同", FontBig);
      title.Alignment = Element.ALIGN_CENTER;
      doc.Add(title);//第二页标题
      title = new Paragraph(" ", FontNorm);
      doc.Add(title);
      doc.Add(table);//第二页表头
      title = new Paragraph(" ", FontNorm);
      title.IndentationLeft = 30;
      doc.Add(title);

      PdfPTable table3 = new PdfPTable(8) { WidthPercentage = 90 };//根据列配置确定表格列数量       
      int[] tab3w = new[] { 6,20, 20, 8,10,11,8,12 };
      table3.SetWidths(tab3w);
      PdfPRow row3;
      PdfPCell[] dcell3 = new PdfPCell[8];
      dcell3[0] = new PdfPCell(new Phrase("序号", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
      dcell3[1] = new PdfPCell(new Phrase("产品名称", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
      dcell3[2] = new PdfPCell(new Phrase("产品型号", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
      dcell3[3] = new PdfPCell(new Phrase("数量", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
      dcell3[4] = new PdfPCell(new Phrase("单价(元)", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
      dcell3[5] = new PdfPCell(new Phrase("金额(元)", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
      dcell3[6] = new PdfPCell(new Phrase("货期", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
      dcell3[7] = new PdfPCell(new Phrase("备注", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
      row3 = new PdfPRow(dcell3);
      table3.Rows.Add(row3);
      for (int i = 0; i < spd.Rows.Count; i++)
      {
          dcell3 = new PdfPCell[8];
          dcell3[0] = new PdfPCell(new Phrase((i + 1).ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
          dcell3[1] = new PdfPCell(new Phrase(spd.Rows[i]["_Name"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
        //  dcell3[1] = new PdfPCell(new Phrase(spd.Rows[i]["GoodsNO"].ToString(), FontNorm));
          dcell3[2] = new PdfPCell(new Phrase(spd.Rows[i]["spec"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };       
         // dcell3[4] = new PdfPCell(new Phrase(spd.Rows[i]["ProductBrand"].ToString(), FontNorm)) ;
          dcell3[3] = new PdfPCell(new Phrase(spd.Rows[i]["Qty"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
          dcell3[4] = new PdfPCell(new Phrase(spd.Rows[i]["Price"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
          dcell3[5] = new PdfPCell(new Phrase(spd.Rows[i]["Total"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
          dcell3[6] = new PdfPCell(new Phrase(spd.Rows[i]["huoqi"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
       
          dcell3[7] = new PdfPCell(new Phrase(spd.Rows[i]["Remark"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
       
          row3 = new PdfPRow(dcell3);
          table3.Rows.Add(row3);
      }   
      //合计
      dcell3 = new PdfPCell[8];
      dcell3[0] = new PdfPCell(new Phrase("总计", FontNorm)) { Colspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
      dcell3[2] = new PdfPCell(new Phrase("（大写）：" + UpperRMB.CmycurD(OrderPrice.ToString()), FontNorm)) { Colspan = 3, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
      dcell3[5] = new PdfPCell(new Phrase("（小写）：" + OrderPrice.ToString(), FontNorm)) { Colspan = 3, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
      row3 = new PdfPRow(dcell3);
      table3.Rows.Add(row3);    
      doc.Add(table3);

      PdfDiv div = new PdfDiv();
      div.TextAlignment = Element.ALIGN_RIGHT;//cname
      div.PaddingRight = 30;
      Paragraph cop = new Paragraph(" ", FontBig);
      div.AddElement(cop);
      cop= new Paragraph(cname, FontBig);
      cop.Alignment = Element.ALIGN_RIGHT;
      div.AddElement(cop);
      cop = new Paragraph(string.Format("{0:yyyy-MM-dd}",DateTime.Now), FontBig);
      cop.Alignment = Element.ALIGN_RIGHT;
      div.AddElement(cop);
      doc.Add(div);
      img.SetAbsolutePosition(doc.PageSize.Width - 36f - 130f,doc.PageSize.Height- ((spd.Rows.Count+2)*21+200));//410
      doc.Add(img);
    
  }
   doc.Close();
    return stream;
 
    }
    /// <summary>
    /// 合同
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public MemoryStream PrintXSD(string num,out string fname)
    {
        int MaxCount = 6;
        // DALCommon.GetDataList("xs_sellplandetail", "", " BillID=" + this.hfRecID.Value);
        DataTable spn = DALCommon.GetDataList("xs_sell", "", " [ID]=" + num).Tables[0];
        DataTable spd = DALCommon.GetDataList("xs_selldetail", "", " [BillID]=" + num).Tables[0];
        MemoryStream stream = new MemoryStream();
      
        iTextSharp.text.Font FontBig = new iTextSharp.text.Font(baseFont, 16f); FontBig.IsBold();
        iTextSharp.text.Font FontNorm = new iTextSharp.text.Font(baseFont, 10f);
        iTextSharp.text.Font FontSmall = new iTextSharp.text.Font(baseFont, 8f);
        iTextSharp.text.Font FontTitle = new iTextSharp.text.Font(baseFont, 12f, Font.BOLD);
        //页面大小
        Document doc = new Document(PageSize.A4);
        doc.SetMargins(0f, 0f, 5f, 0f);
        //文件流
        PdfWriter pdfWritey = PdfWriter.GetInstance(doc, stream);
        pdfWritey.CloseStream = false;
        doc.Open();
        //标题三行
        Paragraph title;
        title = new Paragraph(spn.Rows[0]["BillID"].ToString() + " " + spn.Rows[0]["_Name"].ToString(), FontSmall);
        title.IndentationLeft = 30;
        doc.Add(title);
        fname = spn.Rows[0]["BillID"].ToString() + " " + spn.Rows[0]["_Name"].ToString();
        string cname = spn.Rows[0]["BrandName"].ToString() == "总部" ? "北京盛唐和讯科技有限公司" : spn.Rows[0]["BrandName"].ToString();
        title = new Paragraph(cname, FontBig);
        title.Alignment = Element.ALIGN_CENTER;
        doc.Add(title);
        title = new Paragraph("销售合同", FontBig);
        title.Alignment = Element.ALIGN_CENTER;
        Paragraph t2 = new Paragraph("  ", FontSmall);
        doc.Add(title);
        doc.Add(t2);
        //内容
        PdfPTable table = new PdfPTable(4) { WidthPercentage = 90 };//根据列配置确定表格列数量

        PdfPCell[] cellBody = new PdfPCell[4];
        int[] ws = new[] { 13, 47, 13, 27 };
        table.SetWidths(ws);
        cellBody[0] = new PdfPCell(new Phrase("买方(甲方)", FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            // Width = Utilities.MillimetersToPoints(10),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_LEFT
        };

        cellBody[1] = new PdfPCell(new Phrase(spn.Rows[0]["_Name"].ToString(), FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            //  Width = Utilities.MillimetersToPoints(20),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_LEFT
        };

        cellBody[2] = new PdfPCell(new Phrase("合同编号", FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            //Width = Utilities.MillimetersToPoints(10),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_RIGHT
        };
        cellBody[3] = new PdfPCell(new Phrase(spn.Rows[0]["BillID"].ToString(), FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            //Width = Utilities.MillimetersToPoints(20),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_LEFT
        };
        PdfPRow rowBody = new PdfPRow(cellBody);
        table.Rows.Add(rowBody);


        cellBody = new PdfPCell[4];
        cellBody[0] = new PdfPCell(new Phrase("卖方(乙方)：", FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_LEFT
        };
        //"北京盛唐和讯科技有限公司"
        cellBody[1] = new PdfPCell(new Phrase(cname, FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_LEFT
        };

        cellBody[2] = new PdfPCell(new Phrase("签订地点", FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_RIGHT
        };
        cellBody[3] = new PdfPCell(new Phrase("北京", FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_LEFT
        };
        rowBody = new PdfPRow(cellBody);
        table.Rows.Add(rowBody);
        doc.Add(table);
        //条款
        string t1 = "  根据《中华人民共和国合同法》及有关相关法规，经双方充分协商，特订立本合同，共同遵守。";
        string t11 = "  第一条 产品规格、数量、价格、备注：";
        doc.Add(new Paragraph(t1, FontNorm) { IndentationLeft = 30 });
        doc.Add(new Paragraph(t11, FontNorm) { IndentationLeft = 30 });
        doc.Add(new Paragraph(" ", FontNorm));
        //产品详细
        PdfPTable detail_table = new PdfPTable(10) { WidthPercentage=90};//根据列配置确定表格列数量       
        int[] ws2 = new[] { 5, 13, 13, 12, 7, 7, 8, 10,8, 12 };
        detail_table.SetWidths(ws2);
        PdfPCell[] detail_cell = new PdfPCell[10];
        detail_cell[0] = new PdfPCell(new Phrase("序号", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[1] = new PdfPCell(new Phrase("订货号", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[2] = new PdfPCell(new Phrase("型号", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[3] = new PdfPCell(new Phrase("名称", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[4] = new PdfPCell(new Phrase("品牌", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[5] = new PdfPCell(new Phrase("数量", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[6] = new PdfPCell(new Phrase("单价", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[7] = new PdfPCell(new Phrase("小计", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[8] = new PdfPCell(new Phrase("货期", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[9] = new PdfPCell(new Phrase("备注", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        PdfPRow drowBody = new PdfPRow(detail_cell);
        detail_table.Rows.Add(drowBody);

        decimal OrderPrice = 0;
        if (spd.Rows.Count <= MaxCount)
        {

            for (int i = 0; i < spd.Rows.Count; i++)
            {
                OrderPrice += Convert.ToDecimal(spd.Rows[i]["Total"]);
                detail_cell = new PdfPCell[10];
                detail_cell[0] = new PdfPCell(new Phrase((i + 1).ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                detail_cell[1] = new PdfPCell(new Phrase(spd.Rows[i]["GoodsNO"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                detail_cell[2] = new PdfPCell(new Phrase(spd.Rows[i]["spec"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                detail_cell[3] = new PdfPCell(new Phrase(spd.Rows[i]["_Name"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                detail_cell[4] = new PdfPCell(new Phrase(spd.Rows[i]["ProductBrand"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                detail_cell[5] = new PdfPCell(new Phrase(spd.Rows[i]["Qty"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                detail_cell[6] = new PdfPCell(new Phrase(spd.Rows[i]["Price"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                detail_cell[7] = new PdfPCell(new Phrase(spd.Rows[i]["Total"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                detail_cell[8] = new PdfPCell(new Phrase(spd.Rows[i]["huoqi"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
               
                detail_cell[9] = new PdfPCell(new Phrase(spd.Rows[i]["Remark"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                drowBody = new PdfPRow(detail_cell);
                detail_table.Rows.Add(drowBody);

            }
            //for (int ii = 0; ii < MaxCount - spd.Rows.Count; ii++)
            //{
            //    detail_cell = new PdfPCell[10];
            //    detail_cell[0] = new PdfPCell(new Phrase("", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            //    detail_cell[1] = new PdfPCell(new Phrase("", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            //    detail_cell[2] = new PdfPCell(new Phrase("", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            //    detail_cell[3] = new PdfPCell(new Phrase("", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            //    detail_cell[4] = new PdfPCell(new Phrase("", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            //    detail_cell[5] = new PdfPCell(new Phrase("", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            //    detail_cell[6] = new PdfPCell(new Phrase("", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            //    detail_cell[7] = new PdfPCell(new Phrase("", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            //    detail_cell[8] = new PdfPCell(new Phrase("", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                
            //    detail_cell[9] = new PdfPCell(new Phrase("", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            //    drowBody = new PdfPRow(detail_cell);
            //    detail_table.Rows.Add(drowBody);
            //}
            //合计
            detail_cell = new PdfPCell[10];
            detail_cell[0] = new PdfPCell(new Phrase("总计", FontNorm)) { Colspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            detail_cell[2] = new PdfPCell(new Phrase("（大写）：" + UpperRMB.CmycurD(OrderPrice.ToString()), FontNorm)) { Colspan = 4, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            detail_cell[6] = new PdfPCell(new Phrase("（小写）：" + OrderPrice.ToString(), FontNorm)) { Colspan = 4, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            drowBody = new PdfPRow(detail_cell);
            detail_table.Rows.Add(drowBody);
            doc.Add(detail_table);
        }
        else {
            for (int i = 0; i < spd.Rows.Count; i++)
            {
                OrderPrice += Convert.ToDecimal(spd.Rows[i]["Total"]);
            }

            PdfPTable table2 = new PdfPTable(4) { WidthPercentage = 90 };//根据列配置确定表格列数量       
            int[] tab2w = new[] { 10, 35, 30, 25 };
            table2.SetWidths(tab2w);
            PdfPRow row2;
            PdfPCell[] dcell2 = new PdfPCell[4];
            dcell2[0] = new PdfPCell(new Phrase("序号", FontNorm));
            dcell2[1] = new PdfPCell(new Phrase("产品型号", FontNorm));
            dcell2[2] = new PdfPCell(new Phrase("总合计", FontNorm));
            dcell2[3] = new PdfPCell(new Phrase("交货期", FontNorm));
            row2 = new PdfPRow(dcell2);
            table2.Rows.Add(row2);

            dcell2 = new PdfPCell[4];
            dcell2[0] = new PdfPCell(new Phrase("1", FontNorm));
            dcell2[1] = new PdfPCell(new Phrase("详细见合同附件\"货物清单\"", FontNorm));
            dcell2[2] = new PdfPCell(new Phrase(OrderPrice.ToString(".00"), FontNorm));
            dcell2[3] = new PdfPCell(new Phrase("2~3周", FontNorm));
            row2 = new PdfPRow(dcell2);
            table2.Rows.Add(row2);

            List<PdfPRow> rowList2 = table2.Rows;
            foreach (var row in rowList2)
            {
                PdfPCell[] cells = row.GetCells();
                foreach (PdfPCell item in cells)
                {
                    item.BorderWidth = 1;
                    item.MinimumHeight = Utilities.MillimetersToPoints(6);
                    item.BorderColor = BaseColor.BLACK;
                    item.HorizontalAlignment = Element.ALIGN_CENTER;
                    item.VerticalAlignment = Element.ALIGN_MIDDLE;
                }
            }
            doc.Add(table2);
        }
        string t3 = @"第二条 质量标准：厂家标准。        
第三条 出卖人对质量保证的条件及期限：见清单。            
第四条 包装标准、包装物的供应与回收：无。    
第五条 合理损耗标准及计算方法：无。                
第六条 标的物所有权自买受人付款时时转移，买受人未履行完支付价款义务的，标的物属于出卖人单位所有。 
第七条 交（提）货时间：预计发货日期 , 货期以定货款到帐后开始计算。 
第八条 运输方式及送货地址：                   
收货地址：{0}            
收货人：{1} 电话：{2}。        
第九条 检验标准、方法、地点及期限：按厂家标准。          
第十条 结算方式、时间及地点：，                             
第十一条 发票类型：{3}。              
第十二条 付款信息：     
{4}
第十三条 本合同解除的条件：质保期满。            
第十四条 违约责任：质量。   
第十五条 合同争议的解决方式：当地法院仲裁。     
第十六条 本合同一式贰份，双方各执壹份，自双方签字盖章之日起生效，传真件与原件具有同等法律效力。";
        string payinfo = "";
        DataTable dt_branch;//网点信息
        string lm_phone = "";
        string lm_fax = "";
        string lm_mail = "";

        string sell_phone1 = "";
        string sell_phone2 = "";
        string sell_fax = "";
        string sell_mail = "";
        string sell_adr = "";
        if (spn.Rows[0]["BrandName"].ToString() == "总部")
        {
            payinfo = "开户行:中国民生银行股份有限公司北京上地支行 账号: 0110014170025222 所有者：北京盛唐和迅科技有限公司  ";

        }
        else
        {
            dt_branch = DALCommon.GetDataList("BranchList", "", " [_Name]='" + spn.Rows[0]["BrandName"].ToString() + "' ").Tables[0];
            if (dt_branch.Rows.Count>0)
            {
                payinfo = dt_branch.Rows[0]["Account"].ToString();
                sell_phone1 = dt_branch.Rows[0]["Tel"].ToString();
                sell_fax = dt_branch.Rows[0]["Fax"].ToString();
                sell_mail = dt_branch.Rows[0]["Email"].ToString();
                sell_adr = dt_branch.Rows[0]["Adr"].ToString();
            }
        }
        //spn.Rows[0]["Operator"].ToString()  销售员信息
        DataTable sellinfo = DALCommon.GetDataList("jc_staff", "", " [_Name]='" + spn.Rows[0]["Operator"].ToString() + "' ").Tables[0];
        if (sellinfo.Rows.Count>0)
        {
            sell_phone2 = sellinfo.Rows[0]["Tel"].ToString();
        }
        DataTable cuinfo = DALCommon.GetDataList("CustomerList", "", " [LinkMan]='" + spn.Rows[0]["LinkMan"].ToString() + "' and [_Name]='" + spn.Rows[0]["_Name"].ToString() + "' ").Tables[0];
        if (cuinfo.Rows.Count > 0)
        {
            lm_phone = cuinfo.Rows[0]["Tel2"].ToString();
            lm_fax = cuinfo.Rows[0]["Fax"].ToString();
            lm_mail = cuinfo.Rows[0]["Email"].ToString();
        }
        string ratioType = "";
        if (spn.Rows[0]["BrandTaxRateType"].ToString() == "无" || Convert.ToDecimal(spn.Rows[0]["BrandTaxRate"]) == 0)
        {
            ratioType = "不含税";
        }
        else
        {
            ratioType = spn.Rows[0]["BrandTaxRateType"].ToString() + "：" + Math.Round(Convert.ToDecimal(spn.Rows[0]["BrandTaxRate"]) * 100, 0).ToString() + "%";
        }
        Chunk beginning = new Chunk(string.Format(t3, spn.Rows[0]["Adr"].ToString(), spn.Rows[0]["LinkMan"].ToString(), spn.Rows[0]["Tel"].ToString(), ratioType, payinfo,""), FontNorm);
        Phrase p1 = new Phrase(beginning);
        Paragraph p = new Paragraph();
        p.Add(p1);
        p.IndentationLeft = 30;
        doc.Add(p);
        doc.Add(t2);//空白行
        //发货联系
        PdfPTable tb_cat = new PdfPTable(4);//根据列配置确定表格列数量
        PdfPCell[] cell_cat = new PdfPCell[4];
        PdfPRow row_cat;
        int[] ws_cat = new[] { 15, 35, 15, 35 };
        tb_cat.SetWidths(ws_cat);
        //spn spd
        cell_cat[0] = new PdfPCell(new Phrase("买方单位名称", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["_Name"].ToString(), FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("卖方单位名称", FontNorm));
        cell_cat[3] = new PdfPCell(new Phrase(cname, FontNorm));
        row_cat = new PdfPRow(cell_cat);
        tb_cat.Rows.Add(row_cat);

        cell_cat = new PdfPCell[4];
        cell_cat[0] = new PdfPCell(new Phrase("单位地址", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["Adr"].ToString(), FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("单位地址", FontNorm));
        cell_cat[3] = new PdfPCell(new Phrase(sell_adr, FontNorm));
        row_cat = new PdfPRow(cell_cat);
        tb_cat.Rows.Add(row_cat);

        cell_cat = new PdfPCell[4];
        cell_cat[0] = new PdfPCell(new Phrase("法定代表人", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase("", FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("法定代表人", FontNorm));
        cell_cat[3] = new PdfPCell(new Phrase("鲁春宝", FontNorm));
        row_cat = new PdfPRow(cell_cat);
        tb_cat.Rows.Add(row_cat);

        cell_cat = new PdfPCell[4];
        cell_cat[0] = new PdfPCell(new Phrase("委托代理人", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["LinkMan"].ToString(), FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("委托代理人", FontNorm));
        cell_cat[3] = new PdfPCell(new Phrase(spn.Rows[0]["Operator"].ToString(), FontNorm));
        row_cat = new PdfPRow(cell_cat);
        tb_cat.Rows.Add(row_cat);

        cell_cat = new PdfPCell[4];
        cell_cat[0] = new PdfPCell(new Phrase("联系人手机", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase(lm_phone, FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("联系人手机", FontNorm));
        cell_cat[3] = new PdfPCell(new Phrase(sell_phone2, FontNorm));
        row_cat = new PdfPRow(cell_cat);
        tb_cat.Rows.Add(row_cat);

        cell_cat = new PdfPCell[4];
        cell_cat[0] = new PdfPCell(new Phrase("电话", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["Tel"].ToString(), FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("电话", FontNorm));
        cell_cat[3] = new PdfPCell(new Phrase(sell_phone1, FontNorm));
        row_cat = new PdfPRow(cell_cat);
        tb_cat.Rows.Add(row_cat);

        cell_cat = new PdfPCell[4];
        cell_cat[0] = new PdfPCell(new Phrase("传真", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase(lm_fax, FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("传真", FontNorm));
        cell_cat[3] = new PdfPCell(new Phrase(sell_fax, FontNorm));
        row_cat = new PdfPRow(cell_cat);
        tb_cat.Rows.Add(row_cat);

        cell_cat = new PdfPCell[4];
        cell_cat[0] = new PdfPCell(new Phrase("邮箱", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase(lm_mail, FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("邮箱", FontNorm));
        cell_cat[3] = new PdfPCell(new Phrase(sell_mail, FontNorm));
        row_cat = new PdfPRow(cell_cat);
        tb_cat.Rows.Add(row_cat);

        foreach (PdfPRow row in tb_cat.Rows)
        {
            PdfPCell[] cells = row.GetCells();
            foreach (PdfPCell item in cells)
            {
                item.BorderWidth = 1;
                item.MinimumHeight = Utilities.MillimetersToPoints(6);
                item.BorderColor = BaseColor.BLACK;
                item.HorizontalAlignment = Element.ALIGN_CENTER;
                item.VerticalAlignment = Element.ALIGN_MIDDLE;
            }
        } 
 
      //  doc.Add(tb_cat);
        tb_cat.TotalWidth = 560f;
        tb_cat.WriteSelectedRows(0, -1, doc.PageSize.Width - 36f - 540f, 160f, pdfWritey.DirectContent);
        Image img;
        string wdName = cname;//spn.Rows[0]["BrandName"].ToString();
        if (wdName.IndexOf("凡驰") >=0)
        {
            img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "fcht.jpg");
        }
        else if (wdName.IndexOf("美福洋") >=0)
        {
            img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "mfyht.jpg");
        }
        else if (wdName.IndexOf("盛唐") >= 0)
        {
            img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "sthxht.gif");
        }
        else if (wdName.IndexOf("贝利") >= 0)
        {
            img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "blht.png");
        }
        else if (wdName.IndexOf("华宇") >= 0)
        {
            img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "hyht.png");
        }
        else {
            img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "null.png");
        }

        img.ScaleToFit(120f, 120f);
    img.SetAbsolutePosition(doc.PageSize.Width - 36f - 200f, 20f);
  
        doc.Add(img);

        if (spd.Rows.Count > MaxCount)
        {
            doc.NewPage();
            title = new Paragraph("附件合同", FontBig);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);//第二页标题
            title = new Paragraph(" ", FontSmall);
            doc.Add(title);
            doc.Add(table);//第二页表头
            title = new Paragraph(" ", FontSmall);
            title.IndentationLeft = 30;
            doc.Add(title);

            PdfPTable table3 = new PdfPTable(8) { WidthPercentage = 90 };//根据列配置确定表格列数量       
            int[] tab3w = new[] { 6, 20, 20, 8, 10, 11, 8,12 };
            table3.SetWidths(tab3w);
            PdfPRow row3;
            PdfPCell[] dcell3 = new PdfPCell[8];
            dcell3[0] = new PdfPCell(new Phrase("序号", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[1] = new PdfPCell(new Phrase("产品名称", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[2] = new PdfPCell(new Phrase("产品型号", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[3] = new PdfPCell(new Phrase("数量", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[4] = new PdfPCell(new Phrase("单价(元)", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[5] = new PdfPCell(new Phrase("金额(元)", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[6] = new PdfPCell(new Phrase("货期", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
         
            dcell3[7] = new PdfPCell(new Phrase("备注", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            row3 = new PdfPRow(dcell3);
            table3.Rows.Add(row3);
            for (int i = 0; i < spd.Rows.Count; i++)
            {
                dcell3 = new PdfPCell[8];
                dcell3[0] = new PdfPCell(new Phrase((i + 1).ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                dcell3[1] = new PdfPCell(new Phrase(spd.Rows[i]["_Name"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                //  dcell3[1] = new PdfPCell(new Phrase(spd.Rows[i]["GoodsNO"].ToString(), FontNorm));
                dcell3[2] = new PdfPCell(new Phrase(spd.Rows[i]["spec"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                // dcell3[4] = new PdfPCell(new Phrase(spd.Rows[i]["ProductBrand"].ToString(), FontNorm)) ;
                dcell3[3] = new PdfPCell(new Phrase(spd.Rows[i]["Qty"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                dcell3[4] = new PdfPCell(new Phrase(spd.Rows[i]["Price"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                dcell3[5] = new PdfPCell(new Phrase(spd.Rows[i]["Total"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                dcell3[6] = new PdfPCell(new Phrase(spd.Rows[i]["huoqi"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
           
                dcell3[7] = new PdfPCell(new Phrase(spd.Rows[i]["Remark"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                row3 = new PdfPRow(dcell3);
                table3.Rows.Add(row3);
            }
            //合计
            dcell3 = new PdfPCell[8];
            dcell3[0] = new PdfPCell(new Phrase("总计", FontNorm)) { Colspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[2] = new PdfPCell(new Phrase("（大写）：" + UpperRMB.CmycurD(OrderPrice.ToString()), FontNorm)) { Colspan = 3, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[5] = new PdfPCell(new Phrase("（小写）：" + OrderPrice.ToString(), FontNorm)) { Colspan = 3, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            row3 = new PdfPRow(dcell3);
            table3.Rows.Add(row3);
            doc.Add(table3);

            PdfDiv div = new PdfDiv();
            div.TextAlignment = Element.ALIGN_RIGHT;//cname
            div.PaddingRight = 30;
            Paragraph cop = new Paragraph(" ", FontBig);
            div.AddElement(cop);
            cop = new Paragraph(cname, FontBig);
            cop.Alignment = Element.ALIGN_RIGHT;
            div.AddElement(cop);
            cop = new Paragraph(string.Format("{0:yyyy-MM-dd}", DateTime.Now), FontBig);
            cop.Alignment = Element.ALIGN_RIGHT;
            div.AddElement(cop);
            doc.Add(div);
            img.SetAbsolutePosition(doc.PageSize.Width - 36f - 130f, doc.PageSize.Height - ((spd.Rows.Count + 2) * 21 + 200));//410
            doc.Add(img);
        }

        doc.Close();
        return stream;

    }
    public MemoryStream PrintXSDD2(string num, out string fname)
    {
        int MaxCount = 6;

        DataTable spn = DALCommon.GetDataList("xs_sellplan", "", " [ID]=" + num).Tables[0];
        DataTable spd = DALCommon.GetDataList("xs_sellplandetail", "", " [BillID]=" + num).Tables[0];


        MemoryStream stream = new MemoryStream();

        iTextSharp.text.Font FontBig = new iTextSharp.text.Font(baseFont, 16f); FontBig.IsBold();
        iTextSharp.text.Font FontNorm = new iTextSharp.text.Font(baseFont, 10f);
        iTextSharp.text.Font FontSmall = new iTextSharp.text.Font(baseFont, 8f);
        iTextSharp.text.Font FontTitle = new iTextSharp.text.Font(baseFont, 12f, Font.BOLD);

        //  iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 8.5f);
        //页面大小
        Document doc = new Document(PageSize.A4);
        doc.SetMargins(0f, 0f, 10f, 0f);
        //文件流
        PdfWriter pdfWritey = PdfWriter.GetInstance(doc, stream);
        pdfWritey.CloseStream = false;
        doc.Open();

        //标题三行
        Paragraph title;
        title = new Paragraph(spn.Rows[0]["BillID"].ToString() + " " + spn.Rows[0]["_Name"].ToString(), FontSmall);
        title.IndentationLeft = 30;
        doc.Add(title);
        fname = spn.Rows[0]["BillID"].ToString() + " " + spn.Rows[0]["_Name"].ToString();
        string cname = spn.Rows[0]["BrandName"].ToString() == "总部" ? "北京盛唐和讯科技有限公司" : spn.Rows[0]["BrandName"].ToString();
        title = new Paragraph(cname, FontBig);
        title.Alignment = Element.ALIGN_CENTER;
        doc.Add(title);
        title = new Paragraph("销售合同", FontBig);
        title.Alignment = Element.ALIGN_CENTER;
        Paragraph t2 = new Paragraph("  ", FontBig);
        doc.Add(title);
        doc.Add(t2);
        //内容
        PdfPTable table = new PdfPTable(4) { WidthPercentage = 90 };//根据列配置确定表格列数量

        PdfPCell[] cellBody = new PdfPCell[4];
        int[] ws = new[] { 13, 47, 13, 27 };
        table.SetWidths(ws);
        cellBody[0] = new PdfPCell(new Phrase("买方(甲方)：", FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            // Width = Utilities.MillimetersToPoints(10),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_LEFT
        };

        cellBody[1] = new PdfPCell(new Phrase(spn.Rows[0]["_Name"].ToString(), FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            //  Width = Utilities.MillimetersToPoints(20),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_LEFT
        };

        cellBody[2] = new PdfPCell(new Phrase("合同编号", FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            //Width = Utilities.MillimetersToPoints(10),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_RIGHT
        };
        cellBody[3] = new PdfPCell(new Phrase(spn.Rows[0]["BillID"].ToString(), FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            //Width = Utilities.MillimetersToPoints(20),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_LEFT
        };
        PdfPRow rowBody = new PdfPRow(cellBody);
        table.Rows.Add(rowBody);


        cellBody = new PdfPCell[4];
        cellBody[0] = new PdfPCell(new Phrase("卖方(乙方)：", FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_LEFT
        };
        //"北京盛唐和讯科技有限公司"
        cellBody[1] = new PdfPCell(new Phrase(cname, FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_LEFT
        };

        cellBody[2] = new PdfPCell(new Phrase("签订地点", FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_RIGHT
        };
        cellBody[3] = new PdfPCell(new Phrase("北京", FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_LEFT
        };
        rowBody = new PdfPRow(cellBody);
        table.Rows.Add(rowBody);
        doc.Add(table);
        //条款
        string t1 = "  根据《中华人民共和国合同法》及有关相关法规，经双方充分协商，特订立本合同，共同遵守。";
        string t11 = "  第一条 产品规格、数量、价格、备注：";
        doc.Add(new Paragraph(t1, FontNorm) { IndentationLeft = 30 });
        doc.Add(new Paragraph(t11, FontNorm) { IndentationLeft = 30 });
        doc.Add(new Paragraph(" ", FontNorm));
        //产品详细
        PdfPTable detail_table = new PdfPTable(10) { WidthPercentage = 90 };//根据列配置确定表格列数量       
        int[] ws2 = new[] { 5, 13, 13, 12, 7, 7, 8, 10,8, 12 };
        detail_table.SetWidths(ws2);
        PdfPCell[] detail_cell = new PdfPCell[10];
        detail_cell[0] = new PdfPCell(new Phrase("序号", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[1] = new PdfPCell(new Phrase("订货号", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[2] = new PdfPCell(new Phrase("型号", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[3] = new PdfPCell(new Phrase("名称", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[4] = new PdfPCell(new Phrase("品牌", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[5] = new PdfPCell(new Phrase("数量", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[6] = new PdfPCell(new Phrase("单价", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[7] = new PdfPCell(new Phrase("小计", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[8] = new PdfPCell(new Phrase("货期", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[9] = new PdfPCell(new Phrase("备注", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        PdfPRow drowBody = new PdfPRow(detail_cell);
        detail_table.Rows.Add(drowBody);

        decimal OrderPrice = 0;
        if (spd.Rows.Count <= MaxCount)
        {
            for (int i = 0; i < spd.Rows.Count; i++)
            {
                OrderPrice += Convert.ToDecimal(spd.Rows[i]["Total"]);
                detail_cell = new PdfPCell[10];
                detail_cell[0] = new PdfPCell(new Phrase((i + 1).ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                detail_cell[1] = new PdfPCell(new Phrase(spd.Rows[i]["GoodsNO"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                detail_cell[2] = new PdfPCell(new Phrase(spd.Rows[i]["spec"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                detail_cell[3] = new PdfPCell(new Phrase(spd.Rows[i]["_Name"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                detail_cell[4] = new PdfPCell(new Phrase(spd.Rows[i]["ProductBrand"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                detail_cell[5] = new PdfPCell(new Phrase(spd.Rows[i]["Qty"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                detail_cell[6] = new PdfPCell(new Phrase(spd.Rows[i]["Price"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                detail_cell[7] = new PdfPCell(new Phrase(spd.Rows[i]["Total"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                detail_cell[8] = new PdfPCell(new Phrase(spd.Rows[i]["huoqi"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                detail_cell[9] = new PdfPCell(new Phrase(spd.Rows[i]["Remark"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            
                drowBody = new PdfPRow(detail_cell);
                detail_table.Rows.Add(drowBody);
            }
            //for (int ii = 0; ii < MaxCount - spd.Rows.Count; ii++)
            //{
            //    detail_cell = new PdfPCell[10];
            //    detail_cell[0] = new PdfPCell(new Phrase("", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            //    detail_cell[1] = new PdfPCell(new Phrase("", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            //    detail_cell[2] = new PdfPCell(new Phrase("", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            //    detail_cell[3] = new PdfPCell(new Phrase("", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            //    detail_cell[4] = new PdfPCell(new Phrase("", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            //    detail_cell[5] = new PdfPCell(new Phrase("", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            //    detail_cell[6] = new PdfPCell(new Phrase("", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            //    detail_cell[7] = new PdfPCell(new Phrase("", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            //    detail_cell[8] = new PdfPCell(new Phrase("", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            //    detail_cell[9] = new PdfPCell(new Phrase("", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
              
            //    drowBody = new PdfPRow(detail_cell);
            //    detail_table.Rows.Add(drowBody);
            //}
            //合计
            detail_cell = new PdfPCell[10];
            detail_cell[0] = new PdfPCell(new Phrase("总计", FontNorm)) { Colspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            detail_cell[2] = new PdfPCell(new Phrase("（大写）：" + UpperRMB.CmycurD(OrderPrice.ToString()), FontNorm)) { Colspan = 4, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            detail_cell[6] = new PdfPCell(new Phrase("（小写）：" + OrderPrice.ToString(), FontNorm)) { Colspan = 4, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            drowBody = new PdfPRow(detail_cell);
            detail_table.Rows.Add(drowBody);
            doc.Add(detail_table);
        }
        else
        {
            for (int i = 0; i < spd.Rows.Count; i++)
            {
                OrderPrice += Convert.ToDecimal(spd.Rows[i]["Total"]);
            }

            PdfPTable table2 = new PdfPTable(4) { WidthPercentage = 90 };//根据列配置确定表格列数量       
            int[] tab2w = new[] { 10, 35, 30, 25 };
            table2.SetWidths(tab2w);
            PdfPRow row2;
            PdfPCell[] dcell2 = new PdfPCell[4];
            dcell2[0] = new PdfPCell(new Phrase("序号", FontNorm));
            dcell2[1] = new PdfPCell(new Phrase("产品型号", FontNorm));
            dcell2[2] = new PdfPCell(new Phrase("总合计", FontNorm));
            dcell2[3] = new PdfPCell(new Phrase("交货期", FontNorm));
            row2 = new PdfPRow(dcell2);
            table2.Rows.Add(row2);

            dcell2 = new PdfPCell[4];
            dcell2[0] = new PdfPCell(new Phrase("1", FontNorm));
            dcell2[1] = new PdfPCell(new Phrase("详细见合同附件\"货物清单\"", FontNorm));
            dcell2[2] = new PdfPCell(new Phrase(OrderPrice.ToString(".00"), FontNorm));
            dcell2[3] = new PdfPCell(new Phrase("2~3周", FontNorm));
            row2 = new PdfPRow(dcell2);
            table2.Rows.Add(row2);

            List<PdfPRow> rowList2 = table2.Rows;
            foreach (var row in rowList2)
            {
                PdfPCell[] cells = row.GetCells();
                foreach (PdfPCell item in cells)
                {
                    item.BorderWidth = 1;
                    item.MinimumHeight = Utilities.MillimetersToPoints(6);
                    item.BorderColor = BaseColor.BLACK;
                    item.HorizontalAlignment = Element.ALIGN_CENTER;
                    item.VerticalAlignment = Element.ALIGN_MIDDLE;
                }
            }
            doc.Add(table2);
            //title = new Paragraph("详细列表见下页", FontTitle);
            //title.IndentationLeft = 30;
            //doc.Add(title);
            //doc.Add(new Paragraph(" ", FontNorm));
        }
        string t3 = @"第二条 质量标准：厂家标准。        
第三条 出卖人对质量保证的条件及期限：见清单。            
第四条 包装标准、包装物的供应与回收：无。    
第五条 合理损耗标准及计算方法：无。                
第六条 标的物所有权自买受人付款时时转移，买受人未履行完支付价款义务的，标的物属于出卖人单位所有。 
第七条 交（提）货时间：预计发货日期 , 货期以定货款到帐后开始计算。 
第八条 运输方式及送货地址：         
收货地址：{0}                               
收货人：{1} 电话：{2}。        
第九条 检验标准、方法、地点及期限：按厂家标准。          
第十条 结算方式、时间及地点：，                             
第十一条 发票类型：{3}。              
第十二条 付款信息：     
{4}
第十三条 本合同解除的条件：质保期满。            
第十四条 违约责任：质量。   
第十五条 合同争议的解决方式：当地法院仲裁。     
第十六条 本合同一式贰份，双方各执壹份，自双方签字盖章之日起生效，传真件与原件具有同等法律效力。";
        string payinfo = "";
        DataTable dt_branch;//网点信息
        string lm_phone = "";
        string lm_fax = "";
        string lm_mail = "";

        string sell_phone1 = "";
        string sell_phone2 = "";
        string sell_fax = "";
        string sell_mail = "";
        string sell_adr = "";
        if (spn.Rows[0]["BrandName"].ToString() == "总部")
        {
            payinfo = "开户行:中国民生银行股份有限公司北京上地支行 账号: 0110014170025222 所有者：北京盛唐和迅科技有限公司  ";

        }
        else
        {
            dt_branch = DALCommon.GetDataList("BranchList", "", " [_Name]='" + spn.Rows[0]["BrandName"].ToString() + "' ").Tables[0];
            if (dt_branch.Rows.Count > 0)
            {
                payinfo = dt_branch.Rows[0]["Account"].ToString();
                sell_phone1 = dt_branch.Rows[0]["Tel"].ToString();
                sell_fax = dt_branch.Rows[0]["Fax"].ToString();
                sell_mail = dt_branch.Rows[0]["Email"].ToString();
                sell_adr = dt_branch.Rows[0]["Adr"].ToString();
            }
        }
        //spn.Rows[0]["Operator"].ToString()  销售员信息
        DataTable sellinfo = DALCommon.GetDataList("jc_staff", "", " [_Name]='" + spn.Rows[0]["Operator"].ToString() + "' ").Tables[0];
        if (sellinfo.Rows.Count > 0)
        {
            sell_phone2 = sellinfo.Rows[0]["Tel"].ToString();
        }
        DataTable cuinfo = DALCommon.GetDataList("CustomerList", "", " [LinkMan]='" + spn.Rows[0]["LinkMan"].ToString() + "' and [_Name]='" + spn.Rows[0]["_Name"].ToString() + "' ").Tables[0];
        if (cuinfo.Rows.Count > 0)
        {
            lm_phone = cuinfo.Rows[0]["Tel2"].ToString();
            lm_fax = cuinfo.Rows[0]["Fax"].ToString();
            lm_mail = cuinfo.Rows[0]["Email"].ToString();
        }

        string ratioType = "";
        if (spn.Rows[0]["BrandTaxRateType"].ToString() == "无" || Convert.ToDecimal(spn.Rows[0]["BrandTaxRate"]) == 0)
        {
            ratioType = "不含税";
        }
        else
        {
            ratioType = spn.Rows[0]["BrandTaxRateType"].ToString() + "：" + Math.Round(Convert.ToDecimal(spn.Rows[0]["BrandTaxRate"]) * 100, 0).ToString() + "%";
        }
        Chunk beginning = new Chunk(string.Format(t3, spn.Rows[0]["Adr"].ToString(), spn.Rows[0]["LinkMan"].ToString(), spn.Rows[0]["Tel"].ToString(), ratioType, payinfo,""), FontNorm);
        Phrase p1 = new Phrase(beginning);
        Paragraph p = new Paragraph();
        p.Add(p1);
        p.IndentationLeft = 30;
        doc.Add(p);
        doc.Add(t2);//空白行
        //发货联系
        PdfPTable tb_cat = new PdfPTable(4) ;//根据列配置确定表格列数量
        PdfPCell[] cell_cat = new PdfPCell[4];
        PdfPRow row_cat;
        int[] ws_cat = new[] { 15, 35, 15, 35 };
        tb_cat.SetWidths(ws_cat);
        //spn spd
        cell_cat[0] = new PdfPCell(new Phrase("买方单位名称", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["_Name"].ToString(), FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("卖方单位名称", FontNorm));
        cell_cat[3] = new PdfPCell(new Phrase(cname, FontNorm));
        row_cat = new PdfPRow(cell_cat);
        tb_cat.Rows.Add(row_cat);

        cell_cat = new PdfPCell[4];
        cell_cat[0] = new PdfPCell(new Phrase("单位地址", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["Adr"].ToString(), FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("单位地址", FontNorm));
        cell_cat[3] = new PdfPCell(new Phrase(sell_adr, FontNorm));
        row_cat = new PdfPRow(cell_cat);
        tb_cat.Rows.Add(row_cat);

        cell_cat = new PdfPCell[4];
        cell_cat[0] = new PdfPCell(new Phrase("法定代表人", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase("", FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("法定代表人", FontNorm));
        cell_cat[3] = new PdfPCell(new Phrase("鲁春宝", FontNorm));
        row_cat = new PdfPRow(cell_cat);
        tb_cat.Rows.Add(row_cat);

        cell_cat = new PdfPCell[4];
        cell_cat[0] = new PdfPCell(new Phrase("委托代理人", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["LinkMan"].ToString(), FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("委托代理人", FontNorm));
        cell_cat[3] = new PdfPCell(new Phrase(spn.Rows[0]["Operator"].ToString(), FontNorm));
        row_cat = new PdfPRow(cell_cat);
        tb_cat.Rows.Add(row_cat);

        cell_cat = new PdfPCell[4];
        cell_cat[0] = new PdfPCell(new Phrase("联系人手机", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase(lm_phone, FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("联系人手机", FontNorm));
        cell_cat[3] = new PdfPCell(new Phrase(sell_phone2, FontNorm));
        row_cat = new PdfPRow(cell_cat);
        tb_cat.Rows.Add(row_cat);

        cell_cat = new PdfPCell[4];
        cell_cat[0] = new PdfPCell(new Phrase("电话", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["Tel"].ToString(), FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("电话", FontNorm));
        cell_cat[3] = new PdfPCell(new Phrase(sell_phone1, FontNorm));
        row_cat = new PdfPRow(cell_cat);
        tb_cat.Rows.Add(row_cat);

        cell_cat = new PdfPCell[4];
        cell_cat[0] = new PdfPCell(new Phrase("传真", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase(lm_fax, FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("传真", FontNorm));
        cell_cat[3] = new PdfPCell(new Phrase(sell_fax, FontNorm));
        row_cat = new PdfPRow(cell_cat);
        tb_cat.Rows.Add(row_cat);

        cell_cat = new PdfPCell[4];
        cell_cat[0] = new PdfPCell(new Phrase("邮箱", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase(lm_mail, FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("邮箱", FontNorm));
        cell_cat[3] = new PdfPCell(new Phrase(sell_mail, FontNorm));
        row_cat = new PdfPRow(cell_cat);
        tb_cat.Rows.Add(row_cat);

        foreach (PdfPRow row in tb_cat.Rows)
        {
            PdfPCell[] cells = row.GetCells();
            foreach (PdfPCell item in cells)
            {
                item.BorderWidth = 1;
                item.MinimumHeight = Utilities.MillimetersToPoints(6);
                item.BorderColor = BaseColor.BLACK;
                item.HorizontalAlignment = Element.ALIGN_CENTER;
                item.VerticalAlignment = Element.ALIGN_MIDDLE;
            }
        }
        tb_cat.TotalWidth = 560f;
        tb_cat.WriteSelectedRows(0, -1, doc.PageSize.Width - 36f - 540f, 160f, pdfWritey.DirectContent);

      //  doc.Add(tb_cat);
        Image img;
        string wdName = cname;//spn.Rows[0]["BrandName"].ToString();
        if (wdName.IndexOf("凡驰") >= 0)
        {
            img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "fcht.jpg");
        }
        else if (wdName.IndexOf("美福洋") >= 0)
        {
            img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "mfyht.jpg");
        }
        else if (wdName.IndexOf("盛唐") >= 0)
        {
            img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "sthxht.gif");
        }
        else if (wdName.IndexOf("贝利") >= 0)
        {
            img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "blht.png");
        }
        else if (wdName.IndexOf("华宇") >= 0)
        {
            img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "hyht.png");
        }
        else
        {
            img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "null.png");
        }
        img.ScaleToFit(150f, 150f);
    img.SetAbsolutePosition(doc.PageSize.Width - 36f - 200f, 20f);
      
        doc.Add(img);
        if (spd.Rows.Count > MaxCount)
        {
            doc.NewPage();
            title = new Paragraph("附件合同", FontBig);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);//第二页标题
            title = new Paragraph(" ", FontNorm);
            doc.Add(title);
            doc.Add(table);//第二页表头
            title = new Paragraph(" ", FontNorm);
            title.IndentationLeft = 30;
            doc.Add(title);

            PdfPTable table3 = new PdfPTable(8) { WidthPercentage = 90 };//根据列配置确定表格列数量       
            int[] tab3w = new[] { 6, 20, 20, 8, 10, 11, 8,12 };
            table3.SetWidths(tab3w);
            PdfPRow row3;
            PdfPCell[] dcell3 = new PdfPCell[8];
            dcell3[0] = new PdfPCell(new Phrase("序号", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[1] = new PdfPCell(new Phrase("产品名称", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[2] = new PdfPCell(new Phrase("产品型号", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[3] = new PdfPCell(new Phrase("数量", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[4] = new PdfPCell(new Phrase("单价(元)", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[5] = new PdfPCell(new Phrase("金额(元)", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[6] = new PdfPCell(new Phrase("货期", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
           
            dcell3[7] = new PdfPCell(new Phrase("备注", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            row3 = new PdfPRow(dcell3);
            table3.Rows.Add(row3);
            for (int i = 0; i < spd.Rows.Count; i++)
            {
                dcell3 = new PdfPCell[8];
                dcell3[0] = new PdfPCell(new Phrase((i + 1).ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                dcell3[1] = new PdfPCell(new Phrase(spd.Rows[i]["_Name"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                //  dcell3[1] = new PdfPCell(new Phrase(spd.Rows[i]["GoodsNO"].ToString(), FontNorm));
                dcell3[2] = new PdfPCell(new Phrase(spd.Rows[i]["spec"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                // dcell3[4] = new PdfPCell(new Phrase(spd.Rows[i]["ProductBrand"].ToString(), FontNorm)) ;
                dcell3[3] = new PdfPCell(new Phrase(spd.Rows[i]["Qty"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                dcell3[4] = new PdfPCell(new Phrase(spd.Rows[i]["Price"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                dcell3[5] = new PdfPCell(new Phrase(spd.Rows[i]["Total"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                dcell3[6] = new PdfPCell(new Phrase(spd.Rows[i]["huoqi"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                dcell3[7] = new PdfPCell(new Phrase(spd.Rows[i]["Remark"].ToString(), FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
              
                row3 = new PdfPRow(dcell3);
                table3.Rows.Add(row3);
            }
            //合计
            dcell3 = new PdfPCell[8];
            dcell3[0] = new PdfPCell(new Phrase("总计", FontNorm)) { Colspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[2] = new PdfPCell(new Phrase("（大写）：" + UpperRMB.CmycurD(OrderPrice.ToString()), FontNorm)) { Colspan = 3, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[5] = new PdfPCell(new Phrase("（小写）：" + OrderPrice.ToString(), FontNorm)) { Colspan = 3, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            row3 = new PdfPRow(dcell3);
            table3.Rows.Add(row3);
            doc.Add(table3);

            PdfDiv div = new PdfDiv();
            div.TextAlignment = Element.ALIGN_RIGHT;//cname
            div.PaddingRight = 30;
            Paragraph cop = new Paragraph(" ", FontBig);
            div.AddElement(cop);
            cop = new Paragraph(cname, FontBig);
            cop.Alignment = Element.ALIGN_RIGHT;
            div.AddElement(cop);
            cop = new Paragraph(string.Format("{0:yyyy-MM-dd}", DateTime.Now), FontBig);
            cop.Alignment = Element.ALIGN_RIGHT;
            div.AddElement(cop);
            doc.Add(div);
            img.SetAbsolutePosition(doc.PageSize.Width - 36f - 130f, doc.PageSize.Height - ((spd.Rows.Count + 2) * 21 + 200));//410
            doc.Add(img);

        }
        doc.Close();
        return stream;

    }
    /// <summary>
    /// 维修合同
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public MemoryStream PrintPLHT(string num)
    {
        int MaxCount = 10;
        if (num.LastIndexOf(",") == num.Length - 1)
        {
            num = num.Substring(0,num.LastIndexOf(","));
        }
        string[] ids = num.Split(',');
        //页面大小
        Document doc = new Document(PageSize.A4);
        doc.SetMargins(0f, 0f, 10f, 0f);
        MemoryStream stream = new MemoryStream();
       
        PdfWriter pdfWritey = PdfWriter.GetInstance(doc, stream);
        pdfWritey.CloseStream = false;
        doc.Open();
        DataTable spn = new DataTable() ;
      
        //字体
          iTextSharp.text.Font FontBig = new iTextSharp.text.Font(baseFont, 16f);
          iTextSharp.text.Font FontNorml = new iTextSharp.text.Font(baseFont, 10f);
          iTextSharp.text.Font FontSmall = new iTextSharp.text.Font(baseFont, 8f);
          iTextSharp.text.Font FontTitle = new iTextSharp.text.Font(baseFont, 12f, Font.BOLD);
          FontBig.IsBold();
          Paragraph title;
          if (ids.Count() <= 0)
          {
              title = new Paragraph("错误：ID为空", FontBig);
              title.IndentationLeft = 30;
              doc.Add(title);
              doc.Close();
              return stream;
          }
          else
          {
                spn = DALCommon.GetDataList("fw_services", "", " [ID]=" + ids[0]).Tables[0];

                if (spn.Rows.Count > 0)
                {
                    string comName = spn.Rows[0]["CustomerName"].ToString();
                    string billNum = spn.Rows[0]["BillID"].ToString();
                    string bn = ids.Length > 1 ? billNum.Substring(0, billNum.LastIndexOf("-")) : billNum;
                    DataTable spn2; string billNum2; string bn2;
                    for (int x = 0; x < ids.Count(); x++)
                    {
                        if (!string.IsNullOrEmpty(ids[x]))
                        {
                            spn2 = DALCommon.GetDataList("fw_services", "", " [ID]=" + ids[x]).Tables[0];
                            if (spn2.Rows.Count > 0)
                            {
                             
                                billNum2 = spn2.Rows[0]["BillID"].ToString();
                                bn2 = ids.Length > 1? billNum2.Substring(0, billNum2.LastIndexOf("-")):billNum2;
                           
                                if (bn != bn2)
                                {
                                    title = new Paragraph("错误：服务号不匹配，不能合并！", FontBig);
                                    title.IndentationLeft = 30;
                                    doc.Add(title);
                                    doc.Close();
                                    return stream;
                                }
                            }
                            else
                            {
                                title = new Paragraph("错误：ID无效！", FontBig);
                                title.IndentationLeft = 30;
                                doc.Add(title);
                                doc.Close();
                                return stream;
                            }
                        }
                    }

                    #region main               

                    string cname = spn.Rows[0]["BranchName"].ToString() == "总部" || string.IsNullOrEmpty( spn.Rows[0]["BranchName"].ToString()) ? "北京盛唐和讯科技有限公司" : spn.Rows[0]["BranchName"].ToString();
                    title = new Paragraph(cname, FontBig);
                    title.Alignment = Element.ALIGN_CENTER;
                    doc.Add(title);
                    title = new Paragraph("维修合同", FontBig);
                    title.Alignment = Element.ALIGN_CENTER;
                    Paragraph t2 = new Paragraph("  ", FontBig);
                    doc.Add(title);
                    doc.Add(t2);
        
                    //内容
                    PdfPTable table = new PdfPTable(4) { WidthPercentage = 90 };//根据列配置确定表格列数量

                    PdfPCell[] cellBody = new PdfPCell[4];
                    int[] ws = new[] { 12, 48, 12, 28 };
                    table.SetWidths(ws);
                    cellBody[0] = new PdfPCell(new Phrase("维修单号：", FontNorml))
                    {
                        BorderWidth = 0,
                        MinimumHeight = Utilities.MillimetersToPoints(6),
                        // Width = Utilities.MillimetersToPoints(10),
                        BorderColor = BaseColor.WHITE,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    };
                    cellBody[1] = new PdfPCell(new Phrase(bn, FontNorml))
                    {
                        BorderWidth = 0,
                        MinimumHeight = Utilities.MillimetersToPoints(6),
                        //  Width = Utilities.MillimetersToPoints(20),
                        BorderColor = BaseColor.WHITE,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    };
                    cellBody[2] = new PdfPCell(new Phrase("报价日期：", FontNorml))
                    {
                        BorderWidth = 0,
                        MinimumHeight = Utilities.MillimetersToPoints(6),
                        //Width = Utilities.MillimetersToPoints(10),
                        BorderColor = BaseColor.WHITE,
                        HorizontalAlignment = Element.ALIGN_RIGHT
                    };
                    cellBody[3] = new PdfPCell(new Phrase(string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(spn.Rows[0]["Time_Make"])), FontNorml))
                    {
                        BorderWidth = 0,
                        MinimumHeight = Utilities.MillimetersToPoints(6),                     
                        BorderColor = BaseColor.WHITE,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    };
                    PdfPRow rowBody = new PdfPRow(cellBody);
                    table.Rows.Add(rowBody);

                    cellBody = new PdfPCell[4];
                    cellBody[0] = new PdfPCell(new Phrase("客户名称：", FontNorml))
                    {
                        BorderWidth = 0,
                        MinimumHeight = Utilities.MillimetersToPoints(6),
                        BorderColor = BaseColor.WHITE,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    };
                    cellBody[1] = new PdfPCell(new Phrase(comName, FontNorml))
                    {
                        BorderWidth = 0,
                        MinimumHeight = Utilities.MillimetersToPoints(6),
                        BorderColor = BaseColor.WHITE,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    };
                    cellBody[2] = new PdfPCell(new Phrase("报价单位：", FontNorml))
                    {
                        BorderWidth = 0,
                        MinimumHeight = Utilities.MillimetersToPoints(6),
                        BorderColor = BaseColor.WHITE,
                        HorizontalAlignment = Element.ALIGN_RIGHT
                    };
                    cellBody[3] = new PdfPCell(new Phrase(cname, FontNorml))
                    {
                        BorderWidth = 0,
                        MinimumHeight = Utilities.MillimetersToPoints(6),
                        BorderColor = BaseColor.WHITE,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    };
                    rowBody = new PdfPRow(cellBody);
                    table.Rows.Add(rowBody);

                      cellBody = new PdfPCell[4];
                    cellBody[0] = new PdfPCell(new Phrase("联系人：", FontNorml))
                    {
                        BorderWidth = 0,
                        MinimumHeight = Utilities.MillimetersToPoints(6),
                        BorderColor = BaseColor.WHITE,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    };
                    cellBody[1] = new PdfPCell(new Phrase(spn.Rows[0]["LinkMan"].ToString(), FontNorml))
                    {
                        BorderWidth = 0,
                        MinimumHeight = Utilities.MillimetersToPoints(6),
                        BorderColor = BaseColor.WHITE,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    };

                    cellBody[2] = new PdfPCell(new Phrase("报价人：", FontNorml))
                    {
                        BorderWidth = 0,
                        MinimumHeight = Utilities.MillimetersToPoints(6),
                        BorderColor = BaseColor.WHITE,
                        HorizontalAlignment = Element.ALIGN_RIGHT
                    };
                    cellBody[3] = new PdfPCell(new Phrase(spn.Rows[0]["Operator"].ToString(), FontNorml))
                    {
                        BorderWidth = 0,
                        MinimumHeight = Utilities.MillimetersToPoints(6),
                        BorderColor = BaseColor.WHITE,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    };
                    rowBody = new PdfPRow(cellBody);
                    table.Rows.Add(rowBody);


                    doc.Add(table);
                    //条款
                    string t1 = "  尊敬的客户：";
                    string t11 = "  感谢您对我公司的支持与合作！根据贵公司所述产品相关的信息，我公司已在下面表格报价。请确认以下服务方式及计费金额，如同意签字并加盖公章回传给我们。";
                    doc.Add(new Paragraph(t1, FontNorml) { IndentationLeft = 30 });
                    doc.Add(new Paragraph(t11, FontNorml) { IndentationLeft = 30,IndentationRight=30 });
                    doc.Add(new Paragraph(" ", FontNorml));
                    //产品详细
                    //  fw_servicesoffer
                    DataTable tb_mate = DALCommon.GetDataList("fw_servicesoffer", "", " [BillID] in (" + num + ")").Tables[0]; //DALCommon.GetDataList("fw_servicesmaterial", "", " [BillID] in (" + num + ")").Tables[0];
                    List<serModel> fwbaojia = new List<serModel>();
                    decimal OrderPrice = 0;

                    if (tb_mate.Rows.Count > 0)
                        {                           
                                serModel ser;
                                for (int i = 0; i < tb_mate.Rows.Count; i++)
                                {
                                    ser = new serModel();
                                    ser.xid = i + 1;//序号
                                    ser.name = spn.Rows[0]["ProductClass"].ToString();//c产品名称
                                    ser.model = spn.Rows[0]["ProductModel"].ToString(); //产品型号
                                    ser.unit = "";//tb_mate.Rows[i]["Unit"].ToString(); 单位
                                    ser.qty = 1;//数量
                                    ser.price = Convert.ToDecimal(tb_mate.Rows[i]["dAmount"]);
                                    ser.content = tb_mate.Rows[i]["_Name"].ToString();//维修服务
                                    ser.common = "";
                                    ser.zq = tb_mate.Rows[i]["Remark"].ToString(); ;//维修周期
                                    fwbaojia.Add(ser);
                                    OrderPrice += ser.price * ser.qty;
                                }                        
                    }

                        PdfPTable detail_table = new PdfPTable(9) { WidthPercentage = 90 };//根据列配置确定表格列数量       
                    int[] ws2 = new[] { 5, 15, 20, 0, 0, 11, 21, 9, 12 };
                    detail_table.SetWidths(ws2);
                    PdfPCell[] detail_cell = new PdfPCell[9];
                    detail_cell[0] = new PdfPCell(new Phrase("序号", FontNorml))
                    {
                        BorderWidth = 1,
                        MinimumHeight = Utilities.MillimetersToPoints(6),
                        BorderColor = BaseColor.BLACK,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    };
                    detail_cell[1] = new PdfPCell(new Phrase("产品名称", FontNorml))
                    {
                        BorderWidth = 1,
                        MinimumHeight = Utilities.MillimetersToPoints(6),
                        BorderColor = BaseColor.BLACK,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    };
                    detail_cell[2] = new PdfPCell(new Phrase("型号", FontNorml))
                    {
                        BorderWidth = 1,
                        MinimumHeight = Utilities.MillimetersToPoints(6),
                        BorderColor = BaseColor.BLACK,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    };
                    detail_cell[3] = new PdfPCell(new Phrase("单位", FontNorml))
                    {
                        BorderWidth = 1,
                        MinimumHeight = Utilities.MillimetersToPoints(6),
                        BorderColor = BaseColor.BLACK,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    };
                    detail_cell[4] = new PdfPCell(new Phrase("数量", FontNorml))
                    {
                        BorderWidth = 1,
                        MinimumHeight = Utilities.MillimetersToPoints(6),
                        BorderColor = BaseColor.BLACK,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    };
                    detail_cell[5] = new PdfPCell(new Phrase("单价", FontNorml))
                    {
                        BorderWidth = 1,
                        MinimumHeight = Utilities.MillimetersToPoints(6),
                        BorderColor = BaseColor.BLACK,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    };
                    detail_cell[6] = new PdfPCell(new Phrase("维修服务", FontNorml))
                    {
                        BorderWidth = 1,
                        MinimumHeight = Utilities.MillimetersToPoints(6),
                        BorderColor = BaseColor.BLACK,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    };
                    detail_cell[7] = new PdfPCell(new Phrase("维修周期", FontNorml))
                    {
                        BorderWidth = 1,
                        MinimumHeight = Utilities.MillimetersToPoints(6),
                        BorderColor = BaseColor.BLACK,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    };
                    detail_cell[8] = new PdfPCell(new Phrase("备注", FontNorml))
                    {
                        BorderWidth = 1,
                        MinimumHeight = Utilities.MillimetersToPoints(6),
                        BorderColor = BaseColor.BLACK,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    };
                    PdfPRow drowBody = new PdfPRow(detail_cell);
                    detail_table.Rows.Add(drowBody);

                    if (fwbaojia.Count <= MaxCount)
                    {
                        for (int i = 0; i < fwbaojia.Count; i++)
                        {
                            detail_cell = new PdfPCell[9];
                            detail_cell[0] = new PdfPCell(new Phrase(fwbaojia[i].xid.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                            detail_cell[1] = new PdfPCell(new Phrase(fwbaojia[i].name, FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                            detail_cell[2] = new PdfPCell(new Phrase(fwbaojia[i].model.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                            detail_cell[3] = new PdfPCell(new Phrase(fwbaojia[i].unit.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                            detail_cell[4] = new PdfPCell(new Phrase(fwbaojia[i].qty.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                            detail_cell[5] = new PdfPCell(new Phrase(fwbaojia[i].price.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                            detail_cell[6] = new PdfPCell(new Phrase(fwbaojia[i].content.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                            detail_cell[7] = new PdfPCell(new Phrase(fwbaojia[i].zq.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                            detail_cell[8] = new PdfPCell(new Phrase(fwbaojia[i].common.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                            drowBody = new PdfPRow(detail_cell);
                            detail_table.Rows.Add(drowBody);

                        }
                        //for (int ii = 0; ii < MaxCount - fwbaojia.Count; ii++)
                        //{
                        //    detail_cell = new PdfPCell[9];
                        //    detail_cell[0] = new PdfPCell(new Phrase("", FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        //    detail_cell[1] = new PdfPCell(new Phrase("", FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        //    detail_cell[2] = new PdfPCell(new Phrase("", FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        //    detail_cell[3] = new PdfPCell(new Phrase("", FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        //    detail_cell[4] = new PdfPCell(new Phrase("", FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        //    detail_cell[5] = new PdfPCell(new Phrase("", FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        //    detail_cell[6] = new PdfPCell(new Phrase("", FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        //    detail_cell[7] = new PdfPCell(new Phrase("", FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        //    detail_cell[8] = new PdfPCell(new Phrase("", FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        //    drowBody = new PdfPRow(detail_cell);
                        //    detail_table.Rows.Add(drowBody);
                        //}
                    //合计
                    detail_cell = new PdfPCell[9];
                    detail_cell[0] = new PdfPCell(new Phrase("总计", FontNorml)) { Colspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                    detail_cell[2] = new PdfPCell(new Phrase("（大写）：" + UpperRMB.CmycurD(OrderPrice.ToString()), FontNorml)) { Colspan = 4, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                    detail_cell[6] = new PdfPCell(new Phrase("（小写）：" + OrderPrice.ToString(), FontNorml)) { Colspan = 3, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                    drowBody = new PdfPRow(detail_cell);
                    detail_table.Rows.Add(drowBody);  
                    doc.Add(detail_table);
                    }
                    else
                    {
                        for (int i = 0; i < fwbaojia.Count; i++)
                        {
                            OrderPrice += fwbaojia[i].price * fwbaojia[i].qty;
                        }

                        PdfPTable table2 = new PdfPTable(4) { WidthPercentage = 90 };//根据列配置确定表格列数量       
                        int[] tab2w = new[] { 10, 35, 30, 25 };
                        table2.SetWidths(tab2w);
                        PdfPRow row2;
                        PdfPCell[] dcell2 = new PdfPCell[4];
                        dcell2[0] = new PdfPCell(new Phrase("序号", FontNorml));
                        dcell2[1] = new PdfPCell(new Phrase("产品型号", FontNorml));
                        dcell2[2] = new PdfPCell(new Phrase("总合计", FontNorml));
                        dcell2[3] = new PdfPCell(new Phrase("交货期", FontNorml));
                        row2 = new PdfPRow(dcell2);
                        table2.Rows.Add(row2);

                        dcell2 = new PdfPCell[4];
                        dcell2[0] = new PdfPCell(new Phrase("1", FontNorml));
                        dcell2[1] = new PdfPCell(new Phrase("详细见合同附件\"货物清单\"", FontNorml));
                        dcell2[2] = new PdfPCell(new Phrase(OrderPrice.ToString(".00"), FontNorml));
                        dcell2[3] = new PdfPCell(new Phrase("", FontNorml));
                        row2 = new PdfPRow(dcell2);
                        table2.Rows.Add(row2);

                        List<PdfPRow> rowList2 = table2.Rows;
                        foreach (var row in rowList2)
                        {
                            PdfPCell[] cells = row.GetCells();
                            foreach (PdfPCell item in cells)
                            {
                                item.BorderWidth = 1;
                                item.MinimumHeight = Utilities.MillimetersToPoints(6);
                                item.BorderColor = BaseColor.BLACK;
                                item.HorizontalAlignment = Element.ALIGN_CENTER;
                                item.VerticalAlignment = Element.ALIGN_MIDDLE;
                            }
                        }
                        doc.Add(table2);
                    }
                    string t3 = @"1) 税率及运费：{0},含回寄运费。         
2) 付款方式：款到发货。         
以下内容不属保修范围(既使是保修期内也属有偿服务)           
3) 因用户操作不当引起的故障和损坏。     
4) 由于非本公司认可的经销商或者维修人员擅自修理、更换、分解、维修、保养而引起的故障和损坏。          
5) 用户擅自修理机器时。         
6) 未经本公司同意而长期拖欠维修款。       
7) 因火灾，洪水、地震、雷击等不可抗拒的自然灾害而引起的故障和损坏。           
8) 因电源电压等非机器容许范围值而引起的故障和损坏。      
9) 因用户自行将机器运输、搬运不慎而引起的故障和损坏。     
本文件一式二份，文件以传真或正本签章均有效。     ";
                    //   t3 = t3.Replace(Environment.NewLine, String.Empty).Replace("  ", String.Empty);

                    string ratioType = "";
                    if (spn.Rows[0]["BranchRatioType"].ToString() == "无" || Convert.ToDecimal(spn.Rows[0]["BranchRatio"]) == 0)
                    {
                        ratioType = "不含税";
                    }
                    else
                    {
                        ratioType = spn.Rows[0]["BranchRatioType"].ToString() + "：" + Math.Round(Convert.ToDecimal(spn.Rows[0]["BranchRatio"]) * 100, 0).ToString() + "%";
                    }


                    Chunk beginning = new Chunk(string.Format(t3, ratioType), FontNorml);
                    Phrase p1 = new Phrase(beginning);
                    Paragraph p = new Paragraph();
                    p.Add(p1);
                    p.IndentationLeft = 30;
                    doc.Add(p);
                    doc.Add(t2);//空白行
                    //发货联系
                    PdfPTable tb_cat = new PdfPTable(4) { WidthPercentage = 90 };//根据列配置确定表格列数量
                    PdfPCell[] cell_cat = new PdfPCell[4];
                    PdfPRow row_cat;
                    int[] ws_cat = new[] { 15, 35, 15, 35 };
                    tb_cat.SetWidths(ws_cat);

                    //联系信息spn
                  
                    string lm_phone = "";
                    string lm_fax = "";
                    string lm_mail = "";
   //网点信息
                    string sell_phone1 = "";
                    string sell_phone2 = "";
                    string sell_fax = "";
                    string sell_mail = "";
                    string sell_adr = "";

                    DataTable dt_branch = DALCommon.GetDataList("BranchList", "", " [_Name]='" + spn.Rows[0]["BranchName"].ToString() + "' ").Tables[0];
                    if (dt_branch.Rows.Count > 0)
                        {                          
                            sell_phone1 = dt_branch.Rows[0]["Tel"].ToString();
                            sell_fax = dt_branch.Rows[0]["Fax"].ToString();
                            sell_mail = dt_branch.Rows[0]["Email"].ToString();
                            sell_adr = dt_branch.Rows[0]["Adr"].ToString();
                        }                    
                    //spn.Rows[0]["Operator"].ToString()  销售员信息
                    DataTable sellinfo = DALCommon.GetDataList("jc_staff", "", " [_Name]='" + spn.Rows[0]["Operator"].ToString() + "' ").Tables[0];
                    if (sellinfo.Rows.Count > 0)
                    {
                        sell_phone2 = sellinfo.Rows[0]["Tel"].ToString();
                    }
                    DataTable cuinfo = DALCommon.GetDataList("CustomerList", "", " [LinkMan]='" + spn.Rows[0]["LinkMan"].ToString() + "' and [_Name]='" + spn.Rows[0]["CustomerName"].ToString() + "' ").Tables[0];
                    if (cuinfo.Rows.Count > 0)
                    {
                        lm_phone = cuinfo.Rows[0]["Tel2"].ToString();
                        lm_fax = cuinfo.Rows[0]["Fax"].ToString();
                        lm_mail = cuinfo.Rows[0]["Email"].ToString();
                    }


                    //spn spd
                    cell_cat[0] = new PdfPCell(new Phrase("客户名称：", FontNorml));
                    cell_cat[1] = new PdfPCell(new Phrase(comName, FontNorml));
                    cell_cat[2] = new PdfPCell(new Phrase("维修公司：", FontNorml));
                    cell_cat[3] = new PdfPCell(new Phrase(cname, FontNorml));
                    row_cat = new PdfPRow(cell_cat);
                    tb_cat.Rows.Add(row_cat);

                    cell_cat = new PdfPCell[4];
                    cell_cat[0] = new PdfPCell(new Phrase("联系人：", FontNorml));
                    cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["LinkMan"].ToString(), FontNorml));
                    cell_cat[2] = new PdfPCell(new Phrase("业务员：", FontNorml));
                    cell_cat[3] = new PdfPCell(new Phrase(spn.Rows[0]["Operator"].ToString(), FontNorml));
                    row_cat = new PdfPRow(cell_cat);
                    tb_cat.Rows.Add(row_cat);

                    cell_cat = new PdfPCell[4];
                    cell_cat[0] = new PdfPCell(new Phrase("手机：", FontNorml));
                    cell_cat[1] = new PdfPCell(new Phrase(lm_phone, FontNorml));
                    cell_cat[2] = new PdfPCell(new Phrase("手机：", FontNorml));
                    cell_cat[3] = new PdfPCell(new Phrase(sell_phone2, FontNorml));
                    row_cat = new PdfPRow(cell_cat);
                    tb_cat.Rows.Add(row_cat);

                    cell_cat = new PdfPCell[4];
                    cell_cat[0] = new PdfPCell(new Phrase("电话：", FontNorml));
                    cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["Tel"].ToString(), FontNorml));
                    cell_cat[2] = new PdfPCell(new Phrase("电话：", FontNorml));
                    cell_cat[3] = new PdfPCell(new Phrase(sell_phone1, FontNorml));
                    row_cat = new PdfPRow(cell_cat);
                    tb_cat.Rows.Add(row_cat);

                    cell_cat = new PdfPCell[4];
                    cell_cat[0] = new PdfPCell(new Phrase("传真：", FontNorml));
                    cell_cat[1] = new PdfPCell(new Phrase(lm_fax, FontNorml));
                    cell_cat[2] = new PdfPCell(new Phrase("传真：", FontNorml));
                    cell_cat[3] = new PdfPCell(new Phrase(sell_fax, FontNorml));
                    row_cat = new PdfPRow(cell_cat);
                    tb_cat.Rows.Add(row_cat);

                    cell_cat = new PdfPCell[4];
                    cell_cat[0] = new PdfPCell(new Phrase("Email：", FontNorml));
                    cell_cat[1] = new PdfPCell(new Phrase(lm_mail, FontNorml));
                    cell_cat[2] = new PdfPCell(new Phrase("Email：", FontNorml));
                    cell_cat[3] = new PdfPCell(new Phrase(sell_mail, FontNorml));
                    row_cat = new PdfPRow(cell_cat);
                    tb_cat.Rows.Add(row_cat);

                    cell_cat = new PdfPCell[4];
                    cell_cat[0] = new PdfPCell(new Phrase("客户地址：", FontNorml));
                    cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["Adr"].ToString(), FontNorml));
                    cell_cat[2] = new PdfPCell(new Phrase("公司地址：", FontNorml));
                    cell_cat[3] = new PdfPCell(new Phrase(sell_adr, FontNorml));
                    row_cat = new PdfPRow(cell_cat);
                    tb_cat.Rows.Add(row_cat);                                      

                    foreach (PdfPRow row in tb_cat.Rows)
                    {
                        PdfPCell[] cells = row.GetCells();
                        foreach (PdfPCell item in cells)
                        {
                            item.BorderWidth = 1;
                            item.MinimumHeight = Utilities.MillimetersToPoints(6);
                            item.BorderColor = BaseColor.BLACK;
                            item.HorizontalAlignment = Element.ALIGN_CENTER;
                            item.VerticalAlignment = Element.ALIGN_MIDDLE;
                        }
                    }
             
                    //doc.Add(tb_cat);
                    tb_cat.TotalWidth = 560f;
                    tb_cat.WriteSelectedRows(0, -1, doc.PageSize.Width - 36f - 540f, 160f, pdfWritey.DirectContent);
                    Image img;
                    string wdName = cname;//spn.Rows[0]["BranchName"].ToString();
                    if (wdName.IndexOf("凡驰") >=0)
                    {
                        img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "fcht.jpg");
                    }
                    else if (wdName.IndexOf("美福洋") >=0)
                    {
                        img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "mfyht.jpg");
                    }
                    else if (wdName.IndexOf("盛唐") >= 0)
                    {
                        img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "sthxht.gif");
                    }
                    else if (wdName.IndexOf("贝利") >= 0)
                    {
                        img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "blht.png");
                    }
                    else if (wdName.IndexOf("华宇") >= 0)
                    {
                        img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "hyht.png");
                    }
                    else {
                        img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "null.png");
                    }
                    img.ScaleToFit(120f, 120f);
   img.SetAbsolutePosition(doc.PageSize.Width - 36f - 200f, 20f);
                  

                    doc.Add(img);
                    if (fwbaojia.Count > MaxCount)
                    {
                        doc.NewPage();
                        title = new Paragraph("附件合同", FontBig);
                        title.Alignment = Element.ALIGN_CENTER;
                        doc.Add(title);//第二页标题
                        title = new Paragraph(" ", FontNorml);
                        doc.Add(title);
                        doc.Add(table);
                        title = new Paragraph(" ", FontTitle);
                        doc.Add(title);
                        for (int i = 0; i < fwbaojia.Count; i++)
                        {
                            detail_cell = new PdfPCell[9];
                            detail_cell[0] = new PdfPCell(new Phrase(fwbaojia[i].xid.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                            detail_cell[1] = new PdfPCell(new Phrase(fwbaojia[i].name, FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                            detail_cell[2] = new PdfPCell(new Phrase(fwbaojia[i].model.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                            detail_cell[3] = new PdfPCell(new Phrase(fwbaojia[i].unit.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                            detail_cell[4] = new PdfPCell(new Phrase(fwbaojia[i].qty.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                            detail_cell[5] = new PdfPCell(new Phrase(fwbaojia[i].price.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                            detail_cell[6] = new PdfPCell(new Phrase(fwbaojia[i].content.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                            detail_cell[7] = new PdfPCell(new Phrase(fwbaojia[i].zq.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                            detail_cell[8] = new PdfPCell(new Phrase(fwbaojia[i].common.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                            drowBody = new PdfPRow(detail_cell);
                            detail_table.Rows.Add(drowBody);

                        }                    
                        //合计
                        detail_cell = new PdfPCell[9];
                        detail_cell[0] = new PdfPCell(new Phrase("总计", FontNorml)) { Colspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        detail_cell[2] = new PdfPCell(new Phrase("（大写）：" + UpperRMB.CmycurD(OrderPrice.ToString()), FontNorml)) { Colspan = 4, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        detail_cell[6] = new PdfPCell(new Phrase("（小写）：" + OrderPrice.ToString(), FontNorml)) { Colspan = 3, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        drowBody = new PdfPRow(detail_cell);
                        detail_table.Rows.Add(drowBody);
                        doc.Add(detail_table);

                        PdfDiv div = new PdfDiv();
                        div.TextAlignment = Element.ALIGN_RIGHT;//cname
                        div.PaddingRight = 30;
                        Paragraph cop = new Paragraph(" ", FontBig);
                        div.AddElement(cop);
                        cop = new Paragraph(cname, FontBig);
                        cop.Alignment = Element.ALIGN_RIGHT;
                        div.AddElement(cop);
                        cop = new Paragraph(string.Format("{0:yyyy-MM-dd}", DateTime.Now), FontBig);
                        cop.Alignment = Element.ALIGN_RIGHT;
                        div.AddElement(cop);
                        doc.Add(div);
                        img.SetAbsolutePosition(doc.PageSize.Width - 36f - 130f, doc.PageSize.Height - ((fwbaojia.Count + 2) * 21 + 200));//410
                        doc.Add(img);


                    }
                    #endregion
                }
                else {
                    title = new Paragraph("错误：ID无效！", FontSmall);
                    title.IndentationLeft = 30;
                    doc.Add(title);
                    doc.Close();
                    return stream;
                }
          }
            doc.Close();
        return stream;

    }
    public MemoryStream PrintFWBJ(string num)
    {
        int MaxCount = 10;
        if (num.LastIndexOf(",") == num.Length - 1)
        {
            num = num.Substring(0, num.LastIndexOf(","));
        }
        string[] ids = num.Split(',');
        //页面大小
        Document doc = new Document(PageSize.A4);
        doc.SetMargins(0f, 0f, 10f, 0f);
        MemoryStream stream = new MemoryStream();
     
        PdfWriter pdfWritey = PdfWriter.GetInstance(doc, stream);
        pdfWritey.CloseStream = false;
        doc.Open();
        DataTable spn = new DataTable();

        //字体
        iTextSharp.text.Font FontBig = new iTextSharp.text.Font(baseFont, 16f);
        iTextSharp.text.Font FontNorml = new iTextSharp.text.Font(baseFont, 10f);
        iTextSharp.text.Font FontSmall = new iTextSharp.text.Font(baseFont, 8f);
        iTextSharp.text.Font FontTitle = new iTextSharp.text.Font(baseFont, 12f, Font.BOLD);
        FontBig.IsBold();
        Paragraph title;
        if (ids.Count() <= 0)
        {
            title = new Paragraph("错误：ID为空", FontBig);
            title.IndentationLeft = 30;
            doc.Add(title);
            doc.Close();
            return stream;
        }
        else
        {
            spn = DALCommon.GetDataList("fw_services", "", " [ID]=" + ids[0]).Tables[0];

            if (spn.Rows.Count > 0)
            {
                string comName = spn.Rows[0]["CustomerName"].ToString();
                string billNum = spn.Rows[0]["BillID"].ToString();
                string bn = ids.Length > 1 ? billNum.Substring(0, billNum.LastIndexOf("-")) : billNum;
                DataTable spn2; string billNum2; string bn2;
                for (int x = 0; x < ids.Count(); x++)
                {
                    if (!string.IsNullOrEmpty(ids[x]))
                    {
                        spn2 = DALCommon.GetDataList("fw_services", "", " [ID]=" + ids[x]).Tables[0];
                        if (spn2.Rows.Count > 0)
                        {

                            billNum2 = spn2.Rows[0]["BillID"].ToString();
                            bn2 = ids.Length > 1 ? billNum2.Substring(0, billNum2.LastIndexOf("-")) : billNum2;

                            if (bn != bn2)
                            {
                                title = new Paragraph("错误：服务号不匹配，不能合并！", FontBig);
                                title.IndentationLeft = 30;
                                doc.Add(title);
                                doc.Close();
                                return stream;
                            }
                        }
                        else
                        {
                            title = new Paragraph("错误：ID无效！", FontBig);
                            title.IndentationLeft = 30;
                            doc.Add(title);
                            doc.Close();
                            return stream;
                        }
                    }
                }

                #region main

                string cname = spn.Rows[0]["BranchName"].ToString() == "总部" || string.IsNullOrEmpty(spn.Rows[0]["BranchName"].ToString()) ? "北京盛唐和讯科技有限公司" : spn.Rows[0]["BranchName"].ToString();
                title = new Paragraph(cname, FontBig);
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);
                title = new Paragraph("维修报价单", FontBig);
                title.Alignment = Element.ALIGN_CENTER;
                Paragraph t2 = new Paragraph("  ", FontBig);
                doc.Add(title);
                doc.Add(t2);

                //内容
                PdfPTable table = new PdfPTable(4) { WidthPercentage = 90 };//根据列配置确定表格列数量

                PdfPCell[] cellBody = new PdfPCell[4];
                int[] ws = new[] { 12, 48, 12, 28 };
                table.SetWidths(ws);
                cellBody[0] = new PdfPCell(new Phrase("维修单号：", FontNorml))
                {
                    BorderWidth = 0,
                    MinimumHeight = Utilities.MillimetersToPoints(6),
                    // Width = Utilities.MillimetersToPoints(10),
                    BorderColor = BaseColor.WHITE,
                    HorizontalAlignment = Element.ALIGN_LEFT
                };
                cellBody[1] = new PdfPCell(new Phrase(bn, FontNorml))
                {
                    BorderWidth = 0,
                    MinimumHeight = Utilities.MillimetersToPoints(6),
                    //  Width = Utilities.MillimetersToPoints(20),
                    BorderColor = BaseColor.WHITE,
                    HorizontalAlignment = Element.ALIGN_LEFT
                };
                cellBody[2] = new PdfPCell(new Phrase("报价日期：", FontNorml))
                {
                    BorderWidth = 0,
                    MinimumHeight = Utilities.MillimetersToPoints(6),
                    //Width = Utilities.MillimetersToPoints(10),
                    BorderColor = BaseColor.WHITE,
                    HorizontalAlignment = Element.ALIGN_RIGHT
                };
                cellBody[3] = new PdfPCell(new Phrase(string.Format("{0:yyyy-MM-dd}", Convert.ToDateTime(spn.Rows[0]["Time_Make"])), FontNorml))
                {
                    BorderWidth = 0,
                    MinimumHeight = Utilities.MillimetersToPoints(6),
                    BorderColor = BaseColor.WHITE,
                    HorizontalAlignment = Element.ALIGN_LEFT
                };
                PdfPRow rowBody = new PdfPRow(cellBody);
                table.Rows.Add(rowBody);

                cellBody = new PdfPCell[4];
                cellBody[0] = new PdfPCell(new Phrase("客户名称：", FontNorml))
                {
                    BorderWidth = 0,
                    MinimumHeight = Utilities.MillimetersToPoints(6),
                    BorderColor = BaseColor.WHITE,
                    HorizontalAlignment = Element.ALIGN_LEFT
                };
                cellBody[1] = new PdfPCell(new Phrase(comName, FontNorml))
                {
                    BorderWidth = 0,
                    MinimumHeight = Utilities.MillimetersToPoints(6),
                    BorderColor = BaseColor.WHITE,
                    HorizontalAlignment = Element.ALIGN_LEFT
                };
                cellBody[2] = new PdfPCell(new Phrase("报价单位：", FontNorml))
                {
                    BorderWidth = 0,
                    MinimumHeight = Utilities.MillimetersToPoints(6),
                    BorderColor = BaseColor.WHITE,
                    HorizontalAlignment = Element.ALIGN_RIGHT
                };
                cellBody[3] = new PdfPCell(new Phrase(cname, FontNorml))
                {
                    BorderWidth = 0,
                    MinimumHeight = Utilities.MillimetersToPoints(6),
                    BorderColor = BaseColor.WHITE,
                    HorizontalAlignment = Element.ALIGN_LEFT
                };
                rowBody = new PdfPRow(cellBody);
                table.Rows.Add(rowBody);

                cellBody = new PdfPCell[4];
                cellBody[0] = new PdfPCell(new Phrase("联系人：", FontNorml))
                {
                    BorderWidth = 0,
                    MinimumHeight = Utilities.MillimetersToPoints(6),
                    BorderColor = BaseColor.WHITE,
                    HorizontalAlignment = Element.ALIGN_LEFT
                };
                cellBody[1] = new PdfPCell(new Phrase(spn.Rows[0]["LinkMan"].ToString(), FontNorml))
                {
                    BorderWidth = 0,
                    MinimumHeight = Utilities.MillimetersToPoints(6),
                    BorderColor = BaseColor.WHITE,
                    HorizontalAlignment = Element.ALIGN_LEFT
                };

                cellBody[2] = new PdfPCell(new Phrase("报价人：", FontNorml))
                {
                    BorderWidth = 0,
                    MinimumHeight = Utilities.MillimetersToPoints(6),
                    BorderColor = BaseColor.WHITE,
                    HorizontalAlignment = Element.ALIGN_RIGHT
                };
                cellBody[3] = new PdfPCell(new Phrase(spn.Rows[0]["Operator"].ToString(), FontNorml))
                {
                    BorderWidth = 0,
                    MinimumHeight = Utilities.MillimetersToPoints(6),
                    BorderColor = BaseColor.WHITE,
                    HorizontalAlignment = Element.ALIGN_LEFT
                };
                rowBody = new PdfPRow(cellBody);
                table.Rows.Add(rowBody);


                doc.Add(table);
                //条款
                string t1 = "  尊敬的客户：";
                string t11 = "  感谢您对我公司的支持与合作！根据贵公司所述产品相关的信息，我公司已在下面表格报价。请确认以下服务方式及计费金额，如同意签字并加盖公章回传给我们。";
                doc.Add(new Paragraph(t1, FontNorml) { IndentationLeft = 30 });
                doc.Add(new Paragraph(t11, FontNorml) { IndentationLeft = 30, IndentationRight = 30 });
                doc.Add(new Paragraph(" ", FontNorml));
                //产品详细
                //fw_servicesmaterial 耗材
                DataTable tb_mate = DALCommon.GetDataList("fw_servicesoffer", "", " [BillID] in (" + num + ")").Tables[0];
                List<serModel> fwbaojia = new List<serModel>();
                decimal OrderPrice = 0;
                if (tb_mate.Rows.Count > 0)
                {
                    serModel ser;

                    for (int i = 0; i < tb_mate.Rows.Count; i++)
                    {
                        ser = new serModel();
                        ser.xid = i + 1;//序号
                        ser.name = spn.Rows[0]["ProductClass"].ToString();//c产品名称
                        ser.model = spn.Rows[0]["ProductModel"].ToString(); //产品型号
                        ser.unit = "";//tb_mate.Rows[i]["Unit"].ToString(); 单位
                        ser.qty = 1;//数量
                        ser.price = Convert.ToDecimal(tb_mate.Rows[i]["dAmount"]);
                        ser.content = tb_mate.Rows[i]["_Name"].ToString();//维修服务
                        ser.common = "";//维修周期
                        ser.zq = tb_mate.Rows[i]["Remark"].ToString(); ;//维修周期
                        fwbaojia.Add(ser);
                        OrderPrice += ser.price * ser.qty;
                    }
                }


                PdfPTable detail_table = new PdfPTable(9) { WidthPercentage = 90 };//根据列配置确定表格列数量       
                int[] ws2 = new[] { 5, 15, 20, 0, 0, 11, 21, 9, 12 };
                detail_table.SetWidths(ws2);
                PdfPCell[] detail_cell = new PdfPCell[9];
                detail_cell[0] = new PdfPCell(new Phrase("序号", FontNorml))
                {
                    BorderWidth = 1,
                    MinimumHeight = Utilities.MillimetersToPoints(6),
                    BorderColor = BaseColor.BLACK,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };
                detail_cell[1] = new PdfPCell(new Phrase("产品名称", FontNorml))
                {
                    BorderWidth = 1,
                    MinimumHeight = Utilities.MillimetersToPoints(6),
                    BorderColor = BaseColor.BLACK,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };
                detail_cell[2] = new PdfPCell(new Phrase("型号", FontNorml))
                {
                    BorderWidth = 1,
                    MinimumHeight = Utilities.MillimetersToPoints(6),
                    BorderColor = BaseColor.BLACK,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };
                detail_cell[3] = new PdfPCell(new Phrase("单位", FontNorml))
                {
                    BorderWidth = 1,
                    MinimumHeight = Utilities.MillimetersToPoints(6),
                    BorderColor = BaseColor.BLACK,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };
                detail_cell[4] = new PdfPCell(new Phrase("数量", FontNorml))
                {
                    BorderWidth = 1,
                    MinimumHeight = Utilities.MillimetersToPoints(6),
                    BorderColor = BaseColor.BLACK,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };
                detail_cell[5] = new PdfPCell(new Phrase("单价", FontNorml))
                {
                    BorderWidth = 1,
                    MinimumHeight = Utilities.MillimetersToPoints(6),
                    BorderColor = BaseColor.BLACK,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };
                detail_cell[6] = new PdfPCell(new Phrase("维修服务", FontNorml))
                {
                    BorderWidth = 1,
                    MinimumHeight = Utilities.MillimetersToPoints(6),
                    BorderColor = BaseColor.BLACK,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };
                detail_cell[7] = new PdfPCell(new Phrase("维修周期", FontNorml))
                {
                    BorderWidth = 1,
                    MinimumHeight = Utilities.MillimetersToPoints(6),
                    BorderColor = BaseColor.BLACK,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };
                detail_cell[8] = new PdfPCell(new Phrase("备注", FontNorml))
                {
                    BorderWidth = 1,
                    MinimumHeight = Utilities.MillimetersToPoints(6),
                    BorderColor = BaseColor.BLACK,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };
                PdfPRow drowBody = new PdfPRow(detail_cell);
                detail_table.Rows.Add(drowBody);

                if (fwbaojia.Count <= MaxCount)
                {
                    for (int i = 0; i < fwbaojia.Count; i++)
                    {
                        detail_cell = new PdfPCell[9];
                        detail_cell[0] = new PdfPCell(new Phrase(fwbaojia[i].xid.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        detail_cell[1] = new PdfPCell(new Phrase(fwbaojia[i].name, FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        detail_cell[2] = new PdfPCell(new Phrase(fwbaojia[i].model.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        detail_cell[3] = new PdfPCell(new Phrase(fwbaojia[i].unit.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        detail_cell[4] = new PdfPCell(new Phrase(fwbaojia[i].qty.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        detail_cell[5] = new PdfPCell(new Phrase(fwbaojia[i].price.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        detail_cell[6] = new PdfPCell(new Phrase(fwbaojia[i].content.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        detail_cell[7] = new PdfPCell(new Phrase(fwbaojia[i].zq.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        detail_cell[8] = new PdfPCell(new Phrase(fwbaojia[i].common.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        drowBody = new PdfPRow(detail_cell);
                        detail_table.Rows.Add(drowBody);

                    }
                    //for (int ii = 0; ii < MaxCount - fwbaojia.Count; ii++)
                    //{
                    //    detail_cell = new PdfPCell[9];
                    //    detail_cell[0] = new PdfPCell(new Phrase("", FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                    //    detail_cell[1] = new PdfPCell(new Phrase("", FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                    //    detail_cell[2] = new PdfPCell(new Phrase("", FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                    //    detail_cell[3] = new PdfPCell(new Phrase("", FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                    //    detail_cell[4] = new PdfPCell(new Phrase("", FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                    //    detail_cell[5] = new PdfPCell(new Phrase("", FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                    //    detail_cell[6] = new PdfPCell(new Phrase("", FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                    //    detail_cell[7] = new PdfPCell(new Phrase("", FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                    //    detail_cell[8] = new PdfPCell(new Phrase("", FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                    //    drowBody = new PdfPRow(detail_cell);
                    //    detail_table.Rows.Add(drowBody);
                    //}
                    //合计
                    detail_cell = new PdfPCell[9];
                    detail_cell[0] = new PdfPCell(new Phrase("总计", FontNorml)) { Colspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                    detail_cell[2] = new PdfPCell(new Phrase("（大写）：" + UpperRMB.CmycurD(OrderPrice.ToString()), FontNorml)) { Colspan = 4, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                    detail_cell[6] = new PdfPCell(new Phrase("（小写）：" + OrderPrice.ToString(), FontNorml)) { Colspan = 3, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };

                    drowBody = new PdfPRow(detail_cell);
                    detail_table.Rows.Add(drowBody);

                    doc.Add(detail_table);
                }
                else {
                    for (int i = 0; i < fwbaojia.Count; i++)
                    {
                        OrderPrice += fwbaojia[i].price * fwbaojia[i].qty;
                    }

                    PdfPTable table2 = new PdfPTable(4) { WidthPercentage = 90 };//根据列配置确定表格列数量       
                    int[] tab2w = new[] { 10, 35, 30, 25 };
                    table2.SetWidths(tab2w);
                    PdfPRow row2;
                    PdfPCell[] dcell2 = new PdfPCell[4];
                    dcell2[0] = new PdfPCell(new Phrase("序号", FontNorml));
                    dcell2[1] = new PdfPCell(new Phrase("产品型号", FontNorml));
                    dcell2[2] = new PdfPCell(new Phrase("总合计", FontNorml));
                    dcell2[3] = new PdfPCell(new Phrase("交货期", FontNorml));
                    row2 = new PdfPRow(dcell2);
                    table2.Rows.Add(row2);

                    dcell2 = new PdfPCell[4];
                    dcell2[0] = new PdfPCell(new Phrase("1", FontNorml));
                    dcell2[1] = new PdfPCell(new Phrase("详细见合同附件\"货物清单\"", FontNorml));
                    dcell2[2] = new PdfPCell(new Phrase(OrderPrice.ToString(".00"), FontNorml));
                    dcell2[3] = new PdfPCell(new Phrase("", FontNorml));
                    row2 = new PdfPRow(dcell2);
                    table2.Rows.Add(row2);

                    List<PdfPRow> rowList2 = table2.Rows;
                    foreach (var row in rowList2)
                    {
                        PdfPCell[] cells = row.GetCells();
                        foreach (PdfPCell item in cells)
                        {
                            item.BorderWidth = 1;
                            item.MinimumHeight = Utilities.MillimetersToPoints(6);
                            item.BorderColor = BaseColor.BLACK;
                            item.HorizontalAlignment = Element.ALIGN_CENTER;
                            item.VerticalAlignment = Element.ALIGN_MIDDLE;
                        }
                    }
                    doc.Add(table2);
                }
                string t3 = @"1) 税率及运费：{0},含回寄运费。         
2) 付款方式：款到发货。         
以下内容不属保修范围(既使是保修期内也属有偿服务)           
3) 因用户操作不当引起的故障和损坏。     
4) 由于非本公司认可的经销商或者维修人员擅自修理、更换、分解、维修、保养而引起的故障和损坏。          
5) 用户擅自修理机器时。         
6) 未经本公司同意而长期拖欠维修款。       
7) 因火灾，洪水、地震、雷击等不可抗拒的自然灾害而引起的故障和损坏。           
8) 因电源电压等非机器容许范围值而引起的故障和损坏。      
9) 因用户自行将机器运输、搬运不慎而引起的故障和损坏。     
本文件一式二份，文件以传真或正本签章均有效。     ";
                //   t3 = t3.Replace(Environment.NewLine, String.Empty).Replace("  ", String.Empty);
                string ratioType = "";
                if (spn.Rows[0]["BranchRatioType"].ToString() == "无" || Convert.ToDecimal(spn.Rows[0]["BranchRatio"]) == 0)
                {
                    ratioType = "不含税";//含 17%增值税
                }
                else
                {
                    ratioType = spn.Rows[0]["BranchRatioType"].ToString() + "：" + Math.Round(Convert.ToDecimal(spn.Rows[0]["BranchRatio"]) * 100, 0).ToString() + "%";
                }

                Chunk beginning = new Chunk(string.Format(t3,ratioType), FontNorml);
                Phrase p1 = new Phrase(beginning);
                Paragraph p = new Paragraph();
                p.Add(p1);
                p.IndentationLeft = 30;
                doc.Add(p);
                doc.Add(t2);//空白行
                //发货联系
                PdfPTable tb_cat = new PdfPTable(4);//根据列配置确定表格列数量
                PdfPCell[] cell_cat = new PdfPCell[4];
                PdfPRow row_cat;
                int[] ws_cat = new[] { 15, 35, 15, 35 };
                tb_cat.SetWidths(ws_cat);

                //联系信息spn

                string lm_phone = "";
                string lm_fax = "";
                string lm_mail = "";
                //网点信息
                string sell_phone1 = "";
                string sell_phone2 = "";
                string sell_fax = "";
                string sell_mail = "";
                string sell_adr = "";

                DataTable dt_branch = DALCommon.GetDataList("BranchList", "", " [_Name]='" + spn.Rows[0]["BranchName"].ToString() + "' ").Tables[0];
                if (dt_branch.Rows.Count > 0)
                {
                    sell_phone1 = dt_branch.Rows[0]["Tel"].ToString();
                    sell_fax = dt_branch.Rows[0]["Fax"].ToString();
                    sell_mail = dt_branch.Rows[0]["Email"].ToString();
                    sell_adr = dt_branch.Rows[0]["Adr"].ToString();
                }
                //spn.Rows[0]["Operator"].ToString()  销售员信息
                DataTable sellinfo = DALCommon.GetDataList("jc_staff", "", " [_Name]='" + spn.Rows[0]["Operator"].ToString() + "' ").Tables[0];
                if (sellinfo.Rows.Count > 0)
                {
                    sell_phone2 = sellinfo.Rows[0]["Tel"].ToString();
                }
                DataTable cuinfo = DALCommon.GetDataList("CustomerList", "", " [LinkMan]='" + spn.Rows[0]["LinkMan"].ToString() + "' and [_Name]='" + spn.Rows[0]["CustomerName"].ToString() + "' ").Tables[0];
                if (cuinfo.Rows.Count > 0)
                {
                    lm_phone = cuinfo.Rows[0]["Tel2"].ToString();
                    lm_fax = cuinfo.Rows[0]["Fax"].ToString();
                    lm_mail = cuinfo.Rows[0]["Email"].ToString();
                }


                //spn spd
                cell_cat[0] = new PdfPCell(new Phrase("客户名称：", FontNorml));
                cell_cat[1] = new PdfPCell(new Phrase(comName, FontNorml));
                cell_cat[2] = new PdfPCell(new Phrase("维修公司：", FontNorml));
                cell_cat[3] = new PdfPCell(new Phrase(cname, FontNorml));
                row_cat = new PdfPRow(cell_cat);
                tb_cat.Rows.Add(row_cat);

                cell_cat = new PdfPCell[4];
                cell_cat[0] = new PdfPCell(new Phrase("联系人：", FontNorml));
                cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["LinkMan"].ToString(), FontNorml));
                cell_cat[2] = new PdfPCell(new Phrase("业务员：", FontNorml));
                cell_cat[3] = new PdfPCell(new Phrase(spn.Rows[0]["Operator"].ToString(), FontNorml));
                row_cat = new PdfPRow(cell_cat);
                tb_cat.Rows.Add(row_cat);

                cell_cat = new PdfPCell[4];
                cell_cat[0] = new PdfPCell(new Phrase("手机：", FontNorml));
                cell_cat[1] = new PdfPCell(new Phrase(lm_phone, FontNorml));
                cell_cat[2] = new PdfPCell(new Phrase("手机：", FontNorml));
                cell_cat[3] = new PdfPCell(new Phrase(sell_phone2, FontNorml));
                row_cat = new PdfPRow(cell_cat);
                tb_cat.Rows.Add(row_cat);

                cell_cat = new PdfPCell[4];
                cell_cat[0] = new PdfPCell(new Phrase("电话：", FontNorml));
                cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["Tel"].ToString(), FontNorml));
                cell_cat[2] = new PdfPCell(new Phrase("电话：", FontNorml));
                cell_cat[3] = new PdfPCell(new Phrase(sell_phone1, FontNorml));
                row_cat = new PdfPRow(cell_cat);
                tb_cat.Rows.Add(row_cat);

                cell_cat = new PdfPCell[4];
                cell_cat[0] = new PdfPCell(new Phrase("传真：", FontNorml));
                cell_cat[1] = new PdfPCell(new Phrase(lm_fax, FontNorml));
                cell_cat[2] = new PdfPCell(new Phrase("传真：", FontNorml));
                cell_cat[3] = new PdfPCell(new Phrase(sell_fax, FontNorml));
                row_cat = new PdfPRow(cell_cat);
                tb_cat.Rows.Add(row_cat);

                cell_cat = new PdfPCell[4];
                cell_cat[0] = new PdfPCell(new Phrase("Email：", FontNorml));
                cell_cat[1] = new PdfPCell(new Phrase(lm_mail, FontNorml));
                cell_cat[2] = new PdfPCell(new Phrase("Email：", FontNorml));
                cell_cat[3] = new PdfPCell(new Phrase(sell_mail, FontNorml));
                row_cat = new PdfPRow(cell_cat);
                tb_cat.Rows.Add(row_cat);

                cell_cat = new PdfPCell[4];
                cell_cat[0] = new PdfPCell(new Phrase("客户地址：", FontNorml));
                cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["Adr"].ToString(), FontNorml));
                cell_cat[2] = new PdfPCell(new Phrase("公司地址：", FontNorml));
                cell_cat[3] = new PdfPCell(new Phrase(sell_adr, FontNorml));
                row_cat = new PdfPRow(cell_cat);
                tb_cat.Rows.Add(row_cat);

                foreach (PdfPRow row in tb_cat.Rows)
                {
                    PdfPCell[] cells = row.GetCells();
                    foreach (PdfPCell item in cells)
                    {
                        item.BorderWidth = 1;
                        item.MinimumHeight = Utilities.MillimetersToPoints(6);
                        item.BorderColor = BaseColor.BLACK;
                        item.HorizontalAlignment = Element.ALIGN_CENTER;
                        item.VerticalAlignment = Element.ALIGN_MIDDLE;
                    }
                }

            //    doc.Add(tb_cat);
                tb_cat.TotalWidth = 560f;
                tb_cat.WriteSelectedRows(0, -1, doc.PageSize.Width - 36f - 540f, 160f, pdfWritey.DirectContent);
                Image img;
                string wdName = cname;//spn.Rows[0]["BranchName"].ToString();
                if (wdName.IndexOf("凡驰") >=0)
                {
                    img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "fc.jpg");
                }
                else if (wdName.IndexOf("美福洋") >= 0)
                {
                    img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "mfy.jpg");
                }
                else if (wdName.IndexOf("盛唐") >= 0)
                {
                    img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "sthx.jpg");
                }
                else if (wdName.IndexOf("贝利") >= 0)
                {
                    img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "bl.png");
                }
                else if (wdName.IndexOf("华宇") >= 0)
                {
                    img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "hy.png");
                }
                else {
                    img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "null.png");
                }

                img.ScaleToFit(150f, 150f);
    img.SetAbsolutePosition(doc.PageSize.Width - 36f - 200f, 20f);
          

                doc.Add(img);
                if (fwbaojia.Count > MaxCount)
                {
                    doc.NewPage();
                    title = new Paragraph("附件合同", FontBig);
                    title.Alignment = Element.ALIGN_CENTER;
                    doc.Add(title);//第二页标题
                    title = new Paragraph(" ", FontNorml);
                    doc.Add(title);
                    doc.Add(table);
                    title = new Paragraph(" ", FontTitle);              
                    doc.Add(title);

                    for (int i = 0; i < fwbaojia.Count; i++)
                    {
                        detail_cell = new PdfPCell[9];
                        detail_cell[0] = new PdfPCell(new Phrase(fwbaojia[i].xid.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        detail_cell[1] = new PdfPCell(new Phrase(fwbaojia[i].name, FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        detail_cell[2] = new PdfPCell(new Phrase(fwbaojia[i].model.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        detail_cell[3] = new PdfPCell(new Phrase(fwbaojia[i].unit.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        detail_cell[4] = new PdfPCell(new Phrase(fwbaojia[i].qty.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        detail_cell[5] = new PdfPCell(new Phrase(fwbaojia[i].price.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        detail_cell[6] = new PdfPCell(new Phrase(fwbaojia[i].content.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        detail_cell[7] = new PdfPCell(new Phrase(fwbaojia[i].zq.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        detail_cell[8] = new PdfPCell(new Phrase(fwbaojia[i].common.ToString(), FontNorml)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        drowBody = new PdfPRow(detail_cell);
                        detail_table.Rows.Add(drowBody);

                    }
                
                    //合计
                    detail_cell = new PdfPCell[9];
                    detail_cell[0] = new PdfPCell(new Phrase("总计", FontNorml)) { Colspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                    detail_cell[2] = new PdfPCell(new Phrase("（大写）：" + UpperRMB.CmycurD(OrderPrice.ToString()), FontNorml)) { Colspan = 4, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                    detail_cell[6] = new PdfPCell(new Phrase("（小写）：" + OrderPrice.ToString(), FontNorml)) { Colspan = 3, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };

                    drowBody = new PdfPRow(detail_cell);
                    detail_table.Rows.Add(drowBody);

                    doc.Add(detail_table);

                    PdfDiv div = new PdfDiv();
                    div.TextAlignment = Element.ALIGN_RIGHT;//cname
                    div.PaddingRight = 30;
                    Paragraph cop = new Paragraph(" ", FontBig);
                    div.AddElement(cop);
                    cop = new Paragraph(cname, FontBig);
                    cop.Alignment = Element.ALIGN_RIGHT;
                    div.AddElement(cop);
                    cop = new Paragraph(string.Format("{0:yyyy-MM-dd}", DateTime.Now), FontBig);
                    cop.Alignment = Element.ALIGN_RIGHT;
                    div.AddElement(cop);
                    doc.Add(div);
                    img.SetAbsolutePosition(doc.PageSize.Width - 36f - 130f, doc.PageSize.Height - ((fwbaojia.Count + 2) * 21 + 195));//410
                    doc.Add(img);



                }
                #endregion
            }
            else
            {
                title = new Paragraph("错误：ID无效！", FontSmall);
                title.IndentationLeft = 30;
                doc.Add(title);
                doc.Close();
                return stream;
            }
        }
        doc.Close();
        return stream;

    }
}
/// <summary>
/// 服务合并model
/// </summary>
public class serModel
{
    public int xid { get; set; }
    public string name { get; set; }
    public string model { get; set; }
    public string unit { get; set; }
    public int qty { get; set; }
    public decimal price { get; set; }
    public string content { get; set; }
    public string zq { get; set; }
    public string common { get; set; }
    public decimal totlePrice { get; set; }
}