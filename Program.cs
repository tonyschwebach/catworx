using System;
using System.Collections.Generic;

namespace CatWorx.BadgeMaker
{
  class Program
  {
    static void Main(string[] args)
    {
      List<Employee> employees = Util.GetEmployees();
      Util.PrintEmployees(employees);
    }
  }
}