﻿using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Numerics;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using static ProjectEulerProblems.Program;

namespace ProjectEulerProblems
{
    internal class Program
    {
        /************************LATTICEPATHS************************/
        static Dictionary<string, long> pathsDictionary = new Dictionary<string, long>();
        static int gridSize = 20;

        /************************CountingSundays************************/
        static DateTime startDate = new DateTime(1901, 1, 1);
        static DateTime endDate = new DateTime(2000, 12, 31);
        static (int, int, int) startDateTuple = (1901, 1, 1);
        static (int, int, int) endDateTuple = (2000, 12, 31);

        static void Main(string[] args)
        {

            /*Console.WriteLine(GetFirstTenDigitsOfSum(@"371072875339021027.98797998220837590246510135740250 
463769376774900097.12648124896970078050417018260538 
743249861995247410.59474233309513058123726617309629 
919422133635741615.72522430563301811072406154908250 
230675882075393461.71171980310421047513778063246676 
892616706966236338.20136378418383684178734361726757 
281128798128499794.08065481931592621691275889832738 
442742289174325203.21923589422876796487670272189318 
474514457360013064.39091167216856844588711603153276 
703864861058430254.39939619828917593665686757934951 
621764571418565606.29502157223196586755079324193331 
649063524627419049.29101432445813822663347944758178 
925758677183372176.61963751590579239728245598838407 
582035653253593990.08402633568948830189458628227828 
801811993848262820.14278194139940567587151170094390 
353986643728271126.53829987240784473053190104293586 
865155060062958648.61532075273371959191420517255829 
716938887077154664.99115593487603532921714970056938 
543700705768266846.24621495650076471787294438377604 
532826541087568284.43191190634694037855217779295145 
361232725250002960.71075082563815656710885258350721 
458765761724109764.47339110607218265236877223636045 
174237069058518606.60448207621209813287860733969412 
811426604180868306.19328460811191061556940512689692 
519343254517283886.41918047049293215058642563049483 
624672216484350762.01727918039944693004732956340691 
157324443869081257.94514089057706229429197107928209 
550376875256787730.91862540744969844508330393682126 
183363848253301546.86196124348767681297534375946515 
803862875928784902.01521685554828717201219257766954 
781828337579931036.14740356856449095527097864797581 
167263201004368978.42553539920931837441497806860984 
484030981290777917.99088218795327364475675590848030 
870869875513927118.54517078544161852424320693150332 
599594068957565367.82107074926966537676326235447210 
697939506796526947.42597709739166693763042633987085 
410526847082990852.11399427365734116182760315001271 
653786073615010808.57009149939512557028198746004375 
358290353174347173.26932123578154982629742552737307 
949537597651053059.46966067683156574377167401875275 
889028025717332296.19176668713819931811048770190271 
252676802760780030.13678680992525463401061632866526 
362702185404977055.85629946580636237993140746255962 
240744869082311749.77792365466257246923322810917141 
914302881971032885.97806669760892938638285025333403 
344130655780161278.15921815005561868836468420090470 
230530811728164304.87623791969842487255036638784583 
114876969321549028.10424020138335124462181441773470 
637832994906362596.66498587618221225225512486764533 
677201869716985443.12419572409913959008952310058822 
955482553002635207.81532296796249481641953868218774 
760853271322857231.10424803456124867697064507995236 
377742425354112916.84276865538926205024910326572967 
237019132757256752.85653248258265463092207058596522 
297988602722583319.13126375147341994889534765745501 
184957014548792889.84856827726077713721403798879715 
382982037830314735.27721580348144513491373226651381 
348295438291999181.80278916522431027392251122869539 
409579530664052326.32538044100059654939159879593635 
297461521855023713.07642255121183693803580388584903 
416981162220729771.86158236678424689157993532961922 
624679571944012690.43877107275048102390895523597457 
231897067725479150.61505504953922979530901129967519 
861880882258753145.29584099251203829009407770775672 
113067397083047244.83816533873502340845647058077308 
829591747671403631.98008187129011875491310547126581 
976233310448183862.69515456334926366572897563400500 
428462801835170705.27831839425882145521227251250327 
551216035469812005.81762165212827652751691296897789 
322381957343293399.46437501907836945765883352399886 
755061649651847751.80738168837861091527357929701337 
621778427521926234.01942399639168044983993173312731 
329241857071473495.66916674687634660915035914677504 
995186714302352196.28894890102423325116913619626622 
732674608005915474.71830798392868535206946944540724 
768418225246744171.61514036427982273348055556214818 
971426179103425986.47204516893989422179826088076852 
877836461827993463.13767754307809363333018982642090 
108488025216746708.83215120185883543223812876952786 
713296124747824645.38636993009049310363619763878039 
621840735723997942.23406235393808339651327408011116 
666278919814880877.97941876876144230030984490851411 
606618262936828367.64744779239180335110989069790714 
857869440895529906.53640447425576083659976645795096 
660243964099053896.07120198219976047599490197230297 
649139826800329731.56037120041377903785566085089252 
167309393198727502.75468906903707539413042652315011 
948093772450487951.50954100921645863754710598436791 
786391670211874924.31995700641917969777599028300699 
153687137119366149.52811305876380278410754449733078 
407899231155355625.61142322423255033685442488917353 
448899115014406480.20369068063960672322193204149535 
415031288803395360.53299340368006977710650566631954 
812348806732101467.39058568557934581403627822703280 
826165707739483275.92232845941706525094512325230608 
229188020587773197.19839450180888072429661980811197 
771585425020165450.90413245809786882778948721859617 
721078384350691861.55435662884062257473692284509516 
208496039801340017.23930671666823555245252804609722 
535035342264725242.50874054075591789781264330331690"));*/

            Console.WriteLine(ReciprocalCycles());
            Console.ReadLine();
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

        static int HighlyDivisibleTriangularNumber()
        {
            int triangularnum = 1;
            for (int num = 2; num > 0; num++)
            {
                if (Has501Divisors(triangularnum))
                {
                    return triangularnum;
                }
                triangularnum += num;
            }

            return 0;
        }

        static bool Has501Divisors(int numToCheck)
        {
            int count = 0;
            for (int i = 1; i < Math.Sqrt(numToCheck); i++)
            {
                if (numToCheck % i == 0)
                {
                    count += 2;
                }

                if (count > 500)
                {
                    return true;
                }
            }
            return false;
        }

        static string GetFirstTenDigitsOfSum(string input)
        {
            string[] stringArr = input.Split(' ');
            decimal[] decimalArr = new decimal [stringArr.Length];
            decimal sum = 0;

            for (int i = 0; i < stringArr.Length; i++)
            {
                decimalArr[i] = decimal.Parse(stringArr[i]);
            }

            for (int i = 0; i < decimalArr.Length; i++)
            {
                sum += decimalArr[i];
            }
            return sum.ToString().Substring(0, 10);
        }

        static ulong GetLongestCollatzSequence()
        {
            int highestSteps = 0;
            ulong highestCollatzStartNumber = 0;

            for (ulong i = 1; i < 999999; i++)
            {
                (ulong startNumber, int steps) = GetNumberOfCollatzSequenceSteps(i);

                if(steps > highestSteps)
                {
                    highestSteps = steps;
                    highestCollatzStartNumber = startNumber;
                }
            }
            return highestCollatzStartNumber;
        }

        static long GetRemainingSurface(long x, long y)
        {
            return (gridSize - x) * (gridSize - y);
        }

        static long LatticePaths(int x = 0, int y = 0)
        {
            long surface = GetRemainingSurface(x, y);
            long paths = 0;

            if (surface == 0)
            {
                return 1;
            }

            string block = (gridSize - x) + "x" + (gridSize - y);

            if(!pathsDictionary.ContainsKey(block))
            {
                if (x<gridSize)
                {
                    paths += LatticePaths(x + 1, y);
                }
                if(y<gridSize)
                {
                    paths += LatticePaths(x, y + 1);
                }
                pathsDictionary[block] = paths;
            }
            return pathsDictionary[block];
        }

        static (ulong, int) GetNumberOfCollatzSequenceSteps(ulong startNumber)
        {
            int steps = 0;
            ulong number = startNumber;

            while (number != 1)
            {
                if(number % 2 == 0)
                {
                    number /= 2;
                }

                else if(number>1)
                {
                    number = number * 3 + 1;
                }
                steps++;
            }
            return (startNumber, steps);
        }

        static int PowerDigitSum(UInt128 number)
        {
            int sum = 0;
            number = (UInt128)Math.Pow(2, (double)number);
            char[] charArr = number.ToString().ToCharArray();
            
            for (int i = 0; i < charArr.Length; i++)
            {
                sum += (charArr[i] - '0');
            }

            return sum;
        }

        static int[] GetArrayOfInts(int number)
        {
            int[] digits = number.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();
            return digits;
        }

        static int ConvertIntToNumberOfCharacters(int number)
        {
            string[] digitStrings = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            string[] tenToNineteenStrings = { "", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            string[] DigitTimesTenStrings = { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            int[] numberIntArr = GetArrayOfInts(number);
            List<String> stringList = new List<String>();

            for (int i = 0; i < numberIntArr.Length; i++)
            {
                stringList.Add(digitStrings[numberIntArr[i]]);
                if (numberIntArr.Length == 5)
                {
                    switch (i)
                    {
                        case 0:
                            stringList[i] = DigitTimesTenStrings[numberIntArr[i]];
                            break;
                        case 1:
                            if (numberIntArr[i - 1] == 1 && numberIntArr[i] != 0)
                            {
                                stringList[i] = tenToNineteenStrings[numberIntArr[i]];
                                stringList[i - 1] = "";
                            }
                            stringList[i] += "thousand";
                            break;
                        case 2:
                            if (numberIntArr[i] != 0)
                                stringList[i] += "hundred";
                            break;
                        case 3:
                            stringList[i] = DigitTimesTenStrings[numberIntArr[i]];
                            break;
                        case 4:
                            if (numberIntArr[i - 1] == 1 && numberIntArr[i] != 0)
                            {
                                stringList[i] = tenToNineteenStrings[numberIntArr[i]];
                                stringList[i - 1] = "";
                            }
                            break;
                    }
                }

                if (numberIntArr.Length == 4)
                {
                    switch (i)
                    {
                        case 0:
                            stringList[i] += "thousand";
                            break;
                        case 1:
                            if (numberIntArr[i] != 0)
                                stringList[i] += "hundred";
                            break;
                        case 2:
                            stringList[i] = DigitTimesTenStrings[numberIntArr[i]];
                            break;
                        case 3:
                            if (numberIntArr[i - 1] == 1 && numberIntArr[i] != 0)
                            {
                                stringList[i] = tenToNineteenStrings[numberIntArr[i]];
                                stringList[i - 1] = "";
                            }
                            break;
                    }
                }

                if (numberIntArr.Length == 3)
                {
                    switch (i)
                    {
                        case 0:
                            if (numberIntArr[i] != 0)
                                stringList[i] += " hundred";
                            break;
                        case 1:
                            stringList[i] = DigitTimesTenStrings[numberIntArr[i]];
                            break;
                        case 2:
                            if (numberIntArr[i - 1] == 1 && numberIntArr[i] != 0)
                            {
                                stringList[i] = tenToNineteenStrings[numberIntArr[i]];
                                stringList[i - 1] = "";
                            }
                            break;
                    }
                }

                if (numberIntArr.Length == 2)
                {
                    switch (i)
                    {
                        case 0:
                            stringList[i] = DigitTimesTenStrings[numberIntArr[i]];
                            break;
                        case 1:
                            if (numberIntArr[i - 1] == 1 && numberIntArr[i] != 0)
                            {
                                stringList[i] = tenToNineteenStrings[numberIntArr[i]];
                                stringList[i - 1] = "";
                            }
                            break;
                    }
                }
            }

            int sum = 0;

            if (stringList.Count >2 && (stringList[stringList.Count - 1] != "" && stringList[stringList.Count - 2] != ""))
            {
                sum += 3;
            }
            stringList = stringList.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            
            string finalString = string.Join(" ", stringList);

            for (int i = 0; i < finalString.Length; i++)
            {
                if (finalString[i] != ' ')
                {
                    sum++;
                }
            }
            return sum;
        }

        static int MaximumPathSum1()
        {
            int[][] triangle = GetTriangle();

            for (int rowI = triangle.Length - 2; rowI >= 0; rowI--)
            {
                int[] row = triangle[rowI];
                for (int colI = 0; colI < row.Length; colI++)
                {
                    row[colI] += Math.Max(
                        triangle[rowI + 1][colI],
                        triangle[rowI + 1][colI + 1]
                    );
                }
            }
            return triangle[0][0];
        }

        static int[][] GetTriangle()
        {
            return new int[][]
            {
            new int[] { 75 },
            new int[] { 95, 64 },
            new int[] { 17, 47, 82 },
            new int[] { 18, 35, 87, 10 },
            new int[] { 20,  4, 82, 47, 65 },
            new int[] { 19,  1, 23, 75,  3, 34 },
            new int[] { 88,  2, 77, 73,  7, 63, 67 },
            new int[] { 99, 65,  4, 28,  6, 16, 70, 92 },
            new int[] { 41, 41, 26, 56, 83, 40, 80, 70, 33 },
            new int[] { 41, 48, 72, 33, 47, 32, 37, 16, 94, 29 },
            new int[] { 53, 71, 44, 65, 25, 43, 91, 52, 97, 51, 14 },
            new int[] { 70, 11, 33, 28, 77, 73, 17, 78, 39, 68, 17, 57 },
            new int[] { 91, 71, 52, 38, 17, 14, 91, 43, 58, 50, 27, 29, 48 },
            new int[] { 63, 66,  4, 68, 89, 53, 67, 30, 73, 16, 69, 87, 40, 31 },
            new int[] {  4, 62, 98, 27, 23,  9, 70, 98, 73, 93, 38, 53, 60,  4, 23 }
            };
        }

        static int CountingSundaysUsingDateTime(DateTime startDate, DateTime endDate)
        {
            int sundays = 0;
            DateTime currentDate = startDate;

            while(currentDate < endDate)
            {
                if (currentDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    sundays++;
                }
                currentDate = currentDate.AddMonths(1);
            }
            return sundays;
        }

        static int CountingSundaysNoDateTime((int year, int month, int day) startDate, (int year, int month, int day) endDate)
        {
            int sundays = 0;
            int daysUntilSunday = 5;

            int[] monthDays = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            (int year, int month, int day) currentDate = startDate;

            while (currentDate.year <= endDate.year)
            {
                currentDate.day++;
                daysUntilSunday--;

                if(currentDate.day > monthDays[currentDate.month-1])
                {
                    currentDate.day = 1;
                    currentDate.month++;
                }
                if(currentDate.month > monthDays.Length)
                {
                    currentDate.month = 1;
                    currentDate.year++;
                    if (currentDate.year % 4 == 0 &&
                        (currentDate.year.ToString().Substring(2) != "00" || currentDate.year % 400 == 0))
                    {
                        monthDays[1] = 29;
                    }
                    else
                    {
                        monthDays[1] = 28;
                    }
                }
                if(daysUntilSunday == 0)
                {
                    if(currentDate.day == 1)
                    {
                        sundays++;
                    }
                    daysUntilSunday = 7;
                }
            }

            return sundays;
        }

        static int FactorialDigitSum(BigInteger number)
        {
            BigInteger factorialDigit = 1;
            int sum = 0;

            for (BigInteger i = number; i > 0; i--)
            {
                factorialDigit *= i;
            }

            char[] factorialDigitCharArr = factorialDigit.ToString().ToCharArray();

            for (int i = 0; i < factorialDigitCharArr.Length; i++)
            {
                sum += factorialDigitCharArr[i] - '0';
            }

            return sum;
        }

        static int AmicableNumbers(int input)
        {
            int sum = 0;

            for (int i = 0; i < input; i++)
            {
                int num1 = GetSumOfDivisors(i);
                int num2 = GetSumOfDivisors(GetSumOfDivisors(i));
                
                if (num2 == i && num1 != num2)
                {
                    sum = sum + i;
                }
            }

            return sum;
        }

        static int GetSumOfDivisors(int number)
        {
            int sum = 0;

            for (int i = 1; i <= number/2; i++)
            {
                if(number % i == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }

        static ulong NameScores(string file)
        {
            if (!File.Exists(file))
                return 0;

            ulong totalNameScore = 0;
            string fileContents = File.ReadAllText(file);

            string[] nameArray = fileContents.Split(',');
            Array.Sort(nameArray);

            for (int i = 0; i < nameArray.Length; i++)
            {
                ulong nameScore = 0;
                for (int j = 1; j < nameArray[i].Length-1; j++)
                {
                    nameScore += (ulong)nameArray[i][j] - 64;
                }

                nameScore *= (ulong)i + 1;
                totalNameScore += nameScore;
            }

            return totalNameScore;
        }

        static int NonAbundantSums(int limit = 28123)
        {
            int sum = 0;
            List <int> abundantNumbers = GetAbundantNumbers(limit);

            for (int i = 1; i < limit; i++)
            {
                bool isSumOfAbundantNumber = false;
                for (int j = 0; j < abundantNumbers.Count; j++)
                {
                    if (abundantNumbers[j] >= i)
                    {
                        break;
                    }
                    if (abundantNumbers.Contains(i - abundantNumbers[j]))
                    {
                        isSumOfAbundantNumber = true;
                        break;
                    }
                }
                if(!isSumOfAbundantNumber)
                {
                    sum += i;
                }
            }
            return sum;
        }

        static List<int> GetAbundantNumbers(int limit)
        {
            List<int> abundantNumbers = new();

            for (int i = 1; i < limit; i++)
            {
                int sumOfDivisors = 0;
                for (int j = 1; j <= i/2; j++)
                {
                    if (i % j == 0)
                    {
                        sumOfDivisors += j;
                    }
                }
                if(sumOfDivisors > i)
                {
                    abundantNumbers.Add(i);
                }
            }
            return abundantNumbers;
        }

        static string LexicographicPermutations(string input = "0123456789", int limit = 1000000)
        {
            char[] inputArr = input.ToCharArray();

            int i, j;

            for (int count = 1; count < limit; count++)
            {
                for (i = inputArr.Length - 1; i > 0 && inputArr[i - 1] >= inputArr[i]; i--) ;

                if (i == 0)
                    break;

                for (j = inputArr.Length - 1; j > 0 && inputArr[j] <= inputArr[i - 1]; j--) ;

                char temp = inputArr[i - 1];
                inputArr[i - 1] = inputArr[j];
                inputArr[j] = temp;

                for (j = inputArr.Length - 1; i < j; i++, j--)
                {
                    temp = inputArr[i];
                    inputArr[i] = inputArr[j];
                    inputArr[j] = temp;
                }
            }

            return new string(inputArr);
        }

        static int ThousandDigitFibonacciNumberBigInt()
        {
            int count = 1;
            BigInteger fibonacciNumber = 1;
            BigInteger lastFibonacciNumber = 0;

            while(fibonacciNumber.ToString().Length < 1000)
            {
                count++;

                BigInteger temp = fibonacciNumber;
                fibonacciNumber += lastFibonacciNumber;
                lastFibonacciNumber = temp;
            }

            return count;
        }

        static int ThousandDigitFibonacciNumber()
        {
            int[] fibNumber1 = new int[1000];
            int[] fibNumber2 = new int[1000];
            
            fibNumber1[0] = 1;
            fibNumber2[0] = 1;

            int count = 2;

            while(true)
            {
                count++;

                int[] nextFibNumber = new int[1000];

                int carry = 0;
                for (int i = 0; i < 1000; i++)
                {
                    int sum = fibNumber1[i] + fibNumber2[i] + carry;
                    nextFibNumber[i] = sum % 10;
                    carry = sum / 10;
                }

                if (nextFibNumber[999] != 0)
                {
                    return count;
                }

                fibNumber1 = fibNumber2;
                fibNumber2 = nextFibNumber;
            }
        }

        static int ReciprocalCycles(int limit = 1000)
        {
            int highestCycleLength = 0;

            for (int d = 1; d < limit; d++)
            {
                int currentCycleLength = GetCycleLength(d);
                if(currentCycleLength > highestCycleLength)
                {
                    highestCycleLength = currentCycleLength;
                }
            }
            return highestCycleLength;
        }

        static int GetCycleLength(int divisor)
        {
            Dictionary<int, int> remainderPositions = new();

            int remainder = 1;
            int position = 0;

            while(remainder != 0)
            {
                if (remainderPositions.ContainsKey(remainder))
                {
                    return position - remainderPositions[remainder];
                }

                remainderPositions[remainder] = position;

                remainder = (remainder * 10) % divisor;
                position++;
            }

            return 0;
        }
    }
}
