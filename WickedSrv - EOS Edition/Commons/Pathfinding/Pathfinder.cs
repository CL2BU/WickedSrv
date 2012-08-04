using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WickedSrv___EOS_Edition.Commons.Pathfinding
{
    class Pathfinder
    {
        public static string CalculatePath(string[] negativ1)
        {
            try
            {
                //string All2 = "";
                //double maxRange = double.Parse(negativ1[4].Replace("W", ""));
                //double minRange = double.Parse(negativ1[3]);

                //double b4Range1 = double.Parse(negativ1[1]);
                //double b4Range2 = double.Parse(negativ1[2]);

                //if (maxRange != minRange)
                //{
                //    for (double i1 = b4Range1 + 1, i2 = b4Range2 + 1; i1 < minRange && i2 < maxRange; i1++, i2++)
                //    {
                //        if (i2 < maxRange)
                //        {
                //            All2 += i1 + "," + i2 + "#";
                //        }
                //        else
                //        {
                //            All2 += i1 + "," + i2;
                //        }
                //        i1++;
                //        i2++;
                //    }
                //}
                //Form1.getManager().Print(All2);
                //return All2;

                string All2 = "";
                int start = 1;
                for (int i = 1; i < negativ1.Length; i++)
                {
                    if (start > 0 && start <= 3)
                    {
                        if (start != 3)
                        {
                            All2 += negativ1[3] + "," + negativ1[4] + "#";
                        }
                        else
                        {
                            All2 += negativ1[3] + "," + negativ1[4];
                        }
                        start++;
                    }
                    else
                    {
                        start = 1;
                    }
                }
                return All2;
            }
            catch (Exception ex) { Form1.getManager().Print(ex.ToString()); return ""; }
        }
    }
}
