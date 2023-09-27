using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MigrationsExample.Models
{
    public class Article
    {
        [Key]
        public int ID { get; set; }
        [StringLength(255)]
        [Required]
        [Column(TypeName ="nvachar")]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        public string Content {set; get;}
    }
}