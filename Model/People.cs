using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseIt.Model
{
    class People
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Department { get; set; }

        public virtual List<People> Persons { get; set; }
    }
}
