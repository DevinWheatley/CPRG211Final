using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211Final
{
    internal class Loan
    {
        // Attributes
        private int _loanID;
        private int _memberID;
        private int _bookID;
        private DateTime _loanDate;
        private DateTime _dueDate;
        private DateTime? _returnDate; // Nullable to handle cases where the book hasn't been returned yet

        public int LoanID { get { return _loanID; } set { _loanID = value; } }
        public int MemberID { get { return _memberID; } set { _memberID = value; } }
        public int BookID { get { return _bookID; } set { _bookID = value; } }
        public DateTime LoanDate { get { return _loanDate; } set { _loanDate = value; } }
        public DateTime DueDate { get { return _dueDate; } set { _dueDate = value; } }
        public DateTime? ReturnDate { get { return _returnDate; } set { _returnDate = value; } } 

        // Constructor
        public Loan() { }
        public Loan(int loanID, int memberID, int bookID, DateTime loanDate, DateTime dueDate, DateTime? returnDate = null)
        {
            _loanID = loanID;
            _memberID = memberID;
            _bookID = bookID;
            _loanDate = loanDate;
            _dueDate = dueDate;
            _returnDate = returnDate;
        }

        // Methods

        // BorrowBook
        public bool BorrowBook(Loan borrowBook)
        {
            List<Loan> loanList = LoadLoanBinFile();

            if (!CheckLoanID(borrowBook.LoanID))
            {
                loanList.Add(borrowBook);

                using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Append)))
                {
                    foreach (Loan loan in loanList)
                    {
                        writer.Write(loan.LoanID);
                        writer.Write(loan.MemberID);
                        writer.Write(loan.BookID);
                        writer.Write(loan.LoanDate.ToString("yyyy-MM-dd"));
                        writer.Write(loan.DueDate.ToString("yyyy-MM-dd"));
                        writer.Write(loan.ReturnDate?.ToString("yyyy-MM-dd") ?? string.Empty);
                    }
                }
                return true;
            }
            return false;
        }

        // ReturnBook
        public void ReturnBook(int loanID, DateTime returnDate)
        {
            List<Loan> loanList = LoadLoanBinFile();

            var returnBook = loanList.FirstOrDefault(loan => loan.LoanID == loanID);
            if (returnBook != null)
            {
                returnBook.ReturnDate = returnDate;
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                foreach (Loan loan in loanList)
                {
                    writer.Write(loan.LoanID);
                    writer.Write(loan.MemberID);
                    writer.Write(loan.BookID);
                    writer.Write(loan.LoanDate.ToString("yyyy-MM-dd"));
                    writer.Write(loan.DueDate.ToString("yyyy-MM-dd"));
                    writer.Write(loan.ReturnDate?.ToString("yyyy-MM-dd") ?? string.Empty);
                }
            }
        }

        // CheckDueDate
        public DateTime CheckDueDate(int loanID)
        {
            List<Loan> loanList = LoadLoanBinFile();

            Loan checkToDueDate = loanList.FirstOrDefault(loan => loan.LoanID == loanID);

            if (checkToDueDate == null)
            {
                throw new InvalidOperationException($"No loan found with LoanID: {loanID}");
            }

            return checkToDueDate.DueDate;
        }
        


        // FilePath for staff.bin file
        private readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "loan.bin");

        // Bin File Methods

        // Check File Exists
        // If not, create it
        public void CheckLoanBinExist()
        {
            if (!File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create)) // Create the file if it does not exist
                {
                }
            }
        }

        // Load Bin File
        public List<Loan> LoadLoanBinFile()
        {
            CheckLoanBinExist();

            var loanList = new List<Loan>();

            if (!File.Exists(filePath))
            {
                return loanList; // Return empty list if the bin file doesn't exist
            }

            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    var loanID = reader.ReadInt32();
                    var memberID = reader.ReadInt32();
                    var bookID = reader.ReadInt32();
                    var loanDateString = reader.ReadString();  // "yyyy-MM-dd"
                    var dueDateString = reader.ReadString();  // "yyyy-MM-dd"
                    var returnDateString = reader.ReadString(); // "yyyy-MM-dd" or null

                    DateTime loanDate;
                    if (!DateTime.TryParse(loanDateString, out loanDate))
                    {
                        // Handle parsing failure (optional)
                        throw new FormatException($"Unable to parse '{loanDateString}' to DateTime.");
                    }

                    DateTime dueDate;
                    if (!DateTime.TryParse(dueDateString, out dueDate))
                    {
                        // Handle parsing failure (optional)
                        throw new FormatException($"Unable to parse '{dueDateString}' to DateTime.");
                    }

                    DateTime? returnDate = null;
                    // check if returnDateString is null or empty
                    if (!string.IsNullOrEmpty(returnDateString))
                    {
                        // if returnDateString is not null or empty it tries to convert to DateTime
                        if (!DateTime.TryParse(returnDateString, out DateTime tempReturnDate))
                        {
                            throw new FormatException($"Unalbe to parse '{returnDateString}' to DateTime.");
                        }
                        returnDate = tempReturnDate;
                    }

                    loanList.Add(new Loan(loanID, memberID, bookID, loanDate, dueDate, returnDate));
                }
            }
            return loanList;
        }

        public bool CheckLoanID(int loanID)
        {
            List<Loan> loanList = LoadLoanBinFile();

            foreach (Loan loan in loanList)
            {
                if (loanID == loan.LoanID)
                {
                    return true;
                }
            }
            return false;
        }
    }

}
