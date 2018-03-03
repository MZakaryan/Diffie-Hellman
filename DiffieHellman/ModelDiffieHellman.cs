using System.Numerics;

namespace DiffieHellman
{
    class ModelDiffieHellman
    {
        public static readonly int P;
        public static readonly int G;

        private static int _currentCount;

        private int _secureInteger;
        public int _securKey; // Change access modifier to private
        private int _countOdSides;

        static ModelDiffieHellman()
        {
            P = Helper.GetPrimitiveInt(10,50);
            G = Helper.GetPrimitiveIntSQRT(P);
            _currentCount = 0;
        }

        public ModelDiffieHellman(int count)
        {
            _secureInteger = Helper.GetPrimitiveInt(1000, 4000);
            _countOdSides = count;
        }

        public int AccountOpenKey()
        {
            _currentCount++;
            return (int)(BigInteger.Pow(G, _secureInteger) % P);
        }

        public int AccountOpenKey(int openKey)
        {
            _currentCount++;
            if (_currentCount == _countOdSides)
            {
                _securKey = (int)(BigInteger.Pow(openKey, _secureInteger) % P);
                _currentCount = 0;
            }
            return (int)(BigInteger.Pow(openKey, _secureInteger) % P);
        }
    }
}