using ExpenseIt.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class TempPage : Page
    {
        private TextPointer _navigator;

        public TempPage()
        {
            InitializeComponent();
            _navigator = UserInputArea.Document.ContentStart;
            UserInputArea.Focus();
        }
        // Custom constructor to pass data        
        public TempPage(object data) : this()
        {

            this.DataContext = data;
        }

        private void UserInputArea_TextChanged_ParseText(object sender, TextChangedEventArgs e)
        {
            // obj's and locals
            String pattern = @"(@|#| )\w+";
            Regex reg = new Regex(pattern);
            TextPointer navigator = UserInputArea.Document.ContentStart;
            // create list to hold ranges
            List<TextRange> ranges = new List<TextRange>();

            while (navigator.CompareTo(UserInputArea.Document.ContentEnd) < 0)
            {
                var run = new Run(navigator.Parent.ToString());

                if (run != null)
                {
                    string runText = navigator.GetTextInRun(LogicalDirection.Forward);
                    var matches = reg.Matches(runText);

                    foreach (Match match in matches)
                    {

                        TextPointer start = navigator.GetPositionAtOffset(match.Index);
                        TextPointer end = start.GetPositionAtOffset(match.Length);

                        TextRange textrange = new TextRange(start, end);
                        textrange.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Red);

                        ranges.Add(textrange);
                    }

                }

                navigator = navigator.GetNextContextPosition(LogicalDirection.Forward);
            }

        }

        private void UserInputArea_TextChanged_ParseText_v2(object sender, TextChangedEventArgs e)
        {
            String pattern = @"(@|#| )\w+";
            Regex reg = new Regex(pattern);
            UserInputArea.Foreground = Brushes.Black;

            string text = new TextRange(UserInputArea.Document.ContentStart, UserInputArea.Document.ContentEnd).Text;
            var matches = reg.Matches(text);


        }
    }
}
