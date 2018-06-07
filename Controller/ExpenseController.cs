using ExpenseIt.ViewModel;
using ExpenseIt.DataSources.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseIt.Model;

namespace ExpenseIt.Controller
{
    class ExpenseController
    {
        public ExpenseController()
        {

        }

        public ExpenseReport ExpenseReport(string name, string type)
        {
            ExpenseReport expenseReport;

            using (var db = new FinancialContext())
            {
                //refacter to service
                 
                var expense = (from b in db.Expenses
                            where b.ExpenseType == type
                            select b).FirstOrDefault();
               
                var person = (from b in db.Persons
                                    where b.Name == name
                                    select b).FirstOrDefault();

                //build expense report object
                expenseReport = new ExpenseReport {
                    Name = person.Name,
                    Department = person.Department,
                    ExpenceAmount = expense.ExpenseAmount,
                    ExpenseType = expense.ExpenseType
                    
                };

            }

            return expenseReport;
        }

        public IList<Expense> Expenses()
        {
            var result = new List<Expense>();

            using (var db = new FinancialContext())
            {
                //refacter to service

                var query = (from b in db.Expenses
                            orderby b.ExpenseType
                            select b).ToList();

                result = query;
            }

            return result;
        }
    }
}
