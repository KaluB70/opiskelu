using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tentti_03
{
    public class Department
    {
        //Automaattiset ominaisuudet
        public int Id { get; set; }
        public string Name{ get; set; }
        public List<Employee> Employees { get; set; }
        public int EmployeeCount => Employees.Count;

        //Konstruktorit
        public Department()
        {
            Employees = new List<Employee>();
        }

        public Department(int id, string name)
            :this()
        {
            Name = name;
            Id = id;
        }
        public override string ToString()
        {
            return $"{Name} ({EmployeeCount})";
        }
    }
}
