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
/// PrintDoc ��ժҪ˵��
/// </summary>
public class PrintDoc
{
	public PrintDoc()
	{
		//
		// TODO: �ڴ˴���ӹ��캯���߼�
		//    
	}
    //ָ������⣬����������  �������� STZHONGS.TTF  STSONG.TTF
    BaseFont baseFont = BaseFont.CreateFont(System.Web.HttpContext.Current.Server.MapPath("~/dll/STSONG.TTF"), BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
    /// <summary>
    /// ���۶���
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
         //ҳ���С
         Document doc = new Document(PageSize.A4);
        doc.SetMargins(0f, 0f, 10f, 0f);    
        //�ļ���
        PdfWriter pdfWritey = PdfWriter.GetInstance(doc, stream);
        pdfWritey.CloseStream = false;
        doc.Open();
    
        //��������
        Paragraph title;
        title = new Paragraph(spn.Rows[0]["BillID"].ToString() + " " + spn.Rows[0]["_Name"].ToString(), FontSmall);
        title.IndentationLeft = 30;
        doc.Add(title);
        fname = spn.Rows[0]["BillID"].ToString() + " " + spn.Rows[0]["_Name"].ToString();
        string cname = spn.Rows[0]["BrandName"].ToString() == "�ܲ�" ? "����ʢ�ƺ�Ѷ�Ƽ����޹�˾" : spn.Rows[0]["BrandName"].ToString();
        title = new Paragraph(cname, FontBig);
        title.Alignment=Element.ALIGN_CENTER;
        doc.Add(title);
        title = new Paragraph("���۵�", FontBig);
        title.Alignment = Element.ALIGN_CENTER;
       Paragraph t2=  new Paragraph("  ", FontBig);
        doc.Add(title);
        doc.Add(t2);
        //����
        PdfPTable table = new PdfPTable(4) { WidthPercentage = 90 };//����������ȷ�����������
        
        PdfPCell[] cellBody = new PdfPCell[4];
        int[] ws=new[]{13,47,13,27};
        table.SetWidths(ws);
        cellBody[0] = new PdfPCell(new Phrase("��(�׷�)��", FontNorm))
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

        cellBody[2] = new PdfPCell(new Phrase("��ͬ���", FontNorm))
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
        cellBody[0] = new PdfPCell(new Phrase("����(�ҷ�)��", FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_LEFT
        };
        //"����ʢ�ƺ�Ѷ�Ƽ����޹�˾"
        cellBody[1] = new PdfPCell(new Phrase(cname, FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_LEFT
        };

        cellBody[2] = new PdfPCell(new Phrase("ǩ���ص�", FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_RIGHT
        };
        cellBody[3] = new PdfPCell(new Phrase("����", FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_LEFT
        };
         rowBody = new PdfPRow(cellBody);
         table.Rows.Add(rowBody);
         doc.Add(table);
        //����
         string t1 = "  ���ݡ��л����񹲺͹���ͬ�������й���ط��棬��˫�����Э�̣��ض�������ͬ����ͬ���ء�";
         string t11 = "  ��һ�� ��Ʒ����������۸񡢱�ע��";
         doc.Add(new Paragraph(t1, FontNorm) { IndentationLeft=30});
         doc.Add(new Paragraph(t11, FontNorm) { IndentationLeft =30 });
         doc.Add(new Paragraph(" ", FontNorm));
        //��Ʒ��ϸ
         PdfPTable detail_table = new PdfPTable(10) { WidthPercentage = 90 };//����������ȷ�����������       
         int[] ws2 = new[] { 5, 13, 13,12,7,7,8,10,8,12 };
         detail_table.SetWidths(ws2);
         PdfPCell[] detail_cell = new PdfPCell[10];
         detail_cell[0] = new PdfPCell(new Phrase("���", FontNorm))
         {
             BorderWidth = 1,
             MinimumHeight = Utilities.MillimetersToPoints(6),
             BorderColor = BaseColor.BLACK,
             HorizontalAlignment = Element.ALIGN_CENTER,
             VerticalAlignment = Element.ALIGN_MIDDLE
         };
         detail_cell[1] = new PdfPCell(new Phrase("������", FontNorm))
         {
             BorderWidth = 1,
             MinimumHeight = Utilities.MillimetersToPoints(6),
             BorderColor = BaseColor.BLACK,
             HorizontalAlignment = Element.ALIGN_CENTER,
                 VerticalAlignment = Element.ALIGN_MIDDLE
         };
         detail_cell[2] = new PdfPCell(new Phrase("�ͺ�", FontNorm))
         {
             BorderWidth = 1,
             MinimumHeight = Utilities.MillimetersToPoints(6),
             BorderColor = BaseColor.BLACK,
             HorizontalAlignment = Element.ALIGN_CENTER,
             VerticalAlignment = Element.ALIGN_MIDDLE
         };
         detail_cell[3] = new PdfPCell(new Phrase("����", FontNorm))
         {
             BorderWidth = 1,
             MinimumHeight = Utilities.MillimetersToPoints(6),
             BorderColor = BaseColor.BLACK,
             HorizontalAlignment = Element.ALIGN_CENTER,
             VerticalAlignment = Element.ALIGN_MIDDLE
         };
         detail_cell[4] = new PdfPCell(new Phrase("Ʒ��", FontNorm))
         {
             BorderWidth = 1,
             MinimumHeight = Utilities.MillimetersToPoints(6),
             BorderColor = BaseColor.BLACK,
             HorizontalAlignment = Element.ALIGN_CENTER,
             VerticalAlignment = Element.ALIGN_MIDDLE
         };
         detail_cell[5] = new PdfPCell(new Phrase("����", FontNorm))
         {
             BorderWidth = 1,
             MinimumHeight = Utilities.MillimetersToPoints(6),
             BorderColor = BaseColor.BLACK,
             HorizontalAlignment = Element.ALIGN_CENTER,
             VerticalAlignment = Element.ALIGN_MIDDLE
         };
         detail_cell[6] = new PdfPCell(new Phrase("����", FontNorm))
         {
             BorderWidth = 1,
             MinimumHeight = Utilities.MillimetersToPoints(6),
             BorderColor = BaseColor.BLACK,
             HorizontalAlignment = Element.ALIGN_CENTER,
             VerticalAlignment = Element.ALIGN_MIDDLE
         };
         detail_cell[7] = new PdfPCell(new Phrase("С��", FontNorm))
         {
             BorderWidth = 1,
             MinimumHeight = Utilities.MillimetersToPoints(6),
             BorderColor = BaseColor.BLACK,
             HorizontalAlignment = Element.ALIGN_CENTER,
             VerticalAlignment = Element.ALIGN_MIDDLE
         };
         detail_cell[8] = new PdfPCell(new Phrase("����", FontNorm))
         {
             BorderWidth = 1,
             MinimumHeight = Utilities.MillimetersToPoints(6),
             BorderColor = BaseColor.BLACK,
             HorizontalAlignment = Element.ALIGN_CENTER,
             VerticalAlignment = Element.ALIGN_MIDDLE
         };
         detail_cell[9] = new PdfPCell(new Phrase("��ע", FontNorm))
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
             //�ϼ�
             detail_cell = new PdfPCell[10];
             detail_cell[0] = new PdfPCell(new Phrase("�ܼ�", FontNorm)) { Colspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
             detail_cell[2] = new PdfPCell(new Phrase("����д����" + UpperRMB.CmycurD(OrderPrice.ToString()), FontNorm)) { Colspan = 4, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
             detail_cell[6] = new PdfPCell(new Phrase("��Сд����" + OrderPrice.ToString(), FontNorm)) { Colspan = 4, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
             drowBody = new PdfPRow(detail_cell);
             detail_table.Rows.Add(drowBody);
             doc.Add(detail_table);
         }
         else {
             for (int i = 0; i < spd.Rows.Count; i++)
             {
                 OrderPrice += Convert.ToDecimal(spd.Rows[i]["Total"]);
             }

             PdfPTable table2 = new PdfPTable(4) { WidthPercentage = 90 };//����������ȷ�����������       
             int[] tab2w = new[] { 10,35,30,25};
             table2.SetWidths(tab2w);
             PdfPRow row2 ;
             PdfPCell[] dcell2 = new PdfPCell[4];
             dcell2[0] = new PdfPCell(new Phrase("���", FontNorm));
             dcell2[1] = new PdfPCell(new Phrase("��Ʒ�ͺ�", FontNorm));
             dcell2[2] = new PdfPCell(new Phrase("�ܺϼ�", FontNorm));
             dcell2[3] = new PdfPCell(new Phrase("������", FontNorm));
             row2 = new PdfPRow(dcell2);
             table2.Rows.Add(row2);

             dcell2 = new PdfPCell[4];
             dcell2[0] = new PdfPCell(new Phrase("1", FontNorm));
             dcell2[1] = new PdfPCell(new Phrase("��ϸ����ͬ����\"�����嵥\"", FontNorm));
             dcell2[2] = new PdfPCell(new Phrase(OrderPrice.ToString(".00"), FontNorm));
             dcell2[3] = new PdfPCell(new Phrase("2~3��", FontNorm));
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
             //title = new Paragraph("��ϸ�б����ҳ", FontTitle);
             //title.IndentationLeft = 30;
             //doc.Add(title);
             //doc.Add(new Paragraph(" ", FontNorm));
         }
        string t3 = @"�ڶ��� ������׼�����ұ�׼��        
������ �����˶�������֤�����������ޣ����嵥��            
������ ��װ��׼����װ��Ĺ�Ӧ����գ��ޡ�    
������ ������ı�׼�����㷽�����ޡ�                
������ ���������Ȩ�������˸���ʱʱת�ƣ�������δ������֧���ۿ�����ģ���������ڳ����˵�λ���С� 
������ �����ᣩ��ʱ�䣺Ԥ�Ʒ������� , �����Զ�����ʺ�ʼ���㡣 
�ڰ��� ���䷽ʽ���ͻ���ַ��         
�ջ���ַ��{0}                               
�ջ��ˣ�{1} �绰��{2}��        
�ھ��� �����׼���������ص㼰���ޣ������ұ�׼��          
��ʮ�� ���㷽ʽ��ʱ�估�ص㣺��                             
��ʮһ�� ��Ʊ���ͣ�{3}��              
��ʮ���� ������Ϣ��     
{4}
��ʮ���� ����ͬ������������ʱ�������            
��ʮ���� ΥԼ���Σ�������   
��ʮ���� ��ͬ����Ľ����ʽ�����ط�Ժ�ٲá�     
��ʮ���� ����ͬһʽ���ݣ�˫����ִҼ�ݣ���˫��ǩ�ָ���֮������Ч���������ԭ������ͬ�ȷ���Ч����";
        string payinfo = "";
        DataTable dt_branch;//������Ϣ
        string lm_phone = "";
        string lm_fax = "";
        string lm_mail = "";

        string sell_phone1 = "";
        string sell_phone2 = "";
        string sell_fax = "";
        string sell_mail = "";
        string sell_adr = "";
        if (spn.Rows[0]["BrandName"].ToString() == "�ܲ�")
        {
            payinfo = "������:�й��������йɷ����޹�˾�����ϵ�֧�� �˺�: 0110014170025222 �����ߣ�����ʢ�ƺ�Ѹ�Ƽ����޹�˾  ";

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
        //spn.Rows[0]["Operator"].ToString()  ����Ա��Ϣ
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
        if(spn.Rows[0]["BrandTaxRateType"].ToString()=="��" || Convert.ToDecimal(spn.Rows[0]["BrandTaxRate"])==0 )
        {
            ratioType = "����˰";
        }else{
            ratioType = spn.Rows[0]["BrandTaxRateType"].ToString() + "��" + Math.Round(Convert.ToDecimal(spn.Rows[0]["BrandTaxRate"]) * 100, 0).ToString() + "%";
        }
            Chunk beginning = new Chunk(string.Format(t3, spn.Rows[0]["Adr"].ToString(), spn.Rows[0]["LinkMan"].ToString(), spn.Rows[0]["Tel"].ToString(), ratioType, payinfo,""), FontNorm);
        Phrase p1 = new Phrase(beginning);
        Paragraph p = new Paragraph();
        p.Add(p1);
        p.IndentationLeft = 30;
      doc.Add(p);
      doc.Add(t2);//�հ���
        //������ϵ

      PdfPTable tb_cat = new PdfPTable(4);//����������ȷ�����������   WidthPercentage = 90
      PdfPCell[] cell_cat = new PdfPCell[4];
      PdfPRow row_cat;
      int[] ws_cat = new[] { 15, 35, 15, 35 };
      tb_cat.SetWidths(ws_cat);
       cell_cat[0] = new PdfPCell(new Phrase("�򷽵�λ����", FontNorm));
      cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["_Name"].ToString(), FontNorm));
      cell_cat[2] = new PdfPCell(new Phrase("������λ����", FontNorm));
      cell_cat[3] = new PdfPCell(new Phrase(cname, FontNorm));
      row_cat = new PdfPRow(cell_cat);
      tb_cat.Rows.Add(row_cat);

      cell_cat = new PdfPCell[4];
      cell_cat[0] = new PdfPCell(new Phrase("��λ��ַ", FontNorm));
      cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["Adr"].ToString(), FontNorm));
      cell_cat[2] = new PdfPCell(new Phrase("��λ��ַ", FontNorm));
      cell_cat[3] = new PdfPCell(new Phrase(sell_adr, FontNorm));
      row_cat = new PdfPRow(cell_cat);
      tb_cat.Rows.Add(row_cat);

      cell_cat = new PdfPCell[4];
      cell_cat[0] = new PdfPCell(new Phrase("����������", FontNorm));
      cell_cat[1] = new PdfPCell(new Phrase("", FontNorm));
      cell_cat[2] = new PdfPCell(new Phrase("����������", FontNorm));
      cell_cat[3] = new PdfPCell(new Phrase("³����", FontNorm));
      row_cat = new PdfPRow(cell_cat);
      tb_cat.Rows.Add(row_cat);

      cell_cat = new PdfPCell[4];
      cell_cat[0] = new PdfPCell(new Phrase("ί�д�����", FontNorm));
      cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["LinkMan"].ToString(), FontNorm));
      cell_cat[2] = new PdfPCell(new Phrase("ί�д�����", FontNorm));
      cell_cat[3] = new PdfPCell(new Phrase(spn.Rows[0]["Operator"].ToString(), FontNorm));
      row_cat = new PdfPRow(cell_cat);
      tb_cat.Rows.Add(row_cat);

      cell_cat = new PdfPCell[4];
      cell_cat[0] = new PdfPCell(new Phrase("��ϵ���ֻ�", FontNorm));
      cell_cat[1] = new PdfPCell(new Phrase(lm_phone, FontNorm));
      cell_cat[2] = new PdfPCell(new Phrase("��ϵ���ֻ�", FontNorm));
      cell_cat[3] = new PdfPCell(new Phrase(sell_phone2, FontNorm));
      row_cat = new PdfPRow(cell_cat);
      tb_cat.Rows.Add(row_cat);

      cell_cat = new PdfPCell[4];
      cell_cat[0] = new PdfPCell(new Phrase("�绰", FontNorm));
      cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["Tel"].ToString(), FontNorm));
      cell_cat[2] = new PdfPCell(new Phrase("�绰", FontNorm));
      cell_cat[3] = new PdfPCell(new Phrase(sell_phone1, FontNorm));
      row_cat = new PdfPRow(cell_cat);
      tb_cat.Rows.Add(row_cat);

      cell_cat = new PdfPCell[4];
      cell_cat[0] = new PdfPCell(new Phrase("����", FontNorm));
      cell_cat[1] = new PdfPCell(new Phrase(lm_fax, FontNorm));
      cell_cat[2] = new PdfPCell(new Phrase("����", FontNorm));
      cell_cat[3] = new PdfPCell(new Phrase(sell_fax, FontNorm));
      row_cat = new PdfPRow(cell_cat);
      tb_cat.Rows.Add(row_cat);

      cell_cat = new PdfPCell[4];
      cell_cat[0] = new PdfPCell(new Phrase("����", FontNorm));
      cell_cat[1] = new PdfPCell(new Phrase(lm_mail, FontNorm));
      cell_cat[2] = new PdfPCell(new Phrase("����", FontNorm));
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
  if (wdName.IndexOf("����") >=0)
  {
      img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "fc.jpg");
  }
  else if (wdName.IndexOf("������") >=0)
  {
      img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "mfy.jpg");
  }
  else if (wdName.IndexOf("ʢ��") >= 0)
  {
      img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "sthx.jpg");
  }
  else if (wdName.IndexOf("����") >= 0)
  {
      img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "bl.png");
  }
  else if (wdName.IndexOf("����") >= 0)
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
  //    //����5�ڵ�һҳ�̶�λ��
  //    img.SetAbsolutePosition(doc.PageSize.Width - 36f - 200f, 130f);
  //}
  //else {
  //    img.SetAbsolutePosition(doc.PageSize.Width - 36f - 200f, 20f);
  //}
  doc.Add(img);
  if (spd.Rows.Count > MaxCount)
  {
      doc.NewPage();
      title = new Paragraph("������ͬ", FontBig);
      title.Alignment = Element.ALIGN_CENTER;
      doc.Add(title);//�ڶ�ҳ����
      title = new Paragraph(" ", FontNorm);
      doc.Add(title);
      doc.Add(table);//�ڶ�ҳ��ͷ
      title = new Paragraph(" ", FontNorm);
      title.IndentationLeft = 30;
      doc.Add(title);

      PdfPTable table3 = new PdfPTable(8) { WidthPercentage = 90 };//����������ȷ�����������       
      int[] tab3w = new[] { 6,20, 20, 8,10,11,8,12 };
      table3.SetWidths(tab3w);
      PdfPRow row3;
      PdfPCell[] dcell3 = new PdfPCell[8];
      dcell3[0] = new PdfPCell(new Phrase("���", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
      dcell3[1] = new PdfPCell(new Phrase("��Ʒ����", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
      dcell3[2] = new PdfPCell(new Phrase("��Ʒ�ͺ�", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
      dcell3[3] = new PdfPCell(new Phrase("����", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
      dcell3[4] = new PdfPCell(new Phrase("����(Ԫ)", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
      dcell3[5] = new PdfPCell(new Phrase("���(Ԫ)", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
      dcell3[6] = new PdfPCell(new Phrase("����", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
      dcell3[7] = new PdfPCell(new Phrase("��ע", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
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
      //�ϼ�
      dcell3 = new PdfPCell[8];
      dcell3[0] = new PdfPCell(new Phrase("�ܼ�", FontNorm)) { Colspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
      dcell3[2] = new PdfPCell(new Phrase("����д����" + UpperRMB.CmycurD(OrderPrice.ToString()), FontNorm)) { Colspan = 3, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
      dcell3[5] = new PdfPCell(new Phrase("��Сд����" + OrderPrice.ToString(), FontNorm)) { Colspan = 3, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
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
    /// ��ͬ
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
        //ҳ���С
        Document doc = new Document(PageSize.A4);
        doc.SetMargins(0f, 0f, 5f, 0f);
        //�ļ���
        PdfWriter pdfWritey = PdfWriter.GetInstance(doc, stream);
        pdfWritey.CloseStream = false;
        doc.Open();
        //��������
        Paragraph title;
        title = new Paragraph(spn.Rows[0]["BillID"].ToString() + " " + spn.Rows[0]["_Name"].ToString(), FontSmall);
        title.IndentationLeft = 30;
        doc.Add(title);
        fname = spn.Rows[0]["BillID"].ToString() + " " + spn.Rows[0]["_Name"].ToString();
        string cname = spn.Rows[0]["BrandName"].ToString() == "�ܲ�" ? "����ʢ�ƺ�Ѷ�Ƽ����޹�˾" : spn.Rows[0]["BrandName"].ToString();
        title = new Paragraph(cname, FontBig);
        title.Alignment = Element.ALIGN_CENTER;
        doc.Add(title);
        title = new Paragraph("���ۺ�ͬ", FontBig);
        title.Alignment = Element.ALIGN_CENTER;
        Paragraph t2 = new Paragraph("  ", FontSmall);
        doc.Add(title);
        doc.Add(t2);
        //����
        PdfPTable table = new PdfPTable(4) { WidthPercentage = 90 };//����������ȷ�����������

        PdfPCell[] cellBody = new PdfPCell[4];
        int[] ws = new[] { 13, 47, 13, 27 };
        table.SetWidths(ws);
        cellBody[0] = new PdfPCell(new Phrase("��(�׷�)", FontNorm))
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

        cellBody[2] = new PdfPCell(new Phrase("��ͬ���", FontNorm))
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
        cellBody[0] = new PdfPCell(new Phrase("����(�ҷ�)��", FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_LEFT
        };
        //"����ʢ�ƺ�Ѷ�Ƽ����޹�˾"
        cellBody[1] = new PdfPCell(new Phrase(cname, FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_LEFT
        };

        cellBody[2] = new PdfPCell(new Phrase("ǩ���ص�", FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_RIGHT
        };
        cellBody[3] = new PdfPCell(new Phrase("����", FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_LEFT
        };
        rowBody = new PdfPRow(cellBody);
        table.Rows.Add(rowBody);
        doc.Add(table);
        //����
        string t1 = "  ���ݡ��л����񹲺͹���ͬ�������й���ط��棬��˫�����Э�̣��ض�������ͬ����ͬ���ء�";
        string t11 = "  ��һ�� ��Ʒ����������۸񡢱�ע��";
        doc.Add(new Paragraph(t1, FontNorm) { IndentationLeft = 30 });
        doc.Add(new Paragraph(t11, FontNorm) { IndentationLeft = 30 });
        doc.Add(new Paragraph(" ", FontNorm));
        //��Ʒ��ϸ
        PdfPTable detail_table = new PdfPTable(10) { WidthPercentage=90};//����������ȷ�����������       
        int[] ws2 = new[] { 5, 13, 13, 12, 7, 7, 8, 10,8, 12 };
        detail_table.SetWidths(ws2);
        PdfPCell[] detail_cell = new PdfPCell[10];
        detail_cell[0] = new PdfPCell(new Phrase("���", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[1] = new PdfPCell(new Phrase("������", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[2] = new PdfPCell(new Phrase("�ͺ�", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[3] = new PdfPCell(new Phrase("����", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[4] = new PdfPCell(new Phrase("Ʒ��", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[5] = new PdfPCell(new Phrase("����", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[6] = new PdfPCell(new Phrase("����", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[7] = new PdfPCell(new Phrase("С��", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[8] = new PdfPCell(new Phrase("����", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[9] = new PdfPCell(new Phrase("��ע", FontNorm))
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
            //�ϼ�
            detail_cell = new PdfPCell[10];
            detail_cell[0] = new PdfPCell(new Phrase("�ܼ�", FontNorm)) { Colspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            detail_cell[2] = new PdfPCell(new Phrase("����д����" + UpperRMB.CmycurD(OrderPrice.ToString()), FontNorm)) { Colspan = 4, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            detail_cell[6] = new PdfPCell(new Phrase("��Сд����" + OrderPrice.ToString(), FontNorm)) { Colspan = 4, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            drowBody = new PdfPRow(detail_cell);
            detail_table.Rows.Add(drowBody);
            doc.Add(detail_table);
        }
        else {
            for (int i = 0; i < spd.Rows.Count; i++)
            {
                OrderPrice += Convert.ToDecimal(spd.Rows[i]["Total"]);
            }

            PdfPTable table2 = new PdfPTable(4) { WidthPercentage = 90 };//����������ȷ�����������       
            int[] tab2w = new[] { 10, 35, 30, 25 };
            table2.SetWidths(tab2w);
            PdfPRow row2;
            PdfPCell[] dcell2 = new PdfPCell[4];
            dcell2[0] = new PdfPCell(new Phrase("���", FontNorm));
            dcell2[1] = new PdfPCell(new Phrase("��Ʒ�ͺ�", FontNorm));
            dcell2[2] = new PdfPCell(new Phrase("�ܺϼ�", FontNorm));
            dcell2[3] = new PdfPCell(new Phrase("������", FontNorm));
            row2 = new PdfPRow(dcell2);
            table2.Rows.Add(row2);

            dcell2 = new PdfPCell[4];
            dcell2[0] = new PdfPCell(new Phrase("1", FontNorm));
            dcell2[1] = new PdfPCell(new Phrase("��ϸ����ͬ����\"�����嵥\"", FontNorm));
            dcell2[2] = new PdfPCell(new Phrase(OrderPrice.ToString(".00"), FontNorm));
            dcell2[3] = new PdfPCell(new Phrase("2~3��", FontNorm));
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
        string t3 = @"�ڶ��� ������׼�����ұ�׼��        
������ �����˶�������֤�����������ޣ����嵥��            
������ ��װ��׼����װ��Ĺ�Ӧ����գ��ޡ�    
������ ������ı�׼�����㷽�����ޡ�                
������ ���������Ȩ�������˸���ʱʱת�ƣ�������δ������֧���ۿ�����ģ���������ڳ����˵�λ���С� 
������ �����ᣩ��ʱ�䣺Ԥ�Ʒ������� , �����Զ�����ʺ�ʼ���㡣 
�ڰ��� ���䷽ʽ���ͻ���ַ��                   
�ջ���ַ��{0}            
�ջ��ˣ�{1} �绰��{2}��        
�ھ��� �����׼���������ص㼰���ޣ������ұ�׼��          
��ʮ�� ���㷽ʽ��ʱ�估�ص㣺��                             
��ʮһ�� ��Ʊ���ͣ�{3}��              
��ʮ���� ������Ϣ��     
{4}
��ʮ���� ����ͬ������������ʱ�������            
��ʮ���� ΥԼ���Σ�������   
��ʮ���� ��ͬ����Ľ����ʽ�����ط�Ժ�ٲá�     
��ʮ���� ����ͬһʽ���ݣ�˫����ִҼ�ݣ���˫��ǩ�ָ���֮������Ч���������ԭ������ͬ�ȷ���Ч����";
        string payinfo = "";
        DataTable dt_branch;//������Ϣ
        string lm_phone = "";
        string lm_fax = "";
        string lm_mail = "";

        string sell_phone1 = "";
        string sell_phone2 = "";
        string sell_fax = "";
        string sell_mail = "";
        string sell_adr = "";
        if (spn.Rows[0]["BrandName"].ToString() == "�ܲ�")
        {
            payinfo = "������:�й��������йɷ����޹�˾�����ϵ�֧�� �˺�: 0110014170025222 �����ߣ�����ʢ�ƺ�Ѹ�Ƽ����޹�˾  ";

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
        //spn.Rows[0]["Operator"].ToString()  ����Ա��Ϣ
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
        if (spn.Rows[0]["BrandTaxRateType"].ToString() == "��" || Convert.ToDecimal(spn.Rows[0]["BrandTaxRate"]) == 0)
        {
            ratioType = "����˰";
        }
        else
        {
            ratioType = spn.Rows[0]["BrandTaxRateType"].ToString() + "��" + Math.Round(Convert.ToDecimal(spn.Rows[0]["BrandTaxRate"]) * 100, 0).ToString() + "%";
        }
        Chunk beginning = new Chunk(string.Format(t3, spn.Rows[0]["Adr"].ToString(), spn.Rows[0]["LinkMan"].ToString(), spn.Rows[0]["Tel"].ToString(), ratioType, payinfo,""), FontNorm);
        Phrase p1 = new Phrase(beginning);
        Paragraph p = new Paragraph();
        p.Add(p1);
        p.IndentationLeft = 30;
        doc.Add(p);
        doc.Add(t2);//�հ���
        //������ϵ
        PdfPTable tb_cat = new PdfPTable(4);//����������ȷ�����������
        PdfPCell[] cell_cat = new PdfPCell[4];
        PdfPRow row_cat;
        int[] ws_cat = new[] { 15, 35, 15, 35 };
        tb_cat.SetWidths(ws_cat);
        //spn spd
        cell_cat[0] = new PdfPCell(new Phrase("�򷽵�λ����", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["_Name"].ToString(), FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("������λ����", FontNorm));
        cell_cat[3] = new PdfPCell(new Phrase(cname, FontNorm));
        row_cat = new PdfPRow(cell_cat);
        tb_cat.Rows.Add(row_cat);

        cell_cat = new PdfPCell[4];
        cell_cat[0] = new PdfPCell(new Phrase("��λ��ַ", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["Adr"].ToString(), FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("��λ��ַ", FontNorm));
        cell_cat[3] = new PdfPCell(new Phrase(sell_adr, FontNorm));
        row_cat = new PdfPRow(cell_cat);
        tb_cat.Rows.Add(row_cat);

        cell_cat = new PdfPCell[4];
        cell_cat[0] = new PdfPCell(new Phrase("����������", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase("", FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("����������", FontNorm));
        cell_cat[3] = new PdfPCell(new Phrase("³����", FontNorm));
        row_cat = new PdfPRow(cell_cat);
        tb_cat.Rows.Add(row_cat);

        cell_cat = new PdfPCell[4];
        cell_cat[0] = new PdfPCell(new Phrase("ί�д�����", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["LinkMan"].ToString(), FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("ί�д�����", FontNorm));
        cell_cat[3] = new PdfPCell(new Phrase(spn.Rows[0]["Operator"].ToString(), FontNorm));
        row_cat = new PdfPRow(cell_cat);
        tb_cat.Rows.Add(row_cat);

        cell_cat = new PdfPCell[4];
        cell_cat[0] = new PdfPCell(new Phrase("��ϵ���ֻ�", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase(lm_phone, FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("��ϵ���ֻ�", FontNorm));
        cell_cat[3] = new PdfPCell(new Phrase(sell_phone2, FontNorm));
        row_cat = new PdfPRow(cell_cat);
        tb_cat.Rows.Add(row_cat);

        cell_cat = new PdfPCell[4];
        cell_cat[0] = new PdfPCell(new Phrase("�绰", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["Tel"].ToString(), FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("�绰", FontNorm));
        cell_cat[3] = new PdfPCell(new Phrase(sell_phone1, FontNorm));
        row_cat = new PdfPRow(cell_cat);
        tb_cat.Rows.Add(row_cat);

        cell_cat = new PdfPCell[4];
        cell_cat[0] = new PdfPCell(new Phrase("����", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase(lm_fax, FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("����", FontNorm));
        cell_cat[3] = new PdfPCell(new Phrase(sell_fax, FontNorm));
        row_cat = new PdfPRow(cell_cat);
        tb_cat.Rows.Add(row_cat);

        cell_cat = new PdfPCell[4];
        cell_cat[0] = new PdfPCell(new Phrase("����", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase(lm_mail, FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("����", FontNorm));
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
        if (wdName.IndexOf("����") >=0)
        {
            img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "fcht.jpg");
        }
        else if (wdName.IndexOf("������") >=0)
        {
            img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "mfyht.jpg");
        }
        else if (wdName.IndexOf("ʢ��") >= 0)
        {
            img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "sthxht.gif");
        }
        else if (wdName.IndexOf("����") >= 0)
        {
            img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "blht.png");
        }
        else if (wdName.IndexOf("����") >= 0)
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
            title = new Paragraph("������ͬ", FontBig);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);//�ڶ�ҳ����
            title = new Paragraph(" ", FontSmall);
            doc.Add(title);
            doc.Add(table);//�ڶ�ҳ��ͷ
            title = new Paragraph(" ", FontSmall);
            title.IndentationLeft = 30;
            doc.Add(title);

            PdfPTable table3 = new PdfPTable(8) { WidthPercentage = 90 };//����������ȷ�����������       
            int[] tab3w = new[] { 6, 20, 20, 8, 10, 11, 8,12 };
            table3.SetWidths(tab3w);
            PdfPRow row3;
            PdfPCell[] dcell3 = new PdfPCell[8];
            dcell3[0] = new PdfPCell(new Phrase("���", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[1] = new PdfPCell(new Phrase("��Ʒ����", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[2] = new PdfPCell(new Phrase("��Ʒ�ͺ�", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[3] = new PdfPCell(new Phrase("����", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[4] = new PdfPCell(new Phrase("����(Ԫ)", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[5] = new PdfPCell(new Phrase("���(Ԫ)", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[6] = new PdfPCell(new Phrase("����", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
         
            dcell3[7] = new PdfPCell(new Phrase("��ע", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
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
            //�ϼ�
            dcell3 = new PdfPCell[8];
            dcell3[0] = new PdfPCell(new Phrase("�ܼ�", FontNorm)) { Colspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[2] = new PdfPCell(new Phrase("����д����" + UpperRMB.CmycurD(OrderPrice.ToString()), FontNorm)) { Colspan = 3, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[5] = new PdfPCell(new Phrase("��Сд����" + OrderPrice.ToString(), FontNorm)) { Colspan = 3, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
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
        //ҳ���С
        Document doc = new Document(PageSize.A4);
        doc.SetMargins(0f, 0f, 10f, 0f);
        //�ļ���
        PdfWriter pdfWritey = PdfWriter.GetInstance(doc, stream);
        pdfWritey.CloseStream = false;
        doc.Open();

        //��������
        Paragraph title;
        title = new Paragraph(spn.Rows[0]["BillID"].ToString() + " " + spn.Rows[0]["_Name"].ToString(), FontSmall);
        title.IndentationLeft = 30;
        doc.Add(title);
        fname = spn.Rows[0]["BillID"].ToString() + " " + spn.Rows[0]["_Name"].ToString();
        string cname = spn.Rows[0]["BrandName"].ToString() == "�ܲ�" ? "����ʢ�ƺ�Ѷ�Ƽ����޹�˾" : spn.Rows[0]["BrandName"].ToString();
        title = new Paragraph(cname, FontBig);
        title.Alignment = Element.ALIGN_CENTER;
        doc.Add(title);
        title = new Paragraph("���ۺ�ͬ", FontBig);
        title.Alignment = Element.ALIGN_CENTER;
        Paragraph t2 = new Paragraph("  ", FontBig);
        doc.Add(title);
        doc.Add(t2);
        //����
        PdfPTable table = new PdfPTable(4) { WidthPercentage = 90 };//����������ȷ�����������

        PdfPCell[] cellBody = new PdfPCell[4];
        int[] ws = new[] { 13, 47, 13, 27 };
        table.SetWidths(ws);
        cellBody[0] = new PdfPCell(new Phrase("��(�׷�)��", FontNorm))
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

        cellBody[2] = new PdfPCell(new Phrase("��ͬ���", FontNorm))
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
        cellBody[0] = new PdfPCell(new Phrase("����(�ҷ�)��", FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_LEFT
        };
        //"����ʢ�ƺ�Ѷ�Ƽ����޹�˾"
        cellBody[1] = new PdfPCell(new Phrase(cname, FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_LEFT
        };

        cellBody[2] = new PdfPCell(new Phrase("ǩ���ص�", FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_RIGHT
        };
        cellBody[3] = new PdfPCell(new Phrase("����", FontNorm))
        {
            BorderWidth = 0,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.WHITE,
            HorizontalAlignment = Element.ALIGN_LEFT
        };
        rowBody = new PdfPRow(cellBody);
        table.Rows.Add(rowBody);
        doc.Add(table);
        //����
        string t1 = "  ���ݡ��л����񹲺͹���ͬ�������й���ط��棬��˫�����Э�̣��ض�������ͬ����ͬ���ء�";
        string t11 = "  ��һ�� ��Ʒ����������۸񡢱�ע��";
        doc.Add(new Paragraph(t1, FontNorm) { IndentationLeft = 30 });
        doc.Add(new Paragraph(t11, FontNorm) { IndentationLeft = 30 });
        doc.Add(new Paragraph(" ", FontNorm));
        //��Ʒ��ϸ
        PdfPTable detail_table = new PdfPTable(10) { WidthPercentage = 90 };//����������ȷ�����������       
        int[] ws2 = new[] { 5, 13, 13, 12, 7, 7, 8, 10,8, 12 };
        detail_table.SetWidths(ws2);
        PdfPCell[] detail_cell = new PdfPCell[10];
        detail_cell[0] = new PdfPCell(new Phrase("���", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[1] = new PdfPCell(new Phrase("������", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[2] = new PdfPCell(new Phrase("�ͺ�", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[3] = new PdfPCell(new Phrase("����", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[4] = new PdfPCell(new Phrase("Ʒ��", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[5] = new PdfPCell(new Phrase("����", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[6] = new PdfPCell(new Phrase("����", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[7] = new PdfPCell(new Phrase("С��", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[8] = new PdfPCell(new Phrase("����", FontNorm))
        {
            BorderWidth = 1,
            MinimumHeight = Utilities.MillimetersToPoints(6),
            BorderColor = BaseColor.BLACK,
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE
        };
        detail_cell[9] = new PdfPCell(new Phrase("��ע", FontNorm))
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
            //�ϼ�
            detail_cell = new PdfPCell[10];
            detail_cell[0] = new PdfPCell(new Phrase("�ܼ�", FontNorm)) { Colspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            detail_cell[2] = new PdfPCell(new Phrase("����д����" + UpperRMB.CmycurD(OrderPrice.ToString()), FontNorm)) { Colspan = 4, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            detail_cell[6] = new PdfPCell(new Phrase("��Сд����" + OrderPrice.ToString(), FontNorm)) { Colspan = 4, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
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

            PdfPTable table2 = new PdfPTable(4) { WidthPercentage = 90 };//����������ȷ�����������       
            int[] tab2w = new[] { 10, 35, 30, 25 };
            table2.SetWidths(tab2w);
            PdfPRow row2;
            PdfPCell[] dcell2 = new PdfPCell[4];
            dcell2[0] = new PdfPCell(new Phrase("���", FontNorm));
            dcell2[1] = new PdfPCell(new Phrase("��Ʒ�ͺ�", FontNorm));
            dcell2[2] = new PdfPCell(new Phrase("�ܺϼ�", FontNorm));
            dcell2[3] = new PdfPCell(new Phrase("������", FontNorm));
            row2 = new PdfPRow(dcell2);
            table2.Rows.Add(row2);

            dcell2 = new PdfPCell[4];
            dcell2[0] = new PdfPCell(new Phrase("1", FontNorm));
            dcell2[1] = new PdfPCell(new Phrase("��ϸ����ͬ����\"�����嵥\"", FontNorm));
            dcell2[2] = new PdfPCell(new Phrase(OrderPrice.ToString(".00"), FontNorm));
            dcell2[3] = new PdfPCell(new Phrase("2~3��", FontNorm));
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
            //title = new Paragraph("��ϸ�б����ҳ", FontTitle);
            //title.IndentationLeft = 30;
            //doc.Add(title);
            //doc.Add(new Paragraph(" ", FontNorm));
        }
        string t3 = @"�ڶ��� ������׼�����ұ�׼��        
������ �����˶�������֤�����������ޣ����嵥��            
������ ��װ��׼����װ��Ĺ�Ӧ����գ��ޡ�    
������ ������ı�׼�����㷽�����ޡ�                
������ ���������Ȩ�������˸���ʱʱת�ƣ�������δ������֧���ۿ�����ģ���������ڳ����˵�λ���С� 
������ �����ᣩ��ʱ�䣺Ԥ�Ʒ������� , �����Զ�����ʺ�ʼ���㡣 
�ڰ��� ���䷽ʽ���ͻ���ַ��         
�ջ���ַ��{0}                               
�ջ��ˣ�{1} �绰��{2}��        
�ھ��� �����׼���������ص㼰���ޣ������ұ�׼��          
��ʮ�� ���㷽ʽ��ʱ�估�ص㣺��                             
��ʮһ�� ��Ʊ���ͣ�{3}��              
��ʮ���� ������Ϣ��     
{4}
��ʮ���� ����ͬ������������ʱ�������            
��ʮ���� ΥԼ���Σ�������   
��ʮ���� ��ͬ����Ľ����ʽ�����ط�Ժ�ٲá�     
��ʮ���� ����ͬһʽ���ݣ�˫����ִҼ�ݣ���˫��ǩ�ָ���֮������Ч���������ԭ������ͬ�ȷ���Ч����";
        string payinfo = "";
        DataTable dt_branch;//������Ϣ
        string lm_phone = "";
        string lm_fax = "";
        string lm_mail = "";

        string sell_phone1 = "";
        string sell_phone2 = "";
        string sell_fax = "";
        string sell_mail = "";
        string sell_adr = "";
        if (spn.Rows[0]["BrandName"].ToString() == "�ܲ�")
        {
            payinfo = "������:�й��������йɷ����޹�˾�����ϵ�֧�� �˺�: 0110014170025222 �����ߣ�����ʢ�ƺ�Ѹ�Ƽ����޹�˾  ";

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
        //spn.Rows[0]["Operator"].ToString()  ����Ա��Ϣ
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
        if (spn.Rows[0]["BrandTaxRateType"].ToString() == "��" || Convert.ToDecimal(spn.Rows[0]["BrandTaxRate"]) == 0)
        {
            ratioType = "����˰";
        }
        else
        {
            ratioType = spn.Rows[0]["BrandTaxRateType"].ToString() + "��" + Math.Round(Convert.ToDecimal(spn.Rows[0]["BrandTaxRate"]) * 100, 0).ToString() + "%";
        }
        Chunk beginning = new Chunk(string.Format(t3, spn.Rows[0]["Adr"].ToString(), spn.Rows[0]["LinkMan"].ToString(), spn.Rows[0]["Tel"].ToString(), ratioType, payinfo,""), FontNorm);
        Phrase p1 = new Phrase(beginning);
        Paragraph p = new Paragraph();
        p.Add(p1);
        p.IndentationLeft = 30;
        doc.Add(p);
        doc.Add(t2);//�հ���
        //������ϵ
        PdfPTable tb_cat = new PdfPTable(4) ;//����������ȷ�����������
        PdfPCell[] cell_cat = new PdfPCell[4];
        PdfPRow row_cat;
        int[] ws_cat = new[] { 15, 35, 15, 35 };
        tb_cat.SetWidths(ws_cat);
        //spn spd
        cell_cat[0] = new PdfPCell(new Phrase("�򷽵�λ����", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["_Name"].ToString(), FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("������λ����", FontNorm));
        cell_cat[3] = new PdfPCell(new Phrase(cname, FontNorm));
        row_cat = new PdfPRow(cell_cat);
        tb_cat.Rows.Add(row_cat);

        cell_cat = new PdfPCell[4];
        cell_cat[0] = new PdfPCell(new Phrase("��λ��ַ", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["Adr"].ToString(), FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("��λ��ַ", FontNorm));
        cell_cat[3] = new PdfPCell(new Phrase(sell_adr, FontNorm));
        row_cat = new PdfPRow(cell_cat);
        tb_cat.Rows.Add(row_cat);

        cell_cat = new PdfPCell[4];
        cell_cat[0] = new PdfPCell(new Phrase("����������", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase("", FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("����������", FontNorm));
        cell_cat[3] = new PdfPCell(new Phrase("³����", FontNorm));
        row_cat = new PdfPRow(cell_cat);
        tb_cat.Rows.Add(row_cat);

        cell_cat = new PdfPCell[4];
        cell_cat[0] = new PdfPCell(new Phrase("ί�д�����", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["LinkMan"].ToString(), FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("ί�д�����", FontNorm));
        cell_cat[3] = new PdfPCell(new Phrase(spn.Rows[0]["Operator"].ToString(), FontNorm));
        row_cat = new PdfPRow(cell_cat);
        tb_cat.Rows.Add(row_cat);

        cell_cat = new PdfPCell[4];
        cell_cat[0] = new PdfPCell(new Phrase("��ϵ���ֻ�", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase(lm_phone, FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("��ϵ���ֻ�", FontNorm));
        cell_cat[3] = new PdfPCell(new Phrase(sell_phone2, FontNorm));
        row_cat = new PdfPRow(cell_cat);
        tb_cat.Rows.Add(row_cat);

        cell_cat = new PdfPCell[4];
        cell_cat[0] = new PdfPCell(new Phrase("�绰", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["Tel"].ToString(), FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("�绰", FontNorm));
        cell_cat[3] = new PdfPCell(new Phrase(sell_phone1, FontNorm));
        row_cat = new PdfPRow(cell_cat);
        tb_cat.Rows.Add(row_cat);

        cell_cat = new PdfPCell[4];
        cell_cat[0] = new PdfPCell(new Phrase("����", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase(lm_fax, FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("����", FontNorm));
        cell_cat[3] = new PdfPCell(new Phrase(sell_fax, FontNorm));
        row_cat = new PdfPRow(cell_cat);
        tb_cat.Rows.Add(row_cat);

        cell_cat = new PdfPCell[4];
        cell_cat[0] = new PdfPCell(new Phrase("����", FontNorm));
        cell_cat[1] = new PdfPCell(new Phrase(lm_mail, FontNorm));
        cell_cat[2] = new PdfPCell(new Phrase("����", FontNorm));
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
        if (wdName.IndexOf("����") >= 0)
        {
            img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "fcht.jpg");
        }
        else if (wdName.IndexOf("������") >= 0)
        {
            img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "mfyht.jpg");
        }
        else if (wdName.IndexOf("ʢ��") >= 0)
        {
            img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "sthxht.gif");
        }
        else if (wdName.IndexOf("����") >= 0)
        {
            img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "blht.png");
        }
        else if (wdName.IndexOf("����") >= 0)
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
            title = new Paragraph("������ͬ", FontBig);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);//�ڶ�ҳ����
            title = new Paragraph(" ", FontNorm);
            doc.Add(title);
            doc.Add(table);//�ڶ�ҳ��ͷ
            title = new Paragraph(" ", FontNorm);
            title.IndentationLeft = 30;
            doc.Add(title);

            PdfPTable table3 = new PdfPTable(8) { WidthPercentage = 90 };//����������ȷ�����������       
            int[] tab3w = new[] { 6, 20, 20, 8, 10, 11, 8,12 };
            table3.SetWidths(tab3w);
            PdfPRow row3;
            PdfPCell[] dcell3 = new PdfPCell[8];
            dcell3[0] = new PdfPCell(new Phrase("���", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[1] = new PdfPCell(new Phrase("��Ʒ����", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[2] = new PdfPCell(new Phrase("��Ʒ�ͺ�", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[3] = new PdfPCell(new Phrase("����", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[4] = new PdfPCell(new Phrase("����(Ԫ)", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[5] = new PdfPCell(new Phrase("���(Ԫ)", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[6] = new PdfPCell(new Phrase("����", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
           
            dcell3[7] = new PdfPCell(new Phrase("��ע", FontNorm)) { HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
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
            //�ϼ�
            dcell3 = new PdfPCell[8];
            dcell3[0] = new PdfPCell(new Phrase("�ܼ�", FontNorm)) { Colspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[2] = new PdfPCell(new Phrase("����д����" + UpperRMB.CmycurD(OrderPrice.ToString()), FontNorm)) { Colspan = 3, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
            dcell3[5] = new PdfPCell(new Phrase("��Сд����" + OrderPrice.ToString(), FontNorm)) { Colspan = 3, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
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
    /// ά�޺�ͬ
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
        //ҳ���С
        Document doc = new Document(PageSize.A4);
        doc.SetMargins(0f, 0f, 10f, 0f);
        MemoryStream stream = new MemoryStream();
       
        PdfWriter pdfWritey = PdfWriter.GetInstance(doc, stream);
        pdfWritey.CloseStream = false;
        doc.Open();
        DataTable spn = new DataTable() ;
      
        //����
          iTextSharp.text.Font FontBig = new iTextSharp.text.Font(baseFont, 16f);
          iTextSharp.text.Font FontNorml = new iTextSharp.text.Font(baseFont, 10f);
          iTextSharp.text.Font FontSmall = new iTextSharp.text.Font(baseFont, 8f);
          iTextSharp.text.Font FontTitle = new iTextSharp.text.Font(baseFont, 12f, Font.BOLD);
          FontBig.IsBold();
          Paragraph title;
          if (ids.Count() <= 0)
          {
              title = new Paragraph("����IDΪ��", FontBig);
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
                                    title = new Paragraph("���󣺷���Ų�ƥ�䣬���ܺϲ���", FontBig);
                                    title.IndentationLeft = 30;
                                    doc.Add(title);
                                    doc.Close();
                                    return stream;
                                }
                            }
                            else
                            {
                                title = new Paragraph("����ID��Ч��", FontBig);
                                title.IndentationLeft = 30;
                                doc.Add(title);
                                doc.Close();
                                return stream;
                            }
                        }
                    }

                    #region main               

                    string cname = spn.Rows[0]["BranchName"].ToString() == "�ܲ�" || string.IsNullOrEmpty( spn.Rows[0]["BranchName"].ToString()) ? "����ʢ�ƺ�Ѷ�Ƽ����޹�˾" : spn.Rows[0]["BranchName"].ToString();
                    title = new Paragraph(cname, FontBig);
                    title.Alignment = Element.ALIGN_CENTER;
                    doc.Add(title);
                    title = new Paragraph("ά�޺�ͬ", FontBig);
                    title.Alignment = Element.ALIGN_CENTER;
                    Paragraph t2 = new Paragraph("  ", FontBig);
                    doc.Add(title);
                    doc.Add(t2);
        
                    //����
                    PdfPTable table = new PdfPTable(4) { WidthPercentage = 90 };//����������ȷ�����������

                    PdfPCell[] cellBody = new PdfPCell[4];
                    int[] ws = new[] { 12, 48, 12, 28 };
                    table.SetWidths(ws);
                    cellBody[0] = new PdfPCell(new Phrase("ά�޵��ţ�", FontNorml))
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
                    cellBody[2] = new PdfPCell(new Phrase("�������ڣ�", FontNorml))
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
                    cellBody[0] = new PdfPCell(new Phrase("�ͻ����ƣ�", FontNorml))
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
                    cellBody[2] = new PdfPCell(new Phrase("���۵�λ��", FontNorml))
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
                    cellBody[0] = new PdfPCell(new Phrase("��ϵ�ˣ�", FontNorml))
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

                    cellBody[2] = new PdfPCell(new Phrase("�����ˣ�", FontNorml))
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
                    //����
                    string t1 = "  �𾴵Ŀͻ���";
                    string t11 = "  ��л�����ҹ�˾��֧������������ݹ�˾������Ʒ��ص���Ϣ���ҹ�˾���������񱨼ۡ���ȷ�����·���ʽ���Ʒѽ���ͬ��ǩ�ֲ��Ӹǹ��»ش������ǡ�";
                    doc.Add(new Paragraph(t1, FontNorml) { IndentationLeft = 30 });
                    doc.Add(new Paragraph(t11, FontNorml) { IndentationLeft = 30,IndentationRight=30 });
                    doc.Add(new Paragraph(" ", FontNorml));
                    //��Ʒ��ϸ
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
                                    ser.xid = i + 1;//���
                                    ser.name = spn.Rows[0]["ProductClass"].ToString();//c��Ʒ����
                                    ser.model = spn.Rows[0]["ProductModel"].ToString(); //��Ʒ�ͺ�
                                    ser.unit = "";//tb_mate.Rows[i]["Unit"].ToString(); ��λ
                                    ser.qty = 1;//����
                                    ser.price = Convert.ToDecimal(tb_mate.Rows[i]["dAmount"]);
                                    ser.content = tb_mate.Rows[i]["_Name"].ToString();//ά�޷���
                                    ser.common = "";
                                    ser.zq = tb_mate.Rows[i]["Remark"].ToString(); ;//ά������
                                    fwbaojia.Add(ser);
                                    OrderPrice += ser.price * ser.qty;
                                }                        
                    }

                        PdfPTable detail_table = new PdfPTable(9) { WidthPercentage = 90 };//����������ȷ�����������       
                    int[] ws2 = new[] { 5, 15, 20, 0, 0, 11, 21, 9, 12 };
                    detail_table.SetWidths(ws2);
                    PdfPCell[] detail_cell = new PdfPCell[9];
                    detail_cell[0] = new PdfPCell(new Phrase("���", FontNorml))
                    {
                        BorderWidth = 1,
                        MinimumHeight = Utilities.MillimetersToPoints(6),
                        BorderColor = BaseColor.BLACK,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    };
                    detail_cell[1] = new PdfPCell(new Phrase("��Ʒ����", FontNorml))
                    {
                        BorderWidth = 1,
                        MinimumHeight = Utilities.MillimetersToPoints(6),
                        BorderColor = BaseColor.BLACK,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    };
                    detail_cell[2] = new PdfPCell(new Phrase("�ͺ�", FontNorml))
                    {
                        BorderWidth = 1,
                        MinimumHeight = Utilities.MillimetersToPoints(6),
                        BorderColor = BaseColor.BLACK,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    };
                    detail_cell[3] = new PdfPCell(new Phrase("��λ", FontNorml))
                    {
                        BorderWidth = 1,
                        MinimumHeight = Utilities.MillimetersToPoints(6),
                        BorderColor = BaseColor.BLACK,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    };
                    detail_cell[4] = new PdfPCell(new Phrase("����", FontNorml))
                    {
                        BorderWidth = 1,
                        MinimumHeight = Utilities.MillimetersToPoints(6),
                        BorderColor = BaseColor.BLACK,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    };
                    detail_cell[5] = new PdfPCell(new Phrase("����", FontNorml))
                    {
                        BorderWidth = 1,
                        MinimumHeight = Utilities.MillimetersToPoints(6),
                        BorderColor = BaseColor.BLACK,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    };
                    detail_cell[6] = new PdfPCell(new Phrase("ά�޷���", FontNorml))
                    {
                        BorderWidth = 1,
                        MinimumHeight = Utilities.MillimetersToPoints(6),
                        BorderColor = BaseColor.BLACK,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    };
                    detail_cell[7] = new PdfPCell(new Phrase("ά������", FontNorml))
                    {
                        BorderWidth = 1,
                        MinimumHeight = Utilities.MillimetersToPoints(6),
                        BorderColor = BaseColor.BLACK,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        VerticalAlignment = Element.ALIGN_MIDDLE
                    };
                    detail_cell[8] = new PdfPCell(new Phrase("��ע", FontNorml))
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
                    //�ϼ�
                    detail_cell = new PdfPCell[9];
                    detail_cell[0] = new PdfPCell(new Phrase("�ܼ�", FontNorml)) { Colspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                    detail_cell[2] = new PdfPCell(new Phrase("����д����" + UpperRMB.CmycurD(OrderPrice.ToString()), FontNorml)) { Colspan = 4, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                    detail_cell[6] = new PdfPCell(new Phrase("��Сд����" + OrderPrice.ToString(), FontNorml)) { Colspan = 3, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
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

                        PdfPTable table2 = new PdfPTable(4) { WidthPercentage = 90 };//����������ȷ�����������       
                        int[] tab2w = new[] { 10, 35, 30, 25 };
                        table2.SetWidths(tab2w);
                        PdfPRow row2;
                        PdfPCell[] dcell2 = new PdfPCell[4];
                        dcell2[0] = new PdfPCell(new Phrase("���", FontNorml));
                        dcell2[1] = new PdfPCell(new Phrase("��Ʒ�ͺ�", FontNorml));
                        dcell2[2] = new PdfPCell(new Phrase("�ܺϼ�", FontNorml));
                        dcell2[3] = new PdfPCell(new Phrase("������", FontNorml));
                        row2 = new PdfPRow(dcell2);
                        table2.Rows.Add(row2);

                        dcell2 = new PdfPCell[4];
                        dcell2[0] = new PdfPCell(new Phrase("1", FontNorml));
                        dcell2[1] = new PdfPCell(new Phrase("��ϸ����ͬ����\"�����嵥\"", FontNorml));
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
                    string t3 = @"1) ˰�ʼ��˷ѣ�{0},���ؼ��˷ѡ�         
2) ���ʽ���������         
�������ݲ������޷�Χ(��ʹ�Ǳ�������Ҳ���г�����)           
3) ���û�������������Ĺ��Ϻ��𻵡�     
4) ���ڷǱ���˾�Ͽɵľ����̻���ά����Ա���������������ֽ⡢ά�ޡ�����������Ĺ��Ϻ��𻵡�          
5) �û������������ʱ��         
6) δ������˾ͬ���������Ƿά�޿       
7) ����֣���ˮ�������׻��Ȳ��ɿ��ܵ���Ȼ�ֺ�������Ĺ��Ϻ��𻵡�           
8) ���Դ��ѹ�ȷǻ�������Χֵ������Ĺ��Ϻ��𻵡�      
9) ���û����н��������䡢���˲���������Ĺ��Ϻ��𻵡�     
���ļ�һʽ���ݣ��ļ��Դ��������ǩ�¾���Ч��     ";
                    //   t3 = t3.Replace(Environment.NewLine, String.Empty).Replace("  ", String.Empty);

                    string ratioType = "";
                    if (spn.Rows[0]["BranchRatioType"].ToString() == "��" || Convert.ToDecimal(spn.Rows[0]["BranchRatio"]) == 0)
                    {
                        ratioType = "����˰";
                    }
                    else
                    {
                        ratioType = spn.Rows[0]["BranchRatioType"].ToString() + "��" + Math.Round(Convert.ToDecimal(spn.Rows[0]["BranchRatio"]) * 100, 0).ToString() + "%";
                    }


                    Chunk beginning = new Chunk(string.Format(t3, ratioType), FontNorml);
                    Phrase p1 = new Phrase(beginning);
                    Paragraph p = new Paragraph();
                    p.Add(p1);
                    p.IndentationLeft = 30;
                    doc.Add(p);
                    doc.Add(t2);//�հ���
                    //������ϵ
                    PdfPTable tb_cat = new PdfPTable(4) { WidthPercentage = 90 };//����������ȷ�����������
                    PdfPCell[] cell_cat = new PdfPCell[4];
                    PdfPRow row_cat;
                    int[] ws_cat = new[] { 15, 35, 15, 35 };
                    tb_cat.SetWidths(ws_cat);

                    //��ϵ��Ϣspn
                  
                    string lm_phone = "";
                    string lm_fax = "";
                    string lm_mail = "";
   //������Ϣ
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
                    //spn.Rows[0]["Operator"].ToString()  ����Ա��Ϣ
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
                    cell_cat[0] = new PdfPCell(new Phrase("�ͻ����ƣ�", FontNorml));
                    cell_cat[1] = new PdfPCell(new Phrase(comName, FontNorml));
                    cell_cat[2] = new PdfPCell(new Phrase("ά�޹�˾��", FontNorml));
                    cell_cat[3] = new PdfPCell(new Phrase(cname, FontNorml));
                    row_cat = new PdfPRow(cell_cat);
                    tb_cat.Rows.Add(row_cat);

                    cell_cat = new PdfPCell[4];
                    cell_cat[0] = new PdfPCell(new Phrase("��ϵ�ˣ�", FontNorml));
                    cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["LinkMan"].ToString(), FontNorml));
                    cell_cat[2] = new PdfPCell(new Phrase("ҵ��Ա��", FontNorml));
                    cell_cat[3] = new PdfPCell(new Phrase(spn.Rows[0]["Operator"].ToString(), FontNorml));
                    row_cat = new PdfPRow(cell_cat);
                    tb_cat.Rows.Add(row_cat);

                    cell_cat = new PdfPCell[4];
                    cell_cat[0] = new PdfPCell(new Phrase("�ֻ���", FontNorml));
                    cell_cat[1] = new PdfPCell(new Phrase(lm_phone, FontNorml));
                    cell_cat[2] = new PdfPCell(new Phrase("�ֻ���", FontNorml));
                    cell_cat[3] = new PdfPCell(new Phrase(sell_phone2, FontNorml));
                    row_cat = new PdfPRow(cell_cat);
                    tb_cat.Rows.Add(row_cat);

                    cell_cat = new PdfPCell[4];
                    cell_cat[0] = new PdfPCell(new Phrase("�绰��", FontNorml));
                    cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["Tel"].ToString(), FontNorml));
                    cell_cat[2] = new PdfPCell(new Phrase("�绰��", FontNorml));
                    cell_cat[3] = new PdfPCell(new Phrase(sell_phone1, FontNorml));
                    row_cat = new PdfPRow(cell_cat);
                    tb_cat.Rows.Add(row_cat);

                    cell_cat = new PdfPCell[4];
                    cell_cat[0] = new PdfPCell(new Phrase("���棺", FontNorml));
                    cell_cat[1] = new PdfPCell(new Phrase(lm_fax, FontNorml));
                    cell_cat[2] = new PdfPCell(new Phrase("���棺", FontNorml));
                    cell_cat[3] = new PdfPCell(new Phrase(sell_fax, FontNorml));
                    row_cat = new PdfPRow(cell_cat);
                    tb_cat.Rows.Add(row_cat);

                    cell_cat = new PdfPCell[4];
                    cell_cat[0] = new PdfPCell(new Phrase("Email��", FontNorml));
                    cell_cat[1] = new PdfPCell(new Phrase(lm_mail, FontNorml));
                    cell_cat[2] = new PdfPCell(new Phrase("Email��", FontNorml));
                    cell_cat[3] = new PdfPCell(new Phrase(sell_mail, FontNorml));
                    row_cat = new PdfPRow(cell_cat);
                    tb_cat.Rows.Add(row_cat);

                    cell_cat = new PdfPCell[4];
                    cell_cat[0] = new PdfPCell(new Phrase("�ͻ���ַ��", FontNorml));
                    cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["Adr"].ToString(), FontNorml));
                    cell_cat[2] = new PdfPCell(new Phrase("��˾��ַ��", FontNorml));
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
                    if (wdName.IndexOf("����") >=0)
                    {
                        img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "fcht.jpg");
                    }
                    else if (wdName.IndexOf("������") >=0)
                    {
                        img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "mfyht.jpg");
                    }
                    else if (wdName.IndexOf("ʢ��") >= 0)
                    {
                        img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "sthxht.gif");
                    }
                    else if (wdName.IndexOf("����") >= 0)
                    {
                        img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "blht.png");
                    }
                    else if (wdName.IndexOf("����") >= 0)
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
                        title = new Paragraph("������ͬ", FontBig);
                        title.Alignment = Element.ALIGN_CENTER;
                        doc.Add(title);//�ڶ�ҳ����
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
                        //�ϼ�
                        detail_cell = new PdfPCell[9];
                        detail_cell[0] = new PdfPCell(new Phrase("�ܼ�", FontNorml)) { Colspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        detail_cell[2] = new PdfPCell(new Phrase("����д����" + UpperRMB.CmycurD(OrderPrice.ToString()), FontNorml)) { Colspan = 4, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                        detail_cell[6] = new PdfPCell(new Phrase("��Сд����" + OrderPrice.ToString(), FontNorml)) { Colspan = 3, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
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
                    title = new Paragraph("����ID��Ч��", FontSmall);
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
        //ҳ���С
        Document doc = new Document(PageSize.A4);
        doc.SetMargins(0f, 0f, 10f, 0f);
        MemoryStream stream = new MemoryStream();
     
        PdfWriter pdfWritey = PdfWriter.GetInstance(doc, stream);
        pdfWritey.CloseStream = false;
        doc.Open();
        DataTable spn = new DataTable();

        //����
        iTextSharp.text.Font FontBig = new iTextSharp.text.Font(baseFont, 16f);
        iTextSharp.text.Font FontNorml = new iTextSharp.text.Font(baseFont, 10f);
        iTextSharp.text.Font FontSmall = new iTextSharp.text.Font(baseFont, 8f);
        iTextSharp.text.Font FontTitle = new iTextSharp.text.Font(baseFont, 12f, Font.BOLD);
        FontBig.IsBold();
        Paragraph title;
        if (ids.Count() <= 0)
        {
            title = new Paragraph("����IDΪ��", FontBig);
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
                                title = new Paragraph("���󣺷���Ų�ƥ�䣬���ܺϲ���", FontBig);
                                title.IndentationLeft = 30;
                                doc.Add(title);
                                doc.Close();
                                return stream;
                            }
                        }
                        else
                        {
                            title = new Paragraph("����ID��Ч��", FontBig);
                            title.IndentationLeft = 30;
                            doc.Add(title);
                            doc.Close();
                            return stream;
                        }
                    }
                }

                #region main

                string cname = spn.Rows[0]["BranchName"].ToString() == "�ܲ�" || string.IsNullOrEmpty(spn.Rows[0]["BranchName"].ToString()) ? "����ʢ�ƺ�Ѷ�Ƽ����޹�˾" : spn.Rows[0]["BranchName"].ToString();
                title = new Paragraph(cname, FontBig);
                title.Alignment = Element.ALIGN_CENTER;
                doc.Add(title);
                title = new Paragraph("ά�ޱ��۵�", FontBig);
                title.Alignment = Element.ALIGN_CENTER;
                Paragraph t2 = new Paragraph("  ", FontBig);
                doc.Add(title);
                doc.Add(t2);

                //����
                PdfPTable table = new PdfPTable(4) { WidthPercentage = 90 };//����������ȷ�����������

                PdfPCell[] cellBody = new PdfPCell[4];
                int[] ws = new[] { 12, 48, 12, 28 };
                table.SetWidths(ws);
                cellBody[0] = new PdfPCell(new Phrase("ά�޵��ţ�", FontNorml))
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
                cellBody[2] = new PdfPCell(new Phrase("�������ڣ�", FontNorml))
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
                cellBody[0] = new PdfPCell(new Phrase("�ͻ����ƣ�", FontNorml))
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
                cellBody[2] = new PdfPCell(new Phrase("���۵�λ��", FontNorml))
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
                cellBody[0] = new PdfPCell(new Phrase("��ϵ�ˣ�", FontNorml))
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

                cellBody[2] = new PdfPCell(new Phrase("�����ˣ�", FontNorml))
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
                //����
                string t1 = "  �𾴵Ŀͻ���";
                string t11 = "  ��л�����ҹ�˾��֧������������ݹ�˾������Ʒ��ص���Ϣ���ҹ�˾���������񱨼ۡ���ȷ�����·���ʽ���Ʒѽ���ͬ��ǩ�ֲ��Ӹǹ��»ش������ǡ�";
                doc.Add(new Paragraph(t1, FontNorml) { IndentationLeft = 30 });
                doc.Add(new Paragraph(t11, FontNorml) { IndentationLeft = 30, IndentationRight = 30 });
                doc.Add(new Paragraph(" ", FontNorml));
                //��Ʒ��ϸ
                //fw_servicesmaterial �Ĳ�
                DataTable tb_mate = DALCommon.GetDataList("fw_servicesoffer", "", " [BillID] in (" + num + ")").Tables[0];
                List<serModel> fwbaojia = new List<serModel>();
                decimal OrderPrice = 0;
                if (tb_mate.Rows.Count > 0)
                {
                    serModel ser;

                    for (int i = 0; i < tb_mate.Rows.Count; i++)
                    {
                        ser = new serModel();
                        ser.xid = i + 1;//���
                        ser.name = spn.Rows[0]["ProductClass"].ToString();//c��Ʒ����
                        ser.model = spn.Rows[0]["ProductModel"].ToString(); //��Ʒ�ͺ�
                        ser.unit = "";//tb_mate.Rows[i]["Unit"].ToString(); ��λ
                        ser.qty = 1;//����
                        ser.price = Convert.ToDecimal(tb_mate.Rows[i]["dAmount"]);
                        ser.content = tb_mate.Rows[i]["_Name"].ToString();//ά�޷���
                        ser.common = "";//ά������
                        ser.zq = tb_mate.Rows[i]["Remark"].ToString(); ;//ά������
                        fwbaojia.Add(ser);
                        OrderPrice += ser.price * ser.qty;
                    }
                }


                PdfPTable detail_table = new PdfPTable(9) { WidthPercentage = 90 };//����������ȷ�����������       
                int[] ws2 = new[] { 5, 15, 20, 0, 0, 11, 21, 9, 12 };
                detail_table.SetWidths(ws2);
                PdfPCell[] detail_cell = new PdfPCell[9];
                detail_cell[0] = new PdfPCell(new Phrase("���", FontNorml))
                {
                    BorderWidth = 1,
                    MinimumHeight = Utilities.MillimetersToPoints(6),
                    BorderColor = BaseColor.BLACK,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };
                detail_cell[1] = new PdfPCell(new Phrase("��Ʒ����", FontNorml))
                {
                    BorderWidth = 1,
                    MinimumHeight = Utilities.MillimetersToPoints(6),
                    BorderColor = BaseColor.BLACK,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };
                detail_cell[2] = new PdfPCell(new Phrase("�ͺ�", FontNorml))
                {
                    BorderWidth = 1,
                    MinimumHeight = Utilities.MillimetersToPoints(6),
                    BorderColor = BaseColor.BLACK,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };
                detail_cell[3] = new PdfPCell(new Phrase("��λ", FontNorml))
                {
                    BorderWidth = 1,
                    MinimumHeight = Utilities.MillimetersToPoints(6),
                    BorderColor = BaseColor.BLACK,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };
                detail_cell[4] = new PdfPCell(new Phrase("����", FontNorml))
                {
                    BorderWidth = 1,
                    MinimumHeight = Utilities.MillimetersToPoints(6),
                    BorderColor = BaseColor.BLACK,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };
                detail_cell[5] = new PdfPCell(new Phrase("����", FontNorml))
                {
                    BorderWidth = 1,
                    MinimumHeight = Utilities.MillimetersToPoints(6),
                    BorderColor = BaseColor.BLACK,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };
                detail_cell[6] = new PdfPCell(new Phrase("ά�޷���", FontNorml))
                {
                    BorderWidth = 1,
                    MinimumHeight = Utilities.MillimetersToPoints(6),
                    BorderColor = BaseColor.BLACK,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };
                detail_cell[7] = new PdfPCell(new Phrase("ά������", FontNorml))
                {
                    BorderWidth = 1,
                    MinimumHeight = Utilities.MillimetersToPoints(6),
                    BorderColor = BaseColor.BLACK,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };
                detail_cell[8] = new PdfPCell(new Phrase("��ע", FontNorml))
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
                    //�ϼ�
                    detail_cell = new PdfPCell[9];
                    detail_cell[0] = new PdfPCell(new Phrase("�ܼ�", FontNorml)) { Colspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                    detail_cell[2] = new PdfPCell(new Phrase("����д����" + UpperRMB.CmycurD(OrderPrice.ToString()), FontNorml)) { Colspan = 4, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                    detail_cell[6] = new PdfPCell(new Phrase("��Сд����" + OrderPrice.ToString(), FontNorml)) { Colspan = 3, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };

                    drowBody = new PdfPRow(detail_cell);
                    detail_table.Rows.Add(drowBody);

                    doc.Add(detail_table);
                }
                else {
                    for (int i = 0; i < fwbaojia.Count; i++)
                    {
                        OrderPrice += fwbaojia[i].price * fwbaojia[i].qty;
                    }

                    PdfPTable table2 = new PdfPTable(4) { WidthPercentage = 90 };//����������ȷ�����������       
                    int[] tab2w = new[] { 10, 35, 30, 25 };
                    table2.SetWidths(tab2w);
                    PdfPRow row2;
                    PdfPCell[] dcell2 = new PdfPCell[4];
                    dcell2[0] = new PdfPCell(new Phrase("���", FontNorml));
                    dcell2[1] = new PdfPCell(new Phrase("��Ʒ�ͺ�", FontNorml));
                    dcell2[2] = new PdfPCell(new Phrase("�ܺϼ�", FontNorml));
                    dcell2[3] = new PdfPCell(new Phrase("������", FontNorml));
                    row2 = new PdfPRow(dcell2);
                    table2.Rows.Add(row2);

                    dcell2 = new PdfPCell[4];
                    dcell2[0] = new PdfPCell(new Phrase("1", FontNorml));
                    dcell2[1] = new PdfPCell(new Phrase("��ϸ����ͬ����\"�����嵥\"", FontNorml));
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
                string t3 = @"1) ˰�ʼ��˷ѣ�{0},���ؼ��˷ѡ�         
2) ���ʽ���������         
�������ݲ������޷�Χ(��ʹ�Ǳ�������Ҳ���г�����)           
3) ���û�������������Ĺ��Ϻ��𻵡�     
4) ���ڷǱ���˾�Ͽɵľ����̻���ά����Ա���������������ֽ⡢ά�ޡ�����������Ĺ��Ϻ��𻵡�          
5) �û������������ʱ��         
6) δ������˾ͬ���������Ƿά�޿       
7) ����֣���ˮ�������׻��Ȳ��ɿ��ܵ���Ȼ�ֺ�������Ĺ��Ϻ��𻵡�           
8) ���Դ��ѹ�ȷǻ�������Χֵ������Ĺ��Ϻ��𻵡�      
9) ���û����н��������䡢���˲���������Ĺ��Ϻ��𻵡�     
���ļ�һʽ���ݣ��ļ��Դ��������ǩ�¾���Ч��     ";
                //   t3 = t3.Replace(Environment.NewLine, String.Empty).Replace("  ", String.Empty);
                string ratioType = "";
                if (spn.Rows[0]["BranchRatioType"].ToString() == "��" || Convert.ToDecimal(spn.Rows[0]["BranchRatio"]) == 0)
                {
                    ratioType = "����˰";//�� 17%��ֵ˰
                }
                else
                {
                    ratioType = spn.Rows[0]["BranchRatioType"].ToString() + "��" + Math.Round(Convert.ToDecimal(spn.Rows[0]["BranchRatio"]) * 100, 0).ToString() + "%";
                }

                Chunk beginning = new Chunk(string.Format(t3,ratioType), FontNorml);
                Phrase p1 = new Phrase(beginning);
                Paragraph p = new Paragraph();
                p.Add(p1);
                p.IndentationLeft = 30;
                doc.Add(p);
                doc.Add(t2);//�հ���
                //������ϵ
                PdfPTable tb_cat = new PdfPTable(4);//����������ȷ�����������
                PdfPCell[] cell_cat = new PdfPCell[4];
                PdfPRow row_cat;
                int[] ws_cat = new[] { 15, 35, 15, 35 };
                tb_cat.SetWidths(ws_cat);

                //��ϵ��Ϣspn

                string lm_phone = "";
                string lm_fax = "";
                string lm_mail = "";
                //������Ϣ
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
                //spn.Rows[0]["Operator"].ToString()  ����Ա��Ϣ
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
                cell_cat[0] = new PdfPCell(new Phrase("�ͻ����ƣ�", FontNorml));
                cell_cat[1] = new PdfPCell(new Phrase(comName, FontNorml));
                cell_cat[2] = new PdfPCell(new Phrase("ά�޹�˾��", FontNorml));
                cell_cat[3] = new PdfPCell(new Phrase(cname, FontNorml));
                row_cat = new PdfPRow(cell_cat);
                tb_cat.Rows.Add(row_cat);

                cell_cat = new PdfPCell[4];
                cell_cat[0] = new PdfPCell(new Phrase("��ϵ�ˣ�", FontNorml));
                cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["LinkMan"].ToString(), FontNorml));
                cell_cat[2] = new PdfPCell(new Phrase("ҵ��Ա��", FontNorml));
                cell_cat[3] = new PdfPCell(new Phrase(spn.Rows[0]["Operator"].ToString(), FontNorml));
                row_cat = new PdfPRow(cell_cat);
                tb_cat.Rows.Add(row_cat);

                cell_cat = new PdfPCell[4];
                cell_cat[0] = new PdfPCell(new Phrase("�ֻ���", FontNorml));
                cell_cat[1] = new PdfPCell(new Phrase(lm_phone, FontNorml));
                cell_cat[2] = new PdfPCell(new Phrase("�ֻ���", FontNorml));
                cell_cat[3] = new PdfPCell(new Phrase(sell_phone2, FontNorml));
                row_cat = new PdfPRow(cell_cat);
                tb_cat.Rows.Add(row_cat);

                cell_cat = new PdfPCell[4];
                cell_cat[0] = new PdfPCell(new Phrase("�绰��", FontNorml));
                cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["Tel"].ToString(), FontNorml));
                cell_cat[2] = new PdfPCell(new Phrase("�绰��", FontNorml));
                cell_cat[3] = new PdfPCell(new Phrase(sell_phone1, FontNorml));
                row_cat = new PdfPRow(cell_cat);
                tb_cat.Rows.Add(row_cat);

                cell_cat = new PdfPCell[4];
                cell_cat[0] = new PdfPCell(new Phrase("���棺", FontNorml));
                cell_cat[1] = new PdfPCell(new Phrase(lm_fax, FontNorml));
                cell_cat[2] = new PdfPCell(new Phrase("���棺", FontNorml));
                cell_cat[3] = new PdfPCell(new Phrase(sell_fax, FontNorml));
                row_cat = new PdfPRow(cell_cat);
                tb_cat.Rows.Add(row_cat);

                cell_cat = new PdfPCell[4];
                cell_cat[0] = new PdfPCell(new Phrase("Email��", FontNorml));
                cell_cat[1] = new PdfPCell(new Phrase(lm_mail, FontNorml));
                cell_cat[2] = new PdfPCell(new Phrase("Email��", FontNorml));
                cell_cat[3] = new PdfPCell(new Phrase(sell_mail, FontNorml));
                row_cat = new PdfPRow(cell_cat);
                tb_cat.Rows.Add(row_cat);

                cell_cat = new PdfPCell[4];
                cell_cat[0] = new PdfPCell(new Phrase("�ͻ���ַ��", FontNorml));
                cell_cat[1] = new PdfPCell(new Phrase(spn.Rows[0]["Adr"].ToString(), FontNorml));
                cell_cat[2] = new PdfPCell(new Phrase("��˾��ַ��", FontNorml));
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
                if (wdName.IndexOf("����") >=0)
                {
                    img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "fc.jpg");
                }
                else if (wdName.IndexOf("������") >= 0)
                {
                    img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "mfy.jpg");
                }
                else if (wdName.IndexOf("ʢ��") >= 0)
                {
                    img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "sthx.jpg");
                }
                else if (wdName.IndexOf("����") >= 0)
                {
                    img = Image.GetInstance(HttpContext.Current.Server.MapPath("/images/yinzhang/") + "bl.png");
                }
                else if (wdName.IndexOf("����") >= 0)
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
                    title = new Paragraph("������ͬ", FontBig);
                    title.Alignment = Element.ALIGN_CENTER;
                    doc.Add(title);//�ڶ�ҳ����
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
                
                    //�ϼ�
                    detail_cell = new PdfPCell[9];
                    detail_cell[0] = new PdfPCell(new Phrase("�ܼ�", FontNorml)) { Colspan = 2, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                    detail_cell[2] = new PdfPCell(new Phrase("����д����" + UpperRMB.CmycurD(OrderPrice.ToString()), FontNorml)) { Colspan = 4, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };
                    detail_cell[6] = new PdfPCell(new Phrase("��Сд����" + OrderPrice.ToString(), FontNorml)) { Colspan = 3, HorizontalAlignment = Element.ALIGN_CENTER, VerticalAlignment = Element.ALIGN_MIDDLE, MinimumHeight = Utilities.MillimetersToPoints(6) };

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
                title = new Paragraph("����ID��Ч��", FontSmall);
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
/// ����ϲ�model
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