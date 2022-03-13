using System;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CatWorx.BadgeMaker
{
  class PeopleFetcher
  {
    // accept user input to build a list of employee names
    private static List<Employee> GetManual()
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

    private static List<Employee> GetFromApi()
    {
      List<Employee> employees = new List<Employee>();
      using (WebClient client = new WebClient())
      {
        string response = client.DownloadString("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
        JObject json = JObject.Parse(response);
        foreach (JToken token in json.SelectToken("results"))
        {
          Employee employee = new Employee(
            token.SelectToken("name.first").ToString(),
            token.SelectToken("name.last").ToString(),
            Int32.Parse(token.SelectToken("id.value").ToString().Replace("-", "")),
            token.SelectToken("picture.large").ToString()
          );
          employees.Add(employee);
        }

      }
      return employees;
    }

    public static List<Employee> GetEmployees()
    {
      Console.WriteLine("Do you want to get contacts from the API? [Y/n]");
      string answer = Console.ReadLine();
      if (answer.ToLower() == "y" || answer.ToLower() == "yes")
      {
        return GetFromApi();
      }
      else
      {
        return GetManual();
      }
    }
  }
}