﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    class AccountLogic
    {
        public int AddSavingsAccount(long ssn) 
        {
            foreach (var item in CustomerLogic.Customers)
            {
                if (item.SSN == ssn)
                {
                    int accountID = 1000 + item.Accounts.Count;
                    item.Accounts.Add(new SavingsAccount(0.01, accountID));
                    return accountID;
                }
            }
            return -1;
        }

        public string GetAccount(long ssn, int accountID) 
        {
            foreach (var customer in CustomerLogic.Customers)
            {
                if (customer.SSN == ssn)
                {
                    foreach (var account in customer.Accounts)
                    {
                        if (account.AccountID == accountID)
                        {
                            if (account is SavingsAccount)
                            {
                                return $"{account.AccountID}{account.Balance} Savings Account {account.Interest}";
                            }
                            else if (account is CreditAccount)
                            {
                                return $"{account.AccountID}{account.Balance} Credit Account {account.Interest}";
                            }
                        }
                    }
                }
            }

            //var a =
            //    from customer in CustomerLogic.Customers
            //    from account in customer.Accounts
            //    where ssn == customer.SSN && account.AccountID == accountID
            //    select account;
            //            Account temp = selectedAccount.First();
            return null;
        }

        public bool Deposit(long ssn, int accountID, decimal amount) 
        {
            //var selectedAccount =
            //    from customer in CustomerLogic.Customers
            //    from account in customer.Accounts
            //    where ssn == customer.SSN && account.AccountID == accountID
            //    select account;

            //Account temp = selectedAccount.First();

            foreach (var customer in CustomerLogic.Customers)
            {
                if (customer.SSN == ssn)
                {
                    for (int i = 0; i < customer.Accounts.Count; i++)
                    {
                        if (customer.Accounts[i].AccountID == accountID)
                        {
                            customer.Accounts[i].Balance += amount;
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool Withdraw(long pNr, int accountId, decimal amount) { }

        public string CloseAccount(long pNr, int accountId) { }

    }
}
