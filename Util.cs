using System;
using System.IO;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
  class Util
  {

    // accept user input to build a list of employee names

    public static List<Employee> GetEmployees()
    {
      List<Employee> employees = new List<Employee>();
      while (true)
      {
        //get a name from user input to the console
        Console.WriteLine("Please enter first name: (leave empty to exit)");
        string firstName = Console.ReadLine();
        if (firstName == "")
        {
          break;
        }
        // get last name
        Console.WriteLine("Enter last name: ");
        string lastName = Console.ReadLine();
        // get id
        Console.WriteLine("Enter employee id: ");
        int id = Int32.Parse(Console.ReadLine());
        // get photo url
        Console.WriteLine("Enter photo url: ");
        string photoUrl = Console.ReadLine();

        Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
        employees.Add(currentEmployee);
      }
      return employees;
    }

    public static void PrintEmployees(List<Employee> employees)
    {
      for (int i = 0; i < employees.Count; i++)
      {
        string template = "{0,-10}\t{1,-20}\t{2}";
        Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetName(), employees[i].GetPhotoUrl()));
      }
    }

    public static void MakeCsv(List<Employee> employees)
    {
      if (!Directory.Exists("data"))
      {
        Directory.CreateDirectory("data");
      }
      using (StreamWriter file = new StreamWriter("data/employees.csv"))
      {
        file.WriteLine("ID,Name,PhotoUrl");
        for (int i = 0; i < employees.Count; i++)
        {
          string template = "{0},{1},{2}";
          file.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetName(), employees[i].GetPhotoUrl()));
        }
      }


    }

  }


}