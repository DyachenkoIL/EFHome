using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using EFTask.Models;

namespace EFTask
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SimpleContext())
            {
                Console.WriteLine("All Groups in the database:");
                
                foreach (Group g in db.Groups.Include(g => g.Users))
                {
                    Console.WriteLine("Команда: {0}", g.GroupName);
                    foreach (User us in g.Users)
                    {
                        Console.WriteLine("{0} - {1}", us.FirstName, us.LastName, us.Position);
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
