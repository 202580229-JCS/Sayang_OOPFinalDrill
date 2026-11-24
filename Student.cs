namespace AseanPhonebook
{

    public class Student
    {
        public string StudentNumber { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string Occupation { get; set; }
        public char Gender { get; set; }        
        public int CountryCode { get; set; }
        public string AreaCode { get; set; }
        public string PhoneNumber { get; set; }

        public Student(string studentNumber, string surname, string firstName, string occupation,
                       char gender, int countryCode, string areaCode, string phoneNumber)
        {
            StudentNumber = studentNumber;
            Surname = surname;
            FirstName = firstName;
            Occupation = occupation;
            Gender = gender;
            CountryCode = countryCode;
            AreaCode = areaCode;
            PhoneNumber = phoneNumber;
        }

        public string FullNumber
        {
            get { return CountryCode + "-" + AreaCode + "-" + PhoneNumber; }
        }

        private string Possessive
        {
            get { return Gender == 'M' ? "His" : "Her"; }
        }

        public string ToEditDisplay()
        {
            return FirstName + " " + Surname + " is a " + Occupation + ". " +
                   Possessive + " number is " + FullNumber;
        }

        public string ToSearchDisplay()
        {
            return Surname + ", " + FirstName + ", with student number " + StudentNumber +
                   ", is a " + Occupation + ". " + Possessive + " phone number is " + FullNumber;
        }
    }
}