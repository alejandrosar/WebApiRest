using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public string Birthdate { get; set; }
    }
}
