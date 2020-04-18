// Program 1A
// CIS 200-01
// By: M9888
// Due: 9/23/2019

// File: TwoDayPackage.cs
// This class's prupose is to allow for the creation of a Two Day Day Air Package derived from Air Package.
// This class uses amd Delivery Type to adjust the cost.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog0
{
    class TwoDayAirPackage : AirPackage
    {
        private const double CONST_SIZE_MULTI = 0.2; // constant used for calculating air package cost for overall size
        private const double CONST_WEIGHT_MULTI = 0.2; // constant used for calculating air package cost for weight
        private const double CONST_SAVER_REDUCT = 0.85; // constant used for calculating two day air package cost, used if it is a "saver"
        public enum Delivery { Early, Saver }; // enums used to specify whether a package is early or a saver (saver reduces cost)

        // Precondition:  None
        // Postcondition: The air package is created with the specified values for
        //                origin address and destination address as well as dimensions and delivery type (saver or early)
        public TwoDayAirPackage(Address originAddress, Address destAddress, double length, double width, double height, double weight, Delivery deliveryType)
               : base(originAddress, destAddress, length, width, height, weight)
        {
            DeliveryType = deliveryType;
        }

        // Precondition:  Delivery type must exist (saver or early) 
        // Postcondition: Delivery type is returned
        public Delivery DeliveryType
        {
            get;
            set;
        }

        // Precondition:  Length Width Height and ZoneDistance must all be greater than 0 and delivery type defined as a saver or early 
        // Postcondition: The package's cost has been returned
        public override decimal CalcCost()
        {
            double baseCost = (CONST_SIZE_MULTI * (Length + Width + Height)) + (CONST_WEIGHT_MULTI * (Weight)); // base cost of a two day air package before determining saver or early

            // logic to adjust price based on being a saver
            if (DeliveryType == Delivery.Saver)
            {
                return Convert.ToDecimal(baseCost * CONST_SAVER_REDUCT);
            }
            else return Convert.ToDecimal(baseCost);
        }

        // Precondition:  None
        // Postcondition: A String with the data has been returned
        public override String ToString()
        {
            string NL = Environment.NewLine; // NewLine shortcut

            return $"Package: Two Day Air ({DeliveryType}){NL}" +
                $"{NL}{base.ToString()}";
        }
    }
}
