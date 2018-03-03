using System;
using System.Collections.Generic;

namespace DiffieHellman
{

    static class Helper
    {
        static private Random _random = new Random();

        static public int GetPrimitiveIntSQRT(int p)
        {
            int g = 3;
            for (int i = 4; i < p; i++)
                if (Math.Pow(i, p - 1) % p == 1)
                {
                    bool flag = false;
                    for (int j = 2; j < Math.Sqrt(i) + 1; j++)
                        if (i % j == 0)
                            flag = true;
                    if (!flag)
                        g = i;
                }
            return g;
        }
        static public int GetPrimitiveInt(int startIndex, int endIndex)
        {
            startIndex = startIndex < 2 ? 2 : startIndex;
            List<int> primitiveInt = new List<int>();
            for (int i = startIndex; i <= endIndex; i++)
            {
                bool flag = false;
                for (int j = 2; j < Math.Sqrt(i) + 1; j++)
                    if (i % j == 0)
                        flag = true;
                if (!flag)
                    primitiveInt.Add(i);
                flag = true;
            }
            return primitiveInt[_random.Next(0, primitiveInt.Count)];
        }
    }
}
