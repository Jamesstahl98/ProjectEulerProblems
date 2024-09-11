namespace ProjectEulerProblems
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetLargestProductInGrid());
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
        //Takes way too long, try find more optimized way
        static int GetLargestProductInGrid()
        {
            string gridString = "08 02 22 97 38 15 00 40 00 75 04 05 07 78 52 12 50 77 91 08\r\n49 49 99 40 17 81 18 57 60 87 17 40 98 43 69 48 04 56 62 00\r\n81 49 31 73 55 79 14 29 93 71 40 67 53 88 30 03 49 13 36 65\r\n52 70 95 23 04 60 11 42 69 24 68 56 01 32 56 71 37 02 36 91\r\n22 31 16 71 51 67 63 89 41 92 36 54 22 40 40 28 66 33 13 80\r\n24 47 32 60 99 03 45 02 44 75 33 53 78 36 84 20 35 17 12 50\r\n32 98 81 28 64 23 67 10 26 38 40 67 59 54 70 66 18 38 64 70\r\n67 26 20 68 02 62 12 20 95 63 94 39 63 08 40 91 66 49 94 21\r\n24 55 58 05 66 73 99 26 97 17 78 78 96 83 14 88 34 89 63 72\r\n21 36 23 09 75 00 76 44 20 45 35 14 00 61 33 97 34 31 33 95\r\n78 17 53 28 22 75 31 67 15 94 03 80 04 62 16 14 09 53 56 92\r\n16 39 05 42 96 35 31 47 55 58 88 24 00 17 54 24 36 29 85 57\r\n86 56 00 48 35 71 89 07 05 44 44 37 44 60 21 58 51 54 17 58\r\n19 80 81 68 05 94 47 69 28 73 92 13 86 52 17 77 04 89 55 40\r\n04 52 08 83 97 35 99 16 07 97 57 32 16 26 26 79 33 27 98 66\r\n88 36 68 87 57 62 20 72 03 46 33 67 46 55 12 32 63 93 53 69\r\n04 42 16 73 38 25 39 11 24 94 72 18 08 46 29 32 40 62 76 36\r\n20 69 36 41 72 30 23 88 34 62 99 69 82 67 59 85 74 04 36 16\r\n20 73 35 29 78 31 90 01 74 31 49 71 48 86 81 16 23 57 05 54\r\n01 70 54 71 83 51 54 69 16 92 33 48 61 43 52 01 89 19 67 48";
            string[] stringArrayRows = gridString.Split("\r\n");
            int[][] jaggedStringGrid = new int[stringArrayRows.Length][];
            int highestProduct = 0;

            for (int i = 0; i < jaggedStringGrid.Length; i++)
            {
                string[] tempStringArr = stringArrayRows[i].Split(' ');
                int[] tempIntArr = new int[jaggedStringGrid.Length];

                for (int j = 0; j < tempStringArr.Length; j++)
                {
                    tempIntArr[j] = Int32.Parse(tempStringArr[j]);
                }

                jaggedStringGrid[i] = tempIntArr;
            }

            for (int i = 0; i < jaggedStringGrid.Length; i++)
            {
                for (int j = 0; j < jaggedStringGrid[0].Length; j++)
                {
                    int highestProductInIndex = GetHighestProductOfJaggedArrayIndex(jaggedStringGrid, i, j);
                    if(highestProductInIndex > highestProduct)
                    {
                        highestProduct = highestProductInIndex;
                    }
                }
            }

            return highestProduct;
        }

        static int GetHighestProductOfJaggedArrayIndex(int[][] jaggedStringGrid, int iIndex, int jIndex)
        {
            int highestProduct = 0;
            if(jIndex < jaggedStringGrid[jIndex].Length-3)
            {
                int productToRight = jaggedStringGrid[iIndex][jIndex] * jaggedStringGrid[iIndex][jIndex + 1] * jaggedStringGrid[iIndex][jIndex + 2] * jaggedStringGrid[iIndex][jIndex + 3];
                
                if (productToRight > highestProduct)
                {
                    highestProduct = productToRight;
                }
            }
            
            if(jIndex > 3)
            {
                int productToLeft = jaggedStringGrid[iIndex][jIndex] * jaggedStringGrid[iIndex][jIndex - 1] * jaggedStringGrid[iIndex][jIndex - 2] * jaggedStringGrid[iIndex][jIndex - 3];
                if (productToLeft > highestProduct)
                {
                    highestProduct = productToLeft;
                }
            }
            
            if(iIndex > 3)
            {
                int sumUp = jaggedStringGrid[iIndex][jIndex] * jaggedStringGrid[iIndex - 1][jIndex] * jaggedStringGrid[iIndex - 2][jIndex] * jaggedStringGrid[iIndex - 3][jIndex];
                if (sumUp > highestProduct)
                {
                    highestProduct = sumUp;
                }
            
                if(jIndex < jaggedStringGrid[jIndex].Length - 3)
                {
                    int productDiagonalUpRight = jaggedStringGrid[iIndex][jIndex] * jaggedStringGrid[iIndex - 1][jIndex + 1] * jaggedStringGrid[iIndex - 2][jIndex + 2] * jaggedStringGrid[iIndex - 3][jIndex + 3];
                    if (productDiagonalUpRight > highestProduct)
                    {
                        highestProduct = productDiagonalUpRight;
                    }
                }
            
                if(jIndex > 3)
                {
                    int productDiagonalUpLeft = jaggedStringGrid[iIndex][jIndex] * jaggedStringGrid[iIndex - 1][jIndex - 1] * jaggedStringGrid[iIndex - 2][jIndex - 2] * jaggedStringGrid[iIndex - 3][iIndex - 3];
                    if (productDiagonalUpLeft > highestProduct)
                    {
                        highestProduct = productDiagonalUpLeft;
                    }
                }
            }
            
            if (iIndex < jaggedStringGrid.Length - 3)
            {
                int sumDown = jaggedStringGrid[iIndex][jIndex] * jaggedStringGrid[iIndex + 1][jIndex] * jaggedStringGrid[iIndex + 2][jIndex] * jaggedStringGrid[iIndex + 3][jIndex];
                if (sumDown > highestProduct)
                {
                    highestProduct = sumDown;
                }
            
                if(jIndex < jaggedStringGrid[jIndex].Length - 3)
                {
                    int productDiagonalDownRight = jaggedStringGrid[iIndex][jIndex] * jaggedStringGrid[iIndex + 1][jIndex + 1] * jaggedStringGrid[iIndex + 2][jIndex + 2] * jaggedStringGrid[iIndex + 3][jIndex + 3];
                    if (productDiagonalDownRight > highestProduct)
                    {
                        highestProduct = productDiagonalDownRight;
                    }
                }
            
                if(jIndex > 3)
                {
                    int productDiagonalDownLeft = jaggedStringGrid[iIndex][jIndex] * jaggedStringGrid[iIndex + 1][jIndex - 1] * jaggedStringGrid[iIndex + 2][jIndex - 2] * jaggedStringGrid[iIndex + 3][jIndex - 3];
                    if (productDiagonalDownLeft > highestProduct)
                    {
                        highestProduct = productDiagonalDownLeft;
                    }
                }
            }
            return highestProduct;
        }
    }
}
