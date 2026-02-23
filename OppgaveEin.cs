using System;
using System.Collections.Generic;

namespace OppgaveEin
{
    class Oppgave
    {
        private List<string> logTemp = new List<string>();

        static void Main(string[] args)
        {
            Oppgave active = new Oppgave();
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nVel ein handling:");
                Console.WriteLine("1. Log Tempratur:");
                Console.WriteLine("2. Les logger:");
                Console.WriteLine("3. Avslutt");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.Write("Skriv inn temperatur i Celsius: ");
                        if (double.TryParse(Console.ReadLine(), out double logTempData))
                        {
                            active.LogTempratur(logTempData);
                        }
                        else
                        {
                            Console.WriteLine("Ugyldig inndata.");
                        }
                        break;

                    case "2":
                        active.ViewLogsTemp();
                        break;

                    case "3":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Ugyldig val.");
                        break;
                }
            }
        }

        public void LogTempratur(double logTempData)
        {
            logTemp.Add($"Registrert {logTempData:F2}°C kl {DateTime.Now}");
        }

        public void ViewLogsTemp()
        {
            if (logTemp.Count == 0)
            {
                Console.WriteLine("Ingen loggar enno.");
            }
            else
            {
                Console.WriteLine("Tidlegare oppføringar:");
                for (int i = 0; i < logTemp.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {logTemp[i]}");
                }
            }
            Console.WriteLine("\nTrykk ein tast for å gå tilbake til menyen");
            Console.ReadKey();
        }
    }
}