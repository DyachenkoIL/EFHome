using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EFTask.Models;

namespace EFTask
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SimpleContext())
            {
                Console.Write("Enter a name for a new Group: ");
                var name = Console.ReadLine();

                var group = new Group { GroupName = name };
                db.Groups.Add(group);
                db.SaveChangesAsync();

                var query = from g in db.Groups
                            orderby g.GroupName
                            select g;

                Console.WriteLine("All Groups in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.GroupName);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
            //string connection = @"Data Source=(localdb)\v11.0;Initial Catalog=newDB;Integrated Security=True";
        }
    }
}
