using System;
using System.Collections.Generic;
using System.IO;

namespace Library
{

    public class FileRepository
    {
        string _path;
        List<Employee> EmployeeList = new List<Employee>();
        public FileRepository()
        {
        string dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var path = Path.Combine(dir, "emploeeyes.csv");
        _path = path;

        if(!File.Exists(_path))
            {
                using (File.Create(_path)) { }
            }
        }

        public void SaveToFile(List<Employee> EmployeeList)
        {
            using (StreamWriter sw = File.CreateText(_path))
            {
                foreach (var employee in EmployeeList)
                {
                    var csv = $"{employee.Id},{employee.Password},{employee.Name},{employee.Adress},{employee.IsAdmin}";
                    sw.Write(csv);
                }
            }
        }
        public List<Employee> ReadFile()
        {
            using (StreamReader sr = File.OpenText(_path))
            {
                var line = string.Empty;
                while ((line = sr.ReadLine())!= null)
                {
                    var split = line.Split(',');
                    //Employee employee = new Employee(int.Parse(split[0]), split[1], split[2], split[3], bool.Parse(split[4]));
                }
            }
            return EmployeeList;
        }
    }
   
}
