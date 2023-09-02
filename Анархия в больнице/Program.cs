using System;
using System.Collections.Generic;
using System.Linq;

namespace Анархия_в_больнице
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hospital hospital = new Hospital();

            hospital.Work();
        }
    }

    class Patient
    {
        public Patient(string name, int age, string disease)
        {
            Name = name;
            Age = age;
            Disease = disease;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Disease { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя: {Name}, Возраст: {Age}, Заболевание: {Disease}");
        }
    }

    class Hospital
    {
        private List<Patient> _patients;

        public Hospital()
        {
            _patients = Create();
        }

        public void Work()
        {
            const string CommandSortByName = "1";
            const string CommandSortByAge = "2";
            const string CommandSortByDisease = "3";

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("Список всех больных\n");
                ShowInfo(_patients);

                Console.WriteLine();
                Console.WriteLine($"{CommandSortByName} - Сортиравка по имени");
                Console.WriteLine($"{CommandSortByAge} - Сортировать по возрасту");
                Console.WriteLine($"{CommandSortByDisease} - Сортировать по болезни");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandSortByName:
                        SortByName();
                        break;

                    case CommandSortByAge:
                        SortByAge();
                        break;

                    case CommandSortByDisease:
                        SortByDisease();
                        break;

                    default:
                        Console.WriteLine("Некорректный ввод");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private void SortByName()
        {
            Console.WriteLine("Введите имя");
            string introducedName = Console.ReadLine();

            var sortedList = _patients.Where(patient => patient.Name == introducedName);

            ShowInfo(sortedList);
        }

        private void SortByAge()
        {
            Console.WriteLine("Введите возраст");
            int introducedAge = ReadAge();

            var sortedList = _patients.Where(patient => patient.Age == introducedAge);

            ShowInfo(sortedList);
        }

        private void SortByDisease()
        {
            Console.WriteLine("Введите заболевание");
            string introducedDisease = Console.ReadLine();

            var sortedList = _patients.Where(patient => patient.Disease == introducedDisease);

            ShowInfo(sortedList);
        }

        private List<Patient> Create()
        {
            List<Patient> patients = new List<Patient>()
            {
                new Patient("Елизавета", 19, "Камни в почках"),
                new Patient("Валерий", 25, "Апендицит"),
                new Patient("Аркадий", 35, "Язва"),
                new Patient("Мария", 65, "Тошнота"),
                new Patient("Елизавета", 47, "Апендицит"),
                new Patient("Эдуард", 63, "Язва"),
                new Patient("Светлана", 49, "Апендицит"),
                new Patient("Валерий", 34, "Тошнота"),
                new Patient("Елизавета", 28, "Камни в почках"),
                new Patient("Мария", 48, "Апендицит"),
            };

            return patients;
        }

        private void ShowInfo(List<Patient> patients)
        {
            foreach (Patient patient in patients)
            {
                patient.ShowInfo();
            }
        }

        private void ShowInfo(IEnumerable<Patient> patients)
        {
            foreach (Patient patient in patients)
            {
                patient.ShowInfo();
            }
        }

        private int ReadAge()
        {
            int number = 0;

            bool result = false;

            while (result == false)
            {
                result = int.TryParse(Console.ReadLine(), out number);

                if (result == false)
                {
                    Console.WriteLine("Ошибка. Введите число.");
                }
            }

            return number;
        }
    }
}
