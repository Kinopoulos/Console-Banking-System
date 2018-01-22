using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankingSystemAfDEMP
{
    public class LoginScreen
    {   //Properties.
        public static string Username { get; set; }
        public static string Password { get; set; }


        public void Login()
        {
            string loginimg = "\n" +
           "\t****************************************************************************************************\n" +
           "\t*                                                Welcome                                           *\n" +
           "\t*                                 Please insert your Username and your Password                    *\n" +
           "\t*                                        You have THREE tries to Login                             *\n" +
           "\t****************************************************************************************************\n";
            Console.WriteLine(loginimg);

            Console.Write("--->USERNAME: ");
            Username = Console.ReadLine();
            Console.Write("--->PASSWORD: ");
            //Encrypt user's input.
            ConsoleKeyInfo key;
            Password = "";
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    Password += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && Password.Length > 0)
                    {
                        Password = Password.Substring(0, (Password.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            while (key.Key != ConsoleKey.Enter);
        }



        public static bool InputValidation()
        {
            // The using statement simplifies the code that you have to write to create and then finally clean up the object.
            //The using statement obtains the resource specified, 
            //executes the statements and finally calls the Dispose method of the object to clean up the object.
            using (DatabaseAccessCtx ctx = new DatabaseAccessCtx())
            {

                //Getting and setting the current or original value of an individual property with the syntax:
                //var @@@ = context.@@@.Find(1);
                //string currentName1 = context.Entry(blog).Property(u => u.Name).CurrentValue;==>// Read the current value of the Name property
                //respectively we are using this syntax for the Username & Password properties.
                var admin = ctx.Users.Find(1);
                string adminstrator = ctx.Entry(admin).Property(i => i.Username).CurrentValue;
                string adminpassword = ctx.Entry(admin).Property(i => i.Password).CurrentValue;
                var user1 = ctx.Users.Find(2);
                string simpleuser1 = ctx.Entry(user1).Property(i => i.Username).CurrentValue;
                string simpleuserpassword1 = ctx.Entry(user1).Property(i => i.Password).CurrentValue;
                var user2 = ctx.Users.Find(3);
                string simpleuser2 = ctx.Entry(user2).Property(i => i.Username).CurrentValue;
                string simpleuserpassword2 = ctx.Entry(user2).Property(i => i.Password).CurrentValue;

                //Check user's inputs.
                if ((Username == adminstrator && Password == adminpassword) || (Username == simpleuser1 && Password == simpleuserpassword1) || (Username == simpleuser2 && Password == simpleuserpassword2))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public void Counter()
        {
            //As the counter counts searching for the -LoginScreen.InputValidation- condition to fulfill if one of the inputs is the the right one it calls the ApplicationsMenu class and 
            //its UsersChoiceinput method in order to display to the user the Bank's Menu.
            int logincounter = 1;
            while (logincounter <= 3)
            {
                Login();
                if (LoginScreen.InputValidation())
                {
                    ApplicationsMenu.UsersChoiceInput();
                    logincounter = 1;
                }
                else
                {
                    if (logincounter < 3)
                    {
                        logincounter++;
                    }
                    else
                    {
                        Console.WriteLine("\n**********Press any key to exit**********");
                        logincounter++;
                    }
                }
                Console.ReadKey();
                //Clears the console's Buffer.
                //Buffering is a manipulation of unmanaged memory that is represented as arrays of bytes.
                Console.Clear();
            }

        }
    }
}
