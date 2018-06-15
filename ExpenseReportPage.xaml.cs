using ExpenseIt.Controller;
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
    /// Interaction logic for ExpenseReportPage.xaml
    /// </summary>
    public partial class ExpenseReportPage : Page
    {
        public ExpenseReportPage()
        {
            InitializeComponent();
        }
        // Custom constructor to pass expense report data
        // Benifit of this() constructor: allow use of object type and reduce duplicate code
        public ExpenseReportPage(object data) : this()
        {
            // Bind to expense report data.
            this.DataContext = data;
        }

        private void Button_Click_ViewDetails(object sender, RoutedEventArgs e)
        {
            // View Expense Report
            TempPage tempPage = new TempPage();
            this.NavigationService.Navigate(tempPage);
        }
    }
}
