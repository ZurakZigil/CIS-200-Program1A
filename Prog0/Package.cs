// Program 1A
// CIS 200-01
// By: M9888
// Due: 9/23/2019

// File: Package.cs 
// This abstract class's prupose is to set the framework for the derived package classes.
// It contians a ToString.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog0
{
    abstract class Package : Parcel
    {
        //double _length, _width, _height, _weight; // backing fields for the dimensions used in this class

        // Precondition:  None
        // Postcondition: The package is created with the specified values for
        //                origin address and destination address as well as dimensions
        public Package(Address originAddress, Address destAddress, double length, double width, double height, double weight)
               : base(originAddress, destAddress)
        {
            Length = length;
            Width = width;
            Height = height;
            Weight = weight;
        }

        public double Length
        {
            // Precondition:  None
            // Postcondition: The length has been returned
            get;
            // Precondition:  none
            // Postcondition: The length has been set
            set;
        }

        public double Width
        {
            // Precondition:  None
            // Postcondition: The width has been returned
            get;
            // Precondition:  none
            // Postcondition: The width has been set
            set;
        }

        public double Height
        {
            // Precondition:  None
            // Postcondition: The height has been returned
            get;
            // Precondition:  none
            // Postcondition: The height has been set
            set;
        }

        public double Weight
        {
            // Precondition:  None
            // Postcondition: The weight has been returned
            get;
            // Precondition:  none
            // Postcondition: The weight has been set
            set;
        }

        // Precondition:  None
        // Postcondition: A String with the data has been returned
        public override string ToString()
        {
            string NL = Environment.NewLine; // NewLine shortcut

            return $"{base.ToString()}" +
                $"{NL}{NL}Dimensions" +
                $"{NL}Length:   {Length}    inches" +
                $"{NL}Width:    {Width}     inches" +
                $"{NL}Height:   {Height}    inches" +
                $"{NL}Weight:   {Weight}    pounds";
        }
    }
}
