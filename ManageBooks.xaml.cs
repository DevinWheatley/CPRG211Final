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
using System.Windows.Shapes;

namespace CPRG211Final
{
    /// <summary>
    /// Interaction logic for ManageBooks.xaml
    /// </summary>
    public partial class ManageBooks : Window
    {
        public ManageBooks()
        {
            InitializeComponent();

            taskbarControl.ShowManageBooksClick += TaskbarControl_ShowManageBooksClick;
            taskbarControl.ShowManageMembersClick += TaskbarControl_ShowManageMembersClick;
            taskbarControl.ShowManageStaffClick += TaskbarControl_ShowManageStaffClick;
            taskbarControl.ShowCheckInOutClick += TaskbarControl_ShowCheckInOutClick;
        }

        // AddBook
        private void AddBook(object sender, RoutedEventArgs e)
        {
            int bookID = int.Parse(inputBookID.Text);
            string title = inputTitle.Text;
            string author = inputAuthor.Text;
            string isbn = inputISBN.Text;
            string genre = inputGenre.Text;
            bool availability = true;

            Book book = new Book(bookID, title, author, isbn, genre, availability);

            if (book.AddBook(book))
            {
                AddMessage.Text = "Book Successfully Added";
            }
            else
            {
                AddMessage.Text = "Error: Book Not Added";
            }
        }

        // RemoveBook
        private void RemoveBook(object sender, RoutedEventArgs e)
        {
            int removeID = int.Parse(TextBlockID.Text);

            Book book = new Book();

            book.RemoveBook(removeID);
        }

        // UpdateBook
        private void UpdateBook(object sender, RoutedEventArgs e)
        {
            int updateID = int.Parse(TextBlockID.Text);

            int bookID = int.Parse(inputUpdateBookID.Text);
            string title = inputUpdateTitle.Text;
            string author = inputUpdateAuthor.Text;
            string isbn = inputUpdateISBN.Text;
            string genre = inputUpdateGenre.Text;
            bool availability = true;

            Book book = new Book(bookID, title, author, isbn, genre, availability);

            book.UpdateBookInfo(book, updateID);
        }

        // SearchBook
        private void SearchBooks(object sender, RoutedEventArgs e)
        {
            int searchID = int.Parse(inputSearch.Text);

            Book book = new Book();

            Book searchBook = book.SearchBooks(searchID);

            if (searchBook != null)
            {
                TextBlockID.Text = searchBook.BookID.ToString();
                TextBlockTitle.Text = searchBook.Title;
                TextBlockAuthor.Text = searchBook.Author;
                TextBlockISBN.Text = searchBook.ISBN;
                TextBlockGenre.Text = searchBook.Genre;
            }
            else
            {
                TextBlockID.Text = "No Match";
                TextBlockTitle.Text = "";
                TextBlockAuthor.Text = "";
                TextBlockISBN.Text = "";
                TextBlockGenre.Text = "";
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