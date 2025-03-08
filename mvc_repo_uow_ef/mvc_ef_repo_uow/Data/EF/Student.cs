using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF
{
    class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(10)]
        public string RollNo { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\\.[a-zA-Z0-9-]+)*$")]
        public int StudentId { get; set; }

        public Institute Institute { get; set; }
    }
}
