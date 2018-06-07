using ExpenseIt.DataSources.Contexts;
using ExpenseIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseIt.Controller
{
    class PeopleController
    {
        public PeopleController()
        {

        }

        public IList<Person> People(string name, string department)
        {

            List<Person> peopleReport;

            using (var db = new FinancialContext())
            {
                //refacter to service
                peopleReport = (from b in db.Persons
                                where b.Name == name
                                orderby b.Department, b.Name
                                select b).ToList();
            }

            return peopleReport;
        }

        public Person Person(string name)
        {
            Person person;

            using (var db = new FinancialContext())
            {
                //refacter to service

                person = (from b in db.Persons
                          where b.Name == name                          
                          select b).FirstOrDefault();

            }

            return person;
        }
    }
}
