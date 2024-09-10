namespace ProjectEulerProblems
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TenThousandAndFirstPrime());
        }

        static List<int> GetMultiplesOfTwoNumbers(int num1 = 3, int num2 = 5, int highestNumber = 1000)
        {
            List<int> multiplesOfNumbers = new List<int>();

            for (int i = 0; i < highestNumber; i++)
            {
                if (i % num1 == 0 || i % num2 == 0)
                {
                    multiplesOfNumbers.Add(i);
                }
            }
            return multiplesOfNumbers;
        }

        static int GetSumOfEvenFibonacciNumbers(int stopValue)
        {
            List<int> fibonacciNumbers = new List<int> { 1, 2 };
            int sum = 2;

            while (fibonacciNumbers[fibonacciNumbers.Count-1] < stopValue)
            {
                fibonacciNumbers.Add(fibonacciNumbers[fibonacciNumbers.Count-1] + fibonacciNumbers[fibonacciNumbers.Count-2]);
                if (fibonacciNumbers[fibonacciNumbers.Count-1] % 2 == 0)
                {
                    sum += fibonacciNumbers[fibonacciNumbers.Count-1];
                }
            }
            return sum;
        }

        static (int, int) LargestPalindromeProduct()
        {
            int largestI = 0;
            int largestJ = 0;
            for (int i = 100; i < 1000; i++)
            {
                for (int j = 100; j < 1000; j++)
                {
                    if(CheckIfPalindrome((i * j).ToString()))
                    {
                        largestI = i;
                        largestJ = j;
                    }
                }
            }
            return (largestI, largestJ);
        }

        static bool CheckIfPalindrome(string input)
        {
            char[] charArr = input.ToCharArray();
            char[] reverseCharArr = new char[charArr.Length];

            for (int i = 0; i < charArr.Length; i++)
            {
                char tempC1 = charArr[i];
                char tempC2 = charArr[charArr.Length - i - 1];
                reverseCharArr[charArr.Length - i - 1] = tempC1;
                reverseCharArr[i] = tempC2;
            }
            string reverseS = new string(reverseCharArr);
            if (input == reverseS)
            {
                return true;
            }
            return false;
        }

        static int GetLowestNumberDivisibleByInput(int[] numbers)
        {
            int lowestDivisible = 1;
            while(true)
            {
                for (int i = 1; i <= numbers.Length-1; i++)
                {
                    if(lowestDivisible % numbers[i] != 0)
                    {
                        i = 0;
                        lowestDivisible++;
                    }
                }
                return lowestDivisible;
            }
        }

        static (int[], ulong) GetHighestProductOfAdjacentNumbersInSeries(string series, int groupingSize = 13)
        {
            int[] seriesArr = series.ToString().Select(o => Convert.ToInt32(o) - 48).ToArray();
            int[] highestProductGroup = new int[groupingSize];
            ulong highestProduct = 0;

            for (int i = 0; i < seriesArr.Length - groupingSize + 1; i++)
            {
                ulong currentProduct = 1;

                int[] currentGroup = new int[groupingSize];

                for (int j = 0; j < groupingSize; j++)
                {
                    currentProduct *= (ulong)seriesArr[i + j];

                    currentGroup[j] = seriesArr[i + j];
                }

                if (currentProduct > highestProduct)
                {
                    highestProductGroup = currentGroup;
                    highestProduct = currentProduct;
                }
            }
            return (highestProductGroup, highestProduct);
        }

        static int SpecialPythagoreanTriplet()
        {
            int c;

            for (int a = 0; a < 1000; a++)
            {
                for (int b = 0; b < 500; b++)
                {
                    c = 1000 - a - b;
                    if(Math.Pow(a,2) + Math.Pow(b,2) == Math.Pow(c,2))
                    {
                        return a * b * c;
                    }
                }
            }
            return 0;
        }

        static int TenThousandAndFirstPrime()
        {
            int primeCount = 0;
            bool[] primesArr = SieveOfEratosthenes(110000);
            for (int i = 0; i < primesArr.Length; i++)
            {
                if (primesArr[i])
                {
                    primeCount++;
                }
                if (primeCount == 10001)
                {
                    return i;
                }
            }

            return 0;
        }

        static long SumOfPrimesUnderTwoMillion()
        {
            long sum = 0;
            bool[] arrOfPrimes = SieveOfEratosthenes(2000000);

            for (int i = 0; i < arrOfPrimes.Length; i++)
            {
                if (arrOfPrimes[i])
                {
                    sum += i;
                }
            }
            return sum;
        }
        
        static bool[] SieveOfEratosthenes(int maxNumber)
        {
            bool[] primes = new bool[maxNumber+1];

            for (int i = 2; i < primes.Length; i++)
            {
                primes[i] = true;
            }

            for (int i = 2; i < Math.Sqrt(maxNumber)+1; i++)
            {
                if (primes[i])
                {
                    for (int j = (int)Math.Pow(i,2); j <= maxNumber; j+=i)
                    {
                        primes[j] = false;
                    }
                }
            }
            return primes;
        }
    }
}
