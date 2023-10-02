using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.EF.Models
{
    internal class Extract
    {
        [Key]
        public int Id { get; set; }

        public float Historic { get; set; }
    }
}
