using System.Collections.Generic;
using System.Linq;

namespace Rekrutacja.Workers.Parsers
{
    public static class IntParser
    {
        public static int ParseFromString(this string number)
        {
            var result = 0;

            if(string.IsNullOrWhiteSpace(number))
                throw new System.Exception("Number cannot be empty");

            CheckIfHasOnlyNumbers(number);
            CheckIfOutOfRanges(number);

            var multiply = 1;

            if(number[0] == '-')
            {
                for(var i = number.Length - 1; i >= 1; i--)
                {
                    var digit = getDigit(number[i]);
                    result += multiply * digit;
                    multiply *= 10;
                }

                result = result * -1;
            }
            else
            {
                for(var i = number.Length - 1; i >= 0; i--)
                {
                    var digit = getDigit(number[i]);
                    result += multiply * digit;
                    multiply *= 10;
                }
            }

            return result;
        }

        private static void CheckIfHasOnlyNumbers(string number)
        {
            var charNumbers = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            if(number[0] == '-')
            {
                for(var i = 1; i < number.Length; i++)
                {
                    if(!charNumbers.Contains(number[i]))
                        throw new System.Exception("Number cannot have any characters other than digits");
                }
            }
            else
            {
                foreach(var numberChar in number)
                {
                    if(!charNumbers.Contains(numberChar))
                        throw new System.Exception("Number cannot have any characters other than digits");
                }
            }
        }

        private static void CheckIfOutOfRanges(string number)
        {
            var maxInt = int.MaxValue.ToString();
            var minInt = int.MinValue.ToString();

            if(number[0] == '-')
            {
                if(number.Count() > minInt.Count())
                    throw new System.Exception("Number is out of int range");

                if(number.Count() == minInt.Count())
                    for(var i = 1; i < number.Length; i++)
                    {
                        if(number[i] < minInt[i])
                            break;
                        if(number[i] == minInt[i])
                            continue;
                        if(number[i] > maxInt[i])
                            throw new System.Exception("Number is out of int range");
                    }
            }
            else
            {
                if(number.Count() > maxInt.Count())
                    throw new System.Exception("Number is out of int range");

                if(number.Count() == maxInt.Count())
                    for(var i = 0; i < number.Length; i++)
                    {
                        if(number[i] < maxInt[i])
                            break;
                        if(number[i] == maxInt[i])
                            continue;
                        if(number[i] > maxInt[i])
                            throw new System.Exception("Number is out of int range");
                    }
            }
        }

        private static int getDigit(char digit)
        {
            switch(digit)
            {
                case '0':
                    return 0;

                case '1':
                    return 1;

                case '2':
                    return 2;

                case '3':
                    return 3;

                case '4':
                    return 4;

                case '5':
                    return 5;

                case '6':
                    return 6;

                case '7':
                    return 7;

                case '8':
                    return 8;

                case '9':
                    return 9;

                default:
                    throw new System.Exception("Char cannot be any character other than digit");
            }
        }
    }
}