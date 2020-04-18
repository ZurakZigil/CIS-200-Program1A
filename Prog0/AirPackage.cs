// Program 1A
// CIS 200-01
// By: M9888
// Due: 9/23/2019

// File: AirPackage.cs
// This abstract class's prupose is to set the framework for the derived air package classes (NextDay mad TwoDay)
// Air packages have a Heavy and a large property to add addional cost.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog0
{
    abstract class AirPackage : Package
    {
        const int CONST_LARGE_PACKAGE = 75; // max size before being considered a large package
        const int CONST_HEAVY_PACKAGE = 50; // max size before being considered a heavy package

        // Precondition:  None
        // Postcondition: The air package is created with the specified values for
        //                origin address and destination address as well as dimensions
        public AirPackage(Address originAddress, Address destAddress, double length, double width, double height, double weight)
               : base(originAddress, destAddress, length, width, height, weight)
        {
            // No body needed
            // based entirely on previous class
        }

        // Precondition:  weight must be a positive number 
        // Postcondition: The bool is returned
        public bool IsHeavy()
        {
            if (Weight <= 0) // validation
            {
                throw new ArgumentOutOfRangeException(nameof(Weight),
                   Weight, $"{nameof(IsHeavy)} must be > 0");
            }
            else
            {
                if (Weight > CONST_HEAVY_PACKAGE)
                {
                    return true;
                }
                else return false;
            }
           
        }

        // Precondition:  Length, Width, and Height must be a positive number 
        // Postcondition: The bool is returned
        public bool IsLarge()
        {
            double value = Length + Width + Height; // value for validation
            if (value <= 0) // validation
            {
                throw new ArgumentOutOfRangeException(nameof(value),
                   value, $"{nameof(IsLarge)} must be > 0");
            }
            else
            {
                if ((Length + Height + Width) > CONST_LARGE_PACKAGE)
                {
                    return true;
                }
                else return false;
            }
            
        }

        // Precondition:  None
        // Postcondition: A String with the data has been returned
        public override String ToString()
        {
            string NL = Environment.NewLine; // NewLine shortcut

            return $"{base.ToString()}" +
                $"{NL}{NL}Classifications" +
                $"{NL}Heavy?: {IsHeavy()}" +
                $"{NL}Large?: {IsLarge()}";
        }

    }
}
