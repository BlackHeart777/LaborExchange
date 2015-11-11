using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.Storeges;
using DataAccess;
using System.Data.Entity;

namespace TestProjectForCreateTestDb
{
    class Program
    {
        static void Main(string[] args)
        {
            Applicant applicant = new Applicant()
            {
                AdditionalInformation = "I'm a new user this is sestem",
                Birthday = new DateTime(1991, 2, 1)
                
            };

            //Create.Insert(applicant);


            using (var db = new LaborExchangeContext())
            {
                var app = CRUD.Select<Applicant>(db).First();
                Console.WriteLine(app.Birthday.ToShortDateString());
            }

            Console.ReadKey();
        }
    }
}
