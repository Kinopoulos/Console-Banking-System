using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;

namespace BankingSystemAfDEMP
{
    public class InternalBankAccount
    {
        public static Account Account { get; set; }
        
        
        //Tracks transactions.
        public static List<string> ListforTxt = new List<string>();

        //Create four methods for the four main actions:View Balance-View all balances-Deposit-Withdraw.
        public static void Balance()
        {
            using (DatabaseAccessCtx dbb = new DatabaseAccessCtx())
            {
                string forBalance = (from a in dbb.Accounts
                                     where a.User.Username.Equals(LoginScreen.Username)
                                     select ($"This account belongs to: {a.User.Username} ***Account Balance: {a.Amount} *** Last transcaction: {a.Transaction_Date}")).First().ToString();

                Console.WriteLine(forBalance);
            }
            Console.ReadKey();
        }



        public static void AllBalances()
        {
            using (DatabaseAccessCtx dbb = new DatabaseAccessCtx())
            {
                List<int> accoun = (from baseuser in dbb.Accounts
                                    select baseuser.Id).ToList();

                for (int i = 2; i <= accoun.Count; i++)
                {
                    string account = (from b in dbb.Accounts
                                      where b.Id.Equals(i)
                                      select ($"This account belongs to: {b.User.Username}***Date of Last Transaction:{b.Transaction_Date.ToString("dd-MM-yyyy HH.mm.ss.FFF")}***Balance:{String.Format("{0:0.00}", b.Amount)}")).First().ToString();

                    Console.WriteLine($" User {i - 1} account: ");
                    Console.WriteLine(account.ToString());
                    Console.WriteLine();
                }
            }

            Console.ReadKey();
        }


        public static void Deposit()
        {
            Console.Write("//////////Insert ammount//////////: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            Console.Write("/////Insert account/////: ");
            string name = Console.ReadLine();

            using (DatabaseAccessCtx dbd = new DatabaseAccessCtx())
            {
                List<string> names = (from usersss in dbd.Users
                                      select usersss.Username).ToList();


                bool valid = false;

                foreach (var nameelement in names)
                {
                    if (nameelement == name)
                    {
                        valid = true;
                        if (amount > 0 && name != LoginScreen.Username)
                        {
                            Account main = (from y in dbd.Accounts
                                            where y.User.Username == LoginScreen.Username
                                            select y).First();

                            Account internalacc = (from x in dbd.Accounts
                                                   where x.User.Username == name
                                                   select x).First();


                            if (main.Amount >= amount)
                            {
                                string list;
                                internalacc.Amount += amount;
                                internalacc.Transaction_Date = DateTime.Now;

                                main.Amount -= amount;
                                main.Transaction_Date = DateTime.Now;
                                internalacc.Transaction_Date.ToString("dd-MM-yyyy HH.mm.ss.FFF");
                                Console.WriteLine("SUCCESFULL TRANSACTION");
                                Console.ReadKey();
                                dbd.SaveChanges();

                                Console.WriteLine($"\nMoney tranfer from {String.Format("{0:0.00}", amount)}  {name} account");
                                list = $"{internalacc.Transaction_Date.ToString("dd-MM-yyyy HH.mm.ss.FFF")}, {String.Format("{0:0.00}", amount)} withdrawed from {name.ToUpper()}";
                                ListforTxt.Add(list);
                                dbd.SaveChanges();


                                break;
                            }
                            else
                            {
                                Console.WriteLine("LACK OF MONEY!!!");
                            }
                        }
                        else
                        {
                            //invalid inputs = account||money
                            Console.WriteLine("ERROR");
                        }
                    }
                }
                if (valid == false)
                {
                    //wrong name input.
                    Console.WriteLine("ERROR");
                }
            }
        }

        public static void Withdraw()
        {
            Console.Write("//////////Insert ammount//////////: ");
            decimal amount = decimal.Parse(Console.ReadLine());
            Console.Write("/////Insert account/////: ");
            string name = Console.ReadLine();

            using (DatabaseAccessCtx dbd = new DatabaseAccessCtx())
            {
                List<string> names = (from n in dbd.Users
                                      select n.Username).ToList();

                bool valid = false;

                foreach (var nameElement in names)
                {
                    if (nameElement == name)
                    {
                        valid = true;
                        if (amount > 0 && name != LoginScreen.Username)
                        {
                            Account main = (from x in dbd.Accounts
                                            where x.User.Username == name
                                            select x).First();
                            Account internalacc = (from y in dbd.Accounts
                                                   where y.User.Username == LoginScreen.Username
                                                   select y).First();

                            if (main.Amount >= amount)
                            {

                                string list;
                                main.Amount -= amount;
                                main.Transaction_Date = DateTime.Now;

                                internalacc.Amount += amount;
                                internalacc.Transaction_Date = DateTime.Now;
                                
                                internalacc.Transaction_Date.ToString("dd-MM-yyyy HH.mm.ss.FFF");
                                Console.WriteLine("SUCCESFULL TRANSACTION");
                                Console.ReadKey();
                                dbd.SaveChanges();

                                Console.WriteLine($"\nYou have succesfully transfered {String.Format("{0:0.00}", amount)} in {name}");
                                list = $"{internalacc.Transaction_Date.ToString("dd-MM-yyyy HH.mm.ss.FFF")}, {String.Format("{0:0.00}", amount)} withdrawed from {name.ToUpper()}";
                                ListforTxt.Add(list);
                                dbd.SaveChanges();

                            }
                            else
                            {
                                Console.WriteLine($"\n{name} doesn't have enough money in his account for this transaction");
                            }
                        }
                        else
                        {
                            //Wrong ammount || owner
                            Console.WriteLine("ERROR");

                        }
                    }
                }
                if (valid == false)
                {
                    //Wrong name input.
                    Console.WriteLine("ERROR");
                }
            }
        }
       


        public override string ToString()
        {
            return String.Format("{0, 10} {1, 30:yyyy/MM/dd HH:mm:ss.FFF} {2, 20:C2}", Account.User, Account.Amount, Account.Transaction_Date);
        }
    }
    

}