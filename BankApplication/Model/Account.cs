﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    public abstract class Account
    {
        public ObservableCollection<Transaction> Transactions { get; set; } = new ObservableCollection<Transaction>(); //lista över en kunds transaktioner
        public decimal Balance { get; set; }
        public double Interest { get; set; }
        public int AccountID { get; set; }

        public Account(decimal balance, double interest)
        {
            Balance = balance;
            Interest = interest;
            AccountID = AccountLogic.NewAccountID();
        }
        public string DisplayAccID { get { return $"Account ID: {AccountID}"; } }
        public string DisplayInterest { get { return $"Interest: {Interest*100}%"; } }
        public string DisplayBalance{ get { return $"Account balance: {Balance} SEK"; } }
        public string DisplayAccType { get { return $"Account type: {GetType().Name}"; } }
    }
}
