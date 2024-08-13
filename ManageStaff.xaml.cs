using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
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

namespace CPRG211Final
{
    /// <summary>
    /// Interaction logic for ManageStaff.xaml
    /// </summary>
    public partial class ManageStaff : Window
    {
        public ManageStaff()
        {
            InitializeComponent();
            taskbarControl.ShowManageBooksClick += TaskbarControl_ShowManageBooksClick;
            taskbarControl.ShowManageMembersClick += TaskbarControl_ShowManageMembersClick;
            taskbarControl.ShowManageStaffClick += TaskbarControl_ShowManageStaffClick;
            taskbarControl.ShowCheckInOutClick += TaskbarControl_ShowCheckInOutClick;
        }



        // AddStaff
        private void AddStaff(object sender, RoutedEventArgs e)
        {
            int staffID = int.Parse(inputStaffID.Text);
            string firstName = inputFirstName.Text;
            string lastName = inputLastName.Text;
            string role = inputRole.Text;
            string email = inputEmail.Text;
            int phone = int.Parse(inputPhone.Text);
            string address = inputAddress.Text;
            DateTime hireDate;

            // Attempt to parse the hire date
            if (!DateTime.TryParse(inputHireDate.Text, out hireDate))
            {
                AddMessage.Text = "Error: Invalid date format.";
                return;
            }

            Staff staff = new Staff(staffID, firstName, lastName, role, email, phone, address, hireDate);

            if (staff.AddStaff(staff))
            {
                AddMessage.Text = "Staff Successfully Added";
            }
            else
            {
                AddMessage.Text = "Error: Staff Not Added";
            }
        }


        // RemoveStaff
        private void RemoveStaff(object sender, RoutedEventArgs e)
        {
            int removeID = int.Parse(TextBlockID.Text);

            Staff book = new Staff();

            book.RemoveStaff(removeID);
        }

        // SearchStaff
        private void SearchStaff(object sender, RoutedEventArgs e)
        {
            int searchID = int.Parse(inputSearch.Text);

            Staff staff = new Staff();

            Staff searchStaff = staff.SearchStaff(searchID);

            if (searchStaff != null)
            {
                TextBlockID.Text = searchStaff.StaffID.ToString();
                TextBlockFirstName.Text = searchStaff.FirstName;
                TextBlockLastName.Text = searchStaff.LastName;
                TextBlockRole.Text = searchStaff.Role;
                TextBlockEmail.Text = searchStaff.Email;
                TextBlockPhone.Text = searchStaff.Phone.ToString();
                TextBlockAddress.Text = searchStaff.Address;
                TextBlockHireDate.Text = searchStaff.HireDate.ToString("yyyy-MM-dd");
            }
            else
            {
                TextBlockID.Text = "No Match";
                TextBlockFirstName.Text = "";
                TextBlockLastName.Text = "";
                TextBlockRole.Text = "";
                TextBlockEmail.Text = "";
                TextBlockPhone.Text = "";
                TextBlockAddress.Text = "";
                TextBlockHireDate.Text = "";
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
