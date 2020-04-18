// Program 1A
// CIS 200-01
// By: M9888
// Due: 9/23/2019

// File: GroundPackage.cs
// This class's prupose is to allow for the creation of a groundpackage.
// Ground Packages change the cost based on the distance between zones.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog0
{
    class GroundPackage : Package
    {
        const double CONST_SIZE_COST_MAGNIFIER = 0.25; // constant used for calculating ground package cost
        const double CONST_DISTANCE_COST_MAGNIFIER = 0.45; // constant created that is multiplied against the distance to adjust cost
        const int CONST_ZIP_REMAINDER = 10000; // used in the calulation of zone distance difference 

        // Precondition:  None
        // Postcondition: The ground package is created with the specified values for
        //                origin address and destination address as well as dimensions
        public GroundPackage(Address originAddress, Address destAddress, double length, double width, double height, double weight)
               : base(originAddress, destAddress, length, width, height, weight)
        {
            // No body needed
            // based entirely on previous class
        }

        public int ZoneDistance
        {
            // Precondition:  Zip codes had to match requiremnts specified in Address
            // Postcondition: The zone distance has been returned
            get
            {
                int firstZip = (OriginAddress.Zip - (OriginAddress.Zip % CONST_ZIP_REMAINDER)) / CONST_ZIP_REMAINDER; // to define a calculatable conversion for zip 1
                int secondZip = (DestinationAddress.Zip - (DestinationAddress.Zip % CONST_ZIP_REMAINDER)) / CONST_ZIP_REMAINDER; // to define a calculatable conversion for zip 2

                // logic to avoid negative numbers when calulating the difference
                if (secondZip > firstZip)
                {
                    return (secondZip - firstZip);
                }
                else
                {
                    return (firstZip - secondZip);
                }  
            }
        }

        // Precondition:  Length Width Height and ZoneDistance must all be greater than 0
        // Postcondition: The ground package's cost has been returned
        public override decimal CalcCost()
        {
            double cost = CONST_SIZE_COST_MAGNIFIER * (Length + Width + Height) + CONST_DISTANCE_COST_MAGNIFIER * (ZoneDistance + 1) * Weight; // base cost of a ground package 
            return Convert.ToDecimal(cost);
        }

        // Precondition:  None
        // Postcondition: A String with the data has been returned
        public override String ToString()
        {
            string NL = Environment.NewLine; // NewLine shortcut

            return $"Package: Ground{NL}" +
                $"{NL}{base.ToString()}" +
                $"{NL}{NL}Zone Distance: {ZoneDistance}";
        }

    }
}
