using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tentti_02
{
    //Staattinen luokka - varsinainen toteutus
    static class Application
    {
        //ConsoleColor- tyyppiset muuttujat
        private static ConsoleControl JobMenu, JobDetails, JobEmployees;

        //Asetetaan valikon tiedot
        private static void BindMenuData(List<Job> lista)
        {
            JobMenu.Items = new List<string>();
            //Käydään töiden lista läpi, ja lisätään tarvittavat tiedot ominaisuuteen
            foreach (var j in lista)
            {
                JobMenu.Items.Add($"{j.Id} {j.Title}");
            }
        }
        //Asetetaan tehtävän työn tiedot
        private static void BindDetailsData(Job tyo)
        {
            if (JobDetails.Items == null)
            {
                JobDetails.Items = new List<string>();
            }
            else
            {
                JobDetails.Items.Clear();
            }
            //Tietojen populointi ominaisuuteen
            string tiedot = "TYÖN TIEDOT";
            string id = $"Id: {tyo.Id}";
            string nimi = $"Nimi: {tyo.Title}";
            string alku = $"Alkaa: {tyo.StartDate.ToShortDateString()}";
            string loppu = $"Loppuu: {tyo.EndDate.ToShortDateString()}";

            JobDetails.Items.Add(tiedot);
            JobDetails.Items.Add(id);
            JobDetails.Items.Add(nimi);
            JobDetails.Items.Add(alku);
            JobDetails.Items.Add(loppu);
        }
        private static void BindEmployeesData(Job tyo)
        {
            if (JobEmployees.Items == null)
            {
                JobEmployees.Items = new List<string>();
            }
            else
            {
                JobEmployees.Items.Clear();
            }
            //Tietojen populointi ominaisuuteen
            JobEmployees.Items.Add("TYÖN TEKIJÄT");
            foreach (Employee j in Data.employees)
            {
                foreach (Job item in j.Jobs)
                {
                    //Lisätään ominaisuuteen kaikki työlle tarkoitetut työtekijät ID:n perusteella
                    if (tyo.Id == item.Id)
                    {
                        JobEmployees.Items.Add(j.Name);
                    }
                }
            }
        }
        //Konsolin alustus
        private static void Initialize()
        {
            //Valikon alustus
            JobMenu = new ConsoleControl(0, 1, Console.WindowWidth / 2, Data.jobs.Count)
            {
                BackColor = ConsoleColor.Gray,
                TextColor = ConsoleColor.DarkBlue
            };
            //Työn tietojen alustus
            JobDetails = new ConsoleControl((Console.WindowWidth / 2) + 1, 1, (Console.WindowWidth / 2) - 1, 5)
            {
                BackColor = ConsoleColor.Gray,
                TextColor = ConsoleColor.DarkGreen
            };
            //Työntekijöiden alustus
            JobEmployees = new ConsoleControl((Console.WindowWidth / 2) + 1, JobDetails.Height + 2, (Console.WindowWidth / 2) - 1, Console.WindowHeight - JobDetails.Height - 1)
            {
                BackColor = ConsoleColor.Gray,
                TextColor = ConsoleColor.DarkRed
            };

            //Lisätään työt valikkoon ja asetetaan tapahtumakäsittelijä JobChanged- oliolle, joka varmistaa
            //halutun datan näkymisen konsolissa
            BindMenuData(Data.jobs);
            Mediator.Instance.JobChanged += (sender, e) => { BindDetailsData(e.Job); BindEmployeesData(e.Job); };
        }
        //Metodi, joka vertailee käyttäjän syöttämän parametrin arvoa tehtävän työn ID arvoon
        // ja lähettää pyynnön valitun työn tietojen tulostamisesta
        private static void MenuSelectionChanged(int id)
        {
            foreach (Job tyo in Data.jobs)
            {
                if (id == tyo.Id)
                {
                    Mediator.Instance.OnJobChanged(JobMenu, tyo);
                    JobDetails.Draw();
                    JobEmployees.Draw();
                }
            }
        }
        //Ohjelman suoritus
        public static void Run()
        {
            //Alustus, valikon tulostus sekä looppi joka lukee käyttäjän syötettä, kunnes syöte == 0
            Initialize();
            JobMenu.Draw();
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write("Valitse työn id (nolla lopettaa): ");
                //Evaluoidaan käyttäjän syöte ja tehdään seuraavat toimenpiteet:
                bool parseOK = int.TryParse(Console.ReadLine(), out int paluu);

                if (paluu <= JobMenu.Items.Count && paluu > 0 && parseOK)
                {
                    //Syöte on kelvollinen, eikä ole 0 -> syöte jatkokäsittelyyn metodin välityksellä
                    MenuSelectionChanged(paluu);
                }
                else 
                {
                    if (paluu == 0 && parseOK)
                    {
                        //Syöte == 0 -> Ohjelman lopetus
                        break;
                    }
                    else
                    {
                        //Syöte ei kelvollinen -> virheilmoitus ja tekstirivin pyyhintä -> paluu loopin alkuun
                        Console.SetCursorPosition(0, 0);
                        Console.Write("Virheellinen syöte, Paina Enter.");
                        Console.ReadLine();
                        Console.SetCursorPosition(0, 0);
                        for (int i = 0; i < Console.WindowWidth; i++)
                        {
                            Console.Write(' ');
                        }
                    }
                }
                
            }
        }
    }
}
