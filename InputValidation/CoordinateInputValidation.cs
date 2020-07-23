namespace MarsApp.InputValidation
{
    class CoordinateInputValidation : IInputValidation
    {
        private readonly string _input;

        public CoordinateInputValidation(string input)
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

            if (inputValues.Length != 2)
            {
                return false;
            }

            foreach (string value in inputValues)
            {
                var number = 0;
                var isParseable = int.TryParse(value, out number);
                if (isParseable == false)
                {
                    return false;
                }
            }
            
            return true;
        }
    }
}