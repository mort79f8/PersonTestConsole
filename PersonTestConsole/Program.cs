using Dapper;
using HelperLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HelperLibrary.Tools;

namespace PersonTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**** Corey Code ****");
            MapMultipleObjectsDapper();
            Console.WriteLine();
            Console.WriteLine("**** My Code ****");
            MapMultipleObjectsPerson();

            Console.ReadLine();
        }

        // My code
        public static void MapMultipleObjectsPerson()
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionStringPerson()))
            {
                string sql = @"select pe.*, ph.*
                                from dbo.People pe
                                left join dbo.PhoneNumbers ph
                                    on pe.PhoneNumber = ph.Id;";

                var people = cnn.Query<FullPersonModel, PhoneModel, FullPersonModel>(sql,
                    (person, phone) => { person.PhoneNumber = phone; return person; });

                foreach (var p in people)
                {
                    Console.WriteLine($"{p.Firstname} {p.Lastname}: Phonenumber: {p.PhoneNumber?.PhoneNumber}");
                }
            }
        }


        // Corey's code example
        public static void MapMultipleObjectsDapper()
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionStringDapper()))
            {
                string sql = @"select pe.*, ph.* 
                               from dbo.Person pe
                               left join dbo.Phone ph
                                 on pe.CellPhoneId = ph.Id;";

                var people = cnn.Query<FullPersonModel, PhoneModel, FullPersonModel>(sql,
                    (person, phone) => { person.CellPhone = phone; return person; });

                foreach (var p in people)
                {
                    Console.WriteLine($"{ p.FirstName } { p.LastName }: Cell: { p.CellPhone?.PhoneNumber }");
                }
            }
        }
    }
}
