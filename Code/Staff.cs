using System;
using System.Collections.Generic;
using System.IO;
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
        public Staff() { }
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

        // Main Methods

        // AddStaff
        public bool AddStaff(Staff addStaff)
        {
            List<Staff> staffList = LoadStaffBinFile();

            if (!CheckStaffID(addStaff.StaffID)) // Checks for Unique Staff ID
            {
                staffList.Add(addStaff);

                using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Append)))
                {
                    foreach (Staff staff in staffList)
                    {
                        writer.Write(staff.StaffID);
                        writer.Write(staff.FirstName);
                        writer.Write(staff.LastName);
                        writer.Write(staff.Role);
                        writer.Write(staff.Email);
                        writer.Write(staff.Phone);
                        writer.Write(staff.Address);
                        writer.Write(staff.HireDate.ToString("yyyy-MM-dd"));
                    }
                }
                return true;
            }
            return false;
        }

        // RemoveStaff
        public void RemoveStaff(int staffID)
        {
            List<Staff> staffList = LoadStaffBinFile();

            var staffToRemove = staffList.FirstOrDefault(s => s.StaffID == staffID);
            if (staffToRemove != null)
            {
                staffList.Remove(staffToRemove);

                using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
                {
                    foreach (Staff staff in staffList)
                    {
                        writer.Write(staff.StaffID);
                        writer.Write(staff.FirstName);
                        writer.Write(staff.LastName);
                        writer.Write(staff.Role);
                        writer.Write(staff.Email);
                        writer.Write(staff.Phone);
                        writer.Write(staff.Address);
                        writer.Write(staff.HireDate.ToString("yyyy-MM-dd"));
                    }
                }
            }
        }

        // SearchStaff
        public Staff SearchStaff(int staffID)
        {
            List<Staff> staffList = LoadStaffBinFile();

            Staff staff = staffList.FirstOrDefault(b => b.StaffID == staffID);

            return staff;
        }










        // FilePath for staff.bin file
        private readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "staff.bin");

        // Bin File Methods

        // Check File Exists
        // If not, create it
        public void CheckStaffBinExist()
        {
            if (!File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Create)) // Create the file if it does not exist
                {
                }
            }
        }

        // Load Bin File
        public List<Staff> LoadStaffBinFile()
        {
            CheckStaffBinExist();

            var staffList = new List<Staff>();

            if (!File.Exists(filePath))
            {
                return staffList; // Return empty list if the bin file doesn't exist
            }

            using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
            {
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    var staffID = reader.ReadInt32();
                    var firstName = reader.ReadString();
                    var lastName = reader.ReadString();
                    var role = reader.ReadString();
                    var email = reader.ReadString();
                    var phone = reader.ReadInt32();
                    var address = reader.ReadString();
                    var hireDateString = reader.ReadString(); // "yyyy-MM-dd"

                    DateTime hireDate;
                    if (!DateTime.TryParse(hireDateString, out hireDate))
                    {
                        // Handle parsing failure (optional)
                        throw new FormatException($"Unable to parse '{hireDateString}' to DateTime.");
                    }

                    staffList.Add(new Staff(staffID, firstName, lastName, role, email, phone, address, hireDate));
                }
            }
            return staffList;
        }

        // Check Unique ID
        // Returns true if match
        // Returns false if no match
        public bool CheckStaffID(int staffID)
        {
            List<Staff> staffList = LoadStaffBinFile();

            foreach (Staff staff in staffList)
            {
                if (staffID == staff.StaffID)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
