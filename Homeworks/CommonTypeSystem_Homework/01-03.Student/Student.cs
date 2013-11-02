using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _01_03.Student
{
    class Student : ICloneable, IComparable<Student>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public BigInteger SSN { get; set; }  //because Math.Abs(uint) return incorrect result
        public string Address { get; set; }
        public uint MobilePhone { get; set; }
        public string Email { get; set; }
        public byte Course { get; set; }
        public Specialty Specialty { get; set; }
        public University University { get; set; }
        public Faculty Faculty { get; set; }

        public Student(string firstName, string middleName, string lastName, BigInteger socialNumber,
            string address, uint phone, string email, byte course, Specialty specialty, University university, Faculty faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = socialNumber;
            this.Address = address;
            this.MobilePhone = phone;
            this.Email = email;
            this.Course = course;
            this.Specialty = specialty;
            this.University = university;
            this.Faculty = faculty;
        }

        public override bool Equals(object obj)
        {
            Student student = obj as Student;
            if ((object)student == null)
            {
                return false;
            }
            else if (this.SSN != student.SSN)
            {
                return false;
            }
            return true;
        }

        public static bool operator ==(Student student1, Student student2)
        {
            return Student.Equals(student1, student2);
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return !(Student.Equals(student1, student2));
        }

        public override int GetHashCode()
        {
            return SSN.GetHashCode()^FirstName.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("Name: {0} {1} {2}", this.FirstName, this.MiddleName, this.LastName);
            result.AppendFormat("\r\nSSN: {0}", this.SSN);
            result.AppendFormat("\r\nAddress: {0}", this.Address);
            result.AppendFormat("\r\nMobile Phone: {0}", this.MobilePhone);
            result.AppendFormat("\r\nE-mail: {0}", this.Email);
            result.AppendFormat("\r\nUniversity: {0}", this.University);
            result.AppendFormat("\r\nFaculty: {0}", this.Faculty);
            result.AppendFormat("\r\nSpecialty: {0}", this.Specialty);
            result.AppendFormat("\r\nCourse: {0}", this.Course);
            return result.ToString();
        }

        public Student Clone()
        {
            Student deepCloneStudent = new Student(this.FirstName, this.MiddleName, this.LastName, this.SSN,
                this.Address, this.MobilePhone, this.Email, this.Course, this.Specialty, this.University, this.Faculty);
            return deepCloneStudent;
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public int CompareTo(Student student)
        {
            if (this.FirstName != student.FirstName)
            {
                return String.Compare(this.FirstName, student.FirstName);
            }
            if (this.MiddleName != student.MiddleName)
            {
                return String.Compare(this.MiddleName, student.MiddleName);
            }
            if (this.LastName != student.LastName)
            {
                return String.Compare(this.LastName, student.LastName);
            }
            if (this.SSN != student.SSN)
            {
                return (int) ((this.SSN-student.SSN)/BigInteger.Abs(this.SSN - student.SSN));
            }
            return 0;
        }
    }
}
