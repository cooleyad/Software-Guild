using System;

namespace Warmups.BLL
{
    public class Strings
    {

        public string SayHi(string name)
        {
            return "Hello " + name + "!";
        }

        public string Abba(string a, string b)
        {
            string wunwun = a + b + b + a;
            return wunwun;
            throw new NotImplementedException();
        }

        public string MakeTags(string tag, string content)
        {
            string blerp = string.Format("<{0}>{1}</{0}>", tag, content);
            return blerp;
            throw new NotImplementedException();
        }

        public string InsertWord(string container, string word)
        {
            return container.Insert(2, word);
            throw new NotImplementedException();
        }

        public string MultipleEndings(string str)
        {
            string nerd = str.Substring(str.Length - 2);
            return (nerd + nerd + nerd);
            throw new NotImplementedException();
        }

        public string FirstHalf(string str)
        {
            int halvzies = str.Length / 2;
            return str.Substring(0, halvzies);
            throw new NotImplementedException();
        }

        public string TrimOne(string str)
        {
            string FirstOut = str.Substring(1, str.Length - 2);
            return FirstOut;
            throw new NotImplementedException();
        }

        public string LongInMiddle(string a, string b)
        {
            if (a.Length > b.Length)
            {
                return (b + a + b);
            }
            else return (a + b + a);
            throw new NotImplementedException();
        }

        public string RotateLeft2(string str)
        {
            string Left = str.Substring(0, 2);
            string Right = str.Substring(2);
            return Right + Left;
            throw new NotImplementedException();
        }

        public string RotateRight2(string str)
        {
            string right = str.Substring(str.Length - 2);
            string left = str.Substring(0, str.Length - 2);
            return right + left;
            throw new NotImplementedException();
        }

        public string TakeOne(string str, bool fromFront)
        {
            string Only1 = str.Substring(str.Length - 1);
            string Front1 = str.Substring(0, 1);
            if (fromFront)
            {
                return Front1;
            }
            else
            {
                return Only1;
            }
            throw new NotImplementedException();
        }

        public string MiddleTwo(string str)
        {
            int TheMiddle = (str.Length - 2) / 2;
            string midstring = str.Substring(TheMiddle, 2);
            return midstring;
            throw new NotImplementedException();
        }

        public bool EndsWithLy(string str)
        {
            bool EndsWith = false;
            if (str.EndsWith("ly"))
            {
                EndsWith = true;
            }
            return EndsWith;

            throw new NotImplementedException();
        }

        public string FrontAndBack(string str, int n)
        {
            string bump = str.Substring(0, n);
            string rump = str.Substring(str.Length - n);
            return bump + rump;
            throw new NotImplementedException();
        }

        public string TakeTwoFromPosition(string str, int n)
        {
            if (n > str.Length - 2)
            {
                return str.Substring(0, 2);
            }
            else return str.Substring(n, 2);
            throw new NotImplementedException();
        }

        public bool HasBad(string str)
        {
            if ((str.IndexOf("bad") == 0) || (str.IndexOf("bad") == 1))
            {
                return true;
            }
            else return false;
            throw new NotImplementedException();
        }

        public string AtFirst(string str)
        {
            int NumOfAts = 0;
            if (str.Length<2)
            {
                NumOfAts = 2 - str.Length;
                for (int i = 0; i < NumOfAts; i++)
                {
                    str += "@";
                }
            }
            else
            {
                str=str.Substring(0, 2);
            }
            return str;
            throw new NotImplementedException();
        }

        public string LastChars(string a, string b)
        {
            if (a == "") a = "@";
            if (b == "") b = "@";
            return a.Substring(0, 1) + b.Substring(b.Length - 1);
            throw new NotImplementedException();
        }

        public string ConCat(string a, string b)
        {
            string newString = a + b;
            if (a.Length < 1 || b.Length < 1) return newString;
            if (newString[a.Length - 1] == newString[a.Length])
                return newString.Remove(a.Length, 1);
            return newString;
            throw new NotImplementedException();
        }

        public string SwapLast(string str)
        {
            if (str.Length>=2)
            {
                string begin = str.Substring(0, str.Length - 2);
                string sndlast = str[str.Length-2].ToString();
                string last = str.Substring(str.Length - 1).ToString();
                str = begin + last + sndlast;
            }
            return str;
            throw new NotImplementedException();
        }

        public bool FrontAgain(string str)
        {
            bool Front = false;
            if (str.EndsWith(str.Substring(0, 2)))
            {
                Front = true;
            }
            return Front;
                throw new NotImplementedException();
        }

        public string MinCat(string a, string b)
        {
            if (a.Length > b.Length)
            {
                a = a.Substring(a.Length - b.Length);
            }
            else
            {
                b = b.Substring(b.Length - a.Length);
            }
            return a + b;
        }

        public string TweakFront(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                if (str.Length >= 2 && str[1] != 'b')
                {
                    str=str.Remove(1, 1);
                }
                if (str.Length>=1 && str[0] !='a')
                {
                    str=str.Remove(0, 1);
                }
            }
            return str;
                throw new NotImplementedException();
        }

        public string StripX(string str)
        {
            return str.Trim(new[] { 'x' });
            throw new NotImplementedException();
        }
    }
}
