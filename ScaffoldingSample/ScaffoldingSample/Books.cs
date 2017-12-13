using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScaffoldingSample
{
    [Table("Books", Schema = "books")]
    public partial class Books
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        [StringLength(25)]
        public string Publisher { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(20)]
        public string Isbn { get; set; }
    }
}
