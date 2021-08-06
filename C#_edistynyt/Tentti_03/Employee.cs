using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tentti_03
{
    public class Employee
    {
        //Kenttämuuttuja
        private double _salary;
        //Ominaisuudet
        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Department Department { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Name => $"{LastName} {FirstName}";
        //Ikä saadaan muuttamalla DateTime tyyppiset DateOfBirth ominaisuuden ja now(nykyhetki) muuttujan merkkijonoksi tietyssä muodossa
        //ja vähentämällä nykyhetki syntymäpäivällä ja jakamalla tulos 10000:lla
        //(Ottaa näin huomioon yhden vuoden heiton erotuksessa, jos nykyhetken päivä on ylittänyt syntymäpäivän ajankohdan)
        public int Age => DateOfBirth.HasValue ? (now - int.Parse(DateOfBirth.Value.ToString("yyyyMMdd")))/10000 : 0;
        int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));

        //Salary- ominaisuus, joka tarkistaa palkan kelvollisuuden
        public double Salary
        {
            get => Math.Round(_salary, 2);
            set
            {
                if (value < 0)
                {
                    throw new Exception("Negatiivinen palkka");
                }
                else
                {
                    _salary = value;
                }
            }
        }
        //Konstruktori
        public Employee(int id, string first, string last, DateTime dob, double salary)
        {
            Id = id;
            FirstName = first;
            LastName = last;
            DateOfBirth = dob;
            Salary = salary;
            StartDate = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Id} {FirstName} {LastName}";
        }
    }
}
