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
    class ExpenseReportController
    {
        public ExpenseReportController()
        {

        }

        public ExpenseReport expenseReport(string name)
        {
            using (var db = new FinancialContext())
            {
                // Display all Blogs from the database 
                var query = from b in db.Expenses
                            orderby b.ExpenseType
                            select b;
                // query for peaple
                //build expense report object
            }

            return new ExpenseReport();
        }

        public IList<Expense> expenses()
        {
            var result = new List<Expense>();

            using (var db = new FinancialContext())
            {
                
                var query = from b in db.Expenses
                            orderby b.ExpenseType
                            select b;

                result = query.ToList<Expense>();
            }

            return result;
        }
    }
}
