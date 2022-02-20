﻿using FourthLabWorkInSeventhChapters;
using Xunit;

namespace Test
{
    public class FailedTransactionsTest
    {
        [Theory]
        [InlineData(1000, 1200, 0, 1000, 1000)]
        public void FieldAcountTransaction(int balance, ushort withdrawAmounMony, ushort putAmounMony, int firstAccountBalance, int secondAccountBalance)
        {
            //Создание операций, которые должны были произойти в картсчете определенной карты.
            //Создание банковских счетов с определенным балансом из входных данных
            var firstAccountBank = new BankAccount(10000000, balance, BankAccountType.Current);
            var secondAccountBank = new BankAccount(10000001, balance, BankAccountType.Current);
            //Выполнение операций с картами.
            var isFirstOperation = firstAccountBank.TransferOfMoney(secondAccountBank, withdrawAmounMony);
            firstAccountBank.PutMoney(putAmounMony);
            var isSecondOperation = secondAccountBank.WithdrawMoney(withdrawAmounMony);
            secondAccountBank.PutMoney(putAmounMony);
            //Проверка правильности выполнения операций
            Assert.Equal(firstAccountBank.Balance, firstAccountBalance);
            Assert.Equal(secondAccountBank.Balance, secondAccountBalance);
            Assert.False(isFirstOperation);
            Assert.False(isSecondOperation);
            Assert.Empty(firstAccountBank.Transaction);
            Assert.Empty(secondAccountBank.Transaction);
        }
    }
}