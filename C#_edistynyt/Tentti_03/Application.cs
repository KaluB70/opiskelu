using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Tentti_03
{
    public static class Application
    {
        //Staattinen Menu- muuttuja
        static List<MenuItem> Menu;

        //Valmiiksi annettu koodi - tulostaa taulut konsoliin
        public static void WriteResult<T>(int itemid, List<T> result)
        {
            string row;
            //otsikkorivit
            WriteLine();
            WriteLine(Menu.Where(mi => mi.Id == itemid).First().Name.ToUpper());
            WriteLine("-".PadRight(18 * result[0].GetType().GetProperties().Length + 2, '-'));
            //sarakeotsikkorivit
            if (result.Count > 0)
            {
                row = "";
                foreach (PropertyInfo property in result[0].GetType().GetProperties())
                {
                    row += $"{property.Name}".PadRight(16) + " | ";
                }
                WriteLine(row);
            }
            WriteLine("-".PadRight(18 * result[0].GetType().GetProperties().Length + 2, '-'));
            //datarivit
            foreach (object item in result)
            {
                row = "";
                foreach (PropertyInfo property in item.GetType().GetProperties())
                {
                    row += $"{property.GetValue(item, null).ToString()}".PadRight(16) + " | ";
                }
                WriteLine(row);
            }
            WriteLine("-".PadRight(18 * result[0].GetType().GetProperties().Length + 2, '-'));
            WriteLine();
            Write("Paina Enter jatkaaksesi.");
            ReadLine();
        }

        //Menun alustus ja datan populointi
        static void InitializeMenu()
        {
            Menu = new List<MenuItem>();
            Menu.Add(new MenuItem() { Id = 1, Name = "50-vuotiaat työntekijät" });
            Menu.Add(new MenuItem() { Id = 2, Name = "Osastot yli 50 henkilöä" });
            Menu.Add(new MenuItem() { Id = 3, Name = "Sukunimen työntekijät" });
            Menu.Add(new MenuItem() { Id = 4, Name = "Osastojen isoimmat palkat" });
            Menu.Add(new MenuItem() { Id = 5, Name = "Viisi yleisintä sukunimeä" });
            Menu.Add(new MenuItem() { Id = 6, Name = "Osastojen ikäjakaumat" });

            //Tapahtumakäsittelijät valikon eri vaihtoehdoille

            //Hakee kaikki 50-vuotiaat työntekijät
            Menu[0].ItemSelected += (obj, a) =>
            {
                var result = Data.Employees.Where(emp => emp.Age == 50)
                                           .Select(emp => new { Nimi = emp.Name, Ikä = emp.Age, Osasto = emp.Department.Name}).ToList();
                WriteResult(a.ItemId, result);
            };
            //Hakee osastot, joissa työntekijöiden määrä > 50
            //=> Järjestää tulokset työntekijöiden vahvuusmäärän mukaan
            Menu[1].ItemSelected += (obj, a) =>
            {
                var result = Data.Departments.Where(d => d.EmployeeCount > 50)
                                             .Select(d => new { Id = d.Id, Nimi = d.Name, Vahvuus = d.EmployeeCount })
                                             .OrderByDescending(d => d.Vahvuus).ToList();
                WriteResult(a.ItemId, result);
            };
            //Hakee kaikki työntekijät, joiden nimi on täsmälleen sama kuin käyttäjän syötteessä
            //(tehtävänannossa ei puhetta isojen- ja pienten kirjainten tarkistamisesta)
            //=> Tuottaa tulokset tauluun
            Menu[2].ItemSelected += (obj, a) =>
            {
                Console.WriteLine();
                Console.Write("Anna sukunimi: ");
                string syote = Console.ReadLine();
                var result = Data.Employees.Where(emp => emp.LastName == syote)
                                           .Select(emp => new { Id = emp.Id, Nimi = emp.Name}).ToList();

                //Pakollinen try-catch blokki, koska valmiiksi annettu koodi heittää poikkeuksen, jos nimeä ei löydy listalta
                //=> Mahdollistaa ohjelman jatkamisen poikkeuksen jälkeen enteriä painamalla
                //Voi pitää tehtävänannon ulkopuolisena toimintona, mutta mieluummin palautan ehjän ohjelman :)
                try
                {
                    WriteResult(a.ItemId, result);
                }
                catch (Exception)
                {
                    Console.WriteLine($"\nSukunimellä {syote} ei löytynyt työntekijöitä\n");
                    Console.Write("Paina Enter jatkaaksesi.");
                    Console.ReadLine();
                }
            };
            //Hakee kaikista osastoista parhaimmat palkat
            //=> Osittaa tulokset osastojen mukaan
            Menu[3].ItemSelected += (obj, a) =>
            {
                var result = Data.Departments.SelectMany(d => d.Employees,
                                              (d, e) => new { Osasto = d.Name, Palkka = e.Salary })
                                             .GroupBy(de => de.Osasto)
                                             .Select(ryhma => new
                                             {
                                                 Osasto = ryhma.Key,
                                                 Maksimipalkka = ryhma.Max(de => de.Palkka)
                                             }).ToList();
                WriteResult(a.ItemId, result);
            };
            //Hakee kaikista sukunimistä viisi yleisintä
            //=> Järjestää tulokset nimien lukumäärän mukaan
            Menu[4].ItemSelected += (obj, a) =>
            {
                var result = Data.Employees.GroupBy(emp => emp.LastName)
                                           .Select(emp => new { Sukunimi = emp.Key, Lkm = emp.Count() })
                                           .OrderByDescending(emp => emp.Lkm).Take(5).ToList();

                WriteResult(a.ItemId, result);
            };
            //Hakee kaikkien osastojen eri ikähaarukat(alle 30v, 30-50v, yli 50v)
            //=> Tuottaa tauluun saadun datan, eli erikseen joka osaston eri haarukoiden "jäsenet"
            Menu[5].ItemSelected += (obj, a) =>
            {
                var result = Data.Departments.SelectMany(d => d.Employees,
                                              (d, e) => new
                                              {
                                                  Nimi = d.Name,
                                                  Alle30v = e.Age < 30,
                                                  Välillä30_50v = e.Age >= 30 && e.Age <= 50,
                                                  Yli50v = e.Age > 50
                                              })
                                              .GroupBy(ryhma => ryhma.Nimi)
                                              .Select(ryhma => new
                                              {
                                                  Nimi = ryhma.Key,
                                                  Alle30v = ryhma.Count(e => e.Alle30v),
                                                  Välillä30_50v = ryhma.Count(e => e.Välillä30_50v),
                                                  Yli50v = ryhma.Count(e => e.Yli50v)
                                              }).ToList();

                WriteResult(a.ItemId, result);
            };


        }
        //Datan generointi ja ohjelman alustus
        static void Initialize()
        {
            Data.GenerateData();
            InitializeMenu();
        }
        //Käyttäjän syötteen lukeminen
        //=> Jos syöte on kelvollinen(int väliltä 0-6) => palautetaan syöte kokonaislukuna
        //=> Muuten => heitetään poikkeus virhetekstillä
        //=> Poikkeus otetaan kiinni tässä vaiheessa, jotta ohjelma ei lopu virheellisen syötteen jälkeen.
        static int ReadFromMenu()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Vaihtoehdot");
                foreach (var item in Menu)
                {
                    Console.WriteLine(item);
                }
                Console.Write("Valitse (0 = lopetus): ");
                string syote = Console.ReadLine();
                bool syoteOK = int.TryParse(syote, out int id);
                if (id >= 0 && id <= 6 && syoteOK)
                {
                    return id;
                }
                else
                {
                    throw new Exception("Vastaus ei ole kelvollinen");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"\n{e.Message}\n");
                Console.Write($"Paina Enter jatkaaksesi.");
                Console.ReadLine();
                return -1;
            }
        }
        //Varsinaisen ohjelman ajometodi
        //=> Alustaa ohjelman
        //=> Kutsuu metodia käyttäjän syötteen lukemiseen
        //=> Jos syöte on 0 => ohjelma loppuu
        //=> Jos syöte on kelvollinen => Kutsutaan Select- metodia syötteen perusteella,
        //   joka mahdollistaa ohjelman varsinaisen toiminnan
        public static void Run()
        {
            bool loop = true;
            Initialize();
            while (loop)
            {
                int syote = ReadFromMenu();
                foreach (var item in Menu)
                {
                    if (syote == 0)
                    {
                        loop = false;
                    }
                    if (item.Id == syote)
                    {
                        item.Select();
                    }
                }
            }
        }
    }
}
