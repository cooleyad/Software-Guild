using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups.BLL
{
    public class Logic
    {

        public bool GreatParty(int cigars, bool isWeekend)
        {
            bool GreatParty = cigars >= 40;
                if (!isWeekend && GreatParty)
            {
                GreatParty = cigars <= 60;
            }
            return GreatParty;

            throw new NotImplementedException();
        }
        
        public int CanHazTable(int yourStyle, int dateStyle)
        {
            if (yourStyle <=2 || dateStyle <=2)
            {
                return 0;
            }
            if (yourStyle >= 8 || dateStyle >= 8)
            {
                return 2;
            }
            else return 1;
            throw new NotImplementedException();
        }

        public bool PlayOutside(int temp, bool isSummer)
        {
            bool IsSummer =(temp >=60 && temp <=100);
            if (temp <= 90 && temp >= 60)
            {
                return true;
            }
            else return isSummer;
            throw new NotImplementedException();
        }
        
        public int CaughtSpeeding(int speed, bool isBirthday)
        {
            int regspeed = 60;
            int highspeed = 80;
            bool CaughtSpeeding = ((speed > regspeed) && (speed > highspeed));
            if ((!isBirthday) && (speed > regspeed))
            {
                return 1;
            }
            else return 0;
            throw new NotImplementedException();
        }
        
        public int SkipSum(int a, int b)
        {
            int sum = a + b;
            if ((a + b) >= 10 && (a + b) <= 19)
            {
                return 20;
            }
            else return sum;
            throw new NotImplementedException();
        }
        
        public string AlarmClock(int day, bool vacation)
        {
            switch (day)
            {
                case 0:
                    return (vacation) ? "off" : "10:00";
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    return (vacation) ? "10:00" : "7:00";
                default:
                    return (vacation) ? "off" : "10:00";
            }
            throw new NotImplementedException();
        }
        
        public bool LoveSix(int a, int b)
        {
            if ((a == 6) || (b == 6) || ((a + b) == 6))
            {
                return true;
            }
            else return false;
            throw new NotImplementedException();
        }
        
        public bool InRange(int n, bool outsideMode)
        {
            return outsideMode ? (n <= 1 || n >= 10) : (n >= 1 && n <= 10);
        }

        public bool SpecialEleven(int n)
        {
            if ((n % 11 == 0) || (n % 11 == 1))
            {
                return true;
            }
            else return false;
            throw new NotImplementedException();
        }
        
        public bool Mod20(int n)
        {
            bool Mod20 = false;
            if ((n%20==1) || (n%20==2))
            {
                Mod20 = true;
            }
            return Mod20;
            throw new NotImplementedException();
        }
        
        public bool Mod35(int n)
        {
            bool Mod35 = true;
            if ((n % 3 == 0) && (n % 5 == 0))
            {
                Mod35 = false;
            }
            return Mod35;
            throw new NotImplementedException();
        }
        
        public bool AnswerCell(bool isMorning, bool isMom, bool isAsleep)
        {
            bool AnswerCell = true;
            if ((!isMom && isMorning) || (isAsleep))
            {
                AnswerCell = false;
            }
            return AnswerCell;
            throw new NotImplementedException();
        }
        
        public bool TwoIsOne(int a, int b, int c)
        {
            bool TwoIsOne = false;
            if ((a+b==c) || (b+c==a) || (c+a==b))
            {
                TwoIsOne = true;
            }
            return TwoIsOne;
            throw new NotImplementedException();
        }
        
        public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            bool AreInOrder = false;
            if ((b>a) && (c>b) || (bOk))
            {
                AreInOrder = true;
            }
            return AreInOrder;
            throw new NotImplementedException();
        }
        
        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            bool InOrderEqual = false;
            if ((a<=b) && (b<=c) || (equalOk))
            {
                InOrderEqual = true;
            }
            return InOrderEqual;
            throw new NotImplementedException();
        }
        
        public bool LastDigit(int a, int b, int c)
        {
            int Adiv = (a / 10) * 10;
            int Bdiv = (b / 10) * 10;
            int Cdiv = (c / 10) * 10;

            int aLast = a - Adiv;
            int bLast = b - Bdiv;
            int cLast = c - Cdiv;
            bool LastDigit = false;
            if ((aLast==bLast) || (bLast==cLast) || (aLast==cLast))
            {
                LastDigit = true;
            }
            return LastDigit;
            throw new NotImplementedException();
        }
        
        public int RollDice(int die1, int die2, bool noDoubles)
        {
            
            if (noDoubles && ((die1)==(die2)))
            {
                if (die1==6)
                {
                    die1 = 1;
                }
                else
                {
                    die1++;
                }
            }
            return die1 + die2;
            throw new NotImplementedException();
        }

    }
}
