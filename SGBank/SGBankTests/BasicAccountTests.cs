using NUnit.Framework;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBankTests
{
    [TestFixture]
    public class BasicAccountTests
    {
        
        [TestCase("33333", "Basic Account", 100, AccountType.Free, 250, 100, false)]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, -100, 100, false)]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, 250, 350, true)]

        public void BasicAccountDepositTest(string accountNumber, string name, decimal balance,
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
        [TestCase("33333", "Basic Account", 1500, AccountType.Basic, -1000, 1500, false)]
        [TestCase("33333", "Basic Account", 100, AccountType.Free, -100, 100, false)]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, 1000, 100, false)]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, -50, 50, true)]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, -150, -60, true)]


        public void BasicWithdrawRuleTest(string accountNumber, string name, decimal balance,
            AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {
            IWithdraw withdraw = new BasicAccountWithdrawRule();
            Account account = new Account();
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;
            account.AccountNumber = accountNumber;

            AccountWithdrawResponse response = withdraw.Withdraw(account, amount);

            Assert.AreEqual(response.Account.Balance, newBalance);
        }
    }
}
