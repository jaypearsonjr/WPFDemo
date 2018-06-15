using ExpenseIt.DataSources.Contexts;
using ExpenseIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExpenseIt
{
    /// <summary>
    /// Interaction logic for ExpenseItHome.xaml
    /// </summary>
    public partial class ExpenseItHome : Page
    {
        public ExpenseItHome()
        {
            InitializeComponent();
        }

        public int CreateNewExpense(Expense e)
        {
            using (var db = new FinancialContext())
            {
                int result = 0;
                string type = "placeholder",
                       amount = "placeholder";

                type = e.ExpenseType;
                amount = e.ExpenseAmount;

                var expense = new Expense { ExpenseType = type, ExpenseAmount = amount };
                db.Expenses.Add(expense);

                result = db.SaveChanges();

                if (false)
                {
                   //handle unexpected result

                }
                else
                {

                    return result;
                }

            }
        }

        private void Button_Click_ViewReport(object sender, RoutedEventArgs e)
        {
            // View Expense Report
            ExpenseReportPage expenseReportPage = new ExpenseReportPage(this.projectListBox.SelectedItem);
            this.NavigationService.Navigate(expenseReportPage);
        } 
    }
}
