using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211Final
{
    internal class Member
    {
        // Attributes
        private int _memberID;
        private string _firstName;
        private string _lastName;
        private string _email;
        private int _phone;
        private string _address;

        public int MemberID { get { return _memberID; } set { _memberID = value; } }
        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string LastName { get { return _lastName; } set { _lastName = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public int Phone { get { return _phone; } set { _phone = value; } }
        public string Address { get { return _address; } set { _address = value; } }

        // Constructor
        public Member(int memberID, string firstName, string lastName, string email, int phone, string address)
        {
            _memberID = memberID;
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _phone = phone;
            _address = address;
        }

        // Methods

        // Register
        public void Register(Member member)
        {
            return;
        }

        // UpdateMemberInfo
        public void UpdateMemberInfo(int memberID)
        {
            return;
        }

        // ViewHistory
        public void ViewHistory(int memberID)
        {
            return;
        }
    }
}
