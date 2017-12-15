using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVCWithEFCore.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        public string Publisher { get; set; }
        [StringLength(20)]
        public string Isbn { get; set; }
    }
}
