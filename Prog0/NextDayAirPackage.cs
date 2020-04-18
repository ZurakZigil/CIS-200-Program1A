// Program 1A
// CIS 200-01
// By: M9888
// Due: 9/23/2019

// File: NextDayAirPackage.cs
// This class's prupose is to allow for the creation of a Next Day Air Package derived from Air Package.
// This class implements the IsHeavy and IsLarge methods defined in AirPackage to adjust the cost of the package.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog0
{
    class NextDayAirPackage : AirPackage
    {
        private const double CONST_SIZE_MULTI = 0.30; // constant used for calculating air package cost for overall size
        private const double CONST_WEIGHT_MULTI = 0.25; // constant used for calculating air package cost for weight
        private const double WEIGHT_AND_LENGTH_MULTI = 0.2; // constant used for calculating air package cost, used if it is heavy or large

        // Precondition:  None
        // Postcondition: The air package is created with the specified values for
        //                origin address and destination address as well as dimensions and express fee
        public NextDayAirPackage(Address originAddress, Address destAddress, double length, double width, double height, double weight, decimal expressFee)
               : base(originAddress, destAddress, length, width, height, weight)
        {
            ExpressFee = expressFee;
        }

        // Precondition:  fee must be a positive number 
        // Postcondition: The fee is returned 
        public decimal ExpressFee
        {
            get;
        }

        // Precondition:  Length Width Height and ZoneDistance must all be greater than 0
        // Postcondition: The package's cost has been returned
        public override decimal CalcCost()
        {
            double baseCost = (CONST_SIZE_MULTI * (Length + Width + Height)) + (CONST_WEIGHT_MULTI * (Weight)) + Convert.ToDouble(ExpressFee); // base cost of a next day air package

            // testing for whether the package is large (defined in air package) or heavy (defined in air package)
            if(IsHeavy() && IsLarge())
            {
                return Convert.ToDecimal(baseCost + (WEIGHT_AND_LENGTH_MULTI * Weight) + (WEIGHT_AND_LENGTH_MULTI * (Length + Width + Height)));
            }
            else if (IsHeavy())
            {
                return Convert.ToDecimal(baseCost + (WEIGHT_AND_LENGTH_MULTI * Weight) );
            }
            else if (IsLarge())
            {
                return Convert.ToDecimal(baseCost + (WEIGHT_AND_LENGTH_MULTI * (Length + Width + Height)));
            }
            else return Convert.ToDecimal(baseCost);
        }

        // Precondition:  None
        // Postcondition: A String with the data has been returned
        public override String ToString()
        {
            string NL = Environment.NewLine; // NewLine shortcut

            return $"Package: Next Day Air{NL}" +
                $"{NL}{base.ToString()}" +
                $"{NL}{NL}Express Fee: {ExpressFee:C}";
        }

    }
}
