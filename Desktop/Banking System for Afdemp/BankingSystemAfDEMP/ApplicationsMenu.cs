
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingSystemAfDEMP
{
    public static class ApplicationsMenu
    {
        
        public static void Menu()

        {
            //There are two menus depending on the level of the user:the first menu is for the admin and the second for the users(user1&&user2).
            if (LoginScreen.Username == "admin")
            {
                //Clear buffer in order to not display the login screen with the Menu.
                Console.Clear();
                Console.WriteLine("1.View internal bank account\n\n2.View all members' bank account" +
                            "\n\n3.Deposit to member's account\n\n4.Withdraw from member's account\n\n5.Store today's transactions\n\n6.Exit\n>");
            }
            else
            {
                //Clear buffer in order to not display the login screen with the Menu.
                Console.Clear();
                Console.WriteLine("-1.View your account\n\n2.Deposit to internal bank account" +
                            "\n\n3.Deposit to other account\n\n4.Store today's transactions\n\n5.Exit\n>");
            }
        }

        //In this method we are using a SWITCH statement to test the choice string for equality against the 6 cases that constitute the menu.
        public static void UsersChoiceInput()
        {
            

            bool exit = false;
            while (!exit)
            {
                Menu();

                string choice = Console.ReadLine();
                Console.Clear();
                
                
                switch (choice)
                {
                    
                    case "1":
                        InternalBankAccount.Balance();
                        break;
                    case "2":
                        if (LoginScreen.Username == "admin")
                        {
                            InternalBankAccount.AllBalances();
                        }
                        else
                        {
                            Console.WriteLine("Access Denied!");
                            Console.ReadKey();
                        }
                        break;
                    case "3":
                        InternalBankAccount.Deposit();
                        break;
                    case "4":
                        if (LoginScreen.Username == "admin")
                        {
                            InternalBankAccount.Withdraw();
                        }
                        else
                        {
                            Console.WriteLine("Access Denied!");
                            Console.ReadKey();
                        }
                        break;
                    case "5":
                        FileAccess.Files();
                        

                        break; 
                    case "6":
                        exit = true;
                        break;
                    //In case of an input that is different than 1-6.
                    default:
                        Console.WriteLine("**********INVALID CHOICE-PRESS ANY KEY TO REDIRECT TO MENU************");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            }


        }
    }
}
