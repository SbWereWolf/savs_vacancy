namespace AlienLanguageBL
{
    public class BusinessLogic : IAlienTranslator
    {
        private const char CDefaultSymbol = 'z';

        private readonly char _symbol;

        public BusinessLogic(char symbol = CDefaultSymbol)
        {
            _symbol = symbol;
        }

        public long Translate(string s, long n)
        {
            var input = s;

            var isEmpty = string.IsNullOrWhiteSpace(input);
            var inputLength = 0;
            if (!isEmpty)
            {
                inputLength = input.Length;
            }

            var isExceeds = inputLength > n;
            if (isExceeds)
            {
                var stringLimit = (int)n;
                input = input.Substring(0, stringLimit);
            }

            var integerPartOccurence = CountOccurrences(input);

            var isExistsOccurence = integerPartOccurence > 0;
            long integerPart = 0;
            long fractionalPart = 0;
            if (isExistsOccurence)
            {
                integerPart = n / inputLength;
                fractionalPart = n % inputLength;
            }

            var fractionalLenght = (int)fractionalPart;
            var fractionalInput = input.Substring(0, fractionalLenght);

            var fractionalPartOccurence = CountOccurrences(fractionalInput);

            var occurence = fractionalPartOccurence + integerPartOccurence * integerPart;

            return occurence;
        }

        private int CountOccurrences(string input)
        {
            var isInputEmpty = string.IsNullOrWhiteSpace(input);
            var integerPartOccurence = 0;
            if (!isInputEmpty)
            {
                foreach (var symbol in input)
                {
                    var isIt = symbol == this._symbol;
                    if (isIt)
                    {
                        integerPartOccurence++;
                    }
                }
            }
            return integerPartOccurence;
        }
    }
}
