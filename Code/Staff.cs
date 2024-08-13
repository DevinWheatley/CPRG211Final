using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211Final
{
    internal class Staff
    {
        // Attributes
        private int _staffID;
        private string _firstName;
        private string _lastName;
        private string _role;
        private string _email;
        private int _phone;
        private string _address;
        private DateTime _hireDate;

        public int StaffID { get { return _staffID; } set { _staffID = value; } }
        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string LastName { get { return _lastName; } set { _lastName = value; } }
        public string Role { get { return _role; } set { _role = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public int Phone { get { return _phone; } set { _phone = value; } }
        public string Address { get { return _address; } set { _address = value; } }
        public DateTime HireDate { get { return _hireDate; } set { _hireDate = value; } }

        // Constructor
        public Staff(int staffID, string firstName, string lastName, string role, string email, int phone, string address, DateTime hireDate)
        {
            _staffID = staffID;
            _firstName = firstName;
            _lastName = lastName;
            _role = role;
            _email = email;
            _phone = phone;
            _address = address;
            _hireDate = hireDate;
        }

        // Methods

        // AddStaff
        public void AddStaff(Staff staff)
        {
            return;
        }

        // RemoveStaff
        public void RemoveStaff(int staffID)
        {
            return;
        }
    }
}
