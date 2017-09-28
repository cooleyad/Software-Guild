﻿using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Responses;

namespace SGBank.BLL.WithdrawRules
{
    public class PremiumAccountWithdrawRules : IWithdraw
    {
        public AccountWithdrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();

            response.OldBalance = account.Balance;
            response.Account = account;

            if (account.Type != AccountType.Premium)
            {
                response.Success = false;
                response.Message = "Error: a non-Premium account hit the Premium Withdraw Rule. Contact IT";
                return response;
            }
            if (amount >= 0)
            {
                response.Success = false;
                response.Message = "Withdrawal amounts must be negative!";
                return response;
            }
            if (account.Balance+amount < -500)
            {
                response.Success = false;
                response.Message = "Withdrawal exceeds $500 overdraft limit!";
                return response;
            }
            response.Success = true;
            response.Amount = amount;
            account.Balance += amount;            
            return response;
        }
    }
}
