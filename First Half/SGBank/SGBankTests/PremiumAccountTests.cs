﻿using NUnit.Framework;
using SGBank.BLL;
using SGBank.Models;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models.Interfaces;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;


namespace SGBankTests
{
    [TestFixture]
    public class PremiumAccountTests
    {

        [TestCase("55555", "Premium Account", 100, AccountType.Free, 100, 100, false)]
        [TestCase("55555", "Premium Account", 100, AccountType.Premium, -100, 100, false)]
        [TestCase("55555", "Premium Account", 100, AccountType.Premium, 1000, 1100, true)]


        public void PremiumAccountDepositTest(string accountNumber, string name, decimal balance,
            AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {
            IDeposit deposit = new NoLimitDepositRule();
            Account account = new Account();

            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;
            account.AccountNumber = accountNumber;

            AccountDepositResponse response = deposit.Deposit(account, amount);

            Assert.AreEqual(expectedResult, response.Success);

            if (response.Success)
            {
                Assert.AreEqual(newBalance, response.Account.Balance);
            }
            else
            {
                Assert.AreEqual(balance, account.Balance);
            }
        }
        [TestCase("55555", "Premium Account", 1500, AccountType.Basic, -1000, 1500, false)]
        [TestCase("55555", "Premium Account", 1000, AccountType.Premium, 1000, 1000, false)]
        [TestCase("55555", "Premium Account", 1500, AccountType.Premium, -2500, 1500, false)]
        [TestCase("55555", "Premium Account", 1500, AccountType.Premium, -500, 1000, true)]
        [TestCase("55555", "Premium Account", 1500, AccountType.Premium, -1600, -100, true)]

        public void PremiumAccountWithdrawalTest(string accountNumber, string name, decimal balance,
            AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {
            Account account = new Account();
            IWithdraw withdraw = new PremiumAccountWithdrawRules();

            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;
            account.AccountNumber = accountNumber;


            AccountWithdrawResponse response = withdraw.Withdraw(account, amount);

            Assert.AreEqual(newBalance, response.Account.Balance);

            Assert.AreEqual(expectedResult, response.Success);


        }
    }
}

