using System;

namespace Warmups.BLL
{
    public class Loops
    {

        public string StringTimes(string str, int n)
        {
            string herng = "";
            for (int i = 0; i < n; i++)
            {
                herng += str;
            }
            return herng;
            throw new NotImplementedException();
        }

        public string FrontTimes(string str, int n)
        {
            string front=(str.Length <= 3) ? str: str.Substring(0, 3);
            return StringTimes(front, n);
            throw new NotImplementedException();
        }

        public int CountXX(string str)
        {
            int xcount = 0;
            while (str.Contains("xx"))
            {
                str = str.Remove(str.IndexOf('x'), 1);
                xcount++;
            }
            return xcount;
            throw new NotImplementedException();
        }

        public bool DoubleX(string str)
        {
            if (str.Contains("x") && str.IndexOf('x') != str.Length - 1)
            {
                int firstX = str.IndexOf('x');
                if (str[firstX + 1] == 'x')
                {
                    return true;
                }
            }
            return false;
        }

        public string EveryOther(string str)
        {
            string other = "";
            for (int i = 0; i < str.Length; i += 2)
            {
                other += str[i];
            }
            return other;
            throw new NotImplementedException();
        }

        public string StringSplosion(string str)
        {
            string burp = "";
            for (int i = 0; i < str.Length; i++)
            {
                burp += str.Substring(0, i + 1);
            }
            return burp;
            throw new NotImplementedException();
        }

        public int CountLast2(string str)
        {
            string lasttwo = str.Substring(str.Length - 2, 2);
            int count = 0;

            str = str.Remove(str.Length - 2);
            while (str.Contains(lasttwo))
            {
                str = str.Remove(str.IndexOf(lasttwo), 1);
                count++;
            }
            return count;
            throw new NotImplementedException();
        }

        public int Count9(int[] numbers)
        {
            int CountNine = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 9)
                    CountNine++;
            }
            return CountNine;
            throw new NotImplementedException();
        }

        public bool ArrayFront9(int[] numbers)
        {
            for (int i = 0; i < numbers.Length && i < 4; i++)
            {
                if (numbers[i] == 9)
                    return true;
            }
            return false;
            throw new NotImplementedException();
        }

        public bool Array123(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if (numbers[i] == 1 && numbers[i + 1] == 2 && numbers[i + 2] == 3)
                    return true;
            }
            return false;
            throw new NotImplementedException();
        }

        public int SubStringMatch(string a, string b)
        {
            int matchCount = 0;
            for (int i = 0; i < Math.Min(a.Length, b.Length) - 1; i++)
            {
                if (a[i] == b[i] && a[i + 1] == b[i + 1]) matchCount++;
            }
            return matchCount;
            throw new NotImplementedException();
        }

        public string StringX(string str)
        {
            string bork = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (i == 0 || i == str.Length - 1 || str[i] != 'x')
                    bork += str[i];
            }
            return bork;
            throw new NotImplementedException();
        }

        public string AltPairs(string str)
        {
            string result = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (i % 4 == 0 || i % 4 == 1)
                {
                    result += str[i];
                }
            }
            return result;
            throw new NotImplementedException();
        }

        public string DoNotYak(string str)
        {
            return System.Text.RegularExpressions.Regex.Replace(str, $"y.k", "");
            throw new NotImplementedException();
        }

        public int Array667(int[] numbers)
        {
            int numeric = 0;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == 6 && (numbers[i + 1] == 6 || numbers[i + 1] == 7))
                {
                    numeric++;
                }
            }
            return numeric;
            throw new NotImplementedException();
        }

        public bool NoTriples(int[] numbers)
        {
            if (numbers.Length < 3) return true;
            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if ((numbers[i] == numbers[i + 1]) && (numbers[i + 1] == numbers[i + 2])) return false;
            }
            return true;
            throw new NotImplementedException();
        }

        public bool Pattern51(int[] numbers)
        {
            if (numbers.Length < 3) return false;
            for (int i = 0; i < numbers.Length - 2; i++)
            {
                if (numbers[i] + 5 == numbers[i + 1] && numbers[i] - 1 == numbers[i + 2]) return true;
            }
            return false;
            throw new NotImplementedException();
        }

    }
}
