using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using System.Printing;


namespace CPRG211Final
{
    /// <summary>
    /// Interaction logic for ManageCheckInOut.xaml
    /// </summary>
    public partial class ManageCheckInOut : Window
    {
        public ManageCheckInOut()
        {
            InitializeComponent();

            taskbarControl.ShowManageBooksClick += TaskbarControl_ShowManageBooksClick;
            taskbarControl.ShowManageMembersClick += TaskbarControl_ShowManageMembersClick;
            taskbarControl.ShowManageStaffClick += TaskbarControl_ShowManageStaffClick;
            taskbarControl.ShowCheckInOutClick += TaskbarControl_ShowCheckInOutClick;
        }

        // LoanBook
        private void BorrowBook(object sender, RoutedEventArgs e)
        {
            int loanID = int.Parse(inputLoanID.Text);
            int memberID = int.Parse(inputmemberID.Text);
            int bookID = int.Parse(inputBookID.Text);
            DateTime loanDate;
            DateTime dueDate;
            DateTime? returnDate = null;

            if (!DateTime.TryParse(inputLoanDate.Text, out loanDate))
            {
                AddMessage.Text = "Error: Invalid date format.";
                return;
            }

            dueDate = loanDate.AddDays(10);

            Loan loan = new Loan(loanID, memberID, bookID, loanDate, dueDate, returnDate);

            if (loan.BorrowBook(loan))
            {
                AddMessage.Text = "The book is Successfully Loaned.";
            }
            else
            {
                AddMessage.Text = "Error: The book is Not Loaned.";
            }
        }

        // ReturnBook
        private void ReturnBook(object sender, RoutedEventArgs e)
        {
            int loanID = int.Parse(inputLoanID.Text);
            
            DateTime? returnDate = null;

            // check if returnDateString is null or empty
            if (!string.IsNullOrEmpty(inputReturnDate.Text))
            {
                // if returnDateString is not null or empty it tries to convert to DateTime
                if (!DateTime.TryParse(inputReturnDate.Text, out DateTime tempReturnDate))
                {
                    AddMessage.Text = "Error: Invalid date format.";
                    return;
                }
                returnDate = tempReturnDate;
            }

            Loan loan = new Loan();

            loan.ReturnBook(loanID, (DateTime)returnDate);
        }

        // CheckDueDate
        private void CheckDueDate(object sender, RoutedEventArgs e)
        {
            try
            {
                int loanID = int.Parse(inputLoanID.Text);

                Loan loan = new Loan();
                DateTime dueDate = loan.CheckDueDate(loanID);

                DueDateDisplay.Text = $"Due Date: {dueDate:yyyy-MM-dd}";
            }
            catch (FormatException)
            {
                ErrorMessage.Text = "Error: Invalid LoanID format.";
            }

            catch (InvalidOperationException ex)
            {
                ErrorMessage.Text = ex.Message;
            }
        }











        // Open Window Methods

        // ShowManageBooks
        private void TaskbarControl_ShowManageBooksClick(object sender, RoutedEventArgs e)
        {
            ManageBooks manageBooks = new ManageBooks();
            manageBooks.Show();
            this.Close();
        }

        // ShowManageMembers
        private void TaskbarControl_ShowManageMembersClick(object sender, RoutedEventArgs e)
        {
            ManageMembers manageMembers = new ManageMembers();
            manageMembers.Show();
            this.Close();
        }

        // ShowManageStaff
        private void TaskbarControl_ShowManageStaffClick(object sender, RoutedEventArgs e)
        {
            ManageStaff manageStaff = new ManageStaff();
            manageStaff.Show();
            this.Close();
        }

        // ShowCheckInOut
        private void TaskbarControl_ShowCheckInOutClick(object sender, RoutedEventArgs e)
        {
            ManageCheckInOut manageCheckInOut = new ManageCheckInOut();
            manageCheckInOut.Show();
            this.Close();
        }
    }
}
