using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseIt.Model
{
    public class Expense
    {
        public int Id { get; set; }

        public string ExpenseType { get; set; }
        public string ExpenseAmount { get; set; }

        public virtual List<Expense> Expenses { get; set; }

    }
}
