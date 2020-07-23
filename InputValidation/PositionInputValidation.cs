using System.Linq;

namespace MarsApp.InputValidation
{
    class PositionInputValidation : IInputValidation
    {
        private readonly string _input;

        public PositionInputValidation(string input)
        {
            _input = input;
        }
        
        public bool IsValid()
        {
            if (string.IsNullOrEmpty(_input))
            {
                return false;
            }
            
            var inputValues = _input.Split(" ");

            if (inputValues.Length != 3)
            {
                return false;
            }

            for (var i = 0; i < 2; i++)
            {
                var number = 0;
                var isParseable = int.TryParse(inputValues[i], out number);
                if (isParseable == false)
                {
                    return false;
                }
            }
            
            string[] directions = {"N", "E", "S", "W"};

            return directions.Contains(inputValues[2]);
        }
    }
}