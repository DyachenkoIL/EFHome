using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTask.Models
{
    public class Group
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int LeaderId { get; set; }
        public User Leader { get; set; }

        public ICollection<User> Users { get; set; }
        public Group()
        {
            Users = new List<User>();
        }
    }
}
