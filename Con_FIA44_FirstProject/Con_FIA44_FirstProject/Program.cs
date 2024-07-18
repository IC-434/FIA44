using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

namespace Con_FIA44_FirstProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();

            ConsoleColor consoleColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Systeminformationen:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---------------------");
            Console.ForegroundColor = consoleColor;

            // Betriebssystem und Version
            Console.WriteLine($"Betriebssystem : {Environment.OSVersion}");

            // Ist 64-Bit Betriebssystem
            string osBitness = Environment.Is64BitOperatingSystem ? "64-Bit" : "32-Bit";
            Console.WriteLine($"64-Bit Betriebssystem: {osBitness}");

            // Ist 64-Bit Prozess
            string bitness = Environment.Is64BitProcess ? "64-Bit" : "32-Bit";
            Console.WriteLine($"64-Bit Prozess: {bitness}");

            // Systemzeit
            Console.WriteLine($"Systemzeit: {DateTime.Now}");
            // Systemzeitzone
            Console.WriteLine($"Systemzeitzone: {TimeZoneInfo.Local.DisplayName} - {TimeZoneInfo.Local.DaylightName}");

            // Maschinenname
            Console.WriteLine($"Maschinenname: {Environment.MachineName}");

            // Prozessoranzahl
            Console.WriteLine($"Prozessoranzahl: {Environment.ProcessorCount}");

            // Systemverzeichnis
            Console.WriteLine($"Systemverzeichnis: {Environment.SystemDirectory}");

            // Benutzerdomäne
            Console.WriteLine($"Benutzerdomäne: {Environment.UserDomainName}");

            // Benutzername
            Console.WriteLine($"Benutzername: {Environment.UserName}");

            // Aktuelles Verzeichnis
            Console.WriteLine($"Aktuelles Verzeichnis: {Environment.CurrentDirectory}");

            // .NET Version
            Console.WriteLine($".NET Version: {Environment.Version}");

            // Verfügbare Laufwerke
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Verfügbare Laufwerke 💾 ");
            Console.ForegroundColor = consoleColor;

            foreach (var drive in Environment.GetLogicalDrives())
            {
                // Einrückungen mit Escape-Sequenzen \t (Tabulator)
                Console.WriteLine($"\t\t  - {drive}");
            }

            // Uptime des Systems in Millisekunden
            long uptimeInTicks = Environment.TickCount64;
            long uptimeInSeconds = uptimeInTicks / 1000;
            long uptimeInMinutes = uptimeInSeconds / 60;
            long uptimeInHours = uptimeInMinutes / 60;
            long uptimeInDays = uptimeInHours / 24;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("System-Uptime 🕗");
            Console.ForegroundColor = consoleColor;

            Console.WriteLine($"System-Uptime in Ticks: {uptimeInTicks} Ticks");
            Console.WriteLine($"System-Uptime in Sekunden: {uptimeInSeconds} Sekunden");
            Console.WriteLine($"System-Uptime in Minuten: {uptimeInMinutes} Minuten");
            Console.WriteLine($"System-Uptime in Stunden: {uptimeInHours} Stunden");
            Console.WriteLine($"System-Uptime in Tagen: {uptimeInDays} Tage");
            Console.WriteLine();

            // Spezielle Verzeichnisse
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Spezielle Verzeichnisse 📁");
            Console.ForegroundColor = consoleColor;
            Console.WriteLine($"  - Arbeitsverzeichnis: {Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}");
            Console.WriteLine($"  - Eigene Dokumente: {Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}");
            Console.WriteLine($"  - Programmverzeichnis: {Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)}");
            Console.WriteLine($"  - Anwendungsdaten: {Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}");
            Console.WriteLine($"  - Lokale Anwendungsdaten: {Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}");
            Console.WriteLine($"  - Systemverzeichnis: {Environment.GetFolderPath(Environment.SpecialFolder.System)}");
            //Stringverkettung
            Console.WriteLine($"  - Fontverzeichnis:" + Environment.GetFolderPath(Environment.SpecialFolder.Fonts));
            Console.WriteLine($"  - Local-AppData: {Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}");
            Console.WriteLine($"  - Benutzerprofile: {Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}");
            Console.WriteLine($"  - Programme (x86): {Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86)}");

            Console.WriteLine();

            // Weitere Informationen
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Weitere Informationen:");
            Console.ForegroundColor = consoleColor;

            Console.WriteLine($"  - Aktuelle Kultur: {CultureInfo.CurrentCulture.Name}");
            Console.WriteLine($"  - Aktuelle UI-Kultur: {CultureInfo.CurrentUICulture.Name}");
            Console.WriteLine($"  - OS Architektur: {RuntimeInformation.OSArchitecture}");
            Console.WriteLine($"  - Prozess Architektur: {RuntimeInformation.ProcessArchitecture}");
            Console.WriteLine($"  - OS Bezeichnung:{RuntimeInformation.OSDescription}");
            Console.WriteLine($"  - Framework Bezeichnung: {RuntimeInformation.FrameworkDescription}");
            Console.WriteLine($"  - Laufzeitbezeichner: {RuntimeInformation.RuntimeIdentifier}");
            Console.WriteLine();
            // Alle Umgebungsvariablen
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Umgebungsvariablen:");
            Console.ForegroundColor = consoleColor;
            foreach (System.Collections.DictionaryEntry envVar in Environment.GetEnvironmentVariables())
            {
                Console.WriteLine($"\t  - {envVar.Key} = {envVar.Value}");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("---------------------");
            Console.WriteLine("Drücken Sie eine beliebige Taste zum Beenden...");
            Console.ForegroundColor = consoleColor;
            Console.ReadKey();
        }
    }
}
