using System;
using System.Collections.Generic;
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
        public void BorrowBook()
        {
            return;
        }

        // ReturnBook
        public void ReturnBook(int loanID)
        {
            return;
        }

        // CheckDueDate
        public void CheckDueDate(int loanID)
        {
            return;
        }
    }

}
