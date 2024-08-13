using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Principal;
using System.Net;

namespace CPRG211Final
{
    internal class Book
    {
        // Attributes
        private int _bookID;
        private string _title;
        private string _author;
        private string _isbn;
        private string _genre;
        private bool _availability;

        public int BookID { get { return _bookID; } set { _bookID = value; } }
        public string Title { get { return _title; } set { _title = value; } }
        public string Author { get { return _author; } set { _author = value; } }
        public string ISBN { get { return _isbn; } set { _isbn = value; } }
        public string Genre { get { return _genre; } set { _genre = value; } }
        public bool Availability { get { return _availability; } set { _availability = value; } }

        // FilePath for books.bin file
        private readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "books.bin");

        // Constructor
        public Book() { }
        public Book(int bookID, string title, string author, string isbn, string genre, bool availability)
        {
            _bookID = bookID;
            _title = title;
            _author = author;
            _isbn = isbn;
            _genre = genre;
            _availability = availability;
        }

        // Main Methods

        // AddBook
        // Returns true if book was added
        // Returns false if book not added
        public bool AddBook(Book addBook)
        {
            List<Book> books = LoadBookBinFile();

            if (!CheckBookID(addBook.BookID)) // Checks for Unique Book ID
            {
                books.Add(addBook);

                using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
                {
                    foreach (Book book in books)
                    {
                        writer.Write(book.BookID);
                        writer.Write(book.Title);
                        writer.Write(book.Author);
                        writer.Write(book.ISBN);
                        writer.Write(book.Genre);
                        writer.Write(book.Availability);
                    }
                }
                return true;
            }
            return false;
        }

        // UpdateBookInfo
        public void UpdateBookInfo(Book updatedBook, int updateID)
        {
            List<Book> books = LoadBookBinFile();

            // Find the book with the matching ID
            var bookToUpdate = books.FirstOrDefault(b => b.BookID == updateID);

            if (bookToUpdate != null)
            {
                // Update the book's details
                bookToUpdate.BookID = updatedBook.BookID;
                bookToUpdate.Title = updatedBook.Title;
                bookToUpdate.Author = updatedBook.Author;
                bookToUpdate.ISBN = updatedBook.ISBN;
                bookToUpdate.Genre = updatedBook.Genre;
                bookToUpdate.Availability = updatedBook.Availability;

                // Write the updated list back to the file
                using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
                {
                    foreach (Book bk in books)
                    {
                        writer.Write(bk.BookID);
                        writer.Write(bk.Title);
                        writer.Write(bk.Author);
                        writer.Write(bk.ISBN);
                        writer.Write(bk.Genre);
                        writer.Write(bk.Availability);
                    }
                }
            }
        }


        // CheckAvailability
        public void CheckAvailability()
        {
            return;
        }

        // RemoveBook
        public void RemoveBook(int bookID)
        {
            List<Book> books = LoadBookBinFile();

            // Find the book with the matching ID
            var bookToRemove = books.FirstOrDefault(b => b.BookID == bookID);

            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);

                using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
                {
                    foreach (Book bk in books)
                    {
                        writer.Write(bk.BookID);
                        writer.Write(bk.Title);
                        writer.Write(bk.Author);
                        writer.Write(bk.ISBN);
                        writer.Write(bk.Genre);
                        writer.Write(bk.Availability);
                    }
                }
            }
        }

        // Search Books
        public Book SearchBooks(int bookID)
        {
            List<Book> books = LoadBookBinFile();

            Book book = books.FirstOrDefault(b => b.BookID == bookID);

            return book;
        }





        // Bin File Methods

        // Check File Exists
        // If not, create it
        public void CheckBooksBinExist()
        {
            if (!File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create)) // Create the file if it does not exist
                {
                }
            }
        }

        // Load Bin File
        public List<Book> LoadBookBinFile()
        {
            var books = new List<Book>();

            if (!File.Exists(filePath))
            {
                return books; // Return empty list if the bin file doesn't exist
            }

            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    var bookID = reader.ReadInt32();
                    var title = reader.ReadString();
                    var author = reader.ReadString();
                    var isbn = reader.ReadString();
                    var genre = reader.ReadString();
                    var availability = reader.ReadBoolean();

                    books.Add(new Book(bookID, title, author, isbn, genre, availability));
                }
            }
            return books;
        }

        // Check Unique ID
        // Returns true if match
        // Returns false if no match
        public bool CheckBookID(int bookID)
        {
            List<Book> books = LoadBookBinFile();

            foreach (Book book in books)
            {
                if (bookID == book.BookID)
                {
                    return true;
                }
            }
            return false;
        }
    }

}
