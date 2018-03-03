using System.Collections.Generic;

namespace DiffieHellman
{
    class ControllerDiffieHelman
    {
        private ModelDiffieHellman[] _sides;
        private int _currentNumberOfSide = 0;
        private int _numberOfSide = 0;
        private int _openKey;
        
        private ModelDiffieHellman[] GenerateSides(int count)
        {
            List<ModelDiffieHellman> list = new List<ModelDiffieHellman>();
            for (int i = 0; i < count; i++)
            {
                list.Add(new ModelDiffieHellman(count));
            }
            return list.ToArray();
        }

        public void GenerateSecureKeyForNSides(int count)
        {
            _sides = GenerateSides(count);
            for (int i = 0; i < count; i++)
            {
                _openKey = _sides[_numberOfSide].AccountOpenKey();
                for (int j = 0; j < count - 1; j++)
                {
                    _currentNumberOfSide++;
                    if (_currentNumberOfSide == count)
                    {
                        _currentNumberOfSide = 0;
                    }
                    _openKey = _sides[_currentNumberOfSide].AccountOpenKey(_openKey);
                }
                _numberOfSide++;
                _currentNumberOfSide = _numberOfSide;
            }

            // Delete after preview
            foreach (var item in _sides)
            {
                System.Console.WriteLine(item._securKey);
            }
        }
    }
}
