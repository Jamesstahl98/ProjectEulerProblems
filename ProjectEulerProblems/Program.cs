namespace ProjectEulerProblems
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LargestPalindromeProduct());
            //(int[] highestSumGroup, ulong highestSum) = GetHighestSumOfAdjacentNumbersInSeries("7316717653133062491922511967442657474235534919493496983520312774506326239578318016984801869478851843858615607891129494954595017379583319528532088055111254069874715852386305071569329096329522744304355766896648950445244523161731856403098711121722383113622298934233803081353362766142828064444866452387493035890729629049156044077239071381051585930796086670172427121883998797908792274921901699720888093776657273330010533678812202354218097512545405947522435258490771167055601360483958644670632441572215539753697817977846174064955149290862569321978468622482839722413756570560574902614079729686524145351004748216637048440319989000889524345065854122758866688116427171479924442928230863465674813919123162824586178664583591245665294765456828489128831426076900422421902267105562632111110937054421750694165896040807198403850962455444362981230987879927244284909188845801561660979191338754992005240636899125607176060588611646710940507754100225698315520005593572972571636269561882670428252483600823257530420752963450");
            //
            //Console.Write("The numbers in the group with the highest product are:");
            //for (int i = 0; i < highestSumGroup.Length; i++)
            //{
            //    Console.Write($" {highestSumGroup[i]} ");
            //}
            //Console.WriteLine();
            //Console.WriteLine($"The sum is {highestSum}");
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

        static (int[], ulong) GetHighestSumOfAdjacentNumbersInSeries(string series, int groupingSize = 13)
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
    }
}
