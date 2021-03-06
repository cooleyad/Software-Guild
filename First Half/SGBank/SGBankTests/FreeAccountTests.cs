﻿using NUnit.Framework;
using SGBank.BLL;
using SGBank.Models;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Data;
using SGBank.Models.Interfaces;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;

namespace SGBankTests
{
    [TestFixture]
    public class FreeAccountTests
    {
        [Test]
        public void CanLoadFreeAccountTestData()
        {
            AccountManager manager = AccountManagerFactory.Create();

            AccountLookupResponse response = manager.LookupAccount("12345");

            Assert.IsNotNull(response.Account);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("12345", response.Account.AccountNumber);
        }
        [TestCase("12345", "Free Account", 100, AccountType.Free, 250, 100, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, -100, 100, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Basic, 50, 100, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, 50, 150, true)]


        public void FreeAccountDepositRuleTest(string accountNumber, string name, decimal balance,
            AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {
            IDeposit deposit = new FreeAccountDepositRules();
            Account account = new Account();
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;
            account.AccountNumber = accountNumber;
            
            AccountDepositResponse response = deposit.Deposit(account, amount);

            Assert.AreEqual(response.Account.Balance, newBalance);


            Assert.AreEqual(expectedResult, response.Success);
            

        }
        [TestCase("12345", "Free Account", 100, AccountType.Free, 1, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, -101, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Basic, -1, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, -150, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, -50, true)]

        public void FreeAccountWithdrawRuleTest(string accountNumber, string name, decimal balance,
            AccountType accountType, decimal amount, bool expectedResult)
        {
            IWithdraw withdraw = new FreeAccountWithdrawRules();
            Account account = new Account();
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;
            account.AccountNumber = accountNumber;

            AccountWithdrawResponse response = withdraw.Withdraw(account, amount);
            Assert.AreEqual(expectedResult, response.Success);

            if (response.Success)
            {
                Assert.AreEqual(response.OldBalance+amount, response.Account.Balance);
            }
            else
            {
                Assert.AreEqual(balance, account.Balance);
            }
        }
    }
}
