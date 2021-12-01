using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public decimal Salary { get; set; }
        private List<string> address;
        public virtual List<string> GetAddress()
        {
            return address;
        }
        public virtual int GetAge()
        {
            return DateTime.Now.Year - Birth.Year;
        }
        public abstract decimal GetSalary();
    }
    
    public class Student: Person
    {
        public List<Course> Courses { get; set; }
        public Dictionary<string, char> Grades { get; set; }
        public double GetGPA()
        {
            double total = 0;
            int course = Grades.Count;
            var form = new Dictionary<char, double>() { { 'A', 4 }, { 'B', 3.5 }, { 'C', 3 }, { 'D', 2.5 }, { 'E', 2 }, { 'F', 1.5 } };
            foreach(var grade in Grades.Values)
            {
                total += form[grade];
            }
            double gpa = total / course;
            return gpa;
        }

        public override decimal GetSalary()
        {
            return 0;
        }
    }

    public class Instructor: Person
    {
        public string Department { get; set; }
        public bool Head { get; set; }
        public decimal Bonus { get; set; }
        public DateTime JoinDate { get; set; }
        public override decimal GetSalary()
        {
            return Salary + Bonus;
        }
        public int YearsOfExperience()
        {
            return DateTime.Now.Year - JoinDate.Year;
        }
    }
}