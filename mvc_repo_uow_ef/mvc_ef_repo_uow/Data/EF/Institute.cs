using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF
{
    class Institute
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage ="Max 30 characters allowed.")]
        public string Name { get; set; }
        [RegularExpression("\"^https?:\\\\/\\\\/(?:www\\\\.)?[-a-zA-Z0-9@:%._\\\\+~#=]{1,256}\\\\.[a-zA-Z0-9()]{1,6}\\\\b(?:[-a-zA-Z0-9()@:%_\\\\+.~#?&\\\\/=]*)$\"")]
        public string Website { get; set; }
        public string City { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
