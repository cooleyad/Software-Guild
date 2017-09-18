using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using System.IO;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        private const string _filePath = @"\\Mac\Home\Desktop\Repos\Accounts.txt";

        public Account LoadAccount(string AccountNumber)
        {
            try
            {
                using (StreamReader sr = new StreamReader(_filePath))
                {
                    sr.ReadLine();
                    string line;


                    while ((line = sr.ReadLine()) != null)
                    {

                        string[] input = line.Split(',');

                        if (input[0] == AccountNumber)
                        {

                            return ParseAccount(input);
                        }
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("There was a problem opening the account file: " + error.Message);
            }
            return null;
        }

        public void SaveAccount(Account account)
        {
            try
            {
                List<string> lines = new List<string>();
                using (StreamReader reader = new StreamReader(_filePath))
                {
                    string line;

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] entries = line.Split(',');

                        if (entries[0] == account.AccountNumber)
                        {
                            lines.Add(ParseFromAccount(account));
                        }
                        else
                        {
                            lines.Add(line);
                        }
                    }
                }
                File.WriteAllLines(_filePath, lines);
            }
            catch (Exception exception)
            {
                Console.WriteLine("There was a problem saving the account file: " + exception.Message);
            }
        }
        private Account ParseAccount(string[] entry)
        {
            AccountType type;

            switch (entry[3])
            {
                case "F":
                    type = AccountType.Free;
                    break;

                case "B":
                    type = AccountType.Basic;
                    break;
                case "P":
                    type = AccountType.Premium;
                    break;
                default:
                    throw new Exception("Account Type doesn't match");
            }
            return new Account()
            {
                AccountNumber = entry[0],
                Name = entry[1],
                Balance = decimal.Parse(entry[2]),
                Type = type
            };
        }
        private string ParseFromAccount(Account account)
        {
            return $"{account.AccountNumber},{account.Name},{account.Balance},{account.Type.ToString()[0]}";
        }
    }
}
