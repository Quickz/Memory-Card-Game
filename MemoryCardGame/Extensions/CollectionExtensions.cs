﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemoryCardGame.Extensions
{
    public static class CollectionExtensions
    {
        private static Random random = new Random();

        public static void Shuffle<T>(this T[,] array, Random random = null)
        {
            if (random == null)
            {
                random = CollectionExtensions.random;
            }

            int lengthRow = array.GetLength(1);

            for (int i = array.Length - 1; i > 0; i--)
            {
                int i0 = i / lengthRow;
                int i1 = i % lengthRow;

                int j = random.Next(i + 1);
                int j0 = j / lengthRow;
                int j1 = j % lengthRow;

                T temp = array[i0, i1];
                array[i0, i1] = array[j0, j1];
                array[j0, j1] = temp;
            }
        }
    }
}
