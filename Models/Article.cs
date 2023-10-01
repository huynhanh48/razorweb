using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace MigrationsExample.Models
{
    public class Article
    {
        [Key]
        public int ID { get; set; }
        [StringLength(255)]
        [Required]
        [Column(TypeName ="nvachar")]
        [DisplayName("Tieu De")]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Ngay Tao")]
        public DateTime PublishDate { get; set; }

        [DisplayName("Noi Dung")]
        public string Content {set; get;}
    }
}