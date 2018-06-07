using ExpenseIt.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseIt.DataSources.Contexts
{
    class FinancialContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<People> Persons { get; set; }
    }
}
