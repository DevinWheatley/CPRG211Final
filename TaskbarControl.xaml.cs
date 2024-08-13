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

namespace CPRG211Final
{
    /// <summary>
    /// Interaction logic for TaskbarControl.xaml
    /// </summary>
    public partial class TaskbarControl : UserControl
    {
        public event RoutedEventHandler ShowManageBooksClick;
        public event RoutedEventHandler ShowManageMembersClick;
        public event RoutedEventHandler ShowManageStaffClick;
        public event RoutedEventHandler ShowCheckInOutClick;

        public TaskbarControl()
        {
            InitializeComponent();
        }



        // ShowManageBooks
        private void ShowManageBooks(object sender, RoutedEventArgs e)
        {
            ShowManageBooksClick?.Invoke(this, e);
        }

        // ShowManageMembers
        private void ShowManageMembers(object sender, RoutedEventArgs e)
        {
            ShowManageMembersClick?.Invoke(this, e);
        }

        // ShowManageStaff
        private void ShowManageStaff(object sender, RoutedEventArgs e)
        {
            ShowManageStaffClick?.Invoke(this, e);
        }

        // ShowManageCheckInOut
        private void ShowCheckInOut(object sender, RoutedEventArgs e)
        {
            ShowCheckInOutClick?.Invoke(this, e);
        }
    }
}
