using System;

namespace AseanPhonebook
{
    public static class ConsoleInput
    {
        public static string ReadNonEmpty(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string s = (Console.ReadLine() ?? "").Trim();
                if (s.Length > 0) return s;
                Console.WriteLine("Input cannot be empty. Try again.");
            }
        }

        public static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                int n;
                if (int.TryParse((Console.ReadLine() ?? "").Trim(), out n)) return n;
                Console.WriteLine("Please enter a number.");
            }
        }

        public static char ReadGender(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string s = (Console.ReadLine() ?? "").Trim().ToUpper();
                if (s == "M" || s == "F") return s[0];
                Console.WriteLine("Please enter M or F.");
            }
        }

        public static bool ReadYesNo(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string s = (Console.ReadLine() ?? "").Trim().ToUpper();
                if (s == "Y") return true;
                if (s == "N") return false;
                Console.WriteLine("Please enter Y or N.");
            }
        }
        public static int ReadCountryCode(string prompt)
        {
            while (true)
            {
                int code = ReadInt(prompt);
                if (CountryRegistry.IsValidCode(code)) return code;
                Console.WriteLine("Invalid country code. Valid codes: 60, 62, 63, 65, 66.");
            }
        }
        public static string ReadUniqueStudentNumber(string prompt, Phonebook book)
        {
            while (true)
            {
                string number = ReadNonEmpty(prompt);
                if (!book.Exists(number)) return number;
                Console.WriteLine("That student number already exists. Try another.");
            }
        }
    }
}