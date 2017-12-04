﻿using System; 

namespace Warmups.BLL
{
    public class Conditionals
    {
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            bool inTrouble = false;
            if (aSmile && bSmile || !aSmile && !bSmile)
            {
                inTrouble = true;
            }
            return inTrouble;
        }

        public bool CanSleepIn(bool isWeekday, bool isVacation)
        {
            bool CanSleepIn = false;
            if (!isWeekday || isVacation)
            {
                CanSleepIn = true;
            }
            return CanSleepIn;
        }

        public int SumDouble(int a, int b)
        {
            int sum = (a + b);
            if (a == b)
            {
                return (sum * 2);
            }
            return sum;

        }

        public int Diff21(int n)
        {
            int absolute = Math.Abs(n - 21);
            if (n > 21)
            {
                return (absolute * 2);
            }
            return absolute;
        }

        public bool ParrotTrouble(bool isTalking, int hour)
        {
            bool inTrouble = false;
            if (isTalking && (hour < 7 || hour > 20))
            {
                inTrouble = true;
            }
            return inTrouble;

        }

        public bool Makes10(int a, int b)
        {
            bool Ten = false;
            if ((a == 10 || b == 10) || (a + b == 10))
            {
                Ten = true;
            }
            return Ten;
        }

        public bool NearHundred(int n)
        {
            return ((n >= 90 && Math.Abs(n) <= 110) || (n >= 190 && Math.Abs(n) <= 210));
        }


        public bool PosNeg(int a, int b, bool negative)
        {
            bool Negative = true;
            if ((a== -a) || (b== -b))

            {
                Negative = true;
            }
            return Negative;
        }
        
        public string NotString(string s)
        {
            if (s.IndexOf("not ")==0)
            {
                return s;
            }
            else
            {
                return ("not " + s);
            }
        }
        
        public string MissingChar(string str, int n)
        {
            string nub = str.Remove(n, 1);
            return nub;
        }

        public string FrontBack(string str)
        {
            if (str.Length <= 1)
            {
                return str;
            }
            else
            {
                var first = str[0];
                var last = str[str.Length - 1];
                var middle = str.Substring(1, str.Length -2);
                return (last + middle + first);
            }
            throw new NotImplementedException();
        }
        
        public string Front3(string str)
        {
            string front = str.Length >= 3 ? str.Substring(0, 3) : str;
            return front + front + front;
        }
        
        public string BackAround(string str)
        {
            var last = str[str.Length - 1];
            string wubb = (last + (str) + last);
            {
                return wubb;
            }
        }
        
        
        public bool Multiple3or5(int number)
        {
            if (number % 3 == 0 || number % 5  == 0)
            {
                return true;
            }
            else return false;
        }
        
        public bool StartHi(string str)
        {
            if (str.StartsWith("hi"))
            {
                if (str.Length > 2)
                {
                    if (char.IsLetter(str[2]))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
            throw new NotImplementedException();
        }
        
        public bool IcyHot(int temp1, int temp2)
        {
            if ((temp1 <= 0 || temp1 >= 100) && (temp2 <= 0 || temp2 >= 100))
            {
                return true;
            }
            else return false;
            throw new NotImplementedException();

        }

        public bool Between10and20(int a, int b)
        {
            if ((a >= 10 && a <= 20) || (b >= 10 && b <= 20))
            {
                return true;
            }
            else return false;
            throw new NotImplementedException();
        }
        
        public bool HasTeen(int a, int b, int c)
        {
            if ((a <= 19 && a >= 13) || (b <= 19 && b >= 13) || (c <= 19 && c >= 13))
            {
                return true;
            }
            else return false;
            throw new NotImplementedException();
        }
        
        public bool SoAlone(int a, int b)
        {
            return (((a >= 13 && a <= 19) && !(b >= 13 && b <= 19)) || (!(a >= 13 && a <= 19) && (b >= 13 && b <= 19)));
        }
        
        public string RemoveDel(string str)
        {
            var d = "del";
            return str.Replace(d, "");   
        }
        
        public bool IxStart(string str)
        {
            if (str.Length > 2 && str.Substring(1, 2) == "ix")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string StartOz(string str)
        {
            string zero = "";
            string one = "";
            if (str.Length>0 && str[0]=='o')
            {
                zero = "o";
            }
            if (str.Length>1 && str[1]=='z')
            {
                one = "z";
            }
            return (zero + one);
            throw new NotImplementedException();
        }

        public int Max(int a, int b, int c)
        {
            return Math.Max(a, Math.Max(b, c));
            throw new NotImplementedException();
        }

        public int Closer(int a, int b)
        {
            int A10 = Math.Abs(10 - a);
            int B10 = Math.Abs(10 - b);
            if (A10 > B10)
            {
                return b;
            }
            else if (B10 > A10)
            {
                return a;
            }
            else return 0;
            throw new NotImplementedException();
        }
        
        public bool GotE(string str)
        {
            int eCount = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'e')
                    eCount++;
            }
            return (eCount >= 1 && eCount <= 3);
            throw new NotImplementedException();
        }
        
        public string EndUp(string str)
        {
            if (str.Length > 2)
            {
                string front = str.Substring(0, str.Length - 3);
                string end = str.Substring(str.Length - 3).ToUpper();
                return (front + end);
            }
            else
            {
                return str.ToUpper();
            }
        }

        public string EveryNth(string str, int n)
        {
            string NewNth = "";
            for (int i = 0 ;i < str.Length; i+=n)
            {
                NewNth += str.Substring(i, 1);
            }
            return NewNth;
            throw new NotImplementedException();
        }
    }
}
