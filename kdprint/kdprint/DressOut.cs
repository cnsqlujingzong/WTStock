using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace kdprint
{
    class DressOut
    {
        //分解收货地址
        public string[] GetString(string Stxt1)
        {
            int n = 0;
            List<string> ls = new List<string>();
            //收件人变量
            string Sname = "", Sdress = "", Stel = "", Sphone = "", Spost = "", Stxt = "", Sxin = "", Squ = "";
            string[] st = { "", "", "", "", "", "", "" };
            //删除 ：以前的字符
            for (int i = 0; i < Stxt1.Length; i++)
            {
                if (Stxt1.ToCharArray()[i].ToString() == "：" || Stxt1.ToCharArray()[i].ToString() == ":")
                {
                    Stxt1 = Stxt1.Substring(i + 1, Stxt1.Length - i - 1);
                    break;
                }
            }

            #region //分隔字符
            while (n < Stxt1.Length)
            {
                if (Stxt1.ToCharArray()[n].ToString() == "," || Stxt1.ToCharArray()[n].ToString() == "，")
                {
                    if (Stxt1.Substring(0, n).Replace(" ", "") != "")
                    {
                        while (n < Stxt1.Length-1)
                        {
                            if (Stxt1.ToCharArray()[n + 1].ToString() == "," || Stxt1.ToCharArray()[n + 1].ToString() == "，")
                                n++;
                            else
                                break;
                        }
                        ls.Add(Stxt1.Substring(0, n));
                    }
                    Stxt1 = Stxt1.Substring(n + 1, Stxt1.Length - n - 1);
                    n = 0;
                }
                n++;
            }
            Regex rex = new Regex(@"^[0-9]+[-]?[0-9]+[0-9]");
            if (ls.Count < 2)
                return st;
            if (!rex.IsMatch(ls[0]))
                Sname = ls[0];
            if (rex.IsMatch(ls[1]))
                Stel = ls[1];
            n = 2;
            if (ls.Count > 2)
            {
                if (rex.IsMatch(ls[2]))
                {
                    Sphone = ls[2];
                    n = 3;
                }
            }
            while (n < ls.Count)
            {
                if (!rex.IsMatch(ls[n]))
                    Sdress = Sdress + ls[n];
                n++;
            }
            ls.Clear();
            if (rex.IsMatch(Stxt1))
                Spost = Stxt1;
            else
                Sdress = Sdress + Stxt1;
            #endregion
            #region//找出城市和区域 顺序：１．县２.市
            rex = new Regex(@"\s+([^\s]+县)\s.+", RegexOptions.RightToLeft);
            if (rex.IsMatch(Sdress))
            {
                Match m = rex.Match(Sdress);
                Sxin = m.Groups[1].Value;
            }
            rex = new Regex(@"\s+([^\s]+市)\s+", RegexOptions.ExplicitCapture|RegexOptions.RightToLeft);
            if (rex.IsMatch(Sdress))
            {
                MatchCollection o = rex.Matches(Sdress);
                //Match o = rex.Match(Sdress);
                //Sxin = o.Groups[1].Value + Sxin;
                Sxin = o[0].Value + Sxin;
            }
            rex = new Regex(@".+\s+([^\s]+[区|镇])\s.+", RegexOptions.RightToLeft);
            if (rex.IsMatch(Sdress))
            {
                Match p = rex.Match(Sdress);
                Squ = p.Groups[1].Value;
            }
            #endregion
            st[0] = Sname;
            st[1] = Stel;
            st[2] = Sphone;
            st[3] = Sdress;
            st[4] = Spost;
            st[5] = Sxin;
            st[6] = Squ;
            return st;
        }
    }
}
