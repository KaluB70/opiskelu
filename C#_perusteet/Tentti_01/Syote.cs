using System;
using System.Globalization;
using System.Linq;
using static System.Console;

namespace Helpers
{
    public static class Syote
    {
        public static int Kokonaisluku(string kehote, int min = int.MinValue, int max = int.MaxValue)
        {
            int paluu;
            Write($"{kehote} ");
            if (!int.TryParse(ReadLine(), out paluu) || (paluu < min || paluu > max))
            {
                throw new ApplicationException("Syöte ei ole kelvollinen kokonaisluku." +
                    (min > int.MinValue ? ($" Minimi on {min}.") : "") +
                    (max < int.MaxValue ? ($" Maksimi on {max}.") : ""));
            }
            return paluu;
        }
        public static double Desimaaliluku(string kehote, int tarkkuus = -1)
        {
            double paluu;
            Write($"{kehote} ");
            if (!double.TryParse(ReadLine(), out paluu))
            {
                throw new ApplicationException("Syöte ei ole kelvollinen desimaaliluku.");
            }
            return tarkkuus >= 0 ? Math.Round(paluu, tarkkuus) : paluu;
        }
        public static char Merkki(string kehote)
        {
            char paluu;
            Write($"{kehote} ");
            if (!char.TryParse(ReadLine(), out paluu))
            {
                throw new ApplicationException("Syöte ei ole kelvollinen merkki.");
            }
            return paluu;
        }
        public static string Merkkijono(string kehote)
        {
            Write($"{kehote} ");
            return ReadLine();
        }
        public static char Merkki(string kehote, char[] sallitut)
        {
            char paluu;
            Write($"{kehote} "); if (!char.TryParse(ReadLine(), out paluu) || !sallitut.Contains(paluu))
            {
                string merkit = "";
                for (int i = 0; i < sallitut.Length; i++)
                {
                    if (i < sallitut.Length - 2)
                    {
                        merkit += $"{sallitut[i]}, ";
                    }
                    else if (i == sallitut.Length - 2)
                    {
                        merkit += $"{sallitut[i]} ja ";
                    }
                    else
                    {
                        merkit += $"{sallitut[i]}.";
                    }
                }
                throw new ApplicationException($"Syöte ei ole kelvollinen merkki. Sallittuja merkkejä ovat { merkit }");
            }
            return paluu;
        }
        public static string Merkkijono(string kehote, string[] sallitut,
                                        bool tasoherkkyys = false)
        {
            string paluu;
            bool ok = false;
            Write($"{kehote} ");
            paluu = ReadLine();
            foreach (string m in sallitut)
            {
                if ((tasoherkkyys && m == paluu) ||
                    (!tasoherkkyys && m.ToUpper() == paluu.ToUpper()))
                {
                    ok = true;
                    break;
                }
            }
            if (!ok)
            {
                string merkkijonot = "";
                for (int i = 0; i < sallitut.Length; i++)
                {
                    if (i < sallitut.Length - 2)
                    {
                        merkkijonot += $"{sallitut[i]}, ";
                    }
                    else if (i == sallitut.Length - 2)
                    {
                        merkkijonot += $"{sallitut[i]} ja ";
                    }
                    else
                    {
                        merkkijonot += $"{sallitut[i]}.";
                    }
                }
                throw new ApplicationException($"Syöte ei ole kelvollinen. Sallittuja syötteitä ovat { merkkijonot }");
            }
            return paluu;
        }
        public static DateTime Paivays(string kehote)
        {
            DateTime paluu;
            Write($"{kehote} ");
            try
            {
                paluu = DateTime.Parse(ReadLine(), new CultureInfo("fi‐FI"));
            }
            catch
            {
                throw new ApplicationException("Syöte ei ole kelvollinen päiväys."); ;
            }
            return paluu;
        }
        public static int KokonaislukuPakottaen(string kehote, int min = int.MinValue,
            int max = int.MaxValue)
        {
            do
            {
                try
                {
                    return Syote.Kokonaisluku(kehote, min, max);
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }
            } while (true);
        }
        public static double DesimaalilukuPakottaen(string kehote, int tarkkuus = -1)
        {
            do
            {
                try
                {
                    return Syote.Desimaaliluku(kehote, tarkkuus);
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }
            } while (true);
        }
        public static DateTime PaivaysPakottaen(string kehote)
        {
            do
            {
                try
                {
                    return Syote.Paivays(kehote);
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }
            } while (true);
        }
    }
}

