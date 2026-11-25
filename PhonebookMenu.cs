using System;
using System.Collections.Generic;

namespace AseanPhonebook
{
    public class PhonebookMenu
    {
        private readonly Phonebook book = new Phonebook();

        public void Run()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("[1] Store to ASEAN phonebook");
                Console.WriteLine("[2] Edit entry in ASEAN phonebook");
                Console.WriteLine("[3] Search ASEAN phonebook by country");
                Console.WriteLine("[4] Exit");
                Console.Write("Enter choice: ");
                string choice = (Console.ReadLine() ?? "").Trim();

                switch (choice)
                {
                    case "1": StoreEntries(); break;
                    case "2": EditEntry(); break;
                    case "3": SearchByCountry(); break;
                    case "4": running = false; break;
                    default: Console.WriteLine("Invalid option."); break;
                }
            }
        }

        private void StoreEntries()
        {
            do
            {
                string number = ConsoleInput.ReadUniqueStudentNumber("Enter student number: ", book);
                string surname = ConsoleInput.ReadNonEmpty("Enter surname: ");
                string first = ConsoleInput.ReadNonEmpty("Enter first name: ");
                string occupation = ConsoleInput.ReadNonEmpty("Enter occupation: ");
                char gender = ConsoleInput.ReadGender("Enter gender (M for male, F for female): ");
                int country = ConsoleInput.ReadCountryCode("Enter country code: ");
                string area = ConsoleInput.ReadNonEmpty("Enter area code: ");
                string phone = ConsoleInput.ReadNonEmpty("Enter number: ");

                book.Add(new Student(number, surname, first, occupation, gender, country, area, phone));

                Console.WriteLine("Student successfully added to the ASEAN phonebook.");
            }
            while (ConsoleInput.ReadYesNo("Do you want to enter another entry [Y/N]? "));
        }

        private void EditEntry()
        {
            Console.Write("Enter student number: ");
            string number = (Console.ReadLine() ?? "").Trim();
            Student s = book.FindByStudentNumber(number);
            if (s == null)
            {
                Console.WriteLine("Error: student number does not exist.");
                return;
            }

            int choice;
            do
            {
                Console.WriteLine("Here is the existing information about " + s.StudentNumber + ":");
                Console.WriteLine(s.ToEditDisplay());
                Console.WriteLine();
                Console.WriteLine("Which of the following information do you wish to change?");
                Console.WriteLine("[1] Student number [2] Surname [3] Gender [4] Occupation");
                Console.WriteLine("[5] Country code [6] Area code [7] Phone number");
                Console.WriteLine("[8] None - Go back to main menu");
                choice = ConsoleInput.ReadInt("Enter choice: ");

                switch (choice)
                {
                    case 1:
                        s.StudentNumber = ConsoleInput.ReadUniqueStudentNumber("Enter new student number: ", book);
                        break;
                    case 2:
                        s.Surname = ConsoleInput.ReadNonEmpty("Enter new surname: ");
                        break;
                    case 3:
                        s.Gender = ConsoleInput.ReadGender("Enter new gender (M for male, F for female): ");
                        break;
                    case 4:
                        s.Occupation = ConsoleInput.ReadNonEmpty("Enter new occupation: ");
                        break;
                    case 5:
                        s.CountryCode = ConsoleInput.ReadCountryCode("Enter new country code: ");
                        break;
                    case 6:
                        s.AreaCode = ConsoleInput.ReadNonEmpty("Enter new area code: ");
                        break;
                    case 7:
                        s.PhoneNumber = ConsoleInput.ReadNonEmpty("Enter new phone number: ");
                        break;
                    case 8:
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
                Console.WriteLine();
            }
            while (choice != 8);
        }

        private void SearchByCountry()
        {
            Console.WriteLine("From which country:");
            Console.WriteLine("[1] Philippines [2] Thailand [3] Singapore [4] Indonesia");
            Console.WriteLine("[5] Malaysia [6] ALL [0] No More");

            HashSet<int> selectedCodes = new HashSet<int>();
            List<string> selectedNames = new List<string>();
            bool all = false;
            int n = 1;

            while (true)
            {
                int choice = ConsoleInput.ReadInt("Enter choice " + n + ": ");
                if (choice == 0) break;

                if (choice == 6)
                {
                    all = true;
                    break;
                }
                if (choice < 1 || choice > 5)
                {
                    Console.WriteLine("Invalid option.");
                    continue;
                }

                Country c = CountryRegistry.Countries[choice - 1];
                if (selectedCodes.Add(c.Code)) selectedNames.Add(c.Name);
                n++;
            }

            if (!all && selectedCodes.Count == 0)
            {
                Console.WriteLine("No country selected.");
                return;
            }

            List<Student> results = book.SearchByCountryCodes(selectedCodes, all);

            string label = "all countries";
            if (!all)
            {
                label = selectedNames[0];
                for (int i = 1; i < selectedNames.Count; i++)
                    label += (i == selectedNames.Count - 1 ? " and " : ", ") + selectedNames[i];
            }
            Console.WriteLine("Here are the students from " + label + ":");
            if (results.Count == 0) Console.WriteLine("(no students found)");
            foreach (Student s in results)
                Console.WriteLine(s.ToSearchDisplay());
        }
    }
}
