using System;
using System.Linq;
using System.Net.NetworkInformation;

namespace FastFup_Prove_Eksamen_1
{
    public class TransportCalc
    {
        


        public static double Average(int AntalKm, double AntalLiter) //Metode til at udregne det gennemsnitslige brændstofforbrug ud fra "AntalKm" og "AntalLiter")
        {
            if (AntalKm < 0 || AntalKm >= 2000) throw new ArgumentOutOfRangeException();
            
            return (AntalKm / AntalLiter) * 100;
            
            
        }

        public static int Total(string Transporter) //Metode til at opdele strings og derefter konvertere //Parse string og lægge hver tal sammen
        {
            string[] TransporterSting = Transporter.Split(' '); //Splitter string array
            int[] TransporterInts = Array.ConvertAll(TransporterSting, int.Parse); //Konverterer det til et array med Ints

            int sum = TransporterInts.Sum(); //Finder summen ved hjælp af LINQ
            return sum; //returnerer summen
        }
    }
}
