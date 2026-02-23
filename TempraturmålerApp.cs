using System;
using System.Collections.Generic;

namespace TempraturmålerApp
{
    class Tempraturmåler
    {
        private double tempraturen = 0.0;
        private List<string> logs = new List<string>();
        private List<int?> ratings = new List<int?>();
        private readonly Random rng = new Random();

        /// <summary>
        /// Set temperaturen og kommenterer han i Kelvin.
        /// </summary>
        public void setTempraturen(double temp, bool logEntry = true)
        {
            tempraturen = temp;
            double tempCelcius = temp;
            // Use Celsius ranges for more granular, user-friendly messages (including below zero)
            if (tempCelcius <= -50)
            {
                Console.WriteLine("Ekstrem kulde — sjølv pingvinar vurderer ullgenser no. Gå ikkje ut utan riktig utstyr.");
            }
            else if (tempCelcius > -50 && tempCelcius <= -30)
            {
                Console.WriteLine("Ekstremt kaldt — pølsene nektar å grille, og håret ditt frys til kunstverk.");
            }
            else if (tempCelcius > -30 && tempCelcius <= -20)
            {
                Console.WriteLine("Særs kaldt — kle deg som ein løk, og vurder ekstra sokkar.");
            }
            else if (tempCelcius > -20 && tempCelcius <= -10)
            {
                Console.WriteLine("Kaldt — det biter i nasa og husdyr spør etter teppe.");
            }
            else if (tempCelcius > -10 && tempCelcius < 0)
            {
                Console.WriteLine("Under frysepunktet — ta vare på plantar og varm drikke.");
            }
            else if (Math.Abs(tempCelcius) < 0.0001)
            {
                Console.WriteLine("Nøyaktig frysepunktet for vatn — perfekt høve til å teste isens styrke.");
            }
            else if (tempCelcius > 0 && tempCelcius < 5)
            {
                Console.WriteLine("Kaldt, men over frysepunktet — tid for tjukk genser og dårlege unnskyldningar for å halde seg inne.");
            }
            else if (tempCelcius >= 5 && tempCelcius < 10)
            {
                Console.WriteLine("Kjøleg — jakke vert anbefalt, men stol på sola for motivasjon.");
            }
            else if (tempCelcius >= 10 && tempCelcius < 15)
            {
                Console.WriteLine("Litt kjøleg — behageleg for ein rusletur med varm drikke.");
            }
            else if (tempCelcius >= 15 && tempCelcius < 20)
            {
                Console.WriteLine("Behageleg temperatur — perfekt for utandørs kaffi og små triumfar.");
            }
            else if (tempCelcius >= 20 && tempCelcius < 25)
            {
                Console.WriteLine("Litt varmt — ta på solbriller og eit smil.");
            }
            else if (tempCelcius >= 25 && tempCelcius < 30)
            {
                Console.WriteLine("Varmt — tid for is eller å late som ein likar å svette.");
            }
            else if (tempCelcius >= 30 && tempCelcius < 35)
            {
                Console.WriteLine("Særs varmt — sola har ambisjonar, finn skugge.");
            }
            else if (tempCelcius >= 35 && tempCelcius < 45)
            {
                Console.WriteLine("Ekstrem varme — drikk vatn; elles vil mobilen din klage over varmebølgje.");
            }
            else
            {
                Console.WriteLine("Farleg høg temperatur — dette er ikkje ein vanleg sommardag. Søk kjøling straks.");
            }

            if (logEntry)
            {
                logs.Add($"Registrert {tempCelcius}°C kl {DateTime.Now}");
                ratings.Add(null);
            }
        }

        /// <summary>
        /// Les temperatur frå konsollen og set han.
        /// </summary>
        public void setTempraturen()
        {
            Console.WriteLine("Skriv inn temperatur i Celsius:");
            string? input = Console.ReadLine();
            if (double.TryParse(input, out double temp))
            {
                setTempraturen(temp);
            }
            else
            {
                Console.WriteLine("Ugyldig inndata. Prøv på nytt.");
            }
        }

        /// <summary>
        /// Hentar noverande temperatur.
        /// </summary>
        public double getTempraturen()
        {
            return tempraturen;
        }

        /// <summary>
        /// Set temperatur frå Fahrenheit.
        /// </summary>
        public void setTempraturenFahrenheit(double tempF)
        {
            double tempC = (tempF - 32) * 5 / 9;
            // Call Celsius setter without logging, then create a combined log entry
            setTempraturen(tempC, false);
            logs.Add($"Registrert {tempF}°F ({Math.Round(tempC,2)}°C) kl {DateTime.Now}");
            ratings.Add(null);
        }

        /// <summary>
        /// Set temperatur frå Kelvin.
        /// </summary>
        public void setTempraturenKelvin(double tempK)
        {
            double tempC = tempK - 273.15;
            // Call Celsius setter without logging, then create a combined log entry
            setTempraturen(tempC, false);
            logs.Add($"Registrert {tempK}K ({Math.Round(tempC,2)}°C) kl {DateTime.Now}");
            ratings.Add(null);
        }

        /// <summary>
        /// Viser alle loggar.
        /// </summary>
        public void viewLogs()
        {
            if (logs.Count == 0)
            {
                Console.WriteLine("Ingen loggar enno.");
            }
            else
            {
                Console.WriteLine("Tidlegare oppføringar:");
                for (int i = 0; i < logs.Count; i++)
                {
                    string ratingText = (i < ratings.Count && ratings[i].HasValue) ? $" - Vurdering: {ratings[i]}/5" : " - Vurdering: ingen";
                    Console.WriteLine($"{i + 1}. {logs[i]}{ratingText}");
                }
            }
            Console.WriteLine("\nTrykk ein tast for å gå tilbake til menyen...");
            Console.ReadKey();
        }

        /// <summary>
        /// Fortel ein tilfeldig vits.
        /// </summary>
        public void tellJoke()
        {
            var jokes = new List<string>
            {
                "Kvifor gjekk temperaturen til legen? Han kjende seg litt nede (under null).",
                "Eg forsøkte å bruke Celsius som flytande valuta — det smelta bort.",
                "Veret og eg har eit forhold: det endrar seg heile tida.",
                "Om du ikkje likar temperaturen, vent 10 minutt — den vil endre seg.",
                "Kvifor er termometeret så optimistisk? Fordi det alltid ser glaset som halvfullt... med vatn!"
            };
            string joke = jokes[rng.Next(jokes.Count)];
            Console.WriteLine(joke);
            logs.Add($"Fortalde vits: {joke} kl {DateTime.Now}");
            ratings.Add(null);
            Console.WriteLine();
            Console.Write("Gje vitsen karakter 1-5 (eller trykk Enter for å hoppe over): ");
            string? r = Console.ReadLine();
            if (int.TryParse(r, out int rate) && rate >= 1 && rate <= 5)
            {
                ratings[ratings.Count - 1] = rate;
                Console.WriteLine($"Takk! Du gav {rate}/5.");
            }
            else
            {
                Console.WriteLine("Ingen vurdering registrert.");
            }
            Console.WriteLine("\nTrykk ein tast for å gå tilbake til menyen...");
            Console.ReadKey();
        }

        /// <summary>
        /// Fortel ein vits basert på noverande temperatur.
        /// </summary>
        public void tellTemperatureJoke()
        {
            string joke;
            double c = tempraturen;
            if (c <= 0)
            {
                joke = "Det er så kaldt at sjølv pingvinen bestiller varm sjokolade.";
            }
            else if (c > 0 && c < 20)
            {
                joke = "Det er litt kjøleg — tid for eit ekstra lag med sarkasme.";
            }
            else if (c >= 20 && c < 30)
            {
                joke = "Perfekt temperatur for å late som du trenar ved å opne vindauget.";
            }
            else
            {
                joke = "Det er så varmt at isen søkjer asyl i frysaren.";
            }
            Console.WriteLine(joke);
            logs.Add($"Fortalde temp-vits: {joke} kl {DateTime.Now}");
            ratings.Add(null);
            Console.WriteLine();
            Console.Write("Gje vitsen karakter 1-5 (eller trykk Enter for å hoppe over): ");
            string? r2 = Console.ReadLine();
            if (int.TryParse(r2, out int rate2) && rate2 >= 1 && rate2 <= 5)
            {
                ratings[ratings.Count - 1] = rate2;
                Console.WriteLine($"Takk! Du gav {rate2}/5.");
            }
            else
            {
                Console.WriteLine("Ingen vurdering registrert.");
            }
            Console.WriteLine("\nTrykk ein tast for å gå tilbake til menyen...");
            Console.ReadKey();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Tempraturmåler tm = new Tempraturmåler();
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nVel ein handling:");
                    Console.WriteLine("1. Angi temperatur i Celsius");
                    Console.WriteLine("2. Angi temperatur i Fahrenheit");
                    Console.WriteLine("3. Angi temperatur i Kelvin");
                    Console.WriteLine("4. Vis noverande temperatur");
                    Console.WriteLine("5. Vis loggar");
                    Console.WriteLine("6. Fortel ein vits");
                    Console.WriteLine("7. Avslutt");
                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Skriv inn temperatur i Celsius: ");
                        if (double.TryParse(Console.ReadLine(), out double tempC))
                        {
                            tm.setTempraturen(tempC);
                        }
                        else
                        {
                            Console.WriteLine("Ugyldig inndata.");
                        }
                        break;
                    case "2":
                        Console.Write("Skriv inn temperatur i Fahrenheit: ");
                        if (double.TryParse(Console.ReadLine(), out double tempF))
                        {
                            tm.setTempraturenFahrenheit(tempF);
                        }
                        else
                        {
                            Console.WriteLine("Ugyldig inndata.");
                        }
                        break;
                    case "3":
                        Console.Write("Skriv inn temperatur i Kelvin: ");
                        if (double.TryParse(Console.ReadLine(), out double tempK))
                        {
                            tm.setTempraturenKelvin(tempK);
                        }
                        else
                        {
                            Console.WriteLine("Ugyldig inndata.");
                        }
                        break;
                    case "4":
                        Console.WriteLine($"Noverande temperatur: {tm.getTempraturen()} °C");
                        break;
                    case "5":
                        tm.viewLogs();
                        break;
                    case "6":
                        Console.WriteLine("Vel vits-type:\n1. Tilfeldig vits\n2. Vits basert på noverande temperatur\n3. Tilbake");
                        string? jchoice = Console.ReadLine();
                        switch (jchoice)
                        {
                            case "1":
                                tm.tellJoke();
                                break;
                            case "2":
                                tm.tellTemperatureJoke();
                                break;
                            default:
                                break;
                        }
                        break;
                    case "7":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Ugyldig val.");
                        break;
                }
            }
        }
    }
}
