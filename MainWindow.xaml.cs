using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CPRG211Final
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            taskbarControl.ShowManageBooksClick += TaskbarControl_ShowManageBooksClick;
            taskbarControl.ShowManageMembersClick += TaskbarControl_ShowManageMembersClick;
            taskbarControl.ShowManageStaffClick += TaskbarControl_ShowManageStaffClick;
            taskbarControl.ShowCheckInOutClick += TaskbarControl_ShowCheckInOutClick;
        }

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