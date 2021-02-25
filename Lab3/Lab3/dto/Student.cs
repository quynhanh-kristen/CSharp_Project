using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.dto
{
    class Student
    {
        //Fullname;DOB;gender;national;phone;address; Qualification; Salary
        private string id;
        public string GetId()
        {
            return id;
        }
        private string fullname;
        public string GetFullname()
        {
            return fullname; 
        }
        private string dob;
        public string GetDob()
        {
            return dob;
        }
        private string gender;
        public string GetGender()
        {
            return gender;
        }
        private string national;
        public string GetNational()
        {
            return national;
        }
        private string phone;
        public string GetPhone()
        {
            return phone;
        }
        private string address;
        public string GetAddress()
        {
            return address;
        }
        private string major;
        public string GetMajor()
        {
            return major;
        }

        public Student(string id, string fullname, string dob, string gender, string national, string phone, string address, string major)
        {
            this.id = id;
            this.fullname = fullname;
            this.dob = dob;
            this.gender = gender;
            this.national = national;
            this.phone = phone;
            this.address = address;
            this.major = major;
        }

        public Student()
        {

        }
    }
}
