// Program 1A
// CIS 200-01
// By: M9888
// Due: 9/23/2019

// File: Program.cs
// Simple test program for Parcel classes

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Prog0
{
    class Program
    {
        // Precondition:  None
        // Postcondition: Small list of Parcels is created and displayed
        static void Main(string[] args)
        {
            Address ad1 = new Address("  John Smith  ", "   123 Any St.   ", "  Apt. 45", "Louisville   ", "  KY   ", 40202); // Test Address 1
            Address ad2 = new Address("Jane Doe", "987 Main St.", "Beverly Hills", "CA", 90210); // Test Address 2
            Address ad3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321", "El Paso", "TX", 79901); // Test Address 3
            Address ad4 = new Address("John Crichton", "678 Pau Place", "Apt. 7", "Portland", "ME", 04101); // Test Address 4

            Address ad5 = new Address("name", "address_1", "address_2", "city", "state", 99999); //Test address 5
            Address ad6 = new Address("Joe", "123 The Street", "wut", "NYC", "NY", 12345); //Test address 6
            Address ad7 = new Address("Dr. Wright", "I dont know where you live", "Louisville", "KY", 40217); //Test address 7
            Address ad8 = new Address("'Ol McDonald", "had a farm", "                           eee eye eee eye", "Farmville", "T E X A S", 5); //Test address 8


            List<Parcel> parcelList = new List<Parcel>() // Test list of parcels
            {
                new Letter(ad1, ad3, 0.50M), // Test Letter 1
                new Letter(ad2, ad4, 1.20M), // Test Letter 2
                new Letter(ad4, ad1, 1.70M), // Test Letter 3

                new GroundPackage(ad4, ad5, 5, 10, 1, 100), //Test Groundpackage

                new NextDayAirPackage(ad6, ad7, 5, 10, 1, 100, 150), //Test Next Day Air Package Heavy
                new NextDayAirPackage(ad6, ad7, 5, 10, 100, 49.9, 150), //Test Next Day Air Package Large
                new NextDayAirPackage(ad6, ad7, 5, 10, 100, 100, 150), //Test Next Day Air Package Large & Heavy

                new TwoDayAirPackage(ad8, ad3, 5, 10, 1, 100, TwoDayAirPackage.Delivery.Saver), //Test Two Day Air Package that is a Saver
                new TwoDayAirPackage(ad7, ad2, 5, 10, 1, 100, TwoDayAirPackage.Delivery.Early) //Test Two Day Air Package that is a Early
            };

            string NL = Environment.NewLine; // NewLine shortcut

            // Display data
            WriteLine($"Program 1A - List of Parcels{NL}");

            // Precondition:  None
            // Postcondition: A String with the data has been returned
            foreach (Parcel p in parcelList)
            {
                Console.WriteLine($"{p.ToString()}{NL}");
                WriteLine($"______________________________________________{NL}");
            }
            Console.ReadLine();
        }
    }
}
