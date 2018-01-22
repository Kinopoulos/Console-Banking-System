using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BankingSystemAfDEMP
{
    public static class FileAccess
    {
        public static void Files()
        {
           
            string files = $"statement_{LoginScreen.Username}_{DateTime.Now.ToString("dd_MM_yyyy")}.txt";

            foreach (var list in InternalBankAccount.ListforTxt)
            {
                if (File.Exists(files) == false)
                {
                    using (FileStream filestream = File.Create(files))
                    {
                        Console.WriteLine($"\nStatement named: {files} \nsuccess");
                    }
                    using (StreamWriter streamwriter0 = File.AppendText(files))
                    {
                        streamwriter0.WriteLine("\t Statement");
                    }
                }

                using (StreamWriter streamwriter2 = File.AppendText(files))
                {
                    streamwriter2.WriteLine();
                    streamwriter2.WriteLine(list);
                }
            }
            Console.WriteLine($"\n{files} statement");
        }
    }
}