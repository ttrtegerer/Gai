using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace REG_MARK_LIB
{
    public class Class1
    {
        public Boolean CheckMark(String mark)
        {
            if (Regex.IsMatch(mark, @"/ ^[A-Z]\d{ 3} (?<!000)[A-Z]{ 2}\d{ 2,3}$/ ui"))
            {
                return true;
            }
            return false;
        }
        public string GetNextMarkAfter (String mark)
        {
            int Seria =Convert.ToInt32(mark.Substring(1, 4));
            String NextMarkAfter = "";
            if (Seria != 999)
            {
                Seria++; 
                if (mark.Length == 8)
                {
                    NextMarkAfter = mark.Substring(0, 1) + Convert.ToString(Seria) + mark.Substring(4, 7);
                }
                else
                {
                    NextMarkAfter = mark.Substring(0, 1) + Convert.ToString(Seria) + mark.Substring(4, 8);
                }
            }
      else {
                Seria = 000;
                if (mark.Substring(5, 6) != "Z")
                {
                    var Sumbol = Convert.ToChar(mark.Substring(5, 6));
                    var NextSumbol = (Sumbol == 'Z' ? 'A' : (char)(Sumbol + 1));
                    if (mark.Length == 8)
                    {
                        NextMarkAfter = mark.Substring(0, 1) + Convert.ToString(Seria) + mark.Substring(4, 5) + Convert.ToString(NextSumbol) + mark.Substring(6, 7);
                    }
                    else
                    {
                        NextMarkAfter = mark.Substring(0, 1) + Convert.ToString(Seria) + mark.Substring(4, 5) + Convert.ToString(NextSumbol) + mark.Substring(6, 8);
                    }
                }
                else if(mark.Substring(4, 5) != "Z")
                        {
                    var Sumbol = Convert.ToChar(mark.Substring(4, 5));
                    var NextSumbol = (Sumbol == 'Z' ? 'A' : (char)(Sumbol + 1));
                    var NextSumbol2 ="A";
                    if (mark.Length == 8)
                    {
                        NextMarkAfter = mark.Substring(0, 1) + Convert.ToString(Seria) + Convert.ToString(NextSumbol2) + Convert.ToString(NextSumbol) + mark.Substring(6, 7);
                    }
                    else
                    {
                        NextMarkAfter = mark.Substring(0, 1) + Convert.ToString(Seria) + Convert.ToString(NextSumbol2) + Convert.ToString(NextSumbol) + mark.Substring(6, 8);
                    }
                }
                else
                {
                    var Sumbol = Convert.ToChar(mark.Substring(0, 1));
                    var NextSumbol = (Sumbol == 'Z' ? 'A' : (char)(Sumbol + 1));
                    if (mark.Length == 8)
                    {
                        NextMarkAfter = Convert.ToString(NextSumbol) + Convert.ToString(Seria) +"AA"+ mark.Substring(6, 7);
                    }
                    else
                    {
                        NextMarkAfter = Convert.ToString(NextSumbol) + Convert.ToString(Seria)+ "AA"  + mark.Substring(6, 8);
                    }
                }
            }
           
            return NextMarkAfter;
        }
        public string GetNextMarkAfterInRange(String prevMark, String rangeStart, String rangeEnd)
        {
            string NextMarkAfterInRange = "";
            if (prevMark.Substring(0,1)==rangeStart.Substring(0,1)&& prevMark.Substring(0, 1) == rangeEnd.Substring(0,1)
            && prevMark.Substring(4, 6) == rangeStart.Substring(4, 6) && prevMark.Substring(4, 6) == rangeEnd.Substring(4, 6))
            {
                int Seria1 = Convert.ToInt32(prevMark.Substring(1, 4));
                int Seria2 = Convert.ToInt32(rangeStart.Substring(1, 4));
                int Seria3 = Convert.ToInt32(rangeEnd.Substring(1, 4));
                if (Seria1 >= Seria2 && Seria1 < Seria3)
                {
                    Seria1++;
                    if (prevMark.Length == 8)
                    {
                        NextMarkAfterInRange = prevMark.Substring(0, 1) + Convert.ToString(Seria1) + prevMark.Substring(4, 7);
                    }
                    else
                    {
                        NextMarkAfterInRange = prevMark.Substring(0, 1) + Convert.ToString(Seria1) + prevMark.Substring(4, 8);
                    }
                }
                else NextMarkAfterInRange = "out of stock";
            }
            else
            {
                int Seria1 = Convert.ToInt32(prevMark.Substring(1, 4));
                Seria1++; 
                if (prevMark.Length == 8)
                {
                    NextMarkAfterInRange = prevMark.Substring(0, 1) + Convert.ToString(Seria1) + prevMark.Substring(4, 7);
                }
                else
                {
                    NextMarkAfterInRange = prevMark.Substring(0, 1) + Convert.ToString(Seria1) + prevMark.Substring(4, 8);
                }
            }

            return NextMarkAfterInRange;


        }
       public int GetCombinationsCountInRange(String mark1, String mark2)
        {
            int Seria1 = Convert.ToInt32(mark1.Substring(1, 4));
            int Seria2 = Convert.ToInt32(mark2.Substring(1, 4));
            if (Seria1 != 999)
            {
                if (mark1.Substring(0, 1) == mark2.Substring(0, 1) && mark1.Substring(4, 6) == mark2.Substring(4, 6))
                {
                    return Seria2 - Seria1;
                }
                else
                {
                    return (999 - Seria1) + Seria2;
                }
            }
            else
            {
                return 1 + Seria2;
            }
        }
    }
}
