using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text;

namespace BankingSystemAfDEMP
{
    public class Account
    {
        
        [Key]
        public int Id { get; set; }
        [ForeignKey("user_id")]
        public User User { get; set; }
        public decimal Amount { get; set; }
        public DateTime Transaction_Date { get; set; }


        //Amount's display format.
        public static string FormatAmount(decimal amount)
        {
            Console.OutputEncoding = Encoding.UTF8;
            return amount.ToString("C2", CultureInfo.CreateSpecificCulture("el-GR"));

        }
    }
}
