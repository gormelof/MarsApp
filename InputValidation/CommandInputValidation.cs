using System.Linq;

namespace MarsApp.InputValidation
{
    class CommandInputValidation : IInputValidation
    {
        private readonly string _input;

        public CommandInputValidation(string input)
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

            if (inputValues.Length != 1)
            {
                return false;
            }

            char[] commands = {'L', 'R', 'M'};
            return _input.All(c => commands.Contains(c));
        }
    }
}