using System;
using System.Collections.Generic;

namespace AseanPhonebook
{
    public class Phonebook
    {
        private readonly List<Student> students = new List<Student>();

        public void Add(Student student)
        {
            students.Add(student);
        }

        public bool Exists(string studentNumber)
        {
            return FindByStudentNumber(studentNumber) != null;
        }

        public Student FindByStudentNumber(string studentNumber)
        {
            foreach (Student s in students)
            {
                if (string.Equals(s.StudentNumber, studentNumber, StringComparison.OrdinalIgnoreCase))
                    return s;
            }
            return null;
        }

        public List<Student> SearchByCountryCodes(ICollection<int> countryCodes, bool all)
        {
            List<Student> result = new List<Student>();
            foreach (Student s in students)
            {
                if (all || countryCodes.Contains(s.CountryCode))
                    result.Add(s);
            }

            result.Sort(delegate (Student a, Student b)
            {
                int cmp = string.Compare(a.Surname, b.Surname, StringComparison.OrdinalIgnoreCase);
                if (cmp != 0) return cmp;
                return string.Compare(a.FirstName, b.FirstName, StringComparison.OrdinalIgnoreCase);
            });
            return result;
        }
    }
}