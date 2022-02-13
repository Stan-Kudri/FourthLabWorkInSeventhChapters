﻿namespace FourthLabWorkInSeventhChapters.Transaction
{
    public class PaymentToPutBankTransaction : BankTransaction
    {
        public PaymentToPutBankTransaction(int amountOfMony) : base(amountOfMony)
        {
        }

        public PaymentToPutBankTransaction(int amountOfMony, int numberAccount) : base(amountOfMony, numberAccount)
        {
        }

        public override string ToString()
        {
            return string.Format($"Получение {_amountOfMony} рублей с карты {_numberAccountOfTransfer}: {_dateTime}");
        }
    }
}
