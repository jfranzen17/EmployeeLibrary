using System;
using System.Collections.Generic;
using System.Text;
using Library;

namespace AdminUI
{
    public class AdminLoginMenu
    {
        private List<Employee> EmployeeList=new List<Employee>();
        private static FileRepository _fileRepository;
        public void Run()
        {

            Console.WriteLine("1: Login as Admin \n 2: Register as a Admin");
            int input = int.Parse(Console.ReadLine());
            if (input == 1)
            {
                LogIn();
                LoggedInMenu();
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
                employee.IsAdmin = true;
                EmployeeList.Add(employee);
                _fileRepository.SaveToFile(EmployeeList);
                Console.WriteLine("Thank You");
                LogIn();
            }
            bool LogIn()
            {
                EmployeeList = _fileRepository.ReadFile();
                Console.WriteLine("---------- Admin Login ----------");
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
            Employee GetAllNames(string Name)
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
            void LoggedInMenu()
            {

                Console.WriteLine("---------- Admin Login ----------\n 1: Create an Employee \n 2: Remove an Employee");
                int input = int.Parse(Console.ReadLine());
                if (input == 1)
                {
                    CreateEmployee();

                }
                else if (input == 2)
                {
                    RemoveEmployee();
                }
            }

            void CreateEmployee()
            {
                Employee employee = new Employee();
                Guid id = Guid.NewGuid();
                Console.WriteLine($"New employee ID: {id}");
                Console.WriteLine("Enter password: ");
                employee.Password = Console.ReadLine();
                Console.WriteLine("Enter name: ");
                employee.Name = Console.ReadLine();
                Console.WriteLine("Enter adress: ");
                employee.Adress = Console.ReadLine();
                Console.WriteLine("Should the employee have Admin access? \n 1: Yes \n 2: No");
                int adminAccess = int.Parse(Console.ReadLine());
                if (adminAccess == 1)
                {
                    employee.IsAdmin = true;
                }
                else
                {
                    employee.IsAdmin = false;
                }
                EmployeeList.Add(employee);
                _fileRepository.SaveToFile(EmployeeList);
            }
            void RemoveEmployee()
            {
                Console.WriteLine("What name has the Employee you want to remove?");
                var emplyeeToRemove = Console.ReadLine();
                var employee = GetAllNames(emplyeeToRemove);
                if (employee == null)
                {
                    Console.WriteLine("Incorrect name.");
                    return;
                }
                EmployeeList.Remove(employee);
                _fileRepository.SaveToFile(EmployeeList);
                LoggedInMenu();
            }

        }



    }
}
