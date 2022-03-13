using System;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
  class Program
  {
    static void Main(string[] args)
    {
      List<Employee> employees = PeopleFetcher.GetEmployees();
      Util.PrintEmployees(employees);
      Util.MakeCsv(employees);
      Util.MakeBadges(employees);
    }
  }
}