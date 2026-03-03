using Ivi.Visa;
using System;


namespace SursaHMC8043
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. ADRESA (Se NI MAX)
            string adresaInstrument = "USB0::0x0AAD::0x0135::034318994::INSTR";

            try
            {
                Console.WriteLine("Încercăm conectarea cu sursa...");

                using (var session = GlobalResourceManager.Open(adresaInstrument) as IMessageBasedSession)
                {
                    Console.WriteLine("Conectat cu succes!\n");

                    // (Comanda SCPI)
                    string comanda = "*IDN?";
                    double voltage = 5.0;
                    double current = 0.5;

                    Console.WriteLine($"Trimitem comanda: {comanda}");
                    session.FormattedIO.WriteLine(comanda);
            

                    string raspuns = session.FormattedIO.ReadLine();

                    Console.WriteLine($"\nSursa a răspuns: {raspuns}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nUps, a apărut o problemă: {ex.Message}");
            }

        }
    }
}