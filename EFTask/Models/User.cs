using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTask.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string FirstNane { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }

        public int? GroupId { get; set; }
        public Group Group { get; set; }
    }
}
