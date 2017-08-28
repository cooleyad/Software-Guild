using System;

namespace Warmups.BLL
{
    public class Arrays
    {

        public bool FirstLast6(int[] numbers)
        {
            return numbers[0] == 6 || numbers[numbers.Length - 1] == 6;
            throw new NotImplementedException();
        }

        public bool SameFirstLast(int[] numbers)
        {
            return (numbers[0] == numbers[numbers.Length - 1]);
            throw new NotImplementedException();
        }
        public int[] MakePi(int n)
        {
            int[] PiPiPi = new int[n];
            string digits = Math.PI.ToString().Remove(1, 1);
            for (int i = 0; i < n; i++)
            {
                PiPiPi[i] = (int)(digits[i] - '0');
            }
            return PiPiPi;
            throw new NotImplementedException();
        }
        
        public bool CommonEnd(int[] a, int[] b)
        {
            return a[a.Length - 1] == b[b.Length - 1];
            throw new NotImplementedException();
        }
        
        public int Sum(int[] numbers)
        {
            int car = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                car += numbers[i];
            }
            return car;
            throw new NotImplementedException();
        }
        
        public int[] RotateLeft(int[] numbers)
        {
            int first = numbers[0];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i != (numbers.Length - 1))
                {
                    numbers[i] = numbers[i + 1];
                }
                else
                {
                    numbers[i] = first;
                }
            }
            return numbers;
            throw new NotImplementedException();
        }
        
        public int[] Reverse(int[] numbers)
        {
            Array.Reverse(numbers);
            return numbers;
            throw new NotImplementedException();
        }
        
        public int[] HigherWins(int[] numbers)
        {
            int victory = Math.Max(numbers[0], numbers[numbers.Length - 1]);
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = victory;
            }
            return numbers;
            throw new NotImplementedException();
        }
        
        public int[] GetMiddle(int[] a, int[] b)
        {
            return new[] { a[1], b[1] };
            throw new NotImplementedException();
        }
        
        public bool HasEven(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0) return true;
            }
            return false;
            throw new NotImplementedException();
        }
        
        public int[] KeepLast(int[] numbers)
        {
            int[] result = new int[numbers.Length * 2];
            result[result.Length - 1] = numbers[numbers.Length - 1];
            return result;
            throw new NotImplementedException();
        }
        
        public bool Double23(int[] numbers)
        {
            int twoCount = 0;
            int threeCount = 0;
            foreach (int number in numbers)
            {
                if (number == 2)
                {
                    twoCount++;
                }
                if (number == 3)
                {
                    threeCount++;
                }
            }
            return (twoCount == 2 || threeCount == 2);
            throw new NotImplementedException();
        }
        
        public int[] Fix23(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == 2 && numbers[i + 1] == 3)
                {
                    numbers[i + 1] = 0;
                    i++;
                }
            }
            return numbers;
            throw new NotImplementedException();
        }
        
        public bool Unlucky1(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] == 1 && numbers[i + 1] == 3)
                {
                    return true;
                }
            }
            return false;
            throw new NotImplementedException();
        }
        
        public int[] Make2(int[] a, int[] b)
        {
            int[] c = new int[a.Length + b.Length];
            int indexer = 0;
            for (int i = 0; i < a.Length; i++)
            {
                c[i] = a[i];
                indexer++;
            }
            for (int i = 0; i < b.Length; i++)
            {
                c[i + indexer] = b[i];
            }
            return new int[] { c[0], c[1] };
            throw new NotImplementedException();
        }

    }
}
