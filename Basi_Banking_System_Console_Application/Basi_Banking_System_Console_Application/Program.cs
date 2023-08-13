using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Basi_Banking_System_Console_Application
{
    //Please note that this is a basic example and lacks advanced error handling, security measures, and other features you'd find in a real-world banking system. Use this as a starting point and enhance it as needed for your requirements.
    // Represents a bank account
    class Account
    {
        public int AccountNumber { get; set; }  // Unique account number
        public decimal Balance { get; set; }    // Current account balance
    }

    // Manages banking operations
    class BankingSystem
    {
        private Dictionary<int, Account> accounts = new Dictionary<int, Account>();  // Store accounts using account number as key

        // Create a new bank account
        public void CreateAccount(int accountNumber, decimal initialBalance)
        {
            Account newAccount = new Account { AccountNumber = accountNumber, Balance = initialBalance };
            accounts[accountNumber] = newAccount;
            Console.WriteLine("Account created successfully.");
        }

        // Check the balance of an account
        public void CheckBalance(int accountNumber)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                Console.WriteLine($"Account Balance: {accounts[accountNumber].Balance}");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        // Deposit funds into an account
        public void Deposit(int accountNumber, decimal amount)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                accounts[accountNumber].Balance += amount;
                Console.WriteLine($"Deposit successful. Updated balance: {accounts[accountNumber].Balance}");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        // Withdraw funds from an account
        public void Withdraw(int accountNumber, decimal amount)
        {
            if (accounts.ContainsKey(accountNumber))
            {
                if (accounts[accountNumber].Balance >= amount)
                {
                    accounts[accountNumber].Balance -= amount;
                    Console.WriteLine($"Withdrawal successful. Updated balance: {accounts[accountNumber].Balance}");
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                }
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BankingSystem bankingSystem = new BankingSystem();  // Initialize the banking system

            // Create some example accounts
            bankingSystem.CreateAccount(123456, 1000.0m);
            bankingSystem.CreateAccount(789012, 500.0m);

            while (true)
            {
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("0. Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter account number: ");
                        int accountNumber = int.Parse(Console.ReadLine());
                        bankingSystem.CheckBalance(accountNumber);
                        break;
                    case 2:
                        Console.Write("Enter account number: ");
                        int depositAccountNumber = int.Parse(Console.ReadLine());
                        Console.Write("Enter deposit amount: ");
                        decimal depositAmount = decimal.Parse(Console.ReadLine());
                        bankingSystem.Deposit(depositAccountNumber, depositAmount);
                        break;
                    case 3:
                        Console.Write("Enter account number: ");
                        int withdrawAccountNumber = int.Parse(Console.ReadLine());
                        Console.Write("Enter withdrawal amount: ");
                        decimal withdrawAmount = decimal.Parse(Console.ReadLine());
                        bankingSystem.Withdraw(withdrawAccountNumber, withdrawAmount);
                        break;
                    case 0:
                        Environment.Exit(0);  // Exit the application
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }

}
