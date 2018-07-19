using System;
using System.Configuration;
using System.Linq;
using Repository.Entities;

namespace Repository
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello!");
            
            string connectionStr = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

            var unitOfWork = new UnitOfWork(new RepoDbContext(connectionStr));
            var repo = unitOfWork.GetRepository<User>();

            var user = repo.Find(1);
            user.Addresses.First().Name = "ChangedAddress";
            user.Addresses.Add(new Address { Name = "Belarus, Minsk", UserId = 1 });
            repo.Update(user);
            unitOfWork.Save();

            /*while (true)
            {
                var users = repo.GetAll();

                Console.WriteLine();
                if (users.Any())
                {
                    Console.WriteLine("There are the following users in DB:");
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine($"Id\t\tName");
                    Console.WriteLine("----------------------------------------------");
                    users.ForEach(x => { Console.WriteLine($"{x.Id}\t\t{x.Name}"); });
                }
                else
                {
                    Console.WriteLine("Currently the table User is empty");
                }
                Console.WriteLine();

                Console.WriteLine("The following operations are available:");
                Console.WriteLine("     update existing users: -u");
                Console.WriteLine("     insert 10 users: -i");
                Console.WriteLine("     delete existing users: -d");

                string data = Console.ReadLine();
                if (data.Length < 2)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Error: Unknown command.");
                    Console.ResetColor();
                }
                else
                {
                    string action = data.Substring(0, 2);
                    switch (action)
                    {
                        case "-u":
                            users.ForEach(x => { x.Name = $"Updated_{x.Name}"; });
                            break;
                        case "-i":
                            for (int i = 0; i < 10; i++)
                            {
                                repo.Insert(new User { Name = $"{i}{i}{i}{i}{i}{i}{i}" });
                            }
                            break;
                        case "-d":
                            users.ForEach(x =>
                            {
                                repo.Delete(x);
                            });
                            break;
                        default:
                            Console.WriteLine("Error: Unknown command.");
                            break;
                    }
                    unitOfWork.Save();
                }
            }*/
        }
    }
}
