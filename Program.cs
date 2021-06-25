using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicSquareHackerRank
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] matriz = new int[3][];
            matriz[0] = new int[3] { 4, 9, 2 };
            matriz[1] = new int[3] { 3, 5, 7 };
            matriz[2] = new int[3] { 8, 1, 5 };

            formingMagicSquare(matriz);
        }

        static int formingMagicSquare(int[][] s)
        {
            int result = 0;
            List<int> listNumbers = new List<int>();
            List<int> myNumbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<int> notThis = new List<int>();

            List<int> sumRow = new List<int>();
            List<int> sumColumn = new List<int>();
            int sumDiagonal = 0;
            int sumDiagonalReverse = 0;
            int indexi = 0;
            int index = 0;
            int indexj = 2;
            int indexR = 2;

            for (int i = 0; i < s[0].Length; i++)
            {
                sumRow.Add(s[i].Sum());

                s[i].ToList().ForEach(x => {
                    if (index == indexi)
                    {
                        sumDiagonal += x;
                        indexi++;
                    }

                    if(indexR == indexj)
                    {
                        sumDiagonalReverse += s[i][indexj];
                        indexj--;
                    }
                    indexR--;
                    listNumbers.Add(x);
                });
                indexi = 0;
                indexj = 2;
                index++;
            }

            List<int> numbersRepeat = NumbersRepeat(listNumbers);

            listNumbers
            .Distinct()
            .OrderBy(x => x)
            .ToList()
            .ForEach(x => {
                notThis = myNumbers.Where(n => !listNumbers.Contains(n)).ToList();
            });

            listNumbers.ForEach(x => Console.WriteLine(x));

            return result;
        }

        static List<int> NumbersRepeat(List<int> listNumbers) => 
            listNumbers.GroupBy(x => x)
            .Where(x => x.Count() > 1)
            .Select(x => x.Key)
            .ToList();
    }
}
