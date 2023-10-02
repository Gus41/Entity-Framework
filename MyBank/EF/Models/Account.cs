using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.EF.Models
{
    internal class Account
    {

        [Key]
        public int Id { get; set; } 

        public int User_Id { get; set; }

        public decimal? Balance { get; set; }

        public int Extract_Id { get; set; }
    }
}
