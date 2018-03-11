using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            var helloPass = from pass in users
                            where pass.Password == "hello"
                            select pass;

            Console.WriteLine("Name: PassWord:");
            //Console.WriteLine("Full user list:");

            //foreach (var allUsers in users)
            //{
            //    Console.WriteLine("{0}  {1}", allUsers.Name, allUsers.Password);
            //}

            //Console.WriteLine("hello passwords");
            foreach (var pass in helloPass)
            {

                Console.WriteLine("{0}  {1}", pass.Name, pass.Password);
            }

            //remove lowercase name passwords
            users.RemoveAll(lowerpass => lowerpass.Name.ToLower() == lowerpass.Password);

            //Console.WriteLine("Lower case name password removed:");

            //foreach (var lowerpass in users)
            //{
            //    Console.WriteLine("{0}  {1}", lowerpass.Name, lowerpass.Password);
            //}

            users.Remove(users.First(firstHello => firstHello.Password == "hello"));

            Console.WriteLine("Remaining users:");

            foreach (var remainingUsers in users)
            {
                Console.WriteLine("{0}  {1}", remainingUsers.Name, remainingUsers.Password);
            }
            
              Console.ReadLine();          
        }
    }
}
