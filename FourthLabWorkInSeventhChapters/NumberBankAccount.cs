﻿namespace FourthLabWorkInSeventhChapters
{
    public class NumberBankAccount
    {
        const int stringSizeNumberAccount = 19;

        private readonly string _numberAccount;

        public string NumberAccount => _numberAccount;

        public NumberBankAccount(string line)
        {
            if (line == null)
                throw new ArgumentNullException("Строка нулевая");
            if (!TryParseNumberAccount(line, out string numberAccount))
                throw new FormatNumberAccountException("Строка не правильного формата");
            _numberAccount = numberAccount;
        }

        private static bool TryParseNumberAccount(string line, out string numberAccount)
        {
            var numberDigitBeforeSpace = 0;
            var number = stringSizeNumberAccount;
            var charArray = new char[stringSizeNumberAccount];
            foreach (var charElement in line.Where(x => x != ' '))
            {
                var IsFirstElementZero = number == stringSizeNumberAccount && charElement == '0';
                if (!char.IsNumber(charElement) || IsFirstElementZero || number < 1)
                {
                    numberAccount = string.Empty;
                    return false;
                }
                if (numberDigitBeforeSpace == 4)
                {
                    charArray[stringSizeNumberAccount - number] = ' ';
                    number--;
                    numberDigitBeforeSpace = 0;
                }
                charArray[stringSizeNumberAccount - number] = charElement;
                number--;
                numberDigitBeforeSpace++;
            }
            if (number != 0)
            {
                numberAccount = string.Empty;
                return false;
            }
            numberAccount = new string(charArray);
            return true;
        }
    }
}
