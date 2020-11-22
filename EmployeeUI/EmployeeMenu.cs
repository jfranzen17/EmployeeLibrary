using System;
using System.Collections.Generic;
using System.Text;
using Library;

namespace EmployeeUI
{
    class EmployeeMenu
    {
        private List<Employee> EmployeeList = new List<Employee>();
        private static FileRepository _fileRepository;

        public void Run()
        {
            FirstMenu();
        }
        public void FirstMenu()
        {

            Console.WriteLine("1: Login as Employee \n2: Register as a Employee");
            int input = int.Parse(Console.ReadLine());
            if (input == 1)
            {
                LogIn();
            }
            else
            {
                Employee employee = new Employee();
                Guid id = Guid.NewGuid();
                Console.WriteLine($"New ID: {id} \n Enter password: ");
                employee.Password = Console.ReadLine();
                Console.WriteLine("Enter your name: ");
                employee.Name = Console.ReadLine();
                Console.WriteLine("Enter your adress: ");
                employee.Adress = Console.ReadLine();
                employee.IsAdmin = false;
                EmployeeList.Add(employee);
                _fileRepository.SaveToFile(EmployeeList);
                LogIn();
            }
        }
        public bool LogIn()
        {
            EmployeeList = _fileRepository.ReadFile();
            Console.WriteLine("---------- Employee Login ----------");
            Employee employee = null;
            do
            {
                Console.Write("\nEnter first name: ");
                var inputName = Console.ReadLine();
                employee = GetAllNames(inputName);
                if (employee == null)
                {
                    Console.WriteLine("Incorrect name.");
                }
                if (employee != null)
                {
                    var _latestEmployee = employee;
                    var inputPassword = string.Empty;
                    do
                    {
                        Console.Write("\nEnter password: ");
                        inputPassword = Console.ReadLine();
                        if (inputPassword != _latestEmployee.Password)
                        {
                            Console.WriteLine("Incorrect password.");
                        }
                    } while (inputPassword != _latestEmployee.Password);
                    Console.WriteLine($"Welcome {_latestEmployee.Name}!");
                    break;
                }
            } while (employee == null);

            return false;
        }
        public Employee GetAllNames(string Name)
        {
            foreach (var employee in EmployeeList)
            {
                if (Name == employee.Name)
                {
                    return employee;
                }
            }
            return null;
        }
        public void LoggedInMenu()
        {

            Console.WriteLine("Welcome!!! \n 1: Edit your profile \n2: LogOut");
            int input = int.Parse(Console.ReadLine());
            if (input == 1)
            {
                Employee employee = new Employee();
                Console.WriteLine("Enter your new password: ");
                employee.Password = Console.ReadLine();
                Console.WriteLine("Enter your new name: ");
                employee.Name = Console.ReadLine();
                Console.WriteLine("Enter your new adress: ");
                employee.Adress = Console.ReadLine();
                employee.IsAdmin = false;
                EmployeeList.Add(employee);
                _fileRepository.SaveToFile(EmployeeList);
            }
            else
            {
                Console.WriteLine("Bye!");
                FirstMenu();
            }
        }
    }
}
